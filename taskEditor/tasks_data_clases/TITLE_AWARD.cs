
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class TITLE_AWARD
	{
		public int m_ulTitleID;
		public uint m_lPeriod;

        internal static TITLE_AWARD Read(int version, BinaryReader br)
        {
            return new TITLE_AWARD
            {
                m_ulTitleID = br.ReadInt32(),
                m_lPeriod = br.ReadUInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, TITLE_AWARD m_pTitleAward)
        {
            bw.Write(m_pTitleAward.m_ulTitleID);
            bw.Write(m_pTitleAward.m_lPeriod);
        }
	}
}

