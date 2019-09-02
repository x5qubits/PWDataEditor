using System;
using System.Collections.Generic;

namespace AIPolicy
{
    [Serializable]
    public class Policy
    {
        public List<Trigger> Triggers;

        public int Count { get; set; }

        public int Version { get; set; }

        public int ID { get; set; }

        public Policy()
        {
            this.Triggers = new List<Trigger>();
        }

        public Policy(int ID)
          : this()
        {
            this.ID = ID;
            this.Version = 1;
            this.Count = 0;
        }

        public Policy Deserialize(DataStream ds)
        {
            this.Version = ds.ReadInt32();
            this.ID = ds.ReadInt32();
            this.Count = ds.ReadInt32();
            for (int index = 0; index < this.Count; ++index)
                this.Triggers.Add(new Trigger().Deserialize(this, ds));
            return this;
        }

        public DataStream Serialize()
        {
            DataStream dataStream = new DataStream().Write((object)this.Version).Write((object)this.ID).Write((object)this.Count);
            foreach (Trigger trigger in this.Triggers)
                dataStream.Write(trigger.Serialize());
            return dataStream;
        }

        public void Remove(Trigger trig)
        {
            this.Triggers.Remove(trig);
            --this.Count;
        }

        public void Add(Trigger trig)
        {
            int listIndex = this.GetListIndex(trig.Index);
            if (listIndex == -1)
            {
                this.Triggers.Add(trig);
                ++this.Count;
            }
            else
                this.Triggers[listIndex] = trig;
        }

        public int FindTriggerIndex(Trigger trig)
        {
            return this.Triggers.IndexOf(trig);
        }

        public int GetListIndex(int trigindex)
        {
            for (int index = 0; index < this.Count; ++index)
            {
                if (this.Triggers[index].Index == trigindex)
                    return index;
            }
            return -1;
        }

        internal void RemoveAll(List<int> ids)
        {
            foreach (int index in ids)
            {
                this.Triggers.RemoveAt(index);
                --this.Count;
            }
        }
    }
}
