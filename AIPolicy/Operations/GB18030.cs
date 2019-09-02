using System;
using System.Text;

namespace AIPolicy.Operations
{
    [Serializable]
    public class GB18030
    {
        public byte[] data { get; set; }

        public GB18030(byte[] data)
        {
            this.data = data;
        }

        public GB18030()
        {

        }
        public override string ToString()
        {
            string @string = Encoding.GetEncoding("GB18030").GetString(this.data);
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < 128 && (int)@string[index] != 0; ++index)
                stringBuilder.Append(@string[index]);
            return stringBuilder.ToString();
        }

        public void Set(string name)
        {
            byte[] bytes = Encoding.GetEncoding("GB18030").GetBytes(name);
            Buffer.BlockCopy((Array)bytes, 0, (Array)this.data, 0, Math.Min(128, bytes.Length));
        }

        public bool Contains(string name)
        {
            return this.ToString().ToLower().Contains(name.ToLower());
        }
    }
}
