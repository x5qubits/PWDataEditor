using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SkillXMLEditor
{
    public class Skill
    {
        public int id { get; set; }
        public int lvl { get; set; }
        public string name { get; set; }
        public string img { get; set; }

        public Skill()
        {
        }

        public Skill(int id, string name, string img)
        {
            this.id = id;
            this.name = name;
            this.img = img;
        }
    }
}

