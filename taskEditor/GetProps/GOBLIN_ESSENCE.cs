
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class GOBLIN_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                line += "\n" + String.Format(Extensions.GetLocalization(7120), 1);
                string init_strength = "0";
                string init_agility = "0";
                string init_tili = "0";
                string init_energy = "0";
                for (int k = 0; k < TaskEditor.eLC.Lists[119].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[119].elementFields[k] == "init_strength")
                    {
                        init_strength = TaskEditor.eLC.GetValue(119, pos_item, k);
                        if (init_strength != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7058), "+" + init_strength);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[119].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[119].elementFields[k] == "init_agility")
                    {
                        init_agility = TaskEditor.eLC.GetValue(119, pos_item, k);
                        if (init_agility != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7059), "+" + init_agility);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[119].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[119].elementFields[k] == "init_tili")
                    {
                        init_tili = TaskEditor.eLC.GetValue(119, pos_item, k);
                        if (init_tili != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7060), "+" + init_tili);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[119].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[119].elementFields[k] == "init_energy")
                    {
                        init_energy = TaskEditor.eLC.GetValue(119, pos_item, k);
                        if (init_energy != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7061), "+" + init_energy);
                        }
                        break;
                    }
                }
                line += "\n" + String.Format(Extensions.GetLocalization(7062), 50);
                line += "\n" + String.Format(Extensions.GetLocalization(7063), (100 + Convert.ToInt32(init_tili)));
                line += "\n" + String.Format(Extensions.GetLocalization(7064), Convert.ToSingle(1 + 0.02 * Convert.ToInt32(init_energy)).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                line += "\n" + String.Format(Extensions.GetLocalization(7065), 20000);
                line += "\n" + Extensions.GetLocalization(7066);
                for (int k = 0; k < TaskEditor.eLC.Lists[119].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[119].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(119, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[119].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[119].elementFields[k] == "default_skill1")
                    {
                        string default_skill1 = TaskEditor.eLC.GetValue(119, pos_item, k);
                        if (default_skill1 != "0")
                        {
                            line += "\n" + Extensions.SkillName(Convert.ToInt32(default_skill1)) + String.Format(Extensions.GetLocalization(7067), 1);
                        }
                        string default_skill2 = TaskEditor.eLC.GetValue(119, pos_item, k + 1);
                        if (default_skill2 != "0")
                        {
                            line += "\n" + Extensions.SkillName(Convert.ToInt32(default_skill2)) + String.Format(Extensions.GetLocalization(7067), 1);
                        }
                        string default_skill3 = TaskEditor.eLC.GetValue(119, pos_item, k + 2);
                        if (default_skill3 != "0")
                        {
                            line += "\n" + Extensions.SkillName(Convert.ToInt32(default_skill3)) + String.Format(Extensions.GetLocalization(7067), 1);
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

