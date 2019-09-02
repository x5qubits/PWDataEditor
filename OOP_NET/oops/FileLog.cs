using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharkShield.classes.oops
{
    public static class FileLog
    {
        public static void write(string msg)
        {
            File.AppendAllText("log.txt", msg + Environment.NewLine);
        }

    }
}
