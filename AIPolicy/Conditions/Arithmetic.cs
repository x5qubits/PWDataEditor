using AIPolicy;
using System;
using System.Collections.Generic;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class Arithmetic : Condition
  {
    public List<object> Parameters;

    public Expression Left { get; private set; }

    public Expression Right { get; private set; }

    public Arithmetic()
    {
      this.Parameters = new List<object>();
    }

    public Arithmetic DeserializeArithmetic(DataStream ds)
    {
      this.Parameters.Add((object) ds.ReadInt32());
      this.Parameters.Add((object) ds.ReadInt32());
      this.Left = new Expression().DeserializeExpression(ds);
      this.Parameters.Add((object) ds.ReadInt32());
      this.Right = new Expression().DeserializeExpression(ds);
      return this;
    }

    public Arithmetic GetArithmetic(CharStream encoded)
    {
      for (int index = 0; index < 3; ++index)
        this.Parameters.Add((object) index);
      this.Left = new Expression().GetExpression(encoded);
      this.Right = new Expression().GetExpression(encoded);
      if (this.Left == null || this.Right == null)
        return (Arithmetic) null;
      return this;
    }

    public DataStream SerializeArithmetic()
    {
      return new DataStream().Write(this.Parameters[0]).Write(this.Parameters[1]).Write(this.Left.SerializeExpression()).Write(this.Parameters[2]).Write(this.Right.SerializeExpression());
    }
  }
}
