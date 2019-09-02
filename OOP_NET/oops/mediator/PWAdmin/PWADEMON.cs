using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class PWADEMON : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            int result = Int32.Parse(response["result"].ToString());
            if (result == 0)
            {
                PWAdmin.getInstance().unlockdemons("Operation was a success, acquiring new data!", false);
                BaseSocketPacket packet = new BaseSocketPacket();
                HashMap<string, object> sd = new HashMap<string, object>();
                packet.module = Module.PWADMIN;
                packet.cmd = Cmd.STATUS;
                sd["maps"] = PWAdmin.server_cache.GetMapsString();
                packet.value = sd;
                if (Iobserver.instance() != null) { Iobserver.instance().send(packet); }
            }
            else
            {
                PWAdmin.getInstance().unlockdemons("Operation was a failed, program now ready!");
            }

        }
    }
}
