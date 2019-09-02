using ElementEditor.helper_classes;
using PWDataEditorPaied.helper_classes;

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
        public int elat = -1;

        public SaleItem(SaleItem SaleItem)
        {
            itemId = SaleItem.itemId;
            rowId = SaleItem.rowId;
            saleTab = SaleItem.saleTab;
            itemInfo = SaleItem.itemInfo;
            recipe = SaleItem.recipe;
            upgradable = SaleItem.upgradable;
            elat = SaleItem.elat;
        }
        public SaleItem()
        {
        }
    }
}
