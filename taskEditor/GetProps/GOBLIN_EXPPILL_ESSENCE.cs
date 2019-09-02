
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class GOBLIN_EXPPILL_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[122].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[122].elementFields[k] == "level")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7000), TaskEditor.eLC.GetValue(122, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[122].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[122].elementFields[k] == "exp")
                    {
                        string exp = TaskEditor.eLC.GetValue(122, pos_item, k);
                        if (exp != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7079), exp);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[122].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[122].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(122, pos_item, k);
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

