
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class AWARD_MONSTERS_SUMMONED
	{
        public bool m_bRandChoose;
        public int m_ulSummonRadius;
        public bool m_bDeathDisappear;
        public MONSTERS_SUMMONED[] m_Monsters;

        internal static AWARD_MONSTERS_SUMMONED Read(int version, BinaryReader br, int value)
        {
            AWARD_MONSTERS_SUMMONED m_SummonedMonsters = new AWARD_MONSTERS_SUMMONED();
            m_SummonedMonsters.m_bRandChoose = br.ReadBoolean();
            m_SummonedMonsters.m_ulSummonRadius = br.ReadInt32();
            m_SummonedMonsters.m_bDeathDisappear = br.ReadBoolean();
            m_SummonedMonsters.m_Monsters = new MONSTERS_SUMMONED[value];
            for (int index2 = 0; index2 < m_SummonedMonsters.m_Monsters.Length; index2++)
            {
                m_SummonedMonsters.m_Monsters[index2] = MONSTERS_SUMMONED.Read(version, br);
            }
            return m_SummonedMonsters;
        }

        internal static void Write(int version, BinaryWriter bw, AWARD_MONSTERS_SUMMONED m_SummonedMonsters)
        {
            bw.Write(m_SummonedMonsters.m_bRandChoose);
            bw.Write(m_SummonedMonsters.m_ulSummonRadius);
            bw.Write(m_SummonedMonsters.m_bDeathDisappear);
            for (int index2 = 0; index2 < m_SummonedMonsters.m_Monsters.Length; index2++)
            {
                MONSTERS_SUMMONED.Write(version, bw, m_SummonedMonsters.m_Monsters[index2]);
            }
        }
	}
}

