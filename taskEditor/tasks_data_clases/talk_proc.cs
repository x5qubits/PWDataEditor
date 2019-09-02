
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class talk_proc
	{
        public int crypt_key;
        public int id_talk;
        public byte[] text;
        public int num_window;
        public window[] windows;
		public string DialogText
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

        internal static talk_proc Read(int version, BinaryReader br, int m_ID)
        {
            talk_proc talk_proc = new talk_proc();
            talk_proc.crypt_key = m_ID;
            talk_proc.id_talk = br.ReadInt32();
            talk_proc.text = br.ReadBytes(128);
            talk_proc.num_window = br.ReadInt32();
            talk_proc.windows = new window[talk_proc.num_window];
            for (int i = 0; i < talk_proc.windows.Length; i++)
            {
                talk_proc.windows[i] = window.Read(version, br, m_ID);
            }
            return talk_proc;
        }

        internal static void Write(int version, BinaryWriter bw, talk_proc talk_proc)
        {
            bw.Write(talk_proc.id_talk);
            bw.Write(talk_proc.text);
            bw.Write(talk_proc.num_window);
            for (int i = 0; i < talk_proc.windows.Length; i++)
            {
                window.Write(version, bw, talk_proc.windows[i]);
            }
        }
	}
}

