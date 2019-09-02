using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class ServerSends : INotification
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
                        ProfileView.instance().DologinDone();
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    default:
                        ProfileView.instance().DologinDone();
                        break;
                }
            }
        }
    }
}
