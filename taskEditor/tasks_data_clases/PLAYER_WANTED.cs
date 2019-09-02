
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class PLAYER_WANTED
	{
		public int m_ulPlayerNum;
		public int m_ulDropItemId;
		public int m_ulDropItemCount;
		public bool m_bDropCmnItem;
        public float m_fDropProb;
        public Kill_Player_Requirements m_Requirements;

        internal static PLAYER_WANTED Read(int version, BinaryReader br)
        {
            return new PLAYER_WANTED
            {
                m_ulPlayerNum = br.ReadInt32(),
                m_ulDropItemId = br.ReadInt32(),
                m_ulDropItemCount = br.ReadInt32(),
                m_bDropCmnItem = br.ReadBoolean(),
                m_fDropProb = br.ReadSingle(),
                m_Requirements = Kill_Player_Requirements.Read(version, br)
            };
        }

        internal static void Write(int version, BinaryWriter bw, PLAYER_WANTED m_PlayerWanted)
        {
            bw.Write(m_PlayerWanted.m_ulPlayerNum);
            bw.Write(m_PlayerWanted.m_ulDropItemId);
            bw.Write(m_PlayerWanted.m_ulDropItemCount);
            bw.Write(m_PlayerWanted.m_bDropCmnItem);
            bw.Write(m_PlayerWanted.m_fDropProb);
            Kill_Player_Requirements.Write(version, bw, m_PlayerWanted.m_Requirements);
        }
	}
}

