using ElementEditor.Element_Editor_Classes;
using PWDataEditorPaied.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using PWDataEditorPaied.PW_Admin_classes;

namespace ElementEditor.classes
{

    public class CacheSave
    {
        public Bitmap sourceBitmap = null;
        public bool started = false;
        public SortedDictionary<string, Bitmap> imagesChache = new SortedDictionary<string, Bitmap>();

        public bool ContainsKey(string path)
        {
            return this.imageposition != null && this.imageposition.ContainsKey(path);
        }

        public Bitmap images(string name)
        {
           if(this.sourceBitmap != null)
           {
                if (this.imageposition.ContainsKey(name))
                {
                    if (imagesChache != null && this.imagesChache.ContainsKey(name))
                    {
                        return this.imagesChache[name];
                    }
                    int w = 32;
                    int h = 32;
                    Point d = imageposition[name];
                    Bitmap pageBitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                    using (Graphics graphics = Graphics.FromImage(pageBitmap))
                    {
                        graphics.DrawImage(sourceBitmap, new Rectangle(0, 0, w, h), new Rectangle(d.X, d.Y, w, h), GraphicsUnit.Pixel);
                    }
                    if(this.imagesChache == null || this.imagesChache != null && !this.imagesChache.ContainsKey(name))
                    {
                        this.imagesChache[name] = pageBitmap;
                    }
                    return pageBitmap;
                }

            }
            return new Bitmap(new Bitmap(Resources.blank));
        }

        public int rows = 0;
        public int cols = 0;
        public SortedList<int, String> imagesx = null;
        public SortedList<string, Point> imageposition = null;      
        public SortedList<int, int> item_color = null;
        public SortedList<int, string> item_desc = null;
        public SortedList<int, ItemDupe> task_recipes = null;
        public SortedList<int, ItemDupe> task_items = null;
        public string[] task_items_list = null;
        public SortedList monsters_npcs_mines = null;
        public SortedList titles = null;
        public SortedList homeitems = null;
        public SortedList InstanceList = null;
        public string[] buff_str = null;
        public string[] item_ext_desc = null;
        public string[] skillstr = null;
        public string[] world_targets = null;
        public SortedList addonslist = null;
        public SortedList LocalizationText = null;
        public SortedList<int, Map> defaultMapsTemplate = null;
    }
}
