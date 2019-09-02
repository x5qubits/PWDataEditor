
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class MONSTERS_CONTRIB
	{
		public int m_ulMonsterTemplId;
		public int m_iWholeContrib;
		public int m_iShareContrib;
        public int m_iPersonalWholeContrib;

        internal static MONSTERS_CONTRIB Read(int version, BinaryReader br)
        {
            return new MONSTERS_CONTRIB
            {
                m_ulMonsterTemplId = br.ReadInt32(),
                m_iWholeContrib = br.ReadInt32(),
                m_iShareContrib = br.ReadInt32(),
                m_iPersonalWholeContrib = (version < 82) ? 0 : br.ReadInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, MONSTERS_CONTRIB MONSTERS_CONTRIB)
        {
            bw.Write(MONSTERS_CONTRIB.m_ulMonsterTemplId);
            bw.Write(MONSTERS_CONTRIB.m_iWholeContrib);
            bw.Write(MONSTERS_CONTRIB.m_iShareContrib);
            if (version < 82)
            {
                return;
            }
            bw.Write(MONSTERS_CONTRIB.m_iPersonalWholeContrib);
        }
	}
}

