
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class AWARD_ITEMS_CAND
    {
        public int m_ulAwardItems;
		public ITEM_WANTED[] m_AwardItems;
        public bool m_bRandChoose;

        internal static AWARD_ITEMS_CAND Read(int version, BinaryReader br)
        {
            AWARD_ITEMS_CAND itemGroup = new AWARD_ITEMS_CAND();
            itemGroup.m_bRandChoose = br.ReadBoolean();
            itemGroup.m_ulAwardItems = br.ReadInt32();
            itemGroup.m_AwardItems = new ITEM_WANTED[itemGroup.m_ulAwardItems];
            for (int index = 0; index < itemGroup.m_AwardItems.Length; index++)
            {
                itemGroup.m_AwardItems[index] = ITEM_WANTED.Read(version, br);
            }
            return itemGroup;
        }

        internal static void Write(int version, BinaryWriter bw, AWARD_ITEMS_CAND canditems)
        {
            bw.Write(canditems.m_bRandChoose);
            bw.Write(canditems.m_ulAwardItems);
            for (int index = 0; index < canditems.m_AwardItems.Length; index++)
            {
                ITEM_WANTED.Write(version, bw, canditems.m_AwardItems[index]);
            }
        }
	}
}

