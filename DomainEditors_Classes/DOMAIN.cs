using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEditors
{
    public class DOMAIN
    {
        public int version;
        public List<DOMAIN_INFO> domains = new List<DOMAIN_INFO>();
        public List<BATTLETIME> battletime = new List<BATTLETIME>();
        public int battletime_max;
        public int[] batles = new int[2];
    }
}
