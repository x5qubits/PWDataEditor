using AIPolicy;
using System;
using System.Collections.Generic;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class Logic : Condition
  {
    public List<object> Parameters;

    public Condition Left { get; private set; }

    public Condition Right { get; private set; }

    public Logic()
    {
      this.Parameters = new List<object>();
    }

    public Logic DeserializeLogic(DataStream ds)
    {
      this.Parameters.Add((object) ds.ReadInt32());
      this.Parameters.Add((object) ds.ReadInt32());
      this.Left = new Condition().Deserialize(ds);
      this.Parameters.Add((object) ds.ReadInt32());
      this.Right = new Condition().Deserialize(ds);
      if (this.Left == null || this.Right == null)
        return (Logic) null;
      return this;
    }

    public Logic GetLogic(CharStream encoded)
    {
      for (int index = 0; index < 3; ++index)
        this.Parameters.Add((object) index);
      this.Left = this.GetCondition(encoded);
      this.Right = this.GetCondition(encoded);
      if (this.Left == null || this.Right == null)
        return (Logic) null;
      return this;
    }

    public DataStream SerializeLogic()
    {
      return new DataStream().Write(this.Parameters[0]).Write(this.Parameters[1]).Write(this.Left.Serialize()).Write(this.Parameters[2]).Write(this.Right.Serialize());
    }
  }
}
