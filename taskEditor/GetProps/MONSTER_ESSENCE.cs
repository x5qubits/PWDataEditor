
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class MONSTER_ESSENCE
    {
        public static string GetProps(int pos)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "level")
                    {
                        line += "\n" + Extensions.GetLocalization(7300) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "life")
                    {
                        line += "\n" + Extensions.GetLocalization(7301) + " " + Convert.ToInt32(TaskEditor.eLC.GetValue(38, pos, k)).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "hp_regenerate")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7318), TaskEditor.eLC.GetValue(38, pos, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "short_range_mode")
                    {
                        string short_range_mode = TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7337);
                        if (short_range_mode == "") line += " " + Extensions.GetLocalization(3130);
                        if (short_range_mode == "1") line += " " + Extensions.GetLocalization(3131);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "damage_min")
                    {
                        line += "\n" + Extensions.GetLocalization(7314) + " " + TaskEditor.eLC.GetValue(38, pos, k) + "-" + TaskEditor.eLC.GetValue(38, pos, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "magic_damage_min")
                    {
                        line += "\n" + Extensions.GetLocalization(7317) + " " + TaskEditor.eLC.GetValue(38, pos, k) + "-" + TaskEditor.eLC.GetValue(38, pos, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "attack_range")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7315), TaskEditor.eLC.GetValue(38, pos, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "attack_speed")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7316), TaskEditor.eLC.GetValue(38, pos, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "defence")
                    {
                        line += "\n" + Extensions.GetLocalization(7302) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "magic_defences_1")
                    {
                        line += "\n" + Extensions.GetLocalization(7303) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7304) + " " + TaskEditor.eLC.GetValue(38, pos, k + 1);
                        line += "\n" + Extensions.GetLocalization(7305) + " " + TaskEditor.eLC.GetValue(38, pos, k + 2);
                        line += "\n" + Extensions.GetLocalization(7306) + " " + TaskEditor.eLC.GetValue(38, pos, k + 3);
                        line += "\n" + Extensions.GetLocalization(7307) + " " + TaskEditor.eLC.GetValue(38, pos, k + 4);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "immune_type")
                    {
                        string immune_type = TaskEditor.eLC.GetValue(38, pos, k);
                        if (immune_type != "0")
                        {
                            string tmp = "";
                            string tmp1 = "";
                            int tmp2 = 0;
                            int tmp3 = 0;
                            uint immunetype;
                            bool result_immune_type = uint.TryParse(immune_type, out immunetype);
                            List<uint> powers_immune_type = new List<uint>(Extensions.GetPowers(immunetype));
                            for (int p = 0; p < powers_immune_type.Count; p++)
                            {
                                if (powers_immune_type[p] == 0) continue;

                                switch (p)
                                {
                                    case 0:
                                        tmp += "\n" + Extensions.GetLocalization(3081);//immune_type_1
                                        tmp1 += "\n" + Extensions.GetLocalization(3081);//immune_type_1
                                        tmp2 += 1;
                                        break;
                                    case 1:
                                        tmp += "\n" + Extensions.GetLocalization(3082);//immune_type_2
                                        tmp2 += 1;
                                        tmp3 += 1;
                                        break;
                                    case 2:
                                        tmp += "\n" + Extensions.GetLocalization(3083);//immune_type_4
                                        tmp2 += 1;
                                        tmp3 += 1;
                                        break;
                                    case 3:
                                        tmp += "\n" + Extensions.GetLocalization(3084);//immune_type_8
                                        tmp2 += 1;
                                        tmp3 += 1;
                                        break;
                                    case 4:
                                        tmp += "\n" + Extensions.GetLocalization(3085);//immune_type_16
                                        tmp2 += 1;
                                        tmp3 += 1;
                                        break;
                                    case 5:
                                        tmp += "\n" + Extensions.GetLocalization(3086);//immune_type_32
                                        tmp2 += 1;
                                        tmp3 += 1;
                                        break;
                                }
                            }
                            if (tmp2 < 6)
                            {
                                if (tmp3 < 5) line += tmp;
                                else line += tmp1 + "\n" + Extensions.GetLocalization(3086);
                            }
                            else line += "\n" + Extensions.GetLocalization(3080);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "exp")
                    {
                        line += "\n" + Extensions.GetLocalization(7308) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "skillpoint")
                    {
                        line += "\n" + Extensions.GetLocalization(7309) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "money_average")
                    {
                        line += "\n" + Extensions.GetLocalization(7310) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7311) + " " + TaskEditor.eLC.GetValue(38, pos, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "attack")
                    {
                        line += "\n" + Extensions.GetLocalization(7312) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "armor")
                    {
                        line += "\n" + Extensions.GetLocalization(7313) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "aggressive_mode")
                    {
                        string aggressive_mode = TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7319) + " ";
                        if (aggressive_mode == "0") line += Extensions.GetLocalization(2310);
                        else line += Extensions.GetLocalization(2311);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "aggro_range")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7320), TaskEditor.eLC.GetValue(38, pos, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "aggro_time")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7321), Extensions.ItemPropsSecondsToString2(Convert.ToUInt32(TaskEditor.eLC.GetValue(38, pos, k))));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "inhabit_type")
                    {
                        string inhabit_type = TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7322) + " ";
                        if (inhabit_type == "0") line += Extensions.GetLocalization(3100);
                        if (inhabit_type == "1") line += Extensions.GetLocalization(3101);
                        if (inhabit_type == "2") line += Extensions.GetLocalization(3102);
                        if (inhabit_type == "3") line += Extensions.GetLocalization(3103);
                        if (inhabit_type == "4") line += Extensions.GetLocalization(3104);
                        if (inhabit_type == "5") line += Extensions.GetLocalization(3105);
                        if (inhabit_type == "6") line += Extensions.GetLocalization(3106);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "walk_speed")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7323), TaskEditor.eLC.GetValue(38, pos, k));
                        line += "\n" + String.Format(Extensions.GetLocalization(7324), TaskEditor.eLC.GetValue(38, pos, k));
                        line += "\n" + String.Format(Extensions.GetLocalization(7325), TaskEditor.eLC.GetValue(38, pos, k));
                        line += "\n" + String.Format(Extensions.GetLocalization(7326), TaskEditor.eLC.GetValue(38, pos, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "attack_degree")
                    {
                        line += "\n" + Extensions.GetLocalization(7327) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7328) + " " + TaskEditor.eLC.GetValue(38, pos, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "invisible_lvl")
                    {
                        line += "\n" + Extensions.GetLocalization(7333) + " " + TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7334) + " " + TaskEditor.eLC.GetValue(38, pos, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "common_strategy")
                    {
                        string common_strategy = TaskEditor.eLC.GetValue(38, pos, k);
                        if (common_strategy != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7329) + " " + common_strategy;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "hp_adjust_common_value")
                    {
                        string hp_adjust_common_value = TaskEditor.eLC.GetValue(38, pos, k);
                        if (hp_adjust_common_value != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7330) + " " + hp_adjust_common_value;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "defence_adjust_common_value")
                    {
                        string defence_adjust_common_value = TaskEditor.eLC.GetValue(38, pos, k);
                        if (defence_adjust_common_value != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7331) + " " + defence_adjust_common_value;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "attack_adjust_common_value")
                    {
                        string attack_adjust_common_value = TaskEditor.eLC.GetValue(38, pos, k);
                        if (attack_adjust_common_value != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7332) + " " + attack_adjust_common_value;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "probability_drop_num0")
                    {
                        string probability_drop_num0 = TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7335) + " ";
                        if (probability_drop_num0 == "1") line += Extensions.GetLocalization(2310);
                        else line += Extensions.GetLocalization(2311);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[38].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[38].elementFields[k] == "drop_mine_probability")
                    {
                        string probability_drop_num0 = TaskEditor.eLC.GetValue(38, pos, k);
                        line += "\n" + Extensions.GetLocalization(7336) + " ";
                        if (probability_drop_num0 == "0") line += Extensions.GetLocalization(2310);
                        else line += Extensions.GetLocalization(2311);
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

