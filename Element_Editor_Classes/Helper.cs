using ElementEditor.classes.helper;
using sTASKedit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElementEditor.classes
{
    [Serializable]
    public class Helper
    {

        public static SortedList<int, List_RealList> list_supdype = new SortedList<int, List_RealList>()
        {
            //suptype_LIST_ID, LIST_WHERE IT WILL BE USED, type;

            //Weapons
             {1,  new List_RealList{useonList=3, type=Constatns.typeMajorType}},
             {2,  new List_RealList{useonList=3, type=Constatns.typeSubType}},
             //Gear
             {4,  new List_RealList{useonList=6, type=Constatns.typeMajorType}},
             {5,  new List_RealList{useonList=6, type=Constatns.typeSubType}},
             //ACC
             {7,  new List_RealList{useonList=9, type=Constatns.typeMajorType}},
             {8,  new List_RealList{useonList=9, type=Constatns.typeSubType}},
             //Remedies
             {10,  new List_RealList{useonList=12, type=Constatns.typeMajorType}},
             {11,  new List_RealList{useonList=12, type=Constatns.typeSubType}},
             //Materials
             {13,  new List_RealList{useonList=15, type=Constatns.typeMajorType}},
             {14,  new List_RealList{useonList=15, type=Constatns.typeSubType}},

             //ATK Heiro
             {16,  new List_RealList{useonList=17, type=Constatns.typeSubType}},
             {18,  new List_RealList{useonList=19, type=Constatns.typeSubType}},
             {20,  new List_RealList{useonList=21, type=Constatns.typeSubType}},
             {30,  new List_RealList{useonList=31, type=Constatns.typeSubType}},


             {32,  new List_RealList{useonList=33, type=Constatns.typeSubType}},
             {34,  new List_RealList{useonList=35, type=Constatns.typeSubType}},
             {67,  new List_RealList{useonList=69, type=Constatns.typeMajorType}},
             {68,  new List_RealList{useonList=69, type=Constatns.typeSubType}},

             {81,  new List_RealList{useonList=83, type=Constatns.typeMajorType}},
             {82,  new List_RealList{useonList=83, type=Constatns.typeSubType}},

             {87,  new List_RealList{useonList=89, type=Constatns.typeMajorType}},
             {88,  new List_RealList{useonList=89, type=Constatns.typeSubType}},
             {183,  new List_RealList{useonList=184, type=Constatns.typeSubType}},
             {138,  new List_RealList{useonList=139, type=Constatns.typeSubType}},

             {142,  new List_RealList{useonList=144, type=Constatns.typeMajorType}},
             {143,  new List_RealList{useonList=144, type=Constatns.typeSubType}},

             {224,  new List_RealList{useonList=217, type=Constatns.typeMajorType}},   //Formula       
             {225,  new List_RealList{useonList=217, type=Constatns.typeSubType}},
             {226,  new List_RealList{useonList=218, type=Constatns.typeMajorType}},
             {227,  new List_RealList{useonList=218, type=Constatns.typeSubType}},//Formula

             {221,  new List_RealList{useonList=223, type=Constatns.typeMajorType}},
             {222,  new List_RealList{useonList=223, type=Constatns.typeSubType}},//Formula

        };
        public static SortedList<int, SubTypeElement> subtypesInfolist = null;

        public static SortedList<int, string> classMasksID = new SortedList<int, string>()
        {
             {1, "BladeMaster"},
             {2, "Wizard"},
             {4, "Psychic"},
             {8, "Venomarcer"},
             {16, "Barbarian"},
             {32, "Assasin"},
             {64, "Archer"},
             {128, "Cleric"},
             {256, "Seeker"},
             {512, "Mystic"},
             {1024, "DustbBade"},
             {2048, "StormBringer"},
             {4095, "All"}
         };

        public static SortedList<string, int> classMasksName = new SortedList<string, int>()
        {
             {"BladeMaster", 1},
             {"Wizard", 2},
             {"Psychic", 4},
             {"Venomarcer", 8},
             {"Barbarian", 16},
             {"Assasin", 32},
             {"Archer", 64},
             {"Cleric", 128},
             {"Seeker", 256},
             {"Mystic", 512},
             {"DustbBade", 1024},
             {"StormBringer", 2048},
             {"All", 4095}
         };
        public static string getProtectTypeDesc(int id)
        {
            List<uint> powers = new List<uint>(Extensions.GetPowers((uint)id));
            string line = null;
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
                    case 13:
                        line += Extensions.GetLocalization(3013);//proc_type_8192
                        break;
                    case 6:
                        line += "\n" + Extensions.GetLocalization(3006);//proc_type_64
                        break;
                    case 15:
                        line += "\n" + Extensions.GetLocalization(3015);//proc_type_32768
                        break;
                }
            }
            return line;
        }
        public static DataGridViewComboBoxCell getProtectComboBox(int id)
        {

            return null;
        }
        public static string getClassByMaskID(int id)
        {
            String returnMask = "";

            if(4095 == id)
            {
                return "All.";
            }

            int number = id;
            if (number / 2048 > 0)
            {
                number = number % 2048;
                returnMask += "StormBringer,";
            }

            if (number / 1024 > 0)
            {
                number = number % 1024;
                returnMask += "Dustblade,";
            }

            if (number / 512 > 0)
            {
                number = number % 512;
                returnMask += "Mystic,";
            }
            if (number / 256 > 0)
            {
                number = number % 256;
                returnMask += "Seeker,";
            }
            if (number / 128 > 0)
            {
                number = number % 128;
                returnMask += "Cleric,";
            }
            if (number / 64 > 0)
            {
                number = number % 64;
                returnMask += "Archer,";
            }
            if (number / 32 > 0)
            {
                number = number % 32;
                returnMask += "Assassin,";
            }
            if (number / 16 > 0)
            {
                number = number % 16;
                returnMask += "Barbarian,";
            }
            if (number / 8 > 0)
            {
                number = number % 8;
                returnMask += "Venomarcer,";
            }
            if (number / 4 > 0)
            {
                number = number % 4;
                returnMask += "Psychic,";
            }
            if (number / 2 > 0)
            {
                number = number % 2;
                returnMask += "Wizard,";
            }
            if (number / 1 > 0)
            {
                number = number % 1;
                returnMask += "BladeMaster,";
            }

            if (returnMask.Length > 0)
            {
                return returnMask.Remove(returnMask.Length - 1);
            }
            else
            {
                return returnMask;
            }
        }


        public static string getType(int list, int id, int type)
        {

            if(Helper.subtypesInfolist.ContainsKey(list))
            {
                if(type == Constatns.typeSubType)
                {
                    if(Helper.subtypesInfolist[list].subtype.ContainsKey(id))
                    {
                        return Helper.subtypesInfolist[list].subtype[id];
                    }
                }
                if (type == Constatns.typeMajorType)
                {
                    if (Helper.subtypesInfolist[list].majorType.ContainsKey(id))
                    {
                        return Helper.subtypesInfolist[list].majorType[id];
                    }
                }

            }
            return "";
        }

        public static void getComboboxType(ComboBox cbc, int list, int id, int type)
        {
            //cbc.Value = cbc.Items[0];
            int count = 0;
            int selected = -0;
            if (Helper.subtypesInfolist.ContainsKey(list))
            {
                if (type == Constatns.typeMajorType)
                {
                    foreach (KeyValuePair<int, string> entry in Helper.subtypesInfolist[list].majorType)
                    {
                        cbc.Items.Add(entry.Value.Replace('_',' ') + "_" + entry.Key);
                        if (id == entry.Key) { selected = count; }
                        count++;
                    }
                }
                if (type == Constatns.typeSubType)
                {
                    foreach (KeyValuePair<int, string> entry in Helper.subtypesInfolist[list].subtype)
                    {
                        cbc.Items.Add(entry.Value.Replace('_', ' ') + "_" + entry.Key);
                        if (id == entry.Key) { selected = count; }
                        count++;
                    }
                }
            }
            try { if (selected != -1) { cbc.SelectedIndex = selected; } } catch (Exception) { }
        }

        public static DataGridViewComboBoxCell getComboboxType(int list, int id, int type)
        {
            DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
            //cbc.Value = cbc.Items[0];
            int count = 0;
            int selected = -0;
            if (Helper.subtypesInfolist.ContainsKey(list))
            {
                if (type == Constatns.typeMajorType)
                {
                    foreach (KeyValuePair<int, string> entry in Helper.subtypesInfolist[list].majorType)
                    {
                        cbc.Items.Add(entry.Value.Replace('_', ' ') + "_" + entry.Key);
                        if (id == entry.Key) { selected = count; }
                        count++;
                    }
                }
                if (type == Constatns.typeSubType)
                {
                    foreach (KeyValuePair<int, string> entry in Helper.subtypesInfolist[list].subtype)
                    {
                        cbc.Items.Add(entry.Value.Replace('_', ' ') + "_" + entry.Key);
                        if (id == entry.Key) { selected = count; }
                        count++;
                    }
                }
            }
            try { if (selected != -1) { cbc.Value = cbc.Items[selected]; } } catch (Exception) { }
            return cbc;
        }


        public static Color getByID(int id)
        {
            switch(id)
            {
                case 0:
                    return Color.White;
                case 1:
                    return Color.LightBlue;
                case 2:
                    return Color.LightYellow;
                case 3:
                    return Color.MediumPurple;
                case 4:
                    return Color.Gold;
                case 5:
                    return Color.White;
                case 6:
                    return Color.Gray;
                case 7:
                    return Color.LightGreen;
            }
            return Color.Black;
        }

        public static string recalculateElement(string type, string operation, string oldValue, string newValue, bool isIgnore)
        {
            if (type == "int16")
            {
                short op1 = 0;
                short op2 = 0;
                bool try1 = Int16.TryParse(newValue, out op1);
                bool try2 = Int16.TryParse(oldValue, out op2);
                if(!try1)
                {
                    MessageBox.Show("Invalid old value!");
                    return "";
                }
                if (!try2)
                {
                    MessageBox.Show("Invalid new value!");
                    return "";
                }
                String result = "";
                if (operation == "*")
                {
                    if (op1 == 0 && op2 == 0)
                        return "0";
                    result = (op1 * op2).ToString();
                }
                if (operation == "/")
                {
                    if (op1 == 0 || op2 == 0)
                        return "0";
                    if (op1 > op2 || isIgnore)
                        result = (op1 / op2).ToString();
                    else
                        result = (op2 / op1).ToString();
                }
                if (operation == "+")
                {
                    result = (op1 + op2).ToString();
                }
                if (operation == "-")
                {
                    if(op1 > op2 || isIgnore)
                        result = (op1 - op2).ToString();
                    else
                        result = (op2 - op1).ToString();
                }
                if (operation == "=")
                {
                    result = newValue;
                }
                return result;
            }
            if (type == "int32")
            {
                int op1 = 0;
                int op2 = 0;
                bool try1 = Int32.TryParse(newValue, out op1);
                bool try2 = Int32.TryParse(oldValue, out op2);
                if (!try1)
                {
                    MessageBox.Show("Invalid old value!");
                    return "";
                }
                if (!try2)
                {
                    MessageBox.Show("Invalid new value!");
                    return "";
                }
                String result = "";
                if (operation == "*")
                {
                    if (op1 == 0 && op2 == 0)
                        return "0";
                    result = (op1 * op2).ToString();
                }
                if (operation == "/")
                {
                    if (op1 == 0 || op2 == 0)
                        return "0";

                    if (op1 > op2 || isIgnore)
                        result = (op1 / op2).ToString();
                    else
                        result = (op2 / op1).ToString();
                }
                if (operation == "+")
                {
                    result = (op1 + op2).ToString();
                }
                if (operation == "-")
                {
                    if (op1 > op2 || isIgnore)
                        result = (op1 - op2).ToString();
                    else
                        result = (op2 - op1).ToString();
                }
                if (operation == "=")
                {
                    result = newValue;
                }
                return result;
            }
            if (type == "int64")
            {
                long op1 = 0;
                long op2 = 0;
                bool try1 = Int64.TryParse(newValue, out op1);
                bool try2 = Int64.TryParse(oldValue, out op2);
                if (!try1)
                {
                    MessageBox.Show("Invalid old value!");
                    return "";
                }
                if (!try2)
                {
                    MessageBox.Show("Invalid new value!");
                    return "";
                }
                String result = "";
                if (operation == "*")
                {
                    if (op1 == 0 && op2 == 0)
                        return "0";

                    result = (op1 * op2).ToString();
                }
                if (operation == "/")
                {
                    if (op1 == 0 || op2 == 0)
                        return "0";

                    if (op1 > op2 || isIgnore)
                        result = (op1 / op2).ToString();
                    else
                        result = (op2 / op1).ToString();
                }
                if (operation == "+")
                {
                    result = (op1 + op2).ToString();
                }
                if (operation == "-")
                {
                    if (op1 > op2 || isIgnore)
                        result = (op1 - op2).ToString();
                    else
                        result = (op2 - op1).ToString();
                }
                if (operation == "=")
                {
                    result = newValue;
                }
                return result;
            }
            if (type == "float")
            {
                float op1 = 0;
                float op2 = 0;
                bool try1 = Single.TryParse(newValue, out op1);
                bool try2 = Single.TryParse(oldValue, out op2);
                if (!try1)
                {
                    MessageBox.Show("Invalid old value!");
                    return "";
                }
                if (!try2)
                {
                    MessageBox.Show("Invalid new value!");
                    return "";
                }
                String result = "";
                if (operation == "*")
                {
                    if (op1 == 0 && op2 == 0)
                        return "0";

                    result = (op1 * op2).ToString("F3");
                }
                if (operation == "/")
                {
                    if (op1 == 0 || op2 == 0)
                        return "0";

                    if (op1 > op2 || isIgnore)
                        result = (op1 / op2).ToString("F3");
                    else
                        result = (op2 / op1).ToString("F3");
                }
                if (operation == "+")
                {
                    result = (op1 + op2).ToString("F3");
                }
                if (operation == "-")
                {
                    if (op1 > op2 || isIgnore)
                        result = (op1 - op2).ToString("F3");
                    else
                        result = (op2 - op1).ToString("F3");
                }
                if (operation == "=")
                {
                    result = newValue;
                }
                return result;
            }
            if (type == "double")
            {
                double op1 = 0;
                double op2 = 0;
                bool try1 = Double.TryParse(newValue, out op1);
                bool try2 = Double.TryParse(oldValue, out op2);
                if (!try1)
                {
                    MessageBox.Show("Invalid old value!");
                    return "";
                }
                if (!try2)
                {
                    MessageBox.Show("Invalid new value!");
                    return "";
                }
                string result = "";
                if (operation == "*")
                {
                    if (op1 == 0 && op2 == 0)
                        return "0";

                    result = (op1 * op2).ToString("F3");
                }
                if (operation == "/")
                {
                    if (op1 == 0 || op2 == 0)
                        return "0";

                    if (op1 > op2 || isIgnore)
                        result = (op1 / op2).ToString("F3");
                    else
                        result = (op2 / op1).ToString("F3");
                }
                if (operation == "+")
                {
                    result = (op1 + op2).ToString("F3");
                }
                if (operation == "-")
                {
                    if (op1 > op2 || isIgnore)
                        result = (op1 - op2).ToString("F3");
                    else
                        result = (op2 - op1).ToString("F3");
                }
                if (operation == "=")
                {
                    result = newValue;
                }
                return result;
            }
            if (operation == "=")
            {
                return newValue;
            }
            return "";
        }

    }
}
