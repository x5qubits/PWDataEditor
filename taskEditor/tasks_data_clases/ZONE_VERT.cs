
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
	public class ZONE_VERT
	{
		public float x;
		public float y;
		public float z;

        internal static ZONE_VERT Read(int version, BinaryReader br)
        {
            return new ZONE_VERT
            {
                x = br.ReadSingle(),
                y = br.ReadSingle(),
                z = br.ReadSingle()
            };
        }

        internal static void Write(int version, BinaryWriter bw, ZONE_VERT ZONE_VERT)
        {
            bw.Write(ZONE_VERT.x);
            bw.Write(ZONE_VERT.y);
            bw.Write(ZONE_VERT.z);
        }
	}
}

