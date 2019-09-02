using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Classes
{
    [Serializable]
    public class Licence
    {
        public string LicenceName { get; set; }
        public string HardwereName { get; set; }
        public string HardwereHash { get; set; }
        public int OpenTimes { get; set; }
        public int MaxTimes { get; set; } = 3;
        public int[] Products { get; set; }
        public long RecheckTime { get; set; }
        public int Type { get; set; } = 0;
        public string Msg { get; set; }
    }
}
