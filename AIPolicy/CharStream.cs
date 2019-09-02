using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIPolicy
{
    public class CharStream
  {
    private char[] buffer;

    private int Position { get; set; }

    private int Length { get; set; }

    public CharStream(string s)
    {
      this.buffer = Enumerable.ToArray<char>((IEnumerable<char>) s);
      this.Length = s.Length;
      this.Position = 0;
    }

    public char Read()
    {
      if (this.Position == this.Length)
        throw new IndexOutOfRangeException();
      return this.buffer[this.Position++];
    }

    public string Read(int len)
    {
      if (len > this.Length - this.Position)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < len; ++index)
        stringBuilder.Append(this.Read());
      return stringBuilder.ToString();
    }

    public string ReadUntil(char c)
    {
      StringBuilder stringBuilder = new StringBuilder();
      char ch;
      while (this.Position != this.Length && (int) (ch = this.Read()) != (int) c)
        stringBuilder.Append(ch);
      --this.Position;
      return stringBuilder.ToString();
    }

    public string ReadBlock()
    {
      char c = this.Read();
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.ReadUntil(c));
      return stringBuilder.ToString();
    }
  }
}
