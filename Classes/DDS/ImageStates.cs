// Decompiled with JetBrains decompiler
// Type: DevIL.ImageState
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using DevIL.Unmanaged;

namespace DevIL
{
  public sealed class ImageState : IImageState
  {
    private DataFormat m_absoluteFormat = DataFormat.BGRA;
    private DataType m_absoluteDataType = DataType.UnsignedByte;
    private OriginLocation m_absoluteOrigin = OriginLocation.LowerLeft;
    private Color m_keyColor = new Color(1f, 0.0f, 1f, 1f);
    private bool m_blitBlend = true;
    private bool m_useAbsoluteFormat;
    private bool m_useAbsoluteDataType;
    private bool m_useAbsoluteOrigin;
    private bool m_convertPalette;
    private bool m_defaultImageOnFail;
    private bool m_useColorKey;

    public bool UseAbsoluteFormat
    {
      get
      {
        return this.m_useAbsoluteFormat;
      }
      set
      {
        this.m_useAbsoluteFormat = value;
      }
    }

    public bool UseAbsoluteDataType
    {
      get
      {
        return this.m_useAbsoluteDataType;
      }
      set
      {
        this.m_useAbsoluteDataType = value;
      }
    }

    public bool UseAbsoluteOrigin
    {
      get
      {
        return this.m_useAbsoluteOrigin;
      }
      set
      {
        this.m_useAbsoluteOrigin = value;
      }
    }

    public DataFormat AbsoluteFormat
    {
      get
      {
        return this.m_absoluteFormat;
      }
      set
      {
        this.m_absoluteFormat = value;
        this.UseAbsoluteFormat = true;
      }
    }

    public DataType AbsoluteDataType
    {
      get
      {
        return this.m_absoluteDataType;
      }
      set
      {
        this.m_absoluteDataType = value;
        this.UseAbsoluteDataType = true;
      }
    }

    public OriginLocation AbsoluteOrigin
    {
      get
      {
        return this.m_absoluteOrigin;
      }
      set
      {
        this.m_absoluteOrigin = value;
        this.UseAbsoluteOrigin = true;
      }
    }

    public bool ConvertPalette
    {
      get
      {
        return this.m_convertPalette;
      }
      set
      {
        this.m_convertPalette = value;
      }
    }

    public bool DefaultImageOnFail
    {
      get
      {
        return this.m_defaultImageOnFail;
      }
      set
      {
        this.m_defaultImageOnFail = value;
      }
    }

    public bool UseColorKey
    {
      get
      {
        return this.m_useColorKey;
      }
      set
      {
        this.m_useColorKey = value;
      }
    }

    public Color ColorKey
    {
      get
      {
        return this.m_keyColor;
      }
      set
      {
        this.m_keyColor = value;
        this.m_useColorKey = true;
      }
    }

    public bool BlitBlend
    {
      get
      {
        return this.m_blitBlend;
      }
      set
      {
        this.m_blitBlend = value;
      }
    }

    public void Apply()
    {
      if (!IL.IsInitialized)
        return;
      if (this.m_useAbsoluteFormat)
        IL.Enable(ILEnable.AbsoluteFormat);
      else
        IL.Disable(ILEnable.AbsoluteFormat);
      IL.SetDataFormat(this.m_absoluteFormat);
      if (this.m_useAbsoluteDataType)
        IL.Enable(ILEnable.AbsoluteType);
      else
        IL.Disable(ILEnable.AbsoluteType);
      IL.SetDataType(this.m_absoluteDataType);
      if (this.m_useAbsoluteOrigin)
        IL.Enable(ILEnable.AbsoluteOrigin);
      else
        IL.Disable(ILEnable.AbsoluteOrigin);
      IL.SetOriginLocation(this.m_absoluteOrigin);
      if (this.m_convertPalette)
        IL.Enable(ILEnable.ConvertPalette);
      else
        IL.Disable(ILEnable.ConvertPalette);
      if (this.m_defaultImageOnFail)
        IL.Enable(ILEnable.DefaultOnFail);
      else
        IL.Disable(ILEnable.DefaultOnFail);
      if (this.m_useColorKey)
      {
        IL.Enable(ILEnable.UseColorKey);
        IL.SetKeyColor(this.m_keyColor);
      }
      else
        IL.Disable(ILEnable.UseColorKey);
      if (this.m_blitBlend)
        IL.Enable(ILEnable.BlitBlend);
      else
        IL.Disable(ILEnable.BlitBlend);
    }
  }
}
