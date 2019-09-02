using AndBurn.DDSReader;
using ElementEditor.classes;
using ElementEditor.classes.helper;
using ElementEditor.Element_Editor_Classes;
using ElementEditor.helper_classes;
using PerfectWorldAccountManager;
using PWDataEditorPaied;
using PWDataEditorPaied.Element_Editor_Classes;
using PWDataEditorPaied.helper_classes;
using PWDataEditorPaied.Properties;
using PWnpcEditor;
using SkillXMLEditor;
using sTASKedit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace ElementEditor
{

    public partial class ElementsEditor : Form
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;

        public int defWidth = 932;
        public int defHeight = 709;
        public static int rows = 0;
        public static int cols = 0;
        private Boolean locked = false;
        private eListCollection eLC;
        private eListConversation conversationList;
        public static int selectedMask = 0;
        public static String selectedImage = null;
        public static Configs configs = null;
        public static CacheSave database = null;
        private ConvertElements currentConvertSettings = null;
        private int lastList = 0;
        private int lastItem = 0;
        private eListCollection empty_eLC;
        private Boolean lock2 = false;
        private Boolean firstLoad = true;


        public bool lock3 = false;
        private IToolType customTooltype;

        public ElementsEditor()
        {
            InitializeComponent();
            database = new CacheSave();
            sale = elementIntoTab.TabPages[1];
            craft = elementIntoTab.TabPages[2];
            elementIntoTab.TabPages.Remove(sale);
            elementIntoTab.TabPages.Remove(craft);
            comboBox3.SelectedIndex = 0;
        }
        private TabPage sale = null;
        private TabPage craft = null;

        public bool newAutoLoad(string _path)
        {
            Application.DoEvents();
            replaceSelected.SelectedIndex = 0;
            if (ElementsEditor.configs != null)
            {
                foreach (KeyValuePair<int, ConvertElements> entry in ElementsEditor.configs.currentConvertSettings)
                {
                    try
                    {
                        exportCombobox.Items.Add(entry.Value.versionFrom.ToString() + ">" + entry.Value.versionTo.ToString());
                        exportCombobox.SelectedIndex = 0;
                    }
                    catch (Exception) { }
                }
                Application.DoEvents();
                autonewId.Checked = configs.autoNewId;
                autonewIdCTRLV.Checked = configs.autonewIdCTRLV;
                checkBox3.Checked = configs.enableDisableLiveCacheRefresh;
                if (configs.nextAutoNewId != 0)
                {
                    nextautoIdlabel.Text = configs.nextAutoNewId.ToString();
                }


                autoOpenCache.Checked = configs.autoOpen;
                autoSaveCache.Checked = configs.autoSave;
                exportClipboardWithRules.Checked = configs.exportClipboardWithRules;
            }


            Application.DoEvents();
            autoLoadElements(_path);
            firstLoad = false;
            GC.Collect();
            return true;
        }

        private void reloadSettings(object sender, EventArgs e)
        {
            configs = new SystemCacheManager().getConfig();
        }

        public void saveConfigs()
        {
            new SystemCacheManager().setConfigs(configs);
        }

        public void saveCache()
        {
            if (ProfileView.profile == null) { return; }         
            progress_bar("Saving cache...", 0, 10);
            new SystemCacheManager().setCache(database);
            progress_bar("Ready", 0, 0);
        }

        public void progress_bar(String value, int min, int max)
        {
            if(progress_bar2 != null)
            {
                progress_bar2(value, min, max);
            }
            progres.Text = value;
            if (min == 0 && max == 0)
            {
                progressBar1.Value = 0;
                
                comboBox_lists.Enabled = true;
            }
            else
            {
                int val = (100 * min) / max;
                progressBar1.Value = val <= 100 ? val:100;
            }
        }



        public void autoLoadElements(string _path = "")
        {
            GC.Collect();
            String path = _path.Length>0 ? _path : configs.lastElementsLocation;
            try
            {
                if (TaskEditor.eLC != null)
                {
                    eLC = TaskEditor.eLC;
                    if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                    {
                        conversationList = new eListConversation((byte[])eLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
                    }
                    Application.DoEvents();
                    dataGridView_item.Rows.Clear();
                    listBox_items.Rows.Clear();
                    comboBox_lists.Items.Clear();
                    for (int l = 0; l < eLC.Lists.Length; l++)
                    {
                        comboBox_lists.Items.Add("[" + l + "] " + eLC.Lists[l].listName);
                    }
                    Application.DoEvents();
                    version_label.Text = eLC.Version.ToString();
                    Application.DoEvents();
                    comboBox_lists.SelectedIndex = 0;
                    if (eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Count == 0) { return; }
                    comboBox_lists.SelectedIndex = 0;
                    listBox_items.Rows[0].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                    listBox_items_CellClick(null, null);
                    if (autoSaveCache.Checked)
                    {
                        saveCache();
                    }
                }
                else
                {
                    eLC = new eListCollection();
                    eLC.progress_bar += progress_bar;
                    eLC.Lists = eLC.Load(_path);
                    if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                    {
                        conversationList = new eListConversation((byte[])eLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
                    }
                    Application.DoEvents();
                    dataGridView_item.Rows.Clear();
                    listBox_items.Rows.Clear();
                    comboBox_lists.Items.Clear();
                    for (int l = 0; l < eLC.Lists.Length; l++)
                    {
                        comboBox_lists.Items.Add("[" + l + "] " + eLC.Lists[l].listName);
                    }
                    Application.DoEvents();
                    version_label.Text = eLC.Version.ToString();

                    Application.DoEvents();
                    comboBox_lists.SelectedIndex = 0;
                    if (eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Count == 0) { return; }
                    comboBox_lists.SelectedIndex = 0;
                    listBox_items.Rows[0].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                    listBox_items_CellClick(null, null);
                    if (autoSaveCache.Checked)
                    {
                        saveCache();
                    }
                }
                Loadelements();
                if (this.Visible)
                    NewMainForm.getInstance().setText("P.W.D.E. - " + eLC.loadedFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("LOADING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch" + ex.ToString());
            }
            
            
        }

        private void Loadelements()
        {
            if(database.task_items != null)
            {
                TaskEditor.eLC = eLC;
            }
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\configs\\item_list_index.txt";
            progress_bar("Loading ...", 0, 0);
            try
            {
                if (eLC.Lists.Length > 0)
                {
                    int l = -1;
                    int pos = -1;
                    int posP = -1;
                    int posPrice = -1;
                    if (File.Exists(path))
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(path, Encoding.Unicode);
                            ElementsEditor.database.task_items_list = sr.ReadToEnd().Split(new char[3] { '\t', '\n', ' ' });

                            sr.Close();
                            ElementsEditor.database.task_items = new SortedList<int, ItemDupe>();
                            for (int k = 0; k < ElementsEditor.database.task_items_list.Length; k += 2)
                            {
                                if (eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[k + 1]))
                                {
                                    l = Convert.ToInt32(ElementsEditor.database.task_items_list[k]);
                                     pos = -1;
                                     posP = -1;
                                     posPrice = -1;
                                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                                    {
                                        if (eLC.Lists[l].elementFields[i] == "Name")
                                        {
                                            pos = i;

                                        }
                                        if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                                        {
                                            posP = i;
                                        }
                                        if (eLC.Lists[l].elementFields[i] == "price")
                                        {
                                            posPrice = i;
                                        }
                                        if (pos != -1 && posP != -1 && posPrice != -1)
                                        {
                                            break;
                                        }
                                    }
                                    for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                                    {
                                        int itemId = int.Parse(eLC.GetValue(l, e, 0));
                                        if (!ElementsEditor.database.task_items.ContainsKey(itemId))
                                        {
                                            ItemDupe item = new ItemDupe();
                                            item.itemId = itemId;
                                            item.listID = l;
                                            item.index = e;
                                            item.name = eLC.GetValue(l, e, pos);
                                            if (posP != -1)
                                            {
                                                try
                                                {
                                                    item.iconpath = Path.GetFileName(eLC.GetValue(l, e, posP)).ToLower();
                                                }
                                                catch (Exception asd)
                                                {

                                                }
                                            }
                                            if (posPrice != -1)
                                            {
                                                item.price = eLC.GetValue(l, e, posPrice);
                                            }
                                            ElementsEditor.database.task_items.Add(itemId, item);
                                        }

                                    }
                                }
                            }
                            
                        }
                        catch (Exception xe)
                        {
                            MessageBox.Show("ERROR LOADING ITEM LISTS\n" + xe.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("NOT FOUND item_list_index.txt!");
                    }
                    ElementsEditor.database.monsters_npcs_mines = new SortedList();
                    for (int k = 0; k < TaskEditor.monster_npc_minelists.Count; k++)
                    {
                        progress_bar("Importing info...", k, TaskEditor.monster_npc_minelists.Count);
                        Application.DoEvents();
                        
                        l = (int)TaskEditor.monster_npc_minelists[k];
                        pos = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos = i;
                                break;
                            }
                        }
                        for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                        {
                            if (!ElementsEditor.database.monsters_npcs_mines.ContainsKey(eLC.GetValue(l, e, 0)))
                            {
                                ElementsEditor.database.monsters_npcs_mines.Add(eLC.GetValue(l, e, 0), eLC.GetValue(l, e, pos));
                            }
                        }
                    }

                    if (eLC.Version >= 87)
                    {
                        ElementsEditor.database.titles = new SortedList();
                        l = 169;
                        int pos1 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos1 = i;
                                break;
                            }
                        }
                        for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                        {
                            if (!ElementsEditor.database.titles.ContainsKey(eLC.GetValue(l, e, 0)))
                            {
                                ElementsEditor.database.titles.Add(eLC.GetValue(l, e, 0), eLC.GetValue(l, e, pos1));
                            }
                        }
                    }

                    if (eLC.Version >= 153)
                    {
                        ElementsEditor.database.homeitems = new SortedList();
                        l = 223;
                        int pos2 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos2 = i;
                                break;
                            }
                        }
                        for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                        {
                            if (!ElementsEditor.database.homeitems.ContainsKey(eLC.GetValue(l, e, 0)))
                            {
                                ElementsEditor.database.homeitems.Add(eLC.GetValue(l, e, 0), eLC.GetValue(l, e, pos2));
                            }
                        }
                    }

                    ElementsEditor.database.task_recipes = new SortedList<int, ItemDupe>();
                     l = 69;
                     pos = -1;
                     posP = -1;
                     posPrice = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;

                        }
                        if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                        {
                            posP = i;
                        }
                        if (eLC.Lists[l].elementFields[i] == "price")
                        {
                            posPrice = i;
                        }
                        if (pos != -1 && posP != -1 && posPrice != -1)
                        {
                            break;
                        }
                    }
                    for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                    {
                        int itemId = int.Parse(eLC.GetValue(l, e, 0));
                        if (!ElementsEditor.database.task_recipes.ContainsKey(itemId))
                        {
                            ItemDupe item = new ItemDupe();
                            item.itemId = itemId;
                            item.listID = l;
                            item.index = e;
                            item.name = eLC.GetValue(l, e, pos);
                            if (posP != -1)
                            {
                                item.iconpath = Path.GetFileName(eLC.GetValue(l, e, posP)).ToLower();
                            }
                            if (posPrice != -1)
                            {
                                item.price = eLC.GetValue(l, e, posPrice);
                            }
                            ElementsEditor.database.task_recipes.Add(itemId, item);
                        }

                    }

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
                            eLC.skillNames[skillText.id] = skillText;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Extensions.GetLocalization(478));
            }
            if (configs.nextAutoNewId == 0)
            {

                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                nextautoIdlabel.Text = configs.nextAutoNewId.ToString();
            }


            TaskEditor.eLC = eLC;
            progress_bar("Ready", 0, 0);
            
            
        }

        public void setIndex(ItemDupe item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    setIndex(item);
                    return;
                }));
            }
            try
            {
            comboBox_lists.SelectedIndex = item.listID;
            comboBox_lists.Enabled = true;
            listBox_items.Enabled = true;
            listBox_items.Rows[item.index].Selected = true;
            listBox_items.CurrentCell = listBox_items.Rows[item.index].Cells[0];
            listBox_items_CellClick(null, null);
            listBox_items.PerformLayout();
            }
            catch { }
        }

        public void setIndex(BookMark item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    setIndex(item);
                    return;
                }));
            }
            try
            {
                comboBox_lists.SelectedIndex = item.listIndex;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                listBox_items.Rows[item.elementIndex].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[item.elementIndex].Cells[0];
                listBox_items_CellClick(null, null);
                dataGridView_item.Rows[item.rowIndex].Selected = true;
                dataGridView_item.CurrentCell = dataGridView_item.Rows[item.rowIndex].Cells[0];

                //listBox_items.Refresh();
                listBox_items.PerformLayout();
            }
            catch { }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog eLoad = new OpenFileDialog();
            eLoad.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            eLoad.RestoreDirectory = false;
            if (eLoad.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(eLoad.FileName))
            {
                GC.Collect();
                try
                {
                    eLC = new eListCollection();
                    eLC.progress_bar += progress_bar;
                    configs.lastElementsLocation = eLoad.FileName;
                    eLC.Lists = eLC.Load(eLoad.FileName);

                    if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                    {
                        conversationList = new eListConversation((byte[])eLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
                    }
                    Application.DoEvents();
                    dataGridView_item.Rows.Clear();
                    listBox_items.Rows.Clear();
                    comboBox_lists.Items.Clear();
                    for (int l = 0; l < eLC.Lists.Length; l++)
                    {
                        comboBox_lists.Items.Add("["+ l + "] "+eLC.Lists[l].listName);
                    }
                    Application.DoEvents();
                    //path_label.Text = eLoad.FileName;
                    version_label.Text = eLC.Version.ToString();

                    Application.DoEvents();
                    comboBox_lists.SelectedIndex = 0;
                    if (eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Count == 0) { return; }
                    comboBox_lists.SelectedIndex = 0;
                    listBox_items.Rows[0].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                    listBox_items_CellClick(null, null);
                    if(autoSaveCache.Checked)
                    {
                        saveCache();
                    }
                    Loadelements();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LOADING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch" + ex.ToString());
                }
            }
            
            
        }


        private int proctypeLocation = 0;
        private int proctypeLocationvak = 0;
        private void listBox_items_CellClick(object sender, EventArgs e)
        {
            if (locked) { return; }
            if (lock3) { return; }
            int list = comboBox_lists.SelectedIndex;
            if (listBox_items.CurrentCell == null) { return; }
            int element = listBox_items.CurrentCell.RowIndex;
            int scroll = dataGridView_item.FirstDisplayedScrollingRowIndex;
            int saveInfoTabindex = tabControl2.SelectedIndex;
            dataGridView_item.SuspendLayout();
            dataGridView_item.Rows.Clear();
            proctypeLocation = 0;
            proctypeLocationvak = 0;
            if (list != eLC.ConversationListIndex)
            {
                // lastInfo = null;
                tabControl2.SelectedIndex = 0;
                //comboBox_lists.Enabled = false;
                if (element > -1 && element < eLC.Lists[list].elementValues.Count)
                {
                    Application.DoEvents();
                    progress_bar("Loading ...", 0, 100);
                    dataGridView_item.Enabled = false;
                    for (int f = 0; f < eLC.Lists[list].elementValues[element].Count; f++)
                    {

                        DataGridViewRow row = (DataGridViewRow)dataGridView_item.RowTemplate.Clone();
                        row.CreateCells(dataGridView_item);
                        row.Cells[0].Value = f.ToString();
                        row.Cells[1].Value = eLC.Lists[list].elementFields[f].Replace('_', ' ');

                        switch (eLC.Lists[list].elementFields[f])
                        {
                            case "file_icon":
                            case "file_icon1":
                                DataGridViewImageCell cell = new DataGridViewImageCell();

                                String file_icon = eLC.GetValue(list, element, f);
                                Bitmap img = null;
                                String path = Path.GetFileName(file_icon);
                                if (ElementsEditor.database.sourceBitmap != null && ElementsEditor.database.ContainsKey(path))
                                {
                                    img = new Bitmap(ElementsEditor.database.images(path), 22, 22);
                                }
                                else
                                {
                                    if (ElementsEditor.database.sourceBitmap != null && ElementsEditor.database.ContainsKey("unknown.dds"))
                                    {
                                        img = new Bitmap(ElementsEditor.database.images("unknown.dds"), 22, 22);
                                    }
                                }
                                cell.Value = img;
                                // cell.ContextMenuStrip = row_editor_context;
                                row.Cells[2] = cell;
                                break;
                            case "id_major_type":
                                row.Cells[2] = Helper.getComboboxType(list, Int32.Parse(eLC.GetValue(list, element, f)), Constatns.typeMajorType);
                                break;
                            case "id_sub_type":
                                row.Cells[2] = Helper.getComboboxType(list, Int32.Parse(eLC.GetValue(list, element, f)), Constatns.typeSubType);
                                break;
                            case "character_combo_id":
                                //infoIcon
                                //classmaskMenu
                                DataGridViewImageCell cell1 = new DataGridViewImageCell();
                                cell1.Value = new Bitmap(new Bitmap(Resources.infoIcon, 22, 22));
                                cell1.ContextMenuStrip = classmaskMenu;
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                cell1.ToolTipText = "" + Helper.getClassByMaskID(id);
                                row.Cells[2] = cell1;
                                break;
                        }
                        if (eLC.Lists[list].elementFields[f].Contains("addon") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("id_addon") || eLC.Lists[list].elementFields[f].Contains("rands") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("unique") && eLC.Lists[list].elementFields[f].Contains("id"))
                        {
                            DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                            string resing = EQUIPMENT_ADDON.GetAddon(Int32.Parse(eLC.GetValue(list, element, f)).ToString());
                            if (resing.Length > 0)
                            {
                                int maxLength = 20;
                                string newle = "";
                                if (!string.IsNullOrEmpty(resing) && resing.Length > maxLength)
                                {
                                    newle = resing.Substring(0, maxLength) + "...";
                                }
                                else
                                {
                                    newle = resing;
                                }
                                cell1.Value = newle;
                                cell1.ToolTipText = "" + resing;
                                row.Cells[2] = cell1;
                            }
                            else
                            {
                                cell1.Value = "None";
                                row.Cells[2] = cell1;
                            }
                        }
                        if (eLC.Lists[list].elementFields[f].Contains("proc_type"))
                        {
                            DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                            int id = Int32.Parse(eLC.GetValue(list, element, f));
                            string resing = Helper.getProtectTypeDesc(id);
                            cell1.Value = "Change";
                            cell1.ToolTipText = "";
                            row.Cells[2] = cell1;
                            proctypeLocation = f;
                            proctypeLocationvak = id;
                        }
                        
                        if (eLC.Lists[list].elementFields[f].Contains("targets") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("id_drop_after_damaged") || eLC.Lists[list].elementFields[f].Contains("element_id") || eLC.Lists[list].elementFields[f].Contains("id_upgrade_equip") || eLC.Lists[list].elementFields[f].Contains("npcgen") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("equipment") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("goods") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("id_pet"))
                        {
                            try
                            {
                                if (list != 54)
                                {
                                    DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                    int id = Int32.Parse(eLC.GetValue(list, element, f));
                                    if (id > 0 && eLC.valuableItems.ContainsKey(id))
                                    {
                                        ItemDupe ItemDupe = eLC.valuableItems[id];
                                        cell1.Value = ItemDupe.name;
                                        cell1.ToolTipText = "";
                                        row.Cells[2] = cell1;
                                        row.Cells[2].Tag = ItemDupe;
                                    }
                                    else
                                    {

                                        if (id > 0 && eLC.ocupiedIds.ContainsKey(id))
                                        {
                                            ItemDupe ItemDupe = eLC.ocupiedIds[id];
                                            cell1.Value = ItemDupe.name;
                                            cell1.ToolTipText = "";
                                            row.Cells[2] = cell1;
                                            row.Cells[2].Tag = ItemDupe;
                                        }
                                    }
                                }else
                                {
                                    DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                    int id = Int32.Parse(eLC.GetValue(list, element, f));
                                    if (id > 0 && eLC.NPCCraftingService.ContainsKey(id))
                                    {
                                        ItemDupe ItemDupe = eLC.NPCCraftingService[id];
                                        cell1.Value = ItemDupe.name;
                                        cell1.ToolTipText = "";
                                        row.Cells[2] = cell1;
                                        row.Cells[2].Tag = ItemDupe;
                                    }
                                    else
                                    {

                                        if (id > 0 && eLC.ocupiedIds.ContainsKey(id))
                                        {
                                            ItemDupe ItemDupe = eLC.ocupiedIds[id];
                                            cell1.Value = ItemDupe.name;
                                            cell1.ToolTipText = "";
                                            row.Cells[2] = cell1;
                                            row.Cells[2].Tag = ItemDupe;
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Contains("materials") && eLC.Lists[list].elementFields[f].Contains("id"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.valuableItems.ContainsKey(id))
                                {
                                    ItemDupe ItemDupe = eLC.valuableItems[id];
                                    cell1.Value = ItemDupe.name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = ItemDupe;
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Contains("skill") && eLC.Lists[list].elementFields[f].Contains("id"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.skillNames.ContainsKey(id))
                                {
                                    cell1.Value = eLC.skillNames[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.skillNames[id];
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Contains("drop_matters") && eLC.Lists[list].elementFields[f].Contains("id"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.valuableItems.ContainsKey(id))
                                {
                                    ItemDupe ItemDupe = eLC.valuableItems[id];
                                    cell1.Value = ItemDupe.name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = ItemDupe;
                                }
                            }
                            catch { }
                        }

                        if (eLC.Lists[list].elementFields[f].Contains("param") && !eLC.Lists[list].elementFields[f].Contains("num"))
                        {
                            float data = BitConverter.ToSingle(BitConverter.GetBytes(int.Parse(eLC.GetValue(list, element, f))), 0);

                            String text = (data).ToString("F6");
                            float n;
                            if (float.TryParse(text, out n) && n > 0)
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                cell1.Value = "Float: " + text;
                                cell1.ToolTipText = "";
                                row.Cells[2] = cell1;
                            }
                        }
                        
                        if (eLC.Lists[list].elementFields[f].Equals("id_task_out_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCActivateQuests.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCActivateQuests[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCActivateQuests[id];
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Equals("id_task_in_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCReciveQuests.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCReciveQuests[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCReciveQuests[id];
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Equals("id_make_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCCraftingService.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCCraftingService[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCCraftingService[id];
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Equals("id_engrave_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCEngraveService.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCEngraveService[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = true;
                                }
                            }
                            catch { }
                        }

                        if (eLC.Lists[list].elementFields[f].Equals("id_randprop_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCHoneService.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCHoneService[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCHoneService[id];
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Equals("id_skill_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCSkill.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCSkill[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCSkill[id];
                                }
                            }
                            catch { }
                        }

                        if (eLC.Lists[list].elementFields[f].Equals("id_src_monster"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.MONSTERS.ContainsKey(id))
                                {
                                    cell1.Value = eLC.MONSTERS[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.MONSTERS[id];
                                }
                            }
                            catch { }
                        }

                        if (eLC.Lists[list].elementFields[f].Equals("id_task_matter_service"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCTasks.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCTasks[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCTasks[id];
                                }
                            }
                            catch { }
                        }
                        if (eLC.Lists[list].elementFields[f].Equals("id_type"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.NPCTYPE.ContainsKey(id))
                                {
                                    cell1.Value = eLC.NPCTYPE[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.NPCTYPE[id];
                                }
                            }
                            catch { }
                        }

                        
                        row.Cells[3].Value = eLC.GetValue(list, element, f);
                        dataGridView_item.Rows.Add(row);
                    }
                    dataGridView_item.Enabled = true;
                    // dataGridView_item.Refresh();
                    dataGridView_item.PerformLayout();
                    dataGridView_item.ResumeLayout();
                }
            }
            else
            {
                if (element > -1)
                {
                    dataGridView_item.Rows.Add(new String[] { "1", "Dialog ID", "int32", conversationList.Dialogs[element].DialogID.ToString() });
                    dataGridView_item.Rows.Add(new String[] { "2", "Dialog Name", "wstring:128", conversationList.Dialogs[element].GetText() });
                    for (int q = 0; q < conversationList.Dialogs[element].QuestionCount; q++)
                    {
                        dataGridView_item.Rows.Add(new String[] { q.ToString(), "Question_" + q + " - ID", "int32", conversationList.Dialogs[element].Questions[q].QuestionID.ToString() });
                        dataGridView_item.Rows.Add(new String[] { q.ToString(), "Question_" + q + " - Control", "int32", conversationList.Dialogs[element].Questions[q].Control.ToString() });
                        dataGridView_item.Rows.Add(new String[] { q.ToString(), "Question_" + q + " - Text", "wstring:" + conversationList.Dialogs[element].Questions[q].QuestionTextLength, conversationList.Dialogs[element].Questions[q].GetText() });
                        for (int c = 0; c < conversationList.Dialogs[element].Questions[q].ChoiceQount; c++)
                        {
                            dataGridView_item.Rows.Add(new String[] { q.ToString(), "Question_" + q + " - Choice_" + c + " - Control", "int32", conversationList.Dialogs[element].Questions[q].Choices[c].Control.ToString() });
                            dataGridView_item.Rows.Add(new String[] { q.ToString(), "Question_" + q + " - Choice_" + c + " - Text", "wstring:132", conversationList.Dialogs[element].Questions[q].Choices[c].GetText() });
                        }
                    }


                }
                if (scroll > -1)
                {
                    try { dataGridView_item.FirstDisplayedScrollingRowIndex = scroll; } catch (Exception) { }
                }
            }
            if (scroll > -1)
            {
                try { dataGridView_item.FirstDisplayedScrollingRowIndex = scroll; } catch (Exception) { }

            }
            tabControl2.SelectedIndex = saveInfoTabindex;
            progress_bar("Ready", 0, 0);
            if (list == 40 && elementIntoTab.SelectedIndex > 1)
            {
                elementIntoTab_SelectedIndexChanged(null, null);

            }
            if (list == 54 && elementIntoTab.SelectedIndex > 1)
            {
                elementIntoTab_SelectedIndexChanged(null, null);

            }
            this.ActiveControl = listBox_items;
            //comboBox_lists.Enabled = true;
        }

        public BookMark getBookmark()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    getBookmark();
                    return;
                }));
            }
            if(eLC == null)
            {
                MessageBox.Show("Element file not loaded!");
                return null;
            }
            if (comboBox_lists.SelectedIndex < 0)
            {
                MessageBox.Show("Element file not loaded!");
                return null;
            }
            if (dataGridView_item.CurrentCell == null)
            {
                MessageBox.Show("No rows are selected!");
                return null;
            }
            if (listBox_items.CurrentCell == null)
            {
                MessageBox.Show("No item is slected!");
                return null;
            }
            BookMark book = new BookMark();
            book.editorID = Constatns.elementEditorId;
            book.listIndex = comboBox_lists.SelectedIndex;
            book.elementIndex = listBox_items.CurrentCell.RowIndex;
            book.rowIndex = dataGridView_item.CurrentCell.RowIndex;
            book.name = comboBox_lists.Items[book.listIndex].ToString() + "["+eLC.GetValue(book.listIndex, book.elementIndex, 0)+ "]";
            return book;
        }

        private void change_list(object sender, EventArgs ex)
        {
            if(lock3) { return; }
            GC.Collect();
            itemToBeOperated = null;
            copyValues = null;
            int tabIndex = tabControl2.SelectedIndex;
            if (comboBox_lists.SelectedIndex > -1)
            {
                locked = true;
                tabControl2.SelectedIndex = 0;
                comboBox_lists.Enabled = false;
                
                lastList = 0;
                lastItem = 0;
                int l = comboBox_lists.SelectedIndex;
                listBox_items.SuspendLayout();
                listBox_items.Rows.Clear();
                dataGridView_item.Rows.Clear();
                
                elementIntoTab.SelectedIndex = 0;
                listBox_items.Enabled = false;
                try
                {
                    if (elementIntoTab.TabPages.Contains(sale))
                    {
                        elementIntoTab.TabPages.Remove(sale);
                    }
                    if (elementIntoTab.TabPages.Contains(craft))
                    {
                        elementIntoTab.TabPages.Remove(craft);
                    }
                }
                catch { }

                if (l == 40)
                {
                    elementIntoTab.TabPages.Add(sale);
                    if (elementIntoTab.TabPages.Contains(craft))
                    {
                        elementIntoTab.TabPages.Remove(craft);
                    }
                }
                else if (l == 54)
                {
                    elementIntoTab.TabPages.Add(craft);
                    if (elementIntoTab.TabPages.Contains(sale))
                    {
                        elementIntoTab.TabPages.Remove(sale);
                    }
                }
                else
                {
                    elementIntoTab.TabPages.Remove(sale);
                    elementIntoTab.TabPages.Remove(craft);
                }
                locked = false;
                try
                {
                    groupBox2.Text = "List: " + l;
                    listbox_description.Text = "Items: " + eLC.Lists[l].elementValues.Count + " Elements: " + eLC.Lists[l].elementTypes.Count;
                }catch
                (Exception exx)
                {
                    listbox_description.Text = "Items: " + eLC.Lists[l].elementValues.Count + " Elements: " + eLC.Lists[l].elementTypes.Count;
                    MessageBox.Show(exx.ToString());
                }
                if (eLC.Lists[l].elementValues.Count == 0)
                {
                    progress_bar("Ready", 0, 0);
                    return;
                }
                locked = true;
                selecter_rowscheckbox.Items.Clear();
                if (l != eLC.ConversationListIndex)
                {

                    for (int opt = 0; opt < eLC.Lists[l].elementFields.Count; opt++)
                    {

                        selecter_rowscheckbox.Items.Add(eLC.Lists[l].elementFields[opt]);
                    }
                    try { selecter_rowscheckbox.SelectedIndex = 0; } catch (Exception) { }
                    int posid = -1;
                    int pos = -1;
                    int pos2 = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "ID")
                        {
                            posid = i;
                        }
                        if (eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;
                        }
                        if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                        {
                            pos2 = i;
                        }
                        if (pos != -1 && pos2 != -1)
                        {
                            break;
                        }
                    }
                    
                    for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                    {
                        Application.DoEvents();
                        progress_bar("Loading ...", e, eLC.Lists[l].elementValues.Count);

                        if (eLC.Lists[l].elementFields[0] == "ID")
                        {
                            Bitmap img = null;
                            int elemnet_id = Int32.Parse(eLC.GetValue(l, e, posid));
                            string path = Path.GetFileName(eLC.GetValue(l, e, pos2));
                            if (ElementsEditor.database.sourceBitmap != null && ElementsEditor.database.ContainsKey(path))
                            {
                                if (ElementsEditor.database.ContainsKey(path))
                                {
                                    img = ElementsEditor.database.images(path);
                                }else
                                {
                                    if (pos2 != -1)
                                    {
                                        img = ElementsEditor.database.images("unknown.dds");
                                    }else
                                    {
                                        img = null;
                                    }
                                }

                            }
                            listBox_items.Rows.Add(new object[] { eLC.GetValue(l, e, 0), img, eLC.GetValue(l, e, pos) });
                            listBox_items.Rows[listBox_items.Rows.Count - 1].ReadOnly = false;
                            if (l == 3 || l == 6 || l == 9)
                            {
                                if (ElementsEditor.database.item_color != null && ElementsEditor.database.item_color.ContainsKey(elemnet_id))
                                {
                                    int itemID = ElementsEditor.database.item_color[elemnet_id];
                                    listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Helper.getByID(itemID) };
                                }
                            }
                        }
                        else
                        {
                            listBox_items.Rows.Add(new object[] { 0, new Bitmap(new Bitmap(Resources.blank)), eLC.GetValue(l, e, pos) });
                            listBox_items.Rows[listBox_items.Rows.Count - 1].ReadOnly = false;
                        }
                    }
                }
                else
                {
                    for (int e = 0; e < conversationList.DialogCount; e++)
                    {
                        listBox_items.Rows.Add(new object[] { conversationList.Dialogs[e].DialogID, new Bitmap(new Bitmap(Resources.blank)), conversationList.Dialogs[e].DialogID + " - Dialog" });
                        listBox_items.Rows[listBox_items.Rows.Count - 1].ReadOnly = true;
                    }

                }
            }
            try
            {
                locked = false;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                listBox_items.Rows[0].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                listBox_items_CellClick(null, null);
                //listBox_items.Refresh();
                listBox_items.PerformLayout();
                listBox_items.ResumeLayout();
            }
            catch (Exception exxx) { MessageBox.Show("CHANGE LIST:"+exxx.ToString()); }
            tabControl2.SelectedIndex = tabIndex;
            progress_bar("Ready", 0, 0);
            
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                try
                {
                    if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                    {
                        eLC.Lists[eLC.ConversationListIndex].elementValues[0][0] = conversationList.GetBytes();
                    }
                    eLC.Save(eLC.loadedFile);
                }
                catch (Exception)
                {
                    MessageBox.Show("SAVING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
                }
            }
        }

        private void change_value(object sender, DataGridViewCellEventArgs ea)
        {
            if (lock3) { return; }
                try
                {
                    if (eLC != null && ea.ColumnIndex == 3)
                    {
                        lock3 = true;
                        int l = comboBox_lists.SelectedIndex;
                        int e = listBox_items.CurrentCell.RowIndex;
                        if (l != eLC.ConversationListIndex)
                        {
                            eLC.SetValue(l, e, ea.RowIndex, Convert.ToString(dataGridView_item.Rows[ea.RowIndex].Cells[3].Value));
                            int pos = -1;
                            int pos2 = -1;

                            for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                            {
                                if (eLC.Lists[l].elementFields[i] == "Name")
                                {
                                    pos = i;
                                }
                                if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                                {
                                    pos2 = i;
                                }
                                if (pos != -1 && pos2 != -1)
                                {
                                    break;
                                }
                            }
                            String name = eLC.GetValue(l, e, pos);
                            String file_icon = eLC.GetValue(l, e, pos2);
                            Bitmap img = null;
                            String path = Path.GetFileName(file_icon);
                            if (ElementsEditor.database.ContainsKey(path))
                            {
                                img = ElementsEditor.database.images(path);
                            }
                            else
                            {
                                if (pos2 != -1)
                                {
                                if (ElementsEditor.database.ContainsKey("unknown.dds"))
                                {
                                    img = ElementsEditor.database.images("unknown.dds");
                                }
                                else
                                {
                                    img = new Bitmap(new Bitmap(Resources.blank));
                                }
                            }
                                else
                                {
                                    img = new Bitmap(new Bitmap(Resources.blank));
                                }
                            }
                                listBox_items.Rows[e].Cells[0].Value = eLC.GetValue(l, e, 0);//ID
                                listBox_items.Rows[e].Cells[1].Value = img;//ICON
                                listBox_items.Rows[e].Cells[2].Value = name;//NAME
                        if(ea.RowIndex == 0 || ea.RowIndex == pos)
                        this.refreshTaskRecipes();
                    }
                        else
                        {
                            //check which item was changed (by field name)
                            String fieldName = dataGridView_item[0, ea.RowIndex].Value.ToString();

                            if (fieldName == "Dialog ID")
                            {
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].DialogID = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
                                return;
                            }
                            if (fieldName == "Dialog Name")
                            {
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].SetText(dataGridView_item.CurrentCell.Value.ToString());
                                return;
                            }
                            if (fieldName.StartsWith("Question_") && fieldName.EndsWith(" - ID"))
                            {
                                int q = Convert.ToInt32(fieldName.Replace("Question_", "").Replace(" - ID", ""));
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].Questions[q].QuestionID = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
                                return;
                            }
                            if (fieldName.StartsWith("Question_") && fieldName.Contains("Choice_") && fieldName.EndsWith(" - Control"))
                            {
                                String[] s = fieldName.Replace("Question_", "").Replace(" - Choice_", ";").Replace(" - Control", "").Split(';');
                                int q = Convert.ToInt32(s[0]);
                                int c = Convert.ToInt32(s[1]);
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].Questions[q].Choices[c].Control = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
                                return;
                            }
                            if (fieldName.StartsWith("Question_") && fieldName.Contains("Choice_") && fieldName.EndsWith(" - Text"))
                            {
                                String[] s = fieldName.Replace("Question_", "").Replace(" - Choice_", ";").Replace(" - Text", "").Split(';');
                                int q = Convert.ToInt32(s[0]);
                                int c = Convert.ToInt32(s[1]);
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].Questions[q].Choices[c].SetText(dataGridView_item.CurrentCell.Value.ToString());
                                return;
                            }
                            if (fieldName.StartsWith("Question_") && fieldName.EndsWith(" - Control"))
                            {
                                int q = Convert.ToInt32(fieldName.Replace("Question_", "").Replace(" - Control", ""));
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].Questions[q].Control = Convert.ToInt32(dataGridView_item.CurrentCell.Value);
                                return;
                            }
                            if (fieldName.StartsWith("Question_") && fieldName.EndsWith(" - Text"))
                            {
                                int q = Convert.ToInt32(fieldName.Replace("Question_", "").Replace(" - Text", ""));
                                conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].Questions[q].SetText(dataGridView_item.CurrentCell.Value.ToString());
                                dataGridView_item[1, ea.RowIndex].Value = "wstring:" + conversationList.Dialogs[listBox_items.CurrentCell.RowIndex].Questions[q].QuestionTextLength;
                                return;
                            }
                        }
                    }
                }
                catch (Exception)
		        {
                    MessageBox.Show("CHANGING ERROR!\nFailed changing value, this value seems to be invalid.");
                }
            lock3 = false;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs ex)
        {
            int l = comboBox_lists.SelectedIndex;
            if (l != eLC.ConversationListIndex)
            {
                if (l > -1)
                {
                    Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                    for (int i = 0; i< eLC.Lists[l].elementFields.Count; i++)
                    {
                        Object data = (Object)eLC.getDefaultValue(eLC.Lists[l].elementTypes[i].ToString());
                        itemValues.Add(i, data);
                    }
                    eLC.AddItem(l, itemValues);
                    int pos = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;
                            break;
                        }
                    }
                    listBox_items.Rows.Add(new object[] { eLC.GetValue(l, eLC.Lists[l].elementValues.Count - 1, 0), new Bitmap(new Bitmap(Resources.blank)), eLC.GetValue(l, eLC.Lists[l].elementValues.Count - 1, pos) });
                    listBox_items.Rows[eLC.Lists[l].elementValues.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[l].elementValues.Count - 1].Cells[0];
                }
                else
                {
                    MessageBox.Show("Please select a item!");
                }

            }
            else
            {
                try
                {
                    
                    eDialog data = conversationList.Dialogs[conversationList.Dialogs.Count-1];
                    conversationList.DialogCount++;
                    conversationList.Dialogs[conversationList.DialogCount-1] = data;
                    listBox_items.Rows.Add(new object[] { conversationList.Dialogs[conversationList.DialogCount - 1].DialogID, new Bitmap(new Bitmap(Resources.blank)), conversationList.Dialogs[conversationList.DialogCount - 1].DialogID + " - Dialog" });
                    listBox_items.Rows[listBox_items.Rows.Count - 1].ReadOnly = true;
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }catch(Exception)
                {

                }
            }

            this.refreshTaskRecipes();
            listBox_items_CellClick(null, null);
        }

        private Dictionary<int, Dictionary<int, Object>> resortDic(IDictionary<int, Dictionary<int, Object>> data)
        {
            Dictionary<int, Dictionary<int, Object>> datanew = new Dictionary<int, Dictionary<int, Object>>();
            int i = 0;
            foreach (KeyValuePair<int, Dictionary<int, Object>> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (comboBox_lists.SelectedIndex > -1)
            {
                locked = true;
                int l = comboBox_lists.SelectedIndex;
                int xe = listBox_items.CurrentCell.RowIndex;
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    progress_bar("Deleting ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    if (l != eLC.ConversationListIndex)
                    {
                        eLC.Lists[l].RemoveItem(l, idx);
                    }else
                    {
                        conversationList.Dialogs.Remove(idx);
                        conversationList.DialogCount--;
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
                this.refreshTaskRecipes();
                progress_bar("Ready", 0, 0);
                locked = false;
                
            }
            else
            {
                MessageBox.Show("Please select a item!");
            }
            
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "ElementData Export (*.edx)|*.edx";
            save.FileName = comboBox_lists.Text + ".edx";
            int l = comboBox_lists.SelectedIndex;
            int xe = listBox_items.CurrentCell.RowIndex;
            if (xe > -1 && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export();
                        export.ListId = l;
                        export.type = 0; //Elements data = 0 | Gshop = 1 
                        export.ForVersion = eLC.Version;
                        export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Exporting ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex == eLC.ConversationListIndex)
                            {
                                
                                export.data.Add(i, conversationList.Dialogs[index]);
                            }
                            else
                            {
                                export.data.Add(i, eLC.Lists[l].elementValues[index]);
                            }

                        }
                        FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, export);
                        fs.Close();
                    }

                    locked = false;
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }else
            {
                MessageBox.Show("Please select a item!");

            }
            
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs ex)
        {
            
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to import!", 0, 0);
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "ElementData Export(*.edx) | *.edx";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.Multiselect = true;
            int ltc = comboBox_lists.SelectedIndex;
            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String pathx = openFileDialog1.FileName;
                progress_bar("Importing ...", 0, 0);
                Application.DoEvents();
                using (Stream file = File.Open(pathx, FileMode.Open))
                {
                   
                    BinaryFormatter bf = new BinaryFormatter();
                    Export obj = (Export)bf.Deserialize(file);
                    if (obj.ForVersion != eLC.Version)
                    {
                        locked = false;
                        comboBox_lists.Enabled = true;
                        listBox_items.Enabled = true;
                        file.Close();
                        if(!(MessageBox.Show("You are about to import " + obj.ForVersion + " on " + eLC.Version + "! Do you want to continue?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                        {
                            return;
                        }
                    }
                    comboBox_lists.SelectedIndex = obj.ListId;
                    ltc = obj.ListId;
                    Application.DoEvents();
                    comboBox_lists.Enabled = false;
                    listBox_items.Enabled = false;
                    locked = true;
                    // for (int i = 0; i < datax.Count; i++)
                    int i = 0;
                    foreach (KeyValuePair<int, Object> entry in obj.data)
                    {
                        Application.DoEvents();
                        progress_bar("Importing ...", i, obj.data.Count);                   
                        if (eLC.ConversationListIndex == obj.ListId)
                        {
                            conversationList.DialogCount++;
                            conversationList.Dialogs[conversationList.DialogCount - 1] = (eDialog)entry.Value;
                        }
                        else
                        {
                            Dictionary<int, object> data = (Dictionary<int, object>)entry.Value;
                            if (autonewId.Checked)
                            {
                                    if (configs.nextAutoNewId == 0)
                                    {
                                        configs.nextAutoNewId = eLC.getNextFreeId(0, null, null);
                                    }
                                    int id_index = -1;
                                    if (id_index == -1)
                                    {
                                        for (int e = 0; 0 < eLC.Lists[obj.ListId].elementFields.Count; e++)
                                        {
                                            if (eLC.Lists[obj.ListId].elementFields[e] == "ID")
                                            {
                                                id_index = e;
                                                break;
                                            }
                                        }
                                    }
                                    data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                                    configs.nextAutoNewId = (int)data[id_index];
                                    eLC.useFreeId(configs.nextAutoNewId, obj.ListId, eLC.Lists[obj.ListId].elementValues.Count);
                            }

                                
                                eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                            
                        }
                        
                    }
                    file.Close();
                }
               // if(comboBox_lists.SelectedIndex == 69)
              //  {
                    this.refreshTaskRecipes();
               // }
                locked = false;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                change_list(null, null);
                listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Cells[0];
                progress_bar("Ready", 0, 0);
            }

            locked = false;
            
        }

        private void listBox_items_CellValueChanged(object sender, DataGridViewCellEventArgs ea)
        {
            if (lock3) { return; }
            locked = true;
            try
            {
                if (eLC != null && ea.ColumnIndex > -1)
                {
                    int l = comboBox_lists.SelectedIndex;
                    int e = listBox_items.CurrentCell.RowIndex;
                    if (l != eLC.ConversationListIndex)
                    {
                        int pos = -1;
                        int pos2 = -1;
                        int pos3 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "ID")
                            {
                                pos = i;
                            }
                            if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                            {
                                pos2 = i;
                            }
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos3 = i;
                            }
                        }

                        switch (ea.ColumnIndex)
                        {
                            case 0:
                                if (pos != -1)
                                {
                                    String test = Convert.ToString(listBox_items.CurrentCell.Value);
                                    eLC.SetValue(l, e, pos, test);
                                    this.refreshTaskRecipes();
                                }
                                break;
                            case 2:
                                if (pos3 != -1)
                                {
                                    String test = Convert.ToString(listBox_items.CurrentCell.Value);
                                    eLC.SetValue(l, e, pos3, test);
                                }
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("List Not Supported!" + e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("CHANGING ERROR!\nFailed changing value, this value seems to be invalid." + e.ToString());
            }
            locked = false;
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs ezx)
        {
            int l = comboBox_lists.SelectedIndex;
            int e = listBox_items.CurrentCell.RowIndex;
            if (dataGridView_item.CurrentCell == null) return;
                if (eLC != null && e > -1)
                {

                    if (l != eLC.ConversationListIndex)
                    {
                        int pos = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "ID")
                            {
                                pos = i;
                                 break;
                            }
                        }
                    if (pos != -1)
                    {
                        try
                        {
                           // string value = "";
                            string value = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value.ToString();
                            int id = Int32.Parse(eLC.Lists[l].GetValue(e, pos).ToString());
                            Point imagePath = new Point(-1, -1);
                            if (ElementsEditor.database.imageposition.ContainsKey(Path.GetFileName(value)))
                            {
                                imagePath = ElementsEditor.database.imageposition[Path.GetFileName(value)];
                            }
                            ImageChange ic = new ImageChange(id, imagePath);
                            ic.FormClosed += new FormClosedEventHandler(ic_FormClosed);
                            ic.ShowDialog(this);
                        }
                        catch (Exception) { }
                    }
                }
               }
            
        }

        private void ic_FormClosed(object sender, FormClosedEventArgs ex)
        {
            if(selectedImage != null)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                try
                {
                    if (eLC != null && e > -1)
                    {
                        if (l != eLC.ConversationListIndex)
                        {
                            int pos = -1;
                            int pos2 = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                            {
                                if (eLC.Lists[l].elementFields[i] == "Name")
                                {
                                    pos = i;
                                }
                                if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                                {
                                    pos2 = i;
                                }
                                if (pos != -1 && pos2 != -1)
                                {
                                    break;
                                }
                            }

                            if (pos2 != -1)
                            {
                                eLC.SetValue(l, e, pos2, selectedImage);
                                Bitmap img = null;
                                String path = selectedImage;
                                if (ElementsEditor.database.ContainsKey(path))
                                {
                                    img = ElementsEditor.database.images(path);
                                }
                                else
                                {
                                    if (pos2 != -1)
                                    {
                                        if (ElementsEditor.database.ContainsKey("unknown.dds"))
                                        {
                                            img = ElementsEditor.database.images("unknown.dds");
                                        }
                                        else
                                        {
                                            img = new Bitmap(new Bitmap(Resources.blank));
                                        }
                                    }
                                    else
                                    {
                                        img = new Bitmap(new Bitmap(Resources.blank));
                                    }
                                }

                                listBox_items.Rows[e].Cells[0].Value = eLC.GetValue(l, e, 0);//ID
                                listBox_items.Rows[e].Cells[1].Value = img;//ICON
                                listBox_items.Rows[e].Cells[2].Value = eLC.GetValue(l, e, pos);//NAME
                                listBox_items_CellClick(null, null);
                            }
                        }
                        else
                        {
                            MessageBox.Show("List Not Supported!" + e.ToString());
                        }
                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show("CHANGING ERROR!\nFailed changing value, this value seems to be invalid." + ed.ToString());
                }
                selectedImage = null;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ProfileView.profile == null) { return; }
                 string databasepatg = Path.GetDirectoryName(Application.ExecutablePath) + @"\cache\"+ ProfileView.profile.name+".gca";
            try
            {
                database = new CacheSave();
                ElementsEditor.database.sourceBitmap = null;
                string bitmapdata = databasepatg + "_a";
                string databaseFile = databasepatg + "_b";
                File.Delete(databasepatg);
                File.Delete(bitmapdata);
                File.Delete(databaseFile);
            }
            catch (Exception) { }
                MessageBox.Show("Ready");
        }

        private void saveCache(object sender, EventArgs e)
        {
            saveCache();
            MessageBox.Show("Ready");
        }

        private void autoOpenCache_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    configs.autoOpen = autoOpenCache.Checked;
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }

        private void autoSaveCache_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    configs.autoSave = autoSaveCache.Checked;
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }

        private void EnableDevMenu_CheckedChanged(object sender, EventArgs e)
        {
            String verF = versionFromBox.Text.ToString();
            String verT = versionToBox.Text.ToString();
            if (verF.Length == 0 && EnableDevMenu.Checked)
            {
                MessageBox.Show("Please input version from!");
                EnableDevMenu.Checked = false;
                return;
            }
            if (verT.Length == 0 && EnableDevMenu.Checked)
            {
                MessageBox.Show("Please input version to!");
                EnableDevMenu.Checked = false;
                return;
            }

            if (EnableDevMenu.Checked)
            {
                dataGridView_item.ContextMenuStrip = developerMenuitems;
                int version = Int32.Parse(version_label.Text);
                int versionN = Int32.Parse(verT);
                if (!configs.currentConvertSettings.ContainsKey(version))
                {
                    currentConvertSettings = new ConvertElements();
                    currentConvertSettings.versionFrom = Int32.Parse(verF);
                    currentConvertSettings.versionTo = Int32.Parse(verT);
                    currentConvertSettings.lists = new Dictionary<int, Dictionary<int, RowIndexesExport>>();
                }else
                {
                    currentConvertSettings = configs.currentConvertSettings[version];
                }
            }
            else
            {
                dataGridView_item.ContextMenuStrip = null;
            }
        }

        private void addRowHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            int item = listBox_items.CurrentCell.RowIndex;
            int row = dataGridView_item.CurrentCell.RowIndex;
            if (list != -1 && item != -1 && row != -1)
            {
                int count_newRows = Int32.Parse(toolStripTextBox2.Text);
                int version = Int32.Parse(version_label.Text);
                if (currentConvertSettings.lists.ContainsKey(list))
                {    
                    int done = 0;
                    while (done < count_newRows)
                    {
                        RowIndexesExport ce = new RowIndexesExport();

                        ce.operation = Constatns.add;
                        ce.value = toolStripTextBox3.Text;
                        ce.id = (row + done);
                        currentConvertSettings.lists[list].Add((row + done), ce);
                        done++;
                    }
                }else
                {
                    Dictionary<int, RowIndexesExport> dic = new Dictionary<int, RowIndexesExport>();
                    int done = 0;
                    while (done < count_newRows)
                    {
                        RowIndexesExport ce = new RowIndexesExport();

                        ce.operation = Constatns.add;
                        ce.value = toolStripTextBox3.Text;
                        ce.id = (row + done);
                        dic.Add((row+ done), ce);
                        done++;
                    }
                    

                    currentConvertSettings.lists.Add(list, dic);
                }
                MessageBox.Show("Ready");
            }
            else
            {
                MessageBox.Show("Please select an row!");
            }
        }

        private void saveExportConfigs(object sender, EventArgs e)
        {
            int version = Int32.Parse(version_label.Text);
            if (currentConvertSettings != null)
            {
                configs.currentConvertSettings[version] = currentConvertSettings;
            }
            saveConfigs();
            MessageBox.Show("Ready");
        }


        private void btnAdd_Click(object sender, EventArgs ex)
        {
            if(eLC == null)
            {
                return;
            }
            String serach = searchInput1.Text;          
            int n;
            bool byID = int.TryParse(serach, out n);
            if (byID)
            {
                for (int l = lastList; l < eLC.Lists.Length; l++)
                {
                    int pos = 0;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "ID")
                        {
                            pos = i;
                            break;
                        }
                    }
                    for (int e = lastItem; e < eLC.Lists[l].elementValues.Count; e++)
                    {
                        try
                        {
                            if (caseSensitiveCheckbox.Checked)
                            {

                                if (n == Int32.Parse(eLC.GetValue(l, e, pos).ToString()))
                                {
                                    comboBox_lists.SelectedIndex = l;
                                    listBox_items.Rows[e].Selected = true;
                                    listBox_items.CurrentCell = listBox_items.Rows[e].Cells[0];
                                    lastList = l;
                                    lastItem = e + 1;
                                    listBox_items_CellClick(null, null);
                                    return;
                                }
                            }else
                            {
                                string hey = eLC.GetValue(l, e, pos).ToString().ToLower();
                                if (hey.Contains(serach.ToLower().Trim()))
                                {
                                    comboBox_lists.SelectedIndex = l;
                                    listBox_items.Rows[e].Selected = true;
                                    listBox_items.CurrentCell = listBox_items.Rows[e].Cells[0];
                                    lastList = l;
                                    lastItem = e + 1;
                                    listBox_items_CellClick(null, null);
                                    return;
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                }
            }
            else
            {//Search by name
                for (int l = lastList; l < eLC.Lists.Length; l++)
                {
                    int pos = 0;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;
                            break;
                        }
                    }
                    for (int e = lastItem; e < eLC.Lists[l].elementValues.Count; e++)
                    {
                        string hey = eLC.GetValue(l, e, pos).ToString().ToLower();

                        if (!caseSensitiveCheckbox.Checked)
                        {
                            if (hey.Contains(serach.ToLower().Trim()))
                            {
                                comboBox_lists.SelectedIndex = l;
                                listBox_items.Rows[e].Selected = true;
                                listBox_items.CurrentCell = listBox_items.Rows[e].Cells[0];
                                lastList = l;
                                lastItem = e + 1;
                                listBox_items_CellClick(null, null);
                                return;
                            }
                        }else
                        {
                            if (hey == serach.ToLower().Trim())
                            {
                                comboBox_lists.SelectedIndex = l;
                                listBox_items.Rows[e].Selected = true;
                                listBox_items.CurrentCell = listBox_items.Rows[e].Cells[0];
                                lastList = l;
                                lastItem = e + 1;
                                listBox_items_CellClick(null, null);
                                return;
                            }
                        }
                    }
                }
            }
            lastList = 0;
            lastItem = 0;
        }

        private void saveToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            int total_exported_items = 0;
            int total_fixed_rows = 0;
            

            if (exportCombobox.SelectedIndex == -1)
            {
                progress_bar("Please select a version to export!", 0, 0);
                return;
            }

            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "ElementData Export (*.edx)|*.edx";
            save.FileName = comboBox_lists.Text + ".edx";
            int list = comboBox_lists.SelectedIndex;
            int xe = listBox_items.CurrentCell.RowIndex;

            int export_vestion = Int32.Parse(exportCombobox.Items[exportCombobox.SelectedIndex].ToString().Split('>')[0]);
            int export_vestion_current = Int32.Parse(exportCombobox.Items[exportCombobox.SelectedIndex].ToString().Split('>')[1]);
            if (configs.currentConvertSettings.ContainsKey(export_vestion))
            {
                empty_eLC = new eListCollection();
                empty_eLC.progress_bar += progress_bar;
                empty_eLC.setLists(empty_eLC.loadEmptyConfigs(export_vestion_current));
            }else
            {
                progress_bar("Export failed no configs!", 0, 0);
                return;
            }
             if (xe > -1 && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export();
                        export.ListId = list;
                        export.type = 0; //Elements data = 0 | Gshop = 1 
                        export.ForVersion = export_vestion_current;
                        export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Exporting ...", i, listBox_items.SelectedRows.Count);
                            int item = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex == eLC.ConversationListIndex)
                            {
                                export.data.Add(i, conversationList.Dialogs[item]);
                            }
                            else
                            {
                                empty_eLC.Lists[list].elementValues = new Dictionary<int, Dictionary<int, object>>();
                                Dictionary<int, object> data = new Dictionary<int, object>();
                                for (int d = 0; d < empty_eLC.Lists[list].elementFields.Count; d++)
                                {
                                    data.Add(d, empty_eLC.getDefaultValue(empty_eLC.Lists[list].elementTypes[d].ToString()));
                                }
                                empty_eLC.Lists[list].elementValues[item] = data;
                                int rowToEdit = 0;
                                int iexMax = empty_eLC.Lists[list].elementFields.Count;
                                int currentRow = 0;
                                while ( rowToEdit < iexMax)
                                {
                                    if (configs.currentConvertSettings[export_vestion].lists.ContainsKey(list))
                                    {
                                        if(configs.currentConvertSettings[export_vestion].lists[list].ContainsKey(rowToEdit))
                                        {
                                            String operation = configs.currentConvertSettings[export_vestion].lists[list][rowToEdit].operation;
                                            if(operation == Constatns.add)
                                            {
                                                empty_eLC.Lists[list].SetValue(item, rowToEdit, configs.currentConvertSettings[export_vestion].lists[list][rowToEdit].value.ToString());
                                            }
                                            if (operation == Constatns.replace)
                                            {
                                                empty_eLC.Lists[list].SetValue(item, rowToEdit, configs.currentConvertSettings[export_vestion].lists[list][rowToEdit].value.ToString());
                                            }
                                            
                                            if (total_exported_items == 0)
                                            {
                                                total_fixed_rows++;
                                            }
                                            currentRow++;
                                        }
                                        else
                                        {
                                            empty_eLC.Lists[list].SetValue(item, rowToEdit, eLC.Lists[list].GetValue(item, (rowToEdit - currentRow)));
                                        }
                                    }else
                                    {
                                        empty_eLC.Lists[list].SetValue(item, rowToEdit, eLC.Lists[list].GetValue(item, (rowToEdit - currentRow)));
                                    }
                                    rowToEdit++;
                                }
                                Object datax = (Object)empty_eLC.Lists[list].elementValues[item];
                                export.data.Add(i, datax);
                            }
                            total_exported_items++;
                        }
                        FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, export);
                        fs.Close();
                    }

                    locked = false;
                    MessageBox.Show("Exported items:" + total_exported_items.ToString()+" Row Fixed:"+ total_fixed_rows);
                }
                catch (Exception asd)
                {
                    MessageBox.Show("SAVING ERROR:"+ asd.ToString());
                }
               // listBox_items_CellValueChanged(null, null);
                progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");
            }
        }

        private void changeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            int item = listBox_items.CurrentCell.RowIndex;
            int row = dataGridView_item.CurrentCell.RowIndex;
            if (list != -1 && item != -1 && row != -1)
            {
                int version = Int32.Parse(version_label.Text);
                RowIndexesExport ce = new RowIndexesExport();
                ce.id = row;
                ce.operation = Constatns.replace;
                ce.value = toolStripTextBox1.Text;
                if(currentConvertSettings == null)
                {
                    currentConvertSettings = new ConvertElements();
                }
                if (currentConvertSettings.lists.ContainsKey(list))
                {
                    if (currentConvertSettings.lists[list].ContainsKey(row))
                    {
                        currentConvertSettings.lists[list].Add(row, ce);
                    }
                }
                else
                {
                    Dictionary<int, RowIndexesExport> dic = new Dictionary<int, RowIndexesExport>();
                    dic.Add(row, ce);
                    currentConvertSettings.lists.Add(list, dic);
                }
                MessageBox.Show("Ready");
            }
            else
            {
                MessageBox.Show("Please select an row!");
            }
        }

        private void configEditorExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lock2)
            {
                ConfigEditor cfe = new ConfigEditor();
                cfe.FormClosed += new FormClosedEventHandler(cfe_FormClosed);
                cfe.Show();
                lock2 = true;
            }
        }

        private void cfe_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int version = Int32.Parse(version_label.Text);
                currentConvertSettings = configs.currentConvertSettings[version];
                saveConfigs();
            }
            catch (Exception) { }
        }

        private void changeToolStripMenuItem2_Click(object sender, EventArgs ea)
        {
            if (eLC != null && dataGridView_item.CurrentCell.ColumnIndex > -1)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                if (l != eLC.ConversationListIndex)
                {
                    string value = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    string name = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    if (name.Equals("character combo id"))
                    {
                        int n;
                        bool intvalue = Int32.TryParse(value, out n);
                        if (intvalue)
                        {
                            lock3 = true;
                            ClassMaskGenerator cm = new ClassMaskGenerator(n);
                            cm.FormClosed += new FormClosedEventHandler(cmg_FormClosed); 
                            cm.ShowDialog(this);
                        }
                        else
                        {
                            MessageBox.Show("Invalid value");
                        }
                    }
                }
            }
            
        }

        private void cmg_FormClosed(object sender, FormClosedEventArgs ex)
        {

            int l = comboBox_lists.SelectedIndex;
            int e = listBox_items.CurrentCell.RowIndex;
            try
            {
                lock3 = true;
                if (eLC != null && e > -1)
                {
                    if (l != eLC.ConversationListIndex)
                    {
                        int pos = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "character_combo_id")
                            {
                                pos = i;
                                break;
                            }
                        }

                        if (pos != -1)
                        {
                            eLC.SetValue(l, e, pos, selectedMask.ToString());
                            dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value = selectedMask;
                        }
                    }
                    else
                    {
                        MessageBox.Show("List Not Supported!" + e.ToString());
                    }
                }
            }
            catch (Exception ed)
            {
                MessageBox.Show("CHANGING ERROR!\nFailed changing value, this value seems to be invalid." + ed.ToString());
            }
            lock3 = false;
        }

        private void dataGridView_item_CellClick(object sender, DataGridViewCellEventArgs ex)
        {
            try { if (eLC != null) { selecter_rowscheckbox.SelectedIndex = dataGridView_item.CurrentCell.RowIndex; textBox23.Text = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value.ToString(); } } catch (Exception) { }
            if (eLC != null && dataGridView_item.CurrentCell.ColumnIndex == 0 || eLC != null && dataGridView_item.CurrentCell.ColumnIndex == 2)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                if (l != eLC.ConversationListIndex)
                {
                    string value = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    string name = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    
                    if (name.Equals("character combo id"))
                    {
                        int n;
                        bool intvalue = Int32.TryParse(value, out n);
                        if (intvalue)
                        {
                            lock3 = true;
                            ClassMaskGenerator cm = new ClassMaskGenerator(n);
                            cm.FormClosed += new FormClosedEventHandler(cmg_FormClosed);
                            cm.ShowDialog(this);
                        }
                        else
                        {
                            MessageBox.Show("Invalid value");
                        }
                    }
                    if (name.Equals("file icon") || name.Equals("file icon1"))
                    {
                        int pos = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "ID")
                            {
                                pos = i;
                                break;
                            }
                        }
                        if (pos != -1)
                        {
                            try
                            {
                                int id = Int32.Parse(eLC.Lists[l].GetValue(e, pos).ToString());
                                Point imagePath = new Point(-1,-1);
                                if (ElementsEditor.database.imageposition.ContainsKey(Path.GetFileName(value)))
                                {
                                    imagePath = ElementsEditor.database.imageposition[Path.GetFileName(value)];
                                }
                                ImageChange ic = new ImageChange(id, imagePath);
                                ic.FormClosed += new FormClosedEventHandler(ic_FormClosed);
                                ic.ShowDialog(this);
                            }
                            catch (Exception) { }
                        }
                    }
                    if (name.Contains("id addon"))
                    {
                        EQUIP_ADDON_LISTSELECT EQUIP_ADDON_LISTSELECT = new EQUIP_ADDON_LISTSELECT();
                        //EQUIP_ADDON_LISTSELECT.ShowDialog(this);
                    }
                    if (name.Contains("proc type"))
                    {
                        if (proctypeLocation > 0)
                        {
                            int id = Int32.Parse(eLC.Lists[l].GetValue(e, proctypeLocation).ToString());
                            ProcTypeGenerator ptg = new ProcTypeGenerator(id);
                            ptg.FormClosed += changeProctype;
                            ptg.ShowDialog(this);
                        }
                    }
                    if (name.Contains("skill") && name.Contains("id"))
                    {
                        return;
                    }

                    if (name.Contains("drop matters") && name.Contains("id") || name.Contains("drop matters"))
                    {
                        if (eLC != null)
                        {

                            int n;
                            bool intvalue = Int32.TryParse(value, out n);
                            if (intvalue)
                            {
                                if(eLC.valuableItems.ContainsKey(n))
                                {
                                    ItemDupe ItemDupe = eLC.valuableItems[n];
                                    comboBox_lists.SelectedIndex = ItemDupe.listID;
                                    listBox_items.ClearSelection();
                                    dataGridView_item.ClearSelection();
                                    listBox_items.Rows[ItemDupe.index].Selected = true;
                                    listBox_items.CurrentCell = listBox_items.Rows[ItemDupe.index].Cells[0];
                                    listBox_items_CellClick(null, null);
                                    elementIntoTab.SelectedIndex = 0;
                                    listBox_items.PerformLayout();
                                    dataGridView_item.PerformLayout();
                                }
                            }
                        }
                    }
                    if (name.Contains("param") && !name.Contains("num"))
                    {
                        //String text = "Float: " + (BitConverter.ToSingle(BitConverter.GetBytes(int.Parse(eLC.GetValue(list, element, f))), 0)).ToString("F6");
                        ParmCalc pc = new ParmCalc(value);
                        pc.FormClosed += thislist1parmValueChange;
                        pc.ShowDialog(this);
                        
                    }
                    if(dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[2].Tag is ItemDupe)
                    {
                        ItemDupe ItemDupe = (ItemDupe)dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[2].Tag;
                        comboBox_lists.SelectedIndex = ItemDupe.listID;
                        listBox_items.ClearSelection();
                        dataGridView_item.ClearSelection();
                        listBox_items.Rows[ItemDupe.index].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[ItemDupe.index].Cells[0];
                        listBox_items_CellClick(null, null);
                        elementIntoTab.SelectedIndex = 0;
                        listBox_items.PerformLayout();
                        dataGridView_item.PerformLayout();
                    }
                       

                }
            }
        }

        private void thislist1parmValueChange(object sender, FormClosedEventArgs ex)
        {
            try { if (eLC != null) { selecter_rowscheckbox.SelectedIndex = dataGridView_item.CurrentCell.RowIndex; textBox23.Text = dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value.ToString(); } } catch (Exception) { }
            if (eLC != null && dataGridView_item.CurrentCell.ColumnIndex == 0 || eLC != null && dataGridView_item.CurrentCell.ColumnIndex == 2)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                if (l != eLC.ConversationListIndex)
                {
                    dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[3].Value = Constatns.valueParm;
                    float data = BitConverter.ToSingle(BitConverter.GetBytes(int.Parse(Constatns.valueParm)), 0);

                    String text = (data).ToString("F6");
                    float n;
                    if (float.TryParse(text, out n) && n > 0)
                    {
                        DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                        cell1.Value = "Float: " + text;
                        cell1.ToolTipText = "";
                        dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[2] = cell1;
                    }
                }
            }
        }

        private void changeProctype(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (eLC != null && listBox_items.CurrentCell != null)
                {
                    int l = comboBox_lists.SelectedIndex;
                    int elindex = listBox_items.CurrentCell.RowIndex;
                    if (l != eLC.ConversationListIndex)
                    {
                        if (proctypeLocation > 0 && l > 0 && proctypeLocationvak.ToString() != ProcTypeGenerator.value_tosave)
                        {
                            eLC.Lists[l].SetValue(elindex, proctypeLocation, ProcTypeGenerator.value_tosave);
                            listBox_items_CellClick(null, null);
                        }
                    }
                }
            }
            catch { }
            
        }

        private void dataGridView_item_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                // Remove an existing event-handler, if present, to avoid 
                // adding multiple handlers when the editing control is reused.
                combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                // Add the event handler. 
                combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs ex)
        {
            if (eLC != null && dataGridView_item.CurrentCell.ColumnIndex > -1)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                int row = dataGridView_item.CurrentCell.RowIndex;
                if (l != eLC.ConversationListIndex)
                {
                    ComboBox cb = ((ComboBox)sender);
                    if (cb != null && cb.SelectedIndex > -1)
                    {
                        try
                        {
                            lock3 = true;
                            String value = cb.Items[cb.SelectedIndex].ToString().Split('_')[1];
                            if (value.Length > 0)
                            {
                                dataGridView_item.Rows[row].Cells[3].Value = value;
                                eLC.Lists[l].SetValue(e, row, value);
                            }
                        }
                        catch (Exception) { };
                        listBox_items_CellClick(null, null);
                    }
                    
                }
            }
            lock3 = false;

            
        }

        private void replaceInList(object sender, EventArgs ex)
        {
            if (eLC != null)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                int replaced = 0;
                if(e == -1)
                {
                    MessageBox.Show("Please slect a item!");
                    return;
                }
                if (l != eLC.ConversationListIndex)
                {
                    if ((MessageBox.Show("Are you sure you want to replace all selected items?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        int valueInt = 0;
                        int operation = replaceSelected.SelectedIndex;
                        bool isInt = Int32.TryParse(textBox_newValue.Text, out valueInt);
                        for (int selectedRowx = 0; selectedRowx < dataGridView_item.SelectedRows.Count; selectedRowx++)
                        {
                            int selectedRow = dataGridView_item.SelectedRows[selectedRowx].Index;
                            String valueStr = textBox_newValue.Text;
                            for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                            {
                                Application.DoEvents();
                                progress_bar("Replacing ...", i, listBox_items.SelectedRows.Count);
                                int item = listBox_items.SelectedRows[i].Index;
                                String oldValue = eLC.Lists[l].GetValue(item, selectedRow);
                                String oldValueText = textBox_oldValue.Text.ToString();
                                String type = eLC.GetType(l, selectedRow);
                                String op = "=";
                                switch(operation)
                                {
                                    case 0 :
                                        op = "=";
                                        break;
                                    case 1:
                                        op = "*";
                                        break;
                                    case 2:
                                        op = "/";
                                        break;
                                    case 3:
                                        op = "+";
                                        break;
                                    case 4:
                                        op = "-";
                                        break;
                                }
                                if (oldValueText == "*")
                                {
                                    String calculated = Helper.recalculateElement(type, op, oldValue, valueStr, false);
                                    if (calculated.Length > 0)
                                    {
                                        eLC.Lists[l].SetValue(item, selectedRow, calculated);
                                        replaced++;
                                    }
                                }
                                else
                                {
                                    if (oldValueText.Trim() == oldValue.Trim())
                                    {
                                        String calculated = Helper.recalculateElement(type, op, oldValueText, valueStr, false);
                                        if (calculated.Length > 0)
                                        {
                                            eLC.Lists[l].SetValue(item, selectedRow, calculated);
                                            replaced++;
                                        }
                                    }
                                }
                            }
                        }
                        progress_bar("Ready", 0, 0);
                        
                        if(replaced > 1)
                        {
                            MessageBox.Show("Replaced:" + replaced + " items!");
                        }
                        listBox_items_CellClick(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Not suported!");
                }
            }
        }

        private void copyrightLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.games-shark.com/en/");
        }


        private void ElementsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
               // Hide();
            }
        }

        private void FileOrginizerForm_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyData == (Keys.Control | Keys.C))
                {
                    e.Handled = true;
                    try
                    {
                        if (exportClipboardWithRules.Checked)
                        {

                            int export_vestion = Int32.Parse(exportCombobox.Items[exportCombobox.SelectedIndex].ToString().Split('>')[0]);
                            if (eLC.Version == export_vestion)
                            {
                                exportItemsWithRulesFromClipBoard();
                            }else
                            {
                                exportClipboardwithNorules();
                            }
                        }else
                        {
                            exportClipboardwithNorules();
                        }
                        
                    }
                    catch(Exception)
                    {
                        exportClipboardwithNorules();
                    }
                }
                else if (e.KeyData == (Keys.Control | Keys.V))
                {
                    e.Handled = true;
                    ElementsEditor.isImportcanceled = true;
                    ImportOption io = new ImportOption();                                
                    io.ShowDialog(this);
                    if (!ElementsEditor.isImportcanceled)
                    {
                        importItemsWithRulesFromClipBoard();
                    }
                }
                else if (e.KeyData == Keys.Delete)
                {
                    e.Handled = true;
                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                    int count = listBox_items.SelectedRows.Count;
                        if ((MessageBox.Show("Do you realy want to delete:" + count+" items?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                        {
                            deleteToolStripMenuItem_Click(null, null);
                        }
                    }
                
                }
        }

        private string memoryStreamToString(Byte[] value)
        {
            string temp_inBase64 = Convert.ToBase64String(value);
            return temp_inBase64;
        }

        public void CopyToClipboard(Export objectToCopy)
        {
            string format = "MyImporting";
            Clipboard.Clear();
            Clipboard.SetData(format, objectToCopy);
        }

        protected Export GetFromClipboard()
        {
            Export doc = null;
            string format = "MyImporting";
            if (Clipboard.ContainsData(format))
            {
                doc = (Export)Clipboard.GetData(format);
            }
            return doc;
        }

        public static bool isImportWithReplace = false;
        public static bool isImportWithAdd = true;
        public static bool isImportWithDelete = false;
        public static bool isImportcanceled = true;
        private Dictionary<int, SaleTab> saleTabAllItems;

        private void importItemsWithRulesFromClipBoard()
        {

            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to import!", 0, 0);
                return;
            }

            int ltc = comboBox_lists.SelectedIndex;
            Export obj = GetFromClipboard();
            if (obj != null)
            {
                    if(obj.ForVersion != eLC.Version)
                    {
                        if(!(MessageBox.Show("You are about to import " + obj.ForVersion + " on " + eLC.Version + "! Do you want to continue?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                        {
                            return;
                        }
                    }
                    progress_bar("Importing ...", 0, 0);
                    if (obj.ListId != -1)
                    {
                        comboBox_lists.SelectedIndex = obj.ListId;
                        ltc = obj.ListId;
                        Application.DoEvents();
                        comboBox_lists.Enabled = false;
                        listBox_items.Enabled = false;
                        locked = true;
                    }
                    

                    int i = 0;
                    if (ElementsEditor.isImportWithDelete)
                    {
                        eLC.Lists[obj.ListId].elementValues = new Dictionary<int, Dictionary<int, object>>();
                    }
                    foreach (KeyValuePair<int, Object> importObject in obj.data)
                    {

                    if (importObject.Value is Export)
                    {

                        Export datxzx = (Export)importObject.Value;
                        foreach (KeyValuePair<int, object> entryx in datxzx.data)
                        {
                            KeyValuePair<int, Object> entry = entryx;
                            Application.DoEvents();
                            progress_bar("Importing ...", i, datxzx.data.Count);
                            if (eLC.ConversationListIndex == datxzx.ListId)
                            {
                                conversationList.DialogCount++;
                                conversationList.Dialogs[conversationList.DialogCount - 1] = (eDialog)entry.Value;
                                i++;
                            }
                            else
                            {
                                Dictionary<int, object> data = (Dictionary<int, object>)entry.Value;
                                int id_index = -1;
                                if (ElementsEditor.isImportWithAdd)
                                {
                                    eLC.Lists[datxzx.ListId].AddItem(datxzx.ListId, data);
                                    i++;
                                }
                                else if (ElementsEditor.isImportWithReplace)
                                {
                                    if (id_index == -1)
                                    {
                                        for (int e = 0; 0 < eLC.Lists[datxzx.ListId].elementFields.Count; e++)
                                        {
                                            if (eLC.Lists[datxzx.ListId].elementFields[e] == "ID")
                                            {
                                                id_index = e;
                                                break;
                                            }
                                        }
                                    }
                                    int itemID = -1;
                                    if (id_index != -1)
                                    {
                                        itemID = (int)data[id_index];
                                    }
                                    if (itemID != -1)
                                    {
                                        int elementIndex = getItemIDbyListId(datxzx.ListId, itemID);
                                        bool done = false;
                                        if (elementIndex != -1)
                                        {
                                            eLC.Lists[datxzx.ListId].elementValues[elementIndex] = data;
                                            done = true;
                                            i++;
                                        }
                                        if (!done)
                                        {
                                            eLC.Lists[datxzx.ListId].AddItem(datxzx.ListId, data);
                                            i++;
                                        }
                                    }

                                }
                                else if (ElementsEditor.isImportWithDelete)
                                {
                                    eLC.Lists[datxzx.ListId].AddItem(datxzx.ListId, data);
                                    i++;
                                }

                                if (autonewIdCTRLV.Checked && ElementsEditor.isImportWithDelete || autonewIdCTRLV.Checked && ElementsEditor.isImportWithAdd)
                                {
                                    if (id_index == -1)
                                    {
                                        for (int e = 0; 0 < eLC.Lists[datxzx.ListId].elementFields.Count; e++)
                                        {
                                            if (eLC.Lists[datxzx.ListId].elementFields[e] == "ID")
                                            {
                                                id_index = e;
                                                break;
                                            }
                                        }
                                    }
                                    if (id_index != -1)
                                    {
                                        if (configs.nextAutoNewId == 0)
                                        {
                                            configs.nextAutoNewId = eLC.getNextFreeId(0, null, null);
                                        }
                                        data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                                        configs.nextAutoNewId = (int)data[id_index];
                                        eLC.useFreeId(configs.nextAutoNewId, datxzx.ListId, eLC.Lists[datxzx.ListId].elementValues.Count);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        KeyValuePair<int, Object> entry = importObject;
                        Application.DoEvents();
                        progress_bar("Importing ...", i, obj.data.Count);
                        if (eLC.ConversationListIndex == obj.ListId)
                        {
                            conversationList.DialogCount++;
                            conversationList.Dialogs[conversationList.DialogCount - 1] = (eDialog)entry.Value;
                            i++;
                        }
                        else
                        {
                            Dictionary<int, object> data = (Dictionary<int, object>)entry.Value;
                            int id_index = -1;
                            if (ElementsEditor.isImportWithAdd)
                            {
                                eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                                i++;
                            }
                            else if (ElementsEditor.isImportWithReplace)
                            {
                                if (id_index == -1)
                                {
                                    for (int e = 0; 0 < eLC.Lists[obj.ListId].elementFields.Count; e++)
                                    {
                                        if (eLC.Lists[obj.ListId].elementFields[e] == "ID")
                                        {
                                            id_index = e;
                                            break;
                                        }
                                    }
                                }
                                int itemID = -1;
                                if (id_index != -1)
                                {
                                    itemID = (int)data[id_index];
                                }
                                if (itemID != -1)
                                {
                                    int elementIndex = getItemIDbyListId(obj.ListId, itemID);
                                    bool done = false;
                                    if (elementIndex != -1)
                                    {
                                        eLC.Lists[obj.ListId].elementValues[elementIndex] = data;
                                        done = true;
                                        i++;
                                    }
                                    if (!done)
                                    {
                                        eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                                        i++;
                                    }
                                }

                            }
                            else if (ElementsEditor.isImportWithDelete)
                            {
                                eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                                i++;
                            }

                            if (autonewIdCTRLV.Checked && ElementsEditor.isImportWithDelete || autonewIdCTRLV.Checked && ElementsEditor.isImportWithAdd)
                            {
                                if (id_index == -1)
                                {
                                    for (int e = 0; 0 < eLC.Lists[obj.ListId].elementFields.Count; e++)
                                    {
                                        if (eLC.Lists[obj.ListId].elementFields[e] == "ID")
                                        {
                                            id_index = e;
                                            break;
                                        }
                                    }
                                }
                                if (id_index != -1)
                                {
                                    if (configs.nextAutoNewId == 0)
                                    {
                                        configs.nextAutoNewId = eLC.getNextFreeId(0, null, null);
                                    }
                                    data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                                    configs.nextAutoNewId = (int)data[id_index];
                                    eLC.useFreeId(configs.nextAutoNewId, obj.ListId, eLC.Lists[obj.ListId].elementValues.Count);
                                }

                            }

                        }
                    }

                    }
                this.refreshTaskRecipes();
                locked = false;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                change_list(null, null);
                listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Cells[0];
                listBox_items_CellClick(null, null);
                progress_bar("Ready", 0, 0);
            }

            locked = false;
            
        }


        private int getItemIDbyListId(int list, int itemID)
        {

                int pos = 0;
                for (int i = 0; i < eLC.Lists[list].elementFields.Count; i++)
                {
                    if (eLC.Lists[list].elementFields[i] == "ID")
                    {
                        pos = i;
                        break;
                    }
                }
                for (int e = 0; e < eLC.Lists[list].elementValues.Count; e++)
                {
                    try
                    {
                        if (itemID == Int32.Parse(eLC.GetValue(list, e, pos).ToString()))
                        {
                            return e;
                        }
                        
                    }
                    catch (Exception) { }
                }
            return -1;
        }

        private void exportItemsWithRulesFromClipBoard()
        {
            int total_exported_items = 0;
            int total_fixed_rows = 0;
            if (exportCombobox.SelectedIndex == -1)
            {
                progress_bar("Please select a version to copy!", 0, 0);
                return;
            }

            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to copy!", 0, 0);
                return;
            }

            int list = comboBox_lists.SelectedIndex;
            int xe = listBox_items.CurrentCell.RowIndex;

            int export_vestion = Int32.Parse(exportCombobox.Items[exportCombobox.SelectedIndex].ToString().Split('>')[0]);
            int export_vestion_current = Int32.Parse(exportCombobox.Items[exportCombobox.SelectedIndex].ToString().Split('>')[1]);
            if (configs.currentConvertSettings.ContainsKey(export_vestion))
            {
                empty_eLC = new eListCollection();
                empty_eLC.progress_bar += progress_bar;
                empty_eLC.setLists(empty_eLC.loadEmptyConfigs(export_vestion_current));
            }
            else
            {
                progress_bar("Export failed no configs!", 0, 0);
                return;
            }
            if (xe > -1)
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export();
                        export.ListId = list;
                        export.type = 0; //Elements data = 0 | Gshop = 1 
                        export.ForVersion = export_vestion_current;
                        export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Copying ...", i, listBox_items.SelectedRows.Count);
                            int item = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex == eLC.ConversationListIndex)
                            {
                                export.data.Add(i, conversationList.Dialogs[item]);
                            }
                            else
                            {
                                empty_eLC.Lists[list].elementValues = new Dictionary<int, Dictionary<int, object>>();
                                Dictionary<int, object> data = new Dictionary<int, object>();
                                for (int d = 0; d < empty_eLC.Lists[list].elementFields.Count; d++)
                                {
                                    data.Add(d, empty_eLC.getDefaultValue(empty_eLC.Lists[list].elementTypes[d].ToString()));
                                }
                                empty_eLC.Lists[list].elementValues[item] = data;
                                int rowToEdit = 0;
                                int iexMax = empty_eLC.Lists[list].elementFields.Count;
                                int currentRow = 0;
                                while (rowToEdit < iexMax)
                                {
                                    if (configs.currentConvertSettings[export_vestion].lists.ContainsKey(list))
                                    {
                                        if (configs.currentConvertSettings[export_vestion].lists[list].ContainsKey(rowToEdit))
                                        {
                                            String operation = configs.currentConvertSettings[export_vestion].lists[list][rowToEdit].operation;
                                            if (operation == Constatns.add)
                                            {
                                                empty_eLC.Lists[list].SetValue(item, rowToEdit, configs.currentConvertSettings[export_vestion].lists[list][rowToEdit].value.ToString());
                                            }
                                            if (operation == Constatns.replace)
                                            {
                                                empty_eLC.Lists[list].SetValue(item, rowToEdit, configs.currentConvertSettings[export_vestion].lists[list][rowToEdit].value.ToString());
                                            }

                                            if (total_exported_items == 0)
                                            {
                                                total_fixed_rows++;
                                            }
                                            currentRow++;
                                        }
                                        else
                                        {
                                            empty_eLC.Lists[list].SetValue(item, rowToEdit, eLC.Lists[list].GetValue(item, (rowToEdit - currentRow)));
                                        }
                                    }
                                    else
                                    {
                                        empty_eLC.Lists[list].SetValue(item, rowToEdit, eLC.Lists[list].GetValue(item, (rowToEdit - currentRow)));
                                    }
                                    rowToEdit++;
                                }
                                Object datax = (Object)empty_eLC.Lists[list].elementValues[item];
                                export.data.Add(i, datax);
                            }
                            total_exported_items++;
                        }
                        CopyToClipboard(export);
                    }

                    locked = false;
                    MessageBox.Show("Copyed items:" + total_exported_items.ToString() + " Row Fixed:" + total_fixed_rows);
                }
                catch (Exception asd)
                {
                    MessageBox.Show("Copy ERROR:" + asd.ToString());
                }
                // listBox_items_CellValueChanged(null, null);
                progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");
            }
        }

        private void exportClipboardwithNorules()
        {

            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            int l = comboBox_lists.SelectedIndex;
            int xe = listBox_items.CurrentCell.RowIndex;
            if (xe > -1)
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export();
                        export.ListId = l;
                        export.type = 0; //Elements data = 0 | Gshop = 1 
                        export.ForVersion = eLC.Version;
                        export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Copying ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex == eLC.ConversationListIndex)
                            {

                                export.data.Add(i, conversationList.Dialogs[index]);
                            }
                            else
                            {
                                export.data.Add(i, eLC.Lists[l].elementValues[index]);
                            }

                        }
                        CopyToClipboard(export);
                    }

                    locked = false;
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    configs.exportClipboardWithRules = exportClipboardWithRules.Checked;
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }

        private void listBox_items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(customTooltype != null)
                customTooltype.Close();
            }
            catch { }
            if (e.ColumnIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                InfoTool ift = null;
                try
                {
                    int l = comboBox_lists.SelectedIndex;
                    int xe = e.RowIndex;
                    int Id = Convert.ToInt32(this.listBox_items.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        ift = Extensions.GetItemProps2(Id, 0, l, xe);
                    }
                    if (ift == null)
                    {
                        string text = Extensions.GetItemProps(Id, 0);
                        text += Extensions.ItemDesc(Id);
                        this.listBox_items.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                    }
                    else
                    {
                        ift.description = Extensions.ColorClean(Extensions.ItemDesc(Id));
                        customTooltype = new IToolType(ift);
                        customTooltype.Show();
                    }
                }
                catch
                {
                }
            }
        }

        private void listBox_items_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (customTooltype != null)
            {
                customTooltype.Close();
            }
        }

        private Button lastBtnPressPreview = null;
        private void tab_salebtn_1_MouseClick(object sender, MouseEventArgs e)
        {

            tab_salebtn_1.ForeColor = Color.Black;
            tab_salebtn_1.BackColor = Color.White;
            tab_salebtn_2.ForeColor = Color.Black;
            tab_salebtn_2.BackColor = Color.White;
            tab_salebtn_3.ForeColor = Color.Black;
            tab_salebtn_3.BackColor = Color.White;
            tab_salebtn_4.ForeColor = Color.Black;
            tab_salebtn_4.BackColor = Color.White;
            tab_salebtn_5.ForeColor = Color.Black;
            tab_salebtn_5.BackColor = Color.White;
            tab_salebtn_6.ForeColor = Color.Black;
            tab_salebtn_6.BackColor = Color.White;
            tab_salebtn_7.ForeColor = Color.Black;
            tab_salebtn_7.BackColor = Color.White;
            tab_salebtn_8.ForeColor = Color.Black;
            tab_salebtn_8.BackColor = Color.White;
            lastBtnPressPreview = sender as Button;
            if (lastBtnPressPreview != null)
            {
                lastBtnPressPreview.ForeColor = Color.White;
                lastBtnPressPreview.BackColor = Color.Black;
                
                int id = int.Parse(lastBtnPressPreview.Tag.ToString());
                if (saleTabAllItems.ContainsKey(id))
                {
                    SortedDictionary<int, SaleItem> items = saleTabAllItems[id].items;
                    foreach (KeyValuePair<int, SaleItem> itemEntry in items)
                    {
                        if (itemEntry.Value.itemId != 0)
                        {
                            string nameofpic = "picture_item_" + itemEntry.Key;
                            PictureBox mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                            mybox.Image = itemEntry.Value.itemInfo.img;
                            mybox.Tag = itemEntry.Value;
                            mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            string nameofpic = "picture_item_" + itemEntry.Key;
                            PictureBox mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                            mybox.Image = null;
                            mybox.Tag = itemEntry.Value;
                        }
                    }
                }
                textBox2.Text = lastBtnPressPreview.Text;
            }
        }


        private bool lockedelementTabInfo = false;
        private void elementIntoTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            if(eLC != null && listBox_items.CurrentCell != null)
            {
                resetrecipeFirst();
                int list = comboBox_lists.SelectedIndex;
                int item = listBox_items.CurrentCell.RowIndex;
                int element = listBox_items.CurrentCell.RowIndex;

                if (list == 54 && elementIntoTab.SelectedIndex > 1 && !lockedelementTabInfo)
                {
                    lockedelementTabInfo = true;
                    tab_craftbtn_1.ForeColor = Color.White;
                    tab_craftbtn_1.BackColor = Color.Black;
                    tab_craftbtn_2.ForeColor = Color.Black;
                    tab_craftbtn_2.BackColor = Color.White;
                    tab_craftbtn_3.ForeColor = Color.Black;
                    tab_craftbtn_3.BackColor = Color.White;
                    tab_craftbtn_4.ForeColor = Color.Black;
                    tab_craftbtn_4.BackColor = Color.White;
                    tab_craftbtn_5.ForeColor = Color.Black;
                    tab_craftbtn_5.BackColor = Color.White;
                    tab_craftbtn_6.ForeColor = Color.Black;
                    tab_craftbtn_6.BackColor = Color.White;
                    tab_craftbtn_7.ForeColor = Color.Black;
                    tab_craftbtn_7.BackColor = Color.White;
                    tab_craftbtn_8.ForeColor = Color.Black;
                    tab_craftbtn_8.BackColor = Color.White;
                    saleTabAllItems = new Dictionary<int, SaleTab>();
                    int elat = 0;
                    int intTabId = 0;
                    for (int f = 0; f < eLC.Lists[list].elementValues[element].Count; f++)
                    {
                        Application.DoEvents();
                        progress_bar("Loading preview...", f, eLC.Lists[list].elementValues[element].Count);
                        if (eLC.Lists[list].elementFields[f].Contains("_title"))
                        {
                            intTabId++;
                            SaleTab saleTab = new SaleTab();
                            saleTab.title = eLC.GetValue(list, element, f);
                            saleTab.List = list;
                            saleTab.Item = element;
                            saleTab.elId = f;
                            saleTabAllItems.Add(intTabId, saleTab);
                            elat = 1;
                        }

                        if (eLC.Lists[list].elementFields[f].Contains("_id"))
                        {
                            string valsx = eLC.GetValue(list, element, f);
                            int saleId = -1;
                            bool isInt = int.TryParse(valsx, out saleId);
                            if (isInt)
                            {
                                if (saleId > 0)
                                {
                                    Recipe recipe = Extensions.getCraftByRecipId(saleId, 0);
                                    if (recipe != null)
                                    {
                                        int itemdi = 0;
                                        bool hasfirstidtomake = false;
                                        if (recipe.targets_1_id_to_make > 0)
                                        {
                                            itemdi = recipe.targets_1_id_to_make;
                                            hasfirstidtomake = true;
                                        }
                                        if (!hasfirstidtomake && recipe.targets_2_id_to_make > 0)
                                        {
                                            itemdi = recipe.targets_2_id_to_make;
                                            hasfirstidtomake = true;
                                        }
                                        if (!hasfirstidtomake && recipe.targets_3_id_to_make > 0)
                                        {
                                            itemdi = recipe.targets_3_id_to_make;
                                            hasfirstidtomake = true;
                                        }
                                        if (!hasfirstidtomake && recipe.targets_4_id_to_make > 0)
                                        {
                                            itemdi = recipe.targets_4_id_to_make;
                                            hasfirstidtomake = true;
                                        }
                                        if (hasfirstidtomake)
                                        {
                                            InfoTool info = Extensions.GetItemProps2byId(itemdi, 0);
                                            SaleItem saleItem = new SaleItem();
                                            saleItem.itemId = saleId;
                                            saleItem.itemInfo = info;
                                            saleItem.recipe = recipe;
                                            saleItem.rowId = f;
                                            saleItem.saleTab = saleTabAllItems[intTabId];
                                            saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                        }else
                                        {
                                            SaleItem saleItem = new SaleItem();
                                            saleItem.itemId = saleId;
                                            saleItem.itemInfo = null;
                                            saleItem.rowId = f;
                                            saleItem.recipe = recipe;
                                            saleItem.saleTab = saleTabAllItems[intTabId];
                                            saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                        }
                                    }else
                                    {
                                        SaleItem saleItem = new SaleItem();
                                        saleItem.itemId = saleId;
                                        saleItem.itemInfo = null;
                                        saleItem.rowId = f;
                                        saleItem.recipe = recipe;
                                        saleItem.saleTab = saleTabAllItems[intTabId];
                                        saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                    }
                                }
                                else
                                {
                                    SaleItem saleItem = new SaleItem();
                                    saleItem.itemId = saleId;
                                    saleItem.itemInfo = null;
                                    saleItem.rowId = f;
                                    saleItem.recipe = null;
                                    saleItem.saleTab = saleTabAllItems[intTabId];
                                    saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                }
                            }
                            elat++;
                        }
                    }

                    int bcount = 0;
                    foreach (KeyValuePair<int, SaleTab> entry in saleTabAllItems)
                    {
                        bcount++;
                        if (bcount == 1)
                        {
                            SortedDictionary<int, SaleItem> items = entry.Value.items;
                            foreach (KeyValuePair<int, SaleItem> itemEntry in items)
                            {
                                if (itemEntry.Value.itemId != 0)
                                {
                                    string nameofpic = "pictureBox_craft_" + itemEntry.Key;
                                    PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                                    
                                    if(itemEntry.Value.itemInfo != null)
                                    {
                                        mybox.Image = itemEntry.Value.itemInfo.img;
                                    }else
                                    {
                                        mybox.Image = new Bitmap(ElementsEditor.database.images("unknown.dds"), 32, 32);
                                    }
                                    mybox.Tag = itemEntry.Value;
                                    mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                                else
                                {
                                    string nameofpic = "pictureBox_craft_" + itemEntry.Key;
                                    PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                                    mybox.Image = null;
                                    mybox.Tag = itemEntry.Value;
                                }

                            }
                        }
                        string nameofButon = "tab_craftbtn_" + bcount;
                        Button myButton = (Button)this.groupBox7.Controls[nameofButon];
                        if (entry.Value.title.Length > 0)
                        {
                            myButton.Text = entry.Value.title;
                            myButton.Tag = bcount;
                            if (bcount <= 1)
                            {
                                if (lastBtnPressPreview == null)
                                {
                                    lastBtnPressPreview = myButton;
                                }
                                textBox3.Text = entry.Value.title;
                            }
                        }
                        else
                        {
                            if (bcount <= 1)
                            {
                                textBox3.Text = "Page " + bcount;
                            }
                            myButton.Text = "Page " + bcount;
                            myButton.Tag = bcount;
                        }
                    }

                    lockedelementTabInfo = false;
                    progress_bar("Ready", 0, 0);
                }
                if (list == 40 && elementIntoTab.SelectedIndex > 1 && !lockedelementTabInfo)
                {
                    lockedelementTabInfo = true;
                    groupBox4.Enabled = false;
                    groupBox1.Enabled = false;
                    
                    tab_salebtn_1.ForeColor = Color.White;
                    tab_salebtn_1.BackColor = Color.Black;
                    tab_salebtn_2.ForeColor = Color.Black;
                    tab_salebtn_2.BackColor = Color.White;
                    tab_salebtn_3.ForeColor = Color.Black;
                    tab_salebtn_3.BackColor = Color.White;
                    tab_salebtn_4.ForeColor = Color.Black;
                    tab_salebtn_4.BackColor = Color.White;
                    tab_salebtn_5.ForeColor = Color.Black;
                    tab_salebtn_5.BackColor = Color.White;
                    tab_salebtn_6.ForeColor = Color.Black;
                    tab_salebtn_6.BackColor = Color.White;
                    tab_salebtn_7.ForeColor = Color.Black;
                    tab_salebtn_7.BackColor = Color.White;
                    tab_salebtn_8.ForeColor = Color.Black;
                    tab_salebtn_8.BackColor = Color.White;
                    saleTabAllItems = new Dictionary<int, SaleTab>();
                    int elat = 0;
                    int intTabId = 0;
                    for (int f = 0; f < eLC.Lists[list].elementValues[element].Count; f++)
                    {
                        Application.DoEvents();
                        progress_bar("Loading preview...", f, eLC.Lists[list].elementValues[element].Count);
                        if (eLC.Lists[list].elementFields[f].Contains("_title"))
                        {
                            intTabId++;
                            SaleTab saleTab = new SaleTab();
                            saleTab.title = eLC.GetValue(list, element, f);
                            saleTab.List = list;
                            saleTab.Item = element;
                            saleTab.elId = f;
                            saleTabAllItems.Add(intTabId, saleTab);
                            elat = 1;
                        }

                        if (eLC.Lists[list].elementFields[f].Contains("_id"))
                        {
                            string valsx = eLC.GetValue(list, element, f);
                            int saleId = -1;
                            bool isInt = int.TryParse(valsx, out saleId);
                            if (isInt)
                            {
                                if (saleId > 0)
                                {
                                    InfoTool info = Extensions.GetItemProps2byId(saleId, 0);
                                    SaleItem saleItem = new SaleItem();
                                    saleItem.itemId = saleId;
                                    saleItem.itemInfo = info;
                                    saleItem.rowId = f;
                                    saleItem.saleTab = saleTabAllItems[intTabId];
                                    saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                }
                                else
                                {
                                    SaleItem saleItem = new SaleItem();
                                    saleItem.itemId = saleId;
                                    saleItem.itemInfo = null;
                                    saleItem.rowId = f;
                                    saleItem.saleTab = saleTabAllItems[intTabId];
                                    saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                }
                            }
                            elat++;
                        }
                    }
                    int bcount = 0;
                    foreach (KeyValuePair<int, SaleTab> entry in saleTabAllItems)
                    {
                        bcount++;
                        if (bcount == 1)
                        {
                            SortedDictionary<int, SaleItem> items = entry.Value.items;
                            foreach (KeyValuePair<int, SaleItem> itemEntry in items)
                            {
                                if (itemEntry.Value.itemId != 0)
                                {
                                    string nameofpic = "picture_item_" + itemEntry.Key;
                                    string nameoflabel = "label_item_" + itemEntry.Key;
                                    PictureBox mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                                    Label mylabel = (Label)this.groupBox1.Controls[nameoflabel];
                                    mybox.Image = itemEntry.Value.itemInfo.img;
                                    mybox.Tag = itemEntry.Value;
                                    mylabel.Text = itemEntry.Value.itemId.ToString();
                                    mylabel.Visible = true;
                                    if(checkBox1.Checked)
                                    {
                                        mylabel.Visible = true;
                                    }else
                                    {
                                        mylabel.Visible = false;
                                    }
                                    mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                                else
                                {
                                    string nameofpic = "picture_item_" + itemEntry.Key;
                                    string nameoflabel = "label_item_" + itemEntry.Key;
                                    PictureBox mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                                    Label mylabel = (Label)this.groupBox1.Controls[nameoflabel];
                                    mylabel.Text = 0.ToString();
                                    mybox.Image = null;
                                    mylabel.Visible = false;
                                    mybox.Tag = itemEntry.Value;
                                }

                            }
                        }
                        string nameofButon = "tab_salebtn_" + bcount;
                        Button myButton = (Button)this.groupBox4.Controls[nameofButon];
                        if (entry.Value.title.Length > 0)
                        {
                            myButton.Text = entry.Value.title;
                            myButton.Tag = bcount;
                            if (bcount <= 1)
                            {
                                if (lastBtnPressPreview == null)
                                {
                                    lastBtnPressPreview = myButton;
                                }
                                textBox2.Text = entry.Value.title;
                            }
                        }
                        else
                        {
                            if (bcount <= 1)
                            {
                                textBox2.Text = "Page " + bcount;
                            }
                            myButton.Text = "Page " + bcount;
                            myButton.Tag = bcount;
                        }
                    }
                    lockedelementTabInfo = false;
                    progress_bar("Ready", 0, 0);
                    groupBox4.Enabled = true;
                    groupBox1.Enabled = true;
                }
            }
        }

        private void picture_item_1_MouseEnter(object sender, EventArgs e)
        {
            var picboxS = sender as PictureBox;
            if (picboxS != null)
            {
                try
                {
                    if(customTooltype != null)
                    customTooltype.Close();
                }
                catch { }
                if (picboxS.Tag != null && ((SaleItem)picboxS.Tag).itemInfo != null)
                {
                    customTooltype = new IToolType(((SaleItem)picboxS.Tag).itemInfo);
                    customTooltype.Show();
                }
            }
        }

        private void picture_item_1_MouseLeave(object sender, EventArgs e)
        {
            if (customTooltype != null)
            {
                customTooltype.Close();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    configs.autoNewId = autonewId.Checked;
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    int val;
                    bool par = int.TryParse(nextautoIdlabel.Text.ToString(), out val);
                    if (par) {
                        configs.nextAutoNewId = eLC.getNextFreeId(val, nextautoIdlabel, nextautoIdlabelmax);
                    }
                    else
                    {
                        configs.nextAutoNewId = eLC.getNextFreeId(0, null, null);
                    }
                    nextautoIdlabel.Text = configs.nextAutoNewId.ToString();
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }
        private SaleItem itemToBeOperated = null;

        private void resetrecipeFirst()
        {
            this.pictureBox_craft_req_1.Image = null;
            this.pictureBox_craft_req_2.Image = null;
            this.pictureBox_craft_req_3.Image = null;
            this.pictureBox_craft_req_4.Image = null;
            this.pictureBox_craft_req_5.Image = null;
            this.pictureBox_craft_req_6.Image = null;
            this.pictureBox_craft_req_7.Image = null;
            this.pictureBox_craft_req_8.Image = null;

            this.pictureBox41.Image = null;
            this.pictureBox42.Image = null;
            this.pictureBox43.Image = null;
            this.pictureBox44.Image = null;
            this.textBox6.Text = "";
            this.textBox8.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.textBox13.Text = "";
            this.textBox14.Text = "";
            this.textBox16.Text = "";
            this.textBox17.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox19.Text = "";
            this.textBox20.Text = "";


            this.textBox24.Text = "";
            this.textBox9.Text = "";
            this.textBox12.Text = "";
            this.textBox18.Text = "";
            this.textBox15.Text = "";
            this.textBox21.Text = "";
            this.textBox22.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 1; i < 9; i++)
            {
                String name = "pictureBox_craft_req_" + i;
                PictureBox box = null;
                box = (PictureBox)this.groupBox10.Controls[name];
                if (box.Tag == null)

                    box.Tag = null;
            }
        }
        private PictureBox lastPicboClick = null;
        private void picture_item_1_Click(object sender, EventArgs e)
        {
            var picboxS = sender as PictureBox;
            if (picboxS != null)
            {
                lastPicboClick = picboxS;
                thisSubMatSelected = null;
                SaleItem saleItem = (SaleItem)picboxS.Tag;
                if (saleItem != null)
                {
                    foreach (KeyValuePair<int, SaleTab> entry in saleTabAllItems)
                    {
                        SortedDictionary<int, SaleItem> items = entry.Value.items;
                        foreach (KeyValuePair<int, SaleItem> itemEntry in items)
                        {
                            PictureBox mybox = null;
                            if (comboBox_lists.SelectedIndex == 40)
                            {
                                string nameofpic = "picture_item_" + itemEntry.Key;
                                mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                            }
                            else
                            {
                                string nameofpic = "pictureBox_craft_" + itemEntry.Key;
                                mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            }

                            Graphics g = mybox.CreateGraphics();
                            g.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                            g.Dispose();
                        }
                    }

                    Graphics gx = picboxS.CreateGraphics();
                    gx.DrawRectangle(new Pen(Brushes.Red), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    gx.Dispose();

                    itemToBeOperated = saleItem;
                    if (comboBox_lists.SelectedIndex == 54)
                    {
                        if(saleItem.recipe != null)
                        {
                            Recipe recipe = saleItem.recipe;
                            Dictionary<int, string> items = recipe.materials;
                            Dictionary<int, string> items_num = recipe.materials;
                            int found = 0;
                            resetrecipeFirst();
                            if (recipe.targets_1_id_to_make > 0)
                            {
                                InfoTool info = Extensions.GetItemProps2byId(recipe.targets_1_id_to_make, 0);
                                if (info != null)
                                {
                                    this.pictureBox41.Image = info.img;
                                    this.textBox6.Text = recipe.targets_1_id_to_make.ToString();
                                    this.textBox8.Text = recipe.targets_1_probability.ToString();
                                    pictureBox41.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }


                            if (recipe.targets_2_id_to_make > 0)
                            {
                                InfoTool info = Extensions.GetItemProps2byId(recipe.targets_2_id_to_make, 0);
                                if (info != null)
                                {
                                    this.pictureBox42.Image = info.img;
                                    this.textBox10.Text = recipe.targets_2_id_to_make.ToString();
                                    this.textBox11.Text = recipe.targets_2_probability.ToString();
                                    pictureBox42.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }

                            if (recipe.targets_3_id_to_make > 0)
                            {
                                InfoTool info = Extensions.GetItemProps2byId(recipe.targets_3_id_to_make, 0);
                                if (info != null)
                                {
                                    this.pictureBox43.Image = info.img;
                                    this.textBox13.Text = recipe.targets_3_id_to_make.ToString();
                                    this.textBox14.Text = recipe.targets_3_probability.ToString();
                                    pictureBox43.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }

                            if (recipe.targets_4_id_to_make > 0)
                            {
                                InfoTool info = Extensions.GetItemProps2byId(recipe.targets_4_id_to_make, 0);
                                if (info != null)
                                {
                                    this.pictureBox44.Image = info.img;
                                    this.textBox16.Text = recipe.targets_4_id_to_make.ToString();
                                    this.textBox17.Text = recipe.targets_4_probability.ToString();
                                    pictureBox44.SizeMode = PictureBoxSizeMode.StretchImage;

                                }
                            }
                            textBox8_Leave(null, null);
                            if (recipe.id_upgrade_equip > 0)
                            {
                                PictureBox box = null;
                                found++;
                                String name = "pictureBox_craft_req_" + found;
                                box = (PictureBox)this.groupBox10.Controls[name];
                                InfoTool info = Extensions.GetItemProps2byId(recipe.id_upgrade_equip, 0);
                                if (info != null)
                                {
                                    SaleItem craftItem = new SaleItem();
                                    craftItem.itemId = recipe.id_upgrade_equip;
                                    craftItem.itemInfo = info;
                                    craftItem.recipe = recipe;
                                    craftItem.upgradable = true;
                                    craftItem.rowId = recipe.id_upgrade_equip_rowId;
                                    box.Image = info.img;
                                    box.Tag = craftItem;
                                }
                            }
                            foreach (KeyValuePair<int, string> entry in items)
                            {
                                try
                                {
                                    if (int.Parse(entry.Value) > 0)
                                    {
                                        found++;
                                        String name = "pictureBox_craft_req_" + found;
                                        PictureBox box = null;
                                        box = (PictureBox)this.groupBox10.Controls[name];
                                        InfoTool info = Extensions.GetItemProps2byId(int.Parse(entry.Value), 0);
                                        if (info != null)
                                        {
                                            SaleItem craftItem = new SaleItem();
                                            craftItem.itemId = int.Parse(entry.Value);
                                            craftItem.itemInfo = info;
                                            craftItem.recipe = recipe;
                                            craftItem.rowId = entry.Key;
                                            box.Image = info.img;
                                            box.Tag = craftItem;
                                        }
                                        box.SizeMode = PictureBoxSizeMode.StretchImage;
                                        if (found == 8)
                                        {
                                            break;
                                        }
                                    }
                                }
                                catch { }
                            }

                            for (int i = 1; i < 9; i++)
                            {
                                String name = "pictureBox_craft_req_" + i;
                                PictureBox box = null;
                                box = (PictureBox)this.groupBox10.Controls[name];
                                if (box.Tag == null)
                                {
                                    SaleItem craftItem = new SaleItem();
                                    craftItem.itemId = 0;
                                    craftItem.itemInfo = null;
                                    craftItem.recipe = recipe;
                                    craftItem.rowId = i;
                                    box.Image = new Bitmap(Resources.blank);
                                    box.Tag = craftItem;
                                }
                            }
                            textBox24.Text = recipe.num_to_make.ToString();
                            textBox9.Text = recipe.recipe_level.ToString();
                            textBox12.Text = recipe.id_skill.ToString();
                            textBox18.Text = recipe.bind_type.ToString();
                            textBox15.Text = recipe.skill_level.ToString();
                            textBox21.Text = recipe.exp.ToString();
                            textBox22.Text = recipe.skillpoint.ToString();
                            textBox7.Text = recipe.ID.ToString();
                            textBox19.Text = recipe.price.ToString();
                            textBox20.Text = recipe.duration.ToString();
                            Helper.getComboboxType(comboBox1, recipe.list, recipe.id_major_type, Constatns.typeMajorType);
                            Helper.getComboboxType(comboBox2, recipe.list, recipe.id_sub_type, Constatns.typeSubType);
                            
                            
                        }

                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0 && itemToBeOperated != null)
            {
                int value = -1;
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    if (int.TryParse(textBox1.Text, out value))
                    {

                        eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, value.ToString());
                        itemToBeOperated = null;
                        elementIntoTab_SelectedIndexChanged(null, null);
                        tab_salebtn_1_MouseClick(lastBtnPressPreview, null);
                    }
                }
            }
        }

        private void delteItemSalePreview(object sender, EventArgs e)
        {
            if (eLC != null && listBox_items.CurrentCell != null)
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        var picboxS = owner.SourceControl as PictureBox;
                        if (picboxS != null)
                        {
                            SaleItem saleItem = (SaleItem)picboxS.Tag;
                            int list = comboBox_lists.SelectedIndex;
                            int item = listBox_items.CurrentCell.RowIndex;
                            eLC.Lists[list].SetValue(item, saleItem.rowId, "0");
                            elementIntoTab_SelectedIndexChanged(null, null);
                            tab_salebtn_1_MouseClick(lastBtnPressPreview, null);
                        }
                    }
                }
            }
        }

        private void addItemSalePreview(object sender, EventArgs e)
        {
            if(itemToBeOperated != null)
            {
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    eLC.Lists[itemToBeOperated.saleTab.List].SetValue(itemToBeOperated.saleTab.Item, itemToBeOperated.saleTab.elId, textBox2.Text);
                    itemToBeOperated = null;
                    elementIntoTab_SelectedIndexChanged(null, null);
                    tab_salebtn_1_MouseClick(lastBtnPressPreview, null);
                }
            }else
            {
                MessageBox.Show("Please select a item in the sale tab first!");
            }
        }

        private void moveHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null && listBox_items.CurrentCell != null)
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        var picboxS = owner.SourceControl as PictureBox;
                        if (picboxS != null)
                        {
                            SaleItem saleItem = (SaleItem)picboxS.Tag;
                            int list = comboBox_lists.SelectedIndex;
                            int item = listBox_items.CurrentCell.RowIndex;
                            if (itemToBeOperated == null)//There is no selected item
                            {
                                if ((MessageBox.Show("Nothing to move here! Would you like to delete?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                {
                                    eLC.Lists[list].SetValue(item, saleItem.rowId, "0");
                                }
                            }
                            else if(itemToBeOperated != null)//There is a selected item
                            {
                                if (saleItem.itemInfo != null)//There's a item where selected item will be placed 
                                {
                                    if ((MessageBox.Show("The box already contains a item, would you like to override? (No to swap)", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                    {
                                        eLC.Lists[list].SetValue(item, saleItem.rowId, itemToBeOperated.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, 0.ToString());
                                    }
                                    else
                                    {
                                        eLC.Lists[list].SetValue(item, saleItem.rowId, itemToBeOperated.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, saleItem.itemId.ToString());
                                    }
                                }
                                else
                                {
                                    eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, 0.ToString());
                                    eLC.Lists[list].SetValue(item, saleItem.rowId, itemToBeOperated.itemId.ToString());
                                }
                            }
                            itemToBeOperated = null;
                            elementIntoTab_SelectedIndexChanged(null, null);
                            tab_salebtn_1_MouseClick(lastBtnPressPreview, null);
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void tab_craftbtn_1_Click(object sender, EventArgs e)
        {
            resetrecipeFirst();
            tab_craftbtn_1.ForeColor = Color.Black;
            tab_craftbtn_1.BackColor = Color.White;
            tab_craftbtn_2.ForeColor = Color.Black;
            tab_craftbtn_2.BackColor = Color.White;
            tab_craftbtn_3.ForeColor = Color.Black;
            tab_craftbtn_3.BackColor = Color.White;
            tab_craftbtn_4.ForeColor = Color.Black;
            tab_craftbtn_4.BackColor = Color.White;
            tab_craftbtn_5.ForeColor = Color.Black;
            tab_craftbtn_5.BackColor = Color.White;
            tab_craftbtn_6.ForeColor = Color.Black;
            tab_craftbtn_6.BackColor = Color.White;
            tab_craftbtn_7.ForeColor = Color.Black;
            tab_craftbtn_7.BackColor = Color.White;
            tab_craftbtn_8.ForeColor = Color.Black;
            tab_craftbtn_8.BackColor = Color.White;
            thisSubMatSelected = null;
            lastBtnPressPreview = sender as Button;
            if (lastBtnPressPreview != null)
            {
                lastBtnPressPreview.ForeColor = Color.White;
                lastBtnPressPreview.BackColor = Color.Black;

                int id = int.Parse(lastBtnPressPreview.Tag.ToString());
                if (saleTabAllItems.ContainsKey(id))
                {
                    SortedDictionary<int, SaleItem> items = saleTabAllItems[id].items;
                    foreach (KeyValuePair<int, SaleItem> itemEntry in items)
                    {
                        if (itemEntry.Value.itemId != 0)
                        {
                            string nameofpic = "pictureBox_craft_" + itemEntry.Key;
                            PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            if (itemEntry.Value.itemInfo != null)
                            {
                                mybox.Image = itemEntry.Value.itemInfo.img;
                            }else
                            {
                                mybox.Image = new Bitmap(ElementsEditor.database.images("unknown.dds"), 32, 32);
                            }
                            mybox.Tag = itemEntry.Value;
                            mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            string nameofpic = "pictureBox_craft_" + itemEntry.Key;
                            PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            mybox.Image = null;
                            mybox.Tag = itemEntry.Value;
                        }
                    }
                }
                textBox3.Text = lastBtnPressPreview.Text;
            }
        }
        private PictureBox thisSubMatSelected = null;

        private void pictureBox_craft_req_1_Click(object sender, EventArgs e)
        {
            var picboxS = sender as PictureBox;
            if (picboxS != null)
            {
                SaleItem saleItem = (SaleItem)picboxS.Tag;
                if (saleItem != null && saleItem.recipe != null && saleItem.itemInfo != null)
                {
                    thisSubMatSelected = picboxS;
                    Recipe recipe = saleItem.recipe;
                    textBox4.Text = saleItem.itemId.ToString();
                    textBox5.Text = eLC.GetValue(recipe.list, recipe.index, saleItem.rowId+1).ToString();
                    if(saleItem.upgradable)
                    {
                        label3.Text = "Upgrade Rate:";
                    }else
                    {
                        label3.Text = "Upgrade Count:";
                    }
                    textBox19.Text = recipe.price.ToString();
                    textBox20.Text = recipe.duration.ToString();
                    Graphics g = pictureBox_craft_req_1.CreateGraphics();
                    g.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g.Dispose();
                    Graphics g1 = pictureBox_craft_req_2.CreateGraphics();
                    g1.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g1.Dispose();
                    Graphics g2 = pictureBox_craft_req_3.CreateGraphics();
                    g2.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g2.Dispose();
                    Graphics g3 = pictureBox_craft_req_4.CreateGraphics();
                    g3.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g3.Dispose();
                    Graphics g4 = pictureBox_craft_req_5.CreateGraphics();
                    g4.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g4.Dispose();
                    Graphics g5 = pictureBox_craft_req_6.CreateGraphics();
                    g5.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g5.Dispose();
                    Graphics g6 = pictureBox_craft_req_7.CreateGraphics();
                    g6.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g6.Dispose();
                    Graphics g7 = pictureBox_craft_req_8.CreateGraphics();
                    g7.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g7.Dispose();
                    Graphics gx = picboxS.CreateGraphics();
                    gx.DrawRectangle(new Pen(Brushes.Red), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    gx.Dispose();
                    button11.Visible = true;
                    button14.Visible = false;

                }
                else
                {
                    thisSubMatSelected = picboxS;
                    Graphics g = pictureBox_craft_req_1.CreateGraphics();
                    g.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g.Dispose();
                    Graphics g1 = pictureBox_craft_req_2.CreateGraphics();
                    g1.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g1.Dispose();
                    Graphics g2 = pictureBox_craft_req_3.CreateGraphics();
                    g2.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g2.Dispose();
                    Graphics g3 = pictureBox_craft_req_4.CreateGraphics();
                    g3.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g3.Dispose();
                    Graphics g4 = pictureBox_craft_req_5.CreateGraphics();
                    g4.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g4.Dispose();
                    Graphics g5 = pictureBox_craft_req_6.CreateGraphics();
                    g5.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g5.Dispose();
                    Graphics g6 = pictureBox_craft_req_7.CreateGraphics();
                    g6.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g6.Dispose();
                    Graphics g7 = pictureBox_craft_req_8.CreateGraphics();
                    g7.DrawRectangle(new Pen(Brushes.White), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g7.Dispose();
                    Graphics gx = picboxS.CreateGraphics();
                    gx.DrawRectangle(new Pen(Brushes.Red), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    gx.Dispose();
                    textBox4.Text = "0";
                    textBox5.Text = "0";
                    button11.Visible = false;
                    button14.Visible = true;
                }
            }
        }

        private void renameCraftTab(object sender, EventArgs e)
        {
            if (itemToBeOperated != null)
            {
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    eLC.Lists[itemToBeOperated.saleTab.List].SetValue(itemToBeOperated.saleTab.Item, itemToBeOperated.saleTab.elId, textBox3.Text);
                    itemToBeOperated = null;
                    elementIntoTab_SelectedIndexChanged(null, null);
                    tab_craftbtn_1_Click(lastBtnPressPreview, null);
                }
            }
            else
            {
                MessageBox.Show("Please select a item in the sale tab first!");
            }
        }

        private void ModifyRecipe(object sender, EventArgs e)
        {
            if (thisSubMatSelected != null)
            {
                SaleItem saleItem = (SaleItem)thisSubMatSelected.Tag;
                if (saleItem != null && saleItem.recipe != null)
                {
                    Recipe recipe = saleItem.recipe;
                    eLC.Lists[recipe.list].SetValue(recipe.index, saleItem.rowId, textBox4.Text);
                    eLC.Lists[recipe.list].SetValue(recipe.index, saleItem.rowId+1, textBox5.Text);
                    if (recipe.id_upgrade_equip_rowId != saleItem.rowId)
                    {
                        saleItem.recipe.materials[saleItem.rowId] = eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId);
                        saleItem.recipe.materials_count[saleItem.rowId + 1] = eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId + 1);
                    }else
                    {
                        saleItem.recipe.id_upgrade_equip = int.Parse(eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId));
                        saleItem.recipe.upgrade_rate = eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId + 1);
                    }
                    if(lastPicboClick != null)
                        picture_item_1_Click(lastPicboClick, null);
                }
            }
        }

        private void modifyClickOtherCraftingItems(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                if (itemToBeOperated != null)
                {
                    SaleItem saleItem = (SaleItem)itemToBeOperated;
                    if (saleItem != null && saleItem.recipe != null)
                    {
                        Recipe recipe = saleItem.recipe;
                        if (textBox6.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_1_id_to_make_rowId, textBox6.Text);
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_1_probability_rowId, textBox8.Text);
                        }
                        if (textBox10.Text.Length > 0)
                        {

                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_2_id_to_make_rowId, textBox10.Text);
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_2_probability_rowId, textBox11.Text);
                        }
                        if (textBox13.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_3_id_to_make_rowId, textBox13.Text);
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_3_probability_rowId, textBox14.Text);
                        }
                        if (textBox16.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_4_id_to_make_rowId, textBox16.Text);
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.targets_4_probability_rowId, textBox17.Text);
                        }

                        if (recipe.fail_probability_rowId > 0 && textBox19.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.fail_probability_rowId, textBox19.Text);
                        }
                        if (recipe.duration_rowId > 0 && textBox20.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.duration_rowId, textBox20.Text);
                        }
                        if (recipe.num_to_make_rowId > 0 && textBox24.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.num_to_make_rowId, textBox24.Text);
                        }
                        if (recipe.id_skill_rowId > 0 && textBox12.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.id_skill_rowId, textBox12.Text);
                        }
                        if (recipe.skill_level_rowId > 0 && textBox12.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.skill_level_rowId, textBox15.Text);
                        }
                        if (recipe.exp_rowId > 0 && textBox21.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.exp_rowId, textBox21.Text);
                        }
                        if (recipe.skillpoint_rowId > 0 && textBox21.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.skillpoint_rowId, textBox22.Text);
                        }
                        if (recipe.bind_type_rowId > 0 && textBox18.Text.Length > 0)
                        {
                            eLC.Lists[recipe.list].SetValue(recipe.index, recipe.bind_type_rowId, textBox18.Text);
                        }

                        elementIntoTab_SelectedIndexChanged(null, null);
                        tab_craftbtn_1_Click(lastBtnPressPreview, null);
                    }
                }
            }
        }

        private void moveCraftingItem(object sender, EventArgs e)
        {
            if (eLC != null && listBox_items.CurrentCell != null)
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        var picboxS = owner.SourceControl as PictureBox;
                        if (picboxS != null)
                        {
                            SaleItem saleItem = (SaleItem)picboxS.Tag;
                            int list = comboBox_lists.SelectedIndex;
                            int item = listBox_items.CurrentCell.RowIndex;
                            if (itemToBeOperated == null)//There is no selected item
                            {
                                if ((MessageBox.Show("Nothing to move here! Would you like to delete?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                {
                                    eLC.Lists[list].SetValue(item, saleItem.rowId, "0");
                                }
                            }
                            else if (itemToBeOperated != null)//There is a selected item
                            {
                                if (saleItem.itemInfo != null)//There's a item where selected item will be placed 
                                {
                                    if ((MessageBox.Show("The box already contains a item, would you like to override? (No to swap)", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                    {
                                        eLC.Lists[list].SetValue(item, saleItem.rowId, itemToBeOperated.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, 0.ToString());
                                    }
                                    else
                                    {
                                        eLC.Lists[list].SetValue(item, saleItem.rowId, itemToBeOperated.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, saleItem.itemId.ToString());
                                    }
                                }
                                else
                                {
                                    eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, 0.ToString());
                                    eLC.Lists[list].SetValue(item, saleItem.rowId, itemToBeOperated.itemId.ToString());
                                }
                            }
                            itemToBeOperated = null;
                            elementIntoTab_SelectedIndexChanged(null, null);
                            tab_craftbtn_1_Click(lastBtnPressPreview, null);
                        }
                    }
                }
            }
        }

        private void deleteCraftItem(object sender, EventArgs e)
        {
            if (eLC != null && listBox_items.CurrentCell != null)
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        var picboxS = owner.SourceControl as PictureBox;
                        if (picboxS != null)
                        {
                            SaleItem saleItem = (SaleItem)picboxS.Tag;
                            int list = comboBox_lists.SelectedIndex;
                            int item = listBox_items.CurrentCell.RowIndex;
                            eLC.Lists[list].SetValue(item, saleItem.rowId, "0");
                            elementIntoTab_SelectedIndexChanged(null, null);
                            tab_craftbtn_1_Click(lastBtnPressPreview, null);
                        }
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0 && itemToBeOperated != null)
            {
                int value = -1;
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    if (int.TryParse(textBox7.Text, out value))
                    {

                        eLC.Lists[list].SetValue(item, itemToBeOperated.rowId, value.ToString());
                        itemToBeOperated = null;
                        elementIntoTab_SelectedIndexChanged(null, null);
                        tab_craftbtn_1_Click(lastBtnPressPreview, null);

                    }
                }
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            double tmp = 0;
            double total = 0;
            if (textBox8.Text.Length > 0)
            {
                tmp = 0;
                double.TryParse(textBox8.Text, out tmp);
                total = total + tmp;
            }
            if (textBox11.Text.Length > 0)
            {
                tmp = 0;
                double.TryParse(textBox11.Text, out tmp);
                total = total + tmp;
            }
            if (textBox14.Text.Length > 0)
            {
                tmp = 0;
                double.TryParse(textBox14.Text, out tmp);
                total = total + tmp;
            }
            if (textBox17.Text.Length > 0)
            {
                tmp = 0;
                double.TryParse(textBox17.Text, out tmp);
                total = total + tmp;
            }
            total = 100 * total;
            label17.Text = total + "%";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (eLC != null && thisSubMatSelected != null)
            {
                SaleItem sale = (SaleItem)thisSubMatSelected.Tag;
                if (sale != null && sale.recipe != null)
                {
                    Recipe recipe = sale.recipe;
                    if ((MessageBox.Show("Is this a normal material?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                    {
                        foreach (KeyValuePair<int, string> entry in recipe.materials)
                        {
                            if (int.Parse(entry.Value) == 0)
                            {
                                eLC.Lists[recipe.list].SetValue(recipe.index, entry.Key, textBox4.Text);
                                eLC.Lists[recipe.list].SetValue(recipe.index, entry.Key + 1, textBox5.Text);
                                sale.recipe.materials[sale.rowId] = eLC.Lists[recipe.list].GetValue(recipe.index, sale.rowId);
                                sale.recipe.materials_count[sale.rowId + 1] = eLC.Lists[recipe.list].GetValue(recipe.index, sale.rowId + 1);
                                if (lastPicboClick != null)
                                    picture_item_1_Click(lastPicboClick, null);
                                break;
                            }
                        }
                    }else
                    {
                        eLC.Lists[recipe.list].SetValue(recipe.index, recipe.id_upgrade_equip_rowId, textBox4.Text);
                        eLC.Lists[recipe.list].SetValue(recipe.index, recipe.upgrade_addon_rate_rowId, textBox5.Text);
                        sale.recipe.materials[sale.rowId] = eLC.Lists[recipe.list].GetValue(recipe.index, sale.rowId);
                        sale.recipe.materials_count[sale.rowId + 1] = eLC.Lists[recipe.list].GetValue(recipe.index, sale.rowId + 1);
                        if (lastPicboClick != null)
                            picture_item_1_Click(lastPicboClick, null);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a recipe.");
                }
               


            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog eSave = new SaveFileDialog();
            eSave.RestoreDirectory = false;
            eSave.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            if (eSave.ShowDialog() == System.Windows.Forms.DialogResult.OK && eSave.FileName != "")
            {
                try
                {
                    if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                    {
                        eLC.Lists[eLC.ConversationListIndex].elementValues[0][0] = conversationList.GetBytes();
                    }
                    eLC.Save(eSave.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("SAVING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    configs.autonewIdCTRLV = autonewIdCTRLV.Checked;
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!firstLoad)
                {
                    configs.enableDisableLiveCacheRefresh = checkBox3.Checked;
                    saveConfigs();
                }
            }
            catch (Exception) { }
        }

        private void replaceSelected_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs ex)
        {
            string toestring = textBox23.Text;
            if(toestring.Length <= 0)
            {
                return;
            }

            if (checkBox5.Checked)
            {
              
                bool isonlyInThisList = checkBox4.Checked;
                bool isCaseSensitive = checkBox2.Checked;
                if(isCaseSensitive)
                {
                    toestring = toestring.Trim().ToLower();
                }
                if (isonlyInThisList)
                {
                    int nameIndex = -1;
                    int list = comboBox_lists.SelectedIndex;
                    if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
                    {
                        dataGridView1.Rows.Clear();

                        if (nameIndex == -1)
                        {
                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                {
                                    nameIndex = f;
                                    break;
                                }
                            }
                        }


                        for (int f = 0; f < eLC.Lists[list].elementValues.Count; f++)
                        {
                            Dictionary<int, Object> data = eLC.Lists[list].elementValues[f];
                            for (int i = 0; i < data.Count; i++)
                            {
                                string value = eLC.Lists[list].GetValue(f, i);
                                if (checkBox2.Checked)
                                {
                                    if (toestring.Equals(value.Trim().ToLower()))
                                    {
                                        string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[i], namex, value, list, f, i });
                                    }
                                }
                                else
                                {
                                    if (value.ToLower().Trim().Contains(toestring.ToLower().Trim()))
                                    {
                                        string namexx = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[i], namexx, value, list, f, i });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                toestring = toestring.Trim().ToLower();
                int list = comboBox_lists.SelectedIndex;
                if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
                {
                    if (checkBox4.Checked)
                    {
                        dataGridView1.Rows.Clear();

                        string name = selecter_rowscheckbox.Items[selecter_rowscheckbox.SelectedIndex].ToString();
                        int nameIndex = -1;
                        int elementIndex = -1;
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                    }
                                    if (eLC.Lists[list].elementFields[f].Equals(name))
                                    {
                                        elementIndex = f;
                                    }
                                    if (nameIndex != -1 && elementIndex != -1)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (elementIndex == -1)
                            {
                                continue;
                            }
                            int e = elementIndex;
                            string value = eLC.Lists[list].GetValue(i, e);
                            if (value.Length == 0)
                            {
                                continue;
                            }
                            if (checkBox2.Checked)
                            {
                                if (toestring.Equals(value.Trim().ToLower()))
                                {
                                    string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex);
                                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], namex, value, list, i, e });
                                }
                            }
                            else
                            {
                                if (value.ToLower().Trim().Contains(toestring.ToLower().Trim()))
                                {
                                    string namexx = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex);
                                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], namexx, value, list, i, e });
                                }
                            }


                        }

                    }
                    else
                    {


                        dataGridView1.Rows.Clear();
                        for (list = 0; list < eLC.Lists.Length; list++)
                        {
                            string name = selecter_rowscheckbox.Items[selecter_rowscheckbox.SelectedIndex].ToString();
                            int nameIndex = -1;
                            int elementIndex = -1;
                            for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                            {
                                if (nameIndex == -1)
                                {
                                    for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                    {
                                        if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                        {
                                            nameIndex = f;
                                        }
                                        if (eLC.Lists[list].elementFields[f].Equals(name))
                                        {
                                            elementIndex = f;
                                        }
                                        if (nameIndex != -1 && elementIndex != -1)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (elementIndex == -1)
                                {
                                    continue;
                                }
                                int e = elementIndex;
                                string value = eLC.Lists[list].GetValue(i, e);
                                if (value.Length == 0)
                                {
                                    continue;
                                }
                                if (checkBox2.Checked)
                                {
                                    if (toestring.Equals(value.Trim().ToLower()))
                                    {
                                        string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex);
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], namex, value, list, i, e });
                                    }
                                }
                                else
                                {
                                    if (value.ToLower().Trim().Contains(toestring.ToLower().Trim()))
                                    {
                                        string namexx = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex);
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], namexx, value, list, i, e });
                                    }
                                }


                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && eLC != null)
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                //2630
                int list = int.Parse(dataGridView1.Rows[rowindex].Cells[3].Value.ToString());
                int element = int.Parse(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());
                int row = int.Parse(dataGridView1.Rows[rowindex].Cells[5].Value.ToString());
                comboBox_lists.SelectedIndex = list;
                listBox_items.ClearSelection();
                dataGridView_item.ClearSelection();
                listBox_items.Rows[element].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[element].Cells[0];
                listBox_items_CellClick(null, null);
                dataGridView_item.Rows[row].Selected = true;
                dataGridView_item.CurrentCell  = dataGridView_item.Rows[row].Cells[0];
                elementIntoTab.SelectedIndex = 0;
                listBox_items.PerformLayout();
                dataGridView_item.PerformLayout();
            }
        }

        private void listSameRowsIDValues(object sender, EventArgs ex)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                dataGridView1.Rows.Clear();
                int nameIndex = -1;
                for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                {
                    if (nameIndex == -1)
                    {
                        for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                        {
                            if (eLC.Lists[list].elementFields[f].Equals("Name"))
                            {
                                nameIndex = f;
                                break;
                            }

                        }
                    }
                    int e = selecter_rowscheckbox.SelectedIndex;
                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e});
                }
            }
        }

        private void button16_Click(object sender, EventArgs ex)
        {
            int[] whereToSearch;
            if (eLC == null || comboBox3.SelectedIndex < 0)
            {
                return;
            }
            string toestring = textBox25.Text;
            if(toestring.Length <= 0)
            {
                return;
            }
            int index = comboBox3.SelectedIndex;
            toestring = checkBox2.Checked ? toestring.ToLower().Trim():toestring;
            switch (index)
            {
                case 0:
                    dataGridView1.Rows.Clear();
                    for (int list = 0; list < eLC.Lists.Length; list++)
                    {
                        Application.DoEvents();
                        progress_bar("Searching...", list, eLC.Lists.Length);
                        int nameIndex = -1;
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }

                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }
                            int e = 0;
                            RowsInfo rowsInfo = new RowsInfo();
                            rowsInfo.rowId = e;
                            rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                            rowsInfo.elementValue = checkBox2.Checked ? eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower() : eLC.Lists[list].GetValue(i, e).ToString();
                            rowsInfo.elementType = eLC.Lists[list].elementTypes[e];
                            if (checkBox2.Checked)
                            {
                                if (toestring.Equals(rowsInfo.elementValue))
                                {
                                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e});
                                }
                            }else
                            {
                                if (toestring.Contains(rowsInfo.elementValue))
                                {
                                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    dataGridView1.Rows.Clear();
                    for (int list = 0; list < eLC.Lists.Length; list++)
                    {
                        Application.DoEvents();
                        progress_bar("Searching...", list, eLC.Lists.Length);
                        int nameIndex = -1;
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }

                                }
                            }
                            if(nameIndex == -1)
                            {
                                continue;
                            }
                                int e = nameIndex;
                                RowsInfo rowsInfo = new RowsInfo();
                                rowsInfo.rowId = e;
                                rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                rowsInfo.elementValue = checkBox2.Checked ? eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower() : eLC.Lists[list].GetValue(i, e).ToString();
                                rowsInfo.elementType = eLC.Lists[list].elementTypes[e];
                            if (checkBox2.Checked)
                            {
                                if (toestring.Equals(rowsInfo.elementValue))
                                {
                                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                }
                            }
                            else
                            {
                                if (toestring.Contains(rowsInfo.elementValue))
                                {
                                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    dataGridView1.Rows.Clear();
                    whereToSearch = new int[] {45,46,74};
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }
                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }
                            
                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("task"))
                                {
                                    int e = f;
                                    RowsInfo rowsInfo = new RowsInfo();
                                    rowsInfo.rowId = e;
                                    rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                    rowsInfo.elementValue = eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower();
                                    rowsInfo.elementType = eLC.Lists[list].elementTypes[e];

                                    if (toestring.Equals(rowsInfo.elementValue))
                                    {
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                    }
                                }
                            }


                        }
                    }
                    break;
                case 3:
                    dataGridView1.Rows.Clear();
                    whereToSearch = new int[] { 38 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }
                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }

                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("drop"))
                                {
                                    int e = f;
                                    RowsInfo rowsInfo = new RowsInfo();
                                    rowsInfo.rowId = e;
                                    rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                    rowsInfo.elementValue = eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower();
                                    rowsInfo.elementType = eLC.Lists[list].elementTypes[e];

                                    if (toestring.Equals(rowsInfo.elementValue))
                                    {
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                    }
                                }
                            }


                        }
                    }
                    break;
                case 4:
                    dataGridView1.Rows.Clear();
                    whereToSearch = new int[] { 79 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }
                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }

                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("materials") && eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("id"))
                                {
                                    int e = f;
                                    RowsInfo rowsInfo = new RowsInfo();
                                    rowsInfo.rowId = e;
                                    rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                    rowsInfo.elementValue = eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower();
                                    rowsInfo.elementType = eLC.Lists[list].elementTypes[e];

                                    if (toestring.Equals(rowsInfo.elementValue))
                                    {
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                    }
                                }
                            }


                        }
                    }
                    break;
                case 5:
                    dataGridView1.Rows.Clear();
                    whereToSearch = new int[] { 69 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }
                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }

                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].ToLower().Trim().Equals("id"))
                                {
                                    int e = f;
                                    RowsInfo rowsInfo = new RowsInfo();
                                    rowsInfo.rowId = e;
                                    rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                    rowsInfo.elementValue = eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower();
                                    rowsInfo.elementType = eLC.Lists[list].elementTypes[e];

                                    if (toestring.Equals(rowsInfo.elementValue))
                                    {
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                    }
                                }
                            }


                        }
                    }
                    break;
                case 6:
                    dataGridView1.Rows.Clear();
                    whereToSearch = new int[] { 40 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }
                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }

                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                    if (eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("goods") && eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("id"))
                                    {
                                        int e = f;
                                        RowsInfo rowsInfo = new RowsInfo();
                                        rowsInfo.rowId = e;
                                        rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                        rowsInfo.elementValue = eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower();
                                        rowsInfo.elementType = eLC.Lists[list].elementTypes[e];

                                        if (toestring.Equals(rowsInfo.elementValue))
                                        {
                                            dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                        }
                                     }
                            }


                        }
                    }
                    break;
                case 7:
                    dataGridView1.Rows.Clear();
                    whereToSearch = new int[] { 21,48 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                        break;
                                    }
                                }
                            }
                            if (nameIndex == -1)
                            {
                                continue;
                            }

                            for (int f = 0; f < eLC.Lists[list].elementFields.Count; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].ToLower().Trim().Contains("id"))
                                {
                                    int e = f;
                                    RowsInfo rowsInfo = new RowsInfo();
                                    rowsInfo.rowId = e;
                                    rowsInfo.elementField = eLC.Lists[list].elementFields[e];
                                    rowsInfo.elementValue = eLC.Lists[list].GetValue(i, e).ToString().Trim().ToLower();
                                    rowsInfo.elementType = eLC.Lists[list].elementTypes[e];

                                    if (toestring.Equals(rowsInfo.elementValue))
                                    {
                                        dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                                    }
                                }
                            }


                        }
                    }
                    break;

            }
            progress_bar("Ready", 0, 0);

        }

        private void dataGridView_item_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void copyAllItemNamesToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {       

                List<string> values = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // int item = dataGridView1.Rows[i];
                   
                    values.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());

                }
                Clipboard.SetText(string.Join(",", values.ToArray()));
             
        }

        private void copyAllItemNamesToClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // int item = dataGridView1.Rows[i];

                values.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());

            }
            Clipboard.SetText(string.Join(",", values.ToArray()));
        }
