
using ElementEditor;
using ElementEditor.helper_classes;
using PWDataEditorPaied.helper_classes;
using PWDataEditorPaied.PW_Admin_classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;

using System.Text;

namespace sTASKedit
{
    class Extensions
    {
        public static string decrypt(int key, byte[] text)
        {
            if (TaskEditor.version >= 53)
            {
                string result = "";
                byte[] dbyte = new byte[2];
                for (int i = 0; i < text.Length; i += 2)
                {
                    dbyte = BitConverter.GetBytes((short)key);
                    byte[] expr_20_cp_0 = dbyte;
                    int expr_20_cp_1 = 0;
                    expr_20_cp_0[expr_20_cp_1] ^= text[i];
                    byte[] expr_37_cp_0 = dbyte;
                    int expr_37_cp_1 = 1;
                    expr_37_cp_0[expr_37_cp_1] ^= text[i + 1];
                    result += BitConverter.ToChar(dbyte, 0);
                }
                string arg_6F_0 = result;
                char[] trimChars = new char[1];
                return arg_6F_0.TrimEnd(trimChars);
            }
            else
            {
                return ByteArray_to_UnicodeString(text);
            }
        }
        public static byte[] encrypt(int key, string text, int length, bool appendZero)
        {
            byte[] result;
            if (appendZero)
            {
                result = new byte[length + 2];
            }
            else
            {
                result = new byte[length];
            }
            if (TaskEditor.version >= 53)
            {
                byte[] dbyte = new byte[2];
                for (int i = 0; i < result.Length; i += 2)
                {
                    dbyte = BitConverter.GetBytes((short)key);
                    result[i] = dbyte[0];
                    result[i + 1] = dbyte[1];
                    if (i / 2 < text.Length)
                    {
                        dbyte = BitConverter.GetBytes(text[i / 2]);
                        byte[] expr_57_cp_0 = result;
                        int expr_57_cp_1 = i;
                        expr_57_cp_0[expr_57_cp_1] ^= dbyte[0];
                        byte[] expr_70_cp_0 = result;
                        int expr_70_cp_1 = i + 1;
                        expr_70_cp_0[expr_70_cp_1] ^= dbyte[1];
                    }
                }
                return result;
            }
            else
            {
                return UnicodeString_to_ByteArray2(text, length);
            }
        }

        internal static string ByteArray_to_HexString(byte[] value)
        {
            return BitConverter.ToString(value);
        }
        internal static byte[] HexString_to_ByteArray(string value)
        {
            char[] chArray = new char[]
			{
				'-'
			};
            string[] strArray = value.Split(chArray);
            byte[] numArray = new byte[strArray.Length];
            for (int index = 0; index < strArray.Length; index++)
            {
                numArray[index] = Convert.ToByte(strArray[index], 16);
            }
            return numArray;
        }

        internal static string ByteArray_to_GbkString(byte[] text)
        {
            Encoding encoding = Encoding.GetEncoding("GBK");
            char[] array = new char[1];
            char[] chArray = array;
            return encoding.GetString(text).Split(chArray)[0];
        }
        internal static byte[] GbkString_to_ByteArray(string text, int length)
        {
            Encoding encoding = Encoding.GetEncoding("GBK");
            byte[] numArray = new byte[length];
            byte[] bytes = encoding.GetBytes(text);
            if (numArray.Length > bytes.Length)
            {
                Array.Copy(bytes, numArray, bytes.Length);
            }
            else
            {
                byte[] numArray2 = bytes;
                byte[] numArray3 = numArray;
                int length2 = numArray3.Length;
                Array.Copy(numArray2, numArray3, length2);
            }
            return numArray;
        }
        public static byte[] GbkString_to_ByteArray2(string text, int length)
        {
            Encoding enc = Encoding.GetEncoding("GBK");
            byte[] target = new byte[length];
            byte[] source = enc.GetBytes(text);
            if (target.Length > source.Length)
            {
                Array.Copy(source, target, source.Length);
            }
            else
            {
                Array.Copy(source, target, target.Length);
            }
            return target;
        }

        internal static string ByteArray_to_UnicodeString(byte[] text)
        {
            Encoding encoding = Encoding.GetEncoding("Unicode");
            char[] array = new char[1];
            char[] chArray = array;
            return encoding.GetString(text).Split(chArray)[0];
        }
        internal static byte[] UnicodeString_to_ByteArray(string text, int length)
        {
            Encoding encoding = Encoding.GetEncoding("Unicode");
            byte[] numArray = new byte[length];
            byte[] bytes = encoding.GetBytes(text);
            if (numArray.Length > bytes.Length)
            {
                Array.Copy(bytes, numArray, bytes.Length);
            }
            else
            {
                byte[] numArray2 = bytes;
                byte[] numArray3 = numArray;
                int length2 = numArray3.Length;
                Array.Copy(numArray2, numArray3, length2);
            }
            return numArray;
        }
        public static byte[] UnicodeString_to_ByteArray2(string text, int length)
        {
            Encoding enc = Encoding.GetEncoding("Unicode");
            byte[] target = new byte[length];
            byte[] source = enc.GetBytes(text);
            if (target.Length > source.Length)
            {
                Array.Copy(source, target, source.Length);
            }
            else
            {
                Array.Copy(source, target, target.Length);
            }
            return target;
        }

