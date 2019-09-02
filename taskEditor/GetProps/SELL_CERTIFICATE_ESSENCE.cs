
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class SELL_CERTIFICATE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[123].elementFields[k] == "num_sell_item")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7080), TaskEditor.eLC.GetValue(123, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[123].elementFields[k] == "num_buy_item")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7081), TaskEditor.eLC.GetValue(123, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[123].elementFields[k] == "max_name_length")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7082), TaskEditor.eLC.GetValue(123, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[123].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[123].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(123, pos_item, k);
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

