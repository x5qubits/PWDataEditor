// Decompiled with JetBrains decompiler
// Type: DevIL.ImageExporter
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;
using System;
using System.IO;

namespace DevIL
{
  public sealed class ImageExporter : IDisposable
  {
    private bool m_isDisposed;

    public bool IsDisposed
    {
      get
      {
        return this.m_isDisposed;
      }
    }

    public ImageExporter()
    {
      this.m_isDisposed = false;
      IL.AddRef();
    }

    ~ImageExporter()
    {
      this.Dispose(false);
    }

    public bool SaveImage(Image image, string filename)
    {
      if (!image.IsValid || string.IsNullOrEmpty(filename))
        return false;
      this.CheckDisposed();
      IL.BindImage(image.ImageID);
      return IL.SaveImage(filename);
    }

    public bool SaveImage(Image image, ImageType imageType, string filename)
    {
      if (!image.IsValid || imageType == ImageType.Unknown || string.IsNullOrEmpty(filename))
        return false;
      this.CheckDisposed();
      IL.BindImage(image.ImageID);
      return IL.SaveImage(imageType, filename);
    }

    public bool SaveImageToStream(Image image, ImageType imageType, Stream stream)
    {
      if (!image.IsValid || imageType == ImageType.Unknown || (stream == null || !stream.CanWrite))
        return false;
      this.CheckDisposed();
      IL.BindImage(image.ImageID);
      return IL.SaveImageToStream(imageType, stream);
    }

    public string[] GetSupportedExtensions()
    {
      return IL.GetExportExtensions();
    }

    private void CheckDisposed()
    {
      if (this.m_isDisposed)
        throw new ObjectDisposedException("Exporter has been disposed.");
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (this.m_isDisposed)
        return;
      IL.Release();
      this.m_isDisposed = true;
    }
  }
}
