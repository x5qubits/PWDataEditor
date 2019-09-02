using ElementEditor.classes;
using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PWDataEditorPaied
{
    public partial class EncryptedListRip : JForm
    {
        public eListCollection eLC;
        private int list_id;
        private string sameFile = "";
        public EncryptedListRip()
        {
            InitializeComponent();
        }

        public bool BrakeReading = false;
        public bool Blocked = false;

        public int LastList = -1;
        public string LastAddress = "";

        public void Progress_bar(String value, int min, int max)
        {

            progres.Text = value;
            if (min == 0 && max == 0)
            {
                progressBar1.Value = 0;

            }
            else
            {
                int val = (100 * min) / max;
                progressBar1.Value = val <= 100 ? val : 100;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs exxx)
        {
            BrakeReading = false;
            list_id = 0;
            bool isParse = int.TryParse(textBox2.Text, out list_id);
            if (!isParse)
            {
                MessageBox.Show("Please specify the list!");
                return;
            }
            LastList = list_id;
            bool tryparse2 = int.TryParse(textBox4.Text, out int version);
            if(!tryparse2)
            {
                MessageBox.Show("Please specify an element version!");
                return;
            }

            bool tryparse3 = int.TryParse(textBox3.Text, out int countx);

            OpenFileDialog eLoad = new OpenFileDialog
            {
                Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*",
                RestoreDirectory = false
            };
            if (eLoad.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(eLoad.FileName))
            {
                GC.Collect();
                sameFile = eLoad.FileName;
                try
                {
                    Blocked = true;
                    LastAddress = textBox1.Text;
                    eLC = new eListCollection();
                    eLC.progress_bar += Progress_bar;
                    eList[] Li = new eList[0];
                    Li = eLC.LoadEmptyConfigs(version);
                    eLC.Lists = Li;
                    listBox_items.Rows.Clear();
                    using (FileStream fs = File.OpenRead(eLoad.FileName))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            int pos = Convert.ToInt32(textBox1.Text.ToUpper().Trim().Normalize(), 16);
                            br.BaseStream.Seek(pos, SeekOrigin.Begin);
                            for (int l = list_id; l < list_id + 1; l++)
                            {
                                eLC.Lists[l].elementValues = new SortedList<int, SortedList<int, object>>();
                                eLC.Lists[l].elementPosition = new SortedList<int, int>();

                                for (int e = 0; e < (tryparse3 && countx > 0 ? countx : 999999); e++)
                                {
                                    eLC.Lists[l].elementValues[e] = new SortedList<int, object>();
                                    Application.DoEvents();
                                    Progress_bar("Read :" + e + "/" + 99999, e, 99999);
                                    try
                                    {
                                        for (int f = 0; f < eLC.Lists[l].elementTypes.Length; f++)
                                        {
                                            eLC.Lists[l].elementValues[e][f] = eLC.ReadValue(br, eLC.Lists[l].elementTypes[f]);

                                            if (eLC.Lists[l].elementFields[f] == "Name")
                                            {
                                                int id = Int32.Parse(eLC.Lists[l].elementValues[e][0].ToString());
                                                bool isNegative = (id & (1 << 31)) != 0;
                                                if (isNegative)
                                                    break;
                                                listBox_items.Rows.Add(new object[] { id.ToString(), eLC.Lists[l].GetValue(e, f) });

                                                if (checkBox1.Checked)
                                                {
                                                    Application.DoEvents();
                                                    listBox_items.Rows[e].Selected = true;
                                                    listBox_items.CurrentCell = listBox_items.Rows[e].Cells[0];
                                                }
                                            }

                                        }

                                        eLC.Lists[l].elementPosition[e] = (Int32)br.BaseStream.Position;
                                        textBox5.Text = eLC.Lists[l].elementPosition[e].ToString("X4").ToUpper();
                                    }
                                    catch
                                    {
                                        break;
                                    }

                                    if (BrakeReading)
                                        break;
                                }
                            }

                            BrakeReading = false;
                            Blocked = false;
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void ListBox_items_SelectionChanged(object sender, EventArgs e)
        {
            if (Blocked) return;

            int list = list_id;
            try
            {
                int element = listBox_items.CurrentCell.RowIndex;
                Application.DoEvents();
                int pos = eLC.Lists[list].elementPosition[element];
                textBox5.Text = pos.ToString("X4").ToUpper();
                dataGridView_item.Rows.Clear();
                for (int f = 0; f < eLC.Lists[list].elementValues[element].Count; f++)
                {
                    dataGridView_item.Rows.Add(new object[] { f.ToString(), eLC.Lists[list].elementFields[f].Replace('_', ' ') , eLC.GetValue(list, element, f) });
                }
            }catch
            {

            }
            Progress_bar("Done", 0, 0);
        }
        private SortedList<int, SortedList<int, object>> resortDic(SortedList<int, SortedList<int, object>> data)
        {
            SortedList<int, SortedList<int, object>> datanew = new SortedList<int, SortedList<int, object>>();
            int i = 0;
            foreach (KeyValuePair<int, SortedList<int, object>> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }
        private void ListBox_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
                ExportClipboardwithNorules();
            }
            if (e.KeyData ==  Keys.Delete)
            {

                if (list_id > -1)
                {
                    int l = list_id;
                    int xe = listBox_items.CurrentCell.RowIndex;
                    DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                    for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        Progress_bar("Deleting ...", x, listBox_items.SelectedRows.Count);
                        int idx = listBox_items.SelectedRows[x].Index;
                        if (l != eLC.ConversationListIndex)
                        {
                            eLC.Lists[l].RemoveItem(l, idx);
                        }
                    }
                    for (int i = selected.Count - 1; i >= 0; i--)
                    {
                        listBox_items.Rows.Remove(selected[i]);
                    }
                    // if (comboBox_lists.SelectedIndex == 69)
                    // {

                    //}
                    eLC.Lists[l].elementValues = resortDic(eLC.Lists[l].elementValues);
                    Progress_bar("Ready", 0, 0);

                }
                else
                {
                    MessageBox.Show("Please select a item!");
                }
            }
        }

        public void CopyToClipboard(Export objectToCopy)
        {
            string format = "MyImporting";
            Clipboard.Clear();
            Clipboard.SetData(format, objectToCopy);
        }

        private void ExportClipboardwithNorules()
        {
            int l = list_id; 
            int xe = listBox_items.CurrentCell.RowIndex;
            if (xe > -1)
            {
                try
                {
                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export();
                        export.ListId = l;
                        export.type = 0; //Elements data = 0 | Gshop = 1 
                        export.Version = eLC.Version;
                        export.RowCount = eLC.Lists[l].elementFields.Length;
                        export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            Progress_bar("Copying ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            export.data.Add(i, eLC.Lists[l].elementValues[index]);
                        }
                        CopyToClipboard(export);
                    }
                }
                catch (Exception)
                {

                }
                Progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");

            }
        }

        private void JButton1_Click(object sender, EventArgs e)
        {
            if(listBox_items.CurrentCell == null)
            {
                MessageBox.Show("Please select last element from this list");
                return;
            }
            int list = list_id;
            try
            {
                LastAddress = textBox1.Text;
                LastList = list_id;
                int element = listBox_items.CurrentCell.RowIndex;
                int pos = eLC.Lists[list].elementPosition[element] + int.Parse(textBox6.Text);
                textBox1.Text = pos.ToString("X4").ToUpper();
                textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();
                OpenSameFile();
            }
            catch
            {

            }

        }


        private void OpenSameFile()
        {
            list_id = 0;
            bool isParse = int.TryParse(textBox2.Text, out list_id);
            if (!isParse)
            {
                MessageBox.Show("Please specify the list!");
                return;
            }
          
            bool tryparse2 = int.TryParse(textBox4.Text, out int version);
            if(!tryparse2)
            {
                MessageBox.Show("Please specify an element version!");
                return;
            }

            bool tryparse3 = int.TryParse(textBox3.Text, out int countx);


            if (sameFile != null)
            {
                GC.Collect();
                try
                {
                    Blocked = true;
                    eLC = new eListCollection();
                    eList[] Li = new eList[0];
                    Li = eLC.LoadEmptyConfigs(version);
                    eLC.Lists = Li;
                    listBox_items.Rows.Clear();

                    
                    using (FileStream fs = File.OpenRead(sameFile))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            int pos = Convert.ToInt32(textBox1.Text.ToUpper().Trim().Normalize(), 16);
                            br.BaseStream.Seek(pos, SeekOrigin.Begin);
                            for (int l = list_id; l < list_id + 1; l++)
                            {
                                eLC.Lists[l].elementValues = new SortedList<int, SortedList<int, object>>();
                                eLC.Lists[l].elementPosition = new SortedList<int, int>();

                                for (int e = 0; e < (tryparse3 && countx > 0 ? countx : 999999); e++)
                                {
                                    eLC.Lists[l].elementValues[e] = new SortedList<int, object>();
                                    Application.DoEvents();
                                    Progress_bar("Read :" + e + "/" + 99999, e, 99999);
                                    try
                                    {
                                        for (int f = 0; f < eLC.Lists[l].elementTypes.Length; f++)
                                        {
                                            eLC.Lists[l].elementValues[e][f] = eLC.ReadValue(br, eLC.Lists[l].elementTypes[f]);

                                            if (eLC.Lists[l].elementFields[f] == "Name")
                                            {
                                                int id = Int32.Parse(eLC.Lists[l].elementValues[e][0].ToString());
                                                bool isNegative = (id & (1 << 31)) != 0;
                                                if (isNegative)
                                                    break;
                                                listBox_items.Rows.Add(new object[] { id.ToString(), eLC.Lists[l].GetValue(e, f) });



                                                if (checkBox1.Checked)
                                                {
                                                    Application.DoEvents();
                                                    listBox_items.Rows[e].Selected = true;
                                                    listBox_items.CurrentCell = listBox_items.Rows[e].Cells[0];
                                                }
                                            }

                                        }

                                        eLC.Lists[l].elementPosition[e] = (Int32)br.BaseStream.Position;
                                        textBox5.Text = eLC.Lists[l].elementPosition[e].ToString("X4").ToUpper();
                                    }
                                    catch
                                    {
                                        break;
                                    }

                                    if (BrakeReading)
                                        break;
                                }
                            }

                            BrakeReading = false;
                            Blocked = false;
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            
        }

        private void jButton2_Click(object sender, EventArgs e)
        {
            BrakeReading = true;
        }

        private void jButton3_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Text = LastAddress.ToUpper();
                textBox2.Text = LastList.ToString();
                OpenSameFile();
            }
            catch
            {

            }
        }
    }
}
