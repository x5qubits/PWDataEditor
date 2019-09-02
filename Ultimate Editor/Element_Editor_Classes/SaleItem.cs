using ElementEditor.helper_classes;
using PWDataEditorPaied.helper_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.Element_Editor_Classes
{
    public class SaleItem
    {
        public int itemId = 0;
        public int rowId = 0;
        public SaleTab saleTab = null;
        public InfoTool itemInfo = null;
        public Recipe recipe = null;
        public bool upgradable = false;
    }
}
