using PWDataEditorPaied;
using SharkShield.classes.oops;
using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using Shield.classes.oops.util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Shield.classes.oops.iNotif
{
    public class Auth : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
           

            if (response.ContainsKey("result"))
            {
                int result = Int32.Parse(response["result"].ToString());

                switch (result)
                {
                    case 0:
                        if (response.ContainsKey("id"))
                        {
                            if (result == 0 && !response.ContainsKey("perm"))
                            {
                                ProfileView.instance().progress_bar("Not enough privileges!", 0, 0);                              
                                MessageBox.Show("Not enough privileges!");
                                Constants.canRecoonect = false;
                                if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                                return;
                            }
                            int priv = Int32.Parse(response["perm"].ToString());
                            Constants.permission = priv;
                            if (Iobserver.instance() != null) { Iobserver.instance().registerCMDS(priv); }
                            Dictionary<string, Dictionary<string, Object>> gmeAccounts = new Dictionary<string, Dictionary<string, Object>>();
                            try
                            {
                                Dictionary<string, Object> gmsacc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Object>>(response["GMS"].ToString());
                                foreach (KeyValuePair<string, Object> datax in gmsacc)
                                {
                                    Dictionary<string, Object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Object>>(datax.Value.ToString());
                                    gmeAccounts.Add(datax.Key, dic);

                                }
                            }
                            catch
                            { }
                            ProfileView.gmeAccounts = gmeAccounts;


                            int playerID = Int32.Parse(response["id"].ToString());
                            Constants.Authed = true;
                            Constants.midb = writeInt(playerID);
                            ProfileView.instance().progress_bar("Connected !", 0, 0);
                            ProfileView.instance().loginDone();
                        }
                        break;
                    case 100:
                        // INVALID_STRUCTURE_HWKEY
                        ProfileView.instance().progress_bar("Invalid password!", 0, 0);
                        MessageBox.Show("Invalid password!");
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    case 101:
                        // INVALID_BUILD
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    case 102:
                        // INVALID_BUILD
                        ProfileView.instance().progress_bar("Invalid password!", 0, 0);
                        MessageBox.Show("Invalid password!");
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    case 103:
                        ProfileView.instance().progress_bar("Not enough privileges!", 0, 0);
                        MessageBox.Show("Not enough privileges!");
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    case 104:
                        ProfileView.instance().progress_bar("Already logged in!", 0, 0);
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        MessageBox.Show("Already logged in!");
                        break;
                }
            }
        }

        public static byte[] writeInt(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            return intBytes;
        }
    }

}
