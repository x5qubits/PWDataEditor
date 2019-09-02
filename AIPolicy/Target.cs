using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace AIPolicy
{
    [Serializable]
    public class Target
    {
        private int param;

        public int Type { get; set; }

        public bool HasParameter { get; set; }

        public int Parameter
        {
            get
            {
                return this.param;
            }
            set
            {
                this.param = value;
                this.HasParameter = true;
            }
        }

        [XmlIgnore]
        public List<AIPolicy.Parameter> GetParameters
        {
            get
            {
                List<AIPolicy.Parameter> list = new List<AIPolicy.Parameter>();
                if (this.Type == 6)
                    list.Add(new AIPolicy.Parameter((object)this.Parameter, typeof(int), "class_mask"));
                return list;
            }
        }

        public Target()
        {
        }

        public Target(int type)
          : this()
        {
            this.Type = type;
            if (this.Type != 6)
                return;
            this.Parameter = 0;
        }

        public Target Deserialize(DataStream ds)
        {
            switch (this.Type = ds.ReadInt32())
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 7:
                case 8:
                case 9:
                case 13:
                    return this;
                case 6:
                case 14:
                    this.Parameter = ds.ReadInt32(true);
                    goto case 0;
                case 10:
                case 11:
                case 12:
                    this.Parameter = this.Type % 10;
                    goto case 0;
                default:
                    return (Target)null;
            }
        }

        public DataStream Serialize()
        {
            DataStream dataStream = new DataStream().Write((object)this.Type);
            if (this.Type == 6)
                dataStream = dataStream.Write((object)this.Parameter);
            return dataStream;
        }

        public void SetParameter(int mask)
        {
            this.Parameter = mask;
        }

        public enum Name
        {
            [Description("Aggro First")]
            Aggro_First,
            [Description("Aggro Second")]
            Aggro_Second,
            [Description("Aggro Second Random")]
            Aggro_Second_Rand,
            [Description("Target Most HP")]
            Target_Most_HP,
            [Description("Target Most MP")]
            Target_Most_MP,
            [Description("Target Least HP")]
            Target_Least_HP,
            [Description("Target Character Profession Mask")]
            Target_Class_Combo,
            [Description("Target Self")]
            Target_Self,
            [Description("Target Monster Killer")]
            Target_Monster_Killer,
            [Description("Target Monster Birthplace Faction")]
            Target_Monster_Birthplace_Faction,
            [Description("Target Aggro Random")]
            Target_Aggro_random,
            [Description("Target Aggro Nearest")]
            Target_Aggro_nearest,
            [Description("Target Aggro Farthest")]
            Target_Aggro_Farthest,
            [Description("Target Aggro First Redirected")]
            Target_Aggro_First_Redirected,
            [Description("NUM")]
            num,
        }
    }
}
