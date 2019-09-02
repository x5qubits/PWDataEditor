using ElementEditor;
using JHUI.Forms;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace sTASKedit
{
    public partial class SelectSkillIdWindow: JForm
	{
        int Param;
        bool loaded = false;
        bool Scrolling = false;
        private TaskEditor MainWindow;
        public SelectSkillIdWindow(TaskEditor MainWindow, int param)
		{
            
            this.MainWindow = MainWindow;
            Param = param;
            InitializeComponent();
            
            this.SetLocalization();
            try
            {
                this.richTextBox_SkillDesc.Font = new Font(TaskEditor.f.Families[0], 8, FontStyle.Bold);
            }
            catch
            { }
       

        }

        private void SelectSkillIdWindow_Load(object sender, EventArgs e)
        {
            this.dataGridView_Skills.Rows.Clear();
            string[] values = new string[]
			{
			    "0",
			    Extensions.GetLocalization(402)
			};
            this.dataGridView_Skills.Rows.Add(values);
            for (int num25 = 0; num25 < ElementsEditor.database.skillstr.Length - 1; num25 += 4)
            {
                try
                {
                    string[] strArray14 = new string[]
					{
						Convert.ToInt32(ElementsEditor.database.skillstr[num25]).ToString().Substring(0, Convert.ToString(Convert.ToInt32(ElementsEditor.database.skillstr[num25])).Length - 1),
                        ElementsEditor.database.skillstr[num25 + 1].ToString()
					};
                    this.dataGridView_Skills.Rows.Add(strArray14);
                    goto IL_701;
                }
                catch
                {
                    MessageBox.Show(Extensions.GetLocalization(465));
                    goto IL_701;
                }
            IL_701: ;
            }
            loaded = true;
            this.dataGridView_Skills.CurrentCell = this.dataGridView_Skills.Rows[MainWindow.SelectSkillIdWindow_SelectedItemIndex].Cells[0];
            this.dataGridView_Skills_SelectionChanged(null, null);
        }

        private void dataGridView_Skills_SelectionChanged(object sender, EventArgs e)
        {
            if (loaded == true)
            {
                int index = this.dataGridView_Skills.CurrentCell.RowIndex;
                int id = Convert.ToInt32(this.dataGridView_Skills.Rows[index].Cells[0].Value);
                if (id != 0)
                {
                    string line = Extensions.SkillDesc(id);
                    string[] blocks = line.Split(new char[] { '^' });
                    if (blocks.Length > 1)
                    {
                        int le1 = 0;
                        this.richTextBox_SkillDesc.Text = "";
                        le1 = (line.IndexOf('^', 0));
                        this.richTextBox_SkillDesc.AppendText(string.Format(line.Substring(0, le1)));
                        this.richTextBox_SkillDesc.Select(0, le1);
                        this.richTextBox_SkillDesc.SelectionColor = Color.White;
                        string result = "";

                        if (blocks[0] != "")
                        {
                            result += blocks[0];
                        }

                        int le = 0;
                        int st = 0;
                        Color color = Color.White;
                        for (int i = 1; i < blocks.Length; i++)
                        {
                            if (blocks[i] != "")
                            {
                                st = this.richTextBox_SkillDesc.Text.Length;
                                try
                                {
                                    color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                                    this.richTextBox_SkillDesc.AppendText(string.Format(blocks[i].Substring(6)));
                                }
                                catch
                                {
                                    this.richTextBox_SkillDesc.AppendText(string.Format("^" + blocks[i]));
                                }
                                le = this.richTextBox_SkillDesc.Text.Length - st;
                                this.richTextBox_SkillDesc.Select(st, le);
                                this.richTextBox_SkillDesc.SelectionColor = color;
                            }
                        }
                    }
                    else
                    {
                        this.richTextBox_SkillDesc.Text = line;
                        this.richTextBox_SkillDesc.Select(0, this.richTextBox_SkillDesc.Text.Length);
                        this.richTextBox_SkillDesc.SelectionColor = Color.White;
                    }
                }
                else
                {
                    this.richTextBox_SkillDesc.Text = Extensions.GetLocalization(402);
                    this.richTextBox_SkillDesc.Select(0, this.richTextBox_SkillDesc.Text.Length);
                    this.richTextBox_SkillDesc.SelectionColor = Color.White;
                }
            }
        }

        private void dataGridView_Skills_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_Skills.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0 && MainWindow.lEnableShowInfo == true)
                    {
                        text += Extensions.ColorClean(Extensions.SkillText(Id));
                    }
                    this.dataGridView_Skills.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_Skills.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }

        private void dataGridView_Skills_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }

        private void dataGridView_Skills_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true)
            {
                Scrolling = false;
            }
        }

        private void textBox_SearchSkillId_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= this.dataGridView_Skills.Rows.Count - 1; i++)
            {
                if (this.dataGridView_Skills.Rows[i].Cells[0].FormattedValue.ToString() == textBox_SearchSkillId.Text)
                {
                    this.dataGridView_Skills.CurrentCell = this.dataGridView_Skills.Rows[i].Cells[0];
                    this.dataGridView_Skills_SelectionChanged(null, null);
                    break;
                }
            }
        }

        private void textBox_SearchSkillName_TextChanged(object sender, EventArgs e)
        {
            int k = 0;
            int index = this.dataGridView_Skills.CurrentCell.RowIndex;
            for (int i = index; i <= this.dataGridView_Skills.Rows.Count - 1; i++)
            {
                if (this.dataGridView_Skills.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchSkillName.Text.ToLower()))
                {
                    this.dataGridView_Skills.CurrentCell = this.dataGridView_Skills.Rows[i].Cells[1];
                    this.dataGridView_Skills_SelectionChanged(null, null);
                    break;
                }
                if (i == this.dataGridView_Skills.Rows.Count - 1 && k == 0)
                {
                    k = 1;
                    i = 0;
                }
            }
        }

        private void textBox_SearchSkillId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.textBox_SearchSkillId_TextChanged(null, null);
            }
        }

        private void textBox_SearchSkillName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                int k = 0;
                int index = this.dataGridView_Skills.CurrentCell.RowIndex + 1;
                for (int i = index; i <= this.dataGridView_Skills.Rows.Count - 1; i++)
                {
                    if (this.dataGridView_Skills.Rows[i].Cells[1].FormattedValue.ToString().ToLower().Contains(textBox_SearchSkillName.Text.ToLower()))
                    {
                        this.dataGridView_Skills.CurrentCell = this.dataGridView_Skills.Rows[i].Cells[1];
                        this.dataGridView_Skills_SelectionChanged(null, null);
                        break;
                    }
                    if (i == this.dataGridView_Skills.Rows.Count - 1 && k == 0)
                    {
                        k = 1;
                        i = 0;
                    }
                }
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeSkillId(Convert.ToInt32(this.dataGridView_Skills.CurrentRow.Cells[0].Value), Param);
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectSkillIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectSkillIdWindow_SelectedItemIndex = this.dataGridView_Skills.CurrentCell.RowIndex;
        }

        private void SelectSkillIdWindow_SizeChanged(object sender, EventArgs e)
        {
            ///if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectSkillIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6023);
            Column_SkillId.HeaderText = Extensions.GetLocalization(6024);
            Column_SkillName.HeaderText = Extensions.GetLocalization(6025);
            label1.Text = Extensions.GetLocalization(6026);
            label2.Text = Extensions.GetLocalization(6027);
            button_Ok.Text = Extensions.GetLocalization(6028);
            button_Cancel.Text = Extensions.GetLocalization(6029);
        }
	}
}
