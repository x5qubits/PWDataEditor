using System;

namespace AIPolicy
{
    [Serializable]
    public class Parameter
    {
        private System.Type type { get; set; }

        private string name { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Type
        {
            get
            {
                return this.type.Name;
            }
        }

        public object Value { get; set; }

        public Parameter(object val, System.Type t, string name)
        {
            this.Value = val;
            this.type = t;
            this.name = name;
        }
    }
}
