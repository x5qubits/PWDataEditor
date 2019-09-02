
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class ITEM_WANTED
	{
		public int m_ulItemTemplId;
		public bool m_bCommonItem;
		public int m_ulItemNum;
		public float m_fProb;
        public uint m_lPeriod;

        internal static ITEM_WANTED Read(int version, BinaryReader br)
        {
            return new ITEM_WANTED
            {
                m_ulItemTemplId = br.ReadInt32(),
                m_bCommonItem = br.ReadBoolean(),
                m_ulItemNum = br.ReadInt32(),
                m_fProb = br.ReadSingle(),
                m_lPeriod = (version < 60) ? 0 : br.ReadUInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, ITEM_WANTED item)
        {
            bw.Write(item.m_ulItemTemplId);
            bw.Write(item.m_bCommonItem);
            bw.Write(item.m_ulItemNum);
            bw.Write(item.m_fProb);
            if (version < 60)
            {
                return;
            }
            bw.Write(item.m_lPeriod);
        }
	}
}

