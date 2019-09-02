using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class DownResp : INotification
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
                            PWAdmin.getInstance().unlockShoutdown("Server will restart in #. Program is now Ready!", true);
                        break;
                    default:
                            PWAdmin.getInstance().unlockShoutdown("A Restart is already in progress... Program is now Ready!", false);
                        break;
                }
            }
        }
    }
}
