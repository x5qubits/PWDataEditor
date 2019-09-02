using DomainEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.DomainEditors_Classes
{
    public class DOMAIN2
    {
        public int magic;
        public int domain2_data_timestamp;
        public List<DOMAIN2_INFO> domains = new List<DOMAIN2_INFO>();
        public List<BATTLETIME> battletime = new List<BATTLETIME>();
        public int battletime_max;
    }
}
