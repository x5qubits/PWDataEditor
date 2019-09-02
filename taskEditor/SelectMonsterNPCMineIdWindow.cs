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
	public partial class SelectMonsterNPCMineIdWindow: JForm
    {
        int Param;
        bool Loced = false;
        bool Scrolling = false;
        private TaskEditor MainWindow;
        public SelectMonsterNPCMineIdWindow(TaskEditor MainWindow, int param)
		{
            InitializeComponent(); 
            this.MainWindow = MainWindow;
            Param = param;
            this.SetLocalization();
		}

        private void SelectMonsterNPCMineIdWindow_Load(object sender, EventArgs e)
        {
            this.comboBox_MonstersNPCsMinesLists.Items.Clear();
            for (int i = 0; i < TaskEditor.monster_npc_minelists.Count; i++)
            {
                this.comboBox_MonstersNPCsMinesLists.Items.Add(TaskEditor.eLC.Lists[(int)TaskEditor.monster_npc_minelists[i]].listName + " (" + TaskEditor.eLC.Lists[(int)TaskEditor.monster_npc_minelists[i]].elementValues.Count + ")");
            }
            this.comboBox_MonstersNPCsMinesLists.SelectedIndex = MainWindow.SelectMonsterNPCMineIdWindow_SelectedListIndex;
            this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[MainWindow.SelectMonsterNPCMineIdWindow_SelectedItemIndex].Cells[0];
            this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
        }

        private void comboBox_MonstersNPCsMinesLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loced = true;
            this.dataGridView_Props.Rows.Clear();
            int l = 38;
            switch (this.comboBox_MonstersNPCsMinesLists.SelectedIndex)
            {
                case 0:
                    l = 38;
                    break;
                case 1:
                    l = 57;
                    break;
                case 2:
                    l = 79;
                    break;
            }
            if (l != TaskEditor.eLC.ConversationListIndex)
            {
                this.dataGridView_MonstersNPCsMines.Rows.Clear();
                string[] values = new string[]
			    {
			        "0",
			        Extensions.GetLocalization(402)
			    };
                this.dataGridView_MonstersNPCsMines.Rows.Add(values);
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
                        this.dataGridView_MonstersNPCsMines.Rows.Add(strArray14);
                    }
                }
            }
            Loced = false;
        }

        private void dataGridView_MonstersNPCsMines_SelectionChanged(object sender, EventArgs e)
        {
            int l = 38;
            switch (this.comboBox_MonstersNPCsMinesLists.SelectedIndex)
            {
                case 0:
                    l = 38;
                    break;
                case 1:
                    l = 57;
                    break;
                case 2:
                    l = 79;
                    break;
            }
            int k = this.dataGridView_MonstersNPCsMines.CurrentCell.RowIndex - 1;
            int scroll = this.dataGridView_Props.FirstDisplayedScrollingRowIndex;
            this.dataGridView_Props.Rows.Clear();
            if (k >= 0 && Loced == false)
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

        private void dataGridView_MonstersNPCsMines_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_MonstersNPCsMines.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0 && MainWindow.lEnableShowInfo == true)
                    {
                        if (TaskEditor.LoadedElements == true) text += Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(Id));
                    }
                    this.dataGridView_MonstersNPCsMines.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_MonstersNPCsMines.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }

        private void dataGridView_MonstersNPCsMines_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }

        private void dataGridView_MonstersNPCsMines_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true)
            {
                Scrolling = false;
            }
        }

        private void textBox_SearchMonsterNPCMineId_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox_SearchAllLists.Checked)
            {
                for (int i = 0; i < TaskEditor.monster_npc_minelists.Count; i++)
                {
                    int l = Convert.ToInt32(TaskEditor.monster_npc_minelists[i]);
                    for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                    {
                        if (TaskEditor.eLC.GetValue(l, t, 0) == this.textBox_SearchMonsterNPCMineId.Text)
                        {
                            this.comboBox_MonstersNPCsMinesLists.SelectedIndex = i;
                            this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[t + 1].Cells[0];
                            this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
                            return;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= this.dataGridView_MonstersNPCsMines.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_MonstersNPCsMines.Rows[i].Cells[0].FormattedValue.ToString() == textBox_SearchMonsterNPCMineId.Text)
                    {
                        this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[i].Cells[0];
                        this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
                        break;
                    }
                }
            }
        }

        private void textBox_SearchMonsterNPCMineName_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox_SearchAllLists.Checked)
            {
                int a = 0;
                int index1 = this.comboBox_MonstersNPCsMinesLists.SelectedIndex;
                int index2 = this.dataGridView_MonstersNPCsMines.CurrentCell.RowIndex - 1;
                if (index2 < 0) { index2 = 0; }
                for (int i = index1; i < TaskEditor.monster_npc_minelists.Count; i++)
                {
                    int l = Convert.ToInt32(TaskEditor.monster_npc_minelists[i]);
                    int pos = 0;
                    for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                        {
                            pos = k;
                            break;
                        }
                    }
                    for (int t = index2; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                    {
                        if (TaskEditor.eLC.GetValue(l, t, pos).ToLower().Contains(this.textBox_SearchMonsterNPCMineName.Text.ToLower()))
                        {
                            this.comboBox_MonstersNPCsMinesLists.SelectedIndex = i;
                            this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[t + 1].Cells[0];
                            this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
                            return;
                        }
                    }
                    index2 = 0;
                    if (i == TaskEditor.monster_npc_minelists.Count - 1 && a == 0)
                    {
                        a = 1;
                        i = -1;
                    }
                }
            }
            else
            {
                int k = 0;
                int index = this.dataGridView_MonstersNPCsMines.CurrentCell.RowIndex;
                for (int i = index; i <= this.dataGridView_MonstersNPCsMines.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_MonstersNPCsMines.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchMonsterNPCMineName.Text.ToLower()))
                    {
                        this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[i].Cells[1];
                        this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
                        break;
                    }
                    if (i == this.dataGridView_MonstersNPCsMines.Rows.Count - 1 && k == 0)
                    {
                        k = 1;
                        i = 0;
                    }
                }
            }
        }

        private void textBox_SearchMonsterNPCMineId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.textBox_SearchMonsterNPCMineId_TextChanged(null, null);
            }
        }

        private void textBox_SearchMonsterNPCMineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.checkBox_SearchAllLists.Checked)
                {
                    int a = 0;
                    int index1 = this.comboBox_MonstersNPCsMinesLists.SelectedIndex;
                    int index2 = this.dataGridView_MonstersNPCsMines.CurrentCell.RowIndex;
                    if (index2 < 0) { index2 = 0; }
                    for (int i = index1; i < TaskEditor.monster_npc_minelists.Count; i++)
                    {
                        int l = Convert.ToInt32(TaskEditor.monster_npc_minelists[i]);
                        int pos = 0;
                        for (int k = 0; k < TaskEditor.eLC.Lists[l].elementFields.Length; k++)
                        {
                            if (TaskEditor.eLC.Lists[l].elementFields[k] == "Name")
                            {
                                pos = k;
                                break;
                            }
                        }
                        for (int t = index2; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                        {
                            if (TaskEditor.eLC.GetValue(l, t, pos).ToLower().Contains(this.textBox_SearchMonsterNPCMineName.Text.ToLower()))
                            {
                                this.comboBox_MonstersNPCsMinesLists.SelectedIndex = i;
                                this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[t + 1].Cells[0];
                                this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
                                return;
                            }
                        }
                        index2 = 0;
                        if (i == TaskEditor.monster_npc_minelists.Count - 1 && a == 0)
                        {
                            a = 1;
                            i = -1;
                        }
                    }
                }
                else
                {
                    int k = 0;
                    int index = this.dataGridView_MonstersNPCsMines.CurrentCell.RowIndex + 1;
                    for (int i = index; i <= this.dataGridView_MonstersNPCsMines.Rows.Count - 1; i++)
                    {
                        if (this.dataGridView_MonstersNPCsMines.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchMonsterNPCMineName.Text.ToLower()))
                        {
                            this.dataGridView_MonstersNPCsMines.CurrentCell = this.dataGridView_MonstersNPCsMines.Rows[i].Cells[1];
                            this.dataGridView_MonstersNPCsMines_SelectionChanged(null, null);
                            break;
                        }
                        if (i == this.dataGridView_MonstersNPCsMines.Rows.Count - 1 && k == 0)
                        {
                            k = 1;
                            i = 0;
                        }
                    }
                }
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeMonsterId(Convert.ToInt32(this.dataGridView_MonstersNPCsMines.CurrentRow.Cells[0].Value), Param);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectMonsterNPCMineIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectMonsterNPCMineIdWindow_SelectedListIndex = this.comboBox_MonstersNPCsMinesLists.SelectedIndex;
            MainWindow.SelectMonsterNPCMineIdWindow_SelectedItemIndex = this.dataGridView_MonstersNPCsMines.CurrentCell.RowIndex;
        }

        private void SelectMonsterNPCMineIdWindow_SizeChanged(object sender, EventArgs e)
        {
           // if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectMonsterNPCMineIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6039);
            Column_ElementId.HeaderText = Extensions.GetLocalization(6040);
            Column_ElementName.HeaderText = Extensions.GetLocalization(6025);
            Column_Parameter.HeaderText = Extensions.GetLocalization(6049);
            Column_Value.HeaderText = Extensions.GetLocalization(6050);
            label1.Text = Extensions.GetLocalization(6026);
            label2.Text = Extensions.GetLocalization(6027);
            checkBox_SearchAllLists.Text = Extensions.GetLocalization(6048);
            button_Ok.Text = Extensions.GetLocalization(6001);
            button_Cancel.Text = Extensions.GetLocalization(6002);
        }
    }
}
