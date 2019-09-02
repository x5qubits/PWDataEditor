using ComponentAce.Compression.Libs.zlib;
using Gpckx;
using Pck_Guy_View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ultimate_Editor.Clases.Utils;

namespace Ultimate_Editor.Clases.AngelicaFileManager
{
    public class PackHelper
    {
        private CombinationStream stream = null;
        private List<Stream> streams = null;
        private PackStructureManager psm = null;
        private int KEY_1 = -1466731422;
        private int KEY_2 = -240896429;
        private int ASIG_1 = -33685778;
        private int ASIG_2 = -267534609;
        private int FSIG_1 = 1305093103;
        private int FSIG_2 = 1453361591;
        public static Dictionary<string, PckEntry> files = new Dictionary<string, PckEntry>();
        private bool initiated = false;

        public PackHelper(string path)
        {
            Thread th = new Thread(() => ReadTable(path));
            th.IsBackground = true;
            th.Start();
        }

        private void ReadTable(string path)
        {
            psm = new PackStructureManager(Path.GetFileNameWithoutExtension(path));
            streams = new List<Stream>();
            if (File.Exists(path))
            {
                streams.Add(new FileStream(path, FileMode.Open, FileAccess.Read));
            }
            string pkx = path.Replace(".pck", ".pkx");
            if (File.Exists(pkx))
            {
                streams.Add(new FileStream(pkx, FileMode.Open, FileAccess.Read));
            }
            stream = new CombinationStream(streams);

            BinaryReader br = new BinaryReader(stream);
            br.BaseStream.Seek(-8, SeekOrigin.End);
            int entryCount = br.ReadInt32();
            br.BaseStream.Seek(-272, SeekOrigin.End);
            long fileTableOffset = (long)((ulong)((uint)(br.ReadUInt32() ^ (ulong)KEY_1)));
            br.BaseStream.Seek(fileTableOffset, SeekOrigin.Begin);
            PckEntry[] table = new PckEntry[entryCount];
            for (int a = 0; a < entryCount; ++a)
            {
                int entrySize = br.ReadInt32() ^ KEY_1;
                entrySize = br.ReadInt32() ^ KEY_2;
                byte[] buffer = new byte[entrySize];
                buffer = br.ReadBytes(entrySize);
                if (entrySize < 276)
                {
                    table[a] = readTableEntry(buffer, true);
                }
                else
                {
                    table[a] = readTableEntry(buffer, false);
                }
                string name = table[a].filePath.ToLower();
                files[name] = table[a];
                psm.addfille(files[name]);
            }

            initiated = true;
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

        public FolderTreeModel getDirectory(string files = @"Models\Weapons\人物\斧锤\双手长锤\工锤")
        {
           return psm.GetDirectory(files);
        }

    }
}
