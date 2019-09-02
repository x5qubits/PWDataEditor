

using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using Shield.classes.oops;
using System.Collections.Generic;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class PWAMAP : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                int result = int.Parse(response["result"].ToString());
                if (result == 0)
                {
                    PWDataEditorPaied.PWAdmin.getInstance().unlockMaps("Operation was a success, acquiring new data!", false);
                    BaseSocketPacket packet = new BaseSocketPacket();
                    HashMap<string, object> sd = new HashMap<string, object>();
                    packet.module = Module.PWADMIN;
                    packet.cmd = Cmd.STATUS;
                    sd["maps"] = PWDataEditorPaied.PWAdmin.server_cache.GetMapsString();
                    packet.value = sd;
                    if (Iobserver.instance() != null) { Iobserver.instance().send(packet); }
                }
                else
                {
                    PWDataEditorPaied.PWAdmin.getInstance().unlockMaps("Operation was a failed, program now ready!");
                }
            }
        }
    }
}
