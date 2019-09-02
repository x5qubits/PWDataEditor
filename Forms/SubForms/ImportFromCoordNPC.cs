using ElementEditor;
using JHUI.Forms;
using PWnpcEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied.Forms.SubForms
{
    public partial class ImportFromCoordNPC : JForm
    {
        private NpcEditor editor = null;
        public ImportFromCoordNPC(NpcEditor editor)
        {
            this.editor = editor;
            InitializeComponent();
        }
        public class Mobs
        {
            internal int id;
            internal string x;
            internal string y;
            internal string z;

            public string Name { get; internal set; }
            public string Type { get; internal set; }
        }
        private Dictionary<string, List<Mobs>> database = new Dictionary<string, List<Mobs>>();
        private List<Mobs>  display = new List<Mobs>();
        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            if (Exporting) return;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            ///MOB
            //MINE
            //NPC
            openFileDialog1.Filter = "coord_data.txt (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            jComboBox2.SelectedIndex = 2;
            openFileDialog1.Multiselect = true;
            jComboBox1.Items.Clear();
            database = new Dictionary<string, List<Mobs>>();
            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                string[] temp = sr.ReadToEnd().Split(new char[1] { '\n' });
                for(int i = 1; i < temp.Length;i++)
                {
                    try
                    {
                        string[] data = temp[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        int entityId = 0;
                        bool isEntity = int.TryParse(data[0], out entityId);
                        if (isEntity)
                        {
                            string mapID = data[1];
                            mapID = mapID.Length > 0 ? mapID : "all";
                            mapID = mapID.ToLower().Trim();
                            Mobs mob = new Mobs();
                            string[] test = data[2].Split(',');
                            if (test.Length > 1)
                            {
                                mob.x = test[0].Trim();
                                mob.y = test[1].Trim();
                                mob.z = test[2].Trim();
                            }else
                            {
                                mob.x = data[2].Trim();
                                mob.y = data[3].Trim();
                                mob.z = data[4].Trim();
                            }
                            mob.id = entityId;

                            if (database.ContainsKey(mapID))
                            {
                                database[mapID].Add(mob);
                            }else
                            {
                                database[mapID] = new List<Mobs>();
                                database[mapID].Add(mob);
                                jComboBox1.Items.Add(mapID);
                            }
                        }
                    }
                    catch { }
                }

                sr.Close();
                try
                {
                    jComboBox1.SelectedIndex = 0;
                }
                catch { }
            }
        }
        private int type = 0;
        private bool reading = false;
        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Exporting) return;
            reading = true;
            //Mobs
            //Resources
            //NPCS
            display = new List<Mobs>();
            listBox_items.SuspendLayout();
            listBox_items.Rows.Clear();
            if (database != null && database.Count > 0 && jComboBox1.SelectedIndex != -1)
            {
                if (database.ContainsKey(jComboBox1.Items[jComboBox1.SelectedIndex].ToString()))
                {
                    foreach (Mobs mob in database[jComboBox1.Items[jComboBox1.SelectedIndex].ToString()])
                    {
                        ElementsEditor elementsEditor = ElementsEditor.Instance;
                        if (elementsEditor != null && ElementsEditor.eLC != null)
                        {
                            if(ElementsEditor.eLC.MONSTERS.ContainsKey(mob.id) && jComboBox2.SelectedIndex == 0)
                            {
                                mob.Name = ElementsEditor.eLC.MONSTERS[mob.id].name;
                                mob.Type = "MOB";
                                display.Add(mob);
                                type = 1;
                            }
                            else if (ElementsEditor.eLC.NPCS.ContainsKey(mob.id) && jComboBox2.SelectedIndex == 2)
                            {
                                mob.Name = ElementsEditor.eLC.NPCS[mob.id].name;
                                mob.Type = "NPC";
                                display.Add(mob);
                                type = 0;
                            }
                            else if (ElementsEditor.eLC.RESOURCES.ContainsKey(mob.id) && jComboBox2.SelectedIndex == 1)
                            {
                                mob.Name = ElementsEditor.eLC.RESOURCES[mob.id].name;
                                mob.Type = "MINE";
                                display.Add(mob);
                                type = 2;
                            }
                            else
                            {
                                if(jCheckBox1.Checked)
                                    listBox_items.Rows.Add(new object[] { mob.id, "Load Elements", "UNK", mob.x, mob.y, mob.z });
                            }
                        }
                        else
                        {
                            if (jCheckBox1.Checked)
                                listBox_items.Rows.Add(new object[] { mob.id, "Load Elements", "UNK", mob.x, mob.y, mob.z });
                        }
                        
                    }
                    foreach(Mobs mob in display)
                    {
                        listBox_items.Rows.Add(new object[] { mob.id, mob.Name, mob.Type, mob.x, mob.y, mob.z });
                    }
                }
            
            }
            listBox_items.ResumeLayout();
            listBox_items.PerformLayout();
            reading = false;
        }
        private bool Exporting = false;
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(jCheckBox1.Checked)
            {
                MessageBox.Show("Sorry i dont know how to continue disable show unk.");
                return;
            }
            Exporting = true;
            try
            {
                List<Mobs> export = new List<Mobs>();
                if (editor != null)
                {
                    for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                    {
                        int index = listBox_items.SelectedRows[i].Index;
                        export.Add(display[index]);
                    }
                    editor.ImportData(type, display);
                }
            }
            catch(Exception c)
            {
                MessageBox.Show("Error:"+ c.ToString() + ".");
            }
            Exporting = false;

        }

        private void jComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Exporting) return;
            if (!reading)
                jComboBox1_SelectedIndexChanged(null, null);
        }
    }
}
