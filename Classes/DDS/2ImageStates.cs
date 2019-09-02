// Decompiled with JetBrains decompiler
// Type: DevIL.HintState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class HintState : IImageState
  {
    private CompressionHint m_compressHint = CompressionHint.UseCompression;
    private MemoryHint m_memHint = MemoryHint.Fastest;

    public CompressionHint CompressionHint
    {
      get
      {
        return this.m_compressHint;
      }
      set
      {
        this.m_compressHint = value;
      }
    }

    public MemoryHint MemoryHint
    {
      get
      {
        return this.m_memHint;
      }
      set
      {
        this.m_memHint = value;
      }
    }

    public void Apply()
    {
      if (!IL.IsInitialized)
        return;
      IL.SetCompressionHint(this.m_compressHint);
      IL.SetMemoryHint(this.m_memHint);
    }
  }
}
