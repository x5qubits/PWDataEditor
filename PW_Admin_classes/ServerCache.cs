using ElementEditor;
using PWDataEditorPaied.PW_Admin_classes.IWEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.PW_Admin_classes
{
    [Serializable]
    public class ServerCache
    {
        public Dictionary<int, String> permissionsAdvanced = new Dictionary<int, String>()
        {
            { 0, "Player/Item/IP ID"},
            { 1, "Stelth/Invincible On"},
            { 2, "Online Status"},
            { 3, "Hide Wisper"},
            { 4, "Teleport to player"},
            { 5, "Teleport player to GM"},
            { 6, "Teleport by ctrl+clicking map"},
            { 11, "Show online Players Count"},
            { 100, "Ban player account/character"},
            { 101, "Mute player account/character"},
            { 102, "Ban trading for a player"},
            { 103, "Ban selling for a player"},
            { 104, "GM announcement broadcast"},
            { 105, "Restart gameserver"},
            { 200, "Create Monster"},
            { 201, "Delete Monster"},
            { 202, "Morph into Monster"},
            { 204, "GM Administrator"},
            { 205, "Set same-ip connection limit"},
            { 206, "Activate Monster Creator"},
            { 207, "Forbid trade for all players"},
            { 208, "Forbid auction for all players"},
            { 209, "Forbid ingame mail for all players"},
            { 210, "Forbid all Faction activity"},
            { 211, "Set double money drop"},
            { 212, "Set double item drop"},
            { 213, "Set double SP reward"},
            { 214, "Forbid point card selling"},
            { 500, "GM TAG/DO NOT REMOVE"},
            { 501, "Edit character data"},
            { 502, "Check status of server"},
            { 503, "Check logs"},
            { 504, "Forcefully reboot game server"},
            { 505, "Forcefully reboot database server"},
            { 506, "Find ID of char name"},
            { 507, "Character data view"},
            { 508, "Character online status"},
            { 509, "Send mail with item to user"},
            { 510, "See ban history"},
            { 511, "See cubigold payments"},
            { 512, "See cubigold amount"},
            { 513, "Add cubigold"},
            { 514, "View by Account username"},
            { 515, "Edit account username"},
            { 516, "Remove ban"},
            { 517, "Get Role list"},
            { 518, "Change Account password"}
        };

        public Dictionary<int, String> permissionsbasic = new Dictionary<int, String>()
        {
            { 0, "Player/Item/IP ID"},
            { 1, "Stelth/Invincible On"},
            { 2, "Online Status"},
            { 3, "Hide Wisper"},
            { 4, "Teleport to player"},
            { 5, "Teleport player to GM"},
            { 6, "Teleport by ctrl+clicking map"},
            { 11, "Show online Players Count"},
            { 100, "Ban player account/character"},
            { 101, "Mute player account/character"},
            { 102, "Ban trading for a player"},
            { 103, "Ban selling for a player"},
            { 104, "GM announcement broadcast"},
            { 105, "Restart gameserver"},
            { 200, "Create Monster"},
            { 206, "Activate Monster Creator"},
            { 500, "GM TAG/DO NOT REMOVE"},
        };


        public string numCores = "";
        public string ghzmax = "";
        public string ghzused = "";

        public string ramtotal = "";
        public string ramfree = "";
        public string ramused = "";

        public string totalAcc = "";
        public string onlineAcc = "";
        public Dictionary<string, GmAccount> gmeAccounts = new Dictionary<string, GmAccount>();
        public SortedList<int, Demon> demons = new SortedList<int, Demon>();
        public SortedList<int, Map> maps = new SortedList<int, Map>();
        public string swpfree = "";
        public string swptotal = "";
        public string swpused = "";
        internal string map_online_count = "0";

        internal void updateDemonByID(int demonID, int status)
        {
            if (PWAdmin.server_cache.demons.ContainsKey(demonID))
            {
                PWAdmin.server_cache.demons[demonID].status = status;
            }
        }

        internal String[] GetMapsString()
        {
            List<string> retu = new List<string>();
            foreach(KeyValuePair<int, Map> data in PWAdmin.server_cache.maps)
            {
                retu.Add(data.Value.realName);
            }
            return retu.ToArray();
        }
        internal Map getMapByName(String name)
        {
            foreach (KeyValuePair<int, Map> data in PWAdmin.server_cache.maps)
            {
                if(data.Value.realName == name)
                {
                    return PWAdmin.server_cache.maps[data.Key];
                }
            }
            return null;
        }

        internal void reset()
        {
            SortedList<int, Map> copy = null;
            if (ProfileView.profile == null || ProfileView.profile.defaultMapsTemplate == null)
            {
                copy = ElementsEditor.database.defaultMapsTemplate;
            }
            else
            {
                if (ProfileView.profile.defaultMapsTemplate != null)
                {
                    copy = ProfileView.profile.defaultMapsTemplate;
                }
                else
                {
                    copy = ElementsEditor.database.defaultMapsTemplate;
                }
            }

            PWAdmin.server_cache.maps = copy;
            if (ElementsEditor.database.defaultDemonsTemplate != null)
            {
                SortedList<int, Demon> demonsc = ElementsEditor.database.defaultDemonsTemplate;
                PWAdmin.server_cache.demons = demonsc;
            }
        }
    }
}
