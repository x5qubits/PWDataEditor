using System;
using System.Collections.Generic;
using System.Text;

namespace ElementEditor.classes
{
    [Serializable]
    public class Export
    {
        public int ListId = 0;
        public int itemID = 0;
        public int ForVersion = 0;
        public int type = 0;
        public SortedDictionary<int, object> data = null;
    }
}
