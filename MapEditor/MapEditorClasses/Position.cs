using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MapEditor.MapEditorClasses
{
    public class Position
    {
        public float a;
        public float b;
        public float c;
        public void ar(BinaryReader br)
        {
            a = br.ReadSingle();
            b = br.ReadSingle();
            c = br.ReadSingle();
        }
    }
}
