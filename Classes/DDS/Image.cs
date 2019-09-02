// Decompiled with JetBrains decompiler
// Type: DevIL.Image
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;
using System;

namespace DevIL
{
  public sealed class Image : IDisposable, IEquatable<Image>
  {
    private static Image s_default = new Image(new ImageID(0));
    private bool m_isDisposed;
    private ImageID m_id;

    internal ImageID ImageID
    {
      get
      {
        return this.m_id;
      }
    }

    internal bool IsValid
    {
      get
      {
        if ((int) this.m_id >= 0)
          return IL.IsInitialized;
        return false;
      }
    }

    public static Image DefaultImage
    {
      get
      {
        return Image.s_default;
      }
    }

    public DataFormat Format
    {
      get
      {
        if (!this.IsValid)
          return DataFormat.RGBA;
        this.Bind();
        return (DataFormat) IL.ilGetInteger(3562U);
      }
    }

    public CompressedDataFormat DxtcFormat
    {
      get
      {
        if (!this.IsValid)
          return CompressedDataFormat.None;
        this.Bind();
        return (CompressedDataFormat) IL.ilGetInteger(1805U);
      }
    }

    public DataType DataType
    {
      get
      {
        if (!this.IsValid)
          return DataType.UnsignedByte;
        this.Bind();
        return (DataType) IL.ilGetInteger(3563U);
      }
    }

    public PaletteType PaletteType
    {
      get
      {
        if (!this.IsValid)
          return PaletteType.None;
        this.Bind();
        return (PaletteType) IL.ilGetInteger(3564U);
      }
    }

    public DataFormat PaletteBaseType
    {
      get
      {
        if (!this.IsValid)
          return DataFormat.RGBA;
        this.Bind();
        return (DataFormat) IL.ilGetInteger(3568U);
      }
    }

    public OriginLocation Origin
    {
      get
      {
        if (!this.IsValid)
          return OriginLocation.UpperLeft;
        this.Bind();
        return (OriginLocation) IL.ilGetInteger(3582U);
      }
    }

