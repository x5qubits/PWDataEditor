using ElementEditor;
using sTASKedit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.PW_Admin_classes
{
    public partial class SelectWorld : Form
    {
        public SelectWorld(int index2)
        {
            InitializeComponent();
            try
            {
                IList KeyList = ElementsEditor.database.InstanceList.GetKeyList();
                IList ValueList = ElementsEditor.database.InstanceList.GetValueList();
                this.dataGridView_Instances.Rows.Clear();
                for (int num25 = 0; num25 < ElementsEditor.database.InstanceList.Count; num25++)
                {
                    try
                    {
                        string[] strArray14 = new string[]
                        {
                        KeyList[num25].ToString(),
                        ValueList[num25].ToString().Replace("\\n", Environment.NewLine)
                        };
                        this.dataGridView_Instances.Rows.Add(strArray14);
                        goto IL_701;
                    }
                    catch
                    {
                        MessageBox.Show(Extensions.GetLocalization(465));
                        goto IL_701;
                    }
                    IL_701:;
                }
                int index = -1;

                DataGridViewRow row = dataGridView_Instances.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[0].Value.ToString().Equals(index2.ToString()))
                    .First();

                index = row.Index;
                this.dataGridView_Instances.CurrentCell = this.dataGridView_Instances.Rows[index].Cells[0];
            }
            catch { }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            AssetManager.anydata = Convert.ToInt32(this.dataGridView_Instances.CurrentRow.Cells[0].Value);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
