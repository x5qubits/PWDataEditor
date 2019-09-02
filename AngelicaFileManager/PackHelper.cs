using ComponentAce.Compression.Libs.zlib;
using Gpckx;
using JHUI;
using Pck_Guy_View;
using PWDataEditorPaied.Game_Shop_classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultimate_Editor.Clases.Utils;

namespace Ultimate_Editor.Clases.AngelicaFileManager
{
    public class PackHelper
    {
        #region VARS
        private CombinationStream stream = null;
        private List<Stream> streams = null;
        public PackStructureManager directoryStructure = null;
        private int KEY_1 = -1466731422;
        private int KEY_2 = -240896429;
        public int ASIG_1 = -33685778;
        public int ASIG_2 = -267534609;
        public int FSIG_1 = 1305093103;
        public int FSIG_2 = 1453361591;
        private bool disposed = true;
        public bool initiated = false;
        private bool modified = false;
        public string path;
        public Action ReadTableIsDone;
        private BinaryReader br;
        public SortedList<int, PckEntry> table;
        private long fileTableOffset;
        public short version;
        private int initialCount = 0;
        private bool isReading = false;

        public int CompressionLevel { get; set; } = 1;
        public delegate void UpdateProgressDelegate(string value, int min, int max);
        public event UpdateProgressDelegate progress_bar;

