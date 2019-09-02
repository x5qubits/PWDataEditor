using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;

using System.Text;
using System.Windows.Forms;
using System.IO;
using ElementEditor;
using JHUI.Forms;

namespace sTASKedit
{
	public partial class SelectItemIdWindow: JForm
    {
        int Param;
        bool CommonItem;
        bool Loced = false;
        bool resizing = false;
        bool Scrolling = false;
        private TaskEditor MainWindow;
        public SelectItemIdWindow(TaskEditor MainWindow, int param)
		{
            InitializeComponent(); 
            this.MainWindow = MainWindow;
            Param = param;
            this.SetLocalization();
            try
            {
                this.richTextBox_Desc.Font = new Font(TaskEditor.f.Families[0], 8, FontStyle.Bold);
            }
            catch
            { }

            this.richTextBox_Desc.Location = new System.Drawing.Point(this.richTextBox_Desc.Location.X, this.dataGridView_Props.Location.Y + this.dataGridView_Props.Height + 7);
            this.richTextBox_Desc.Height = this.Height - this.dataGridView_Props.Location.Y - this.dataGridView_Props.Height - 7 - 47;

        }

        private void SelectItemIdWindow_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ElementsEditor.database.task_items_list.Length; i += 2)
            {
                if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                {
                    this.comboBox_ItemsLists.Items.Add(TaskEditor.eLC.Lists[Convert.ToInt32(ElementsEditor.database.task_items_list[i])].listName + " (" + TaskEditor.eLC.Lists[Convert.ToInt32(ElementsEditor.database.task_items_list[i])].elementValues.Count + ")");
                }
            }
            this.comboBox_ItemsLists.SelectedIndex = MainWindow.SelectItemIdWindow_SelectedListIndex;
            this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[MainWindow.SelectItemIdWindow_SelectedItemIndex].Cells[0];
            this.dataGridView_Items_SelectionChanged(null, null);
        }

        private void SelectItemIdWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= this.dataGridView_Props.Location.X && e.X <= this.dataGridView_Props.Location.X + this.dataGridView_Props.Width &&
                e.Y >= this.dataGridView_Props.Location.Y + this.dataGridView_Props.Height && e.Y <= this.richTextBox_Desc.Location.Y)
            {
                resizing = true;
            }
            else
            {
                resizing = false;
            }
        }

        private void SelectItemIdWindow_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void SelectItemIdWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= this.dataGridView_Props.Location.X && e.X <= this.dataGridView_Props.Location.X + this.dataGridView_Props.Width &&
                e.Y >= this.dataGridView_Props.Location.Y + this.dataGridView_Props.Height && e.Y <= this.richTextBox_Desc.Location.Y)
            {
                this.Cursor = Cursors.HSplit;
            }
            else if (resizing == false)
            {
                this.Cursor = Cursors.Default;
            }
            if (resizing && e.Y <= this.button_Cancel.Location.Y)
            {
                int Height = this.dataGridView_Props.Height;
                this.dataGridView_Props.Height = e.Y - this.dataGridView_Props.Location.Y;
                this.richTextBox_Desc.Height = this.richTextBox_Desc.Height + (Height - this.dataGridView_Props.Height);
                this.richTextBox_Desc.Location = new System.Drawing.Point(this.richTextBox_Desc.Location.X, this.richTextBox_Desc.Location.Y - (Height - this.dataGridView_Props.Height));
              //  MainWindow.lSelectItemIdWindow_dataGridView_Props_Size = this.dataGridView_Props.Size;
            }
        }

        private void SelectItemIdWindow_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
            this.Cursor = Cursors.Default;
        }

        private void comboBox_ItemsLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loced = true;
            this.dataGridView_Props.Rows.Clear();
            int l = 3;
            int selectedindex = this.comboBox_ItemsLists.SelectedIndex;
            l = Convert.ToInt32(ElementsEditor.database.task_items_list[selectedindex * 2]);
            if (l == 28) CommonItem = false;
            else CommonItem = true;
            if (l != TaskEditor.eLC.ConversationListIndex)
            {
                this.dataGridView_Items.Rows.Clear();
                string[] values = new string[]
			    {
			        "0",
			        Extensions.GetLocalization(402)
			    };
                this.dataGridView_Items.Rows.Add(values);
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
                        this.dataGridView_Items.Rows.Add(strArray14);
                    }
                }
            }
            Loced = false;
        }

        private void dataGridView_Items_SelectionChanged(object sender, EventArgs e)
        {
            uint proctypes;
            int l = 3;
            int selectedindex = this.comboBox_ItemsLists.SelectedIndex;
            l = Convert.ToInt32(ElementsEditor.database.task_items_list[selectedindex * 2]);
            int k = this.dataGridView_Items.CurrentCell.RowIndex - 1;
            if (k >= 0)
            {
                if (l != TaskEditor.eLC.ConversationListIndex && Loced == false)
                {
                    string line = "";
                    int pos = -1;
                    for (int i = 0; i < TaskEditor.eLC.Lists[l].elementFields.Length; i++)
                    {
                        if (TaskEditor.eLC.Lists[l].elementFields[i] == "proc_type")
                        {
                            pos = i;
                            break;
                        }
                    }
                    if (TaskEditor.eLC.Lists[l].elementFields[0] == "ID")
                    {
                        bool result = uint.TryParse(TaskEditor.eLC.GetValue(l, k, pos), out proctypes);
                        List<uint> powers = new List<uint>(GetPowers(proctypes));
                        for (int p = 0; p < powers.Count; p++)
                        {
                            if (powers[p] == 0) continue;

                            switch (p)
                            {
                                case 6:
                                    line += Extensions.GetLocalization(3006) + "\n\n";//proc_type_64
                                    break;
                                case 15:
                                    line += Extensions.GetLocalization(3015);//proc_type_32768
                                    break;
                            }
                        }
                        for (int p = 0; p < powers.Count; p++)
                        {
                            if (powers[p] == 0) continue;

                            switch (p)
                            {
                                case 13:
                                    line += Extensions.GetLocalization(3013);//proc_type_8192
                                    break;
                            }
                        }
                        if (l == 124)
                        {
                            for (int i = 0; i < TaskEditor.eLC.Lists[l].elementFields.Length; i++)
                            {
                                if (TaskEditor.eLC.Lists[l].elementFields[i] == "id_skill")
                                {
                                    line += Extensions.SkillDesc(Convert.ToInt32(TaskEditor.eLC.GetValue(l, k, i))) + "\n\n";
                                    break;
                                }
                            }
                        }
                        for (int p = 0; p < powers.Count; p++)
                        {
                            if (powers[p] == 0) continue;

                            switch (p)
                            {
                                case 0:
                                    line += Extensions.GetLocalization(3000);//proc_type_1
                                    break;
                                case 1:
                                    line += Extensions.GetLocalization(3001);//proc_type_2
                                    break;
                                case 2:
                                    line += Extensions.GetLocalization(3002);//proc_type_4
                                    break;
                                case 3:
                                    line += Extensions.GetLocalization(3003);//proc_type_8
                                    break;
                                case 4:
                                    line += Extensions.GetLocalization(3004);//proc_type_16
                                    break;
                                case 5:
                                    line += Extensions.GetLocalization(3005);//proc_type_32
                                    break;
                                case 7:
                                    line += Extensions.GetLocalization(3007);//proc_type_128
                                    break;
                                case 8:
                                    line += Extensions.GetLocalization(3008);//proc_type_256
                                    break;
                                case 9:
                                    line += Extensions.GetLocalization(3009);//proc_type_512
                                    break;
                                case 10:
                                    line += Extensions.GetLocalization(3010);//proc_type_1024
                                    break;
                                case 11:
                                    line += Extensions.GetLocalization(3011);//proc_type_2048
                                    break;
                                case 12:
                                    line += Extensions.GetLocalization(3012);//proc_type_4096
                                    break;
                                case 14:
                                    line += Extensions.GetLocalization(3014);//proc_type_16384
                                    break;
                            }
                        }
                        line += Extensions.ItemDesc(Convert.ToInt32(this.dataGridView_Items.Rows[k + 1].Cells[0].Value));
                        string[] blocks = line.Split(new char[] { '^' });
                        if (blocks.Length > 1)
                        {
                            int le1 = 0;
                            this.richTextBox_Desc.Text = "";
                            le1 = (line.IndexOf('^', 0));
                            this.richTextBox_Desc.AppendText(string.Format(line.Substring(0, le1)));
                            this.richTextBox_Desc.Select(0, le1);
                            this.richTextBox_Desc.SelectionColor = Color.White;
                            /*string result = "";

                            if (blocks[0] != "")
                            {
                                result += blocks[0];
                            }*/

                            int le = 0;
                            int st = 0;
                            Color color = Color.White;
                            for (int i = 1; i < blocks.Length; i++)
                            {
                                if (blocks[i] != "")
                                {
                                    st = this.richTextBox_Desc.Text.Length;
                                    try
                                    {
                                        color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                                        this.richTextBox_Desc.AppendText(string.Format(blocks[i].Substring(6)));
                                    }
                                    catch
                                    {
                                        this.richTextBox_Desc.AppendText(string.Format("^" + blocks[i]));
                                    }
                                    le = this.richTextBox_Desc.Text.Length - st;
                                    this.richTextBox_Desc.Select(st, le);
                                    this.richTextBox_Desc.SelectionColor = color;
                                }
                            }
                        }
                        else
                        {
                            this.richTextBox_Desc.Text = line;
                            this.richTextBox_Desc.Select(0, this.richTextBox_Desc.Text.Length);
                            this.richTextBox_Desc.SelectionColor = Color.White;
                        }
                    }
                }
            }
            else
            {
                this.richTextBox_Desc.Text = "";
            }
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

        private void dataGridView_Items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_Items.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0 && MainWindow.lEnableShowInfo == true)
                    {
                        if (TaskEditor.LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, 0));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_Items.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_Items.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }

        private void dataGridView_Items_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }

        private void dataGridView_Items_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true)
            {
                Scrolling = false;
            }
        }

        private void textBox_SearchItemId_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox_SearchAllLists.Checked)
            {
                for (int i = 0; i < ElementsEditor.database.task_items_list.Length; i += 2)
                {
                    if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                    {
                        int l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
                        for (int t = 0; t < TaskEditor.eLC.Lists[l].elementValues.Count; t++)
                        {
                            if (TaskEditor.eLC.GetValue(l, t, 0) == this.textBox_SearchItemId.Text)
                            {
                                this.comboBox_ItemsLists.SelectedIndex = i / 2;
                                this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[t + 1].Cells[0];
                                this.dataGridView_Items_SelectionChanged(null, null);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= this.dataGridView_Items.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_Items.Rows[i].Cells[0].FormattedValue.ToString() == textBox_SearchItemId.Text)
                    {
                        this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[i].Cells[0];
                        this.dataGridView_Items_SelectionChanged(null, null);
                        break;
                    }
                }
            }
        }

        private void textBox_SearchItemName_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox_SearchAllLists.Checked)
            {
                int a = 0;
                int index1 = this.comboBox_ItemsLists.SelectedIndex;
                int index2 = this.dataGridView_Items.CurrentCell.RowIndex - 1;
                if (index2 < 0) { index2 = 0; }
                for (int i = index1 * 2; i < ElementsEditor.database.task_items_list.Length; i += 2)
                {
                    if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                    {
                        int l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
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
                            if (TaskEditor.eLC.GetValue(l, t, pos).ToLower().Contains(this.textBox_SearchItemName.Text.ToLower()))
                            {
                                this.comboBox_ItemsLists.SelectedIndex = i / 2;
                                this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[t + 1].Cells[0];
                                this.dataGridView_Items_SelectionChanged(null, null);
                                return;
                            }
                        }
                    }
                    index2 = 0;
                    if (i == ElementsEditor.database.task_items_list.Length - 2 && a == 0)
                    {
                        a = 1;
                        i = -2;
                    }
                }
            }
            else
            {
                int k = 0;
                int index = this.dataGridView_Items.CurrentCell.RowIndex;
                for (int i = index; i <= this.dataGridView_Items.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_Items.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchItemName.Text.ToLower()))
                    {
                        this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[i].Cells[1];
                        this.dataGridView_Items_SelectionChanged(null, null);
                        break;
                    }
                    if (i == this.dataGridView_Items.Rows.Count - 1 && k == 0)
                    {
                        k = 1;
                        i = 0;
                    }
                }
            }
        }

        private void textBox_SearchItemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.textBox_SearchItemId_TextChanged(null, null);
            }
        }

        private void textBox_SearchItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.checkBox_SearchAllLists.Checked)
                {
                    int a = 0;
                    int index1 = this.comboBox_ItemsLists.SelectedIndex;
                    int index2 = this.dataGridView_Items.CurrentCell.RowIndex;
                    if (index2 < 0) { index2 = 0; }
                    for (int i = index1 * 2; i < ElementsEditor.database.task_items_list.Length; i += 2)
                    {
                        if (TaskEditor.eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[i + 1]))
                        {
                            int l = Convert.ToInt32(ElementsEditor.database.task_items_list[i]);
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
                                if (TaskEditor.eLC.GetValue(l, t, pos).ToLower().Contains(this.textBox_SearchItemName.Text.ToLower()))
                                {
                                    this.comboBox_ItemsLists.SelectedIndex = i / 2;
                                    this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[t + 1].Cells[0];
                                    this.dataGridView_Items_SelectionChanged(null, null);
                                    return;
                                }
                            }
                        }
                        index2 = 0;
                        if (i == ElementsEditor.database.task_items_list.Length - 2 && a == 0)
                        {
                            a = 1;
                            i = -2;
                        }
                    }
                }
                else
                {
                    int k = 0;
                    int index = this.dataGridView_Items.CurrentCell.RowIndex + 1;
                    for (int i = index; i <= this.dataGridView_Items.Rows.Count - 1; i++)
                    {
                        if (this.dataGridView_Items.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchItemName.Text.ToLower()))
                        {
                            this.dataGridView_Items.CurrentCell = this.dataGridView_Items.Rows[i].Cells[1];
                            this.dataGridView_Items_SelectionChanged(null, null);
                            break;
                        }
                        if (i == this.dataGridView_Items.Rows.Count - 1 && k == 0)
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
            MainWindow.ChangeItemId(Convert.ToInt32(this.dataGridView_Items.CurrentRow.Cells[0].Value), Param, CommonItem);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectItemIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectItemIdWindow_SelectedListIndex = this.comboBox_ItemsLists.SelectedIndex;
            MainWindow.SelectItemIdWindow_SelectedItemIndex = this.dataGridView_Items.CurrentCell.RowIndex;
        }

        private void SelectItemIdWindow_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized && MainWindow != null)
            {
                //MainWindow.lSelectItemIdWindow_Size = this.Size;
                if (this.dataGridView_Props.Height > this.button_Cancel.Location.Y - this.dataGridView_Props.Location.Y)
                {
                    this.dataGridView_Props.Height = this.dataGridView_Items.Height;
                    this.richTextBox_Desc.Location = new System.Drawing.Point(this.richTextBox_Desc.Location.X, this.dataGridView_Props.Location.Y + this.dataGridView_Props.Height + 7);
                    this.richTextBox_Desc.Height = this.Height - this.dataGridView_Props.Location.Y - this.dataGridView_Props.Height - 7 - 47;
                   // MainWindow.lSelectItemIdWindow_dataGridView_Props_Size = this.dataGridView_Props.Size;
                }
            }
        }

        IEnumerable<uint> GetPowers(uint value)
        {
            uint v = value;
            while (v > 0)
            {
                yield return (v & 0x01);
                v >>= 1;
            }
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6035);
            Column_ItemId.HeaderText = Extensions.GetLocalization(6036);
            Column_ItemName.HeaderText = Extensions.GetLocalization(6025);
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
