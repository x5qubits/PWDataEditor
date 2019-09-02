
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class task_tm
	{
		public int day;
		public int hour;
		public int min;
		public int month;
		public int wday;
		public int year;

        internal static task_tm Read(int version, BinaryReader br)
        {
            return new task_tm
            {
                year = br.ReadInt32(),
                month = br.ReadInt32(),
                day = br.ReadInt32(),
                hour = br.ReadInt32(),
                min = br.ReadInt32(),
                wday = br.ReadInt32()
            };
        }

        internal static void Write(int version, BinaryWriter bw, task_tm task_tm)
        {
            bw.Write(task_tm.year);
            bw.Write(task_tm.month);
            bw.Write(task_tm.day);
            bw.Write(task_tm.hour);
            bw.Write(task_tm.min);
            bw.Write(task_tm.wday);
        }
	}
}

