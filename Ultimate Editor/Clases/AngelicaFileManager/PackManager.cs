using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Pck_Guy_View;
using System.IO.MemoryMappedFiles;
using System.Threading;
using ComponentAce.Compression.Libs.zlib;

namespace Gpckx
{
    public class PckEntry
    {
        public String packPath { get; set; }
        public String filePath { get; set; }
        public String fullP { get; set; }
        public MemoryStream memory { get; set; }
        public MemoryStream memoryun { get; set; }
        public uint fileoffset { get; set; }
        public int decompressedSize { get; set; }
        public int compressedSize { get; set; }
        public String filetobeadded { get; set; }
    }

    public class PackManager
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        public int KEY_1 = -1466731422;
        public int KEY_2 = -240896429;
        public int ASIG_1 = -33685778;
        public int ASIG_2 = -267534609;
        public int FSIG_1 = 1305093103;
        public int FSIG_2 = 1453361591;
        public int CompressionLevel = 1;
        public SortedDictionary<string, PckEntry> table;
        private long fileTableOffset;
        private long filesize = 0;
        private long filesize2 = 0;
        public string filePathToshow = "";
        public BinaryReader binaryReaderchunk;
        public PackStructureManager directoryStructure = null;
        public MemoryMappedFile pckfileOpened = null;
        public MemoryMappedViewStream viewStream;
        private int showMax = 50;
        private string memmoryMFPath = "";

        public void addFilesToTable(string fileName, string dropedFile, bool isUpdate)
        {
            if (isUpdate)
            {
                /*
                PckEntry fte = new PckEntry();
                MemoryStream fileMs = new MemoryStream(File.ReadAllBytes(dir + "\\" + files[a]));
                fte.filePath = files[a];
                fte.fileoffset = (uint)bw.BaseStream.Position;
                fte.decompressedSize = (int)fileMs.Length;
                MemoryStream ms = new MemoryStream();
                CompressStream(fileMs, ms, (int)fileMs.Length);
                byte[] buffer = ms.ToArray();
                fte.compressedSize = buffer.Length;
                bw.Write(buffer);
                fileTable.Add(fte);
                */
                //update table file
                if (table.ContainsKey(fileName))
                {
                    PckEntry fte = table[fileName];
                    MemoryStream fileMs = new MemoryStream(File.ReadAllBytes(dropedFile));
                    fte.filePath = fte.filePath;
                    fte.fileoffset = 0; //TO DO WHEN SAVE
                    fte.decompressedSize = (int)fileMs.Length;
                    fte.memoryun = fileMs;
                    //fte.memoryun.Flush();
                    MemoryStream ms = new MemoryStream();
                    CompressStream(fileMs, ms, (int)fileMs.Length);
                    byte[] buffer = ms.ToArray();
                    fte.compressedSize = buffer.Length;
                    fte.memory = new MemoryStream(buffer);
                    //fte.memory.Flush();
                    table[fileName] = fte;
                    directoryStructure.addfille(fte);
                }
            }
            else
            {
                //add file to table
                PckEntry fte = new PckEntry();
                MemoryStream fileMs = new MemoryStream(File.ReadAllBytes(dropedFile));
                fte.filePath = fileName;
                fte.fileoffset = 0; //TO DO WHEN SAVE
                fte.decompressedSize = (int)fileMs.Length;
                fte.memoryun = fileMs;
                //fte.memoryun.Flush();
                MemoryStream ms = new MemoryStream();
                CompressStream(fileMs, ms, (int)fileMs.Length);
                byte[] buffer = ms.ToArray();
                fte.compressedSize = buffer.Length;
                fte.memory = new MemoryStream(buffer);
                //fte.memory.Flush();
                table[fileName] = fte;
                directoryStructure.addfille(fte);

            }
        }

        internal void dispose()
        {
            if(binaryReaderchunk != null)
            {
                binaryReaderchunk.Close();
                binaryReaderchunk = null;
            }
            if(directoryStructure != null)
            {
                directoryStructure = null;
            }
            if(pckfileOpened != null)
            {
                pckfileOpened.Dispose();
                pckfileOpened = null;
            }
            GC.Collect();
        }

