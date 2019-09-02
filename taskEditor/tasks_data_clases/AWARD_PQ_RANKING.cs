
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class AWARD_PQ_RANKING
    {
        public bool m_bAwardByProf;
        public RANKING_AWARD[] m_RankingAward;

        internal static AWARD_PQ_RANKING Read(int version, BinaryReader br, int value)
        {
            AWARD_PQ_RANKING m_PQRankingAward = new AWARD_PQ_RANKING();
            m_PQRankingAward.m_bAwardByProf = br.ReadBoolean();
            m_PQRankingAward.m_RankingAward = new RANKING_AWARD[value];
            for (int index2 = 0; index2 < m_PQRankingAward.m_RankingAward.Length; index2++)
            {
                m_PQRankingAward.m_RankingAward[index2] = RANKING_AWARD.Read(version, br);
            }
            return m_PQRankingAward;
        }

        internal static void Write(int version, BinaryWriter bw, AWARD_PQ_RANKING m_PQRankingAward)
        {
            bw.Write(m_PQRankingAward.m_bAwardByProf);
            for (int index2 = 0; index2 < m_PQRankingAward.m_RankingAward.Length; index2++)
            {
                RANKING_AWARD.Write(version, bw, m_PQRankingAward.m_RankingAward[index2]);
            }
        }
	}
}

