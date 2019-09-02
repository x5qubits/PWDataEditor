using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEditors
{
    public class DOMAIN_INFO
    {
        public byte[] name = new byte[32];
        public int id = 0;
        public DOMAIN_TYPE type = 0;
        public int reward = 0;
        public int[] iconpos = new int[2];
        public List<DomainPoint> pointcountArray = new List<DomainPoint>();
        public List<DomainTriangle> triangle = new List<DomainTriangle>();
        public int[] neighbour = new int[0];

    }
}
