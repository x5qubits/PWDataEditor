using System;
using System.Collections.Generic;
using PWDataEditorPaied.PW_Admin_classes;
using System.Drawing;
using System.Drawing.Imaging;
using PWDataEditorPaied.Properties;
using ElementEditor.Element_Editor_Classes;
using System.Collections;
using PWDataEditorPaied.Classes;

namespace PWDataEditorPaied.Database
{
    [Serializable]
    public class Session
    {
        public Session()
        {
            rows = 0;
            cols = 0;
            item_color = new SortedList<int, int>();
            item_desc = new SortedList<int, string>();
            task_recipes = new SortedList<int, ItemDupe>();
            task_items = new SortedList<int, ItemDupe>();
            monsters_npcs_mines = new SortedList();
            titles = new SortedList();
            homeitems = new SortedList();
            InstanceList = new SortedList<int, Map>();
            addonslist = new SortedList<string, string>();
            LocalizationText = new SortedList<string, string>();
            defaultMapsTemplate = new SortedList<int, Map>();
            gshopSurfaces = new string[0];
            hasJustBecomeReady = isredyC2 = isredyC1 = false;
        }

       
        public bool started = false;
        public bool ContainsKey(string path)
        {
            return InconPacker.Instance.getIcon(path) != null;
        }
        public Bitmap images(string name)
        {
            return InconPacker.Instance.getIcon(name).icon;
        }

        public Point GetPoint(string name)
        {
            if(ContainsKey(name))
            {
                return InconPacker.Instance.getIcon(name).Location;
            }
            return new Point(0,0);
        }

        public int rows { get; set; }
        public int cols { get; set; }
        public SortedList<int, int> item_color { get; set; }
        public SortedList<int, string> item_desc { get; set; }
        public SortedList<int, ItemDupe> task_recipes { get; set; }
        public SortedList<int, ItemDupe> task_items { get; set; }
        public string[] _task_items_list { get; set; }
        public string[] task_items_list { get
            {

                if (Version > 191)
                    return task_items_list191;
                else
                    return _task_items_list;
            }
            set
            {
                if (Version > 191)
                    task_items_list191 = value;
                else
                    _task_items_list = value;
            }
        }
        public string[] task_items_list191 { get; set; }
        public SortedList monsters_npcs_mines { get; set; }
        public SortedList titles { get; set; }
        public SortedList homeitems { get; set; }
        public SortedList<int, Map> InstanceList { get; set; }
        public string[] buff_str { get; set; }
        public string[] skillstr { get; set; }
        public string[] world_targets { get; set; }
        public SortedList<string, string> addonslist { get; set; }
        public SortedList<string, string> LocalizationText { get; set; }
        public SortedList<int, Map> defaultMapsTemplate { get; set; }
        public bool Isready
        {
            get
            {
                return isredyC1 && isredyC2;
            }
        }
        public bool isredyC1 = false;
        public bool isredyC2 = false;
        public bool hasJustBecomeReady = false;
        public int Version = 0;
        public string[] gshopSurfaces;

        public void Clear()
        {
           // foreach(KeyValuePair<string, Bitmap> aaa in imagesChache)
           // {
           //     aaa.Value.Dispose();
           // }
            hasJustBecomeReady = isredyC2 = isredyC1 = false;
            InconPacker.Instance.Clear();
            rows = 0;
            cols = 0;
            //imagesx = new SortedList<int, string>();
           // imageposition = new SortedList<string, Point>();
            item_color = new SortedList<int, int>();
            item_desc = new SortedList<int, string>();
            task_recipes = new SortedList<int, ItemDupe>();
            task_items = new SortedList<int, ItemDupe>();
            monsters_npcs_mines = new SortedList();
            titles = new SortedList();
            homeitems = new SortedList();
            InstanceList = new SortedList<int, Map>();
            addonslist = new SortedList<string, string>();
            LocalizationText = new SortedList<string, string>();
            defaultMapsTemplate = new SortedList<int, Map>();
            gshopSurfaces = new string[0];
        }
    }
}
