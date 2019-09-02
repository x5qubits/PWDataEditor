using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElementEditor.Element_Editor_Classes
{
    [Serializable]
    public class ItemDupe
    {
        public int listID = 0;
        public int index = 0;
        public int itemId = 0;
        public string name = "";
        public string iconpath = "";
        public int count = 0;
        public string price = "";
        public int maxCount = 1;
        public int petId = 0;
    }
}
