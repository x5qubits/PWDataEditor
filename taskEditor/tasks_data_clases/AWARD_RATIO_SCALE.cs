
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class AWARD_RATIO_SCALE
	{
        public int m_ulScales;
        public float[] m_Ratios;
        public AWARD_DATA[] m_Awards;

        internal static AWARD_RATIO_SCALE Read(int version, BinaryReader br)
        {
            AWARD_RATIO_SCALE m_AwByRatio = new AWARD_RATIO_SCALE();
            m_AwByRatio.m_ulScales = br.ReadInt32();
            m_AwByRatio.m_Ratios = new float[5];
            for (int num44 = 0; num44 < m_AwByRatio.m_Ratios.Length; num44++)
            {
                m_AwByRatio.m_Ratios[num44] = br.ReadSingle();
            }
            m_AwByRatio.m_Awards = new AWARD_DATA[m_AwByRatio.m_ulScales];
            for (int num45 = 0; num45 < m_AwByRatio.m_Awards.Length; num45++)
            {
                m_AwByRatio.m_Awards[num45] = AWARD_DATA.Read(version, br);
            }
            return m_AwByRatio;
        }

        internal static void Write(int version, BinaryWriter bw, AWARD_RATIO_SCALE m_AwByRatio)
        {
            bw.Write(m_AwByRatio.m_ulScales);
            for (int index2 = 0; index2 < m_AwByRatio.m_Ratios.Length; index2++)
            {
                bw.Write(m_AwByRatio.m_Ratios[index2]);
            }
            for (int index2 = 0; index2 < m_AwByRatio.m_Awards.Length; index2++)
            {
                AWARD_DATA.Write(version, bw, m_AwByRatio.m_Awards[index2]);
            }
        }
	}
}

