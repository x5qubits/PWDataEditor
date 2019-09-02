using System;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    [Serializable]
    public class Trigger
    {
        public int triger_id = 0;
        public int gm_activateId = 0;
        public Byte[] name = new byte[128];
        public bool on_load = false;
        public int unknown_4 = 0;
        public int unknown_5 = 0;
        public bool auto_start = false;
        public bool auto_stop = false;
        public int year_1 = 0;
        public int month_1 = 0;
        public int week_day_1 = 0;
        public int day_1 = 0;
        public int hour_1 = 0;
        public int minute_1 = 0;
        public int year_2 = 0;
        public int month_2 = 0;
        public int week_day_2 = 0;
        public int day_2 = 0;
        public int hour_2 = 0;
        public int minute_2 = 0;
        public int duration = 0;
    }
}
