using System;
using System.IO;
using System.Text;
using Ultimate_Editor.Clases.AngelicaFileManager;

namespace Gpckx
{
    public class PckEntry
    {
        public byte[] bytes;
        public byte[] bytesCompresed;
        public int id;
        private int compressedxsize = 276;
        private byte[] other;
        public int version;

        public string packPath { get; set; }
        public string filePath { get; set; }
        public string fullP { get; set; }
        public MemoryStream memory { get; set; }
        public long fileoffset { get; set; }
        public int decompressedSize { get; set; }
        public int compressedSize { get; set; }
        public string filetobeadded { get; set; }

        public PckEntry()
        {
        }

        public PckEntry(int version)
        {
            this.version = version;
            compressedxsize = this.version == 2 ? 276 : 288;
        }

        public void setVersion(int version)
        {
            this.version = version;
            compressedxsize = this.version == 2 ? 276 : 288;
        }

        public PckEntry(byte[] bytes, int version)
        {
            this.version = version;
            compressedxsize = this.version == 2 ? 276 : 288;
            Read(bytes);
        }

        public void Read(byte[] bytes)
        {
            if (bytes.Length < compressedxsize)
            {
                bytes = PCKZlib.Decompress(bytes, compressedxsize);
            }
            BinaryReader br = new BinaryReader(new MemoryStream(bytes));
            filePath = Encoding.GetEncoding("GB2312").GetString(br.ReadBytes(260)).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("/", "\\");
            fullP = string.Empty;
            if (this.version > 2)
            {
                other = br.ReadBytes(4);
                fileoffset = br.ReadInt64();
            }
            else
                fileoffset = br.ReadUInt32();

            decompressedSize = br.ReadInt32();
            compressedSize = br.ReadInt32();
            br.Close();
        }

        public byte[] Write(int CompressionLevel)
        {
            byte[] buffer = new byte[compressedxsize];
            MemoryStream msb = new MemoryStream(buffer);
            BinaryWriter bw = new BinaryWriter(msb);
            byte[] dataxacsdfile = Encoding.GetEncoding("GB2312").GetBytes(filePath.Replace("/", "\\"));
            bw.Write(dataxacsdfile);
            if (this.version > 2)
            {
                bw.BaseStream.Seek(260, SeekOrigin.Begin);
                bw.Write(other != null ? other : new byte[4] { 0, 0, 0, 0 });
                bw.Write(fileoffset);
                bw.Write(decompressedSize);
                bw.Write(compressedSize);
                bw.Write(0);
                bw.BaseStream.Seek(0, SeekOrigin.Begin);
                bw.Close();
            }
            else
            {
                bw.BaseStream.Seek(260, SeekOrigin.Begin);
                bw.Write((uint)fileoffset);
                bw.Write(decompressedSize);
                bw.Write(compressedSize);
                bw.Write(0);
                bw.BaseStream.Seek(0, SeekOrigin.Begin);
                bw.Close();
            }
            byte[] compressed = PCKZlib.Compress(buffer, CompressionLevel);
            return compressed.Length < compressedxsize ? compressed : buffer;
        }
    }
}
