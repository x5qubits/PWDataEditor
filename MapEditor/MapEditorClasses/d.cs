using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MapEditor.MapEditorClasses
{
    public class d
    {
        public int r;
        public int s;
        public int t;
        public void ar(BinaryReader br)
        {
            r = br.ReadInt32();
            s = br.ReadInt32();
            t = br.ReadInt32();
        }
    }
}
