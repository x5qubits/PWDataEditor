using Newtonsoft.Json;
using PWDataEditorPaied;
using PWDataEditorPaied.PW_Admin_classes;
using PWDataEditorPaied.PW_Admin_classes.IWEB;
using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shield.classes.oops.iNotif
{
    public class PWAdmin_med : INotification
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
                        PWAdmin.server_cache.reset();
                        Dictionary<string, object> game = new Dictionary<string, object>();
                        try
                        {
                            game = JsonConvert.DeserializeObject<Dictionary< string, object>> (response["game"].ToString());
                        }
                        catch { }

                        Dictionary<string, object> allMapsData = new Dictionary<string, object>();
                        if (game.ContainsKey("allMaps"))
                        {
                            allMapsData = JsonConvert.DeserializeObject<Dictionary<string, object>>(game["allMaps"].ToString());

                            foreach (KeyValuePair<string, object> datax in allMapsData)
                            {
                                int id = 0;
                                Int32.TryParse(datax.Value.ToString(), out id);
                                PWAdmin.server_cache.getMapByName(datax.Key).status = id;

                            }                         
                        }

                        Dictionary<string, object> demons_update = new Dictionary<string, object>();
                        if (game.ContainsKey("allDemons"))
                        {
                            demons_update = JsonConvert.DeserializeObject<Dictionary<string, object>>(game["allDemons"].ToString());
                        }

                        foreach (KeyValuePair<string, object> datax in demons_update)
                        {
                            try
                            {
                                String[] demonData = JsonConvert.DeserializeObject<String[]>(datax.ToString());
                                int idd = Int32.Parse(demonData[0]);
                                int status = Int32.Parse(demonData[1]);
                                PWAdmin.server_cache.updateDemonByID(idd, status);
                            }
                            catch { }
                        }


                        Dictionary<string, object> sysInfo = new Dictionary<string, object>();
                        if (response.ContainsKey("data"))
                        {
                            sysInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(response["data"].ToString());
                        }

                        foreach (KeyValuePair<string, object> datax in sysInfo)
                        {
                            try
                            {
                                switch (datax.Key)
                                {
                                    case "availableProcessors":
                                        PWAdmin.server_cache.numCores = datax.Value.ToString();
                                        break;
                                    case "getSystemCpuLoad":
                                        PWAdmin.server_cache.ghzused = datax.Value.ToString();
                                        break;
                                }
                            }
                            catch { }
                        }
                        if (game != null)
                        {
                            foreach (KeyValuePair<string, object> datax in game)
                            {
                                try
                                {
                                    switch (datax.Key)
                                    {
                                        case "map_online_count":
                                            PWAdmin.server_cache.map_online_count = datax.Value.ToString();
                                            break;
                                        case "totalAcc":
                                            PWAdmin.server_cache.totalAcc = datax.Value.ToString();
                                            break;
                                        case "totalOnline":
                                            PWAdmin.server_cache.onlineAcc = datax.Value.ToString();
                                            break;
                                        case "mem":
                                            String[] mem = JsonConvert.DeserializeObject<String[]>(datax.Value.ToString());
                                            PWAdmin.server_cache.ramfree = mem[3];
                                            PWAdmin.server_cache.ramtotal = mem[1];
                                            PWAdmin.server_cache.ramused = mem[2];
                                            break;
                                        case "swp":
                                            String[] swp = JsonConvert.DeserializeObject<String[]>(datax.Value.ToString());
                                            PWAdmin.server_cache.swpfree = swp[3];
                                            PWAdmin.server_cache.swptotal = swp[1];
                                            PWAdmin.server_cache.swpused = swp[2];
                                            break;
                                        case "CPUmhz":
                                            PWAdmin.server_cache.ghzmax = datax.Value.ToString();
                                            break;
                                    }
                                }
                                catch { }
                            }
                        }
                        BaseSocketPacket packet = new BaseSocketPacket();
                        HashMap<string, object> sd = new HashMap<string, object>();
                        packet.module = Module.PWADMIN;
                        packet.cmd = Cmd.ANALLMAPUPDATE;
                        sd["maps"] = "";
                        packet.value = sd;
                        if (Iobserver.instance() != null) { Iobserver.instance().send(packet); }

                        PWAdmin.getInstance().update_serverStatus();
                    break;
                }
            }

        }
    }
}
