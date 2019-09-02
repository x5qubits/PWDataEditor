using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringExtension
{
    public static string GetBetween(this string text, string first, string second)
    {
        int beginIndex = text.IndexOf(first); // find occurence of left delimiter
        if (beginIndex == -1)
            return text; // or throw exception?

        beginIndex += first.Length;

        int endIndex = text.IndexOf(second, beginIndex); // find occurence of right delimiter
        if (endIndex == -1)
            return text; // or throw exception?

        return text.Substring(beginIndex, endIndex - beginIndex).Trim();
    }
    public static string GetNumbers(this string input)
    {
        return new string(input.Where(c => char.IsDigit(c)).ToArray());
    }
    public static string[] CleanArray(this string[] test)
    {
        return test.Where(x => !string.IsNullOrEmpty(x)).ToArray();
    }
}

