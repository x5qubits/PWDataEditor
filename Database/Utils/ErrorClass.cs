using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Database.Utils
{
    [Serializable]
    public class ErrorClass
    {
        public int listId;
        public int itemId;
        public int type;
        public string msg;
    }
}
