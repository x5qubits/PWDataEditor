using Newtonsoft.Json;
using PWDataEditorPaied;
using PWDataEditorPaied.PW_Admin_classes;
using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using Shield.classes.oops.ntsshark;
using Shield.classes.oops.util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shield.classes.oops.iNotif
{
    public class HeartBeat : INotification
    {
        public static int x = 50;
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string,object> response = (Dictionary < string,object>)data.value;
            if (response.ContainsKey("result"))
            {
                int result = Int32.Parse(response["result"].ToString());
                switch(result)
                {
                    case 0:
                        if (!Constants.Authed && data.type == 3)
                        {
                            BaseSocketPacket packet = new BaseSocketPacket();
                            HashMap<string, object> sd = new HashMap<string, object>();
                            sd["buildId"] = Constants.build;
                            sd["yek"] = Constants.ke;
                            sd["usr"] = ProfileView.profile.userName;
                            sd["pwd"] = ProfileView.profile.passWord;
                            sd["key"] = ProfileView.profile.keyString;
                            packet.module = Module.USER;
                            packet.cmd = Cmd.AUTH;
                            packet.value = sd;
                            ProfileView.instance().progress_bar("Connected !", 0, 0);
                            if (Iobserver.instance() != null) { Iobserver.instance().send(packet); }
                        }
                        
                        if (data.type == 2 && response.ContainsKey("data") && Constants.Authed)
                        {
                            Dictionary<string, object> sysInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(response["data"].ToString());
                            foreach (KeyValuePair<string, object> datax in sysInfo)
                            {
                                String[] demonData = JsonConvert.DeserializeObject<String[]>(datax.Value.ToString());
                                MessageClass msgc = new MessageClass();
                                int key = Int32.Parse(datax.Key);
                                msgc.to = demonData[0];
                                msgc.channel = demonData[2];
                                msgc.from = demonData[1];

                                msgc.message = demonData[3];
                                msgc.time = demonData[4];
                                PWAdmin.getInstance().add_chat_line(key, msgc);
                            }
                        }
                        
                        break;
                    case 100:
                        // INVALID_STRUCTURE_HWKEY
                        ProfileView.instance().progress_bar("Invalid password!", 0, 0);
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    case 101:
                        // INVALID_BUILD
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                    case 102:
                        // INVALID_BUILD
                        ProfileView.instance().progress_bar("Not enough privileges!", 0, 0);
                        Constants.canRecoonect = false;
                        if (Iobserver.instance() != null) { Iobserver.instance().close(); }
                        break;
                }
            }
        }
    }
}
