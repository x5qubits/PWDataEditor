using ElementEditor;
using ElementEditor.classes;
using PWDataEditorPaied.Properties;
using PWDataEditorPaied.PW_Admin_classes;
using sTASKedit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied
{
    public class AssetManager
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar;
        private SortedList<int, int> item_color;
        private int rows;
        private Bitmap sourceBitmap;
        private CacheSave database = new CacheSave();
        private bool firstLoad = true;
        private int cols;
        private SortedList<int, string> imagesx;
        private SortedList<string, Point> imageposition;
        private SortedList<int, string> item_desc;
        
        public static object anydata;




        


    }
}
