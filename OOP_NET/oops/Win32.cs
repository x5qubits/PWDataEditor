using Microsoft.Win32;
using Shield.classes.oops.ntsshark;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharkShield.classes.oops
{
    public static class Win32
    {

        public static String getOnline(bool save = false)
        {
            String val = "";
            if (save)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WIN32VALUES2");
                if (key != null)
                {
                    val = key.GetValue("online").ToString();
                    key.Close();
                }
            }
            else
            {
                if (val.Length < 10)
                {
                    val = Iu.Value();
                    if (save)
                    {
                        Win32.setOnline(val);
                    }
                }
            }
            return val;
        }

        public static void setOnline(String val)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WIN32VALUES2");
            if(key != null)
            {
                //Set
            }else
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WIN32VALUES2");
                if(key != null)
                {
                     key.SetValue("online", val);
                }
            }
            try { key.Close(); } catch (Exception) { }
        }

    }
}
