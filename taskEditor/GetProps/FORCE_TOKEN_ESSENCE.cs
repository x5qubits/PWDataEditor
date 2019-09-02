
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class FORCE_TOKEN_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                for (int k = 0; k < TaskEditor.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[151].elementFields[k] == "require_force")
                    {
                        string id_sub_type = TaskEditor.eLC.GetValue(151, pos_item, k);
                        for (int t = 0; t < TaskEditor.eLC.Lists[150].elementValues.Count; t++)
                        {
                            if (TaskEditor.eLC.GetValue(150, t, 0) == id_sub_type)
                            {
                                for (int a = 0; a < TaskEditor.eLC.Lists[150].elementFields.Length; a++)
                                {
                                    if (TaskEditor.eLC.Lists[150].elementFields[a] == "Name")
                                    {
                                        line += "\n" + String.Format(Extensions.GetLocalization(7095), TaskEditor.eLC.GetValue(150, t, a));
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[151].elementFields[k] == "reputation_add")
                    {
                        string reputation_add = TaskEditor.eLC.GetValue(151, pos_item, k);
                        line += "\n" + String.Format(Extensions.GetLocalization(7096), reputation_add, reputation_add);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[151].elementFields[k] == "reputation_increase_ratio")
                    {
                        line += "\n" + String.Format(Extensions.GetLocalization(7097), TaskEditor.eLC.GetValue(151, pos_item, k));
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[151].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[151].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(151, pos_item, k);
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

