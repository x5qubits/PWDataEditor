using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.PW_Admin_classes
{
    [Serializable]
    public class Demon
    {
        public String name = "";
        public int status = 0;//1 online 0 offline
        public string realName;
        public int startCount;
    }
}
