// Decompiled with JetBrains decompiler
// Type: DevIL.SaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public class SaveState : IImageState
  {
    private bool m_saveInterlaced;
    private bool m_overwriteExistingFile;
    private CompressionLibrary m_compressionLibrary;

    public bool SaveInterlaced
    {
      get
      {
        return this.m_saveInterlaced;
      }
      set
      {
        this.m_saveInterlaced = value;
      }
    }

    public bool OverwriteExistingFile
    {
      get
      {
        return this.m_overwriteExistingFile;
      }
      set
      {
        this.m_overwriteExistingFile = value;
      }
    }

    public CompressionLibrary CompressionLibrary
    {
      get
      {
        return this.m_compressionLibrary;
      }
      set
      {
        this.m_compressionLibrary = value;
      }
    }

    public virtual void Apply()
    {
      if (!IL.IsInitialized)
        return;
      if (this.m_saveInterlaced)
        IL.Enable(ILEnable.SaveInterlaced);
      else
        IL.Disable(ILEnable.SaveInterlaced);
      if (this.m_overwriteExistingFile)
        IL.Enable(ILEnable.OverwriteExistingFile);
      else
        IL.Disable(ILEnable.OverwriteExistingFile);
      switch (this.m_compressionLibrary)
      {
        case CompressionLibrary.Default:
          IL.Disable(ILEnable.NvidiaCompression);
          IL.Disable(ILEnable.SquishCompression);
          break;
        case CompressionLibrary.Nvidia:
          IL.Disable(ILEnable.SquishCompression);
          IL.Enable(ILEnable.NvidiaCompression);
          break;
        case CompressionLibrary.Squish:
          IL.Disable(ILEnable.NvidiaCompression);
          IL.Enable(ILEnable.SquishCompression);
          break;
      }
    }
  }
}
