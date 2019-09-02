using System;
using System.Collections.Generic;
using System.Text;

namespace ElementEditor.classes
{
    public enum REPLACEOPERATION
    {
        SKIP_ROW,
        ADD_ROW,
        REPLACE,
        DELETE
    }

    [Serializable]
    public class ConvertElements
    {
        // List / Row Indexs
        public Dictionary<int, Dictionary<int, RowIndexesExport>> lists = new Dictionary<int, Dictionary<int, RowIndexesExport>>();
        /// <summary>
        /// // IF EXPORT COMES FROM VERSION
        /// </summary>
        public int versionFrom;
        /// <summary>
        /// IF CURRENT ELEMENTS IS VERSION
        /// </summary>
        public int versionTo;
    }
}
