// Decompiled with JetBrains decompiler
// Type: DevIL.PngSaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class PngSaveState : SaveState
  {
    private int m_pngAlphaIndex = -1;
    private string m_pngAuthName = string.Empty;
    private string m_pngTitle = string.Empty;
    private string m_pngDescription = string.Empty;
    private bool m_usePngInterlace;

    public int PngAlphaIndex
    {
      get
      {
        return this.m_pngAlphaIndex;
      }
      set
      {
        this.m_pngAlphaIndex = value;
      }
    }

    public string PngAuthorName
    {
      get
      {
        return this.m_pngAuthName;
      }
      set
      {
        this.m_pngAuthName = value;
      }
    }

    public string PngTitle
    {
      get
      {
        return this.m_pngTitle;
      }
      set
      {
        this.m_pngTitle = value;
      }
    }

    public string PngDescription
    {
      get
      {
        return this.m_pngDescription;
      }
      set
      {
        this.m_pngDescription = value;
      }
    }

    public bool UsePngInterlace
    {
      get
      {
        return this.m_usePngInterlace;
      }
      set
      {
        this.m_usePngInterlace = value;
      }
    }

    public override void Apply()
    {
      base.Apply();
      if (!IL.IsInitialized)
        return;
      IL.SetInteger(ILIntegerMode.PngAlphaIndex, this.m_pngAlphaIndex);
      IL.SetString(ILStringMode.PngAuthorName, this.m_pngAuthName);
      IL.SetString(ILStringMode.PngTitle, this.m_pngTitle);
      IL.SetString(ILStringMode.PngDescription, this.m_pngDescription);
      IL.SetBoolean(ILBooleanMode.PngInterlace, this.m_usePngInterlace);
    }
  }
}
