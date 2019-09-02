
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class HomeItemData
	{
		public int m_ulItemTemplId;
		public int m_ulItemNum;

        internal static HomeItemData Read(int version, BinaryReader br)
        {
            return new HomeItemData
            {
                m_ulItemTemplId = br.ReadInt32(),
                m_ulItemNum = br.ReadInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, HomeItemData item)
        {
            bw.Write(item.m_ulItemTemplId);
            bw.Write(item.m_ulItemNum);
        }
	}
}

