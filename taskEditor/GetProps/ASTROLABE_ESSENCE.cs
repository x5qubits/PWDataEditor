
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class ASTROLABE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                line += "\n" + String.Format(Extensions.GetLocalization(7000), 1);
                for (int k = 0; k < TaskEditor.eLC.Lists[202].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[202].elementFields[k] == "exp_1")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7099), 0, TaskEditor.eLC.GetValue(202, 0, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[197].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[197].elementFields[k] == "total_point_value_min")
                    {
                        line += "\n" + Extensions.GetLocalization(7105) + " " + (Convert.ToSingle(TaskEditor.eLC.GetValue(197, pos_item, k)) / 100).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[197].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[197].elementFields[k] == "swallow_exp")
                    {
                        string swallow_exp = TaskEditor.eLC.GetValue(197, pos_item, k);
                        if (swallow_exp != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7103) + " " + swallow_exp;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[197].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[197].elementFields[k] == "character_combo_id")
                    {
                        line += Extensions.DecodingCharacterComboId(TaskEditor.eLC.GetValue(197, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[197].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[197].elementFields[k] == "require_level")
                    {
                        string require_level = TaskEditor.eLC.GetValue(197, pos_item, k);
                        if (require_level != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), require_level);
                        }
                        break;
                    }
                }
                line += "\n" + Extensions.GetLocalization(7106) + "(" + String.Format(Extensions.GetLocalization(7107), 10) + ")";
                for (int k = 0; k < TaskEditor.eLC.Lists[197].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[197].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(197, pos_item, k);
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