        public static string SecondsToString(uint time)
        {
            uint days = time / 86400;
            time = time - (days * 86400);
            uint hours = time / 3600;
            time = time - (hours * 3600);
            uint minutes = time / 60;
            uint seconds = time - (minutes * 60);
            return (days.ToString("D2") + "-" + hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"));
        }
        public static uint StringToSecond(string time)
        {
            char[] chArray = new char[]
			{
				'-', ':'
			};
            string[] times = time.Split(chArray);
            return (86400 * Convert.ToUInt32(times[0])) + (3600 * Convert.ToUInt32(times[1])) + (60 * Convert.ToUInt32(times[2])) + Convert.ToUInt32(times[3]);
        }

        public static string ConvertToClientX(float x)
        {
            double cx = 400 + Math.Truncate(x * 0.1);
            return cx.ToString();
        }
        public static string ConvertToClientY(float y)
        {
            double cy = Math.Truncate(y * 0.1);
            return cy.ToString();
        }
        public static string ConvertToClientZ(float z)
        {
            double cz = 550 + Math.Truncate(z * 0.1);
            return cz.ToString();
        }

        public static string ItemName(int id)
        {
            string result;
            if (id != 0 && TaskEditor.LoadedElements == true)
            {
                try
                {
                    if(ElementsEditor.database.task_items.ContainsKey(id))
                    {
                        return ElementsEditor.database.task_items[id].name;
                    }else
                    {
                        return "Unknown("+ id + ")";
                    }
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result/*.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9)*/;
        }

        public static string MonsterNPCMineName(int id)
        {
            string result;
            if (TaskEditor.eLC != null && id != 0 && TaskEditor.LoadedElements == true)
            {
                try
                {
                    result = ElementsEditor.database.monsters_npcs_mines[id.ToString()].ToString();
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result/*.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9)*/;
        }

        public static string TitleName(int id)
        {
            string result;
            if (id != 0 && TaskEditor.LoadedElements == true)
            {
                try
                {
                    result = ElementsEditor.database.titles[id.ToString()].ToString();
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result/*.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9)*/;
        }

        public static string HomeItemName(int id)
        {
            string result;
            if (id != 0 && TaskEditor.LoadedElements == true)
            {
                try
                {
                    result = ElementsEditor.database.homeitems[id.ToString()].ToString();
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result/*.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9)*/;
        }

        public static Map InstanceName(int id)
        {
            Map result = new Map();
            if (TaskEditor.eLC == null) return result;

            result.name = Extensions.GetLocalization(404);
            try
            {
                result = TaskEditor.InstanceList[id];
            }
            catch
            {
            }

            return result;
        }

        public static string BuffDesc(int id)
        {
            string result;
            if (id != 0)
            {
                try
                {
                    int index = -1;
                    for (int num25 = 0; num25 < ElementsEditor.database.buff_str.Length - 1; num25 += 2)
                    {
                        if (Convert.ToInt32(ElementsEditor.database.buff_str[num25 + 0]) == id)
                        {
                            index = num25 + 1;
                            break;
                        }
                    }
                    if (ElementsEditor.database.buff_str.Length > index && index != -1)
                    {
                        result = ElementsEditor.database.buff_str[index];
                    }else
                    {
                        result = Extensions.GetLocalization(404);
                    }
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9);
        }

        public static string ItemDesc(int id)
        {
            string result;
            if (id != 0)
            {
                if(ElementsEditor.database.item_desc.ContainsKey(id))
                {
                    result = ElementsEditor.database.item_desc[id];
                }else
                {
                    result = "";
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result.Replace("\\r", Environment.NewLine).Replace("\\t", "" + (char)9);
        }

        public static string SkillName(int id)
        {
            string result;
            string nameid = id.ToString() + "0";
            try
            {
                int index = -1;
                for (int num25 = 0; num25 < ElementsEditor.database.skillstr.Length - 1; num25 += 4)
                {
                    if (Convert.ToInt32(ElementsEditor.database.skillstr[num25 + 0]) == Convert.ToInt32(nameid))
                    {
                        index = num25 + 1;
                        break;
                    }
                }
                result = ElementsEditor.database.skillstr[index];
            }
            catch
            {
                result = Extensions.GetLocalization(404);
            }

            return result/*.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9)*/;
        }

        public static string SkillDesc(int id)
        {
            string result;
            string descid = id.ToString() + "1";
            try
            {
                int index = -1;
                for (int num25 = 0; num25 < ElementsEditor.database.skillstr.Length - 1; num25 += 4)
                {
                    if (Convert.ToInt32(ElementsEditor.database.skillstr[num25 + 2]) == Convert.ToInt32(descid))
                    {
                        index = num25 + 3;
                        break;
                    }
                }
                result = ElementsEditor.database.skillstr[index];
            }
            catch
            {
                result = Extensions.GetLocalization(404);
            }

            return result.Replace("%%", "%")/*.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9)*/;
        }

        public static string SkillText(int id)
        {
            string result;
            if (id != 0)
            {
                try
                {
                    string name = Extensions.SkillName(id);
                    string desc = Extensions.SkillDesc(id);
                    if (name != Extensions.GetLocalization(404) && desc != Extensions.GetLocalization(404))
                    {
                        if (name != "")
                        {
                            if (desc != "")
                            {
                                result = name + "\n\n" + ColorClean(desc);
                            }
                            else
                            {
                                result = name;
                            }
                        }
                        else
                        {
                            result = ColorClean(desc);
                        }
                    }
                    else
                    {
                        result = Extensions.GetLocalization(404);
                    }
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9);
        }

        public static string RelayStationName(int id)
        {
            string result;
            if (id != 0 && TaskEditor.eLC != null)
            {
                try
                {
                    int index = -1;
                    for (int num25 = 0; num25 < ElementsEditor.database.world_targets.Length - 1; num25 += 5)
                    {
                        if (Convert.ToInt32(ElementsEditor.database.world_targets[num25 + 0]) == id)
                        {
                            index = num25 + 1;
                            break;
                        }
                    }
                    result = ElementsEditor.database.world_targets[index];
                }
                catch
                {
                    result = Extensions.GetLocalization(404);
                }
            }
            else
            {
                result = Extensions.GetLocalization(402);
            }

            return result.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9);
        }

        public static string GetLocalization(int key, bool v = false)
        {
            string result;
            try
            {
                if (TaskEditor.LocalizationText.ContainsKey(key.ToString()))
                {
                    result = TaskEditor.LocalizationText[key.ToString()].ToString();
                }else
                {
                    result = "NOT FOUND KEY " + key;
                }
            }
            catch
            {
                result = "NOT FOUND KEY " + key;
            }
            return result.Replace("\\n", Environment.NewLine).Replace("\\t", "" + (char)9);
        }

        public static int DigitNumberToInt32(object value)
        {
            string result = Convert.ToString(value).Replace("" + (char)160, "").Replace("" + (char)32, "");
            return Convert.ToInt32(result);
        }

        public static float PercentNumberToSingle(object value, bool EnableShowPercents)
        {
            if (EnableShowPercents == true)
            {
                float result = Convert.ToSingle(Convert.ToString(value).Replace("%", ""));
                return Convert.ToSingle(result * 0.01);
            }
            else
            {
                float result = Convert.ToSingle(value);
                return result;
            }
        }

        public static string ColorClean(string line)
        {
            if (line == ""|| line.Length <= 1) { return ""; }
            string[] blocks = line.Split(new char[] { '^' });
            if (blocks.Length > 1)
            {
                string result = "";

                if (blocks[0] != "")
                {
                    result += blocks[0];
                }
                for (int i = 1; i < blocks.Length; i++)
                {
                    if (blocks[i] != "")
                    {
                        result += blocks[i].Substring(6);
                    }
                }

                return result;
            }
            else
            {
                return line;
            }
        }

        public static string GetItemPWAProps(int Id, uint Period)
        {
            string line = "";
            uint proctypes;
            int l = 0;
            int pos_item = -1;
            int pos_proc_type = -1;
            bool Suc = false;
            try
            {
                for (int i = 0; i < ElementsEditor.database.task_items_list.Length; i += 2)
                {
                    if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                    {
                        l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
                        for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                        {
                            if (Convert.ToInt32(TaskEditor.eLC.GetValue(l, t, 0)) == Id)
                            {
                                pos_item = t;
                                Suc = true;
                                break;
                            }
                        }
                        if (Suc == true) break;
                    }
                }
                if (pos_item == -1)
                {
                    return line;
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                    {
                        line += TaskEditor.eLC.GetValue(l, pos_item, k);
                        break;
                    }
                }
                if (Period != 0)
                {
                    line += "\n" + Extensions.GetLocalization(7113) + Extensions.ItemPropsSecondsToString2(Period);
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "proc_type")
                    {
                        pos_proc_type = k;
                        break;
                    }
                }
                bool result = uint.TryParse(TaskEditor.eLC.GetValue(l, pos_item, pos_proc_type), out proctypes);
                List<uint> powers = new List<uint>(Extensions.GetPowers(proctypes));
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 6:
                            line += "<br>" + Extensions.GetLocalization(3006);//proc_type_64
                            break;
                        case 15:
                            line += "<br>" + Extensions.GetLocalization(3015);//proc_type_32768
                            break;
                    }
                }
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 13:
                            line += Extensions.GetLocalization(3013);//proc_type_8192
                            break;
                    }
                }
                if (TaskEditor.eLC.Version > 191)
                {
                    if (l == 3) line += WEAPON_ESSENCE.GetProps(pos_item);
                    if (l == 6) line += ARMOR_ESSENCE.GetProps(pos_item);
                    if (l == 9) line += DECORATION_ESSENCE.GetProps(pos_item);
                    if (l == 12) line += MEDICINE_ESSENCE.GetProps(pos_item);
                    if (l == 17) line += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                    if (l == 19) line += ARMORRUNE_ESSENCE.GetProps(pos_item);
                    if (l == 22) line += FLYSWORD_ESSENCE.GetProps(pos_item);
                    if (l == 23) line += WINGMANWING_ESSENCE.GetProps(pos_item);
                    if (l == 27) line += ELEMENT_ESSENCE.GetProps(pos_item);
                    if (l == 28) line += "<br>" + Extensions.GetLocalization(7118);
                    if (l == 31) line += PROJECTILE_ESSENCE.GetProps(pos_item);
                    if (l == 82) line += FASHION_ESSENCE.GetProps(pos_item);
                    if (l == 88) line += FACEPILL_ESSENCE.GetProps(pos_item);
                    if (l == 94) line += PET_EGG_ESSENCE.GetProps(pos_item);
                    if (l == 95) line += PET_FOOD_ESSENCE.GetProps(pos_item);
                    if (l == 97) line += FIREWORKS_ESSENCE.GetProps(pos_item);
                    if (l == 105) line += SKILLMATTER_ESSENCE.GetProps(pos_item);
                    if (l == 106) line += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                    if (l == 113) line += AUTOHP_ESSENCE.GetProps(pos_item);
                    if (l == 114) line += AUTOMP_ESSENCE.GetProps(pos_item);
                    if (l == 118) line += GOBLIN_ESSENCE.GetProps(pos_item);
                    if (l == 120) line += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                    if (l == 121) line += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                    if (l == 122) line += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                    if (l == 123) line += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                    if (l == 129) line += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                    if (l == 132) line += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                    if (l == 134) line += SHARPENER_ESSENCE.GetProps(pos_item);
                    if (l == 140) line += CONGREGATE_ESSENCE.GetProps(pos_item);
                    if (l == 150) line += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 183) line += POKER_ESSENCE.GetProps(pos_item);
                    if (l == 190) line += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 196) line += ASTROLABE_ESSENCE.GetProps(pos_item);
                    if (l == 211) line += FIREWORKS2_ESSENCE.GetProps(pos_item);
                    if (l == 217) line += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 82 && l != 88 && l != 94 && l != 95 && l != 97 && l != 105 &&
                        l != 106 && l != 113 && l != 114 && l != 118 && l != 120 && l != 121 && l != 122 &&
                        l != 123 && l != 129 && l != 132 && l != 134 && l != 140 && l != 150 && l != 183 &&
                        l != 190 && l != 196 && l != 211 && l != 217)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    line += "<br>" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (l == 3) line += WEAPON_ESSENCE.GetProps(pos_item);
                    if (l == 6) line += ARMOR_ESSENCE.GetProps(pos_item);
                    if (l == 9) line += DECORATION_ESSENCE.GetProps(pos_item);
                    if (l == 12) line += MEDICINE_ESSENCE.GetProps(pos_item);
                    if (l == 17) line += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                    if (l == 19) line += ARMORRUNE_ESSENCE.GetProps(pos_item);
                    if (l == 22) line += FLYSWORD_ESSENCE.GetProps(pos_item);
                    if (l == 23) line += WINGMANWING_ESSENCE.GetProps(pos_item);
                    if (l == 27) line += ELEMENT_ESSENCE.GetProps(pos_item);
                    if (l == 28) line += "<br>" + Extensions.GetLocalization(7118);
                    if (l == 31) line += PROJECTILE_ESSENCE.GetProps(pos_item);
                    if (l == 83) line += FASHION_ESSENCE.GetProps(pos_item);
                    if (l == 89) line += FACEPILL_ESSENCE.GetProps(pos_item);
                    if (l == 95) line += PET_EGG_ESSENCE.GetProps(pos_item);
                    if (l == 96) line += PET_FOOD_ESSENCE.GetProps(pos_item);
                    if (l == 98) line += FIREWORKS_ESSENCE.GetProps(pos_item);
                    if (l == 106) line += SKILLMATTER_ESSENCE.GetProps(pos_item);
                    if (l == 107) line += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                    if (l == 114) line += AUTOHP_ESSENCE.GetProps(pos_item);
                    if (l == 115) line += AUTOMP_ESSENCE.GetProps(pos_item);
                    if (l == 119) line += GOBLIN_ESSENCE.GetProps(pos_item);
                    if (l == 121) line += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                    if (l == 122) line += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                    if (l == 123) line += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                    if (l == 124) line += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                    if (l == 130) line += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                    if (l == 133) line += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                    if (l == 135) line += SHARPENER_ESSENCE.GetProps(pos_item);
                    if (l == 141) line += CONGREGATE_ESSENCE.GetProps(pos_item);
                    if (l == 151) line += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 184) line += POKER_ESSENCE.GetProps(pos_item);
                    if (l == 191) line += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 197) line += ASTROLABE_ESSENCE.GetProps(pos_item);
                    if (l == 212) line += FIREWORKS2_ESSENCE.GetProps(pos_item);
                    if (l == 218) line += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 83 && l != 89 && l != 95 && l != 96 && l != 98 && l != 106 &&
                        l != 107 && l != 114 && l != 115 && l != 119 && l != 121 && l != 122 && l != 123 &&
                        l != 124 && l != 130 && l != 133 && l != 135 && l != 141 && l != 151 && l != 184 &&
                        l != 191 && l != 197 && l != 212 && l != 218)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    line += "<br>" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                line += "<br><br>";
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 0:
                            line += Extensions.GetLocalization(3000);//proc_type_1
                            break;
                        case 1:
                            line += Extensions.GetLocalization(3001);//proc_type_2
                            break;
                        case 2:
                            line += Extensions.GetLocalization(3002);//proc_type_4
                            break;
                        case 3:
                            line += Extensions.GetLocalization(3003);//proc_type_8
                            break;
                        case 4:
                            line += Extensions.GetLocalization(3004);//proc_type_16
                            break;
                        case 5:
                            line += Extensions.GetLocalization(3005);//proc_type_32
                            break;
                        case 7:
                            line += Extensions.GetLocalization(3007);//proc_type_128
                            break;
                        case 8:
                            line += Extensions.GetLocalization(3008);//proc_type_256
                            break;
                        case 9:
                            line += Extensions.GetLocalization(3009);//proc_type_512
                            break;
                        case 10:
                            line += Extensions.GetLocalization(3010);//proc_type_1024
                            break;
                        case 11:
                            line += Extensions.GetLocalization(3011);//proc_type_2048
                            break;
                        case 12:
                            line += Extensions.GetLocalization(3012);//proc_type_4096
                            break;
                        case 14:
                            line += Extensions.GetLocalization(3014);//proc_type_16384
                            break;
                    }
                }
            }
            catch
            {
                //line = "";
            }
            return line;
        }

