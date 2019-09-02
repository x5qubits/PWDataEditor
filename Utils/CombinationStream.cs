﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Ultimate_Editor.Clases.Utils
{
    public class CombinationStream : Stream
    {

        private readonly IList<Stream> _streams;
        private readonly IList<int> _streamsToDispose;
        private readonly IList<long> _streamsStartPos;
        private int _currentStreamIndex;
        private Stream _currentStream;
        private long _length = -1;
        private long _postion;

        public CombinationStream(IList<Stream> streams) : this(streams, null) { }

        public CombinationStream(IList<Stream> streams, IList<int> streamsToDispose)
        {
            if (streams == null)
                throw new ArgumentNullException("streams");

            _streams = streams;
            _streamsToDispose = streamsToDispose;
            if (streams.Count > 0)
                _currentStream = streams[_currentStreamIndex++];

            _streamsStartPos = new List<long>(streams.Count);
            long pos = 0;
            foreach (var strm in streams)
            {
                _streamsStartPos.Add(pos);
                pos += strm.Length;
            }
        }

        public IList<Stream> InternalStreams { get { return _streams; } }

        public override void Flush()
        {
            if (_currentStream != null)
                _currentStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long pos = 0;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    pos = offset;
                    break;
                case SeekOrigin.Current:
                    pos = this.Position + offset;
                    break;
                case SeekOrigin.End:
                    pos = Length + offset;
                    break;
            }
            int idx = 0;
            while (idx + 1 < _streamsStartPos.Count)
            {
                if (_streamsStartPos[idx + 1] > pos)
                {
                    break;
                }
                idx++;
            }

            _currentStreamIndex = idx;
            _currentStream = _streams[_currentStreamIndex];
            _currentStream.Seek(pos - _streamsStartPos[idx], SeekOrigin.Begin);
            _postion = pos;
            return _postion;
            //throw new InvalidOperationException("Stream is not seekable.");
        }

        public override void SetLength(long value)
        {
            _length = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int result = 0;
            int buffPostion = offset;

            while (count > 0)
            {
                int bytesRead = _currentStream.Read(buffer, buffPostion, count);
                result += bytesRead;
                buffPostion += bytesRead;
                _postion += bytesRead;

                if (bytesRead <= count)
                    count -= bytesRead;

                if (count > 0)
                {
                    if (_currentStreamIndex >= _streams.Count)
                        break;

                    _currentStream = _streams[_currentStreamIndex++];
                }
            }

            return result;
        }

#if NETFX_CORE

public async override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
{
    int result = 0;
    int buffPostion = offset;

    while (count > 0)
    {
        int bytesRead = await _currentStream.ReadAsync(buffer, buffPostion, count, cancellationToken);
        result += bytesRead;
        buffPostion += bytesRead;
        _postion += bytesRead;

        if (bytesRead <= count)
            count -= bytesRead;

        if (count > 0)
        {
            if (_currentStreamIndex >= _streams.Count)
                break;

            _currentStream = _streams[_currentStreamIndex++];
        }
    }

    return result;
}

public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
{
    throw new InvalidOperationException("Stream is not writable");
}

#else
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CombinationStreamAsyncResult asyncResult = new CombinationStreamAsyncResult(state);
            if (count > 0)
            {
                int buffPostion = offset;

                AsyncCallback rc = null;
                rc = readresult =>
                {
                    try
                    {
                        int bytesRead = _currentStream.EndRead(readresult);
                        asyncResult.BytesRead += bytesRead;
                        buffPostion += bytesRead;
                        _postion += bytesRead;

                        if (bytesRead <= count)
                            count -= bytesRead;

                        if (count > 0)
                        {
                            if (_currentStreamIndex >= _streams.Count)
                            {
                            // done
                            asyncResult.CompletedSynchronously = false;
                                asyncResult.SetAsyncWaitHandle();
                                asyncResult.IsCompleted = true;
                                callback(asyncResult);
                            }
                            else
                            {
                                _currentStream = _streams[_currentStreamIndex++];
                                _currentStream.BeginRead(buffer, buffPostion, count, rc, readresult.AsyncState);
                            }
                        }
                        else
                        {
                        // done
                        asyncResult.CompletedSynchronously = false;
                            asyncResult.SetAsyncWaitHandle();
                            asyncResult.IsCompleted = true;
                            callback(asyncResult);
                        }
                    }
                    catch (Exception ex)
                    {
                    // done
                    asyncResult.Exception = ex;
                        asyncResult.CompletedSynchronously = false;
                        asyncResult.SetAsyncWaitHandle();
                        asyncResult.IsCompleted = true;
                        callback(asyncResult);
                    }
                };
                _currentStream.BeginRead(buffer, buffPostion, count, rc, state);
            }
            else
            {
                // done
                asyncResult.CompletedSynchronously = true;
                asyncResult.SetAsyncWaitHandle();
                asyncResult.IsCompleted = true;
                callback(asyncResult);
            }

            return asyncResult;
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            // todo: check if it is of same reference
            asyncResult.AsyncWaitHandle.WaitOne();
            var ar = (CombinationStreamAsyncResult)asyncResult;
            if (ar.Exception != null)
            {
                throw ar.Exception;
            }

            return ar.BytesRead;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new InvalidOperationException("Stream is not writable");
        }

        internal class CombinationStreamAsyncResult : IAsyncResult
        {
            private readonly object _asyncState;

            public CombinationStreamAsyncResult(object asyncState)
            {
                _asyncState = asyncState;
                _manualResetEvent = new ManualResetEvent(false);
            }

            public bool IsCompleted { get; internal set; }

            public WaitHandle AsyncWaitHandle
            {
                get { return _manualResetEvent; }
            }

            public object AsyncState
            {
                get { return _asyncState; }
            }

            public bool CompletedSynchronously { get; internal set; }

            public Exception Exception { get; internal set; }

            internal void SetAsyncWaitHandle()
            {
                _manualResetEvent.Set();
            }

            private readonly ManualResetEvent _manualResetEvent;
            public int BytesRead;
        }

#endif

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException("Stream is not writable");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try
            {
                if (_streamsToDispose == null)
                {
                    foreach (var stream in InternalStreams)
                        stream.Dispose();
                }
                else
                {
                    int i;
                    for (i = 0; i < InternalStreams.Count; i++)
                        InternalStreams[i].Dispose();
                }
            }
            catch { }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get
            {
                if (_length == -1)
                {
                    _length = 0;
                    foreach (var stream in _streams)
                        _length += stream.Length;
                }

                return _length;
            }
        }

        public override long Position
        {
            get { return _postion; }
            set { throw new NotImplementedException(); }
        }
    }
}
