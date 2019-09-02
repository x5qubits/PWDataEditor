using JHUI.Forms;
using PWDataEditorPaied.PW_Admin_classes;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sTASKedit
{
	public partial class SelectWorldIdWindow: JForm
	{
        int Param;
        int SelectedItemIndex;
        private TaskEditor MainWindow;
        public SelectWorldIdWindow(TaskEditor MainWindow, int param, int selecteditemindex)
		{
			InitializeComponent();
            this.MainWindow = MainWindow;
            Param = param;
            SelectedItemIndex = selecteditemindex;
            this.SetLocalization();

		}

        private void SelectWorldIdWindow_Load(object sender, EventArgs e)
        {
            int[] KeyList = TaskEditor.InstanceList.Keys.ToArray();
            Map[] ValueList = TaskEditor.InstanceList.Values.ToArray();
            this.dataGridView_Instances.Rows.Clear();
            for (int num25 = 0; num25 < TaskEditor.InstanceList.Count; num25++)
            {
                try
                {
                    string[] strArray14 = new string[]
					{
						KeyList[num25].ToString(),
						ValueList[num25].name.ToString().Replace("\\n", Environment.NewLine)
					};
                    this.dataGridView_Instances.Rows.Add(strArray14);
                    goto IL_701;
                }
                catch
                {
                    MessageBox.Show(Extensions.GetLocalization(465));
                    goto IL_701;
                }
            IL_701: ;
            }
            this.dataGridView_Instances.CurrentCell = this.dataGridView_Instances.Rows[SelectedItemIndex].Cells[0];
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeWorldId(Convert.ToInt32(this.dataGridView_Instances.CurrentRow.Cells[0].Value), Param);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectWorldIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectWorldIdWindow_SelectedItemIndex = this.dataGridView_Instances.CurrentCell.RowIndex;
        }

        private void SelectWorldIdWindow_SizeChanged(object sender, EventArgs e)
        {
          //  if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectWorldIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6013);
            Column_WorldId.HeaderText = Extensions.GetLocalization(6014);
            Column_InstanceName.HeaderText = Extensions.GetLocalization(6015);
            button_Ok.Text = Extensions.GetLocalization(6016);
            button_Cancel.Text = Extensions.GetLocalization(6017);
        }
	}
}
