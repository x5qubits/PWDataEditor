// Decompiled with JetBrains decompiler
// Type: DevIL.ManagedImage
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public class ManagedImage
  {
    private MipMapChainCollection m_faces;
    private AnimationChainCollection m_animChain;

    public MipMapChainCollection Faces
    {
      get
      {
        return this.m_faces;
      }
    }

    public AnimationChainCollection AnimationChain
    {
      get
      {
        return this.m_animChain;
      }
    }

    public ManagedImage(Image image)
    {
      this.m_faces = new MipMapChainCollection();
      this.m_animChain = new AnimationChainCollection();
      if (!image.IsValid)
        return;
      ImageID imageId = image.ImageID;
      this.LoadFaces(imageId, 0);
      this.LoadAnimationChain(imageId);
    }

    private ManagedImage(ImageID imageID, int imageNum)
    {
      this.m_faces = new MipMapChainCollection();
      this.m_animChain = new AnimationChainCollection();
      this.LoadFaces(imageID, imageNum);
    }

    private void LoadAnimationChain(ImageID imageID)
    {
      IL.BindImage(imageID);
      int num = IL.ilGetInteger(3569U) + 1;
      if (num <= 1)
        return;
      this.m_animChain.Add(this);
      for (int imageNum = 1; imageNum < num; ++imageNum)
      {
        ManagedImage managedImage = new ManagedImage(imageID, imageNum);
        if (managedImage.Faces.Count != 0)
          this.m_animChain.Add(managedImage);
      }
    }

    private void LoadFaces(ImageID imageID, int imageNum)
    {
      IL.BindImage(imageID);
      if (!IL.ActiveImage(imageNum))
        return;
      int num = IL.ilGetInteger(3553U) + 1;
      for (int faceNum = 0; faceNum < num; ++faceNum)
      {
        MipMapChain mipMapChain = this.CreateMipMapChain(imageID, imageNum, faceNum);
        if (mipMapChain == null)
          break;
        this.m_faces.Add(mipMapChain);
      }
    }

    private MipMapChain CreateMipMapChain(ImageID imageID, int imageNum, int faceNum)
    {
      IL.BindImage(imageID);
      if (!IL.ActiveImage(imageNum))
        return (MipMapChain) null;
      if (!IL.ActiveFace(faceNum))
        return (MipMapChain) null;
      int num = IL.ilGetInteger(3570U) + 1;
      MipMapChain mipMapChain = new MipMapChain();
      for (int mipMapIndex = 0; mipMapIndex < num; ++mipMapIndex)
      {
        ImageData imageData = ImageData.Load(new Subimage(imageID, imageNum, faceNum, 0, mipMapIndex));
        if (imageData != null)
          mipMapChain.Add(imageData);
        else
          break;
      }
      mipMapChain.TrimExcess();
      return mipMapChain;
    }
  }
}
