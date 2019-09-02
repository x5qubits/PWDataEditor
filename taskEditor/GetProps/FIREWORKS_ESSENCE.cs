
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class FIREWORKS_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[98].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[98].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(98, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[98].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[98].elementFields[k] == "level")
                    {
                        string level = TaskEditor.eLC.GetValue(98, pos_item, k);
                        line += "\n";
                        for (int a = 0; a < Convert.ToInt32(level); a++)
                        {
                            line += Extensions.GetLocalization(7046);
                        }
                        break;
                    }
                }
            }
            catch
            {
                line = "";
            }
            return line;
        }
	}
}

