using System;
using System.Collections.Generic;
using System.Text;

namespace ElementEditor.classes
{
    [Serializable]
    public class ConvertElements
    {
        // List / Row Indexs
        public Dictionary<int, Dictionary<int, RowIndexesExport>> lists = new Dictionary<int, Dictionary<int, RowIndexesExport>>();
        public int versionFrom;
        public int versionTo;
    }
}
