using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.PW_Admin_classes
{
    [Serializable]
    public class Map
    {
        public Boolean autoStart = false;
        public String name = "";
        public int status = 0;//1 online 0 offline
        internal string realName;
    }
}
