// Decompiled with JetBrains decompiler
// Type: DevIL.MemoryHelper
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DevIL
{
  public static class MemoryHelper
  {
    public static byte[] ReadByteBuffer(IntPtr pointer, int numBytes)
    {
      if (pointer == IntPtr.Zero)
        return (byte[]) null;
      byte[] destination = new byte[numBytes];
      Marshal.Copy(pointer, destination, 0, numBytes);
      return destination;
    }

    public static T[] MarshalArray<T>(IntPtr pointer, int length) where T : struct
    {
      return MemoryHelper.MarshalArray<T>(pointer, length, false);
    }

    public static T[] MarshalArray<T>(IntPtr pointer, int length, bool pointerToPointer) where T : struct
    {
      if (pointer == IntPtr.Zero)
        return (T[]) null;
      try
      {
        Type structureType = typeof (T);
        int num = pointerToPointer ? IntPtr.Size : Marshal.SizeOf(typeof (T));
        T[] objArray = new T[length];
        for (int index = 0; index < length; ++index)
        {
          IntPtr ptr = pointer + num * index;
          if (pointerToPointer)
            ptr = Marshal.ReadIntPtr(ptr);
          objArray[index] = (T) Marshal.PtrToStructure(ptr, structureType);
        }
        return objArray;
      }
      catch
      {
        return (T[]) null;
      }
    }

    public static T MarshalStructure<T>(IntPtr ptr) where T : struct
    {
      if (ptr == IntPtr.Zero)
        return default (T);
      return (T) Marshal.PtrToStructure(ptr, typeof (T));
    }

    public static float Clamp(float value, float min, float max)
    {
      value = (double) value > (double) max ? max : value;
      value = (double) value < (double) min ? min : value;
      return value;
    }

    public static double Clamp(double value, double min, double max)
    {
      value = value > max ? max : value;
      value = value < min ? min : value;
      return value;
    }

    public static int RoundUpToPowerOfTwo(int value)
    {
      --value;
      value |= value >> 1;
      value |= value >> 2;
      value |= value >> 4;
      value |= value >> 8;
      value |= value >> 16;
      return value + 1;
    }

    public static int RoundDownToPowerOfTwo(int value)
    {
      value |= value >> 1;
      value |= value >> 2;
      value |= value >> 4;
      value |= value >> 8;
      value |= value >> 16;
      return value - (value >> 1);
    }

    public static int RoundToNearestPowerOfTwo(int value)
    {
      int powerOfTwo1 = MemoryHelper.RoundUpToPowerOfTwo(value);
      int powerOfTwo2 = MemoryHelper.RoundDownToPowerOfTwo(value);
      int num = Math.Abs(powerOfTwo1 - value);
      if (Math.Abs(value - powerOfTwo2) < num)
        return powerOfTwo2;
      return powerOfTwo1;
    }

    public static int GetFormatComponentCount(DataFormat format)
    {
      switch (format)
      {
        case DataFormat.ColorIndex:
        case DataFormat.Alpha:
        case DataFormat.Luminance:
          return 1;
        case DataFormat.RGB:
        case DataFormat.BGR:
          return 3;
        case DataFormat.RGBA:
        case DataFormat.BGRA:
          return 4;
        case DataFormat.LuminanceAlpha:
          return 2;
        default:
          return 0;
      }
    }

    public static int GetPaletteComponentCount(PaletteType palette)
    {
      switch (palette)
      {
        case PaletteType.RGB24:
        case PaletteType.BGR24:
          return 3;
        case PaletteType.RGB32:
        case PaletteType.RGBA32:
        case PaletteType.BGR32:
        case PaletteType.BGRA32:
          return 4;
        default:
          return 0;
      }
    }

    public static DataFormat GetPaletteBaseFormat(PaletteType palette)
    {
      switch (palette)
      {
        case PaletteType.RGB24:
          return DataFormat.RGB;
        case PaletteType.RGB32:
          return DataFormat.RGBA;
        case PaletteType.RGBA32:
          return DataFormat.RGBA;
        case PaletteType.BGR24:
          return DataFormat.BGR;
        case PaletteType.BGR32:
          return DataFormat.BGRA;
        case PaletteType.BGRA32:
          return DataFormat.BGRA;
        default:
          return DataFormat.RGBA;
      }
    }

    public static int GetDataTypeSize(DataType dataType)
    {
      switch (dataType)
      {
        case DataType.Byte:
        case DataType.UnsignedByte:
          return 1;
        case DataType.Short:
        case DataType.UnsignedShort:
        case DataType.Half:
          return 2;
        case DataType.Int:
        case DataType.UnsignedInt:
        case DataType.Float:
          return 4;
        case DataType.Double:
          return 8;
        default:
          return 0;
      }
    }

    public static int GetBpp(DataFormat format, DataType dataType)
    {
      return MemoryHelper.GetDataTypeSize(dataType) * MemoryHelper.GetFormatComponentCount(format);
    }

    public static int GetDataSize(int width, int height, int depth, DataFormat format, DataType dataType)
    {
      if (width <= 0)
        width = 1;
      if (height <= 0)
        height = 1;
      if (depth <= 0)
        depth = 1;
      return width * height * depth * MemoryHelper.GetBpp(format, dataType);
    }

    public static byte[] ReadStreamFully(Stream stream, int initialLength)
    {
      if (initialLength < 1)
        initialLength = 32768;
      byte[] buffer = new byte[initialLength];
      int length = 0;
      int num1;
      while ((num1 = stream.Read(buffer, length, buffer.Length - length)) > 0)
      {
        length += num1;
        if (length == buffer.Length)
        {
          int num2 = stream.ReadByte();
          if (num2 == -1)
            return buffer;
          byte[] numArray = new byte[buffer.Length * 2];
          Array.Copy((Array) buffer, (Array) numArray, buffer.Length);
          numArray[length] = (byte) num2;
          buffer = numArray;
          ++length;
        }
      }
      byte[] numArray1 = new byte[length];
      Array.Copy((Array) buffer, (Array) numArray1, length);
      return numArray1;
    }
  }
}
