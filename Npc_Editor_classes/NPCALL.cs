using System;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    [Serializable]
    public class NPCALL
    {
        public int version;
        public int creature_sets_count;
        public int resource_sets_count;
        public int dynamics_count;
        public int triggers_count;
        public SortedList<int, CreatureSet> creature_sets;
        public SortedList<int, ResourceSet> resource_sets;
        public SortedList<int, Dynamic> dynamics;
        public SortedList<int, Trigger> triggers;
    }
}
