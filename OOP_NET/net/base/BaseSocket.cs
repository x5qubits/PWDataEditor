using Newtonsoft.Json;
using PWDataEditorPaied;
using Shield.classes;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using Shield.classes.oops;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

public class BaseSocketPacket
{
    public int sn = -1;
    public int type = 2;
    public int module;
    public int cmd;
    public Double time;
    public object value;
    public int state;
    public String toString()
    {
        return (((this.module + "_") + this.cmd));
    }
}

public class BaseSocketResponseType
{
        public const int RESPONSE_CODE_ERROR = -1;
        public const int RESPONSE_CODE_USER_TOO_MANY = -100;
        public const int RESPONSE_CODE_SUCCESS = 0;
        public const int RESPONSE_CODE_NO_RESULTS = 1;
        public const int RESPONSE_CODE_RESOLVE_ERROR = 2;
        public const int RESPONSE_CODE_NO_RIGHT = 3;
        public const int RESPONSE_CODE_AUTH_CODE_ERROR = 4;
}

namespace Shield.classes.net
{
    public class BaseSocket
    {
        private int HEADER_LEN = 8;
        private int PACKAGE_HEAD = -1860168940;
        private int _sn = 0;
        private String _host;
        private int _port;
        private Socket _socket;
        private byte[] carragebytes;
        private ByteArray _totalBytes = null;
        private Dictionary<int, int> _stateList;
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone =  new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =  new ManualResetEvent(false);
        private static String response = String.Empty;
        public event EventHandler onDisconect = delegate { };
        public event EventHandler onRecive = delegate { };
        public event EventHandler onSent = delegate { };
        public event EventHandler onConnect = delegate { };

        public void Socket(String host, int port)
        {
            this._host = host;
            this._port = port;
            this._stateList = new Dictionary<int, int>();
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._socket.Blocking = true;
            this._socket.NoDelay = true;
            this._totalBytes = new ByteArray();
            this._socket.SendBufferSize = 20048;
            this._socket.ReceiveBufferSize = 40096;
        }

        public void disconnect()
        {
            try
            {
                Constants.Authed = false;
                this._socket.Shutdown(0);
                try { this._socket.Disconnect(false); } catch { }
            }
            catch { }
        }

        public void connect()
        {
            IPAddress ipAddress = IPAddress.Parse(this._host);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, this._port);
            carragebytes = new byte[9000000];
            this._socket.BeginConnect(remoteEP, new AsyncCallback(onConnectLoc), this._socket);
        }

