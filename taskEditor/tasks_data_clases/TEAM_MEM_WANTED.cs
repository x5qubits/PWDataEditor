
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class TEAM_MEM_WANTED
	{
		public int m_ulLevelMin;
		public int m_ulLevelMax;
		public int m_ulRace;
		public int m_ulOccupation;
		public int m_ulGender;
		public int m_ulMinCount;
		public int m_ulMaxCount;
		public int m_ulTask;
        public int m_iForce;

        internal static TEAM_MEM_WANTED Read(int version, BinaryReader br)
        {
            return new TEAM_MEM_WANTED
            {
                m_ulLevelMin = br.ReadInt32(),
                m_ulLevelMax = br.ReadInt32(),
                m_ulRace = br.ReadInt32(),
                m_ulOccupation = br.ReadInt32(),
                m_ulGender = br.ReadInt32(),
                m_ulMinCount = br.ReadInt32(),
                m_ulMaxCount = br.ReadInt32(),
                m_ulTask = br.ReadInt32(),
                m_iForce = (version < 99) ? 0 : br.ReadInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, TEAM_MEM_WANTED m_TeamMemsWanted)
        {
            bw.Write(m_TeamMemsWanted.m_ulLevelMin);
            bw.Write(m_TeamMemsWanted.m_ulLevelMax);
            bw.Write(m_TeamMemsWanted.m_ulRace);
            bw.Write(m_TeamMemsWanted.m_ulOccupation);
            bw.Write(m_TeamMemsWanted.m_ulGender);
            bw.Write(m_TeamMemsWanted.m_ulMinCount);
            bw.Write(m_TeamMemsWanted.m_ulMaxCount);
            bw.Write(m_TeamMemsWanted.m_ulTask);
            if (version < 99)
            {
                return;
            }
            bw.Write(m_TeamMemsWanted.m_iForce);
        }
	}
}

