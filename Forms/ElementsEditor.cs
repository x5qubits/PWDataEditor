using ElementEditor.classes;
using ElementEditor.classes.helper;
using ElementEditor.Element_Editor_Classes;
using ElementEditor.helper_classes;
using Gpckx;
using JHUI;
using JHUI.Animation;
using JHUI.Controls;
using JHUI.Forms;
using JHUI.Utils;
using Newtonsoft.Json;
using PerfectWorldAccountManager;
using PWDataEditorPaied;
using PWDataEditorPaied.AngelicaFileManager;
using PWDataEditorPaied.Database;
using PWDataEditorPaied.Database.Utils;
using PWDataEditorPaied.Element_Editor_Classes;
using PWDataEditorPaied.Forms;
using PWDataEditorPaied.Forms.SubForms;
using PWDataEditorPaied.helper_classes;
using PWDataEditorPaied.Properties;
using PWDataEditorPaied.Utils;
using PWnpcEditor;
using SkillXMLEditor;
using sTASKedit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tests;
using Ultimate_Editor.Clases.AngelicaFileManager;

namespace ElementEditor
{

    public partial class ElementsEditor : JForm
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        public int defWidth = 932;
        public int defHeight = 709;
        public static int rows = 0;
        public static int cols = 0;
        private bool locked = false;
        public static eListCollection eLC;
        private eListConversation conversationList;
        public static int selectedMask = 0;
        public static string selectedImage = null;
        public static Configs configs = new Configs();
        public static ElementsEditor Instance = null;
        public static bool AnythingChanged = false;
        public static Session database
        {

            get
            {
                Session database = DatabaseManager.Instance.getDatabase(configs.lastElementsLocation);
                if (database.hasJustBecomeReady)
                {
                    if (ElementsEditor.Instance != null)
                    {
                        database.hasJustBecomeReady = false;
                        ElementsEditor.Instance.Loadelements();
                    }

                }
                return database;
            }

        }

        static public int SelectedList { get; set; } = 0;
        static public int SelectedRow { get; set; } = 0;
        public int LastTabId { get; private set; }

        private int lastList = 0;
        private int lastItem = 0;

        public bool lock3 = true;
        private IToolType customTooltype;
        public ElementsEditor()
        {
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            label1.Visible = version_label.Visible = jLabel2.Visible = pathLabel.Visible = jLabel1.Visible = jPictureBox2.Visible = nextautoIdlabel.Visible = false;
            this.Opacity = 0;
            sale = elementIntoTab.TabPages[1];
            craft = elementIntoTab.TabPages[2];
            recalculateDropsToolStripMenuItem.Visible = false;
            recalculateRandsToolStripMenuItem.Visible = false;
            recalculateAdonsToolStripMenuItem.Visible = false;
            dropSelectedAddonFasterToolStripMenuItem.Visible = false;
            toolStripSeparator13.Visible = false;

            Task.Run(() =>
            {
                while (!IsHandleCreated)
                {

                }
                this.Invoke(new MethodInvoker(delegate
                {
                    elementIntoTab.TabPages.Remove(sale);
                    elementIntoTab.TabPages.Remove(craft);
                    comboBox3.SelectedIndex = 0;
                    Instance = this;
                    pathLabel.Visible = false;
                    new JBehavor().InvokeRepeating(CheckErrors, 5);
                    CheckErrors();

                }));
            });
            new JAnimate().FadeInForm(this, 10);

        }

