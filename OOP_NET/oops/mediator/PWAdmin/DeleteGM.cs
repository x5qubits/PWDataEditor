using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PWDataEditorPaied.PW_Admin_classes.IWEB;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class DeleteGM : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                int resp = int.Parse(response["result"].ToString());
                switch (resp)
                {
                    case 0:
                        Dictionary<string, GmAccount> gmeAccounts = new Dictionary<string, GmAccount>();
                        try
                        {
                            Dictionary<string, object> gmsacc = JsonConvert.DeserializeObject<Dictionary<string, object>>(response["gmsacc"].ToString());
                            foreach (KeyValuePair<string, object> datax in gmsacc)
                            {
                                Dictionary<string, object> gmInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(datax.Value.ToString());
                                GmAccount gm = new GmAccount();
                                if (gmInfo.ContainsKey("perms"))
                                {

                                    String[] perms = JsonConvert.DeserializeObject<String[]>(gmInfo["perms"].ToString());
                                    gm.permisions = perms.ToList<String>();

                                }
                                if (gmInfo.ContainsKey("info"))
                                {
                                    String[] info = JsonConvert.DeserializeObject<String[]>(gmInfo["info"].ToString());
                                    gm.id = info[0];
                                    gm.name = info[1];
                                }
                                gmeAccounts.Add(gm.id, gm);
                            }
                        }
                        catch
                        { }
                        PWAdmin.server_cache.gmeAccounts = gmeAccounts;
                        PWAdmin.getInstance().unlockGMPANEL();
                        PWAdmin.getInstance().updateGMScreeen();
                        break;
                    case 10000:
                        PWAdmin.getInstance().unlockGMPANEL();
                        MessageBox.Show("No such Account!");
                        break;
                    default:
                        PWAdmin.getInstance().unlockGMPANEL();
                        MessageBox.Show("Unknown server errror!");
                        break;
                }
            }
        }
    }
}
