// Decompiled with JetBrains decompiler
// Type: DevIL.LanguageState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class LanguageState : IImageState
  {
    private Language m_language = Language.English;

    public Language Language
    {
      get
      {
        return this.m_language;
      }
      set
      {
        this.m_language = value;
      }
    }

    public void Apply()
    {
      if (!ILU.IsInitialized)
        return;
      ILU.SetLanguage(this.m_language);
    }
  }
}
