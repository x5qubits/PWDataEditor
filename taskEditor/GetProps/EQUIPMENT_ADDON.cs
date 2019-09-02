
using ElementEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace sTASKedit
{
    class EQUIPMENT_ADDON
    {

        public static string GetAddon(string id)
        {
            string str = "";
            try
            {
                //  for (int index = 0; index < GlobalProgramData.eLC.Lists[0].elementValues.Length; ++index)
                //   {
                string name = "";
                string elParamValue1 = "0";
                string elParamValue2 = "0";
                string elParamValue3 = "0";
                string elParamValue4 = "0";
                //for (int k = 0; k < TaskEditor.eLC.Lists[0].elementValues.Count; k++)
                //{
                int key = int.Parse(id);
                if (!TaskEditor.eLC.addonIndex.ContainsKey(key))
                {
                    return "";
                }
                int k = TaskEditor.eLC.addonIndex[key];
                if (TaskEditor.eLC.GetValue(0, k, 0) == id)
                {
                    for (int t = 0; t < TaskEditor.eLC.Lists[0].elementFields.Length; t++)
                    {
                        if (TaskEditor.eLC.Lists[0].elementFields[t] == "Name")
                        {
                            name = TaskEditor.eLC.GetValue(0, k, t);
                            break;
                        }
                    }
                    for (int t = 0; t < TaskEditor.eLC.Lists[0].elementFields.Length; t++)
                    {
                        if (TaskEditor.eLC.Lists[0].elementFields[t] == "num_params")
                        {
                            elParamValue1 = TaskEditor.eLC.GetValue(0, k, t);
                            break;
                        }
                    }
                    for (int t = 0; t < TaskEditor.eLC.Lists[0].elementFields.Length; t++)
                    {
                        if (TaskEditor.eLC.Lists[0].elementFields[t] == "param1")
                        {
                            elParamValue2 = TaskEditor.eLC.GetValue(0, k, t);
                            elParamValue3 = TaskEditor.eLC.GetValue(0, k, t + 1);
                            elParamValue4 = TaskEditor.eLC.GetValue(0, k, t + 2);
                            break;
                        }
                    }
                    try
                        {
                            int num = Convert.ToInt32(ElementsEditor.database.addonslist[id].ToString());
                            switch (num)
                            {
                                case 0:
                                    str = Extensions.GetLocalization(7202, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 1:
                                    str = Extensions.GetLocalization(7203, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 2:
                                    str = Extensions.GetLocalization(7202, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 3:
                                    str = Extensions.GetLocalization(7204, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 4:
                                    str = Extensions.GetLocalization(7205, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 5:
                                    str = Extensions.GetLocalization(7204, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 6:
                                    str = Extensions.GetLocalization(7206, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7202, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 7:
                                    str = Extensions.GetLocalization(7202, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7206, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 8:
                                    str = Extensions.GetLocalization(7204, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7207, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 9:
                                    str = string.Format(Extensions.GetLocalization(7214, false), (object)("-" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("F2", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"))));
                                    goto label_281;
                                case 10:
                                    str = Extensions.GetLocalization(7213, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("F2", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"));
                                    goto label_281;
                                case 11:
                                    str = Extensions.GetLocalization(7215, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 12:
                                    str = Extensions.GetLocalization(7206, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 13:
                                    str = Extensions.GetLocalization(7237, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 14:
                                    str = Extensions.GetLocalization(7207, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 15:
                                    str = Extensions.GetLocalization(7208, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 16:
                                    str = Extensions.GetLocalization(7208, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 17:
                                    str = Extensions.GetLocalization(7209, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 18:
                                    str = Extensions.GetLocalization(7209, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 19:
                                    str = Extensions.GetLocalization(7210, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 20:
                                    str = Extensions.GetLocalization(7210, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 21:
                                    str = Extensions.GetLocalization(7211, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 22:
                                    str = Extensions.GetLocalization(7211, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 23:
                                    str = Extensions.GetLocalization(7212, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 24:
                                    str = Extensions.GetLocalization(7212, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 25:
                                    str = Extensions.GetLocalization(7208, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7211, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                    goto label_281;
                                case 26:
                                    str = Extensions.GetLocalization(7209, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7208, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                    goto label_281;
                                case 27:
                                    str = Extensions.GetLocalization(7210, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7212, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                    goto label_281;
                                case 28:
                                    str = Extensions.GetLocalization(7211, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7210, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                    goto label_281;
                                case 29:
                                    str = Extensions.GetLocalization(7212, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7209, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                    goto label_281;
                                case 30:
                                    str = Extensions.GetLocalization(7208, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7211, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 31:
                                    str = Extensions.GetLocalization(7209, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7208, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 32:
                                    str = Extensions.GetLocalization(7210, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7212, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 33:
                                    str = Extensions.GetLocalization(7211, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7210, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 34:
                                    str = Extensions.GetLocalization(7212, false) + " +" + elParamValue2 + "\n" + Extensions.GetLocalization(7209, false) + " -" + elParamValue3;
                                    goto label_281;
                                case 35:
                                    str = Extensions.GetLocalization(7217, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 36:
                                    str = Extensions.GetLocalization(7218, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 37:
                                    str = Extensions.GetLocalization(7219, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 38:
                                    str = Extensions.GetLocalization(7220, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 39:
                                    str = Extensions.GetLocalization(7221, false) + " +" + (object)(Convert.ToInt32(elParamValue2) / 2);
                                    goto label_281;
                                case 40:
                                    str = Extensions.GetLocalization(7222, false) + " +" + (object)(Convert.ToInt32(elParamValue2) / 2);
                                    goto label_281;
                                case 41:
                                    str = Extensions.GetLocalization(7223, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 42:
                                    str = Extensions.GetLocalization(7224, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 43:
                                    str = Extensions.GetLocalization(7225, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 44:
                                    str = Extensions.GetLocalization(7226, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 45:
                                    str = Extensions.GetLocalization(7229, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 46:
                                    str = Extensions.GetLocalization(7227, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 47:
                                    str = Extensions.GetLocalization(7227, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 48:
                                    str = string.Format(Extensions.GetLocalization(7230, false), (object)("+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("F2", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"))));
                                    goto label_281;
                                case 49:
                                    str = Extensions.GetLocalization(7231, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 50:
                                    str = Extensions.GetLocalization(7228, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 51:
                                    str = Extensions.GetLocalization(7228, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 52:
                                    str = Extensions.GetLocalization(7232, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 53:
                                    str = Extensions.GetLocalization(7232, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 54:
                                    str = Extensions.GetLocalization(7233, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 55:
                                    str = Extensions.SkillDesc(Convert.ToInt32(elParamValue2));
                                    goto label_281;
                                case 56:
                                    str = Extensions.GetLocalization(7235, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 57:
                                    str = Extensions.GetLocalization(7236, false);
                                    goto label_281;
                                case 58:
                                    str = Extensions.GetLocalization(7216, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 59:
                                    str = Extensions.GetLocalization(7239, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 60:
                                    str = Extensions.GetLocalization(7240, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 61:
                                    str = Extensions.GetLocalization(7238, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 62:
                                    str = Extensions.GetLocalization(7241, false);
                                    goto label_281;
                                case 63:
                                    str = Extensions.GetLocalization(7242, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 64:
                                    str = Extensions.GetLocalization(7243, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 65:
                                    str = Extensions.GetLocalization(7244, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 66:
                                    str = Extensions.GetLocalization(7245, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 67:
                                    str = Extensions.GetLocalization(7246, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 68:
                                    str = Extensions.GetLocalization(7247, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 69:
                                    str = Extensions.GetLocalization(7234, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 70:
                                    str = Extensions.GetLocalization(7239, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 71:
                                    str = Extensions.GetLocalization(7240, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 72:
                                    str = Extensions.GetLocalization(7229, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 73:
                                    str = Extensions.GetLocalization(7217, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 74:
                                    str = Extensions.GetLocalization(7218, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 75:
                                    str = Extensions.GetLocalization(7227, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 76:
                                    str = Extensions.GetLocalization(7206, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 77:
                                    str = Extensions.GetLocalization(7207, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 78:
                                    str = Extensions.GetLocalization(7233, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 79:
                                    str = Extensions.GetLocalization(7234, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 80:
                                    str = Extensions.GetLocalization(7215, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 81:
                                    str = Extensions.GetLocalization(7213, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("F2", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"));
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("F2", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"));
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 82:
                                    str = Extensions.GetLocalization(7222, false) + " +" + (object)(Convert.ToInt32(elParamValue2) / 2);
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + (object)(Convert.ToInt32(elParamValue3) / 2);
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 83:
                                    str = Extensions.GetLocalization(7237, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 84:
                                    str = Extensions.GetLocalization(7238, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue3)), 0).ToString("P0");
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 85:
                                    str = Extensions.GetLocalization(7221, false) + " +" + (object)(Convert.ToInt32(elParamValue2) / 2);
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + (object)(Convert.ToInt32(elParamValue3) / 2);
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 86:
                                    str = Extensions.GetLocalization(7228, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 87:
                                    str = Extensions.GetLocalization(7203, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 88:
                                    str = Extensions.GetLocalization(7205, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 89:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 90:
                                    str = Extensions.GetLocalization(7248, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 91:
                                    str = Extensions.GetLocalization(7249, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 92:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 93:
                                    str = Extensions.GetLocalization(7217, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 94:
                                    str = Extensions.GetLocalization(7217, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 95:
                                    str = Extensions.GetLocalization(7223, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 96:
                                    str = Extensions.GetLocalization(7224, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 97:
                                    str = Extensions.GetLocalization(7225, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 98:
                                    str = Extensions.GetLocalization(7226, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 99:
                                    str = Extensions.GetLocalization(7218, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 100:
                                    str = Extensions.GetLocalization(7202, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 101:
                                    str = Extensions.GetLocalization(7203, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 102:
                                    str = Extensions.GetLocalization(7204, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 103:
                                    str = Extensions.GetLocalization(7205, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 104:
                                    str = Extensions.GetLocalization(7206, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 105:
                                    str = Extensions.GetLocalization(7217, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 106:
                                    str = Extensions.GetLocalization(7223, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 107:
                                    str = Extensions.GetLocalization(7224, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 108:
                                    str = Extensions.GetLocalization(7225, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 109:
                                    str = Extensions.GetLocalization(7227, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 110:
                                    str = Extensions.GetLocalization(7229, false) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 111:
                                    str = Extensions.GetLocalization(7239, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 112:
                                    str = Extensions.GetLocalization(7240, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 113:
                                    str = Extensions.GetLocalization(7215, false) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("P0");
                                    goto label_281;
                                case 114:
                                    str = Extensions.GetLocalization(7207, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 115:
                                    str = string.Format(Extensions.GetLocalization(7250, false), (object)("+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("F1", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"))));
                                    goto label_281;
                                case 116:
                                    str = string.Format(Extensions.GetLocalization(7254, false), (object)("+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(elParamValue2)), 0).ToString("F1", (IFormatProvider)CultureInfo.CreateSpecificCulture("en-US"))));
                                    goto label_281;
                                case 150:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 151:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 152:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 153:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 154:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 155:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 156:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 160:
                                    str = Extensions.GetLocalization(7251, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 161:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 162:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 163:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 164:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 165:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 166:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 167:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 168:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 169:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 170:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 171:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 172:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 173:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 174:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 175:
                                    str = Extensions.GetLocalization(7252, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 176:
                                    str = Extensions.GetLocalization(7253, false) + " +" + elParamValue2;
                                    goto label_281;
                                case 177:
                                    str = Extensions.GetLocalization(7206, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 178:
                                    str = Extensions.GetLocalization(7207, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 179:
                                    str = Extensions.GetLocalization(7251, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 180:
                                    str = Extensions.GetLocalization(7252, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 181:
                                    str = Extensions.GetLocalization(7253, false) + " +" + elParamValue2;
                                    if (Convert.ToInt32(elParamValue1) > 1)
                                    {
                                        if (elParamValue2 != elParamValue3)
                                        {
                                            str = str + "~" + elParamValue3;
                                            goto label_281;
                                        }
                                        else
                                            goto label_281;
                                    }
                                    else
                                        goto label_281;
                                case 200:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 201:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 202:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 203:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 204:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 205:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 206:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 207:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 208:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 209:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 210:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 211:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                case 212:
                                    str = Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                                    goto label_281;
                                default:
                                    return Extensions.GetLocalization(7200, false) + " " + id + " " + Extensions.GetLocalization(7201, false) + " " + (object)num + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                            }
                        }
                        catch
                        {
                            str = Extensions.GetLocalization(7200, false) + " " + id + " " + elParamValue2 + "-" + elParamValue3 + "-" + elParamValue4;
                           // break;
                        }
                    //}
                }
            }
            catch
            {
                str = "";
            }
            label_281:
            return str;
        }

        /*

        public static string GetAddon(string id)
        {
            string line = "";
            try
            {
                string name = "";
                string num_params = "0";
                string param1 = "0";
                string param2 = "0";
                string param3 = "0";
                //for (int k = 0; k < TaskEditor.eLC.Lists[0].elementValues.Count; k++)
                //{
                int key = int.Parse(id);
                if (!TaskEditor.eLC.addonIndex.ContainsKey(key))
                {
                    return "";
                }
                int k = TaskEditor.eLC.addonIndex[key];
                    if (TaskEditor.eLC.GetValue(0, k, 0) == id)
                    {
                        for (int t = 0; t < TaskEditor.eLC.Lists[0].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[0].elementFields[t] == "Name")
                            {
                                name = TaskEditor.eLC.GetValue(0, k, t);
                                break;
                            }
                        }
                        for (int t = 0; t < TaskEditor.eLC.Lists[0].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[0].elementFields[t] == "num_params")
                            {
                                num_params = TaskEditor.eLC.GetValue(0, k, t);
                                break;
                            }
                        }
                        for (int t = 0; t < TaskEditor.eLC.Lists[0].elementFields.Length; t++)
                        {
                            if (TaskEditor.eLC.Lists[0].elementFields[t] == "param1")
                            {
                                param1 = TaskEditor.eLC.GetValue(0, k, t);
                                param2 = TaskEditor.eLC.GetValue(0, k, t + 1);
                                param3 = TaskEditor.eLC.GetValue(0, k, t + 2);
                                break;
                            }
                        }
                        try
                        {
                            int addon_type = Convert.ToInt32(ElementsEditor.database.addonslist[id].ToString());
                            switch (addon_type)
                            {
                                case 0:
                                    line = Extensions.GetLocalization(7202) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 1:
                                    line = Extensions.GetLocalization(7203) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 2:
                                    line = Extensions.GetLocalization(7202) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 3:
                                    line = Extensions.GetLocalization(7204) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 4:
                                    line = Extensions.GetLocalization(7205) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 5:
                                    line = Extensions.GetLocalization(7204) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 6:
                                    line = Extensions.GetLocalization(7206) + " +" + param1 + "\n" + Extensions.GetLocalization(7202) + " -" + param2;
                                    break;
                                case 7:
                                    line = Extensions.GetLocalization(7202) + " +" + param1 + "\n" + Extensions.GetLocalization(7206) + " -" + param2;
                                    break;
                                case 8:
                                    line = Extensions.GetLocalization(7204) + " +" + param1 + "\n" + Extensions.GetLocalization(7207) + " -" + param2;;
                                    break;
                                case 9:
                                    line = String.Format(Extensions.GetLocalization(7214), "-" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 10:
                                    line = Extensions.GetLocalization(7213) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                                    break;
                                case 11:
                                    line = Extensions.GetLocalization(7215) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 12:
                                    line = Extensions.GetLocalization(7206) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 13:
                                    line = Extensions.GetLocalization(7237) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 14:
                                    line = Extensions.GetLocalization(7207) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 15:
                                    line = Extensions.GetLocalization(7208) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 16:
                                    line = Extensions.GetLocalization(7208) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 17:
                                    line = Extensions.GetLocalization(7209) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 18:
                                    line = Extensions.GetLocalization(7209) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 19:
                                    line = Extensions.GetLocalization(7210) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 20:
                                    line = Extensions.GetLocalization(7210) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 21:
                                    line = Extensions.GetLocalization(7211) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 22:
                                    line = Extensions.GetLocalization(7211) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 23:
                                    line = Extensions.GetLocalization(7212) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 24:
                                    line = Extensions.GetLocalization(7212) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 25:
                                    line = Extensions.GetLocalization(7208) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7211) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 26:
                                    line = Extensions.GetLocalization(7209) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7208) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 27:
                                    line = Extensions.GetLocalization(7210) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7212) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 28:
                                    line = Extensions.GetLocalization(7211) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7210) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 29:
                                    line = Extensions.GetLocalization(7212) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0") + "\n" + Extensions.GetLocalization(7209) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 30:
                                    line = Extensions.GetLocalization(7208) + " +" + param1 + "\n" + Extensions.GetLocalization(7211) + " -" + param2;
                                    break;
                                case 31:
                                    line = Extensions.GetLocalization(7209) + " +" + param1 + "\n" + Extensions.GetLocalization(7208) + " -" + param2;
                                    break;
                                case 32:
                                    line = Extensions.GetLocalization(7210) + " +" + param1 + "\n" + Extensions.GetLocalization(7212) + " -" + param2;
                                    break;
                                case 33:
                                    line = Extensions.GetLocalization(7211) + " +" + param1 + "\n" + Extensions.GetLocalization(7210) + " -" + param2;
                                    break;
                                case 34:
                                    line = Extensions.GetLocalization(7212) + " +" + param1 + "\n" + Extensions.GetLocalization(7209) + " -" + param2;
                                    break;
                                case 35:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 36:
                                    line = Extensions.GetLocalization(7218) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 37:
                                    line = Extensions.GetLocalization(7219) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 38:
                                    line = Extensions.GetLocalization(7220) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 39:
                                    line = Extensions.GetLocalization(7221) + " +" + Convert.ToInt32(param1) / 2;
                                    break;
                                case 40:
                                    line = Extensions.GetLocalization(7222) + " +" + Convert.ToInt32(param1) / 2;
                                    break;
                                case 41:
                                    line = Extensions.GetLocalization(7223) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 42:
                                    line = Extensions.GetLocalization(7224) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 43:
                                    line = Extensions.GetLocalization(7225) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 44:
                                    line = Extensions.GetLocalization(7226) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 45:
                                    line = Extensions.GetLocalization(7229) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 46:
                                    line = Extensions.GetLocalization(7227) + " +" + param1;
                                    break;
                                case 47:
                                    line = Extensions.GetLocalization(7227) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 48:
                                    line = String.Format(Extensions.GetLocalization(7230), "+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 49:
                                    line = Extensions.GetLocalization(7231) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 50:
                                    line = Extensions.GetLocalization(7228) + " +" + param1;
                                    break;
                                case 51:
                                    line = Extensions.GetLocalization(7228) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");//param1%~param2%
                                    break;
                                case 52:
                                    line = Extensions.GetLocalization(7232) + " +" + param1;
                                    break;
                                case 53:
                                    line = Extensions.GetLocalization(7232) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 54:
                                    line = Extensions.GetLocalization(7233) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 55:
                                    line = Extensions.SkillDesc(Convert.ToInt32(param1));
                                    break;
                                case 56:
                                    line = Extensions.GetLocalization(7235) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 57:
                                    line = Extensions.GetLocalization(7236);
                                    break;
                                case 58:
                                    line = Extensions.GetLocalization(7216) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 59:
                                    line = Extensions.GetLocalization(7239) + " +" + param1;
                                    break;
                                case 60:
                                    line = Extensions.GetLocalization(7240) + " +" + param1;
                                    break;
                                case 61:
                                    line = Extensions.GetLocalization(7238) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 62:
                                    line = Extensions.GetLocalization(7241);
                                    break;
                                case 63:
                                    line = Extensions.GetLocalization(7242) + " +" + param1;
                                    break;
                                case 64:
                                    line = Extensions.GetLocalization(7243) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 65:
                                    line = Extensions.GetLocalization(7244) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 66:
                                    line = Extensions.GetLocalization(7245) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 67:
                                    line = Extensions.GetLocalization(7246) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 68:
                                    line = Extensions.GetLocalization(7247) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 69:
                                    line = Extensions.GetLocalization(7234) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 70:
                                    line = Extensions.GetLocalization(7239) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 71:
                                    line = Extensions.GetLocalization(7240) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 72:
                                    line = Extensions.GetLocalization(7229) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 73:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 74:
                                    line = Extensions.GetLocalization(7218) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 75:
                                    line = Extensions.GetLocalization(7227) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 76:
                                    line = Extensions.GetLocalization(7206) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 77:
                                    line = Extensions.GetLocalization(7207) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 78:
                                    line = Extensions.GetLocalization(7233) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 79:
                                    line = Extensions.GetLocalization(7234) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 80:
                                    line = Extensions.GetLocalization(7215) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 81:
                                    line = Extensions.GetLocalization(7213) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("F2", CultureInfo.CreateSpecificCulture("en-US"));
                                    break;
                                case 82:
                                    line = Extensions.GetLocalization(7222) + " +" + Convert.ToInt32(param1) / 2;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + Convert.ToInt32(param2) / 2;
                                    break;
                                case 83:
                                    line = Extensions.GetLocalization(7237) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 84:
                                    line = Extensions.GetLocalization(7238) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param2)), 0).ToString("P0");
                                    break;
                                case 85:
                                    line = Extensions.GetLocalization(7221) + " +" + Convert.ToInt32(param1) / 2;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + Convert.ToInt32(param2) / 2;
                                    break;
                                case 86:
                                    line = Extensions.GetLocalization(7228) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 87:
                                    line = Extensions.GetLocalization(7203) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 88:
                                    line = Extensions.GetLocalization(7205) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 89:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 90:
                                    line = Extensions.GetLocalization(7248) + " +" + param1;
                                    break;
                                case 91:
                                    line = Extensions.GetLocalization(7249) + " +" + param1;
                                    break;
                                case 92:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    //if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 93:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    break;
                                case 94:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 95:
                                    line = Extensions.GetLocalization(7223) + " +" + param1;
                                    break;
                                case 96:
                                    line = Extensions.GetLocalization(7224) + " +" + param1;
                                    break;
                                case 97:
                                    line = Extensions.GetLocalization(7225) + " +" + param1;
                                    break;
                                case 98:
                                    line = Extensions.GetLocalization(7226) + " +" + param1;
                                    break;
                                case 99:
                                    line = Extensions.GetLocalization(7218) + " +" + param1;
                                    break;
                                case 100:
                                    line = Extensions.GetLocalization(7202) + " +" + param1;
                                    break;
                                case 101:
                                    line = Extensions.GetLocalization(7203) + " +" + param1;
                                    break;
                                case 102:
                                    line = Extensions.GetLocalization(7204) + " +" + param1;
                                    break;
                                case 103:
                                    line = Extensions.GetLocalization(7205) + " +" + param1;
                                    break;
                                case 104:
                                    line = Extensions.GetLocalization(7206) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 105:
                                    line = Extensions.GetLocalization(7217) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 106:
                                    line = Extensions.GetLocalization(7223) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 107:
                                    line = Extensions.GetLocalization(7224) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 108:
                                    line = Extensions.GetLocalization(7225) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 109:
                                    line = Extensions.GetLocalization(7227) + " +" + param1;
                                    if (Convert.ToInt32(num_params) > 1 && param1 != param2) line += "~" + param2;
                                    break;
                                case 110:
                                    line = Extensions.GetLocalization(7229) + " +" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 111:
                                    line = Extensions.GetLocalization(7239) + " +" + param1;
                                    break;
                                case 112:
                                    line = Extensions.GetLocalization(7240) + " +" + param1;
                                    break;
                                case 113:
                                    line = Extensions.GetLocalization(7215) + " -" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("P0");
                                    break;
                                case 114:
                                    line = Extensions.GetLocalization(7207) + " +" + param1;
                                    break;
                                case 115:
                                    line = String.Format(Extensions.GetLocalization(7050), "+" + BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToInt32(param1)), 0).ToString("F1", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                //case 120-146: Engrave
                                case 150:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 151:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 152:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 153:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 154:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 155:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 156:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 160:
                                    line = Extensions.GetLocalization(7251) + " +" + param1;
                                    break;
                                case 161:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 162:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 163:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 164:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 165:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 166:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 167:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 168:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 169:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 170:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 171:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 172:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 173:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 174:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 175:
                                    line = Extensions.GetLocalization(7252) + " +" + param1;
                                    break;
                                case 176:
                                    line = Extensions.GetLocalization(7253) + " +" + param1;
                                    break;
                                case 200:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 201:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 202:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 203:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 204:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 205:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 206:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 207:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 208:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 209:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 210:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 211:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                case 212:
                                    line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    break;
                                default:
                                    {
                                        return line = Extensions.GetLocalization(7200) + " " + id + " " + Extensions.GetLocalization(7201) + " " + addon_type + " " + param1 + "-" + param2 + "-" + param3;
                                    }
                            }
                        }
                        catch
                        {
                            line = Extensions.GetLocalization(7200) + " " + id + " " + param1 + "-" + param2 + "-" + param3;
                        }
                    }
                
            }
            catch
            {
                line = "";
            }
            return line;
        } */
    }

}

