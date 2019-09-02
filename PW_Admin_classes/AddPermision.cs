using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.PW_Admin_classes
{
    public partial class AddPermision : Form
    {
        private bool _isAdvanced = false;
        public AddPermision(bool isAdvanced = false)
        {
            InitializeComponent();
            _isAdvanced = isAdvanced;
            comboBox7.Items.Clear();
            if (isAdvanced)
            {
                foreach (KeyValuePair<int, String> data in PWAdmin.server_cache.permissionsAdvanced)
                {
                    comboBox7.Items.Add(data.Key + "-" + data.Value);
                }
            }
            else
            {
                foreach (KeyValuePair<int, String> data in PWAdmin.server_cache.permissionsbasic)
                {
                    comboBox7.Items.Add(data.Key + "-" + data.Value);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<String> str1 = new List<String>();
            try
            {
                for (int i = 0; i < comboBox7.Items.Count; i++)
                { 
                    if (comboBox7.GetItemCheckState(i) == CheckState.Checked)
                    {
                        str1.Add(comboBox7.Items[i].ToString().ToString().Split('-')[0]);
                    }
                }
                AssetManager.anydata = str1;
            }catch
            {
                AssetManager.anydata = null;
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
