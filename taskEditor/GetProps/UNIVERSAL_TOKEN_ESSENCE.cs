
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using System.Text;

namespace sTASKedit
{
    class UNIVERSAL_TOKEN_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[191].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[191].elementFields[k] == "link_num")
                    {
                        string link_num = TaskEditor.eLC.GetValue(191, pos_item, k);
                        if (link_num != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7104);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[191].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[191].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(191, pos_item, k);
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