    public int Width
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageWidth);
      }
    }

    public int Height
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageHeight);
      }
    }

    public int Depth
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageDepth);
      }
    }

    public int BytesPerPixel
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageBytesPerPixel);
      }
    }

    public int BitsPerPixel
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageBitsPerPixel);
      }
    }

    public int ChannelCount
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageChannels);
      }
    }

    public int PaletteBytesPerPixel
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImagePaletteBytesPerPixel);
      }
    }

    public int PaletteColumnCount
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImagePaletteColumnCount);
      }
    }

    public int FaceCount
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageFaceCount) + 1;
      }
    }

    public int ImageArrayCount
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageArrayCount) + 1;
      }
    }

    public int MipMapCount
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageMipMapCount) + 1;
      }
    }

    public int LayerCount
    {
      get
      {
        if (!this.IsValid)
          return 0;
        this.Bind();
        return IL.GetInteger(ILIntegerMode.ImageLayerCount) + 1;
      }
    }

    public bool HasDXTCData
    {
      get
      {
        if (!this.IsValid)
          return false;
        return this.DxtcFormat != CompressedDataFormat.None;
      }
    }

    public bool HasPaletteData
    {
      get
      {
        if (!this.IsValid)
          return false;
        return this.PaletteType != PaletteType.None;
      }
    }

    public bool IsCubeMap
    {
      get
      {
        if (!this.IsValid)
          return false;
        CubeMapFace integer = (CubeMapFace) IL.ilGetInteger(3581U);
        if (integer != CubeMapFace.None)
          return integer != CubeMapFace.SphereMap;
        return false;
      }
    }

    public bool IsSphereMap
    {
      get
      {
        if (!this.IsValid)
          return false;
        return IL.ilGetInteger(3581U) == 65536;
      }
    }

    internal Image(ImageID id)
    {
      this.m_id = id;
    }

    ~Image()
    {
      this.Dispose(false);
    }

    public void Bind()
    {
      IL.BindImage(this.m_id);
    }

    public bool ConvertToDxtc(CompressedDataFormat compressedFormat)
    {
      if (!Image.CheckValid(this))
        return false;
      this.Bind();
      return IL.ImageToDxtcData(compressedFormat);
    }

    public bool CopyFrom(Image srcImage)
    {
      if (!Image.CheckValid(this) || !Image.CheckValid(srcImage))
        return false;
      this.Bind();
      return IL.CopyImage(srcImage.ImageID);
    }

    public bool CopyTo(Image destImage)
    {
      if (!Image.CheckValid(this) || !Image.CheckValid(destImage))
        return false;
      destImage.Bind();
      return IL.CopyImage(this.ImageID);
    }

    public Image Clone()
    {
      ImageID image1 = IL.GenerateImage();
      Image image2 = new Image(image1);
      IL.BindImage(image1);
      IL.CopyImage(this.m_id);
      return image2;
    }

    public void Resize(int width, int height, int depth, SamplingFilter filter, bool regenerateMipMaps)
    {
      width = Math.Max(1, width);
      height = Math.Max(1, height);
      depth = Math.Max(1, depth);
      this.Bind();
      SamplingFilter samplingFilter = ILU.GetSamplingFilter();
      ILU.SetSamplingFilter(filter);
      ILU.Scale(width, height, depth);
      if (regenerateMipMaps)
      {
        this.Bind();
        ILU.BuildMipMaps();
      }
      ILU.SetSamplingFilter(samplingFilter);
    }

    public void ResizeToNearestPowerOfTwo(SamplingFilter filter, bool regenerateMipMaps)
    {
      int width = this.Width;
      int height = this.Height;
      int depth = this.Depth;
      int nearestPowerOfTwo1 = MemoryHelper.RoundToNearestPowerOfTwo(width);
      int nearestPowerOfTwo2 = MemoryHelper.RoundToNearestPowerOfTwo(height);
      int nearestPowerOfTwo3 = MemoryHelper.RoundToNearestPowerOfTwo(depth);
      this.Bind();
      SamplingFilter samplingFilter = ILU.GetSamplingFilter();
      ILU.SetSamplingFilter(filter);
      ILU.Scale(nearestPowerOfTwo1, nearestPowerOfTwo2, nearestPowerOfTwo3);
      if (regenerateMipMaps)
      {
        this.Bind();
        ILU.BuildMipMaps();
      }
      ILU.SetSamplingFilter(samplingFilter);
    }

    public ImageInfo GetImageInfo()
    {
      ImageInfo imageInfo = new ImageInfo();
      if (Image.CheckValid(this))
      {
        this.Bind();
        imageInfo = IL.GetImageInfo();
      }
      return imageInfo;
    }

    public ImageData GetImageData(int imageIndex, int faceIndex, int layerIndex, int mipmapIndex)
    {
      if (!this.IsValid || imageIndex < 0 || (faceIndex < 0 || layerIndex < 0) || mipmapIndex < 0)
        return (ImageData) null;
      return ImageData.Load(new Subimage(this.m_id, imageIndex, faceIndex, layerIndex, mipmapIndex));
    }

    public ImageData GetImageData(CubeMapFace cubeMapFace, int mipmapIndex)
    {
      if (!this.IsValid || mipmapIndex < 0)
        return (ImageData) null;
      int faceCount = this.FaceCount;
      for (int index = 0; index < faceCount; ++index)
      {
        this.Bind();
        IL.ActiveFace(index);
        if ((CubeMapFace) IL.ilGetInteger(3581U) == cubeMapFace)
          return ImageData.Load(new Subimage(this.m_id, 0, index, 0, mipmapIndex));
      }
      return (ImageData) null;
    }

    public ImageData GetImageData(int mipmapIndex)
    {
      if (!this.IsValid || mipmapIndex < 0)
        return (ImageData) null;
      return ImageData.Load(new Subimage(this.m_id, 0, 0, 0, mipmapIndex));
    }

    public ManagedImage ToManaged()
    {
      if (this.IsValid)
        return new ManagedImage(this);
      return (ManagedImage) null;
    }

    public static bool CheckValid(Image image)
    {
      return image != null && image.IsValid;
    }

    public bool Equals(Image other)
    {
      return other.ImageID == this.ImageID;
    }

    public override bool Equals(object obj)
    {
      Image image = obj as Image;
      if (image == null)
        return false;
      return image.ImageID == this.ImageID;
    }

    public override int GetHashCode()
    {
      return this.m_id.GetHashCode();
    }

    public override string ToString()
    {
      return this.m_id.ToString();
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (!this.m_isDisposed)
        return;
      if (this.m_id > (ImageID) 0)
        IL.DeleteImage(this.m_id);
      this.m_isDisposed = true;
    }
  }
}