        public static string GetItemProps(int Id, uint Period)
        {
            string line = "";
            uint proctypes;
            int l = 0;
            int pos_item = -1;
            int pos_proc_type = -1;
            bool Suc = false;
            try
            {
                for (int i = 0; i < ElementsEditor.database.task_items_list.Length; i += 2)
                {
                    if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                    {
                        l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
                        for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                        {
                            if (Convert.ToInt32(TaskEditor.eLC.GetValue(l, t, 0)) == Id)
                            {
                                pos_item = t;
                                Suc = true;
                                break;
                            }
                        }
                        if (Suc == true) break;
                    }
                }
                if(pos_item == -1)
                {
                    return line;
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                    {
                        line += TaskEditor.eLC.GetValue(l, pos_item, k);
                        break;
                    }
                }
                if (Period != 0)
                {
                    line += "\n" + Extensions.GetLocalization(7113) + Extensions.ItemPropsSecondsToString2(Period);
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "proc_type")
                    {
                        pos_proc_type = k;
                        break;
                    }
                }
                bool result = uint.TryParse(TaskEditor.eLC.GetValue(l, pos_item, pos_proc_type), out proctypes);
                List<uint> powers = new List<uint>(Extensions.GetPowers(proctypes));
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 6:
                            line += "\n" + Extensions.GetLocalization(3006);//proc_type_64
                            break;
                        case 15:
                            line += "\n" + Extensions.GetLocalization(3015);//proc_type_32768
                            break;
                    }
                }
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 13:
                            line += Extensions.GetLocalization(3013);//proc_type_8192
                            break;
                    }
                }
                if (TaskEditor.eLC.Version > 191)
                {
                    if (l == 3) line += WEAPON_ESSENCE.GetProps(pos_item);
                    if (l == 6) line += ARMOR_ESSENCE.GetProps(pos_item);
                    if (l == 9) line += DECORATION_ESSENCE.GetProps(pos_item);
                    if (l == 12) line += MEDICINE_ESSENCE.GetProps(pos_item);
                    if (l == 17) line += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                    if (l == 19) line += ARMORRUNE_ESSENCE.GetProps(pos_item);
                    if (l == 22) line += FLYSWORD_ESSENCE.GetProps(pos_item);
                    if (l == 23) line += WINGMANWING_ESSENCE.GetProps(pos_item);
                    if (l == 27) line += ELEMENT_ESSENCE.GetProps(pos_item);
                    if (l == 28) line += "\n" + Extensions.GetLocalization(7118);
                    if (l == 31) line += PROJECTILE_ESSENCE.GetProps(pos_item);
                    if (l == 82) line += FASHION_ESSENCE.GetProps(pos_item);
                    if (l == 88) line += FACEPILL_ESSENCE.GetProps(pos_item);
                    if (l == 94) line += PET_EGG_ESSENCE.GetProps(pos_item);
                    if (l == 95) line += PET_FOOD_ESSENCE.GetProps(pos_item);
                    if (l == 97) line += FIREWORKS_ESSENCE.GetProps(pos_item);
                    if (l == 105) line += SKILLMATTER_ESSENCE.GetProps(pos_item);
                    if (l == 106) line += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                    if (l == 113) line += AUTOHP_ESSENCE.GetProps(pos_item);
                    if (l == 114) line += AUTOMP_ESSENCE.GetProps(pos_item);
                    if (l == 118) line += GOBLIN_ESSENCE.GetProps(pos_item);
                    if (l == 120) line += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                    if (l == 121) line += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                    if (l == 122) line += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                    if (l == 123) line += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                    if (l == 129) line += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                    if (l == 132) line += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                    if (l == 134) line += SHARPENER_ESSENCE.GetProps(pos_item);
                    if (l == 140) line += CONGREGATE_ESSENCE.GetProps(pos_item);
                    if (l == 150) line += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 183) line += POKER_ESSENCE.GetProps(pos_item);
                    if (l == 190) line += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 196) line += ASTROLABE_ESSENCE.GetProps(pos_item);
                    if (l == 211) line += FIREWORKS2_ESSENCE.GetProps(pos_item);
                    if (l == 217) line += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 82 && l != 88 && l != 94 && l != 95 && l != 97 && l != 105 &&
                        l != 106 && l != 113 && l != 114 && l != 118 && l != 120 && l != 121 && l != 122 &&
                        l != 123 && l != 129 && l != 132 && l != 134 && l != 140 && l != 150 && l != 183 &&
                        l != 190 && l != 196 && l != 211 && l != 217)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (l == 3) line += WEAPON_ESSENCE.GetProps(pos_item);
                    if (l == 6) line += ARMOR_ESSENCE.GetProps(pos_item);
                    if (l == 9) line += DECORATION_ESSENCE.GetProps(pos_item);
                    if (l == 12) line += MEDICINE_ESSENCE.GetProps(pos_item);
                    if (l == 17) line += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                    if (l == 19) line += ARMORRUNE_ESSENCE.GetProps(pos_item);
                    if (l == 22) line += FLYSWORD_ESSENCE.GetProps(pos_item);
                    if (l == 23) line += WINGMANWING_ESSENCE.GetProps(pos_item);
                    if (l == 27) line += ELEMENT_ESSENCE.GetProps(pos_item);
                    if (l == 28) line += "\n" + Extensions.GetLocalization(7118);
                    if (l == 31) line += PROJECTILE_ESSENCE.GetProps(pos_item);
                    if (l == 83) line += FASHION_ESSENCE.GetProps(pos_item);
                    if (l == 89) line += FACEPILL_ESSENCE.GetProps(pos_item);
                    if (l == 95) line += PET_EGG_ESSENCE.GetProps(pos_item);
                    if (l == 96) line += PET_FOOD_ESSENCE.GetProps(pos_item);
                    if (l == 98) line += FIREWORKS_ESSENCE.GetProps(pos_item);
                    if (l == 106) line += SKILLMATTER_ESSENCE.GetProps(pos_item);
                    if (l == 107) line += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                    if (l == 114) line += AUTOHP_ESSENCE.GetProps(pos_item);
                    if (l == 115) line += AUTOMP_ESSENCE.GetProps(pos_item);
                    if (l == 119) line += GOBLIN_ESSENCE.GetProps(pos_item);
                    if (l == 121) line += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                    if (l == 122) line += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                    if (l == 123) line += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                    if (l == 124) line += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                    if (l == 130) line += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                    if (l == 133) line += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                    if (l == 135) line += SHARPENER_ESSENCE.GetProps(pos_item);
                    if (l == 141) line += CONGREGATE_ESSENCE.GetProps(pos_item);
                    if (l == 151) line += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 184) line += POKER_ESSENCE.GetProps(pos_item);
                    if (l == 191) line += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 197) line += ASTROLABE_ESSENCE.GetProps(pos_item);
                    if (l == 212) line += FIREWORKS2_ESSENCE.GetProps(pos_item);
                    if (l == 218) line += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 83 && l != 89 && l != 95 && l != 96 && l != 98 && l != 106 &&
                        l != 107 && l != 114 && l != 115 && l != 119 && l != 121 && l != 122 && l != 123 &&
                        l != 124 && l != 130 && l != 133 && l != 135 && l != 141 && l != 151 && l != 184 &&
                        l != 191 && l != 197 && l != 212 && l != 218)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                line += "\n\n";
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 0:
                            line += Extensions.GetLocalization(3000);//proc_type_1
                            break;
                        case 1:
                            line += Extensions.GetLocalization(3001);//proc_type_2
                            break;
                        case 2:
                            line += Extensions.GetLocalization(3002);//proc_type_4
                            break;
                        case 3:
                            line += Extensions.GetLocalization(3003);//proc_type_8
                            break;
                        case 4:
                            line += Extensions.GetLocalization(3004);//proc_type_16
                            break;
                        case 5:
                            line += Extensions.GetLocalization(3005);//proc_type_32
                            break;
                        case 7:
                            line += Extensions.GetLocalization(3007);//proc_type_128
                            break;
                        case 8:
                            line += Extensions.GetLocalization(3008);//proc_type_256
                            break;
                        case 9:
                            line += Extensions.GetLocalization(3009);//proc_type_512
                            break;
                        case 10:
                            line += Extensions.GetLocalization(3010);//proc_type_1024
                            break;
                        case 11:
                            line += Extensions.GetLocalization(3011);//proc_type_2048
                            break;
                        case 12:
                            line += Extensions.GetLocalization(3012);//proc_type_4096
                            break;
                        case 14:
                            line += Extensions.GetLocalization(3014);//proc_type_16384
                            break;
                    }
                }
            }
            catch
            {
                //line = "";
            }
            return line;
        }

        public static InfoTool GetItemProps2(int Id, uint Period, int l, int pos_item)
        {
            InfoTool ift = new InfoTool();
            uint proctypes;
            int pos_proc_type = -1;
            ift.itemId = Id;
            try
            {

                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                    {
                        ift.name = TaskEditor.eLC.GetValue(l, pos_item, k);
                        break;
                    }
                }
                if (Period != 0)
                {
                    ift.time = "\n" + Extensions.GetLocalization(7113) + Extensions.ItemPropsSecondsToString2(Period);
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "proc_type")
                    {
                        pos_proc_type = k;
                        break;
                    }
                }
                bool result = uint.TryParse(TaskEditor.eLC.GetValue(l, pos_item, pos_proc_type), out proctypes);
                List<uint> powers = new List<uint>(Extensions.GetPowers(proctypes));
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 6:
                            ift.powers += "\n" + Extensions.GetLocalization(3006);//proc_type_64
                            break;
                        case 15:
                            ift.powers += "\n" + Extensions.GetLocalization(3015);//proc_type_32768
                            break;
                    }
                }

                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 13:
                            ift.powers += Extensions.GetLocalization(3013);//proc_type_8192
                            break;
                    }
                }
                if (TaskEditor.eLC.Version > 191)
                {
                    if (l == 3) ift.addons += WEAPON_ESSENCE.GetProps(pos_item);
                    if (l == 6) ift.addons += ARMOR_ESSENCE.GetProps(pos_item);
                    if (l == 9) ift.addons += DECORATION_ESSENCE.GetProps(pos_item);
                    if (l == 12) ift.addons += MEDICINE_ESSENCE.GetProps(pos_item);
                    if (l == 17) ift.addons += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                    if (l == 19) ift.addons += ARMORRUNE_ESSENCE.GetProps(pos_item);
                    if (l == 22) ift.addons += FLYSWORD_ESSENCE.GetProps(pos_item);
                    if (l == 23) ift.addons += WINGMANWING_ESSENCE.GetProps(pos_item);
                    if (l == 27) ift.addons += ELEMENT_ESSENCE.GetProps(pos_item);
                    if (l == 28) ift.addons += "\n" + Extensions.GetLocalization(7118);
                    if (l == 31) ift.addons += PROJECTILE_ESSENCE.GetProps(pos_item);
                    if (l == 82) ift.addons += FASHION_ESSENCE.GetProps(pos_item);
                    if (l == 88) ift.addons += FACEPILL_ESSENCE.GetProps(pos_item);
                    if (l == 94) ift.addons += PET_EGG_ESSENCE.GetProps(pos_item);
                    if (l == 95) ift.addons += PET_FOOD_ESSENCE.GetProps(pos_item);
                    if (l == 97) ift.addons += FIREWORKS_ESSENCE.GetProps(pos_item);
                    if (l == 105) ift.addons += SKILLMATTER_ESSENCE.GetProps(pos_item);
                    if (l == 106) ift.addons += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                    if (l == 113) ift.addons += AUTOHP_ESSENCE.GetProps(pos_item);
                    if (l == 114) ift.addons += AUTOMP_ESSENCE.GetProps(pos_item);
                    if (l == 118) ift.addons += GOBLIN_ESSENCE.GetProps(pos_item);
                    if (l == 120) ift.addons += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                    if (l == 121) ift.addons += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                    if (l == 122) ift.addons += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                    if (l == 123) ift.addons += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                    if (l == 129) ift.addons += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                    if (l == 132) ift.addons += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                    if (l == 134) ift.addons += SHARPENER_ESSENCE.GetProps(pos_item);
                    if (l == 140) ift.addons += CONGREGATE_ESSENCE.GetProps(pos_item);
                    if (l == 150) ift.addons += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 183) ift.addons += POKER_ESSENCE.GetProps(pos_item);
                    if (l == 190) ift.addons += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 196) ift.addons += ASTROLABE_ESSENCE.GetProps(pos_item);
                    if (l == 211) ift.addons += FIREWORKS2_ESSENCE.GetProps(pos_item);
                    if (l == 217) ift.addons += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 82 && l != 88 && l != 94 && l != 95 && l != 97 && l != 105 &&
                        l != 106 && l != 113 && l != 114 && l != 118 && l != 120 && l != 121 && l != 122 &&
                        l != 123 && l != 129 && l != 132 && l != 134 && l != 140 && l != 150 && l != 183 &&
                        l != 190 && l != 196 && l != 211 && l != 217)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    ift.price += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (l == 3) ift.addons += WEAPON_ESSENCE.GetProps(pos_item);
                    if (l == 6) ift.addons += ARMOR_ESSENCE.GetProps(pos_item);
                    if (l == 9) ift.addons += DECORATION_ESSENCE.GetProps(pos_item);
                    if (l == 12) ift.addons += MEDICINE_ESSENCE.GetProps(pos_item);
                    if (l == 17) ift.addons += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                    if (l == 19) ift.addons += ARMORRUNE_ESSENCE.GetProps(pos_item);
                    if (l == 22) ift.addons += FLYSWORD_ESSENCE.GetProps(pos_item);
                    if (l == 23) ift.addons += WINGMANWING_ESSENCE.GetProps(pos_item);
                    if (l == 27) ift.addons += ELEMENT_ESSENCE.GetProps(pos_item);
                    if (l == 28) ift.addons += "\n" + Extensions.GetLocalization(7118);
                    if (l == 31) ift.addons += PROJECTILE_ESSENCE.GetProps(pos_item);
                    if (l == 83) ift.addons += FASHION_ESSENCE.GetProps(pos_item);
                    if (l == 89) ift.addons += FACEPILL_ESSENCE.GetProps(pos_item);
                    if (l == 95) ift.addons += PET_EGG_ESSENCE.GetProps(pos_item);
                    if (l == 96) ift.addons += PET_FOOD_ESSENCE.GetProps(pos_item);
                    if (l == 98) ift.addons += FIREWORKS_ESSENCE.GetProps(pos_item);
                    if (l == 106) ift.addons += SKILLMATTER_ESSENCE.GetProps(pos_item);
                    if (l == 107) ift.addons += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                    if (l == 114) ift.addons += AUTOHP_ESSENCE.GetProps(pos_item);
                    if (l == 115) ift.addons += AUTOMP_ESSENCE.GetProps(pos_item);
                    if (l == 119) ift.addons += GOBLIN_ESSENCE.GetProps(pos_item);
                    if (l == 121) ift.addons += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                    if (l == 122) ift.addons += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                    if (l == 123) ift.addons += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                    if (l == 124) ift.addons += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                    if (l == 130) ift.addons += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                    if (l == 133) ift.addons += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                    if (l == 135) ift.addons += SHARPENER_ESSENCE.GetProps(pos_item);
                    if (l == 141) ift.addons += CONGREGATE_ESSENCE.GetProps(pos_item);
                    if (l == 151) ift.addons += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 184) ift.addons += POKER_ESSENCE.GetProps(pos_item);
                    if (l == 191) ift.addons += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                    if (l == 197) ift.addons += ASTROLABE_ESSENCE.GetProps(pos_item);
                    if (l == 212) ift.addons += FIREWORKS2_ESSENCE.GetProps(pos_item);
                    if (l == 218) ift.addons += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 83 && l != 89 && l != 95 && l != 96 && l != 98 && l != 106 &&
                        l != 107 && l != 114 && l != 115 && l != 119 && l != 121 && l != 122 && l != 123 &&
                        l != 124 && l != 130 && l != 133 && l != 135 && l != 141 && l != 151 && l != 184 &&
                        l != 191 && l != 197 && l != 212 && l != 218)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    ift.price += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                if (ift.addons.Length > 1)
                {
                    ift.addons = ift.addons.Remove(0, 1) + "\n\n";
                }
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 0:
                            ift.protect += Extensions.GetLocalization(3000);//proc_type_1
                            break;
                        case 1:
                            ift.protect += Extensions.GetLocalization(3001);//proc_type_2
                            break;
                        case 2:
                            ift.protect += Extensions.GetLocalization(3002);//proc_type_4
                            break;
                        case 3:
                            ift.protect += Extensions.GetLocalization(3003);//proc_type_8
                            break;
                        case 4:
                            ift.protect += Extensions.GetLocalization(3004);//proc_type_16
                            break;
                        case 5:
                            ift.protect += Extensions.GetLocalization(3005);//proc_type_32
                            break;
                        case 7:
                            ift.protect += Extensions.GetLocalization(3007);//proc_type_128
                            break;
                        case 8:
                            ift.protect += Extensions.GetLocalization(3008);//proc_type_256
                            break;
                        case 9:
                            ift.protect += Extensions.GetLocalization(3009);//proc_type_512
                            break;
                        case 10:
                            ift.protect += Extensions.GetLocalization(3010);//proc_type_1024
                            break;
                        case 11:
                            ift.protect += Extensions.GetLocalization(3011);//proc_type_2048
                            break;
                        case 12:
                            ift.protect += Extensions.GetLocalization(3012);//proc_type_4096
                            break;
                        case 14:
                            ift.protect += Extensions.GetLocalization(3014);//proc_type_16384
                            break;
                    }
                }

                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "file_icon")
                    {
                        string image = TaskEditor.eLC.GetValue(l, pos_item, k);
                        String path = Path.GetFileName(image);
                        if (ElementsEditor.database.ContainsKey(path))
                        {
                            ift.img = ElementsEditor.database.images(path);
                        }
                        else
                        {
                            ift.img = ElementsEditor.database.images("unknown.dds");
                        }
                        break;
                    }
                }
                if (ElementsEditor.database.item_desc.ContainsKey(ift.itemId))
                {
                    ift.description = ElementsEditor.database.item_desc[ift.itemId];
                }

            }
            catch
            {

            }
            if (ift.addons.Length > 1 || ift.img != null)
            {
                return ift;
            }
            else
            {
                return null;
            }
        }

        public static Recipe getCraftByRecipId(int Id, uint Period)
        {
            int l = TaskEditor.eLC.RecipeListIndex;
            int pos_item = -1;
            if(ElementsEditor.database.task_recipes.ContainsKey(Id))
            {
                pos_item = ElementsEditor.database.task_recipes[Id].index;
            }
            if(pos_item == -1)
            {
                return null;
            }
            Recipe recipe = new Recipe();
            recipe.list = l;
            recipe.index = pos_item;
            int mat = 1;
            int num = 1;
            for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
            {
                if (TaskEditor.eLC.Lists[l].elementFields[k].Contains("materials_" + mat + "_id"))
                {
                    int id = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                    recipe.materials.Add(k, id.ToString());
                    mat++;
                }
                if (TaskEditor.eLC.Lists[l].elementFields[k].Contains("materials_" + num + "_num"))
                {
                    int id = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                    recipe.materials_count.Add(k, id.ToString());
                    num++;
                }
                switch (TaskEditor.eLC.Lists[l].elementFields[k])
                {
                    case "ID":
                        recipe.ID = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.ID_rowId = k;
                        break;
                    case "Name":
                        recipe.Name = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.Name_rowId = k;
                        break;
                    case "recipe_level":
                        recipe.recipe_level = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.recipe_level_rowId = k;
                        break;
                    case "price":
                        recipe.price = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.fail_probability_rowId = k;
                        break;
                    case "id_major_type":
                        recipe.id_major_type = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.id_major_type_rowId = k;
                        break;
                    case "id_sub_type":
                        recipe.id_sub_type = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.id_sub_type_rowId = k;
                        break;
                    case "fail_probability":
                        recipe.fail_probability = Convert.ToSingle(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.fail_probability_rowId = k;
                        break;
                    case "id_skill":
                        recipe.id_skill = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.id_skill_rowId = k;
                        break;
                    case "skill_level":
                        recipe.skill_level = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.skill_level_rowId = k;
                        break;
                    case "bind_type":
                        recipe.bind_type = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.bind_type_rowId = k;
                        break;
                    case "targets_1_id_to_make":
                        recipe.targets_1_id_to_make = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.targets_1_id_to_make_rowId = k;
                        break;
                    case "targets_2_id_to_make":
                        recipe.targets_2_id_to_make = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.targets_2_id_to_make_rowId = k;
                        break;
                    case "targets_3_id_to_make":
                        recipe.targets_3_id_to_make = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.targets_3_id_to_make_rowId = k;
                        break;
                    case "targets_4_id_to_make":
                        recipe.targets_4_id_to_make = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.targets_4_id_to_make_rowId = k;
                        break;
                    case "targets_1_probability":
                        recipe.targets_1_probability = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.targets_1_probability_rowId = k;
                        break;
                    case "targets_2_probability":
                        recipe.targets_2_probability = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.targets_2_probability_rowId = k;
                        break;
                    case "targets_3_probability":
                        recipe.targets_3_probability = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.targets_3_probability_rowId = k;
                        break;
                    case "targets_4_probability":
                        recipe.targets_4_probability = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.targets_4_probability_rowId = k;
                        break;
                    case "num_to_make":
                        recipe.num_to_make = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.num_to_make_rowId = k;
                        break;
                    case "duration":
                        recipe.duration = float.Parse(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.duration_rowId = k;
                        break;
                    case "exp":
                        recipe.exp = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.exp_rowId = k;
                        break;
                    case "skillpoint":
                        recipe.skillpoint = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.skillpoint_rowId = k;
                        break;
                    case "id_upgrade_equip":
                        recipe.id_upgrade_equip = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.id_upgrade_equip_rowId = k;
                        break;
                    case "upgrade_rate":
                        recipe.upgrade_rate = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.upgrade_rate_rowId = k;
                        break;
                    case "proc_type":
                        recipe.proc_type = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.proc_type_rowId = k;
                        break;
                    case "character_combo_id":
                        recipe.character_combo_id = Convert.ToInt32(TaskEditor.eLC.GetValue(l, pos_item, k));
                        recipe.character_combo_id_rowId = k;
                        break;
                    case "upgrade_engrave_rate":
                        recipe.upgrade_engrave_rate = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.upgrade_engrave_rate_rowId = k;
                        break;
                    case "upgrade_addon_rate":
                        recipe.upgrade_addon_rate = TaskEditor.eLC.GetValue(l, pos_item, k);
                        recipe.upgrade_addon_rate_rowId = k;
                        break;
                }
            }
            return recipe;
        }

        public static InfoTool GetItemProps2byId(int Id, uint Period)
        {
            InfoTool ift = new InfoTool();
            uint proctypes;
            int pos_proc_type = -1;
            ift.itemId = Id;
            int l = 0;
            int pos_item = 0;
            bool Suc = false;


                if (ElementsEditor.database.task_items.ContainsKey(Id))
                {
                    pos_item = ElementsEditor.database.task_items[Id].index;
                    l = ElementsEditor.database.task_items[Id].listID;
                    ift.name = ElementsEditor.database.task_items[Id].name;
                    ift.price = ift.price += "\n" + Extensions.GetLocalization(7024) + " " + ElementsEditor.database.task_items[Id].price;
                    ift.test = ElementsEditor.database.task_items[Id];
                    if (ElementsEditor.database.ContainsKey(ElementsEditor.database.task_items[Id].iconpath))
                    {
                        ift.img = ElementsEditor.database.images(ElementsEditor.database.task_items[Id].iconpath);
                    }
                    else
                    {
                        ift.img = ElementsEditor.database.images("unknown.dds");
                    }
                }
                else
                {
                    for (int i = 0; i < ElementsEditor.database.task_items_list.Length; i += 2)
                    {
                        if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                        {
                            l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
                            for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                            {
                                if (Convert.ToInt32(TaskEditor.eLC.GetValue(l, t, 0)) == Id)
                                {
                                    pos_item = t;
                                    Suc = true;
                                    break;
                                }
                            }
                            if (Suc == true) break;
                        }
                    }

                    for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                        {
                            ift.name = TaskEditor.eLC.GetValue(l, pos_item, k);
                            break;
                        }
                    }

                    for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[k] == "file_icon")
                        {
                            ift.file_icon = TaskEditor.eLC.GetValue(l, pos_item, k);
                            String path = Path.GetFileName(ift.file_icon);
                            Bitmap img = null;
                            if (ElementsEditor.database.ContainsKey(path))
                            {
                                img = ElementsEditor.database.images(path);
                            }
                            if (img != null)
                            {
                                ift.img = img;
                            }
                            break;
                        }
                    }

                    if (Period != 0)
                    {
                        ift.time = "\n" + Extensions.GetLocalization(7113) + Extensions.ItemPropsSecondsToString2(Period);
                    }
                    for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[k] == "proc_type")
                        {
                            pos_proc_type = k;
                            break;
                        }
                    }
                    for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[k] == "file_icon")
                        {
                            string image = TaskEditor.eLC.GetValue(l, pos_item, k);
                            String path = Path.GetFileName(image);
                            if (ElementsEditor.database.ContainsKey(path))
                            {
                                ift.img = ElementsEditor.database.images(path);
                            }
                            else
                            {
                                ift.img = ElementsEditor.database.images("unknown.dds");
                            }
                            break;
                        }
                    }
                if (TaskEditor.eLC.Version > 191)
                {
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 82 && l != 88 && l != 94 && l != 95 && l != 97 && l != 105 &&
                        l != 106 && l != 113 && l != 114 && l != 118 && l != 120 && l != 121 && l != 122 &&
                        l != 123 && l != 129 && l != 132 && l != 134 && l != 140 && l != 150 && l != 183 &&
                        l != 190 && l != 196 && l != 211 && l != 217)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    ift.price += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (l != 3 && l != 6 && l != 9 && l != 12 && l != 17 && l != 19 && l != 22 && l != 23 &&
                        l != 27 && l != 31 && l != 83 && l != 89 && l != 95 && l != 96 && l != 98 && l != 106 &&
                        l != 107 && l != 114 && l != 115 && l != 119 && l != 121 && l != 122 && l != 123 &&
                        l != 124 && l != 130 && l != 133 && l != 135 && l != 141 && l != 151 && l != 184 &&
                        l != 191 && l != 197 && l != 212 && l != 218)
                    {
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "price")
                            {
                                string price = TaskEditor.eLC.GetValue(l, pos_item, k);
                                if (price != "0")
                                {
                                    ift.price += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                                }
                                break;
                            }
                        }
                    }
                }
                }

                bool result = uint.TryParse(TaskEditor.eLC.GetValue(l, pos_item, pos_proc_type), out proctypes);
                List<uint> powers = new List<uint>(Extensions.GetPowers(proctypes));
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 6:
                            ift.powers += "\n" + Extensions.GetLocalization(3006);//proc_type_64
                            break;
                        case 15:
                            ift.powers += "\n" + Extensions.GetLocalization(3015);//proc_type_32768
                            break;
                    }
                }

                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 13:
                            ift.powers += Extensions.GetLocalization(3013);//proc_type_8192
                            break;
                    }
                }
            if (TaskEditor.eLC.Version > 191)
            {
                if (l == 3) ift.addons += WEAPON_ESSENCE.GetProps(pos_item);
                if (l == 6) ift.addons += ARMOR_ESSENCE.GetProps(pos_item);
                if (l == 9) ift.addons += DECORATION_ESSENCE.GetProps(pos_item);
                if (l == 12) ift.addons += MEDICINE_ESSENCE.GetProps(pos_item);
                if (l == 17) ift.addons += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                if (l == 19) ift.addons += ARMORRUNE_ESSENCE.GetProps(pos_item);
                if (l == 22) ift.addons += FLYSWORD_ESSENCE.GetProps(pos_item);
                if (l == 23) ift.addons += WINGMANWING_ESSENCE.GetProps(pos_item);
                if (l == 27) ift.addons += ELEMENT_ESSENCE.GetProps(pos_item);
                if (l == 28) ift.addons += "\n" + Extensions.GetLocalization(7118);
                if (l == 31) ift.addons += PROJECTILE_ESSENCE.GetProps(pos_item);
                if (l == 82) ift.addons += FASHION_ESSENCE.GetProps(pos_item);
                if (l == 88) ift.addons += FACEPILL_ESSENCE.GetProps(pos_item);
                if (l == 94) ift.addons += PET_EGG_ESSENCE.GetProps(pos_item);
                if (l == 95) ift.addons += PET_FOOD_ESSENCE.GetProps(pos_item);
                if (l == 97) ift.addons += FIREWORKS_ESSENCE.GetProps(pos_item);
                if (l == 105) ift.addons += SKILLMATTER_ESSENCE.GetProps(pos_item);
                if (l == 106) ift.addons += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                if (l == 113) ift.addons += AUTOHP_ESSENCE.GetProps(pos_item);
                if (l == 114) ift.addons += AUTOMP_ESSENCE.GetProps(pos_item);
                if (l == 118) ift.addons += GOBLIN_ESSENCE.GetProps(pos_item);
                if (l == 120) ift.addons += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                if (l == 121) ift.addons += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                if (l == 122) ift.addons += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                if (l == 123) ift.addons += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                if (l == 129) ift.addons += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                if (l == 132) ift.addons += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                if (l == 134) ift.addons += SHARPENER_ESSENCE.GetProps(pos_item);
                if (l == 140) ift.addons += CONGREGATE_ESSENCE.GetProps(pos_item);
                if (l == 150) ift.addons += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                if (l == 183) ift.addons += POKER_ESSENCE.GetProps(pos_item);
                if (l == 190) ift.addons += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                if (l == 196) ift.addons += ASTROLABE_ESSENCE.GetProps(pos_item);
                if (l == 211) ift.addons += FIREWORKS2_ESSENCE.GetProps(pos_item);
                if (l == 217) ift.addons += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
            }
            else
            {
                if (l == 3) ift.addons += WEAPON_ESSENCE.GetProps(pos_item);
                if (l == 6) ift.addons += ARMOR_ESSENCE.GetProps(pos_item);
                if (l == 9) ift.addons += DECORATION_ESSENCE.GetProps(pos_item);
                if (l == 12) ift.addons += MEDICINE_ESSENCE.GetProps(pos_item);
                if (l == 17) ift.addons += DAMAGERUNE_ESSENCE.GetProps(pos_item);
                if (l == 19) ift.addons += ARMORRUNE_ESSENCE.GetProps(pos_item);
                if (l == 22) ift.addons += FLYSWORD_ESSENCE.GetProps(pos_item);
                if (l == 23) ift.addons += WINGMANWING_ESSENCE.GetProps(pos_item);
                if (l == 27) ift.addons += ELEMENT_ESSENCE.GetProps(pos_item);
                if (l == 28) ift.addons += "\n" + Extensions.GetLocalization(7118);
                if (l == 31) ift.addons += PROJECTILE_ESSENCE.GetProps(pos_item);
                if (l == 83) ift.addons += FASHION_ESSENCE.GetProps(pos_item);
                if (l == 89) ift.addons += FACEPILL_ESSENCE.GetProps(pos_item);
                if (l == 95) ift.addons += PET_EGG_ESSENCE.GetProps(pos_item);
                if (l == 96) ift.addons += PET_FOOD_ESSENCE.GetProps(pos_item);
                if (l == 98) ift.addons += FIREWORKS_ESSENCE.GetProps(pos_item);
                if (l == 106) ift.addons += SKILLMATTER_ESSENCE.GetProps(pos_item);
                if (l == 107) ift.addons += REFINE_TICKET_ESSENCE.GetProps(pos_item);
                if (l == 114) ift.addons += AUTOHP_ESSENCE.GetProps(pos_item);
                if (l == 115) ift.addons += AUTOMP_ESSENCE.GetProps(pos_item);
                if (l == 119) ift.addons += GOBLIN_ESSENCE.GetProps(pos_item);
                if (l == 121) ift.addons += GOBLIN_EQUIP_ESSENCE.GetProps(pos_item);
                if (l == 122) ift.addons += GOBLIN_EXPPILL_ESSENCE.GetProps(pos_item);
                if (l == 123) ift.addons += SELL_CERTIFICATE_ESSENCE.GetProps(pos_item);
                if (l == 124) ift.addons += TARGET_ITEM_ESSENCE.GetProps(pos_item);
                if (l == 130) ift.addons += INC_SKILL_ABILITY_ESSENCE.GetProps(pos_item);
                if (l == 133) ift.addons += WEDDING_BOOKCARD_ESSENCE.GetProps(pos_item);
                if (l == 135) ift.addons += SHARPENER_ESSENCE.GetProps(pos_item);
                if (l == 141) ift.addons += CONGREGATE_ESSENCE.GetProps(pos_item);
                if (l == 151) ift.addons += FORCE_TOKEN_ESSENCE.GetProps(pos_item);
                if (l == 184) ift.addons += POKER_ESSENCE.GetProps(pos_item);
                if (l == 191) ift.addons += UNIVERSAL_TOKEN_ESSENCE.GetProps(pos_item);
                if (l == 197) ift.addons += ASTROLABE_ESSENCE.GetProps(pos_item);
                if (l == 212) ift.addons += FIREWORKS2_ESSENCE.GetProps(pos_item);
                if (l == 218) ift.addons += HOME_FORMULAS_ITEM_ESSENCE.GetProps(pos_item);
            }

            if (ift.addons.Length > 1)
                {
                    ift.addons = ift.addons.Remove(0, 1) + "\n\n";
                }
                for (int p = 0; p < powers.Count; p++)
                {
                    if (powers[p] == 0) continue;

                    switch (p)
                    {
                        case 0:
                            ift.protect += Extensions.GetLocalization(3000);//proc_type_1
                            break;
                        case 1:
                            ift.protect += Extensions.GetLocalization(3001);//proc_type_2
                            break;
                        case 2:
                            ift.protect += Extensions.GetLocalization(3002);//proc_type_4
                            break;
                        case 3:
                            ift.protect += Extensions.GetLocalization(3003);//proc_type_8
                            break;
                        case 4:
                            ift.protect += Extensions.GetLocalization(3004);//proc_type_16
                            break;
                        case 5:
                            ift.protect += Extensions.GetLocalization(3005);//proc_type_32
                            break;
                        case 7:
                            ift.protect += Extensions.GetLocalization(3007);//proc_type_128
                            break;
                        case 8:
                            ift.protect += Extensions.GetLocalization(3008);//proc_type_256
                            break;
                        case 9:
                            ift.protect += Extensions.GetLocalization(3009);//proc_type_512
                            break;
                        case 10:
                            ift.protect += Extensions.GetLocalization(3010);//proc_type_1024
                            break;
                        case 11:
                            ift.protect += Extensions.GetLocalization(3011);//proc_type_2048
                            break;
                        case 12:
                            ift.protect += Extensions.GetLocalization(3012);//proc_type_4096
                            break;
                        case 14:
                            ift.protect += Extensions.GetLocalization(3014);//proc_type_16384
                            break;
                    }
                }

            if (ElementsEditor.database.item_desc.ContainsKey(ift.itemId))
            {
                ift.description = ElementsEditor.database.item_desc[ift.itemId];
            }
            return ift;

        }



        public static string GetMonsterNPCMineProps(int Id)
        {
            string line = "";
            int l = 0;
            int pos = -1;
            bool Suc = false;
            if (TaskEditor.eLC == null)
                return line;

            try
            {
                for (int i = 0; i < TaskEditor.monster_npc_minelists.Count; i++)
                {
                    l = Convert.ToInt32(TaskEditor.monster_npc_minelists[i]);
                    for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                    {
                        if (Convert.ToInt32(TaskEditor.eLC.GetValue(l, t, 0)) == Id)
                        {
                            pos = t;
                            Suc = true;
                            break;
                        }
                    }
                    if (Suc == true) break;
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                    {
                        if (pos != -1)
                        { 
                            line += TaskEditor.eLC.GetValue(l, pos, k);
                            break;
                        }
                    }
                }
                if (l == 38) line += MONSTER_ESSENCE.GetProps(pos);
                if (l == 57) line += NPC_ESSENCE.GetProps(pos);
                if (l == TaskEditor.eLC.MineEssenceList) line += MINE_ESSENCE.GetProps(pos);
            }
            catch
            {
                line = "";
            }
            return line;
        }

        public static string GetTitleProps(int Id)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[TaskEditor.eLC.TitleListIndex].elementValues.Count; k++)
                {
                    if (Convert.ToInt32(TaskEditor.eLC.GetValue(TaskEditor.eLC.TitleListIndex, k, 0)) == Id)
                    {
                        line += TITLE_CONFIG.GetProps(k);
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

        public static string GetHomeItemProps(int Id)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[TaskEditor.eLC.HomeItemsListIndex].elementValues.Count; k++)
                {
                    if (Convert.ToInt32(TaskEditor.eLC.GetValue(TaskEditor.eLC.HomeItemsListIndex, k, 0)) == Id)
                    {
                        line += HOME_ITEM_ENTITY.GetProps(k);
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

        public static string DecodingCharacterComboId(string character_combo_id)
        {
            string line = "";
            if ((character_combo_id != "0" && character_combo_id != "255" && TaskEditor.eLC.Version < 52) || (character_combo_id != "0" && character_combo_id != "4095"))
            {
                line += "\n" + Extensions.GetLocalization(7017);
                uint charactercomboids;
                bool result_character_combo_id = uint.TryParse(character_combo_id, out charactercomboids);
                List<uint> powers_character_combo_id = new List<uint>(Extensions.GetPowers(charactercomboids));
                for (int p = 0; p < powers_character_combo_id.Count; p++)
                {
                    if (powers_character_combo_id[p] == 0) continue;

                    switch (p)
                    {
                        case 0:
                            line += " " + Extensions.GetLocalization(1120);//character_combo_id_1
                            break;
                        case 1:
                            line += " " + Extensions.GetLocalization(1121);//character_combo_id_2
                            break;
                        case 2:
                            line += " " + Extensions.GetLocalization(1122);//character_combo_id_4
                            break;
                        case 3:
                            line += " " + Extensions.GetLocalization(1123);//character_combo_id_8
                            break;
                        case 4:
                            line += " " + Extensions.GetLocalization(1124);//character_combo_id_16
                            break;
                        case 5:
                            line += " " + Extensions.GetLocalization(1125);//character_combo_id_32
                            break;
                        case 6:
                            line += " " + Extensions.GetLocalization(1126);//character_combo_id_64
                            break;
                        case 7:
                            line += " " + Extensions.GetLocalization(1127);//character_combo_id_128
                            break;
                        case 8:
                            line += " " + Extensions.GetLocalization(1128);//character_combo_id_256
                            break;
                        case 9:
                            line += " " + Extensions.GetLocalization(1129);//character_combo_id_512
                            break;
                        case 10:
                            line += " " + Extensions.GetLocalization(1130);//character_combo_id_1024
                            break;
                        case 11:
                            line += " " + Extensions.GetLocalization(1131);//character_combo_id_2048
                            break;
                    }
                }
            }
            return line;
        }

        public static string DecodingFoodMask(string food_mask)
        {
            string line = "";
            if (food_mask != "0")
            {
                line += "\n" + Extensions.GetLocalization(7050);
                uint foodmasks;
                bool result_food_mask = uint.TryParse(food_mask, out foodmasks);
                List<uint> powers_food_mask = new List<uint>(Extensions.GetPowers(foodmasks));
                for (int p = 0; p < powers_food_mask.Count; p++)
                {
                    if (powers_food_mask[p] == 0) continue;

                    switch (p)
                    {
                        case 0:
                            line += " " + Extensions.GetLocalization(3050);//food_mask_1
                            break;
                        case 1:
                            line += " " + Extensions.GetLocalization(3051);//food_mask_2
                            break;
                        case 2:
                            line += " " + Extensions.GetLocalization(3052);//food_mask_4
                            break;
                        case 3:
                            line += " " + Extensions.GetLocalization(3053);//food_mask_8
                            break;
                        case 4:
                            line += " " + Extensions.GetLocalization(3054);//food_mask_16
                            break;
                    }
                }
            }
            return line;
        }

        public static string ItemPropsSecondsToString(uint time)
        {
            string result = "";
            uint time1 = time;
            uint days = time / 86400;
            time = time - (days * 86400);
            uint hours = time / 3600;
            time = time - (hours * 3600);
            uint minutes = time / 60;
            uint seconds = time - (minutes * 60);
            if (time1 == 60) seconds = 60;
            if (time1 == 3600) minutes = 60;
            if (time1 == 86400) hours = 60;
            if (time1 <= 60) result = seconds.ToString() + Extensions.GetLocalization(7091);
            if (time1 > 60 && time1 <= 3600) result = minutes.ToString() + Extensions.GetLocalization(7092) + " " + seconds.ToString() + Extensions.GetLocalization(7091);
            if (time1 > 3600 && time1 <= 86400) result = hours.ToString() + Extensions.GetLocalization(7093) + " " + minutes.ToString() + Extensions.GetLocalization(7092);
            if (time1 > 86400) result = days.ToString() + Extensions.GetLocalization(7094) + " " + hours.ToString() + Extensions.GetLocalization(7093);
            return result;
        }

        public static string ItemPropsSecondsToString2(uint time)
        {
            string result = "";
            uint time1 = time;
            uint days = time / 86400;
            time = time - (days * 86400);
            uint hours = time / 3600;
            time = time - (hours * 3600);
            uint minutes = time / 60;
            uint seconds = time - (minutes * 60);
            if (time1 == 60) seconds = 60;
            if (time1 == 3600) minutes = 60;
            if (time1 == 86400) hours = 60;
            if (time1 <= 60) result = seconds.ToString() + Extensions.GetLocalization(7114);
            if (time1 > 60 && time1 <= 3600) result = minutes.ToString() + Extensions.GetLocalization(7115) + " " + seconds.ToString() + Extensions.GetLocalization(7114);
            if (time1 > 3600 && time1 <= 86400) result = hours.ToString() + Extensions.GetLocalization(7116) + " " + minutes.ToString() + Extensions.GetLocalization(7115);
            if (time1 > 86400) result = days.ToString() + Extensions.GetLocalization(7117) + " " + hours.ToString() + Extensions.GetLocalization(7116);
            return result;
        }

        public static IEnumerable<uint> GetPowers(uint value)
        {
            uint v = value;
            while (v > 0)
            {
                yield return (v & 0x01);
                v >>= 1;
            }
        }
	}
}
