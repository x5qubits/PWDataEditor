using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ElementEditor.classes
{
    [Serializable]
    public class Export
    {
        public int ListId = 0;
        public int itemID = 0;
        public int Version = 0;
        public int type = 0;
        public SortedDictionary<int, object> data = null;
        public SortedDictionary<int, object> data2 = null;
        public int RowCount = 0;

        public Export() { }

        public Export(string path)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            Export importObject = binFormat.Deserialize(new MemoryStream(File.ReadAllBytes(path))) as Export;
            ListId = importObject.ListId;
            itemID = importObject.itemID;
            Version = importObject.Version;
            type = importObject.type;
            RowCount = importObject.RowCount;
            data = importObject.data;
        }
    }
}
