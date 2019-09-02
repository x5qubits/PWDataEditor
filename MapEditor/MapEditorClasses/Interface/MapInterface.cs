using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MapEditor.MapEditorClasses.Interface
{
    public class MapInterface
    {
        public short a;
        public short b;
        public int c;
        public int d;
        public int e;
        public int f;
        public int g;
        public ArrayList h = new ArrayList();
        public ArrayList i = new ArrayList();
        public ArrayList j = new ArrayList();
        public ArrayList k = new ArrayList();
        public ArrayList l = new ArrayList();
        public ArrayList m = new ArrayList();
        public ArrayList n = new ArrayList();
        public ArrayList o = new ArrayList();
        public ArrayList p = new ArrayList();
        public ArrayList q = new ArrayList();
        public int v;
        public int u;
        public int r;
        public int s;
        public int t;

        public void read(BinaryReader br)
        {
            v = br.ReadInt32(); //f
            u = br.ReadInt32(); //E
            r = br.ReadInt32(); //d
            s = br.ReadInt32(); //d
            t = br.ReadInt32(); //d

            a = br.ReadInt16(); //C
            b = br.ReadInt16(); //C
            c = br.ReadInt32(); //C
            d = br.ReadInt32(); //C
            e = br.ReadInt32(); //C
            f = br.ReadInt32(); //C
            g = br.ReadInt32(); //C


        }
    }
}
