
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class Kill_Player_Requirements
	{
		public int m_ulOccupations;
		public int m_iMinLevel;
		public int m_iMaxLevel;
		public int m_iGender;
        public int m_iForce;
        public bool ModelCheck;
        public byte[] ModelType;

        internal static Kill_Player_Requirements Read(int version, BinaryReader br)
        {
            Kill_Player_Requirements Kill_Player_Requirements = new Kill_Player_Requirements();
            Kill_Player_Requirements.m_ulOccupations = br.ReadInt32();
            Kill_Player_Requirements.m_iMinLevel = br.ReadInt32();
            Kill_Player_Requirements.m_iMaxLevel = br.ReadInt32();
            Kill_Player_Requirements.m_iGender = br.ReadInt32();
            Kill_Player_Requirements.m_iForce = br.ReadInt32();
            if (version >= 130)
            {
                Kill_Player_Requirements.ModelCheck = br.ReadBoolean();
                Kill_Player_Requirements.ModelType = new byte[3];
                for (int i = 0; i < 3; i++)
                {
                    Kill_Player_Requirements.ModelType[i] = br.ReadByte();
                }
            }
            else
            {
                Kill_Player_Requirements.ModelCheck = false;
                Kill_Player_Requirements.ModelType = new byte[3];
            }
            return Kill_Player_Requirements;
        }

        internal static void Write(int version, BinaryWriter bw, Kill_Player_Requirements m_Requirements)
        {
            bw.Write(m_Requirements.m_ulOccupations);
            bw.Write(m_Requirements.m_iMinLevel);
            bw.Write(m_Requirements.m_iMaxLevel);
            bw.Write(m_Requirements.m_iGender);
            bw.Write(m_Requirements.m_iForce);
            if (version >= 130)
            {
                bw.Write(m_Requirements.ModelCheck);
                for (byte i = 0; i < 3; i++)
                {
                    bw.Write(m_Requirements.ModelType[i]);
                }
            }
        }
	}
}

