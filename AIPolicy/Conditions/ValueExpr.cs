using AIPolicy;
using System;
using System.Collections.Generic;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class ValueExpr : Expression
    {
        public List<object> Parameters;

        public int Constant { get; set; }

        public ValueExpr()
        {
            this.Parameters = new List<object>();
        }

        public ValueExpr DeserializeValueExpr(DataStream ds)
        {
            this.Parameters.Add((object)ds.ReadInt32());
            switch (this.Type)
            {
                case 16:
                case 17:
                case 21:
                case 23:
                case 27:
                    this.Constant = ds.ReadInt32();
                    goto case 26;
                case 26:
                    return this;
                default:
                    return (ValueExpr)null;
            }
        }

        public DataStream SerializeValueExpr()
        {
            DataStream dataStream = new DataStream().Write(this.Parameters[0]);
            switch (this.Type)
            {
                case 16:
                case 17:
                case 21:
                case 23:
                case 27:
                    dataStream.Write((object)this.Constant);
                    goto case 26;
                case 26:
                    return dataStream;
                default:
                    return (DataStream)null;
            }
        }

        public ValueExpr GetValueExpr(CharStream encoded)
        {
            this.Parameters.Add((object)0);
            switch (this.Type)
            {
                case 16:
                case 17:
                case 21:
                case 23:
                case 27:
                    int result;
                    if (!int.TryParse(encoded.ReadBlock(), out result))
                        return (ValueExpr)null;
                    this.Constant = result;
                    return this;
                case 26:
                    return this;
                default:
                    return (ValueExpr)null;
            }
        }
    }
}