        #endregion
        #region CONSTRUCTOR
        public PackHelper(string path, bool isThred = true)
        {
            
            if (!File.Exists(path))
            {
                return;
            }
            table = null;
            directoryStructure = null;
            GC.Collect();
            modified = false;
            this.path = path;
            directoryStructure = new PackStructureManager(Path.GetFileNameWithoutExtension(path));
            MakeStreams();
            if (isThred)
            {
                Thread th = new Thread(() => ReadTable());
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                ReadTable();
            }


            disposed = false;
        }
        #endregion
        #region UTILES
        public void CreateDir(string path, string subpath)
        {
            string[] subdirs = subpath.Split(new char[] { '\\' });
            for (int a = 0; a < subdirs.Length - 1; ++a)
            {
                path += "\\" + subdirs[a];
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        public void deleteFile(int[] ids)
        {
            foreach (int id in ids)
            {
                if (table.ContainsKey(id))
                {
                    modified = true;
                    table.Remove(id);
                }
            }
            table = resortDic(table);
        }

        private SortedList<int, PckEntry> resortDic(SortedList<int, PckEntry> data)
        {
            SortedList<int, PckEntry> datanew = new SortedList<int, PckEntry>();
            int i = 0;
            foreach (KeyValuePair<int, PckEntry> entry in data)
            {
                datanew[i] = entry.Value;
                datanew[i].id = i;
                i++;
            }
            return datanew;
        }


        public void addFilesToTable(string Directory, string FilePaths)
        {

            PckEntry data = table.Values.FirstOrDefault(x => x.filePath.ToLower().Equals(Directory));
            if (data != null)
            {
                data.filePath = Directory;
                data.bytes = File.ReadAllBytes(FilePaths);
                data.bytesCompresed = PCKZlib.Compress(data.bytes, CompressionLevel);
                data.fileoffset = (uint)0;
                data.compressedSize = data.bytesCompresed.Length;
                data.decompressedSize = data.bytes.Length;
                table[data.id] = data;
                modified = true;
            }
            else
            {
                data = new PckEntry(version);
                data.filePath = Directory;
                data.bytes = File.ReadAllBytes(FilePaths);
                data.bytesCompresed = PCKZlib.Compress(data.bytes, CompressionLevel);
                data.fileoffset = (uint)0;
                data.compressedSize = data.bytesCompresed.Length;
                data.decompressedSize = data.bytes.Length;
                data.id = table.Count;
                table.Add(data.id, data);
                directoryStructure.addfille(data);
                modified = true;
            }
        }

        private void MakeStreams()
        {
            if (disposed)
            {
                streams = new List<Stream>();
                if (File.Exists(path))
                {
                    streams.Add(File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
                }
                string pkx = path.Replace(".pck", ".pkx");
                if (File.Exists(pkx))
                {
                    streams.Add(File.Open(pkx, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
                }
                stream = new CombinationStream(streams);
                br = new BinaryReader(stream);
                disposed = false;
            }
        }
        public void Dispose()
        {
            if (isReading)
                return;

            stream.Dispose();
            br.Dispose();
            if (streams != null)
            {
                for (int i = 0; i < streams.Count; i++)
                {
                    streams[i] = null;
                }
                streams.Clear();
            }
            streams = null;
            disposed = true;
        }
        public void CopyStream(Stream input, Stream output, int Size)
        {
            try
            {
                byte[] buffer = new byte[Size];
                int len;
                while ((len = input.Read(buffer, 0, Size)) > 0)
                {
                    output.Write(buffer, 0, len);
                }
                output.Flush();
            }
            catch
            {
            }
        }
        #endregion
        #region READ
        private void ReadTable()
        {
            isReading = true;
            initialCount = 0;
            int maxCount = 100;
            int cnow = 0;
            int entryCount = 0;
            try
            {
                br.BaseStream.Seek(-4, SeekOrigin.End);
                version = br.ReadInt16();
                br.BaseStream.Seek(-8, SeekOrigin.End);
                entryCount = br.ReadInt32();
                if (maxCount > 1000)
                    maxCount = entryCount / 100;
                else
                    maxCount = entryCount / 10;

                if (maxCount <= 1)
                {
                    maxCount = 1;
                }
                br.BaseStream.Seek(version == 2 ? -272 : -280, SeekOrigin.End);

                fileTableOffset = (long)((ulong)((uint)(br.ReadUInt32() ^ (ulong)KEY_1)));
                br.BaseStream.Seek(fileTableOffset, SeekOrigin.Begin);
                table = new SortedList<int, PckEntry>();
                for (int a = 0; a < entryCount; ++a)
                {
                    if (progress_bar != null && cnow > maxCount)
                    {
                        progress_bar("Reading files ....", a, entryCount);
                        cnow = 0;
                    }
                    cnow++;
                    int entrySize = br.ReadInt32() ^ KEY_1;
                    entrySize = br.ReadInt32() ^ KEY_2;
                    byte[] buffer = new byte[entrySize];
                    buffer = br.ReadBytes(entrySize);
                    table[a] = new PckEntry(buffer, version);
                    table[a].id = a;
                    directoryStructure.addfille(table[a]);
                }
            }
            catch { }
            disposed = false;
            initiated = true;
            initialCount = table.Count();
            if(progress_bar != null)
            progress_bar("Reading files ....", entryCount, entryCount);
            if (ReadTableIsDone != null)
                ReadTableIsDone.Invoke();

            isReading = false;
            this.Dispose();
        }

        public List<PckEntry> getDirectory(string files, bool isFileNameOnly = false, string fileName = "")
        {
            List<PckEntry> xx = directoryStructure.GetDirectory(files, isFileNameOnly, fileName);
            int maxCount = 1;
            int entryCount = xx.Count;
            int cnow = 0;

            if (maxCount > 1000)
                maxCount = entryCount / 100;
            else
                maxCount = entryCount / 10;

            if (maxCount <= 1)
            {
                maxCount = 1;
            }

            for (int i = 0; i < xx.Count; i++)
            {
                if (progress_bar != null && cnow > maxCount)
                {
                    progress_bar("Extracting files ....", i, entryCount);
                    cnow = 0;
                }
                cnow++;
                xx[i] = GetFile(xx[i]);
            }
            return xx;
        }

        public byte[] getChunk(string packPath, PckEntry table)
        {
            if (table.bytes != null)
            {
                return table.bytes;
            }
            MakeStreams();
            byte[] buffer = new byte[table.compressedSize];
            table.fullP = table.filePath;
            br.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);
            buffer = br.ReadBytes(table.compressedSize);
            br.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);

            if (table.compressedSize < table.decompressedSize)
            {
                MemoryStream ms = new MemoryStream();
                ZOutputStream zos = new ZOutputStream(ms);
                CopyStream(new MemoryStream(buffer), zos, table.compressedSize);
                return ms.ToArray();
            }
            else
            {
                return buffer;
            }
        }
        public byte[] getChunk2(string packPath, PckEntry table)
        {
            if (table.bytes != null)
            {
                return table.bytes;
            }
            
            byte[] buffer = new byte[table.compressedSize];
            table.fullP = table.filePath;
            br.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);
            buffer = br.ReadBytes(table.compressedSize);
            br.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);

            if (table.compressedSize < table.decompressedSize)
            {
                MemoryStream ms = new MemoryStream();
                ZOutputStream zos = new ZOutputStream(ms);
                CopyStream(new MemoryStream(buffer), zos, table.compressedSize);
                return ms.ToArray();
            }
            else
            {
                return buffer;
            }
        }
        public PckEntry GetFile(PckEntry table, bool isRaw = false, bool returnOnlyRaw = false)
        {
            if (table.bytes != null)
            {
                return table;
            }
            MakeStreams();
            byte[] buffer = new byte[table.compressedSize];
            table.fullP = table.filePath;
            br.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);
            buffer = br.ReadBytes(table.compressedSize);
            br.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);
            if(isRaw)
            {
                table.bytesCompresed = buffer;
                if(returnOnlyRaw)
                    return table;
            }
            if (table.compressedSize < table.decompressedSize)
            {
                MemoryStream ms = new MemoryStream();
                ZOutputStream zos = new ZOutputStream(ms);
                CopyStream(new MemoryStream(buffer), zos, table.compressedSize);
                table.bytes = ms.ToArray();
                return table;
            }
            else
            {
                table.bytes = buffer;
                return table;
            }
        }

