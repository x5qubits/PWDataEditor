using AIPolicy;
using PWDataEditorPaied.AIPolicy.Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AIPolicy.Conditions
{
    [Serializable]
    public class Condition
    {
        private static Dictionary<int, int> Complexes = new Dictionary<int, int>();
        public int Type { get; set; }

        public int Complex
        {
            get
            {
                if (Enumerable.Contains<int>((IEnumerable<int>)Condition.Complexes.Keys, this.Type))
                    return Condition.Complexes[this.Type];
                return -1;
            }
            set
            {
                Condition.Complexes[this.Type] = value;
            }
        }

        public Condition()
        {
        }

        public Condition(int type)
        {
            this.Type = type;
        }

        public DataStream Serialize()
        {
            DataStream dataStream = new DataStream().Write((object)this.Type);
            switch (this.Type)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 8:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                    dataStream.Write(((Func)this).SerializeFunc());
                    break;
                case 5:
                    dataStream.Write(((Negation)this).SerializeNegation());
                    break;
                case 6:
                case 7:
                    dataStream.Write(((Logic)this).SerializeLogic());
                    break;
                case 13:
                case 14:
                case 15:
                    dataStream.Write(((Arithmetic)this).SerializeArithmetic());
                    break;
            }
            dataStream.Write((object)this.Complex);
            return dataStream;
        }

        public Condition Deserialize(DataStream ds)
        {
            int type;
            switch (type = ds.ReadInt32())
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 8:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                    return ((Func)new Func().SetType(type)).DeserializeFunc(ds).SetComplex(ds.ReadInt32());
                case 5:
                    return ((Negation)new Negation().SetType(type)).DeserializeNegation(ds).SetComplex(ds.ReadInt32());
                case 6:
                case 7:
                    return ((Logic)new Logic().SetType(type)).DeserializeLogic(ds).SetComplex(ds.ReadInt32());
                case 13:
                case 14:
                case 15:
                    return ((Arithmetic)new Arithmetic().SetType(type)).DeserializeArithmetic(ds).SetComplex(ds.ReadInt32());
                default:
                    return (Condition)null;
            }
        }

        public Condition SetType(int type)
        {
            this.Type = type;
            return this;
        }

        public Condition SetComplex(int complex)
        {
            if (this.Complex == -1)
                this.Complex = complex;
            if (this.Complex != complex)
                return (Condition)null;
            return this;
        }

        public Condition GetCondition(CharStream encoded)
        {
            int result;
            if (!int.TryParse(encoded.ReadBlock(), out result))
                return (Condition)null;
            switch (result)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 8:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                    return (Condition)((Func)new Func().SetType(result)).GetFunc(encoded);
                case 5:
                    return (Condition)((Negation)new Negation().SetType(result)).GetNegation(encoded);
                case 6:
                case 7:
                    return (Condition)((Logic)new Logic().SetType(result)).GetLogic(encoded);
                case 13:
                case 14:
                case 15:
                    return (Condition)((Arithmetic)new Arithmetic().SetType(result)).GetArithmetic(encoded);
                default:
                    return (Condition)null;
            }
        }

        public string GetRepresentation(bool initial = true)
        {
            string str1 = !initial ? "(" : "";
            switch (this.Type)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 8:
                case 16:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                    string str2 = "" + EnumUtils.StringValueOf((Condition.Name)this.Type) + "(";
                    Func func = (Func)this;
                    for (int index = 1; index < func.Parameters.Count; ++index)
                    {
                        str2 = !(func.Parameters[index] is float) ? str2 + func.Parameters[index].ToString() : str2 + ((float)func.Parameters[index]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        if (index != func.Parameters.Count - 1)
                            str2 += ", ";
                    }
                    return str2 + ")";
                case 5:
                    return ((Negation)this).GetNegationRepresentation();
                case 6:
                case 7:
                    str1 = str1 + ((Logic)this).Left.GetRepresentation(false) + (this.Type % 2 > 0 ? " && " : " || ") + ((Logic)this).Right.GetRepresentation(false);
                    break;
                case 13:
                case 14:
                case 15:
                    str1 = str1 + ((Arithmetic)this).Left.GetExprRepresentation() + this.GetCompar(false) + ((Arithmetic)this).Right.GetExprRepresentation();
                    break;
                case 17:
                    return ((ValueExpr)this).Constant.ToString();
            }
            return str1 + (!initial ? ")" : "");
        }

        public string GetCompar(bool negation)
        {
            switch (this.Type)
            {
                case 13:
                    return " > ";
                case 14:
                    return " < ";
                case 15:
                    return negation ? " != " : " == ";
                default:
                    return "";
            }
        }

        public enum Name
        {
            [Description("Timer Running")]
            TimerRunning = 0,
            [Description("Hp Lower Than")]
            HpLowerThan = 1,
            [Description("Combat Started")]
            CombatStarted = 2,
            [Description("Random")]
            Random = 3,
            [Description("Target Killed")]
            TargetKilled = 4,
            [Description("Died")]
            Died = 8,
            [Description("Public Counter")]
            PublicCounter = 16,
            [Description("Damage")]
            Damage = 18,
            [Description("Path Ended")]
            PathEnded = 19,
            [Description("History Stage")]
            HistoryStage = 20,
            [Description("History Value")]
            HistoryValue = 21,
            [Description("Combat Ended")]
            CombatEnded = 22,
            [Description("Local Value")]
            LocalValue = 23,
            [Description("Path Ended 2")]
            PathEnded2 = 24,
            [Description("Special Filter")]
            SpecialFilter = 25,
            [Description("Room Index")]
            RoomIndex = 26,
            [Description("PLAYER_COUNT_IN_RADIUS")]
            PLAYER_COUNT_IN_RADIUS = 27,
            [Description("PLAYER_COUNT_IN_REGION")]
            PLAYER_COUNT_IN_REGION = 28,
        }
    }
}
