
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class MONSTER_WANTED
	{
		public int m_ulMonsterTemplId;
		public int m_ulMonsterNum;
		public int m_ulDropItemId;
		public int m_ulDropItemCount;
		public bool m_bDropCmnItem;
		public float m_fDropProb;
		public bool m_bKillerLev;
		public int m_iDPH;
        public int m_iDPS;

        internal static MONSTER_WANTED Read(int version, BinaryReader br)
        {
            return new MONSTER_WANTED
            {
                m_ulMonsterTemplId = br.ReadInt32(),
                m_ulMonsterNum = br.ReadInt32(),
                m_ulDropItemId = br.ReadInt32(),
                m_ulDropItemCount = br.ReadInt32(),
                m_bDropCmnItem = br.ReadBoolean(),
                m_fDropProb = br.ReadSingle(),
                m_bKillerLev = br.ReadBoolean(),
                m_iDPH = (version < 92) ? 0 : br.ReadInt32(),
                m_iDPS = (version < 92) ? 0 : br.ReadInt32(),
            };
        }

        internal static void Write(int version, BinaryWriter bw, MONSTER_WANTED m_MonsterWanted)
        {
            bw.Write(m_MonsterWanted.m_ulMonsterTemplId);
            bw.Write(m_MonsterWanted.m_ulMonsterNum);
            bw.Write(m_MonsterWanted.m_ulDropItemId);
            bw.Write(m_MonsterWanted.m_ulDropItemCount);
            bw.Write(m_MonsterWanted.m_bDropCmnItem);
            bw.Write(m_MonsterWanted.m_fDropProb);
            bw.Write(m_MonsterWanted.m_bKillerLev);
            if (version < 92)
            {
                return;
            }
            bw.Write(m_MonsterWanted.m_iDPH);
            bw.Write(m_MonsterWanted.m_iDPS);
        }
	}
}