        #endregion
        #region WRITE
        public void pack()
        {
           // throw new NotImplementedException();
        }
        /// <summary>
        /// Returns 0 success
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            if (path != null && path.Length > 0)
            {
                if(initialCount > table.Count)
                {
                    return ReWrite();
                }
                if(!modified)
                {
                    DialogResult res = JMessageBox.Show(PackView.Instance, "The archive has not been modified do you wish to rewirte it?","Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if(res == DialogResult.Yes)
                    {
                        return ReWrite();
                    }
                    else
                    {
                        return 0;
                    }
                }
                this.Dispose();
                PCKStream stream = new PCKStream(path);

                if (stream != null)
                {
                    stream.Seek(fileTableOffset, SeekOrigin.Begin);
                    //Write new files
                    PckEntry[] values = table.Values.ToArray();
                    for (int i = 0; i < values.Length; i++)
                    {
                        PckEntry fte = values[i];
                        if (fte.bytesCompresed != null)
                        {
                            fte.fileoffset = (uint)stream.Position;
                            stream.WriteBytes(fte.bytesCompresed);
                        }
                    }
                    uint fileTableOffset_tmp = (uint)stream.Position;
                    //RewriteTable
                    progress_bar("Finalizing Pack...", 0, 0);
                    MemoryStream FileTable = new MemoryStream();
                    for (int i = 0; i < values.Length; i++)
                    {
                        PckEntry fte = values[i];
                        byte[] buffer = fte.Write(CompressionLevel);
                        lock (FileTable)
                        {
                            FileTable.Write(BitConverter.GetBytes(buffer.Length ^ KEY_1), 0, 4);
                            FileTable.Write(BitConverter.GetBytes(buffer.Length ^ KEY_2), 0, 4);
                            FileTable.Write(buffer, 0, buffer.Length);
                        }
                        progress_bar("Finalizing Pack...", i, values.Length);
                    }
                    stream.WriteBytes(FileTable.ToArray());
                    FileTable.Flush();
                    FileTable.Dispose();
                    stream.WriteInt32(ASIG_1);
                    stream.WriteInt16(version);
                    stream.WriteInt16(2);
                    stream.WriteUInt32((uint)(fileTableOffset_tmp ^ KEY_1));
                    if (version > 2)
                        stream.WriteInt32(-1);
                    stream.WriteInt32(0);
                    NameChar namechar = new NameChar(252);
                    namechar.DefaultEncoding = Encoding.Default;
                    namechar.Name = "Angelica File Package, writed by JHS Software.";
                    stream.WriteBytes(namechar.EncodedName);
                    stream.WriteInt32(ASIG_2);
                    if (version > 2)
                        stream.WriteInt32(512);
                    stream.WriteInt32(table.Count);
                    stream.WriteInt16(version);
                    stream.WriteInt16(2);
                    stream.Seek(4, SeekOrigin.Begin);
                    stream.WriteUInt32((uint)stream.GetLenght());
                    stream.Dispose();
                    progress_bar("Clearing memory...", 0, 0);
                    foreach (PckEntry fte in table.Values)
                    {
                        table[fte.id].bytes = null;
                        table[fte.id].bytesCompresed = null;
                        table[fte.id].memory = null;
                    }
                    GC.Collect();
                    return 0;//SUccess
                }else
                {
                    return 3;//CANNOT OPEN STREAM;
                }
            }
            else
            {
                if(path == null)
                    return 1; //PATH NULL
                else if (path != null && path.Length == 0)
                    return 1; //PATH NULL
                else
                    return 2;// NOT MODIFIED
            }
        }

