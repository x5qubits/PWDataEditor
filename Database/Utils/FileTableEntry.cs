using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Database
{
    public class FileTableEntry
    {
        private byte[] filePathRawData = new byte[260];
        public string FilePath
        {
            get
            {
                return Encoding.GetEncoding("gb2312").GetString(filePathRawData).TrimEnd((char)0x00);
            }
            set
            {
                byte[] encoded = Encoding.GetEncoding("gb2312").GetBytes(value);
                filePathRawData = new byte[260];
                if (encoded.Length >= 260)
                {
                    Array.Copy(encoded, filePathRawData, 259);
                }
                else
                {
                    Array.Copy(encoded, filePathRawData, encoded.Length);
                }
            }
        }

        public uint FileDataOffset;
        public uint FileDataDecompressedSize;
        public uint FileDataCompressedSize;

        public void Read(BinaryReader bReader)
        {
            filePathRawData = bReader.ReadBytes(260);
            FileDataOffset = bReader.ReadUInt32();
            FileDataDecompressedSize = bReader.ReadUInt32();
            FileDataCompressedSize = bReader.ReadUInt32();
        }

        public void Write(BinaryWriter bWriter)
        {
            bWriter.Write(filePathRawData);
            bWriter.Write(FileDataOffset);
            bWriter.Write(FileDataDecompressedSize);
            bWriter.Write(FileDataCompressedSize);
        }
    }
}
