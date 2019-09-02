using System;
using System.Text;

namespace DomainEditors
{
    [Serializable]
    internal class Unicode
    {
        public byte[] data { get; private set; }

        public Unicode(byte[] data)
        {
            this.data = data;
        }

        public override string ToString()
        {
          return Encoding.GetEncoding("Unicode").GetString(this.data).Split('\0')[0];

        }

        public void Set(string name)
        {
            byte[] bytes = Encoding.GetEncoding("Unicode").GetBytes(name);
            Buffer.BlockCopy(bytes, 0, this.data, 0, bytes.Length);
        }

        public bool Contains(string name)
        {
            return this.ToString().ToLower().Contains(name.ToLower());
        }
    }
}
