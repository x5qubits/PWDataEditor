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
	public partial class SelectMonsterIdWindow: JForm
    {
        int Param;
        bool Scrolling = false;
        private TaskEditor MainWindow;
        public SelectMonsterIdWindow(TaskEditor MainWindow, int param)
		{
            InitializeComponent(); 
            this.MainWindow = MainWindow;
            Param = param;
            this.SetLocalization();
		}

        private void SelectMonsterIdWindow_Load(object sender, EventArgs e)
        {
            this.dataGridView_Monsters.Rows.Clear();
            string[] values = new string[]
			    {
			        "0",
			        Extensions.GetLocalization(402)
			    };
            this.dataGridView_Monsters.Rows.Add(values);
            int l = 38;
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
                        this.dataGridView_Monsters.Rows.Add(strArray14);
                    }
                }
            }
            this.dataGridView_Monsters.CurrentCell = this.dataGridView_Monsters.Rows[MainWindow.SelectMonsterIdWindow_SelectedItemIndex].Cells[0];
            this.dataGridView_Monsters_SelectionChanged(null, null);
        }

        private void dataGridView_Monsters_SelectionChanged(object sender, EventArgs e)
        {
            int l = 38;
            int k = this.dataGridView_Monsters.CurrentCell.RowIndex - 1;
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

        private void dataGridView_Monsters_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_Monsters.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0 && MainWindow.lEnableShowInfo == true)
                    {
                        if (TaskEditor.LoadedElements == true) text += Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(Id));
                    }
                    this.dataGridView_Monsters.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_Monsters.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }

        private void dataGridView_Monsters_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }

        private void dataGridView_Monsters_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true)
            {
                Scrolling = false;
            }
        }

        private void textBox_SearchMonsterId_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= this.dataGridView_Monsters.Rows.Count - 1; i++)
            {
                if (this.dataGridView_Monsters.Rows[i].Cells[0].FormattedValue.ToString() == textBox_SearchMonsterId.Text)
                {
                    this.dataGridView_Monsters.CurrentCell = this.dataGridView_Monsters.Rows[i].Cells[0];
                    this.dataGridView_Monsters_SelectionChanged(null, null);
                    break;
                }
            }
        }

        private void textBox_SearchMonsterName_TextChanged(object sender, EventArgs e)
        {
            int k = 0;
            int index = this.dataGridView_Monsters.CurrentCell.RowIndex;
            for (int i = index; i <= this.dataGridView_Monsters.Rows.Count - 1; i++)
            {
                if (this.dataGridView_Monsters.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchMonsterName.Text.ToLower()))
                {
                    this.dataGridView_Monsters.CurrentCell = this.dataGridView_Monsters.Rows[i].Cells[1];
                    this.dataGridView_Monsters_SelectionChanged(null, null);
                    break;
                }
                if (i == this.dataGridView_Monsters.Rows.Count - 1 && k == 0)
                {
                    k = 1;
                    i = 0;
                }
            }
        }

        private void textBox_SearchMonsterId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.textBox_SearchMonsterId_TextChanged(null, null);
            }
        }

        private void textBox_SearchMonsterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int k = 0;
                int index = this.dataGridView_Monsters.CurrentCell.RowIndex + 1;
                for (int i = index; i <= this.dataGridView_Monsters.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_Monsters.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchMonsterName.Text.ToLower()))
                    {
                        this.dataGridView_Monsters.CurrentCell = this.dataGridView_Monsters.Rows[i].Cells[1];
                        this.dataGridView_Monsters_SelectionChanged(null, null);
                        break;
                    }
                    if (i == this.dataGridView_Monsters.Rows.Count - 1 && k == 0)
                    {
                        k = 1;
                        i = 0;
                    }
                }
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeMonsterId(Convert.ToInt32(this.dataGridView_Monsters.CurrentRow.Cells[0].Value), Param);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectMonsterIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectMonsterIdWindow_SelectedItemIndex = this.dataGridView_Monsters.CurrentCell.RowIndex;
        }

        private void SelectMonsterIdWindow_SizeChanged(object sender, EventArgs e)
        {
            //if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectMonsterIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6037);
            Column_MonsterId.HeaderText = Extensions.GetLocalization(6038);
            Column_MonsterName.HeaderText = Extensions.GetLocalization(6025);
            Column_Parameter.HeaderText = Extensions.GetLocalization(6049);
            Column_Value.HeaderText = Extensions.GetLocalization(6050);
            label1.Text = Extensions.GetLocalization(6026);
            label2.Text = Extensions.GetLocalization(6027);
            button_Ok.Text = Extensions.GetLocalization(6001);
            button_Cancel.Text = Extensions.GetLocalization(6002);
        }
	}
}
