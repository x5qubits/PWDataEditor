using AIPolicy;
using System;
using System.Collections.Generic;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class Negation : Condition
  {
    public List<object> Parameters;

    public Condition Inner { get; private set; }

    public Negation()
    {
      this.Parameters = new List<object>();
    }

    public Negation DeserializeNegation(DataStream ds)
    {
      this.Parameters.Add((object) ds.ReadInt32());
      this.Parameters.Add((object) ds.ReadInt32());
      this.Inner = new Condition().Deserialize(ds);
      if (this.Inner == null || this.Inner is Expression)
        return (Negation) null;
      return this;
    }

    public DataStream SerializeNegation()
    {
      return new DataStream().Write(this.Parameters[0]).Write(this.Parameters[1]).Write(this.Inner.Serialize());
    }

    public Negation GetNegation(CharStream encoded)
    {
      if (this.Type != 5)
        return (Negation) null;
      this.Parameters.Add((object) 0);
      this.Parameters.Add((object) 2);
      this.Inner = this.GetCondition(encoded);
      if (this.Inner == null)
        return (Negation) null;
      return this;
    }

    public string GetNegationRepresentation()
    {
      if (this.Inner.Type == 15)
        return ((Arithmetic) this.Inner).Left.GetExprRepresentation() + this.Inner.GetCompar(true) + ((Arithmetic) this.Inner).Right.GetExprRepresentation();
      return "!" + this.Inner.GetRepresentation(false);
    }
  }
}
