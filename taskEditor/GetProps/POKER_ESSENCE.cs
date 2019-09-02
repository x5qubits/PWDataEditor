
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class POKER_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                string rank = "0";
                string id_sub_type = "0";
                string poker_adjust_1 = "0";
                string poker_adjust_2 = "0";
                string poker_adjust_3 = "0";
                string poker_adjust_4 = "0";
                string poker_adjust_5 = "0";
                string poker_adjust_6 = "0";
                for (int k = 0; k < TaskEditor.eLC.Lists[71].elementValues.Count; k++)
                {
                    if (Convert.ToInt32(TaskEditor.eLC.GetValue(71, k, 0)) == 2)
                    {
                        for (int t = 0; t < TaskEditor.eLC.Lists[71].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[71].elementFields[t] == "poker_adjust_1")
                            {
                                poker_adjust_1 = TaskEditor.eLC.GetValue(71, k, t);
                                poker_adjust_2 = TaskEditor.eLC.GetValue(71, k, t + 1);
                                poker_adjust_3 = TaskEditor.eLC.GetValue(71, k, t + 2);
                                poker_adjust_4 = TaskEditor.eLC.GetValue(71, k, t + 3);
                                poker_adjust_5 = TaskEditor.eLC.GetValue(71, k, t + 4);
                                poker_adjust_6 = TaskEditor.eLC.GetValue(71, k, t + 5);
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "rank")
                    {
                        rank = TaskEditor.eLC.GetValue(184, pos_item, k);
                        line += "\n" + Extensions.GetLocalization(7098);
                        if (rank == "0") line += " C";
                        if (rank == "1") line += " B";
                        if (rank == "2") line += " A";
                        if (rank == "3") line += " S";
                        if (rank == "4") line += " S+";
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "id_sub_type")
                    {
                        id_sub_type = TaskEditor.eLC.GetValue(184, pos_item, k);
                        line += "\n" + Extensions.GetLocalization(7044);
                        if (id_sub_type == "41061") line += " " + Extensions.GetLocalization(3060);
                        if (id_sub_type == "41062") line += " " + Extensions.GetLocalization(3061);
                        if (id_sub_type == "41063") line += " " + Extensions.GetLocalization(3062);
                        if (id_sub_type == "41064") line += " " + Extensions.GetLocalization(3063);
                        if (id_sub_type == "41065") line += " " + Extensions.GetLocalization(3064);
                        if (id_sub_type == "41066") line += " " + Extensions.GetLocalization(3065);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "max_level")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7119), 1, TaskEditor.eLC.GetValue(184, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[180].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[180].elementFields[k] == "exp_adjust_" + (Convert.ToInt32(rank) + 1))
                    {
                        string exp_adjust = TaskEditor.eLC.GetValue(180, 0, k);
                        for (int t = 0; t < TaskEditor.eLC.Lists[180].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[180].elementFields[t] == "exp_1")
                            {
                                string exp_1 = TaskEditor.eLC.GetValue(180, 0, t);
                                line += "\n" + String.Format(Extensions.GetLocalization(7099), 0, Convert.ToInt32(Convert.ToSingle(exp_1) * Convert.ToSingle(exp_adjust)));
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "hp")
                    {
                        string hp = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (hp != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7006) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(hp) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(hp) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(hp) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(hp) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(hp) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(hp) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "damage")
                    {
                        string damage = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (damage != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7004) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(damage) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(damage) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(damage) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(damage) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(damage) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(damage) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "magic_damage")
                    {
                        string magic_damage = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (magic_damage != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7005) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(magic_damage) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(magic_damage) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(magic_damage) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(magic_damage) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(magic_damage) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(magic_damage) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "defence")
                    {
                        string defence = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (defence != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7009) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(defence) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(defence) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(defence) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(defence) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(defence) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(defence) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "magic_defence_1")
                    {
                        string magic_defence_1 = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (magic_defence_1 != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7010) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(magic_defence_1) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(magic_defence_1) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(magic_defence_1) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(magic_defence_1) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(magic_defence_1) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(magic_defence_1) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "magic_defence_2")
                    {
                        string magic_defence_2 = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (magic_defence_2 != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7011) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(magic_defence_2) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(magic_defence_2) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(magic_defence_2) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(magic_defence_2) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(magic_defence_2) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(magic_defence_2) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "magic_defence_3")
                    {
                        string magic_defence_3 = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (magic_defence_3 != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7012) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(magic_defence_3) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(magic_defence_3) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(magic_defence_3) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(magic_defence_3) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(magic_defence_3) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(magic_defence_3) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "magic_defence_4")
                    {
                        string magic_defence_4 = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (magic_defence_4 != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7013) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(magic_defence_4) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(magic_defence_4) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(magic_defence_4) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(magic_defence_4) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(magic_defence_4) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(magic_defence_4) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "magic_defence_5")
                    {
                        string magic_defence_5 = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (magic_defence_5 != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7014) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(magic_defence_5) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(magic_defence_5) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(magic_defence_5) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(magic_defence_5) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(magic_defence_5) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(magic_defence_5) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "vigour")
                    {
                        string vigour = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (vigour != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7100) + " +";
                            if (id_sub_type == "41061") line += Convert.ToInt32(Convert.ToSingle(vigour) * Convert.ToSingle(poker_adjust_1));
                            if (id_sub_type == "41062") line += Convert.ToInt32(Convert.ToSingle(vigour) * Convert.ToSingle(poker_adjust_2));
                            if (id_sub_type == "41063") line += Convert.ToInt32(Convert.ToSingle(vigour) * Convert.ToSingle(poker_adjust_3));
                            if (id_sub_type == "41064") line += Convert.ToInt32(Convert.ToSingle(vigour) * Convert.ToSingle(poker_adjust_4));
                            if (id_sub_type == "41065") line += Convert.ToInt32(Convert.ToSingle(vigour) * Convert.ToSingle(poker_adjust_5));
                            if (id_sub_type == "41066") line += Convert.ToInt32(Convert.ToSingle(vigour) * Convert.ToSingle(poker_adjust_6));
                        }
                        break;
                    }
                }
                for (int k = 1; k < 5; k++)
                {
                    for (int t = 0; t < TaskEditor.eLC.Lists[184].elementFields.Length; t++)
                    {
                        if (TaskEditor.eLC.Lists[184].elementFields[t] == "addon_" + k)
                        {
                            string addon = TaskEditor.eLC.GetValue(184, pos_item, t);
                            if (addon != "0")
                            {
                                line += "\n" + "^4286f4" + EQUIPMENT_ADDON.GetAddon(addon) + "^FFFFFF";
                            }
                            break;
                        }
                    }
                }
                line += "\n" + Extensions.GetLocalization(7101) + " " + Extensions.GetLocalization(1120);
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "require_level")
                    {
                        string require_level = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (require_level != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), require_level);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "require_control_point_1")
                    {
                        string require_control_point_1 = TaskEditor.eLC.GetValue(184, pos_item, k);
                        line += "\n" + Extensions.GetLocalization(7102) + " " + require_control_point_1 + "~" + TaskEditor.eLC.GetValue(184, pos_item, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "swallow_exp")
                    {
                        string swallow_exp = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (swallow_exp != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7103) + " " + swallow_exp;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[184].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[184].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(184, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                bool Suc = false;
                for (int k = 0; k < TaskEditor.eLC.Lists[181].elementValues.Count; k++)
                {
                    for (int a = 1; a < 7; a++)
                    {
                        for (int t = 0; t < TaskEditor.eLC.Lists[181].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[181].elementFields[t] == "list_" + a)
                            {
                                if (Convert.ToInt32(TaskEditor.eLC.GetValue(181, k, t)) == Convert.ToInt32(TaskEditor.eLC.GetValue(184, pos_item, 0)))
                                {
                                    Suc = true;
                                    string name = "";
                                    int max_equips = 0;
                                    for (int n = 0; n < TaskEditor.eLC.Lists[181].elementFields.Length; n++)
                                    {
                                        if (TaskEditor.eLC.Lists[181].elementFields[n] == "Name")
                                        {
                                            name = TaskEditor.eLC.GetValue(181, k, n);
                                            break;
                                        }
                                    }
                                    for (int f = 1; f < 7; f++)
                                    {
                                        for (int n = 0; n < TaskEditor.eLC.Lists[181].elementFields.Length; n++)
                                        {
                                            if (TaskEditor.eLC.Lists[181].elementFields[n] == "list_" + f)
                                            {
                                                if (TaskEditor.eLC.GetValue(181, k, n) != "0")
                                                {
                                                    max_equips = max_equips + 1;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    line += "\n\n" + name + " (" + max_equips + ")";
                                    break;
                                }
                                break;
                            }
                        }
                    }
                    if (Suc == true) break;
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

