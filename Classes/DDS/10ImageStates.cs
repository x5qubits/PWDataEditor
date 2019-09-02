// Decompiled with JetBrains decompiler
// Type: DevIL.BmpSaveState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class BmpSaveState : SaveState
  {
    private int m_pcdPicNumber = 2;
    private bool m_useBmpRle;

    public bool UseBmpRle
    {
      get
      {
        return this.m_useBmpRle;
      }
      set
      {
        this.m_useBmpRle = value;
      }
    }

    public int PcdPicNumber
    {
      get
      {
        return this.m_pcdPicNumber;
      }
      set
      {
        this.m_pcdPicNumber = value;
      }
    }

    public override void Apply()
    {
      base.Apply();
      if (!IL.IsInitialized)
        return;
      IL.SetBoolean(ILBooleanMode.BmpRLE, this.m_useBmpRle);
      IL.SetInteger(ILIntegerMode.PcdPicNumber, this.m_pcdPicNumber);
    }
  }
}
