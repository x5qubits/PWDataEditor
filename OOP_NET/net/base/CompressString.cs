using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.OOP_NET.net
{
    public class CompressString
    {
        private static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];
            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        // Base64
        public static string ZipBase64(string compress)
        {
            var bytes = Zip(compress);
            var encoded = Convert.ToBase64String(bytes, Base64FormattingOptions.None);
            return encoded;
        }

        public static string UnzipBase64(string compressRequest)
        {
            var bytes = Convert.FromBase64String(compressRequest);
            var unziped = Unzip(bytes);
            return unziped;
        }

        // Testing
        public static bool TestZip(String stringToTest)
        {
            byte[] compressed = Zip(stringToTest);
            String decompressed = Unzip(compressed);
            return stringToTest == decompressed;
        }
    }
}
