// Decompiled with JetBrains decompiler
// Type: DevIL.Unmanaged.ImageInfo
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

namespace DevIL.Unmanaged
{
  public struct ImageInfo
  {
    public DataFormat Format;
    public CompressedDataFormat DxtcFormat;
    public DataType DataType;
    public PaletteType PaletteType;
    public DataFormat PaletteBaseType;
    public CubeMapFace CubeFlags;
    public OriginLocation Origin;
    public int Width;
    public int Height;
    public int Depth;
    public int BitsPerPixel;
    public int BytesPerPixel;
    public int Channels;
    public int Duration;
    public int SizeOfData;
    public int OffsetX;
    public int OffsetY;
    public int PlaneSize;
    public int FaceCount;
    public int ImageCount;
    public int LayerCount;
    public int MipMapCount;
    public int PaletteBytesPerPixel;
    public int PaletteColumnCount;

    public bool HasDXTC
    {
      get
      {
        return this.DxtcFormat != CompressedDataFormat.None;
      }
    }

    public bool HasPalette
    {
      get
      {
        return this.PaletteType != PaletteType.None;
      }
    }

    public bool IsCubeMap
    {
      get
      {
        if (this.CubeFlags != CubeMapFace.None)
          return this.CubeFlags != CubeMapFace.SphereMap;
        return false;
      }
    }

    public bool IsSphereMap
    {
      get
      {
        return this.CubeFlags == CubeMapFace.SphereMap;
      }
    }
  }
}
