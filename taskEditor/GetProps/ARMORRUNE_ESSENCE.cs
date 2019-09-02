
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class ARMORRUNE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                string damage_type = "-1";
                string require_player_level_max = "0";
                string damage_reduce_percent = "0";
                for (int k = 0; k < TaskEditor.eLC.Lists[19].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[19].elementFields[k] == "damage_type")
                    {
                        damage_type = TaskEditor.eLC.GetValue(19, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[19].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[19].elementFields[k] == "require_player_level_max")
                    {
                        require_player_level_max = TaskEditor.eLC.GetValue(19, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[19].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[19].elementFields[k] == "damage_reduce_percent")
                    {
                        damage_reduce_percent = TaskEditor.eLC.GetValue(19, pos_item, k);
                        break;
                    }
                }
                if (require_player_level_max != "0")
                {
                    line += "\n" + Extensions.GetLocalization(7031) + String.Format(Extensions.GetLocalization(7033), require_player_level_max);
                }
                if (damage_reduce_percent != "0" && damage_type == "0")
                {
                    line += "\n" + Extensions.GetLocalization(7025) + String.Format(Extensions.GetLocalization(7034), "+" + Convert.ToSingle(damage_reduce_percent).ToString("P0"));
                }
                if (damage_reduce_percent != "0" && damage_type == "1")
                {
                    line += "\n" + Extensions.GetLocalization(7025) + String.Format(Extensions.GetLocalization(7035), "+" + Convert.ToSingle(damage_reduce_percent).ToString("P0"));
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[19].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[19].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(19, pos_item, k);
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

