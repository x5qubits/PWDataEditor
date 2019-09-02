using ElementEditor;
using ElementEditor.classes;
using JHUI;
using JHUI.Forms;
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
    public partial class ImportConfigEditor : JForm
    {
        private string ImportSettingBaseDir;
        private string opendVilePath;
        private ConvertElements currentconfig = new ConvertElements();
        public ImportConfigEditor()
        {
            ImportSettingBaseDir = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Import_Configs\\";
            InitializeComponent();
        }

        private void ReplaceEditor_Shown(object sender, EventArgs e)
        {

        }

        private void jButton2_Click(object sender, EventArgs e)
        {
            int MajorVersion = 0;
            int MinorVersion = 0;
            string versionFromt = versionFromBox1.Text;
            string versionTot = versionFromBox2.Text;
            bool isInt1 = int.TryParse(versionFromt, out MajorVersion);
            bool isInt2 = int.TryParse(versionTot, out MinorVersion);
            if(!isInt1 || !isInt2)
            {
                JMessageBox.Show(this, "Value from/to must be a number!");
                return;
            }
            opendVilePath = Path.Combine(ImportSettingBaseDir, ""+ MajorVersion +"-"+ MinorVersion+".ini");
            currentconfig = new ConvertElements();
            currentconfig.versionFrom = MajorVersion; // IF EXPORT COMES FROM VERSION
            currentconfig.versionTo = MinorVersion; // IF CURRENT ELEMENTS IS VERSION
            currentconfig.lists = new Dictionary<int, Dictionary<int, RowIndexesExport>>();
            listBox_items.Rows.Clear();
            if (File.Exists(opendVilePath))
            {
                using (StreamReader sr = new StreamReader(opendVilePath))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            if (line.StartsWith("#"))
                            {
                            }
                            else
                            {
                                try
                                {
                                    string[] rule = line.ToString().Trim().Split('_');
                                    if (rule.Length == 4)
                                    {
                                        int LIST = int.Parse(rule[0]);
                                        if (!currentconfig.lists.ContainsKey(LIST))
                                        {
                                            currentconfig.lists.Add(LIST, new Dictionary<int, RowIndexesExport>());
                                        }
                                        int ROWID = int.Parse(rule[1]);
                                        REPLACEOPERATION OPERATION = (REPLACEOPERATION)int.Parse(rule[2]);
                                        string VALUE = rule[3];
                                        RowIndexesExport data = new RowIndexesExport();
                                        data.LIST = LIST;
                                        data.ROWID = ROWID;
                                        data.OPERATION = OPERATION;
                                        data.VALUE = VALUE;
                                        currentconfig.lists[LIST].Add(ROWID, data);
                                        DataGridViewRow row = (DataGridViewRow)listBox_items.RowTemplate.Clone();
                                        row.CreateCells(listBox_items);
                                        row.Height = 22;
                                        row.Cells[0].Value = LIST.ToString();
                                        row.Cells[1].Value = ROWID.ToString();
                                        row.Cells[3].Value = VALUE.ToString();
                                        row.Cells[2].Value = (row.Cells[2] as DataGridViewComboBoxCell).Items[(int)OPERATION];
                                        listBox_items.Rows.Add(row);
                                    }
                                }
                                catch
                                {
                                    JMessageBox.Show(this, "There was a problem with ImportConfig " + MajorVersion + "_" + MinorVersion + ".ini skipng file. Please fix it.");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ReplaceEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            MainProgram.getInstance().ReloadConfigs();
        }

        private void SaveButton(object sender, EventArgs e)
        {

            int MajorVersion = 0;
            int MinorVersion = 0;
            string versionFromt = versionFromBox1.Text;
            string versionTot = versionFromBox2.Text;
            bool isInt1 = int.TryParse(versionFromt, out MajorVersion);
            bool isInt2 = int.TryParse(versionTot, out MinorVersion);
            if (!isInt1 || !isInt2)
            {
                JMessageBox.Show(this, "Value from/to must be a number!");
                return;
            }
            opendVilePath = Path.Combine(ImportSettingBaseDir, "" + MajorVersion + "-" + MinorVersion + ".ini");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#LIST_ROWID_OPERATION_VALUE");
            sb.AppendLine("# VALUE CAN BE ANYTHING BUT IT MUST MATCH ADDED REPLACED VALUE");
            sb.AppendLine("# OPERATION = 0=DELETE ROW, 1=ADD(MUST HAVE VALUE) 2=REPLACE(MUST HAVE VALUE)");
            sb.AppendLine("#");
            sb.AppendLine("#");
            sb.AppendLine("#REPLACE RULES PLEASE EDIT IF YOU LIKE");
            for (int r = 0; r < listBox_items.Rows.Count; r++)
            {
                DataGridViewRow row = listBox_items.Rows[r];
                string ListID = row.Cells[0].Value.ToString();
                string RowID = row.Cells[1].Value.ToString();
                DataGridViewComboBoxCell dcc = (row.Cells[2] as DataGridViewComboBoxCell);
                int operation = dcc.Items.IndexOf(dcc.Value);
                string value = row.Cells[3].Value.ToString();
                sb.AppendLine(""+ ListID + "_" + RowID + "_" + operation + "_" + value + "");
            }
            sb.AppendLine("#THA END");
            File.WriteAllText(opendVilePath, sb.ToString());
            MainProgram.getInstance().ReloadConfigs();
            JMessageBox.Show(this, "All done!");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)listBox_items.RowTemplate.Clone();
            row.CreateCells(listBox_items);
            row.Height = 22;
            row.Cells[0].Value = ElementsEditor.SelectedList;
            row.Cells[1].Value = ElementsEditor.SelectedRow;
            row.Cells[3].Value = "0";
            row.Cells[2].Value = (row.Cells[2] as DataGridViewComboBoxCell).Items[2];
            listBox_items.Rows.Add(row);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox_items.CurrentCell != null)
            {
                listBox_items.Rows.RemoveAt(listBox_items.CurrentCell.RowIndex);
            }
        }
    }
}