        private void CheckErrors()
        {
            return;

            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        CheckErrors();
                    }));
                }
                catch { }
                return;
            }

            if (eLC != null && eLC.ready)
            {
                if (eLC.errorList != null && eLC.errorList.Count > 0)
                {
                    if (this.InvokeRequired)
                        this.Invoke(new MethodInvoker(delegate
                        {
                            try
                            {
                                jPictureBox3.Visible = true;
                                new JAnimate().Start(jPictureBox3, 10, Effect.Wobble, () => { jPictureBox3.Visible = true; });
                            }
                            catch { }
                        }));
                    else
                    {
                        try
                        {
                            jPictureBox3.Visible = true;
                            new JAnimate().Start(jPictureBox3, 10, Effect.Wobble, () => { jPictureBox3.Visible = true; });
                        }
                        catch { }
                    }
                }
                else
                {
                    if (this.InvokeRequired)
                        this.Invoke(new MethodInvoker(delegate
                        {

                            try
                            {
                                jPictureBox3.Visible = false;
                            }
                            catch { }
                        }));
                    else
                        jPictureBox3.Visible = false;
                }
            }
            else
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            jPictureBox3.Visible = false;
                        }
                        catch { }
                    }));
                else
                    jPictureBox3.Visible = false;
            }
        }

        private TabPage sale = null;
        private TabPage craft = null;

        public void progress_bar(String value, int min, int max)
        {
            if (progress_bar2 != null)
            {
                progress_bar2(value, min, max);
            }
        }

        public void Loadelements()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    Loadelements();
                }));
                return;
            }


            progress_bar("Loading ...", 0, 0);

            if (eLC.Lists.Length > 0)
            {
                int l = -1;
                int pos = -1;
                int posP = -1;
                int posPrice = -1;
                try
                {

                    ElementsEditor.database.task_items = new SortedList<int, ItemDupe>();
                    for (int k = 0; k < ElementsEditor.database.task_items_list.Length; k += 2)
                    {
                        if (eLC.Version >= Convert.ToInt32(ElementsEditor.database.task_items_list[k + 1]))
                        {
                            l = Convert.ToInt32(ElementsEditor.database.task_items_list[k]);
                            pos = -1;
                            posP = -1;
                            posPrice = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                                        catch
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
                    JMessageBox.Show(this, "ERROR LOADING ITEM LISTS\n" + xe.Message);
                }
                ElementsEditor.database.monsters_npcs_mines = new SortedList();
                for (int k = 0; k < TaskEditor.monster_npc_minelists.Count; k++)
                {
                    progress_bar("Importing info...", k, TaskEditor.monster_npc_minelists.Count);
                    // Application.DoEvents();

                    l = (int)TaskEditor.monster_npc_minelists[k];
                    pos = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                    l = eLC.TitleListIndex;
                    int pos1 = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                    l = eLC.HomeItemsListIndex;
                    int pos2 = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                l = eLC.RecipeListIndex;
                pos = -1;
                posP = -1;
                posPrice = -1;
                for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                        JMessageBox.Show(this, Extensions.GetLocalization(465));
                        goto IL_701;
                    }
                    IL_701:;
                }

            }

            if (configs.nextAutoNewId == 0)
            {

                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                nextautoIdlabel.Text = configs.nextAutoNewId.ToString();
            }

            //this.exportToolStripMenuItem.DropDownItems.Add(new ToolStripLabel("Select a valid Conversation Rules Set"));
            //this.exportToolStripMenuItem.DropDownItems[0].Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.exportToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Configs\\Element\\rules", "PW_v" + eLC.Version.ToString() + "*.rules");
            string pa = Application.StartupPath + "\\Configs\\Element\\rules\\";
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace("=", "=>");
                files[i] = files[i].Replace(".rules", "");
                files[i] = files[i].Replace(pa, "");
                this.exportToolStripMenuItem.DropDownItems.Add(files[i], Resources.Send_message, new System.EventHandler(this.exportToolStripMenuItem_Click_1));
            }


            LoadImportConfig();
            label1.Visible = version_label.Visible = jLabel2.Visible = pathLabel.Visible = jLabel1.Visible = nextautoIdlabel.Visible = jPictureBox2.Visible = true;
            new JAnimate().Start(jPictureBox2, 10, Effect.FadeIn, () => { jPictureBox2.Enabled = true; });
            eLC.ready = true;
            CheckErrors();
            progress_bar("Ready", 0, 0);
        }

        public void LoadImportConfig()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    LoadImportConfig();
                }));
                return;
            }
            //LOAD RULES
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Import_Configs\\";
            string[] filePaths = Directory.GetFiles(path, "*.ini", SearchOption.TopDirectoryOnly);
            configs.currentConvertSettings = new Dictionary<int, ConvertElements>();
            int count = 0;
            foreach (string file in filePaths)
            {
                string[] title = Path.GetFileNameWithoutExtension(file).Split('-');
                if (title.Length == 2)
                {
                    int MajorVersion = -1;
                    int MinorVersion = -1;
                    bool tryParse1 = int.TryParse(title[0], out MajorVersion);
                    bool tryParse2 = int.TryParse(title[1], out MinorVersion);
                    if (tryParse1 && tryParse2)
                    {
                        ConvertElements RuleConfigImport = new ConvertElements();
                        RuleConfigImport.versionFrom = MajorVersion; // IF EXPORT COMES FROM VERSION
                        RuleConfigImport.versionTo = MinorVersion; // IF CURRENT ELEMENTS IS VERSION
                        RuleConfigImport.lists = new Dictionary<int, Dictionary<int, RowIndexesExport>>();
                        using (StreamReader sr = new StreamReader(file))
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
                                                if (!RuleConfigImport.lists.ContainsKey(LIST))
                                                {
                                                    RuleConfigImport.lists.Add(LIST, new Dictionary<int, RowIndexesExport>());
                                                }
                                                int ROWID = int.Parse(rule[1]);
                                                REPLACEOPERATION OPERATION = (REPLACEOPERATION)int.Parse(rule[2]);
                                                string VALUE = rule[3];
                                                RowIndexesExport data = new RowIndexesExport();
                                                data.LIST = LIST;
                                                data.ROWID = ROWID;
                                                data.OPERATION = OPERATION;
                                                data.VALUE = VALUE;
                                                RuleConfigImport.lists[LIST].Add(ROWID, data);
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
                        //IF EXPORT COMES FROM MAJOR VERSION WE KNOW HOW TO FIX IT
                        configs.currentConvertSettings[count] = RuleConfigImport;
                    }
                }
                count++;
            }
        }

        public void SetStyle(JColorStyle style, JThemeStyle thme, int alpha)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SetStyle(style, thme, alpha);
                }));
                return;
            }
            this.components.SetStyle(this, style, thme, alpha);
        }

        public void setIndex(ErrorClass item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    setIndex(item);
                }));
                return;
            }
            try
            {
                comboBox_lists.SelectedIndex = item.listId;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                listBox_items.Rows[item.itemId].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[item.itemId].Cells[0];
                listBox_items_CellClick(null, null);
                listBox_items.PerformLayout();
            }
            catch { }
        }
        public void setIndex(ItemDupe item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    setIndex(item);
                }));
                return;
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
                this.Invoke(new MethodInvoker(delegate
                {
                    setIndex(item);
                }));
                return;
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
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog eLoad = new OpenFileDialog();
            eLoad.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            eLoad.RestoreDirectory = false;
            if (eLoad.ShowDialog() == DialogResult.OK && File.Exists(eLoad.FileName))
            {
                // mouseDown_time = Time.time;
                locked = true;
                lock3 = true;
                AnythingChanged = false;
                try
                {
                    block(true);
                    if (eLC != null)
                        eLC.CancelAllTasks();

                    eLC = new eListCollection
                    {
                        ready = false
                    };
                    eLC.progress_bar += progress_bar;
                    configs.lastElementsLocation = eLoad.FileName;
                    eLC.Lists = eLC.Load(eLoad.FileName);
                    DatabaseManager.Instance._NAME = eLoad.FileName.ToLower();
                    nextautoIdlabel.Text = eLC.getNextFreeId(DatabaseManager.Instance.nextId, nextautoIdlabel) + "";
                    pathLabel.Text = eLoad.FileName;

                    if (DatabaseManager.Instance.AutoLoadPck)
                        DatabaseManager.Instance.CreateNewDatabase(eLoad.FileName, eLC.Version);
                    else
                        DatabaseManager.Instance.SetVersion(eLC.Version);


                    if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                    {
                        conversationList = new eListConversation((byte[])eLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
                    }

                    dataGridView_item.Rows.Clear();
                    listBox_items.Rows.Clear();
                    comboBox_lists.Items.Clear();

                    for (int l = 0; l < eLC.Lists.Length; l++)
                    {
                        comboBox_lists.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase("[" + l + "] " + eLC.Lists[l].listName.ToLower().Replace('_', ' ')));

                    }
                    goToToolStripMenuItem.DropDown.Items.Clear();
                    HashSet<BookMark> books = DatabaseManager.Instance.BookMars;
                    foreach (BookMark book in books)
                    {
                        ToolStripItem tsi = new ToolStripMenuItem();
                        tsi.Text = book.name;
                        tsi.Image = Resources.View;
                        tsi.Tag = book;
                        tsi.MouseDown += JumpToItem;
                        goToToolStripMenuItem.DropDown.Items.Add(tsi);
                    }
                    //goToToolStripMenuItem.DropDown.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(eLC.Lists[l].listName.ToLower().Replace('_', ' ')), Resources.View);
                    //comboBox_lists.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                    //comboBox_lists.AutoCompleteCustomSource.AddRange(autoCompleate.ToArray());
                    // Application.DoEvents();
                    //path_label.Text = eLoad.FileName;
                    version_label.Text = eLC.Version.ToString();

                    // Application.DoEvents();
                    block(false);
                    locked = false;
                    lock3 = false;
                    comboBox_lists.SelectedIndex = 0;
                    if (eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Count == 0) { return; }
                    comboBox_lists.SelectedIndex = 0;
                    listBox_items.Rows[0].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                    listBox_items_CellClick(null, null);
                    Loadelements();
                    pathLabel.Visible = true;
                    //  mouseDown_time = Time.time;
                }
                catch (Exception ex)
                {
                    JMessageBox.Show(this, "LOADING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch" + ex.ToString());
                    pathLabel.Visible = false;
                    eLC.ready = false;
                }
                block(false);
                locked = false;
                lock3 = false;
                //  mouseDown_time = Time.time;
            }
        }

        private void JumpToItem(object sender, MouseEventArgs e)
        {
            BookMark book = sender == null ? null : (BookMark)((ToolStripMenuItem)sender).Tag;
            if (book != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        setIndex(book);
                        break;
                    case MouseButtons.Right:
                        DatabaseManager.Instance.DelBook(book);
                        goToToolStripMenuItem.DropDown.Items.Remove((ToolStripMenuItem)sender);
                        break;

                }
            }
        }

        private int proctypeLocation = 0;
        private int proctypeLocationvak = 0;
        private void listBox_items_CellClick(object sender, EventArgs e)
        {
            if (locked) { return; }
            if (lock3) { return; }
            showInfo = false;
            lastBtnPressPreview = null;
            int list = comboBox_lists.SelectedIndex;
            if (listBox_items.CurrentCell == null) { return; }
            int element = listBox_items.CurrentCell.RowIndex;
            int scroll = dataGridView_item.FirstDisplayedScrollingRowIndex;
            int saveInfoTabindex = tabControl2.SelectedIndex;
            //dataGridView_item.Visible = false;

            block2(true);
            dataGridView_item.Rows.Clear();
            proctypeLocation = 0;
            proctypeLocationvak = 0;

            if (list == eLC.PetEggs)
            {
                CopyPetToolStripMenuItem.Visible = true;
                PastePetToolStripMenuItem1.Visible = true;
            }
            else
            {
                CopyPetToolStripMenuItem.Visible = false;
                PastePetToolStripMenuItem1.Visible = false;
            }

            if (list != eLC.ConversationListIndex)
            {
                // lastInfo = null;
                tabControl2.SelectedIndex = 0;
                //comboBox_lists.Enabled = false;
                if (element > -1 && element < eLC.Lists[list].elementValues.Count)
                {
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
                                if (ElementsEditor.database.ContainsKey(path))
                                {
                                    img = new Bitmap(ElementsEditor.database.images(path), 22, 22);
                                }
                                else
                                {
                                    img = Resources.blank;
                                }
                                cell.Value = img;
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
                                if (list != eLC.CraftServiceListIndex)
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

                                        if (id > 0 && database.task_items.ContainsKey(id))
                                        {
                                            ItemDupe ItemDupe = database.task_items[id];
                                            cell1.Value = ItemDupe.name;
                                            cell1.ToolTipText = "";
                                            row.Cells[2] = cell1;
                                            row.Cells[2].Tag = ItemDupe;
                                        }
                                    }
                                }
                                else
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
                        //award 1 id
                        if (eLC.Lists[list].elementFields[f].Contains("award") && eLC.Lists[list].elementFields[f].Contains("id") || eLC.Lists[list].elementFields[f].Contains("materials") && eLC.Lists[list].elementFields[f].Contains("id"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && database.task_items.ContainsKey(id))
                                {
                                    ItemDupe ItemDupe = database.task_items[id];
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
                                if (id > 0 && database.task_items.ContainsKey(id))
                                {
                                    ItemDupe ItemDupe = database.task_items[id];
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
                        if (eLC.Lists[list].elementFields[f].Equals("id_pet"))
                        {
                            try
                            {
                                DataGridViewButtonCell cell1 = new DataGridViewButtonCell();
                                int id = Int32.Parse(eLC.GetValue(list, element, f));
                                if (id > 0 && eLC.PETS.ContainsKey(id))
                                {
                                    cell1.Value = eLC.PETS[id].name;
                                    cell1.ToolTipText = "";
                                    row.Cells[2] = cell1;
                                    row.Cells[2].Tag = eLC.PETS[id];
                                }
                            }
                            catch { }
                        }

                        row.Cells[3].Value = eLC.GetValue(list, element, f);
                        dataGridView_item.Rows.Add(row);
                    }
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
            }
            block2(false);
            //dataGridView_item.Visible = true;
            if (scroll > -1)
            {
                try { dataGridView_item.FirstDisplayedScrollingRowIndex = scroll; } catch (Exception) { }
            }
            tabControl2.SelectedIndex = saveInfoTabindex;
            progress_bar("Ready", 0, 0);
            if (list == eLC.SaleServiceListIndex && elementIntoTab.SelectedIndex > 1)
            {
                elementIntoTab_SelectedIndexChanged(null, null);

            }
            if (list == eLC.CraftServiceListIndex && elementIntoTab.SelectedIndex > 1)
            {
                elementIntoTab_SelectedIndexChanged(null, null);

            }
            this.ActiveControl = listBox_items;
        }

        public BookMark getBookmark()
        {
            if (eLC == null)
            {
                JMessageBox.Show(this, "Element file not loaded!");
                return null;
            }
            if (comboBox_lists.SelectedIndex < 0)
            {
                JMessageBox.Show(this, "Element file not loaded!");
                return null;
            }
            if (dataGridView_item.CurrentCell == null)
            {
                JMessageBox.Show(this, "No rows are selected!");
                return null;
            }
            if (listBox_items.CurrentCell == null)
            {
                JMessageBox.Show(this, "No item is slected!");
                return null;
            }
            BookMark book = new BookMark();
            book.editorID = Constatns.elementEditorId;
            book.listIndex = comboBox_lists.SelectedIndex;
            book.elementIndex = listBox_items.CurrentCell.RowIndex;
            book.rowIndex = dataGridView_item.CurrentCell.RowIndex;
            book.name = comboBox_lists.Items[book.listIndex].ToString() + "[" + eLC.GetValue(book.listIndex, book.elementIndex, 0) + "]";
            return book;
        }

        private void block(bool isBlock)
        {
            bool isBlocked = !isBlock;

            if (isBlocked)
            {
                //SUSPEND ETC
                DrawingControl.ResumeDrawing(comboBox_lists);
                DrawingControl.ResumeDrawing(listBox_items);
                DrawingControl.ResumeDrawing(dataGridView_item);
                DrawingControl.ResumeDrawing(tabControl2);
                DrawingControl.ResumeDrawing(selecter_rowscheckbox);


                comboBox_lists.PerformLayout();
                tabControl2.PerformLayout();
                //comboBox_lists.Update();
                //tabControl2.Update();


                listBox_items.Enabled = true;
                listBox_items.PerformLayout();
                listBox_items.ResumeLayout();

                dataGridView_item.Enabled = true;
                dataGridView_item.PerformLayout();
                dataGridView_item.ResumeLayout();
            }
            else
            {

                listBox_items.SuspendLayout();
                listBox_items.Enabled = false;
                dataGridView_item.SuspendLayout();
                dataGridView_item.Enabled = false;
                tabControl2.SuspendLayout();
                comboBox_lists.SuspendLayout();
                DrawingControl.SuspendDrawing(comboBox_lists);
                DrawingControl.SuspendDrawing(listBox_items);
                DrawingControl.SuspendDrawing(dataGridView_item);
                DrawingControl.SuspendDrawing(tabControl2);
                DrawingControl.SuspendDrawing(selecter_rowscheckbox);

            }

        }

        private void block2(bool isBlock)
        {
            bool isBlocked = !isBlock;

            if (isBlocked)
            {
                //SUSPEND ETC

                DrawingControl.ResumeDrawing(dataGridView_item);
                dataGridView_item.Enabled = true;
                dataGridView_item.PerformLayout();
                dataGridView_item.ResumeLayout();
            }
            else
            {
                dataGridView_item.SuspendLayout();
                dataGridView_item.Enabled = false;
                DrawingControl.SuspendDrawing(dataGridView_item);
            }

        }
        private void Change_list(object sender, EventArgs ex)
        {
            if(AnythingChanged)
                ElementsEditor.Instance.Loadelements();

            GC.Collect();
            showInfo = false;
            selectedCraftItem = null;
            int tabIndex = tabControl2.SelectedIndex;
            try
            {

                if (comboBox_lists.SelectedIndex > -1)
                {
                    lock3 = true;
                    locked = true;
                    tabControl2.SelectedIndex = 0;
                    SelectedList = comboBox_lists.SelectedIndex;
                    lastList = 0;
                    lastItem = 0;
                    int l = comboBox_lists.SelectedIndex;
                    block(true);
                    listBox_items.Rows.Clear();
                    dataGridView_item.Rows.Clear();
                    selecter_rowscheckbox.Items.Clear();
                    jComboBox1.Items.Clear();
                    elementIntoTab.SelectedIndex = 0;
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
                    recalculateDropsToolStripMenuItem.Visible = false;
                    recalculateRandsToolStripMenuItem.Visible = false;
                    recalculateAdonsToolStripMenuItem.Visible = false;
                    dropSelectedAddonFasterToolStripMenuItem.Visible = false;
                    toolStripSeparator13.Visible = false;

                    if (l == 3 || l == 6 || l == 9)
                    {
                        recalculateRandsToolStripMenuItem.Visible = true;
                        recalculateAdonsToolStripMenuItem.Visible = true;
                        dropSelectedAddonFasterToolStripMenuItem.Visible = true;
                        toolStripSeparator13.Visible = true;
                    }
                    if (l == 38 || l == 79)
                    {
                        recalculateDropsToolStripMenuItem.Visible = true;
                        toolStripSeparator13.Visible = true;
                        dropSelectedAddonFasterToolStripMenuItem.Visible = true;
                    }
                    if (eLC.CanShopProbabilityMenu(l))
                    {
                        recalculateDropsToolStripMenuItem.Visible = true;
                        toolStripSeparator13.Visible = true;
                        dropSelectedAddonFasterToolStripMenuItem.Visible = true;
                    }
                    if (eLC.Version == 156)
                    {
                        if (l == 94)
                        {
                            makePetEggToolStripMenuItem.Visible = true;
                            toolStripSeparator14.Visible = true;
                        }
                        else
                        {
                            makePetEggToolStripMenuItem.Visible = false;
                            toolStripSeparator14.Visible = false;
                        }
                    }
                    else
                    {
                        makePetEggToolStripMenuItem.Visible = false;
                        toolStripSeparator14.Visible = false;
                    }
                    if (l == eLC.SaleServiceListIndex)
                    {
                        elementIntoTab.TabPages.Add(sale);
                        if (elementIntoTab.TabPages.Contains(craft))
                        {
                            elementIntoTab.TabPages.Remove(craft);
                        }
                    }
                    else if (l == eLC.CraftServiceListIndex)
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
                    if (eLC.Lists[l].elementValues.Count == 0)
                    {
                        progress_bar("Ready", 0, 0);
                        lock3 = false;
                        locked = false;
                        block(false);
                        return;
                    }
                    if (l != eLC.ConversationListIndex)
                    {
                        jComboBox1.Items.Add("Dont Search Val2");
                        for (int opt = 0; opt < eLC.Lists[l].elementFields.Length; opt++)
                        {
                            selecter_rowscheckbox.Items.Add(eLC.Lists[l].elementFields[opt]);
                            jComboBox1.Items.Add(eLC.Lists[l].elementFields[opt]);
                        }
                        try
                        {
                            selecter_rowscheckbox.SelectedIndex = 0;
                            jComboBox1.SelectedIndex = 0;
                        }
                        catch { }

                        listBox_items.RowCount = eLC.Lists[l].elementValues.Count;
                    }
                    else
                    {
                        listBox_items.RowCount = conversationList.Dialogs.Count;
                    }
                }
                lock3 = false;
                locked = false;
                block(false);
                try
                {
                    listBox_items.Rows[0].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                    listBox_items_CellClick(null, null);
                }
                catch { }
            }
            catch (Exception e)
            {
                JMessageBox.Show(this, e.ToString());
            }
            try
            {
                jGroupBox1.Text = "Items: " + eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Count + ", Rows: " + eLC.Lists[comboBox_lists.SelectedIndex].elementFields.Length + "";
            }
            catch
            {
                jGroupBox1.Text = "";
            }

            tabControl2.SelectedIndex = tabIndex;
            lock3 = false;
            locked = false;
            block(false);
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
                    JMessageBox.Show(this, "SAVING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
                }
            }
        }

        private void Change_value(object sender, DataGridViewCellEventArgs ea)
        {
            if (lock3) { return; }
            try
            {
                if (eLC != null && ea.ColumnIndex == 3)
                {
                    int pos = -1;
                    DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                    for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                    {
                        lock3 = true;
                        int l = comboBox_lists.SelectedIndex;
                        int e = selected[x].Index;
                        if (l != eLC.ConversationListIndex)
                        {
                            eLC.SetValue(l, e, ea.RowIndex, Convert.ToString(dataGridView_item.Rows[ea.RowIndex].Cells[3].Value));

                            int pos2 = -1;

                            for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                            listBox_items.SuspendLayout();
                            listBox_items.Rows[e].Cells[0].Value = eLC.GetValue(l, e, 0);//ID
                            listBox_items.Rows[e].Cells[1].Value = img;//ICON
                            listBox_items.Rows[e].Cells[2].Value = name;//NAME
                            listBox_items.ResumeLayout();
                            listBox_items.PerformLayout();
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
                    if (ea.RowIndex == 0 || ea.RowIndex == pos)
                        this.RefreshTaskRecipes();
                }
            }
            catch (Exception)
            {
                JMessageBox.Show(this, "CHANGING ERROR!\nFailed changing value, this value seems to be invalid.");
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
                    SortedList<int, object> itemValues = new SortedList<int, object>();
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
                    {
                        object data = (object)eLC.GetDefaultValue(eLC.Lists[l].elementTypes[i].ToString());
                        itemValues.Add(i, data);
                    }
                    eLC.AddItem(l, itemValues);
                    int pos = -1;
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
                    {
                        if (eLC.Lists[l].elementFields[i] == "Name")
                        {
                            pos = i;
                            break;
                        }
                    }
                    listBox_items.RowCount++;
                    // listBox_items.Rows.Add(new object[] { eLC.GetValue(l, eLC.Lists[l].elementValues.Count - 1, 0), new Bitmap(new Bitmap(Resources.blank)), eLC.GetValue(l, eLC.Lists[l].elementValues.Count - 1, pos) });
                    listBox_items.Rows[eLC.Lists[l].elementValues.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[l].elementValues.Count - 1].Cells[0];
                }
                else
                {
                    JMessageBox.Show(this, "Please select a item!");
                }

            }
            else
            {
                try
                {

                    eDialog data = conversationList.Dialogs[conversationList.Dialogs.Count - 1];
                    conversationList.DialogCount++;
                    conversationList.Dialogs[conversationList.DialogCount - 1] = data;
                    listBox_items.RowCount++;
                    // listBox_items.Rows.Add(new object[] { conversationList.Dialogs[conversationList.DialogCount - 1].DialogID, new Bitmap(new Bitmap(Resources.blank)), conversationList.Dialogs[conversationList.DialogCount - 1].DialogID + " - Dialog" });
                    listBox_items.Rows[listBox_items.Rows.Count - 1].ReadOnly = true;
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }
                catch (Exception)
                {

                }
            }

            this.RefreshTaskRecipes();
            listBox_items_CellClick(null, null);
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
                    progress_bar("Deleting ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    if (l != eLC.ConversationListIndex)
                    {
                        eLC.Lists[l].RemoveItem(l, idx);
                    }
                    else
                    {
                        conversationList.Dialogs.Remove(idx);
                        conversationList.DialogCount--;
                    }
                }
                for (int i = selected.Count - 1; i >= 0; i--)
                {
                    listBox_items.Rows.Remove(selected[i]);
                }

                eLC.Lists[l].elementValues = resortDic(eLC.Lists[l].elementValues);
                this.RefreshTaskRecipes();
                progress_bar("Ready", 0, 0);
                locked = false;
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");
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
                        export.RowCount = eLC.Lists[l].elementFields.Length;
                        export.type = 0; //Elements data = 0 | Gshop = 1 
                        export.Version = eLC.Version;
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
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

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
                // Application.DoEvents();
                using (Stream file = File.Open(pathx, FileMode.Open))
                {

                    BinaryFormatter bf = new BinaryFormatter();
                    Export obj = (Export)bf.Deserialize(file);
                    if (obj.Version != eLC.Version)
                    {
                        locked = false;
                        comboBox_lists.Enabled = true;
                        listBox_items.Enabled = true;
                        file.Close();
                        if (!(JMessageBox.Show(this, "You are about to import " + obj.Version + " on " + eLC.Version + "! Do you want to continue?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                        {
                            return;
                        }
                    }
                    comboBox_lists.SelectedIndex = obj.ListId;
                    ltc = obj.ListId;
                    // Application.DoEvents();
                    comboBox_lists.Enabled = false;
                    listBox_items.Enabled = false;
                    locked = true;
                    // for (int i = 0; i < datax.Count; i++)
                    int i = 0;
                    foreach (KeyValuePair<int, Object> entry in obj.data)
                    {
                        // Application.DoEvents();
                        progress_bar("Importing ...", i, obj.data.Count);
                        if (eLC.ConversationListIndex == obj.ListId)
                        {
                            conversationList.DialogCount++;
                            conversationList.Dialogs[conversationList.DialogCount - 1] = (eDialog)entry.Value;
                        }
                        else
                        {
                            SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                            if (DatabaseManager.Instance.autonewId)
                            {
                                if (configs.nextAutoNewId == 0)
                                {
                                    configs.nextAutoNewId = eLC.getNextFreeId(0, null);
                                }
                                int id_index = -1;
                                if (id_index == -1)
                                {
                                    for (int e = 0; 0 < eLC.Lists[obj.ListId].elementFields.Length; e++)
                                    {
                                        if (eLC.Lists[obj.ListId].elementFields[e] == "ID")
                                        {
                                            id_index = e;
                                            break;
                                        }
                                    }
                                }
                                data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                                configs.nextAutoNewId = (int)data[id_index];
                                eLC.useFreeId(configs.nextAutoNewId, obj.ListId, eLC.Lists[obj.ListId].elementValues.Count);
                            }


                            eLC.Lists[obj.ListId].AddItem(obj.ListId, data);

                        }

                    }
                    file.Close();
                }

                this.RefreshTaskRecipes();
                locked = false;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                Change_list(null, null);
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
                        for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                                    String test = Convert.ToString(listBox_items.CurrentCell.EditedFormattedValue);
                                    eLC.SetValue(l, e, pos, test);
                                    this.RefreshTaskRecipes();
                                }
                                break;
                            case 2:
                                if (pos3 != -1)
                                {
                                    String test = Convert.ToString(listBox_items.CurrentCell.EditedFormattedValue);
                                    eLC.SetValue(l, e, pos3, test);
                                }
                                break;
                        }
                    }
                    else
                    {
                        JMessageBox.Show(this, "List Not Supported!" + e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                JMessageBox.Show(this, "CHANGING ERROR!\nFailed changing value, this value seems to be invalid." + e.ToString());
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
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                            ImageChange ic = new ImageChange(id, value);
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
            if (selectedImage != null && listBox_items.SelectedRows != null)
            {
                lock3 = true;
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                try
                {
                    if (eLC != null && e > -1)
                    {

                        DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                        for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                        {
                            e = selected[x].Index;
                            if (l != eLC.ConversationListIndex)
                            {
                                int pos = -1;
                                int pos2 = -1;
                                for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                                }
                            }
                            else
                            {
                                JMessageBox.Show(this, "List Not Supported!" + e.ToString());
                            }
                        }
                    }
                }
                catch
                {
                    // JMessageBox.Show(this, "CHANGING ERROR!\nFailed changing value, this value seems to be invalid." + ed.ToString());
                }
                lock3 = false;
                listBox_items_CellClick(null, null);
                selectedImage = null;
                lock3 = false;
            }

        }

        private void btnAdd_Click(object sender, EventArgs ex)
        {
            if (eLC == null)
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
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                            }
                            else
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
                    for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                        }
                        else
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
                            JMessageBox.Show(this, "Invalid value");
                        }
                    }
                }
            }

        }

        private void cmg_FormClosed(object sender, FormClosedEventArgs ex)
        {
            if (listBox_items.CurrentCell == null) return;

            int l = comboBox_lists.SelectedIndex;
            int e = listBox_items.CurrentCell.RowIndex;
            try
            {
                lock3 = true;
                if (eLC != null && e > -1)
                {
                    DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                    for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                    {
                        e = selected[x].Index;
                        if (l != eLC.ConversationListIndex)
                        {
                            int pos = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                            JMessageBox.Show(this, "List Not Supported!" + e.ToString());
                        }
                    }
                }
            }
            catch (Exception ed)
            {
                JMessageBox.Show(this, "CHANGING ERROR!\nFailed changing value, this value seems to be invalid." + ed.ToString());
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
                            JMessageBox.Show(this, "Invalid value");
                        }
                    }
                    if (name.Equals("file icon") || name.Equals("file icon1"))
                    {
                        int pos = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                                ImageChange ic = new ImageChange(id, value);
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
                                if (eLC.valuableItems.ContainsKey(n))
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
                    if (dataGridView_item.Rows[dataGridView_item.CurrentCell.RowIndex].Cells[2].Tag is ItemDupe)
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
                    lock3 = true;
                    int l = comboBox_lists.SelectedIndex;
                    int elindex = listBox_items.CurrentCell.RowIndex;
                    DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                    for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                    {
                        elindex = selected[x].Index;
                        if (l != eLC.ConversationListIndex)
                        {
                            if (proctypeLocation > 0 && l > 0 && proctypeLocationvak.ToString() != ProcTypeGenerator.value_tosave)
                            {
                                eLC.Lists[l].SetValue(elindex, proctypeLocation, ProcTypeGenerator.value_tosave);

                            }
                        }
                    }
                }
            }
            catch { }
            lock3 = false;
            listBox_items_CellClick(null, null);
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
                locked = true;
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    e = selected[x].Index;
                    int row = dataGridView_item.CurrentCell.RowIndex;
                    if (l != eLC.ConversationListIndex)
                    {
                        ComboBox cb = ((ComboBox)sender);
                        if (cb != null && cb.SelectedIndex > -1)
                        {
                            try
                            {
                                string value = cb.Items[cb.SelectedIndex].ToString().Split('_')[1];
                                if (value.Length > 0)
                                {
                                    dataGridView_item.Rows[row].Cells[3].Value = value;
                                    eLC.Lists[l].SetValue(e, row, value);
                                }
                            }
                            catch (Exception) { };

                        }

                    }
                }
            }
            lock3 = false;
            listBox_items_CellClick(null, null);


        }
        private void ElementsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.StandAlone)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    showInfo = false;
                    e.Cancel = true;
                    MainProgram.getInstance().ShowElementEditor(null, null);
                }
            }
            else
            {
                MainProgram.getInstance().ExitInvoke();
            }
        }

        private void FileOrginizerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (lock3 || eLC == null || comboBox_lists.SelectedIndex == -1) { return; }
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
                exportClipboardwithNorules();
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

                if (listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex != -1)
                {
                    e.Handled = true;
                    int count = listBox_items.SelectedRows.Count;
                    if ((JMessageBox.Show(this, "Do you realy want to delete:" + count + " items?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
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
        public static bool isImportWithAdd = false;
        public static bool isImportInThisList = false;
        public static bool isImportWithDelete = false;
        public static bool isImportNewOnly = false;
        public static bool isImportcanceled = true;
        public static bool importWithReplaceAndAddNew = true;
        private Dictionary<int, SaleTab> saleTabAllItems;
        private bool versionMistmatch = false;
        private bool BrakeImport(int actual_elements_Count, int import_elements_Count, int ListId, int importVersion)
        {
            if (eLC == null) return true;

            ConvertElements importRules = configs.GetExportConfig(eLC.Version, importVersion);
            if (importRules != null)
            {
                versionMistmatch = true;
                if (ListId > (eLC.Lists.Length - 1))
                {
                    JMessageBox.Show(this, "The list dose not exist.", "Unable to continue.", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (actual_elements_Count == import_elements_Count)
                {
                    return false;
                }
                else
                {
                    versionMistmatch = true;
                    DialogResult dia = JMessageBox.Show(this, "Unable to find config for the imported version, if you continue you have to manually fix it the items or create an import ini. Do you wish to continue?", "Import version mismatch (" + importVersion + " --> " + eLC.Version + ")", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    return dia == DialogResult.No;
                }
            }
        }

        private void importItemsWithRulesFromClipBoard()
        {
            int ltc = 0;
            int i = 0;
            int list = comboBox_lists.SelectedIndex;
            versionMistmatch = false;
            Export importObject = GetFromClipboard();
            if (ElementsEditor.isImportInThisList)
                importObject.ListId = list;

            if (eLC != null && importObject != null && importObject.data != null && importObject.data.Count > 0)
            {
                lock3 = true;
                progress_bar("Importing ...", 0, 0);
                int actual_elements_Count = 0;
                int import_elements_Count = 0;
                if (importObject.ListId != -1)
                {
                    actual_elements_Count = eLC.Lists[importObject.ListId].elementFields.Length;
                    import_elements_Count = importObject.RowCount;
                    if (BrakeImport(actual_elements_Count, import_elements_Count, importObject.ListId, importObject.Version))
                    {
                        return;
                    }
                    comboBox_lists.SelectedIndex = importObject.ListId;
                    ltc = importObject.ListId;
                    comboBox_lists.Enabled = false;
                    listBox_items.Enabled = false;
                    locked = true;
                    if (ElementsEditor.isImportWithDelete)
                    {
                        eLC.Lists[importObject.ListId].elementValues = new SortedList<int, SortedList<int, object>>();
                    }
                }
                ConvertElements importRules = configs.GetExportConfig(eLC.Version, importObject.Version);

                int lastIdList = 0;
                bool hasLoadedIds = false;
                List<int> IDs = new List<int>();
                foreach (KeyValuePair<int, object> entryx in importObject.data)
                {
                    progress_bar("Importing ...", i, importObject.data.Count);
                    if (entryx.Value is Export datxzx)
                    {
                        if (ElementsEditor.isImportInThisList)
                            datxzx.ListId = list;
                        actual_elements_Count = eLC.Lists[datxzx.ListId].elementFields.Length;
                        import_elements_Count = datxzx.RowCount;
                        if (ElementsEditor.isImportNewOnly && !hasLoadedIds)
                        {
                            for (int x = 0; x < eLC.Lists[datxzx.ListId].elementValues.Count; x++)
                            {
                                try
                                {
                                    IDs.Add(int.Parse(eLC.Lists[datxzx.ListId].elementValues[x][0].ToString()));
                                }
                                catch
                                {

                                }
                            }
                            hasLoadedIds = true;
                        }
                        if (ElementsEditor.isImportWithDelete && lastIdList != datxzx.ListId)
                        {
                            eLC.Lists[datxzx.ListId].elementValues = new SortedList<int, SortedList<int, object>>();
                        }
                        lastIdList = datxzx.ListId;

                        if (BrakeImport(actual_elements_Count, import_elements_Count, datxzx.ListId, datxzx.Version))
                        {
                            return;
                        }
                        bool isDone = false;
                        foreach (KeyValuePair<int, object> subentry in datxzx.data)
                        {
                            if (ElementsEditor.isImportNewOnly && hasLoadedIds)
                            {
                                try
                                {
                                    int valueID = int.Parse(((SortedList<int, object>)subentry.Value)[0].ToString());
                                    if (!IDs.Contains(valueID))
                                    {
                                        if (DealWithImportedItem(datxzx, subentry, versionMistmatch, importRules))
                                        {
                                            isDone = true;
                                        }
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                if (DealWithImportedItem(datxzx, subentry, versionMistmatch, importRules))
                                {
                                    isDone = true;
                                }
                            }

                        }
                        if (isDone)
                            i++;
                    }
                    else
                    {
                        if (ElementsEditor.isImportNewOnly && !hasLoadedIds)
                        {
                            for (int x = 0; x < eLC.Lists[importObject.ListId].elementValues.Count; x++)
                            {
                                try
                                {
                                    IDs.Add(int.Parse(eLC.Lists[importObject.ListId].elementValues[x][0].ToString()));
                                }
                                catch
                                {

                                }
                            }
                            hasLoadedIds = true;
                        }
                        if (ElementsEditor.isImportNewOnly && hasLoadedIds)
                        {
                            try
                            {
                                int valueID = int.Parse(((SortedList<int, object>)entryx.Value)[0].ToString());
                                if (!IDs.Contains(valueID))
                                {
                                    if (DealWithImportedItem(importObject, entryx, versionMistmatch, importRules))
                                    {
                                        i++;
                                    }
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            if (DealWithImportedItem(importObject, entryx, versionMistmatch, importRules))
                            {
                                i++;
                            }
                        }

                    }

                }

                this.RefreshTaskRecipes();
                locked = false;
                lock3 = false;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                try
                {
                    Change_list(null, null);
                    listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Cells[0];
                    locked = false;
                    listBox_items_CellClick(null, null);
                }
                catch { }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Somthing went wrong with the export, please try again!");
            }

            locked = false;

        }

        private bool DealWithImportedItem(Export importObject, KeyValuePair<int, object> entry, bool versionMistmatch, ConvertElements importRules)
        {
            int id_index = 0;
            if (eLC.ConversationListIndex == importObject.ListId)
            {
                conversationList.DialogCount++;
                conversationList.Dialogs[conversationList.DialogCount - 1] = (eDialog)entry.Value;
                return true;
            }
            else
            {
                SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                if (versionMistmatch)
                {
                    #region FIX DATA FIRS
                    //CREATE NEW ITEM
                    SortedList<int, object> Fixeddata = new SortedList<int, object>();
                    for (int i = 0; i < eLC.Lists[importObject.ListId].elementFields.Length; i++)
                    {
                        Fixeddata[i] = eLC.GetDefaultValue(eLC.Lists[importObject.ListId].elementTypes[i].ToString());
                    }

                    if (importRules != null)
                    {
                        if (importRules.lists.ContainsKey(importObject.ListId))
                        {
                            Dictionary<int, RowIndexesExport> config = importRules.lists[importObject.ListId];
                            int a = 0;
                            //FIX LIKE OLD TIMES COPY OLD VALUES TO NEW
                            int count = eLC.Lists[importObject.ListId].elementFields.Length > importObject.RowCount ? eLC.Lists[importObject.ListId].elementFields.Length : importObject.RowCount;
                            for (int e = 0; e < count; e++)
                            {

                                if (config.ContainsKey(e))
                                {
                                    RowIndexesExport xd = config[e];
                                    switch (xd.OPERATION)
                                    {
                                        case REPLACEOPERATION.ADD_ROW:
                                            //  List<object> xda = data.Values.ToList();
                                            // xda.Insert(xd.ROWID, eLC.getDefaultValue(eLC.Lists[importObject.ListId].elementTypes[xd.ROWID]));
                                            //  Fixeddata = new SortedList<int,object>(xda.Select(p => new { id = key++, value = p }).ToDictionary(x => x.id, x => x.value));
                                            //  eLC.TrySetValue(xd.LIST, xd.ROWID, ref Fixeddata, xd.VALUE);
                                            eLC.TrySetValue(importObject.ListId, e, ref Fixeddata, xd.VALUE);
                                            a++;
                                            break;
                                        case REPLACEOPERATION.SKIP_ROW:
                                            // Dictionary<int, object> tmpdata = data.Where(x => x.Key != xd.ROWID).ToDictionary(x => x.Key, x => x.Value);
                                            // Fixeddata = new SortedList<int, object>(tmpdata.Values.Select(p => new { id = key++, value = p }).ToDictionary(x => x.id, x => x.value));
                                            // eLC.TrySetValue(xd.LIST, xd.ROWID, ref Fixeddata, xd.value);

                                            break;
                                        case REPLACEOPERATION.REPLACE:
                                            Fixeddata = data;
                                            eLC.TrySetValue(xd.LIST, xd.ROWID, ref Fixeddata, xd.VALUE);
                                            break;
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        eLC.TrySetValue(importObject.ListId, e, ref Fixeddata, data[e - a]);
                                    }
                                    catch { }
                                }
                            }
                            /*
                            foreach (KeyValuePair<int, RowIndexesExport> fordata in config)
                            {
                                int key = 0;
                                RowIndexesExport xd = fordata.Value;
                                switch (xd.OPERATION)
                                {
                                    case REPLACEOPERATION.ADD_ROW:
                                        List<object> xda = data.Values.ToList();
                                        xda.Insert(xd.ROWID, eLC.getDefaultValue(eLC.Lists[importObject.ListId].elementTypes[xd.ROWID]));
                                        key = 0;
                                      //  Fixeddata = new SortedList<int,object>(xda.Select(p => new { id = key++, value = p }).ToDictionary(x => x.id, x => x.value));
                                      //  eLC.TrySetValue(xd.LIST, xd.ROWID, ref Fixeddata, xd.VALUE);
                                        break;
                                    case REPLACEOPERATION.SKIP_ROW:
                                        Dictionary < int, object> tmpdata = data.Where(x=>x.Key != xd.ROWID).ToDictionary(x => x.Key, x => x.Value);
                                        key = 0;
                                        Fixeddata = new SortedList<int,object>(tmpdata.Values.Select(p => new { id = key++, value = p }).ToDictionary(x => x.id, x => x.value));
                                       // eLC.TrySetValue(xd.LIST, xd.ROWID, ref Fixeddata, xd.value);
                                        break;
                                    case REPLACEOPERATION.REPLACE:
                                        Fixeddata = data;
                                        eLC.TrySetValue(xd.LIST, xd.ROWID, ref Fixeddata, xd.VALUE);
                                        break;
                                }
                            }
                            */
                        }
                        else
                        {
                            //FIX LIKE OLD TIMES COPY OLD VALUES TO NEW
                            int count = eLC.Lists[importObject.ListId].elementFields.Length > importObject.RowCount ? eLC.Lists[importObject.ListId].elementFields.Length : importObject.RowCount;
                            for (int e = 0; e < count; e++)
                            {
                                if (Fixeddata.ContainsKey(e))
                                    eLC.TrySetValue(importObject.ListId, e, ref Fixeddata, data[e]);
                            }
                        }
                    }
                    else
                    {
                        //FIX LIKE OLD TIMES COPY OLD VALUES TO NEW
                        int count = eLC.Lists[importObject.ListId].elementFields.Length > importObject.RowCount ? eLC.Lists[importObject.ListId].elementFields.Length : importObject.RowCount;
                        for (int e = 0; e < count; e++)
                        {
                            if (Fixeddata.ContainsKey(e))
                                eLC.TrySetValue(importObject.ListId, e, ref Fixeddata, data[e]);
                        }
                    }
                    data = Fixeddata;
                    #endregion
                }
                #region ADD NEW IDS
                if (DatabaseManager.Instance.autonewId && ElementsEditor.isImportWithDelete || DatabaseManager.Instance.autonewId && ElementsEditor.isImportWithAdd)
                {
                    if (id_index != -1)
                    {
                        if (configs.nextAutoNewId == 0)
                        {
                            configs.nextAutoNewId = eLC.getNextFreeId(0, null);
                        }
                        data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                        configs.nextAutoNewId = (int)data[id_index];
                        eLC.useFreeId(configs.nextAutoNewId, importObject.ListId, eLC.Lists[importObject.ListId].elementValues.Count);
                    }

                }
                #endregion
                #region IMPORT WITH ADD
                if (ElementsEditor.isImportWithAdd)
                {
                    eLC.Lists[importObject.ListId].AddItem(importObject.ListId, data);
                    return true;
                }
                #endregion
                #region IMPORT WITH REPLACE
                else if (ElementsEditor.isImportWithReplace)
                {
                    int itemID = -1;
                    if (id_index != -1)
                    {
                        itemID = (int)data[id_index];
                    }
                    if (itemID != -1)
                    {
                        int elementIndex = GetItemIDbyListId(importObject.ListId, itemID);
                        if (elementIndex != -1)
                        {
                            if (DatabaseManager.Instance.autonewId)
                            {
                                data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                                configs.nextAutoNewId = (int)data[id_index];
                                eLC.useFreeId(configs.nextAutoNewId, importObject.ListId, eLC.Lists[importObject.ListId].elementValues.Count);
                                eLC.Lists[importObject.ListId].elementValues[elementIndex] = data;
                                return true;
                            }
                            else
                            {
                                eLC.Lists[importObject.ListId].elementValues[elementIndex] = data;
                                return true;
                            }

                        }
                    }
                    return false;
                }
                #endregion
                #region IMPORT WITH REPLACE AND ADD
                else if (ElementsEditor.importWithReplaceAndAddNew)
                {
                    int itemID = -1;
                    if (id_index != -1)
                    {
                        itemID = (int)data[id_index];
                    }
                    if (itemID != -1)
                    {
                        if (DatabaseManager.Instance.autonewId)
                        {
                            data[id_index] = (int)eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                            configs.nextAutoNewId = (int)data[id_index];
                            eLC.useFreeId(configs.nextAutoNewId, importObject.ListId, eLC.Lists[importObject.ListId].elementValues.Count);
                            itemID = (int)data[id_index];
                        }

                        int elementIndex = GetItemIDbyListId(importObject.ListId, itemID);
                        if (elementIndex != -1)
                        {
                            eLC.Lists[importObject.ListId].elementValues[elementIndex] = data;
                            return true;
                        }
                        else
                        {
                            eLC.Lists[importObject.ListId].AddItem(importObject.ListId, data);
                            return true;
                        }

                    }
                    return false;

                }
                #endregion
                #region Import with delete
                else if (ElementsEditor.isImportWithDelete)
                {
                    eLC.Lists[importObject.ListId].AddItem(importObject.ListId, data);
                    return true;
                }
                else if (ElementsEditor.isImportNewOnly)
                {
                    eLC.Lists[importObject.ListId].AddItem(importObject.ListId, data);
                    return true;
                }
                #endregion
            }
            return false;
        }

        private int GetItemIDbyListId(int list, int itemID)
        {

            int pos = 0;
            for (int i = 0; i < eLC.Lists[list].elementFields.Length; i++)
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

        private void exportClipboardwithNorules()
        {

            if (comboBox_lists.SelectedIndex == -1 || listBox_items.CurrentCell == null)
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
                        export.Version = eLC.Version;
                        export.RowCount = eLC.Lists[l].elementFields.Length;
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
                JMessageBox.Show(this, "Please select a item!");
            }
        }

        private JButton lastBtnPressPreview = null;
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
            lastBtnPressPreview = sender as JButton;
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
                            string nameofpic = "picture_item_" + itemEntry.Value.elat;
                            PictureBox mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                            mybox.Image = itemEntry.Value.itemInfo.img;
                            mybox.Tag = itemEntry.Value;
                            mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            string nameofpic = "picture_item_" + itemEntry.Value.elat;
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
        private void DealWithCraftingTab(int list, int element)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    DealWithCraftingTab(list, element);
                }));
                return;
            }
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
                // Application.DoEvents();
                progress_bar("Loading preview...", f, eLC.Lists[list].elementValues[element].Count);
                if (eLC.Lists[list].elementFields[f].Contains("_title"))
                {
                    intTabId++;
                    SaleTab saleTab = new SaleTab();
                    saleTab.title = eLC.GetValue(list, element, f);
                    saleTab.List = list;
                    saleTab.Item = element;
                    saleTab.elId = f;
                    saleTab.intTabId = intTabId;
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
                                    SaleItem saleItem = new SaleItem
                                    {
                                        itemId = saleId,
                                        itemInfo = info,
                                        recipe = recipe,
                                        rowId = f,
                                        elat = elat,
                                        saleTab = saleTabAllItems[intTabId]
                                    };
                                    saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                }
                                else
                                {
                                    SaleItem saleItem = new SaleItem
                                    {
                                        itemId = saleId,
                                        itemInfo = null,
                                        rowId = f,
                                        recipe = recipe,
                                        elat = elat,
                                        saleTab = saleTabAllItems[intTabId]
                                    };
                                    saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                }
                            }
                            else
                            {
                                SaleItem saleItem = new SaleItem
                                {
                                    itemId = saleId,
                                    itemInfo = null,
                                    rowId = f,
                                    recipe = recipe,
                                    elat = elat,
                                    saleTab = saleTabAllItems[intTabId]
                                };
                                saleTabAllItems[intTabId].items.Add(elat, saleItem);
                            }
                        }
                        else
                        {
                            SaleItem saleItem = new SaleItem
                            {
                                itemId = saleId,
                                itemInfo = null,
                                rowId = f,
                                recipe = null,
                                elat = elat,
                                saleTab = saleTabAllItems[intTabId]
                            };
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
                            string nameofpic = "pictureBox_craft_" + itemEntry.Value.elat;
                            PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            if (itemEntry.Value.itemInfo != null && itemEntry.Value.itemInfo.img != null)
                            {
                                mybox.Image = itemEntry.Value.itemInfo.img;
                            }
                            else
                            {
                                mybox.Image = new Bitmap(Resources.blank, 32, 32);
                            }
                            mybox.Tag = itemEntry.Value;
                            mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            string nameofpic = "pictureBox_craft_" + itemEntry.Value.elat;
                            PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            mybox.Image = null;
                            mybox.Tag = itemEntry.Value;
                        }

                    }
                }
                string nameofButon = "tab_craftbtn_" + bcount;
                JButton myButton = (JButton)this.craftTab.Controls[nameofButon];
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
        private void elementIntoTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked || lock3) { return; }
            if (eLC != null && listBox_items.CurrentCell != null)
            {
                textBox4.Visible = label4.Visible = label3.Visible = textBox5.Visible = false;
                block(true);
                resetrecipeFirst();
                int list = comboBox_lists.SelectedIndex;
                int item = listBox_items.CurrentCell.RowIndex;
                int element = listBox_items.CurrentCell.RowIndex;

                if (list == eLC.CraftServiceListIndex && elementIntoTab.SelectedIndex > 1 && !lockedelementTabInfo)
                {
                    Task.Factory.StartNew(() =>
                    {
                        DealWithCraftingTab(list, element);
                    });
                }
                if (list == eLC.SaleServiceListIndex && elementIntoTab.SelectedIndex > 1 && !lockedelementTabInfo)
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
                        progress_bar("Loading preview...", f, eLC.Lists[list].elementValues[element].Count);
                        if (eLC.Lists[list].elementFields[f].Contains("_title"))
                        {
                            intTabId++;
                            SaleTab saleTab = new SaleTab();
                            saleTab.title = eLC.GetValue(list, element, f);
                            saleTab.List = list;
                            saleTab.Item = element;
                            saleTab.elId = f;
                            saleTab.intTabId = intTabId;
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
                                    saleItem.elat = elat;
                                    saleItem.saleTab = saleTabAllItems[intTabId];
                                    saleTabAllItems[intTabId].items.Add(elat, saleItem);
                                }
                                else
                                {
                                    SaleItem saleItem = new SaleItem();
                                    saleItem.itemId = saleId;
                                    saleItem.itemInfo = null;
                                    saleItem.rowId = f;
                                    saleItem.elat = elat;
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
                                    string nameofpic = "picture_item_" + itemEntry.Value.elat;
                                    string nameoflabel = "label_item_" + itemEntry.Value.elat;
                                    PictureBox mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                                    Label mylabel = (Label)this.groupBox1.Controls[nameoflabel];
                                    mybox.Image = itemEntry.Value.itemInfo.img;
                                    mybox.Tag = itemEntry.Value;
                                    mylabel.Text = itemEntry.Value.itemId.ToString();
                                    mylabel.Visible = true;
                                    if (checkBox1.Checked)
                                    {
                                        mylabel.Visible = true;
                                    }
                                    else
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
                        JButton myButton = (JButton)this.groupBox4.Controls[nameofButon];
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
                    block(false);
                    lockedelementTabInfo = false;
                    progress_bar("Ready", 0, 0);
                    groupBox4.Enabled = true;
                    groupBox1.Enabled = true;
                }
            }
            block(false);
        }

        private void picture_item_1_MouseEnter(object sender, EventArgs e)
        {
            var picboxS = sender as PictureBox;
            if (picboxS != null)
            {
                try
                {
                    if (customTooltype != null)
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

        private SaleItem selectedCraftItem = null;

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
                string name = "pictureBox_craft_req_" + i;
                PictureBox box = null;
                box = (PictureBox)this.groupBox10.Controls[name];
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
                            if (comboBox_lists.SelectedIndex == eLC.SaleServiceListIndex)
                            {
                                string nameofpic = "picture_item_" + itemEntry.Value.elat;
                                mybox = (PictureBox)this.groupBox1.Controls[nameofpic];
                            }
                            else
                            {
                                string nameofpic = "pictureBox_craft_" + itemEntry.Value.elat;
                                mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            }

                            using (Graphics g = mybox.CreateGraphics())
                            {
                                g.DrawRectangle(new Pen(Color.FromArgb(17, 17, 17)), new Rectangle(new Point(0, 0), new Size(32, 32)));
                            }
                        }
                    }
                    using (Graphics g = picboxS.CreateGraphics())
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(Color.Gold)), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    }

                    selectedCraftItem = saleItem;
                    if (comboBox_lists.SelectedIndex == eLC.CraftServiceListIndex)
                    {
                        if (saleItem.recipe != null)
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
                                string name = "pictureBox_craft_req_" + found;
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
            if (textBox1.Text.Length > 0 && selectedCraftItem != null)
            {
                int value = -1;
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    if (int.TryParse(textBox1.Text, out value))
                    {

                        eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, value.ToString());
                        selectedCraftItem = null;
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
            if (selectedCraftItem != null)
            {
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    eLC.Lists[selectedCraftItem.saleTab.List].SetValue(selectedCraftItem.saleTab.Item, selectedCraftItem.saleTab.elId, textBox2.Text);
                    selectedCraftItem = null;
                    elementIntoTab_SelectedIndexChanged(null, null);
                    tab_salebtn_1_MouseClick(lastBtnPressPreview, null);
                }
            }
            else
            {
                JMessageBox.Show(this, "Please select a item in the sale tab first!");
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
                            if (selectedCraftItem == null)//There is no selected item
                            {
                                if ((JMessageBox.Show(this, "Nothing to move here! Would you like to delete?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                {
                                    eLC.Lists[list].SetValue(item, saleItem.rowId, "0");
                                }
                            }
                            else if (selectedCraftItem != null)//There is a selected item
                            {
                                if (saleItem.itemInfo != null)//There's a item where selected item will be placed 
                                {
                                    if ((JMessageBox.Show(this, "The box already contains a item, would you like to override? (No to swap)", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                    {
                                        eLC.Lists[list].SetValue(item, saleItem.rowId, selectedCraftItem.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, 0.ToString());
                                    }
                                    else
                                    {
                                        eLC.Lists[list].SetValue(item, saleItem.rowId, selectedCraftItem.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, saleItem.itemId.ToString());
                                    }
                                }
                                else
                                {
                                    eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, 0.ToString());
                                    eLC.Lists[list].SetValue(item, saleItem.rowId, selectedCraftItem.itemId.ToString());
                                }
                            }
                            selectedCraftItem = null;
                            elementIntoTab_SelectedIndexChanged(null, null);
                            tab_salebtn_1_MouseClick(lastBtnPressPreview, null);
                        }
                    }
                }
            }
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
            lastBtnPressPreview = sender as JButton;
            if (lastBtnPressPreview != null)
            {
                lastBtnPressPreview.ForeColor = Color.White;
                lastBtnPressPreview.BackColor = Color.Black;

                LastTabId = int.Parse(lastBtnPressPreview.Tag.ToString());
                if (saleTabAllItems.ContainsKey(LastTabId))
                {
                    SortedDictionary<int, SaleItem> items = saleTabAllItems[LastTabId].items;
                    foreach (KeyValuePair<int, SaleItem> itemEntry in items)
                    {
                        if (itemEntry.Value.itemId != 0)
                        {
                            string nameofpic = "pictureBox_craft_" + itemEntry.Value.elat;
                            PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            if (itemEntry.Value.itemInfo != null)
                            {
                                mybox.Image = itemEntry.Value.itemInfo.img;
                            }
                            else
                            {
                                mybox.Image = new Bitmap(ElementsEditor.database.images("unknown.dds"), 32, 32);
                            }
                            mybox.Tag = itemEntry.Value;
                            mybox.SizeMode = PictureBoxSizeMode.StretchImage;
                            mybox.Refresh();
                        }
                        else
                        {
                            string nameofpic = "pictureBox_craft_" + itemEntry.Value.elat;
                            PictureBox mybox = (PictureBox)this.groupBox8.Controls[nameofpic];
                            mybox.Image = null;
                            mybox.Tag = itemEntry.Value;
                            mybox.Refresh();
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
                textBox5.Visible = label4.Visible = label3.Visible = textBox4.Visible = true;
                SaleItem saleItem = (SaleItem)picboxS.Tag;
                if (saleItem != null && saleItem.recipe != null && saleItem.itemInfo != null)
                {
                    thisSubMatSelected = picboxS;
                    Recipe recipe = saleItem.recipe;
                    textBox4.Text = saleItem.itemId.ToString();
                    textBox5.Text = eLC.GetValue(recipe.list, recipe.index, saleItem.rowId + 1).ToString();
                    if (saleItem.upgradable)
                    {
                        label3.Text = "Rate:";
                    }
                    else
                    {
                        label3.Text = "Count:";
                    }
                    textBox19.Text = recipe.price.ToString();
                    textBox20.Text = recipe.duration.ToString();
                    Graphics g = pictureBox_craft_req_1.CreateGraphics();
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g.Dispose();
                    Graphics g1 = pictureBox_craft_req_2.CreateGraphics();
                    g1.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g1.Dispose();
                    Graphics g2 = pictureBox_craft_req_3.CreateGraphics();
                    g2.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g2.Dispose();
                    Graphics g3 = pictureBox_craft_req_4.CreateGraphics();
                    g3.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g3.Dispose();
                    Graphics g4 = pictureBox_craft_req_5.CreateGraphics();
                    g4.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g4.Dispose();
                    Graphics g5 = pictureBox_craft_req_6.CreateGraphics();
                    g5.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g5.Dispose();
                    Graphics g6 = pictureBox_craft_req_7.CreateGraphics();
                    g6.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g6.Dispose();
                    Graphics g7 = pictureBox_craft_req_8.CreateGraphics();
                    g7.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g7.Dispose();
                    Graphics gx = picboxS.CreateGraphics();
                    gx.DrawRectangle(new Pen(new SolidBrush(Color.DarkSlateGray)), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    gx.Dispose();
                    button11.Visible = true;
                    button14.Visible = false;

                }
                else
                {
                    thisSubMatSelected = picboxS;
                    Graphics g = pictureBox_craft_req_1.CreateGraphics();
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g.Dispose();
                    Graphics g1 = pictureBox_craft_req_2.CreateGraphics();
                    g1.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g1.Dispose();
                    Graphics g2 = pictureBox_craft_req_3.CreateGraphics();
                    g2.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g2.Dispose();
                    Graphics g3 = pictureBox_craft_req_4.CreateGraphics();
                    g3.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g3.Dispose();
                    Graphics g4 = pictureBox_craft_req_5.CreateGraphics();
                    g4.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g4.Dispose();
                    Graphics g5 = pictureBox_craft_req_6.CreateGraphics();
                    g5.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g5.Dispose();
                    Graphics g6 = pictureBox_craft_req_7.CreateGraphics();
                    g6.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g6.Dispose();
                    Graphics g7 = pictureBox_craft_req_8.CreateGraphics();
                    g7.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(0, 0), new Size(32, 32)));
                    g7.Dispose();
                    Graphics gx = picboxS.CreateGraphics();
                    gx.DrawRectangle(new Pen(new SolidBrush(Color.DarkSlateGray)), new Rectangle(new Point(0, 0), new Size(32, 32)));
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
            if (selectedCraftItem != null)
            {
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    eLC.Lists[selectedCraftItem.saleTab.List].SetValue(selectedCraftItem.saleTab.Item, selectedCraftItem.saleTab.elId, textBox3.Text);
                    selectedCraftItem = null;
                    elementIntoTab_SelectedIndexChanged(null, null);
                    tab_craftbtn_1_Click(lastBtnPressPreview, null);
                }
            }
            else
            {
                JMessageBox.Show(this, "Please select a item in the sale tab first!");
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
                    eLC.Lists[recipe.list].SetValue(recipe.index, saleItem.rowId + 1, textBox5.Text);
                    if (recipe.id_upgrade_equip_rowId != saleItem.rowId)
                    {
                        saleItem.recipe.materials[saleItem.rowId] = eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId);
                        saleItem.recipe.materials_count[saleItem.rowId + 1] = eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId + 1);
                    }
                    else
                    {
                        saleItem.recipe.id_upgrade_equip = int.Parse(eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId));
                        saleItem.recipe.upgrade_rate = eLC.Lists[recipe.list].GetValue(recipe.index, saleItem.rowId + 1);
                    }
                    if (lastPicboClick != null)
                        picture_item_1_Click(lastPicboClick, null);
                }
            }
        }

        private void modifyClickOtherCraftingItems(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                if (selectedCraftItem != null)
                {
                    SaleItem saleItem = (SaleItem)selectedCraftItem;
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

                        if (lastBtnPressPreview != null)
                        {
                            lastBtnPressPreview.ForeColor = Color.White;
                            lastBtnPressPreview.BackColor = Color.Black;

                            int id = int.Parse(lastBtnPressPreview.Tag.ToString());
                            if (saleTabAllItems.ContainsKey(id))
                            {
                                if (saleTabAllItems[saleItem.saleTab.intTabId].items.ContainsKey(saleItem.elat))
                                {
                                    saleItem.recipe = recipe;
                                    saleTabAllItems[saleItem.saleTab.intTabId].items[saleItem.elat] = saleItem;
                                }
                            }
                        }
                        tab_craftbtn_1_Click(lastBtnPressPreview, null);
                    }
                }
            }
        }

        private void moveCraftingItem(object sender, EventArgs e)
        {
            if (eLC != null && listBox_items.CurrentCell != null && selectedCraftItem != null)
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        PictureBox picboxS = owner.SourceControl as PictureBox;
                        if (picboxS != null)
                        {
                            SaleItem BoxUnderMouse = (SaleItem)picboxS.Tag;
                            int list = comboBox_lists.SelectedIndex;
                            int item = listBox_items.CurrentCell.RowIndex;
                            if (selectedCraftItem != null)//There is a selected item
                            {
                                if (BoxUnderMouse.itemInfo != null)//There's a item where selected item will be placed 
                                {
                                    if ((JMessageBox.Show(this, "The box already contains a item, would you like to override? (No to swap)", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
                                    {
                                        eLC.Lists[list].SetValue(item, BoxUnderMouse.rowId, selectedCraftItem.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, 0.ToString());
                                    }
                                    else
                                    {
                                        eLC.Lists[list].SetValue(item, BoxUnderMouse.rowId, selectedCraftItem.itemId.ToString());
                                        eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, BoxUnderMouse.itemId.ToString());
                                    }
                                }
                                else
                                {
                                    eLC.Lists[list].SetValue(item, BoxUnderMouse.rowId, selectedCraftItem.itemId.ToString());
                                    eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, 0.ToString());
                                }
                            }
                            if (lastBtnPressPreview != null)
                            {
                                lastBtnPressPreview.ForeColor = Color.White;
                                lastBtnPressPreview.BackColor = Color.Black;

                                selectedCraftItem = null;
                                DealWithCraftingTab(list, item);
                                tab_craftbtn_1_Click(lastBtnPressPreview, null);
                            }
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
            if (textBox7.Text.Length > 0 && selectedCraftItem != null)
            {
                int value = -1;
                if (eLC != null && listBox_items.CurrentCell != null)
                {

                    int list = comboBox_lists.SelectedIndex;
                    int item = listBox_items.CurrentCell.RowIndex;
                    if (int.TryParse(textBox7.Text, out value))
                    {

                        eLC.Lists[list].SetValue(item, selectedCraftItem.rowId, value.ToString());
                        selectedCraftItem = null;
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
                    if ((JMessageBox.Show(this, "Is this a normal material?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
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
                    }
                    else
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
                    JMessageBox.Show(this, "Please select a recipe.");
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
                    JMessageBox.Show(this, "SAVING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch");
                }
            }
        }

        private void button15_Click(object sender, EventArgs ex)
        {
            string toestring = textBox23.Text;
            string toestring2 = jTextBox1.Text;
            bool isSecondRowSearch = false;

            if (toestring.Length <= 0)
            {
                return;
            }
            if (jComboBox1.SelectedIndex > 0)
            {
                if (toestring2.Length <= 0)
                {
                    JMessageBox.Show(this, "Please input value 2");
                    return;
                }
                isSecondRowSearch = true;
            }
            dataGridView1.Rows.Clear();
            if (checkBox5.Checked)
            {

                bool isonlyInThisList = checkBox4.Checked;
                bool isCaseSensitive = checkBox2.Checked;
                if (isCaseSensitive)
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
                        if (isSecondRowSearch && checkBox4.Checked)
                        {
                            dataGridView1.Rows.Clear();
                            int elementIndex = -1;
                            int elementIndex2 = -1;
                            string name = selecter_rowscheckbox.Items[selecter_rowscheckbox.SelectedIndex].ToString();
                            string name2 = jComboBox1.Items[jComboBox1.SelectedIndex].ToString();
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                                {
                                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                    {
                                        nameIndex = f;
                                    }
                                    if (eLC.Lists[list].elementFields[f].Equals(name))
                                    {
                                        elementIndex = f;
                                    }
                                    if (eLC.Lists[list].elementFields[f].Equals(name2))
                                    {
                                        elementIndex2 = f;
                                    }
                                }
                            }

                            int row1 = elementIndex;
                            int row2 = elementIndex2;
                            for (int f = 0; f < eLC.Lists[list].elementValues.Count; f++)
                            {
                                SortedList<int, object> data = eLC.Lists[list].elementValues[f];
                                string value1 = eLC.Lists[list].GetValue(f, row1);
                                string value2 = eLC.Lists[list].GetValue(f, row2);
                                if (checkBox2.Checked)
                                {
                                    if (toestring.Equals(value1.Trim().ToLower()) && toestring2.Equals(value2.Trim().ToLower()))
                                    {
                                        string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                        dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[row1] + "+" + eLC.Lists[list].elementFields[row2], namex, value1, list, f, row1 });
                                    }
                                }
                                else
                                {
                                    if (value1.ToLower().Trim().Contains(toestring.ToLower().Trim()) && value2.ToLower().Trim().Contains(toestring2.ToLower().Trim()))
                                    {
                                        string namexx = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                        dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[row1] + "+" + eLC.Lists[list].elementFields[row2], namexx, value1, list, f, row1 });
                                    }
                                }

                            }
                            return;
                        }




                        if (nameIndex == -1)
                        {
                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                            SortedList<int, object> data = eLC.Lists[list].elementValues[f];
                            for (int i = 0; i < data.Count; i++)
                            {
                                string value = eLC.Lists[list].GetValue(f, i);
                                if (checkBox2.Checked)
                                {
                                    if (toestring.Equals(value.Trim().ToLower()))
                                    {
                                        string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                        dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[i], namex, value, list, f, i });
                                    }
                                }
                                else
                                {
                                    if (value.ToLower().Trim().Contains(toestring.ToLower().Trim()))
                                    {
                                        string namexx = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                        dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[i], namexx, value, list, f, i });
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
                    if (isSecondRowSearch && checkBox4.Checked)
                    {
                        dataGridView1.Rows.Clear();
                        int nameIndex = -1;
                        int elementIndex = -1;
                        int elementIndex2 = -1;
                        string name = selecter_rowscheckbox.Items[selecter_rowscheckbox.SelectedIndex].ToString();
                        string name2 = jComboBox1.Items[jComboBox1.SelectedIndex].ToString();
                        if (nameIndex == -1)
                        {
                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                            {
                                if (eLC.Lists[list].elementFields[f].Equals("Name"))
                                {
                                    nameIndex = f;
                                }
                                if (eLC.Lists[list].elementFields[f].Equals(name))
                                {
                                    elementIndex = f;
                                }
                                if (eLC.Lists[list].elementFields[f].Equals(name2))
                                {
                                    elementIndex2 = f;
                                }
                            }
                        }

                        int row1 = elementIndex;
                        int row2 = elementIndex2;
                        for (int f = 0; f < eLC.Lists[list].elementValues.Count; f++)
                        {
                            SortedList<int, object> data = eLC.Lists[list].elementValues[f];
                            string value1 = eLC.Lists[list].GetValue(f, row1);
                            string value2 = eLC.Lists[list].GetValue(f, row2);
                            if (checkBox2.Checked)
                            {
                                if (toestring.Equals(value1.Trim().ToLower()) && toestring2.Equals(value2.Trim().ToLower()))
                                {
                                    string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                    dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[row1] + "+" + eLC.Lists[list].elementFields[row2], namex, value1, list, f, row1 });
                                }
                            }
                            else
                            {
                                if (value1.ToLower().Trim().Contains(toestring.ToLower().Trim()) && value2.ToLower().Trim().Contains(toestring2.ToLower().Trim()))
                                {
                                    string namexx = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                                    dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[row1] + "+" + eLC.Lists[list].elementFields[row2], namexx, value1, list, f, row1 });
                                }
                            }

                        }
                        return;
                    }

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
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                                    for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
            jGroupBox2.Text = "Search Results Found " + dataGridView1.Rows.Count;
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
                dataGridView_item.CurrentCell = dataGridView_item.Rows[row].Cells[0];
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
                        for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                        {
                            if (eLC.Lists[list].elementFields[f].Equals("Name"))
                            {
                                nameIndex = f;
                                break;
                            }

                        }
                    }
                    int e = selecter_rowscheckbox.SelectedIndex;
                    dataGridView1.Rows.Add(new Object[] { eLC.Lists[list].elementFields[e], nameIndex == -1 ? "" : eLC.Lists[list].GetValue(i, nameIndex), eLC.Lists[list].GetValue(i, e), list, i, e });
                }
            }
            jGroupBox2.Text = "Rows Found " + dataGridView1.Rows.Count;
        }

        private void button16_Click(object sender, EventArgs ex)
        {
            int[] whereToSearch;
            if (eLC == null || comboBox3.SelectedIndex < 0)
            {
                return;
            }
            string toestring = textBox25.Text;
            if (toestring.Length <= 0)
            {
                return;
            }
            int index = comboBox3.SelectedIndex;
            toestring = checkBox2.Checked ? toestring.ToLower().Trim() : toestring;
            switch (index)
            {
                case 0:
                    dataGridView1.Rows.Clear();
                    for (int list = 0; list < eLC.Lists.Length; list++)
                    {
                        // Application.DoEvents();
                        progress_bar("Searching...", list, eLC.Lists.Length);
                        int nameIndex = -1;
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                case 1:
                    dataGridView1.Rows.Clear();
                    for (int list = 0; list < eLC.Lists.Length; list++)
                    {
                        // Application.DoEvents();
                        progress_bar("Searching...", list, eLC.Lists.Length);
                        int nameIndex = -1;
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                    whereToSearch = new int[] { 45, 46, 74 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            // Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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

                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                            // Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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

                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                    whereToSearch = new int[] { eLC.MineEssenceList };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            // Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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

                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                    whereToSearch = new int[] { eLC.RecipeListIndex };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            // Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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

                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                    whereToSearch = new int[] { eLC.SaleServiceListIndex };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            // Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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

                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
                    whereToSearch = new int[] { 21, 48 };
                    for (int l = 0; l < whereToSearch.Length; l++)
                    {
                        int nameIndex = -1;
                        int list = whereToSearch[l];
                        for (int i = 0; i < eLC.Lists[list].elementValues.Count; i++)
                        {
                            // Application.DoEvents();
                            progress_bar("Searching...", i, eLC.Lists[list].elementValues.Count);
                            if (nameIndex == -1)
                            {
                                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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

                            for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
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
            jGroupBox2.Text = "Search Results Found " + dataGridView1.Rows.Count;
            progress_bar("Ready", 0, 0);

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
                        for (int ix = 0; ix < eLC.Lists[currentList].elementFields.Length; ix++)
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
                            JMessageBox.Show(this, "Cant create recipes in this list!");
                            return;
                        }
                        if (itemNameIndex == -1)
                        {
                            locked = false;
                            JMessageBox.Show(this, "Cant create recipes in this list!");
                            return;
                        }
                        int recipes_listId = eLC.RecipeListIndex;
                        int targets_1_id_to_make = 0;
                        int targets_1_probability = 0;
                        int targets_Name = 0;
                        int num_to_make = 0;
                        Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                        for (int ie = 0; ie < eLC.Lists[recipes_listId].elementFields.Length; ie++)
                        {
                            Object data = (Object)eLC.GetDefaultValue(eLC.Lists[recipes_listId].elementTypes[ie].ToString());
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
                                SortedList<int, object> itemValuesClone = new SortedList<int, object>(itemValues);
                                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
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
                                JMessageBox.Show(this, "Cant make recipes from conversation list.");
                                break;
                            }
                        }
                    }

                    locked = false;
                    this.RefreshTaskRecipes();
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

            }
        }

        private void dataGridView_item_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V) && eLC != null)
            {
                Export obj = GetFromClipboard();
                if (obj != null)
                {
                    if (obj.ListId == eLC.RecipeListIndex && comboBox_lists.SelectedIndex == eLC.CraftServiceListIndex)
                    {
                        populateFieldsFromExport(obj);
                        e.Handled = true;
                    }
                    else if (comboBox_lists.SelectedIndex == eLC.SaleServiceListIndex && obj.ListId != eLC.RecipeListIndex)
                    {
                        populateFieldsFromExportSellService(obj);
                        e.Handled = true;
                    }
                    else
                    {
                        populateFieldsFromExport(obj);
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
                        if(entry.Value is SortedList<int, object> data)
                        ids.Add((int)data[0]);

                        if (entry.Value is ElementEditor.Game_Shop_classes.Item data2)
                            ids.Add((int)data2.id);
                    }
                    int pageId = 0;
                    int rowindex = dataGridView_item.CurrentCell != null ? dataGridView_item.CurrentCell.RowIndex : 0;
                    for (int row = rowindex; row < eLC.Lists[currentList].elementFields.Length; row++)
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
                        SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                        ids.Add((int)data[0]);
                    }
                    int pageId = 0;
                    int rowindex = dataGridView_item.CurrentCell != null ? dataGridView_item.CurrentCell.RowIndex : 0;
                    for (int row = rowindex; row < eLC.Lists[currentList].elementFields.Length; row++)
                    {
                        if (ids.Count == 0)
                        {
                            break;
                        }
                        string rowName = eLC.Lists[currentList].elementFields[row];
                        string rowValue = eLC.Lists[currentList].GetValue(currentCell, row);
                        if (currentList == 40)
                        {
                            if (rowName.Contains("id_goods") && rowValue == "0")
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
                        else
                        {
                            if (rowName.Contains("id"))
                            {
                                int id = ids[0];
                                eLC.Lists[currentList].SetValue(currentCell, row, id.ToString());
                                ids.RemoveAt(0);
                            }
                        }
                    }
                    locked = false;
                    listBox_items_CellClick(null, null);
                }
                catch { }
            }
            locked = false;
        }

        public void RefreshTaskRecipes()
        {
            if (eLC != null)
            {
                eLC.RefreshTasksRecipe();
                AnythingChanged = true;
            }
        }


        private void ReloadInfo(int list)
        {
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
                        for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                        JMessageBox.Show(this, "ERROR LOADING ITEM LISTS\n" + e.Message);
                    }

                    if (TaskEditor.monster_npc_minelists.Contains(list))
                    {
                        for (int k = 0; k < TaskEditor.monster_npc_minelists.Count; k++)
                        {
                            progress_bar("Importing info...", k, TaskEditor.monster_npc_minelists.Count);
                            // Application.DoEvents();

                            l = (int)TaskEditor.monster_npc_minelists[k];
                            pos = -1;
                            for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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

                    if (eLC.Version >= 87 && list == eLC.TitleListIndex)
                    {
                        ElementsEditor.database.titles = new SortedList();
                        l = eLC.TitleListIndex;
                        int pos1 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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

                    if (eLC.Version >= 153 && list == eLC.HomeItemsListIndex)
                    {
                        ElementsEditor.database.homeitems = new SortedList();
                        l = eLC.HomeItemsListIndex;
                        int pos2 = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                    if (list == eLC.RecipeListIndex)
                    {
                        ElementsEditor.database.task_recipes = new SortedList<int, ItemDupe>();
                        l = eLC.RecipeListIndex;
                        pos = -1;
                        posP = -1;
                        posPrice = -1;
                        for (int i = 0; i < eLC.Lists[l].elementFields.Length; i++)
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
                JMessageBox.Show(this, ex.Message, Extensions.GetLocalization(478));
            }
            if (configs.nextAutoNewId == 0)
            {

                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                nextautoIdlabel.Text = configs.nextAutoNewId.ToString();
            }
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
                        for (int ix = 0; ix < eLC.Lists[currentList].elementFields.Length; ix++)
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
                            JMessageBox.Show(this, "Cant create recipes in this list!");
                            return;
                        }
                        if (itemNameIndex == -1)
                        {
                            locked = false;
                            JMessageBox.Show(this, "Cant create recipes in this list!");
                            return;
                        }
                        int recipes_listId = eLC.RecipeListIndex;
                        int targets_1_id_to_make = 0;
                        int targets_1_probability = 0;
                        int targets_Name = 0;
                        int num_to_make = 0;
                        int materials_1_id = 0;
                        int materials_1_num = 0;

                        Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                        for (int ie = 0; ie < eLC.Lists[recipes_listId].elementFields.Length; ie++)
                        {
                            Object data = (Object)eLC.GetDefaultValue(eLC.Lists[recipes_listId].elementTypes[ie].ToString());
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
                                SortedList<int, object> itemValuesClone = new SortedList<int, object>(itemValues);
                                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
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
                                JMessageBox.Show(this, "Cant make recipes from conversation list.");
                                break;
                            }
                        }
                    }

                    locked = false;
                    this.RefreshTaskRecipes();
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

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
                    if (this.dataGridView_item.Rows[e.RowIndex].Cells[2].Tag is ItemDupe)
                    {
                        ItemDupe item = (ItemDupe)this.dataGridView_item.Rows[e.RowIndex].Cells[2].Tag;
                        int Id = item.itemId;
                        if (Id > 0)
                        {
                            ift = Extensions.GetItemProps2(Id, 0, item.listID, item.index);
                        }
                        if (ift != null)
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
                        for (int ix = 0; ix < eLC.Lists[currentList].elementFields.Length; ix++)
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
                            JMessageBox.Show(this, "Cant create recipes in this list!");
                            return;
                        }
                        if (itemNameIndex == -1)
                        {
                            locked = false;
                            JMessageBox.Show(this, "Cant create recipes in this list!");
                            return;
                        }
                        int recipes_listId = eLC.RecipeListIndex;
                        int targets_1_id_to_make = 0;
                        int targets_1_probability = 0;
                        int targets_Name = 0;
                        int num_to_make = 0;
                        int id_upgrade_equip = 0;
                        int upgrade_rate = 0;
                        Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                        for (int ie = 0; ie < eLC.Lists[recipes_listId].elementFields.Length; ie++)
                        {
                            Object data = (Object)eLC.GetDefaultValue(eLC.Lists[recipes_listId].elementTypes[ie].ToString());
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
                                SortedList<int, object> itemValuesClone = new SortedList<int, object>(itemValues);
                                configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
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
                                JMessageBox.Show(this, "Cant make recipes from conversation list.");
                                break;
                            }
                        }
                    }

                    locked = false;
                    this.RefreshTaskRecipes();
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

            }
        }

        private void invertRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
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
                        JMessageBox.Show(this, "You can invert 2 rows value first value becomes second value and so on.");
                    }
                }
            }
        }

        public void CopyToRowsClipboard(Dictionary<int, string> objectToCopy)
        {
            string format = "MyImportingRows";
            Clipboard.Clear();
            Clipboard.SetData(format, objectToCopy);
        }

        protected Dictionary<int, string> GetFromRowsClipboard()
        {
            Dictionary<int, string> doc = null;
            string format = "MyImportingRows";
            if (Clipboard.ContainsData(format))
            {
                doc = (Dictionary<int, string>)Clipboard.GetData(format);
            }
            return doc;
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                if (dataGridView_item.CurrentCell != null)
                {
                    Dictionary<int, string> copyValues = new Dictionary<int, string>();
                    for (int i = 0; i < dataGridView_item.SelectedRows.Count; i++)
                    {
                        int index = dataGridView_item.SelectedRows[i].Index;
                        copyValues[index] = dataGridView_item.Rows[index].Cells[3].Value.ToString();
                    }
                    CopyToRowsClipboard(copyValues);
                }
            }
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null)
            {
                if (dataGridView_item.CurrentCell != null)
                {
                    Dictionary<int, string> copyValues = GetFromRowsClipboard();
                    if (copyValues != null)
                    {
                        foreach (KeyValuePair<int, string> row in copyValues)
                        {
                            dataGridView_item.Rows[row.Key].Cells[3].Value = row.Value;
                        }
                        copyValues = null;
                    }
                    else
                    {
                        JMessageBox.Show(this, "Nothing copied!");
                    }
                }
            }
        }

        private void copySelectedItemsToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null && comboBox_lists.SelectedIndex != -1)
            {
                locked = true;
                List<string> values = new List<string>();
                Export export = new Export();
                export.ListId = -1;
                export.type = 0; //Elements data = 0 | Gshop = 1 
                export.RowCount = eLC.Lists[comboBox_lists.SelectedIndex].elementFields.Length;
                export.Version = eLC.Version;
                export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int index = dataGridView1.SelectedRows[i].Index;
                    int listToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    int itemToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());
                    Export exportx = new Export();
                    exportx.ListId = listToCopyFrom;
                    exportx.type = 0; //Elements data = 0 | Gshop = 1 
                    exportx.Version = eLC.Version;
                    exportx.RowCount = eLC.Lists[exportx.ListId].elementFields.Length;
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
                locked = false;
                listBox_items.Refresh();
            }
        }

        private void exportSkillsToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog eSave = new SaveFileDialog();
            eSave.RestoreDirectory = false;
            eSave.Filter = "Save File (*.txt)|*.txt|All Files (*.*)|*.*";
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

        private void saveToDiskToolStripMenuItem_Click(object sender, EventArgs ex)
        {
            if (lock3) { return; }
            try
            {
                if (LicenceManager.Products[(int)Editors.Fashion_Rip] == 0)
                {
                    JMessageBox.Show(this, "Function disabled on trial.");
                    return;
                }
                if (eLC != null && comboBox_lists.SelectedIndex != -1 && listBox_items.CurrentCell != null && dataGridView_item.CurrentCell != null)
                {
                    lock3 = true;
                    int List = comboBox_lists.SelectedIndex;
                    int Element = listBox_items.CurrentCell.RowIndex;
                    int RowIndex = dataGridView_item.CurrentCell.RowIndex;
                    int[] allowList = new int[] { 3, 6, 22, 38, 57, 59, 83, 94 };
                    string rowName = dataGridView_item.Rows[RowIndex].Cells[1].Value.ToString();

                    // if (allowList.Contains(List))
                    // {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();
                        List<string> paths = new List<string>();
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            int index = listBox_items.SelectedRows[i].Index;
                            string posible_path = eLC.GetValue(List, index, RowIndex);
                            if (rowName.Contains("realname"))
                            {
                                if (List == 83)
                                {
                                    string path1 = @"models\players\装备\女\" + posible_path + "\\zxz.ecm";
                                    paths.Add(path1.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower());
                                    string path2 = @"models\players\装备\男\" + posible_path + "\\zxz.ecm";
                                    paths.Add(path2.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower());
                                }
                            }
                            else
                            {

                                paths.Add(posible_path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower());
                            }
                        }
                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            string savePath = fbd.SelectedPath;
                            //realname = 6
                            //model = 3 22

                            FileRip fr = new FileRip(paths.ToArray(), savePath, eLC.loadedFile);
                            fr.ShowDialog();
                        }
                    }
                    // string temp = @"configs\Reborn\155Weapon\mg\100级青云门剑\100级青云门剑.ecm".Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
                    // string temp2 = @"Shaders\NewBattlePets\Air\风元素\风元素变色.ecm".Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();


                    // Application.Run(new FileRip(new string[] { temp, temp2 }, @"E:\Blue-Dragon\element\Test", @"E:\Blue-Dragon\element\data\elements.data"));

                    //}
                }
            }
            catch { }
            lock3 = false;
        }

        private void ElementsEditor_ResizeBegin(object sender, EventArgs e)
        {
            block(true);
        }

        private void ElementsEditor_ResizeEnd(object sender, EventArgs e)
        {
            showInfo = false;
            block(false);
        }
        /*
        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Replace rp = new Replace();
            rp.ShowDialog(this);
            rp.NewValue
        }
        */
        private void replaceToolStripMenuItem1_Click(object sender, EventArgs ex)
        {
            if (eLC != null)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                int replaced = 0;
                if (e == -1)
                {
                    JMessageBox.Show(this, "Please slect a item!");
                    return;
                }
                if (l != eLC.ConversationListIndex)
                {
                    using (Replace rp = new Replace())
                    {
                        rp.ShowDialog(this);
                        if (Replace.Changed)
                        {
                            if ((JMessageBox.Show(this, "Are you sure you want to replace all selected items?", "Please confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                            {
                                int valueInt = 0;
                                int operation = Replace.replaceIndexType;
                                bool isInt = Int32.TryParse(Replace.NewValue, out valueInt);
                                for (int selectedRowx = 0; selectedRowx < dataGridView_item.SelectedRows.Count; selectedRowx++)
                                {
                                    int selectedRow = dataGridView_item.SelectedRows[selectedRowx].Index;
                                    string valueStr = Replace.NewValue;
                                    for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                                    {
                                        progress_bar("Replacing ...", i, listBox_items.SelectedRows.Count);
                                        int item = listBox_items.SelectedRows[i].Index;
                                        string oldValue = eLC.Lists[l].GetValue(item, selectedRow);
                                        string oldValueText = Replace.OldValue.ToString();
                                        string type = eLC.GetType(l, selectedRow);
                                        string op = "=";
                                        switch (operation)
                                        {
                                            case 0:
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
                                            case 5:
                                                op = "regex";
                                                break;
                                        }
                                        if (operation == 6)
                                        {
                                            try
                                            {
                                                int value = int.Parse(eLC.Lists[l].GetValue(item, selectedRow));
                                                int valuex = int.Parse(oldValueText);
                                                if (value > valuex)
                                                {
                                                    eLC.Lists[l].SetValue(item, selectedRow, valueStr);
                                                    replaced++;
                                                }
                                            }
                                            catch { }
                                        }
                                        else if (operation == 7)
                                        {
                                            try
                                            {
                                                int value = int.Parse(eLC.Lists[l].GetValue(item, selectedRow));
                                                int valuex = int.Parse(oldValueText);
                                                if (value < valuex)
                                                {
                                                    eLC.Lists[l].SetValue(item, selectedRow, valueStr);
                                                    replaced++;
                                                }
                                            }
                                            catch { }
                                        }
                                        else if (op != "regex")
                                        {
                                            if (oldValueText == "*")
                                            {
                                                string calculated = Helper.recalculateElement(type, op, oldValue, valueStr, false);
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
                                                    string calculated = Helper.recalculateElement(type, op, oldValueText, valueStr, false);
                                                    if (calculated.Length > 0)
                                                    {
                                                        eLC.Lists[l].SetValue(item, selectedRow, calculated);
                                                        replaced++;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                Regex x = new Regex(oldValueText);
                                                if (x.IsMatch(oldValue))
                                                {
                                                    string calculated = x.Replace(oldValue, Replace.NewValue);
                                                    eLC.Lists[l].SetValue(item, selectedRow, calculated);
                                                    replaced++;
                                                }
                                            }
                                            catch { }
                                        }
                                    }
                                }
                                progress_bar("Ready", 0, 0);

                                if (replaced > 1)
                                {
                                    JMessageBox.Show(this, "Replaced:" + replaced + " items!");
                                }
                                listBox_items_CellClick(null, null);
                            }
                        }
                    }
                }
                else
                {
                    JMessageBox.Show(this, "Not suported!");
                }

            }
        }

        private void jPictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if (eLC != null)
                {
                    ElementSettings es = new ElementSettings();
                    es.ShowDialog(this);
                    nextautoIdlabel.Text = DatabaseManager.Instance.nextId.ToString();
                }
            }
            catch { }
        }

        private void asignNewIdsToolStripMenuItem_Click(object sender, EventArgs ex)
        {
            if (eLC != null && listBox_items.CurrentCell != null)
            {
                int ListId = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;

                if (ListId != eLC.ConversationListIndex && ListId != -1)
                {
                    lock3 = true;
                    for (int i = listBox_items.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        int index = listBox_items.SelectedRows[i].Index;
                        if (configs.nextAutoNewId == 0)
                        {
                            configs.nextAutoNewId = eLC.getNextFreeId(0, null);
                        }
                        int id_index = 0;
                        configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);

                        eLC.useFreeId(configs.nextAutoNewId, ListId, index);
                        eLC.SetValue(ListId, index, id_index, configs.nextAutoNewId + "");
                        listBox_items.Rows[index].Cells[0].Value = configs.nextAutoNewId + "";
                    }
                }
            }
            lock3 = false;
        }

        private void ShowErrors_Click(object sender, EventArgs e)
        {
            if (eLC != null && eLC.ready)
            {
                ErrorList el = new ErrorList(eLC.errorList.Values.ToList());
                el.Show();
            }
        }
        private PackHelper tpackManager = null;
        private void viewModelToolStripMenuItem_Click(object sender, EventArgs ex)
        {

            if (eLC != null && listBox_items.CurrentCell != null && dataGridView_item.CurrentCell != null)
            {
                try
                {
                    int ListId = comboBox_lists.SelectedIndex;
                    int element = listBox_items.CurrentCell.RowIndex;
                    int RowIndex = dataGridView_item.CurrentCell.RowIndex;
                    string savePath = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "ModelView" + Path.DirectorySeparatorChar + "dataexe";
                    string exe = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "ModelView" + Path.DirectorySeparatorChar + "model.exe";
                    //int[] allowList = new int[] { 3, 6, 22, 38, 57, 59, 83, 94 };
                    if (ListId != -1 && element != -1)
                    {
                        string rowName = dataGridView_item.Rows[RowIndex].Cells[1].Value.ToString();
                        string modelPath = eLC.GetValue(ListId, element, RowIndex);
                        if (rowName.Contains("realname"))
                        {
                            modelPath = "models\\players\\装备\\女\\" + modelPath + "\\dummy.ecm";
                            // modelPath = "models\\players\\装备\\男\\" + modelPath;
                            modelPath = modelPath.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
                            string mainPackName = modelPath.Split(Path.DirectorySeparatorChar)[0] + ".pck";
                            string packPath = Directory.GetParent(Path.GetDirectoryName(eLC.loadedFile)).FullName + Path.DirectorySeparatorChar + mainPackName;
                            bool found = false;
                            tpackManager = PackDatabase.Instance.getManager(mainPackName, packPath, () =>
                            {
                                if (tpackManager != null)
                                {
                                    List<PckEntry> files = tpackManager.getDirectory(Path.GetDirectoryName(modelPath));
                                    string titles = modelPath;
                                    ModelClass model = new ModelClass();

                                    foreach (PckEntry file in files)
                                    {
                                        string extenstion = Path.GetExtension(file.fullP);
                                        if (extenstion.ToLower().Equals(".ski"))
                                        {
                                            model.skyfile = file.bytes;
                                            found = true;
                                        }
                                        if (extenstion.ToLower().Equals(".dds"))
                                        {
                                            model.DDSIMAGE.Add(Path.GetFileName(file.fullP), file.bytes);
                                        }
                                    }
                                    if (found)
                                    {
                                        using (BinaryWriter br = new BinaryWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
                                        {
                                            byte[] title = Encoding.GetEncoding(936).GetBytes(titles);
                                            br.Write(title.Length);
                                            br.Write(title);
                                            br.Write(model.skyfile.Length);
                                            br.Write(model.skyfile);
                                            br.Write(model.DDSIMAGE.Count);
                                            foreach (KeyValuePair<string, byte[]> xxa in model.DDSIMAGE)
                                            {
                                                byte[] titlex = Encoding.GetEncoding(936).GetBytes(xxa.Key);
                                                br.Write(titlex.Length);
                                                br.Write(titlex);
                                                br.Write(xxa.Value.Length);
                                                br.Write(xxa.Value);
                                            }
                                        }
                                        Process.Start(exe);
                                    }
                                }
                            }
                            , true);
                            if (!found)
                            {
                                modelPath = "models\\players\\装备\\男\\" + modelPath + "\\dummy.ecm";
                                // modelPath = "models\\players\\装备\\男\\" + modelPath;
                                modelPath = modelPath.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
                                mainPackName = modelPath.Split(Path.DirectorySeparatorChar)[0] + ".pck";
                                packPath = Directory.GetParent(Path.GetDirectoryName(eLC.loadedFile)).FullName + Path.DirectorySeparatorChar + mainPackName;
                                found = false;
                                tpackManager = PackDatabase.Instance.getManager(mainPackName, packPath, () =>
                                {
                                    if (tpackManager != null)
                                    {
                                        List<PckEntry> files = tpackManager.getDirectory(Path.GetDirectoryName(modelPath));
                                        string titles = modelPath;
                                        ModelClass model = new ModelClass();

                                        foreach (PckEntry file in files)
                                        {
                                            string extenstion = Path.GetExtension(file.fullP);
                                            if (extenstion.ToLower().Equals(".ski"))
                                            {
                                                model.skyfile = file.bytes;
                                                found = true;
                                            }
                                            if (extenstion.ToLower().Equals(".dds"))
                                            {
                                                model.DDSIMAGE.Add(Path.GetFileName(file.fullP), file.bytes);
                                            }
                                        }
                                        if (found)
                                        {
                                            using (BinaryWriter br = new BinaryWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
                                            {
                                                byte[] title = Encoding.GetEncoding(936).GetBytes(titles);
                                                br.Write(title.Length);
                                                br.Write(title);
                                                br.Write(model.skyfile.Length);
                                                br.Write(model.skyfile);
                                                br.Write(model.DDSIMAGE.Count);
                                                foreach (KeyValuePair<string, byte[]> xxa in model.DDSIMAGE)
                                                {
                                                    byte[] titlex = Encoding.GetEncoding(936).GetBytes(xxa.Key);
                                                    br.Write(titlex.Length);
                                                    br.Write(titlex);
                                                    br.Write(xxa.Value.Length);
                                                    br.Write(xxa.Value);
                                                }
                                            }
                                            Process.Start(exe);
                                        }
                                    }
                                }
                                , true);
                            }
                        }
                        else if (!rowName.Contains("realname"))
                        {
                            modelPath = modelPath.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
                            string mainPackName = modelPath.Split(Path.DirectorySeparatorChar)[0] + ".pck";
                            string packPath = Directory.GetParent(Path.GetDirectoryName(eLC.loadedFile)).FullName + Path.DirectorySeparatorChar + mainPackName;
                            tpackManager = PackDatabase.Instance.getManager(mainPackName, packPath, () =>
                            {
                                if (tpackManager != null)
                                {
                                    List<PckEntry> files = tpackManager.getDirectory(Path.GetDirectoryName(modelPath));
                                    string titles = modelPath;
                                    ModelClass model = new ModelClass();
                                    bool found = false;
                                    foreach (PckEntry file in files)
                                    {
                                        string extenstion = Path.GetExtension(file.fullP);
                                        if (extenstion.ToLower().Equals(".ski"))
                                        {
                                            model.skyfile = file.bytes;
                                            found = true;
                                        }
                                        if (extenstion.ToLower().Equals(".dds"))
                                        {
                                            model.DDSIMAGE.Add(Path.GetFileName(file.fullP), file.bytes);
                                        }
                                    }
                                    if (found)
                                    {

                                        using (BinaryWriter br = new BinaryWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
                                        {
                                            byte[] title = Encoding.GetEncoding(936).GetBytes(titles);
                                            br.Write(title.Length);
                                            br.Write(title);
                                            br.Write(model.skyfile.Length);
                                            br.Write(model.skyfile);
                                            br.Write(model.DDSIMAGE.Count);
                                            foreach (KeyValuePair<string, byte[]> xxa in model.DDSIMAGE)
                                            {
                                                byte[] titlex = Encoding.GetEncoding(936).GetBytes(xxa.Key);
                                                br.Write(titlex.Length);
                                                br.Write(titlex);
                                                br.Write(xxa.Value.Length);
                                                br.Write(xxa.Value);
                                            }

                                        }

                                        Process.Start(exe);
                                    }
                                }
                            }
                            , true);

                        }
                    }
                }
                catch { }

            }
            /*            
            if (!File.Exists(path))
                return;
            BinaryReader binaryReader = new BinaryReader((Stream)new MemoryStream(File.ReadAllBytes(path)));
            ModelClass modelClass = new ModelClass();
            string title = Encoding.GetEncoding(936).GetString(binaryReader.ReadBytes(binaryReader.ReadInt32()));
            modelClass.skyfile = binaryReader.ReadBytes(binaryReader.ReadInt32());
            int num = binaryReader.ReadInt32();
            for (int index = 0; index < num; ++index)
            {
                string key = Encoding.GetEncoding(936).GetString(binaryReader.ReadBytes(binaryReader.ReadInt32()));
                byte[] numArray = binaryReader.ReadBytes(binaryReader.ReadInt32());
                modelClass.DDSIMAGE.Add(key, numArray);
            }
            */
        }

        private void listBox_items_CellValueNeeded(object sender, DataGridViewCellValueEventArgs data)
        {
            if (locked) return;
            locked = true;
            // listBox_items.SuspendLayout();
            // listBox_items();
            int l = comboBox_lists.SelectedIndex;
            if (eLC != null && l != -1 && eLC.Lists[l].ItemIdIndex != -1 && eLC.Lists[l].itemNameIndex != -1)
            {
                int e = data.RowIndex;
                if (l != eLC.ConversationListIndex)
                {
                    if (eLC.Lists[l].elementValues.Count != 0)
                    {
                        int elemnet_id = Int32.Parse(eLC.GetValue(l, e, eLC.Lists[l].ItemIdIndex));
                        string path = "";
                        switch (data.ColumnIndex)
                        {
                            case 0:
                                data.Value = elemnet_id;
                                //listBox_items.Rows[e].ReadOnly = false;
                                break;
                            case 1:
                                path = Path.GetFileName(eLC.GetValue(l, e, eLC.Lists[l].itemIconIndex));
                                if (ElementsEditor.database.ContainsKey(path))
                                {
                                    if (ElementsEditor.database.ContainsKey(path))
                                    {
                                        data.Value = ElementsEditor.database.images(path);
                                    }
                                    else
                                    {
                                        data.Value = Resources.blank;
                                    }

                                }
                                else { data.Value = Resources.blank; }
                                break;
                            case 2:
                                data.Value = eLC.GetValue(l, e, eLC.Lists[l].itemNameIndex);
                                break;
                        }
                    }
                }
                else
                {
                    switch (data.ColumnIndex)
                    {
                        case 0:
                            data.Value = conversationList.Dialogs[e].DialogID;
                            // listBox_items.Rows[e].ReadOnly = true;
                            break;
                        case 1:
                            data.Value = Resources.blank;
                            break;
                        case 2:
                            data.Value = conversationList.Dialogs[e].DialogID + " - Dialog";
                            break;
                    }
                }
            }
            //   listBox_items.ResumeLayout();
            // listBox_items.PerformLayout();
            locked = false;
        }

        private void jPictureBox5_MouseHover(object sender, EventArgs e)
        {
            Tools.Show();
        }

        private void jPictureBox5_MouseLeave(object sender, EventArgs e)
        {
            Tools.Hide();
        }

        private void exportIconsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bookMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC == null)
            {
                JMessageBox.Show(this, "Element file not loaded!");
                return;
            }
            if (comboBox_lists.SelectedIndex < 0)
            {
                JMessageBox.Show(this, "Element file not loaded!");
                return;
            }
            if (dataGridView_item.CurrentCell == null)
            {
                JMessageBox.Show(this, "No rows are selected!");
                return;
            }
            if (listBox_items.CurrentCell == null)
            {
                JMessageBox.Show(this, "No item is slected!");
                return;
            }
            BookMark bk = new BookMark();
            bk.editorID = Constatns.elementEditorId;
            bk.listIndex = comboBox_lists.SelectedIndex;
            bk.elementIndex = listBox_items.CurrentCell.RowIndex;
            bk.rowIndex = dataGridView_item.CurrentCell.RowIndex;
            bk.name = comboBox_lists.Items[bk.listIndex].ToString() + "[" + eLC.GetValue(bk.listIndex, bk.elementIndex, 0) + "]";
            DatabaseManager.Instance.AddBook(bk);
            HashSet<BookMark> books = DatabaseManager.Instance.BookMars;
            goToToolStripMenuItem.DropDown.Items.Clear();
            foreach (BookMark book in books)
            {
                ToolStripItem tsi = new ToolStripMenuItem();
                tsi.Text = book.name;
                tsi.Image = Resources.View;
                tsi.Tag = book;
                tsi.MouseDown += JumpToItem;
                goToToolStripMenuItem.DropDown.Items.Add(tsi);
            }
        }

        private void listBox_items_DragDrop(object sender, DragEventArgs e)
        {
            if (isExporting) return;
            int ltc = 0;
            int i = 0;
            int list = comboBox_lists.SelectedIndex;
            versionMistmatch = false;
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists(FileList[0]))
            {
                byte[] bytes = File.ReadAllBytes(FileList[0]);
                BinaryFormatter binFormat = new BinaryFormatter();
                Export importObject = binFormat.Deserialize(new MemoryStream(bytes)) as Export;
                if (eLC != null && importObject != null && importObject.data != null && importObject.data.Count > 0)
                {
                    lock3 = true;
                    progress_bar("Importing ...", 0, 0);
                    int actual_elements_Count = 0;
                    int import_elements_Count = 0;
                    if (importObject.ListId != -1)
                    {
                        actual_elements_Count = eLC.Lists[importObject.ListId].elementFields.Length;
                        import_elements_Count = importObject.RowCount;
                        if (BrakeImport(actual_elements_Count, import_elements_Count, importObject.ListId, importObject.Version))
                        {
                            return;
                        }
                        comboBox_lists.SelectedIndex = importObject.ListId;
                        ltc = importObject.ListId;
                        // Application.DoEvents();
                        comboBox_lists.Enabled = false;
                        listBox_items.Enabled = false;
                        locked = true;
                        if (ElementsEditor.isImportWithDelete)
                        {
                            eLC.Lists[importObject.ListId].elementValues = new SortedList<int, SortedList<int, object>>();
                        }
                    }
                    ConvertElements importRules = configs.GetExportConfig(eLC.Version, importObject.Version);

                    int lastIdList = 0;
                    foreach (KeyValuePair<int, object> entryx in importObject.data)
                    {
                        // Application.DoEvents();
                        progress_bar("Importing ...", i, importObject.data.Count);
                        if (entryx.Value is Export)
                        {
                            Export datxzx = (Export)entryx.Value;
                            actual_elements_Count = eLC.Lists[datxzx.ListId].elementFields.Length;
                            import_elements_Count = datxzx.RowCount;

                            if (ElementsEditor.isImportWithDelete && lastIdList != datxzx.ListId)
                            {
                                eLC.Lists[datxzx.ListId].elementValues = new SortedList<int, SortedList<int, object>>();
                            }
                            lastIdList = datxzx.ListId;

                            if (BrakeImport(actual_elements_Count, import_elements_Count, datxzx.ListId, datxzx.Version))
                            {
                                return;
                            }
                            bool isDone = false;
                            foreach (KeyValuePair<int, object> subentry in datxzx.data)
                            {
                                if (DealWithImportedItem(datxzx, subentry, versionMistmatch, importRules))
                                {
                                    isDone = true;
                                }
                            }
                            if (isDone)
                                i++;
                        }
                        else
                        {
                            if (DealWithImportedItem(importObject, entryx, versionMistmatch, importRules))
                            {
                                i++;
                            }
                        }

                    }

                    this.RefreshTaskRecipes();
                    locked = false;
                    lock3 = false;
                    comboBox_lists.Enabled = true;
                    listBox_items.Enabled = true;
                    try
                    {
                        Change_list(null, null);
                        listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[ltc].elementValues.Count - 1].Cells[0];
                        listBox_items_CellClick(null, null);
                    }
                    catch { }
                    progress_bar("Ready", 0, 0);
                }
                else
                {
                    JMessageBox.Show(this, "Somthing went wrong with the export, please try again!");
                }
            }
            locked = false;
        }

        private void listBox_items_DragEnter(object sender, DragEventArgs e)
        {
            if (listBox_items.SelectedRows.Count > 0 && eLC != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private bool isExporting = false;
        private void listBox_items_DragLeave(object sender, EventArgs e)
        {
            //DROP ON DESKTOP
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            int l = comboBox_lists.SelectedIndex;
            int xe = listBox_items.CurrentCell.RowIndex;
            if (xe > -1)
            {
                isExporting = true;
                try
                {
                    locked = lock3 = true;

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
                        var tempFilePath = Path.Combine(Path.GetTempPath(), comboBox_lists.Items[l].ToString() + "_" + export.data.Count + "_" + export.Version + "_" + Time.timeStampMilisecond + ".save");
                        byte[] databytes = export.Serialize();
                        File.WriteAllBytes(tempFilePath, databytes);
                        string[] files = { tempFilePath };
                        DataObject objectx = new DataObject(DataFormats.FileDrop, files);
                        DoDragDrop(objectx, DragDropEffects.Copy);
                        progress_bar("Ready", 0, 0);
                        File.Delete(tempFilePath);
                    }

                    locked = lock3 = false;
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

            }
            locked = lock3 = false;
            isExporting = false;
        }

        private DataGridViewRow rw;
        private int rowIndexFromMouseDown;
        private float mouseDown_time = 0;

        private void listBox_items_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && eLC != null)
            {
                mouseDown_time = Time.time;
            }
            else
            {
                mouseDown_time = 0;
            }
        }

        private void listBox_items_MouseMove(object sender, MouseEventArgs e)
        {
            if (listBox_items.SelectedRows != null && listBox_items.SelectedRows.Count >= 0 && eLC != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    rw = listBox_items.SelectedRows[0];
                    rowIndexFromMouseDown = listBox_items.SelectedRows[0].Index;
                    listBox_items.DoDragDrop(rw, DragDropEffects.Move);
                }
                else
                {
                    mouseDown_time = 0;
                }
            }
        }

        private void listBox_items_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lock3) { return; }
            if (Time.time > MouseEnterTime && !showInfo)
            {
                try
                {
                    if (customTooltype != null)
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
                        if (ift != null)
                        {
                            ift.description = Extensions.ColorClean(Extensions.ItemDesc(Id));
                            customTooltype = new IToolType(ift);
                            customTooltype.Show();
                            showInfo = true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        private float MouseEnterTime = 0;
        private bool showInfo = false;
        public bool isAutoOpen = false;
        public string autoOpenPath = "";

        private void listBox_items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                MouseEnterTime = Time.time + 0.1f;
            }
        }

        private void listBox_items_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (lock3) { return; }
            if (customTooltype != null)
            {
                customTooltype.Close();
                showInfo = false;
            }
        }

        private void ElementsEditor_Leave(object sender, EventArgs e)
        {
            showInfo = false;
        }

        private void ElementsEditor_Shown(object sender, EventArgs e)
        {
            if (isAutoOpen)
            {
                if (LicenceManager.type == LICENCETYPE.TIMED)
                {
                    if (LicenceManager.TimeLeft <= 0)
                    {
                        MainProgram.getInstance().ExitInvoke();
                    }
                }
                if (LicenceManager.type == LICENCETYPE.PERMANENT)
                {
                    if (LicenceManager.TimeLeft > 0)
                    {
                        MainProgram.getInstance().ExitInvoke();
                    }
                }
                try
                {
                    locked = true;
                    lock3 = true;
                    AnythingChanged = false;
                    try
                    {
                        block(true);
                        if (eLC != null)
                            eLC.CancelAllTasks();

                        eLC = new eListCollection();
                        eLC.ready = false;
                        eLC.progress_bar += progress_bar;
                        configs.lastElementsLocation = autoOpenPath;
                        eLC.Lists = eLC.Load(autoOpenPath);
                        DatabaseManager.Instance._NAME = autoOpenPath.ToLower();
                        nextautoIdlabel.Text = eLC.getNextFreeId(DatabaseManager.Instance.nextId, nextautoIdlabel) + "";
                        pathLabel.Text = autoOpenPath;
                        //  mouseDown_time = Time.time;
                        if (DatabaseManager.Instance.AutoLoadPck)
                            DatabaseManager.Instance.CreateNewDatabase(autoOpenPath, eLC.Version);
                        else
                            DatabaseManager.Instance.SetVersion(eLC.Version);

                        if (eLC.ConversationListIndex > -1 && eLC.Lists.Length > eLC.ConversationListIndex)
                        {
                            conversationList = new eListConversation((byte[])eLC.Lists[eLC.ConversationListIndex].elementValues[0][0]);
                        }
                        // Application.DoEvents();
                        dataGridView_item.Rows.Clear();
                        listBox_items.Rows.Clear();
                        comboBox_lists.Items.Clear();

                        // List<string> autoCompleate = new List<string>();
                        for (int l = 0; l < eLC.Lists.Length; l++)
                        {
                            comboBox_lists.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase("[" + l + "] " + eLC.Lists[l].listName.ToLower().Replace('_', ' ')));

                        }
                        goToToolStripMenuItem.DropDown.Items.Clear();
                        HashSet<BookMark> books = DatabaseManager.Instance.BookMars;
                        foreach (BookMark book in books)
                        {
                            ToolStripItem tsi = new ToolStripMenuItem();
                            tsi.Text = book.name;
                            tsi.Image = Resources.View;
                            tsi.Tag = book;
                            tsi.MouseDown += JumpToItem;
                            goToToolStripMenuItem.DropDown.Items.Add(tsi);
                        }
                        //goToToolStripMenuItem.DropDown.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(eLC.Lists[l].listName.ToLower().Replace('_', ' ')), Resources.View);
                        //comboBox_lists.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                        //comboBox_lists.AutoCompleteCustomSource.AddRange(autoCompleate.ToArray());
                        // Application.DoEvents();
                        //path_label.Text = eLoad.FileName;
                        version_label.Text = eLC.Version.ToString();

                        // Application.DoEvents();
                        block(false);
                        locked = false;
                        lock3 = false;
                        comboBox_lists.SelectedIndex = 0;
                        if (eLC.Lists[comboBox_lists.SelectedIndex].elementValues.Count == 0) { return; }
                        comboBox_lists.SelectedIndex = 0;
                        listBox_items.Rows[0].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                        locked = false;
                        lock3 = false;
                        listBox_items_CellClick(null, null);
                        Loadelements();
                        pathLabel.Visible = true;
                        //  mouseDown_time = Time.time;
                    }
                    catch (Exception ex)
                    {
                        JMessageBox.Show(this, "LOADING ERROR!\nThis error mostly occurs of configuration and elements.data mismatch" + ex.ToString());
                        pathLabel.Visible = false;
                        eLC.ready = false;
                    }
                    block(false);
                    locked = false;
                    lock3 = false;
                    //  mouseDown_time = Time.time;
                }
                catch { }
            }
            this.Focus();
        }

        private void listBox_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int l = comboBox_lists.SelectedIndex;
            if (eLC != null && l != -1)
            {
                if (l != eLC.ConversationListIndex)
                {
                    listBox_items.Rows[e.RowIndex].Cells[0].ReadOnly = false;
                }
                else
                {
                    listBox_items.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                }
            }
        }
        private ImportConfigEditor replaceEditor;
        private void importConfigsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replaceEditor != null)
            {
                replaceEditor.Show();
            }
            else
            {
                replaceEditor = new ImportConfigEditor();
                replaceEditor.Show();
            }

        }

        private void loadRequiredFilesFrompckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null && configs.lastElementsLocation != null && configs.lastElementsLocation.Length > 0)
                DatabaseManager.Instance.CreateNewDatabase(configs.lastElementsLocation, eLC.Version);
        }

        private void dataGridView_item_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_item.CurrentCell != null)
                SelectedRow = dataGridView_item.CurrentCell.RowIndex;
        }

        private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog eSave = new SaveFileDialog();
            eSave.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            try
            {
                string start = ((ToolStripMenuItem)sender).Text.Split('>')[1].ToString();
                eSave.FileName = "elements_" + start.TrimStart().TrimEnd().Replace("PW_", "") + ".data";
            }
            catch { }
            if (eSave.ShowDialog() == DialogResult.OK && eSave.FileName != "")
            {
                try
                {


                    // Cursor = Cursors.WaitCursor;

                    string rulesFile = Application.StartupPath + "\\Configs\\Element\\rules\\" + ((ToolStripMenuItem)sender).Text.Replace("=>", "=") + ".rules";
                    eLC.Export(rulesFile, eSave.FileName);

                    // Cursor = Cursors.Default;
                }
                catch
                {
                    MessageBox.Show("EXPORTING ERROR!\nThis error mostly occurs if selected rules fileset is invalid");
                    Cursor = Cursors.Default;
                }
            }
        }

        private void JPictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                Control btnSender = (Control)sender;
                Point ptLowerLeft = new Point(0, btnSender.Height);
                ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
                Tools.Show(ptLowerLeft);
            }
            catch { }
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lock3 || eLC == null || comboBox_lists.SelectedIndex == -1) { return; }
            exportClipboardwithNorules();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                jComboBox1.Visible = true;
                jTextBox1.Visible = true;
                //  button5.Visible = true;
            }
            else
            {
                jComboBox1.Visible = false;
                jTextBox1.Visible = false;
                // button5.Visible = false;
            }
        }

        private void FindDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex && dataGridView_item.SelectedRows != null)
            {
                dataGridView1.Rows.Clear();
                int nameIndex = -1;
                List<int> selctedRows = new List<int>();
                for (int i = 0; i < dataGridView_item.SelectedRows.Count; i++)
                {
                    int index = dataGridView_item.SelectedRows[i].Index;
                    selctedRows.Add(index);
                }
                if (nameIndex == -1)
                {
                    for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                    {
                        if (eLC.Lists[list].elementFields[f].Equals("Name"))
                        {
                            nameIndex = f;
                        }
                        if (nameIndex != -1)
                        {
                            break;
                        }
                    }
                }
                for (int i = 0; i < selctedRows.Count; i++)
                {
                    HashSet<string> data = new HashSet<string>();
                    for (int f = 0; f < eLC.Lists[list].elementValues.Count; f++)
                    {
                        string value1 = eLC.Lists[list].GetValue(f, selctedRows[i]);
                        if (!data.Add(value1))
                        {
                            string namex = nameIndex == -1 ? "" : eLC.Lists[list].GetValue(f, nameIndex);
                            dataGridView1.Rows.Add(new object[] { eLC.Lists[list].elementFields[selctedRows[i]], namex, value1, list, f, selctedRows[i] });
                        }
                    }

                }
                jGroupBox2.Text = "Found " + dataGridView1.Rows.Count + " duplicates.";
                try
                {
                    elementIntoTab.SelectTab("tabPage4");
                }
                catch { }
            }
        }

        private void DeleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eLC != null && comboBox_lists.SelectedIndex != -1)
            {
                locked = true;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int index = dataGridView1.SelectedRows[i].Index;
                    int listToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
                    int itemToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());
                    if (listToCopyFrom != eLC.ConversationListIndex)
                    {
                        eLC.Lists[listToCopyFrom].RemoveItem(listToCopyFrom, itemToCopyFrom);
                        eLC.Lists[listToCopyFrom].elementValues = resortDic(eLC.Lists[listToCopyFrom].elementValues);
                    }
                    progress_bar("Removing...", i, dataGridView1.SelectedRows.Count);
                }
                this.RefreshTaskRecipes();
                locked = false;
                Change_list(null, null);
                progress_bar("Ready", 0, 0);
            }
        }

        private void ASKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                int nameIndex = -1;
                int itemIdIndex = -1;
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f] == "ID")
                    {
                        itemIdIndex = f;
                    }
                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                    {
                        nameIndex = f;
                    }
                    if (nameIndex != -1 && itemIdIndex != -1)
                    {
                        break;
                    }
                }
                var items = eLC.Lists[list].elementValues.OrderBy(r => r.Value[itemIdIndex]).ThenBy(r => r.Key);
                SortedList<int, SortedList<int, object>> datanew = new SortedList<int, SortedList<int, object>>();
                int i = 0;
                foreach (KeyValuePair<int, SortedList<int, object>> entry in items)
                {
                    datanew[i] = entry.Value;
                    i++;
                }
                eLC.Lists[list].elementValues = datanew;
                Change_list(null, null);
            }
        }

        private void DSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                int nameIndex = -1;
                int itemIdIndex = -1;
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f] == "ID")
                    {
                        itemIdIndex = f;
                    }
                    if (eLC.Lists[list].elementFields[f].Equals("Name"))
                    {
                        nameIndex = f;
                    }
                    if (nameIndex != -1 && itemIdIndex != -1)
                    {
                        break;
                    }
                }
                var items = eLC.Lists[list].elementValues.OrderByDescending(r => r.Value[itemIdIndex]).ThenBy(r => r.Key);
                SortedList<int, SortedList<int, object>> datanew = new SortedList<int, SortedList<int, object>>();
                int i = 0;
                foreach (KeyValuePair<int, SortedList<int, object>> entry in items)
                {
                    datanew[i] = entry.Value;
                    i++;
                }
                eLC.Lists[list].elementValues = datanew;
                Change_list(null, null);
            }
        }

        private void CopyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportClipboardwithNorules();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElementsEditor.isImportcanceled = true;
            ImportOption io = new ImportOption();
            io.ShowDialog(this);
            if (!ElementsEditor.isImportcanceled)
            {
                importItemsWithRulesFromClipBoard();
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows != null)
                {
                    listBox_items.ClearSelection();
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int index = dataGridView1.SelectedRows[i].Index;
                        int listToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[3].Value.ToString());
                        int itemToCopyFrom = int.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());
                        if (listToCopyFrom == comboBox_lists.SelectedIndex)
                        {
                            listBox_items.Rows[itemToCopyFrom].Selected = true;
                            //listBox_items.CurrentCell = listBox_items.Rows[itemToCopyFrom].Cells[0];
                        }
                    }

                }
            }
            catch { }
        }

        private void RecalculateDropsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (list == 38)
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("drop_matters") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }
                    }
                    else if (list == 207)
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("award") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 2);
                        }
                    }
                    else
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("materials") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }

                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("addons") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_addon")
                        || eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("task") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id")
                        || eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("materials") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id")
                        || eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("list") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }
                    }
                }

                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    progress_bar("Calculating ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    List<int> itemsIds_real = new List<int>();
                    List<int> new_Indexes = new List<int>();
                    for (int i = 0; i < itemsIds.Count; i++)
                    {
                        int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                        if (value != 0)
                        {
                            itemsIds_real.Add(value);
                            new_Indexes.Add(probabilityIds[i]);
                        }
                    }

                    if (itemsIds_real.Count != 0)
                    {
                        float probability = 1f / itemsIds_real.Count;

                        for (int i = 0; i < new_Indexes.Count; i++)
                        {
                            eLC.SetValue(list, idx, new_Indexes[i], probability.ToString());
                        }

                    }
                }
                progress_bar("Ready", 0, 0);
                listBox_items_CellClick(null, null);
            }
        }

        private float GetFloatConverter()
        {
            return 0;
        }

        private void DropSelectedFasterMobsAndMine(int selectedRow)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (list == 38)
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("drop_matters") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }
                    }
                    else if (list == 207)
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("award") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 2);
                        }
                    }
                    else
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("addons") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_addon")
|| eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("task") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id")
|| eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("materials") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id")
|| eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("list") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))

                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }
                    }
                }
                int rowConvIndex = 0;
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    progress_bar("Calculating ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    List<int> itemsIds_real = new List<int>();
                    List<int> new_Indexes = new List<int>();
                    List<float> prob_Indexes = new List<float>();
                    for (int i = 0; i < itemsIds.Count; i++)
                    {
                        int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                        float probvalue = float.Parse(eLC.GetValue(list, idx, probabilityIds[i]));
                        if (value != 0)
                        {
                            itemsIds_real.Add(value);
                            new_Indexes.Add(probabilityIds[i]);
                            if (probabilityIds[i] == selectedRow)
                                rowConvIndex = i;

                            prob_Indexes.Add(probvalue);
                        }
                    }
                    if (itemsIds_real.Count != 0)
                    {
                        for (int i = 0; i < new_Indexes.Count; i++)
                        {
                            float probability = 0;
                            if (selectedRow == new_Indexes[i])
                                probability = prob_Indexes[rowConvIndex] * 2;
                            else
                                probability = (prob_Indexes[i] - (prob_Indexes[rowConvIndex] / (itemsIds_real.Count - 1)));
                            eLC.SetValue(list, idx, new_Indexes[i], probability.ToString());
                        }
                    }
                }
                progress_bar("Ready", 0, 0);
                listBox_items_CellClick(null, null);
            }
        }

        private void DropSelectedFasterAdonOrRands(int selectedRow, bool isRands)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (isRands)
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("rands") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_rand"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }
                    }
                    else
                    {
                        if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("addons") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_addon"))
                        {
                            itemsIds.Add(f);
                            probabilityIds.Add(f + 1);
                        }
                    }
                }
                int rowConvIndex = 0;
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    progress_bar("Calculating ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    List<int> itemsIds_real = new List<int>();
                    List<int> new_Indexes = new List<int>();
                    List<float> prob_Indexes = new List<float>();
                    for (int i = 0; i < itemsIds.Count; i++)
                    {
                        int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                        float probvalue = float.Parse(eLC.GetValue(list, idx, probabilityIds[i]));
                        if (value != 0)
                        {
                            itemsIds_real.Add(value);
                            new_Indexes.Add(probabilityIds[i]);
                            if (probabilityIds[i] == selectedRow)
                                rowConvIndex = i;

                            prob_Indexes.Add(probvalue);
                        }
                    }
                    if (itemsIds_real.Count != 0)
                    {
                        for (int i = 0; i < new_Indexes.Count; i++)
                        {
                            float probability = 0;
                            if (selectedRow == new_Indexes[i])
                                probability = prob_Indexes[rowConvIndex] * 2;
                            else
                                probability = (prob_Indexes[i] - (prob_Indexes[rowConvIndex] / (itemsIds_real.Count - 1)));
                            eLC.SetValue(list, idx, new_Indexes[i], probability.ToString());
                        }
                    }
                }
                progress_bar("Ready", 0, 0);
                listBox_items_CellClick(null, null);
            }
        }

        private void DropSelectedAddonFasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex && dataGridView_item.CurrentCell != null)
            {
                if (eLC.CanShopProbabilityMenu(list))
                {
                    int rowIndex_now = dataGridView_item.CurrentCell.RowIndex;
                    string rowValue = dataGridView_item.Rows[rowIndex_now].Cells[1].Value.ToString();
                    if (rowValue.ToLower().Contains("materials") && rowValue.ToLower().Contains("id")
                        || rowValue.ToLower().Contains("task") && rowValue.ToLower().Contains("id")
                        || rowValue.ToLower().Contains("list") && rowValue.ToLower().Contains("id")
                        || rowValue.ToLower().Contains("addons") && rowValue.ToLower().Contains("id")
                     )
                    {
                        DropSelectedFasterMobsAndMine((rowIndex_now + 1));
                    }
                    else if (rowValue.ToLower().Contains("award") && rowValue.ToLower().Contains("id"))
                    {
                        DropSelectedFasterMobsAndMine((rowIndex_now + 2));
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please select the item you want to drop more!");
                    }
                }
                else if (list == 3 || list == 6 || list == 9)
                {
                    int rowIndex_now = dataGridView_item.CurrentCell.RowIndex;
                    string rowValue = dataGridView_item.Rows[rowIndex_now].Cells[1].Value.ToString();
                    if (rowValue.ToLower().Contains("rands") && rowValue.ToLower().Contains("id rand"))
                    {
                        DropSelectedFasterAdonOrRands((rowIndex_now + 1), true);
                    }
                    else if (rowValue.ToLower().Contains("addons") && rowValue.ToLower().Contains("id addon"))
                    {
                        DropSelectedFasterAdonOrRands((rowIndex_now + 1), false);
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please select the item you want to drop more!");
                    }
                }
            }
        }

        private void RecalculateAdonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("addons") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_addon"))
                    {
                        itemsIds.Add(f);
                        probabilityIds.Add(f + 1);
                    }
                }

                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    progress_bar("Calculating ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    List<int> itemsIds_real = new List<int>();
                    List<int> new_Indexes = new List<int>();
                    for (int i = 0; i < itemsIds.Count; i++)
                    {
                        int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                        if (value != 0)
                        {
                            itemsIds_real.Add(value);
                            new_Indexes.Add(probabilityIds[i]);
                        }
                    }

                    if (itemsIds_real.Count != 0)
                    {
                        float probability = 1f / itemsIds_real.Count;

                        for (int i = 0; i < new_Indexes.Count; i++)
                        {
                            eLC.SetValue(list, idx, new_Indexes[i], probability.ToString());
                        }

                    }
                }
                progress_bar("Ready", 0, 0);
                listBox_items_CellClick(null, null);
            }
        }

        private void RecalculateRandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("rands") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_rand"))
                    {
                        itemsIds.Add(f);
                        probabilityIds.Add(f + 1);
                    }
                }

                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    progress_bar("Calculating ...", x, listBox_items.SelectedRows.Count);
                    int idx = listBox_items.SelectedRows[x].Index;
                    List<int> itemsIds_real = new List<int>();
                    List<int> new_Indexes = new List<int>();
                    for (int i = 0; i < itemsIds.Count; i++)
                    {
                        int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                        if (value != 0)
                        {
                            itemsIds_real.Add(value);
                            new_Indexes.Add(probabilityIds[i]);
                        }
                    }

                    if (itemsIds_real.Count != 0)
                    {
                        float probability = 1f / itemsIds_real.Count;

                        for (int i = 0; i < new_Indexes.Count; i++)
                        {
                            eLC.SetValue(list, idx, new_Indexes[i], probability.ToString());
                        }

                    }
                }
                progress_bar("Ready", 0, 0);
                listBox_items_CellClick(null, null);
            }
        }

        private void ShowSumeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("rands") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_rand"))
                    {
                        itemsIds.Add(f);
                        probabilityIds.Add(f + 1);
                    }
                }
                int idx = listBox_items.CurrentCell.RowIndex;
                List<int> itemsIds_real = new List<int>();
                List<int> new_Indexes = new List<int>();
                float total = 0;
                for (int i = 0; i < itemsIds.Count; i++)
                {
                    int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                    float valuex = float.Parse(eLC.GetValue(list, idx, probabilityIds[i]));
                    if (value != 0)
                    {
                        total += valuex;
                        new_Indexes.Add(probabilityIds[i]);
                    }
                }
                JMessageBox.Show(this, "The rands total is:" + total.ToString());
            }
        }

        private void ShowSumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("addons") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_addon"))
                    {
                        itemsIds.Add(f);
                        probabilityIds.Add(f + 1);
                    }
                }
                int idx = listBox_items.CurrentCell.RowIndex;
                List<int> itemsIds_real = new List<int>();
                List<int> new_Indexes = new List<int>();
                float total = 0;
                for (int i = 0; i < itemsIds.Count; i++)
                {
                    int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                    float valuex = float.Parse(eLC.GetValue(list, idx, probabilityIds[i]));
                    if (value != 0)
                    {
                        total += valuex;
                        new_Indexes.Add(probabilityIds[i]);
                    }
                }
                JMessageBox.Show(this, "The addons total is:" + total.ToString());
            }
        }

        public class ImageSave
        {
            public string name = "";
            public string description = "";
            public string imageb64 = "";
        }
        private void ExportIconsForPWAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Task.Run(() =>
                    {
                        // int test = 1000;
                        int count = ElementsEditor.database.task_items.Values.Count;
                        int i = 0;
                        foreach (KeyValuePair<int, ItemDupe> data in ElementsEditor.database.task_items)
                        {
                            //Debug


                            string path = Path.GetFileName(data.Value.iconpath);
                            string text = Extensions.GetItemProps(data.Value.itemId, 0).Replace("\r\n", "<br>").Replace("\n", "<br>").Replace("\r", "<br>");
                            string imageb64 = "";
                            Bitmap image = null;
                            if (ElementsEditor.database.ContainsKey(path))
                            {
                                image = ElementsEditor.database.images(path);
                            }
                            if (image != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    using (var bitmap = new Bitmap(image))
                                    {
                                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        imageb64 = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                                    }
                                }
                            }
                            ImageSave save = new ImageSave();
                            int itemID = 0;
                            if (ElementsEditor.database.item_color.ContainsKey(data.Value.itemId))
                            {
                                itemID = ElementsEditor.database.item_color[data.Value.itemId];
                            }
                            Color color = Helper.getByID(itemID);
                            Color tmp = Color.White;
                            save.name = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("<font color=\"" + ColorTranslator.ToHtml(color) + "\">" + data.Value.name + "</font>"));
                            string[] blocks = text.Split(new char[] { '^' });
                            string resultx = "";
                            if (blocks.Length > 1)
                            {
                                if (blocks[0] != "")
                                {
                                    resultx += blocks[0];
                                }
                                for (int x = 1; x < blocks.Length; x++)
                                {
                                    if (blocks[x] != "")
                                    {
                                        try
                                        {
                                            if (blocks[x].Substring(0, 6).ToUpper() == "FFFFFF")
                                            {
                                                color = tmp;
                                            }
                                            else
                                            {
                                                color = Color.FromArgb(int.Parse(blocks[x].Substring(0, 6), NumberStyles.HexNumber));
                                            }
                                            resultx += "<font color=\"" + ColorTranslator.ToHtml(color) + "\">";
                                            resultx += string.Format(blocks[x].Substring(6)) + "</font>";
                                        }
                                        catch
                                        {
                                            resultx += string.Format("^" + blocks[x]);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                resultx = text;
                            }
                            save.description = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(resultx));
                            save.imageb64 = imageb64;
                            string datasave = JsonConvert.SerializeObject(save);
                            File.WriteAllText(Path.Combine(fbd.SelectedPath, data.Value.itemId + ".data"), datasave);
                            progress_bar("Saving..", i, count);
                            i++;
                        }
                        progress_bar("Ready", 0, 100);
                    });
                }
                progress_bar("Ready", 0, 100);
            }
        }

        private void MakePetEggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DROP ON DESKTOP
            if (comboBox_lists.SelectedIndex == -1)
            {
                progress_bar("Please select items to make eg!", 0, 0);
                return;
            }
            if (listBox_items.SelectedRows == null)
            {
                progress_bar("Please select items to make eg!", 0, 0);
                return;
            }
            if (eLC != null && comboBox_lists.SelectedIndex != -1)
            {
                locked = true;
                int l = comboBox_lists.SelectedIndex;
                int pl = comboBox_lists.SelectedIndex + 1;
                Dictionary<int, Object> itemValues = new Dictionary<int, Object>();
                for (int ie = 0; ie < eLC.Lists[pl].elementFields.Length; ie++)
                {
                    Object data = (Object)eLC.GetDefaultValue(eLC.Lists[pl].elementTypes[ie].ToString());
                    itemValues.Add(ie, data);
                }
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < selected.Count; x++)
                {
                    int index = selected[x].Index;
                    int itemId = int.Parse(eLC.GetValue(l, index, 0));
                    int itemtype = int.Parse(eLC.GetValue(l, index, 1));
                    string itemName = eLC.GetValue(l, index, 2) + " Egg";
                    string Icon = eLC.GetValue(l, index, 4);
                    SortedList<int, object> itemValuesClone = new SortedList<int, object>(itemValues);
                    configs.nextAutoNewId = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                    itemValuesClone[0] = configs.nextAutoNewId;
                    eLC.useFreeId(configs.nextAutoNewId, pl, eLC.Lists[pl].elementValues.Count);
                    int newIndex = eLC.AddItem(pl, itemValuesClone);
                    eLC.SetValue(pl, newIndex, 0, configs.nextAutoNewId.ToString());
                    eLC.SetValue(pl, newIndex, 1, itemName);
                    eLC.SetValue(pl, newIndex, 2, @"Models\Matters\物品\宠物蛋\宠物蛋.ecm");
                    eLC.SetValue(pl, newIndex, 3, Icon);
                    eLC.SetValue(pl, newIndex, 4, itemId.ToString());
                    eLC.SetValue(pl, newIndex, 6, itemtype.ToString());
                    eLC.SetValue(pl, newIndex, 8, "1");
                    eLC.SetValue(pl, newIndex, 75, "1");//money
                    eLC.SetValue(pl, newIndex, 76, "10000000");//money
                    eLC.SetValue(pl, newIndex, 77, "1");//money
                    switch (itemtype)
                    {
                        case 8781: //Mount

                            break;
                        case 8782: //Battle Pet
                            eLC.SetValue(pl, newIndex, 11, "687");
                            eLC.SetValue(pl, newIndex, 12, "5");
                            break;
                        case 8783: //Synthesize pet

                            break;
                        case 28752: //Summon Monster

                            break;
                        case 28913: //Plant

                            break;
                        case 37698: //Evolving Pet

                            break;
                    }


                    progress_bar("Creating Pets...", x, selected.Count);
                }
                locked = false;
                progress_bar("Ready", 0, 0);
            }

        }

        private void PathFixerToolStripMenuItem_Click(object sender, EventArgs ex)
        {
            if (eLC != null)
            {
                int l = comboBox_lists.SelectedIndex;
                int e = listBox_items.CurrentCell.RowIndex;
                int replaced = 0;
                if (e == -1)
                {
                    JMessageBox.Show(this, "Please slect a item!");
                    return;
                }
                if (l != eLC.ConversationListIndex)
                {
                    PckMoveFixer pathfixer = new PckMoveFixer();
                    pathfixer.ShowDialog(this);
                    if (pathfixer.DialogResult == DialogResult.OK)
                    {

                        List<string> replaceValues = PckMoveFixer.oldValue.Split(',').ToList(); //models/npcs,//models2/npcs
                        for (int i = 0; i < replaceValues.Count; i++)
                        {
                            replaceValues[i] = replaceValues[i] + "(.*)".ToLower();
                        }

                        string valueStr = PckMoveFixer.newValue.ToLower() + "$1"; //shaders/npcs

                        for (int selectedRowx = 0; selectedRowx < dataGridView_item.SelectedRows.Count; selectedRowx++)
                        {
                            int selectedRow = dataGridView_item.SelectedRows[selectedRowx].Index;


                            for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                            {
                                progress_bar("Fixing ...", i, listBox_items.SelectedRows.Count);
                                int item = listBox_items.SelectedRows[i].Index;
                                string valueNow = eLC.Lists[l].GetValue(item, selectedRow).ToLower();
                                foreach (string oldvalue in replaceValues)
                                {
                                    try
                                    {
                                        Regex x = new Regex(oldvalue);
                                        if (x.IsMatch(valueNow))
                                        {
                                            string calculated = x.Replace(valueNow, valueStr);
                                            eLC.Lists[l].SetValue(item, selectedRow, calculated);
                                            replaced++;
                                        }
                                    }
                                    catch { }
                                }

                            }
                        }

                        JMessageBox.Show(this, "Replaced:" + replaced + " items!");
                    }
                }
            }
            progress_bar("Ready", 0, 0);
        }

        private void CalculateTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int list = comboBox_lists.SelectedIndex;
            if (eLC != null & list != -1 && list != eLC.ConversationListIndex)
            {
                List<int> itemsIds = new List<int>();
                List<int> probabilityIds = new List<int>();
                for (int f = 0; f < eLC.Lists[list].elementFields.Length; f++)
                {
                    if (eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("addons") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id_addon")
                    || eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("task") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id")
                    || eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("materials") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id")
                    || eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("list") && eLC.Lists[list].elementFields[f].ToString().ToLower().Contains("id"))
                    {
                        itemsIds.Add(f);
                        probabilityIds.Add(f + 1);
                    }
                }
                int idx = listBox_items.CurrentCell.RowIndex;
                List<int> itemsIds_real = new List<int>();
                List<int> new_Indexes = new List<int>();
                float total = 0;
                for (int i = 0; i < itemsIds.Count; i++)
                {
                    int value = int.Parse(eLC.GetValue(list, idx, itemsIds[i]));
                    float valuex = float.Parse(eLC.GetValue(list, idx, probabilityIds[i]));
                    if (value != 0)
                    {
                        total += valuex;
                        new_Indexes.Add(probabilityIds[i]);
                    }
                }
                JMessageBox.Show(this, "The addons total is:" + total.ToString());
            }
        }

        private void IconsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageChange ic = new ImageChange(0, "");
            ic.Show();
        }

        private void CopyPets(object sender, EventArgs e)
        {
            if (comboBox_lists.SelectedIndex == -1 || listBox_items.CurrentCell == null)
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
                        Export export = new Export
                        {
                            ListId = l,
                            type = 0, //Elements data = 0 | Gshop = 1 
                            Version = eLC.Version,
                            RowCount = eLC.Lists[l].elementFields.Length,
                            data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default)),
                            data2 = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default))
                        };
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Copying ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            int itemId = int.Parse(eLC.Lists[l].GetValue(index, 0));

                            export.data.Add(itemId, eLC.Lists[l].elementValues[index]);
                            if (l == eLC.PetEggs)
                            {
                                int petId = int.Parse(eLC.Lists[l].GetValue(index, eLC.PetIdelementPosition));
                                if (petId > 0)
                                {
                                    if (eLC.PETS.TryGetValue(petId, out ItemDupe perref))
                                    {
                                        export.data2.Add(itemId, eLC.Lists[perref.listID].elementValues[perref.index]);
                                    }
                                }
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
                JMessageBox.Show(this, "Please select a item!");
            }

        }

        private void PastePets(object sender, EventArgs ex)
        {
            Export obj = GetFromClipboard();
            int id_index = 0;
            if (obj != null && obj.data != null && obj.data.Count != 0)
            {
                foreach (KeyValuePair<int, object> entry in obj.data)
                {
                    SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                    SortedList<int, object> data2 = null;
                    int id = (int)data[id_index];
                    if (obj.data2 != null && obj.data2.ContainsKey(id))
                    {
                        data2 = (SortedList<int, object>)obj.data2[id];
                    }
                    if (DatabaseManager.Instance.autonewId)
                    {
                        if (configs.nextAutoNewId == 0)
                        {
                            configs.nextAutoNewId = eLC.getNextFreeId(0, null);
                        }
                        data[id_index] = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                        configs.nextAutoNewId = (int)data[id_index];
                        eLC.useFreeId(configs.nextAutoNewId, eLC.PetEggs, eLC.Lists[eLC.PetEggs].elementValues.Count);

                        if (data2 != null)
                        {
                            data2[id_index] = eLC.getNextFreeId(configs.nextAutoNewId, nextautoIdlabel);
                            configs.nextAutoNewId = (int)data2[id_index];

                            eLC.useFreeId(configs.nextAutoNewId, eLC.Pets, eLC.Lists[eLC.Pets].elementValues.Count);
                            data[eLC.PetIdelementPosition] = data2[id_index];
                        }



                    }
                    eLC.Lists[eLC.PetEggs].AddItem(eLC.PetEggs, data);
                    if (data2 != null)
                        eLC.Lists[eLC.Pets].AddItem(eLC.Pets, data2);
                }


                this.RefreshTaskRecipes();
                locked = false;
                lock3 = false;
                comboBox_lists.Enabled = true;
                listBox_items.Enabled = true;
                try
                {
                    Change_list(null, null);
                    listBox_items.Rows[eLC.Lists[eLC.PetEggs].elementValues.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[eLC.Lists[eLC.PetEggs].elementValues.Count - 1].Cells[0];
                    locked = false;
                    listBox_items_CellClick(null, null);
                }
                catch { }
                progress_bar("Ready", 0, 0);
            }
        }

        private void JPictureBox6_Click(object sender, EventArgs e)
        {
            RefreshTaskRecipes();
        }
    }

}
