using JHUI.Forms;
using System;
using System.Windows.Forms;

namespace sTASKedit
{
    public partial class SelectHomeItemIdWindow: JForm
    {
        int Param;
        bool Scrolling = false;
        private TaskEditor MainWindow;
        public SelectHomeItemIdWindow(TaskEditor MainWindow, int param)
		{
            InitializeComponent(); 
            this.MainWindow = MainWindow;
            Param = param;
            this.SetLocalization();

		}

        private void SelectHomeItemIdWindow_Load(object sender, EventArgs e)
        {
            this.dataGridView_HomeItems.Rows.Clear();
            string[] values = new string[]
			    {
			        "0",
			        Extensions.GetLocalization(402)
			    };
            this.dataGridView_HomeItems.Rows.Add(values);
            if (TaskEditor.eLC.Version >= 153)
            {
                int l = 223;
                if (l != TaskEditor.eLC.ConversationListIndex)
                {
                    int pos = -1;
                    for (int i = 0; i < TaskEditor.eLC.Lists[l].elementFields.Length; i++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;
                            break;
                        }
                    }
                    for (int k = 0; k < TaskEditor.eLC.Lists[l].elementValues.Count; k++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[0] == "ID")
                        {
                            string[] strArray14 = new string[]
					        {
						        TaskEditor.eLC.GetValue(l, k, 0),
						        TaskEditor.eLC.GetValue(l, k, pos)
					        };
                            this.dataGridView_HomeItems.Rows.Add(strArray14);
                        }
                    }
                }
            }
            this.dataGridView_HomeItems.CurrentCell = this.dataGridView_HomeItems.Rows[MainWindow.SelectHomeItemIdWindow_SelectedItemIndex].Cells[0];
            this.dataGridView_HomeItems_SelectionChanged(null, null);
        }

        private void dataGridView_HomeItems_SelectionChanged(object sender, EventArgs e)
        {
            int l = 223;
            int k = this.dataGridView_HomeItems.CurrentCell.RowIndex - 1;
            int scroll = this.dataGridView_Props.FirstDisplayedScrollingRowIndex;
            this.dataGridView_Props.Rows.Clear();
            if (k >= 0)
            {
                for (int f = 0; f < TaskEditor.eLC.Lists[l].elementValues[k].Count; f++)
                {
                    this.dataGridView_Props.Rows.Add(new string[] { TaskEditor.eLC.Lists[l].elementFields[f], TaskEditor.eLC.GetValue(l, k, f) });
                }
            }
            if (scroll > -1 && k > -1)
            {
                this.dataGridView_Props.FirstDisplayedScrollingRowIndex = scroll;
            }
        }

        private void dataGridView_HomeItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_HomeItems.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0 && MainWindow.lEnableShowInfo == true)
                    {
                        if (TaskEditor.LoadedElements == true) text += Extensions.ColorClean(Extensions.GetHomeItemProps(Id));
                    }
                    this.dataGridView_HomeItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_HomeItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }

        private void dataGridView_HomeItems_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }

        private void dataGridView_HomeItems_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true)
            {
                Scrolling = false;
            }
        }

        private void textBox_SearchHomeItemId_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= this.dataGridView_HomeItems.Rows.Count - 1; i++)
            {
                if (this.dataGridView_HomeItems.Rows[i].Cells[0].FormattedValue.ToString() == textBox_SearchHomeItemId.Text)
                {
                    this.dataGridView_HomeItems.CurrentCell = this.dataGridView_HomeItems.Rows[i].Cells[0];
                    this.dataGridView_HomeItems_SelectionChanged(null, null);
                    break;
                }
            }
        }

        private void textBox_SearchHomeItemName_TextChanged(object sender, EventArgs e)
        {
            int k = 0;
            int index = this.dataGridView_HomeItems.CurrentCell.RowIndex;
            for (int i = index; i <= this.dataGridView_HomeItems.Rows.Count - 1; i++)
            {
                if (this.dataGridView_HomeItems.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchHomeItemName.Text.ToLower()))
                {
                    this.dataGridView_HomeItems.CurrentCell = this.dataGridView_HomeItems.Rows[i].Cells[1];
                    this.dataGridView_HomeItems_SelectionChanged(null, null);
                    break;
                }
                if (i == this.dataGridView_HomeItems.Rows.Count - 1 && k == 0)
                {
                    k = 1;
                    i = 0;
                }
            }
        }

        private void textBox_SearchHomeItemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.textBox_SearchHomeItemId_TextChanged(null, null);
            }
        }

        private void textBox_SearchHomeItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int k = 0;
                int index = this.dataGridView_HomeItems.CurrentCell.RowIndex + 1;
                for (int i = index; i <= this.dataGridView_HomeItems.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_HomeItems.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchHomeItemName.Text.ToLower()))
                    {
                        this.dataGridView_HomeItems.CurrentCell = this.dataGridView_HomeItems.Rows[i].Cells[1];
                        this.dataGridView_HomeItems_SelectionChanged(null, null);
                        break;
                    }
                    if (i == this.dataGridView_HomeItems.Rows.Count - 1 && k == 0)
                    {
                        k = 1;
                        i = 0;
                    }
                }
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeHomeItemId(Convert.ToInt32(this.dataGridView_HomeItems.CurrentRow.Cells[0].Value), Param);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectHomeItemIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectHomeItemIdWindow_SelectedItemIndex = this.dataGridView_HomeItems.CurrentCell.RowIndex;
        }

        private void SelectHomeItemIdWindow_SizeChanged(object sender, EventArgs e)
        {
           // if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectHomeItemIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6045);
            Column_HomeItemId.HeaderText = Extensions.GetLocalization(6046);
            Column_HomeItemName.HeaderText = Extensions.GetLocalization(6025);
            Column_Parameter.HeaderText = Extensions.GetLocalization(6049);
            Column_Value.HeaderText = Extensions.GetLocalization(6050);
            label1.Text = Extensions.GetLocalization(6026);
            label2.Text = Extensions.GetLocalization(6027);
            button_Ok.Text = Extensions.GetLocalization(6001);
            button_Cancel.Text = Extensions.GetLocalization(6002);
        }
	}
}
