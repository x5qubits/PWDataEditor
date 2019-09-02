
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class PET_FOOD_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[96].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[96].elementFields[k] == "food_type")
                    {
                        line += Extensions.DecodingFoodMask(TaskEditor.eLC.GetValue(96, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[96].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[96].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(96, pos_item, k);
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

