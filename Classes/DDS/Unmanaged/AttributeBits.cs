// Decompiled with JetBrains decompiler
// Type: DevIL.Unmanaged.AttributeBits
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using System;

namespace DevIL.Unmanaged
{
  [Flags]
  public enum AttributeBits
  {
    Origin = 1,
    File = 2,
    Palette = 4,
    Format = 8,
    Type = 16,
    Compress = 32,
    LoadFail = 64,
    FormatSpecific = 128,
    All = 1048575,
  }
}
