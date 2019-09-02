using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD = System.Drawing;
using SDI = System.Drawing.Imaging;

namespace PWDataEditorPaied.Database
{
    public class SurfacesHandler
    {
        private bool allDone = false;
        private PCKFile SurfacesPCK = null;

        public List<string> Names { get; set; } = new List<string>();

        public bool PCKIsLoaded
        {
            get
            {
                return SurfacesPCK.IsLoaded;
            }
        }

        public SurfacesHandler(string path)
        {
            SurfacesPCK = new PCKFile();
            SurfacesPCK.LoadIndex(path);
        }

        public bool Loaded()
        {
            return allDone && PCKIsLoaded;
        }

        public void Search(string data = "百宝阁")
        {
            Names = new List<string>(SurfacesPCK.SearchFiles(data));
            allDone = true;
        }

        public SD.Bitmap LoadImage(DevIL.ImageImporter ImImport, MemoryStream mStream, int width = 128, int height = 128)
        {
            try
            {
                DevIL.Image IconImg = ImImport.LoadImageFromStream(mStream);
                IconImg.Bind();
                var img = new SD.Bitmap(IconImg.Width, IconImg.Height, SDI.PixelFormat.Format32bppArgb);
                SD.Rectangle rect = new SD.Rectangle(0, 0, IconImg.Width, IconImg.Height);
                SDI.BitmapData data = img.LockBits(rect, SDI.ImageLockMode.WriteOnly, SDI.PixelFormat.Format32bppArgb);
                DevIL.Unmanaged.IL.CopyPixels(0, 0, 0, IconImg.Width, IconImg.Height, 1, DevIL.DataFormat.BGRA, DevIL.DataType.UnsignedByte, data.Scan0);
                img.UnlockBits(data);
                return img;
            }
            catch
            {
                return new SD.Bitmap(width, height);
            }

        }

        public SD.Bitmap GetBitmap(string FileName, int width = 128, int height = 128, bool foreceResize = false)
        {
            if (!SurfacesPCK.IsLoaded) return new SD.Bitmap(width, height);
            try
            {
                string NameFound = (from n in Names where n.ToLower() == FileName.ToLower() select n).FirstOrDefault();
                if (string.IsNullOrEmpty(NameFound)) return new SD.Bitmap(width, height);

                byte[] imgData = SurfacesPCK.LoadFile(NameFound);
                if (imgData != null)
                {
                    using (MemoryStream mStream = new MemoryStream(imgData))
                    {
                        using (DevIL.ImageImporter imImport = new DevIL.ImageImporter())
                        {
                            SD.Bitmap returnx = LoadImage(imImport, mStream);
                            if (foreceResize)
                            {
                                SD.Bitmap resized = new SD.Bitmap(returnx, new SD.Size(returnx.Width / 4, returnx.Height / 4));
                                return resized;
                            }
                            else
                                return returnx;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new SD.Bitmap(width, height);
        }

        public SD.Bitmap GetBitmap(int NameIndex, int width = 128, int height = 128)
        {
            if (NameIndex >= Names.Count) return new SD.Bitmap(width, height);

            return GetBitmap(Names[NameIndex]);
        }
    }
}
