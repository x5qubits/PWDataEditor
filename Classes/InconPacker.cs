using DevIL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Classes
{
    public class InconPacker
    {
        public int cols = 128;
        public int rows;
        public string currentImagePath;
        public string currentTextPath;
        private Dictionary<string, GeneralIcon> currentIcons = new Dictionary<string, GeneralIcon>();
        private static InconPacker instance;
        private int w;
        private int h;

        public Bitmap sourceBitmap { get; set; }

        private InconPacker() { }

        public static InconPacker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InconPacker();
                }
                return instance;
            }
        }

        public class GeneralIcon
        {
            public int Index;
            public string name;
            public Point Location;
            public Bitmap icon;
        }

        public GeneralIcon getIcon(string path)
        {
            GeneralIcon ret = null;
            currentIcons.TryGetValue(path, out ret);
            return ret;
        }

        public GeneralIcon GetIconAtPoint(Point point)
        {
            GeneralIcon ret = currentIcons.Values.FirstOrDefault(x => x.Location.Equals(point));
            return ret;
        }

        public bool LoadFiles(string path, bool ovveride = false)
        {
            if(!ovveride)
            {
                Clear();
            }
            try
            {
                currentImagePath = path;
                currentTextPath = path.Replace(".dds", ".txt");
                if (File.Exists(currentImagePath) && File.Exists(currentTextPath))
                {
                    using (MemoryStream iconlist_ivtrm_img_ms = new MemoryStream(File.ReadAllBytes(currentImagePath)))
                    {
                        using (MemoryStream iconlist_ivtrm_txt_ms = new MemoryStream(File.ReadAllBytes(currentTextPath)))
                        {
                            using (DevIL.ImageImporter imImport = new DevIL.ImageImporter())
                            {
                                sourceBitmap = LoadImage(imImport, iconlist_ivtrm_img_ms);
                            }
                            if (sourceBitmap != null)
                            {
                                SortedList<String, Bitmap> results = new SortedList<String, Bitmap>();
                                List<Bitmap> zxczxc = new List<Bitmap>();
                                List<String> fileNames = new List<string>();
                                w = 0;
                                h = 0;
                                int counter = 0;
                                string line;
                                Encoding enc = Encoding.GetEncoding("GBK");
                                StreamReader file = new StreamReader(iconlist_ivtrm_txt_ms, enc);
                                while ((line = file.ReadLine()) != null)
                                {
                                    switch (counter)
                                    {
                                        case 0:
                                            w = Int32.Parse(line);
                                            break;
                                        case 1:
                                            h = Int32.Parse(line);
                                            break;
                                        case 2:
                                            rows = Int32.Parse(line);
                                            break;
                                        case 3:
                                            cols = Int32.Parse(line);
                                            break;
                                        default:
                                            fileNames.Add(line);
                                            break;
                                    }
                                    counter++;
                                }

                                int x, y = 0;
                                for (int i = 0; i < fileNames.Count; i++)
                                {
                                    y = i / cols;
                                    x = i - y * cols;
                                    x = x * w;
                                    y = y * h;
                                    try
                                    {
                                        GeneralIcon icon = new GeneralIcon();
                                        icon.name = fileNames[i];
                                        icon.Location = new Point(x, y);
                                        Bitmap pageBitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                                        using (Graphics graphics = Graphics.FromImage(pageBitmap))
                                        {
                                            graphics.DrawImage(sourceBitmap, new Rectangle(0, 0, w, h), new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                                        }
                                        icon.icon = pageBitmap;
                                        icon.Index = i;
                                        currentIcons[icon.name] = icon;
                                    }
                                    catch (Exception) { }
                                }

                            }
                        }

                    }
                  //  currentIcons = currentIcons.OrderBy(u => u.Value.Index).ToDictionary(z => z.Key, y => y.Value);
                    return true;

                }
            }
            catch { }

            return false;
        }

        public bool saveImage(string fileName)
        {
            try
            {
                string txtFile = fileName.Replace(".dds", ".txt");
                string txtFilepng = fileName.Replace(".dds", ".png");
                try
                {
                    File.Delete(fileName);
                }

                catch { }
                GeneralIcon[] array = currentIcons.Values.ToArray();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(w.ToString());
                sb.AppendLine(h.ToString());
                int rrow = array.Length / cols;
                sb.AppendLine(rrow.ToString());
                sb.AppendLine(cols.ToString());
                int imageWidth = w * cols;
                using (Bitmap img = new Bitmap(imageWidth, imageWidth, PixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(img))
                    {
                        int x, y = 0;

                        for (int i = 0; i < array.Length; i++)
                        {
                            GeneralIcon icon = array[i];
                            y = i / cols;
                            x = i - y * cols;
                            x = x * w;
                            y = y * h;
                            graphics.DrawImage(icon.icon, x, y);
                            sb.AppendLine(icon.name);
                        }
                    }
                    using (DevIL.ImageImporter ImImport = new DevIL.ImageImporter())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            using (DevIL.Image IconImg = ImImport.LoadImageFromStream(new MemoryStream(ms.ToArray())))
                            {
                                IconImg.Bind();
                                ImageExporter exporter = new ImageExporter();
                                exporter.SaveImage(IconImg, ImageType.Dds, fileName);
                            }
                        }
                    }
                    
                    File.WriteAllText(txtFile, sb.ToString(), Encoding.GetEncoding("GBK"));
                }
                Remake();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private int index = -1;
        private string last = "";
        public GeneralIcon getByAproximation(string text)
        {
            if (index >= currentIcons.Values.Count)
                index = -1;

            if (text != last)
            {
                index = -1;
                last = text;
            }
            
            GeneralIcon ret = currentIcons.Values.FirstOrDefault(x => x.name.ToLower().Trim().Contains(text.ToLower().Trim()) && x.Index > index);
            if (ret != null)
                index = ret.Index;

            return ret;
        }
        public void Remake()
        {
            int imageWidth = w * cols;
            GeneralIcon[] array = currentIcons.Values.ToArray();
            using (Bitmap img = new Bitmap(imageWidth, imageWidth, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(img))
                {
                    int x, y = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        GeneralIcon iconx = array[i];
                        y = i / cols;
                        x = i - y * cols;
                        x = x * w;
                        y = y * h;
                        iconx.Location = new Point(x,y);
                        graphics.DrawImage(iconx.icon, x, y);
                    }
                }
                sourceBitmap = (Bitmap)img.Clone();
            }
        }

        public GeneralIcon addFile(string fileName)
        {
            try
            {
                Bitmap bitmax = new Bitmap(new MemoryStream(File.ReadAllBytes(fileName)));
                if (bitmax != null)
                {
                    int i = currentIcons.Count + 1;
                    int y = i / cols;
                    int x = i - y * cols;
                    x = x * w;
                    y = y * h;
                    GeneralIcon icon = new GeneralIcon();
                    icon.name = i.ToString() + ".dds";
                    icon.Location = new Point(x, y);
                    icon.icon = new Bitmap((Bitmap)bitmax.Clone(), w, h);
                    icon.Index = i;
                    currentIcons[icon.name] = icon;
                    Remake();
                    return currentIcons[icon.name];
                }
            }
            catch { }
            return null;

        }

        public bool Delete(GeneralIcon icon)
        {
            if (icon != null && currentIcons.ContainsKey(icon.name))
            {
                currentIcons.Remove(icon.name);
                Remake();
                return true;
            }

            return false;
        }

        public void setName(GeneralIcon icon, string text)
        {
            if (icon != null && currentIcons.ContainsKey(icon.name))
                currentIcons[icon.name].name = text;
        }

        public Bitmap LoadImage(DevIL.ImageImporter ImImport, MemoryStream mStream, int width = 128, int height = 128)
        {
            try
            {
                Bitmap img2 = null;
                using (DevIL.Image IconImg = ImImport.LoadImageFromStream(mStream))
                {
                    IconImg.Bind();
                    using (var img = new Bitmap(IconImg.Width, IconImg.Height, PixelFormat.Format32bppArgb))
                    {
                        Rectangle rect = new Rectangle(0, 0, IconImg.Width, IconImg.Height);
                        BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                        DevIL.Unmanaged.IL.CopyPixels(0, 0, 0, IconImg.Width, IconImg.Height, 1, DevIL.DataFormat.BGRA, DevIL.DataType.UnsignedByte, data.Scan0);
                        img.UnlockBits(data);
                        img2 = (Bitmap)img.Clone();
                    }
                }
                return img2;
            }
            catch
            {
                return new Bitmap(width, height);
            }

        }


        public void Clear()
        {
            sourceBitmap = null;
            currentIcons = new Dictionary<string, GeneralIcon>();
        }
    }
}
