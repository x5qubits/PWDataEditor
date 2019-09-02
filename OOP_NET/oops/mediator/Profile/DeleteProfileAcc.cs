using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class DeleteProfileAcc : INotification
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
                        ProfileView.instance().unlockProfileView();
                        break;
                    default:
                        MessageBox.Show("No permission!");
                        ProfileView.instance().unlockProfileView();
                        break;
                }
            }
        }
    }
}
