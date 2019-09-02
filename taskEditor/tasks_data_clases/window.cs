
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class window
    {
        public int crypt_key;
        public int id;
        public int id_parent;
        public int talk_text_len;
        public byte[] talk_text;
        public int num_option;
        public option[] options;
        public string talktext
		{
			get
			{
                return Extensions.decrypt(this.crypt_key, this.talk_text);
			}
			set
			{
				char[] array = new char[1];
				char[] trimChars = array;
				value = value.TrimEnd(trimChars);
                this.talk_text = Extensions.encrypt(this.crypt_key, value, value.Length * 2 + 2, true);
                this.talk_text_len = this.talk_text.Length / 2;
			}
		}

        internal static window Read(int version, BinaryReader br, int m_ID)
        {
            window window = new window();
            window.crypt_key = m_ID;
            window.id = br.ReadInt32();
            window.id_parent = br.ReadInt32();
            window.talk_text_len = br.ReadInt32();
            window.talk_text = br.ReadBytes(window.talk_text_len * 2);
            window.num_option = br.ReadInt32();
            window.options = new option[window.num_option];
            for (int i = 0; i < window.num_option; i++)
            {
                window.options[i] = option.Read(version, br, m_ID);
            }
            return window;
        }

        internal static void Write(int version, BinaryWriter bw, window window)
        {
            bw.Write(window.id);
            bw.Write(window.id_parent);
            bw.Write(window.talk_text_len);
            bw.Write(window.talk_text);
            bw.Write(window.num_option);
            for (int i = 0; i < window.num_option; i++)
            {
                option.Write(version, bw, window.options[i]);
            }
        }
	}
}

