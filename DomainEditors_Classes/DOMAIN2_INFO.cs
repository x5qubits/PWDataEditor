using DomainEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.DomainEditors_Classes
{
    public class DOMAIN2_INFO
    {
        public byte[] name = new byte[32];
        public int id = 0;
        public int point;
        public int wartype;
        public int country_id;
        public int is_capital;
        public List<MapPos> mappos = new List<MapPos>(); //4
        public int[] iconpos = new int[2]; // 2
        public List<DomainPoint> pointcountArray = new List<DomainPoint>();
        public List<DomainTriangle> triangle = new List<DomainTriangle>();
        public int[] neighbour = new int[0];
        public int[] time_neighbours = new int[0];

    }
}
