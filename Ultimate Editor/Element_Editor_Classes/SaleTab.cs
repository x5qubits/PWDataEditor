using ElementEditor.helper_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.Element_Editor_Classes
{
    public class SaleTab
    {
        public String title = "";
        public int List = 0;
        public int Item = 0;
        public int elId = 0;     
        public SortedDictionary<int, SaleItem> items = new SortedDictionary<int,SaleItem>();
    }
}
