using System;
using System.Collections.Generic;
using System.Text;

namespace ElementEditor.classes
{
    [Serializable]
    public class SubTypeElement
    {
        public Dictionary<int, String> subtype = new Dictionary<int, string>();
        public Dictionary<int, String> majorType = new Dictionary<int, string>();
    }
}
