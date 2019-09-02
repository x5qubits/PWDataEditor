// Decompiled with JetBrains decompiler
// Type: DevIL.TiffSaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class TiffSaveState : SaveState
  {
    private string m_tifAuthName = string.Empty;
    private string m_tifDescription = string.Empty;
    private string m_tifDocumentName = string.Empty;
    private string m_tifHostComputer = string.Empty;

    public string TifAuthorName
    {
      get
      {
        return this.m_tifAuthName;
      }
      set
      {
        this.m_tifAuthName = value;
      }
    }

    public string TifDescription
    {
      get
      {
        return this.m_tifDescription;
      }
      set
      {
        this.m_tifDescription = value;
      }
    }

    public string TifDocumentName
    {
      get
      {
        return this.m_tifDocumentName;
      }
      set
      {
        this.m_tifDocumentName = value;
      }
    }

    public string TifHostComputer
    {
      get
      {
        return this.m_tifHostComputer;
      }
      set
      {
        this.m_tifHostComputer = value;
      }
    }

    public override void Apply()
    {
      base.Apply();
      if (!IL.IsInitialized)
        return;
      IL.SetString(ILStringMode.TifAuthorName, this.m_tifAuthName);
      IL.SetString(ILStringMode.TifDescription, this.m_tifDescription);
      IL.SetString(ILStringMode.TifDocumentName, this.m_tifDocumentName);
      IL.SetString(ILStringMode.TifHostComputer, this.m_tifHostComputer);
    }
  }
}