        public int ReWrite()
        {
            string pathx = path + ".files\\";
            DialogResult result = DialogResult.No;
            if (Directory.Exists(pathx))
                result = MessageBox.Show("Found files on disk do you want to rewrite from files?", "Question",MessageBoxButtons.YesNo);
            #region AAAAA
            if (result == DialogResult.No)
            {
                LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(Environment.ProcessorCount / 2);
                List<Task> tasks = new List<Task>();
                TaskFactory factory = new TaskFactory(lcts);
                CancellationTokenSource cts = new CancellationTokenSource();
                MakeStreams();
                if (path != null && path.Length > 0)
                {
                    PckEntry[] values = table.Values.ToArray();
                    int count = values.Length;
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i].bytesCompresed == null)
                        {
                            PckEntry pck = values[i];
                            byte[] data = getChunk2("", pck);
                            progress_bar("Reading files ....", i, count);
                            Task t1 = factory.StartNew((o) =>
                            {
                                progress_bar("Compressing files ....", (int)o, count);
                                pck.bytesCompresed = PCKZlib.Compress(data, CompressionLevel);
                            },i, cts.Token);
                            tasks.Add(t1);
                        }
                    }
                    progress_bar("Please Wait", 0, 0);
                    Task.WaitAll(tasks.ToArray());
                    Thread.Sleep(500);
                    cts.Dispose();
                    initialCount = count;
                    this.Dispose();
                    if (File.Exists(path))
                        File.Delete(path);
                    if (File.Exists(path.Replace(".pck", ".pkx")))
                        File.Delete(path.Replace(".pck", ".pkx"));

