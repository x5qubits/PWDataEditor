using ElementEditor;
using PWDataEditorPaied;
using PWDataEditorPaied.Database;
using SkillXMLEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectWorldAccountManager
{
    public partial class SkillSelector : Form
    {
        public IDictionary<int, SkillText> skillNames = new Dictionary<int, SkillText>();

        public SkillSelector()
        {
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
                    this.skillNames.Add(skillText.id, skillText);
                    goto IL_701;
                }
                catch
                {
                    goto IL_701;
                }
                IL_701:;
            }
            InitializeComponent();
            populateSkills();
        }

        private int lastId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int currentid = 0;
            if(dataGridView1.SelectedRows != null)
            {
                lastId = dataGridView1.SelectedRows[0].Index;
            }
            if(lastId > dataGridView1.Rows.Count)
            {
                lastId = 0;
            }
            bool found = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                string name = r.Cells[2].Value.ToString().Trim().ToLower();
                string searchvalue = textBox1.Text.Trim().ToLower();
                if (lastId < currentid && name.Contains(searchvalue))
                {
                    found = true;
                    lastId = currentid;
                    dataGridView1.CurrentCell = dataGridView1.Rows[currentid].Cells[0];
                    dataGridView1.Rows[currentid].Selected = true;
                    break;
                }
                currentid++;
            }
            if(!found)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Rows[0].Selected = true;
            }

        }

        private void populateSkills()
        {
            
            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<int, SkillText> data in skillNames)
            {
                Bitmap bmp = DatabaseManager.getSkillIcon(data.Value.id);
                dataGridView1.Rows.Add(new object[] { data.Key, bmp, data.Value.name });
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (skillNames.ContainsKey(index))
                {
                    SkillText skt = skillNames[index];
                    Skill sk = new Skill(skt.id, skt.name, skt.icon);
                    //AssetManager.skillConfigs[clasID].Add(sk);
                    this.Close();
                }
            }
            catch { }
        }
    }
}
