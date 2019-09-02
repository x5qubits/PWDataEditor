// Decompiled with JetBrains decompiler
using AIPolicy.Operations;
using System;
using System.IO;

namespace AIPolicy
{
  internal static class FileManager
  {
    public static AI LoadAI(string filename)
    {
      try
      {
        return new AI().Deserialize(new DataStream(File.ReadAllBytes(filename)));
      }
      catch
      {
        return (AI) null;
      }
    }

    public static void ImportText(AI dest, string path)
    {
      string[] strArray1 = File.ReadAllLines(path);
      int num1 = 0;
      int num2 = 0;
      foreach (string str in strArray1)
      {
        if (str.Length > 2)
        {
          string[] strArray2 = str.Split(new string[1]
          {
            " - "
          }, StringSplitOptions.None);
          int ID = int.Parse(strArray2[0]);
          if (ID != num1)
            num2 = 0;
          num1 = ID;
          Policy policy = dest.FindPolicy(ID);
          int num3 = 0;
          for (int index1 = 0; index1 < policy.Count; ++index1)
          {
            Trigger trigger = policy.Triggers[index1];
            for (int index2 = 0; index2 < trigger.Count; ++index2)
            {
              Operation operation = trigger.Operations[index2];
              if (operation.Type == 2 && num3++ >= num2)
              {
                operation.Parameters[0] = (object) ((strArray2[1].Length + 1) * 2);
                operation.Parameters[1] = (object) (strArray2[1] + (object) char.MinValue);
                goto label_12;
              }
            }
          }
label_12:
          ++num2;
        }
      }
      dest.Serialize().Dump("aipolicy.data");
    }
  }
}
