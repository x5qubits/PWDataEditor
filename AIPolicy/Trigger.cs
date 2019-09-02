using AIPolicy.Conditions;
using AIPolicy.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace AIPolicy
{
    [Serializable]
    public class Trigger
    {
        private static int[] Versions = new int[128];
        public List<Operation> Operations;

        public Condition RootConditon { get; set; }

        [XmlIgnore]
        public Policy Parent { get; set; }

        public static int EstimatedVersion
        {
            get
            {
                return Enumerable.ToList<int>((IEnumerable<int>)Trigger.Versions).IndexOf(Enumerable.Max((IEnumerable<int>)Trigger.Versions));
            }
        }

        public int Version { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsRun { get; set; }

        public bool IsAttackValid { get; set; }

        public int Count { get; set; }

        public int Index { get; set; }

        public GB18030 Name { get; set; }

        public Trigger()
        {
            this.Operations = new List<Operation>();
        }

        public Trigger(Policy p, int index, string name)
          : this()
        {
            this.Parent = p;
            this.Index = index;
            this.Name = new GB18030(new byte[128]);
            this.Name.Set(name);
            this.IsEnabled = true;
            this.IsRun = false;
            this.IsAttackValid = false;
            this.Count = 0;
            this.Version = Trigger.EstimatedVersion;
            this.RootConditon = new Condition().GetCondition(new CharStream("@5@1@0.10"));
        }

        public Trigger Deserialize(Policy p, DataStream ds)
        {
            this.Parent = p;
            ++Trigger.Versions[this.Version = ds.ReadInt32()];
            this.Index = ds.ReadInt32();
            this.IsEnabled = (int)ds.ReadByte() > 0;
            this.IsRun = (int)ds.ReadByte() > 0;
            this.IsAttackValid = (int)ds.ReadByte() > 0;
            this.Name = ds.ReadGB18030();
            this.RootConditon = new Condition().Deserialize(ds);
            this.Count = ds.ReadInt32();
            for (int index = 0; index < this.Count; ++index)
            {
                this.Operations.Add(new Operation().Deserialize(this, ds));
            }
            return this;
        }

        public DataStream Serialize()
        {
            DataStream dataStream = new DataStream().Write((object)this.Version).Write((object)this.Index).Write((object)(bool)(this.IsEnabled ? true : false)).Write((object)(bool)(this.IsRun ? true : false)).Write((object)(bool)(this.IsAttackValid ? true : false)).Write((object)this.Name).Write(this.RootConditon.Serialize()).Write((object)this.Count);
            foreach (Operation operation in this.Operations)
                dataStream.Write(operation.Serialize());
            return dataStream;
        }

        public string GetRepresentation()
        {
            return string.Concat(new object[4]
            {
        (object) "[",
        (object) this.Index,
        (object) "] ",
        (object) this.Name.ToString()
            });
        }

        public void Remove(Operation op)
        {
            this.Operations.Remove(op);
            --this.Count;
        }

        public void Add(Operation op)
        {
            this.Operations.Add(op);
            ++this.Count;
        }

        public void SetCondition(Condition cond)
        {
            this.RootConditon = cond;
        }

        public void SetFlag(int flag_num, bool val)
        {
            switch (flag_num)
            {
                case 1:
                    this.IsEnabled = val;
                    break;
                case 2:
                    this.IsRun = val;
                    break;
                case 3:
                    this.IsAttackValid = val;
                    break;
            }
        }

        internal void RemoveAll(List<int> ids)
        {
            foreach (int id in ids)
            {
                this.Operations.RemoveAt(id);
                --this.Count;
            }
            // this.Operations.Add(op);
            //++this.Count;
        }
    }
}