                    PCKStream stream = new PCKStream(path);
                    stream.WriteInt32(stream.key.FSIG_1);
                    stream.WriteInt32(0);
                    stream.WriteInt32(stream.key.FSIG_2);
                    for (int i = 0; i < values.Length; i++)
                    {
                        PckEntry fte = values[i];
                        fte.setVersion(version);
                       
                        progress_bar("Writing files ....", i, count);
                        fte.fileoffset = (uint)stream.Position;
                        stream.WriteBytes(fte.bytesCompresed);                     
                    }
                    uint fileTableOffset_tmp = (uint)stream.Position;
                    MemoryStream FileTable = new MemoryStream();
                    for (int i = 0; i < values.Length; i++)
                    {
                        PckEntry fte = values[i];
                        fte.setVersion(version);
                        byte[] buffer = fte.Write(CompressionLevel);
                        lock (FileTable)
                        {
                            FileTable.Write(BitConverter.GetBytes(buffer.Length ^ KEY_1), 0, 4);
                            FileTable.Write(BitConverter.GetBytes(buffer.Length ^ KEY_2), 0, 4);
                            FileTable.Write(buffer, 0, buffer.Length);
                        }
                        progress_bar("Writing table...", i, count);
                    }
                    stream.WriteBytes(FileTable.ToArray());
                    FileTable.Flush();
                    FileTable.Dispose();
                    stream.WriteInt32(ASIG_1);
                    stream.WriteInt16(version);
                    stream.WriteInt16(2);
                    stream.WriteUInt32((uint)(fileTableOffset_tmp ^ KEY_1));
                    if (version > 2)
                        stream.WriteInt32(-1);
                    stream.WriteInt32(0);
                    NameChar namechar = new NameChar(252);
                    namechar.DefaultEncoding = Encoding.Default;
                    namechar.Name = "Angelica File Package, writed by JHS Software.";
                    stream.WriteBytes(namechar.EncodedName);
                    stream.WriteInt32(ASIG_2);
                    if (version > 2)
                        stream.WriteInt32(512);
                    stream.WriteInt32(table.Count);
                    stream.WriteInt16(version);
                    stream.WriteInt16(2);
                    stream.Seek(4, SeekOrigin.Begin);
                    stream.WriteUInt32((uint)stream.GetLenght());
                    stream.Dispose();
                    progress_bar("Clearing memory...", 0, 0);
                    for (int i = 0; i < values.Length; i++)
                    {
                        PckEntry fte = values[i];
                        table[fte.id].bytes = null;
                        table[fte.id].bytesCompresed = null;
                        table[fte.id].memory = null;
                        progress_bar("Clearing memory...", i, count);
                    }
                    GC.Collect();
                    progress_bar("Ready", 0, 0);
                }
            }
            else
            #endregion
            #region FROM DISK
            {
                directoryStructure = null;
                GC.Collect();
                modified = false;
                directoryStructure = new PackStructureManager(Path.GetFileNameWithoutExtension(path));
                table = new SortedList<int, PckEntry>();
                string[] files = Directory.GetFiles(pathx, "*", SearchOption.AllDirectories);

                int count = files.Length;
                initialCount = count;
                this.Dispose();
                if (File.Exists(path))
                    File.Delete(path);
                if (File.Exists(path.Replace(".pck", ".pkx")))
                    File.Delete(path.Replace(".pck", ".pkx"));

                PCKStream stream = new PCKStream(path);
                stream.WriteInt32(stream.key.FSIG_1);
                stream.WriteInt32(0);
                stream.WriteInt32(stream.key.FSIG_2);
                for (int i = 0; i < files.Length; i++)
                {
                    string file = files[i].Replace(pathx, "").Replace("/", "\\");
                    string pathr = Path.Combine(pathx, file);
                    PckEntry data = new PckEntry(version);
                    data.filePath = file;
                    byte[] datab = File.ReadAllBytes(pathr);
                    byte[] bytesCompresed = PCKZlib.Compress(datab, CompressionLevel);
                    data.compressedSize = bytesCompresed.Length;
                    data.decompressedSize = datab.Length;
                    data.id = i;
                    progress_bar("Writing files ....", i, count);
                    data.fileoffset = (uint)stream.Position;
                    stream.WriteBytes(bytesCompresed);
                    table[i] = data;
                    directoryStructure.addfille(table[i]);
                }
                progress_bar("Please Wait", 0, 0);
                Application.DoEvents();
                uint fileTableOffset_tmp = (uint)stream.Position;
                MemoryStream FileTable = new MemoryStream();
                progress_bar("Finalizing Pack...", 0, 0);
                for (int i = 0; i < table.Count; i++)
                {
                    PckEntry fte = table[i];
                    byte[] buffer = fte.Write(CompressionLevel);
                    lock (FileTable)
                    {
                        FileTable.Write(BitConverter.GetBytes(buffer.Length ^ KEY_1), 0, 4);
                        FileTable.Write(BitConverter.GetBytes(buffer.Length ^ KEY_2), 0, 4);
                        FileTable.Write(buffer, 0, buffer.Length);
                    }
                    progress_bar("Finalizing Pack...", i, count);
                }
                stream.WriteBytes(FileTable.ToArray());
                FileTable.Flush();
                FileTable.Dispose();
                stream.WriteInt32(ASIG_1);
                stream.WriteInt16(version);
                stream.WriteInt16(2);
                stream.WriteUInt32((uint)(fileTableOffset_tmp ^ KEY_1));
                if (version > 2)
                    stream.WriteInt32(-1);
                stream.WriteInt32(0);
                NameChar namechar = new NameChar(252);
                namechar.DefaultEncoding = Encoding.Default;
                namechar.Name = "Angelica File Package, writed by JHS Software.";
                stream.WriteBytes(namechar.EncodedName);
                stream.WriteInt32(ASIG_2);
                if (version > 2)
                    stream.WriteInt32(512);
                stream.WriteInt32(table.Count);
                stream.WriteInt16(version);
                stream.WriteInt16(2);
                stream.Seek(4, SeekOrigin.Begin);
                stream.WriteUInt32((uint)stream.GetLenght());
                stream.Dispose();
                progress_bar("Clearing memory...", 0, 0);
                for (int i = 0; i < table.Count; i++)
                {
                    table[i].bytes = null;
                    table[i].bytesCompresed = null;
                    table[i].memory = null;
                    progress_bar("Clearing memory...", i, count);
                }
                GC.Collect();
                progress_bar("Ready", 0, 0);
            }
            #endregion
            return 0;//SUccess
        }

        public void unpack(bool isThread = false, Action callAfterCompleate = null)
        {
            // Task<bool>[] taskList = {
            //    Task.Run(() =>
            // {
            MakeStreams();

            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(Environment.ProcessorCount / 2);
            List<Task> tasks = new List<Task>();

            // Create a TaskFactory and pass it our custom scheduler. 
            TaskFactory factory = new TaskFactory(lcts);
            CancellationTokenSource cts = new CancellationTokenSource();
            new Thread(() =>
            {
                try
                {
                    var listOfTasks = new List<Task>();
                    if (table.Count > 0 && path != null && path.Length > 0)
                    {
                        string pathx = path + ".files\\";
                        if (Directory.Exists(pathx))
                        {
                            try
                            {
                                Directory.Delete(pathx, true);
                            }
                            catch { }
                        }

                        PckEntry[] files = table.Values.ToArray();
                        for (int i = 0; i < files.Length; i++)
                        {
                            
                            PckEntry pck = files[i];
                            CreateDir(pathx, pck.filePath);
                            if (pck.bytes == null)
                            {
                                byte[] data = getChunk2("", pck);
                                if (data != null)
                                {
                                    Task t1 = factory.StartNew((o) => {
                                        progress_bar("Unpacking..", (int)i, files.Length);
                                        File.WriteAllBytes(pathx + pck.filePath, data);
                                    },i,cts.Token);
                                    tasks.Add(t1);
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                if (pck.bytes != null)
                                {
                                    File.WriteAllBytes(pathx + pck.filePath, pck.bytes);
                                }
                            }
                        }
                        Task.WaitAll(tasks.ToArray());
                        Thread.Sleep(500);
                        cts.Dispose();

                    }
                    if (callAfterCompleate != null)
                    {
                        callAfterCompleate.Invoke();
                    }
                }
                catch
                {
                    
                }
            }).Start();

            //   })
            // };
            // Task.WaitAll(taskList);
        }
        #endregion
        public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
        {
            // Indicates whether the current thread is processing work items.
            [ThreadStatic]
            private static bool _currentThreadIsProcessingItems;

            // The list of tasks to be executed 
            private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)

            // The maximum concurrency level allowed by this scheduler. 
            private readonly int _maxDegreeOfParallelism;

            // Indicates whether the scheduler is currently processing work items. 
            private int _delegatesQueuedOrRunning = 0;

            // Creates a new instance with the specified degree of parallelism. 
            public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
            {
                if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
                _maxDegreeOfParallelism = maxDegreeOfParallelism;
            }

            // Queues a task to the scheduler. 
            protected sealed override void QueueTask(Task task)
            {
                // Add the task to the list of tasks to be processed.  If there aren't enough 
                // delegates currently queued or running to process tasks, schedule another. 
                lock (_tasks)
                {
                    _tasks.AddLast(task);
                    if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                    {
                        ++_delegatesQueuedOrRunning;
                        NotifyThreadPoolOfPendingWork();
                    }
                }
            }

            // Inform the ThreadPool that there's work to be executed for this scheduler. 
            private void NotifyThreadPoolOfPendingWork()
            {
                ThreadPool.UnsafeQueueUserWorkItem(_ =>
                {
                    // Note that the current thread is now processing work items.
                    // This is necessary to enable inlining of tasks into this thread.
                    _currentThreadIsProcessingItems = true;
                    try
                    {
                        // Process all available items in the queue.
                        while (true)
                        {
                            Task item;
                            lock (_tasks)
                            {
                                // When there are no more items to be processed,
                                // note that we're done processing, and get out.
                                if (_tasks.Count == 0)
                                {
                                    --_delegatesQueuedOrRunning;
                                    break;
                                }

                                // Get the next item from the queue
                                item = _tasks.First.Value;
                                _tasks.RemoveFirst();
                            }

                            // Execute the task we pulled out of the queue
                            base.TryExecuteTask(item);
                        }
                    }
                    // We're done processing items on the current thread
                    finally { _currentThreadIsProcessingItems = false; }
                }, null);
            }

            // Attempts to execute the specified task on the current thread. 
            protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
            {
                // If this thread isn't already processing a task, we don't support inlining
                if (!_currentThreadIsProcessingItems) return false;

                // If the task was previously queued, remove it from the queue
                if (taskWasPreviouslyQueued)
                    // Try to run the task. 
                    if (TryDequeue(task))
                        return base.TryExecuteTask(task);
                    else
                        return false;
                else
                    return base.TryExecuteTask(task);
            }

            // Attempt to remove a previously scheduled task from the scheduler. 
            protected sealed override bool TryDequeue(Task task)
            {
                lock (_tasks) return _tasks.Remove(task);
            }

            // Gets the maximum concurrency level supported by this scheduler. 
            public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

            // Gets an enumerable of the tasks currently scheduled on this scheduler. 
            protected sealed override IEnumerable<Task> GetScheduledTasks()
            {
                bool lockTaken = false;
                try
                {
                    Monitor.TryEnter(_tasks, ref lockTaken);
                    if (lockTaken) return _tasks;
                    else throw new NotSupportedException();
                }
                finally
                {
                    if (lockTaken) Monitor.Exit(_tasks);
                }
            }
        }
    }
}
