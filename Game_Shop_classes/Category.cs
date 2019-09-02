using PWDataEditorPaied.Game_Shop_classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementEditor.Game_Shop_classes
{
    [Serializable]
    public class Category
    {
        public NameChar name; // 128 Byte Unicode
        public uint sub_cats_count;
        public Dictionary<int, NameChar> sub_cats; // Array [max 8] of 128 Byte Unicode
    }
}
