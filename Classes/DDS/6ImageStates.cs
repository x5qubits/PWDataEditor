// Decompiled with JetBrains decompiler
// Type: DevIL.JpgSaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class JpgSaveState : SaveState
  {
    private int m_jpgQuality = 99;
    private JpgSaveFormat m_jpgSaveFormat = JpgSaveFormat.Jpg;
    private bool m_jpgProgressive;

    public int JpgQuality
    {
      get
      {
        return this.m_jpgQuality;
      }
      set
      {
        this.m_jpgQuality = value;
      }
    }

    public JpgSaveFormat JpgSaveFormat
    {
      get
      {
        return this.m_jpgSaveFormat;
      }
      set
      {
        this.m_jpgSaveFormat = value;
      }
    }

    public bool UseJpgProgressive
    {
      get
      {
        return this.m_jpgProgressive;
      }
      set
      {
        this.m_jpgProgressive = value;
      }
    }

    public override void Apply()
    {
      if (!IL.IsInitialized)
        return;
      IL.SetInteger(ILIntegerMode.JpgQuality, this.m_jpgQuality);
      IL.SetJpgSaveFormat(this.m_jpgSaveFormat);
      if (this.m_jpgProgressive)
        IL.Enable(ILEnable.JpgProgressive);
      else
        IL.Disable(ILEnable.JpgProgressive);
    }
  }
}
