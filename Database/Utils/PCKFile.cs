using ComponentAce.Compression.Libs.zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Database
{
    public class PCKFile
    {
        // PWI decoding keys
        public const uint KEY_1 = 0xA8937462;
        public const uint KEY_2 = 0xF1A43653;

        private string PCKFilePath = null;
        private FileTableEntry[] AllFilesEntries;

        public bool IsLoaded
        {
            get
            {
                return AllFilesEntries != null;
            }
        }

        public void LoadIndex(string pathToPCK)
        {
            if (!File.Exists(pathToPCK))
            {
                return;
            }
            uint EntryCount = 0;
            try
            {
                using (FileStream fStream = new FileStream(pathToPCK, FileMode.Open, FileAccess.Read))
                {
                    /* set var here to be sure PCKFile can be readed */
                    PCKFilePath = pathToPCK;
                    using (BinaryReader bReader = new BinaryReader(fStream))
                    {
                        fStream.Seek(-8, SeekOrigin.End);
                        EntryCount = bReader.ReadUInt32();
                        AllFilesEntries = new FileTableEntry[EntryCount];
                        fStream.Seek(-272, SeekOrigin.End);
                        uint FileTableOffset = bReader.ReadUInt32() ^ KEY_1;
                        fStream.Seek(FileTableOffset, SeekOrigin.Begin);

                        /* we put var declare out of the loop to optimize */
                        long LastEntryPosition = 0;
                        uint Value1 = 0;
                        uint Value2 = 0;
                        byte[] RawName = null;

                        for (int i = 0; i < EntryCount; i++)
                        {
                            Value1 = bReader.ReadUInt32() ^ KEY_1;
                            Value2 = bReader.ReadUInt32() ^ KEY_2;
                            RawName = bReader.ReadBytes((int)Value2);
                            /* We save last entry position in Stream to come back here later */
                            LastEntryPosition = bReader.BaseStream.Position;

                            if (Value2 < 280)
                            {
                                AllFilesEntries[i] = ReadTableEntry(RawName, true);
                            }
                            else
                            {
                                AllFilesEntries[i] = ReadTableEntry(RawName, false);
                            }
                        }
                        /* Clean var */
                        RawName = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AllFilesEntries = null;
                return;
            }
        }

        public byte[] LoadFile(string FileName)
        {
            if (!IsLoaded) return null;

            var FileEntry = AllFilesEntries.Where(fte => fte.FilePath.ToLower().EndsWith(FileName.ToLower())).FirstOrDefault();
            if (FileEntry == null) return null; /* No file found */

            using (FileStream fStream = new FileStream(PCKFilePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader bReader = new BinaryReader(fStream))
                {
                    /* We go to File Entry position in Stream */
                    fStream.Seek((long)FileEntry.FileDataOffset, SeekOrigin.Begin);
                    byte[] FileData = null;
                    try
                    {
                        /* We check if file is compressed */
                        if (FileEntry.FileDataCompressedSize < FileEntry.FileDataDecompressedSize)
                        {
                            FileData = bReader.ReadBytes((int)FileEntry.FileDataCompressedSize);
                            FileData = inflate(FileData);
                        }
                        else
                        {
                            FileData = bReader.ReadBytes((int)FileEntry.FileDataDecompressedSize);
                        }

                        return FileData;
                    }
                    catch
                    {
                        /* Extract file exception */
                        return null;
                    }
                }
            }
        }

        public static byte[] inflate(byte[] data)
        {
            using (MemoryStream mStream = new MemoryStream(data))
            {
                using (MemoryStream mStreamE = new MemoryStream())
                {
                    using (ZOutputStream outZStream = new ZOutputStream(mStreamE))
                    {
                        CopyStream(mStream, outZStream);
                        //mStream.CopyTo(outZStream);
                    }
                    return mStreamE.ToArray();
                }
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[input.Length];
            int len;
            while ((len = input.Read(buffer, 0, (int)input.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }

        public string[] SearchFiles(string FileName)
        {
            if (!IsLoaded) return new string[0];
            return (from fte in AllFilesEntries
                    where fte.FilePath.ToLower().Contains(FileName.ToLower())
                    select fte.FilePath).ToArray();
        }

        public static FileTableEntry ReadTableEntry(byte[] data, bool Compressed)
        {
            FileTableEntry fte = new FileTableEntry();

            if (Compressed)
            {
                data = inflate(data);
            }
            using (MemoryStream mStream = new MemoryStream(data))
            {
                using (BinaryReader bReader = new BinaryReader(mStream))
                {
                    fte.Read(bReader);
                }
            }
            return fte;
        }
    }
}
