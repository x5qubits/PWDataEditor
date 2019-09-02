
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class PROJECTILE_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                string type = "";
                string require_weapon_level_min = "0";
                string require_weapon_level_max = "0";
                string damage_enhance = "0";
                for (int k = 0; k < TaskEditor.eLC.Lists[31].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[31].elementFields[k] == "type")
                    {
                        string value = TaskEditor.eLC.GetValue(31, pos_item, k);
                        if (value != "0")
                        {
                            for (int t = 0; t < TaskEditor.eLC.Lists[30].elementValues.Count; t++)
                            {
                                if (TaskEditor.eLC.GetValue(30, t, 0) == value)
                                {
                                    for (int a = 0; a < TaskEditor.eLC.Lists[30].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[30].elementFields[a] == "Name")
                                        {
                                            type = TaskEditor.eLC.GetValue(30, t, a);
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[31].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[31].elementFields[k] == "require_weapon_level_min")
                    {
                        require_weapon_level_min = TaskEditor.eLC.GetValue(31, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[31].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[31].elementFields[k] == "require_weapon_level_max")
                    {
                        require_weapon_level_max = TaskEditor.eLC.GetValue(31, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[31].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[31].elementFields[k] == "damage_enhance")
                    {
                        damage_enhance = TaskEditor.eLC.GetValue(31, pos_item, k);
                        break;
                    }
                }
                line += "\n" + String.Format(Extensions.GetLocalization(7042), require_weapon_level_min, require_weapon_level_max, type);
                if (damage_enhance != "0")
                {
                    line += "\n" + Extensions.GetLocalization(7004) + " +" + damage_enhance;
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[31].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[31].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(31, pos_item, k);
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

