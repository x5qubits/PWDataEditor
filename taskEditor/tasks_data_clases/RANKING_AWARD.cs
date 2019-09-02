
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class RANKING_AWARD
	{
		public int m_iRankingStart;
		public int m_iRankingEnd;
		public bool m_bCommonItem;
		public int m_ulAwardItemId;
		public int m_ulAwardItemNum;
        public uint m_lPeriod;

        internal static RANKING_AWARD Read(int version, BinaryReader br)
        {
            return new RANKING_AWARD
            {
                    m_iRankingStart = br.ReadInt32(),
                    m_iRankingEnd = br.ReadInt32(),
                    m_bCommonItem = br.ReadBoolean(),
                    m_ulAwardItemId = br.ReadInt32(),
                    m_ulAwardItemNum = br.ReadInt32(),
                    m_lPeriod = br.ReadUInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, RANKING_AWARD m_RankingAward)
        {
            bw.Write(m_RankingAward.m_iRankingStart);
            bw.Write(m_RankingAward.m_iRankingEnd);
            bw.Write(m_RankingAward.m_bCommonItem);
            bw.Write(m_RankingAward.m_ulAwardItemId);
            bw.Write(m_RankingAward.m_ulAwardItemNum);
            bw.Write(m_RankingAward.m_lPeriod);
        }
	}
}

