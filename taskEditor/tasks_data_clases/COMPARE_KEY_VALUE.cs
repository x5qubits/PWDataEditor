
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class COMPARE_KEY_VALUE
	{
		public int nLeftType;
		public int lLeftNum;
		public int nCompOper;
		public int nRightType;
        public int lRightNum;

        internal static COMPARE_KEY_VALUE Read(int version, BinaryReader br)
        {
            return new COMPARE_KEY_VALUE
            {
                nLeftType = br.ReadInt32(),
                lLeftNum = br.ReadInt32(),
                nCompOper = br.ReadInt32(),
                nRightType = br.ReadInt32(),
                lRightNum = br.ReadInt32(),
            };
        }

        internal static void Write(int version, BinaryWriter bw, COMPARE_KEY_VALUE COMPARE_KEY_VALUE)
        {
            bw.Write(COMPARE_KEY_VALUE.nLeftType);
            bw.Write(COMPARE_KEY_VALUE.lLeftNum);
            bw.Write(COMPARE_KEY_VALUE.nCompOper);
            bw.Write(COMPARE_KEY_VALUE.nRightType);
            bw.Write(COMPARE_KEY_VALUE.lRightNum);
        }
	}
}

