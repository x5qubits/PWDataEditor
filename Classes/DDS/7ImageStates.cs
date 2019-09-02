// Decompiled with JetBrains decompiler
// Type: DevIL.TgaSaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class TgaSaveState : SaveState
  {
    private string m_tgaId = string.Empty;
    private string m_tgaAuthName = string.Empty;
    private string m_tgaAuthComment = string.Empty;
    private bool m_useTgaRle;

    public string TgaID
    {
      get
      {
        return this.m_tgaId;
      }
      set
      {
        this.m_tgaId = value;
      }
    }

    public string TgaAuthorName
    {
      get
      {
        return this.m_tgaAuthName;
      }
      set
      {
        this.m_tgaAuthName = value;
      }
    }

    public string TgaAuthorComment
    {
      get
      {
        return this.m_tgaAuthComment;
      }
      set
      {
        this.m_tgaAuthComment = value;
      }
    }

    public bool UseTgaRle
    {
      get
      {
        return this.m_useTgaRle;
      }
      set
      {
        this.m_useTgaRle = value;
      }
    }

    public override void Apply()
    {
      base.Apply();
      if (!IL.IsInitialized)
        return;
      IL.SetString(ILStringMode.TgaID, this.m_tgaId);
      IL.SetString(ILStringMode.TgaAuthorName, this.m_tgaAuthName);
      IL.SetString(ILStringMode.TgaAuthorComment, this.m_tgaAuthComment);
      IL.SetBoolean(ILBooleanMode.TgaRLE, this.m_useTgaRle);
      IL.SetBoolean(ILBooleanMode.TgaCreateStamp, true);
    }
  }
}
