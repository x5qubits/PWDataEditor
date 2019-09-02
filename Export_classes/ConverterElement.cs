using System;

namespace ElementEditor.classes
{
    [Serializable]
    public class RowIndexesExport
    {
        public int LIST { get; internal set; }
        public REPLACEOPERATION OPERATION { get; internal set; }
        public int ROWID { get; internal set; }
        public string VALUE { get; internal set; }
    }
}