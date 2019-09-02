
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using System.Text;

namespace sTASKedit
{
    class TARGET_ITEM_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "require_level")
                    {
                        string require_level = TaskEditor.eLC.GetValue(124, pos_item, k);
                        if (require_level != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), require_level);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(124, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "num_area")
                    {
                        string num_area = TaskEditor.eLC.GetValue(124, pos_item, k);
                        if (Convert.ToInt32(num_area) > 0)
                        {
                            for (int t = 0; t < TaskEditor.eLC.Lists[124].elementFields.Length; t++)
                            {
                                if (TaskEditor.eLC.Lists[124].elementFields[t] == "area_id_1")
                                {
                                    line += "\n" + Extensions.GetLocalization(7083);
                                    for (int a = 0; a < Convert.ToInt32(num_area) && a < 10; a++)
                                    {
                                        line += " " + Extensions.InstanceName(Convert.ToInt32(TaskEditor.eLC.GetValue(124, pos_item, t + a))).name.Replace("\r\n", " ");
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "num_use_pertime")
                    {
                        string num_use_pertime = TaskEditor.eLC.GetValue(124, pos_item, k);
                        if (num_use_pertime != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7084), num_use_pertime);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "id_skill")
                    {
                        line += "\n" + Extensions.SkillDesc(Convert.ToInt32(TaskEditor.eLC.GetValue(124, pos_item, k)));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "use_in_combat")
                    {
                        string use_in_combat = TaskEditor.eLC.GetValue(124, pos_item, k);
                        if (use_in_combat == "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7085);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[124].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[124].elementFields[k] == "use_in_sanctuary_only")
                    {
                        string use_in_sanctuary_only = TaskEditor.eLC.GetValue(124, pos_item, k);
                        if (use_in_sanctuary_only != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7086);
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

