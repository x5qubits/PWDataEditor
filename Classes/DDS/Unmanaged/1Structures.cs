// Decompiled with JetBrains decompiler
// Type: DevIL.Unmanaged.ImageID
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using System;

namespace DevIL.Unmanaged
{
  public struct ImageID : IEquatable<ImageID>
  {
    private int m_id;

    public int ID
    {
      get
      {
        return this.m_id;
      }
    }

    public ImageID(int id)
    {
      this.m_id = id;
    }

    public static implicit operator ImageID(int id)
    {
      return new ImageID(id);
    }

    public static implicit operator int(ImageID id)
    {
      return id.m_id;
    }

    public static bool operator <(ImageID a, ImageID b)
    {
      return a.m_id < b.m_id;
    }

    public static bool operator >(ImageID a, ImageID b)
    {
      return a.m_id > b.m_id;
    }

    public static bool operator ==(ImageID a, ImageID b)
    {
      return a.m_id == b.m_id;
    }

    public static bool operator !=(ImageID a, ImageID b)
    {
      return a.m_id != b.m_id;
    }

    public bool Equals(ImageID other)
    {
      return this.m_id == other.m_id;
    }

    public override bool Equals(object obj)
    {
      if (obj is ImageID)
        return this.m_id == ((ImageID) obj).m_id;
      return false;
    }

    public override int GetHashCode()
    {
      return this.m_id.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("ImageID: {0}", (object) this.m_id.ToString());
    }
  }
}
