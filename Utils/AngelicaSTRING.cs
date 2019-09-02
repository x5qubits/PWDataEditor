using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AngelicaSTRING
{
    public Encoding DefaultEncoding { get; set; }
    private byte[] _m_name;
    private int _m_Size = 64;

    public AngelicaSTRING()
    {
        DefaultEncoding = Encoding.Unicode;
    }

    public AngelicaSTRING(int _Size)
    {
        DefaultEncoding = Encoding.Unicode;
        _m_Size = _Size;
        _m_name = new byte[_m_Size];
    }

    public AngelicaSTRING(int _Size, BinaryReader bReader, Encoding defaultEncoding)
    {
        DefaultEncoding = defaultEncoding;
        _m_Size = _Size;
        _m_name = bReader.ReadBytes(_Size);
    }

    public AngelicaSTRING(int _Size, BinaryReader bReader)
    {
        DefaultEncoding = Encoding.Unicode;
        _m_Size = _Size;
        _m_name = bReader.ReadBytes(_Size);
    }

    public string Value
    {
        get
        {
            return DefaultEncoding.GetString(_m_name);
        }
        set
        {
            _m_name = DefaultEncoding.GetBytes(value);
            _m_Size = _m_name.Length;
        }
    }

    public int Lenght
    {
        get
        {
            return _m_Size;
        }
        set
        {
            _m_Size = value;
        }
    }

    public byte[] EncodedValue
    {
        get
        {
            return _m_name;
        }
    }
}

