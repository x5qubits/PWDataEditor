
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class HOME_FORMULAS_ITEM_ESSENCE
    {
        public static string GetProps(int pos_item)
        {
            string line = "";
            try
            {
                string name = "";
                string max_produces = "-1";
                string require_produce_type = "0";
                string require_factory_type = "0";
                string require_factory_level = "0";
                string factoryname = "";
                string home_exp = "0";
                string resources_num_1 = "0";
                string resources_num_2 = "0";
                string resources_num_3 = "0";
                string resources_num_4 = "0";
                string price1 = "0";
                for (int k = 0; k < TaskEditor.eLC.Lists[218].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[218].elementFields[k] == "id_recipe")
                    {
                        string id_recipe = TaskEditor.eLC.GetValue(218, pos_item, k);
                        if (id_recipe != "0")
                        {
                            for (int t = 0; t < TaskEditor.eLC.Lists[217].elementValues.Count; t++)
                            {
                                if (TaskEditor.eLC.GetValue(217, t, 0) == id_recipe)
                                {
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "id_to_make")
                                        {
                                            string id_to_make = TaskEditor.eLC.GetValue(217, t, a);
                                            if (id_to_make != "0")
                                            {
                                                for (int i = 0; i < TaskEditor.eLC.Lists[223].elementValues.Count; i++)
                                                {
                                                    if (TaskEditor.eLC.GetValue(223, i, 0) == id_to_make)
                                                    {
                                                        for (int f = 0; f < TaskEditor.eLC.Lists[223].elementFields.Length; f++)
                                                        {
                                                            if (TaskEditor.eLC.Lists[223].elementFields[f] == "Name")
                                                            {
                                                                name = TaskEditor.eLC.GetValue(223, i, f);
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
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "require_produce_type")
                                        {
                                            require_produce_type = TaskEditor.eLC.GetValue(217, t, a);
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "require_factory_type")
                                        {
                                            require_factory_type = TaskEditor.eLC.GetValue(217, t, a);
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "require_factory_level")
                                        {
                                            require_factory_level = TaskEditor.eLC.GetValue(217, t, a);
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "home_exp")
                                        {
                                            home_exp = TaskEditor.eLC.GetValue(217, t, a);
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "resources_num_1")
                                        {
                                            resources_num_1 = TaskEditor.eLC.GetValue(217, t, a);
                                            resources_num_2 = TaskEditor.eLC.GetValue(217, t, a + 1);
                                            resources_num_3 = TaskEditor.eLC.GetValue(217, t, a + 2);
                                            resources_num_4 = TaskEditor.eLC.GetValue(217, t, a + 3);
                                            break;
                                        }
                                    }
                                    for (int a = 0; a < TaskEditor.eLC.Lists[217].elementFields.Length; a++)
                                    {
                                        if (TaskEditor.eLC.Lists[217].elementFields[a] == "price")
                                        {
                                            price1 = TaskEditor.eLC.GetValue(217, t, a);
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
                for (int k = 0; k < TaskEditor.eLC.Lists[218].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[218].elementFields[k] == "max_produces")
                    {
                        max_produces = TaskEditor.eLC.GetValue(218, pos_item, k);
                        break;
                    }
                }
                for (int k = 0; k < TaskEditor.eLC.Lists[218].elementFields.Length; k++)
                {
                    if (TaskEditor.eLC.Lists[218].elementFields[k] == "price")
                    {
                        string price = TaskEditor.eLC.GetValue(218, pos_item, k);
                        if (price != "0")
                        {
                            line += "\n" + Extensions.GetLocalization(7024) + " " + Convert.ToInt32(price).ToString("N0", CultureInfo.CreateSpecificCulture("zh-CN"));
                        }
                        break;
                    }
                }
                if (require_produce_type == "0")
                {
                    if (require_factory_type == "0") factoryname = Extensions.GetLocalization(3070);
                    if (require_factory_type == "1") factoryname = Extensions.GetLocalization(3071);
                    if (require_factory_type == "2") factoryname = Extensions.GetLocalization(3072);
                    if (require_factory_type == "3") factoryname = Extensions.GetLocalization(3073);
                    if (require_factory_type == "4") factoryname = Extensions.GetLocalization(3074);
                }
                if (require_produce_type == "1")
                {
                    factoryname = Extensions.GetLocalization(3075);
                }
                line += "\n\n" + Extensions.GetLocalization(7108) + name;
                if (Convert.ToInt32(max_produces) > 0)
                {
                    line += "\n" + String.Format(Extensions.GetLocalization(7109), max_produces);
                }
                line += "\n" + String.Format(Extensions.GetLocalization(7110), factoryname, require_factory_level, resources_num_1, resources_num_2, resources_num_3, resources_num_4, price1, home_exp);
            }
            catch
            {
                line = "";
            }
            return line;
        }
	}
}

