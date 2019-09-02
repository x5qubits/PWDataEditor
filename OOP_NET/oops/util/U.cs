using Shield.classes.oops.iNotif;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Shield.classes.oops
{
    public static class U
    {
        internal static string r(byte[] xorname)
        {

            byte[] result = new byte[xorname.Length];
            for (int i = 0; i < xorname.Length; i++)
            {
                result[i] = (byte)(xorname[i] ^ HeartBeat.x);
            }
            return System.Text.Encoding.UTF8.GetString(result);
        }

        internal static byte[] x(byte[] xorname)
        {
            byte[] result = new byte[xorname.Length];
            for (int i = 0; i < xorname.Length; i++)
            {
                result[i] = (byte)(xorname[i] ^ HeartBeat.x);
            }
            return result;
        }

        internal static string rx(byte[] xorname)
        {
            byte[] result = new byte[xorname.Length];
            for (int i = 0; i < xorname.Length; i++)
            {
                result[i] = (byte)(xorname[i] ^ 50);
            }
            return System.Text.Encoding.UTF8.GetString(result);
        }
    }
}
