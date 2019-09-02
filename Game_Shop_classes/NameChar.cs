using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Game_Shop_classes
{
    [Serializable]
    public class NameChar
    {
        private byte[] _m_name;
        /* Add \0 after the end (can be Size + 1) */
        public bool AppendEndStringChar;
        /* Add \0 at the end (at Size max) */
        public bool ReplaceEndStringChar;
        public string Name
        {
            get
            {
                string tString = DefaultEncoding.GetString(_m_name);
                if (tString.IndexOf((char)0x00) > -1)
                {
                    tString = tString.Remove(tString.IndexOf((char)0x00));
                }
                return tString;
            }
            set { reencode(value.TrimEnd((char)0x00)); }
        }

        public byte[] EncodedName
        {
            get { return _m_name; }
        }

        public Encoding DefaultEncoding { get; set; }

        private int _m_Size = 64;
        public int Size
        {
            get { return _m_Size; }
        }

        public NameChar()
        {
            DefaultEncoding = Encoding.Unicode;
        }

        public NameChar(int _Size)
        {
            DefaultEncoding = Encoding.Unicode;
            _m_Size = _Size;
            _m_name = new byte[_m_Size];
        }

        public NameChar(int _Size, BinaryReader bReader)
        {
            DefaultEncoding = Encoding.Unicode;
            _m_Size = _Size;
            _m_name = bReader.ReadBytes(_Size);
        }

        public NameChar(int _Size, BinaryReader bReader, Encoding defaultEncoding)
        {
            DefaultEncoding = defaultEncoding;
            _m_Size = _Size;
            _m_name = bReader.ReadBytes(_Size);
        }

        private void reencode(string value)
        {
            if (ReplaceEndStringChar)
            {
                int _NeededBytes = DefaultEncoding.GetByteCount(value);
                if (_NeededBytes < _m_Size)
                {
                    AppendEndStringChar = true;
                }
                else
                {
                    value = value.Remove(value.Length - 1);
                    AppendEndStringChar = true;
                }
            }
            if (AppendEndStringChar)
            {
                value = value + (char)0x00;
            }
            _m_name = new byte[_m_Size];
            byte[] data = DefaultEncoding.GetBytes(value);
            if (data.Length > _m_Size)
            {
                Buffer.BlockCopy(data, 0, _m_name, 0, _m_Size);
                return;
            }
            Buffer.BlockCopy(data, 0, _m_name, 0, data.Length);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
