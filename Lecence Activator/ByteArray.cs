using Newtonsoft.Json;
using Shield.classes.net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied
{
    public class ByteArray
    {
        private byte[] a16 = new byte[2];
        private byte[] a32 = new byte[4];
        private byte[] a64 = new byte[8];
        private MemoryStream data = null;
        private readonly string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
        private BinaryWriter writer = null;
        private BinaryReader reader = null;
        private long maxLen = 0;
        private long lastPos = 0;
        public ByteArray()
        {
            this.data = new MemoryStream();
            this.writer = new BinaryWriter(data);
            this.reader = new BinaryReader(data);
        }

        public void Write(byte[] bytes, int ofset, int len)
        {
            maxLen += len;
            this.writer.BaseStream.Position = ofset;
            this.writer.Write(bytes, 0, (int)len);
            lastPos = this.writer.BaseStream.Position;
            this.writer.BaseStream.Position = 0;
        }

        public void Position(int pos)
        {
                this.reader.BaseStream.Position = pos;
        }

        public int Position()
        {
            return (int)this.reader.BaseStream.Position;
        }

        public int bytesAvailable()
        {
            int av = ((int)maxLen - (int)this.reader.BaseStream.Position);
            return av >= 0 ? av : 0;
        }

        public int Length()
        {
            return (int)maxLen;
        }

        public void Length(int len)
        {
            maxLen = len;
        }

        public void clear()
        {
            this.writer.Flush();
            this.writer.Close();
            this.reader.Close();
            maxLen = 0;
            lastPos = 0;
            this.data = new MemoryStream(0);
            this.writer = new BinaryWriter(data);
            this.reader = new BinaryReader(data);
            this.reader.BaseStream.Position = 0;
        }

        public Dictionary<string, Object> readObject(int type)
        {
            Dictionary<string, Object> values;
            data.Seek(data.Position, SeekOrigin.Begin);
            data.Flush();
            byte[] asa = new byte[this.bytesAvailable()];
            this.reader.Read(asa, 0, asa.Length);
            string message = Encoding.UTF8.GetString(asa);
            if (type == 2)
            {
                values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(message);
            }
            else
            {
                values = JsonConvert.DeserializeObject<Dictionary<string, Object>>(message);
            }
            return values;
        }

        public int ReadInt32()
        {
            a32 = this.reader.ReadBytes(4);
            if (a32.Length > 0)
            {
                Array.Reverse(a32);
                return BitConverter.ToInt32(a32, 0);
            }
            return 0;
        }

        public Int16 ReadInt16BigEndian()
        {
            a16 = this.reader.ReadBytes(2);
            Array.Reverse(a16);
            return BitConverter.ToInt16(a16, 0);
        }

        public Int64 ReadInt64BigEndian()
        {
            a64 = this.reader.ReadBytes(8);
            Array.Reverse(a64);
            return BitConverter.ToInt64(a64, 0);
        }

        public UInt32 ReadUInt32BigEndian()
        {
            a32 = this.reader.ReadBytes(4);
            Array.Reverse(a32);
            return BitConverter.ToUInt32(a32, 0);
        }

        public double ReadDouble32()
        {

            byte[] bytes = this.reader.ReadBytes(8);
            Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }

        public void readBytes(ByteArray bytes, int v, int len)
        {
            byte[] remaining = new byte[this.bytesAvailable()];
            this.reader.Read(remaining, 0, remaining.Length);
            bytes.Write(remaining, 0, remaining.Length);
            bytes.Position(0);
        }

        public void readBytes2(ByteArray bytes, int v, int len)
        {
            byte[] remaining = new byte[this.bytesAvailable()];
            this.reader.Read(remaining, 0, remaining.Length);
            bytes.Write(remaining, 0, remaining.Length);
            //bytes.Position(0);
        }

        public void readBytes3(ByteArray bytes, int v, int len, bool ireq, int xz)
        {
            byte[] remaining = new byte[len];
            //this.Position(v);
            this.reader.Read(remaining, 0, remaining.Length);
            if(ireq)
            {
                remaining = x(remaining, xz);
            }
            bytes.Write(remaining, 0, remaining.Length);
            bytes.Position(0);
        }


        public byte[] readBytes4(int v, int len)
        {
            byte[] remaining = new byte[len];
            this.reader.Read(remaining, 0, remaining.Length);
            return remaining;
            //bytes.Position(0);
        }

        public String Serialize(Object data)
        {
            var serializer = JsonConvert.SerializeObject(data);
            return serializer;
        }
        public void writeInt(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            this.writer.Write(intBytes);
            maxLen += intBytes.Length;
        }

        public void writeObject(HashMap<string, Object> value)
        {
            string toString = Serialize(value);
            byte[] bytes = System.Text.UTF8Encoding.UTF8.GetBytes(toString);
            this.writer.Write(bytes);
            maxLen += bytes.Length;
        }

        public void writeBytes(Byte[] values, bool isenc = false, int xz = 0)
        {
            if (!isenc)
            {
                this.writer.Write(values);
                maxLen += values.Length;
            }else
            {
                values = x(values, xz);
                this.writer.Write(values);
                maxLen += values.Length;
            }
        }

        private static byte[] x(byte[] x, int xz)
        {
            byte[] result = new byte[x.Length];
            for (int i = 0; i < x.Length; i++)
                result[i] = (byte)(x[i] ^ xz);
            return result;
        }

        public byte[] Consume()
        {
            this.data.Position = 0;
            byte[] bytes = new Byte[maxLen];
            this.reader.Read(bytes, 0, bytes.Length);
            return bytes;
        }
        public static byte[] writeIntX(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            return intBytes;
        }

    }
}
