using AIPolicy.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AIPolicy
{
    public class DataStream
  {
    private const int read_buffer_size = 1024;
    private byte[] buffer;
    private List<byte> wbuffer;
    private int Position;
    private int Length;

    public bool CanRead
    {
      get
      {
        return this.Position < this.Length;
      }
    }

    public DataStream()
    {
      this.wbuffer = new List<byte>();
      this.Position = 0;
      this.Length = 0;
    }

    public DataStream(byte[] bytes)
    {
      this.buffer = bytes;
      this.Position = 0;
      this.Length = this.buffer.Length;
    }

    public void Dump(string name)
    {
      File.WriteAllBytes(name, this.wbuffer.ToArray());
    }

    public byte[] Read()
    {
      byte[] numArray = new byte[1024];
      Buffer.BlockCopy((Array) this.buffer, this.Position, (Array) numArray, 0, this.Length - this.Position);
      this.Position = this.Length;
      return numArray;
    }

    public byte[] Read(int count)
    {
      byte[] numArray = new byte[count];
      Buffer.BlockCopy((Array) this.buffer, this.Position, (Array) numArray, 0, count);
      this.Position += count;
      return numArray;
    }

    public float ReadFloat32()
    {
      return this.ReadFloat32(true);
    }

    public double ReadDouble64()
    {
      return this.ReadDouble64(true);
    }

    public float ReadFloat32(bool reverse)
    {
      byte[] numArray = this.Read(4);
      if (reverse)
        Enumerable.Reverse<byte>((IEnumerable<byte>) numArray);
      return BitConverter.ToSingle(numArray, 0);
    }

    public double ReadDouble64(bool reverse)
    {
      byte[] numArray = this.Read(8);
      if (reverse)
        Enumerable.Reverse<byte>((IEnumerable<byte>) numArray);
      return BitConverter.ToDouble(numArray, 0);
    }

    public int ReadInt32()
    {
      return this.ReadInt32(false);
    }

    public int ReadInt32(bool rev)
    {
      byte[] numArray = this.Read(4);
      if (rev)
        Enumerable.Reverse<byte>((IEnumerable<byte>) numArray);
      return BitConverter.ToInt32(numArray, 0);
    }

    public long ReadInt64()
    {
      return this.ReadInt64(true);
    }

    public long ReadInt64(bool rev)
    {
      byte[] numArray = this.Read(8);
      if (rev)
        Enumerable.Reverse<byte>((IEnumerable<byte>) numArray);
      return BitConverter.ToInt64(numArray, 0);
    }

    public uint ReadUInt32()
    {
      return this.ReadUInt32(false);
    }

    public uint ReadUInt32(bool rev)
    {
      byte[] numArray = this.Read(4);
      if (rev)
        Enumerable.Reverse<byte>((IEnumerable<byte>) numArray);
      return BitConverter.ToUInt32(numArray, 0);
    }

    public short ReadInt16()
    {
      return this.ReadInt16(false);
    }

    public short ReadInt16(bool rev)
    {
      byte[] numArray = this.Read(2);
      if (rev)
        Enumerable.Reverse<byte>((IEnumerable<byte>) numArray);
      return BitConverter.ToInt16(numArray, 0);
    }

    public byte ReadByte()
    {
      return this.Read(1)[0];
    }

    public string ReadASCIIS()
    {
      this.ReadInt32();
      return this.ReadASCII();
    }

    public string ReadASCII()
    {
      List<char> list = new List<char>();
      char ch;
      while ((int) (ch = (char) this.ReadByte()) != 0)
        list.Add(ch);
      return string.Concat<char>((IEnumerable<char>) list);
    }

    public GB18030 ReadGB18030()
    {
      return new GB18030(this.Read(128));
    }

    public string ReadUnicode()
    {
      return this.ReadUnicode(this.ReadInt32());
    }

    public string ReadUnicode(int size)
    {
      return Encoding.Unicode.GetString(this.Read(size));
    }

    public DataStream Write(object val)
    {
      if (val is bool)
        return this.Write(BitConverter.GetBytes((bool) val));
      if (val is int)
        return this.Write(BitConverter.GetBytes((int) val));
      if (val is byte)
        return this.Write(BitConverter.GetBytes((short) (byte) val));
      if (val is short)
        return this.Write(BitConverter.GetBytes((short) val));
      if (val is float)
        return this.Write(BitConverter.GetBytes((float) val));
      if (val is double)
        return this.Write(BitConverter.GetBytes((double) val));
      if (val is GB18030)
        return this.Write(((GB18030) val).data);
      if (val is byte[])
        return this.Write((byte[]) val);
      if (val is string)
        return this.Write(Encoding.Unicode.GetBytes((string) val));
      return (DataStream) null;
    }

    public DataStream Write(byte[] bytes)
    {
      this.wbuffer.AddRange((IEnumerable<byte>) bytes);
      this.Position += bytes.Length;
      this.Length += bytes.Length;
      return this;
    }

    public DataStream Write(DataStream ds)
    {
      this.Write(ds.wbuffer.ToArray());
      return this;
    }
  }
}
