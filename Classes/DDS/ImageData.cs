// Decompiled with JetBrains decompiler
// Type: DevIL.ImageData
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public class ImageData
  {
    private ImageInfo m_info;
    private byte[] m_data;
    private byte[] m_compressedData;
    private byte[] m_paletteData;

    public DataFormat Format
    {
      get
      {
        return this.m_info.Format;
      }
    }

    public CompressedDataFormat DxtcFormat
    {
      get
      {
        return this.m_info.DxtcFormat;
      }
    }

    public DataType DataType
    {
      get
      {
        return this.m_info.DataType;
      }
    }

    public PaletteType PaletteType
    {
      get
      {
        return this.m_info.PaletteType;
      }
    }

    public DataFormat PaletteBaseType
    {
      get
      {
        return this.m_info.PaletteBaseType;
      }
    }

    public CubeMapFace CubeFace
    {
      get
      {
        return this.m_info.CubeFlags;
      }
    }

    public OriginLocation Origin
    {
      get
      {
        return this.m_info.Origin;
      }
    }

    public int Width
    {
      get
      {
        return this.m_info.Width;
      }
    }

    public int Height
    {
      get
      {
        return this.m_info.Height;
      }
    }

    public int Depth
    {
      get
      {
        return this.m_info.Depth;
      }
    }

    public int BitsPerPixel
    {
      get
      {
        return this.m_info.BitsPerPixel;
      }
    }

    public int BytesPerPixel
    {
      get
      {
        return this.m_info.BytesPerPixel;
      }
    }

    public int ChannelCount
    {
      get
      {
        return this.m_info.Channels;
      }
    }

    public int Duration
    {
      get
      {
        return this.m_info.Duration;
      }
    }

    public int SizeOfData
    {
      get
      {
        return this.m_info.SizeOfData;
      }
    }

    public int OffsetX
    {
      get
      {
        return this.m_info.OffsetX;
      }
    }

    public int OffsetY
    {
      get
      {
        return this.m_info.OffsetY;
      }
    }

    public int PlaneSize
    {
      get
      {
        return this.m_info.PlaneSize;
      }
    }

    public int PaletteBytesPerPixel
    {
      get
      {
        return this.m_info.PaletteBytesPerPixel;
      }
    }

    public int PaletteColumnCount
    {
      get
      {
        return this.m_info.PaletteColumnCount;
      }
    }

    public bool HasDXTCData
    {
      get
      {
        if (this.m_info.HasDXTC)
          return this.m_compressedData != null;
        return false;
      }
    }

    public bool HasPaletteData
    {
      get
      {
        if (this.m_info.HasPalette)
          return this.m_paletteData != null;
        return false;
      }
    }

    public bool IsCubeMap
    {
      get
      {
        return this.m_info.IsCubeMap;
      }
    }

    public bool IsSphereMap
    {
      get
      {
        return this.m_info.IsSphereMap;
      }
    }

    public byte[] Data
    {
      get
      {
        return this.m_data;
      }
    }

    public byte[] CompressedData
    {
      get
      {
        return this.m_compressedData;
      }
    }

    public byte[] PaletteData
    {
      get
      {
        return this.m_paletteData;
      }
    }

    private ImageData()
    {
    }

    internal static ImageData Load(Subimage subimage)
    {
      if (!subimage.Activate())
        return (ImageData) null;
      ImageData imageData = new ImageData();
      imageData.m_info = IL.GetImageInfo();
      imageData.m_data = IL.GetImageData();
      if (imageData.m_data == null)
        return (ImageData) null;
      if (imageData.m_info.HasDXTC)
        imageData.m_compressedData = IL.GetDxtcData(imageData.DxtcFormat);
      if (imageData.m_info.HasPalette)
        imageData.m_paletteData = IL.GetPaletteData();
      return imageData;
    }
  }
}
