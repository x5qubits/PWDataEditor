using Newtonsoft.Json;
using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class AllMapsUpdate : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                int result = int.Parse(response["result"].ToString());
                if (result == 0)
                {
                    Dictionary<string, object> allMapsData = new Dictionary<string, object>();
                    if (response.ContainsKey("data"))
                    {
                        allMapsData = JsonConvert.DeserializeObject<Dictionary<string, object>>(response["data"].ToString());

                        foreach (KeyValuePair<string, object> datax in allMapsData)
                        {
                            int id = 0;
                            Int32.TryParse(datax.Value.ToString(), out id);
                            PWDataEditorPaied.PWAdmin.server_cache.getMapByName(datax.Key).status = id;
                        }
                        PWAdmin.getInstance().update_serverStatus();
                    }
                }
            }
        }
    }
}
