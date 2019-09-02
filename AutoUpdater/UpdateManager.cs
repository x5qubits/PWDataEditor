using ElementEditor;
using System;
using JHUI;
using JHUI.Utils;
using PWDataEditorPaied.Properties;

namespace NSUpdateManager
{
    /// <summary>
    /// provides information if an update is available and where to get it
    /// </summary>
    public sealed class UpdateManager
    {
        static public UpdateManager instance = new UpdateManager();
        private string updateUrl = "http://licence.jhsoftware.pro/PWTOOL/version";
        private UpdateManager()
        {

        }
        public bool isNewUpdate()
        {  
            string server_version = getServerVersion();
            if (server_version != null)
            {
                var version1 = new Version(server_version);
                var version2 = Program.productVersion;
                if (version1 != version2)
                {
                    return true;
                }
            }
            return false;
        }

        static public string server_verion = null;
        private float timeChecked = 0;
        public string getServerVersion()
        {
            if (timeChecked > Time.time)
                return server_verion;

            string returning = null;
            using (var webClient = new System.Net.WebClient())
            {
                returning = webClient.DownloadString(updateUrl);
                server_verion = returning;
                timeChecked = Time.time + 1000;
            }
            return returning;
        }
    }
}
