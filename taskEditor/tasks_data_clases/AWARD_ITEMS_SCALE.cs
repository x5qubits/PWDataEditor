
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class AWARD_ITEMS_SCALE
	{
        public int m_ulScales;
        public int m_ulItemId;
        public int[] m_Counts;
        public AWARD_DATA[] m_Awards;

        internal static AWARD_ITEMS_SCALE Read(int version, BinaryReader br)
        {
            AWARD_ITEMS_SCALE m_AwByItems = new AWARD_ITEMS_SCALE();
            m_AwByItems.m_ulScales = br.ReadInt32();
            m_AwByItems.m_ulItemId = br.ReadInt32();
            m_AwByItems.m_Counts = new int[5];
            for (int num44 = 0; num44 < m_AwByItems.m_Counts.Length; num44++)
            {
                m_AwByItems.m_Counts[num44] = br.ReadInt32();
            }
            m_AwByItems.m_Awards = new AWARD_DATA[m_AwByItems.m_ulScales];
            for (int num45 = 0; num45 < m_AwByItems.m_Awards.Length; num45++)
            {
                m_AwByItems.m_Awards[num45] = AWARD_DATA.Read(version, br);
            }
            return m_AwByItems;
        }

        internal static void Write(int version, BinaryWriter bw, AWARD_ITEMS_SCALE m_AwByItems)
        {
            bw.Write(m_AwByItems.m_ulScales);
            bw.Write(m_AwByItems.m_ulItemId);
            for (int index2 = 0; index2 < m_AwByItems.m_Counts.Length; index2++)
            {
                bw.Write(m_AwByItems.m_Counts[index2]);
            }
            for (int index2 = 0; index2 < m_AwByItems.m_Awards.Length; index2++)
            {
                AWARD_DATA.Write(version, bw, m_AwByItems.m_Awards[index2]);
            }
        }
	}
}

