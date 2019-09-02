
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class option
    {
        public int crypt_key;
        public int param;
        public byte[] text;
        public int id;
        public string optiontext
		{
			get
			{
                return Extensions.decrypt(this.crypt_key, this.text);
			}
			set
			{
                this.text = Extensions.encrypt(this.crypt_key, value, 128, false);
			}
		}

        internal static option Read(int version, BinaryReader br, int m_ID)
        {
            return new option
            {
                crypt_key = m_ID,
                param = br.ReadInt32(),
                text = br.ReadBytes(128),
                id = br.ReadInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, option option)
        {
            bw.Write(option.param);
            bw.Write(option.text);
            bw.Write(option.id);
        }
	}
}

