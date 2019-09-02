using JHUI.Forms;
using PWDataEditorPaied.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied.Forms.SubForms
{
    public partial class GshopImageView : JForm
    {
        private SortedList<int, ListViewItem> myCache = new SortedList<int, ListViewItem>(); //array to cache items for the virtual list
        private string[] files;
        public static string selectedItem = "";
        private string surface;
        private ImageList imageList;
        private int count;

        public GshopImageView()
        {
            InitializeComponent();
            GshopImageView.selectedItem = "";
            files = DatabaseManager.Instance.GetShopImageName();
            surface = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "Configs" + Path.DirectorySeparatorChar + "Gshop" + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar;
            imageList = new ImageList();
            imageList.ImageSize = new Size(90, 90);
            count = 0;
            listView1.LargeImageList = imageList;
            listView1.SmallImageList = imageList;
            listView1.StateImageList = imageList;
            listView1.VirtualListSize = files.Length;
        }

        private void jListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //check to see if the requested item is currently in the cache
            if(myCache.ContainsKey(e.ItemIndex))
            {
                e.Item = myCache[e.ItemIndex];
                return;
            }
               
            int x = e.ItemIndex;
            string _key = files[x];
            Bitmap img = DatabaseManager.Instance.getShopImage(surface + _key);
            imageList.Images.Add(x.ToString(), img);
            listView1.LargeImageList = imageList;
            //imageList.Images[x] = img;
            e.Item = new ListViewItem();
           // e.Item.Text = _key;
            e.Item.ImageIndex = count;
            myCache[x] = e.Item;
            Debug.WriteLine(string.Format("have {0} items, adding new {1} {2}", myCache.Count, x, files[x]));
            count++;
        }

        private void jListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            GshopImageView.selectedItem = files[e.Item.ImageIndex];
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)

            {
                GshopImageView.selectedItem = files[listView1.SelectedIndices[0]];

                this.Close();
            }
        }
    }
}
