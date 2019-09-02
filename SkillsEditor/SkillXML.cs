using System.Collections.Generic;
using System.Globalization;

namespace SkillXMLEditor
{
    public class SkillXML
    {
        public List<Skill> Read(string input)
        {
            List<Skill> list = new List<Skill>();
            try
            {
                int num1 = 0;
                int num2 = this.ConvertToInt(input.Substring(0, 8));
                for (int index = 0; index < num2; ++index)
                {
                    Skill skill = new Skill();
                    int num3;
                    skill.id = this.ConvertToInt(input.Substring(num3 = num1 + 8, 8));
                    int num4 = num3 + 8;
                    skill.lvl = this.ConvertToInt(input.Substring(num1 = num4 + 8, 8));
                    list.Add(skill);
                }
            }
            catch { }
            return list;
        }

        public string Save(List<Skill> skills)
        {
            string str = "" + this.ConvertToHex(skills.Count);
            for (int index = 0; index < skills.Count; ++index)
                str = str + this.ConvertToHex(skills[index].id) + "00000000" + this.ConvertToHex(skills[index].lvl);
            return str.ToLower();
        }

        public int ConvertToInt(string input)
        {
            string str1 = input.Substring(0, 2);
            string str2 = input.Substring(2, 2);
            string str3 = input.Substring(4, 2);
            return int.Parse(input.Substring(6, 2) + str3 + str2 + str1, NumberStyles.HexNumber);
        }

        public string ConvertToHex(int input)
        {
            string str1 = input.ToString("X8");
            string str2 = str1.Substring(0, 2);
            string str3 = str1.Substring(2, 2);
            string str4 = str1.Substring(4, 2);
            return str1.Substring(6, 2) + str4 + str3 + str2;
        }
    }
}