using AIPolicy;
using System;
using System.Collections.Generic;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class FormulaExpr : Expression
  {
    public List<object> Parameters;

    public Expression Left { get; private set; }

    public Expression Right { get; private set; }

    public FormulaExpr()
    {
      this.Parameters = new List<object>();
    }

    public FormulaExpr DeserializeFormulaExpr(DataStream ds)
    {
      this.Parameters.Add((object) ds.ReadInt32());
      this.Parameters.Add((object) ds.ReadInt32());
      this.Left = new Expression().DeserializeExpression(ds);
      this.Parameters.Add((object) ds.ReadInt32());
      this.Right = new Expression().DeserializeExpression(ds);
      if (this.Left == null || this.Right == null)
        return (FormulaExpr) null;
      return this;
    }

    public FormulaExpr GetFormulaExpr(CharStream encoded)
    {
      for (int index = 0; index < 3; ++index)
        this.Parameters.Add((object) index);
      this.Left = this.GetExpression(encoded);
      this.Right = this.GetExpression(encoded);
      if (this.Left == null || this.Right == null)
        return (FormulaExpr) null;
      return this;
    }

    public DataStream SerializeFormulaExpr()
    {
      return new DataStream().Write(this.Parameters[0]).Write(this.Parameters[1]).Write(this.Left.SerializeExpression()).Write(this.Parameters[2]).Write(this.Right.SerializeExpression());
    }
  }
}
