using Newtonsoft.Json;
using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class PWAdmin_UpdateGameEvents : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                int result = int.Parse(response["result"].ToString());
                if (result == 0)
                {
                    PWAdmin.getInstance().drawEventTab(response);
                }
            }
        }
    }
}
