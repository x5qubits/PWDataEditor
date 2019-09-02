// Decompiled with JetBrains decompiler
// Type: DevIL.ImageImporter
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;
using System;
using System.IO;

namespace DevIL
{
  public sealed class ImageImporter : IDisposable
  {
    private FilterEngine m_filterEngine;
    private TransformEngine m_transformEngine;
    private bool m_isDisposed;

    public FilterEngine Filter
    {
      get
      {
        return this.m_filterEngine;
      }
    }

    public TransformEngine Transform
    {
      get
      {
        return this.m_transformEngine;
      }
    }

    public ImageImporter()
    {
      this.m_filterEngine = new FilterEngine();
      this.m_transformEngine = new TransformEngine();
      this.m_isDisposed = false;
      IL.AddRef();
    }

    ~ImageImporter()
    {
      this.Dispose(false);
    }

    public Image LoadImage(string filename)
    {
      if (string.IsNullOrEmpty(filename))
        throw new IOException("Failed to load image, file does not exist.");
      this.CheckDisposed();
      ImageID id = this.GenImage();
      if (IL.LoadImage(filename))
        return new Image(id);
      throw new IOException(string.Format("Failed to loade image: {0}", (object) IL.GetError()));
    }

    public Image LoadImage(ImageType imageType, string filename)
    {
      if (imageType == ImageType.Unknown || string.IsNullOrEmpty(filename))
        throw new IOException("Failed to load image, invalid imagetype or file does not exist.");
      this.CheckDisposed();
      ImageID id = this.GenImage();
      if (IL.LoadImage(imageType, filename))
        return new Image(id);
      throw new IOException(string.Format("Failed to loade image: {0}", (object) IL.GetError()));
    }

    public Image LoadImageFromStream(Stream stream)
    {
      if (stream == null || !stream.CanRead)
        throw new IOException("Failed to load image, Stream is null or write-only");
      this.CheckDisposed();
      ImageID id = this.GenImage();
      if (IL.LoadImageFromStream(stream))
        return new Image(id);
      throw new IOException(string.Format("Failed to loade image: {0}", (object) IL.GetError()));
    }

    public Image LoadImageFromStream(ImageType imageType, Stream stream)
    {
      if (imageType == ImageType.Unknown || stream == null || !stream.CanRead)
        throw new IOException("Failed to load image, invalid imagetype or stream can't be read from.");
      this.CheckDisposed();
      ImageID id = this.GenImage();
      if (IL.LoadImageFromStream(imageType, stream))
        return new Image(id);
      throw new IOException(string.Format("Failed to load image: {0}", (object) IL.GetError()));
    }

    public string[] GetSupportedExtensions()
    {
      return IL.GetImportExtensions();
    }

    private void CheckDisposed()
    {
      if (this.m_isDisposed)
        throw new ObjectDisposedException("Importer has been disposed.");
    }

    private ImageID GenImage()
    {
      ImageID image = IL.GenerateImage();
      IL.BindImage(image);
      return image;
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
