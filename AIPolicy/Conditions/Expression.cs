using AIPolicy;
using System;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class Expression : Condition
    {
        public Expression DeserializeExpression(DataStream ds)
        {
            int type;
            switch (type = ds.ReadInt32())
            {
                case 9:
                case 10:
                case 11:
                case 12:
                    return (Expression)((FormulaExpr)new FormulaExpr().SetType(type)).DeserializeFormulaExpr(ds).SetComplex(ds.ReadInt32());
                case 16:
                case 17:
                case 21:
                case 23:
                case 26:
                case 27:
                    return (Expression)((ValueExpr)new ValueExpr().SetType(type)).DeserializeValueExpr(ds).SetComplex(ds.ReadInt32());
                default:
                    return (Expression)null;
            }
        }

        public Expression GetExpression(CharStream encoded)
        {
            int result;
            if (!int.TryParse(encoded.ReadBlock(), out result))
                return (Expression)null;
            switch (result)
            {
                case 9:
                case 10:
                case 11:
                case 12:
                    return (Expression)((FormulaExpr)new FormulaExpr().SetType(result)).GetFormulaExpr(encoded);
                case 16:
                case 17:
                case 21:
                case 23:
                case 26:
                case 27:
                    return (Expression)((ValueExpr)new ValueExpr().SetType(result)).GetValueExpr(encoded);
                default:
                    return (Expression)null;
            }
        }

        public DataStream SerializeExpression()
        {
            DataStream dataStream = new DataStream().Write((object)this.Type);
            switch (this.Type)
            {
                case 9:
                case 10:
                case 11:
                case 12:
                    dataStream.Write(((FormulaExpr)this).SerializeFormulaExpr());
                    break;
                case 16:
                case 17:
                case 21:
                case 23:
                case 26:
                case 27:
                    dataStream.Write(((ValueExpr)this).SerializeValueExpr());
                    break;
            }
            dataStream.Write((object)this.Complex);
            return dataStream;
        }

        public string GetExprRepresentation()
        {
            string str = "";
            switch (this.Type)
            {
                case 9:
                case 10:
                case 11:
                case 12:
                    str = str + "(" + ((FormulaExpr)this).Left.GetExprRepresentation() + this.GetSign() + ((FormulaExpr)this).Right.GetExprRepresentation() + ")";
                    break;
                case 16:
                case 21:
                case 23:
                    return "" + (object)(Condition.Name)this.Type + "(" + (object)((ValueExpr)this).Constant + ")";
                case 17:
                    return ((ValueExpr)this).Constant.ToString();
                case 26:
                case 27:
                    return "" + (object)(Condition.Name)this.Type + "()";
            }
            return str;
        }

        public string GetSign()
        {
            switch (this.Type)
            {
                case 9:
                    return " + ";
                case 10:
                    return " - ";
                case 11:
                    return " * ";
                case 12:
                    return " / ";
                default:
                    return "";
            }
        }
    }
}
