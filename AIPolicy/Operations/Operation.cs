using AIPolicy;
using PWDataEditorPaied.AIPolicy.Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AIPolicy.Operations
{
    [Serializable]
    public class Operation
    {
        public static List<string> AllText = new List<string>();
        public List<object> Parameters;

        [XmlIgnore]
        public Trigger Parent { get; set; }

        public int Type { get; set; }

        [XmlIgnore]
        public Target Tg { get; set; }

        [XmlIgnore]
        public List<Parameter> GetParameters
        {
            get
            {
                List<Parameter> list = new List<Parameter>();
                int num = 0;
                foreach (KeyValuePair<string, System.Type> keyValuePair in this.GetParamInfo)
                    list.Add(new Parameter((object)this.GetParamRepresentation(num++), keyValuePair.Value, keyValuePair.Key));
                return list;
            }
        }

        [XmlIgnore]
        public Dictionary<string, System.Type> GetParamInfo
        {
            get
            {
                Dictionary<string, System.Type> dictionary = new Dictionary<string, System.Type>();
                switch (this.Type)
                {
                    case 0:
                        dictionary.Add("strategy", typeof(int));
                        goto case 3;
                    case 1:
                        dictionary.Add("skill_id", typeof(int));
                        dictionary.Add("skill_level", typeof(int));
                        goto case 3;
                    case 2:
                        dictionary.Add("message", typeof(string));
                        dictionary.Add("message_type", typeof(Operation.MessageType));
                        if (this.Parent.Version > 10)
                        {
                            dictionary.Add("mask", typeof(int));
                            goto case 3;
                        }
                        else
                            goto case 3;
                    case 3:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        return dictionary;
                    case 4:
                        dictionary.Add("trigger_id", typeof(int));
                        goto case 3;
                    case 5:
                    case 6:
                        dictionary.Add("trigger_id", typeof(int));
                        goto case 3;
                    case 7:
                        dictionary.Add("timer_id", typeof(int));
                        dictionary.Add("interval", typeof(int));
                        dictionary.Add("count", typeof(int));
                        goto case 3;
                    case 8:
                        dictionary.Add("timer_id", typeof(int));
                        goto case 3;
                    case 14:
                        dictionary.Add("ctrl_id", typeof(int));
                        dictionary.Add("is_active", typeof(bool));
                        goto case 3;
                    case 15:
                        dictionary.Add("key", typeof(int));
                        dictionary.Add("value", typeof(int));
                        dictionary.Add("is_value", typeof(bool));
                        goto case 3;
                    case 16:
                        dictionary.Add("key", typeof(int));
                        dictionary.Add("value", typeof(int));
                        goto case 3;
                    case 17:
                        dictionary.Add("mob_id", typeof(int));
                        dictionary.Add("count", typeof(int));
                        dictionary.Add("remain_time", typeof(int));
                        dictionary.Add("die_with_spawner", typeof(bool));
                        dictionary.Add("path_id", typeof(int));
                        dictionary.Add("target_distance", typeof(int));
                        goto case 3;
                    case 18:
                        dictionary.Add("world_tag", typeof(int));
                        dictionary.Add("global_path_id", typeof(int));
                        dictionary.Add("path_type", typeof(int));
                        dictionary.Add("speed_flag", typeof(bool));
                        goto case 3;
                    case 19:
                        dictionary.Add("action_name", typeof(GB18030));
                        dictionary.Add("play_times", typeof(int));
                        dictionary.Add("interval_time", typeof(int));
                        dictionary.Add("action_last_time", typeof(int));
                        goto case 3;
                    case 20:
                        dictionary.Add("key", typeof(int));
                        dictionary.Add("val", typeof(int));
                        goto case 3;
                    case 21:
                        dictionary.Add("key", typeof(int));
                        dictionary.Add("val", typeof(int));
                        dictionary.Add("flag", typeof(bool));
                        goto case 3;
                    case 22:
                        dictionary.Add("type", typeof(int));
                        goto case 3;
                    case 23:
                        dictionary.Add("destination", typeof(int));
                        dictionary.Add("dest_type", typeof(int));
                        dictionary.Add("source_1", typeof(int));
                        dictionary.Add("sourcetype_1", typeof(int));
                        dictionary.Add("operation", typeof(int));
                        dictionary.Add("source_2", typeof(int));
                        dictionary.Add("sourcetype_2", typeof(int));
                        goto case 3;
                    case 24:
                        dictionary.Add("die_with_spawner", typeof(bool));
                        dictionary.Add("mob_id", typeof(int));
                        dictionary.Add("mob_id_type", typeof(int));
                        dictionary.Add("target_distance", typeof(int));
                        dictionary.Add("path_id", typeof(int));
                        dictionary.Add("count", typeof(int));
                        dictionary.Add("count_type", typeof(int));
                        dictionary.Add("remain_time", typeof(int));
                        dictionary.Add("path_id_type", typeof(int));
                        goto case 3;
                    case 25:
                        dictionary.Add("world_tag", typeof(int));
                        dictionary.Add("global_path_id", typeof(int));
                        dictionary.Add("global_path_id_type", typeof(int));
                        dictionary.Add("path_type", typeof(int));
                        dictionary.Add("speed_flag", typeof(bool));
                        goto case 3;
                    case 26:
                        dictionary.Add("skill_id", typeof(int));
                        dictionary.Add("skill_id_type", typeof(int));
                        dictionary.Add("skill_level", typeof(int));
                        dictionary.Add("skill_level_type", typeof(int));
                        goto case 3;
                    case 27:
                        dictionary.Add("ctrl_id", typeof(int));
                        dictionary.Add("ctrl_id_type", typeof(int));
                        dictionary.Add("is_active", typeof(bool));
                        goto case 3;
                    case 28:
                        dictionary.Add("task_id", typeof(int));
                        dictionary.Add("task_id_type", typeof(int));
                        goto case 3;
                    case 29:
                        dictionary.Add("remain_time_type", typeof(int));
                        dictionary.Add("mine_id", typeof(int));
                        dictionary.Add("mine_id_type", typeof(int));
                        dictionary.Add("target_distance", typeof(int));
                        dictionary.Add("remain_time", typeof(int));
                        dictionary.Add("count", typeof(int));
                        dictionary.Add("count_type", typeof(int));
                        goto case 3;
                    case 30:
                        dictionary.Add("remain_time_type", typeof(int));
                        dictionary.Add("npc_id", typeof(int));
                        dictionary.Add("npc_id_type", typeof(int));
                        dictionary.Add("target_distance", typeof(int));
                        dictionary.Add("remain_time", typeof(int));
                        dictionary.Add("path_id", typeof(int));
                        dictionary.Add("path_id_type", typeof(int));
                        dictionary.Add("count", typeof(int));
                        dictionary.Add("count_type", typeof(int));
                        goto case 3;
                    case 31:
                        dictionary.Add("task_storage_id", typeof(int));
                        dictionary.Add("left", typeof(float));
                        dictionary.Add("top", typeof(double));
                        dictionary.Add("right", typeof(float));
                        dictionary.Add("bottom", typeof(double));
                        goto case 3;
                    case 32:
                        dictionary.Add("task_id", typeof(int));
                        dictionary.Add("task_id_type", typeof(int));
                        dictionary.Add("distance", typeof(int));
                        dictionary.Add("count", typeof(int));
                        goto case 3;
                    case 33:
                        dictionary.Add("left", typeof(float));
                        dictionary.Add("top", typeof(double));
                        dictionary.Add("right", typeof(float));
                        dictionary.Add("bottom", typeof(double));
                        goto case 3;
                    case 34:
                        dictionary.Add("RadiusValue", typeof(float));
                        dictionary.Add("RadiusType", typeof(int));
                        dictionary.Add("TargetID", typeof(int));
                        dictionary.Add("Target_Type", typeof(int));
                        goto case 3;
                    case 35:
                        dictionary.Add("MinX", typeof(float));
                        dictionary.Add("MinY", typeof(float));
                        dictionary.Add("MinZ", typeof(float));
                        dictionary.Add("MaxX", typeof(float));
                        dictionary.Add("MaxY", typeof(float));
                        dictionary.Add("MaxZ", typeof(float));
                        dictionary.Add("TargetID", typeof(int));
                        dictionary.Add("Target_Type", typeof(int));
                        goto case 3;
                    default:
                        dictionary = (Dictionary<string, System.Type>)null;
                        goto case 3;
                }
            }
        }

        public Operation()
        {
            this.Parameters = new List<object>();
        }

        public Operation(Trigger t, int type)
          : this()
        {
            this.Parent = t;
            this.Type = type;
            switch (this.Type)
            {
                case 0:
                    this.Parameters.Add((object)0);
                    break;
                case 1:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 2:
                    this.Parameters.Add((object)"");
                    this.Parameters.Add((object)Operation.MessageType.Owner);
                    if (t.Version > 10)
                    {
                        this.Parameters.Add((object)0);
                        break;
                    }
                    break;
                case 4:
                    this.Parameters.Add((object)0);
                    break;
                case 5:
                case 6:
                    this.Parameters.Add((object)0);
                    break;
                case 7:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 8:
                    this.Parameters.Add((object)0);
                    break;
                case 14:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 15:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 16:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 17:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 18:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 19:
                    this.Parameters.Add((object)new GB18030(new byte[128]));
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 20:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 21:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 22:
                    this.Parameters.Add((object)0);
                    break;
                case 23:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 24:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 25:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 26:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 27:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 28:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 29:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    if (t.Version > 22)
                    {
                        this.Parameters.Add((object)0);
                        break;
                    }
                    break;
                case 30:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 31:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0);
                    break;
                case 32:
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 33:
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0);
                    break;
                case 34:
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
                case 35:
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0.0f);
                    this.Parameters.Add((object)0);
                    this.Parameters.Add((object)0);
                    break;
            }
            this.Tg = new Target(0);
        }

        public Operation Deserialize(Trigger t, DataStream ds)
        {
            this.Parent = t;

            switch (this.Type = ds.ReadInt32()) //HERE
            {
                case 0:
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 1:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 2:
                    int size = ds.ReadInt32();

                        string str = ds.ReadUnicode(size);
                        Operation.MessageType messageType = Operation.MessageType.Owner;
                        if ((int)str[0] == 36)
                        {
                            switch (str[1])
                            {
                                case 'I':
                                    messageType = Operation.MessageType.Instance;
                                    break;
                                case 'S':
                                    messageType = Operation.MessageType.System;
                                    break;
                                case 'T':
                                    messageType = Operation.MessageType.Territory;
                                    break;
                                case 'X':
                                    messageType = Operation.MessageType.Popup;
                                    break;
                                case 'A':
                                    messageType = Operation.MessageType.Normal;
                                    break;
                                case 'B':
                                    messageType = Operation.MessageType.World;
                                    break;
                                case 'F':
                                    messageType = Operation.MessageType.Faction;
                                    break;
                            }
                            if (messageType != Operation.MessageType.Owner)
                                str = str.Substring(2);
                        }

                        this.Parameters.Add((object)str);
                        this.Parameters.Add((object)messageType);

                    if (t.Version > 10)
                    {
                        this.Parameters.Add((object)ds.ReadInt32());
                        if ((int)this.Parameters[2] == 1)
                        {
                            goto case 3;
                        }
                        else
                            goto case 3;
                    }
                    else
                        goto case 3;
                case 3:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    this.Tg = new Target().Deserialize(ds);
                    return this;
                case 4:
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 5:
                case 6:
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 7:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 8:
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 14:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 15:
                    this.Parameters.Add((object)ds.ReadInt32());//ID
                    this.Parameters.Add((object)ds.ReadInt32());//Value
                    if (t.Version <= 23)
                        this.Parameters.Add((object)ds.ReadInt32());//IsValue
                    goto case 3;
                case 16:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 17:
                    this.Parameters.Add((object)ds.ReadInt32());//MonsterID
                    this.Parameters.Add((object)ds.ReadInt32());//Range
                    this.Parameters.Add((object)ds.ReadInt32());//Life
                    this.Parameters.Add((object)ds.ReadInt32());//DispearCondition
                    this.Parameters.Add((object)ds.ReadInt32());//PathID
                    this.Parameters.Add((object)ds.ReadInt32());//MonsterNum
                    goto case 3;
                case 18:
                    this.Parameters.Add((object)ds.ReadInt32());//WorldID
                    this.Parameters.Add((object)ds.ReadInt32());//PathID
                    this.Parameters.Add((object)ds.ReadInt32());//PatrolType
                    this.Parameters.Add((object)ds.ReadInt32());//SpeedType
                    goto case 3;
                case 19:
                    this.Parameters.Add((object)ds.ReadGB18030());//ActionName
                    this.Parameters.Add((object)ds.ReadInt32());//Loop
                    this.Parameters.Add((object)ds.ReadInt32());//Interval
                    this.Parameters.Add((object)ds.ReadInt32());//PlayTime
                    goto case 3;
                case 20:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 21:
                    this.Parameters.Add((object)ds.ReadInt32());//ID
                    this.Parameters.Add((object)ds.ReadInt32());//Value
                    this.Parameters.Add((object)ds.ReadInt32());//IsHistoryValue
                    goto case 3;
                case 22:
                    this.Parameters.Add((object)ds.ReadInt32());//Type
                    goto case 3;
                case 23:
                    this.Parameters.Add((object)ds.ReadInt32());//Dst
                    this.Parameters.Add((object)ds.ReadInt32());//DstType
                    this.Parameters.Add((object)ds.ReadInt32());//Src1
                    this.Parameters.Add((object)ds.ReadInt32());//Src1Type
                    this.Parameters.Add((object)ds.ReadInt32());//Op
                    this.Parameters.Add((object)ds.ReadInt32());//Src2
                    this.Parameters.Add((object)ds.ReadInt32());//Src2Type
                    goto case 3;
                case 24:
                    this.Parameters.Add((object)ds.ReadInt32());//DispearCondition
                    this.Parameters.Add((object)ds.ReadInt32());//MonsterID
                    this.Parameters.Add((object)ds.ReadInt32());//MonsterIDType
                    this.Parameters.Add((object)ds.ReadInt32());//Range
                    this.Parameters.Add((object)ds.ReadInt32());//Life
                    this.Parameters.Add((object)ds.ReadInt32());//PathID
                    this.Parameters.Add((object)ds.ReadInt32());//PathIDType
                    this.Parameters.Add((object)ds.ReadInt32());//MonsterNum
                    this.Parameters.Add((object)ds.ReadInt32());//MonsterNumType
                    goto case 3;
                case 25:
                    this.Parameters.Add((object)ds.ReadInt32());//WorldID
                    this.Parameters.Add((object)ds.ReadInt32());//PathID
                    this.Parameters.Add((object)ds.ReadInt32());//PathIDType
                    this.Parameters.Add((object)ds.ReadInt32());//PatrolType
                    this.Parameters.Add((object)ds.ReadInt32());//SpeedType
                    goto case 3;
                case 26:
                    this.Parameters.Add((object)ds.ReadInt32());//Skill
                    this.Parameters.Add((object)ds.ReadInt32());//SkillType
                    this.Parameters.Add((object)ds.ReadInt32());//Level
                    this.Parameters.Add((object)ds.ReadInt32());//LevelType
                    goto case 3;
                case 27:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 28:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    goto case 3;
                case 29:
                    this.Parameters.Add((object)ds.ReadInt32());//LifeType
                    this.Parameters.Add((object)ds.ReadInt32());//MineID
                    this.Parameters.Add((object)ds.ReadInt32());//MineIDType
                    this.Parameters.Add((object)ds.ReadInt32());//Range
                    this.Parameters.Add((object)ds.ReadInt32());//Life
                    this.Parameters.Add((object)ds.ReadInt32());//MineNum
                    this.Parameters.Add((object)ds.ReadInt32());//MineNumType
                    if (t.Version > 22)
                    {
                        //this.Parameters.Add((object)ds.ReadInt32());
                        goto case 3;
                    }
                    else
                        goto case 3;
                case 30:
                    this.Parameters.Add((object)ds.ReadInt32());// LifeType
                    this.Parameters.Add((object)ds.ReadInt32());//NPCID
                    this.Parameters.Add((object)ds.ReadInt32());//NPCIDType
                    this.Parameters.Add((object)ds.ReadInt32());//Range
                    this.Parameters.Add((object)ds.ReadInt32());//Life
                    this.Parameters.Add((object)ds.ReadInt32());//PathID
                    this.Parameters.Add((object)ds.ReadInt32());//PathIDType
                    this.Parameters.Add((object)ds.ReadInt32());//NPCNum
                    this.Parameters.Add((object)ds.ReadInt32());//NPCNumType
                    goto case 3;
                case 31:
                    if (t.Version > 22)
                    {
                        this.Parameters.Add((object)ds.ReadInt32()); //ID
                        this.Parameters.Add((object)ds.ReadFloat32());//MinX
                        this.Parameters.Add((object)ds.ReadFloat32());//MinY
                        this.Parameters.Add((object)ds.ReadFloat32());//MinZ
                        this.Parameters.Add((object)ds.ReadFloat32());//MaxX
                        this.Parameters.Add((object)ds.ReadFloat32());//MaxY
                        this.Parameters.Add((object)ds.ReadFloat32());//MaxZ
                    }
                    else
                    {
                        this.Parameters.Add((object)ds.ReadInt32()); //ID
                        this.Parameters.Add((object)ds.ReadFloat32());//minx
                        this.Parameters.Add((object)ds.ReadDouble64());//y
                        this.Parameters.Add((object)ds.ReadFloat32());//z
                        this.Parameters.Add((object)ds.ReadDouble64());//c
                    }

                    goto case 3;
                case 32:
                    this.Parameters.Add((object)ds.ReadInt32());//ID
                    this.Parameters.Add((object)ds.ReadInt32());//IDType
                    this.Parameters.Add((object)ds.ReadInt32());//Range
                    this.Parameters.Add((object)ds.ReadInt32());//PlayerNum
                    goto case 3;
                case 33:
                    if (t.Version > 22)
                    {

                        this.Parameters.Add((object)ds.ReadFloat32());//MinX
                        this.Parameters.Add((object)ds.ReadFloat32());//MinY
                        this.Parameters.Add((object)ds.ReadFloat32());//MinZ

                        this.Parameters.Add((object)ds.ReadFloat32());//MaxX
                        this.Parameters.Add((object)ds.ReadFloat32());//MaxY
                        this.Parameters.Add((object)ds.ReadFloat32());//MaxZ
                    }
                    else
                    {
                        this.Parameters.Add((object)ds.ReadFloat32());
                        this.Parameters.Add((object)ds.ReadDouble64());
                        this.Parameters.Add((object)ds.ReadFloat32());
                        this.Parameters.Add((object)ds.ReadDouble64());
                    }
                    goto case 3;
                case 34:
                    this.Parameters.Add((object)ds.ReadFloat32());//ReadSingle
                    this.Parameters.Add((object)ds.ReadInt32());//ReadUInt32
                    this.Parameters.Add((object)ds.ReadInt32());//ReadInt32
                    this.Parameters.Add((object)ds.ReadInt32());//ReadUInt32
                    goto case 3;
                case 35:
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadInt32()); //ID
                    this.Parameters.Add((object)ds.ReadInt32()); //ID
                    goto case 3;
                default:
                    return (Operation)null;
            }
        }

        public DataStream Serialize()
        {
            DataStream dataStream = new DataStream().Write((object)this.Type);
            if (this.Type == 2)
            {
                char ch = char.MinValue;
                switch ((Operation.MessageType)this.Parameters[1])
                {
                    case Operation.MessageType.System:
                        ch = 'S';
                        break;
                    case Operation.MessageType.Instance:
                        ch = 'I';
                        break;
                    case Operation.MessageType.Popup:
                        ch = 'X';
                        break;
                    case Operation.MessageType.World:
                        ch = 'B';
                        break;
                    case Operation.MessageType.Faction:
                        ch = 'F';
                        break;
                    case Operation.MessageType.Normal:
                        ch = 'A';
                        break;
                    case Operation.MessageType.Territory:
                        ch = 'T';
                        break;
                }
                string str = ((int)ch == 0 ? "" : "$" + (object)ch) + (string)this.Parameters[0];
                dataStream.Write((object)(str.Length * 2));
                dataStream.Write((object)str);
                if (this.Parameters.Count > 2)
                    dataStream.Write(this.Parameters[2]);
            }
            else
            {
                foreach (object val in this.Parameters)
                    dataStream.Write(val);
            }
            dataStream.Write(this.Tg.Serialize());
            return dataStream;
        }

        public string GetRepresentation()
        {
            string str = EnumUtils.StringValueOf((Operation.OperationType)this.Type) + "(";
            int i;
            for (i = 0; i < this.GetParamInfo.Count - 1; ++i)
                str = str + this.GetParamRepresentation(i) + ", ";
            if (this.Parameters.Count != 0 && i < this.Parameters.Count)
                str += this.GetParamRepresentation(i);
            try
            {
                return str + ")" + " Target: " + EnumUtils.StringValueOf((Target.Name)this.Tg.Type);// ((Target.Name) this.Tg.Type).ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool SetParameter(int index, string value)
        {
            System.Type type = this.GetParamInfo[Enumerable.ElementAt<string>((IEnumerable<string>)this.GetParamInfo.Keys, index)];
            int result1;
            if (type == typeof(int) && int.TryParse(value, out result1))
            {
                this.Parameters[index] = (object)result1;
                return true;
            }
            Operation.MessageType result2;
            if (type == typeof(Operation.MessageType) && Enum.TryParse<Operation.MessageType>(value, out result2))
            {
                this.Parameters[index] = (object)result2;
                return true;
            }
            float result3;
            if (type == typeof(float) && float.TryParse(value, out result3))
            {
                this.Parameters[index] = (object)result3;
                return true;
            }
            double result4;
            if (type == typeof(double) && double.TryParse(value, out result4))
            {
                this.Parameters[index] = (object)result4;
                return true;
            }
            if (type == typeof(GB18030))
            {
                GB18030 gb18030 = new GB18030(new byte[128]);
                gb18030.Set(value);
                this.Parameters[index] = (object)gb18030;
                return true;
            }
            if (type == typeof(bool))
            {
                if (value.Equals("true"))
                {
                    this.Parameters[index] = (object)1;
                    return true;
                }
                if (!value.Equals("false"))
                    return false;
                this.Parameters[index] = (object)0;
                return true;
            }
            if (!(type == typeof(string)))
                return false;
            if ((int)value[0] == 34 && (int)value[value.Length - 1] == 34)
                value = value.Substring(1, value.Length - 2);
            this.Parameters[index] = (object)(value + ((int)value[value.Length - 1] == 0 ? "" : "\0"));
            return true;
        }

        public void SetTarget(Target tg)
        {
            this.Tg = tg;
        }

        public string GetParamRepresentation(int i)
        {
            object obj = this.Parameters[i];
            System.Type type = this.GetParamInfo[Enumerable.ElementAt<string>((IEnumerable<string>)this.GetParamInfo.Keys, i)];
            if (type == typeof(byte[]))
                return "" + Encoding.GetEncoding("GB18030").GetString((byte[])obj).Trim(new char[1]) + "";
            if (type == typeof(string))
                return "" + ((string)obj).Trim(new char[1]) + "";
            if (type == typeof(bool))
                return (int)obj > 0 ? "true" : "false";
            return obj.ToString();
        }

        public enum MessageType
        {
            System,
            Instance,
            Popup,
            World,
            Faction,
            Owner,
            Normal,
            Territory,
        }

        public enum OperationType
        {
            [Description("Attak Target")]
            Attack,
            [Description("Use Skill")]
            UseSkill,
            [Description("Send Message")]
            SayMessage,
            [Description("Reset Aggro")]
            ResetAggro,
            [Description("Execute Triger")]
            ExecuteTrigger,
            [Description("Enable Passive Triger")]
            EnablePassiveTrigger,
            [Description("Enable Active Triger")]
            EnableActiveTrigger,
            [Description("Create Timer")]
            CreateTimer,
            [Description("Delete Timer")]
            RemoveTimer,
            [Description("Flee")]
            Flee,
            [Description("Be Tunted")]
            BeTaunted,
            [Description("Fade Target")]
            FadeTarget,
            [Description("Fade Aggro")]
            FadeAggro,
            [Description("Break")]
            Break,
            [Description("Active Spawn")]
            ActiveSpawn,
            [Description("Set Common Value")]
            SetCommonValue,
            [Description("Increase Common Value")]
            IncreaseCommonValue,
            [Description("Summon Monster")]
            SummonMonster,
            [Description("Change Path")]
            ChangePath,
            [Description("Play Action")]
            PlayAction,
            [Description("Revise History")]
            ReviseHistory,
            [Description("Set History")]
            SetHistory,
            [Description("Deliver Faction PVP Points")]
            DeliverFactionPVPPoints,
            [Description("Calc Variable")]
            CalcVariable,
            [Description("Summon Monster")]
            SummonMonster2,
            [Description("Change Path")]
            ChangePath2,
            [Description("Use Skill")]
            UseSkill2,
            [Description("Active Spawn")]
            ActiveSpawn2,
            [Description("Deliver Task")]
            DeliverTask,
            [Description("Summon Mine")]
            SummonMine,
            [Description("Summon Npc")]
            SummonNpc,
            [Description("Deliver Random Task In Region")]
            DeliverRandomTaskInRegion,
            [Description("Deliver Task In Damage List")]
            DeliverTaskInDamageList,
            [Description("Clear Tower Task In Region")]
            ClearTowerTaskInRegion,

            [Description("Save_player_count_in_radius_to_param")]
            save_player_count_in_radius_to_param,
            [Description("save_player_count_in_region_to_param")]
            save_player_count_in_region_to_param,
            [Description("Unknown3")]
            Unknown3,
            [Description("Unknown4")]
            Unknown4,

        }
    }
}
