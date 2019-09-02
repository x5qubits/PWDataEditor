
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
	public class Task_Region
	{
		public float zvMin_x;
		public float zvMin_y;
		public float zvMin_z;
		public float zvMax_x;
		public float zvMax_y;
        public float zvMax_z;

        internal static Task_Region Read(int version, BinaryReader br)
        {
            return new Task_Region
            {
                zvMin_x = br.ReadSingle(),
                zvMin_y = br.ReadSingle(),
                zvMin_z = br.ReadSingle(),
                zvMax_x = br.ReadSingle(),
                zvMax_y = br.ReadSingle(),
                zvMax_z = br.ReadSingle()
            };
        }

        internal static void Write(int version, BinaryWriter bw, Task_Region location_Task_Region)
        {
            bw.Write(location_Task_Region.zvMin_x);
            bw.Write(location_Task_Region.zvMin_y);
            bw.Write(location_Task_Region.zvMin_z);
            bw.Write(location_Task_Region.zvMax_x);
            bw.Write(location_Task_Region.zvMax_y);
            bw.Write(location_Task_Region.zvMax_z);
        }
	}
}

