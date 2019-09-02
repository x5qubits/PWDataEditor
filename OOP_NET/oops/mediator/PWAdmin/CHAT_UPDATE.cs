using Newtonsoft.Json;
using PWDataEditorPaied.PW_Admin_classes;
using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class CHAT_UPDATE : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;


            if (response.ContainsKey("result"))
            {
                int result = Int32.Parse(response["result"].ToString());
                if(result == 0)
                {
                    if(response.ContainsKey("reset"))
                    {
                        PWAdmin.getInstance().reset_chat_line();
                    }
                    SortedList<int, object> sysInfo = JsonConvert.DeserializeObject<SortedList<int, object>>(response["data"].ToString());
                    foreach (KeyValuePair<int, object> datax in sysInfo)
                    {
                        try
                        {
                            String[] demonData = JsonConvert.DeserializeObject<String[]>(datax.Value.ToString());
                            MessageClass msgc = new MessageClass();
                            PWAdmin.chatKey = datax.Key;
                            msgc.to = demonData[0];
                            msgc.from = demonData[1];
                            msgc.channel = demonData[2];
                            msgc.message = demonData[3];
                            msgc.time = demonData[4];
                            PWAdmin.getInstance().add_chat_line(PWAdmin.chatKey, msgc);
                        }catch
                        {

                        }
                    }
                    PWAdmin.getInstance().reDrawChat();
                }

            }
        }
    }
}
