using System;
using System.Collections.Generic;
using System.Text;

namespace ElementEditor.Game_Shop_classes
{
    [Serializable]
    public class Boutique
    {
        public uint timestamp = 0;
        public uint item_count = 0;
        public Dictionary<int, Item> items = new Dictionary<int, Item>();
        public Category[] categories = new Category[8]; // [8]


        public Item getItemByIndex(int shopID)
        {
            if(items.ContainsKey(shopID))
            {
                return items[shopID];
            }
            return null;
        }

        public Item getItemByShopId(int shopID)
        {
            foreach (KeyValuePair<int, Item> entry in items)
            {
                if(entry.Value.shop_id == shopID)
                {
                    return entry.Value;
                }
            }
            return null;
        }

    }
}
