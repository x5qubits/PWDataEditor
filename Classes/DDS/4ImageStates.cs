// Decompiled with JetBrains decompiler
// Type: DevIL.CompressionState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class CompressionState : IImageState
  {
    private CompressionAlgorithm m_compression = CompressionAlgorithm.ZLib;
    private CompressedDataFormat m_dxtcFormat = CompressedDataFormat.DXT1;
    private CompressedDataFormat m_vtfCompression = CompressedDataFormat.None;
    private bool m_keepDxtcData;

    public CompressionAlgorithm Compression
    {
      get
      {
        return this.m_compression;
      }
      set
      {
        this.m_compression = value;
      }
    }

    public CompressedDataFormat DxtcFormat
    {
      get
      {
        return this.m_dxtcFormat;
      }
      set
      {
        this.m_dxtcFormat = value;
      }
    }

    public CompressedDataFormat VtfCompression
    {
      get
      {
        return this.m_vtfCompression;
      }
      set
      {
        this.m_vtfCompression = value;
      }
    }

    public bool KeepDxtcData
    {
      get
      {
        return this.m_keepDxtcData;
      }
      set
      {
        this.m_keepDxtcData = value;
      }
    }

    public void Apply()
    {
      if (!IL.IsInitialized)
        return;
      IL.SetCompressionAlgorithm(this.m_compression);
      IL.SetDxtcFormat(this.m_dxtcFormat);
      IL.SetInteger(ILIntegerMode.VTFCompression, (int) this.m_vtfCompression);
      IL.SetBoolean(ILBooleanMode.KeepDxtcData, this.m_keepDxtcData);
    }
  }
}
