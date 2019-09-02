using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator.User
{
    public class SEARCH_PLAYERS_HANDLER : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                Dictionary<string, Dictionary<string, Object>> gmeAccounts = new Dictionary<string, Dictionary<string, Object>>();
                try
                {
                    Dictionary<string, Object> gmsacc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Object>>(response["data"].ToString());
                    foreach (KeyValuePair<string, Object> datax in gmsacc)
                    {
                        Dictionary<string, Object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Object>>(datax.Value.ToString());
                        gmeAccounts.Add(datax.Key, dic);

                    }
                }
                catch
                { }
                PWAdmin.getInstance().updateAccountManagment(gmeAccounts);

            }
        }
    }
}
