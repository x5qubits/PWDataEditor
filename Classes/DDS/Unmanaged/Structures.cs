// Decompiled with JetBrains decompiler
// Type: DevIL.Unmanaged.Subimage
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

namespace DevIL.Unmanaged
{
  public struct Subimage
  {
    private ImageID m_rootImage;
    private int m_imageIndex;
    private int m_faceIndex;
    private int m_layerIndex;
    private int m_mipMapIndex;

    public ImageID RootImage
    {
      get
      {
        return this.m_rootImage;
      }
    }

    public int ImageIndex
    {
      get
      {
        return this.m_imageIndex;
      }
    }

    public int FaceIndex
    {
      get
      {
        return this.m_faceIndex;
      }
    }

    public int LayerIndex
    {
      get
      {
        return this.m_layerIndex;
      }
    }

    public int MipMapIndex
    {
      get
      {
        return this.m_mipMapIndex;
      }
    }

    public Subimage(ImageID rootImage)
    {
      this.m_rootImage = rootImage;
      this.m_imageIndex = 0;
      this.m_faceIndex = 0;
      this.m_layerIndex = 0;
      this.m_mipMapIndex = 0;
    }

    public Subimage(ImageID rootImage, int imageIndex)
    {
      this.m_rootImage = rootImage;
      this.m_imageIndex = imageIndex;
      this.m_faceIndex = 0;
      this.m_layerIndex = 0;
      this.m_mipMapIndex = 0;
    }

    public Subimage(ImageID rootImage, int imageIndex, int faceIndex)
    {
      this.m_rootImage = rootImage;
      this.m_imageIndex = imageIndex;
      this.m_faceIndex = faceIndex;
      this.m_layerIndex = 0;
      this.m_mipMapIndex = 0;
    }

    public Subimage(ImageID rootImage, int imageIndex, int faceIndex, int layerIndex)
    {
      this.m_rootImage = rootImage;
      this.m_imageIndex = imageIndex;
      this.m_faceIndex = faceIndex;
      this.m_layerIndex = layerIndex;
      this.m_mipMapIndex = 0;
    }

    public Subimage(ImageID rootImage, int imageIndex, int faceIndex, int layerIndex, int mipMapIndex)
    {
      this.m_rootImage = rootImage;
      this.m_imageIndex = imageIndex;
      this.m_faceIndex = faceIndex;
      this.m_layerIndex = layerIndex;
      this.m_mipMapIndex = mipMapIndex;
    }

    public bool Activate()
    {
      if ((int) this.m_rootImage <= 0)
        return false;
      IL.BindImage(this.m_rootImage);
      return (this.m_imageIndex <= 0 || IL.ActiveImage(this.m_imageIndex)) && (this.m_faceIndex <= 0 || IL.ActiveFace(this.m_faceIndex)) && ((this.m_layerIndex <= 0 || IL.ActiveLayer(this.m_layerIndex)) && (this.m_mipMapIndex <= 0 || IL.ActiveMipMap(this.m_mipMapIndex)));
    }
  }
}
