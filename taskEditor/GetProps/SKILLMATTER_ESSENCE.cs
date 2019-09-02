
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using System.Text;

namespace sTASKedit
{
    class SKILLMATTER_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[106].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[106].elementFields[k] == "level_required")
                    {
                        string level_required = TaskEditor.eLC.GetValue(106, pos_item, k);
                        if (level_required != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), level_required);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[106].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[106].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(106, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
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

