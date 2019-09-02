using System;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    [Serializable]
    public class ResourceSet
    {
        public float spawn_x = 0;
        public float spawn_alt = 0;
        public float spawn_z = 0;
        public float spread_x = 0;
        public float spread_z = 0;
        public int resource_groups_count = 1;
        public bool unknown_1 = true;
        public bool unknown_2 = true;
        public bool unknown_3 = true;
        public int unknown_4 = 0;
        public Byte unknown_5a = 0;
        public Byte unknown_5b = 0;
        public Byte unknown_5c = 0;
        public int unknown_trigger = 0;
        public Byte unknown_6 = 0;
        public bool unknown_7 = false;
        public bool unknown_8 = false;
        public bool unknown_9 = false;
        public Dictionary<int, ResourceGroup> resource_groups = new Dictionary<int, ResourceGroup>();
    }
}
