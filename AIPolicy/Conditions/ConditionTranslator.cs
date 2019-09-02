using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIPolicy.Conditions
{
  internal static class ConditionTranslator
  {
    private static string LastMessage { get; set; }

    public static string TranslateCondition(string text)
    {
      if (Enumerable.Contains(text, '@'))
      {
        ConditionTranslator.LastMessage = "Input contains invalid characters.";
        return null;
      }
      text = ConditionTranslator.FixMissingSpaces(text).Trim();
      if (Enumerable.Count(text, x => (int)x == 40) != Enumerable.Count(text, x => (int)x == 41))
      {
        ConditionTranslator.LastMessage = "Uneven amount of open and closed brackets.";
        return null;
      }
      if (text.Length == 0)
        return "@3@1.0";
      text = ConditionTranslator.ReplaceFunctions(text);
      if (text == null)
        return null;
      return ConditionTranslator.TranslateCondition(ConditionTranslator.GetWords(text), 0, (string) null);
    }

    private static string ReplaceFirst(string text, string search, string replace)
    {
      int length = text.IndexOf(search, StringComparison.OrdinalIgnoreCase);
      if (length < 0)
        return text;
      return text.Substring(0, length) + replace + text.Substring(length + search.Length);
    }

    private static string ReplaceFunctions(string p)
    {
      foreach (string str in Enum.GetNames(typeof (Condition.Name)))
      {
        int num = 0;
        int type = (int) Enum.Parse(typeof (Condition.Name), str);
        while (num != -1)
        {
          string replace = "@" + (object) type;
          num = p.IndexOf(str, StringComparison.OrdinalIgnoreCase);
          if (num != -1)
          {
            if ((int) p[num + str.Length] != 40)
            {
              ConditionTranslator.LastMessage = "Expected a '(' after " + str;
              break;
            }
            string s = p.Substring(num + str.Length + 1).Split(')')[0];
            if (ConditionTranslator.GetWords(s).Length != 0)
            {
              string[] strArray = s.Split(',');
              if (strArray.Length != Func.GetParamNum(type))
              {
                ConditionTranslator.LastMessage = "Invalid amount of parameters in function " + str;
                return (string) null;
              }
              for (int index = 0; index < strArray.Length; ++index)
              {
                string[] words;
                if ((words = ConditionTranslator.GetWords(strArray[index])).Length != 1)
                {
                  ConditionTranslator.LastMessage = string.Concat(new object[4]
                  {
                    (object) "Bad parameter in function ",
                    (object) str,
                    (object) " at place ",
                    (object) (index + 1)
                  });
                  return (string) null;
                }
                strArray[index] = words[0];
              }
              if (type == 1 || type == 3)
              {
                float result;
                if (!float.TryParse(strArray[0], out result))
                {
                  ConditionTranslator.LastMessage = "Bad parameter in function " + str + " at place 1";
                  return (string) null;
                }
                replace = replace + "@" + (Single) result;
              }
              else
              {
                for (int index = 0; index < strArray.Length; ++index)
                {
                  int result;
                  if (!int.TryParse(strArray[index], out result))
                  {
                    ConditionTranslator.LastMessage = string.Concat(new object[4]
                    {
                       "Bad parameter in function ",
                       str,
                       " at place ",
                       index + 1
                    });
                    return null;
                  }
                  replace = replace + "@" + (int) result;
                }
              }
            }
            p = ConditionTranslator.ReplaceFirst(p, string.Concat(new object[4]
            {
               str,
               '(',
               s,
               ')'
            }), replace);
          }
        }
      }
      return p;
    }

    private static string GetSign(string s)
    {
      if (s.Length > 2)
        return (string) null;
      char ch = s[0];
      if (s.Length == 1)
      {
        switch (ch)
        {
          case '*':
            return "@11";
          case '+':
            return "@9";
          case '-':
            return "@10";
          case '/':
            return "@12";
          case '<':
            return "@14";
          case '>':
            return "@13";
        }
      }
      if ((int) ch == 38 && (int) s[1] == 38)
        return "@7";
      if ((int) ch == 124 && (int) s[1] == 124)
        return "@6";
      if ((int) ch == 61 && (int) s[1] == 61)
        return "@15";
      if ((int) ch == 33 && (int) s[1] == 61)
        return "@5";
      return (string) null;
    }

    private static string TranslateCondition(string[] words, int index, string prev)
    {
      string s1 = words[index++];
      string str1 = "";
      while ((int) s1[0] == 33)
      {
        s1 = words[index - 1] = s1.Substring(1);
        str1 += "@5";
      }
      if (s1 == "-")
        s1 = words[index - 1] = s1 + words[index];
      string str2 = (int) s1[0] != 40 || (int) s1[s1.Length - 1] != 41 ? str1 + ConditionTranslator.GetFunc(s1) : str1 + ConditionTranslator.TranslateCondition(ConditionTranslator.GetWords(s1.Substring(1, s1.Length - 2)), 0, (string) null);
      if (str2 == null)
        return (string) null;
      if (index >= words.Length - 1)
        return prev == null ? str2 : prev + str2;
      string s2 = ConditionTranslator.GetSign(words[index++]);
      if (s2 == null)
      {
        ConditionTranslator.LastMessage = "Expected an operator.";
        return (string) null;
      }
      int num1 = ConditionTranslator.CondType(s2);
      if (num1 == 5)
        s2 = "@5" + ConditionTranslator.GetSign("==");
      if (prev == null)
        return ConditionTranslator.TranslateCondition(words, index, s2 + str2);
      int num2 = ConditionTranslator.CondType(prev);
      switch (num1)
      {
        case 5:
        case 13:
        case 14:
        case 15:
          if (num2 == 6 || num2 == 7)
            return ConditionTranslator.TranslateCondition(words, index, prev + s2 + str2);
          if (num2 > 7 && num2 < 13)
            return ConditionTranslator.TranslateCondition(words, index, s2 + prev + str2);
          return (string) null;
        case 6:
        case 7:
          if (num2 > 4 && num2 < 8 || num2 > 12 && num2 < 16)
            return ConditionTranslator.TranslateCondition(words, index, s2 + prev + str2);
          return (string) null;
        case 9:
        case 10:
          if (num2 == 5 || num2 == 9 || num2 == 10 || num2 > 12 && num2 < 16)
            return ConditionTranslator.TranslateCondition(words, index, prev + s2 + str2);
          if (num2 == 11 || num2 == 12)
            return ConditionTranslator.TranslateCondition(words, index, s2 + prev + str2);
          return (string) null;
        case 11:
        case 12:
          if (num2 == 5 || num2 > 8 && num2 < 16)
            return ConditionTranslator.TranslateCondition(words, index, prev + s2 + str2);
          return (string) null;
        default:
          return (string) null;
      }
    }

    public static int CondType(string s)
    {
      return int.Parse(s.Split('@')[1]);
    }

    private static string GetFunc(string s)
    {
      if ((int) s[0] == 64)
        return s;
      int result;
      if (!int.TryParse(s, out result))
        return (string) null;
      return "@17@" + (object) result;
    }

    private static string[] GetWords(string s)
    {
      List<string> list = new List<string>();
      int index = 0;
label_16:
      if (index >= s.Length)
        return list.ToArray();
      StringBuilder stringBuilder = new StringBuilder();
      if ((int) s[index] != 32)
      {
        for (; index < s.Length && (int) s[index] != 32; stringBuilder.Append(s[index++]))
        {
          if ((int) s[index] == 40)
          {
            --index;
            int num1 = 0;
            int num2 = 0;
            while (++index < s.Length)
            {
              if ((int) s[index] == 40)
                ++num1;
              else if ((int) s[index] == 41)
                ++num2;
              if (num1 != num2)
                stringBuilder.Append(s[index]);
              else
                break;
            }
          }
        }
        list.Add(stringBuilder.ToString());
      }
      while (++index < s.Length && (int) s[index] == 32)
        ;
      goto label_16;
    }

    private static string ReadNextWord(string text, int index)
    {
      while (index < text.Length && (int) text[index] == 32)
        ++index;
      StringBuilder stringBuilder = new StringBuilder();
      for (; index < text.Length && (int) text[index] != 32; ++index)
        stringBuilder.Append(text[index]);
      return stringBuilder.ToString();
    }

    private static string FixMissingSpaces(string s)
    {
      return s.Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("<", " < ").Replace(">", " > ").Replace("==", " == ").Replace("!=", " != ").Replace("&&", " && ").Replace("||", " || ");
    }

    public static string GetLastError()
    {
      return ConditionTranslator.LastMessage;
    }
  }
}
