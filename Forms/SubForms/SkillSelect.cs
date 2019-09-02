using ElementEditor;
using JHUI.Forms;
using PWDataEditorPaied.Database;
using SkillXMLEditor;
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
    public partial class SkillSelect : JForm
    {
        private List<Skill> skills = new List<Skill>();
        private List<SkillText> skill_text = new List<SkillText>();
        private Dictionary<int, string> skill_name = new Dictionary<int, string>();
        private List<SkillText> current_skills = new List<SkillText>();
        private int lastId;

        public SkillSelect(FormStartPosition location = FormStartPosition.CenterParent)
        {
            this.StartPosition = location;
            InitializeComponent();
            this.StartPosition = location;
        }

        private void SkillSelect_Load(object sender, EventArgs e)
        {
            this.dataGridView_Skills.Rows.Clear();
            for (int num25 = 0; num25 < ElementsEditor.database.skillstr.Length - 1; num25 += 4)
            {
                try
                {
                    SkillText skillText = new SkillText();
                    string[] strArray14 = new string[]
                    {
                        ElementsEditor.database.skillstr[num25 + 1].ToString()
                    };
                    skillText.id = Convert.ToInt32(Convert.ToInt32(ElementsEditor.database.skillstr[num25]).ToString().Substring(0, Convert.ToString(Convert.ToInt32(ElementsEditor.database.skillstr[num25])).Length - 1));
                    skillText.name = ElementsEditor.database.skillstr[num25 + 1].ToString();
                    this.skill_text.Add(skillText);
                    if (!this.skill_name.ContainsKey(skillText.id))
                    {
                        this.skill_name.Add(skillText.id, skillText.name);
                    }
                    this.dataGridView_Skills.Rows.Add(new object[] { skillText.id, DatabaseManager.getSkillIcon(skillText.id), skillText.name });
                    goto IL_701;
                }
                catch
                {
                    MessageBox.Show(Extensions.GetLocalization(465));
                    goto IL_701;
                }
                IL_701:;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                this.skills = new SkillXML().Read(Clipboard.GetText());
                this.loadData();
            }
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
                Clipboard.SetText(this.xml.Text);
            }
        }

        private void loadData()
        {
            int lindex = 0;
            if(this.SkillsList.CurrentCell != null)
            {
                lindex = this.SkillsList.CurrentCell.RowIndex;
            }
            this.SkillsList.Rows.Clear();
            for (int index = 0; index < this.skills.Count; ++index)
            {
                string str = this.skill_name.ContainsKey(this.skills[index].id) ? this.skill_name[this.skills[index].id] : "Unknown";
                this.skills[index].name = str;
                this.SkillsList.Rows.Add(new object[] { this.skills[index].id, DatabaseManager.getSkillIcon(this.skills[index].id), this.skills[index].name, this.skills[index].lvl });
            }
            if(lindex > 0)
            {
                try
                {
                    SkillsList.Rows[lindex].Selected = true;
                    SkillsList.CurrentCell = SkillsList.Rows[lindex].Cells[0];
                }
                catch { }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private int FindIndex2(string text)
        {
            int id = 0;
            foreach (SkillText policy in this.skill_text)
            {
                if (policy.name.ToLower().Trim().Contains(text.ToLower().Trim()))
                    return id;
                else
                    id++;
            }
            return id;
        }

        public int FindIndex(int ID)
        {
            int id = 0;
            foreach (SkillText policy in this.skill_text)
            {
                if (policy.id == ID)
                    return id;
                else
                    id++;
            }
            return id;
        }

        private void dataGridView_Skills_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dataGridView_Skills.CurrentCell != null)
            {
                int index = dataGridView_Skills.CurrentCell.RowIndex;
                SkillText skill = this.skill_text[index];
                bool continuex = true;
                foreach (DataGridViewRow row in SkillsList.Rows)
                {
                    int level = int.Parse(row.Cells[0].Value.ToString());
                    if(skill.id == level)
                    {
                        continuex = false;
                        break;
                    }
                }
                Skill sk = new Skill();
                sk.id = skill.id;
                sk.lvl = 1;
                sk.name = skill.name;
                if (continuex)
                {
                    this.SkillsList.Rows.Add(new object[] { sk.id, DatabaseManager.getSkillIcon(sk.id), sk.name, 1 });
                    //this.SkillsList.Rows.Add(new object[] { this.skills[index].id, AssetManager.getSkillIcon(this.skills[index].id), this.skills[index].name, this.skills[index].lvl });
                    this.skills.Add(sk);
                    redrawGrid();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SkillsList.CurrentCell != null)
            {
                int index = SkillsList.CurrentCell.RowIndex;
                this.skills.RemoveAt(index);
                SkillsList.Rows.RemoveAt(index);
                redrawGrid();
            }
        }

        private void redrawGrid()
        {
            foreach (DataGridViewRow row in SkillsList.Rows)
            {
                int level = int.Parse(row.Cells[3].Value.ToString());
                this.skills[row.Index].lvl = level;
            }
            this.xml.Text = new SkillXML().Save(this.skills);
            this.skills = new SkillXML().Read(this.xml.Text);
            this.loadData();
        }

        private void SkillsList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            redrawGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.xml.Text = new SkillXML().Save(this.skills);
            Clipboard.SetText(this.xml.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentid = 0;
            if (dataGridView_Skills.SelectedRows != null)
            {
                lastId = dataGridView_Skills.SelectedRows[0].Index;
            }
            if (lastId > dataGridView_Skills.Rows.Count)
            {
                lastId = 0;
            }
            bool found = false;
            foreach (DataGridViewRow r in dataGridView_Skills.Rows)
            {
                string name = r.Cells[2].Value.ToString().Trim().ToLower();
                string searchvalue = textBox1.Text.Trim().ToLower();
                if (lastId < currentid && name.Contains(searchvalue))
                {
                    found = true;
                    lastId = currentid;
                    dataGridView_Skills.CurrentCell = dataGridView_Skills.Rows[currentid].Cells[0];
                    dataGridView_Skills.Rows[currentid].Selected = true;
                    break;
                }
                currentid++;
            }
            if (!found)
            {
                dataGridView_Skills.CurrentCell = dataGridView_Skills.Rows[0].Cells[0];
                dataGridView_Skills.Rows[0].Selected = true;
            }
        }
    }
}
