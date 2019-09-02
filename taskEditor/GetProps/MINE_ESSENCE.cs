
using ElementEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class MINE_ESSENCE
    {
        public static string GetProps(int pos)
        {
            if(pos == -1)
            {
                return "";
            }
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "level_required")
                    {
                        line += "\n" + Extensions.GetLocalization(7370) + " " + TaskEditor.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "id_equipment_required")
                    {
                        string id_equipment_required = TaskEditor.eLC.GetValue(79, pos, k);
                        bool Suc = false;
                        if (id_equipment_required != "0")
                        {
                            for (int i = 0; i < ElementsEditor.database.task_items_list.Length; i += 2)
                            {
                                if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                                {
                                    int l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
                                    for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                                    {
                                        if (TaskEditor.eLC.GetValue(l, t, 0) == id_equipment_required)
                                        {
                                            for (int a = 0; a < TaskEditor.eLC.Lists[l].elementFields.Length; a++)
                                            {
                                                if (TaskEditor.eLC.Lists[l].elementFields[a] == "Name")
                                                {
                                                    line += "\n" + String.Format(Extensions.GetLocalization(7371), TaskEditor.eLC.GetValue(l, t, a), id_equipment_required);
                                                    break;
                                                }
                                            }
                                            Suc = true;
                                            break;
                                        }
                                    }
                                    if (Suc == true) break;
                                }
                            }
                            for (int i = 0; i < TaskEditor.eLC.Lists[79].elementFields.Length; i++)
                            {
                                if (TaskEditor.eLC.Lists[79].elementFields[i] == "eliminate_tool")
                                {

                                    line += "\n" + Extensions.GetLocalization(7372) + " ";
                                    if (TaskEditor.eLC.GetValue(79, pos, i) == "0") line += Extensions.GetLocalization(2310);
                                    else line += Extensions.GetLocalization(2311);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "time_min")
                    {
                        string time_min = TaskEditor.eLC.GetValue(79, pos, k);
                        string time_max = TaskEditor.eLC.GetValue(79, pos, k + 1);
                        string time = time_min;
                        if (time_min != time_max) time += "~" + time_max;
                        line += "\n" + String.Format(Extensions.GetLocalization(7373), time);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "exp")
                    {
                        line += "\n" + Extensions.GetLocalization(7374) + " " + TaskEditor.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "skillpoint")
                    {
                        line += "\n" + Extensions.GetLocalization(7375) + " " + TaskEditor.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                bool tmp = false;
                for (int t = 1; t < 17; t++)
                {
                    for (int a = 0; a < TaskEditor.eLC.Lists[79].elementFields.Length; a++)
                    {
                        if (TaskEditor.eLC.Lists[79].elementFields[a] == "materials_" + t + "_id")
                        {
                            string id = TaskEditor.eLC.GetValue(79, pos, a);
                            if (id != "0") tmp = true;
                            break;
                        }
                    }
                }
                line += "\n" + Extensions.GetLocalization(7376) + " ";
                if (tmp == false) line += Extensions.GetLocalization(2310);
                else line += Extensions.GetLocalization(2311);
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "task_in")
                    {
                        string task_in = TaskEditor.eLC.GetValue(79, pos, k);
                        line += "\n" + Extensions.GetLocalization(7377) + " ";
                        if (task_in != "0") line += task_in;
                        else line += Extensions.GetLocalization(2310);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "permenent")
                    {

                        string permenent = TaskEditor.eLC.GetValue(79, pos, k);
                        line += "\n" + Extensions.GetLocalization(7378) + " ";
                        if (permenent == "0") line += Extensions.GetLocalization(2310);
                        else line += Extensions.GetLocalization(2311);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "max_gatherer")
                    {
                        line += "\n" + Extensions.GetLocalization(7379) + " " + TaskEditor.eLC.GetValue(79, pos, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[79].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[79].elementFields[k] == "gather_dist")
                    {
                        line += "\n" + Extensions.GetLocalization(7380) + " " + TaskEditor.eLC.GetValue(79, pos, k) + " м.";
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

