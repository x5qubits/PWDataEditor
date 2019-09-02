
using System;
namespace sTASKedit
{
    [Serializable]
    public class CONVERSATION
	{
		public int crypt_key;
        public int m_pwstrDescript_len;
        public byte[] m_pwstrDescript;
        public int m_pwstrOkText_len;
        public byte[] m_pwstrOkText;
        public int m_pwstrNoText_len;
        public byte[] m_pwstrNoText;
        public int m_pwstrTribute_len;
        public byte[] m_pwstrTribute;
        public string Descript
        {
            get
            {
                return Extensions.decrypt(this.crypt_key, this.m_pwstrDescript);
            }
            set
            {
                char[] array = new char[1];
                char[] trimChars = array;
                value = value.TrimEnd(trimChars);
                this.m_pwstrDescript = Extensions.encrypt(this.crypt_key, value, value.Length * 2 + 2, true);
                this.m_pwstrDescript_len = this.m_pwstrDescript.Length / 2;
            }
        }
        public string OkText
        {
            get
            {
                return Extensions.decrypt(this.crypt_key, this.m_pwstrOkText);
            }
            set
            {
                char[] array = new char[1];
                char[] trimChars = array;
                value = value.TrimEnd(trimChars);
                this.m_pwstrOkText = Extensions.encrypt(this.crypt_key, value, value.Length * 2 + 2, true);
                this.m_pwstrOkText_len = this.m_pwstrOkText.Length / 2;
            }
        }
        public string NoText
        {
            get
            {
                return Extensions.decrypt(this.crypt_key, this.m_pwstrNoText);
            }
            set
            {
                char[] array = new char[1];
                char[] trimChars = array;
                value = value.TrimEnd(trimChars);
                this.m_pwstrNoText = Extensions.encrypt(this.crypt_key, value, value.Length * 2 + 2, true);
                this.m_pwstrNoText_len = this.m_pwstrNoText.Length / 2;
            }
        }
        public string Tribute
        {
            get
            {
                return Extensions.decrypt(this.crypt_key, this.m_pwstrTribute);
            }
            set
            {
                char[] array = new char[1];
                char[] trimChars = array;
                value = value.TrimEnd(trimChars);
                this.m_pwstrTribute = Extensions.encrypt(this.crypt_key, value, value.Length * 2 + 2, true);
                this.m_pwstrTribute_len = this.m_pwstrTribute.Length / 2;
            }
        }
	}
}

