
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
	public class MONSTERS_SUMMONED
	{
		public int m_ulMonsterTemplId;
		public int m_ulMonsterNum;
		public float m_fSummonProb;
        public uint m_lPeriod;

        internal static MONSTERS_SUMMONED Read(int version, BinaryReader br)
        {
            return new MONSTERS_SUMMONED
            {
                m_ulMonsterTemplId = br.ReadInt32(),
                m_ulMonsterNum = br.ReadInt32(),
                m_fSummonProb = br.ReadSingle(),
                m_lPeriod = br.ReadUInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, MONSTERS_SUMMONED m_Monsters)
        {
            bw.Write(m_Monsters.m_ulMonsterTemplId);
            bw.Write(m_Monsters.m_ulMonsterNum);
            bw.Write(m_Monsters.m_fSummonProb);
            bw.Write(m_Monsters.m_lPeriod);
        }
	}
}

