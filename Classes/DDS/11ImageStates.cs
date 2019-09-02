// Decompiled with JetBrains decompiler
// Type: DevIL.SgiSaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class SgiSaveState : SaveState
  {
    private bool m_useSgiRle;

    public bool UseSgiRle
    {
      get
      {
        return this.m_useSgiRle;
      }
      set
      {
        this.m_useSgiRle = value;
      }
    }

    public override void Apply()
    {
      base.Apply();
      if (!IL.IsInitialized)
        return;
      IL.SetBoolean(ILBooleanMode.SgiRLE, this.m_useSgiRle);
    }
  }
}