/*
                     Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                    for (int i = 0; i< eLC.Lists[l].elementFields.Count; i++)
                    {
                        Object data = (Object)eLC.getDefaultValue(eLC.Lists[l].elementTypes[i].ToString());
                        itemValues.Add(i, data);
                    }
                    eLC.AddItem(l, itemValues);
                    int pos = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;
                            break;
                        }
                    }*/
        private void makeRecipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select item/s!", 0, 0);
                return;
            }

            int currentList = comboBox_lists.SelectedIndex;
            int currentCell = listBox_items.CurrentCell.RowIndex;
            if (currentCell > -1)
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {

                        int itemIdIndex = -1;
                        int itemNameIndex = -1;
                        for(int ix = 0; ix< eLC.Lists[currentList].elementFields.Count;ix++)
                        {
                            if(eLC.Lists[currentList].elementFields[ix] == "ID")
                            {
                                itemIdIndex = ix;
                            }
                            if (eLC.Lists[currentList].elementFields[ix] == "Name")
                            {
                                itemNameIndex = ix;
                            }
                            if (itemIdIndex != -1 && itemNameIndex != -1)
                            {
                                break;
                            }
                        }
                        if(itemIdIndex == -1)
                        {
                            locked = false;
                            MessageBox.Show("Cant create recipes in this list!");
                            return;
                        }
                        if (itemNameIndex == -1)
                        {
                            locked = false;
                            MessageBox.Show("Cant create recipes in this list!");
                            return;
                        }
                        int recipes_listId = 69;
                        int targets_1_id_to_make = 0;
                        int targets_1_probability = 0;
                        int targets_Name = 0;
                        int num_to_make = 0;
                        Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                        for (int ie = 0; ie < eLC.Lists[recipes_listId].elementFields.Count; ie++)
                        {
                            Object data = (Object)eLC.getDefaultValue(eLC.Lists[recipes_listId].elementTypes[ie].ToString());
                            String dataName = eLC.Lists[recipes_listId].elementFields[ie];
                            if (dataName == "Name")
                            {
                                targets_Name = ie;
                            }
                            if (dataName == "targets_1_id_to_make")
                            {
                                targets_1_id_to_make = ie;
                            }
                            if (dataName == "targets_1_probability")
                            {
                                targets_1_probability = ie;
                            }
                            if (dataName == "num_to_make")
                            {
                                num_to_make = ie;
                            }
                            if (dataName == "id_major_type")
                            {
                                data = (int)2040;
                            }
                            if (dataName == "num_to_make")
                            {
                                data = (int)2;
                            }


                            itemValues.Add(ie, data);
                        }

                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Creating Recipes ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex != eLC.ConversationListIndex)
                            {
                                int itemId = int.Parse(eLC.GetValue(currentList, index, itemIdIndex));
                                String itemName = eLC.GetValue(currentList, index, itemNameIndex);
                                Dictionary<int, Object> itemValuesClone = new Dictionary< int, Object> (itemValues);
                                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                                itemValuesClone[0] = (int)configs.nextAutoNewId;
                                eLC.useFreeId(configs.nextAutoNewId, recipes_listId, currentCell);
                                Encoding enc = Encoding.GetEncoding("Unicode");
                                byte[] target = new byte[Convert.ToInt32(eLC.Lists[recipes_listId].GetType(targets_Name).Substring(8))];
                                byte[] source = enc.GetBytes(itemName);
                                if (target.Length > source.Length)
                                {
                                    Array.Copy(source, target, source.Length);
                                }
                                else
                                {
                                    Array.Copy(source, target, target.Length);
                                }
                                itemValuesClone[targets_Name] = target;
                                itemValuesClone[num_to_make] = (int)1;
                                itemValuesClone[targets_1_id_to_make] = (int)itemId;
                                itemValuesClone[targets_1_probability] = (float)1;
                                eLC.AddItem(recipes_listId, itemValuesClone);

                            }
                            else
                            {
                                locked = false;
                                MessageBox.Show("Cant make recipes from conversation list.");
                                break;
                            }
                        }
                    }

                    locked = false;
                    this.refreshTaskRecipes();
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");

            }
        }

        private void dataGridView_item_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V) && eLC != null)
            {
                Export obj = GetFromClipboard();
                if (obj != null)
                {
                    if (obj.ListId == 69 && comboBox_lists.SelectedIndex == 54)
                    {
                        populateFieldsFromExport(obj);
                        e.Handled = true;
                    }
                    if (comboBox_lists.SelectedIndex == 40 && obj.ListId != 69)
                    {
                        populateFieldsFromExportSellService(obj);
                        e.Handled = true;
                    }
                }
            }
        }

        private void populateFieldsFromExportSellService(Export exportData)
        {
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select item/s!", 0, 0);
                return;
            }

            int currentList = comboBox_lists.SelectedIndex;
            int currentCell = listBox_items.CurrentCell.RowIndex;
            if (currentCell > -1)
            {
                try
                {

                    locked = true;
                    List<int> ids = new List<int>();
                    foreach (KeyValuePair<int, object> entry in exportData.data)
                    {
                        Dictionary<int, object> data = (Dictionary<int, object>)entry.Value;
                        ids.Add((int)data[0]);
                    }
                    int pageId = 0;
                    int rowindex = dataGridView_item.CurrentCell != null ? dataGridView_item.CurrentCell.RowIndex : 0;
                    for (int row = rowindex; row < eLC.Lists[currentList].elementFields.Count; row++)
                    {
                        if (ids.Count == 0)
                        {
                            break;
                        }
                        string rowName = eLC.Lists[currentList].elementFields[row];
                        string rowValue = eLC.Lists[currentList].GetValue(currentCell, row);
                        if (rowName.Contains("goods") && rowName.Contains("id") && rowValue == "0" && !rowName.Contains("contrib") && !rowName.Contains("contribution") && !rowName.Contains("unk"))
                        {
                            int id = ids[0];
                            eLC.Lists[currentList].SetValue(currentCell, row, id.ToString());
                            ids.RemoveAt(0);
                        }
                        if (rowName.Contains("page_title"))
                        {
                            pageId++;
                        }
                        if (rowName.Contains("page_title") && rowValue.Length == 0)
                        {
                           
                            eLC.Lists[currentList].SetValue(currentCell, row, "Page " + pageId);
                        }
                    }
                    locked = false;
                    listBox_items_CellClick(null, null);
                }
                catch { }
            }
            locked = false;
        }
        private void populateFieldsFromExport(Export exportData)
        {
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select item/s!", 0, 0);
                return;
            }

            int currentList = comboBox_lists.SelectedIndex;
            int currentCell = listBox_items.CurrentCell.RowIndex;
            if (currentCell > -1)
            {
                try
                {
                    
                    locked = true;
                    List<int> ids = new List<int>();
                    foreach (KeyValuePair<int, object> entry in exportData.data)
                    {
                        Dictionary<int, object> data = (Dictionary<int, object>)entry.Value;
                        ids.Add((int)data[0]);
                    }
                    int pageId = 0;
                    int rowindex = dataGridView_item.CurrentCell != null ? dataGridView_item.CurrentCell.RowIndex : 0;
                    for (int row = rowindex; row < eLC.Lists[currentList].elementFields.Count; row++)
                    {
                        if(ids.Count == 0)
                        {
                            break;
                        }
                        string rowName = eLC.Lists[currentList].elementFields[row];
                        string rowValue = eLC.Lists[currentList].GetValue(currentCell, row);
                        if(rowName.Contains("id_goods") && rowValue == "0")
                        {
                            int id = ids[0];
                            eLC.Lists[currentList].SetValue(currentCell, row, id.ToString());
                            ids.RemoveAt(0);
                        }
                        if (rowName.Contains("page_title"))
                        {
                            pageId++;
                        }
                        if (rowName.Contains("page_title") && rowValue.Length == 0)
                        {
                            eLC.Lists[currentList].SetValue(currentCell, row, "Page " + pageId);
                        }
                     }
                    locked = false;
                    listBox_items_CellClick(null, null);
                }
                catch { }
            }
            locked = false;
        }


        public void refreshTaskRecipes()
        {
            if(!checkBox3.Checked)
            {
                return;
            }
            int currentList = comboBox_lists.SelectedIndex;
            for (int e = 0; e < eLC.Lists[currentList].elementValues.Count; e++)
            {
                int id = -1;
                String name = "";
                // go through all fields of an element
                int idnpc = -1;
                String namenpc = "";
                int idtest = -1;
                int l = currentList;
                for (int f = 0; f < eLC.Lists[currentList].elementTypes.Count; f++)
                {
                if (eLC.Lists[currentList].elementFields[f] == "ID")
                {
                    idtest = Int32.Parse(eLC.Lists[currentList].GetValue(e, f));
                    if (l == 0)
                    {
                        if (!eLC.addonIndex.ContainsKey(idtest))
                        {
                            eLC.addonIndex.Add(idtest, e);
                        }
                        else
                        {
                            eLC.addonIndex[idtest] = e;
                        }
                    }
                    if (!eLC.ocupiedIds.ContainsKey(idtest))
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        eLC.ocupiedIds.Add(idtest, itemDupe);
                    }
                    else
                    {
                        if (!eLC.ocupiedIds_duplicate.ContainsKey(idtest))
                        {
                            ItemDupe itemDupe = new ItemDupe();
                            itemDupe.count = 1;
                            itemDupe.listID = l;
                            itemDupe.index = e;
                            eLC.ocupiedIds_duplicate.Add(idtest, itemDupe);
                        }
                        else
                        {
                            eLC.ocupiedIds_duplicate[idtest].count++;
                        }

                    }
                }
                if (eLC.Lists[l].elementFields[f] == "Name" && idtest > 0)
                {
                    if (eLC.ocupiedIds_duplicate.ContainsKey(idtest))
                    {
                        eLC.ocupiedIds_duplicate[idtest].itemId = idtest;
                        eLC.ocupiedIds_duplicate[idtest].name = eLC.Lists[l].GetValue(e, f);
                    }
                    if (eLC.ocupiedIds.ContainsKey(idtest))
                    {
                        eLC.ocupiedIds[idtest].itemId = idtest;
                        eLC.ocupiedIds[idtest].name = eLC.Lists[l].GetValue(e, f);
                    }

                    int[] whereToSearch = new int[] { 3, 6, 9, 12, 15, 17, 19, 21, 22, 23, 24, 28, 30, 31, 35, 74, 75, 79, 89, 95, 106, 114, 115, 116, 33 };
                    if (whereToSearch.Contains<int>(l))
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.valuableItems[idtest] = itemDupe;
                    }
                    if (l == 40)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCSellServices[idtest] = itemDupe;
                    }
                    if (l == 45)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCReciveQuests[idtest] = itemDupe;
                    }
                    if (l == 46)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCActivateQuests[idtest] = itemDupe;
                    }
                    if (l == 47)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCTasks[idtest] = itemDupe;
                    }
                    if (l == 48)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCSkill[idtest] = itemDupe;
                    }
                    if (l == 54)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCCraftingService[idtest] = itemDupe;
                    }
                    if (l == 145)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCEngraveService[idtest] = itemDupe;
                    }
                    if (l == 146)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCHoneService[idtest] = itemDupe;
                    }
                    if (l == 38)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.MONSTERS[idtest] = itemDupe;
                    }
                    if (l == 56)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.NPCTYPE[idtest] = itemDupe;
                    }
                    if (l == 150)
                    {
                        ItemDupe itemDupe = new ItemDupe();
                        itemDupe.count = 1;
                        itemDupe.listID = l;
                        itemDupe.index = e;
                        itemDupe.name = eLC.Lists[l].GetValue(e, f);
                        itemDupe.itemId = idtest;
                        eLC.FORCES[idtest] = itemDupe;
                    }

                        // 32227
                    }
                if (l == 38 || l == 57 || l == 79)
                {
                    if (eLC.Lists[l].elementFields[f] == "ID")
                    {
                        idnpc = Int32.Parse(eLC.Lists[l].GetValue(e, f));
                        // NpcEditor.npcdb
                    }
                    if (eLC.Lists[l].elementFields[f] == "Name")
                    {
                        namenpc = eLC.Lists[l].GetValue(e, f);
                        NpcEditor.npcdb[idnpc] = namenpc;
                    }
                }
                if (Helper.list_supdype.ContainsKey(l))
                {

                    if (eLC.Lists[l].elementFields[f] == "ID")
                    {
                        id = Int32.Parse(eLC.Lists[l].GetValue(e, f));
                    }
                    if (eLC.Lists[l].elementFields[f] == "Name")
                    {
                        name = eLC.Lists[l].GetValue(e, f);
                        SubTypeElement ste = new SubTypeElement();
                        if (Helper.list_supdype[l].type == Constatns.typeSubType)
                        {
                            if (Helper.subtypesInfolist.ContainsKey(Helper.list_supdype[l].useonList))
                            {
                                Helper.subtypesInfolist[Helper.list_supdype[l].useonList].subtype.Add(id, name);
                            }
                            else
                            {
                                Helper.subtypesInfolist.Add(Helper.list_supdype[l].useonList, ste);
                                Helper.subtypesInfolist[Helper.list_supdype[l].useonList].subtype.Add(id, name);
                            }
                        }

                        if (Helper.list_supdype[l].type == Constatns.typeMajorType)
                        {
                            if (Helper.subtypesInfolist.ContainsKey(Helper.list_supdype[l].useonList))
                            {
                                if (!Helper.subtypesInfolist[Helper.list_supdype[l].useonList].majorType.ContainsKey(id))
                                {
                                    Helper.subtypesInfolist[Helper.list_supdype[l].useonList].majorType.Add(id, name);
                                }
                            }
                            else
                            {
                                Helper.subtypesInfolist.Add(Helper.list_supdype[l].useonList, ste);
                                Helper.subtypesInfolist[Helper.list_supdype[l].useonList].majorType.Add(id, name);
                            }
                        }
                     }    
                  }
                }
            }
            //ReloadInfo(currentList);


        }
        private void ReloadInfo(int list)
        {
            if (database.task_items != null)
            {
                TaskEditor.eLC = eLC;
            }
            progress_bar("Loading ...", 0, 0);
            try
            {
                if (eLC.Lists.Length > 0)
                {
                    int l = -1;
                    int pos = -1;
                    int posP = -1;
                    int posPrice = -1;
                        try
                        {
                            l = list;
                            pos = -1;
                            posP = -1;
                            posPrice = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                            {
                                if (eLC.Lists[l].elementFields[i] == "Name")
                                {
                                    pos = i;

                                }
                                if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                                {
                                    posP = i;
                                }
                                if (eLC.Lists[l].elementFields[i] == "price")
                                {
                                    posPrice = i;
                                }
                                if (pos != -1 && posP != -1 && posPrice != -1)
                                {
                                    break;
                                }
                            }
                            for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                            {
                                int itemId = int.Parse(eLC.GetValue(l, e, 0));
                                if (!ElementsEditor.database.task_items.ContainsKey(itemId))
                                {
                                    ItemDupe item = new ItemDupe();
                                    item.itemId = itemId;
                                    item.listID = l;
                                    item.index = e;
                                    item.name = eLC.GetValue(l, e, pos);
                                    if (posP != -1)
                                    {
                                        item.iconpath = Path.GetFileName(eLC.GetValue(l, e, posP)).ToLower();
                                    }
                                    if (posPrice != -1)
                                    {
                                        item.price = eLC.GetValue(l, e, posPrice);
                                    }
                                    ElementsEditor.database.task_items.Add(itemId, item);
                                }

                            }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("ERROR LOADING ITEM LISTS\n" + e.Message);
                    }

                    if (TaskEditor.monster_npc_minelists.Contains(list))
                    {
                        for (int k = 0; k < TaskEditor.monster_npc_minelists.Count; k++)
                        {
                            progress_bar("Importing info...", k, TaskEditor.monster_npc_minelists.Count);
                            Application.DoEvents();

                            l = (int)TaskEditor.monster_npc_minelists[k];
                            pos = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                            {
                                if (eLC.Lists[l].elementFields[i] == "Name")
                                {
                                    pos = i;
                                    break;
                                }
                            }
                            for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                            {
                                if (!ElementsEditor.database.monsters_npcs_mines.ContainsKey(eLC.GetValue(l, e, 0)))
                                {
                                    ElementsEditor.database.monsters_npcs_mines.Add(eLC.GetValue(l, e, 0), eLC.GetValue(l, e, pos));
                                }
                            }
                        }
                    }

                    if (eLC.Version >= 87 && list == 169)
                    {
                        ElementsEditor.database.titles = new SortedList();
                        l = 169;
                        int pos1 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos1 = i;
                                break;
                            }
                        }
                        for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                        {
                            if (!ElementsEditor.database.titles.ContainsKey(eLC.GetValue(l, e, 0)))
                            {
                                ElementsEditor.database.titles.Add(eLC.GetValue(l, e, 0), eLC.GetValue(l, e, pos1));
                            }
                        }
                    }

                    if (eLC.Version >= 153 && list == 223)
                    {
                        ElementsEditor.database.homeitems = new SortedList();
                        l = 223;
                        int pos2 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos2 = i;
                                break;
                            }
                        }
                        for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                        {
                            if (!ElementsEditor.database.homeitems.ContainsKey(eLC.GetValue(l, e, 0)))
                            {
                                ElementsEditor.database.homeitems.Add(eLC.GetValue(l, e, 0), eLC.GetValue(l, e, pos2));
                            }
                        }
                    }
                    if (list == 69)
                    {
                        ElementsEditor.database.task_recipes = new SortedList<int, ItemDupe>();
                        l = 69;
                        pos = -1;
                        posP = -1;
                        posPrice = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Count; i++)
                        {
                            if (eLC.Lists[l].elementFields[i] == "Name")
                            {
                                pos = i;

                            }
                            if (eLC.Lists[l].elementFields[i] == "file_icon" || eLC.Lists[l].elementFields[i] == "file_icon1")
                            {
                                posP = i;
                            }
                            if (eLC.Lists[l].elementFields[i] == "price")
                            {
                                posPrice = i;
                            }
                            if (pos != -1 && posP != -1 && posPrice != -1)
                            {
                                break;
                            }
                        }
                        for (int e = 0; e < eLC.Lists[l].elementValues.Count; e++)
                        {
                            int itemId = int.Parse(eLC.GetValue(l, e, 0));
                            if (!ElementsEditor.database.task_recipes.ContainsKey(itemId))
                            {
                                ItemDupe item = new ItemDupe();
                                item.itemId = itemId;
                                item.listID = l;
                                item.index = e;
                                item.name = eLC.GetValue(l, e, pos);
                                if (posP != -1)
                                {
                                    item.iconpath = Path.GetFileName(eLC.GetValue(l, e, posP)).ToLower();
                                }
                                if (posPrice != -1)
                                {
                                    item.price = eLC.GetValue(l, e, posPrice);
                                }
                                ElementsEditor.database.task_recipes.Add(itemId, item);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Extensions.GetLocalization(478));
            }
            if (configs.nextAutoNewId == 0)
            {

                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                nextautoIdlabel.Text = configs.nextAutoNewId.ToString();
            }
            TaskEditor.eLC = eLC;
            progress_bar("Ready", 0, 0);
        }

        private void makeRecipesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select item/s!", 0, 0);
                return;
            }

            int currentList = comboBox_lists.SelectedIndex;
            int currentCell = listBox_items.CurrentCell.RowIndex;
            if (currentCell > -1)
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {

                        int itemIdIndex = -1;
                        int itemNameIndex = -1;
                        for (int ix = 0; ix < eLC.Lists[currentList].elementFields.Count; ix++)
                        {
                            if (eLC.Lists[currentList].elementFields[ix] == "ID")
                            {
                                itemIdIndex = ix;
                            }
                            if (eLC.Lists[currentList].elementFields[ix] == "Name")
                            {
                                itemNameIndex = ix;
                            }
                            if (itemIdIndex != -1 && itemNameIndex != -1)
                            {
                                break;
                            }
                        }
                        if (itemIdIndex == -1)
                        {
                            locked = false;
                            MessageBox.Show("Cant create recipes in this list!");
                            return;
                        }
                        if (itemNameIndex == -1)
                        {
                            locked = false;
                            MessageBox.Show("Cant create recipes in this list!");
                            return;
                        }
                        int recipes_listId = 69;
                        int targets_1_id_to_make = 0;
                        int targets_1_probability = 0;
                        int targets_Name = 0;
                        int num_to_make = 0;
                        int materials_1_id = 0;
                        int materials_1_num = 0;

                        Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                        for (int ie = 0; ie < eLC.Lists[recipes_listId].elementFields.Count; ie++)
                        {
                            Object data = (Object)eLC.getDefaultValue(eLC.Lists[recipes_listId].elementTypes[ie].ToString());
                            String dataName = eLC.Lists[recipes_listId].elementFields[ie];
                            if (dataName == "Name")
                            {
                                targets_Name = ie;
                            }
                            if (dataName == "targets_1_id_to_make")
                            {
                                targets_1_id_to_make = ie;
                            }
                            if (dataName == "targets_1_probability")
                            {
                                targets_1_probability = ie;
                            }
                            if (dataName == "num_to_make")
                            {
                                num_to_make = ie;
                            }
                            if (dataName == "id_major_type")
                            {
                                data = (int)2040;
                            }
                            if (dataName == "num_to_make")
                            {
                                data = (int)2;
                            }

                            if (dataName == "materials_1_id")
                            {
                                materials_1_id = ie;
                            }
                            if (dataName == "materials_1_num")
                            {
                                materials_1_num = ie;
                            }

                            itemValues.Add(ie, data);
                        }

                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Creating Recipes ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex != eLC.ConversationListIndex)
                            {
                                int itemId = int.Parse(eLC.GetValue(currentList, index, itemIdIndex));
                                String itemName = eLC.GetValue(currentList, index, itemNameIndex);
                                Dictionary<int, Object> itemValuesClone = new Dictionary<int, Object>(itemValues);
                                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                                itemValuesClone[0] = (int)configs.nextAutoNewId;
                                eLC.useFreeId(configs.nextAutoNewId, recipes_listId, currentCell);
                                Encoding enc = Encoding.GetEncoding("Unicode");
                                byte[] target = new byte[Convert.ToInt32(eLC.Lists[recipes_listId].GetType(targets_Name).Substring(8))];
                                byte[] source = enc.GetBytes(itemName);
                                if (target.Length > source.Length)
                                {
                                    Array.Copy(source, target, source.Length);
                                }
                                else
                                {
                                    Array.Copy(source, target, target.Length);
                                }
                                itemValuesClone[targets_Name] = target;
                                itemValuesClone[num_to_make] = (int)1;
                                itemValuesClone[materials_1_id] = (int)itemId;
                                itemValuesClone[materials_1_num] = (int)1;
                                eLC.AddItem(recipes_listId, itemValuesClone);

                            }
                            else
                            {
                                locked = false;
                                MessageBox.Show("Cant make recipes from conversation list.");
                                break;
                            }
                        }
                    }

                    locked = false;
                    this.refreshTaskRecipes();
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");

            }
        }

        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (customTooltype != null)
                    customTooltype.Close();
            }
            catch { }
            if (e.ColumnIndex >= 0 && e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                InfoTool ift = null;
                try
                {
                    if(this.dataGridView_item.Rows[e.RowIndex].Cells[2].Tag is ItemDupe)
                    {
                        ItemDupe item = (ItemDupe)this.dataGridView_item.Rows[e.RowIndex].Cells[2].Tag;
                        int Id = item.itemId;
                        if (Id > 0)
                        {
                            ift = Extensions.GetItemProps2(Id, 0, item.listID, item.index);
                        }
                        if (ift == null)
                        {
                            string text = Extensions.GetItemProps(Id, 0);
                            text += Extensions.ItemDesc(Id);
                            this.dataGridView_item.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                        }
                        else
                        {
                            ift.description = Extensions.ColorClean(Extensions.ItemDesc(Id));
                            customTooltype = new IToolType(ift);
                            customTooltype.Show();
                        }
                    }
                    if (this.dataGridView_item.Rows[e.RowIndex].Cells[2].Tag is SkillText)
                    {
                        SkillText st = (SkillText)this.dataGridView_item.Rows[e.RowIndex].Cells[2].Tag;
                        ift = new InfoTool();
                        ift.name = st.name;
                        ift.description = Extensions.SkillDesc(st.id);
                        customTooltype = new IToolType(ift);
                        customTooltype.Show();
                    }
                    

                }
                catch
                {
                }
            }
        }

        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (customTooltype != null)
            {
                customTooltype.Close();
            }
        }

        private void reforgeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select item/s!", 0, 0);
                return;
            }

            int currentList = comboBox_lists.SelectedIndex;
            int currentCell = listBox_items.CurrentCell.RowIndex;
            if (currentCell > -1)
            {
                try
                {
                    locked = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {

                        int itemIdIndex = -1;
                        int itemNameIndex = -1;
                        for (int ix = 0; ix < eLC.Lists[currentList].elementFields.Count; ix++)
                        {
                            if (eLC.Lists[currentList].elementFields[ix] == "ID")
                            {
                                itemIdIndex = ix;
                            }
                            if (eLC.Lists[currentList].elementFields[ix] == "Name")
                            {
                                itemNameIndex = ix;
                            }
                            if (itemIdIndex != -1 && itemNameIndex != -1)
                            {
                                break;
                            }
                        }
                        if (itemIdIndex == -1)
                        {
                            locked = false;
                            MessageBox.Show("Cant create recipes in this list!");
                            return;
                        }
                        if (itemNameIndex == -1)
                        {
                            locked = false;
                            MessageBox.Show("Cant create recipes in this list!");
                            return;
                        }
                        int recipes_listId = 69;
                        int targets_1_id_to_make = 0;
                        int targets_1_probability = 0;
                        int targets_Name = 0;
                        int num_to_make = 0;
                        int id_upgrade_equip = 0;
                        int upgrade_rate = 0;
                        Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                        for (int ie = 0; ie < eLC.Lists[recipes_listId].elementFields.Count; ie++)
                        {
                            Object data = (Object)eLC.getDefaultValue(eLC.Lists[recipes_listId].elementTypes[ie].ToString());
                            String dataName = eLC.Lists[recipes_listId].elementFields[ie];
                            if (dataName == "Name")
                            {
                                targets_Name = ie;
                            }
                            if (dataName == "targets_1_id_to_make")
                            {
                                targets_1_id_to_make = ie;
                            }
                            if (dataName == "targets_1_probability")
                            {
                                targets_1_probability = ie;
                            }
                            if (dataName == "num_to_make")
                            {
                                num_to_make = ie;
                            }
                            if (dataName == "id_major_type")
                            {
                                data = (int)2040;
                            }
                            if (dataName == "num_to_make")
                            {
                                data = (int)2;
                            }

                            if (dataName == "id_upgrade_equip")
                            {
                                id_upgrade_equip = ie;
                            }
                            if (dataName == "upgrade_rate")
                            {
                                upgrade_rate = ie;
                            }

                            itemValues.Add(ie, data);
                        }

                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Creating Recipes ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            if (comboBox_lists.SelectedIndex != eLC.ConversationListIndex)
                            {
                                int itemId = int.Parse(eLC.GetValue(currentList, index, itemIdIndex));
                                String itemName = eLC.GetValue(currentList, index, itemNameIndex);
                                Dictionary<int, Object> itemValuesClone = new Dictionary<int, Object>(itemValues);
                                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel, nextautoIdlabelmax);
                                itemValuesClone[0] = (int)configs.nextAutoNewId;
                                eLC.useFreeId(configs.nextAutoNewId, recipes_listId, currentCell);
                                Encoding enc = Encoding.GetEncoding("Unicode");
                                byte[] target = new byte[Convert.ToInt32(eLC.Lists[recipes_listId].GetType(targets_Name).Substring(8))];
                                byte[] source = enc.GetBytes(itemName);
                                if (target.Length > source.Length)
                                {
                                    Array.Copy(source, target, source.Length);
                                }
                                else
                                {
                                    Array.Copy(source, target, target.Length);
                                }
                                itemValuesClone[targets_Name] = target;
                                itemValuesClone[num_to_make] = (int)1;
                                itemValuesClone[targets_1_id_to_make] = (int)itemId;
                                itemValuesClone[targets_1_probability] = (float)1;
                                itemValuesClone[id_upgrade_equip] = (int)itemId;
                                itemValuesClone[upgrade_rate] = (float)1;
                                eLC.AddItem(recipes_listId, itemValuesClone);

                            }
                            else
                            {
                                locked = false;
                                MessageBox.Show("Cant make recipes from conversation list.");
                                break;
                            }
                        }
                    }

                    locked = false;
                    this.refreshTaskRecipes();
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                MessageBox.Show("Please select a item!");

            }
        }

        private void invertRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(eLC != null)
            {
                if (dataGridView_item.CurrentCell != null)
                { 
                    int rowCount = dataGridView_item.SelectedRows.Count;
                    if (rowCount == 2)
                    {
                        int row1ID = -1;
                        int row2ID = -1;
                        string row1Val = "";
                        string row2Val = "";
                        for (int i = 0; i < dataGridView_item.SelectedRows.Count; i++)
                        {
                            int index = dataGridView_item.SelectedRows[i].Index;
                            if (row2ID == -1 && row1ID != -1)
                            {
                                row2ID = index;
                                row2Val = dataGridView_item.Rows[index].Cells[3].Value.ToString();
                            }


                            if (row1ID == -1)
                            {
                                row1ID = index;
                                row1Val = dataGridView_item.Rows[index].Cells[3].Value.ToString();
                            }

                        }
                        if (row1ID != -1 && row2ID != -1)
                        {
                            dataGridView_item.Rows[row1ID].Cells[3].Value = row2Val;
                            dataGridView_item.Rows[row2ID].Cells[3].Value = row1Val;
                        }

                    }
                    else
                    {
                        MessageBox.Show("You can invert 2 rows value first value becomes second value and so on.");
                    }
                }
            }
        }

        private Dictionary<int, string> copyValues = null;
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                if (dataGridView_item.CurrentCell != null)
                {
                    copyValues = new Dictionary<int, string>();
                    for (int i = 0; i < dataGridView_item.SelectedRows.Count; i++)
                    {
                        int index = dataGridView_item.SelectedRows[i].Index;
                        copyValues[index] = dataGridView_item.Rows[index].Cells[3].Value.ToString();
                    }
                }
            }
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                if (dataGridView_item.CurrentCell != null)
                {
                    if (copyValues != null)
                    {
                        foreach (KeyValuePair<int, string> row in copyValues)
                        {
                            dataGridView_item.Rows[row.Key].Cells[3].Value = row.Value;
                        }
                        copyValues = null;
                    }else
                    {
                        MessageBox.Show("Nothing copied!");
                    }
                }
            }
        }

        private void copySelectedItemsToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                locked = true;
                List<string> values = new List<string>();
                Export export = new Export();
                export.ListId = -1;
                export.type = 0; //Elements data = 0 | Gshop = 1 
                export.ForVersion = eLC.Version;
                export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));


                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int index = dataGridView1.SelectedRows[i].Index;
                    int listToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    int itemToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());
                    Export exportx = new Export();
                    exportx.ListId = listToCopyFrom;
                    exportx.type = 0; //Elements data = 0 | Gshop = 1 
                    exportx.ForVersion = eLC.Version;
                    exportx.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));

                    if (exportx.ListId == eLC.ConversationListIndex)
                    {
                        exportx.data.Add(i, conversationList.Dialogs[itemToCopyFrom]);
                    }
                    else
                    {
                        exportx.data.Add(i, eLC.Lists[listToCopyFrom].elementValues[itemToCopyFrom]);
                    }
                    export.data.Add(i, exportx);
                }

                CopyToClipboard(export);
                locked = true;
            }
        }

        private void exportSkillsToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog eSave = new SaveFileDialog();
            eSave.RestoreDirectory = false;
            eSave.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            if (eSave.ShowDialog() == System.Windows.Forms.DialogResult.OK && eSave.FileName != "")
            {
                try
                {
                    if (eLC != null)
                    {
                        string data = "";
                        foreach (KeyValuePair<int, SkillText> skil in eLC.skillNames)
                        {
                            data += skil.Key + ";" + skil.Value.name + "\n";
                        }
                        File.WriteAllText(eSave.FileName, data);
                    }
                }
                catch { }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
        private bool lockx = false;
        private void readListDEBUGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lockx)
            {
                EncryptedListRip cfe = new EncryptedListRip();
                cfe.FormClosed += new FormClosedEventHandler(EncryptedListRip_FormClosed);
                cfe.Show();
                lockx = true;
            }
        }

        private void EncryptedListRip_FormClosed(object sender, FormClosedEventArgs e)
        {
            lockx = false;
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkillSelect ss = new SkillSelect(FormStartPosition.CenterScreen);
            ss.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkillSelector ss = new SkillSelector();
            ss.ShowDialog(this);
        }
    }
}