        private void onConnectLoc(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                dispatchEvent(2, new BaseSocketEvent(BaseSocketEvent.CONNECT, "Socket connected to :" + client.RemoteEndPoint.ToString()));
                connectDone.Set();
                HashMap<string, object> sd = new HashMap<string, object>();
                sd["buildId"] = Constants.build;
                sd["yek"] = Constants.ke;
                BaseSocketPacket packet = new BaseSocketPacket();
                packet.module = Module.USER;
                packet.cmd = Cmd.HEART;
                packet.type = 3;
                packet.value = sd;
                this.Send(packet);
                sendDone.WaitOne();
                this.Receive();
                receiveDone.WaitOne();
                
            }
            catch (Exception e)
            {
                dispatchEvent(0, new BaseSocketEvent(BaseSocketEvent.CLOSE, e.Message.ToString()));
            }
        }

        private void Receive()
        {
            if (!this.connected())
            {
                return;
            }
            try
            {
                this._socket.BeginReceive(this.carragebytes, 0, this.carragebytes.Length, 0, new AsyncCallback(onReceiveLoc), this._socket);
            }
            catch (Exception e)
            {
                dispatchEvent(0, new BaseSocketEvent(BaseSocketEvent.CLOSE, e.Message.ToString()));
            }
        }

        protected void recived(int bytesRead)
        {
            if (!this.connected())
            {
                return;
            }
            try
            {
                int head = 0;
                int len = 0;
                int sn = 0;
                int type = 0;
                int module = 0;
                int cmd = 0;
                Double time = 0;
                int status;
                String protocol = "";
                BaseSocketPacket packet;
                int recevs = bytesRead;
                int length = (int)this._totalBytes.Length();
                this._totalBytes.Write(this.carragebytes, length, recevs);
                this.Receive();
#if DEBUG
                Console.WriteLine("Recived:" + bytesRead + " bytes.");
#endif
                ByteArray bytes = new ByteArray();
                while (this._totalBytes.bytesAvailable() >= this.HEADER_LEN)
                {
                    head = this._totalBytes.ReadInt32();
                    while (head != PACKAGE_HEAD)
                    {
                        this._totalBytes.Position(this._totalBytes.Position() - 3);
                        if (this._totalBytes.bytesAvailable() >= this.HEADER_LEN)
                        {
                            head = this._totalBytes.ReadInt32();
                        }
                        else
                        {
                            return;
                        };
                    };
                    len = this._totalBytes.ReadInt32();
                    if (this._totalBytes.bytesAvailable() < len)
                    {
                        this._totalBytes.Position(this._totalBytes.Position() - this.HEADER_LEN);
                        return;
                    }
                    bytes.clear();
                    this._totalBytes.readBytes(bytes, 0, len);
                    this._totalBytes.clear();
                    sn = bytes.ReadInt32();
                    type = bytes.ReadInt32();
                    module = bytes.ReadInt32();
                    cmd = bytes.ReadInt32();
                    time = bytes.ReadDouble32();
                    status = bytes.ReadInt32();
                    protocol = ((module + "_") + cmd);
#if DEBUG
                    Console.WriteLine("Read toatal:" + bytes.Length() + " bytes, Packet:" + ((module + "_") + cmd));
#endif
                    switch (status)
                    {
                        case BaseSocketResponseType.RESPONSE_CODE_SUCCESS:
                            if (bytes.bytesAvailable() > 0)
                            {
                                packet = new BaseSocketPacket();
                                packet.sn = sn;
                                packet.type = type;
                                packet.module = module;
                                packet.cmd = cmd;
                                packet.time = time;
                                packet.value = bytes.readObject(type);
                                packet.state = (sn != -1 || this._stateList.ContainsKey(sn)) ? this._stateList[sn] : 0;
                                dispatchEvent(1, new BaseSocketEvent(BaseSocketEvent.RECEIVED, protocol, packet));
                                if (this._stateList.ContainsKey(sn))
                                {
                                    this._stateList.Remove(sn);
                                }
                            }
                            break;
                        case BaseSocketResponseType.RESPONSE_CODE_NO_RESULTS:
                            dispatchEvent(1, new BaseSocketEvent(BaseSocketEvent.RESPONSE_CODE_NO_RESULTS, protocol));
                            break;
                        case BaseSocketResponseType.RESPONSE_CODE_RESOLVE_ERROR:
                            dispatchEvent(1, new BaseSocketEvent(BaseSocketEvent.RESPONSE_CODE_RESOLVE_ERROR, protocol));
                            break;
                        case BaseSocketResponseType.RESPONSE_CODE_NO_RIGHT:
                            dispatchEvent(1, new BaseSocketEvent(BaseSocketEvent.RESPONSE_CODE_NO_RIGHT, protocol));
                            break;
                        case BaseSocketResponseType.RESPONSE_CODE_AUTH_CODE_ERROR:
                            dispatchEvent(1, new BaseSocketEvent(BaseSocketEvent.RESPONSE_CODE_AUTH_CODE_ERROR, protocol));
                            break;
                        case BaseSocketResponseType.RESPONSE_CODE_ERROR:
                            dispatchEvent(1, new BaseSocketEvent(BaseSocketEvent.RESPONSE_CODE_ERROR, protocol));
                            break;
                    }
                }
                bytes.clear();
                int bitesav = this._totalBytes.bytesAvailable();
                if (bitesav > 0) // If totalBytes contains bytes avalible
                {
                    this._totalBytes.readBytes(bytes, 0, bitesav);
                };
                this._totalBytes.clear();
                bitesav = bytes.bytesAvailable();
                if (bitesav > 0)
                {
                    bytes.readBytes(this._totalBytes, 0, bitesav);
                };
            }
            catch (JsonException)
            {

                PWAdmin.getInstance().resetallForm(false);
                PWAdmin.getInstance().unlockMaps("Ready");
            }
            catch (Exception e)
            {
                dispatchEvent(0, new BaseSocketEvent(BaseSocketEvent.IO_ERROR, e.Message.ToString()));
            }
        }



        protected void onReceiveLoc(IAsyncResult ar)
        {
            if(!this.connected())
            {
                return;
            }
            try
            {
                int bytesRead = this._socket.EndReceive(ar);
                dispatchEvent(4, null, bytesRead);
            }
            catch { }
        }


        public virtual void Send(BaseSocketPacket packet)
        {
            if (!this.connected())
            {
                return;
            }
            try
            {
                ByteArray values = new ByteArray();
                int sn;
                int validataNumber;
                ByteArray output;
                long len;
                values.writeInt(packet.module);
                values.writeInt(packet.cmd);
                if (packet.value != null)
                {
                    values.writeObject(packet.value as HashMap<string, object>);
                };
                sn = this.getSn();
           //     if (packet.state != -1){
                    this._stateList[sn] = packet.state;
               // };
                byte[] value = values.Consume();
                validataNumber = this.fnvHash(value);
                output = new ByteArray();
                output.writeInt(sn);
                output.writeInt(packet.type);
                output.writeInt(validataNumber);
                output.writeBytes(value);
                len = output.Length();
                byte[] dass = output.Consume();
                ByteArray packetx = new ByteArray();
                packetx.writeInt(PACKAGE_HEAD);
                packetx.writeInt((int)len);
                packetx.writeBytes(dass);
                byte[] toSend = packetx.Consume();
                this._socket.BeginSend(toSend, 0, toSend.Length, 0, new AsyncCallback(onSendLoc), this._socket);
#if DEBUG
                Console.WriteLine("Sent:" + toSend.Length + " bytes, Packet:" + ((packet.module + "_") + packet.cmd));
#endif
            }
            catch (Exception e)
            {
                dispatchEvent(0, new BaseSocketEvent(BaseSocketEvent.IO_ERROR, e.Message.ToString()));
            }
        }

        private void onSendLoc(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
                sendDone.Set();
                dispatchEvent(3, new BaseSocketEvent(BaseSocketEvent.SENT, ""+bytesSent));
            }
            catch (Exception e)
            {
                dispatchEvent(0, new BaseSocketEvent(BaseSocketEvent.IO_ERROR, e.Message.ToString()));
            }
        }

        public Boolean connected()
        {
            try
            {
                if(this._socket == null)
                {
                    return false;
                }
                return this._socket.Connected;
            }
            catch (Exception e) {
                dispatchEvent(0, new BaseSocketEvent(BaseSocketEvent.CLOSE, e.Message.ToString()));
                return false;
            }
        }


        private int fnvHash(byte[] data)
        {
            int seed = 16777619;
            int hash = -2128831035;
            byte[] arrby = data;
            int n = arrby.Length;
            int n2 = 0;
            while (n2 < n)
            {
                byte b = arrby[n2];
                hash = (hash ^ b) * seed;
                ++n2;
            }
            hash += hash << 7;
            hash ^= hash >> 6;
            hash += hash << 3;
            hash ^= hash >> 8;
            hash += hash << 1;
            return hash;
        }

        private int getSn()
        {
            this._sn++;
            if (this._sn == int.MaxValue)
            {
                this._sn = 1;
            };
            return (this._sn);
        }

        private void dispatchEvent(int a, BaseSocketEvent data, int rec = 0)
        {
            //Thread t = null;
            switch (a)
            {
                case 1:
                    // t = new Thread(new ThreadStart(() => { onRecive(this, data); }));
                    // t.Start();
                    try
                    {
                        onRecive(this, data);
                    }
                    catch { }
                        break;
                case 2:
                    // t = new Thread(new ThreadStart(() => { onConnect(this, data); }));
                    //  t.Start();
                    try
                    {
                        onConnect(this, data);
                    }
                    catch { }
                    break;
                case 0:
                    // t = new Thread(new ThreadStart(() => { onDisconect(this, data); }));
                    // t.Start();
                    try
                    {
                        onDisconect(this, data);
                    }
                    catch { }
                    break;
                case 3:
                    //t = new Thread(new ThreadStart(() => { onSent(this, data); }));
                    // t.Start();
                    try
                    {
                        onSent(this, data);
                    }
                    catch { }
                    break;
                case 4:
                    try
                    {
                        this.recived(rec);
                    }
                    catch { }
                    break;
            }
        }
    }
}
