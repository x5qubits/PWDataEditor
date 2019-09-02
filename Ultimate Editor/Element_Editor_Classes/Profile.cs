using PWDataEditorPaied.helper_classes;
using PWDataEditorPaied.PW_Admin_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.Element_Editor_Classes
{
    [Serializable]
    public class Profile
    {
        public int id = 0;
        public string name = "";

        public bool rememberMe = false;

        public bool autoOpenEPath = false;
        public bool autoOpenTPath = false;
        public bool autoOpenGPath = false;
        public bool autoOpenNPath = false;
        public bool autoOpenAPath = false;
        public bool autoOpenPPath = false;

        public string EPath = "";
        public string TPath = "";
        public string GPath = "";
        public string NPath = "";
        public string APath = "";
        public string[] PPath = new string[0];

        public string serverIP = "";
        public string serverPort = "";
        public string userName = "";
        public string passWord = "";


        public string buff_str = "";
        public string item_color = "";
        public string item_ext_desc = "";
        public string skillstr = "";
        public string world_targets = "";
        public string iconlist_ivtrmdds = "";
        public string iconlist_ivtrmtxt = "";

        public int DDSFORMAT = 6;

        public SortedList<int, Map> defaultMapsTemplate = null;

        public bool autoStartMap = false;
        public bool keepDemonsAlive = false;
        public bool keepMapsOnline = false;
        public SortedList<int, string> gmDescription = new SortedList<int, string>();
        public String keyString = "";
        public List<BookMark> bookmarks = new List<BookMark>();
    }
}
