using AIPolicy;
using System;
using System.Collections.Generic;

namespace AIPolicy.Conditions
{
    [Serializable]
    internal class Func : Condition
    {
        public List<object> Parameters { get; set; }

        public Func()
        {
            this.Parameters = new List<object>();
        }

        public Func DeserializeFunc(DataStream ds)
        {
            this.Parameters.Add((object)ds.ReadInt32());
            switch (this.Type)
            {
                case 0:
                case 16:
                case 17:
                case 19:
                case 20:
                case 21:
                case 23:
                case 25:
                    this.Parameters.Add((object)ds.ReadInt32());
                    break;
                case 1:
                case 3:
                case 27:
                    this.Parameters.Add((object)ds.ReadFloat32());
                    break;
                case 18:
                case 24:
                    this.Parameters.Add((object)ds.ReadInt32());
                    this.Parameters.Add((object)ds.ReadInt32());
                    break;
                case 28:
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    this.Parameters.Add((object)ds.ReadFloat32());
                    break;
            }
            return this;
        }

        public Func GetFunc(CharStream encoded)
        {
            this.Parameters.Add((object)0);
            switch (this.Type)
            {
                case 0:
                case 16:
                case 17:
                case 19:
                case 20:
                case 21:
                case 23:
                case 25:
                    int result1;
                    if (!int.TryParse(encoded.ReadBlock(), out result1))
                        return (Func)null;
                    this.Parameters.Add((object)result1);
                    goto case 2;
                case 1:
                case 3:
                case 27:
                    this.Parameters[0] = (object)4;
                    float result2;
                    if (!float.TryParse(encoded.ReadBlock(), out result2))
                        return (Func)null;
                    this.Parameters.Add((object)result2);
                    goto case 2;
                case 2:
                case 4:
                case 8:
                case 22:
                    return this;
                case 18:
                case 24:
                    string s1 = encoded.ReadBlock();
                    string s2 = encoded.ReadBlock();
                    int result3;
                    if (!int.TryParse(s1, out result3))
                        return (Func)null;
                    this.Parameters.Add((object)result3);
                    int result4;
                    if (!int.TryParse(s2, out result4))
                        return (Func)null;
                    this.Parameters.Add((object)result4);
                    goto case 2;
                case 28:
                    try
                    {
                        this.Parameters.Add(float.Parse(encoded.ReadBlock()));
                        this.Parameters.Add(float.Parse(encoded.ReadBlock()));
                        this.Parameters.Add(float.Parse(encoded.ReadBlock()));
                        this.Parameters.Add(float.Parse(encoded.ReadBlock()));
                        this.Parameters.Add(float.Parse(encoded.ReadBlock()));
                        this.Parameters.Add(float.Parse(encoded.ReadBlock()));
                    }
                    catch
                    {
                        return (Func)null;
                    }
                    goto case 2;
                default:
                    return (Func)null;
            }
        }

        public static int GetParamNum(int type)
        {
            switch (type)
            {
                case 0:
                case 1:
                case 3:
                case 16:
                case 17:
                case 19:
                case 20:
                case 21:
                case 23:
                case 25:
                case 26:
                    return 1;
                case 2:
                case 4:
                case 8:
                case 22:
                    return 0;
                case 18:
                case 24:
                    return 2;
                case 28:
                    return 6;
                default:
                    return -1;
            }
        }

        public DataStream SerializeFunc()
        {
            DataStream dataStream = new DataStream().Write(this.Parameters[0]);
            switch (this.Type)
            {
                case 0:
                case 1:
                case 3:
                case 16:
                case 17:
                case 19:
                case 20:
                case 21:
                case 23:
                case 25:
                case 26:
                case 27:
                    dataStream.Write(this.Parameters[1]);
                    break;
                case 18:
                case 24:
                    dataStream.Write(this.Parameters[1]);
                    dataStream.Write(this.Parameters[2]);
                    break;
                case 28:
                    dataStream.Write(this.Parameters[1]);
                    dataStream.Write(this.Parameters[2]);
                    dataStream.Write(this.Parameters[3]);
                    dataStream.Write(this.Parameters[4]);
                    dataStream.Write(this.Parameters[5]);
                    dataStream.Write(this.Parameters[6]);
                    break;
            }
            return dataStream;
        }
    }
}
