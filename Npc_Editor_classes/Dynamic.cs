using System;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    [Serializable]
    public class Dynamic
    {
        public int id = 0;
        public float spawn_x = 0;
        public float spawn_y = 0;
        public float spawn_z = 0;
        public Byte dx = 0;
        public Byte dy = 0;
        public Byte dz = 0;
        public int trigger = 0;
        public Byte scale = 0;
    }
}
