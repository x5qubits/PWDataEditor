using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    [Serializable]
    public class CreatureSet
    {
        public int positionType = 0;
        public int creature_groups_count = 1;
        public float spawn_x = 0;
        public float spawn_alt = 0;
        public float spawn_z = 0;
        public float rot_1 = 0;
        public float rot_2 = 0;
        public float rot_3 = 0;
        public float spread_x = 0;
        public float spread_alt = 0;
        public float spread_z = 0;
        public int monstertype = 0;
        public int groupeType = 0;
        public bool unknown_9 = true;
        public bool unknown_10 = true;
        public bool unknown_11 = true;
        public int GenId = 0;
        public int trigger = 0;
        public int LifeTime = 0;
        public int MaxNum = 0;
        public SortedList<int, CreatureGroup> creature_groups = new SortedList<int, CreatureGroup>();
    }
}
