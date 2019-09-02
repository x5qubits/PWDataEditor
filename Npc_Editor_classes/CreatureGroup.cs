using System;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    [Serializable]
    public class CreatureGroup
    {
        public int id = 1;
        public int amount = 0;
        public int respawn = 0;
        public int diedTimes = 0;
        public int aggressive = 0;
        public int faction = 0;
        public int unknown_5 = 0;
        public int unknown_6 = 0;
        public int unknown_7 = 0;
        public int unknown_8 = 0;
        public bool defFaction = true;
        public bool defFacHelp = true;
        public bool defFacAccept = true;
        public bool needHelp = true;
        public int unknown_13 = 0;
        public int pathID = 0;
        public int loopType = 0;
        public int sppedFlag = 0;
        public int delayTime = 0;
    }
}
