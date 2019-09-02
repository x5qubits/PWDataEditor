using AIPolicy.Operations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AIPolicy
{
    [Serializable]
    public class AI
    {
        public SortedDictionary<int, Policy> Policies;
        public int lastKnownId = 0;
        public int Count(bool isInitial = false)
        {
            if (isInitial)
            {
                return this.countx;
            }
            return this.Policies.Count;
        }
        private int countx = 0;
        public void Count(int c)
        {
            this.countx = c;
        }

        public int Beginning { get; set; }
        public AI()
        {
            this.Policies = new SortedDictionary<int, Policy>();
        }
        public AI Deserialize(DataStream ds)
        {
            this.Beginning = ds.ReadInt32();
            this.Count(ds.ReadInt32());
            List<Policy> Policiesdup = new List<Policy>();
            try
            {
                for (int index = 0; index < this.Count(true); ++index)
                {
                    Policy pol = new Policy().Deserialize(ds);
                    if (this.lastKnownId < pol.ID)
                    {
                        this.lastKnownId = pol.ID;
                    }
                    if (this.Policies.ContainsKey(pol.ID))
                    {
                        Policiesdup.Add(pol);
                    }
                    else
                    {
                        this.Policies.Add(pol.ID, pol);
                    }
                }
            }
            catch { }

            foreach (Policy pol in Policiesdup)
            {
                if (MessageBox.Show("Warning: " + pol.ID + " already exists. Do you want to generate new id? (No to overwrite)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int newid = getNewId();
                    pol.ID = newid;
                    this.Policies.Add(newid, pol);
                }
                else
                {
                    this.Policies[pol.ID] = pol;
                }
            }
            return this;
        }

        public DataStream Serialize()
        {
            DataStream dataStream = new DataStream().Write((object)this.Beginning).Write((object)this.Count());
            foreach (Policy policy in this.Policies.Values)
                dataStream.Write(policy.Serialize());
            return dataStream;
        }
        public Policy FindPolicy(int ID)
        {
            foreach (Policy policy in this.Policies.Values)
            {
                if (policy.ID == ID)
                    return policy;
            }
            return (Policy)null;
        }

        public int FindPolicyIndex(int ID)
        {
            int id = 0;
            foreach (Policy policy in this.Policies.Values)
            {
                if (policy.ID == ID)
                    return id;
                else
                    id++;
            }
            return id;
        }

        public void Remove(Policy pol)
        {
            this.Policies.Remove(pol.ID);
        }
        public void Add(Policy pol)
        {
            if (!this.Policies.ContainsKey(pol.ID))
                this.Policies.Add(pol.ID, pol);
            else
                this.Policies[pol.ID] = pol;
        }
        public bool Dump(string filename)
        {
            try
            {
                this.Serialize().Dump(filename);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public List<Operation> SearchOperation(string text, bool chinese = true)
        {
            List<Operation> list = new List<Operation>();
            foreach (Policy policy in this.Policies.Values)
            {
                foreach (Trigger trigger in policy.Triggers)
                {
                    foreach (Operation operation in trigger.Operations)
                    {
                        if (operation.Type == 2)
                        {
                            string input = operation.Parameters[0].ToString();
                            if (input.ToLower().Contains(text.ToLower()))

                                list.Add(operation);
                        }
                    }
                }
            }
            return list;
        }
        public List<Trigger> SearchTrigger(string text)
        {
            List<Trigger> list = new List<Trigger>();
            foreach (Policy policy in this.Policies.Values)
            {
                foreach (Trigger trigger in policy.Triggers)
                {
                    if (trigger.Name.Contains(text))
                        list.Add(trigger);
                }
            }
            return list;
        }

        internal int getNewId()
        {
            while (this.Policies.ContainsKey(lastKnownId))
            {
                lastKnownId++;
            }
            return lastKnownId;
        }

        internal void removeAll(List<int> ids)
        {
            foreach (int policy in ids)
            {
                this.Policies.Remove(policy);
            }
        }
    }
}
