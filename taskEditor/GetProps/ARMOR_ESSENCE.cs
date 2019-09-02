
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class ARMOR_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "id_sub_type")
                    {
                        string id_sub_type = TaskEditor.eLC.GetValue(6, pos_item, k);
                        for (int t = 0; t < TaskEditor.eLC.Lists[5].elementValues.Count; t++)
                        {
                            if (TaskEditor.eLC.GetValue(5, t, 0) == id_sub_type)
                            {
                                for (int a = 0; a < TaskEditor.eLC.Lists[5].elementFields.Length; a++)
                                {
                                    if (TaskEditor.eLC.Lists[5].elementFields[a] == "Name")
                                    {
                                        line += "\n" + TaskEditor.eLC.GetValue(5, t, a);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "level")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7000), TaskEditor.eLC.GetValue(6, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                    {
                        if (TaskEditor.eLC.Lists[6].elementFields[k] == "mp_enhance_low")
                        {
                            string hp_enhance_low = TaskEditor.eLC.GetValue(6, pos_item, k + 2);
                            if (hp_enhance_low != "0")
                            {
                                line += "\n" + Extensions.GetLocalization(7006) + " +" + hp_enhance_low;
                            }
                            string mp_enhance_low = TaskEditor.eLC.GetValue(6, pos_item, k);
                            if (mp_enhance_low != "0")
                            {
                                line += "\n" + Extensions.GetLocalization(7007) + " +" + mp_enhance_low;
                            }
                            string armor_enhance_low = TaskEditor.eLC.GetValue(6, pos_item, k + 4);
                            if (armor_enhance_low != "0")
                            {
                                line += "\n" + Extensions.GetLocalization(7008) + " +" + armor_enhance_low;
                            }
                            break;
                        }
                    }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "defence_low")
                    {
                        string defence_low = TaskEditor.eLC.GetValue(6, pos_item, k);
                        if (defence_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7009) + " +" + defence_low;
                        }
                        string magic_defences_1_low = TaskEditor.eLC.GetValue(6, pos_item, k + 2);
                        if (magic_defences_1_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7010) + " +" + magic_defences_1_low;
                        }
                        string magic_defences_2_low = TaskEditor.eLC.GetValue(6, pos_item, k + 4);
                        if (magic_defences_2_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7011) + " +" + magic_defences_2_low;
                        }
                        string magic_defences_3_low = TaskEditor.eLC.GetValue(6, pos_item, k + 6);
                        if (magic_defences_3_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7012) + " +" + magic_defences_3_low;
                        }
                        string magic_defences_4_low = TaskEditor.eLC.GetValue(6, pos_item, k + 8);
                        if (magic_defences_4_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7013) + " +" + magic_defences_4_low;
                        }
                        string magic_defences_5_low = TaskEditor.eLC.GetValue(6, pos_item, k + 10);
                        if (magic_defences_5_low != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7014) + " +" + magic_defences_5_low;
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "durability_min")
                    {
                        line += "\n" + Extensions.GetLocalization(7015) + " " + TaskEditor.eLC.GetValue(6, pos_item, k) + "/" + TaskEditor.eLC.GetValue(6, pos_item, k + 1);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "character_combo_id")
                    {
                        line += Extensions.DecodingCharacterComboId(TaskEditor.eLC.GetValue(6, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "require_level")
                    {
                        string require_level = TaskEditor.eLC.GetValue(6, pos_item, k);
                        if (require_level != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7018), require_level);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "require_strength")
                    {
                        string require_strength = TaskEditor.eLC.GetValue(6, pos_item, k);
                        if (require_strength != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7019), require_strength);
                        }
                        string require_agility = TaskEditor.eLC.GetValue(6, pos_item, k + 1);
                        if (require_agility != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7020), require_agility);
                        }
                        string require_energy = TaskEditor.eLC.GetValue(6, pos_item, k + 2);
                        if (require_energy != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7021), require_energy);
                        }
                        string require_tili = TaskEditor.eLC.GetValue(6, pos_item, k + 3);
                        if (require_tili != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7022), require_tili);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "require_reputation")
                    {
                        string require_reputation = TaskEditor.eLC.GetValue(6, pos_item, k);
                        if (require_reputation != "0")
                        {
                            line += "\n" + String.Format(Extensions.GetLocalization(7023), require_reputation);
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "fixed_props")
                    {
                        if ("0" != TaskEditor.eLC.GetValue(6, pos_item, k))
                        {
                            string probability_addon_num0 = "0";
                            for (int t = 0; t < TaskEditor.eLC.Lists[6].elementFields.Length; t++)
                            {
                                if (TaskEditor.eLC.Lists[6].elementFields[t] == "probability_addon_num0")
                                {
                                    probability_addon_num0 = TaskEditor.eLC.GetValue(6, pos_item, t);
                                    break;
                                }
                            }
                            if (probability_addon_num0 != "1")
                            {
                                for (int t = 1; t < 33; t++)
                                {
                                    for (int a = 0; a < TaskEditor.eLC.Lists[6].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[6].elementFields[a] == "addons_" + t + "_id_addon")
                                        {
                                            string id_addon = TaskEditor.eLC.GetValue(6, pos_item, a);
                                            if (id_addon != "0")
                                            {
                                                line += "\n" + "^4286f4" + EQUIPMENT_ADDON.GetAddon(id_addon) + "^FFFFFF";
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[6].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[6].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(6, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                bool Suc = false;
                for (int k = 0; k < TaskEditor.eLC.Lists[90].elementValues.Count; k++)
                {
                    for (int a = 1; a < 13; a++)
                    {
                        for (int t = 0; t < TaskEditor.eLC.Lists[90].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[90].elementFields[t] == "equipments_" + a + "_id")
                            {
                                if (Convert.ToInt32(TaskEditor.eLC.GetValue(90, k, t)) == Convert.ToInt32(TaskEditor.eLC.GetValue(6, pos_item, 0)))
                                {
                                    Suc = true;
                                    string name = "";
                                    string max_equips = "0";
                                    for (int n = 0; n < TaskEditor.eLC.Lists[90].elementFields.Length; n++)
                                    {
                                        if (TaskEditor.eLC.Lists[90].elementFields[n] == "Name")
                                        {
                                            name = TaskEditor.eLC.GetValue(90, k, n);
                                            break;
                                        }
                                    }
                                    for (int n = 0; n < TaskEditor.eLC.Lists[90].elementFields.Length; n++)
                                    {
                                        if (TaskEditor.eLC.Lists[90].elementFields[n] == "max_equips")
                                        {
                                            max_equips = TaskEditor.eLC.GetValue(90, k, n);
                                            break;
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
