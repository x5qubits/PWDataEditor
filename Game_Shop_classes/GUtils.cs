using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Game_Shop_classes
{
    public class GUtils
    {
        public static string seconds_to_string(uint time)
        {
            try
            {
                uint days = time / 86400;
                time = time - (days * 86400);
                uint hours = time / 3600;
                time = time - (hours * 3600);
                uint minutes = time / 60;
                uint seconds = time - (minutes * 60);

                return (days.ToString("D2") + "-" + hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"));
            }
            catch
            {
                return "0";
            }
        }
        public static uint string_to_seconds(string time)
        {
            try
            {
                string[] times = time.Split(new char[] { '-', ':' });
                return ((86400 * Convert.ToUInt32(times[0])) + (3600 * Convert.ToUInt32(times[1])) + (60 * Convert.ToUInt32(times[2])) + Convert.ToUInt32(times[3]));
            }
            catch
            {
                return 0;
            }
        }
        public static uint string_to_timestamp(string date)
        {
            DateTime target = DateTime.Parse(date); // parsing depends on culture, application was set to invariant culture
            return Convert.ToUInt32(target.Subtract(new DateTime(1970, 01, 01)).TotalSeconds);

        }

        public static string timestamp_to_string(uint timestamp)
        {
            DateTime origin = new DateTime(1970, 01, 01);
            origin = origin.AddSeconds(timestamp);
            return origin.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
