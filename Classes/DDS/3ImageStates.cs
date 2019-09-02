// Decompiled with JetBrains decompiler
// Type: DevIL.QuantizationState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class QuantizationState : IImageState
  {
    private Quantization m_quantMode = Quantization.Wu;
    private int m_maxQuantIndices = 256;
    private int m_neuQuantSample = 15;

    public Quantization QuantizationMode
    {
      get
      {
        return this.m_quantMode;
      }
      set
      {
        this.m_quantMode = value;
      }
    }

    public int MaxQuantizationIndices
    {
      get
      {
        return this.m_maxQuantIndices;
      }
      set
      {
        this.m_maxQuantIndices = value;
      }
    }

    public int NeuQuantizationSamples
    {
      get
      {
        return this.m_neuQuantSample;
      }
      set
      {
        this.m_neuQuantSample = value;
      }
    }

    public void Apply()
    {
      if (!IL.IsInitialized)
        return;
      IL.SetQuantization(this.m_quantMode);
      IL.SetInteger(ILIntegerMode.MaxQuantizationIndices, this.m_maxQuantIndices);
      IL.SetInteger(ILIntegerMode.NeuQuantizationSample, this.m_neuQuantSample);
    }
  }
}
