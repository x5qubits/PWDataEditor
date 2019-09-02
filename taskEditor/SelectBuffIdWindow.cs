using ElementEditor;
using JHUI.Forms;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace sTASKedit
{
	public partial class SelectBuffIdWindow: JForm
    {
        int Param;
        private TaskEditor MainWindow;
        public SelectBuffIdWindow(TaskEditor MainWindow, int param)
		{
            InitializeComponent();
            this.MainWindow = MainWindow;
            Param = param;
            this.SetLocalization();
        }

        private void SelectBuffIdWindow_Load(object sender, EventArgs e)
        {
            this.dataGridView_Buffs.Rows.Clear();
            string[] values = new string[]
			{
			    "0",
			    Extensions.GetLocalization(402)
			};
            this.dataGridView_Buffs.Rows.Add(values);
            for (int num25 = 0; num25 < ElementsEditor.database.buff_str.Length - 1; num25 += 2)
            {
                try
                {
                    string[] strArray14 = new string[]
					{
						Convert.ToInt32(ElementsEditor.database.buff_str[num25 + 0]).ToString(),
                        ElementsEditor.database.buff_str[num25 + 1].ToString()
					};
                    this.dataGridView_Buffs.Rows.Add(strArray14);
                    goto IL_701;
                }
                catch
                {
                    MessageBox.Show(Extensions.GetLocalization(465));
                    goto IL_701;
                }
            IL_701: ;
            }
            this.dataGridView_Buffs.CurrentCell = this.dataGridView_Buffs.Rows[MainWindow.SelectBuffIdWindow_SelectedItemIndex].Cells[0];
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeBuffId(Convert.ToInt32(this.dataGridView_Buffs.CurrentRow.Cells[0].Value), Param);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectBuffIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectBuffIdWindow_SelectedItemIndex = this.dataGridView_Buffs.CurrentCell.RowIndex;
        }

        private void SelectBuffIdWindow_SizeChanged(object sender, EventArgs e)
        {
           // if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectBuffIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6018);
            Column_BuffId.HeaderText = Extensions.GetLocalization(6019);
            Column_BuffDesc.HeaderText = Extensions.GetLocalization(6020);
            button_Ok.Text = Extensions.GetLocalization(6021);
            button_Cancel.Text = Extensions.GetLocalization(6022);
        }
	}
}