        public byte[] getChunk(string path, PckEntry table)
        {
            Byte[] datax = null;
            if (table.memoryun != null)
            {
                return table.memoryun.ToArray();
            }
            string filepath = path;

            if (binaryReaderchunk == null || binaryReaderchunk.BaseStream == null)
            {
                binaryReaderchunk = GenNewbinaryReader(getRealPath());
            }
            if (table.fileoffset <= 0)
            {
                MessageBox.Show("Bad file Address: " + table.fileoffset);
            }
            else
            {
                byte[] buffer = new byte[table.compressedSize];
                binaryReaderchunk.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);
                buffer = binaryReaderchunk.ReadBytes(table.compressedSize);
                if (table.compressedSize < table.decompressedSize)
                {
                    MemoryStream ms = new MemoryStream();
                    ZOutputStream zos = new ZOutputStream(ms);
                    CopyStream(new MemoryStream(buffer), zos, table.compressedSize);
                    datax = ms.ToArray();
                }
                else
                {
                    datax = buffer;
                }

            }
            return datax;
        }
        public byte[] getChunkraw(string path, PckEntry table)
        {
            string filepath = path;
            byte[] datax = null;
            if (binaryReaderchunk == null || binaryReaderchunk.BaseStream == null)
            {
                binaryReaderchunk = GenNewbinaryReader(getRealPath());
            }
            if (table.fileoffset <= 0)
            {
                MessageBox.Show("Bad file Address: " + table.fileoffset);
            }
            else
            {
                byte[] buffer = new byte[table.compressedSize];
                binaryReaderchunk.BaseStream.Seek(table.fileoffset, SeekOrigin.Begin);
                buffer = binaryReaderchunk.ReadBytes(table.compressedSize);
                datax = buffer;

            }
            return datax;
        }
        private BinaryWriter GenNewBinaryWriter(string fileName)
        {
            if (pckfileOpened == null)
            {
                if (filesize == 0)
                {
                    filesize = new FileInfo(fileName).Length;
                }
                using (FileStream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    pckfileOpened = MemoryMappedFile.CreateFromFile(stream, null, 0, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.Inheritable, false);
                }
                viewStream = pckfileOpened.CreateViewStream(0, 0, MemoryMappedFileAccess.ReadWrite);
                return new BinaryWriter(viewStream);
            }
            else
            {
                viewStream = pckfileOpened.CreateViewStream(0, 0, MemoryMappedFileAccess.ReadWrite);
                return new BinaryWriter(viewStream);
            }
        }
        public void save()
        {
            String pckFullPath = Path.GetDirectoryName(filePathToshow) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePathToshow)+".gshark";
            BinaryWriter bw = new BinaryWriter(new FileStream(pckFullPath, FileMode.Create, FileAccess.ReadWrite));
            if (bw != null)
            {
                bw.Write(FSIG_1);
                bw.Write(0);
                bw.Write(FSIG_2);
                List<PckEntry> fileTable = new List<PckEntry>();
                foreach (PckEntry fte in table.Values)
                {
                    if (fte.memory != null && fte.memory.Length > 0)
                    {
                        byte[] buffer = fte.memory.ToArray();
                        fte.fileoffset = (uint)bw.BaseStream.Position;
                        fte.compressedSize = (int)buffer.Length;
                        fte.decompressedSize = (int)fte.memoryun.Length;
                        bw.Write(buffer);
                        fte.memory = null;
                        fileTable.Add(fte);
                    }
                    else
                    {
                        byte[] buffer = getChunkraw(filePathToshow, fte);
                        fte.fileoffset = (uint)bw.BaseStream.Position;
                        bw.Write(buffer);
                        fileTable.Add(fte);
                    }
                }
                int fileTableOffset_tmp = (int)bw.BaseStream.Position;
                foreach (PckEntry file in fileTable)
                {
                    byte[] buffer = writeTableEntry(file);
                    bw.Write(buffer.Length ^ KEY_1);
                    bw.Write(buffer.Length ^ KEY_2);
                    bw.Write(buffer);
                }
                bw.Write(ASIG_1);
                bw.Write((short)2);
                bw.Write((short)2);
                bw.Write((uint)(fileTableOffset_tmp ^ KEY_1));
                bw.Write(0);
                bw.Write(Encoding.Default.GetBytes("Angelica File Package, Perfect World."));
                byte[] nuller = new byte[215];
                bw.Write(nuller);
                bw.Write(ASIG_2);
                bw.Write(fileTable.Count);
                bw.Write((short)2);
                bw.Write((short)2);
                bw.BaseStream.Seek(4, SeekOrigin.Begin);
                bw.Write((uint)bw.BaseStream.Length);
                bw.Close();
                if (deleteAndSplit(pckFullPath, filePathToshow))
                {
                    GC.Collect();


                    File.Delete(pckFullPath);
                    if (File.Exists(memmoryMFPath))
                    {
                        try
                        {
                            File.Delete(memmoryMFPath);
                        }
                        catch { }
                    }

                    progress_bar2("Ready", 0, 0);
                }
            }
        }


        public bool SplitFile(string pck, string pkx, string gsFile)
        {
            progress_bar2("Spliting files ...", 0, 100);
            FileStream file1 = new FileStream(pck, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            FileStream file2 = new FileStream(pkx, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            long size = new FileInfo(gsFile).Length;
            FileStream mainFile = new FileStream(gsFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            long rest = size - 2147483393;
            mainFile.Seek(0, SeekOrigin.Begin);
            CopyStream(mainFile, file1, 2147483393);
            Application.DoEvents();
            mainFile.Seek(2147483392, SeekOrigin.Begin);
            CopyStream(mainFile, file2, (int)rest);
            Application.DoEvents();
            file1.SetLength(2147483392);
            file1.Close();
            file2.Close();
            mainFile.Close();
            if (pckfileOpened != null)
            {
                pckfileOpened.Dispose();
                pckfileOpened = null;
            }
            return true;
        }

        public void Split(string pck)
        {
            if (new FileInfo(pck).Length > 2147483393)
            {
                Application.DoEvents();
                progress_bar2("Spliting files ...", 0, 100);
                string pkx = pck.Replace(".pck", ".pkx");
                FileStream mainFilex = new FileStream(pkx, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                FileStream mainFile = new FileStream(pck, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                mainFile.Seek(2147483392, SeekOrigin.Begin);
                Application.DoEvents();
                CopyStream(mainFile, mainFilex, 134217728);
                Application.DoEvents();
                mainFile.Seek(0, SeekOrigin.Begin);
                Application.DoEvents();
                mainFile.SetLength(2147483392);
                Application.DoEvents();
                mainFilex.Close();
                Application.DoEvents();
                mainFile.Close();
            }
        }

        private bool deleteAndSplit(string pckFullPath, string filePathToshow)
        {
            if (pckfileOpened != null)
            {
                pckfileOpened.Dispose();
                pckfileOpened = null;
            }
            if (new FileInfo(pckFullPath).Length > 2147483393)
            {
                return SplitFile(filePathToshow, filePathToshow.Replace(".pck", ".pkx"), pckFullPath);

            } else
            {
                File.Replace(pckFullPath, filePathToshow, filePathToshow + ".backup", false);

            }
            return true;
        }
        private string getRealPath()
        {
            if (memmoryMFPath.Length > 0)
            {
                return memmoryMFPath;
            }else
            {
                return filePathToshow;
            }
        }
        private BinaryReader GenNewbinaryReader(string fileName)
        {
            if (pckfileOpened == null)
            {
                if (filesize == 0)
                {
                    filesize = new FileInfo(fileName).Length;
                }
                using (FileStream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    pckfileOpened = MemoryMappedFile.CreateFromFile(stream, null, filesize, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.Inheritable, false);
                }
                viewStream = pckfileOpened.CreateViewStream(0, filesize, MemoryMappedFileAccess.ReadWrite);
                return new BinaryReader(viewStream);
            }
            else
            {
                if (filesize == 0)
                {
                    filesize = new FileInfo(fileName).Length;
                }
                using (FileStream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    pckfileOpened = MemoryMappedFile.CreateFromFile(stream, null, filesize, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.Inheritable, false);
                }
                viewStream = pckfileOpened.CreateViewStream(0, filesize, MemoryMappedFileAccess.ReadWrite);
                return new BinaryReader(viewStream);
            }
        }
        public PackStructureManager readOnly(string filepath)
        {
            directoryStructure = new PackStructureManager(Path.GetFileNameWithoutExtension(filepath));
            progress_bar2("Reading ...", 0, 100);
            Application.DoEvents();
            bool compleate = Merge(filepath);
            if (compleate == true)
            {
                filePathToshow = filepath;
                BinaryReader br = GenNewbinaryReader(getRealPath());
                br.BaseStream.Seek(-8, SeekOrigin.End);
                int entryCount = br.ReadInt32();
                br.BaseStream.Seek(-272, SeekOrigin.End);
                fileTableOffset = (long)((ulong)((uint)(br.ReadUInt32() ^ (ulong)KEY_1)));
                br.BaseStream.Seek(fileTableOffset, SeekOrigin.Begin);
                table = new SortedDictionary<string, PckEntry>();
                for (int a = 0; a < entryCount; ++a)
                {
                    int entrySize = br.ReadInt32() ^ KEY_1;
                    entrySize = br.ReadInt32() ^ KEY_2;
                    byte[] buffer = new byte[entrySize];
                    buffer = br.ReadBytes(entrySize);
                    PckEntry entry = null;
                    if (entrySize < 276)
                    {
                        entry = readTableEntry(buffer, true);
                        table[entry.filePath] = entry;
                    }
                    else
                    {
                        entry = readTableEntry(buffer, false);
                        table[entry.filePath] = entry;
                    }
                    table[entry.filePath].packPath = filepath;
                    directoryStructure.addfille(table[entry.filePath]);
                }
                br.Close();
                pckfileOpened.Dispose();
                pckfileOpened = null;
                progress_bar2("Ready", 0, 0);
                Application.DoEvents();
                return directoryStructure;
            }
            return null;
        }
        public void unpack()
        {
            progress_bar2("Unpacking ...", 0, 100);
            string path = filePathToshow + ".files\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                Directory.Delete(path, true);
            }
            //BinaryReader br = new BinaryReader(new FileStream(filePathToshow, FileMode.Open, FileAccess.Read));
            bool compleate = Merge(filePathToshow);
            if (compleate == true)
            {
                BinaryReader br = GenNewbinaryReader(getRealPath());
                br.BaseStream.Seek(-8, SeekOrigin.End);
                int entryCount = br.ReadInt32();
                br.BaseStream.Seek(-272, SeekOrigin.End);
                fileTableOffset = (long)((ulong)((uint)(br.ReadUInt32() ^ (ulong)KEY_1)));

                br.BaseStream.Seek(fileTableOffset, SeekOrigin.Begin);
                table = new SortedDictionary<string, PckEntry>();
                int show = 0;
                for (int a = 0; a < entryCount; ++a)
                {
                    int entrySize = br.ReadInt32() ^ KEY_1;
                    entrySize = br.ReadInt32() ^ KEY_2;
                    byte[] buffer = new byte[entrySize];
                    buffer = br.ReadBytes(entrySize);
                    PckEntry entry = null;
                    if (entrySize < 276)
                    {
                        entry = readTableEntry(buffer, true);
                        table[entry.filePath] = entry;
                    }
                    else
                    {
                        entry = readTableEntry(buffer, false);
                        table[entry.filePath] = entry;
                    }
                    if (show <= 0)
                    {
                        Application.DoEvents();
                        progress_bar2(string.Format("Reading tables: {0}/{1}", a, entryCount), a, entryCount);
                        show = showMax;
                    }
                    else
                    {
                        show--;
                    }
                }
                show = 0;
                int b = 0;
                foreach (PckEntry fte in table.Values)
                {
                    if (fte.fileoffset <= 0)
                    {
                        MessageBox.Show("Bad file Address: " + fte.fileoffset);
                    }
                    else
                    {
                        CreateDir(path, fte.filePath);
                        byte[] buffer = new byte[fte.compressedSize];
                        fte.fullP = path + fte.filePath;
                       // BinaryWriter bw = new BinaryWriter(new FileStream(fte.fullP, FileMode.Create, FileAccess.Write));
                        br.BaseStream.Seek(fte.fileoffset, SeekOrigin.Begin);
                        buffer = br.ReadBytes(fte.compressedSize);
                        if (fte.compressedSize < fte.decompressedSize)
                        {
                            
                            Thread t = new Thread(new ThreadStart(() => { saveFile(fte.fullP, buffer, fte, true); }));
                            t.Start();
                        }
                        else
                        {
                            Thread t = new Thread(new ThreadStart(() => { saveFile(fte.fullP, buffer, fte, false); }));
                            t.Start();
                        }
                        //bw.Close();
                    }
                    if (show <= 0)
                    {
                        Application.DoEvents();
                        progress_bar2(string.Format("Unpacking: {0}/{1}", b, entryCount), b, entryCount);
                        show = showMax;
                    }
                    else
                    {
                        show--;
                    }
                    b++;
                }
                br.Close();
                br.Close();
                pckfileOpened.Dispose();
                pckfileOpened = null;
                if (filePathToshow.EndsWith("x")) File.Delete(filePathToshow);

            }
            progress_bar2("Ready", 0, 0);
        }

        public void saveFile(string path, byte[] buffer, PckEntry fte, bool compresed)
        {
            if(compresed)
            {
                MemoryStream ms = new MemoryStream();
                ZOutputStream zos = new ZOutputStream(ms);
                CopyStream(new MemoryStream(buffer), zos, fte.compressedSize);
                File.WriteAllBytes(path, ms.ToArray());
            }else
            {
                File.WriteAllBytes(path, buffer);
            }
        }


        public void pack(string dir)
        {
            if (!Directory.Exists(dir))
            {
                unpack();
            }
            progress_bar2("Packing ...", 0, 100);
            string pck = dir.Replace(".files\\", "").Replace(".files", "");
            string[] files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            for (int a = 0; a < files.Length; ++a)
            {
                files[a] = files[a].Replace(dir, "").Replace("/", "\\").Remove(0, 1);
            }
            fileTableOffset = 0;
            List<PckEntry> fileTable = new List<PckEntry>();
            BinaryWriter bw = new BinaryWriter(new FileStream(pck, FileMode.Create, FileAccess.ReadWrite));
            bw.Write(FSIG_1);
            bw.Write(0);
            bw.Write(FSIG_2);
            int show = 0;
            for (int a = 0; a < files.Length; ++a)
            {
                PckEntry fte = new PckEntry();
                MemoryStream fileMs = new MemoryStream(File.ReadAllBytes(dir + "\\" + files[a]));
                fte.filePath = files[a];
                fte.fileoffset = (uint)bw.BaseStream.Position;
                fte.decompressedSize = (int)fileMs.Length;
                MemoryStream ms = new MemoryStream();
                CompressStream(fileMs, ms, (int)fileMs.Length);
                byte[] buffer = ms.ToArray();
                fte.compressedSize = buffer.Length;
                bw.Write(buffer);
                fileTable.Add(fte);
                if (show <= 0)
                {
                    Application.DoEvents();
                    progress_bar2(string.Format("Writeing records: {0}/{1}", a, files.Length), a, files.Length);
                    show = showMax;
                }
                else
                {
                    show--;
                }
            }
            fileTableOffset = bw.BaseStream.Position;
            for (int a = 0; a < fileTable.Count; ++a)
            {
                byte[] buffer = writeTableEntry(fileTable[a]);
                bw.Write(buffer.Length ^ KEY_1);
                bw.Write(buffer.Length ^ KEY_2);
                bw.Write(buffer);
                if (show <= 0)
                {
                    Application.DoEvents();
                    progress_bar2(string.Format("Writeing files: {0}/{1}", a, files.Length), a, files.Length);
                    show = showMax;
                }
                else
                {

                    show--;
                }
            }
            bw.Write(ASIG_1);
            bw.Write((short)2);
            bw.Write((short)2);
            bw.Write((uint)(fileTableOffset ^ KEY_1));
            bw.Write(0);
            bw.Write(Encoding.Default.GetBytes("Angelica File Package, Perfect World."));
            byte[] nuller = new byte[215];
            bw.Write(nuller);
            bw.Write(ASIG_2);
            bw.Write(fileTable.Count);
            bw.Write((short)2);
            bw.Write((short)2);
            bw.BaseStream.Seek(4, SeekOrigin.Begin);
            bw.Write((uint)bw.BaseStream.Length);
            bw.Close();
            Split(pck);
            progress_bar2("Ready", 0, 0);
        }

        public PckEntry readTableEntry(byte[] buffer, bool compressed)
        {
            PckEntry fte = new PckEntry();
            MemoryStream ms = new MemoryStream(buffer);
            if (compressed)
            {
                byte[] buf = new byte[276];
                ZOutputStream zos = new ZOutputStream(new MemoryStream(buf));
                CopyStream(new MemoryStream(buffer), zos, 276);
                buffer = buf;
            }
            BinaryReader br = new BinaryReader(new MemoryStream(buffer));
            fte.filePath = Encoding.GetEncoding("GB2312").GetString(br.ReadBytes(260)).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("/", "\\");
            fte.fullP = string.Empty;
            fte.fileoffset = br.ReadUInt32();
            fte.decompressedSize = br.ReadInt32();
            fte.compressedSize = br.ReadInt32();
            return fte;
        }

        public byte[] writeTableEntry(PckEntry fte)
        {
            byte[] buffer = new byte[276];
            MemoryStream msb = new MemoryStream(buffer);
            BinaryWriter bw = new BinaryWriter(msb);
            bw.Write(Encoding.GetEncoding("GB2312").GetBytes(fte.filePath.Replace("/", "\\")));
            bw.BaseStream.Seek(260, SeekOrigin.Begin);
            bw.Write(fte.fileoffset);
            bw.Write(fte.decompressedSize);
            bw.Write(fte.compressedSize);
            bw.Write(0);
            msb.Seek(0, SeekOrigin.Begin);
            MemoryStream ms = new MemoryStream();
            CompressStream(msb, ms, 276);
            return ms.ToArray();
        }
        public void deleteFile(PckEntry file)
        {
            if (table.ContainsKey(file.filePath))
            {
                table.Remove(file.filePath);
            }
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
                MessageBox.Show("Bad zlib data");
            }
        }
        public void CompressStream(Stream inStream, Stream outStream, int Size)
        {
            ZOutputStream zos = new ZOutputStream(outStream, CompressionLevel);
            CopyStream(inStream, zos, Size);
            zos.finish();
        }
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
        public MemoryMappedFile mearge2(string f1Path, string f2Path)
        {
            byte[] buffer;
            int offset;
            int length;
            memmoryMFPath = Path.GetDirectoryName(f1Path) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(f1Path) + ".gsharkm";
            using (FileStream f1ReadStream = new FileStream(f1Path, FileMode.Open, FileAccess.Read))
            {
                offset = (int)f1ReadStream.Length;
            }
            using (FileStream f2ReadStream = new FileStream(f2Path, FileMode.Open, FileAccess.Read))
            {
                length = (int)f2ReadStream.Length;
            }
            // read file2 and append all to file1
            using (var mappedFile2 = MemoryMappedFile.CreateFromFile(f2Path, FileMode.Open, null, length))
            {
                using (var reader = mappedFile2.CreateViewStream(0, length, MemoryMappedFileAccess.Read))
                {
                    // Read from MMF
                    buffer = new byte[length];
                    reader.Read(buffer, 0, length);
                }
            }
            if (!File.Exists(memmoryMFPath))
            {
                File.WriteAllBytes(memmoryMFPath, new byte[10]);
            }
           
            var mappedFile1 = MemoryMappedFile.CreateFromFile(memmoryMFPath, FileMode.Open, null, filesize);
            // Create writer to MMF
            using (var writer = mappedFile1.CreateViewAccessor(offset, length, MemoryMappedFileAccess.Write))
            {
                // Write to MMF
                writer.WriteArray<byte>(0, buffer, 0, length);
            }
            mappedFile1.Dispose();
            mappedFile1 = null;
            return mappedFile1;
        }
        public bool Merge(string pck)
        {
            if (filesize == 0)
            {
                filesize = new FileInfo(pck).Length;
            }
            if (filesize < 2147483393)
            {
                string pkx = pck.Replace(".pck", ".pkx");
                String f1Path = pck;
                String f2Path = pkx;
                if (File.Exists(pkx))
                {
                    filesize2 = new FileInfo(f2Path).Length;
                    filesize = filesize + filesize2;
                    pckfileOpened = mearge2(f1Path, f2Path);
                    return true;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return true;
            }

        }
    }
}
