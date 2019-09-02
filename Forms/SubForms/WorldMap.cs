using JHUI;
using JHUI.Forms;
using PWDataEditorPaied.Classes;
using PWDataEditorPaied.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied.Forms.SubForms
{
    public partial class WorldMap : JForm
    {
        internal delegate void OnMouseDown(float x, float y);
        internal event OnMouseDown mouseDown;

        private ConfigStr currentConfig;
        private Bitmap currentImage;
        private bool Loaded = false;
        private Dictionary<string, ConfigStr> configs = new Dictionary<string, ConfigStr>();
        private string pathToFiles;
        private string pathToConfigs;
        private PointF[] points;
        private bool autoSlected;

        public string FilePath { get; private set; }

        public WorldMap(string FilePath, bool AutoCalculatePath = true)
        {
            InitializeComponent();
            if (AutoCalculatePath)
            {
                this.FilePath = FilePath.ToLower().GetBetween("maps", "region.clt").GetBetween("maps", "precinct.clt").GetBetween("maps", "world_targets.txt");
            }
            else
            {
                this.FilePath = FilePath;
            }
            
        }

        private void LoadConfigs()
        {
            pathToConfigs = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\minimaps\\";

            try
            {
                string[] configcontent = File.ReadAllLines(pathToConfigs + "config.txt");
                foreach (string line in configcontent)
                {
                    if (!line.StartsWith("#"))
                    {
                        ConfigStr cfg = new ConfigStr();
                        string[] split = line.Split('@');
                        cfg.GridSize = int.Parse(split[1]);
                        cfg.ImageXoffset = int.Parse(split[2]);
                        cfg.ImageYoffset = int.Parse(split[3]);
                        cfg.rows = int.Parse(split[5]);
                        cfg.cols = int.Parse(split[4]);
                        cfg.ImageSize = int.Parse(split[6]);
                        cfg.rowsStart = int.Parse(split[7]);
                        cfg.colsStart = int.Parse(split[8]);
                        configs.Add(split[0].ToLower().Trim(), cfg);
                    }

                }
            }
            catch { JMessageBox.Show(this, "Unable to load config:" + pathToConfigs); return; }
            if(FilePath != null)
            {
                LoadMap(FilePath);
            }
        }

        private void LoadMap(string mapName)
        {
            pathToFiles = Path.Combine(mapName, pathToConfigs);
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9-]");
                string key = rgx.Replace(mapName, "").ToLower().Trim();
                if (configs.ContainsKey(key))
                {
                    currentConfig = configs[key];
                    currentImage = new Bitmap(currentConfig.rows * currentConfig.ImageSize, currentConfig.cols * currentConfig.ImageSize);
                    using (Graphics g = Graphics.FromImage(currentImage))
                    {
                        for (int col = 0; col < currentConfig.cols; col++)
                        {
                            for (int row = 0; row < currentConfig.rows; row++)
                            {

                                    string imageName = Path.Combine(pathToFiles + key, (col + currentConfig.colsStart).ToString("D2") + (row + currentConfig.rowsStart).ToString("D2") + ".dds");
                                    int x = currentConfig.ImageSize * (row + currentConfig.rowsStart);
                                    int y = currentConfig.ImageSize * (col + currentConfig.colsStart);
                                try
                                {
                                    using (DevIL.ImageImporter imImport = new DevIL.ImageImporter())
                                    {
                                        g.DrawImage(LoadImage(imImport, new MemoryStream(File.ReadAllBytes(imageName)), currentConfig.ImageSize, currentConfig.ImageSize), x, y, currentConfig.ImageSize, currentConfig.ImageSize);
                                    }
                                }
                                catch {

                                    g.DrawImage(new Bitmap(currentConfig.ImageSize, currentConfig.ImageSize), x, y, currentConfig.ImageSize, currentConfig.ImageSize);
                                }
                            }
                        }

                    }
                    pictureBox_path.Width = currentConfig.rows * currentConfig.ImageSize;
                    pictureBox_path.Height = currentConfig.cols * currentConfig.ImageSize;

                    pictureBox_path.BackgroundImage = currentImage;
                    pictureBox_path.Refresh();
                    comboBox_lists.Items.Clear();
                    foreach (string map in configs.Keys)
                    {
                        comboBox_lists.Items.Add(map);
                    }
                    autoSlected = true;
                    comboBox_lists.SelectedIndex = comboBox_lists.FindString(key);
                    autoSlected = false;
                    Loaded = true;
                }
                else
                {
                    JMessageBox.Show(this, "Unable to load images for :" + mapName + ".\rWill not continue without graphic suport!");
                    return;
                }
            }
            catch(Exception e) { JMessageBox.Show(this, "Unable to load config:" + e.ToString()); return; }
        }

        internal void DrawPoligonWithSelectedPoint(object last_index, object points, bool v)
        {
            throw new NotImplementedException();
        }

        private void pictureBox_path_MouseDown(object sender, MouseEventArgs e)
        { 
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > -1 && e.X < pictureBox_path.BackgroundImage.Width && e.Y > -1 && e.Y < pictureBox_path.BackgroundImage.Height)
                {
                    float x = (e.X - (pictureBox_path.BackgroundImage.Width / 2));
                    float y = (-(e.Y) + (pictureBox_path.BackgroundImage.Height / 2));
                    float fxx = x * currentConfig.GridSize - currentConfig.ImageXoffset;
                    float fyy = y * currentConfig.GridSize - currentConfig.ImageYoffset;
                    mouseDown(fxx, fyy);
                }
            }
        }

        private void pictureBox_path_MouseMove(object sender, MouseEventArgs e)
        {
            if (Loaded)
            {
                if (e.X > -1 && e.X < pictureBox_path.BackgroundImage.Width && e.Y > -1 && e.Y < pictureBox_path.BackgroundImage.Height)
                {
                    float x = (e.X - (pictureBox_path.BackgroundImage.Width / 2));
                    float y = (-(e.Y) + (pictureBox_path.BackgroundImage.Height / 2));
                    float fx = x * currentConfig.GridSize - currentConfig.ImageXoffset;
                    float fy = y * currentConfig.GridSize - currentConfig.ImageYoffset;
                    string text = "X: " + fx.ToString("F1") + "\nZ: " + fy.ToString("F1");
                    text += "\n eX: " + e.X + "\neZ: " + e.Y;
                    if (text != toolTip.GetToolTip(pictureBox_path))
                    {
                        toolTip.SetToolTip(pictureBox_path, text);
                    }
                }
            }
        }

        private void pictureBox_path_MouseUp(object sender, MouseEventArgs e)
        {

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

        public void ScrollTo(PointF point)
        {
            
            if (!Loaded)
                return;

            panel_path.VerticalJScrollbar.Value = Convert.ToInt32(point.Y - (panel_path.ClientSize.Width / 2) + (panel_path.ClientSize.Width / 4));
            panel_path.HorizontalJScrollbar.Value = Convert.ToInt32(point.X - (panel_path.ClientSize.Width / 2));
        }

        public void DrawPoligonWithSelectedPoint(int index, PointF[] pointsIn, bool scroolto)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    DrawPoligonWithSelectedPoint(index, points, scroolto);
                }));
                return;
            }

            if (Loaded && pointsIn != null && pointsIn.Length > 0)
            {
                points = new PointF[pointsIn.Length];
                for (int i = 0; i < pointsIn.Length; i++)
                {
                    float x = (pointsIn[i].X + currentConfig.ImageXoffset) / currentConfig.GridSize;
                    float fx = x + (pictureBox_path.BackgroundImage.Width / 2);
                    float y = (pointsIn[i].Y + currentConfig.ImageYoffset) / currentConfig.GridSize;
                    float fy = -(y) + (pictureBox_path.BackgroundImage.Height / 2);
                    points[i] = new PointF(fx, fy);
                }

                pictureBox_path.Image = new Bitmap(pictureBox_path.Width, pictureBox_path.Height);
                Pen blackPen = new Pen(Color.Black, 2);
                Color clearColor = Color.FromArgb(0, 0, 0, 0);
                Graphics g = Graphics.FromImage(pictureBox_path.Image);
                g.Clear(clearColor);
                Pen path = new Pen(Color.Red);
                g.DrawPolygon(path, points);
                for (int i = 0; i < points.Length; i++)
                {
                    if (i == index)
                    {
                        g.DrawCircle(new Pen(Color.Green, 4), points[i].X, points[i].Y, 4);
                    }
                    else
                        g.DrawCircle(new Pen(Color.Red, 2), points[i].X, points[i].Y, 2);
                }
                if (index == 0 || index == points.Length)
                {
                    g.DrawCircle(new Pen(Color.Green, 4), points[0].X, points[0].Y, 4);
                    g.DrawCircle(new Pen(Color.Green, 4), points[points.Length - 1].X, points[points.Length - 1].Y, 4);
                }
                
                g.Dispose();

                try
                {
                    if (scroolto)
                        ScrollTo(points[index]);
                }
                catch { }
            }
            
        }

        private void comboBox_lists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loaded || autoSlected)
                return;

            if (comboBox_lists.SelectedIndex != -1)
            {
                LoadMap(comboBox_lists.Items[comboBox_lists.SelectedIndex].ToString());
            }
        }

        private void WorldMap_Shown(object sender, EventArgs e)
        {
            LoadConfigs();
        }
    }
}
