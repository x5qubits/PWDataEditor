using sTASKedit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied
{
    public partial class EQUIP_ADDON_LISTSELECT : Form
    {
        public EQUIP_ADDON_LISTSELECT()
        {
            InitializeComponent();
        }

        private void EQUIP_ADDON_LISTSELECT_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach(int id in TaskEditor.eLC.addonIndex.Keys)
            {
                listBox1.Items.Add(EQUIPMENT_ADDON.GetAddon(id.ToString()));
            }
        }
    }
}
