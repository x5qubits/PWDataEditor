
using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ElementEditor;
using ElementEditor.classes;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using PWDataEditorPaied.Properties;
using ElementEditor.helper_classes;
using ElementEditor.Element_Editor_Classes;
using PWDataEditorPaied.Database;
using PWDataEditorPaied.PW_Admin_classes;
using JHUI.Forms;
using JHUI;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace sTASKedit
{
    public partial class TaskEditor: JForm
	{
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;

        protected static ArrayList versions = new ArrayList(new int[]
		{
			43,
			53,
			54,
			55,
			56,
			57,
			59,
			60,
			63,
			68,
			69,
			75,
			78,
			80,
			82,
			89,
			90,
			92,
			93,
			99,
			100,
			101,
			102,
			103,
			105,
			107,
			108,
			111,
			118,
			119,
			120,
			121,
			122,
			123,
			124,
			125,
			127,
			128,
			129,
			130,
            146,
            9999
		});
        public static string[] itemlists;
        public static ArrayList monster_npc_minelists = new ArrayList(new int[]
		{
			38,
			57,
			79
		});


        public static int version;
        public static int NewID = 0;
        public static int tmpNewID = 0;
        public static string path;
        private string ValueFormat;
        private string ProbValueFormat;
        private string ProbAddValueFormat;
        public bool LoadedTask = false;
        public static bool LoadedElements = true;
        public bool Selecting = false;
        public bool LockedSelecting = false;
        private bool Scrolling = false;
        public static ATaskTemplFixedData[] BTasks;
        protected ATaskTemplFixedData[] Tasks;
        protected ATaskTemplFixedData SelectedTask;
        protected AWARD_DATA SelectedReward;
        public static SortedList<int, Map> InstanceList
        {
            get
            {
                return dm.getInstanceList();
            }
        }
        public static SortedList<string,string> LocalizationText
        {
            get
            {
                return dm.GetLocalizationText();
            }
        }
        public static SortedList monsters_npcs_mines
        {
            get
            {
                return dm.getDatabase(path).monsters_npcs_mines;
            }
        }
        public static SortedList titles
        {
            get
            {
                return dm.getDatabase(path).titles;
            }
        }
        public static SortedList homeitems
        {
            get
            {
                return dm.getDatabase(path).homeitems;
            }
        }
        public static SortedList<string, string> addonslist
        {
            get
            {
                return dm.getDatabase(path).addonslist;
            }
        }
        public static string[] buff_str
        {
            get
            {
                return dm.getbuffList(path);
            }
        }
        public static string[] skillstr
        {
            get
            {
                return dm.getSkillList(path);
            }
        }
        public static string[] world_targets
        {
            get
            {
               return dm.getDatabase(path).world_targets;
            }
        }
        public static ImageList imageList1;
        public static ImageList imageList2;
        public static eListCollection eLC
        {
            get
            {
                return ElementsEditor.eLC;
            }

        }
        public eListConversation conversationList;
        public static System.Drawing.Text.PrivateFontCollection f;
        public int SelectItemIdWindow_SelectedListIndex = 0;
        public int SelectItemIdWindow_SelectedItemIndex = 0;
        public int SelectMonsterIdWindow_SelectedItemIndex = 0;
        public int SelectNPCIdWindow_SelectedItemIndex = 0;
        public int SelectMonsterNPCMineIdWindow_SelectedListIndex = 0;
        public int SelectMonsterNPCMineIdWindow_SelectedItemIndex = 0;
        public int SelectTitleIdWindow_SelectedItemIndex = 0;
        public int SelectHomeItemIdWindow_SelectedItemIndex = 0;
        public int SelectBuffIdWindow_SelectedItemIndex = 0;
        public int SelectWorldIdWindow_SelectedItemIndex = 0;
        public int SelectSkillIdWindow_SelectedItemIndex = 0;
        public int SelectRelayStationIdWindow_SelectedItemIndex = 0;
        public TreeNode lastSelectedNode = null;
        public static DatabaseManager dm = DatabaseManager.Instance;
        public TaskEditor()
		{
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            jLabel1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = jPictureBox2.Visible = false;
            this.comboBox_search.SelectedIndex = 0;
            for (int i = 0; i < TaskEditor.versions.Count - 1; i++)
            {
                this.comboBox_SaveVersion.Items.Add(((int)TaskEditor.versions[i]));
            }
            this.LoadImageLists();
            this.CheckShowDigits();
            this.CheckShowPercents();
        }

        #region Change
        private void change_m_ID(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                //this.toolStripStatusLabel_Message.Text = Extensions.GetLocalization(510);
                progressShow(Extensions.GetLocalization(510), 0, 0);
                try
                {
                    if (this.SelectedTask.ID != Convert.ToInt32(this.textBox_m_ID.Text))
                    {
                        this.treeView_tasks.BeginUpdate();
                        int oldID = this.SelectedTask.ID;
                        int Selected_talk_proc = this.listBox_conversation_talk_procs.SelectedIndex;
                        int Selected_window = this.listBox_conversation_windows.SelectedIndex;
                        int Selected_option = this.listBox_conversation_options.SelectedIndex;
                        this.SelectedTask.ID = Convert.ToInt32(this.textBox_m_ID.Text);
                        string m_szName = this.SelectedTask.Name;
                        if (m_szName.StartsWith("^"))
                        {
                            m_szName = m_szName.Substring(7);
                        }
                        this.treeView_tasks.SelectedNode.Text = this.SelectedTask.ID.ToString() + " - " + m_szName;
                        if (this.SelectedTask.sub_quest_count != 0)
                        {
                            for (int i = 0; i < this.SelectedTask.sub_quest_count; i++)
                            {
                                this.SelectedTask.sub_quests[i].m_ulParent = this.SelectedTask.ID;
                            }
                        }
                        ArrayList listSelected = new ArrayList();
                        TreeNode selectedNode = this.treeView_tasks.SelectedNode;
                        if (selectedNode.Parent != null)
                        {
                            while (selectedNode.Parent != null)
                            {
                                listSelected.Add(selectedNode.Index);
                                selectedNode = selectedNode.Parent;
                            }
                            ATaskTemplFixedData parentTask = this.Tasks[selectedNode.Index];
                            for (int i = listSelected.Count - 1; i > 0; i--)
                            {
                                parentTask = parentTask.sub_quests[(int)listSelected[i]];
                            }
                            if ((int)listSelected[0] < parentTask.sub_quest_count - 1) parentTask.sub_quests[(int)listSelected[0] + 1].m_ulPrevSibling = this.SelectedTask.ID;
                            if ((int)listSelected[0] != 0) parentTask.sub_quests[(int)listSelected[0] - 1].m_ulNextSibling = this.SelectedTask.ID;
                            if ((int)listSelected[0] == 0) parentTask.m_ulFirstChild = this.SelectedTask.ID;
                        }
                        this.SetNewIDIntalk_procs(SelectedTask, oldID, this.SelectedTask.ID);
                        this.change_ColorAndIcon();
                        this.listBox_conversation_talk_procs.SelectedIndex = Selected_talk_proc;
                        this.listBox_conversation_windows.SelectedIndex = Selected_window;
                        this.listBox_conversation_options.SelectedIndex = Selected_option;
                        this.treeView_tasks.EndUpdate();
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
                progressShow(Extensions.GetLocalization(499), 0, 0);
            }
        }
        private void change_m_szName(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                progressShow(Extensions.GetLocalization(510), 0, 0);
                try
                {
                    if (this.SelectedTask.Name != this.textBox_m_szName.Text)
                    {
                        string node = this.textBox_m_szName.Text;
                        this.SelectedTask.Name = node;
                        this.treeView_tasks.BeginUpdate();
                        if (node.StartsWith("^"))
                        {
                            node = node.Substring(7);
                        }
                        this.treeView_tasks.SelectedNode.Text = this.SelectedTask.ID.ToString() + " - " + node;
                        this.change_ColorAndIcon();
                        this.treeView_tasks.EndUpdate();
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
                progressShow(Extensions.GetLocalization(499), 0, 0);
            }
        }
        private void change_m_pszSignature(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.AuthorText != this.textBox_m_pszSignature.Text)
                    {
                        if (this.textBox_m_pszSignature.Text == "")
                        {
                            this.checkBox_m_bHasSign.Checked = false;
                            this.SelectedTask.m_bHasSign = false;
                        }
                        else
                        {
                            this.checkBox_m_bHasSign.Checked = true;
                            this.SelectedTask.m_bHasSign = true;
                        }
                        this.SelectedTask.AuthorText = this.textBox_m_pszSignature.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulType(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    switch (this.comboBox_m_ulType.SelectedIndex)
                    {
                        case 0:
                            this.SelectedTask.m_ulType = 0;
                            break;
                        case 1:
                            this.SelectedTask.m_ulType = 1;
                            break;
                        case 2:
                            this.SelectedTask.m_ulType = 2;
                            break;
                        case 3:
                            this.SelectedTask.m_ulType = 3;
                            break;
                        case 4:
                            this.SelectedTask.m_ulType = 4;
                            break;
                        case 5:
                            this.SelectedTask.m_ulType = 5;
                            break;
                        case 6:
                            this.SelectedTask.m_ulType = 6;
                            break;
                        case 7:
                            this.SelectedTask.m_ulType = 7;
                            break;
                        case 8:
                            this.SelectedTask.m_ulType = 8;
                            break;
                        case 9:
                            this.SelectedTask.m_ulType = 9;
                            break;
                        case 10:
                            this.SelectedTask.m_ulType = 10;
                            break;
                        case 11:
                            this.SelectedTask.m_ulType = 11;
                            break;
                        case 12:
                            this.SelectedTask.m_ulType = 12;
                            break;
                        case 13:
                            this.SelectedTask.m_ulType = 100;
                            break;
                        case 14:
                            this.SelectedTask.m_ulType = 101;
                            break;
                        case 15:
                            this.SelectedTask.m_ulType = 102;
                            break;
                        case 16:
                            this.SelectedTask.m_ulType = 103;
                            break;
                        case 17:
                            this.SelectedTask.m_ulType = 104;
                            break;
                        case 18:
                            this.SelectedTask.m_ulType = 105;
                            break;
                        case 19:
                            this.SelectedTask.m_ulType = 106;
                            break;
                        case 20:
                            this.SelectedTask.m_ulType = 107;
                            break;
                        case 21:
                            this.SelectedTask.m_ulType = 108;
                            break;
                        case 22:
                            this.SelectedTask.m_ulType = 109;
                            break;
                        case 23:
                            this.SelectedTask.m_ulType = 110;
                            break;
                    }
                    this.change_ColorAndIcon();
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }

        public void SetStyle(JColorStyle style, JThemeStyle thme, int alpha)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    SetStyle(style, thme, alpha);
                }));
                return;
            }
            this.components.SetStyle(this, style, thme, alpha);
        }

        private void change_m_ulTimeLimit(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (Extensions.SecondsToString(this.SelectedTask.m_ulTimeLimit) != this.textBox_m_ulTimeLimit.Text)
                    {
                        this.SelectedTask.m_ulTimeLimit = Extensions.StringToSecond(this.textBox_m_ulTimeLimit.Text);
                        for (int i = 0; i < this.listBox_reward_m_AwByRatio_S.Items.Count; i++)
                        {
                            this.listBox_reward_m_AwByRatio_S.Items[i] = Extensions.GetLocalization(405) + (float)this.SelectedTask.m_ulTimeLimit * this.SelectedTask.m_AwByRatio_S.m_Ratios[i];
                        }
                        this.TriggerDebug((Control)sender);
                        for (int i = 0; i < this.listBox_reward_m_AwByRatio_F.Items.Count; i++)
                        {
                            this.listBox_reward_m_AwByRatio_F.Items[i] = Extensions.GetLocalization(405) + (float)this.SelectedTask.m_ulTimeLimit * this.SelectedTask.m_AwByRatio_F.m_Ratios[i];
                        }
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bOfflineFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bOfflineFail != this.checkBox_m_bOfflineFail.Checked)
                    {
                        this.SelectedTask.m_bOfflineFail = this.checkBox_m_bOfflineFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bAbsFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bAbsFail != this.checkBox_m_bAbsFail.Checked)
                    {
                        this.SelectedTask.m_bAbsFail = this.checkBox_m_bAbsFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_tmAbsFailTime(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int arg_1B_0 = this.dataGridView_m_tmAbsFailTime.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_tmAbsFailTime.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_tmAbsFailTime.year = Convert.ToInt32(this.dataGridView_m_tmAbsFailTime.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_tmAbsFailTime.month = Convert.ToInt32(this.dataGridView_m_tmAbsFailTime.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_tmAbsFailTime.day = Convert.ToInt32(this.dataGridView_m_tmAbsFailTime.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_tmAbsFailTime.hour = Convert.ToInt32(this.dataGridView_m_tmAbsFailTime.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_tmAbsFailTime.min = Convert.ToInt32(this.dataGridView_m_tmAbsFailTime.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_tmAbsFailTime.wday = this.Column_m_tmAbsFailTime_wday.Items.IndexOf(this.dataGridView_m_tmAbsFailTime.CurrentCell.Value);
                            break;
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bItemNotTakeOff(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bItemNotTakeOff != this.checkBox_m_bItemNotTakeOff.Checked)
                    {
                        this.SelectedTask.m_bItemNotTakeOff = this.checkBox_m_bItemNotTakeOff.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bAbsTime(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bAbsTime != this.checkBox_m_bAbsTime.Checked)
                    {
                        this.SelectedTask.m_bAbsTime = this.checkBox_m_bAbsTime.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_tmType_m_tmStart_m_tmEnd(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_tmType[rowIndex] = Convert.ToByte(this.Column416.Items.IndexOf(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value));
                            break;
                        case 1:
                            this.SelectedTask.m_tmStart[rowIndex].year = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_tmStart[rowIndex].month = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_tmStart[rowIndex].day = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_tmStart[rowIndex].hour = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_tmStart[rowIndex].min = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 6:
                            this.SelectedTask.m_tmStart[rowIndex].wday = this.Column6.Items.IndexOf(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 8:
                            this.SelectedTask.m_tmEnd[rowIndex].year = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 9:
                            this.SelectedTask.m_tmEnd[rowIndex].month = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 10:
                            this.SelectedTask.m_tmEnd[rowIndex].day = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 11:
                            this.SelectedTask.m_tmEnd[rowIndex].hour = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 12:
                            this.SelectedTask.m_tmEnd[rowIndex].min = Convert.ToInt32(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                        case 13:
                            this.SelectedTask.m_tmEnd[rowIndex].wday = this.Column13.Items.IndexOf(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lAvailFrequency(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_lAvailFrequency != this.comboBox_m_lAvailFrequency.SelectedIndex)
                    {
                        this.SelectedTask.m_lAvailFrequency = this.comboBox_m_lAvailFrequency.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lPeriodLimit(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_lPeriodLimit != Extensions.DigitNumberToInt32(this.textBox_m_lPeriodLimit.Text))
                    {
                        this.SelectedTask.m_lPeriodLimit = Extensions.DigitNumberToInt32(this.textBox_m_lPeriodLimit.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_lPeriodLimit.Text = this.SelectedTask.m_lPeriodLimit.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bChooseOne(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bChooseOne != this.checkBox_m_bChooseOne.Checked)
                    {
                        this.SelectedTask.m_bChooseOne = this.checkBox_m_bChooseOne.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bRandOne(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bRandOne != this.checkBox_m_bRandOne.Checked)
                    {
                        this.SelectedTask.m_bRandOne = this.checkBox_m_bRandOne.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bExeChildInOrder(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bExeChildInOrder != this.checkBox_m_bExeChildInOrder.Checked)
                    {
                        this.SelectedTask.m_bExeChildInOrder = this.checkBox_m_bExeChildInOrder.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bParentAlsoFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bParentAlsoFail != this.checkBox_m_bParentAlsoFail.Checked)
                    {
                        this.SelectedTask.m_bParentAlsoFail = this.checkBox_m_bParentAlsoFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bParentAlsoSucc(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bParentAlsoSucc != this.checkBox_m_bParentAlsoSucc.Checked)
                    {
                        this.SelectedTask.m_bParentAlsoSucc = this.checkBox_m_bParentAlsoSucc.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCanGiveUp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCanGiveUp != this.checkBox_m_bCanGiveUp.Checked)
                    {
                        this.SelectedTask.m_bCanGiveUp = this.checkBox_m_bCanGiveUp.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCanRedo(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCanRedo != this.checkBox_m_bCanRedo.Checked)
                    {
                        this.SelectedTask.m_bCanRedo = this.checkBox_m_bCanRedo.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCanRedoAfterFailure(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCanRedoAfterFailure != this.checkBox_m_bCanRedoAfterFailure.Checked)
                    {
                        this.SelectedTask.m_bCanRedoAfterFailure = this.checkBox_m_bCanRedoAfterFailure.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bClearAsGiveUp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bClearAsGiveUp != this.checkBox_m_bClearAsGiveUp.Checked)
                    {
                        this.SelectedTask.m_bClearAsGiveUp = this.checkBox_m_bClearAsGiveUp.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bNeedRecord(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bNeedRecord != this.checkBox_m_bNeedRecord.Checked)
                    {
                        this.SelectedTask.m_bNeedRecord = this.checkBox_m_bNeedRecord.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bFailAsPlayerDie(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bFailAsPlayerDie != this.checkBox_m_bFailAsPlayerDie.Checked)
                    {
                        this.SelectedTask.m_bFailAsPlayerDie = this.checkBox_m_bFailAsPlayerDie.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulMaxReceiver(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulMaxReceiver != Extensions.DigitNumberToInt32(this.textBox_m_ulMaxReceiver.Text))
                    {
                        this.SelectedTask.m_ulMaxReceiver = Extensions.DigitNumberToInt32(this.textBox_m_ulMaxReceiver.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_ulMaxReceiver.Text = this.SelectedTask.m_ulMaxReceiver.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDelvInZone(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDelvInZone != this.checkBox_m_bDelvInZone.Checked)
                    {
                        this.SelectedTask.m_bDelvInZone = this.checkBox_m_bDelvInZone.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulDelvWorld(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulDelvWorld != Convert.ToInt32(this.textBox_m_ulDelvWorld.Text))
                    {
                        this.SelectedTask.m_ulDelvWorld = Convert.ToInt32(this.textBox_m_ulDelvWorld.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_m_ulDelvWorld();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pDelvRegion(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_pDelvRegion.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_x = Convert.ToSingle(this.dataGridView_m_pDelvRegion.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_y = Convert.ToSingle(this.dataGridView_m_pDelvRegion.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_z = Convert.ToSingle(this.dataGridView_m_pDelvRegion.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_x = Convert.ToSingle(this.dataGridView_m_pDelvRegion.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_y = Convert.ToSingle(this.dataGridView_m_pDelvRegion.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_z = Convert.ToSingle(this.dataGridView_m_pDelvRegion.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                    this.Convert_m_pDelvRegion(null, null);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bEnterRegionFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bEnterRegionFail != this.checkBox_m_bEnterRegionFail.Checked)
                    {
                        this.SelectedTask.m_bEnterRegionFail = this.checkBox_m_bEnterRegionFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulEnterRegionWorld(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulEnterRegionWorld != Convert.ToInt32(this.textBox_m_ulEnterRegionWorld.Text))
                    {
                        this.SelectedTask.m_ulEnterRegionWorld = Convert.ToInt32(this.textBox_m_ulEnterRegionWorld.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_m_ulEnterRegionWorld();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pEnterRegion(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_pEnterRegion.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_x = Convert.ToSingle(this.dataGridView_m_pEnterRegion.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_y = Convert.ToSingle(this.dataGridView_m_pEnterRegion.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_z = Convert.ToSingle(this.dataGridView_m_pEnterRegion.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_x = Convert.ToSingle(this.dataGridView_m_pEnterRegion.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_y = Convert.ToSingle(this.dataGridView_m_pEnterRegion.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_z = Convert.ToSingle(this.dataGridView_m_pEnterRegion.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                    this.Convert_m_pEnterRegion(null, null);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bLeaveRegionFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bLeaveRegionFail != this.checkBox_m_bLeaveRegionFail.Checked)
                    {
                        this.SelectedTask.m_bLeaveRegionFail = this.checkBox_m_bLeaveRegionFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulLeaveRegionWorld(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulLeaveRegionWorld != Convert.ToInt32(this.textBox_m_ulLeaveRegionWorld.Text))
                    {
                        this.SelectedTask.m_ulLeaveRegionWorld = Convert.ToInt32(this.textBox_m_ulLeaveRegionWorld.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_m_ulLeaveRegionWorld();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pLeaveRegion(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_pLeaveRegion.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_x = Convert.ToSingle(this.dataGridView_m_pLeaveRegion.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_y = Convert.ToSingle(this.dataGridView_m_pLeaveRegion.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_z = Convert.ToSingle(this.dataGridView_m_pLeaveRegion.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_x = Convert.ToSingle(this.dataGridView_m_pLeaveRegion.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_y = Convert.ToSingle(this.dataGridView_m_pLeaveRegion.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_z = Convert.ToSingle(this.dataGridView_m_pLeaveRegion.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                    this.Convert_m_pLeaveRegion(null, null);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bLeaveForceFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bLeaveForceFail != this.checkBox_m_bLeaveForceFail.Checked)
                    {
                        this.SelectedTask.m_bLeaveForceFail = this.checkBox_m_bLeaveForceFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bTransTo(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bTransTo != this.checkBox_m_bTransTo.Checked)
                    {
                        this.SelectedTask.m_bTransTo = this.checkBox_m_bTransTo.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulTransWldId(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulTransWldId != Convert.ToInt32(this.textBox_m_ulTransWldId.Text))
                    {
                        this.SelectedTask.m_ulTransWldId = Convert.ToInt32(this.textBox_m_ulTransWldId.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_m_ulTransWldId();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TransPt_x(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_TransPt.x != Convert.ToSingle(this.textBox_m_TransPt_x.Text))
                    {
                        this.SelectedTask.m_TransPt.x = Convert.ToSingle(this.textBox_m_TransPt_x.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_m_TransPt();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TransPt_y(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_TransPt.y != Convert.ToSingle(this.textBox_m_TransPt_y.Text))
                    {
                        this.SelectedTask.m_TransPt.y = Convert.ToSingle(this.textBox_m_TransPt_y.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_m_TransPt();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TransPt_z(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_TransPt.z != Convert.ToSingle(this.textBox_m_TransPt_z.Text))
                    {
                        this.SelectedTask.m_TransPt.z = Convert.ToSingle(this.textBox_m_TransPt_z.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_m_TransPt();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lMonsCtrl(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_lMonsCtrl != Convert.ToInt32(this.textBox_m_lMonsCtrl.Text))
                    {
                        this.SelectedTask.m_lMonsCtrl = Convert.ToInt32(this.textBox_m_lMonsCtrl.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bTrigCtrl(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bTrigCtrl != this.checkBox_m_bTrigCtrl.Checked)
                    {
                        this.SelectedTask.m_bTrigCtrl = this.checkBox_m_bTrigCtrl.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bAutoDeliver(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bAutoDeliver != this.checkBox_m_bAutoDeliver.Checked)
                    {
                        this.SelectedTask.m_bAutoDeliver = this.checkBox_m_bAutoDeliver.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDisplayInExclusiveUI(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDisplayInExclusiveUI != this.checkBox_m_bDisplayInExclusiveUI.Checked)
                    {
                        this.SelectedTask.m_bDisplayInExclusiveUI = this.checkBox_m_bDisplayInExclusiveUI.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bReadyToNotifyServer(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bReadyToNotifyServer != this.checkBox_m_bReadyToNotifyServer.Checked)
                    {
                        this.SelectedTask.m_bReadyToNotifyServer = this.checkBox_m_bReadyToNotifyServer.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bUsedInTokenShop(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bUsedInTokenShop != this.checkBox_m_bUsedInTokenShop.Checked)
                    {
                        this.SelectedTask.m_bUsedInTokenShop = this.checkBox_m_bUsedInTokenShop.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDeathTrig(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDeathTrig != this.checkBox_m_bDeathTrig.Checked)
                    {
                        this.SelectedTask.m_bDeathTrig = this.checkBox_m_bDeathTrig.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bClearAcquired(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bClearAcquired != this.checkBox_m_bClearAcquired.Checked)
                    {
                        this.SelectedTask.m_bClearAcquired = this.checkBox_m_bClearAcquired.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulSuitableLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulSuitableLevel != Convert.ToInt32(this.numericUpDown_m_ulSuitableLevel.Value))
                    {
                        this.SelectedTask.m_ulSuitableLevel = Convert.ToInt32(this.numericUpDown_m_ulSuitableLevel.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowPrompt(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowPrompt != this.checkBox_m_bShowPrompt.Checked)
                    {
                        this.SelectedTask.m_bShowPrompt = this.checkBox_m_bShowPrompt.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bKeyTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bKeyTask != this.checkBox_m_bKeyTask.Checked)
                    {
                        this.SelectedTask.m_bKeyTask = this.checkBox_m_bKeyTask.Checked;
                        this.change_ColorAndIcon();
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulDelvNPC(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulDelvNPC != Convert.ToInt32(this.textBox_m_ulDelvNPC.Text))
                    {
                        this.SelectedTask.m_ulDelvNPC = Convert.ToInt32(this.textBox_m_ulDelvNPC.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowNPCName_m_ulDelvNPC();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulAwardNPC(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulAwardNPC != Convert.ToInt32(this.textBox_m_ulAwardNPC.Text))
                    {
                        this.SelectedTask.m_ulAwardNPC = Convert.ToInt32(this.textBox_m_ulAwardNPC.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowNPCName_m_ulAwardNPC();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bSkillTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bSkillTask != this.checkBox_m_bSkillTask.Checked)
                    {
                        this.SelectedTask.m_bSkillTask = this.checkBox_m_bSkillTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCanSeekOut(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCanSeekOut != this.checkBox_m_bCanSeekOut.Checked)
                    {
                        this.SelectedTask.m_bCanSeekOut = this.checkBox_m_bCanSeekOut.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowDirection(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowDirection != this.checkBox_m_bShowDirection.Checked)
                    {
                        this.SelectedTask.m_bShowDirection = this.checkBox_m_bShowDirection.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bMarriage(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bMarriage != this.checkBox_m_bMarriage.Checked)
                    {
                        this.SelectedTask.m_bMarriage = this.checkBox_m_bMarriage.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulChangeKey(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_ulChangeKey.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_plChangeKey[rowIndex] = Convert.ToInt32(this.dataGridView_m_ulChangeKey.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_plChangeKeyValue[rowIndex] = Convert.ToInt32(this.dataGridView_m_ulChangeKey.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_pbChangeType[rowIndex] = Convert.ToBoolean(this.dataGridViewTextBoxColumn69.Items.IndexOf(this.dataGridView_m_ulChangeKey.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bSwitchSceneFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bSwitchSceneFail != this.checkBox_m_bSwitchSceneFail.Checked)
                    {
                        this.SelectedTask.m_bSwitchSceneFail = this.checkBox_m_bSwitchSceneFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bHidden(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bHidden != this.checkBox_m_bHidden.Checked)
                    {
                        this.SelectedTask.m_bHidden = this.checkBox_m_bHidden.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDeliverySkill(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDeliverySkill != this.checkBox_m_bDeliverySkill.Checked)
                    {
                        this.SelectedTask.m_bDeliverySkill = this.checkBox_m_bDeliverySkill.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iDeliveredSkillID(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iDeliveredSkillID != Convert.ToInt32(this.textBox_m_iDeliveredSkillID.Text))
                    {
                        this.SelectedTask.m_iDeliveredSkillID = Convert.ToInt32(this.textBox_m_iDeliveredSkillID.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowSkillText_m_iDeliveredSkillID();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iDeliveredSkillLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iDeliveredSkillLevel != Convert.ToInt32(this.numericUpDown_m_iDeliveredSkillLevel.Value))
                    {
                        this.SelectedTask.m_iDeliveredSkillLevel = Convert.ToInt32(this.numericUpDown_m_iDeliveredSkillLevel.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowGfxFinished(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowGfxFinished != this.checkBox_m_bShowGfxFinished.Checked)
                    {
                        this.SelectedTask.m_bShowGfxFinished = this.checkBox_m_bShowGfxFinished.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bChangePQRanking(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bChangePQRanking != this.checkBox_m_bChangePQRanking.Checked)
                    {
                        this.SelectedTask.m_bChangePQRanking = this.checkBox_m_bChangePQRanking.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCompareItemAndInventory(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCompareItemAndInventory != this.checkBox_m_bCompareItemAndInventory.Checked)
                    {
                        this.SelectedTask.m_bCompareItemAndInventory = this.checkBox_m_bCompareItemAndInventory.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulInventorySlotNum(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulInventorySlotNum != Convert.ToInt32(this.textBox_m_ulInventorySlotNum.Text))
                    {
                        this.SelectedTask.m_ulInventorySlotNum = Convert.ToInt32(this.textBox_m_ulInventorySlotNum.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_TowerTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.TowerTask != this.checkBox_TowerTask.Checked)
                    {
                        this.SelectedTask.TowerTask = this.checkBox_TowerTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_HomeTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.HomeTask != this.checkBox_HomeTask.Checked)
                    {
                        this.SelectedTask.HomeTask = this.checkBox_HomeTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_DelilverInHostHome(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.DelilverInHostHome != this.checkBox_DelilverInHostHome.Checked)
                    {
                        this.SelectedTask.DelilverInHostHome = this.checkBox_DelilverInHostHome.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_FinishInHostHome(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.FinishInHostHome != this.checkBox_FinishInHostHome.Checked)
                    {
                        this.SelectedTask.FinishInHostHome = this.checkBox_FinishInHostHome.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPQTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPQTask != this.checkBox_m_bPQTask.Checked)
                    {
                        this.SelectedTask.m_bPQTask = this.checkBox_m_bPQTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pszPQExp(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pszPQExp.CurrentCell.RowIndex;
                    int columnIndex = this.dataGridView_m_pszPQExp.CurrentCell.ColumnIndex;
                    if (columnIndex == 0)
                    {
                        this.SelectedTask.m_pszPQExp[rowIndex] = Extensions.GbkString_to_ByteArray2(Convert.ToString(this.dataGridView_m_pszPQExp.CurrentCell.Value), 64);
                    }
                    else if (Convert.ToSingle(columnIndex) / 2 != (int)Convert.ToSingle(columnIndex / 2))
                    {
                        this.SelectedTask.m_pPQExpArr[rowIndex].type[((columnIndex + 1) / 2) - 1] = Convert.ToInt32(this.dataGridView_m_pszPQExp.CurrentCell.Value);
                    }
                    else
                    {
                        this.SelectedTask.m_pPQExpArr[rowIndex].value[(columnIndex / 2) - 1] = Convert.ToSingle(this.dataGridView_m_pszPQExp.CurrentCell.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPQSubTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPQSubTask != this.checkBox_m_bPQSubTask.Checked)
                    {
                        this.SelectedTask.m_bPQSubTask = this.checkBox_m_bPQSubTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bClearContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bClearContrib != this.checkBox_m_bClearContrib.Checked)
                    {
                        this.SelectedTask.m_bClearContrib = this.checkBox_m_bClearContrib.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_MonstersContrib(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_MonstersContrib.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_MonstersContrib[rowIndex].m_ulMonsterTemplId = Convert.ToInt32(this.dataGridView_m_MonstersContrib.CurrentCell.Value);
                            this.dataGridView_m_MonstersContrib.Rows[rowIndex].Cells[1].Value = Extensions.MonsterNPCMineName(this.SelectedTask.m_MonstersContrib[rowIndex].m_ulMonsterTemplId);
                            break;
                        case 2:
                            this.SelectedTask.m_MonstersContrib[rowIndex].m_iWholeContrib = Extensions.DigitNumberToInt32(this.dataGridView_m_MonstersContrib.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_MonstersContrib.Rows[rowIndex].Cells[2].Value = this.SelectedTask.m_MonstersContrib[rowIndex].m_iWholeContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 3:
                            this.SelectedTask.m_MonstersContrib[rowIndex].m_iShareContrib = Extensions.DigitNumberToInt32(this.dataGridView_m_MonstersContrib.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_MonstersContrib.Rows[rowIndex].Cells[3].Value = this.SelectedTask.m_MonstersContrib[rowIndex].m_iShareContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 4:
                            this.SelectedTask.m_MonstersContrib[rowIndex].m_iPersonalWholeContrib = Extensions.DigitNumberToInt32(this.dataGridView_m_MonstersContrib.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_MonstersContrib.Rows[rowIndex].Cells[4].Value = this.SelectedTask.m_MonstersContrib[rowIndex].m_iPersonalWholeContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremNeedRecordTasksNum(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremNeedRecordTasksNum != Extensions.DigitNumberToInt32(this.textBox_m_iPremNeedRecordTasksNum.Text))
                    {
                        this.SelectedTask.m_iPremNeedRecordTasksNum = Extensions.DigitNumberToInt32(this.textBox_m_iPremNeedRecordTasksNum.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremNeedRecordTasksNum.Text = this.SelectedTask.m_iPremNeedRecordTasksNum.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByNeedRecordTasksNum(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByNeedRecordTasksNum != this.checkBox_m_bShowByNeedRecordTasksNum.Checked)
                    {
                        this.SelectedTask.m_bShowByNeedRecordTasksNum = this.checkBox_m_bShowByNeedRecordTasksNum.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremiseFactionContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremiseFactionContrib != Extensions.DigitNumberToInt32(this.textBox_m_iPremiseFactionContrib.Text))
                    {
                        this.SelectedTask.m_iPremiseFactionContrib = Extensions.DigitNumberToInt32(this.textBox_m_iPremiseFactionContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremiseFactionContrib.Text = this.SelectedTask.m_iPremiseFactionContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByFactionContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByFactionContrib != this.checkBox_m_bShowByFactionContrib.Checked)
                    {
                        this.SelectedTask.m_bShowByFactionContrib = this.checkBox_m_bShowByFactionContrib.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bAccountTaskLimit(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bAccountTaskLimit != this.checkBox_m_bAccountTaskLimit.Checked)
                    {
                        this.SelectedTask.m_bAccountTaskLimit = this.checkBox_m_bAccountTaskLimit.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bRoleTaskLimit(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bRoleTaskLimit != this.checkBox_m_bRoleTaskLimit.Checked)
                    {
                        this.SelectedTask.m_bRoleTaskLimit = this.checkBox_m_bRoleTaskLimit.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulAccountTaskLimitCnt(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulAccountTaskLimitCnt != Extensions.DigitNumberToInt32(this.textBox_m_ulAccountTaskLimitCnt.Text))
                    {
                        this.SelectedTask.m_ulAccountTaskLimitCnt = Extensions.DigitNumberToInt32(this.textBox_m_ulAccountTaskLimitCnt.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_ulAccountTaskLimitCnt.Text = this.SelectedTask.m_ulAccountTaskLimitCnt.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bLeaveFactionFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bLeaveFactionFail != this.checkBox_m_bLeaveFactionFail.Checked)
                    {
                        this.SelectedTask.m_bLeaveFactionFail = this.checkBox_m_bLeaveFactionFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bNotIncCntWhenFailed(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bNotIncCntWhenFailed != this.checkBox_m_bNotIncCntWhenFailed.Checked)
                    {
                        this.SelectedTask.m_bNotIncCntWhenFailed = this.checkBox_m_bNotIncCntWhenFailed.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bNotClearItemWhenFailed(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bNotClearItemWhenFailed != this.checkBox_m_bNotClearItemWhenFailed.Checked)
                    {
                        this.SelectedTask.m_bNotClearItemWhenFailed = this.checkBox_m_bNotClearItemWhenFailed.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDisplayInTitleTaskUI(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDisplayInTitleTaskUI != this.checkBox_m_bDisplayInTitleTaskUI.Checked)
                    {
                        this.SelectedTask.m_bDisplayInTitleTaskUI = this.checkBox_m_bDisplayInTitleTaskUI.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ucPremiseTransformedForm(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ucPremiseTransformedForm != Convert.ToByte(this.textBox_m_ucPremiseTransformedForm.Text))
                    {
                        this.SelectedTask.m_ucPremiseTransformedForm = Convert.ToByte(this.textBox_m_ucPremiseTransformedForm.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByTransformed(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByTransformed != this.checkBox_m_bShowByTransformed.Checked)
                    {
                        this.SelectedTask.m_bShowByTransformed = this.checkBox_m_bShowByTransformed.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Lev_Min(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremise_Lev_Min != Convert.ToInt32(this.numericUpDown_m_ulPremise_Lev_Min.Value))
                    {
                        this.SelectedTask.m_ulPremise_Lev_Min = Convert.ToInt32(this.numericUpDown_m_ulPremise_Lev_Min.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Lev_Max(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremise_Lev_Max != Convert.ToInt32(this.numericUpDown_m_ulPremise_Lev_Max.Value))
                    {
                        this.SelectedTask.m_ulPremise_Lev_Max = Convert.ToInt32(this.numericUpDown_m_ulPremise_Lev_Max.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremCheckMaxHistoryLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremCheckMaxHistoryLevel != this.comboBox_m_bPremCheckMaxHistoryLevel.SelectedIndex)
                    {
                        this.SelectedTask.m_bPremCheckMaxHistoryLevel = this.comboBox_m_bPremCheckMaxHistoryLevel.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByLev(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByLev != this.checkBox_m_bShowByLev.Checked)
                    {
                        this.SelectedTask.m_bShowByLev = this.checkBox_m_bShowByLev.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremCheckReincarnation(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremCheckReincarnation != this.checkBox_m_bPremCheckReincarnation.Checked)
                    {
                        this.SelectedTask.m_bPremCheckReincarnation = this.checkBox_m_bPremCheckReincarnation.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremReincarnationMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremReincarnationMin != Convert.ToInt32(this.numericUpDown_m_ulPremReincarnationMin.Value))
                    {
                        this.SelectedTask.m_ulPremReincarnationMin = Convert.ToInt32(this.numericUpDown_m_ulPremReincarnationMin.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremReincarnationMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremReincarnationMax != Convert.ToInt32(this.numericUpDown_m_ulPremReincarnationMax.Value))
                    {
                        this.SelectedTask.m_ulPremReincarnationMax = Convert.ToInt32(this.numericUpDown_m_ulPremReincarnationMax.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByReincarnation(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByReincarnation != this.checkBox_m_bShowByReincarnation.Checked)
                    {
                        this.SelectedTask.m_bShowByReincarnation = this.checkBox_m_bShowByReincarnation.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremCheckRealmLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremCheckRealmLevel != this.checkBox_m_bPremCheckRealmLevel.Checked)
                    {
                        this.SelectedTask.m_bPremCheckRealmLevel = this.checkBox_m_bPremCheckRealmLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremRealmLevelMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremRealmLevelMin != Convert.ToInt32(this.numericUpDown_m_ulPremRealmLevelMin.Value))
                    {
                        this.SelectedTask.m_ulPremRealmLevelMin = Convert.ToInt32(this.numericUpDown_m_ulPremRealmLevelMin.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremRealmLevelMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremRealmLevelMax != Convert.ToInt32(this.numericUpDown_m_ulPremRealmLevelMax.Value))
                    {
                        this.SelectedTask.m_ulPremRealmLevelMax = Convert.ToInt32(this.numericUpDown_m_ulPremRealmLevelMax.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremCheckRealmExpFull(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremCheckRealmExpFull != this.checkBox_m_bPremCheckRealmExpFull.Checked)
                    {
                        this.SelectedTask.m_bPremCheckRealmExpFull = this.checkBox_m_bPremCheckRealmExpFull.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByRealmLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByRealmLevel != this.checkBox_m_bShowByRealmLevel.Checked)
                    {
                        this.SelectedTask.m_bShowByRealmLevel = this.checkBox_m_bShowByRealmLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_PremItems(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_PremItems.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_PremItems.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_PremItems[rowIndex].m_ulItemTemplId = Convert.ToInt32(this.dataGridView_m_PremItems.CurrentCell.Value);
                            this.dataGridView_m_PremItems.Rows[rowIndex].Cells[1].Value = Extensions.ItemName(this.SelectedTask.m_PremItems[rowIndex].m_ulItemTemplId);
                            break;
                        case 2:
                            this.SelectedTask.m_PremItems[rowIndex].m_bCommonItem = Convert.ToBoolean(this.dataGridView_m_PremItems.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_PremItems[rowIndex].m_ulItemNum = Extensions.DigitNumberToInt32(this.dataGridView_m_PremItems.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_PremItems.Rows[rowIndex].Cells[3].Value = this.SelectedTask.m_PremItems[rowIndex].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 4:
                            this.SelectedTask.m_PremItems[rowIndex].m_fProb = Extensions.PercentNumberToSingle(this.dataGridView_m_PremItems.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 5:
                            this.SelectedTask.m_PremItems[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_m_PremItems.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByItems != this.checkBox_m_bShowByItems.Checked)
                    {
                        this.SelectedTask.m_bShowByItems = this.checkBox_m_bShowByItems.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremItemsAnyOne(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremItemsAnyOne != this.checkBox_m_bPremItemsAnyOne.Checked)
                    {
                        this.SelectedTask.m_bPremItemsAnyOne = this.checkBox_m_bPremItemsAnyOne.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulGivenCmnCount(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulGivenCmnCount != Convert.ToInt32(this.textBox_m_ulGivenCmnCount.Text))
                    {
                        this.SelectedTask.m_ulGivenCmnCount = Convert.ToInt32(this.textBox_m_ulGivenCmnCount.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulGivenTskCount(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulGivenTskCount != Convert.ToInt32(this.textBox_m_ulGivenTskCount.Text))
                    {
                        this.SelectedTask.m_ulGivenTskCount = Convert.ToInt32(this.textBox_m_ulGivenTskCount.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_GivenItems(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_GivenItems.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_GivenItems.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_GivenItems[rowIndex].m_ulItemTemplId = Convert.ToInt32(this.dataGridView_m_GivenItems.CurrentCell.Value);
                            this.dataGridView_m_GivenItems.Rows[rowIndex].Cells[1].Value = Extensions.ItemName(this.SelectedTask.m_GivenItems[rowIndex].m_ulItemTemplId);
                            break;
                        case 2:
                            this.SelectedTask.m_GivenItems[rowIndex].m_bCommonItem = Convert.ToBoolean(this.dataGridView_m_GivenItems.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_GivenItems[rowIndex].m_ulItemNum = Extensions.DigitNumberToInt32(this.dataGridView_m_GivenItems.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_GivenItems.Rows[rowIndex].Cells[3].Value = this.SelectedTask.m_GivenItems[rowIndex].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 4:
                            this.SelectedTask.m_GivenItems[rowIndex].m_fProb = Extensions.PercentNumberToSingle(this.dataGridView_m_GivenItems.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 5:
                            this.SelectedTask.m_GivenItems[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_m_GivenItems.CurrentCell.Value));
                            break;
                    }
                    this.Count_m_ulGivenCmnCount_m_ulGivenTskCount();
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Deposit(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremise_Deposit != Extensions.DigitNumberToInt32(this.textBox_m_ulPremise_Deposit.Text))
                    {
                        this.SelectedTask.m_ulPremise_Deposit = Extensions.DigitNumberToInt32(this.textBox_m_ulPremise_Deposit.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_ulPremise_Deposit.Text = this.SelectedTask.m_ulPremise_Deposit.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByDeposit(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByDeposit != this.checkBox_m_bShowByDeposit.Checked)
                    {
                        this.SelectedTask.m_bShowByDeposit = this.checkBox_m_bShowByDeposit.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lPremise_Reputation(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_lPremise_Reputation != Extensions.DigitNumberToInt32(this.textBox_m_lPremise_Reputation.Text))
                    {
                        this.SelectedTask.m_lPremise_Reputation = Extensions.DigitNumberToInt32(this.textBox_m_lPremise_Reputation.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_lPremise_Reputation.Text = this.SelectedTask.m_lPremise_Reputation.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lPremise_RepuMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_lPremise_RepuMax != Extensions.DigitNumberToInt32(this.textBox_m_lPremise_RepuMax.Text))
                    {
                        this.SelectedTask.m_lPremise_RepuMax = Extensions.DigitNumberToInt32(this.textBox_m_lPremise_RepuMax.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_lPremise_RepuMax.Text = this.SelectedTask.m_lPremise_RepuMax.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByRepu(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByRepu != this.checkBox_m_bShowByRepu.Checked)
                    {
                        this.SelectedTask.m_bShowByRepu = this.checkBox_m_bShowByRepu.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Tasks(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int index = 0;
                    this.SelectedTask.m_ulPremise_Tasks = new int[20];
                    if (this.textBox_m_ulPremise_Tasks_1.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_1.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_2.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_2.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_3.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_3.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_4.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_4.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_5.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_5.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_6.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_6.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_7.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_7.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_8.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_8.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_9.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_9.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_10.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_10.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_11.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_11.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_12.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_12.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_13.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_13.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_14.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_14.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_15.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_15.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_16.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_16.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_17.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_17.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_18.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_18.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_19.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_19.Text);
                        index++;
                    }
                    if (this.textBox_m_ulPremise_Tasks_20.Text != "0")
                    {
                        this.SelectedTask.m_ulPremise_Tasks[index] = Convert.ToInt32(this.textBox_m_ulPremise_Tasks_20.Text);
                        index++;
                    }
                    this.SelectedTask.m_ulPremise_Task_Count = index;
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByPreTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByPreTask != this.checkBox_m_bShowByPreTask.Checked)
                    {
                        this.SelectedTask.m_bShowByPreTask = this.checkBox_m_bShowByPreTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Task_Least_Num(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremise_Task_Least_Num != Convert.ToInt32(this.textBox_m_ulPremise_Task_Least_Num.Text))
                    {
                        this.SelectedTask.m_ulPremise_Task_Least_Num = Convert.ToInt32(this.textBox_m_ulPremise_Task_Least_Num.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Period(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    switch (this.comboBox_m_ulPremise_Period.SelectedIndex)
                    {
                        case 0:
                            this.SelectedTask.m_ulPremise_Period = 0;
                            break;
                        case 1:
                            this.SelectedTask.m_ulPremise_Period = 1;
                            break;
                        case 2:
                            this.SelectedTask.m_ulPremise_Period = 2;
                            break;
                        case 3:
                            this.SelectedTask.m_ulPremise_Period = 3;
                            break;
                        case 4:
                            this.SelectedTask.m_ulPremise_Period = 4;
                            break;
                        case 5:
                            this.SelectedTask.m_ulPremise_Period = 5;
                            break;
                        case 6:
                            this.SelectedTask.m_ulPremise_Period = 6;
                            break;
                        case 7:
                            this.SelectedTask.m_ulPremise_Period = 7;
                            break;
                        case 8:
                            this.SelectedTask.m_ulPremise_Period = 8;
                            break;
                        case 9:
                            this.SelectedTask.m_ulPremise_Period = 20;
                            break;
                        case 10:
                            this.SelectedTask.m_ulPremise_Period = 30;
                            break;
                        case 11:
                            this.SelectedTask.m_ulPremise_Period = 21;
                            break;
                        case 12:
                            this.SelectedTask.m_ulPremise_Period = 31;
                            break;
                        case 13:
                            this.SelectedTask.m_ulPremise_Period = 22;
                            break;
                        case 14:
                            this.SelectedTask.m_ulPremise_Period = 32;
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByPeriod(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByPeriod != this.checkBox_m_bShowByPeriod.Checked)
                    {
                        this.SelectedTask.m_bShowByPeriod = this.checkBox_m_bShowByPeriod.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Faction(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremise_Faction != this.comboBox_m_ulPremise_Faction.SelectedIndex)
                    {
                        this.SelectedTask.m_ulPremise_Faction = this.comboBox_m_ulPremise_Faction.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremise_FactionRole(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremise_FactionRole != this.comboBox_m_iPremise_FactionRole.SelectedIndex)
                    {
                        this.SelectedTask.m_iPremise_FactionRole = this.comboBox_m_iPremise_FactionRole.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByFaction(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByFaction != this.checkBox_m_bShowByFaction.Checked)
                    {
                        this.SelectedTask.m_bShowByFaction = this.checkBox_m_bShowByFaction.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulGender(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulGender != this.comboBox_m_ulGender.SelectedIndex)
                    {
                        this.SelectedTask.m_ulGender = this.comboBox_m_ulGender.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByGender(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByGender != this.checkBox_m_bShowByGender.Checked)
                    {
                        this.SelectedTask.m_bShowByGender = this.checkBox_m_bShowByGender.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_Occupations(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int index = 0;
                    this.SelectedTask.m_Occupations = new int[12];
                    if (this.checkBox_m_Occupations_0.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 0;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_1.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 1;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_2.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 2;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_3.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 3;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_4.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 4;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_5.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 5;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_6.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 6;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_7.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 7;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_8.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 8;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_9.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 9;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_10.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 10;
                        index++;
                    }
                    if (this.checkBox_m_Occupations_11.Checked)
                    {
                        this.SelectedTask.m_Occupations[index] = 11;
                        index++;
                    }
                    this.SelectedTask.m_ulOccupations = index;
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByOccup(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByOccup != this.checkBox_m_bShowByOccup.Checked)
                    {
                        this.SelectedTask.m_bShowByOccup = this.checkBox_m_bShowByOccup.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremise_Spouse(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremise_Spouse != this.checkBox_m_bPremise_Spouse.Checked)
                    {
                        this.SelectedTask.m_bPremise_Spouse = this.checkBox_m_bPremise_Spouse.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowBySpouse(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowBySpouse != this.checkBox_m_bShowBySpouse.Checked)
                    {
                        this.SelectedTask.m_bShowBySpouse = this.checkBox_m_bShowBySpouse.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremiseWeddingOwner(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremiseWeddingOwner != this.checkBox_m_bPremiseWeddingOwner.Checked)
                    {
                        this.SelectedTask.m_bPremiseWeddingOwner = this.checkBox_m_bPremiseWeddingOwner.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByWeddingOwner(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByWeddingOwner != this.checkBox_m_bShowByWeddingOwner.Checked)
                    {
                        this.SelectedTask.m_bShowByWeddingOwner = this.checkBox_m_bShowByWeddingOwner.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bGM(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bGM != this.checkBox_m_bGM.Checked)
                    {
                        this.SelectedTask.m_bGM = this.checkBox_m_bGM.Checked;
                        this.change_ColorAndIcon();
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShieldUser(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShieldUser != this.checkBox_m_bShieldUser.Checked)
                    {
                        this.SelectedTask.m_bShieldUser = this.checkBox_m_bShieldUser.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByRMB(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByRMB != this.checkBox_m_bShowByRMB.Checked)
                    {
                        this.SelectedTask.m_bShowByRMB = this.checkBox_m_bShowByRMB.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremRMBMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremRMBMin != Convert.ToInt32(this.textBox_m_ulPremRMBMin.Text))
                    {
                        this.SelectedTask.m_ulPremRMBMin = Convert.ToInt32(this.textBox_m_ulPremRMBMin.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremRMBMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremRMBMax != Convert.ToInt32(this.textBox_m_ulPremRMBMax.Text))
                    {
                        this.SelectedTask.m_ulPremRMBMax = Convert.ToInt32(this.textBox_m_ulPremRMBMax.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCharTime(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCharTime != this.checkBox_m_bCharTime.Checked)
                    {
                        this.SelectedTask.m_bCharTime = this.checkBox_m_bCharTime.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByCharTime(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByCharTime != this.checkBox_m_bShowByCharTime.Checked)
                    {
                        this.SelectedTask.m_bShowByCharTime = this.checkBox_m_bShowByCharTime.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iCharStartTime(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iCharStartTime != Convert.ToInt32(this.textBox_m_iCharStartTime.Text))
                    {
                        this.SelectedTask.m_iCharStartTime = Convert.ToInt32(this.textBox_m_iCharStartTime.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iCharEndTime(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iCharEndTime != Convert.ToInt32(this.textBox_m_iCharEndTime.Text))
                    {
                        this.SelectedTask.m_iCharEndTime = Convert.ToInt32(this.textBox_m_iCharEndTime.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_tmCharEndTime(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int arg_1B_0 = this.dataGridView_m_tmCharEndTime.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_tmCharEndTime.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_tmCharEndTime.year = Convert.ToInt32(this.dataGridView_m_tmCharEndTime.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_tmCharEndTime.month = Convert.ToInt32(this.dataGridView_m_tmCharEndTime.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_tmCharEndTime.day = Convert.ToInt32(this.dataGridView_m_tmCharEndTime.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_tmCharEndTime.hour = Convert.ToInt32(this.dataGridView_m_tmCharEndTime.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_tmCharEndTime.min = Convert.ToInt32(this.dataGridView_m_tmCharEndTime.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_tmCharEndTime.wday = this.Column_m_tmCharEndTime_wday.Items.IndexOf(this.dataGridView_m_tmCharEndTime.CurrentCell.Value);
                            break;
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulCharTimeGreaterThan(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulCharTimeGreaterThan != Convert.ToInt32(this.textBox_m_ulCharTimeGreaterThan.Text))
                    {
                        this.SelectedTask.m_ulCharTimeGreaterThan = Convert.ToInt32(this.textBox_m_ulCharTimeGreaterThan.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremise_Cotask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremise_Cotask != Convert.ToInt32(this.textBox_m_ulPremise_Cotask.Text))
                    {
                        this.SelectedTask.m_ulPremise_Cotask = Convert.ToInt32(this.textBox_m_ulPremise_Cotask.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulCoTaskCond(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulCoTaskCond != Convert.ToInt32(this.textBox_m_ulCoTaskCond.Text))
                    {
                        this.SelectedTask.m_ulCoTaskCond = Convert.ToInt32(this.textBox_m_ulCoTaskCond.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulMutexTasks(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int index = 0;
                    this.SelectedTask.m_ulMutexTasks = new int[5];
                    if (this.textBox_m_ulMutexTasks_1.Text != "0")
                    {
                        this.SelectedTask.m_ulMutexTasks[index] = Convert.ToInt32(this.textBox_m_ulMutexTasks_1.Text);
                        index++;
                    }
                    if (this.textBox_m_ulMutexTasks_2.Text != "0")
                    {
                        this.SelectedTask.m_ulMutexTasks[index] = Convert.ToInt32(this.textBox_m_ulMutexTasks_2.Text);
                        index++;
                    }
                    if (this.textBox_m_ulMutexTasks_3.Text != "0")
                    {
                        this.SelectedTask.m_ulMutexTasks[index] = Convert.ToInt32(this.textBox_m_ulMutexTasks_3.Text);
                        index++;
                    }
                    if (this.textBox_m_ulMutexTasks_4.Text != "0")
                    {
                        this.SelectedTask.m_ulMutexTasks[index] = Convert.ToInt32(this.textBox_m_ulMutexTasks_4.Text);
                        index++;
                    }
                    if (this.textBox_m_ulMutexTasks_5.Text != "0")
                    {
                        this.SelectedTask.m_ulMutexTasks[index] = Convert.ToInt32(this.textBox_m_ulMutexTasks_5.Text);
                        index++;
                    }
                    this.SelectedTask.m_ulMutexTaskCount = index;
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lSkillLev_0(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    //this.SelectedTask.m_lSkillLev = new int[4];
                    if (this.numericUpDown_m_lSkillLev_blacksmith.Text != "0")
                    {
                        this.SelectedTask.m_lSkillLev[0] = Convert.ToInt32(this.numericUpDown_m_lSkillLev_blacksmith.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lSkillLev_1(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.numericUpDown_m_lSkillLev_tailor.Text != "0")
                    {
                        this.SelectedTask.m_lSkillLev[1] = Convert.ToInt32(this.numericUpDown_m_lSkillLev_tailor.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lSkillLev_2(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.numericUpDown_m_lSkillLev_craftsman.Text != "0")
                    {
                        this.SelectedTask.m_lSkillLev[2] = Convert.ToInt32(this.numericUpDown_m_lSkillLev_craftsman.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_lSkillLev_3(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.numericUpDown_m_lSkillLev_apothecary.Text != "0")
                    {
                        this.SelectedTask.m_lSkillLev[3] = Convert.ToInt32(this.numericUpDown_m_lSkillLev_apothecary.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_DynTaskType(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_DynTaskType != Convert.ToByte(this.comboBox_m_DynTaskType.SelectedIndex))
                    {
                        this.SelectedTask.m_DynTaskType = Convert.ToByte(this.comboBox_m_DynTaskType.SelectedIndex);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulSpecialAward(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulSpecialAward != Convert.ToInt32(this.textBox_m_ulSpecialAward.Text))
                    {
                        this.SelectedTask.m_ulSpecialAward = Convert.ToInt32(this.textBox_m_ulSpecialAward.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bTeamwork(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bTeamwork != this.checkBox_m_bTeamwork.Checked)
                    {
                        this.SelectedTask.m_bTeamwork = this.checkBox_m_bTeamwork.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bRcvByTeam(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bRcvByTeam != this.checkBox_m_bRcvByTeam.Checked)
                    {
                        this.SelectedTask.m_bRcvByTeam = this.checkBox_m_bRcvByTeam.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bSharedTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bSharedTask != this.checkBox_m_bSharedTask.Checked)
                    {
                        this.SelectedTask.m_bSharedTask = this.checkBox_m_bSharedTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bSharedAchieved(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bSharedAchieved != this.checkBox_m_bSharedAchieved.Checked)
                    {
                        this.SelectedTask.m_bSharedAchieved = this.checkBox_m_bSharedAchieved.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCheckTeammate(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCheckTeammate != this.checkBox_m_bCheckTeammate.Checked)
                    {
                        this.SelectedTask.m_bCheckTeammate = this.checkBox_m_bCheckTeammate.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_fTeammateDist(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_fTeammateDist != Convert.ToSingle(this.textBox_m_fTeammateDist.Text))
                    {
                        this.SelectedTask.m_fTeammateDist = Convert.ToSingle(this.textBox_m_fTeammateDist.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bAllFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bAllFail != this.checkBox_m_bAllFail.Checked)
                    {
                        this.SelectedTask.m_bAllFail = this.checkBox_m_bAllFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCapFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCapFail != this.checkBox_m_bCapFail.Checked)
                    {
                        this.SelectedTask.m_bCapFail = this.checkBox_m_bCapFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCapSucc(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCapSucc != this.checkBox_m_bCapSucc.Checked)
                    {
                        this.SelectedTask.m_bCapSucc = this.checkBox_m_bCapSucc.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_fSuccDist(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_fSuccDist != Convert.ToSingle(this.textBox_m_fSuccDist.Text))
                    {
                        this.SelectedTask.m_fSuccDist = Convert.ToSingle(this.textBox_m_fSuccDist.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDismAsSelfFail(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDismAsSelfFail != this.checkBox_m_bDismAsSelfFail.Checked)
                    {
                        this.SelectedTask.m_bDismAsSelfFail = this.checkBox_m_bDismAsSelfFail.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bRcvChckMem(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bRcvChckMem != this.checkBox_m_bRcvChckMem.Checked)
                    {
                        this.SelectedTask.m_bRcvChckMem = this.checkBox_m_bRcvChckMem.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_fRcvMemDist(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_fRcvMemDist != Convert.ToSingle(this.textBox_m_fRcvMemDist.Text))
                    {
                        this.SelectedTask.m_fRcvMemDist = Convert.ToSingle(this.textBox_m_fRcvMemDist.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCntByMemPos(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCntByMemPos != this.checkBox_m_bCntByMemPos.Checked)
                    {
                        this.SelectedTask.m_bCntByMemPos = this.checkBox_m_bCntByMemPos.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_fCntMemDist(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_fCntMemDist != Convert.ToSingle(this.textBox_m_fCntMemDist.Text))
                    {
                        this.SelectedTask.m_fCntMemDist = Convert.ToSingle(this.textBox_m_fCntMemDist.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bAllSucc(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bAllSucc != this.checkBox_m_bAllSucc.Checked)
                    {
                        this.SelectedTask.m_bAllSucc = this.checkBox_m_bAllSucc.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bCoupleOnly(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bCoupleOnly != this.checkBox_m_bCoupleOnly.Checked)
                    {
                        this.SelectedTask.m_bCoupleOnly = this.checkBox_m_bCoupleOnly.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bDistinguishedOcc(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bDistinguishedOcc != this.checkBox_m_bDistinguishedOcc.Checked)
                    {
                        this.SelectedTask.m_bDistinguishedOcc = this.checkBox_m_bDistinguishedOcc.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TeamMemsWanted(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int r = this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_TeamMemsWanted.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulLevelMin = Convert.ToInt32(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulLevelMax = Convert.ToInt32(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulRace = this.dataGridViewTextBoxColumn10.Items.IndexOf(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 3:
                            if (this.dataGridViewTextBoxColumn11.Items.IndexOf(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value) > -1)
                            {
                                this.SelectedTask.m_TeamMemsWanted[r].m_ulOccupation = this.dataGridViewTextBoxColumn11.Items.IndexOf(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value) - 1;
                            }
                            else
                            {
                                this.SelectedTask.m_TeamMemsWanted[r].m_ulOccupation = 0;
                            }
                            break;
                        case 4:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulGender = this.dataGridViewTextBoxColumn12.Items.IndexOf(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulMinCount = Convert.ToInt32(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 6:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulMaxCount = Convert.ToInt32(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 7:
                            this.SelectedTask.m_TeamMemsWanted[r].m_ulTask = Convert.ToInt32(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value);
                            break;
                        case 8:
                            if (this.Column18.Items.IndexOf(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value) > 0)
                            {
                                this.SelectedTask.m_TeamMemsWanted[r].m_iForce = this.Column18.Items.IndexOf(this.dataGridView_m_TeamMemsWanted.CurrentCell.Value) + 1003;
                            }
                            else
                            {
                                this.SelectedTask.m_TeamMemsWanted[r].m_iForce = 0;
                            }
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByTeam(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByTeam != this.checkBox_m_bShowByTeam.Checked)
                    {
                        this.SelectedTask.m_bShowByTeam = this.checkBox_m_bShowByTeam.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremNeedComp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremNeedComp != this.checkBox_m_bPremNeedComp.Checked)
                    {
                        this.SelectedTask.m_bPremNeedComp = this.checkBox_m_bPremNeedComp.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_nPremExp1AndOrExp2(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_nPremExp1AndOrExp2 != this.comboBox_m_nPremExp1AndOrExp2.SelectedIndex)
                    {
                        this.SelectedTask.m_nPremExp1AndOrExp2 = this.comboBox_m_nPremExp1AndOrExp2.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_Prem1KeyValue(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int arg_1B_0 = this.dataGridView_m_Prem1KeyValue.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_Prem1KeyValue.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_Prem1KeyValue.nLeftType = this.Column29.Items.IndexOf(this.dataGridView_m_Prem1KeyValue.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_Prem1KeyValue.lLeftNum = Convert.ToInt32(this.dataGridView_m_Prem1KeyValue.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_Prem1KeyValue.nCompOper = this.Column31.Items.IndexOf(this.dataGridView_m_Prem1KeyValue.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_Prem1KeyValue.nRightType = this.Column32.Items.IndexOf(this.dataGridView_m_Prem1KeyValue.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_Prem1KeyValue.lRightNum = Convert.ToInt32(this.dataGridView_m_Prem1KeyValue.CurrentCell.Value);
                            break;
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_Prem2KeyValue(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int arg_1B_0 = this.dataGridView_m_Prem2KeyValue.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_Prem2KeyValue.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_Prem2KeyValue.nLeftType = this.dataGridViewComboBoxColumn110.Items.IndexOf(this.dataGridView_m_Prem2KeyValue.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_Prem2KeyValue.lLeftNum = Convert.ToInt32(this.dataGridView_m_Prem2KeyValue.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_Prem2KeyValue.nCompOper = this.dataGridViewComboBoxColumn112.Items.IndexOf(this.dataGridView_m_Prem2KeyValue.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_Prem2KeyValue.nRightType = this.dataGridViewComboBoxColumn113.Items.IndexOf(this.dataGridView_m_Prem2KeyValue.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_Prem2KeyValue.lRightNum = Convert.ToInt32(this.dataGridView_m_Prem2KeyValue.CurrentCell.Value);
                            break;
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremCheckForce(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremCheckForce != this.checkBox_m_bPremCheckForce.Checked)
                    {
                        this.SelectedTask.m_bPremCheckForce = this.checkBox_m_bPremCheckForce.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremForce(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.comboBox_m_iPremForce.SelectedIndex > 0)
                    {
                        try
                        {
                            this.SelectedTask.m_iPremForce = int.Parse(this.comboBox_m_iPremForce.Items[this.comboBox_m_iPremForce.SelectedIndex].ToString().Split('_')[0]);
                        }
                        catch { }
                    }
                    else
                    {
                        this.SelectedTask.m_iPremForce = 0;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByForce(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByForce != this.checkBox_m_bShowByForce.Checked)
                    {
                        this.SelectedTask.m_bShowByForce = this.checkBox_m_bShowByForce.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremForceReputation(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremForceReputation != Extensions.DigitNumberToInt32(this.textBox_m_iPremForceReputation.Text))
                    {
                        this.SelectedTask.m_iPremForceReputation = Extensions.DigitNumberToInt32(this.textBox_m_iPremForceReputation.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremForceReputation.Text = this.SelectedTask.m_iPremForceReputation.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByForceReputation(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByForceReputation != this.checkBox_m_bShowByForceReputation.Checked)
                    {
                        this.SelectedTask.m_bShowByForceReputation = this.checkBox_m_bShowByForceReputation.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremForceContribution(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremForceContribution != Extensions.DigitNumberToInt32(this.textBox_m_iPremForceContribution.Text))
                    {
                        this.SelectedTask.m_iPremForceContribution = Extensions.DigitNumberToInt32(this.textBox_m_iPremForceContribution.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremForceContribution.Text = this.SelectedTask.m_iPremForceContribution.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByForceContribution(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByForceContribution != this.checkBox_m_bShowByForceContribution.Checked)
                    {
                        this.SelectedTask.m_bShowByForceContribution = this.checkBox_m_bShowByForceContribution.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremForceExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremForceExp != Extensions.DigitNumberToInt32(this.textBox_m_iPremForceExp.Text))
                    {
                        this.SelectedTask.m_iPremForceExp = Extensions.DigitNumberToInt32(this.textBox_m_iPremForceExp.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremForceExp.Text = this.SelectedTask.m_iPremForceExp.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByForceExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByForceExp != this.checkBox_m_bShowByForceExp.Checked)
                    {
                        this.SelectedTask.m_bShowByForceExp = this.checkBox_m_bShowByForceExp.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremForceSP(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremForceSP != Extensions.DigitNumberToInt32(this.textBox_m_iPremForceSP.Text))
                    {
                        this.SelectedTask.m_iPremForceSP = Extensions.DigitNumberToInt32(this.textBox_m_iPremForceSP.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremForceSP.Text = this.SelectedTask.m_iPremForceSP.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByForceSP(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByForceSP != this.checkBox_m_bShowByForceSP.Checked)
                    {
                        this.SelectedTask.m_bShowByForceSP = this.checkBox_m_bShowByForceSP.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremForceActivityLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremForceActivityLevel != Convert.ToInt32(this.textBox_m_iPremForceActivityLevel.Text))
                    {
                        this.SelectedTask.m_iPremForceActivityLevel = Convert.ToInt32(this.textBox_m_iPremForceActivityLevel.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByForceActivityLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByForceActivityLevel != this.checkBox_m_bShowByForceActivityLevel.Checked)
                    {
                        this.SelectedTask.m_bShowByForceActivityLevel = this.checkBox_m_bShowByForceActivityLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremIsKing(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremIsKing != this.checkBox_m_bPremIsKing.Checked)
                    {
                        this.SelectedTask.m_bPremIsKing = this.checkBox_m_bPremIsKing.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByKing(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByKing != this.checkBox_m_bShowByKing.Checked)
                    {
                        this.SelectedTask.m_bShowByKing = this.checkBox_m_bShowByKing.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bPremNotInTeam(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bPremNotInTeam != this.checkBox_m_bPremNotInTeam.Checked)
                    {
                        this.SelectedTask.m_bPremNotInTeam = this.checkBox_m_bPremNotInTeam.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByNotInTeam(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByNotInTeam != this.checkBox_m_bShowByNotInTeam.Checked)
                    {
                        this.SelectedTask.m_bShowByNotInTeam = this.checkBox_m_bShowByNotInTeam.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremTitleNumRequired(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iPremTitleNumRequired != Extensions.DigitNumberToInt32(this.textBox_m_iPremTitleNumRequired.Text))
                    {
                        this.SelectedTask.m_iPremTitleNumRequired = Extensions.DigitNumberToInt32(this.textBox_m_iPremTitleNumRequired.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iPremTitleNumRequired.Text = this.SelectedTask.m_iPremTitleNumRequired.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_PremTitles(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_PremTitles.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_PremTitles.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_PremTitles[rowIndex] = Convert.ToInt32(this.dataGridView_m_PremTitles.CurrentCell.Value);
                            this.dataGridView_m_PremTitles.Rows[rowIndex].Cells[1].Value = Extensions.TitleName(this.SelectedTask.m_PremTitles[rowIndex]);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByTitle(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByTitle != this.checkBox_m_bShowByTitle.Checked)
                    {
                        this.SelectedTask.m_bShowByTitle = this.checkBox_m_bShowByTitle.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremHistoryStageIndex(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    this.SelectedTask.m_iPremHistoryStageIndex = new int[2];
                    if (this.textBox_m_iPremHistoryStageIndex_1.Text != "0")
                    {
                        this.SelectedTask.m_iPremHistoryStageIndex[0] = Convert.ToInt32(this.textBox_m_iPremHistoryStageIndex_1.Text);
                    }
                    if (this.textBox_m_iPremHistoryStageIndex_2.Text != "0")
                    {
                        this.SelectedTask.m_iPremHistoryStageIndex[1] = Convert.ToInt32(this.textBox_m_iPremHistoryStageIndex_2.Text);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByHistoryStage(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByHistoryStage != this.checkBox_m_bShowByHistoryStage.Checked)
                    {
                        this.SelectedTask.m_bShowByHistoryStage = this.checkBox_m_bShowByHistoryStage.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremGeneralCardCount(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremGeneralCardCount != Extensions.DigitNumberToInt32(this.textBox_m_ulPremGeneralCardCount.Text))
                    {
                        this.SelectedTask.m_ulPremGeneralCardCount = Extensions.DigitNumberToInt32(this.textBox_m_ulPremGeneralCardCount.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_ulPremGeneralCardCount.Text = this.SelectedTask.m_ulPremGeneralCardCount.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByGeneralCard(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByGeneralCard != this.checkBox_m_bShowByGeneralCard.Checked)
                    {
                        this.SelectedTask.m_bShowByGeneralCard = this.checkBox_m_bShowByGeneralCard.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iPremGeneralCardRank(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    switch (this.comboBox_m_iPremGeneralCardRank.SelectedIndex)
                    {
                        case 0:
                            this.SelectedTask.m_iPremGeneralCardRank = -1;
                            break;
                        case 1:
                            this.SelectedTask.m_iPremGeneralCardRank = 0;
                            break;
                        case 2:
                            this.SelectedTask.m_iPremGeneralCardRank = 1;
                            break;
                        case 3:
                            this.SelectedTask.m_iPremGeneralCardRank = 2;
                            break;
                        case 4:
                            this.SelectedTask.m_iPremGeneralCardRank = 3;
                            break;
                        case 5:
                            this.SelectedTask.m_iPremGeneralCardRank = 4;
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPremGeneralCardRankCount(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPremGeneralCardRankCount != Extensions.DigitNumberToInt32(this.textBox_m_ulPremGeneralCardRankCount.Text))
                    {
                        this.SelectedTask.m_ulPremGeneralCardRankCount = Extensions.DigitNumberToInt32(this.textBox_m_ulPremGeneralCardRankCount.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_ulPremGeneralCardRankCount.Text = this.SelectedTask.m_ulPremGeneralCardRankCount.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bShowByGeneralCardRank(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bShowByGeneralCardRank != this.checkBox_m_bShowByGeneralCardRank.Checked)
                    {
                        this.SelectedTask.m_bShowByGeneralCardRank = this.checkBox_m_bShowByGeneralCardRank.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremiseIconStateID(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremiseIconStateID != Convert.ToInt32(this.textBox_PremiseIconStateID.Text))
                    {
                        this.SelectedTask.PremiseIconStateID = Convert.ToInt32(this.textBox_PremiseIconStateID.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowBuffDesc_PremiseIconStateID();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByIconStateID(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByIconStateID != this.checkBox_ShowByIconStateID.Checked)
                    {
                        this.SelectedTask.ShowByIconStateID = this.checkBox_ShowByIconStateID.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_VIPLevelMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.VIPLevelMin != Convert.ToInt32(this.textBox_VIPLevelMin.Text))
                    {
                        this.SelectedTask.VIPLevelMin = Convert.ToInt32(this.textBox_VIPLevelMin.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_VIPLevelMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.VIPLevelMax != Convert.ToInt32(this.textBox_VIPLevelMax.Text))
                    {
                        this.SelectedTask.VIPLevelMax = Convert.ToInt32(this.textBox_VIPLevelMax.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByVIPLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByVIPLevel != this.checkBox_ShowByVIPLevel.Checked)
                    {
                        this.SelectedTask.ShowByVIPLevel = this.checkBox_ShowByVIPLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremNoHome(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremNoHome != this.checkBox_PremNoHome.Checked)
                    {
                        this.SelectedTask.PremNoHome = this.checkBox_PremNoHome.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeLevelMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeLevelMin != Convert.ToInt32(this.numericUpDown_PremHomeLevelMin.Value))
                    {
                        this.SelectedTask.PremHomeLevelMin = Convert.ToInt32(this.numericUpDown_PremHomeLevelMin.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeLevelMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeLevelMax != Convert.ToInt32(this.numericUpDown_PremHomeLevelMax.Value))
                    {
                        this.SelectedTask.PremHomeLevelMax = Convert.ToInt32(this.numericUpDown_PremHomeLevelMax.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByHomeLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByHomeLevel != this.checkBox_ShowByHomeLevel.Checked)
                    {
                        this.SelectedTask.ShowByHomeLevel = this.checkBox_ShowByHomeLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeResourceType(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeResourceType != Convert.ToInt32(this.comboBox_PremHomeResourceType.SelectedIndex))
                    {
                        this.SelectedTask.PremHomeResourceType = Convert.ToInt32(this.comboBox_PremHomeResourceType.SelectedIndex);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeResourceLevelMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeResourceLevelMin != Convert.ToInt32(this.numericUpDown_PremHomeResourceLevelMin.Value))
                    {
                        this.SelectedTask.PremHomeResourceLevelMin = Convert.ToInt32(this.numericUpDown_PremHomeResourceLevelMin.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeResourceLevelMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeResourceLevelMax != Convert.ToInt32(this.numericUpDown_PremHomeResourceLevelMax.Value))
                    {
                        this.SelectedTask.PremHomeResourceLevelMax = Convert.ToInt32(this.numericUpDown_PremHomeResourceLevelMax.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByHomeResourceLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByHomeResourceLevel != this.checkBox_ShowByHomeResourceLevel.Checked)
                    {
                        this.SelectedTask.ShowByHomeResourceLevel = this.checkBox_ShowByHomeResourceLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeFactoryType(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeFactoryType != Convert.ToInt32(this.comboBox_PremHomeFactoryType.SelectedIndex))
                    {
                        this.SelectedTask.PremHomeFactoryType = Convert.ToInt32(this.comboBox_PremHomeFactoryType.SelectedIndex);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeFactoryLevelMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeFactoryLevelMin != Convert.ToInt32(this.numericUpDown_PremHomeFactoryLevelMin.Value))
                    {
                        this.SelectedTask.PremHomeFactoryLevelMin = Convert.ToInt32(this.numericUpDown_PremHomeFactoryLevelMin.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeFactoryLevelMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeFactoryLevelMax != Convert.ToInt32(this.numericUpDown_PremHomeFactoryLevelMax.Value))
                    {
                        this.SelectedTask.PremHomeFactoryLevelMax = Convert.ToInt32(this.numericUpDown_PremHomeFactoryLevelMax.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByHomeFactoryLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByHomeFactoryLevel != this.checkBox_ShowByHomeFactoryLevel.Checked)
                    {
                        this.SelectedTask.ShowByHomeFactoryLevel = this.checkBox_ShowByHomeFactoryLevel.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeFlourishMin(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeFlourishMin != Extensions.DigitNumberToInt32(this.textBox_PremHomeFlourishMin.Text))
                    {
                        this.SelectedTask.PremHomeFlourishMin = Extensions.DigitNumberToInt32(this.textBox_PremHomeFlourishMin.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_PremHomeFlourishMin.Text = this.SelectedTask.PremHomeFlourishMin.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeFlourishMax(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeFlourishMax != Extensions.DigitNumberToInt32(this.textBox_PremHomeFlourishMax.Text))
                    {
                        this.SelectedTask.PremHomeFlourishMax = Extensions.DigitNumberToInt32(this.textBox_PremHomeFlourishMax.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_PremHomeFlourishMax.Text = this.SelectedTask.PremHomeFlourishMax.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByHomeFlourish(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByHomeFlourish != this.checkBox_ShowByHomeFlourish.Checked)
                    {
                        this.SelectedTask.ShowByHomeFlourish = this.checkBox_ShowByHomeFlourish.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_PremHomeStorageTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.PremHomeStorageTask != this.checkBox_PremHomeStorageTask.Checked)
                    {
                        this.SelectedTask.PremHomeStorageTask = this.checkBox_PremHomeStorageTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_ShowByHomeStorageTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.ShowByHomeStorageTask != this.checkBox_ShowByHomeStorageTask.Checked)
                    {
                        this.SelectedTask.ShowByHomeStorageTask = this.checkBox_ShowByHomeStorageTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_enumMethod(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_enumMethod != this.comboBox_m_enumMethod.SelectedIndex)
                    {
                        this.SelectedTask.m_enumMethod = this.comboBox_m_enumMethod.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_enumFinishType(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_enumFinishType != this.comboBox_m_enumFinishType.SelectedIndex)
                    {
                        this.SelectedTask.m_enumFinishType = this.comboBox_m_enumFinishType.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_PlayerWanted(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_PlayerWanted.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_ulPlayerNum = Extensions.DigitNumberToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_PlayerWanted.Rows[rowIndex].Cells[0].Value = this.SelectedTask.m_PlayerWanted[rowIndex].m_ulPlayerNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 1:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_ulDropItemId = Convert.ToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            this.dataGridView_m_PlayerWanted.Rows[rowIndex].Cells[2].Value = Extensions.ItemName(this.SelectedTask.m_PlayerWanted[rowIndex].m_ulDropItemId);
                            break;
                        case 3:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_ulDropItemCount = Extensions.DigitNumberToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_PlayerWanted.Rows[rowIndex].Cells[3].Value = this.SelectedTask.m_PlayerWanted[rowIndex].m_ulDropItemCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 4:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_bDropCmnItem = Convert.ToBoolean(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_fDropProb = Extensions.PercentNumberToSingle(this.dataGridView_m_PlayerWanted.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 6:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.m_ulOccupations = Convert.ToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 7:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.m_iMinLevel = Convert.ToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 8:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.m_iMaxLevel = Convert.ToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 9:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.m_iGender = this.Column27.Items.IndexOf(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 10:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.m_iForce = Convert.ToInt32(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 11:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.ModelCheck = Convert.ToBoolean(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 12:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.ModelType[0] = Convert.ToByte(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 13:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.ModelType[1] = Convert.ToByte(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                        case 14:
                            this.SelectedTask.m_PlayerWanted[rowIndex].m_Requirements.ModelType[2] = Convert.ToByte(this.dataGridView_m_PlayerWanted.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_MonsterWanted(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_MonsterWanted.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_ulMonsterTemplId = Convert.ToInt32(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            this.dataGridView_m_MonsterWanted.Rows[rowIndex].Cells[1].Value = Extensions.MonsterNPCMineName(this.SelectedTask.m_MonsterWanted[rowIndex].m_ulMonsterTemplId);
                            break;
                        case 2:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_ulMonsterNum = Extensions.DigitNumberToInt32(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_MonsterWanted.Rows[rowIndex].Cells[2].Value = this.SelectedTask.m_MonsterWanted[rowIndex].m_ulMonsterNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 3:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_ulDropItemId = Convert.ToInt32(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            this.dataGridView_m_MonsterWanted.Rows[rowIndex].Cells[4].Value = Extensions.ItemName(this.SelectedTask.m_MonsterWanted[rowIndex].m_ulDropItemId);
                            break;
                        case 5:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_ulDropItemCount = Extensions.DigitNumberToInt32(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_MonsterWanted.Rows[rowIndex].Cells[5].Value = this.SelectedTask.m_MonsterWanted[rowIndex].m_ulDropItemCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 6:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_bDropCmnItem = Convert.ToBoolean(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            break;
                        case 7:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_fDropProb = Extensions.PercentNumberToSingle(this.dataGridView_m_MonsterWanted.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 8:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_bKillerLev = Convert.ToBoolean(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            break;
                        case 9:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_iDPH = Convert.ToInt32(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            break;
                        case 10:
                            this.SelectedTask.m_MonsterWanted[rowIndex].m_iDPS = Convert.ToInt32(this.dataGridView_m_MonsterWanted.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ItemsWanted(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_ItemsWanted.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_ItemsWanted[rowIndex].m_ulItemTemplId = Convert.ToInt32(this.dataGridView_m_ItemsWanted.CurrentCell.Value);
                            this.dataGridView_m_ItemsWanted.Rows[rowIndex].Cells[1].Value = Extensions.ItemName(this.SelectedTask.m_ItemsWanted[rowIndex].m_ulItemTemplId);
                            break;
                        case 2:
                            this.SelectedTask.m_ItemsWanted[rowIndex].m_bCommonItem = Convert.ToBoolean(this.dataGridView_m_ItemsWanted.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_ItemsWanted[rowIndex].m_ulItemNum = Extensions.DigitNumberToInt32(this.dataGridView_m_ItemsWanted.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_m_ItemsWanted.Rows[rowIndex].Cells[3].Value = this.SelectedTask.m_ItemsWanted[rowIndex].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 4:
                            this.SelectedTask.m_ItemsWanted[rowIndex].m_fProb = Extensions.PercentNumberToSingle(this.dataGridView_m_ItemsWanted.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 5:
                            this.SelectedTask.m_ItemsWanted[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_m_ItemsWanted.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulGoldWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulGoldWanted != Extensions.DigitNumberToInt32(this.textBox_m_ulGoldWanted.Text))
                    {
                        this.SelectedTask.m_ulGoldWanted = Extensions.DigitNumberToInt32(this.textBox_m_ulGoldWanted.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_ulGoldWanted.Text = this.SelectedTask.m_ulGoldWanted.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iFactionContribWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iFactionContribWanted != Extensions.DigitNumberToInt32(this.textBox_m_iFactionContribWanted.Text))
                    {
                        this.SelectedTask.m_iFactionContribWanted = Extensions.DigitNumberToInt32(this.textBox_m_iFactionContribWanted.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iFactionContribWanted.Text = this.SelectedTask.m_iFactionContribWanted.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_iFactionExpContribWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_iFactionExpContribWanted != Extensions.DigitNumberToInt32(this.textBox_m_iFactionExpContribWanted.Text))
                    {
                        this.SelectedTask.m_iFactionExpContribWanted = Extensions.DigitNumberToInt32(this.textBox_m_iFactionExpContribWanted.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_m_iFactionExpContribWanted.Text = this.SelectedTask.m_iFactionExpContribWanted.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulNPCToProtect(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulNPCToProtect != Convert.ToInt32(this.textBox_m_ulNPCToProtect.Text))
                    {
                        this.SelectedTask.m_ulNPCToProtect = Convert.ToInt32(this.textBox_m_ulNPCToProtect.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulProtectTimeLen(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (Extensions.SecondsToString(this.SelectedTask.m_ulProtectTimeLen) != this.textBox_m_ulProtectTimeLen.Text)
                    {
                        this.SelectedTask.m_ulProtectTimeLen = Extensions.StringToSecond(this.textBox_m_ulProtectTimeLen.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulNPCMoving(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulNPCMoving != Convert.ToInt32(this.textBox_m_ulNPCMoving.Text))
                    {
                        this.SelectedTask.m_ulNPCMoving = Convert.ToInt32(this.textBox_m_ulNPCMoving.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulNPCDestSite(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulNPCDestSite != Convert.ToInt32(this.textBox_m_ulNPCDestSite.Text))
                    {
                        this.SelectedTask.m_ulNPCDestSite = Convert.ToInt32(this.textBox_m_ulNPCDestSite.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pReachSite(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pReachSite.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_pReachSite.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_pReachSite[rowIndex].zvMin_x = Convert.ToSingle(this.dataGridView_m_pReachSite.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_pReachSite[rowIndex].zvMin_y = Convert.ToSingle(this.dataGridView_m_pReachSite.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_pReachSite[rowIndex].zvMin_z = Convert.ToSingle(this.dataGridView_m_pReachSite.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_pReachSite[rowIndex].zvMax_x = Convert.ToSingle(this.dataGridView_m_pReachSite.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_pReachSite[rowIndex].zvMax_y = Convert.ToSingle(this.dataGridView_m_pReachSite.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_pReachSite[rowIndex].zvMax_z = Convert.ToSingle(this.dataGridView_m_pReachSite.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                    this.Convert_m_pReachSite(null, null);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulReachSiteId(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulReachSiteId != Convert.ToInt32(this.textBox_m_ulReachSiteId.Text))
                    {
                        this.SelectedTask.m_ulReachSiteId = Convert.ToInt32(this.textBox_m_ulReachSiteId.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_m_ulReachSiteId();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulWaitTime(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (Extensions.SecondsToString(this.SelectedTask.m_ulWaitTime) != this.textBox_m_ulWaitTime.Text)
                    {
                        this.SelectedTask.m_ulWaitTime = Extensions.StringToSecond(this.textBox_m_ulWaitTime.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TreasureStartZone_x(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_TreasureStartZone.x != Convert.ToSingle(this.textBox_m_TreasureStartZone_x.Text))
                    {
                        this.SelectedTask.m_TreasureStartZone.x = Convert.ToSingle(this.textBox_m_TreasureStartZone_x.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_m_TreasureStartZone();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TreasureStartZone_y(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_TreasureStartZone.y != Convert.ToSingle(this.textBox_m_TreasureStartZone_y.Text))
                    {
                        this.SelectedTask.m_TreasureStartZone.y = Convert.ToSingle(this.textBox_m_TreasureStartZone_y.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_m_TreasureStartZone();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_TreasureStartZone_z(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_TreasureStartZone.z != Convert.ToSingle(this.textBox_m_TreasureStartZone_z.Text))
                    {
                        this.SelectedTask.m_TreasureStartZone.z = Convert.ToSingle(this.textBox_m_TreasureStartZone_z.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_m_TreasureStartZone();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ucZonesNumX(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ucZonesNumX != Convert.ToByte(this.textBox_m_ucZonesNumX.Text))
                    {
                        this.SelectedTask.m_ucZonesNumX = Convert.ToByte(this.textBox_m_ucZonesNumX.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ucZonesNumZ(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ucZonesNumZ != Convert.ToByte(this.textBox_m_ucZonesNumZ.Text))
                    {
                        this.SelectedTask.m_ucZonesNumZ = Convert.ToByte(this.textBox_m_ucZonesNumZ.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ucZoneSide(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ucZoneSide != Convert.ToByte(this.textBox_m_ucZoneSide.Text))
                    {
                        this.SelectedTask.m_ucZoneSide = Convert.ToByte(this.textBox_m_ucZoneSide.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pLeaveSite(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_pLeaveSite.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_x = Convert.ToSingle(this.dataGridView_m_pLeaveSite.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_y = Convert.ToSingle(this.dataGridView_m_pLeaveSite.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_z = Convert.ToSingle(this.dataGridView_m_pLeaveSite.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_x = Convert.ToSingle(this.dataGridView_m_pLeaveSite.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_y = Convert.ToSingle(this.dataGridView_m_pLeaveSite.CurrentCell.Value);
                            break;
                        case 5:
                            this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_z = Convert.ToSingle(this.dataGridView_m_pLeaveSite.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                    this.Convert_m_pLeaveSite(null, null);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulLeaveSiteId(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulLeaveSiteId != Convert.ToInt32(this.textBox_m_ulLeaveSiteId.Text))
                    {
                        this.SelectedTask.m_ulLeaveSiteId = Convert.ToInt32(this.textBox_m_ulLeaveSiteId.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_m_ulLeaveSiteId();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bFinNeedComp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bFinNeedComp != this.checkBox_m_bFinNeedComp.Checked)
                    {
                        this.SelectedTask.m_bFinNeedComp = this.checkBox_m_bFinNeedComp.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_nFinExp1AndOrExp2(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_nFinExp1AndOrExp2 != this.comboBox_m_nFinExp1AndOrExp2.SelectedIndex)
                    {
                        this.SelectedTask.m_nFinExp1AndOrExp2 = this.comboBox_m_nFinExp1AndOrExp2.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_Fin1KeyValue(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int arg_1B_0 = this.dataGridView_m_Fin1KeyValue.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_Fin1KeyValue.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_Fin1KeyValue.nLeftType = this.Column29_1.Items.IndexOf(this.dataGridView_m_Fin1KeyValue.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_Fin1KeyValue.lLeftNum = Convert.ToInt32(this.dataGridView_m_Fin1KeyValue.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_Fin1KeyValue.nCompOper = this.Column31_1.Items.IndexOf(this.dataGridView_m_Fin1KeyValue.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_Fin1KeyValue.nRightType = this.Column32_1.Items.IndexOf(this.dataGridView_m_Fin1KeyValue.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_Fin1KeyValue.lRightNum = Convert.ToInt32(this.dataGridView_m_Fin1KeyValue.CurrentCell.Value);
                            break;
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_Fin2KeyValue(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int arg_1B_0 = this.dataGridView_m_Fin2KeyValue.CurrentCell.RowIndex;
                    switch (this.dataGridView_m_Fin2KeyValue.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.m_Fin2KeyValue.nLeftType = this.Column29_2.Items.IndexOf(this.dataGridView_m_Fin2KeyValue.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedTask.m_Fin2KeyValue.lLeftNum = Convert.ToInt32(this.dataGridView_m_Fin2KeyValue.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedTask.m_Fin2KeyValue.nCompOper = this.Column31_2.Items.IndexOf(this.dataGridView_m_Fin2KeyValue.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedTask.m_Fin2KeyValue.nRightType = this.Column32_2.Items.IndexOf(this.dataGridView_m_Fin2KeyValue.CurrentCell.Value);
                            break;
                        case 4:
                            this.SelectedTask.m_Fin2KeyValue.lRightNum = Convert.ToInt32(this.dataGridView_m_Fin2KeyValue.CurrentCell.Value);
                            break;
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pszExp(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pszExp.CurrentCell.RowIndex;
                    int columnIndex = this.dataGridView_m_pszExp.CurrentCell.ColumnIndex;
                    if (columnIndex == 0)
                    {
                        this.SelectedTask.m_pszExp[rowIndex] = Extensions.GbkString_to_ByteArray2(Convert.ToString(this.dataGridView_m_pszExp.CurrentCell.Value), 64);
                    }
                    else if (Convert.ToSingle(columnIndex) / 2 != (int)Convert.ToSingle(columnIndex / 2))
                    {
                        this.SelectedTask.m_pExpArr[rowIndex].type[((columnIndex + 1) / 2) - 1] = Convert.ToInt32(this.dataGridView_m_pszExp.CurrentCell.Value);
                    }
                    else
                    {
                        this.SelectedTask.m_pExpArr[rowIndex].value[(columnIndex / 2) - 1] = Convert.ToSingle(this.dataGridView_m_pszExp.CurrentCell.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_pTaskChar(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_m_pTaskChar.CurrentCell.RowIndex;
                    if (this.dataGridView_m_pTaskChar.CurrentCell.ColumnIndex == 0)
                    {
                        this.SelectedTask.m_pTaskChar[rowIndex] = Extensions.UnicodeString_to_ByteArray2(Convert.ToString(this.dataGridView_m_pTaskChar.CurrentCell.Value), 128);
                    }
                    this.TriggerDebug((Control)sender);
                    this.FormatingString_m_pTaskChar();
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ucTransformedForm(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ucTransformedForm != Convert.ToByte(this.textBox_m_ucTransformedForm.Text))
                    {
                        this.SelectedTask.m_ucTransformedForm = Convert.ToByte(this.textBox_m_ucTransformedForm.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulReachLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulReachLevel != Convert.ToInt32(this.numericUpDown_m_ulReachLevel.Value))
                    {
                        this.SelectedTask.m_ulReachLevel = Convert.ToInt32(this.numericUpDown_m_ulReachLevel.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulReachReincarnationCount(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulReachReincarnationCount != Convert.ToInt32(this.numericUpDown_m_ulReachReincarnationCount.Value))
                    {
                        this.SelectedTask.m_ulReachReincarnationCount = Convert.ToInt32(this.numericUpDown_m_ulReachReincarnationCount.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulReachRealmLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulReachRealmLevel != Convert.ToInt32(this.numericUpDown_m_ulReachRealmLevel.Value))
                    {
                        this.SelectedTask.m_ulReachRealmLevel = Convert.ToInt32(this.numericUpDown_m_ulReachRealmLevel.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_uiEmotion(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    switch (this.comboBox_m_uiEmotion.SelectedIndex)
                    {
                        case 0:
                            this.SelectedTask.m_uiEmotion = 0;
                            break;
                        case 1:
                            this.SelectedTask.m_uiEmotion = 1;
                            break;
                        case 2:
                            this.SelectedTask.m_uiEmotion = 2;
                            break;
                        case 3:
                            this.SelectedTask.m_uiEmotion = 3;
                            break;
                        case 4:
                            this.SelectedTask.m_uiEmotion = 4;
                            break;
                        case 5:
                            this.SelectedTask.m_uiEmotion = 5;
                            break;
                        case 6:
                            this.SelectedTask.m_uiEmotion = 6;
                            break;
                        case 7:
                            this.SelectedTask.m_uiEmotion = 7;
                            break;
                        case 8:
                            this.SelectedTask.m_uiEmotion = 8;
                            break;
                        case 9:
                            this.SelectedTask.m_uiEmotion = 9;
                            break;
                        case 10:
                            this.SelectedTask.m_uiEmotion = 10;
                            break;
                        case 11:
                            this.SelectedTask.m_uiEmotion = 11;
                            break;
                        case 12:
                            this.SelectedTask.m_uiEmotion = 12;
                            break;
                        case 13:
                            this.SelectedTask.m_uiEmotion = 13;
                            break;
                        case 14:
                            this.SelectedTask.m_uiEmotion = 14;
                            break;
                        case 15:
                            this.SelectedTask.m_uiEmotion = 15;
                            break;
                        case 16:
                            this.SelectedTask.m_uiEmotion = 16;
                            break;
                        case 17:
                            this.SelectedTask.m_uiEmotion = 17;
                            break;
                        case 18:
                            this.SelectedTask.m_uiEmotion = 18;
                            break;
                        case 19:
                            this.SelectedTask.m_uiEmotion = 19;
                            break;
                        case 20:
                            this.SelectedTask.m_uiEmotion = 20;
                            break;
                        case 21:
                            this.SelectedTask.m_uiEmotion = 21;
                            break;
                        case 22:
                            this.SelectedTask.m_uiEmotion = 22;
                            break;
                        case 23:
                            this.SelectedTask.m_uiEmotion = 23;
                            break;
                        case 24:
                            this.SelectedTask.m_uiEmotion = 24;
                            break;
                        case 25:
                            this.SelectedTask.m_uiEmotion = 25;
                            break;
                        case 26:
                            this.SelectedTask.m_uiEmotion = 26;
                            break;
                        case 27:
                            this.SelectedTask.m_uiEmotion = 27;
                            break;
                        case 28:
                            this.SelectedTask.m_uiEmotion = 28;
                            break;
                        case 29:
                            this.SelectedTask.m_uiEmotion = 29;
                            break;
                        case 30:
                            this.SelectedTask.m_uiEmotion = 30;
                            break;
                        case 31:
                            this.SelectedTask.m_uiEmotion = 31;
                            break;
                        case 32:
                            this.SelectedTask.m_uiEmotion = 1024;
                            break;
                        case 33:
                            this.SelectedTask.m_uiEmotion = 1025;
                            break;
                        case 34:
                            this.SelectedTask.m_uiEmotion = 1026;
                            break;
                        case 35:
                            this.SelectedTask.m_uiEmotion = 1027;
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_TMIconStateID(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.TMIconStateID != Convert.ToInt32(this.textBox_TMIconStateID.Text))
                    {
                        this.SelectedTask.TMIconStateID = Convert.ToInt32(this.textBox_TMIconStateID.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowBuffDesc_TMIconStateID();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_TMHomeLevelType(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.TMHomeLevelType != Convert.ToInt32(this.comboBox_TMHomeLevelType.SelectedIndex))
                    {
                        this.SelectedTask.TMHomeLevelType = Convert.ToInt32(this.comboBox_TMHomeLevelType.SelectedIndex);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_TMReachHomeLevel(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.TMReachHomeLevel != Convert.ToInt32(this.numericUpDown_TMReachHomeLevel.Value))
                    {
                        this.SelectedTask.TMReachHomeLevel = Convert.ToInt32(this.numericUpDown_TMReachHomeLevel.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_TMReachHomeFlourish(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.TMReachHomeFlourish != Extensions.DigitNumberToInt32(this.textBox_TMReachHomeFlourish.Text))
                    {
                        this.SelectedTask.TMReachHomeFlourish = Extensions.DigitNumberToInt32(this.textBox_TMReachHomeFlourish.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_TMReachHomeFlourish.Text = this.SelectedTask.TMReachHomeFlourish.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_TMHomeItem(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedTask != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_TMHomeItem.CurrentCell.RowIndex;
                    switch (this.dataGridView_TMHomeItem.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedTask.TMHomeItemData[rowIndex].m_ulItemTemplId = Convert.ToInt32(this.dataGridView_TMHomeItem.CurrentCell.Value);
                            this.dataGridView_TMHomeItem.Rows[rowIndex].Cells[1].Value = Extensions.HomeItemName(this.SelectedTask.TMHomeItemData[rowIndex].m_ulItemTemplId);
                            break;
                        case 2:
                            this.SelectedTask.TMHomeItemData[rowIndex].m_ulItemNum = Extensions.DigitNumberToInt32(this.dataGridView_TMHomeItem.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_TMHomeItem.Rows[rowIndex].Cells[2].Value = this.SelectedTask.TMHomeItemData[rowIndex].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulAwardType_S(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulAwardType_S != this.comboBox_m_ulAwardType_S.SelectedIndex)
                    {
                        this.SelectedTask.m_ulAwardType_S = this.comboBox_m_ulAwardType_S.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                        this.ShowHide();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulAwardType_F(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulAwardType_F != this.comboBox_m_ulAwardType_F.SelectedIndex)
                    {
                        this.SelectedTask.m_ulAwardType_F = this.comboBox_m_ulAwardType_F.SelectedIndex;
                        this.TriggerDebug((Control)sender);
                        this.ShowHide();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_Ratios_S(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_reward_m_AwByRatio_S.SelectedIndex;
                    if (this.radioButton_m_AwByRatio_S.Checked && selectedIndex > -1)
                    {
                        decimal num5 = this.numericUpDown_m_Ratios_S.Value;
                        if (this.SelectedTask.m_AwByRatio_S.m_Ratios[selectedIndex] != Convert.ToSingle(num5))
                        {
                            decimal num6 = this.numericUpDown_m_Ratios_S.Value;
                            this.SelectedTask.m_AwByRatio_S.m_Ratios[selectedIndex] = Convert.ToSingle(num6);
                            this.listBox_reward_m_AwByRatio_S.Items[selectedIndex] = Extensions.GetLocalization(405) + (float)this.SelectedTask.m_ulTimeLimit * this.SelectedTask.m_AwByRatio_S.m_Ratios[selectedIndex];
                            this.TriggerDebug((Control)sender);
                        }
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_Ratios_F(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_reward_m_AwByRatio_F.SelectedIndex;
                    if (this.radioButton_m_AwByRatio_F.Checked && selectedIndex > -1)
                    {
                        decimal num5 = this.numericUpDown_m_Ratios_F.Value;
                        if (this.SelectedTask.m_AwByRatio_F.m_Ratios[selectedIndex] != Convert.ToSingle(num5))
                        {
                            decimal num6 = this.numericUpDown_m_Ratios_F.Value;
                            this.SelectedTask.m_AwByRatio_F.m_Ratios[selectedIndex] = Convert.ToSingle(num6);
                            this.listBox_reward_m_AwByRatio_F.Items[selectedIndex] = Extensions.GetLocalization(405) + (float)this.SelectedTask.m_ulTimeLimit * this.SelectedTask.m_AwByRatio_F.m_Ratios[selectedIndex];
                            this.TriggerDebug((Control)sender);
                        }
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulGoldNum(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulGoldNum != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulGoldNum.Text))
                    {
                        this.SelectedReward.m_ulGoldNum = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulGoldNum.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulGoldNum.Text = this.SelectedReward.m_ulGoldNum.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulExp(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulExp != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulExp.Text))
                    {
                        this.SelectedReward.m_ulExp = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulExp.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulExp.Text = this.SelectedReward.m_ulExp.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                        this.CalculationExpAndSPDependingOnLvlAndNum(null, null);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulRealmExp(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulRealmExp != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulRealmExp.Text))
                    {
                        this.SelectedReward.m_ulRealmExp = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulRealmExp.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulRealmExp.Text = this.SelectedReward.m_ulRealmExp.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bExpandRealmLevelMax(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bExpandRealmLevelMax != this.checkBox_reward_m_bExpandRealmLevelMax.Checked)
                    {
                        this.SelectedReward.m_bExpandRealmLevelMax = this.checkBox_reward_m_bExpandRealmLevelMax.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulNewTask(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulNewTask != Convert.ToInt32(this.textBox_reward_m_ulNewTask.Text))
                    {
                        this.SelectedReward.m_ulNewTask = Convert.ToInt32(this.textBox_reward_m_ulNewTask.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulSP(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulSP != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulSP.Text))
                    {
                        this.SelectedReward.m_ulSP = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulSP.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulSP.Text = this.SelectedReward.m_ulSP.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                        this.CalculationExpAndSPDependingOnLvlAndNum(null, null);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_lReputation(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_lReputation != Extensions.DigitNumberToInt32(this.textBox_reward_m_lReputation.Text))
                    {
                        this.SelectedReward.m_lReputation = Extensions.DigitNumberToInt32(this.textBox_reward_m_lReputation.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_lReputation.Text = this.SelectedReward.m_lReputation.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulNewPeriod(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    switch (this.comboBox_reward_m_ulNewPeriod.SelectedIndex)
                    {
                        case 0:
                            this.SelectedReward.m_ulNewPeriod = 0;
                            break;
                        case 1:
                            this.SelectedReward.m_ulNewPeriod = 1;
                            break;
                        case 2:
                            this.SelectedReward.m_ulNewPeriod = 2;
                            break;
                        case 3:
                            this.SelectedReward.m_ulNewPeriod = 3;
                            break;
                        case 4:
                            this.SelectedReward.m_ulNewPeriod = 4;
                            break;
                        case 5:
                            this.SelectedReward.m_ulNewPeriod = 5;
                            break;
                        case 6:
                            this.SelectedReward.m_ulNewPeriod = 6;
                            break;
                        case 7:
                            this.SelectedReward.m_ulNewPeriod = 7;
                            break;
                        case 8:
                            this.SelectedReward.m_ulNewPeriod = 8;
                            break;
                        case 9:
                            this.SelectedReward.m_ulNewPeriod = 20;
                            break;
                        case 10:
                            this.SelectedReward.m_ulNewPeriod = 30;
                            break;
                        case 11:
                            this.SelectedReward.m_ulNewPeriod = 21;
                            break;
                        case 12:
                            this.SelectedReward.m_ulNewPeriod = 31;
                            break;
                        case 13:
                            this.SelectedReward.m_ulNewPeriod = 22;
                            break;
                        case 14:
                            this.SelectedReward.m_ulNewPeriod = 32;
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulNewRelayStation(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulNewRelayStation != Convert.ToInt32(this.textBox_reward_m_ulNewRelayStation.Text))
                    {
                        this.SelectedReward.m_ulNewRelayStation = Convert.ToInt32(this.textBox_reward_m_ulNewRelayStation.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowRelayStationName_Award_m_ulNewRelayStation();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulStorehouseSize(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulStorehouseSize != Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize.Text))
                    {
                        this.SelectedReward.m_ulStorehouseSize = Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulStorehouseSize2(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulStorehouseSize2 != Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize2.Text))
                    {
                        this.SelectedReward.m_ulStorehouseSize2 = Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize2.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulStorehouseSize3(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulStorehouseSize3 != Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize3.Text))
                    {
                        this.SelectedReward.m_ulStorehouseSize3 = Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize3.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulStorehouseSize4(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulStorehouseSize4 != Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize4.Text))
                    {
                        this.SelectedReward.m_ulStorehouseSize4 = Convert.ToInt32(this.textBox_reward_m_ulStorehouseSize4.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_lInventorySize(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_lInventorySize != Convert.ToInt32(this.textBox_reward_m_lInventorySize.Text))
                    {
                        this.SelectedReward.m_lInventorySize = Convert.ToInt32(this.textBox_reward_m_lInventorySize.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulPetInventorySize(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulPetInventorySize != Convert.ToInt32(this.textBox_reward_m_ulPetInventorySize.Text))
                    {
                        this.SelectedReward.m_ulPetInventorySize = Convert.ToInt32(this.textBox_reward_m_ulPetInventorySize.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulFuryULimit(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulFuryULimit != Convert.ToInt32(this.textBox_reward_m_ulFuryULimit.Text))
                    {
                        this.SelectedReward.m_ulFuryULimit = Convert.ToInt32(this.textBox_reward_m_ulFuryULimit.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulTransWldId(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulTransWldId != Convert.ToInt32(this.textBox_reward_m_ulTransWldId.Text))
                    {
                        this.SelectedReward.m_ulTransWldId = Convert.ToInt32(this.textBox_reward_m_ulTransWldId.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowInstanceName_Award_m_ulTransWldId();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_TransPt_x(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_TransPt.x != Convert.ToSingle(this.textBox_reward_m_TransPt_x.Text))
                    {
                        this.SelectedReward.m_TransPt.x = Convert.ToSingle(this.textBox_reward_m_TransPt_x.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_reward_m_TransPt();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_TransPt_y(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_TransPt.y != Convert.ToSingle(this.textBox_reward_m_TransPt_y.Text))
                    {
                        this.SelectedReward.m_TransPt.y = Convert.ToSingle(this.textBox_reward_m_TransPt_y.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_reward_m_TransPt();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_TransPt_z(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_TransPt.z != Convert.ToSingle(this.textBox_reward_m_TransPt_z.Text))
                    {
                        this.SelectedReward.m_TransPt.z = Convert.ToSingle(this.textBox_reward_m_TransPt_z.Text);
                        this.TriggerDebug((Control)sender);
                        this.Convert_reward_m_TransPt();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_lMonsCtrl(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_lMonsCtrl != Convert.ToInt32(this.textBox_reward_m_lMonsCtrl.Text))
                    {
                        this.SelectedReward.m_lMonsCtrl = Convert.ToInt32(this.textBox_reward_m_lMonsCtrl.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bTrigCtrl(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bTrigCtrl != this.checkBox_reward_m_bTrigCtrl.Checked)
                    {
                        this.SelectedReward.m_bTrigCtrl = (this.checkBox_reward_m_bTrigCtrl.Checked);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bUseLevCo(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bUseLevCo != this.checkBox_reward_m_bUseLevCo.Checked)
                    {
                        this.SelectedReward.m_bUseLevCo = (this.checkBox_reward_m_bUseLevCo.Checked);
                        this.TriggerDebug((Control)sender);
                        this.ShowHide();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bDivorce(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bDivorce != this.checkBox_reward_m_bDivorce.Checked)
                    {
                        this.SelectedReward.m_bDivorce = (this.checkBox_reward_m_bDivorce.Checked);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bSendMsg(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bSendMsg != this.checkBox_reward_m_bSendMsg.Checked)
                    {
                        this.SelectedReward.m_bSendMsg = (this.checkBox_reward_m_bSendMsg.Checked);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_nMsgChannel(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_nMsgChannel != Convert.ToInt32(this.comboBox_reward_m_nMsgChannel.SelectedIndex))
                    {
                        this.SelectedReward.m_nMsgChannel = Convert.ToInt32(this.comboBox_reward_m_nMsgChannel.SelectedIndex);
                        this.TriggerDebug((Control)sender);
                        this.FormatingString(2);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulCandItems(object sender, EventArgs e)
        {
           if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulCandItems != Convert.ToInt32(this.numericUpDown_reward_m_ulCandItems.Value))
                    {
                        this.SelectedReward.m_ulCandItems = Convert.ToInt32(this.numericUpDown_reward_m_ulCandItems.Value);
                        this.toolStripComboBox1.SelectedIndex = -1;
                        this.toolStripComboBox1_1.SelectedIndex = -1;
                        if (this.SelectedReward.m_CandItems.Length < this.SelectedReward.m_ulCandItems)
                        {
                            Array.Resize<AWARD_ITEMS_CAND>(ref this.SelectedReward.m_CandItems, this.SelectedReward.m_ulCandItems);
                            for (int i = this.checkedListBox_reward_canditems_m_bRandChoose.Items.Count; i < this.SelectedReward.m_ulCandItems; i++)
                            {
                                this.SelectedReward.m_CandItems[i] = new AWARD_ITEMS_CAND();
                                this.SelectedReward.m_CandItems[i].m_AwardItems = new ITEM_WANTED[0];
                                this.checkedListBox_reward_canditems_m_bRandChoose.Items.Add("[" + (i + 1).ToString() + "]" + Extensions.GetLocalization(406), false);
                                this.toolStripComboBox1.Items.Add("[" + (i + 1).ToString() + "]" + Extensions.GetLocalization(406));
                                this.toolStripComboBox1_1.Items.Add("[" + (i + 1).ToString() + "]" + Extensions.GetLocalization(406));
                                if (this.SelectedReward != null && this.SelectedReward.m_ulCandItems == 1)
                                {
                                    this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = 0;
                                }
                            }
                        }
                        if (this.SelectedReward.m_CandItems.Length > this.SelectedReward.m_ulCandItems)
                        {
                            AWARD_ITEMS_CAND[] temp = new AWARD_ITEMS_CAND[this.SelectedReward.m_ulCandItems];
                            Array.Copy(this.SelectedReward.m_CandItems, temp, temp.Length);
                            this.SelectedReward.m_CandItems = temp;
                            for (int j = 0; j < this.dataGridView_reward_item_m_AwardItems.RowCount; j++)
                            {
                                if (Convert.ToInt32(this.dataGridView_reward_item_m_AwardItems.Rows[j].Cells[0].Value) >= this.SelectedReward.m_ulCandItems)
                                {
                                    this.dataGridView_reward_item_m_AwardItems.Rows.RemoveAt(j);
                                    j--;
                                }
                            }
                            for (int k = this.SelectedReward.m_ulCandItems; k < this.checkedListBox_reward_canditems_m_bRandChoose.Items.Count; k++)
                            {
                                this.checkedListBox_reward_canditems_m_bRandChoose.Items.RemoveAt(k);
                                this.toolStripComboBox1.Items.RemoveAt(k);
                                this.toolStripComboBox1_1.Items.RemoveAt(k);
                            }
                        }
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_canditems_m_bRandChoose(object sender, ItemCheckEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_CandItems[e.Index].m_bRandChoose != (e.NewValue == CheckState.Checked))
                    {
                        this.SelectedReward.m_CandItems[e.Index].m_bRandChoose = (e.NewValue == CheckState.Checked);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_items_m_AwardItems(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int selectedIndex = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                    int rowIndex = this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_item_m_AwardItems.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_ulItemTemplId = Convert.ToInt32(this.dataGridView_reward_item_m_AwardItems.CurrentCell.Value);
                            this.dataGridView_reward_item_m_AwardItems.Rows[rowIndex].Cells[1].Value = Extensions.ItemName(this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_ulItemTemplId);
                            break;
                        case 2:
                            this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_bCommonItem = Convert.ToBoolean(this.dataGridView_reward_item_m_AwardItems.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_ulItemNum = Extensions.DigitNumberToInt32(this.dataGridView_reward_item_m_AwardItems.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_reward_item_m_AwardItems.Rows[rowIndex].Cells[3].Value = this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 4:
                            this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_fProb = Extensions.PercentNumberToSingle(this.dataGridView_reward_item_m_AwardItems.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 5:
                            this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_reward_item_m_AwardItems.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bRandChoose(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_SummonedMonsters.m_bRandChoose != this.checkBox_reward_m_bRandChoose.Checked)
                    {
                        this.SelectedReward.m_SummonedMonsters.m_bRandChoose = this.checkBox_reward_m_bRandChoose.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulSummonRadius(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_SummonedMonsters.m_ulSummonRadius != Convert.ToInt32(this.textBox_reward_m_ulSummonRadius.Text))
                    {
                        this.SelectedReward.m_SummonedMonsters.m_ulSummonRadius = Convert.ToInt32(this.textBox_reward_m_ulSummonRadius.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bDeathDisappear(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_SummonedMonsters.m_bDeathDisappear != this.checkBox_reward_m_bDeathDisappear.Checked)
                    {
                        this.SelectedReward.m_SummonedMonsters.m_bDeathDisappear = this.checkBox_reward_m_bDeathDisappear.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_Monsters(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_m_Monsters.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_SummonedMonsters.m_Monsters[rowIndex].m_ulMonsterTemplId = Convert.ToInt32(this.dataGridView_reward_m_Monsters.CurrentCell.Value);
                            this.dataGridView_reward_m_Monsters.Rows[rowIndex].Cells[1].Value = Extensions.MonsterNPCMineName(this.SelectedReward.m_SummonedMonsters.m_Monsters[rowIndex].m_ulMonsterTemplId);
                            break;
                        case 2:
                            this.SelectedReward.m_SummonedMonsters.m_Monsters[rowIndex].m_ulMonsterNum = Extensions.DigitNumberToInt32(this.dataGridView_reward_m_Monsters.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_reward_m_Monsters.Rows[rowIndex].Cells[2].Value = this.SelectedReward.m_SummonedMonsters.m_Monsters[rowIndex].m_ulMonsterNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 3:
                            this.SelectedReward.m_SummonedMonsters.m_Monsters[rowIndex].m_fSummonProb = Extensions.PercentNumberToSingle(this.dataGridView_reward_m_Monsters.CurrentCell.Value, lEnableShowPercents);
                            break;
                        case 4:
                            this.SelectedReward.m_SummonedMonsters.m_Monsters[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_reward_m_Monsters.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bAwardDeath(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bAwardDeath != this.checkBox_reward_m_bAwardDeath.Checked)
                    {
                        this.SelectedReward.m_bAwardDeath = this.checkBox_reward_m_bAwardDeath.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bAwardDeathWithLoss(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bAwardDeathWithLoss != this.checkBox_reward_m_bAwardDeathWithLoss.Checked)
                    {
                        this.SelectedReward.m_bAwardDeathWithLoss = this.checkBox_reward_m_bAwardDeathWithLoss.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulDividend(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulDividend != Convert.ToInt32(this.textBox_reward_m_ulDividend.Text))
                    {
                        this.SelectedReward.m_ulDividend = Convert.ToInt32(this.textBox_reward_m_ulDividend.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bAwardSkill(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bAwardSkill != this.checkBox_reward_m_bAwardSkill.Checked)
                    {
                        this.SelectedReward.m_bAwardSkill = (this.checkBox_reward_m_bAwardSkill.Checked);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iAwardSkillID(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iAwardSkillID != Convert.ToInt32(this.textBox_reward_m_iAwardSkillID.Text))
                    {
                        this.SelectedReward.m_iAwardSkillID = Convert.ToInt32(this.textBox_reward_m_iAwardSkillID.Text);
                        this.TriggerDebug((Control)sender);
                        this.ShowSkillText_Award_m_iAwardSkillID();
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iAwardSkillLevel(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iAwardSkillLevel != Convert.ToInt32(this.numericUpDown_reward_m_iAwardSkillLevel.Value))
                    {
                        this.SelectedReward.m_iAwardSkillLevel = Convert.ToInt32(this.numericUpDown_reward_m_iAwardSkillLevel.Value);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_AwardSoloTowerChallengeScore(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.AwardSoloTowerChallengeScore != Extensions.DigitNumberToInt32(this.textBox_reward_AwardSoloTowerChallengeScore.Text))
                    {
                        this.SelectedReward.AwardSoloTowerChallengeScore = Extensions.DigitNumberToInt32(this.textBox_reward_AwardSoloTowerChallengeScore.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardSoloTowerChallengeScore.Text = this.SelectedReward.AwardSoloTowerChallengeScore.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulSpecifyContribTaskID(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulSpecifyContribTaskID != Convert.ToInt32(this.textBox_reward_m_ulSpecifyContribTaskID.Text))
                    {
                        this.SelectedReward.m_ulSpecifyContribTaskID = Convert.ToInt32(this.textBox_reward_m_ulSpecifyContribTaskID.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulSpecifyContribSubTaskID(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulSpecifyContribSubTaskID != Convert.ToInt32(this.textBox_reward_m_ulSpecifyContribSubTaskID.Text))
                    {
                        this.SelectedReward.m_ulSpecifyContribSubTaskID = Convert.ToInt32(this.textBox_reward_m_ulSpecifyContribSubTaskID.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulSpecifyContrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulSpecifyContrib != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulSpecifyContrib.Text))
                    {
                        this.SelectedReward.m_ulSpecifyContrib = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulSpecifyContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulSpecifyContrib.Text = this.SelectedReward.m_ulSpecifyContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulContrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulContrib != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulContrib.Text))
                    {
                        this.SelectedReward.m_ulContrib = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulContrib.Text = this.SelectedReward.m_ulContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulRandContrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulRandContrib != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulRandContrib.Text))
                    {
                        this.SelectedReward.m_ulRandContrib = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulRandContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulRandContrib.Text = this.SelectedReward.m_ulRandContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulLowestcontrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_ulLowestcontrib != Extensions.DigitNumberToInt32(this.textBox_reward_m_ulLowestcontrib.Text))
                    {
                        this.SelectedReward.m_ulLowestcontrib = Extensions.DigitNumberToInt32(this.textBox_reward_m_ulLowestcontrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_ulLowestcontrib.Text = this.SelectedReward.m_ulLowestcontrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iFactionContrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iFactionContrib != Extensions.DigitNumberToInt32(this.textBox_reward_m_iFactionContrib.Text))
                    {
                        this.SelectedReward.m_iFactionContrib = Extensions.DigitNumberToInt32(this.textBox_reward_m_iFactionContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_iFactionContrib.Text = this.SelectedReward.m_iFactionContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iFactionExpContrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iFactionExpContrib != Extensions.DigitNumberToInt32(this.textBox_reward_m_iFactionExpContrib.Text))
                    {
                        this.SelectedReward.m_iFactionExpContrib = Extensions.DigitNumberToInt32(this.textBox_reward_m_iFactionExpContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_iFactionExpContrib.Text = this.SelectedReward.m_iFactionExpContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bAwardByProf(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_PQRankingAward.m_bAwardByProf != this.checkBox_reward_m_bAwardByProf.Checked)
                    {
                        this.SelectedReward.m_PQRankingAward.m_bAwardByProf = this.checkBox_reward_m_bAwardByProf.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_RankingAward(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_m_RankingAward.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_iRankingStart = Extensions.DigitNumberToInt32(this.dataGridView_reward_m_RankingAward.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_reward_m_RankingAward.Rows[rowIndex].Cells[0].Value = this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_iRankingStart.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 1:
                            this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_iRankingEnd = Extensions.DigitNumberToInt32(this.dataGridView_reward_m_RankingAward.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_reward_m_RankingAward.Rows[rowIndex].Cells[1].Value = this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_iRankingEnd.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 2:
                            this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_bCommonItem = Convert.ToBoolean(this.dataGridView_reward_m_RankingAward.CurrentCell.Value);
                            break;
                        case 3:
                            this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_ulAwardItemId = Convert.ToInt32(this.dataGridView_reward_m_RankingAward.CurrentCell.Value);
                            this.dataGridView_reward_m_RankingAward.Rows[rowIndex].Cells[4].Value = Extensions.ItemName(this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_ulAwardItemId);
                            break;
                        case 5:
                            this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_ulAwardItemNum = Extensions.DigitNumberToInt32(this.dataGridView_reward_m_RankingAward.CurrentCell.Value);
                            if (lEnableShowDigits == true) this.dataGridView_reward_m_RankingAward.Rows[rowIndex].Cells[5].Value = this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_ulAwardItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            break;
                        case 6:
                            this.SelectedReward.m_PQRankingAward.m_RankingAward[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_reward_m_RankingAward.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulChangeKey(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_m_ulChangeKey.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_plChangeKey[rowIndex] = Convert.ToInt32(this.dataGridView_reward_m_ulChangeKey.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedReward.m_plChangeKeyValue[rowIndex] = Convert.ToInt32(this.dataGridView_reward_m_ulChangeKey.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedReward.m_pbChangeType[rowIndex] = Convert.ToBoolean(this.dataGridViewTextBoxColumn100.Items.IndexOf(this.dataGridView_reward_m_ulChangeKey.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_ulHistoryChange(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_m_ulHistoryChange.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_plHistoryChangeKey[rowIndex] = Convert.ToInt32(this.dataGridView_reward_m_ulHistoryChange.CurrentCell.Value);
                            break;
                        case 1:
                            this.SelectedReward.m_plHistoryChangeKeyValue[rowIndex] = Convert.ToInt32(this.dataGridView_reward_m_ulHistoryChange.CurrentCell.Value);
                            break;
                        case 2:
                            this.SelectedReward.m_pbHistoryChangeType[rowIndex] = Convert.ToBoolean(this.Column282.Items.IndexOf(this.dataGridView_reward_m_ulHistoryChange.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_bMulti(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_bMulti != this.checkBox_reward_m_bMulti.Checked)
                    {
                        this.SelectedReward.m_bMulti = (this.checkBox_reward_m_bMulti.Checked);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_nNumType(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_nNumType != Convert.ToInt32(this.textBox_reward_m_nNumType.Text))
                    {
                        this.SelectedReward.m_nNumType = Convert.ToInt32(this.textBox_reward_m_nNumType.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_lNum(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_lNum != Convert.ToInt32(this.textBox_reward_m_lNum.Text))
                    {
                        this.SelectedReward.m_lNum = Convert.ToInt32(this.textBox_reward_m_lNum.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_plDisplayKey(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_m_plDisplayKey.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_plDisplayKey[rowIndex] = Convert.ToInt32(this.dataGridView_reward_m_plDisplayKey.CurrentCell.Value);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_pszExp(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex;
                    int columnIndex = this.dataGridView_reward_m_pszExp.CurrentCell.ColumnIndex;
                    if (columnIndex == 0)
                    {
                        this.SelectedReward.m_pszExp[rowIndex] = Extensions.GbkString_to_ByteArray2(Convert.ToString(this.dataGridView_reward_m_pszExp.CurrentCell.Value), 64);
                    }
                    else if (Convert.ToSingle(columnIndex) / 2 != (int)Convert.ToSingle(columnIndex / 2))
                    {
                        this.SelectedReward.m_pExpArr[rowIndex].type[((columnIndex + 1) / 2) - 1] = Convert.ToInt32(this.dataGridView_reward_m_pszExp.CurrentCell.Value);
                    }
                    else
                    {
                        this.SelectedReward.m_pExpArr[rowIndex].value[(columnIndex / 2) - 1] = Convert.ToSingle(this.dataGridView_reward_m_pszExp.CurrentCell.Value);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_pTaskChar(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex;
                    if (this.dataGridView_reward_m_pTaskChar.CurrentCell.ColumnIndex == 0)
                    {
                        this.SelectedReward.m_pTaskChar[rowIndex] = Extensions.GbkString_to_ByteArray2(Convert.ToString(this.dataGridView_reward_m_pTaskChar.CurrentCell.Value), 128);
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iForceContribution(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iForceContribution != Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceContribution.Text))
                    {
                        this.SelectedReward.m_iForceContribution = Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceContribution.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_iForceContribution.Text = this.SelectedReward.m_iForceContribution.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iForceReputation(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iForceReputation != Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceReputation.Text))
                    {
                        this.SelectedReward.m_iForceReputation = Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceReputation.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_iForceReputation.Text = this.SelectedReward.m_iForceReputation.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iForceActivity(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iForceActivity != Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceActivity.Text))
                    {
                        this.SelectedReward.m_iForceActivity = Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceActivity.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_iForceActivity.Text = this.SelectedReward.m_iForceActivity.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iForceSetRepu(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iForceSetRepu != Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceSetRepu.Text))
                    {
                        this.SelectedReward.m_iForceSetRepu = Extensions.DigitNumberToInt32(this.textBox_reward_m_iForceSetRepu.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_m_iForceSetRepu.Text = this.SelectedReward.m_iForceSetRepu.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iTaskLimit(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iTaskLimit != Convert.ToInt32(this.textBox_reward_m_iTaskLimit.Text))
                    {
                        this.SelectedReward.m_iTaskLimit = Convert.ToInt32(this.textBox_reward_m_iTaskLimit.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_pTitleAward(object sender, DataGridViewCellEventArgs e)
        {
            if (TaskEditor.LockedChange == false && this.SelectedReward != null)
            {
                try
                {
                    int rowIndex = this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex;
                    switch (this.dataGridView_reward_m_pTitleAward.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            this.SelectedReward.m_pTitleAward[rowIndex].m_ulTitleID = Convert.ToInt32(this.dataGridView_reward_m_pTitleAward.CurrentCell.Value);
                            this.dataGridView_reward_m_pTitleAward.Rows[rowIndex].Cells[1].Value = Extensions.TitleName(this.SelectedReward.m_pTitleAward[rowIndex].m_ulTitleID);
                            break;
                        case 2:
                            this.SelectedReward.m_pTitleAward[rowIndex].m_lPeriod = Extensions.StringToSecond(Convert.ToString(this.dataGridView_reward_m_pTitleAward.CurrentCell.Value));
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_m_iLeaderShip(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.m_iLeaderShip != Convert.ToInt32(this.textBox_reward_m_iLeaderShip.Text))
                    {
                        this.SelectedReward.m_iLeaderShip = Convert.ToInt32(this.textBox_reward_m_iLeaderShip.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_AwardWorldContrib(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.AwardWorldContrib != Extensions.DigitNumberToInt32(this.textBox_reward_AwardWorldContrib.Text))
                    {
                        this.SelectedReward.AwardWorldContrib = Extensions.DigitNumberToInt32(this.textBox_reward_AwardWorldContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardWorldContrib.Text = this.SelectedReward.AwardWorldContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_AwardHomeResource(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    this.SelectedReward.AwardHomeResource = new int[5];
                    if (this.textBox_reward_AwardHomeResource_1.Text != "0")
                    {
                        this.SelectedReward.AwardHomeResource[0] = Extensions.DigitNumberToInt32(this.textBox_reward_AwardHomeResource_1.Text);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardHomeResource_1.Text = this.SelectedReward.AwardHomeResource[0].ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                    if (this.textBox_reward_AwardHomeResource_2.Text != "0")
                    {
                        this.SelectedReward.AwardHomeResource[1] = Extensions.DigitNumberToInt32(this.textBox_reward_AwardHomeResource_2.Text);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardHomeResource_2.Text = this.SelectedReward.AwardHomeResource[1].ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                    if (this.textBox_reward_AwardHomeResource_3.Text != "0")
                    {
                        this.SelectedReward.AwardHomeResource[2] = Extensions.DigitNumberToInt32(this.textBox_reward_AwardHomeResource_3.Text);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardHomeResource_3.Text = this.SelectedReward.AwardHomeResource[2].ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                    if (this.textBox_reward_AwardHomeResource_4.Text != "0")
                    {
                        this.SelectedReward.AwardHomeResource[3] = Extensions.DigitNumberToInt32(this.textBox_reward_AwardHomeResource_4.Text);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardHomeResource_4.Text = this.SelectedReward.AwardHomeResource[3].ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                    if (this.textBox_reward_AwardHomeResource_5.Text != "0")
                    {
                        this.SelectedReward.AwardHomeResource[4] = Extensions.DigitNumberToInt32(this.textBox_reward_AwardHomeResource_5.Text);
                        if (lEnableShowDigits == true) this.textBox_reward_AwardHomeResource_5.Text = this.SelectedReward.AwardHomeResource[4].ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_reward_AwardCreateHome(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                try
                {
                    if (this.SelectedReward.AwardCreateHome != this.checkBox_reward_AwardCreateHome.Checked)
                    {
                        this.SelectedReward.AwardCreateHome = this.checkBox_reward_AwardCreateHome.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulParent(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulParent != Convert.ToInt32(this.textBox_m_ulParent.Text))
                    {
                        this.SelectedTask.m_ulParent = Convert.ToInt32(this.textBox_m_ulParent.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulPrevSibling(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulPrevSibling != Convert.ToInt32(this.textBox_m_ulPrevSibling.Text))
                    {
                        this.SelectedTask.m_ulPrevSibling = Convert.ToInt32(this.textBox_m_ulPrevSibling.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulNextSibling(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulNextSibling != Convert.ToInt32(this.textBox_m_ulNextSibling.Text))
                    {
                        this.SelectedTask.m_ulNextSibling = Convert.ToInt32(this.textBox_m_ulNextSibling.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_ulFirstChild(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_ulFirstChild != Convert.ToInt32(this.textBox_m_ulFirstChild.Text))
                    {
                        this.SelectedTask.m_ulFirstChild = Convert.ToInt32(this.textBox_m_ulFirstChild.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bIsLibraryTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bIsLibraryTask != this.checkBox_m_bIsLibraryTask.Checked)
                    {
                        this.SelectedTask.m_bIsLibraryTask = this.checkBox_m_bIsLibraryTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_fLibraryTasksProbability(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_fLibraryTasksProbability != Extensions.PercentNumberToSingle(this.textBox_m_fLibraryTasksProbability.Text, lEnableShowPercents))
                    {
                        this.SelectedTask.m_fLibraryTasksProbability = Extensions.PercentNumberToSingle(this.textBox_m_fLibraryTasksProbability.Text, lEnableShowPercents);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_m_bIsUniqueStorageTask(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.m_bIsUniqueStorageTask != this.checkBox_m_bIsUniqueStorageTask.Checked)
                    {
                        this.SelectedTask.m_bIsUniqueStorageTask = this.checkBox_m_bIsUniqueStorageTask.Checked;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_WorldContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.WorldContrib != Extensions.DigitNumberToInt32(this.textBox_WorldContrib.Text))
                    {
                        this.SelectedTask.WorldContrib = Extensions.DigitNumberToInt32(this.textBox_WorldContrib.Text);
                        this.TriggerDebug((Control)sender);
                        if (lEnableShowDigits == true) this.textBox_WorldContrib.Text = this.SelectedTask.WorldContrib.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"));
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_m_pwstrDescript(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.conversation.Descript != this.textBox_conversation_m_pwstrDescript.Text)
                    {
                        this.SelectedTask.conversation.Descript = this.textBox_conversation_m_pwstrDescript.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_m_pwstrOkText(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.conversation.OkText != this.textBox_conversation_m_pwstrOkText.Text)
                    {
                        this.SelectedTask.conversation.OkText = this.textBox_conversation_m_pwstrOkText.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_m_pwstrNoText(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.conversation.NoText != this.textBox_conversation_m_pwstrNoText.Text)
                    {
                        this.SelectedTask.conversation.NoText = this.textBox_conversation_m_pwstrNoText.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_m_pwstrTribute(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    if (this.SelectedTask.conversation.Tribute != this.textBox_conversation_m_pwstrTribute.Text)
                    {
                        this.SelectedTask.conversation.Tribute = this.textBox_conversation_m_pwstrTribute.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_talk_proc_id_talk(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    if (selectedIndex > -1 && this.SelectedTask.talk_procs[selectedIndex].id_talk != Convert.ToInt32(this.textBox_conversation_talk_proc_id_talk.Text))
                    {
                        this.SelectedTask.talk_procs[selectedIndex].id_talk = Convert.ToInt32(this.textBox_conversation_talk_proc_id_talk.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_talk_proc_text(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    if (selectedIndex > -1 && this.SelectedTask.talk_procs[selectedIndex].DialogText != this.textBox_conversation_talk_proc_text.Text)
                    {
                        this.SelectedTask.talk_procs[selectedIndex].DialogText = this.textBox_conversation_talk_proc_text.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_window_id(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    if (selectedIndex > -1 && index > -1 && this.SelectedTask.talk_procs[selectedIndex].windows[index].id != Convert.ToInt32(this.textBox_conversation_window_id.Text))
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[index].id = Convert.ToInt32(this.textBox_conversation_window_id.Text);
                        this.listBox_conversation_windows.Items[index] = "[" + this.textBox_conversation_window_id.Text + "]" + Extensions.GetLocalization(408);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_window_id_parent(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    if (selectedIndex > -1 && index > -1 && this.SelectedTask.talk_procs[selectedIndex].windows[index].id_parent != Convert.ToInt32(this.textBox_conversation_window_id_parent.Text))
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[index].id_parent = Convert.ToInt32(this.textBox_conversation_window_id_parent.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_window_talk_text(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    if (selectedIndex > -1 && index > -1 && this.SelectedTask.talk_procs[selectedIndex].windows[index].talktext != this.textBox_conversation_window_talk_text.Text)
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[index].talktext = this.textBox_conversation_window_talk_text.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_option_param(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    int num2 = this.listBox_conversation_options.SelectedIndex;
                    switch (this.comboBox_conversation_option_param.SelectedIndex)
                    {
                        case 0:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483648;
                            this.textBox_conversation_option_param.Text = "-2147483648";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 1:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483647;
                            this.textBox_conversation_option_param.Text = "-2147483647";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 2:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483646;
                            this.textBox_conversation_option_param.Text = "-2147483646";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 3:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483645;
                            this.textBox_conversation_option_param.Text = "-2147483645";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 4:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483644;
                            this.textBox_conversation_option_param.Text = "-2147483644";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 5:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483643;
                            this.textBox_conversation_option_param.Text = "-2147483643";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 6:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483642;
                            this.textBox_conversation_option_param.Text = "-2147483642";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 7:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483641;
                            this.textBox_conversation_option_param.Text = "-2147483641";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 8:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483640;
                            this.textBox_conversation_option_param.Text = "-2147483640";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 9:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483639;
                            this.textBox_conversation_option_param.Text = "-2147483639";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 10:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483638;
                            this.textBox_conversation_option_param.Text = "-2147483638";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 11:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483637;
                            this.textBox_conversation_option_param.Text = "-2147483637";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 12:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483636;
                            this.textBox_conversation_option_param.Text = "-2147483636";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 13:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483635;
                            this.textBox_conversation_option_param.Text = "-2147483635";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 14:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483634;
                            this.textBox_conversation_option_param.Text = "-2147483634";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 15:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483633;
                            this.textBox_conversation_option_param.Text = "-2147483633";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 16:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483632;
                            this.textBox_conversation_option_param.Text = "-2147483632";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 17:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483631;
                            this.textBox_conversation_option_param.Text = "-2147483631";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 18:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483630;
                            this.textBox_conversation_option_param.Text = "-2147483630";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 19:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483629;
                            this.textBox_conversation_option_param.Text = "-2147483629";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 20:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483628;
                            this.textBox_conversation_option_param.Text = "-2147483628";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 21:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483627;
                            this.textBox_conversation_option_param.Text = "-2147483627";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 22:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483626;
                            this.textBox_conversation_option_param.Text = "-2147483626";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 23:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483625;
                            this.textBox_conversation_option_param.Text = "-2147483625";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 24:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483624;
                            this.textBox_conversation_option_param.Text = "-2147483624";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 25:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483623;
                            this.textBox_conversation_option_param.Text = "-2147483623";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 26:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483622;
                            this.textBox_conversation_option_param.Text = "-2147483622";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 27:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483621;
                            this.textBox_conversation_option_param.Text = "-2147483621";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 28:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483620;
                            this.textBox_conversation_option_param.Text = "-2147483620";
                            break;
                        case 29:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483619;
                            this.textBox_conversation_option_param.Text = "-2147483619";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 30:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483618;
                            this.textBox_conversation_option_param.Text = "-2147483618";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 31:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483617;
                            this.textBox_conversation_option_param.Text = "-2147483617";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 32:
                            this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = -2147483616;
                            this.textBox_conversation_option_param.Text = "-2147483616";
                            this.textBox_conversation_option_param.Visible = false;
                            this.label14.Visible = false;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                            break;
                        case 33:
                            if (SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param <= -1)
                            {
                                this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = 0;
                                this.textBox_conversation_option_param.Text = "0";
                            }
                            this.textBox_conversation_option_param.Visible = true;
                            this.label14.Visible = true;
                            this.textBox_conversation_option_id.Size = new System.Drawing.Size(51, 20);
                            break;
                    }
                    this.TriggerDebug((Control)sender);
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }

            }
        }
        private void change_conversation_option_param1(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    int num2 = this.listBox_conversation_options.SelectedIndex;
                    if (selectedIndex > -1 && index > -1 && num2 > -1 && this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param != Convert.ToInt32(this.textBox_conversation_option_param.Text))
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].param = Convert.ToInt32(this.textBox_conversation_option_param.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_option_text(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    int num2 = this.listBox_conversation_options.SelectedIndex;
                    if (selectedIndex > -1 && index > -1 && num2 > -1 && this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].optiontext != this.textBox_conversation_option_text.Text)
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].optiontext = this.textBox_conversation_option_text.Text;
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        private void change_conversation_option_id(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                try
                {
                    int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                    int index = this.listBox_conversation_windows.SelectedIndex;
                    int num2 = this.listBox_conversation_options.SelectedIndex;
                    if (selectedIndex > -1 && index > -1 && num2 > -1 && this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].id != Convert.ToInt32(this.textBox_conversation_option_id.Text))
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num2].id = Convert.ToInt32(this.textBox_conversation_option_id.Text);
                        this.TriggerDebug((Control)sender);
                    }
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(403));
                }
            }
        }
        #endregion

        #region Add And Clone
        private void add_m_tmStart_m_tmEnd(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int limit;
                if (version >= 69)
                {
                    limit = 24;
                }
                else
                {
                    limit = 12;
                }
                if (this.SelectedTask.m_ulTimetable < limit)
                {
                    this.SelectedTask.m_ulTimetable++;
                    Array.Resize<task_tm>(ref this.SelectedTask.m_tmStart, this.SelectedTask.m_tmStart.Length + 1);
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1] = new task_tm();
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].year = 0;
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].month = 0;
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].day = 0;
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].hour = 0;
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].min = 0;
                    this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].wday = 0;
                    Array.Resize<task_tm>(ref this.SelectedTask.m_tmEnd, this.SelectedTask.m_tmEnd.Length + 1);
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1] = new task_tm();
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].year = 0;
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].month = 0;
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].day = 0;
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].hour = 0;
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].min = 0;
                    this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].wday = 0;
                    string[] values = new string[]
				    {
                        this.Column416.Items[this.SelectedTask.m_tmType[this.SelectedTask.m_tmStart.Length - 1]].ToString(),
					    "0",
					    "0",
					    "0",
					    "0",
					    "0",
					    this.Column6.Items[0].ToString(),
					    "=>",
					    "0",
					    "0",
					    "0",
					    "0",
					    "0",
					    this.Column13.Items[0].ToString()
				    };
                    this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows.Add(values);
                }
                else
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(424));
                }
            }
        }
        private void clone_m_tmStart_m_tmEnd(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int limit;
                if (version >= 69)
                {
                    limit = 24;
                }
                else
                {
                    limit = 12;
                }
                if (this.SelectedTask.m_ulTimetable < limit)
                {
                    if (dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell != null)
                    {
                        int i = dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex;
                        this.SelectedTask.m_ulTimetable++;
                        Array.Resize<task_tm>(ref this.SelectedTask.m_tmStart, this.SelectedTask.m_tmStart.Length + 1);
                        this.SelectedTask.m_tmType[this.SelectedTask.m_tmStart.Length - 1] = SelectedTask.m_tmType[i];
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1] = new task_tm();
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].year = SelectedTask.m_tmStart[i].year;
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].month = SelectedTask.m_tmStart[i].month;
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].day = SelectedTask.m_tmStart[i].day;
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].hour = SelectedTask.m_tmStart[i].hour;
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].min = SelectedTask.m_tmStart[i].min;
                        this.SelectedTask.m_tmStart[this.SelectedTask.m_tmStart.Length - 1].wday = SelectedTask.m_tmStart[i].wday;
                        Array.Resize<task_tm>(ref this.SelectedTask.m_tmEnd, this.SelectedTask.m_tmEnd.Length + 1);
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1] = new task_tm();
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].year = SelectedTask.m_tmEnd[i].year;
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].month = SelectedTask.m_tmEnd[i].month;
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].day = SelectedTask.m_tmEnd[i].day;
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].hour = SelectedTask.m_tmEnd[i].hour;
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].min = SelectedTask.m_tmEnd[i].min;
                        this.SelectedTask.m_tmEnd[this.SelectedTask.m_tmEnd.Length - 1].wday = SelectedTask.m_tmEnd[i].wday;
                        string[] values = new string[]
				        {
                            this.Column416.Items[this.SelectedTask.m_tmType[i]].ToString(),
					        SelectedTask.m_tmStart[i].year.ToString(),
					        SelectedTask.m_tmStart[i].month.ToString(),
					        SelectedTask.m_tmStart[i].day.ToString(),
					        SelectedTask.m_tmStart[i].hour.ToString(),
					        SelectedTask.m_tmStart[i].min.ToString(),
					        this.Column6.Items[SelectedTask.m_tmStart[i].wday].ToString(),
					        "=>",
					        SelectedTask.m_tmEnd[i].year.ToString(),
					        SelectedTask.m_tmEnd[i].month.ToString(),
					        SelectedTask.m_tmEnd[i].day.ToString(),
					        SelectedTask.m_tmEnd[i].hour.ToString(),
					        SelectedTask.m_tmEnd[i].min.ToString(),
					        this.Column6.Items[SelectedTask.m_tmEnd[i].wday].ToString()
				        };
                        this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows.Add(values);
                    }
                }
                else
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(424));
                }
            }
        }
        private void add_m_pDelvRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulDelvRegionCnt++;
                    Array.Resize<Task_Region>(ref this.SelectedTask.m_pDelvRegion, this.SelectedTask.m_pDelvRegion.Length + 1);
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1] = new Task_Region();
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMin_x = -9999;
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMin_y = -9999;
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMin_z = -9999;
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMax_x = 9999;
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMax_y = 9999;
                    this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMax_z = 9999;
                    string[] values = new string[]
				{
					"-9999,000",
					"-9999,000",
					"-9999,000",
					"9999,000",
					"9999,000",
					"9999,000"
				};
                    this.dataGridView_m_pDelvRegion.Rows.Add(values);
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void clone_m_pDelvRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    if (dataGridView_m_pDelvRegion.CurrentCell != null)
                    {
                        int i = dataGridView_m_pDelvRegion.CurrentCell.RowIndex;
                        this.SelectedTask.m_ulDelvRegionCnt++;
                        Array.Resize<Task_Region>(ref this.SelectedTask.m_pDelvRegion, this.SelectedTask.m_pDelvRegion.Length + 1);
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1] = new Task_Region();
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMin_x = SelectedTask.m_pDelvRegion[i].zvMin_x;
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMin_y = SelectedTask.m_pDelvRegion[i].zvMin_y;
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMin_z = SelectedTask.m_pDelvRegion[i].zvMin_z;
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMax_x = SelectedTask.m_pDelvRegion[i].zvMax_x;
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMax_y = SelectedTask.m_pDelvRegion[i].zvMax_y;
                        this.SelectedTask.m_pDelvRegion[this.SelectedTask.m_pDelvRegion.Length - 1].zvMax_z = SelectedTask.m_pDelvRegion[i].zvMax_z;
                        string[] values = new string[]
				{
					SelectedTask.m_pDelvRegion[i].zvMin_x.ToString("F3"),
					SelectedTask.m_pDelvRegion[i].zvMin_y.ToString("F3"),
					SelectedTask.m_pDelvRegion[i].zvMin_z.ToString("F3"),
					SelectedTask.m_pDelvRegion[i].zvMax_x.ToString("F3"),
					SelectedTask.m_pDelvRegion[i].zvMax_y.ToString("F3"),
					SelectedTask.m_pDelvRegion[i].zvMax_z.ToString("F3")
				};
                        this.dataGridView_m_pDelvRegion.Rows.Add(values);
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void add_m_pEnterRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulEnterRegionCnt++;
                    Array.Resize<Task_Region>(ref this.SelectedTask.m_pEnterRegion, this.SelectedTask.m_pEnterRegion.Length + 1);
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1] = new Task_Region();
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMin_x = -9999;
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMin_y = -9999;
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMin_z = -9999;
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMax_x = 9999;
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMax_y = 9999;
                    this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMax_z = 9999;
                    string[] values = new string[]
				{
					"-9999,000",
					"-9999,000",
					"-9999,000",
					"9999,000",
					"9999,000",
					"9999,000"
				};
                    this.dataGridView_m_pEnterRegion.Rows.Add(values);
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void clone_m_pEnterRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    if (dataGridView_m_pEnterRegion.CurrentCell != null)
                    {
                        int i = dataGridView_m_pEnterRegion.CurrentCell.RowIndex;
                        this.SelectedTask.m_ulEnterRegionCnt++;
                        Array.Resize<Task_Region>(ref this.SelectedTask.m_pEnterRegion, this.SelectedTask.m_pEnterRegion.Length + 1);
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1] = new Task_Region();
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMin_x = SelectedTask.m_pEnterRegion[i].zvMin_x;
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMin_y = SelectedTask.m_pEnterRegion[i].zvMin_y;
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMin_z = SelectedTask.m_pEnterRegion[i].zvMin_z;
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMax_x = SelectedTask.m_pEnterRegion[i].zvMax_x;
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMax_y = SelectedTask.m_pEnterRegion[i].zvMax_y;
                        this.SelectedTask.m_pEnterRegion[this.SelectedTask.m_pEnterRegion.Length - 1].zvMax_z = SelectedTask.m_pEnterRegion[i].zvMax_z;
                        string[] values = new string[]
				{
					SelectedTask.m_pEnterRegion[i].zvMin_x.ToString("F3"),
					SelectedTask.m_pEnterRegion[i].zvMin_y.ToString("F3"),
					SelectedTask.m_pEnterRegion[i].zvMin_z.ToString("F3"),
					SelectedTask.m_pEnterRegion[i].zvMax_x.ToString("F3"),
					SelectedTask.m_pEnterRegion[i].zvMax_y.ToString("F3"),
					SelectedTask.m_pEnterRegion[i].zvMax_z.ToString("F3")
				};
                        this.dataGridView_m_pEnterRegion.Rows.Add(values);
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void add_m_pLeaveRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulLeaveRegionCnt++;
                    Array.Resize<Task_Region>(ref this.SelectedTask.m_pLeaveRegion, this.SelectedTask.m_pLeaveRegion.Length + 1);
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1] = new Task_Region();
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMin_x = -9999;
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMin_y = -9999;
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMin_z = -9999;
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMax_x = 9999;
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMax_y = 9999;
                    this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMax_z = 9999;
                    string[] values = new string[]
				{
					"-9999,000",
					"-9999,000",
					"-9999,000",
					"9999,000",
					"9999,000",
					"9999,000"
				};
                    this.dataGridView_m_pLeaveRegion.Rows.Add(values);
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void clone_m_pLeaveRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    if (dataGridView_m_pLeaveRegion.CurrentCell != null)
                    {
                        int i = dataGridView_m_pLeaveRegion.CurrentCell.RowIndex;
                        this.SelectedTask.m_ulLeaveRegionCnt++;
                        Array.Resize<Task_Region>(ref this.SelectedTask.m_pLeaveRegion, this.SelectedTask.m_pLeaveRegion.Length + 1);
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1] = new Task_Region();
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMin_x = SelectedTask.m_pLeaveRegion[i].zvMin_x;
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMin_y = SelectedTask.m_pLeaveRegion[i].zvMin_y;
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMin_z = SelectedTask.m_pLeaveRegion[i].zvMin_z;
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMax_x = SelectedTask.m_pLeaveRegion[i].zvMax_x;
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMax_y = SelectedTask.m_pLeaveRegion[i].zvMax_y;
                        this.SelectedTask.m_pLeaveRegion[this.SelectedTask.m_pLeaveRegion.Length - 1].zvMax_z = SelectedTask.m_pLeaveRegion[i].zvMax_z;
                        string[] values = new string[]
				{
					SelectedTask.m_pLeaveRegion[i].zvMin_x.ToString("F3"),
					SelectedTask.m_pLeaveRegion[i].zvMin_y.ToString("F3"),
					SelectedTask.m_pLeaveRegion[i].zvMin_z.ToString("F3"),
					SelectedTask.m_pLeaveRegion[i].zvMax_x.ToString("F3"),
					SelectedTask.m_pLeaveRegion[i].zvMax_y.ToString("F3"),
					SelectedTask.m_pLeaveRegion[i].zvMax_z.ToString("F3")
				};
                        this.dataGridView_m_pLeaveRegion.Rows.Add(values);
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void add_m_ulChangeKey(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulChangeKeyCnt++;
                Array.Resize<int>(ref this.SelectedTask.m_plChangeKey, this.SelectedTask.m_plChangeKey.Length + 1);
                this.SelectedTask.m_plChangeKey[this.SelectedTask.m_plChangeKey.Length - 1] = new int();
                this.SelectedTask.m_plChangeKey[this.SelectedTask.m_plChangeKey.Length - 1] = 0;
                Array.Resize<int>(ref this.SelectedTask.m_plChangeKeyValue, this.SelectedTask.m_plChangeKeyValue.Length + 1);
                this.SelectedTask.m_plChangeKeyValue[this.SelectedTask.m_plChangeKeyValue.Length - 1] = new int();
                this.SelectedTask.m_plChangeKeyValue[this.SelectedTask.m_plChangeKeyValue.Length - 1] = 0;
                Array.Resize<bool>(ref this.SelectedTask.m_pbChangeType, this.SelectedTask.m_pbChangeType.Length + 1);
                this.SelectedTask.m_pbChangeType[this.SelectedTask.m_pbChangeType.Length - 1] = new bool();
                this.SelectedTask.m_pbChangeType[this.SelectedTask.m_pbChangeType.Length - 1] = false;
                string[] values = new string[]
				{
					"0",
					"0",
					this.dataGridViewTextBoxColumn69.Items[0].ToString()
				};
                this.dataGridView_m_ulChangeKey.Rows.Add(values);
            }
        }
        private void clone_m_ulChangeKey(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_ulChangeKey.CurrentCell != null)
                {
                    int i = dataGridView_m_ulChangeKey.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulChangeKeyCnt++;
                    Array.Resize<int>(ref this.SelectedTask.m_plChangeKey, this.SelectedTask.m_plChangeKey.Length + 1);
                    this.SelectedTask.m_plChangeKey[this.SelectedTask.m_plChangeKey.Length - 1] = new int();
                    this.SelectedTask.m_plChangeKey[this.SelectedTask.m_plChangeKey.Length - 1] = SelectedTask.m_plChangeKey[i];
                    Array.Resize<int>(ref this.SelectedTask.m_plChangeKeyValue, this.SelectedTask.m_plChangeKeyValue.Length + 1);
                    this.SelectedTask.m_plChangeKeyValue[this.SelectedTask.m_plChangeKeyValue.Length - 1] = new int();
                    this.SelectedTask.m_plChangeKeyValue[this.SelectedTask.m_plChangeKeyValue.Length - 1] = SelectedTask.m_plChangeKeyValue[i];
                    Array.Resize<bool>(ref this.SelectedTask.m_pbChangeType, this.SelectedTask.m_pbChangeType.Length + 1);
                    this.SelectedTask.m_pbChangeType[this.SelectedTask.m_pbChangeType.Length - 1] = new bool();
                    this.SelectedTask.m_pbChangeType[this.SelectedTask.m_pbChangeType.Length - 1] = SelectedTask.m_pbChangeType[i];
                    string[] values = new string[]
				{
					SelectedTask.m_plChangeKey[i].ToString(),
					SelectedTask.m_plChangeKeyValue[i].ToString(),
					this.dataGridViewTextBoxColumn69.Items[Convert.ToInt32(SelectedTask.m_pbChangeType[i])].ToString()
				};
                    this.dataGridView_m_ulChangeKey.Rows.Add(values);
                }
            }
        }
        private void add_m_pszPQExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulPQExpCnt++;
                Array.Resize<byte[]>(ref this.SelectedTask.m_pszPQExp, this.SelectedTask.m_pszPQExp.Length + 1);
                this.SelectedTask.m_pszPQExp[this.SelectedTask.m_pszPQExp.Length - 1] = new byte[64];
                Array.Resize<TASK_EXPRESSION>(ref this.SelectedTask.m_pPQExpArr, this.SelectedTask.m_pPQExpArr.Length + 1);
                this.SelectedTask.m_pPQExpArr[this.SelectedTask.m_pPQExpArr.Length - 1] = new TASK_EXPRESSION();
                this.SelectedTask.m_pPQExpArr[this.SelectedTask.m_pPQExpArr.Length - 1].type = new int[64];
                this.SelectedTask.m_pPQExpArr[this.SelectedTask.m_pPQExpArr.Length - 1].value = new float[64];
                string[] values = new string[129];
                values[0] = "";
                for (int i = 0; i < 64; i++)
                {
                    values[(i * 2) + 1] = "0";
                    values[(i * 2) + 2] = "0";
                }
                this.dataGridView_m_pszPQExp.Rows.Add(values);
            }
        }
        private void clone_m_pszPQExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int k = dataGridView_m_pszPQExp.CurrentCell.RowIndex;
                this.SelectedTask.m_ulPQExpCnt++;
                Array.Resize<byte[]>(ref this.SelectedTask.m_pszPQExp, this.SelectedTask.m_pszPQExp.Length + 1);
                this.SelectedTask.m_pszPQExp[this.SelectedTask.m_pszPQExp.Length - 1] = this.SelectedTask.m_pszPQExp[k];
                Array.Resize<TASK_EXPRESSION>(ref this.SelectedTask.m_pPQExpArr, this.SelectedTask.m_pPQExpArr.Length + 1);
                this.SelectedTask.m_pPQExpArr[this.SelectedTask.m_pPQExpArr.Length - 1] = new TASK_EXPRESSION();
                this.SelectedTask.m_pPQExpArr[this.SelectedTask.m_pPQExpArr.Length - 1].type = this.SelectedTask.m_pPQExpArr[k].type;
                this.SelectedTask.m_pPQExpArr[this.SelectedTask.m_pPQExpArr.Length - 1].value = this.SelectedTask.m_pPQExpArr[k].value;
                string[] values = new string[129];
                values[0] = Extensions.ByteArray_to_GbkString(this.SelectedTask.m_pszPQExp[k]);
                for (int i = 0; i < 64; i++)
                {
                    values[(i * 2) + 1] = this.SelectedTask.m_pPQExpArr[k].type[i].ToString();
                    values[(i * 2) + 2] = this.SelectedTask.m_pPQExpArr[k].value[i].ToString();
                }
                this.dataGridView_m_pszPQExp.Rows.Add(values);
            }
        }
        private void add_m_MonstersContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulMonsterContribCnt++;
                Array.Resize<MONSTERS_CONTRIB>(ref this.SelectedTask.m_MonstersContrib, this.SelectedTask.m_MonstersContrib.Length + 1);
                this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1] = new MONSTERS_CONTRIB();
                this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_ulMonsterTemplId = 0;
                this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_iWholeContrib = 0;
                this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_iShareContrib = 0;
                this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_iPersonalWholeContrib = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"0",
					"0",
					"0"
				};
                this.dataGridView_m_MonstersContrib.Rows.Add(values);
            }
        }
        private void clone_m_MonstersContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_MonstersContrib.CurrentCell != null)
                {
                    int i = dataGridView_m_MonstersContrib.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulMonsterContribCnt++;
                    Array.Resize<MONSTERS_CONTRIB>(ref this.SelectedTask.m_MonstersContrib, this.SelectedTask.m_MonstersContrib.Length + 1);
                    this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1] = new MONSTERS_CONTRIB();
                    this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_ulMonsterTemplId = SelectedTask.m_MonstersContrib[i].m_ulMonsterTemplId;
                    this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_iWholeContrib = SelectedTask.m_MonstersContrib[i].m_iWholeContrib;
                    this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_iShareContrib = SelectedTask.m_MonstersContrib[i].m_iShareContrib;
                    this.SelectedTask.m_MonstersContrib[this.SelectedTask.m_MonstersContrib.Length - 1].m_iPersonalWholeContrib = SelectedTask.m_MonstersContrib[i].m_iPersonalWholeContrib;
                    string[] values = new string[]
				{
					SelectedTask.m_MonstersContrib[i].m_ulMonsterTemplId.ToString(),
                    Extensions.MonsterNPCMineName(SelectedTask.m_MonstersContrib[i].m_ulMonsterTemplId),
					SelectedTask.m_MonstersContrib[i].m_iWholeContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_MonstersContrib[i].m_iShareContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_MonstersContrib[i].m_iPersonalWholeContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"))
				};
                    this.dataGridView_m_MonstersContrib.Rows.Add(values);
                }
            }
        }
        private void add_m_PremItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulPremItems++;
                Array.Resize<ITEM_WANTED>(ref this.SelectedTask.m_PremItems, this.SelectedTask.m_PremItems.Length + 1);
                this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1] = new ITEM_WANTED();
                this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_ulItemTemplId = 0;
                this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_bCommonItem = true;
                this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_ulItemNum = 1;
                this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_fProb = 1f;
                this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_lPeriod = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"True",
					"1",
					ProbAddValueFormat,
					"00-00:00:00"
				};
                this.dataGridView_m_PremItems.Rows.Add(values);
            }
        }
        private void clone_m_PremItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_PremItems.CurrentCell != null)
                {
                    int i = dataGridView_m_PremItems.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulPremItems++;
                    Array.Resize<ITEM_WANTED>(ref this.SelectedTask.m_PremItems, this.SelectedTask.m_PremItems.Length + 1);
                    this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1] = new ITEM_WANTED();
                    this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_ulItemTemplId = SelectedTask.m_PremItems[i].m_ulItemTemplId;
                    this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_bCommonItem = SelectedTask.m_PremItems[i].m_bCommonItem;
                    this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_ulItemNum = SelectedTask.m_PremItems[i].m_ulItemNum;
                    this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_fProb = SelectedTask.m_PremItems[i].m_fProb;
                    this.SelectedTask.m_PremItems[this.SelectedTask.m_PremItems.Length - 1].m_lPeriod = SelectedTask.m_PremItems[i].m_lPeriod;
                    string[] values = new string[]
				{
					SelectedTask.m_PremItems[i].m_ulItemTemplId.ToString(),
                    Extensions.ItemName(SelectedTask.m_PremItems[i].m_ulItemTemplId),
					SelectedTask.m_PremItems[i].m_bCommonItem.ToString(),
					SelectedTask.m_PremItems[i].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_PremItems[i].m_fProb.ToString(ProbValueFormat),
					Extensions.SecondsToString(SelectedTask.m_PremItems[i].m_lPeriod)
				};
                    this.dataGridView_m_PremItems.Rows.Add(values);
                }
            }
        }
        private void add_m_GivenItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulGivenItems++;
                Array.Resize<ITEM_WANTED>(ref this.SelectedTask.m_GivenItems, this.SelectedTask.m_GivenItems.Length + 1);
                this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1] = new ITEM_WANTED();
                this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_ulItemTemplId = 0;
                this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_bCommonItem = true;
                this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_ulItemNum = 1;
                this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_fProb = 1f;
                this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_lPeriod = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"True",
					"1",
					ProbAddValueFormat,
					"00-00:00:00"
				};
                this.dataGridView_m_GivenItems.Rows.Add(values);
            }
        }
        private void clone_m_GivenItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_GivenItems.CurrentCell != null)
                {
                    int i = dataGridView_m_GivenItems.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulGivenItems++;
                    Array.Resize<ITEM_WANTED>(ref this.SelectedTask.m_GivenItems, this.SelectedTask.m_GivenItems.Length + 1);
                    this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1] = new ITEM_WANTED();
                    this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_ulItemTemplId = SelectedTask.m_GivenItems[i].m_ulItemTemplId;
                    this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_bCommonItem = SelectedTask.m_GivenItems[i].m_bCommonItem;
                    this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_ulItemNum = SelectedTask.m_GivenItems[i].m_ulItemNum;
                    this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_fProb = SelectedTask.m_GivenItems[i].m_fProb;
                    this.SelectedTask.m_GivenItems[this.SelectedTask.m_GivenItems.Length - 1].m_lPeriod = SelectedTask.m_GivenItems[i].m_lPeriod;
                    string[] values = new string[]
				{
					SelectedTask.m_GivenItems[i].m_ulItemTemplId.ToString(),
                    Extensions.ItemName(SelectedTask.m_GivenItems[i].m_ulItemTemplId),
					SelectedTask.m_GivenItems[i].m_bCommonItem.ToString(),
					SelectedTask.m_GivenItems[i].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_GivenItems[i].m_fProb.ToString(ProbValueFormat),
					Extensions.SecondsToString(SelectedTask.m_GivenItems[i].m_lPeriod)
				};
                    this.dataGridView_m_GivenItems.Rows.Add(values);
                }
            }
        }
        private void add_m_TeamMemsWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulTeamMemsWanted++;
                Array.Resize<TEAM_MEM_WANTED>(ref this.SelectedTask.m_TeamMemsWanted, this.SelectedTask.m_TeamMemsWanted.Length + 1);
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1] = new TEAM_MEM_WANTED();
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulLevelMin = 1;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulLevelMax = 150;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulRace = 0;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulOccupation = -1;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulGender = 0;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulMinCount = 1;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulMaxCount = 5;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulTask = 0;
                this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_iForce = 0;
                string[] values = new string[]
				{
					"1",
					"150",
					this.dataGridViewTextBoxColumn10.Items[0].ToString(),
					this.dataGridViewTextBoxColumn11.Items[0].ToString(),
					this.dataGridViewTextBoxColumn12.Items[0].ToString(),
					"1",
					"5",
					"0",
					this.Column18.Items[0].ToString()
				};
                this.dataGridView_m_TeamMemsWanted.Rows.Add(values);
            }
        }
        private void clone_m_TeamMemsWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_TeamMemsWanted.CurrentCell != null)
                {
                    int i = dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulTeamMemsWanted++;
                    Array.Resize<TEAM_MEM_WANTED>(ref this.SelectedTask.m_TeamMemsWanted, this.SelectedTask.m_TeamMemsWanted.Length + 1);
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1] = new TEAM_MEM_WANTED();
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulLevelMin = SelectedTask.m_TeamMemsWanted[i].m_ulLevelMin;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulLevelMax = SelectedTask.m_TeamMemsWanted[i].m_ulLevelMax;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulRace = SelectedTask.m_TeamMemsWanted[i].m_ulRace;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulOccupation = SelectedTask.m_TeamMemsWanted[i].m_ulOccupation;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulGender = SelectedTask.m_TeamMemsWanted[i].m_ulGender;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulMinCount = SelectedTask.m_TeamMemsWanted[i].m_ulMinCount;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulMaxCount = SelectedTask.m_TeamMemsWanted[i].m_ulMaxCount;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_ulTask = SelectedTask.m_TeamMemsWanted[i].m_ulTask;
                    this.SelectedTask.m_TeamMemsWanted[this.SelectedTask.m_TeamMemsWanted.Length - 1].m_iForce = SelectedTask.m_TeamMemsWanted[i].m_iForce;
                    string[] values = new string[]
				{
					SelectedTask.m_TeamMemsWanted[i].m_ulLevelMin.ToString(),
					SelectedTask.m_TeamMemsWanted[i].m_ulLevelMax.ToString(),
					this.dataGridViewTextBoxColumn10.Items[SelectedTask.m_TeamMemsWanted[i].m_ulRace].ToString(),
					this.dataGridViewTextBoxColumn11.Items[Math.Max(0, this.SelectedTask.m_TeamMemsWanted[i].m_ulOccupation - -1)].ToString(),
					this.dataGridViewTextBoxColumn12.Items[SelectedTask.m_TeamMemsWanted[i].m_ulGender].ToString(),
					SelectedTask.m_TeamMemsWanted[i].m_ulMinCount.ToString(),
					SelectedTask.m_TeamMemsWanted[i].m_ulMaxCount.ToString(),
					SelectedTask.m_TeamMemsWanted[i].m_ulTask.ToString(),
					this.Column18.Items[Math.Max(0, this.SelectedTask.m_TeamMemsWanted[i].m_iForce - 1003)].ToString()
				};
                    this.dataGridView_m_TeamMemsWanted.Rows.Add(values);
                }
            }
        }
        private void add_m_PremTitles(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_iPremTitleNumTotal++;
                Array.Resize<int>(ref this.SelectedTask.m_PremTitles, this.SelectedTask.m_PremTitles.Length + 1);
                this.SelectedTask.m_PremTitles[this.SelectedTask.m_PremTitles.Length - 1] = new int();
                this.SelectedTask.m_PremTitles[this.SelectedTask.m_PremTitles.Length - 1] = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402)
				};
                this.dataGridView_m_PremTitles.Rows.Add(values);
            }
        }
        private void add_m_PlayerWanted(object sender, EventArgs e)
        {
            if (version >= 120)
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulPlayerWanted++;
                    Array.Resize<PLAYER_WANTED>(ref this.SelectedTask.m_PlayerWanted, this.SelectedTask.m_PlayerWanted.Length + 1);
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1] = new PLAYER_WANTED();
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulPlayerNum = 1;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulDropItemId = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulDropItemCount = 1;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_bDropCmnItem = false;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_fDropProb = 1f;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements = new Kill_Player_Requirements();
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_ulOccupations = 4095;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iMinLevel = 1;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iMaxLevel = 150;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iGender = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iForce = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelCheck = false;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType = new byte[3];
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[0] = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[1] = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[2] = 0;
                    string[] values = new string[]
				    {
					    "1",
					    "0",
					    Extensions.GetLocalization(402),
					    "1",
					    "False",
					    ProbAddValueFormat,
					    "4095",
					    "1",
					    "150",
					    this.Column27.Items[0].ToString(),
					    "0",
					    "False",
					    "0",
					    "0",
					    "0"
				    };
                    this.dataGridView_m_PlayerWanted.Rows.Add(values);
                }
            }
            else
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulPlayerWanted++;
                    Array.Resize<PLAYER_WANTED>(ref this.SelectedTask.m_PlayerWanted, this.SelectedTask.m_PlayerWanted.Length + 1);
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1] = new PLAYER_WANTED();
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulPlayerNum = 1;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulDropItemId = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulDropItemCount = 1;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_bDropCmnItem = false;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_fDropProb = 1f;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements = new Kill_Player_Requirements();
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_ulOccupations = 1023;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iMinLevel = 1;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iMaxLevel = 150;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iGender = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iForce = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelCheck = false;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType = new byte[3];
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[0] = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[1] = 0;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[2] = 0;
                    string[] values = new string[]
				    {
					    "1",
					    "0",
					    Extensions.GetLocalization(402),
					    "1",
					    "False",
					    ProbAddValueFormat,
					    "1023",
					    "1",
					    "150",
					    this.Column27.Items[0].ToString(),
					    "0",
					    "False",
					    "0",
					    "0",
					    "0"
				    };
                    this.dataGridView_m_PlayerWanted.Rows.Add(values);
                }
            }
        }
        private void clone_m_PlayerWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_PlayerWanted.CurrentCell != null)
                {
                    int i = dataGridView_m_PlayerWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulPlayerWanted++;
                    Array.Resize<PLAYER_WANTED>(ref this.SelectedTask.m_PlayerWanted, this.SelectedTask.m_PlayerWanted.Length + 1);
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1] = new PLAYER_WANTED();
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulPlayerNum = SelectedTask.m_PlayerWanted[i].m_ulPlayerNum;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulDropItemId = SelectedTask.m_PlayerWanted[i].m_ulDropItemId;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_ulDropItemCount = SelectedTask.m_PlayerWanted[i].m_ulDropItemCount;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_bDropCmnItem = SelectedTask.m_PlayerWanted[i].m_bDropCmnItem;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_fDropProb = SelectedTask.m_PlayerWanted[i].m_fDropProb;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements = new Kill_Player_Requirements();
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_ulOccupations = SelectedTask.m_PlayerWanted[i].m_Requirements.m_ulOccupations;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iMinLevel = SelectedTask.m_PlayerWanted[i].m_Requirements.m_iMinLevel;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iMaxLevel = SelectedTask.m_PlayerWanted[i].m_Requirements.m_iMaxLevel;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iGender = SelectedTask.m_PlayerWanted[i].m_Requirements.m_iGender;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.m_iForce = SelectedTask.m_PlayerWanted[i].m_Requirements.m_iForce;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelCheck = SelectedTask.m_PlayerWanted[i].m_Requirements.ModelCheck;
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType = new byte[3];
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[0] = SelectedTask.m_PlayerWanted[i].m_Requirements.ModelType[0];
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[1] = SelectedTask.m_PlayerWanted[i].m_Requirements.ModelType[1];
                    this.SelectedTask.m_PlayerWanted[this.SelectedTask.m_PlayerWanted.Length - 1].m_Requirements.ModelType[2] = SelectedTask.m_PlayerWanted[i].m_Requirements.ModelType[2];
                    string[] values = new string[]
				{
					SelectedTask.m_PlayerWanted[i].m_ulPlayerNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_PlayerWanted[i].m_ulDropItemId.ToString(),
                    Extensions.ItemName(SelectedTask.m_PlayerWanted[i].m_ulDropItemId),
					SelectedTask.m_PlayerWanted[i].m_ulDropItemCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_PlayerWanted[i].m_bDropCmnItem.ToString(),
					SelectedTask.m_PlayerWanted[i].m_fDropProb.ToString(ProbValueFormat),
					SelectedTask.m_PlayerWanted[i].m_Requirements.m_ulOccupations.ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.m_iMinLevel.ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.m_iMaxLevel.ToString(),
					this.Column27.Items[SelectedTask.m_PlayerWanted[i].m_Requirements.m_iGender].ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.m_iForce.ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.ModelCheck.ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.ModelType[0].ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.ModelType[1].ToString(),
					SelectedTask.m_PlayerWanted[i].m_Requirements.ModelType[2].ToString()
				};
                    this.dataGridView_m_PlayerWanted.Rows.Add(values);
                }
            }
        }
        private void add_m_MonsterWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulMonsterWanted++;
                Array.Resize<MONSTER_WANTED>(ref this.SelectedTask.m_MonsterWanted, this.SelectedTask.m_MonsterWanted.Length + 1);
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1] = new MONSTER_WANTED();
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulMonsterTemplId = 0;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulMonsterNum = 0;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulDropItemId = 0;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulDropItemCount = 0;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_bDropCmnItem = false;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_fDropProb = 1f;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_bKillerLev = false;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_iDPH = 0;
                this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_iDPS = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"0",
					"0",
					Extensions.GetLocalization(402),
					"0",
					"False",
					ProbAddValueFormat,
					"False",
					"0",
					"0",
				};
                this.dataGridView_m_MonsterWanted.Rows.Add(values);
            }
        }
        private void clone_m_MonsterWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_MonsterWanted.CurrentCell != null)
                {
                    int i = dataGridView_m_MonsterWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulMonsterWanted++;
                    Array.Resize<MONSTER_WANTED>(ref this.SelectedTask.m_MonsterWanted, this.SelectedTask.m_MonsterWanted.Length + 1);
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1] = new MONSTER_WANTED();
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulMonsterTemplId = SelectedTask.m_MonsterWanted[i].m_ulMonsterTemplId;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulMonsterNum = SelectedTask.m_MonsterWanted[i].m_ulMonsterNum;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulDropItemId = SelectedTask.m_MonsterWanted[i].m_ulDropItemId;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_ulDropItemCount = SelectedTask.m_MonsterWanted[i].m_ulDropItemCount;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_bDropCmnItem = SelectedTask.m_MonsterWanted[i].m_bDropCmnItem;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_fDropProb = SelectedTask.m_MonsterWanted[i].m_fDropProb;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_bKillerLev = SelectedTask.m_MonsterWanted[i].m_bKillerLev;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_iDPH = SelectedTask.m_MonsterWanted[i].m_iDPH;
                    this.SelectedTask.m_MonsterWanted[this.SelectedTask.m_MonsterWanted.Length - 1].m_iDPS = SelectedTask.m_MonsterWanted[i].m_iDPS;
                    string[] values = new string[]
				{
					SelectedTask.m_MonsterWanted[i].m_ulMonsterTemplId.ToString(),
					Extensions.MonsterNPCMineName(SelectedTask.m_MonsterWanted[i].m_ulMonsterTemplId),
					SelectedTask.m_MonsterWanted[i].m_ulMonsterNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_MonsterWanted[i].m_ulDropItemId.ToString(),
                    Extensions.ItemName(SelectedTask.m_MonsterWanted[i].m_ulDropItemId),
					SelectedTask.m_MonsterWanted[i].m_ulDropItemCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_MonsterWanted[i].m_bDropCmnItem.ToString(),
					SelectedTask.m_MonsterWanted[i].m_fDropProb.ToString(ProbValueFormat),
					SelectedTask.m_MonsterWanted[i].m_bKillerLev.ToString(),
					SelectedTask.m_MonsterWanted[i].m_iDPH.ToString(),
					SelectedTask.m_MonsterWanted[i].m_iDPS.ToString(),
				};
                    this.dataGridView_m_MonsterWanted.Rows.Add(values);
                }
            }
        }
        private void add_m_ItemsWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulItemsWanted++;
                Array.Resize<ITEM_WANTED>(ref this.SelectedTask.m_ItemsWanted, this.SelectedTask.m_ItemsWanted.Length + 1);
                this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1] = new ITEM_WANTED();
                this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_ulItemTemplId = 0;
                this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_bCommonItem = true;
                this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_ulItemNum = 1;
                this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_fProb = 1f;
                this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_lPeriod = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"True",
					"1",
					ProbAddValueFormat,
					"00-00:00:00"
				};
                this.dataGridView_m_ItemsWanted.Rows.Add(values);
            }
        }
        private void clone_m_ItemsWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (this.dataGridView_m_ItemsWanted.CurrentCell != null)
                {
                    int i = this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulItemsWanted++;
                    Array.Resize<ITEM_WANTED>(ref this.SelectedTask.m_ItemsWanted, this.SelectedTask.m_ItemsWanted.Length + 1);
                    this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1] = new ITEM_WANTED();
                    this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_ulItemTemplId = SelectedTask.m_ItemsWanted[i].m_ulItemTemplId;
                    this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_bCommonItem = SelectedTask.m_ItemsWanted[i].m_bCommonItem;
                    this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_ulItemNum = SelectedTask.m_ItemsWanted[i].m_ulItemNum;
                    this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_fProb = SelectedTask.m_ItemsWanted[i].m_fProb;
                    this.SelectedTask.m_ItemsWanted[this.SelectedTask.m_ItemsWanted.Length - 1].m_lPeriod = SelectedTask.m_ItemsWanted[i].m_lPeriod;
                    string[] values = new string[]
				{
					SelectedTask.m_ItemsWanted[i].m_ulItemTemplId.ToString(),
                    Extensions.ItemName(SelectedTask.m_ItemsWanted[i].m_ulItemTemplId),
					SelectedTask.m_ItemsWanted[i].m_bCommonItem.ToString(),
					SelectedTask.m_ItemsWanted[i].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedTask.m_ItemsWanted[i].m_fProb.ToString(ProbValueFormat),
					Extensions.SecondsToString(SelectedTask.m_ItemsWanted[i].m_lPeriod)
				};
                    this.dataGridView_m_ItemsWanted.Rows.Add(values);
                }
            }
        }
        private void add_m_pReachSite(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulReachSiteCnt++;
                    Array.Resize<Task_Region>(ref this.SelectedTask.m_pReachSite, this.SelectedTask.m_pReachSite.Length + 1);
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1] = new Task_Region();
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMin_x = -9999;
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMin_y = -9999;
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMin_z = -9999;
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMax_x = 9999;
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMax_y = 9999;
                    this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMax_z = 9999;
                    string[] values = new string[]
				{
					"-9999,000",
					"-9999,000",
					"-9999,000",
					"9999,000",
					"9999,000",
					"9999,000"
				};
                    this.dataGridView_m_pReachSite.Rows.Add(values);
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void clone_m_pReachSite(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    if (dataGridView_m_pReachSite.CurrentCell != null)
                    {
                        int i = dataGridView_m_pReachSite.CurrentCell.RowIndex;
                        this.SelectedTask.m_ulReachSiteCnt++;
                        Array.Resize<Task_Region>(ref this.SelectedTask.m_pReachSite, this.SelectedTask.m_pReachSite.Length + 1);
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1] = new Task_Region();
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMin_x = SelectedTask.m_pReachSite[i].zvMin_x;
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMin_y = SelectedTask.m_pReachSite[i].zvMin_y;
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMin_z = SelectedTask.m_pReachSite[i].zvMin_z;
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMax_x = SelectedTask.m_pReachSite[i].zvMax_x;
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMax_y = SelectedTask.m_pReachSite[i].zvMax_y;
                        this.SelectedTask.m_pReachSite[this.SelectedTask.m_pReachSite.Length - 1].zvMax_z = SelectedTask.m_pReachSite[i].zvMax_z;
                        string[] values = new string[]
				{
					SelectedTask.m_pReachSite[i].zvMin_x.ToString("F3"),
					SelectedTask.m_pReachSite[i].zvMin_y.ToString("F3"),
					SelectedTask.m_pReachSite[i].zvMin_z.ToString("F3"),
					SelectedTask.m_pReachSite[i].zvMax_x.ToString("F3"),
					SelectedTask.m_pReachSite[i].zvMax_y.ToString("F3"),
					SelectedTask.m_pReachSite[i].zvMax_z.ToString("F3")
				};
                        this.dataGridView_m_pReachSite.Rows.Add(values);
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void add_m_pLeaveSite(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    this.SelectedTask.m_ulLeaveSiteCnt++;
                    Array.Resize<Task_Region>(ref this.SelectedTask.m_pLeaveSite, this.SelectedTask.m_pLeaveSite.Length + 1);
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1] = new Task_Region();
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMin_x = -9999;
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMin_y = -9999;
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMin_z = -9999;
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMax_x = 9999;
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMax_y = 9999;
                    this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMax_z = 9999;
                    string[] values = new string[]
				{
					"-9999,000",
					"-9999,000",
					"-9999,000",
					"9999,000",
					"9999,000",
					"9999,000"
				};
                    this.dataGridView_m_pLeaveSite.Rows.Add(values);
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void clone_m_pLeaveSite(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null)
                {
                    if (dataGridView_m_pLeaveSite.CurrentCell != null)
                    {
                        int i = dataGridView_m_pLeaveSite.CurrentCell.RowIndex;
                        this.SelectedTask.m_ulLeaveSiteCnt++;
                        Array.Resize<Task_Region>(ref this.SelectedTask.m_pLeaveSite, this.SelectedTask.m_pLeaveSite.Length + 1);
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1] = new Task_Region();
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMin_x = SelectedTask.m_pLeaveSite[i].zvMin_x;
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMin_y = SelectedTask.m_pLeaveSite[i].zvMin_y;
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMin_z = SelectedTask.m_pLeaveSite[i].zvMin_z;
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMax_x = SelectedTask.m_pLeaveSite[i].zvMax_x;
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMax_y = SelectedTask.m_pLeaveSite[i].zvMax_y;
                        this.SelectedTask.m_pLeaveSite[this.SelectedTask.m_pLeaveSite.Length - 1].zvMax_z = SelectedTask.m_pLeaveSite[i].zvMax_z;
                        string[] values = new string[]
				{
					SelectedTask.m_pLeaveSite[i].zvMin_x.ToString("F3"),
					SelectedTask.m_pLeaveSite[i].zvMin_y.ToString("F3"),
					SelectedTask.m_pLeaveSite[i].zvMin_z.ToString("F3"),
					SelectedTask.m_pLeaveSite[i].zvMax_x.ToString("F3"),
					SelectedTask.m_pLeaveSite[i].zvMax_y.ToString("F3"),
					SelectedTask.m_pLeaveSite[i].zvMax_z.ToString("F3")
				};
                        this.dataGridView_m_pLeaveSite.Rows.Add(values);
                    }
                }
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void add_m_pszExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulExpCnt++;
                Array.Resize<byte[]>(ref this.SelectedTask.m_pszExp, this.SelectedTask.m_pszExp.Length + 1);
                this.SelectedTask.m_pszExp[this.SelectedTask.m_pszExp.Length - 1] = new byte[64];
                Array.Resize<TASK_EXPRESSION>(ref this.SelectedTask.m_pExpArr, this.SelectedTask.m_pExpArr.Length + 1);
                this.SelectedTask.m_pExpArr[this.SelectedTask.m_pExpArr.Length - 1] = new TASK_EXPRESSION();
                this.SelectedTask.m_pExpArr[this.SelectedTask.m_pExpArr.Length - 1].type = new int[64];
                this.SelectedTask.m_pExpArr[this.SelectedTask.m_pExpArr.Length - 1].value = new float[64];
                string[] values = new string[129];
                values[0] = "";
                for (int i = 0; i < 64; i++)
                {
                    values[(i * 2) + 1] = "0";
                    values[(i * 2) + 2] = "0";
                }
                this.dataGridView_m_pszExp.Rows.Add(values);
            }
        }
        private void clone_m_pszExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int k = dataGridView_m_pszExp.CurrentCell.RowIndex;
                this.SelectedTask.m_ulExpCnt++;
                Array.Resize<byte[]>(ref this.SelectedTask.m_pszExp, this.SelectedTask.m_pszExp.Length + 1);
                this.SelectedTask.m_pszExp[this.SelectedTask.m_pszExp.Length - 1] = this.SelectedTask.m_pszExp[k];
                Array.Resize<TASK_EXPRESSION>(ref this.SelectedTask.m_pExpArr, this.SelectedTask.m_pExpArr.Length + 1);
                this.SelectedTask.m_pExpArr[this.SelectedTask.m_pExpArr.Length - 1] = new TASK_EXPRESSION();
                this.SelectedTask.m_pExpArr[this.SelectedTask.m_pExpArr.Length - 1].type = this.SelectedTask.m_pExpArr[k].type;
                this.SelectedTask.m_pExpArr[this.SelectedTask.m_pExpArr.Length - 1].value = this.SelectedTask.m_pExpArr[k].value;
                string[] values = new string[129];
                values[0] = Extensions.ByteArray_to_GbkString(this.SelectedTask.m_pszExp[k]);
                for (int i = 0; i < 64; i++)
                {
                    values[(i * 2) + 1] = this.SelectedTask.m_pExpArr[k].type[i].ToString();
                    values[(i * 2) + 2] = this.SelectedTask.m_pExpArr[k].value[i].ToString();
                }
                this.dataGridView_m_pszExp.Rows.Add(values);
            }
        }
        private void add_m_pTaskChar(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.m_ulTaskCharCnt++;
                Array.Resize<byte[]>(ref this.SelectedTask.m_pTaskChar, this.SelectedTask.m_pTaskChar.Length + 1);
                this.SelectedTask.m_pTaskChar[this.SelectedTask.m_pTaskChar.Length - 1] = new byte[128];
                string[] values = new string[]
				{
					""
				};
                this.dataGridView_m_pTaskChar.Rows.Add(values);
            }
        }
        private void clone_m_pTaskChar(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (dataGridView_m_pTaskChar.CurrentCell != null)
                {
                    int i = dataGridView_m_pTaskChar.CurrentCell.RowIndex;
                    this.SelectedTask.m_ulTaskCharCnt++;
                    Array.Resize<byte[]>(ref this.SelectedTask.m_pTaskChar, this.SelectedTask.m_pTaskChar.Length + 1);
                    this.SelectedTask.m_pTaskChar[this.SelectedTask.m_pTaskChar.Length - 1] = SelectedTask.m_pTaskChar[i];
                    string[] values = new string[]
				{
					Extensions.ByteArray_to_UnicodeString(SelectedTask.m_pTaskChar[i])
				};
                    this.dataGridView_m_pTaskChar.Rows.Add(values);
                }
            }
        }
        private void add_TMHomeItem(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.SelectedTask.TMHomeItemCount++;
                Array.Resize<HomeItemData>(ref this.SelectedTask.TMHomeItemData, this.SelectedTask.TMHomeItemData.Length + 1);
                this.SelectedTask.TMHomeItemData[this.SelectedTask.TMHomeItemData.Length - 1] = new HomeItemData();
                this.SelectedTask.TMHomeItemData[this.SelectedTask.TMHomeItemData.Length - 1].m_ulItemTemplId = 0;
                this.SelectedTask.TMHomeItemData[this.SelectedTask.TMHomeItemData.Length - 1].m_ulItemNum = 1;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"1"
				};
                this.dataGridView_TMHomeItem.Rows.Add(values);
            }
        }
        private void clone_TMHomeItem(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                if (this.dataGridView_TMHomeItem.CurrentCell != null)
                {
                    int i = this.dataGridView_TMHomeItem.CurrentCell.RowIndex;
                    this.SelectedTask.TMHomeItemCount++;
                    Array.Resize<HomeItemData>(ref this.SelectedTask.TMHomeItemData, this.SelectedTask.TMHomeItemData.Length + 1);
                    this.SelectedTask.TMHomeItemData[this.SelectedTask.TMHomeItemData.Length - 1] = new HomeItemData();
                    this.SelectedTask.TMHomeItemData[this.SelectedTask.TMHomeItemData.Length - 1].m_ulItemTemplId = SelectedTask.TMHomeItemData[i].m_ulItemTemplId;
                    this.SelectedTask.TMHomeItemData[this.SelectedTask.TMHomeItemData.Length - 1].m_ulItemNum = SelectedTask.TMHomeItemData[i].m_ulItemNum;
                    string[] values = new string[]
				{
					SelectedTask.TMHomeItemData[i].m_ulItemTemplId.ToString(),
                    Extensions.HomeItemName(SelectedTask.TMHomeItemData[i].m_ulItemTemplId),
					SelectedTask.TMHomeItemData[i].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
				};
                    this.dataGridView_TMHomeItem.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_AwardItems(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                if (index > -1)
                {
                    this.SelectedReward.m_CandItems[index].m_ulAwardItems++;
                    Array.Resize<ITEM_WANTED>(ref this.SelectedReward.m_CandItems[index].m_AwardItems, this.SelectedReward.m_CandItems[index].m_AwardItems.Length + 1);
                    this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1] = new ITEM_WANTED();
                    this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_ulItemTemplId = 0;
                    this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_bCommonItem = true;
                    this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_ulItemNum = 1;
                    this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_fProb = 1f;
                    this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_lPeriod = 0;
                    string[] values = new string[]
					{
						"0",
					    Extensions.GetLocalization(402),
						"True",
						"1",
						ProbAddValueFormat,
						"00-00:00:00"
					};
                    this.dataGridView_reward_item_m_AwardItems.Rows.Add(values);
                    return;
                }
                JMessageBox.Show(this, Extensions.GetLocalization(410));
            }
        }
        private void clone_reward_m_AwardItems(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_item_m_AwardItems.CurrentCell != null)
                {
                    int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                    if (index > -1)
                    {
                        int i = dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                        this.SelectedReward.m_CandItems[index].m_ulAwardItems++;
                        Array.Resize<ITEM_WANTED>(ref this.SelectedReward.m_CandItems[index].m_AwardItems, this.SelectedReward.m_CandItems[index].m_AwardItems.Length + 1);
                        this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1] = new ITEM_WANTED();
                        this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_ulItemTemplId = SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemTemplId;
                        this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_bCommonItem = SelectedReward.m_CandItems[index].m_AwardItems[i].m_bCommonItem;
                        this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_ulItemNum = SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemNum;
                        this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_fProb = SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb;
                        this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_lPeriod = SelectedReward.m_CandItems[index].m_AwardItems[i].m_lPeriod;
                        string[] values = new string[]
					    {
						    SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemTemplId.ToString(),
                            Extensions.ItemName(SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemTemplId),
						    SelectedReward.m_CandItems[index].m_AwardItems[i].m_bCommonItem.ToString(),
						    SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						    SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb.ToString(ProbValueFormat),
						    Extensions.SecondsToString(SelectedReward.m_CandItems[index].m_AwardItems[i].m_lPeriod)
					    };
                        this.dataGridView_reward_item_m_AwardItems.Rows.Add(values);
                        return;
                    }
                    JMessageBox.Show(this, Extensions.GetLocalization(410));
                }
                JMessageBox.Show(this, Extensions.GetLocalization(411));
            }
        }
        private void clone_in_reward_m_AwardItems(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_item_m_AwardItems.CurrentCell != null)
                {
                    int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                    int index2 = this.toolStripComboBox1.SelectedIndex;
                    this.toolStripComboBox1.SelectedIndex = -1;
                    int i = dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    if (index > -1)
                    {
                        this.SelectedReward.m_CandItems[index2].m_ulAwardItems++;
                        Array.Resize<ITEM_WANTED>(ref this.SelectedReward.m_CandItems[index2].m_AwardItems, this.SelectedReward.m_CandItems[index2].m_AwardItems.Length + 1);
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1] = new ITEM_WANTED();
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_ulItemTemplId = SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemTemplId;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_bCommonItem = SelectedReward.m_CandItems[index].m_AwardItems[i].m_bCommonItem;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_ulItemNum = SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemNum;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_fProb = SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_lPeriod = SelectedReward.m_CandItems[index].m_AwardItems[i].m_lPeriod;
                        return;
                    }
                    JMessageBox.Show(this, Extensions.GetLocalization(410));
                }
                JMessageBox.Show(this, Extensions.GetLocalization(411));
            }
        }
        private void move_in_reward_m_AwardItems(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_item_m_AwardItems.CurrentCell != null)
                {
                    int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                    int index2 = this.toolStripComboBox1_1.SelectedIndex;
                    this.toolStripComboBox1_1.SelectedIndex = -1;
                    int i = dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    if (index > -1)
                    {
                        this.SelectedReward.m_CandItems[index2].m_ulAwardItems++;
                        Array.Resize<ITEM_WANTED>(ref this.SelectedReward.m_CandItems[index2].m_AwardItems, this.SelectedReward.m_CandItems[index2].m_AwardItems.Length + 1);
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1] = new ITEM_WANTED();
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_ulItemTemplId = SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemTemplId;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_bCommonItem = SelectedReward.m_CandItems[index].m_AwardItems[i].m_bCommonItem;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_ulItemNum = SelectedReward.m_CandItems[index].m_AwardItems[i].m_ulItemNum;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_fProb = SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb;
                        this.SelectedReward.m_CandItems[index2].m_AwardItems[this.SelectedReward.m_CandItems[index2].m_AwardItems.Length - 1].m_lPeriod = SelectedReward.m_CandItems[index].m_AwardItems[i].m_lPeriod;
                        int rowIndex = this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                        this.SelectedReward.m_CandItems[index].m_ulAwardItems--;
                        ITEM_WANTED[] destinationArray = new ITEM_WANTED[this.SelectedReward.m_CandItems[index].m_ulAwardItems];
                        Array.Copy(this.SelectedReward.m_CandItems[index].m_AwardItems, 0, destinationArray, 0, this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex);
                        Array.Copy(this.SelectedReward.m_CandItems[index].m_AwardItems, this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex, this.SelectedReward.m_CandItems[index].m_ulAwardItems - this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex);
                        this.SelectedReward.m_CandItems[index].m_AwardItems = destinationArray;
                        this.dataGridView_reward_item_m_AwardItems.Rows.RemoveAt(rowIndex);
                        return;
                    }
                    JMessageBox.Show(this, Extensions.GetLocalization(410));
                }
                JMessageBox.Show(this, Extensions.GetLocalization(411));
            }
        }
        private void add_reward_m_Monsters(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulSummonedMonsters++;
                Array.Resize<MONSTERS_SUMMONED>(ref this.SelectedReward.m_SummonedMonsters.m_Monsters, this.SelectedReward.m_SummonedMonsters.m_Monsters.Length + 1);
                this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1] = new MONSTERS_SUMMONED();
                this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_ulMonsterTemplId = 0;
                this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_ulMonsterNum = 1;
                this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_fSummonProb = 1f;
                this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_lPeriod = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"1",
					ProbAddValueFormat,
					"00-00:00:00"
				};
                this.dataGridView_reward_m_Monsters.Rows.Add(values);
            }
        }
        private void clone_reward_m_Monsters(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                int i = dataGridView_reward_m_Monsters.CurrentCell.RowIndex;
                {
                    if (dataGridView_reward_m_Monsters.CurrentCell != null)
                        this.SelectedReward.m_ulSummonedMonsters++;
                    Array.Resize<MONSTERS_SUMMONED>(ref this.SelectedReward.m_SummonedMonsters.m_Monsters, this.SelectedReward.m_SummonedMonsters.m_Monsters.Length + 1);
                    this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1] = new MONSTERS_SUMMONED();
                    this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_ulMonsterTemplId = SelectedReward.m_SummonedMonsters.m_Monsters[i].m_ulMonsterTemplId;
                    this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_ulMonsterNum = SelectedReward.m_SummonedMonsters.m_Monsters[i].m_ulMonsterNum;
                    this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_fSummonProb = SelectedReward.m_SummonedMonsters.m_Monsters[i].m_fSummonProb;
                    this.SelectedReward.m_SummonedMonsters.m_Monsters[this.SelectedReward.m_SummonedMonsters.m_Monsters.Length - 1].m_lPeriod = SelectedReward.m_SummonedMonsters.m_Monsters[i].m_lPeriod;
                    string[] values = new string[]
				{
					SelectedReward.m_SummonedMonsters.m_Monsters[i].m_ulMonsterTemplId.ToString(),
                    Extensions.MonsterNPCMineName(SelectedReward.m_SummonedMonsters.m_Monsters[i].m_ulMonsterTemplId),
					SelectedReward.m_SummonedMonsters.m_Monsters[i].m_ulMonsterNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedReward.m_SummonedMonsters.m_Monsters[i].m_fSummonProb.ToString(ProbValueFormat),
					Extensions.SecondsToString(SelectedReward.m_SummonedMonsters.m_Monsters[i].m_lPeriod)
				};
                    this.dataGridView_reward_m_Monsters.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_RankingAward(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulPQRankingAwardCnt++;
                Array.Resize<RANKING_AWARD>(ref this.SelectedReward.m_PQRankingAward.m_RankingAward, this.SelectedReward.m_PQRankingAward.m_RankingAward.Length + 1);
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1] = new RANKING_AWARD();
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_iRankingStart = 0;
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_iRankingEnd = 0;
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_bCommonItem = true;
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_ulAwardItemId = 0;
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_ulAwardItemNum = 1;
                this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_lPeriod = 0;
                string[] values = new string[]
				{
					"0",
					"0",
					"True",
					"0",
					Extensions.GetLocalization(402),
					"1",
					"00-00:00:00"
				};
                this.dataGridView_reward_m_RankingAward.Rows.Add(values);
            }
        }
        private void clone_reward_m_RankingAward(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_m_RankingAward.CurrentCell != null)
                {
                    int i = dataGridView_reward_m_RankingAward.CurrentCell.RowIndex;
                    this.SelectedReward.m_ulPQRankingAwardCnt++;
                    Array.Resize<RANKING_AWARD>(ref this.SelectedReward.m_PQRankingAward.m_RankingAward, this.SelectedReward.m_PQRankingAward.m_RankingAward.Length + 1);
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1] = new RANKING_AWARD();
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_iRankingStart = SelectedReward.m_PQRankingAward.m_RankingAward[i].m_iRankingStart;
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_iRankingEnd = SelectedReward.m_PQRankingAward.m_RankingAward[i].m_iRankingEnd;
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_bCommonItem = SelectedReward.m_PQRankingAward.m_RankingAward[i].m_bCommonItem;
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_ulAwardItemId = SelectedReward.m_PQRankingAward.m_RankingAward[i].m_ulAwardItemId;
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_ulAwardItemNum = SelectedReward.m_PQRankingAward.m_RankingAward[i].m_ulAwardItemNum;
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[this.SelectedReward.m_PQRankingAward.m_RankingAward.Length - 1].m_lPeriod = SelectedReward.m_PQRankingAward.m_RankingAward[i].m_lPeriod;
                    string[] values = new string[]
				{
					SelectedReward.m_PQRankingAward.m_RankingAward[i].m_iRankingStart.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedReward.m_PQRankingAward.m_RankingAward[i].m_iRankingEnd.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					SelectedReward.m_PQRankingAward.m_RankingAward[i].m_bCommonItem.ToString(),
					SelectedReward.m_PQRankingAward.m_RankingAward[i].m_ulAwardItemId.ToString(),
					Extensions.ItemName(SelectedReward.m_PQRankingAward.m_RankingAward[i].m_ulAwardItemId),
					SelectedReward.m_PQRankingAward.m_RankingAward[i].m_ulAwardItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					Extensions.SecondsToString(SelectedReward.m_PQRankingAward.m_RankingAward[i].m_lPeriod)
				};
                    this.dataGridView_reward_m_RankingAward.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_ulChangeKey(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulChangeKeyCnt++;
                Array.Resize<int>(ref this.SelectedReward.m_plChangeKey, this.SelectedReward.m_plChangeKey.Length + 1);
                this.SelectedReward.m_plChangeKey[this.SelectedReward.m_plChangeKey.Length - 1] = new int();
                this.SelectedReward.m_plChangeKey[this.SelectedReward.m_plChangeKey.Length - 1] = 0;
                Array.Resize<int>(ref this.SelectedReward.m_plChangeKeyValue, this.SelectedReward.m_plChangeKeyValue.Length + 1);
                this.SelectedReward.m_plChangeKeyValue[this.SelectedReward.m_plChangeKeyValue.Length - 1] = new int();
                this.SelectedReward.m_plChangeKeyValue[this.SelectedReward.m_plChangeKeyValue.Length - 1] = 0;
                Array.Resize<bool>(ref this.SelectedReward.m_pbChangeType, this.SelectedReward.m_pbChangeType.Length + 1);
                this.SelectedReward.m_pbChangeType[this.SelectedReward.m_pbChangeType.Length - 1] = new bool();
                this.SelectedReward.m_pbChangeType[this.SelectedReward.m_pbChangeType.Length - 1] = false;
                string[] values = new string[]
				{
					"0",
					"0",
					this.dataGridViewTextBoxColumn100.Items[0].ToString()
				};
                this.dataGridView_reward_m_ulChangeKey.Rows.Add(values);
            }
        }
        private void clone_reward_m_ulChangeKey(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_m_ulChangeKey.CurrentCell != null)
                {
                    int i = dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex;
                    this.SelectedReward.m_ulChangeKeyCnt++;
                    Array.Resize<int>(ref this.SelectedReward.m_plChangeKey, this.SelectedReward.m_plChangeKey.Length + 1);
                    this.SelectedReward.m_plChangeKey[this.SelectedReward.m_plChangeKey.Length - 1] = new int();
                    this.SelectedReward.m_plChangeKey[this.SelectedReward.m_plChangeKey.Length - 1] = SelectedReward.m_plChangeKey[i];
                    Array.Resize<int>(ref this.SelectedReward.m_plChangeKeyValue, this.SelectedReward.m_plChangeKeyValue.Length + 1);
                    this.SelectedReward.m_plChangeKeyValue[this.SelectedReward.m_plChangeKeyValue.Length - 1] = new int();
                    this.SelectedReward.m_plChangeKeyValue[this.SelectedReward.m_plChangeKeyValue.Length - 1] = SelectedReward.m_plChangeKeyValue[i];
                    Array.Resize<bool>(ref this.SelectedReward.m_pbChangeType, this.SelectedReward.m_pbChangeType.Length + 1);
                    this.SelectedReward.m_pbChangeType[this.SelectedReward.m_pbChangeType.Length - 1] = new bool();
                    this.SelectedReward.m_pbChangeType[this.SelectedReward.m_pbChangeType.Length - 1] = SelectedReward.m_pbChangeType[i];
                    string[] values = new string[]
				{
					SelectedReward.m_plChangeKey[i].ToString(),
					SelectedReward.m_plChangeKeyValue[i].ToString(),
					this.dataGridViewTextBoxColumn100.Items[Convert.ToInt32(SelectedReward.m_pbChangeType[i])].ToString()
				};
                    this.dataGridView_reward_m_ulChangeKey.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_ulHistoryChange(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulHistoryChangeCnt++;
                Array.Resize<int>(ref this.SelectedReward.m_plHistoryChangeKey, this.SelectedReward.m_plHistoryChangeKey.Length + 1);
                this.SelectedReward.m_plHistoryChangeKey[this.SelectedReward.m_plHistoryChangeKey.Length - 1] = new int();
                this.SelectedReward.m_plHistoryChangeKey[this.SelectedReward.m_plHistoryChangeKey.Length - 1] = 0;
                Array.Resize<int>(ref this.SelectedReward.m_plHistoryChangeKeyValue, this.SelectedReward.m_plHistoryChangeKeyValue.Length + 1);
                this.SelectedReward.m_plHistoryChangeKeyValue[this.SelectedReward.m_plHistoryChangeKeyValue.Length - 1] = new int();
                this.SelectedReward.m_plHistoryChangeKeyValue[this.SelectedReward.m_plHistoryChangeKeyValue.Length - 1] = 0;
                Array.Resize<bool>(ref this.SelectedReward.m_pbHistoryChangeType, this.SelectedReward.m_pbHistoryChangeType.Length + 1);
                this.SelectedReward.m_pbHistoryChangeType[this.SelectedReward.m_pbHistoryChangeType.Length - 1] = new bool();
                this.SelectedReward.m_pbHistoryChangeType[this.SelectedReward.m_pbHistoryChangeType.Length - 1] = false;
                string[] values = new string[]
				{
					"0",
					"0",
					this.Column282.Items[0].ToString()
				};
                this.dataGridView_reward_m_ulHistoryChange.Rows.Add(values);
            }
        }
        private void clone_reward_m_ulHistoryChange(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_m_ulHistoryChange.CurrentCell != null)
                {
                    int i = dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex;
                    this.SelectedReward.m_ulHistoryChangeCnt++;
                    Array.Resize<int>(ref this.SelectedReward.m_plHistoryChangeKey, this.SelectedReward.m_plHistoryChangeKey.Length + 1);
                    this.SelectedReward.m_plHistoryChangeKey[this.SelectedReward.m_plHistoryChangeKey.Length - 1] = new int();
                    this.SelectedReward.m_plHistoryChangeKey[this.SelectedReward.m_plHistoryChangeKey.Length - 1] = SelectedReward.m_plHistoryChangeKey[i];
                    Array.Resize<int>(ref this.SelectedReward.m_plHistoryChangeKeyValue, this.SelectedReward.m_plHistoryChangeKeyValue.Length + 1);
                    this.SelectedReward.m_plHistoryChangeKeyValue[this.SelectedReward.m_plHistoryChangeKeyValue.Length - 1] = new int();
                    this.SelectedReward.m_plHistoryChangeKeyValue[this.SelectedReward.m_plHistoryChangeKeyValue.Length - 1] = SelectedReward.m_plHistoryChangeKeyValue[i];
                    Array.Resize<bool>(ref this.SelectedReward.m_pbHistoryChangeType, this.SelectedReward.m_pbHistoryChangeType.Length + 1);
                    this.SelectedReward.m_pbHistoryChangeType[this.SelectedReward.m_pbHistoryChangeType.Length - 1] = new bool();
                    this.SelectedReward.m_pbHistoryChangeType[this.SelectedReward.m_pbHistoryChangeType.Length - 1] = SelectedReward.m_pbHistoryChangeType[i];
                    string[] values = new string[]
				{
					SelectedReward.m_plHistoryChangeKey[i].ToString(),
					SelectedReward.m_plHistoryChangeKeyValue[i].ToString(),
					this.Column282.Items[Convert.ToInt32(SelectedReward.m_pbHistoryChangeType[i])].ToString()
				};
                    this.dataGridView_reward_m_ulHistoryChange.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_plDisplayKey(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulDisplayKeyCnt++;
                Array.Resize<int>(ref this.SelectedReward.m_plDisplayKey, this.SelectedReward.m_plDisplayKey.Length + 1);
                this.SelectedReward.m_plDisplayKey[this.SelectedReward.m_plDisplayKey.Length - 1] = new int();
                this.SelectedReward.m_plDisplayKey[this.SelectedReward.m_plDisplayKey.Length - 1] = 0;
                string[] values = new string[]
				{
					"0"
				};
                this.dataGridView_reward_m_plDisplayKey.Rows.Add(values);
            }
        }
        private void add_reward_m_pszExp(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulExpCnt++;
                Array.Resize<byte[]>(ref this.SelectedReward.m_pszExp, this.SelectedReward.m_pszExp.Length + 1);
                this.SelectedReward.m_pszExp[this.SelectedReward.m_pszExp.Length - 1] = new byte[64];
                Array.Resize<TASK_EXPRESSION>(ref this.SelectedReward.m_pExpArr, this.SelectedReward.m_pExpArr.Length + 1);
                this.SelectedReward.m_pExpArr[this.SelectedReward.m_pExpArr.Length - 1] = new TASK_EXPRESSION();
                this.SelectedReward.m_pExpArr[this.SelectedReward.m_pExpArr.Length - 1].type = new int[64];
                this.SelectedReward.m_pExpArr[this.SelectedReward.m_pExpArr.Length - 1].value = new float[64];
                string[] values = new string[129];
                values[0] = "";
                for (int i = 0; i < 64; i++)
                {
                    values[(i * 2) + 1] = "0";
                    values[(i * 2) + 2] = "0";
                }
                this.dataGridView_reward_m_pszExp.Rows.Add(values);
            }
        }
        private void clone_reward_m_pszExp(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                int k = dataGridView_reward_m_pszExp.CurrentCell.RowIndex;
                this.SelectedReward.m_ulExpCnt++;
                Array.Resize<byte[]>(ref this.SelectedReward.m_pszExp, this.SelectedReward.m_pszExp.Length + 1);
                this.SelectedReward.m_pszExp[this.SelectedReward.m_pszExp.Length - 1] = this.SelectedReward.m_pszExp[k];
                Array.Resize<TASK_EXPRESSION>(ref this.SelectedReward.m_pExpArr, this.SelectedReward.m_pExpArr.Length + 1);
                this.SelectedReward.m_pExpArr[this.SelectedReward.m_pExpArr.Length - 1] = new TASK_EXPRESSION();
                this.SelectedReward.m_pExpArr[this.SelectedReward.m_pExpArr.Length - 1].type = this.SelectedReward.m_pExpArr[k].type;
                this.SelectedReward.m_pExpArr[this.SelectedReward.m_pExpArr.Length - 1].value = this.SelectedReward.m_pExpArr[k].value;
                string[] values = new string[129];
                values[0] = Extensions.ByteArray_to_GbkString(this.SelectedReward.m_pszExp[k]);
                for (int i = 0; i < 64; i++)
                {
                    values[(i * 2) + 1] = this.SelectedReward.m_pExpArr[k].type[i].ToString();
                    values[(i * 2) + 2] = this.SelectedReward.m_pExpArr[k].value[i].ToString();
                }
                this.dataGridView_reward_m_pszExp.Rows.Add(values);
            }
        }
        private void add_reward_m_pTaskChar(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulTaskCharCnt++;
                Array.Resize<byte[]>(ref this.SelectedReward.m_pTaskChar, this.SelectedReward.m_pTaskChar.Length + 1);
                this.SelectedReward.m_pTaskChar[this.SelectedReward.m_pTaskChar.Length - 1] = new byte[128];
                string[] values = new string[]
				{
					""
				};
                this.dataGridView_reward_m_pTaskChar.Rows.Add(values);
            }
        }
        private void clone_reward_m_pTaskChar(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_m_pTaskChar.CurrentCell != null)
                {
                    int i = dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex;
                    this.SelectedReward.m_ulTaskCharCnt++;
                    Array.Resize<byte[]>(ref this.SelectedReward.m_pTaskChar, this.SelectedReward.m_pTaskChar.Length + 1);
                    this.SelectedReward.m_pTaskChar[this.SelectedReward.m_pTaskChar.Length - 1] = SelectedReward.m_pTaskChar[i];
                    string[] values = new string[]
				{
					Extensions.ByteArray_to_GbkString(SelectedReward.m_pTaskChar[i])
				};
                    this.dataGridView_reward_m_pTaskChar.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_pTitleAward(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                this.SelectedReward.m_ulTitleNum++;
                Array.Resize<TITLE_AWARD>(ref this.SelectedReward.m_pTitleAward, this.SelectedReward.m_pTitleAward.Length + 1);
                this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1] = new TITLE_AWARD();
                this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1].m_ulTitleID = 0;
                this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1].m_lPeriod = 0;
                string[] values = new string[]
				{
					"0",
					Extensions.GetLocalization(402),
					"00-00:00:00"
				};
                this.dataGridView_reward_m_pTitleAward.Rows.Add(values);
            }
        }
        private void clone_reward_m_pTitleAward(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_m_pTitleAward.CurrentCell != null)
                {
                    int i = dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex;
                    this.SelectedReward.m_ulTitleNum++;
                    Array.Resize<TITLE_AWARD>(ref this.SelectedReward.m_pTitleAward, this.SelectedReward.m_pTitleAward.Length + 1);
                    this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1] = new TITLE_AWARD();
                    this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1].m_ulTitleID = SelectedReward.m_pTitleAward[i].m_ulTitleID;
                    this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1].m_lPeriod = SelectedReward.m_pTitleAward[i].m_lPeriod;
                    string[] values = new string[]
				{
					SelectedReward.m_pTitleAward[i].m_ulTitleID.ToString(),
                    Extensions.TitleName(SelectedReward.m_pTitleAward[i].m_ulTitleID),
					Extensions.SecondsToString(SelectedReward.m_pTitleAward[i].m_lPeriod)
				};
                    this.dataGridView_reward_m_pTitleAward.Rows.Add(values);
                }
            }
        }
        private void add_reward_m_AwByRatio_S(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                JMessageBox.Show(this, Extensions.GetLocalization(412));
            }
        }
        private void add_reward_m_AwByRatio_F(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                JMessageBox.Show(this, Extensions.GetLocalization(412));
            }
        }
        private void add_window(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                if (selectedIndex > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].num_window++;
                    Array.Resize<window>(ref this.SelectedTask.talk_procs[selectedIndex].windows, this.SelectedTask.talk_procs[selectedIndex].windows.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1] = new window();
                    this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    if (this.SelectedTask.talk_procs[selectedIndex].windows.Length > 1)
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].id = this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 2].id + 1;
                        this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].id_parent = this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 2].id;
                    }
                    else
                    {
                        this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].id = 1;
                        this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].id_parent = -1;
                    }
                    this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].num_option = 0;
                    this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].options = new option[0];
                    this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].talktext = Extensions.GetLocalization(413) + this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].id + "";
                    this.listBox_conversation_windows.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1].id + "]" + Extensions.GetLocalization(414));
                    if (this.SelectedTask.talk_procs[selectedIndex].num_window < 2)
                    {
                        this.SelectedTask.talk_procs[selectedIndex].DialogText = "RootNode";
                        this.textBox_conversation_talk_proc_text.Text = "RootNode";
                    }
                    this.listBox_conversation_talk_procs.Items[selectedIndex] = Extensions.GetLocalization(1704 + selectedIndex) + "(" + this.SelectedTask.talk_procs[selectedIndex].num_window + ")";
                    this.listBox_conversation_windows.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1;
                }
            }
        }
        private void add_NPC_GIVE_TASK_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && index > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option++;
                    Array.Resize<option>(ref this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1] = new option();
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].param = -2147483642;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].id = this.SelectedTask.ID;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].optiontext = Extensions.GetLocalization(415) + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + Extensions.GetLocalization(417) + this.SelectedTask.ID + "";
                    this.listBox_conversation_options.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + "]" + Extensions.GetLocalization(416));
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        private void add_NPC_COMPLETE_TASK_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && index > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option++;
                    Array.Resize<option>(ref this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1] = new option();
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].param = -2147483641;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].id = this.SelectedTask.ID;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].optiontext = Extensions.GetLocalization(415) + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + Extensions.GetLocalization(418) + this.SelectedTask.ID + "";
                    this.listBox_conversation_options.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + "]" + Extensions.GetLocalization(416));
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        private void add_TALK_GIVEUP_TASK_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && index > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option++;
                    Array.Resize<option>(ref this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1] = new option();
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].param = -2147483627;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].id = this.SelectedTask.ID;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].optiontext = Extensions.GetLocalization(415) + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + Extensions.GetLocalization(419) + this.SelectedTask.ID + "";
                    this.listBox_conversation_options.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + "]" + Extensions.GetLocalization(416));
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        private void add_TALK_RETURN_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && index > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option++;
                    Array.Resize<option>(ref this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1] = new option();
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].param = -2147483631;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].id = 0;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].optiontext = Extensions.GetLocalization(415) + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + Extensions.GetLocalization(420);
                    this.listBox_conversation_options.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + "]" + Extensions.GetLocalization(416));
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        private void add_TALK_EXIT_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && index > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option++;
                    Array.Resize<option>(ref this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1] = new option();
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].param = -2147483630;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].id = 0;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].optiontext = Extensions.GetLocalization(415) + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + Extensions.GetLocalization(421);
                    this.listBox_conversation_options.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + "]" + Extensions.GetLocalization(416));
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        private void add_Window_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && index > -1)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option++;
                    Array.Resize<option>(ref this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + 1);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1] = new option();
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].crypt_key = this.SelectedTask.conversation.crypt_key;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].param = this.SelectedTask.talk_procs[selectedIndex].windows.Length;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].id = 0;
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options[this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1].optiontext = Extensions.GetLocalization(415) + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + Extensions.GetLocalization(422) + this.SelectedTask.talk_procs[selectedIndex].windows.Length + "";
                    this.listBox_conversation_options.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length + "]" + Extensions.GetLocalization(416));
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        #endregion

        #region Remove
        private void remove_m_tmStart_m_tmEnd(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulTimetable > 0 && this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulTimetable--;
                task_tm[] destinationArray_1 = new task_tm[this.SelectedTask.m_ulTimetable];
                Array.Copy(this.SelectedTask.m_tmStart, 0, destinationArray_1, 0, this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_tmStart, this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex + 1, destinationArray_1, this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex, this.SelectedTask.m_ulTimetable - this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex);
                this.SelectedTask.m_tmStart = destinationArray_1;
                task_tm[] destinationArray_2 = new task_tm[this.SelectedTask.m_ulTimetable];
                Array.Copy(this.SelectedTask.m_tmEnd, 0, destinationArray_2, 0, this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_tmEnd, this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex + 1, destinationArray_2, this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex, this.SelectedTask.m_ulTimetable - this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex);
                this.SelectedTask.m_tmEnd = destinationArray_2;
                this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows.RemoveAt(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.CurrentCell.RowIndex);
                int index;
                for (index = 0; index < this.dataGridView_m_tmType_m_tmStart_m_tmEnd.RowCount; index++)
                {
                    this.SelectedTask.m_tmType[index] = Convert.ToByte(this.Column416.Items.IndexOf(this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows[index].Cells[0].Value));
                }
                for (int index1 = index; index1 < this.SelectedTask.m_tmType.Length; index1++)
                {
                    this.SelectedTask.m_tmType[index1] = 0;
                }
            }
        }
        private void remove_m_pDelvRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null && this.SelectedTask.m_ulDelvRegionCnt > 0 && this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex > -1)
                {
                    this.SelectedTask.m_ulDelvRegionCnt--;
                    Task_Region[] destinationArray = new Task_Region[this.SelectedTask.m_ulDelvRegionCnt];
                    Array.Copy(this.SelectedTask.m_pDelvRegion, 0, destinationArray, 0, this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex);
                    Array.Copy(this.SelectedTask.m_pDelvRegion, this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex, this.SelectedTask.m_ulDelvRegionCnt - this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex);
                    this.SelectedTask.m_pDelvRegion = destinationArray;
                    this.dataGridView_m_pDelvRegion.Rows.RemoveAt(this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex);
                }
                this.Convert_m_pDelvRegion(null, null);
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void remove_m_pEnterRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null && this.SelectedTask.m_ulEnterRegionCnt > 0 && this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex > -1)
                {
                    this.SelectedTask.m_ulEnterRegionCnt--;
                    Task_Region[] destinationArray = new Task_Region[this.SelectedTask.m_ulEnterRegionCnt];
                    Array.Copy(this.SelectedTask.m_pEnterRegion, 0, destinationArray, 0, this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex);
                    Array.Copy(this.SelectedTask.m_pEnterRegion, this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex, this.SelectedTask.m_ulEnterRegionCnt - this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex);
                    this.SelectedTask.m_pEnterRegion = destinationArray;
                    this.dataGridView_m_pEnterRegion.Rows.RemoveAt(this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex);
                }
                this.Convert_m_pEnterRegion(null, null);
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void remove_m_pLeaveRegion(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null && this.SelectedTask.m_ulLeaveRegionCnt > 0 && this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex > -1)
                {
                    this.SelectedTask.m_ulLeaveRegionCnt--;
                    Task_Region[] destinationArray = new Task_Region[this.SelectedTask.m_ulLeaveRegionCnt];
                    Array.Copy(this.SelectedTask.m_pLeaveRegion, 0, destinationArray, 0, this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex);
                    Array.Copy(this.SelectedTask.m_pLeaveRegion, this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex, this.SelectedTask.m_ulLeaveRegionCnt - this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex);
                    this.SelectedTask.m_pLeaveRegion = destinationArray;
                    this.dataGridView_m_pLeaveRegion.Rows.RemoveAt(this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex);
                }
                this.Convert_m_pLeaveRegion(null, null);
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void remove_m_ulChangeKey(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulChangeKeyCnt > 0 && this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulChangeKeyCnt--;
                int[] destinationArray_1 = new int[this.SelectedTask.m_ulChangeKeyCnt];
                Array.Copy(this.SelectedTask.m_plChangeKey, 0, destinationArray_1, 0, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_plChangeKey, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex + 1, destinationArray_1, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex, this.SelectedTask.m_ulChangeKeyCnt - this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
                this.SelectedTask.m_plChangeKey = destinationArray_1;
                int[] destinationArray_2 = new int[this.SelectedTask.m_ulChangeKeyCnt];
                Array.Copy(this.SelectedTask.m_plChangeKeyValue, 0, destinationArray_2, 0, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_plChangeKeyValue, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex + 1, destinationArray_2, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex, this.SelectedTask.m_ulChangeKeyCnt - this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
                this.SelectedTask.m_plChangeKeyValue = destinationArray_2;
                bool[] destinationArray_3 = new bool[this.SelectedTask.m_ulChangeKeyCnt];
                Array.Copy(this.SelectedTask.m_pbChangeType, 0, destinationArray_3, 0, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_pbChangeType, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex + 1, destinationArray_3, this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex, this.SelectedTask.m_ulChangeKeyCnt - this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
                this.SelectedTask.m_pbChangeType = destinationArray_3;
                this.dataGridView_m_ulChangeKey.Rows.RemoveAt(this.dataGridView_m_ulChangeKey.CurrentCell.RowIndex);
            }
        }
        private void remove_m_pszPQExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulPQExpCnt > 0 && this.dataGridView_m_pszPQExp.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulPQExpCnt--;
                byte[][] destinationArray = new byte[this.SelectedTask.m_ulPQExpCnt][];
                Array.Copy(this.SelectedTask.m_pszPQExp, 0, destinationArray, 0, this.dataGridView_m_pszPQExp.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_pszPQExp, this.dataGridView_m_pszPQExp.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pszPQExp.CurrentCell.RowIndex, this.SelectedTask.m_ulPQExpCnt - this.dataGridView_m_pszPQExp.CurrentCell.RowIndex);
                this.SelectedTask.m_pszPQExp = destinationArray;
                TASK_EXPRESSION[] destinationArray2 = new TASK_EXPRESSION[this.SelectedTask.m_ulPQExpCnt];
                Array.Copy(this.SelectedTask.m_pPQExpArr, 0, destinationArray2, 0, this.dataGridView_m_pszPQExp.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_pPQExpArr, this.dataGridView_m_pszPQExp.CurrentCell.RowIndex + 1, destinationArray2, this.dataGridView_m_pszPQExp.CurrentCell.RowIndex, this.SelectedTask.m_ulPQExpCnt - this.dataGridView_m_pszPQExp.CurrentCell.RowIndex);
                this.SelectedTask.m_pPQExpArr = destinationArray2;
                this.dataGridView_m_pszPQExp.Rows.RemoveAt(this.dataGridView_m_pszPQExp.CurrentCell.RowIndex);
            }
        }
        private void remove_m_MonstersContrib(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulMonsterContribCnt > 0 && this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulMonsterContribCnt--;
                MONSTERS_CONTRIB[] destinationArray = new MONSTERS_CONTRIB[this.SelectedTask.m_ulMonsterContribCnt];
                Array.Copy(this.SelectedTask.m_MonstersContrib, 0, destinationArray, 0, this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_MonstersContrib, this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex, this.SelectedTask.m_ulMonsterContribCnt - this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex);
                this.SelectedTask.m_MonstersContrib = destinationArray;
                this.dataGridView_m_MonstersContrib.Rows.RemoveAt(this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex);
            }
        }
        private void remove_m_PremItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulPremItems > 0 && this.dataGridView_m_PremItems.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulPremItems--;
                ITEM_WANTED[] destinationArray = new ITEM_WANTED[this.SelectedTask.m_ulPremItems];
                Array.Copy(this.SelectedTask.m_PremItems, 0, destinationArray, 0, this.dataGridView_m_PremItems.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_PremItems, this.dataGridView_m_PremItems.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_PremItems.CurrentCell.RowIndex, this.SelectedTask.m_ulPremItems - this.dataGridView_m_PremItems.CurrentCell.RowIndex);
                this.SelectedTask.m_PremItems = destinationArray;
                this.dataGridView_m_PremItems.Rows.RemoveAt(this.dataGridView_m_PremItems.CurrentCell.RowIndex);
            }
        }
        private void remove_m_GivenItems(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulGivenItems > 0 && this.dataGridView_m_GivenItems.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulGivenItems--;
                ITEM_WANTED[] destinationArray = new ITEM_WANTED[this.SelectedTask.m_ulGivenItems];
                Array.Copy(this.SelectedTask.m_GivenItems, 0, destinationArray, 0, this.dataGridView_m_GivenItems.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_GivenItems, this.dataGridView_m_GivenItems.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_GivenItems.CurrentCell.RowIndex, this.SelectedTask.m_ulGivenItems - this.dataGridView_m_GivenItems.CurrentCell.RowIndex);
                this.SelectedTask.m_GivenItems = destinationArray;
                this.dataGridView_m_GivenItems.Rows.RemoveAt(this.dataGridView_m_GivenItems.CurrentCell.RowIndex);
            }
            this.Count_m_ulGivenCmnCount_m_ulGivenTskCount();
        }
        private void remove_m_TeamMemsWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulTeamMemsWanted > 0 && this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulTeamMemsWanted--;
                TEAM_MEM_WANTED[] destinationArray = new TEAM_MEM_WANTED[this.SelectedTask.m_ulTeamMemsWanted];
                Array.Copy(this.SelectedTask.m_TeamMemsWanted, 0, destinationArray, 0, this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_TeamMemsWanted, this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex, this.SelectedTask.m_ulTeamMemsWanted - this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex);
                this.SelectedTask.m_TeamMemsWanted = destinationArray;
                this.dataGridView_m_TeamMemsWanted.Rows.RemoveAt(this.dataGridView_m_TeamMemsWanted.CurrentCell.RowIndex);
            }
        }
        private void remove_m_PremTitles(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_iPremTitleNumTotal > 0 && this.dataGridView_m_PremTitles.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_iPremTitleNumTotal--;
                int[] destinationArray = new int[this.SelectedTask.m_iPremTitleNumTotal];
                Array.Copy(this.SelectedTask.m_PremTitles, 0, destinationArray, 0, this.dataGridView_m_PremTitles.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_PremTitles, this.dataGridView_m_PremTitles.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_PremTitles.CurrentCell.RowIndex, this.SelectedTask.m_iPremTitleNumTotal - this.dataGridView_m_PremTitles.CurrentCell.RowIndex);
                this.SelectedTask.m_PremTitles = destinationArray;
                this.dataGridView_m_PremTitles.Rows.RemoveAt(this.dataGridView_m_PremTitles.CurrentCell.RowIndex);
            }
        }
        private void remove_m_PlayerWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulPlayerWanted > 0 && this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulPlayerWanted--;
                PLAYER_WANTED[] destinationArray = new PLAYER_WANTED[this.SelectedTask.m_ulPlayerWanted];
                Array.Copy(this.SelectedTask.m_PlayerWanted, 0, destinationArray, 0, this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_PlayerWanted, this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex, this.SelectedTask.m_ulPlayerWanted - this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex);
                this.SelectedTask.m_PlayerWanted = destinationArray;
                this.dataGridView_m_PlayerWanted.Rows.RemoveAt(this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex);
            }
        }
        private void remove_m_MonsterWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulMonsterWanted > 0 && this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulMonsterWanted--;
                MONSTER_WANTED[] destinationArray = new MONSTER_WANTED[this.SelectedTask.m_ulMonsterWanted];
                Array.Copy(this.SelectedTask.m_MonsterWanted, 0, destinationArray, 0, this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_MonsterWanted, this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex, this.SelectedTask.m_ulMonsterWanted - this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex);
                this.SelectedTask.m_MonsterWanted = destinationArray;
                this.dataGridView_m_MonsterWanted.Rows.RemoveAt(this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex);
            }
        }
        private void remove_m_ItemsWanted(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulItemsWanted > 0 && this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulItemsWanted--;
                ITEM_WANTED[] destinationArray = new ITEM_WANTED[this.SelectedTask.m_ulItemsWanted];
                Array.Copy(this.SelectedTask.m_ItemsWanted, 0, destinationArray, 0, this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_ItemsWanted, this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex, this.SelectedTask.m_ulItemsWanted - this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex);
                this.SelectedTask.m_ItemsWanted = destinationArray;
                this.dataGridView_m_ItemsWanted.Rows.RemoveAt(this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex);
            }
        }
        private void remove_m_pReachSite(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null && this.SelectedTask.m_ulReachSiteCnt > 0 && this.dataGridView_m_pReachSite.CurrentCell.RowIndex > -1)
                {
                    this.SelectedTask.m_ulReachSiteCnt--;
                    Task_Region[] destinationArray = new Task_Region[this.SelectedTask.m_ulReachSiteCnt];
                    Array.Copy(this.SelectedTask.m_pReachSite, 0, destinationArray, 0, this.dataGridView_m_pReachSite.CurrentCell.RowIndex);
                    Array.Copy(this.SelectedTask.m_pReachSite, this.dataGridView_m_pReachSite.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pReachSite.CurrentCell.RowIndex, this.SelectedTask.m_ulReachSiteCnt - this.dataGridView_m_pReachSite.CurrentCell.RowIndex);
                    this.SelectedTask.m_pReachSite = destinationArray;
                    this.dataGridView_m_pReachSite.Rows.RemoveAt(this.dataGridView_m_pReachSite.CurrentCell.RowIndex);
                }
                this.Convert_m_pReachSite(null, null);
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void remove_m_pLeaveSite(object sender, EventArgs e)
        {
            if (version >= 80)
            {
                if (this.SelectedTask != null && this.SelectedTask.m_ulLeaveSiteCnt > 0 && this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex > -1)
                {
                    this.SelectedTask.m_ulLeaveSiteCnt--;
                    Task_Region[] destinationArray = new Task_Region[this.SelectedTask.m_ulLeaveSiteCnt];
                    Array.Copy(this.SelectedTask.m_pLeaveSite, 0, destinationArray, 0, this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex);
                    Array.Copy(this.SelectedTask.m_pLeaveSite, this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex, this.SelectedTask.m_ulLeaveSiteCnt - this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex);
                    this.SelectedTask.m_pLeaveSite = destinationArray;
                    this.dataGridView_m_pLeaveSite.Rows.RemoveAt(this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex);
                }
                this.Convert_m_pLeaveSite(null, null);
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(409));
            }
        }
        private void remove_m_pszExp(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulExpCnt > 0 && this.dataGridView_m_pszExp.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulExpCnt--;
                byte[][] destinationArray = new byte[this.SelectedTask.m_ulExpCnt][];
                Array.Copy(this.SelectedTask.m_pszExp, 0, destinationArray, 0, this.dataGridView_m_pszExp.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_pszExp, this.dataGridView_m_pszExp.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pszExp.CurrentCell.RowIndex, this.SelectedTask.m_ulExpCnt - this.dataGridView_m_pszExp.CurrentCell.RowIndex);
                this.SelectedTask.m_pszExp = destinationArray;
                TASK_EXPRESSION[] destinationArray2 = new TASK_EXPRESSION[this.SelectedTask.m_ulExpCnt];
                Array.Copy(this.SelectedTask.m_pExpArr, 0, destinationArray2, 0, this.dataGridView_m_pszExp.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_pExpArr, this.dataGridView_m_pszExp.CurrentCell.RowIndex + 1, destinationArray2, this.dataGridView_m_pszExp.CurrentCell.RowIndex, this.SelectedTask.m_ulExpCnt - this.dataGridView_m_pszExp.CurrentCell.RowIndex);
                this.SelectedTask.m_pExpArr = destinationArray2;
                this.dataGridView_m_pszExp.Rows.RemoveAt(this.dataGridView_m_pszExp.CurrentCell.RowIndex);
            }
        }
        private void remove_m_pTaskChar(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.m_ulTaskCharCnt > 0 && this.dataGridView_m_pTaskChar.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.m_ulTaskCharCnt--;
                byte[][] destinationArray = new byte[this.SelectedTask.m_ulTaskCharCnt][];
                Array.Copy(this.SelectedTask.m_pTaskChar, 0, destinationArray, 0, this.dataGridView_m_pTaskChar.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.m_pTaskChar, this.dataGridView_m_pTaskChar.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_m_pTaskChar.CurrentCell.RowIndex, this.SelectedTask.m_ulTaskCharCnt - this.dataGridView_m_pTaskChar.CurrentCell.RowIndex);
                this.SelectedTask.m_pTaskChar = destinationArray;
                this.dataGridView_m_pTaskChar.Rows.RemoveAt(this.dataGridView_m_pTaskChar.CurrentCell.RowIndex);
            }
            this.FormatingString_m_pTaskChar();
        }
        private void remove_TMHomeItem(object sender, EventArgs e)
        {
            if (this.SelectedTask != null && this.SelectedTask.TMHomeItemCount > 0 && this.dataGridView_TMHomeItem.CurrentCell.RowIndex > -1)
            {
                this.SelectedTask.TMHomeItemCount--;
                HomeItemData[] destinationArray = new HomeItemData[this.SelectedTask.TMHomeItemCount];
                Array.Copy(this.SelectedTask.TMHomeItemData, 0, destinationArray, 0, this.dataGridView_TMHomeItem.CurrentCell.RowIndex);
                Array.Copy(this.SelectedTask.TMHomeItemData, this.dataGridView_TMHomeItem.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_TMHomeItem.CurrentCell.RowIndex, this.SelectedTask.TMHomeItemCount - this.dataGridView_TMHomeItem.CurrentCell.RowIndex);
                this.SelectedTask.TMHomeItemData = destinationArray;
                this.dataGridView_TMHomeItem.Rows.RemoveAt(this.dataGridView_TMHomeItem.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_CandItems(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulCandItems > 0 && this.checkedListBox_reward_canditems_m_bRandChoose.Items.Count > -1)
            {
                this.toolStripComboBox1.SelectedIndex = -1;
                this.toolStripComboBox1_1.SelectedIndex = -1;
                this.SelectedReward.m_ulCandItems--;
                AWARD_ITEMS_CAND[] destinationArray = new AWARD_ITEMS_CAND[this.SelectedReward.m_ulCandItems];
                Array.Copy(this.SelectedReward.m_CandItems, 0, destinationArray, 0, this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex);
                Array.Copy(this.SelectedReward.m_CandItems, this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex + 1, destinationArray, this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex, this.SelectedReward.m_ulCandItems - this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex);
                this.SelectedReward.m_CandItems = destinationArray;
                this.checkedListBox_reward_canditems_m_bRandChoose.Items.RemoveAt(this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex);
                this.numericUpDown_reward_m_ulCandItems.Text = this.SelectedReward.m_ulCandItems.ToString();
                this.checkedListBox_reward_canditems_m_bRandChoose.Items.Clear();
                this.toolStripComboBox1.Items.Clear();
                this.toolStripComboBox1.SelectedIndex = -1;
                this.toolStripComboBox1_1.Items.Clear();
                this.toolStripComboBox1_1.SelectedIndex = -1;
                for (int num22 = 0; num22 < this.SelectedReward.m_CandItems.Length; num22++)
                {
                    this.checkedListBox_reward_canditems_m_bRandChoose.Items.Add("[" + (num22 + 1).ToString() + "]" + Extensions.GetLocalization(406), this.SelectedReward.m_CandItems[num22].m_bRandChoose);
                    this.toolStripComboBox1.Items.Add("[" + (num22 + 1).ToString() + "]" + Extensions.GetLocalization(406));
                    this.toolStripComboBox1_1.Items.Add("[" + (num22 + 1).ToString() + "]" + Extensions.GetLocalization(406));
                    if (this.SelectedReward != null && this.SelectedReward.m_ulCandItems > 0)
                    {
                        this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = 0;
                    }
                }
            }
        }
        private void remove_reward_m_AwardItems(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                if (this.SelectedReward.m_CandItems[index].m_ulAwardItems > 0 && this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex > -1)
                {
                    int rowIndex = this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    this.SelectedReward.m_CandItems[index].m_ulAwardItems--;
                    ITEM_WANTED[] destinationArray = new ITEM_WANTED[this.SelectedReward.m_CandItems[index].m_ulAwardItems];
                    Array.Copy(this.SelectedReward.m_CandItems[index].m_AwardItems, 0, destinationArray, 0, this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex);
                    Array.Copy(this.SelectedReward.m_CandItems[index].m_AwardItems, this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex, this.SelectedReward.m_CandItems[index].m_ulAwardItems - this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex);
                    this.SelectedReward.m_CandItems[index].m_AwardItems = destinationArray;
                    this.dataGridView_reward_item_m_AwardItems.Rows.RemoveAt(rowIndex);
                }
            }
        }
        private void remove_reward_m_Monsters(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulSummonedMonsters > 0 && this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulSummonedMonsters--;
                MONSTERS_SUMMONED[] destinationArray = new MONSTERS_SUMMONED[this.SelectedReward.m_ulSummonedMonsters];
                Array.Copy(this.SelectedReward.m_SummonedMonsters.m_Monsters, 0, destinationArray, 0, this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_SummonedMonsters.m_Monsters, this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex, this.SelectedReward.m_ulSummonedMonsters - this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex);
                this.SelectedReward.m_SummonedMonsters.m_Monsters = destinationArray;
                this.dataGridView_reward_m_Monsters.Rows.RemoveAt(this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_RankingAward(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulPQRankingAwardCnt > 0 && this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulPQRankingAwardCnt--;
                RANKING_AWARD[] destinationArray = new RANKING_AWARD[this.SelectedReward.m_ulPQRankingAwardCnt];
                Array.Copy(this.SelectedReward.m_PQRankingAward.m_RankingAward, 0, destinationArray, 0, this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_PQRankingAward.m_RankingAward, this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex, this.SelectedReward.m_ulPQRankingAwardCnt - this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex);
                this.SelectedReward.m_PQRankingAward.m_RankingAward = destinationArray;
                this.dataGridView_reward_m_RankingAward.Rows.RemoveAt(this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_ulChangeKey(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulChangeKeyCnt > 0 && this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulChangeKeyCnt--;
                int[] destinationArray_1 = new int[this.SelectedReward.m_ulChangeKeyCnt];
                Array.Copy(this.SelectedReward.m_plChangeKey, 0, destinationArray_1, 0, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_plChangeKey, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex + 1, destinationArray_1, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex, this.SelectedReward.m_ulChangeKeyCnt - this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
                this.SelectedReward.m_plChangeKey = destinationArray_1;
                int[] destinationArray_2 = new int[this.SelectedReward.m_ulChangeKeyCnt];
                Array.Copy(this.SelectedReward.m_plChangeKeyValue, 0, destinationArray_2, 0, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_plChangeKeyValue, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex + 1, destinationArray_2, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex, this.SelectedReward.m_ulChangeKeyCnt - this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
                this.SelectedReward.m_plChangeKeyValue = destinationArray_2;
                bool[] destinationArray_3 = new bool[this.SelectedReward.m_ulChangeKeyCnt];
                Array.Copy(this.SelectedReward.m_pbChangeType, 0, destinationArray_3, 0, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_pbChangeType, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex + 1, destinationArray_3, this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex, this.SelectedReward.m_ulChangeKeyCnt - this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
                this.SelectedReward.m_pbChangeType = destinationArray_3;
                this.dataGridView_reward_m_ulChangeKey.Rows.RemoveAt(this.dataGridView_reward_m_ulChangeKey.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_ulHistoryChange(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulHistoryChangeCnt > 0 && this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulHistoryChangeCnt--;
                int[] destinationArray_1 = new int[this.SelectedReward.m_ulHistoryChangeCnt];
                Array.Copy(this.SelectedReward.m_plHistoryChangeKey, 0, destinationArray_1, 0, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_plHistoryChangeKey, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex + 1, destinationArray_1, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex, this.SelectedReward.m_ulHistoryChangeCnt - this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
                this.SelectedReward.m_plHistoryChangeKey = destinationArray_1;
                int[] destinationArray_2 = new int[this.SelectedReward.m_ulHistoryChangeCnt];
                Array.Copy(this.SelectedReward.m_plHistoryChangeKeyValue, 0, destinationArray_2, 0, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_plHistoryChangeKeyValue, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex + 1, destinationArray_2, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex, this.SelectedReward.m_ulHistoryChangeCnt - this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
                this.SelectedReward.m_plHistoryChangeKeyValue = destinationArray_2;
                bool[] destinationArray_3 = new bool[this.SelectedReward.m_ulHistoryChangeCnt];
                Array.Copy(this.SelectedReward.m_pbHistoryChangeType, 0, destinationArray_3, 0, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_pbHistoryChangeType, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex + 1, destinationArray_3, this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex, this.SelectedReward.m_ulHistoryChangeCnt - this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
                this.SelectedReward.m_pbHistoryChangeType = destinationArray_3;
                this.dataGridView_reward_m_ulHistoryChange.Rows.RemoveAt(this.dataGridView_reward_m_ulHistoryChange.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_plDisplayKey(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulDisplayKeyCnt > 0 && this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulDisplayKeyCnt--;
                int[] destinationArray = new int[this.SelectedReward.m_ulDisplayKeyCnt];
                Array.Copy(this.SelectedReward.m_plDisplayKey, 0, destinationArray, 0, this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_plDisplayKey, this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex, this.SelectedReward.m_ulDisplayKeyCnt - this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex);
                this.SelectedReward.m_plDisplayKey = destinationArray;
                this.dataGridView_reward_m_plDisplayKey.Rows.RemoveAt(this.dataGridView_reward_m_plDisplayKey.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_pszExp(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulExpCnt > 0 && this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulExpCnt--;
                byte[][] destinationArray = new byte[this.SelectedReward.m_ulExpCnt][];
                Array.Copy(this.SelectedReward.m_pszExp, 0, destinationArray, 0, this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_pszExp, this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex, this.SelectedReward.m_ulExpCnt - this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex);
                this.SelectedReward.m_pszExp = destinationArray;
                TASK_EXPRESSION[] destinationArray2 = new TASK_EXPRESSION[this.SelectedReward.m_ulExpCnt];
                Array.Copy(this.SelectedReward.m_pExpArr, 0, destinationArray2, 0, this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_pExpArr, this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex + 1, destinationArray2, this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex, this.SelectedReward.m_ulExpCnt - this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex);
                this.SelectedReward.m_pExpArr = destinationArray2;
                this.dataGridView_reward_m_pszExp.Rows.RemoveAt(this.dataGridView_reward_m_pszExp.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_pTaskChar(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulTaskCharCnt > 0 && this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulTaskCharCnt--;
                byte[][] destinationArray = new byte[this.SelectedReward.m_ulTaskCharCnt][];
                Array.Copy(this.SelectedReward.m_pTaskChar, 0, destinationArray, 0, this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_pTaskChar, this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex, this.SelectedReward.m_ulTaskCharCnt - this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex);
                this.SelectedReward.m_pTaskChar = destinationArray;
                this.dataGridView_reward_m_pTaskChar.Rows.RemoveAt(this.dataGridView_reward_m_pTaskChar.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_pTitleAward(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && this.SelectedReward.m_ulTitleNum > 0 && this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex > -1)
            {
                this.SelectedReward.m_ulTitleNum--;
                TITLE_AWARD[] destinationArray = new TITLE_AWARD[this.SelectedReward.m_ulTitleNum];
                Array.Copy(this.SelectedReward.m_pTitleAward, 0, destinationArray, 0, this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex);
                Array.Copy(this.SelectedReward.m_pTitleAward, this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex + 1, destinationArray, this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex, this.SelectedReward.m_ulTitleNum - this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex);
                this.SelectedReward.m_pTitleAward = destinationArray;
                this.dataGridView_reward_m_pTitleAward.Rows.RemoveAt(this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex);
            }
        }
        private void remove_reward_m_AwByRatio_S(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                JMessageBox.Show(this, Extensions.GetLocalization(412));
            }
        }
        private void remove_reward_m_AwByRatio_F(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                JMessageBox.Show(this, Extensions.GetLocalization(412));
            }
        }
        private void remove_window(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int num3 = this.listBox_conversation_windows.SelectedIndex;
                if (selectedIndex > -1 && num3 > -1 && this.SelectedTask.talk_procs[selectedIndex].num_window > 0)
                {
                    this.SelectedTask.talk_procs[selectedIndex].num_window--;
                    window[] destinationArray = new window[this.SelectedTask.talk_procs[selectedIndex].num_window];
                    Array.Copy(this.SelectedTask.talk_procs[selectedIndex].windows, 0, destinationArray, 0, this.listBox_conversation_windows.SelectedIndex);
                    Array.Copy(this.SelectedTask.talk_procs[selectedIndex].windows, this.listBox_conversation_windows.SelectedIndex + 1, destinationArray, this.listBox_conversation_windows.SelectedIndex, this.SelectedTask.talk_procs[selectedIndex].num_window - this.listBox_conversation_windows.SelectedIndex);
                    this.SelectedTask.talk_procs[selectedIndex].windows = destinationArray;
                    for (int i = 0; i < this.SelectedTask.talk_procs[selectedIndex].windows.Length; i++)
                    {
                        if (i > 0)
                        {
                            this.SelectedTask.talk_procs[selectedIndex].windows[i].id_parent = this.SelectedTask.talk_procs[selectedIndex].windows[i - 1].id;
                        }
                        else
                        {
                            this.SelectedTask.talk_procs[selectedIndex].windows[i].id_parent = -1;
                        }
                    }
                    this.select_talk_proc(null, null);
                    if (this.SelectedTask.talk_procs[selectedIndex].num_window < 1)
                    {
                        this.SelectedTask.talk_procs[selectedIndex].DialogText = "";
                        this.textBox_conversation_talk_proc_text.Text = "";
                    }
                    this.listBox_conversation_talk_procs.Items[selectedIndex] = Extensions.GetLocalization(1704 + selectedIndex) + "(" + this.SelectedTask.talk_procs[selectedIndex].num_window + ")";
                    this.listBox_conversation_windows.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows.Length - 1;
                }
            }
        }
        private void remove_option(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
                int index = this.listBox_conversation_windows.SelectedIndex;
                int num3 = this.listBox_conversation_options.SelectedIndex;
                if (selectedIndex > -1 && index > -1 && num3 > -1 && this.SelectedTask.talk_procs[selectedIndex].num_window > 0)
                {
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option--;
                    option[] destinationArray = new option[this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option];
                    Array.Copy(this.SelectedTask.talk_procs[selectedIndex].windows[index].options, 0, destinationArray, 0, this.listBox_conversation_options.SelectedIndex);
                    Array.Copy(this.SelectedTask.talk_procs[selectedIndex].windows[index].options, this.listBox_conversation_options.SelectedIndex + 1, destinationArray, this.listBox_conversation_options.SelectedIndex, this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option - this.listBox_conversation_options.SelectedIndex);
                    this.SelectedTask.talk_procs[selectedIndex].windows[index].options = destinationArray;
                    this.select_window(null, null);
                    this.listBox_conversation_options.SelectedIndex = this.SelectedTask.talk_procs[selectedIndex].windows[index].options.Length - 1;
                }
            }
        }
        #endregion

        #region Select Task
        private void select_task(object sender, TreeViewEventArgs e)
        {
            if (LockedSelecting == false)
            {
                this.comboBox_m_iPremForce.Items.Clear();
                this.comboBox_m_iPremForce.Items.Add(0 + "_NO");
                this.comboBox_m_iPremForce.Items.Add(-1 + "_ALL");
                this.comboBox_m_iPremForce.Items.Add(1004 + "_Corona");
                this.comboBox_m_iPremForce.Items.Add(1005 + "_Shroud");
                this.comboBox_m_iPremForce.Items.Add(1006 + "_Luminance");

                if (TaskEditor.eLC != null)
                {
                    foreach (ItemDupe data in TaskEditor.eLC.FORCES.Values)
                    {
                        if(data.itemId != 1004 && data.itemId != 1005 && data.itemId != 1006)
                         this.comboBox_m_iPremForce.Items.Add(data.itemId + "_" + data.name);
                    }
                }
                Selecting = true;
                ArrayList list = new ArrayList();
                //TreeNode selectedNode = ((TreeView)sender).SelectedNode;
                TreeNode selectedNode = this.treeView_tasks.SelectedNode;

                while (selectedNode.Parent != null)
                {
                    list.Add(selectedNode.Index);
                    selectedNode = selectedNode.Parent;
                }
                this.SelectedTask = this.Tasks[selectedNode.Index];
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        this.SelectedTask = this.SelectedTask.sub_quests[(int)list[i]];
                    }
                    catch { }
                }
                this.textBox_m_ID.Text = this.SelectedTask.ID.ToString();
                string name = this.SelectedTask.Name;
                this.textBox_m_szName.Text = name;

                if (name.StartsWith("^"))
                {
                    Color col = Color.FromArgb(17, 17, 17);
                    try
                    {
                        col = Color.FromArgb(int.Parse(name.Substring(1, 6), NumberStyles.HexNumber));
                    }
                    catch
                    {
                    }
   

                    Bitmap bmp = new Bitmap(pictureBox_Color.Width, pictureBox_Color.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.FillRectangle(new SolidBrush(col), new Rectangle(Point.Empty, bmp.Size));
                    }

                    pictureBox_Color.BackgroundImage = bmp;
                }
    

                this.checkBox_m_bHasSign.Checked = this.SelectedTask.m_bHasSign;
                this.textBox_m_pszSignature.Text = this.SelectedTask.AuthorText;
                int type = this.SelectedTask.m_ulType;
                switch (type)
                {
                    case 0:
                        this.comboBox_m_ulType.SelectedIndex = 0;
                        break;
                    case 1:
                        this.comboBox_m_ulType.SelectedIndex = 1;
                        break;
                    case 2:
                        this.comboBox_m_ulType.SelectedIndex = 2;
                        break;
                    case 3:
                        this.comboBox_m_ulType.SelectedIndex = 3;
                        break;
                    case 4:
                        this.comboBox_m_ulType.SelectedIndex = 4;
                        break;
                    case 5:
                        this.comboBox_m_ulType.SelectedIndex = 5;
                        break;
                    case 6:
                        this.comboBox_m_ulType.SelectedIndex = 6;
                        break;
                    case 7:
                        this.comboBox_m_ulType.SelectedIndex = 7;
                        break;
                    case 8:
                        this.comboBox_m_ulType.SelectedIndex = 8;
                        break;
                    case 9:
                        this.comboBox_m_ulType.SelectedIndex = 9;
                        break;
                    case 10:
                        this.comboBox_m_ulType.SelectedIndex = 10;
                        break;
                    case 11:
                        this.comboBox_m_ulType.SelectedIndex = 11;
                        break;
                    case 12:
                        this.comboBox_m_ulType.SelectedIndex = 12;
                        break;
                    default:
                        switch (type)
                        {
                            case 100:
                                this.comboBox_m_ulType.SelectedIndex = 13;
                                break;
                            case 101:
                                this.comboBox_m_ulType.SelectedIndex = 14;
                                break;
                            case 102:
                                this.comboBox_m_ulType.SelectedIndex = 15;
                                break;
                            case 103:
                                this.comboBox_m_ulType.SelectedIndex = 16;
                                break;
                            case 104:
                                this.comboBox_m_ulType.SelectedIndex = 17;
                                break;
                            case 105:
                                this.comboBox_m_ulType.SelectedIndex = 18;
                                break;
                            case 106:
                                this.comboBox_m_ulType.SelectedIndex = 19;
                                break;
                            case 107:
                                this.comboBox_m_ulType.SelectedIndex = 20;
                                break;
                            case 108:
                                this.comboBox_m_ulType.SelectedIndex = 21;
                                break;
                            case 109:
                                this.comboBox_m_ulType.SelectedIndex = 22;
                                break;
                            case 110:
                                this.comboBox_m_ulType.SelectedIndex = 23;
                                break;
                        }
                        break;
                }
                this.textBox_m_ulTimeLimit.Text = Extensions.SecondsToString(this.SelectedTask.m_ulTimeLimit);
                this.checkBox_m_bOfflineFail.Checked = this.SelectedTask.m_bOfflineFail;
                this.checkBox_m_bAbsFail.Checked = this.SelectedTask.m_bAbsFail;
                this.dataGridView_m_tmAbsFailTime.Rows.Clear();
                for (int num24 = 0; num24 < 1; num24++)
                {
                    try
                    {
                        string[] strArray13 = new string[]
                    {
                        this.SelectedTask.m_tmAbsFailTime.year.ToString(),
                        this.SelectedTask.m_tmAbsFailTime.month.ToString(),
                        this.SelectedTask.m_tmAbsFailTime.day.ToString(),
                        this.SelectedTask.m_tmAbsFailTime.hour.ToString(),
                        this.SelectedTask.m_tmAbsFailTime.min.ToString(),
                        this.Column_m_tmAbsFailTime_wday.Items[this.SelectedTask.m_tmAbsFailTime.wday].ToString()
                    };
                        this.dataGridView_m_tmAbsFailTime.Rows.Add(strArray13);
                        goto IL_1B1;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(425));
                        goto IL_1B1;
                    }
                    IL_1B1:;
                }
                this.checkBox_m_bItemNotTakeOff.Checked = this.SelectedTask.m_bItemNotTakeOff;
                this.checkBox_m_bAbsTime.Checked = this.SelectedTask.m_bAbsTime;
                this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows.Clear();
                for (int index = 0; index < this.SelectedTask.m_tmStart.Length; index++)
                {
                    try
                    {
                        string[] values = new string[]
                    {
                        this.Column416.Items[this.SelectedTask.m_tmType[index]].ToString(),
                        this.SelectedTask.m_tmStart[index].year.ToString(),
                        this.SelectedTask.m_tmStart[index].month.ToString(),
                        this.SelectedTask.m_tmStart[index].day.ToString(),
                        this.SelectedTask.m_tmStart[index].hour.ToString(),
                        this.SelectedTask.m_tmStart[index].min.ToString(),
                        this.Column6.Items[this.SelectedTask.m_tmStart[index].wday].ToString(),
                        "=>",
                        this.SelectedTask.m_tmEnd[index].year.ToString(),
                        this.SelectedTask.m_tmEnd[index].month.ToString(),
                        this.SelectedTask.m_tmEnd[index].day.ToString(),
                        this.SelectedTask.m_tmEnd[index].hour.ToString(),
                        this.SelectedTask.m_tmEnd[index].min.ToString(),
                        this.Column13.Items[this.SelectedTask.m_tmEnd[index].wday].ToString()
                    };
                        this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows.Add(values);
                        goto IL_2DB;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(426));
                        goto IL_2DB;
                    }
                    IL_2DB:;
                }
                this.comboBox_m_lAvailFrequency.SelectedIndex = this.SelectedTask.m_lAvailFrequency;
                this.textBox_m_lPeriodLimit.Text = this.SelectedTask.m_lPeriodLimit.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bChooseOne.Checked = this.SelectedTask.m_bChooseOne;
                this.checkBox_m_bRandOne.Checked = this.SelectedTask.m_bRandOne;
                this.checkBox_m_bExeChildInOrder.Checked = this.SelectedTask.m_bExeChildInOrder;
                this.checkBox_m_bParentAlsoFail.Checked = this.SelectedTask.m_bParentAlsoFail;
                this.checkBox_m_bParentAlsoSucc.Checked = this.SelectedTask.m_bParentAlsoSucc;
                this.checkBox_m_bCanGiveUp.Checked = this.SelectedTask.m_bCanGiveUp;
                this.checkBox_m_bCanRedo.Checked = this.SelectedTask.m_bCanRedo;
                this.checkBox_m_bCanRedoAfterFailure.Checked = this.SelectedTask.m_bCanRedoAfterFailure;
                this.checkBox_m_bClearAsGiveUp.Checked = this.SelectedTask.m_bClearAsGiveUp;
                this.checkBox_m_bNeedRecord.Checked = this.SelectedTask.m_bNeedRecord;
                this.checkBox_m_bFailAsPlayerDie.Checked = this.SelectedTask.m_bFailAsPlayerDie;
                this.textBox_m_ulMaxReceiver.Text = this.SelectedTask.m_ulMaxReceiver.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bDelvInZone.Checked = this.SelectedTask.m_bDelvInZone;
                this.textBox_m_ulDelvWorld.Text = this.SelectedTask.m_ulDelvWorld.ToString();
                this.ShowInstanceName_m_ulDelvWorld();
                this.dataGridView_m_pDelvRegion.Rows.Clear();
                for (int num25 = 0; num25 < this.SelectedTask.m_pDelvRegion.Length; num25++)
                {
                    try
                    {
                        string[] strArray14 = new string[]
                    {
                        this.SelectedTask.m_pDelvRegion[num25].zvMin_x.ToString("F3"),
                        this.SelectedTask.m_pDelvRegion[num25].zvMin_y.ToString("F3"),
                        this.SelectedTask.m_pDelvRegion[num25].zvMin_z.ToString("F3"),
                        this.SelectedTask.m_pDelvRegion[num25].zvMax_x.ToString("F3"),
                        this.SelectedTask.m_pDelvRegion[num25].zvMax_y.ToString("F3"),
                        this.SelectedTask.m_pDelvRegion[num25].zvMax_z.ToString("F3")
                    };
                        this.dataGridView_m_pDelvRegion.Rows.Add(strArray14);
                        goto IL_701;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(427));
                        goto IL_701;
                    }
                    IL_701:;
                }
                this.checkBox_m_bEnterRegionFail.Checked = this.SelectedTask.m_bEnterRegionFail;
                this.textBox_m_ulEnterRegionWorld.Text = this.SelectedTask.m_ulEnterRegionWorld.ToString();
                this.ShowInstanceName_m_ulEnterRegionWorld();
                this.dataGridView_m_pEnterRegion.Rows.Clear();
                for (int num26 = 0; num26 < this.SelectedTask.m_pEnterRegion.Length; num26++)
                {
                    try
                    {
                        string[] strArray15 = new string[]
                    {
                        this.SelectedTask.m_pEnterRegion[num26].zvMin_x.ToString("F3"),
                        this.SelectedTask.m_pEnterRegion[num26].zvMin_y.ToString("F3"),
                        this.SelectedTask.m_pEnterRegion[num26].zvMin_z.ToString("F3"),
                        this.SelectedTask.m_pEnterRegion[num26].zvMax_x.ToString("F3"),
                        this.SelectedTask.m_pEnterRegion[num26].zvMax_y.ToString("F3"),
                        this.SelectedTask.m_pEnterRegion[num26].zvMax_z.ToString("F3")
                    };
                        this.dataGridView_m_pEnterRegion.Rows.Add(strArray15);
                        goto IL_8A9;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(428));
                        goto IL_8A9;
                    }
                    IL_8A9:;
                }
                this.checkBox_m_bLeaveRegionFail.Checked = this.SelectedTask.m_bLeaveRegionFail;
                this.textBox_m_ulLeaveRegionWorld.Text = this.SelectedTask.m_ulLeaveRegionWorld.ToString();
                this.ShowInstanceName_m_ulLeaveRegionWorld();
                this.dataGridView_m_pLeaveRegion.Rows.Clear();
                for (int num27 = 0; num27 < this.SelectedTask.m_pLeaveRegion.Length; num27++)
                {
                    try
                    {
                        string[] strArray16 = new string[]
                    {
                        this.SelectedTask.m_pLeaveRegion[num27].zvMin_x.ToString("F3"),
                        this.SelectedTask.m_pLeaveRegion[num27].zvMin_y.ToString("F3"),
                        this.SelectedTask.m_pLeaveRegion[num27].zvMin_z.ToString("F3"),
                        this.SelectedTask.m_pLeaveRegion[num27].zvMax_x.ToString("F3"),
                        this.SelectedTask.m_pLeaveRegion[num27].zvMax_y.ToString("F3"),
                        this.SelectedTask.m_pLeaveRegion[num27].zvMax_z.ToString("F3")
                    };
                        this.dataGridView_m_pLeaveRegion.Rows.Add(strArray16);
                        goto IL_A51;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(429));
                        goto IL_A51;
                    }
                    IL_A51:;
                }
                this.checkBox_m_bLeaveForceFail.Checked = this.SelectedTask.m_bLeaveForceFail;
                this.checkBox_m_bTransTo.Checked = this.SelectedTask.m_bTransTo;
                this.textBox_m_ulTransWldId.Text = this.SelectedTask.m_ulTransWldId.ToString();
                this.ShowInstanceName_m_ulTransWldId();
                this.textBox_m_TransPt_x.Text = this.SelectedTask.m_TransPt.x.ToString("F3");
                this.textBox_m_TransPt_y.Text = this.SelectedTask.m_TransPt.y.ToString("F3");
                this.textBox_m_TransPt_z.Text = this.SelectedTask.m_TransPt.z.ToString("F3");
                this.Convert_m_TransPt();
                this.textBox_m_lMonsCtrl.Text = this.SelectedTask.m_lMonsCtrl.ToString();
                this.checkBox_m_bTrigCtrl.Checked = this.SelectedTask.m_bTrigCtrl;
                this.checkBox_m_bAutoDeliver.Checked = this.SelectedTask.m_bAutoDeliver;
                this.checkBox_m_bDisplayInExclusiveUI.Checked = this.SelectedTask.m_bDisplayInExclusiveUI;
                this.checkBox_m_bReadyToNotifyServer.Checked = this.SelectedTask.m_bReadyToNotifyServer;
                this.checkBox_m_bUsedInTokenShop.Checked = this.SelectedTask.m_bUsedInTokenShop;
                this.checkBox_m_bDeathTrig.Checked = this.SelectedTask.m_bDeathTrig;
                this.checkBox_m_bClearAcquired.Checked = this.SelectedTask.m_bClearAcquired;
                this.numericUpDown_m_ulSuitableLevel.Text = this.SelectedTask.m_ulSuitableLevel.ToString();
                this.checkBox_m_bShowPrompt.Checked = this.SelectedTask.m_bShowPrompt;
                this.checkBox_m_bKeyTask.Checked = this.SelectedTask.m_bKeyTask;
                this.textBox_m_ulDelvNPC.Text = this.SelectedTask.m_ulDelvNPC.ToString();
                this.ShowNPCName_m_ulDelvNPC();
                this.textBox_m_ulAwardNPC.Text = this.SelectedTask.m_ulAwardNPC.ToString();
                this.ShowNPCName_m_ulAwardNPC();
                this.checkBox_m_bSkillTask.Checked = this.SelectedTask.m_bSkillTask;
                this.checkBox_m_bCanSeekOut.Checked = this.SelectedTask.m_bCanSeekOut;
                this.checkBox_m_bShowDirection.Checked = this.SelectedTask.m_bShowDirection;
                this.checkBox_m_bMarriage.Checked = this.SelectedTask.m_bMarriage;
                this.dataGridView_m_ulChangeKey.Rows.Clear();
                for (int num36 = 0; num36 < this.SelectedTask.m_plChangeKey.Length; num36++)
                {
                    try
                    {
                        string[] strArray25 = new string[]
                    {
                        this.SelectedTask.m_plChangeKey[num36].ToString(),
                        this.SelectedTask.m_plChangeKeyValue[num36].ToString(),
                        this.dataGridViewTextBoxColumn69.Items[Convert.ToInt32(this.SelectedTask.m_pbChangeType[num36])].ToString()
                    };
                        this.dataGridView_m_ulChangeKey.Rows.Add(strArray25);
                        goto IL_28B0;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(430));
                        goto IL_28B0;
                    }
                    IL_28B0:;
                }
                this.checkBox_m_bSwitchSceneFail.Checked = this.SelectedTask.m_bSwitchSceneFail;
                this.checkBox_m_bHidden.Checked = this.SelectedTask.m_bHidden;
                this.checkBox_m_bDeliverySkill.Checked = this.SelectedTask.m_bDeliverySkill;
                this.textBox_m_iDeliveredSkillID.Text = this.SelectedTask.m_iDeliveredSkillID.ToString();
                this.ShowSkillText_m_iDeliveredSkillID();
                this.numericUpDown_m_iDeliveredSkillLevel.Text = this.SelectedTask.m_iDeliveredSkillLevel.ToString();
                this.checkBox_m_bShowGfxFinished.Checked = this.SelectedTask.m_bShowGfxFinished;
                this.checkBox_m_bChangePQRanking.Checked = this.SelectedTask.m_bChangePQRanking;
                this.checkBox_m_bCompareItemAndInventory.Checked = this.SelectedTask.m_bCompareItemAndInventory;
                this.textBox_m_ulInventorySlotNum.Text = this.SelectedTask.m_ulInventorySlotNum.ToString();
                this.checkBox_TowerTask.Checked = this.SelectedTask.TowerTask;
                this.checkBox_HomeTask.Checked = this.SelectedTask.HomeTask;
                this.checkBox_DelilverInHostHome.Checked = this.SelectedTask.DelilverInHostHome;
                this.checkBox_FinishInHostHome.Checked = this.SelectedTask.FinishInHostHome;
                this.checkBox_m_bPQTask.Checked = this.SelectedTask.m_bPQTask;
                this.dataGridView_m_pszPQExp.Rows.Clear();
                for (int num37 = 0; num37 < this.SelectedTask.m_pPQExpArr.Length; num37++)
                {
                    try
                    {
                        string[] strArray26 = new string[129];
                        strArray26[0] = Extensions.ByteArray_to_GbkString(this.SelectedTask.m_pszPQExp[num37]);
                        for (int i = 0; i < 64; i++)
                        {
                            strArray26[(i * 2) + 1] = this.SelectedTask.m_pPQExpArr[num37].type[i].ToString();
                            strArray26[(i * 2) + 2] = this.SelectedTask.m_pPQExpArr[num37].value[i].ToString();
                        }
                        this.dataGridView_m_pszPQExp.Rows.Add(strArray26);
                        goto IL_29DC;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(431));
                        goto IL_29DC;
                    }
                    IL_29DC:;
                }
                this.checkBox_m_bPQSubTask.Checked = this.SelectedTask.m_bPQSubTask;
                this.checkBox_m_bClearContrib.Checked = this.SelectedTask.m_bClearContrib;
                this.dataGridView_m_MonstersContrib.Rows.Clear();
                for (int num38 = 0; num38 < this.SelectedTask.m_MonstersContrib.Length; num38++)
                {
                    try
                    {
                        string[] strArray27 = new string[]
                    {
                        this.SelectedTask.m_MonstersContrib[num38].m_ulMonsterTemplId.ToString(),
                        Extensions.MonsterNPCMineName(this.SelectedTask.m_MonstersContrib[num38].m_ulMonsterTemplId),
                        this.SelectedTask.m_MonstersContrib[num38].m_iWholeContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
                        this.SelectedTask.m_MonstersContrib[num38].m_iShareContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
                        this.SelectedTask.m_MonstersContrib[num38].m_iPersonalWholeContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"))
                    };
                        this.dataGridView_m_MonstersContrib.Rows.Add(strArray27);
                        goto IL_2B66;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(432));
                        goto IL_2B66;
                    }
                    IL_2B66:;
                }
                this.textBox_m_iPremNeedRecordTasksNum.Text = this.SelectedTask.m_iPremNeedRecordTasksNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByNeedRecordTasksNum.Checked = this.SelectedTask.m_bShowByNeedRecordTasksNum;
                this.textBox_m_iPremiseFactionContrib.Text = this.SelectedTask.m_iPremiseFactionContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByFactionContrib.Checked = this.SelectedTask.m_bShowByFactionContrib;
                this.checkBox_m_bAccountTaskLimit.Checked = this.SelectedTask.m_bAccountTaskLimit;
                this.checkBox_m_bRoleTaskLimit.Checked = this.SelectedTask.m_bRoleTaskLimit;
                this.textBox_m_ulAccountTaskLimitCnt.Text = this.SelectedTask.m_ulAccountTaskLimitCnt.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bLeaveFactionFail.Checked = this.SelectedTask.m_bLeaveFactionFail;
                this.checkBox_m_bNotIncCntWhenFailed.Checked = this.SelectedTask.m_bNotIncCntWhenFailed;
                this.checkBox_m_bNotClearItemWhenFailed.Checked = this.SelectedTask.m_bNotClearItemWhenFailed;
                this.checkBox_m_bDisplayInTitleTaskUI.Checked = this.SelectedTask.m_bDisplayInTitleTaskUI;
                this.textBox_m_ucPremiseTransformedForm.Text = this.SelectedTask.m_ucPremiseTransformedForm.ToString();
                this.checkBox_m_bShowByTransformed.Checked = this.SelectedTask.m_bShowByTransformed;
                this.numericUpDown_m_ulPremise_Lev_Min.Text = this.SelectedTask.m_ulPremise_Lev_Min.ToString();
                this.numericUpDown_m_ulPremise_Lev_Max.Text = this.SelectedTask.m_ulPremise_Lev_Max.ToString();
                try
                {
                    this.comboBox_m_bPremCheckMaxHistoryLevel.SelectedIndex = this.SelectedTask.m_bPremCheckMaxHistoryLevel;
                }
                catch (Exception) { }
                this.checkBox_m_bShowByLev.Checked = this.SelectedTask.m_bShowByLev;
                this.checkBox_m_bPremCheckReincarnation.Checked = this.SelectedTask.m_bPremCheckReincarnation;
                this.numericUpDown_m_ulPremReincarnationMin.Text = this.SelectedTask.m_ulPremReincarnationMin.ToString();
                this.numericUpDown_m_ulPremReincarnationMax.Text = this.SelectedTask.m_ulPremReincarnationMax.ToString();
                this.checkBox_m_bShowByReincarnation.Checked = this.SelectedTask.m_bShowByReincarnation;
                this.checkBox_m_bPremCheckRealmLevel.Checked = this.SelectedTask.m_bPremCheckRealmLevel;
                this.numericUpDown_m_ulPremRealmLevelMin.Text = this.SelectedTask.m_ulPremRealmLevelMin.ToString();
                this.numericUpDown_m_ulPremRealmLevelMax.Text = this.SelectedTask.m_ulPremRealmLevelMax.ToString();
                this.checkBox_m_bPremCheckRealmExpFull.Checked = this.SelectedTask.m_bPremCheckRealmExpFull;
                this.checkBox_m_bShowByRealmLevel.Checked = this.SelectedTask.m_bShowByRealmLevel;
                this.dataGridView_m_PremItems.Rows.Clear();
                for (int num28 = 0; num28 < this.SelectedTask.m_PremItems.Length; num28++)
                {
                    try
                    {
                        string[] strArray17 = new string[]
                    {
                        this.SelectedTask.m_PremItems[num28].m_ulItemTemplId.ToString(),
                        Extensions.ItemName(this.SelectedTask.m_PremItems[num28].m_ulItemTemplId),
                        this.SelectedTask.m_PremItems[num28].m_bCommonItem.ToString(),
                        this.SelectedTask.m_PremItems[num28].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
                        this.SelectedTask.m_PremItems[num28].m_fProb.ToString(ProbValueFormat),
                        Extensions.SecondsToString(this.SelectedTask.m_PremItems[num28].m_lPeriod)
                    };
                        this.dataGridView_m_PremItems.Rows.Add(strArray17);
                        goto IL_F81;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(433));
                        goto IL_F81;
                    }
                    IL_F81:;
                }
                this.checkBox_m_bShowByItems.Checked = this.SelectedTask.m_bShowByItems;
                this.checkBox_m_bPremItemsAnyOne.Checked = this.SelectedTask.m_bPremItemsAnyOne;
                this.textBox_m_ulGivenCmnCount.Text = this.SelectedTask.m_ulGivenCmnCount.ToString();
                this.textBox_m_ulGivenTskCount.Text = this.SelectedTask.m_ulGivenTskCount.ToString();
                this.dataGridView_m_GivenItems.Rows.Clear();
                for (int num29 = 0; num29 < this.SelectedTask.m_GivenItems.Length; num29++)
                {
                    try
                    {
                        string[] strArray18 = new string[]
                    {
                        this.SelectedTask.m_GivenItems[num29].m_ulItemTemplId.ToString(),
                        Extensions.ItemName(this.SelectedTask.m_GivenItems[num29].m_ulItemTemplId),
                        this.SelectedTask.m_GivenItems[num29].m_bCommonItem.ToString(),
                        this.SelectedTask.m_GivenItems[num29].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
                        this.SelectedTask.m_GivenItems[num29].m_fProb.ToString(ProbValueFormat),
                        Extensions.SecondsToString(this.SelectedTask.m_GivenItems[num29].m_lPeriod)
                    };
                        this.dataGridView_m_GivenItems.Rows.Add(strArray18);
                        goto IL_10BD;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(434));
                        goto IL_10BD;
                    }
                    IL_10BD:;
                }
                this.textBox_m_ulPremise_Deposit.Text = this.SelectedTask.m_ulPremise_Deposit.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByDeposit.Checked = this.SelectedTask.m_bShowByDeposit;
                this.textBox_m_lPremise_Reputation.Text = this.SelectedTask.m_lPremise_Reputation.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.textBox_m_lPremise_RepuMax.Text = this.SelectedTask.m_lPremise_RepuMax.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByRepu.Checked = this.SelectedTask.m_bShowByRepu;
                this.textBox_m_ulPremise_Tasks_1.Text = this.SelectedTask.m_ulPremise_Tasks[0].ToString();
                this.textBox_m_ulPremise_Tasks_2.Text = this.SelectedTask.m_ulPremise_Tasks[1].ToString();
                this.textBox_m_ulPremise_Tasks_3.Text = this.SelectedTask.m_ulPremise_Tasks[2].ToString();
                this.textBox_m_ulPremise_Tasks_4.Text = this.SelectedTask.m_ulPremise_Tasks[3].ToString();
                this.textBox_m_ulPremise_Tasks_5.Text = this.SelectedTask.m_ulPremise_Tasks[4].ToString();
                this.textBox_m_ulPremise_Tasks_6.Text = this.SelectedTask.m_ulPremise_Tasks[5].ToString();
                this.textBox_m_ulPremise_Tasks_7.Text = this.SelectedTask.m_ulPremise_Tasks[6].ToString();
                this.textBox_m_ulPremise_Tasks_8.Text = this.SelectedTask.m_ulPremise_Tasks[7].ToString();
                this.textBox_m_ulPremise_Tasks_9.Text = this.SelectedTask.m_ulPremise_Tasks[8].ToString();
                this.textBox_m_ulPremise_Tasks_10.Text = this.SelectedTask.m_ulPremise_Tasks[9].ToString();
                this.textBox_m_ulPremise_Tasks_11.Text = this.SelectedTask.m_ulPremise_Tasks[10].ToString();
                this.textBox_m_ulPremise_Tasks_12.Text = this.SelectedTask.m_ulPremise_Tasks[11].ToString();
                this.textBox_m_ulPremise_Tasks_13.Text = this.SelectedTask.m_ulPremise_Tasks[12].ToString();
                this.textBox_m_ulPremise_Tasks_14.Text = this.SelectedTask.m_ulPremise_Tasks[13].ToString();
                this.textBox_m_ulPremise_Tasks_15.Text = this.SelectedTask.m_ulPremise_Tasks[14].ToString();
                this.textBox_m_ulPremise_Tasks_16.Text = this.SelectedTask.m_ulPremise_Tasks[15].ToString();
                this.textBox_m_ulPremise_Tasks_17.Text = this.SelectedTask.m_ulPremise_Tasks[16].ToString();
                this.textBox_m_ulPremise_Tasks_18.Text = this.SelectedTask.m_ulPremise_Tasks[17].ToString();
                this.textBox_m_ulPremise_Tasks_19.Text = this.SelectedTask.m_ulPremise_Tasks[18].ToString();
                this.textBox_m_ulPremise_Tasks_20.Text = this.SelectedTask.m_ulPremise_Tasks[19].ToString();
                this.checkBox_m_bShowByPreTask.Checked = this.SelectedTask.m_bShowByPreTask;
                this.textBox_m_ulPremise_Task_Least_Num.Text = this.SelectedTask.m_ulPremise_Task_Least_Num.ToString();
                int m_ulPremise_Period = this.SelectedTask.m_ulPremise_Period;
                switch (m_ulPremise_Period)
                {
                    case 0:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 0;
                        break;
                    case 1:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 1;
                        break;
                    case 2:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 2;
                        break;
                    case 3:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 3;
                        break;
                    case 4:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 4;
                        break;
                    case 5:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 5;
                        break;
                    case 6:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 6;
                        break;
                    case 7:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 7;
                        break;
                    case 8:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 8;
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        break;
                    case 20:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 9;
                        break;
                    case 21:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 11;
                        break;
                    case 22:
                        this.comboBox_m_ulPremise_Period.SelectedIndex = 13;
                        break;
                    default:
                        switch (m_ulPremise_Period)
                        {
                            case 30:
                                this.comboBox_m_ulPremise_Period.SelectedIndex = 10;
                                break;
                            case 31:
                                this.comboBox_m_ulPremise_Period.SelectedIndex = 12;
                                break;
                            case 32:
                                this.comboBox_m_ulPremise_Period.SelectedIndex = 14;
                                break;
                        }
                        break;
                }
                this.checkBox_m_bShowByPeriod.Checked = this.SelectedTask.m_bShowByPeriod;
                this.comboBox_m_ulPremise_Faction.SelectedIndex = this.SelectedTask.m_ulPremise_Faction;
                this.comboBox_m_iPremise_FactionRole.SelectedIndex = this.SelectedTask.m_iPremise_FactionRole;
                this.checkBox_m_bShowByFaction.Checked = this.SelectedTask.m_bShowByFaction;
                this.comboBox_m_ulGender.SelectedIndex = this.SelectedTask.m_ulGender;
                this.checkBox_m_bShowByGender.Checked = this.SelectedTask.m_bShowByGender;
                this.checkBox_m_Occupations_0.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_1.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_2.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_3.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_4.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_5.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_6.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_7.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_8.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_9.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_10.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_11.CheckedChanged -= new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_0.Checked = false;
                this.checkBox_m_Occupations_1.Checked = false;
                this.checkBox_m_Occupations_2.Checked = false;
                this.checkBox_m_Occupations_3.Checked = false;
                this.checkBox_m_Occupations_4.Checked = false;
                this.checkBox_m_Occupations_5.Checked = false;
                this.checkBox_m_Occupations_6.Checked = false;
                this.checkBox_m_Occupations_7.Checked = false;
                this.checkBox_m_Occupations_8.Checked = false;
                this.checkBox_m_Occupations_9.Checked = false;
                this.checkBox_m_Occupations_10.Checked = false;
                this.checkBox_m_Occupations_11.Checked = false;
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 0) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 0) > -1)
                {
                    this.checkBox_m_Occupations_0.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 1) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 1) > -1)
                {
                    this.checkBox_m_Occupations_1.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 2) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 2) > -1)
                {
                    this.checkBox_m_Occupations_2.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 3) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 3) > -1)
                {
                    this.checkBox_m_Occupations_3.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 4) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 4) > -1)
                {
                    this.checkBox_m_Occupations_4.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 5) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 5) > -1)
                {
                    this.checkBox_m_Occupations_5.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 6) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 6) > -1)
                {
                    this.checkBox_m_Occupations_6.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 7) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 7) > -1)
                {
                    this.checkBox_m_Occupations_7.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 8) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 8) > -1)
                {
                    this.checkBox_m_Occupations_8.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 9) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 9) > -1)
                {
                    this.checkBox_m_Occupations_9.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 10) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 10) > -1)
                {
                    this.checkBox_m_Occupations_10.Checked = true;
                }
                if (Array.IndexOf<int>(this.SelectedTask.m_Occupations, 11) < this.SelectedTask.m_ulOccupations && Array.IndexOf<int>(this.SelectedTask.m_Occupations, 11) > -1)
                {
                    this.checkBox_m_Occupations_11.Checked = true;
                }
                this.checkBox_m_Occupations_0.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_1.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_2.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_3.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_4.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_5.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_6.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_7.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_8.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_9.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_10.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_Occupations_11.CheckedChanged += new EventHandler(this.change_m_Occupations);
                this.checkBox_m_bShowByOccup.Checked = this.SelectedTask.m_bShowByOccup;
                this.checkBox_m_bPremise_Spouse.Checked = this.SelectedTask.m_bPremise_Spouse;
                this.checkBox_m_bShowBySpouse.Checked = this.SelectedTask.m_bShowBySpouse;
                this.checkBox_m_bPremiseWeddingOwner.Checked = this.SelectedTask.m_bPremiseWeddingOwner;
                this.checkBox_m_bShowByWeddingOwner.Checked = this.SelectedTask.m_bShowByWeddingOwner;
                this.checkBox_m_bGM.Checked = this.SelectedTask.m_bGM;
                this.change_ColorAndIcon();
                this.checkBox_m_bShieldUser.Checked = this.SelectedTask.m_bShieldUser;
                this.checkBox_m_bShowByRMB.Checked = this.SelectedTask.m_bShowByRMB;
                this.textBox_m_ulPremRMBMin.Text = this.SelectedTask.m_ulPremRMBMin.ToString();
                this.textBox_m_ulPremRMBMax.Text = this.SelectedTask.m_ulPremRMBMax.ToString();
                this.checkBox_m_bCharTime.Checked = this.SelectedTask.m_bCharTime;
                this.checkBox_m_bShowByCharTime.Checked = this.SelectedTask.m_bShowByCharTime;
                this.textBox_m_iCharStartTime.Text = this.SelectedTask.m_iCharStartTime.ToString();
                this.textBox_m_iCharEndTime.Text = this.SelectedTask.m_iCharEndTime.ToString();
                this.dataGridView_m_tmCharEndTime.Rows.Clear();
                for (int num30 = 0; num30 < 1; num30++)
                {
                    try
                    {
                        string[] strArray19 = new string[]
                    {
                        this.SelectedTask.m_tmCharEndTime.year.ToString(),
                        this.SelectedTask.m_tmCharEndTime.month.ToString(),
                        this.SelectedTask.m_tmCharEndTime.day.ToString(),
                        this.SelectedTask.m_tmCharEndTime.hour.ToString(),
                        this.SelectedTask.m_tmCharEndTime.min.ToString(),
                        this.Column_m_tmCharEndTime_wday.Items[this.SelectedTask.m_tmCharEndTime.wday].ToString()
                    };
                        this.dataGridView_m_tmCharEndTime.Rows.Add(strArray19);
                        goto IL_1BE8;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(435));
                        goto IL_1BE8;
                    }
                    IL_1BE8:;
                }
                this.textBox_m_ulCharTimeGreaterThan.Text = this.SelectedTask.m_ulCharTimeGreaterThan.ToString();
                this.textBox_m_ulPremise_Cotask.Text = this.SelectedTask.m_ulPremise_Cotask.ToString();
                this.textBox_m_ulCoTaskCond.Text = this.SelectedTask.m_ulCoTaskCond.ToString();
                this.textBox_m_ulMutexTasks_1.Text = this.SelectedTask.m_ulMutexTasks[0].ToString();
                this.textBox_m_ulMutexTasks_2.Text = this.SelectedTask.m_ulMutexTasks[1].ToString();
                this.textBox_m_ulMutexTasks_3.Text = this.SelectedTask.m_ulMutexTasks[2].ToString();
                this.textBox_m_ulMutexTasks_4.Text = this.SelectedTask.m_ulMutexTasks[3].ToString();
                this.textBox_m_ulMutexTasks_5.Text = this.SelectedTask.m_ulMutexTasks[4].ToString();
                this.numericUpDown_m_lSkillLev_blacksmith.Text = this.SelectedTask.m_lSkillLev[0].ToString();
                this.numericUpDown_m_lSkillLev_tailor.Text = this.SelectedTask.m_lSkillLev[1].ToString();
                this.numericUpDown_m_lSkillLev_craftsman.Text = this.SelectedTask.m_lSkillLev[2].ToString();
                this.numericUpDown_m_lSkillLev_apothecary.Text = this.SelectedTask.m_lSkillLev[3].ToString();
                this.comboBox_m_DynTaskType.SelectedIndex = this.SelectedTask.m_DynTaskType;
                this.textBox_m_ulSpecialAward.Text = this.SelectedTask.m_ulSpecialAward.ToString();
                this.checkBox_m_bTeamwork.Checked = this.SelectedTask.m_bTeamwork;
                this.checkBox_m_bRcvByTeam.Checked = this.SelectedTask.m_bRcvByTeam;
                this.checkBox_m_bSharedTask.Checked = this.SelectedTask.m_bSharedTask;
                this.checkBox_m_bSharedAchieved.Checked = this.SelectedTask.m_bSharedAchieved;
                this.checkBox_m_bCheckTeammate.Checked = this.SelectedTask.m_bCheckTeammate;
                this.textBox_m_fTeammateDist.Text = this.SelectedTask.m_fTeammateDist.ToString("F3");
                this.checkBox_m_bAllFail.Checked = this.SelectedTask.m_bAllFail;
                this.checkBox_m_bCapFail.Checked = this.SelectedTask.m_bCapFail;
                this.checkBox_m_bCapSucc.Checked = this.SelectedTask.m_bCapSucc;
                this.textBox_m_fSuccDist.Text = this.SelectedTask.m_fSuccDist.ToString("F3");
                this.checkBox_m_bDismAsSelfFail.Checked = this.SelectedTask.m_bDismAsSelfFail;
                this.checkBox_m_bRcvChckMem.Checked = this.SelectedTask.m_bRcvChckMem;
                this.textBox_m_fRcvMemDist.Text = this.SelectedTask.m_fRcvMemDist.ToString("F3");
                this.checkBox_m_bCntByMemPos.Checked = this.SelectedTask.m_bCntByMemPos;
                this.textBox_m_fCntMemDist.Text = this.SelectedTask.m_fCntMemDist.ToString("F3");
                this.checkBox_m_bAllSucc.Checked = this.SelectedTask.m_bAllSucc;
                this.checkBox_m_bCoupleOnly.Checked = this.SelectedTask.m_bCoupleOnly;
                this.checkBox_m_bDistinguishedOcc.Checked = this.SelectedTask.m_bDistinguishedOcc;
                this.dataGridView_m_TeamMemsWanted.Rows.Clear();
                for (int num31 = 0; num31 < this.SelectedTask.m_TeamMemsWanted.Length; num31++)
                {
                    try
                    {
                        string[] strArray20 = new string[]
                    {
                        this.SelectedTask.m_TeamMemsWanted[num31].m_ulLevelMin.ToString(),
                        this.SelectedTask.m_TeamMemsWanted[num31].m_ulLevelMax.ToString(),
                        this.dataGridViewTextBoxColumn10.Items[this.SelectedTask.m_TeamMemsWanted[num31].m_ulRace].ToString(),
                        this.dataGridViewTextBoxColumn11.Items[Math.Max(0, this.SelectedTask.m_TeamMemsWanted[num31].m_ulOccupation - -1)].ToString(),
                        this.dataGridViewTextBoxColumn12.Items[this.SelectedTask.m_TeamMemsWanted[num31].m_ulGender].ToString(),
                        this.SelectedTask.m_TeamMemsWanted[num31].m_ulMinCount.ToString(),
                        this.SelectedTask.m_TeamMemsWanted[num31].m_ulMaxCount.ToString(),
                        this.SelectedTask.m_TeamMemsWanted[num31].m_ulTask.ToString(),
                        this.Column18.Items[Math.Max(0, this.SelectedTask.m_TeamMemsWanted[num31].m_iForce - 1003)].ToString()
                    };
                        this.dataGridView_m_TeamMemsWanted.Rows.Add(strArray20);
                        goto IL_1E79;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(436));
                        goto IL_1E79;
                    }
                    IL_1E79:;
                }
                this.checkBox_m_bShowByTeam.Checked = this.SelectedTask.m_bShowByTeam;
                this.checkBox_m_bPremNeedComp.Checked = this.SelectedTask.m_bPremNeedComp;
                this.comboBox_m_nPremExp1AndOrExp2.SelectedIndex = this.SelectedTask.m_nPremExp1AndOrExp2;
                this.dataGridView_m_Prem1KeyValue.Rows.Clear();
                for (int num24 = 0; num24 < 1; num24++)
                {
                    try
                    {
                        string[] strArray13 = new string[]
                    {
                        this.Column29.Items[this.SelectedTask.m_Prem1KeyValue.nLeftType].ToString(),
                        this.SelectedTask.m_Prem1KeyValue.lLeftNum.ToString(),
                        this.Column31.Items[this.SelectedTask.m_Prem1KeyValue.nCompOper].ToString(),
                        this.Column32.Items[this.SelectedTask.m_Prem1KeyValue.nRightType].ToString(),
                        this.SelectedTask.m_Prem1KeyValue.lRightNum.ToString(),
                    };
                        this.dataGridView_m_Prem1KeyValue.Rows.Add(strArray13);
                        goto IL_1B1;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(437));
                        goto IL_1B1;
                    }
                    IL_1B1:;
                }
                this.dataGridView_m_Prem2KeyValue.Rows.Clear();
                for (int num24 = 0; num24 < 1; num24++)
                {
                    try
                    {
                        string[] strArray13 = new string[]
                    {
                        this.dataGridViewComboBoxColumn110.Items[this.SelectedTask.m_Prem2KeyValue.nLeftType].ToString(),
                        this.SelectedTask.m_Prem2KeyValue.lLeftNum.ToString(),
                        this.dataGridViewComboBoxColumn112.Items[this.SelectedTask.m_Prem2KeyValue.nCompOper].ToString(),
                        this.dataGridViewComboBoxColumn113.Items[this.SelectedTask.m_Prem2KeyValue.nRightType].ToString(),
                        this.SelectedTask.m_Prem2KeyValue.lRightNum.ToString(),
                    };
                        this.dataGridView_m_Prem2KeyValue.Rows.Add(strArray13);
                        goto IL_1B1;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(438));
                        goto IL_1B1;
                    }
                    IL_1B1:;
                }


                // this.comboBox_m_iPremForce.SelectedIndex =
                //     this.comboBox_m_iPremForce.Items.IndexOf(this.comboBox_m_iPremForce.Items.fi("myValue"))



                this.comboBox_m_iPremForce.SelectedIndex = this.comboBox_m_iPremForce.FindString(this.SelectedTask.m_iPremForce + "_"); 
                
               // this.comboBox_m_iPremForce.SelectedIndex = this.comboBox_m_iPremForce.Items.Contains(this.SelectedTask.m_iPremForce +"_") ?  //Math.Max(0, this.SelectedTask.m_iPremForce - 1003);
                this.checkBox_m_bShowByForce.Checked = this.SelectedTask.m_bShowByForce;
                this.textBox_m_iPremForceReputation.Text = this.SelectedTask.m_iPremForceReputation.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByForceReputation.Checked = this.SelectedTask.m_bShowByForceReputation;
                this.textBox_m_iPremForceContribution.Text = this.SelectedTask.m_iPremForceContribution.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByForceContribution.Checked = this.SelectedTask.m_bShowByForceContribution;
                this.textBox_m_iPremForceExp.Text = this.SelectedTask.m_iPremForceExp.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByForceExp.Checked = this.SelectedTask.m_bShowByForceExp;
                this.textBox_m_iPremForceSP.Text = this.SelectedTask.m_iPremForceSP.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByForceSP.Checked = this.SelectedTask.m_bShowByForceSP;
                this.textBox_m_iPremForceActivityLevel.Text = this.SelectedTask.m_iPremForceActivityLevel.ToString();
                this.checkBox_m_bShowByForceActivityLevel.Checked = this.SelectedTask.m_bShowByForceActivityLevel;
                this.checkBox_m_bPremIsKing.Checked = this.SelectedTask.m_bPremIsKing;
                this.checkBox_m_bShowByKing.Checked = this.SelectedTask.m_bShowByKing;
                this.checkBox_m_bPremNotInTeam.Checked = this.SelectedTask.m_bPremNotInTeam;
                this.checkBox_m_bShowByNotInTeam.Checked = this.SelectedTask.m_bShowByNotInTeam;
                this.textBox_m_iPremTitleNumRequired.Text = this.SelectedTask.m_iPremTitleNumRequired.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.dataGridView_m_PremTitles.Rows.Clear();
                for (int num32 = 0; num32 < this.SelectedTask.m_PremTitles.Length; num32++)
                {
                    try
                    {
                        string[] strArray21 = new string[]
					{
						this.SelectedTask.m_PremTitles[num32].ToString(),
                        Extensions.TitleName(this.SelectedTask.m_PremTitles[num32])
					};
                        this.dataGridView_m_PremTitles.Rows.Add(strArray21);
                        goto IL_21F7;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(439));
                        goto IL_21F7;
                    }
                IL_21F7: ;
                }
                this.checkBox_m_bShowByTitle.Checked = this.SelectedTask.m_bShowByTitle;
                this.textBox_m_iPremHistoryStageIndex_1.Text = this.SelectedTask.m_iPremHistoryStageIndex[0].ToString();
                this.textBox_m_iPremHistoryStageIndex_2.Text = this.SelectedTask.m_iPremHistoryStageIndex[1].ToString();
                this.checkBox_m_bShowByHistoryStage.Checked = this.SelectedTask.m_bShowByHistoryStage;
                this.textBox_m_ulPremGeneralCardCount.Text = this.SelectedTask.m_ulPremGeneralCardCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByGeneralCard.Checked = this.SelectedTask.m_bShowByGeneralCard;
                int PremGeneralCardRank = this.SelectedTask.m_iPremGeneralCardRank;
                switch (PremGeneralCardRank)
                {
                    case -1:
                        this.comboBox_m_iPremGeneralCardRank.SelectedIndex = 0;
                        break;
                    case 0:
                        this.comboBox_m_iPremGeneralCardRank.SelectedIndex = 1;
                        break;
                    case 1:
                        this.comboBox_m_iPremGeneralCardRank.SelectedIndex = 2;
                        break;
                    case 2:
                        this.comboBox_m_iPremGeneralCardRank.SelectedIndex = 3;
                        break;
                    case 3:
                        this.comboBox_m_iPremGeneralCardRank.SelectedIndex = 4;
                        break;
                    case 4:
                        this.comboBox_m_iPremGeneralCardRank.SelectedIndex = 5;
                        break;
                }
                this.textBox_m_ulPremGeneralCardRankCount.Text = this.SelectedTask.m_ulPremGeneralCardRankCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_m_bShowByGeneralCardRank.Checked = this.SelectedTask.m_bShowByGeneralCardRank;
                this.textBox_PremiseIconStateID.Text = this.SelectedTask.PremiseIconStateID.ToString();
                this.ShowBuffDesc_PremiseIconStateID();
                this.checkBox_ShowByIconStateID.Checked = this.SelectedTask.ShowByIconStateID;
                this.textBox_VIPLevelMin.Text = this.SelectedTask.VIPLevelMin.ToString();
                this.textBox_VIPLevelMax.Text = this.SelectedTask.VIPLevelMax.ToString();
                this.checkBox_ShowByVIPLevel.Checked = this.SelectedTask.ShowByVIPLevel;
                this.checkBox_PremNoHome.Checked = this.SelectedTask.PremNoHome;
                this.numericUpDown_PremHomeLevelMin.Text = this.SelectedTask.PremHomeLevelMin.ToString();
                this.numericUpDown_PremHomeLevelMax.Text = this.SelectedTask.PremHomeLevelMax.ToString();
                this.checkBox_ShowByHomeLevel.Checked = this.SelectedTask.ShowByHomeLevel;
                this.comboBox_PremHomeResourceType.SelectedIndex = this.SelectedTask.PremHomeResourceType;
                this.numericUpDown_PremHomeResourceLevelMin.Text = this.SelectedTask.PremHomeResourceLevelMin.ToString();
                this.numericUpDown_PremHomeResourceLevelMax.Text = this.SelectedTask.PremHomeResourceLevelMax.ToString();
                this.checkBox_ShowByHomeResourceLevel.Checked = this.SelectedTask.ShowByHomeResourceLevel;
                this.comboBox_PremHomeFactoryType.SelectedIndex = this.SelectedTask.PremHomeFactoryType;
                this.numericUpDown_PremHomeFactoryLevelMin.Text = this.SelectedTask.PremHomeFactoryLevelMin.ToString();
                this.numericUpDown_PremHomeFactoryLevelMax.Text = this.SelectedTask.PremHomeFactoryLevelMax.ToString();
                this.checkBox_ShowByHomeFactoryLevel.Checked = this.SelectedTask.ShowByHomeFactoryLevel;
                this.textBox_PremHomeFlourishMin.Text = this.SelectedTask.PremHomeFlourishMin.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.textBox_PremHomeFlourishMax.Text = this.SelectedTask.PremHomeFlourishMax.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.checkBox_ShowByHomeFlourish.Checked = this.SelectedTask.ShowByHomeFlourish;
                this.checkBox_PremHomeStorageTask.Checked = this.SelectedTask.PremHomeStorageTask;
                this.checkBox_ShowByHomeStorageTask.Checked = this.SelectedTask.ShowByHomeStorageTask;
                this.comboBox_m_enumMethod.SelectedIndex = this.SelectedTask.m_enumMethod;
                this.comboBox_m_enumFinishType.SelectedIndex = this.SelectedTask.m_enumFinishType;
                this.dataGridView_m_PlayerWanted.Rows.Clear();
                for (int num32 = 0; num32 < this.SelectedTask.m_PlayerWanted.Length; num32++)
                {
                    try
                    {
                        string[] strArray21 = new string[]
					{
						this.SelectedTask.m_PlayerWanted[num32].m_ulPlayerNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedTask.m_PlayerWanted[num32].m_ulDropItemId.ToString(),
                        Extensions.ItemName(this.SelectedTask.m_PlayerWanted[num32].m_ulDropItemId),
						this.SelectedTask.m_PlayerWanted[num32].m_ulDropItemCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedTask.m_PlayerWanted[num32].m_bDropCmnItem.ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_fDropProb.ToString(ProbValueFormat),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.m_ulOccupations.ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.m_iMinLevel.ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.m_iMaxLevel.ToString(),
						this.Column27.Items[this.SelectedTask.m_PlayerWanted[num32].m_Requirements.m_iGender].ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.m_iForce.ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.ModelCheck.ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.ModelType[0].ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.ModelType[1].ToString(),
						this.SelectedTask.m_PlayerWanted[num32].m_Requirements.ModelType[2].ToString()
					};
                        this.dataGridView_m_PlayerWanted.Rows.Add(strArray21);
                        goto IL_21F7;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(440));
                        goto IL_21F7;
                    }
                IL_21F7: ;
                }
                this.dataGridView_m_MonsterWanted.Rows.Clear();
                for (int num33 = 0; num33 < this.SelectedTask.m_MonsterWanted.Length; num33++)
                {
                    try
                    {
                        string[] strArray22 = new string[]
					{
						this.SelectedTask.m_MonsterWanted[num33].m_ulMonsterTemplId.ToString(),
                        Extensions.MonsterNPCMineName(this.SelectedTask.m_MonsterWanted[num33].m_ulMonsterTemplId),
						this.SelectedTask.m_MonsterWanted[num33].m_ulMonsterNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedTask.m_MonsterWanted[num33].m_ulDropItemId.ToString(),
                        Extensions.ItemName(this.SelectedTask.m_MonsterWanted[num33].m_ulDropItemId),
						this.SelectedTask.m_MonsterWanted[num33].m_ulDropItemCount.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedTask.m_MonsterWanted[num33].m_bDropCmnItem.ToString(),
						this.SelectedTask.m_MonsterWanted[num33].m_fDropProb.ToString(ProbValueFormat),
						this.SelectedTask.m_MonsterWanted[num33].m_bKillerLev.ToString(),
						this.SelectedTask.m_MonsterWanted[num33].m_iDPH.ToString(),
						this.SelectedTask.m_MonsterWanted[num33].m_iDPS.ToString(),
					};
                        this.dataGridView_m_MonsterWanted.Rows.Add(strArray22);
                        goto IL_23A3;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(441));
                        goto IL_23A3;
                    }
                IL_23A3: ;
                }
                this.dataGridView_m_ItemsWanted.Rows.Clear();
                for (int num34 = 0; num34 < this.SelectedTask.m_ItemsWanted.Length; num34++)
                {
                    try
                    {
                        string[] strArray23 = new string[]
					{
						this.SelectedTask.m_ItemsWanted[num34].m_ulItemTemplId.ToString(),
                        Extensions.ItemName(this.SelectedTask.m_ItemsWanted[num34].m_ulItemTemplId),
						this.SelectedTask.m_ItemsWanted[num34].m_bCommonItem.ToString(),
						this.SelectedTask.m_ItemsWanted[num34].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedTask.m_ItemsWanted[num34].m_fProb.ToString(ProbValueFormat),
						Extensions.SecondsToString(this.SelectedTask.m_ItemsWanted[num34].m_lPeriod)
					};
                        this.dataGridView_m_ItemsWanted.Rows.Add(strArray23);
                        goto IL_2505;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(442));
                        goto IL_2505;
                    }
                IL_2505: ;
                }
                this.textBox_m_ulGoldWanted.Text = this.SelectedTask.m_ulGoldWanted.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.textBox_m_iFactionContribWanted.Text = this.SelectedTask.m_iFactionContribWanted.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.textBox_m_iFactionExpContribWanted.Text = this.SelectedTask.m_iFactionExpContribWanted.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.textBox_m_ulNPCToProtect.Text = this.SelectedTask.m_ulNPCToProtect.ToString();
                this.textBox_m_ulProtectTimeLen.Text = Extensions.SecondsToString(this.SelectedTask.m_ulProtectTimeLen);
                this.textBox_m_ulNPCMoving.Text = this.SelectedTask.m_ulNPCMoving.ToString();
                this.textBox_m_ulNPCDestSite.Text = this.SelectedTask.m_ulNPCDestSite.ToString();
                this.dataGridView_m_pReachSite.Rows.Clear();
                for (int num35 = 0; num35 < this.SelectedTask.m_pReachSite.Length; num35++)
                {
                    try
                    {
                        string[] strArray24 = new string[]
					{
						this.SelectedTask.m_pReachSite[num35].zvMin_x.ToString("F3"),
						this.SelectedTask.m_pReachSite[num35].zvMin_y.ToString("F3"),
						this.SelectedTask.m_pReachSite[num35].zvMin_z.ToString("F3"),
						this.SelectedTask.m_pReachSite[num35].zvMax_x.ToString("F3"),
						this.SelectedTask.m_pReachSite[num35].zvMax_y.ToString("F3"),
						this.SelectedTask.m_pReachSite[num35].zvMax_z.ToString("F3")
					};
                        this.dataGridView_m_pReachSite.Rows.Add(strArray24);
                        goto IL_26C1;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(443));
                        goto IL_26C1;
                    }
                IL_26C1: ;
                }
                this.textBox_m_ulReachSiteId.Text = this.SelectedTask.m_ulReachSiteId.ToString();
                this.ShowInstanceName_m_ulReachSiteId();
                this.textBox_m_ulWaitTime.Text = Extensions.SecondsToString(this.SelectedTask.m_ulWaitTime);
                this.textBox_m_TreasureStartZone_x.Text = this.SelectedTask.m_TreasureStartZone.x.ToString("F3");
                this.textBox_m_TreasureStartZone_y.Text = this.SelectedTask.m_TreasureStartZone.y.ToString("F3");
                this.textBox_m_TreasureStartZone_z.Text = this.SelectedTask.m_TreasureStartZone.z.ToString("F3");
                this.Convert_m_TreasureStartZone();
                this.textBox_m_ucZonesNumX.Text = this.SelectedTask.m_ucZonesNumX.ToString();
                this.textBox_m_ucZonesNumZ.Text = this.SelectedTask.m_ucZonesNumZ.ToString();
                this.textBox_m_ucZoneSide.Text = this.SelectedTask.m_ucZoneSide.ToString();
                this.dataGridView_m_pLeaveSite.Rows.Clear();
                for (int num39 = 0; num39 < this.SelectedTask.m_pLeaveSite.Length; num39++)
                {
                    try
                    {
                        string[] strArray28 = new string[]
					{
						this.SelectedTask.m_pLeaveSite[num39].zvMin_x.ToString("F3"),
						this.SelectedTask.m_pLeaveSite[num39].zvMin_y.ToString("F3"),
						this.SelectedTask.m_pLeaveSite[num39].zvMin_z.ToString("F3"),
						this.SelectedTask.m_pLeaveSite[num39].zvMax_x.ToString("F3"),
						this.SelectedTask.m_pLeaveSite[num39].zvMax_y.ToString("F3"),
						this.SelectedTask.m_pLeaveSite[num39].zvMax_z.ToString("F3")
					};
                        this.dataGridView_m_pLeaveSite.Rows.Add(strArray28);
                        goto IL_2D7D;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(444));
                        goto IL_2D7D;
                    }
                IL_2D7D: ;
                }
                this.textBox_m_ulLeaveSiteId.Text = this.SelectedTask.m_ulLeaveSiteId.ToString();
                this.ShowInstanceName_m_ulLeaveSiteId();
                this.checkBox_m_bFinNeedComp.Checked = this.SelectedTask.m_bFinNeedComp;
                this.comboBox_m_nFinExp1AndOrExp2.SelectedIndex = this.SelectedTask.m_nFinExp1AndOrExp2;
                this.dataGridView_m_Fin1KeyValue.Rows.Clear();
                for (int num24 = 0; num24 < 1; num24++)
                {
                    try
                    {
                        string[] strArray13 = new string[]
					{
						this.Column29_1.Items[this.SelectedTask.m_Fin1KeyValue.nLeftType].ToString(),
						this.SelectedTask.m_Fin1KeyValue.lLeftNum.ToString(),
						this.Column31_1.Items[this.SelectedTask.m_Fin1KeyValue.nCompOper].ToString(),
						this.Column32_1.Items[this.SelectedTask.m_Fin1KeyValue.nRightType].ToString(),
						this.SelectedTask.m_Fin1KeyValue.lRightNum.ToString(),
					};
                        this.dataGridView_m_Fin1KeyValue.Rows.Add(strArray13);
                        goto IL_1B1;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(445));
                        goto IL_1B1;
                    }
                IL_1B1: ;
                }
                this.dataGridView_m_Fin2KeyValue.Rows.Clear();
                for (int num24 = 0; num24 < 1; num24++)
                {
                    try
                    {
                        string[] strArray13 = new string[]
					{
						this.Column29_2.Items[this.SelectedTask.m_Fin2KeyValue.nLeftType].ToString(),
						this.SelectedTask.m_Fin2KeyValue.lLeftNum.ToString(),
						this.Column31_2.Items[this.SelectedTask.m_Fin2KeyValue.nCompOper].ToString(),
						this.Column32_2.Items[this.SelectedTask.m_Fin2KeyValue.nRightType].ToString(),
						this.SelectedTask.m_Fin2KeyValue.lRightNum.ToString(),
					};
                        this.dataGridView_m_Fin2KeyValue.Rows.Add(strArray13);
                        goto IL_1B1;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(446));
                        goto IL_1B1;
                    }
                IL_1B1: ;
                }
                this.dataGridView_m_pszExp.Rows.Clear();
                for (int num40 = 0; num40 < this.SelectedTask.m_pExpArr.Length; num40++)
                {
                    try
                    {
                        string[] strArray29 = new string[129];
                        strArray29[0] = Extensions.ByteArray_to_GbkString(this.SelectedTask.m_pszExp[num40]);
                        for (int i = 0; i < 64; i++)
                        {
                            strArray29[(i * 2) + 1] = this.SelectedTask.m_pExpArr[num40].type[i].ToString();
                            strArray29[(i * 2) + 2] = this.SelectedTask.m_pExpArr[num40].value[i].ToString();
                        }
                        this.dataGridView_m_pszExp.Rows.Add(strArray29);
                        goto IL_2FCD;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(447));
                        goto IL_2FCD;
                    }
                IL_2FCD: ;
                }
                this.richTextBox_PreviewText_m_pTaskChar.Text = "";
                this.dataGridView_m_pTaskChar.Rows.Clear();
                for (int num41 = 0; num41 < this.SelectedTask.m_pTaskChar.Length; num41++)
                {
                    try
                    {
                        string[] strArray30 = new string[]
					{
						Extensions.ByteArray_to_UnicodeString(this.SelectedTask.m_pTaskChar[num41])
					};
                        this.dataGridView_m_pTaskChar.Rows.Add(strArray30);
                        goto IL_3137;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(448));
                        goto IL_3137;
                    }
                IL_3137: ;
                }
                this.textBox_m_ucTransformedForm.Text = this.SelectedTask.m_ucTransformedForm.ToString();
                this.numericUpDown_m_ulReachLevel.Text = this.SelectedTask.m_ulReachLevel.ToString();
                this.numericUpDown_m_ulReachReincarnationCount.Text = this.SelectedTask.m_ulReachReincarnationCount.ToString();
                this.numericUpDown_m_ulReachRealmLevel.Text = this.SelectedTask.m_ulReachRealmLevel.ToString();
                int Emotion = this.SelectedTask.m_uiEmotion;
                switch (Emotion)
                {
                    case 0:
                        this.comboBox_m_uiEmotion.SelectedIndex = 0;
                        break;
                    case 1:
                        this.comboBox_m_uiEmotion.SelectedIndex = 1;
                        break;
                    case 2:
                        this.comboBox_m_uiEmotion.SelectedIndex = 2;
                        break;
                    case 3:
                        this.comboBox_m_uiEmotion.SelectedIndex = 3;
                        break;
                    case 4:
                        this.comboBox_m_uiEmotion.SelectedIndex = 4;
                        break;
                    case 5:
                        this.comboBox_m_uiEmotion.SelectedIndex = 5;
                        break;
                    case 6:
                        this.comboBox_m_uiEmotion.SelectedIndex = 6;
                        break;
                    case 7:
                        this.comboBox_m_uiEmotion.SelectedIndex = 7;
                        break;
                    case 8:
                        this.comboBox_m_uiEmotion.SelectedIndex = 8;
                        break;
                    case 9:
                        this.comboBox_m_uiEmotion.SelectedIndex = 9;
                        break;
                    case 10:
                        this.comboBox_m_uiEmotion.SelectedIndex = 10;
                        break;
                    case 11:
                        this.comboBox_m_uiEmotion.SelectedIndex = 11;
                        break;
                    case 12:
                        this.comboBox_m_uiEmotion.SelectedIndex = 12;
                        break;
                    case 13:
                        this.comboBox_m_uiEmotion.SelectedIndex = 13;
                        break;
                    case 14:
                        this.comboBox_m_uiEmotion.SelectedIndex = 14;
                        break;
                    case 15:
                        this.comboBox_m_uiEmotion.SelectedIndex = 15;
                        break;
                    case 16:
                        this.comboBox_m_uiEmotion.SelectedIndex = 16;
                        break;
                    case 17:
                        this.comboBox_m_uiEmotion.SelectedIndex = 17;
                        break;
                    case 18:
                        this.comboBox_m_uiEmotion.SelectedIndex = 18;
                        break;
                    case 19:
                        this.comboBox_m_uiEmotion.SelectedIndex = 19;
                        break;
                    case 20:
                        this.comboBox_m_uiEmotion.SelectedIndex = 20;
                        break;
                    case 21:
                        this.comboBox_m_uiEmotion.SelectedIndex = 21;
                        break;
                    case 22:
                        this.comboBox_m_uiEmotion.SelectedIndex = 22;
                        break;
                    case 23:
                        this.comboBox_m_uiEmotion.SelectedIndex = 23;
                        break;
                    case 24:
                        this.comboBox_m_uiEmotion.SelectedIndex = 24;
                        break;
                    case 25:
                        this.comboBox_m_uiEmotion.SelectedIndex = 25;
                        break;
                    case 26:
                        this.comboBox_m_uiEmotion.SelectedIndex = 26;
                        break;
                    case 27:
                        this.comboBox_m_uiEmotion.SelectedIndex = 27;
                        break;
                    case 28:
                        this.comboBox_m_uiEmotion.SelectedIndex = 28;
                        break;
                    case 29:
                        this.comboBox_m_uiEmotion.SelectedIndex = 29;
                        break;
                    case 30:
                        this.comboBox_m_uiEmotion.SelectedIndex = 30;
                        break;
                    case 31:
                        this.comboBox_m_uiEmotion.SelectedIndex = 31;
                        break;
                    default:
                        switch (Emotion)
                        {
                            case 1024:
                                this.comboBox_m_uiEmotion.SelectedIndex = 32;
                                break;
                            case 1025:
                                this.comboBox_m_uiEmotion.SelectedIndex = 33;
                                break;
                            case 1026:
                                this.comboBox_m_uiEmotion.SelectedIndex = 34;
                                break;
                            case 1027:
                                this.comboBox_m_uiEmotion.SelectedIndex = 35;
                                break;
                        }
                        break;
                }
                this.textBox_TMIconStateID.Text = this.SelectedTask.TMIconStateID.ToString();
                this.ShowBuffDesc_TMIconStateID();
                this.comboBox_TMHomeLevelType.SelectedIndex = this.SelectedTask.TMHomeLevelType;
                this.numericUpDown_TMReachHomeLevel.Text = this.SelectedTask.TMReachHomeLevel.ToString();
                this.textBox_TMReachHomeFlourish.Text = this.SelectedTask.TMReachHomeFlourish.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.dataGridView_TMHomeItem.Rows.Clear();
                for (int num34 = 0; num34 < this.SelectedTask.TMHomeItemData.Length; num34++)
                {
                    try
                    {
                        string[] strArray23 = new string[]
					{
						this.SelectedTask.TMHomeItemData[num34].m_ulItemTemplId.ToString(),
                        Extensions.HomeItemName(this.SelectedTask.TMHomeItemData[num34].m_ulItemTemplId),
						this.SelectedTask.TMHomeItemData[num34].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"))
					};
                        this.dataGridView_TMHomeItem.Rows.Add(strArray23);
                        goto IL_2505;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(449));
                        goto IL_2505;
                    }
                IL_2505: ;
                }
                this.comboBox_m_ulAwardType_S.SelectedIndex = this.SelectedTask.m_ulAwardType_S;
                this.comboBox_m_ulAwardType_F.SelectedIndex = this.SelectedTask.m_ulAwardType_F;
                this.listBox_reward_m_AwByRatio_S.Items.Clear();
                for (int j = 0; j < this.SelectedTask.m_AwByRatio_S.m_Awards.Length; j++)
                {
                    this.listBox_reward_m_AwByRatio_S.Items.Add(Extensions.GetLocalization(405) + (float)this.SelectedTask.m_ulTimeLimit * this.SelectedTask.m_AwByRatio_S.m_Ratios[j]);
                }
                this.listBox_reward_m_AwByRatio_F.Items.Clear();
                for (int j = 0; j < this.SelectedTask.m_AwByRatio_F.m_Awards.Length; j++)
                {
                    this.listBox_reward_m_AwByRatio_F.Items.Add(Extensions.GetLocalization(405) + (float)this.SelectedTask.m_ulTimeLimit * this.SelectedTask.m_AwByRatio_F.m_Ratios[j]);
                }
                this.toolStripComboBox1.SelectedIndex = -1;
                this.toolStripComboBox1_1.SelectedIndex = -1;
                if (this.SelectedTask.m_pDelvRegion.Length == 0)
                {
                    this.textBox_m_pDelvRegion_Min_Client.Text = "0, 0 (0)";
                    this.textBox_m_pDelvRegion_Max_Client.Text = "0, 0 (0)";
                }
                if (this.SelectedTask.m_pEnterRegion.Length == 0)
                {
                    this.textBox_m_pEnterRegion_Min_Client.Text = "0, 0 (0)";
                    this.textBox_m_pEnterRegion_Max_Client.Text = "0, 0 (0)";
                }
                if (this.SelectedTask.m_pLeaveRegion.Length == 0)
                {
                    this.textBox_m_pLeaveRegion_Min_Client.Text = "0, 0 (0)";
                    this.textBox_m_pLeaveRegion_Max_Client.Text = "0, 0 (0)";
                }
                if (this.SelectedTask.m_pReachSite.Length == 0)
                {
                    this.textBox_m_pReachSite_Min_Client.Text = "0, 0 (0)";
                    this.textBox_m_pReachSite_Max_Client.Text = "0, 0 (0)";
                }
                if (this.SelectedTask.m_pLeaveSite.Length == 0)
                {
                    this.textBox_m_pLeaveSite_Min_Client.Text = "0, 0 (0)";
                    this.textBox_m_pLeaveSite_Max_Client.Text = "0, 0 (0)";
                }
                //this.Convert_m_pDelvRegion(null, null);
                //this.Convert_m_pEnterRegion(null, null);
                //this.Convert_m_pLeaveRegion(null, null);
                //this.Convert_m_pReachSite(null, null);
                //this.Convert_m_pLeaveSite(null, null);
                this.select_reward(null, null);
                this.textBox_m_ulParent.Text = this.SelectedTask.m_ulParent.ToString();
                this.textBox_m_ulPrevSibling.Text = this.SelectedTask.m_ulPrevSibling.ToString();
                this.textBox_m_ulNextSibling.Text = this.SelectedTask.m_ulNextSibling.ToString();
                this.textBox_m_ulFirstChild.Text = this.SelectedTask.m_ulFirstChild.ToString();
                this.checkBox_m_bIsLibraryTask.Checked = this.SelectedTask.m_bIsLibraryTask;
                this.textBox_m_fLibraryTasksProbability.Text = this.SelectedTask.m_fLibraryTasksProbability.ToString(ProbValueFormat);
                this.checkBox_m_bIsUniqueStorageTask.Checked = this.SelectedTask.m_bIsUniqueStorageTask;
                this.textBox_WorldContrib.Text = this.SelectedTask.WorldContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                this.textBox_conversation_m_pwstrDescript.Text = this.SelectedTask.conversation.Descript;
                this.textBox_conversation_m_pwstrOkText.Text = this.SelectedTask.conversation.OkText;
                this.textBox_conversation_m_pwstrNoText.Text = this.SelectedTask.conversation.NoText;
                this.textBox_conversation_m_pwstrTribute.Text = this.SelectedTask.conversation.Tribute;
                int SelctedTalkProc = this.listBox_conversation_talk_procs.SelectedIndex;
                this.listBox_conversation_talk_procs.SelectedIndex = -1;
                this.listBox_conversation_talk_procs.Items[0] = Extensions.GetLocalization(1704) + "(" + this.SelectedTask.talk_procs[0].num_window + ")";
                this.listBox_conversation_talk_procs.Items[1] = Extensions.GetLocalization(1705) + "(" + this.SelectedTask.talk_procs[1].num_window + ")";
                this.listBox_conversation_talk_procs.Items[2] = Extensions.GetLocalization(1706) + "(" + this.SelectedTask.talk_procs[2].num_window + ")";
                this.listBox_conversation_talk_procs.Items[3] = Extensions.GetLocalization(1707) + "(" + this.SelectedTask.talk_procs[3].num_window + ")";
                this.listBox_conversation_talk_procs.Items[4] = Extensions.GetLocalization(1708) + "(" + this.SelectedTask.talk_procs[4].num_window + ")";
                this.listBox_conversation_talk_procs.SelectedIndex = SelctedTalkProc;
                Selecting = false;
                this.FormatingString(1);
                lastSelectedNode = this.treeView_tasks.SelectedNode;
            }
        }
        #endregion

        #region Select Reward
        private void select_reward(object sender, EventArgs e)
        {
            if (this.SelectedTask == null)
            {
                return;
            }
            this.SelectedReward = null;
            if (this.radioButton_m_Award_S.Checked)
            {
                this.listBox_reward_m_AwByRatio_S.Enabled = false;
                this.numericUpDown_m_Ratios_S.Enabled = false;
                this.numericUpDown_m_Ratios_S.Value = 0m;
                this.listBox_reward_m_AwByRatio_F.Enabled = false;
                this.numericUpDown_m_Ratios_F.Enabled = false;
                this.numericUpDown_m_Ratios_F.Value = 0m;
                this.SelectedReward = this.SelectedTask.m_Award_S;
            }
            if (this.radioButton_m_Award_F.Checked)
            {
                this.listBox_reward_m_AwByRatio_S.Enabled = false;
                this.numericUpDown_m_Ratios_S.Enabled = false;
                this.numericUpDown_m_Ratios_S.Value = 0m;
                this.listBox_reward_m_AwByRatio_F.Enabled = false;
                this.numericUpDown_m_Ratios_F.Enabled = false;
                this.numericUpDown_m_Ratios_F.Value = 0m;
                this.SelectedReward = this.SelectedTask.m_Award_F;
            }
            if (this.radioButton_m_AwByRatio_S.Checked)
            {
                this.listBox_reward_m_AwByRatio_S.Enabled = true;
                this.numericUpDown_m_Ratios_S.Enabled = true;
                if (this.listBox_reward_m_AwByRatio_S.SelectedIndex > -1)
                {
                    this.SelectedReward = this.SelectedTask.m_AwByRatio_S.m_Awards[this.listBox_reward_m_AwByRatio_S.SelectedIndex];
                    decimal num15 = Convert.ToDecimal(this.SelectedTask.m_AwByRatio_S.m_Ratios[this.listBox_reward_m_AwByRatio_S.SelectedIndex]);
                    this.numericUpDown_m_Ratios_S.Value = num15;
                }
                else
                {
                    this.numericUpDown_m_Ratios_S.Value = 0m;
                }
                this.listBox_reward_m_AwByRatio_F.Enabled = false;
                this.numericUpDown_m_Ratios_F.Enabled = false;
                this.numericUpDown_m_Ratios_F.Value = 0m;
            }
            if (this.radioButton_m_AwByRatio_F.Checked)
            {
                this.listBox_reward_m_AwByRatio_F.Enabled = true;
                this.numericUpDown_m_Ratios_F.Enabled = true;
                if (this.listBox_reward_m_AwByRatio_F.SelectedIndex > -1)
                {
                    this.SelectedReward = this.SelectedTask.m_AwByRatio_F.m_Awards[this.listBox_reward_m_AwByRatio_F.SelectedIndex];
                    decimal num15 = Convert.ToDecimal(this.SelectedTask.m_AwByRatio_F.m_Ratios[this.listBox_reward_m_AwByRatio_F.SelectedIndex]);
                    this.numericUpDown_m_Ratios_F.Value = num15;
                }
                else
                {
                    this.numericUpDown_m_Ratios_F.Value = 0m;
                }
                this.listBox_reward_m_AwByRatio_S.Enabled = false;
                this.numericUpDown_m_Ratios_S.Enabled = false;
                this.numericUpDown_m_Ratios_S.Value = 0m;
            }
            if (this.SelectedReward == null)
            {
                this.textBox_reward_m_ulGoldNum.Clear();
                this.textBox_reward_m_ulExp.Clear();
                this.textBox_reward_m_ulRealmExp.Clear();
                this.checkBox_reward_m_bExpandRealmLevelMax.Checked = false;
                this.textBox_reward_m_ulNewTask.Clear();
                this.textBox_reward_m_ulSP.Clear();
                this.textBox_reward_m_lReputation.Clear();
                this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 0;
                this.textBox_reward_m_ulNewRelayStation.Clear();
                this.textBox_reward_m_ulStorehouseSize.Clear();
                this.textBox_reward_m_ulStorehouseSize2.Clear();
                this.textBox_reward_m_ulStorehouseSize3.Clear();
                this.textBox_reward_m_ulStorehouseSize4.Clear();
                this.textBox_reward_m_lInventorySize.Clear();
                this.textBox_reward_m_ulPetInventorySize.Clear();
                this.textBox_reward_m_ulFuryULimit.Clear();
                this.textBox_reward_m_ulTransWldId.Clear();
                this.textBox_reward_m_TransPt_x.Clear();
                this.textBox_reward_m_TransPt_y.Clear();
                this.textBox_reward_m_TransPt_z.Clear();
                this.textBox_reward_m_lMonsCtrl.Clear();
                this.checkBox_reward_m_bTrigCtrl.Checked = false;
                this.checkBox_reward_m_bUseLevCo.Checked = false;
                this.checkBox_reward_m_bDivorce.Checked = false;
                this.checkBox_reward_m_bSendMsg.Checked = false;
                this.comboBox_reward_m_nMsgChannel.SelectedIndex = 0;
                this.numericUpDown_reward_m_ulCandItems.Value = 0m;
                this.checkedListBox_reward_canditems_m_bRandChoose.Items.Clear();
                this.toolStripComboBox1.Items.Clear();
                this.toolStripComboBox1.SelectedIndex = -1;
                this.toolStripComboBox1_1.Items.Clear();
                this.toolStripComboBox1_1.SelectedIndex = -1;
                this.dataGridView_reward_item_m_AwardItems.Rows.Clear();
                this.checkBox_reward_m_bRandChoose.Checked = false;
                this.textBox_reward_m_ulSummonRadius.Clear();
                this.checkBox_reward_m_bDeathDisappear.Checked = false;
                this.dataGridView_reward_m_Monsters.Rows.Clear();
                this.checkBox_reward_m_bAwardDeath.Checked = false;
                this.checkBox_reward_m_bAwardDeathWithLoss.Checked = false;
                this.textBox_reward_m_ulDividend.Clear();
                this.checkBox_reward_m_bAwardSkill.Checked = false;
                this.textBox_reward_m_iAwardSkillID.Clear();
                this.numericUpDown_reward_m_iAwardSkillLevel.Value = 0m;
                this.textBox_reward_AwardSoloTowerChallengeScore.Clear();
                this.textBox_reward_m_ulSpecifyContribTaskID.Clear();
                this.textBox_reward_m_ulSpecifyContribSubTaskID.Clear();
                this.textBox_reward_m_ulSpecifyContrib.Clear();
                this.textBox_reward_m_ulContrib.Clear();
                this.textBox_reward_m_ulRandContrib.Clear();
                this.textBox_reward_m_ulLowestcontrib.Clear();
                this.textBox_reward_m_iFactionContrib.Clear();
                this.textBox_reward_m_iFactionExpContrib.Clear();
                this.checkBox_reward_m_bAwardByProf.Checked = false;
                this.dataGridView_reward_m_RankingAward.Rows.Clear();
                this.dataGridView_reward_m_ulChangeKey.Rows.Clear();
                this.dataGridView_reward_m_ulHistoryChange.Rows.Clear();
                this.checkBox_reward_m_bMulti.Checked = false;
                this.textBox_reward_m_nNumType.Clear();
                this.textBox_reward_m_lNum.Clear();
                this.dataGridView_reward_m_plDisplayKey.Rows.Clear();
                this.dataGridView_reward_m_pszExp.Rows.Clear();
                this.dataGridView_reward_m_pTaskChar.Rows.Clear();
                this.textBox_reward_m_iForceContribution.Clear();
                this.textBox_reward_m_iForceReputation.Clear();
                this.textBox_reward_m_iForceActivity.Clear();
                this.textBox_reward_m_iForceSetRepu.Clear();
                this.textBox_reward_m_iTaskLimit.Clear();
                this.dataGridView_reward_m_pTitleAward.Rows.Clear();
                this.textBox_reward_m_iLeaderShip.Clear();
                this.textBox_reward_AwardWorldContrib.Clear();
                this.textBox_reward_AwardHomeResource_1.Clear();
                this.textBox_reward_AwardHomeResource_2.Clear();
                this.textBox_reward_AwardHomeResource_3.Clear();
                this.textBox_reward_AwardHomeResource_4.Clear();
                this.textBox_reward_AwardHomeResource_5.Clear();
                this.checkBox_reward_AwardCreateHome.Checked = false;
                return;
            }
            this.textBox_reward_m_ulGoldNum.Text = this.SelectedReward.m_ulGoldNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_ulExp.Text = this.SelectedReward.m_ulExp.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_ulRealmExp.Text = this.SelectedReward.m_ulRealmExp.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.checkBox_reward_m_bExpandRealmLevelMax.Checked = this.SelectedReward.m_bExpandRealmLevelMax;
            this.textBox_reward_m_ulNewTask.Text = this.SelectedReward.m_ulNewTask.ToString();
            this.textBox_reward_m_ulSP.Text = this.SelectedReward.m_ulSP.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.CalculationExpAndSPDependingOnLvlAndNum(null, null);
            this.textBox_reward_m_lReputation.Text = this.SelectedReward.m_lReputation.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            int m_ulNewPeriod = this.SelectedReward.m_ulNewPeriod;
            switch (m_ulNewPeriod)
            {
                case 0:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 0;
                    break;
                case 1:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 1;
                    break;
                case 2:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 2;
                    break;
                case 3:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 3;
                    break;
                case 4:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 4;
                    break;
                case 5:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 5;
                    break;
                case 6:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 6;
                    break;
                case 7:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 7;
                    break;
                case 8:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 8;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    break;
                case 20:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 9;
                    break;
                case 21:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 11;
                    break;
                case 22:
                    this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 13;
                    break;
                default:
                    switch (m_ulNewPeriod)
                    {
                        case 30:
                            this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 10;
                            break;
                        case 31:
                            this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 12;
                            break;
                        case 32:
                            this.comboBox_reward_m_ulNewPeriod.SelectedIndex = 14;
                            break;
                    }
                    break;
            }
            this.textBox_reward_m_ulNewRelayStation.Text = this.SelectedReward.m_ulNewRelayStation.ToString();
            this.ShowRelayStationName_Award_m_ulNewRelayStation();
            this.textBox_reward_m_ulStorehouseSize.Text = this.SelectedReward.m_ulStorehouseSize.ToString();
            this.textBox_reward_m_ulStorehouseSize2.Text = this.SelectedReward.m_ulStorehouseSize2.ToString();
            this.textBox_reward_m_ulStorehouseSize3.Text = this.SelectedReward.m_ulStorehouseSize3.ToString();
            this.textBox_reward_m_ulStorehouseSize4.Text = this.SelectedReward.m_ulStorehouseSize4.ToString();
            this.textBox_reward_m_lInventorySize.Text = this.SelectedReward.m_lInventorySize.ToString();
            this.textBox_reward_m_ulPetInventorySize.Text = this.SelectedReward.m_ulPetInventorySize.ToString();
            this.textBox_reward_m_ulFuryULimit.Text = this.SelectedReward.m_ulFuryULimit.ToString();
            this.textBox_reward_m_ulTransWldId.Text = this.SelectedReward.m_ulTransWldId.ToString();
            this.ShowInstanceName_Award_m_ulTransWldId();
            this.textBox_reward_m_TransPt_x.Text = this.SelectedReward.m_TransPt.x.ToString("F3");
            this.textBox_reward_m_TransPt_y.Text = this.SelectedReward.m_TransPt.y.ToString("F3");
            this.textBox_reward_m_TransPt_z.Text = this.SelectedReward.m_TransPt.z.ToString("F3");
            this.Convert_reward_m_TransPt();
            this.textBox_reward_m_lMonsCtrl.Text = this.SelectedReward.m_lMonsCtrl.ToString();
            this.checkBox_reward_m_bTrigCtrl.Checked = this.SelectedReward.m_bTrigCtrl;
            this.checkBox_reward_m_bUseLevCo.Checked = this.SelectedReward.m_bUseLevCo;
            this.ShowHide();
            this.checkBox_reward_m_bDivorce.Checked = this.SelectedReward.m_bDivorce;
            this.checkBox_reward_m_bSendMsg.Checked = this.SelectedReward.m_bSendMsg;
            this.comboBox_reward_m_nMsgChannel.SelectedIndex = this.SelectedReward.m_nMsgChannel;
            decimal num21 = Convert.ToDecimal(this.SelectedReward.m_ulCandItems);
            this.numericUpDown_reward_m_ulCandItems.Value = num21;
            this.checkedListBox_reward_canditems_m_bRandChoose.Items.Clear();
            this.dataGridView_reward_item_m_AwardItems.Rows.Clear();
            this.toolStripComboBox1.Items.Clear();
            this.toolStripComboBox1_1.Items.Clear();
            for (int num22 = 0; num22 < this.SelectedReward.m_CandItems.Length; num22++)
            {
                this.checkedListBox_reward_canditems_m_bRandChoose.Items.Add("[" + (num22 + 1).ToString() + "]" + Extensions.GetLocalization(406), this.SelectedReward.m_CandItems[num22].m_bRandChoose);
                this.toolStripComboBox1.Items.Add("[" + (num22 + 1).ToString() + "]" + Extensions.GetLocalization(406));
                this.toolStripComboBox1_1.Items.Add("[" + (num22 + 1).ToString() + "]" + Extensions.GetLocalization(406));
                if (this.SelectedReward != null && this.SelectedReward.m_ulCandItems > 0)
                {
                    this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = 0;
                }
            }
            this.checkBox_reward_m_bRandChoose.Checked = this.SelectedReward.m_SummonedMonsters.m_bRandChoose;
            this.textBox_reward_m_ulSummonRadius.Text = this.SelectedReward.m_SummonedMonsters.m_ulSummonRadius.ToString();
            this.checkBox_reward_m_bDeathDisappear.Checked = this.SelectedReward.m_SummonedMonsters.m_bDeathDisappear;
            this.dataGridView_reward_m_Monsters.Rows.Clear();
            for (int index = 0; index < this.SelectedReward.m_SummonedMonsters.m_Monsters.Length; index++)
            {
                try
                {
                    string[] strArray3 = new string[]
					{
						this.SelectedReward.m_SummonedMonsters.m_Monsters[index].m_ulMonsterTemplId.ToString(),
                        Extensions.MonsterNPCMineName(SelectedReward.m_SummonedMonsters.m_Monsters[index].m_ulMonsterTemplId),
						this.SelectedReward.m_SummonedMonsters.m_Monsters[index].m_ulMonsterNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedReward.m_SummonedMonsters.m_Monsters[index].m_fSummonProb.ToString(ProbValueFormat),
						Extensions.SecondsToString(this.SelectedReward.m_SummonedMonsters.m_Monsters[index].m_lPeriod)
					};
                    this.dataGridView_reward_m_Monsters.Rows.Add(strArray3);
                    goto IL_68D;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(450));
                    goto IL_68D;
                }
            IL_68D: ;
            }
            this.checkBox_reward_m_bAwardDeath.Checked = this.SelectedReward.m_bAwardDeath;
            this.checkBox_reward_m_bAwardDeathWithLoss.Checked = this.SelectedReward.m_bAwardDeathWithLoss;
            this.textBox_reward_m_ulDividend.Text = this.SelectedReward.m_ulDividend.ToString();
            this.checkBox_reward_m_bAwardSkill.Checked = this.SelectedReward.m_bAwardSkill;
            this.textBox_reward_m_iAwardSkillID.Text = this.SelectedReward.m_iAwardSkillID.ToString();
            this.ShowSkillText_Award_m_iAwardSkillID();
            this.numericUpDown_reward_m_iAwardSkillLevel.Text = this.SelectedReward.m_iAwardSkillLevel.ToString();
            this.textBox_reward_AwardSoloTowerChallengeScore.Text = this.SelectedReward.AwardSoloTowerChallengeScore.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_ulSpecifyContribTaskID.Text = this.SelectedReward.m_ulSpecifyContribTaskID.ToString();
            this.textBox_reward_m_ulSpecifyContribSubTaskID.Text = this.SelectedReward.m_ulSpecifyContribSubTaskID.ToString();
            this.textBox_reward_m_ulSpecifyContrib.Text = this.SelectedReward.m_ulSpecifyContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_ulContrib.Text = this.SelectedReward.m_ulContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_ulRandContrib.Text = this.SelectedReward.m_ulRandContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_ulLowestcontrib.Text = this.SelectedReward.m_ulLowestcontrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_iFactionContrib.Text = this.SelectedReward.m_iFactionContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_iFactionExpContrib.Text = this.SelectedReward.m_iFactionExpContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.checkBox_reward_m_bAwardByProf.Checked = this.SelectedReward.m_PQRankingAward.m_bAwardByProf;
            this.dataGridView_reward_m_RankingAward.Rows.Clear();
            for (int num16 = 0; num16 < this.SelectedReward.m_PQRankingAward.m_RankingAward.Length; num16++)
            {
                try
                {
                    string[] strArray4 = new string[]
					{
						this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_iRankingStart.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_iRankingEnd.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_bCommonItem.ToString(),
						this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString(),
                        Extensions.ItemName(this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId),
						this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
						Extensions.SecondsToString(this.SelectedReward.m_PQRankingAward.m_RankingAward[num16].m_lPeriod)
					};
                    this.dataGridView_reward_m_RankingAward.Rows.Add(strArray4);
                    goto IL_8BD;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(451));
                    goto IL_8BD;
                }
            IL_8BD: ;
            }
            this.dataGridView_reward_m_ulChangeKey.Rows.Clear();
            for (int num17 = 0; num17 < this.SelectedReward.m_plChangeKey.Length; num17++)
            {
                try
                {
                    string[] strArray5 = new string[]
					{
						this.SelectedReward.m_plChangeKey[num17].ToString(),
						this.SelectedReward.m_plChangeKeyValue[num17].ToString(),
						this.dataGridViewTextBoxColumn100.Items[Convert.ToInt32(this.SelectedReward.m_pbChangeType[num17])].ToString()
					};
                    this.dataGridView_reward_m_ulChangeKey.Rows.Add(strArray5);
                    goto IL_A0F;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(452));
                    goto IL_A0F;
                }
            IL_A0F: ;
            }
            this.dataGridView_reward_m_ulHistoryChange.Rows.Clear();
            for (int num17 = 0; num17 < this.SelectedReward.m_plHistoryChangeKey.Length; num17++)
            {
                try
                {
                    string[] strArray5 = new string[]
					{
						this.SelectedReward.m_plHistoryChangeKey[num17].ToString(),
						this.SelectedReward.m_plHistoryChangeKeyValue[num17].ToString(),
						this.Column282.Items[Convert.ToInt32(this.SelectedReward.m_pbHistoryChangeType[num17])].ToString()
					};
                    this.dataGridView_reward_m_ulHistoryChange.Rows.Add(strArray5);
                    goto IL_A0F;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(453));
                    goto IL_A0F;
                }
            IL_A0F: ;
            }
            this.checkBox_reward_m_bMulti.Checked = this.SelectedReward.m_bMulti;
            this.textBox_reward_m_nNumType.Text = this.SelectedReward.m_nNumType.ToString();
            this.textBox_reward_m_lNum.Text = this.SelectedReward.m_lNum.ToString();
            this.dataGridView_reward_m_plDisplayKey.Rows.Clear();
            for (int num17 = 0; num17 < this.SelectedReward.m_plDisplayKey.Length; num17++)
            {
                try
                {
                    string[] strArray5 = new string[]
					{
						this.SelectedReward.m_plDisplayKey[num17].ToString()
					};
                    this.dataGridView_reward_m_plDisplayKey.Rows.Add(strArray5);
                    goto IL_A0F;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(454));
                    goto IL_A0F;
                }
            IL_A0F: ;
            }
            this.dataGridView_reward_m_pszExp.Rows.Clear();
            for (int num18 = 0; num18 < this.SelectedReward.m_pExpArr.Length; num18++)
            {
                try
                {
                    string[] strArray6 = new string[129];
                    strArray6[0] = Extensions.ByteArray_to_GbkString(this.SelectedReward.m_pszExp[num18]);
                    for (int i = 0; i < 64; i++)
                    {
                        strArray6[(i * 2) + 1] = this.SelectedReward.m_pExpArr[num18].type[i].ToString();
                        strArray6[(i * 2) + 2] = this.SelectedReward.m_pExpArr[num18].value[i].ToString();
                    }
                    this.dataGridView_reward_m_pszExp.Rows.Add(strArray6);
                    goto IL_AF9;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(455));
                    goto IL_AF9;
                }
            IL_AF9: ;
            }
            this.dataGridView_reward_m_pTaskChar.Rows.Clear();
            for (int num19 = 0; num19 < this.SelectedReward.m_pTaskChar.Length; num19++)
            {
                try
                {
                    string[] strArray7 = new string[]
					{
						Extensions.ByteArray_to_GbkString(this.SelectedReward.m_pTaskChar[num19])
					};
                    this.dataGridView_reward_m_pTaskChar.Rows.Add(strArray7);
                    goto IL_B95;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(456));
                    goto IL_B95;
                }
            IL_B95: ;
            }
            this.textBox_reward_m_iForceContribution.Text = this.SelectedReward.m_iForceContribution.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_iForceReputation.Text = this.SelectedReward.m_iForceReputation.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_iForceActivity.Text = this.SelectedReward.m_iForceActivity.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_iForceSetRepu.Text = this.SelectedReward.m_iForceSetRepu.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_m_iTaskLimit.Text = this.SelectedReward.m_iTaskLimit.ToString();
            this.dataGridView_reward_m_pTitleAward.Rows.Clear();
            for (int num20 = 0; num20 < this.SelectedReward.m_pTitleAward.Length; num20++)
            {
                try
                {
                    string[] strArray8 = new string[]
					{
						this.SelectedReward.m_pTitleAward[num20].m_ulTitleID.ToString(),
                        Extensions.TitleName(this.SelectedReward.m_pTitleAward[num20].m_ulTitleID),
						Extensions.SecondsToString(this.SelectedReward.m_pTitleAward[num20].m_lPeriod)
					};
                    this.dataGridView_reward_m_pTitleAward.Rows.Add(strArray8);
                    goto IL_C11;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(457));
                    goto IL_C11;
                }
            IL_C11: ;
            }
            this.textBox_reward_m_iLeaderShip.Text = this.SelectedReward.m_iLeaderShip.ToString();
            this.textBox_reward_AwardWorldContrib.Text = this.SelectedReward.AwardWorldContrib.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_AwardHomeResource_1.Text = this.SelectedReward.AwardHomeResource[0].ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_AwardHomeResource_2.Text = this.SelectedReward.AwardHomeResource[1].ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_AwardHomeResource_3.Text = this.SelectedReward.AwardHomeResource[2].ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_AwardHomeResource_4.Text = this.SelectedReward.AwardHomeResource[3].ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.textBox_reward_AwardHomeResource_5.Text = this.SelectedReward.AwardHomeResource[4].ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            this.checkBox_reward_AwardCreateHome.Checked = this.SelectedReward.AwardCreateHome;
        }
        private void select_AwardItems(object sender, EventArgs e)
        {
            this.dataGridView_reward_item_m_AwardItems.Rows.Clear();
            int selectedIndex = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
            if (this.SelectedReward != null && selectedIndex > -1)
            {
                for (int num25 = 0; num25 < this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems.Length; num25++)
                {
                    string[] values = new string[]
					{
					    this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[num25].m_ulItemTemplId.ToString(),
                        Extensions.ItemName(this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[num25].m_ulItemTemplId),
					    this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[num25].m_bCommonItem.ToString(),
					    this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[num25].m_ulItemNum.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU")),
					    this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[num25].m_fProb.ToString(ProbValueFormat),
					    Extensions.SecondsToString(this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[num25].m_lPeriod)
					};
                    this.dataGridView_reward_item_m_AwardItems.Rows.Add(values);
                }
            }
        }
        #endregion

        #region Select Talk
        private void select_talk_proc(object sender, EventArgs e)
        {
            int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
            if (this.SelectedTask != null && selectedIndex > -1)
            {
                this.textBox_conversation_talk_proc_id_talk.Text = this.SelectedTask.talk_procs[selectedIndex].id_talk.ToString();
                this.textBox_conversation_talk_proc_text.Text = this.SelectedTask.talk_procs[selectedIndex].DialogText;
                this.listBox_conversation_windows.Items.Clear();
                for (int i = 0; i < this.SelectedTask.talk_procs[selectedIndex].num_window; i++)
                {
                    this.listBox_conversation_windows.Items.Add("[" + this.SelectedTask.talk_procs[selectedIndex].windows[i].id + "]" + Extensions.GetLocalization(414));
                }
                if (this.SelectedTask.talk_procs[selectedIndex].num_window != 0) this.listBox_conversation_windows.SelectedIndex = 0;
                else
                {
                    this.textBox_conversation_window_id.Clear();
                    this.textBox_conversation_window_id_parent.Clear();
                    this.textBox_conversation_window_talk_text.Clear();
                    this.listBox_conversation_options.Items.Clear();
                    this.comboBox_conversation_option_param.SelectedIndex = -1;
                    this.textBox_conversation_option_param.Clear();
                    this.textBox_conversation_option_param.Visible = false;
                    this.textBox_conversation_option_text.Clear();
                    this.label14.Visible = false;
                    this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                    this.textBox_conversation_option_id.Clear();
                }
            }
        }
        private void select_window(object sender, EventArgs e)
        {
            this.textBox_conversation_window_id.Clear();
            this.textBox_conversation_window_id_parent.Clear();
            this.textBox_conversation_window_talk_text.Clear();
            int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
            int index = this.listBox_conversation_windows.SelectedIndex;
            if (this.SelectedTask != null && selectedIndex > -1 && index > -1)
            {
                this.textBox_conversation_window_id.Text = this.SelectedTask.talk_procs[selectedIndex].windows[index].id.ToString();
                this.textBox_conversation_window_id_parent.Text = this.SelectedTask.talk_procs[selectedIndex].windows[index].id_parent.ToString();
                this.textBox_conversation_window_talk_text.Text = this.SelectedTask.talk_procs[selectedIndex].windows[index].talktext;
                this.listBox_conversation_options.Items.Clear();
                for (int i = 0; i < this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option; i++)
                {
                    this.listBox_conversation_options.Items.Add("[" + (i + 1) + "]" + Extensions.GetLocalization(416));
                }
                if (this.SelectedTask.talk_procs[selectedIndex].windows[index].num_option != 0) this.listBox_conversation_options.SelectedIndex = 0;
                else
                {
                    this.comboBox_conversation_option_param.SelectedIndex = -1;
                    this.textBox_conversation_option_param.Clear();
                    this.textBox_conversation_option_param.Visible = false;
                    this.textBox_conversation_option_text.Clear();
                    this.label14.Visible = false;
                    this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                    this.textBox_conversation_option_id.Clear();
                }
            }
        }

        private void select_option(object sender, EventArgs e)
        {
            this.comboBox_conversation_option_param.SelectedIndex = -1;
            this.textBox_conversation_option_param.Clear();
            this.textBox_conversation_option_param.Visible = false;
            this.textBox_conversation_option_text.Clear();
            this.label14.Visible = false;
            this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
            this.textBox_conversation_option_id.Clear();
            int selectedIndex = this.listBox_conversation_talk_procs.SelectedIndex;
            int index = this.listBox_conversation_windows.SelectedIndex;
            int num = this.listBox_conversation_options.SelectedIndex;
            if (this.SelectedTask != null && selectedIndex > -1 && index > -1 && num > -1)
            {
                int conversation_option_param = this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num].param;
                if (conversation_option_param < 0)
                {
                    switch (conversation_option_param)
                    {
                        case -2147483648:
                            this.comboBox_conversation_option_param.SelectedIndex = 0;
                            break;
                        case -2147483647:
                            this.comboBox_conversation_option_param.SelectedIndex = 1;
                            break;
                        case -2147483646:
                            this.comboBox_conversation_option_param.SelectedIndex = 2;
                            break;
                        case -2147483645:
                            this.comboBox_conversation_option_param.SelectedIndex = 3;
                            break;
                        case -2147483644:
                            this.comboBox_conversation_option_param.SelectedIndex = 4;
                            break;
                        case -2147483643:
                            this.comboBox_conversation_option_param.SelectedIndex = 5;
                            break;
                        case -2147483642:
                            this.comboBox_conversation_option_param.SelectedIndex = 6;
                            break;
                        case -2147483641:
                            this.comboBox_conversation_option_param.SelectedIndex = 7;
                            break;
                        case -2147483640:
                            this.comboBox_conversation_option_param.SelectedIndex = 8;
                            break;
                        case -2147483639:
                            this.comboBox_conversation_option_param.SelectedIndex = 9;
                            break;
                        case -2147483638:
                            this.comboBox_conversation_option_param.SelectedIndex = 10;
                            break;
                        case -2147483637:
                            this.comboBox_conversation_option_param.SelectedIndex = 11;
                            break;
                        case -2147483636:
                            this.comboBox_conversation_option_param.SelectedIndex = 12;
                            break;
                        case -2147483635:
                            this.comboBox_conversation_option_param.SelectedIndex = 13;
                            break;
                        case -2147483634:
                            this.comboBox_conversation_option_param.SelectedIndex = 14;
                            break;
                        case -2147483633:
                            this.comboBox_conversation_option_param.SelectedIndex = 15;
                            break;
                        case -2147483632:
                            this.comboBox_conversation_option_param.SelectedIndex = 16;
                            break;
                        case -2147483631:
                            this.comboBox_conversation_option_param.SelectedIndex = 17;
                            break;
                        case -2147483630:
                            this.comboBox_conversation_option_param.SelectedIndex = 18;
                            break;
                        case -2147483629:
                            this.comboBox_conversation_option_param.SelectedIndex = 19;
                            break;
                        case -2147483628:
                            this.comboBox_conversation_option_param.SelectedIndex = 20;
                            break;
                        case -2147483627:
                            this.comboBox_conversation_option_param.SelectedIndex = 21;
                            break;
                        case -2147483626:
                            this.comboBox_conversation_option_param.SelectedIndex = 22;
                            break;
                        case -2147483625:
                            this.comboBox_conversation_option_param.SelectedIndex = 23;
                            break;
                        case -2147483624:
                            this.comboBox_conversation_option_param.SelectedIndex = 24;
                            break;
                        case -2147483623:
                            this.comboBox_conversation_option_param.SelectedIndex = 25;
                            break;
                        case -2147483622:
                            this.comboBox_conversation_option_param.SelectedIndex = 26;
                            break;
                        case -2147483621:
                            this.comboBox_conversation_option_param.SelectedIndex = 27;
                            break;
                        case -2147483620:
                            this.comboBox_conversation_option_param.SelectedIndex = 28;
                            break;
                        case -2147483619:
                            this.comboBox_conversation_option_param.SelectedIndex = 29;
                            break;
                        case -2147483618:
                            this.comboBox_conversation_option_param.SelectedIndex = 30;
                            break;
                        case -2147483617:
                            this.comboBox_conversation_option_param.SelectedIndex = 31;
                            break;
                        case -2147483616:
                            this.comboBox_conversation_option_param.SelectedIndex = 32;
                            break;
                    }
                    this.textBox_conversation_option_param.Visible = false;
                    this.label14.Visible = false;
                    this.textBox_conversation_option_id.Size = new System.Drawing.Size(162, 20);
                }
                else
                {
                    this.comboBox_conversation_option_param.SelectedIndex = 33;
                    this.textBox_conversation_option_param.Visible = true;
                    this.label14.Visible = true;
                    this.textBox_conversation_option_id.Size = new System.Drawing.Size(51, 20);
                }
                this.textBox_conversation_option_param.Text = conversation_option_param.ToString();
                this.textBox_conversation_option_text.Text = this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num].optiontext;
                this.textBox_conversation_option_id.Text = this.SelectedTask.talk_procs[selectedIndex].windows[index].options[num].id.ToString();
            }
        }
        #endregion

        #region Click
        private void click_cloneTask(object sender, EventArgs e)
        {
            progressShow(Extensions.GetLocalization(503), 0, 0);
            if (this.treeView_tasks.SelectedNode != null)
            {
                try
                {
                    NewID = Convert.ToInt32(this.numericUpDown_NewID.Value);
                    ArrayList task_index_path = new ArrayList();
                    //TreeNode node = ((TreeView)this.contextMenuStrip_task.SourceControl).SelectedNode;
                    TreeNode node = this.treeView_tasks.SelectedNode;
                    while (node.Parent != null)
                    {
                        task_index_path.Add(node.Index);
                        node = node.Parent;
                    }
                    if (task_index_path.Count == 0)
                    {
                        ATaskTemplFixedData[] temp = new ATaskTemplFixedData[this.Tasks.Length + 1];
                        temp[0] = this.Tasks[node.Index].Clone();
                        Array.Copy(this.Tasks, 0, temp, 1, this.Tasks.Length);
                        this.Tasks = temp;
                        TaskEditor.BTasks = this.Tasks;
                        this.treeView_tasks.Nodes.Insert(0, (TreeNode)this.treeView_tasks.SelectedNode.Clone());
                        this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
                        if (this.checkBox_SetNewID.Checked)
                        {
                            this.treeView_tasks.BeginUpdate();
                            this.SetNewID(this.Tasks[0], this.treeView_tasks.SelectedNode, null, null);
                            this.treeView_tasks.EndUpdate();
                        }
                        //this.groupBox1.Text = Extensions.GetLocalization(479) + Tasks.Length;
                        this.textBox_m_ID.Text = this.SelectedTask.ID.ToString();
                        this.textBox_m_ulFirstChild.Text = this.SelectedTask.m_ulFirstChild.ToString();
                    }
                    else
                    {
                        ATaskTemplFixedData parent = this.Tasks[node.Index];
                        for (int i = task_index_path.Count - 1; i > 0; i--)
                        {
                            parent = parent.sub_quests[(int)task_index_path[i]];
                        }
                        parent.sub_quest_count++;
                        ATaskTemplFixedData[] temp2 = new ATaskTemplFixedData[parent.sub_quests.Length + 1];
                        Array.Copy(parent.sub_quests, 0, temp2, 0, parent.sub_quests.Length);
                        temp2[temp2.Length - 1] = parent.sub_quests[(int)task_index_path[0]].Clone();
                        parent.sub_quests = temp2;
                        if (this.checkBox_SetNewID.Checked) this.treeView_tasks.BeginUpdate();
                        this.treeView_tasks.SelectedNode.Parent.Nodes.Add((TreeNode)this.treeView_tasks.SelectedNode.Clone());
                        if (this.checkBox_SetNewID.Checked)
                        {
                            this.SetNewID0(parent.sub_quests[parent.sub_quests.Length - 1], this.treeView_tasks.SelectedNode.Parent.Nodes[this.treeView_tasks.SelectedNode.Parent.Nodes.Count - 1], parent, this.treeView_tasks.SelectedNode.Parent);
                            this.treeView_tasks.EndUpdate();
                        }
                        else 
                        {
                            parent.sub_quests[parent.sub_quests.Length - 1].m_ulParent = parent.ID;
                            if (parent.sub_quests.Length > 1)
                            {
                                parent.sub_quests[parent.sub_quests.Length - 1].m_ulPrevSibling = parent.sub_quests[parent.sub_quests.Length - 2].ID;
                                parent.sub_quests[parent.sub_quests.Length - 2].m_ulNextSibling = parent.sub_quests[parent.sub_quests.Length - 1].ID;
                            }
                        }
                        this.textBox_m_ulFirstChild.Text = this.SelectedTask.m_ulFirstChild.ToString();
                        this.textBox_m_ulNextSibling.Text = this.SelectedTask.m_ulNextSibling.ToString();
                    }
                    this.numericUpDown_NewID.Value = NewID;
                    this.listBox_conversation_talk_procs.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(460) + ex.Message);
                }
            }
            progressShow(Extensions.GetLocalization(499), 0, 0);
        }
        private void click_cloneTaskAsChild(object sender, EventArgs e)
        {
            progressShow(Extensions.GetLocalization(503), 0, 0);
            if (this.treeView_tasks.SelectedNode != null)
            {
                try
                {
                    NewID = Convert.ToInt32(this.numericUpDown_NewID.Value);
                    ArrayList task_index_path = new ArrayList();
                    //TreeNode node = ((TreeView)this.contextMenuStrip_task.SourceControl).SelectedNode;
                    TreeNode node = this.treeView_tasks.SelectedNode;
                    while (node.Parent != null)
                    {
                        task_index_path.Add(node.Index);
                        node = node.Parent;
                    }
                    if (task_index_path.Count == 0)
                    {
                        ATaskTemplFixedData parent = this.Tasks[node.Index];
                        for (int i = task_index_path.Count - 1; i > 0; i--)
                        {
                            parent = parent.sub_quests[(int)task_index_path[i]];
                        }
                        ATaskTemplFixedData[] temp2 = new ATaskTemplFixedData[parent.sub_quests.Length + 1];
                        Array.Copy(parent.sub_quests, 0, temp2, 0, parent.sub_quests.Length);
                        temp2[temp2.Length - 1] = this.Tasks[node.Index].Clone();
                        parent.sub_quest_count++;
                        parent.sub_quests = temp2;
                        if (this.checkBox_SetNewID.Checked) this.treeView_tasks.BeginUpdate();
                        this.treeView_tasks.SelectedNode.Nodes.Add((TreeNode)this.treeView_tasks.SelectedNode.Clone());
                        if (this.checkBox_SetNewID.Checked)
                        {
                            this.SetNewID0(parent.sub_quests[parent.sub_quests.Length - 1], this.treeView_tasks.SelectedNode.Nodes[this.treeView_tasks.SelectedNode.Nodes.Count - 1], parent, this.treeView_tasks.SelectedNode);
                            this.treeView_tasks.EndUpdate();
                        }
                        else
                        {
                            if (parent.sub_quests.Length == 1)
                            {
                                parent.m_ulFirstChild = parent.sub_quests[0].ID;
                                parent.sub_quests[0].m_ulPrevSibling = 0;
                            }
                            parent.sub_quests[parent.sub_quests.Length - 1].m_ulParent = parent.ID;
                            if (parent.sub_quests.Length > 1)
                            {
                                parent.sub_quests[parent.sub_quests.Length - 1].m_ulPrevSibling = parent.sub_quests[parent.sub_quests.Length - 2].ID;
                                parent.sub_quests[parent.sub_quests.Length - 2].m_ulNextSibling = parent.sub_quests[parent.sub_quests.Length - 1].ID;
                            }
                        }
                        this.textBox_m_ulFirstChild.Text = this.SelectedTask.m_ulFirstChild.ToString();
                    }
                    else
                    {
                        ATaskTemplFixedData parent = this.Tasks[node.Index];
                        ATaskTemplFixedData select = this.Tasks[node.Index];
                        for (int i = task_index_path.Count - 1; i > 0; i--)
                        {
                            parent = parent.sub_quests[(int)task_index_path[i]];
                        }
                        select = parent.sub_quests[(int)task_index_path[0]];
                        ATaskTemplFixedData[] temp2 = new ATaskTemplFixedData[select.sub_quests.Length + 1];
                        Array.Copy(select.sub_quests, 0, temp2, 0, select.sub_quests.Length);
                        temp2[temp2.Length - 1] = parent.sub_quests[(int)task_index_path[0]].Clone();
                        select.sub_quest_count++;
                        select.sub_quests = temp2;
                        if (this.checkBox_SetNewID.Checked) this.treeView_tasks.BeginUpdate();
                        this.treeView_tasks.SelectedNode.Nodes.Add((TreeNode)this.treeView_tasks.SelectedNode.Clone());
                        if (this.checkBox_SetNewID.Checked)
                        {
                            this.SetNewID0(select.sub_quests[select.sub_quests.Length - 1], this.treeView_tasks.SelectedNode.Nodes[this.treeView_tasks.SelectedNode.Nodes.Count - 1], select, this.treeView_tasks.SelectedNode);
                            this.treeView_tasks.EndUpdate();
                        }
                        else
                        {
                            if (select.sub_quests.Length == 1)
                            {
                                select.m_ulFirstChild = select.sub_quests[0].ID;
                                select.sub_quests[0].m_ulPrevSibling = 0;
                            }
                            select.sub_quests[select.sub_quests.Length - 1].m_ulParent = select.ID;
                            if (select.sub_quests.Length > 1)
                            {
                                select.sub_quests[select.sub_quests.Length - 1].m_ulPrevSibling = select.sub_quests[select.sub_quests.Length - 2].ID;
                                select.sub_quests[select.sub_quests.Length - 2].m_ulNextSibling = select.sub_quests[select.sub_quests.Length - 1].ID;
                            }
                        }
                        this.textBox_m_ulFirstChild.Text = this.SelectedTask.m_ulFirstChild.ToString();
                    }
                    this.treeView_tasks.SelectedNode.Expand();
                    this.numericUpDown_NewID.Value = NewID;
                    this.listBox_conversation_talk_procs.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(460) + ex.Message);
                }
            }
            progressShow(Extensions.GetLocalization(499), 0, 0);
        }

        private void SetNewID0(ATaskTemplFixedData CopyTask, TreeNode node, ATaskTemplFixedData parentTask, TreeNode parentNode)
        {
            int oldID = CopyTask.ID;
            int newID = NewID;
            CopyTask.ID = NewID;
            string m_szName = CopyTask.Name;
            if (m_szName.StartsWith("^"))
            {
                m_szName = m_szName.Substring(7);
            }
            node.Text = CopyTask.ID.ToString() + " - " + m_szName;
            CopyTask.m_ulParent = 0;
            CopyTask.m_ulPrevSibling = 0;
            CopyTask.m_ulNextSibling = 0;
            CopyTask.m_ulFirstChild = 0;
            if (parentNode != null)
            {
                if (parentTask.sub_quest_count > 0) parentTask.sub_quests[node.Index].m_ulParent = parentTask.ID;
                if (parentTask.sub_quest_count > 1 && node.Index != 0) parentTask.sub_quests[node.Index].m_ulPrevSibling = parentTask.sub_quests[node.Index - 1].ID;
                if (node.Index != 0) parentTask.sub_quests[node.Index - 1].m_ulNextSibling = CopyTask.ID;
                if (node.Index == 0) parentTask.m_ulFirstChild = CopyTask.ID;
            }
            NewID++;
            for (int i = 0; i < CopyTask.sub_quest_count; i++)
            {
                this.SetNewID(CopyTask.sub_quests[i], node.Nodes[i], CopyTask, node);
            }
            this.SetNewIDIntalk_procs(CopyTask, oldID, newID);
        }
        private void SetNewID(ATaskTemplFixedData CopyTask, TreeNode node, ATaskTemplFixedData parentTask, TreeNode parentNode)
        {
            int oldID = CopyTask.ID;
            int newID = NewID;
            CopyTask.ID = NewID;
            string m_szName = CopyTask.Name;
            if (m_szName.StartsWith("^"))
            {
                m_szName = m_szName.Substring(7);
            }
            node.Text = CopyTask.ID.ToString() + " - " + m_szName;
            CopyTask.m_ulParent = 0;
            CopyTask.m_ulPrevSibling = 0;
            CopyTask.m_ulNextSibling = 0;
            CopyTask.m_ulFirstChild = 0;
            //ArrayList listSelected = new ArrayList();
            //TreeNode selectedNode = node;
            if (parentNode != null)
            {
                /*while (selectedNode.Parent != null)
                {
                    listSelected.Add(selectedNode.Index);
                    selectedNode = selectedNode.Parent;
                }
                ATaskTemplFixedData parentTask = this.Tasks[selectedNode.Index];
                for (int i = listSelected.Count - 1; i > 0; i--)
                {
                    parentTask = parentTask.sub_quests[(int)listSelected[i]];
                }*/
                if (parentTask.sub_quest_count > 0) parentTask.sub_quests[node.Index].m_ulParent = parentTask.ID;
                if (parentTask.sub_quest_count > 1 && node.Index != 0) parentTask.sub_quests[node.Index].m_ulPrevSibling = parentTask.sub_quests[node.Index - 1].ID;
                if (node.Index != 0) parentTask.sub_quests[node.Index - 1].m_ulNextSibling = CopyTask.ID;
                if (node.Index == 0) parentTask.m_ulFirstChild = CopyTask.ID;
            }
            NewID++;
            for (int i = 0; i < CopyTask.sub_quest_count; i++)
            {
                this.SetNewID(CopyTask.sub_quests[i], node.Nodes[i], CopyTask, node);
            }
            if (parentNode != null) this.SetNewIDIntalk_procs(parentTask, oldID, newID);
            else this.SetNewIDIntalk_procs(CopyTask, oldID, newID);
        }
        private void SetNewIDIntalk_procs(ATaskTemplFixedData CopyTask, int oldID, int newID)
        {
            for (int i = 0; i < CopyTask.talk_procs.Length; i++)
            {
                for (int k = 0; k < CopyTask.talk_procs[i].windows.Length; k++)
                {
                    for (int l = 0; l < CopyTask.talk_procs[i].windows[k].options.Length; l++)
                    {
                        if (CopyTask.talk_procs[i].windows[k].options[l].id == oldID)
                            CopyTask.talk_procs[i].windows[k].options[l].id = newID;
                    }
                }
            }
            for (int i = 0; i < CopyTask.sub_quest_count; i++)
            {
                this.SetNewIDIntalk_procs(CopyTask.sub_quests[i], oldID, newID);
            }
        }
        private void click_creatureBuilder(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.CurrentDirectory;
            save.FileName = "MonsCtrlList";
            save.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    //this.Cursor = Cursors.AppStarting;
                    StreamWriter sw = new StreamWriter(save.FileName, false, Encoding.Unicode);
                    for (int i = this.Tasks.Length - 1; i > -1; i--)
                    {
                        this.save_CreatureBuilder(this.Tasks[i], sw);
                    }
                    sw.Close();
                    //this.Cursor = Cursors.Default;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(461));
                    //this.Cursor = Cursors.Default;
                }
            }
        }
        private void click_SkillList(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.CurrentDirectory;
            save.FileName = "SkillList";
            save.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    //this.Cursor = Cursors.AppStarting;
                    StreamWriter sw = new StreamWriter(save.FileName, false, Encoding.Unicode);
                    for (int i = this.Tasks.Length - 1; i > -1; i--)
                    {
                        this.save_SkillList(this.Tasks[i], sw);
                    }
                    sw.Close();
                    //this.Cursor = Cursors.Default;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(461));
                    //this.Cursor = Cursors.Default;
                }
            }
        }
        private void click_Test(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.CurrentDirectory;
            save.FileName = "TestList";
            save.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    //this.Cursor = Cursors.AppStarting;
                    StreamWriter sw = new StreamWriter(save.FileName, false, Encoding.Unicode);
                    for (int i = this.Tasks.Length - 1; i > -1; i--)
                    {
                        this.save_Test(this.Tasks[i], sw);
                    }
                    sw.Close();
                    //this.Cursor = Cursors.Default;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(461));
                    //this.Cursor = Cursors.Default;
                }
            }
        }
        private void click_deleteTask(object sender, EventArgs e)
        {
            if (this.Tasks != null)
            {
                if(this.treeView_tasks.SelectedNodes.Count == 0) { JMessageBox.Show(this, "Please select tasks to delete!"); return; }
                //this.Cursor = Cursors.AppStarting;
                progressShow("Deleting ...", 0, this.treeView_tasks.SelectedNodes.Count);
                for (int x = 0; x < this.treeView_tasks.SelectedNodes.Count; x++)
                {
                    try
                    {
                       // ArrayList task_index_path = new ArrayList();
                       // TreeNode node = (TreeNode)this.treeView_tasks.SelectedNodes[x];
                        ArrayList task_index_path = new ArrayList();
                        TreeNode node = (TreeNode)this.treeView_tasks.SelectedNodes[x];
                        while (node.Parent != null)
                        {
                            task_index_path.Add(node.Index);
                            node = node.Parent;
                        }
                        if (task_index_path.Count == 0)
                        {
                            ATaskTemplFixedData[] temp = new ATaskTemplFixedData[this.Tasks.Length - 1];
                            Array.Copy(this.Tasks, 0, temp, 0, node.Index);
                            Array.Copy(this.Tasks, node.Index + 1, temp, node.Index, this.Tasks.Length - 1 - node.Index);
                            this.Tasks = temp;
                        }
                        else
                        {
                            ATaskTemplFixedData parent = this.Tasks[node.Index];
                            for (int i = task_index_path.Count - 1; i > 0; i--)
                            {
                                parent = parent.sub_quests[(int)task_index_path[i]];
                            }
                            parent.sub_quest_count--;
                            ATaskTemplFixedData[] temp2 = new ATaskTemplFixedData[parent.sub_quests.Length - 1];
                            Array.Copy(parent.sub_quests, 0, temp2, 0, (int)task_index_path[0]);
                            Array.Copy(parent.sub_quests, (int)task_index_path[0] + 1, temp2, (int)task_index_path[0], parent.sub_quests.Length - 1 - (int)task_index_path[0]);
                            parent.sub_quests = temp2;

                            if (parent.sub_quest_count == 0) parent.m_ulFirstChild = 0;
                            else
                            {
                                for (int i = 0; i < parent.sub_quest_count; i++)
                                {
                                    if (i != 0) parent.sub_quests[i].m_ulPrevSibling = parent.sub_quests[i - 1].ID;
                                    else parent.sub_quests[i].m_ulPrevSibling = 0;
                                    if (i != parent.sub_quest_count - 1) parent.sub_quests[i].m_ulNextSibling = parent.sub_quests[i + 1].ID;
                                    else parent.sub_quests[i].m_ulNextSibling = 0;
                                }
                            }
                        }
                        ((TreeNode)this.treeView_tasks.SelectedNodes[x]).Remove(); //.RemoveAt(node.Index);
                    }
                    catch (Exception ex)
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(460) + ex.Message);
                    }
                    progressShow("Deleting ...", x, this.treeView_tasks.SelectedNodes.Count);
                   // Application.DoEvents();
                }
            }
            //this.treeView_tasks.RemoveAll();
            //this.toolStripProgressBar_Progress.Value = 0;
            //this.Cursor = Cursors.Default;
            progressShow("Ready ...", 0, 0);
        }
        private void click_deleteTasks(object sender, EventArgs e)
        {
            int length = 0;
            for (int i = 0; i < 670; i++)
            {
                ATaskTemplFixedData[] destinationArray = new ATaskTemplFixedData[this.Tasks.Length - 1];
                Array.Copy(this.Tasks, 0, destinationArray, 0, length);
                Array.Copy(this.Tasks, length + 1, destinationArray, length, this.Tasks.Length - 1 - length);
                this.Tasks = destinationArray;
                TaskEditor.BTasks = this.Tasks;
                this.treeView_tasks.Nodes[length].Remove();
            }
        }
        private void click_developer_search(object sender, EventArgs e)
        {
            if (this.Tasks != null)
            {
                string message = this.developer_scan(this.Tasks);
                new DebugWindow(Extensions.GetLocalization(462), message);
                return;
            }
            JMessageBox.Show(this, Extensions.GetLocalization(463));
        }
        private void click_ExportAllTask(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK && Directory.Exists(dialog.SelectedPath))
            {
                //this.Cursor = Cursors.AppStarting;
                progressShow(Extensions.GetLocalization(505), 0, 0);
                //for (int i = 0; i < this.Tasks.Length; i++)
               // {
                    /*
                    this.SelectedTask = this.Tasks[i];
                    FileStream output = new FileStream(string.Concat(new object[]
					{
						dialog.SelectedPath,
						"\\",
						this.SelectedTask.ID,
						".data"
					}), FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(output);
                    int num2 = version;
                    bw.Write(0);
                    bw.Write(num2);
                    bw.Write(1);
                    bw.Write(16);
                    this.SelectedTask.Save(num2, bw);
                    progressShow(Extensions.GetLocalization(505), i, this.Tasks.Length);
                    bw.Close();
                    output.Close();
                    */
                    try
                    {
                        //this.Cursor = Cursors.AppStarting;
                        
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            List<byte[]> export = new List<byte[]>();
                           //// Application.DoEvents();
                            this.SelectedTask = this.Tasks[i];
                            MemoryStream output = new MemoryStream();
                            output.Position = 0;
                            BinaryWriter bw = new BinaryWriter(output);
                            int num2 = version;
                            bw.Write(0);
                            bw.Write(num2);
                            bw.Write(1);
                            bw.Write(16);
                            this.SelectedTask.Save(num2, bw);
                            bw.Close();
                            export.Add(output.ToArray());
                            progressShow(Extensions.GetLocalization(513), i, this.Tasks.Length);


                            FileStream outputF = new FileStream(string.Concat(new object[]
                            {
                            dialog.SelectedPath,
                            "\\",
                            this.SelectedTask.ID,
                            ".gqe"
                            }), FileMode.Create, FileAccess.Write);
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(outputF, export);
                            outputF.Close();
                        }
                        //this.Cursor = Cursors.Default;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(464));
                        //this.Cursor = Cursors.Default;
                    }


                //}
               // this.toolStripProgressBar_Progress.Value = 0;
                //this.Cursor = Cursors.Default;
                progressShow(Extensions.GetLocalization(499), 0, 0);
            }
        }
        
        private void click_ImportMultipleTask_FirstNode(object sender, EventArgs e)
        {
           // this.toolStripStatusLabel_Message.Text = Extensions.GetLocalization(507);
            if (this.Tasks != null)
            {
                string[] fileNames = null;
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "Task File (*.gqe)|*.data|All Files (*.*)|*.*",
                    Multiselect = true
                };
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                LockedSelecting = true;
                fileNames = dialog.FileNames;
                NewID = Convert.ToInt32(this.numericUpDown_NewID.Value);
                if (this.checkBox_SetNewID.Checked) this.treeView_tasks.BeginUpdate();
                for (int index = 0; index < fileNames.Length; index++)
                {
                    progressShow(Extensions.GetLocalization(507), index, fileNames.Length);
                    string path = fileNames[index];
                    try
                    {
                        using (Stream file = File.Open(path, FileMode.Open))
                        {

                            BinaryFormatter bf = new BinaryFormatter();
                            List<byte[]> obj = (List<byte[]>)bf.Deserialize(file);

                            for (int i = 0; i < obj.Count; i++)
                            {
                                MemoryStream test = new MemoryStream(obj[i]);
                                importMs(test);
                                // Application.DoEvents();
                                progressShow("Exporting...", i, obj.Count);
                            }

                            file.Close();
                        }
                    }
                    catch { }

                }
                LockedSelecting = false;
                this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
                if (this.checkBox_SetNewID.Checked) this.treeView_tasks.EndUpdate();
                progressShow(Extensions.GetLocalization(499), 0, 0);
                this.numericUpDown_NewID.Value = NewID;
                this.listBox_conversation_talk_procs.SelectedIndex = 0;
            }
        }
        private void click_ImportMultipleTask_LastNode(object sender, EventArgs e)
        {
            LockedSelecting = true;
            string[] fileNames = null;
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Task File (*.data)|*.data|All Files (*.*)|*.*",
                Multiselect = true
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            fileNames = dialog.FileNames;
            NewID = Convert.ToInt32(this.numericUpDown_NewID.Value);
            if (this.checkBox_SetNewID.Checked) this.treeView_tasks.BeginUpdate();
            for (int index = 0; index < fileNames.Length; index++)
            {
                progressShow(Extensions.GetLocalization(507), index, fileNames.Length);
                string path = fileNames[index];
                try
                {
                    //this.Cursor = Cursors.AppStarting;
                    FileStream input = File.OpenRead(path);
                    BinaryReader binaryStream = new BinaryReader(input);
                    binaryStream.ReadInt32();
                    int version = binaryStream.ReadInt32();
                    int num4 = binaryStream.ReadInt32();
                    ATaskTemplFixedData[] destinationArray = new ATaskTemplFixedData[this.Tasks.Length + 1];
                    destinationArray[destinationArray.Length - 1] = new ATaskTemplFixedData(version, binaryStream, num4 * 4 + 12, this.treeView_tasks.Nodes);
                    Array.Copy(this.Tasks, 0, destinationArray, 0, this.Tasks.Length);
                    this.Tasks = destinationArray;
                    TaskEditor.BTasks = this.Tasks;
                    binaryStream.Close();
                    input.Close();
                    this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[this.treeView_tasks.Nodes.Count - 1];
                    if (this.checkBox_SetNewID.Checked)
                    {
                        for (int i = 0; i < Tasks[this.treeView_tasks.Nodes.Count - 1].talk_procs.Length; i++)
                        {
                            for (int k = 0; k < Tasks[this.treeView_tasks.Nodes.Count - 1].talk_procs[i].windows.Length; k++)
                            {
                                for (int l = 0; l < Tasks[this.treeView_tasks.Nodes.Count - 1].talk_procs[i].windows[k].options.Length; l++)
                                {
                                    if (Tasks[this.treeView_tasks.Nodes.Count - 1].talk_procs[i].windows[k].options[l].id == this.Tasks[this.treeView_tasks.Nodes.Count - 1].ID)
                                        Tasks[this.treeView_tasks.Nodes.Count - 1].talk_procs[i].windows[k].options[l].id = NewID;
                                }
                            }
                        }
                        int oldID = this.Tasks[this.treeView_tasks.Nodes.Count - 1].ID;
                        int newID = NewID;
                        this.Tasks[this.treeView_tasks.Nodes.Count - 1].ID = NewID;
                        string m_szName = Tasks[this.treeView_tasks.Nodes.Count - 1].Name;
                        if (m_szName.StartsWith("^"))
                        {
                            m_szName = m_szName.Substring(7);
                        }
                        this.treeView_tasks.SelectedNode.Text = Tasks[this.treeView_tasks.Nodes.Count - 1].ID.ToString() + " - " + m_szName;
                        NewID++;
                        for (int i = 0; i < Tasks[this.treeView_tasks.Nodes.Count - 1].sub_quest_count; i++)
                        {
                            this.SetNewID(this.Tasks[this.treeView_tasks.Nodes.Count - 1].sub_quests[i], this.treeView_tasks.SelectedNode.Nodes[i], this.Tasks[this.treeView_tasks.Nodes.Count - 1], this.treeView_tasks.SelectedNode);
                            this.SetNewIDIntalk_procs(this.Tasks[this.treeView_tasks.Nodes.Count - 1].sub_quests[i], oldID, newID);
                        }
                        this.textBox_m_ulParent.Text = this.SelectedTask.m_ulParent.ToString();
                        this.textBox_m_ulPrevSibling.Text = this.SelectedTask.m_ulPrevSibling.ToString();
                        this.textBox_m_ulNextSibling.Text = this.SelectedTask.m_ulNextSibling.ToString();
                        this.textBox_m_ulFirstChild.Text = this.SelectedTask.m_ulFirstChild.ToString();
                    }
                    //this.groupBox1.Text = Extensions.GetLocalization(479) + Tasks.Length;
                    //this.Cursor = Cursors.Default;
                    goto IL_43;
                }
                catch
                {
                    JMessageBox.Show(this, Extensions.GetLocalization(466));
                    //this.Cursor = Cursors.Default;
                    goto IL_43;
                }
            IL_43: ;
            }
            if (this.checkBox_SetNewID.Checked) this.treeView_tasks.EndUpdate();
            LockedSelecting = false;
            this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[this.treeView_tasks.Nodes.Count - 1];
            progressShow(Extensions.GetLocalization(499), 0, 0);
            this.numericUpDown_NewID.Value = NewID;
            this.listBox_conversation_talk_procs.SelectedIndex = 0;
        }
        private void progressShow(String value, int min, int max)
        {
            if(progress_bar2 != null)
            {
                progress_bar2(value, min, max);
            }
        }
        private void click_load(object sender, EventArgs e)
        {
            LockedSelecting = true;
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Tasks File (*.data)|*.data|All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                GC.Collect();
                progressShow(Extensions.GetLocalization(500), 0, 0);
                try
                {
                    this.comboBox_m_iPremForce.Items.Clear();
                    this.comboBox_m_iPremForce.Items.Add(0 + "_NO");
                    this.comboBox_m_iPremForce.Items.Add(-1 + "_ALL");
                    this.comboBox_m_iPremForce.Items.Add(1004 + "_Corona");
                    this.comboBox_m_iPremForce.Items.Add(1005 + "_Shroud");
                    this.comboBox_m_iPremForce.Items.Add(1006 + "_Luminance");

                    if (TaskEditor.eLC != null)
                    {
                        foreach (ItemDupe data in TaskEditor.eLC.FORCES.Values)
                        {
                            if (data.itemId != 1004 && data.itemId != 1005 && data.itemId != 1006)
                                this.comboBox_m_iPremForce.Items.Add(data.itemId + "_" + data.name);
                        }
                    }
                    //this.Cursor = Cursors.WaitCursor;
                    this.treeView_tasks.Nodes.Clear();
                    this.treeView_tasks.BeginUpdate();
                    //this.treeView_tasks.CheckBoxes = true;
                    FileStream input = File.OpenRead(dialog.FileName);

                    BinaryReader binaryStream = new BinaryReader(input);
                    binaryStream.ReadInt32();
                    int m_Version = binaryStream.ReadInt32();
                    if (!TaskEditor.versions.Contains(m_Version))
                    {
                        binaryStream.Close();
                        input.Close();
                        this.treeView_tasks.EndUpdate();
                        //this.Cursor = Cursors.Default;
                        JMessageBox.Show(this, Extensions.GetLocalization(470) + m_Version.ToString());
                        progressShow(Extensions.GetLocalization(499), 0, 0);
                    }
                    else
                    {
                        tmpNewID = 0;
                        version = m_Version;
                        int m_uTaskCount = binaryStream.ReadInt32();
                        int[] numArray = new int[m_uTaskCount];
                        for (int index = 0; index < m_uTaskCount; index++)
                        {
                            numArray[index] = binaryStream.ReadInt32();
                        }
                        this.Tasks = new ATaskTemplFixedData[m_uTaskCount];
                        TaskEditor.BTasks = this.Tasks;
                       // Application.DoEvents();
                        int count = 0;
                        int maxCount = 100;
                        for (int num4 = 0; num4 < m_uTaskCount; num4++)
                        {
                           //// Application.DoEvents();
                            this.Tasks[num4] = new ATaskTemplFixedData(m_Version, binaryStream, numArray[num4], this.treeView_tasks.Nodes);
                            if (count > maxCount)
                            {
                               // Application.DoEvents();
                                progressShow(Extensions.GetLocalization(499), num4, m_uTaskCount);
                                count = 0;
                            }
                            count++;
                        }
                        binaryStream.Close();
                        input.Close();
                        this.treeView_tasks.EndUpdate();
                        this.comboBox_SaveVersion.Text = m_Version.ToString();
                        this.LoadedTask = true;
                        path = dialog.FileName;
                      //  if (LoadedTask == true && LoadedElements == true) this.Text = String.Format(Extensions.GetLocalization(471), path + " || " + lElementsPath);
                      //  else this.Text = String.Format(Extensions.GetLocalization(471), path);
 
                        //this.Cursor = Cursors.Default;
                        LockedSelecting = false;
                        this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
                        this.listBox_conversation_talk_procs.SelectedIndex = 0;
                        this.numericUpDown_NewID.Value = tmpNewID + 1;
                        //this.groupBox1.Text = Extensions.GetLocalization(479) + m_uTaskCount;
                        progressShow(Extensions.GetLocalization(499), 0, 0);
                        lElementsPath = ElementsEditor.configs.lastElementsLocation;
                        SelectItemIdWindow_SelectedListIndex = 0;
                        SelectItemIdWindow_SelectedItemIndex = 0;
                        SelectMonsterIdWindow_SelectedItemIndex = 0;
                        SelectNPCIdWindow_SelectedItemIndex = 0;
                        SelectMonsterNPCMineIdWindow_SelectedListIndex = 0;
                        SelectMonsterNPCMineIdWindow_SelectedItemIndex = 0;
                        SelectTitleIdWindow_SelectedItemIndex = 0;
                        SelectHomeItemIdWindow_SelectedItemIndex = 0;

                        progressShow("Ready", 0, 0);
                        pathLabel.Text = path;
                        version_label.Text = m_Version.ToString();
                        jLabel1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = jPictureBox2.Visible = true;
                    }
                }
                catch (Exception exception)
                {
                    this.treeView_tasks.EndUpdate();
                    //this.Cursor = Cursors.Default;
                    JMessageBox.Show(this, String.Format(Extensions.GetLocalization(475), exception.Message));
                }
                
            }
        }
        private void click_save(object sender, EventArgs e)
        {
            if (this.Tasks != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    FileName = "tasks",
                    Filter = "Tasks File (*.data)|*.data|All Files (*.*)|*.*"
                };
                if (dialog.ShowDialog() == DialogResult.OK && dialog.FileName != "")
                {

                    try
                    {
                        //this.Cursor = Cursors.WaitCursor;
                        int num4 = -1819966623;
                        int m_Version = Convert.ToInt32(this.comboBox_SaveVersion.Text);
                        FileStream output = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(output);
                        bw.Write(num4);
                        bw.Write(m_Version);
                        bw.Write(this.Tasks.Length);
                        int[] numArray = new int[this.Tasks.Length];
                        bw.Write(new byte[this.Tasks.Length * 4]);

                        for (int index = 0; index < this.Tasks.Length; index++)
                        {
                           // Application.DoEvents();
                            numArray[index] = (int)bw.BaseStream.Position;
                            this.Tasks[index].Save(m_Version, bw);
                            progressShow(Extensions.GetLocalization(501), index, this.Tasks.Length);

                        }
                        bw.BaseStream.Position = 12L;
                        for (int num6 = 0; num6 < numArray.Length; num6++)
                        {
                            bw.Write(numArray[num6]);
                        }
                        bw.Close();
                        output.Close();

                        //this.Cursor = Cursors.Default;
                      
                    }
                    catch (Exception exception)
                    {
                        //this.Cursor = Cursors.Default;
                        JMessageBox.Show(this, String.Format(Extensions.GetLocalization(492), exception.Message));
                    }
                }
            }
            progressShow(Extensions.GetLocalization(499), 0, 0);
        }
        private void click_save2(object sender, EventArgs e)
        {
            if (this.Tasks != null)
            {
                {
                    try
                    {
                        //this.Cursor = Cursors.WaitCursor;
                        int num4 = -1819966623;                     
                        FileStream output = new FileStream(path, FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(output);
                        bw.Write(num4);
                        bw.Write(version);
                        bw.Write(this.Tasks.Length);
                        int[] numArray = new int[this.Tasks.Length];
                        bw.Write(new byte[this.Tasks.Length * 4]);
                        for (int index = 0; index < this.Tasks.Length; index++)
                        {
                           // Application.DoEvents();
                            numArray[index] = (int)bw.BaseStream.Position;
                            this.Tasks[index].Save(version, bw);
                            progressShow(Extensions.GetLocalization(501), index, this.Tasks.Length);
                        }
                        bw.BaseStream.Position = 12L;
                        for (int num6 = 0; num6 < numArray.Length; num6++)
                        {
                            bw.Write(numArray[num6]);
                        }
                        bw.Close();
                        output.Close();
                        //this.Cursor = Cursors.Default;
                        progressShow(Extensions.GetLocalization(499), 0, 0);
                    }
                    catch (Exception exception)
                    {
                        //this.Cursor = Cursors.Default;
                        JMessageBox.Show(this, String.Format(Extensions.GetLocalization(492), exception.Message));
                    }
                    progressShow(Extensions.GetLocalization(499), 0, 0);
                }
            }
        }
        private void click_search(object sender, EventArgs e)
        {
            if (this.treeView_tasks.Nodes.Count > 0)
            {
                int[] indices = this.next_treeNode();
                while (indices.Length > 0)
                {
                    if (this.search(indices))
                    {
                        return;
                    }
                    indices = this.next_task(indices);
                }
                this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
                indices = this.next_treeNode();
                while (indices.Length > 0)
                {
                    if (this.search(indices))
                    {
                        return;
                    }
                    indices = this.next_task(indices);
                }
                JMessageBox.Show(this, Extensions.GetLocalization(493));
            }
        }
        private void click_split(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Tasks File (*.data)|*.data|All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                FolderBrowserDialog dialog2 = new FolderBrowserDialog();
                if (dialog2.ShowDialog() == DialogResult.OK && Directory.Exists(dialog2.SelectedPath))
                {
                    progressShow(Extensions.GetLocalization(513), 0, 0);
                    try
                    {
                        //this.Cursor = Cursors.WaitCursor;

                        FileStream input = File.OpenRead(dialog.FileName);
                        BinaryReader reader = new BinaryReader(input);
                        int tmp = reader.ReadInt32();
                        int ver = reader.ReadInt32();
                        int num4 = reader.ReadInt32();
                        int[] numArray = new int[num4];
                        for (int index = 0; index < num4; index++)
                        {
                            numArray[index] = reader.ReadInt32();
                        }
                        for (int num5 = 0; num5 < num4; num5++)
                        {
                            reader.BaseStream.Position = (long)numArray[num5];
                            int num6 = reader.ReadInt32();
                            reader.BaseStream.Position = (long)numArray[num5];
                            FileStream output = new FileStream(string.Concat(new object[]
							{
								dialog2.SelectedPath,
								"\\",
								num6,
								".data"
							}), FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(output);
                            int count = (int)(reader.BaseStream.Length - 1L) - numArray[num5];
                            if (num5 < num4 - 1)
                            {
                                count = numArray[num5 + 1] - numArray[num5];
                            }
                            writer.Write(tmp);
                            writer.Write(ver);
                            writer.Write(1);
                            writer.Write(16);
                            writer.Write(reader.ReadBytes(count));
                            writer.Close();
                            output.Close();
                        }
                        reader.Close();
                        input.Close();

                        //this.Cursor = Cursors.Default;
                        progressShow(Extensions.GetLocalization(499), 0, 0);
                    }
                    catch
                    {

                        //this.Cursor = Cursors.Default;
                        JMessageBox.Show(this, Extensions.GetLocalization(494));
                    }
                }
            }
        }
        private void click_expandAllSelectedNode(object sender, EventArgs e)
        {
            if (this.treeView_tasks.SelectedNode != null) this.treeView_tasks.SelectedNode.ExpandAll();
        }
        private void click_collapseAllSelectedNode(object sender, EventArgs e)
        {
            if (this.treeView_tasks.SelectedNode != null) this.treeView_tasks.SelectedNode.Collapse();
        }
        private void click_expandAllNodes(object sender, EventArgs e)
        {
           // this.toolStripStatusLabel_Message.Text = Extensions.GetLocalization(508);
            progressShow(Extensions.GetLocalization(508), 0, 0);
            this.treeView_tasks.BeginUpdate();
            this.treeView_tasks.ExpandAll();
            this.treeView_tasks.EndUpdate();
            progressShow(Extensions.GetLocalization(499), 0, 0);
        }
        private void click_collapseAllNodes(object sender, EventArgs e)
        {
           // this.toolStripStatusLabel_Message.Text = Extensions.GetLocalization(509);
            progressShow(Extensions.GetLocalization(509), 0, 0);
            this.treeView_tasks.BeginUpdate();
            this.treeView_tasks.CollapseAll();
            this.treeView_tasks.EndUpdate();
            progressShow(Extensions.GetLocalization(499), 0, 0);
        }
        private void click_toTop(object sender, EventArgs e)
        {
            if (this.SelectedTask != null)
            {
                this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
            }
        }
        #endregion

        #region Functions

        #region Developer Search
        private string developer_check_condition(ATaskTemplFixedData task)
        {
            int str = this.toolStripComboBox_developer_search.SelectedIndex;
            if (str == 0 && task.TowerTask)
            {
                return task.ID.ToString();
            }
            if (str == 1 && task.m_bDisplayInTitleTaskUI)
            {
                return task.ID.ToString();
            }
            if (str == 2 && task.m_bGM)
            {
                return task.ID.ToString();
            }
            if (str == 3 && task.m_bShieldUser)
            {
                return task.ID.ToString();
            }
            if (str == 4)
            {
                if (task.m_ulTeamMemsWanted != 0)
                {
                    return task.ID.ToString();
                }
            }
            if (str == 5 && task.m_bPremCheckForce)
            {
                return task.ID.ToString();
            }
            if (str == 6)
            {
                if (task.m_ulPlayerWanted != 0)
                {
                    return task.ID.ToString();
                }
            }
            if (str == 7)
            {
                if (task.m_ulExpCnt != 0)
                {
                    return task.ID.ToString();
                }
            }
            if (str == 8)
            {
                if (task.m_Award_S.m_ulSummonedMonsters != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_ulSummonedMonsters != 0)
                {
                    return task.ID.ToString();
                }
                for (int l = 0; l < task.m_AwByRatio_S.m_Awards.Length; l++)
                {
                    if (task.m_AwByRatio_S.m_Awards[l].m_ulSummonedMonsters != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int l = 0; l < task.m_AwByRatio_F.m_Awards.Length; l++)
                {
                    if (task.m_AwByRatio_F.m_Awards[l].m_ulSummonedMonsters != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 9)
            {
                string returnx = "";
                if (task.m_Award_S.m_ulDividend != 0)
                {
                    returnx += task.ID + " - Type: Award Success, Cant:"+ task.m_Award_S.m_ulDividend;
                }
                if (task.m_Award_F.m_ulDividend != 0)
                {
                    returnx += task.ID + " - Type: Award Faill, Cant:" + task.m_Award_S.m_ulDividend;
                }
                for (int k = 0; k < task.m_AwByRatio_S.m_Awards.Length; k++)
                {
                    if (task.m_AwByRatio_S.m_Awards[k].m_ulDividend != 0)
                    {
                        returnx += task.ID + " - Type: Awrd By Ratio, Cant:" + task.m_AwByRatio_S.m_Awards[k].m_ulDividend;
                    }
                }
                for (int k = 0; k < task.m_AwByRatio_F.m_Awards.Length; k++)
                {
                    if (task.m_AwByRatio_F.m_Awards[k].m_ulDividend != 0)
                    {
                        returnx += task.ID + " - Type: Awrd By Ratio, Cant:" + task.m_AwByRatio_F.m_Awards[k].m_ulDividend;
                    }
                }
                return returnx;
            }
            if (str == 10)
            {
                if (task.m_Award_S.m_ulPQRankingAwardCnt != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_ulPQRankingAwardCnt != 0)
                {
                    return task.ID.ToString();
                }
                for (int m = 0; m < task.m_AwByRatio_S.m_Awards.Length; m++)
                {
                    if (task.m_AwByRatio_S.m_Awards[m].m_ulPQRankingAwardCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int m = 0; m < task.m_AwByRatio_F.m_Awards.Length; m++)
                {
                    if (task.m_AwByRatio_F.m_Awards[m].m_ulPQRankingAwardCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 11)
            {
                if (task.m_Award_S.m_ulHistoryChangeCnt != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_ulHistoryChangeCnt != 0)
                {
                    return task.ID.ToString();
                }
                for (int num5 = 0; num5 < task.m_AwByRatio_S.m_Awards.Length; num5++)
                {
                    if (task.m_AwByRatio_S.m_Awards[num5].m_ulHistoryChangeCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int num5 = 0; num5 < task.m_AwByRatio_F.m_Awards.Length; num5++)
                {
                    if (task.m_AwByRatio_F.m_Awards[num5].m_ulHistoryChangeCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 12)
            {
                if (task.m_Award_S.m_ulExpCnt != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_ulExpCnt != 0)
                {
                    return task.ID.ToString();
                }
                for (int num5 = 0; num5 < task.m_AwByRatio_S.m_Awards.Length; num5++)
                {
                    if (task.m_AwByRatio_S.m_Awards[num5].m_ulExpCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int num5 = 0; num5 < task.m_AwByRatio_F.m_Awards.Length; num5++)
                {
                    if (task.m_AwByRatio_F.m_Awards[num5].m_ulExpCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 13)
            {
                if (task.m_Award_S.m_ulTaskCharCnt != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_ulTaskCharCnt != 0)
                {
                    return task.ID.ToString();
                }
                for (int num6 = 0; num6 < task.m_AwByRatio_S.m_Awards.Length; num6++)
                {
                    if (task.m_AwByRatio_S.m_Awards[num6].m_ulTaskCharCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int num6 = 0; num6 < task.m_AwByRatio_F.m_Awards.Length; num6++)
                {
                    if (task.m_AwByRatio_F.m_Awards[num6].m_ulTaskCharCnt != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 14)
            {
                if (task.m_Award_S.m_iForceContribution != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_iForceContribution != 0)
                {
                    return task.ID.ToString();
                }
                for (int j = 0; j < task.m_AwByRatio_S.m_Awards.Length; j++)
                {
                    if (task.m_AwByRatio_S.m_Awards[j].m_iForceContribution != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int j = 0; j < task.m_AwByRatio_F.m_Awards.Length; j++)
                {
                    if (task.m_AwByRatio_F.m_Awards[j].m_iForceContribution != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 15)
            {
                if (task.m_Award_S.m_iForceReputation != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_iForceReputation != 0)
                {
                    return task.ID.ToString();
                }
                for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                {
                    if (task.m_AwByRatio_S.m_Awards[i].m_iForceReputation != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                {
                    if (task.m_AwByRatio_F.m_Awards[i].m_iForceReputation != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 16)
            {
                if (task.m_Award_S.m_iForceActivity != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_iForceActivity != 0)
                {
                    return task.ID.ToString();
                }
                for (int num7 = 0; num7 < task.m_AwByRatio_S.m_Awards.Length; num7++)
                {
                    if (task.m_AwByRatio_S.m_Awards[num7].m_iForceActivity != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int num7 = 0; num7 < task.m_AwByRatio_F.m_Awards.Length; num7++)
                {
                    if (task.m_AwByRatio_F.m_Awards[num7].m_iForceActivity != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 17)
            {
                if (task.m_Award_S.m_iForceSetRepu != 0)
                {
                    return task.ID.ToString();
                }
                if (task.m_Award_F.m_iForceSetRepu != 0)
                {
                    return task.ID.ToString();
                }
                for (int num8 = 0; num8 < task.m_AwByRatio_S.m_Awards.Length; num8++)
                {
                    if (task.m_AwByRatio_S.m_Awards[num8].m_iForceSetRepu != 0)
                    {
                        return task.ID.ToString();
                    }
                }
                for (int num8 = 0; num8 < task.m_AwByRatio_F.m_Awards.Length; num8++)
                {
                    if (task.m_AwByRatio_F.m_Awards[num8].m_iForceSetRepu != 0)
                    {
                        return task.ID.ToString();
                    }
                }
            }
            if (str == 18 && task.m_AwByRatio_S.m_Awards.Length > 0)
            {
                return task.ID.ToString();
            }
            return "";
        }
        private string developer_scan(ATaskTemplFixedData[] tasks)
        {
            string str = "";
            for (int i = 0; i < tasks.Length; i++)
            {
                string num2 = this.developer_check_condition(tasks[i]);
                if (num2.Length > 0)
                {
                    str = str + num2.ToString() + "\r\n";
                }
                if (tasks[i].sub_quests.Length > 0)
                {
                    str += this.developer_scan(tasks[i].sub_quests);
                }
            }
            return str;
        }
        #endregion

        private void keyPress_clone(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.click_cloneTask(null, EventArgs.Empty);
            }
        }

        #region Save Lists
        private void save_CreatureBuilder(ATaskTemplFixedData t, StreamWriter sw)
        {
            string str = "";
            if (t.m_lMonsCtrl > 0 || t.m_Award_S.m_lMonsCtrl > 0 || t.m_Award_F.m_lMonsCtrl > 0)
            {
                if (t.Name.StartsWith("^"))
                {
                    str = str + t.ID.ToString() + "\t" + t.Name.Substring(7);
                }
                else
                {
                    str = str + t.ID.ToString() + "\t" + t.Name;
                }
                if (t.m_lMonsCtrl > 0)
                {
                    str = str + "\t" + t.m_lMonsCtrl.ToString();
                }
                else
                {
                    str += "\t-";
                }
                if (t.m_Award_S.m_lMonsCtrl > 0)
                {
                    str = str + "\t" + t.m_Award_S.m_lMonsCtrl.ToString();
                }
                else
                {
                    str += "\t-";
                }
                if (t.m_Award_F.m_lMonsCtrl > 0)
                {
                    str = str + "\t" + t.m_Award_F.m_lMonsCtrl.ToString();
                }
                else
                {
                    str += "\t-";
                }
            }
            if (str != "")
            {
                sw.WriteLine(str);
            }
            for (int i = 0; i < t.sub_quests.Length; i++)
            {
                this.save_CreatureBuilder(t.sub_quests[i], sw);
            }
        }
        private void save_SkillList(ATaskTemplFixedData t, StreamWriter sw)
        {
            string str = "";
            if (t.m_iDeliveredSkillID > 0 || t.m_Award_S.m_iAwardSkillID > 0 || t.m_Award_F.m_iAwardSkillID > 0)
            {
                if (t.Name.StartsWith("^"))
                {
                    str = str + t.ID.ToString() + "\t" + t.Name.Substring(7);
                }
                else
                {
                    str = str + t.ID.ToString() + "\t" + t.Name;
                }
                if (t.m_iDeliveredSkillID > 0)
                {
                    str = str + "\t" + t.m_iDeliveredSkillID.ToString();
                }
                else
                {
                    str += "\t-";
                }
                if (t.m_Award_S.m_iAwardSkillID > 0)
                {
                    str = str + "\t" + t.m_Award_S.m_iAwardSkillID.ToString();
                }
                else
                {
                    str += "\t-";
                }
                if (t.m_Award_F.m_iAwardSkillID > 0)
                {
                    str = str + "\t" + t.m_Award_F.m_iAwardSkillID.ToString();
                }
                else
                {
                    str += "\t-";
                }
            }
            if (str != "")
            {
                sw.WriteLine(str);
            }
            for (int i = 0; i < t.sub_quests.Length; i++)
            {
                this.save_SkillList(t.sub_quests[i], sw);
            }
        }

        private void save_Test(ATaskTemplFixedData t, StreamWriter sw)
        {
            string str = "";
            if (t.m_ucPremiseTransformedForm != 255 || t.m_ucTransformedForm != 0)
            {
                if (t.Name.StartsWith("^"))
                {
                    str = str + t.ID.ToString() + "\t" + t.Name.Substring(7);
                }
                else
                {
                    str = str + t.ID.ToString() + "\t" + t.Name;
                }
                if (t.m_ucPremiseTransformedForm != 255)
                {
                    str = str + "\t" + t.m_ucPremiseTransformedForm.ToString();
                }
                else
                {
                    str += "\t-";
                }
                if (t.m_ucTransformedForm != 0)
                {
                    str = str + "\t" + t.m_ucTransformedForm.ToString();
                }
                else
                {
                    str += "\t-";
                }
            } 
            /*if (t.m_iFactionContribWanted > 0/* || t.m_Award_S.m_iAwardSkillID > 0 || t.m_Award_F.m_iAwardSkillID > 0)
            {
                if (t.Name.StartsWith("^"))
                {
                    str = str + t.ID.ToString() + "\t" + t.Name.Substring(7);
                }
                else
                {
                    str = str + t.ID.ToString() + "\t" + t.Name;
                }
                if (t.m_iFactionContribWanted > 0)
                {
                    str = str + "\t" + t.m_iFactionContribWanted.ToString();
                }
                else
                {
                    str += "\t-";
                }
                /*if (t.m_Award_S.m_iAwardSkillID > 0)
                {
                str = str + "\t" + t.m_enumMethod.ToString();
                /*}
                else
                {
                    str += "\t-";
                }*/
                /*if (t.m_Award_F.m_iAwardSkillID > 0)
                {
                    str = str + "\t" + t.m_Award_F.m_iAwardSkillID.ToString();
                }
                else
                {
                    str += "\t-";
                }
            }*/
            if (str != "")
            {
                sw.WriteLine(str);
            }
            for (int i = 0; i < t.sub_quests.Length; i++)
            {
                this.save_Test(t.sub_quests[i], sw);
            }
        }
        #endregion

        #region Search
        private bool search(int[] indices)
        {
            if (indices.Length > 0)
            {
                ATaskTemplFixedData task = this.current_task(indices);
                if (task == null)
                {
                    return false;
                }
                #region Search ID
                if ((int)this.comboBox_search.SelectedIndex == 0 && task.ID.ToString() == this.textBox_search.Text)
                {
                    this.select_treeNode(indices);
                    return true;
                }
                #endregion
                #region Search Name
                if ((int)this.comboBox_search.SelectedIndex == 1 && task.Name.ToLower().Contains(this.textBox_search.Text.ToLower()))
                {
                    this.select_treeNode(indices);
                    return true;
                }
                #endregion
                #region Search Wld Id
                if ((int)this.comboBox_search.SelectedIndex == 2)
                {
                    if (task.m_ulDelvWorld.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 1;
                        return true;
                    }
                    if (task.m_ulEnterRegionWorld.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 1;
                        return true;
                    }
                    if (task.m_ulLeaveRegionWorld.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 1;
                        return true;
                    }
                    if (task.m_ulTransWldId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 0;
                        return true;
                    }
                    if (task.m_ulReachSiteId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 1;
                        return true;
                    }
                    if (task.m_ulLeaveSiteId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 1;
                        return true;
                    }
                    if (task.m_Award_S.m_ulTransWldId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 5;
                        tabControl_Rewards.SelectedIndex = 0;
                        radioButton_m_Award_S.Checked = true;
                        return true;
                    }
                    if (task.m_Award_F.m_ulTransWldId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 5;
                        tabControl_Rewards.SelectedIndex = 0;
                        radioButton_m_Award_F.Checked = true;
                        return true;
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        if (task.m_AwByRatio_S.m_Awards[i].m_ulTransWldId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 0;
                            radioButton_m_AwByRatio_S.Checked = true;
                            listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        if (task.m_AwByRatio_F.m_Awards[i].m_ulTransWldId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 0;
                            radioButton_m_AwByRatio_F.Checked = true;
                            listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                            return true;
                        }
                    }
                }
                #endregion
                #region Search Mons Ctrl
                if ((int)this.comboBox_search.SelectedIndex == 3)
                {
                    if (task.m_lMonsCtrl.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 0;
                        return true;
                    }
                    if (task.m_Award_S.m_lMonsCtrl.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 5;
                        tabControl_Rewards.SelectedIndex = 0;
                        radioButton_m_Award_S.Checked = true;
                        return true;
                    }
                    if (task.m_Award_F.m_lMonsCtrl.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 5;
                        tabControl_Rewards.SelectedIndex = 0;
                        radioButton_m_Award_F.Checked = true;
                        return true;
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        if (task.m_AwByRatio_S.m_Awards[i].m_lMonsCtrl.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 0;
                            radioButton_m_AwByRatio_S.Checked = true;
                            listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        if (task.m_AwByRatio_F.m_Awards[i].m_lMonsCtrl.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 0;
                            radioButton_m_AwByRatio_F.Checked = true;
                            listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                            return true;
                        }
                    }
                }
                #endregion
                #region Search NPC Id
                if ((int)this.comboBox_search.SelectedIndex == 4)
                {
                    if (task.m_ulDelvNPC.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 0;
                        return true;
                    }
                    if (task.m_ulAwardNPC.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 0;
                        return true;
                    }
                }
                #endregion
                #region Search Key
                if ((int)this.comboBox_search.SelectedIndex == 5)
                {
                    for (int num36 = 0; num36 < task.m_plChangeKey.Length; num36++)
                    {
                        if (task.m_plChangeKey[num36].ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 2;
                            tabControl_basic.SelectedIndex = 1;
                            dataGridView_m_ulChangeKey.CurrentCell = dataGridView_m_ulChangeKey.Rows[num36].Cells[0];
                            return true;
                        }
                    }
                    if (task.m_Prem1KeyValue.lLeftNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 2;
                        dataGridView_m_Prem1KeyValue.CurrentCell = dataGridView_m_Prem1KeyValue.Rows[0].Cells[1];
                        return true;
                    }
                    if (task.m_Prem1KeyValue.lRightNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 2;
                        dataGridView_m_Prem1KeyValue.CurrentCell = dataGridView_m_Prem1KeyValue.Rows[0].Cells[4];
                        return true;
                    }
                    if (task.m_Prem2KeyValue.lLeftNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 2;
                        dataGridView_m_Prem2KeyValue.CurrentCell = dataGridView_m_Prem2KeyValue.Rows[0].Cells[1];
                        return true;
                    }
                    if (task.m_Prem2KeyValue.lRightNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 2;
                        dataGridView_m_Prem2KeyValue.CurrentCell = dataGridView_m_Prem2KeyValue.Rows[0].Cells[4];
                        return true;
                    }
                    if (task.m_Fin1KeyValue.lLeftNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_Fin1KeyValue.CurrentCell = dataGridView_m_Fin1KeyValue.Rows[0].Cells[1];
                        return true;
                    }
                    if (task.m_Fin1KeyValue.lRightNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_Fin1KeyValue.CurrentCell = dataGridView_m_Fin1KeyValue.Rows[0].Cells[4];
                        return true;
                    }
                    if (task.m_Fin2KeyValue.lLeftNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_Fin2KeyValue.CurrentCell = dataGridView_m_Fin2KeyValue.Rows[0].Cells[1];
                        return true;
                    }
                    if (task.m_Fin2KeyValue.lRightNum.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_Fin2KeyValue.CurrentCell = dataGridView_m_Fin2KeyValue.Rows[0].Cells[4];
                        return true;
                    }
                    for (int num17 = 0; num17 < task.m_Award_S.m_plChangeKey.Length; num17++)
                    {
                        if (task.m_Award_S.m_plChangeKey[num17].ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_ulChangeKey.CurrentCell = dataGridView_reward_m_ulChangeKey.Rows[num17].Cells[0];
                            return true;
                        }
                    }
                    for (int num17 = 0; num17 < task.m_Award_F.m_plChangeKey.Length; num17++)
                    {
                        if (task.m_Award_F.m_plChangeKey[num17].ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_ulChangeKey.CurrentCell = dataGridView_reward_m_ulChangeKey.Rows[num17].Cells[0];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num17 = 0; num17 < task.m_AwByRatio_S.m_Awards[i].m_plChangeKey.Length; num17++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_plChangeKey[num17].ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_S.Checked = true;
                                listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                dataGridView_reward_m_ulChangeKey.CurrentCell = dataGridView_reward_m_ulChangeKey.Rows[num17].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num17 = 0; num17 < task.m_AwByRatio_F.m_Awards[i].m_plChangeKey.Length; num17++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_plChangeKey[num17].ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_ulChangeKey.CurrentCell = dataGridView_reward_m_ulChangeKey.Rows[num17].Cells[0];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Item Templ Id
                if ((int)this.comboBox_search.SelectedIndex == 6)
                {
                    for (int num28 = 0; num28 < task.m_PremItems.Length; num28++)
                    {
                        if (task.m_PremItems[num28].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 3;
                            tabControl_given_requirements.SelectedIndex = 0;
                            dataGridView_m_PremItems.CurrentCell = dataGridView_m_PremItems.Rows[num28].Cells[0];
                            return true;
                        }
                    }
                    for (int num29 = 0; num29 < task.m_GivenItems.Length; num29++)
                    {
                        if (task.m_GivenItems[num29].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 3;
                            tabControl_given_requirements.SelectedIndex = 0;
                            dataGridView_m_GivenItems.CurrentCell = dataGridView_m_GivenItems.Rows[num29].Cells[0];
                            return true;
                        }
                    }
                    for (int num33 = 0; num33 < task.m_MonsterWanted.Length; num33++)
                    {
                        if (task.m_MonsterWanted[num33].m_ulDropItemId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 4;
                            tabControl_complete_requirements.SelectedIndex = 0;
                            dataGridView_m_MonsterWanted.CurrentCell = dataGridView_m_MonsterWanted.Rows[num33].Cells[2];
                            return true;
                        }
                    }
                    for (int num34 = 0; num34 < task.m_ItemsWanted.Length; num34++)
                    {
                        if (task.m_ItemsWanted[num34].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 4;
                            tabControl_complete_requirements.SelectedIndex = 0;
                            dataGridView_m_ItemsWanted.CurrentCell = dataGridView_m_ItemsWanted.Rows[num34].Cells[0];
                            return true;
                        }
                    }
                    for (int num22 = 0; num22 < task.m_Award_S.m_CandItems.Length; num22++)
                    {
                        for (int num25 = 0; num25 < task.m_Award_S.m_CandItems[num22].m_AwardItems.Length; num25++)
                        {
                            if (task.m_Award_S.m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_Award_S.Checked = true;
                                checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int num22 = 0; num22 < task.m_Award_F.m_CandItems.Length; num22++)
                    {
                        for (int num25 = 0; num25 < task.m_Award_F.m_CandItems[num22].m_AwardItems.Length; num25++)
                        {
                            if (task.m_Award_F.m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_Award_F.Checked = true;
                                checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num22 = 0; num22 < task.m_AwByRatio_S.m_Awards[i].m_CandItems.Length; num22++)
                        {
                            for (int num25 = 0; num25 < task.m_AwByRatio_S.m_Awards[i].m_CandItems[num22].m_AwardItems.Length; num25++)
                            {
                                if (task.m_AwByRatio_S.m_Awards[i].m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                                {
                                    this.select_treeNode(indices);
                                    tabControl1.SelectedIndex = 5;
                                    tabControl_Rewards.SelectedIndex = 1;
                                    radioButton_m_AwByRatio_S.Checked = true;
                                    listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                    checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                    dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                    return true;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num22 = 0; num22 < task.m_AwByRatio_F.m_Awards[i].m_CandItems.Length; num22++)
                        {
                            for (int num25 = 0; num25 < task.m_AwByRatio_F.m_Awards[i].m_CandItems[num22].m_AwardItems.Length; num25++)
                            {
                                if (task.m_AwByRatio_F.m_Awards[i].m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                                {
                                    this.select_treeNode(indices);
                                    tabControl1.SelectedIndex = 5;
                                    tabControl_Rewards.SelectedIndex = 1;
                                    radioButton_m_AwByRatio_F.Checked = true;
                                    listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                    checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                    dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                    return true;
                                }
                            }
                        }
                    }
                    for (int num16 = 0; num16 < task.m_Award_S.m_PQRankingAward.m_RankingAward.Length; num16++)
                    {
                        if (task.m_Award_S.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                            return true;
                        }
                    }
                    for (int num16 = 0; num16 < task.m_Award_F.m_PQRankingAward.m_RankingAward.Length; num16++)
                    {
                        if (task.m_Award_F.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_S.m_Awards[i].m_PQRankingAward.m_RankingAward.Length; num16++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_S.Checked = true;
                                listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_F.m_Awards[i].m_PQRankingAward.m_RankingAward.Length; num16++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Monster Templ Id
                if ((int)this.comboBox_search.SelectedIndex == 7)
                {
                    for (int num38 = 0; num38 < task.m_MonstersContrib.Length; num38++)
                    {
                        if (task.m_MonstersContrib[num38].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 2;
                            tabControl_basic.SelectedIndex = 1;
                            dataGridView_m_MonstersContrib.CurrentCell = dataGridView_m_MonstersContrib.Rows[num38].Cells[0];
                            return true;
                        }
                    }
                    for (int num33 = 0; num33 < task.m_MonsterWanted.Length; num33++)
                    {
                        if (task.m_MonsterWanted[num33].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 4;
                            tabControl_complete_requirements.SelectedIndex = 0;
                            dataGridView_m_MonsterWanted.CurrentCell = dataGridView_m_MonsterWanted.Rows[num33].Cells[0];
                            return true;
                        }
                    }
                    for (int num16 = 0; num16 < task.m_Award_S.m_SummonedMonsters.m_Monsters.Length; num16++)
                    {
                        if (task.m_Award_S.m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                            return true;
                        }
                    }
                    for (int num16 = 0; num16 < task.m_Award_F.m_SummonedMonsters.m_Monsters.Length; num16++)
                    {
                        if (task.m_Award_F.m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_S.m_Awards[i].m_SummonedMonsters.m_Monsters.Length; num16++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_S.Checked = true;
                                listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_F.m_Awards[i].m_SummonedMonsters.m_Monsters.Length; num16++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Title Id
                if ((int)this.comboBox_search.SelectedIndex == 8)
                {
                    for (int num32 = 0; num32 < task.m_PremTitles.Length; num32++)
                    {
                        if (task.m_PremTitles[num32].ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 3;
                            tabControl_given_requirements.SelectedIndex = 3;
                            dataGridView_m_PremTitles.CurrentCell = dataGridView_m_PremTitles.Rows[num32].Cells[0];
                            return true;
                        }
                    }
                    for (int num20 = 0; num20 < task.m_Award_S.m_pTitleAward.Length; num20++)
                    {
                        if (task.m_Award_S.m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                            return true;
                        }
                    }
                    for (int num20 = 0; num20 < task.m_Award_F.m_pTitleAward.Length; num20++)
                    {
                        if (task.m_Award_F.m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 1;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num20 = 0; num20 < task.m_AwByRatio_S.m_Awards[i].m_pTitleAward.Length; num20++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_S.Checked = true;
                                dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num20 = 0; num20 < task.m_AwByRatio_F.m_Awards[i].m_pTitleAward.Length; num20++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 1;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Trans Wld Id
                if ((int)this.comboBox_search.SelectedIndex == 9)
                {
                    if (task.m_ulTransWldId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 0;
                        return true;
                    }
                    if (task.m_Award_S.m_ulTransWldId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 5;
                        tabControl_Rewards.SelectedIndex = 0;
                        radioButton_m_Award_S.Checked = true;
                        return true;
                    }
                    if (task.m_Award_F.m_ulTransWldId.ToString() == this.textBox_search.Text)
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 5;
                        tabControl_Rewards.SelectedIndex = 0;
                        radioButton_m_Award_F.Checked = true;
                        return true;
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        if (task.m_AwByRatio_S.m_Awards[i].m_ulTransWldId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 0;
                            radioButton_m_AwByRatio_S.Checked = true;
                            listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        if (task.m_AwByRatio_F.m_Awards[i].m_ulTransWldId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 0;
                            radioButton_m_AwByRatio_F.Checked = true;
                            listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                            return true;
                        }
                    }
                }
                #endregion
                #region Search Monsters Contrib
                for (int num38 = 0; num38 < task.m_MonstersContrib.Length; num38++)
                    if ((int)this.comboBox_search.SelectedIndex == 10 && (task.m_MonstersContrib[num38].m_ulMonsterTemplId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 1;
                        dataGridView_m_MonstersContrib.CurrentCell = dataGridView_m_MonstersContrib.Rows[num38].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Prem Items
                for (int num28 = 0; num28 < task.m_PremItems.Length; num28++)
                    if ((int)this.comboBox_search.SelectedIndex == 11 && (task.m_PremItems[num28].m_ulItemTemplId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 0;
                        dataGridView_m_PremItems.CurrentCell = dataGridView_m_PremItems.Rows[num28].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Given Items
                for (int num29 = 0; num29 < task.m_GivenItems.Length; num29++)
                    if ((int)this.comboBox_search.SelectedIndex == 12 && (task.m_GivenItems[num29].m_ulItemTemplId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 0;
                        dataGridView_m_GivenItems.CurrentCell = dataGridView_m_GivenItems.Rows[num29].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Prem Titles
                for (int num32 = 0; num32 < task.m_PremTitles.Length; num32++)
                    if ((int)this.comboBox_search.SelectedIndex == 13 && (task.m_PremTitles[num32].ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 3;
                        tabControl_given_requirements.SelectedIndex = 3;
                        dataGridView_m_PremTitles.CurrentCell = dataGridView_m_PremTitles.Rows[num32].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Monster Wanted(Monster)
                for (int num33 = 0; num33 < task.m_MonsterWanted.Length; num33++)
                    if ((int)this.comboBox_search.SelectedIndex == 14 && (task.m_MonsterWanted[num33].m_ulMonsterTemplId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_MonsterWanted.CurrentCell = dataGridView_m_MonsterWanted.Rows[num33].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Monster Wanted(Item)
                for (int num33 = 0; num33 < task.m_MonsterWanted.Length; num33++)
                    if ((int)this.comboBox_search.SelectedIndex == 15 && (task.m_MonsterWanted[num33].m_ulDropItemId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_MonsterWanted.CurrentCell = dataGridView_m_MonsterWanted.Rows[num33].Cells[2];
                        return true;
                    }
                #endregion
                #region Search Items Wanted
                for (int num34 = 0; num34 < task.m_ItemsWanted.Length; num34++)
                    if ((int)this.comboBox_search.SelectedIndex == 16 && (task.m_ItemsWanted[num34].m_ulItemTemplId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 0;
                        dataGridView_m_ItemsWanted.CurrentCell = dataGridView_m_ItemsWanted.Rows[num34].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Task Char
                for (int num34 = 0; num34 < task.m_pTaskChar.Length; num34++)
                    if ((int)this.comboBox_search.SelectedIndex == 17 && (Extensions.ByteArray_to_UnicodeString(task.m_pTaskChar[num34]).ToLower().Contains(this.textBox_search.Text.ToLower())))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 2;
                        tabControl_basic.SelectedIndex = 1;
                        dataGridView_m_pTaskChar.CurrentCell = dataGridView_m_pTaskChar.Rows[num34].Cells[0];
                        return true;
                    }
                #endregion
                #region Search TM Home Item
                for (int num341 = 0; num341 < task.TMHomeItemData.Length; num341++)
                    if ((int)this.comboBox_search.SelectedIndex == 18 && (task.TMHomeItemData[num341].m_ulItemTemplId.ToString() == this.textBox_search.Text))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 4;
                        tabControl_complete_requirements.SelectedIndex = 1;
                        dataGridView_TMHomeItem.CurrentCell = dataGridView_TMHomeItem.Rows[num341].Cells[0];
                        return true;
                    }
                #endregion
                #region Search Award Items
                if ((int)this.comboBox_search.SelectedIndex == 19)
                {
                    for (int num22 = 0; num22 < task.m_Award_S.m_CandItems.Length; num22++)
                    {
                        for (int num25 = 0; num25 < task.m_Award_S.m_CandItems[num22].m_AwardItems.Length; num25++)
                        {
                            if (task.m_Award_S.m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 0;
                                radioButton_m_Award_S.Checked = true;
                                checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int num22 = 0; num22 < task.m_Award_F.m_CandItems.Length; num22++)
                    {
                        for (int num25 = 0; num25 < task.m_Award_F.m_CandItems[num22].m_AwardItems.Length; num25++)
                        {
                            if (task.m_Award_F.m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 0;
                                radioButton_m_Award_F.Checked = true;
                                checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num22 = 0; num22 < task.m_AwByRatio_S.m_Awards[i].m_CandItems.Length; num22++)
                        {
                            for (int num25 = 0; num25 < task.m_AwByRatio_S.m_Awards[i].m_CandItems[num22].m_AwardItems.Length; num25++)
                            {
                                if (task.m_AwByRatio_S.m_Awards[i].m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                                {
                                    this.select_treeNode(indices);
                                    tabControl1.SelectedIndex = 5;
                                    tabControl_Rewards.SelectedIndex = 0;
                                    radioButton_m_AwByRatio_S.Checked = true;
                                    listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                    checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                    dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                    return true;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num22 = 0; num22 < task.m_AwByRatio_F.m_Awards[i].m_CandItems.Length; num22++)
                        {
                            for (int num25 = 0; num25 < task.m_AwByRatio_F.m_Awards[i].m_CandItems[num22].m_AwardItems.Length; num25++)
                            {
                                if (task.m_AwByRatio_F.m_Awards[i].m_CandItems[num22].m_AwardItems[num25].m_ulItemTemplId.ToString() == this.textBox_search.Text)
                                {
                                    this.select_treeNode(indices);
                                    tabControl1.SelectedIndex = 5;
                                    tabControl_Rewards.SelectedIndex = 0;
                                    radioButton_m_AwByRatio_F.Checked = true;
                                    listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                    checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex = num22;
                                    dataGridView_reward_item_m_AwardItems.CurrentCell = dataGridView_reward_item_m_AwardItems.Rows[num25].Cells[0];
                                    return true;
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Search Summoned Monsters
                if ((int)this.comboBox_search.SelectedIndex == 20)
                {
                    for (int num16 = 0; num16 < task.m_Award_S.m_SummonedMonsters.m_Monsters.Length; num16++)
                    {
                        if (task.m_Award_S.m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 3;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                            return true;
                        }
                    }
                    for (int num16 = 0; num16 < task.m_Award_F.m_SummonedMonsters.m_Monsters.Length; num16++)
                    {
                        if (task.m_Award_F.m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 3;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_S.m_Awards[i].m_SummonedMonsters.m_Monsters.Length; num16++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 3;
                                radioButton_m_AwByRatio_S.Checked = true;
                                listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_F.m_Awards[i].m_SummonedMonsters.m_Monsters.Length; num16++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 3;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_Monsters.CurrentCell = dataGridView_reward_m_Monsters.Rows[num16].Cells[0];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Ranking Award
                if ((int)this.comboBox_search.SelectedIndex == 21)
                {
                    for (int num16 = 0; num16 < task.m_Award_S.m_PQRankingAward.m_RankingAward.Length; num16++)
                    {
                        if (task.m_Award_S.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 8;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                            return true;
                        }
                    }
                    for (int num16 = 0; num16 < task.m_Award_F.m_PQRankingAward.m_RankingAward.Length; num16++)
                    {
                        if (task.m_Award_F.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 8;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_S.m_Awards[i].m_PQRankingAward.m_RankingAward.Length; num16++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 8;
                                radioButton_m_AwByRatio_S.Checked = true;
                                listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num16 = 0; num16 < task.m_AwByRatio_F.m_Awards[i].m_PQRankingAward.m_RankingAward.Length; num16++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 8;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_RankingAward.CurrentCell = dataGridView_reward_m_RankingAward.Rows[num16].Cells[3];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Title Award
                if ((int)this.comboBox_search.SelectedIndex == 22)
                {
                    for (int num20 = 0; num20 < task.m_Award_S.m_pTitleAward.Length; num20++)
                    {
                        if (task.m_Award_S.m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 8;
                            radioButton_m_Award_S.Checked = true;
                            dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                            return true;
                        }
                    }
                    for (int num20 = 0; num20 < task.m_Award_F.m_pTitleAward.Length; num20++)
                    {
                        if (task.m_Award_F.m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                        {
                            this.select_treeNode(indices);
                            tabControl1.SelectedIndex = 5;
                            tabControl_Rewards.SelectedIndex = 8;
                            radioButton_m_Award_F.Checked = true;
                            dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                            return true;
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_S.m_Awards.Length; i++)
                    {
                        for (int num20 = 0; num20 < task.m_AwByRatio_S.m_Awards[i].m_pTitleAward.Length; num20++)
                        {
                            if (task.m_AwByRatio_S.m_Awards[i].m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 8;
                                radioButton_m_AwByRatio_S.Checked = true;
                                listBox_reward_m_AwByRatio_S.SelectedIndex = i;
                                dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < task.m_AwByRatio_F.m_Awards.Length; i++)
                    {
                        for (int num20 = 0; num20 < task.m_AwByRatio_F.m_Awards[i].m_pTitleAward.Length; num20++)
                        {
                            if (task.m_AwByRatio_F.m_Awards[i].m_pTitleAward[num20].m_ulTitleID.ToString() == this.textBox_search.Text)
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 5;
                                tabControl_Rewards.SelectedIndex = 8;
                                radioButton_m_AwByRatio_F.Checked = true;
                                listBox_reward_m_AwByRatio_F.SelectedIndex = i;
                                dataGridView_reward_m_pTitleAward.CurrentCell = dataGridView_reward_m_pTitleAward.Rows[num20].Cells[0];
                                return true;
                            }
                        }
                    }
                }
                #endregion
                #region Search Texts
                if ((int)this.comboBox_search.SelectedIndex == 23)
                {
                    if (task.conversation.Descript.ToLower().Contains(this.textBox_search.Text.ToLower()))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 6;
                        return true;
                    }
                    if (task.conversation.OkText.ToLower().Contains(this.textBox_search.Text.ToLower()))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 6;
                        return true;
                    }
                    if (task.conversation.NoText.ToLower().Contains(this.textBox_search.Text.ToLower()))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 6;
                        return true;
                    }
                    if (task.conversation.Tribute.ToLower().Contains(this.textBox_search.Text.ToLower()))
                    {
                        this.select_treeNode(indices);
                        tabControl1.SelectedIndex = 6;
                        return true;
                    }
                    for (int index1 = 0; index1 < task.talk_procs.Length; index1++)
                    {
                        for (int index2 = 0; index2 < task.talk_procs[index1].windows.Length; index2++)
                        {
                            if (task.talk_procs[index1].windows[index2].talktext.ToLower().Contains(this.textBox_search.Text.ToLower()))
                            {
                                this.select_treeNode(indices);
                                tabControl1.SelectedIndex = 6;
                                this.listBox_conversation_talk_procs.SelectedIndex = index1;
                                this.listBox_conversation_windows.SelectedIndex = index2;
                                return true;
                            }
                        }
                    }
                    for (int index1 = 0; index1 < task.talk_procs.Length; index1++)
                    {
                        for (int index2 = 0; index2 < task.talk_procs[index1].windows.Length; index2++)
                        {
                            for (int index3 = 0; index3 < task.talk_procs[index1].windows[index2].options.Length; index3++)
                            {
                                if (task.talk_procs[index1].windows[index2].options[index3].optiontext.ToLower().Contains(this.textBox_search.Text.ToLower()))
                                {
                                    this.select_treeNode(indices);
                                    tabControl1.SelectedIndex = 6;
                                    this.listBox_conversation_talk_procs.SelectedIndex = index1;
                                    this.listBox_conversation_windows.SelectedIndex = index2;
                                    this.listBox_conversation_options.SelectedIndex = index3;
                                    return true;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            return false;
        }

        private int[] next_treeNode()
        {
            int[] array = null;
            int[] array2 = new int[1];
            array = array2;
            if (this.treeView_tasks.SelectedNode.Index > -1)
            {
                array = new int[this.treeView_tasks.SelectedNode.Level + 1];
                bool flag = false;
                TreeNode selectedNode = this.treeView_tasks.SelectedNode;
                for (int i = array.Length - 1; i > -1; i--)
                {
                    array[i] = selectedNode.Index;
                    if (selectedNode == this.treeView_tasks.SelectedNode && this.treeView_tasks.SelectedNode.Nodes.Count > 0)
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        if (selectedNode.NextNode != null)
                        {
                            array[i]++;
                            flag = true;
                        }
                        else
                        {
                            Array.Resize<int>(ref array, array.Length - 1);
                        }
                    }
                    selectedNode = selectedNode.Parent;
                }
                selectedNode = this.treeView_tasks.SelectedNode;
                while (selectedNode.Nodes.Count > 0)
                {
                    Array.Resize<int>(ref array, array.Length + 1);
                    array[array.Length - 1] = 0;
                    selectedNode = selectedNode.Nodes[0];
                }
            }
            return array;
        }
        private int[] next_task(int[] currentIndices)
        {
            int[] array = null;
            if (currentIndices.Length > 0)
            {
                array = new int[currentIndices.Length];
                ATaskTemplFixedData task = this.current_task(currentIndices);
                currentIndices.CopyTo(array, 0);
                if (task.sub_quest_count > 0)
                {
                    Array.Resize<int>(ref array, array.Length + 1);
                    array[array.Length - 1] = 0;
                    return array;
                }
                for (int i = array.Length - 1; i > 0; i--)
                {
                    if (this.current_task(array).m_ulNextSibling != 0)
                    {
                        array[i]++;
                        return array;
                    }
                    Array.Resize<int>(ref array, array.Length - 1);
                }
                if (array[0] < this.Tasks.Length - 1)
                {
                    array[0]++;
                    return array;
                }
            }
            return new int[0];
        }
        private ATaskTemplFixedData current_task(int[] currentIndices)
        {
            if (currentIndices.Length <= 0)
            {
                return null;
            }
            ATaskTemplFixedData task = this.Tasks[currentIndices[0]];
            for (int i = 1; i < currentIndices.Length; i++)
            {
                task = task.sub_quests[currentIndices[i]];
            }
            return task;
        }
        private void select_treeNode(int[] indices)
        {
            if (indices.Length > 0)
            {
                TreeNode node = this.treeView_tasks.Nodes[indices[0]];
                for (int i = 1; i < indices.Length; i++)
                {
                    node = node.Nodes[indices[i]];
                }
                this.treeView_tasks.SelectedNode = node;
            }
        }
        private void keyPress_search(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.click_search(null, null);
            }
        }
        #endregion

        private void TriggerDebug(Control sender)
        {

        }

        #region Select Color
        private void button_SelectColor_Click(object sender, EventArgs e)
        {
            string current = textBox_m_szName.Text;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true; 
            try
            {
                colorDialog.Color = Color.FromArgb(int.Parse(current.Substring(1, 6), NumberStyles.HexNumber));
            }
            catch
            {
                colorDialog.Color = Color.FromArgb(17,17,17);
            }
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var colorcod = ColorCod(colorDialog.Color);
                if(current.StartsWith("^"))
                {
                    textBox_m_szName.Text = colorcod + current.Substring(7);
                }
                else
                {
                    textBox_m_szName.Text = colorcod + current;
                }

                Bitmap bmp = new Bitmap(pictureBox_Color.Width, pictureBox_Color.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(new SolidBrush(colorDialog.Color), new Rectangle(Point.Empty, bmp.Size));
                }

                pictureBox_Color.BackgroundImage = bmp;
                change_m_szName(null, null);
            }
        }
        string ColorCod(Color color)
        {
            string Cod = Convert.ToString(new int[] { color.R, color.G, color.B });
            return String.Format("^{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B).ToUpper();
        }
        #endregion


        #region dataGridViewRowPrePaint
        private void dataGridView_m_tmType_m_tmStart_m_tmEnd_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_tmType_m_tmStart_m_tmEnd.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_pDelvRegion_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pDelvRegion.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pDelvRegion.Rows[index].HeaderCell.Value = indexStr;
            this.Convert_m_pDelvRegion(null, null);
        }
        private void dataGridView_m_pEnterRegion_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pEnterRegion.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pEnterRegion.Rows[index].HeaderCell.Value = indexStr;
            this.Convert_m_pEnterRegion(null, null);
        }
        private void dataGridView_m_pLeaveRegion_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pLeaveRegion.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pLeaveRegion.Rows[index].HeaderCell.Value = indexStr;
            this.Convert_m_pLeaveRegion(null, null);
        }
        private void dataGridView_m_pReachSite_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pReachSite.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pReachSite.Rows[index].HeaderCell.Value = indexStr;
            this.Convert_m_pReachSite(null, null);
        }
        private void dataGridView_m_pLeaveSite_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pLeaveSite.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pLeaveSite.Rows[index].HeaderCell.Value = indexStr;
            this.Convert_m_pLeaveSite(null, null);
        }
        private void dataGridView_m_ulChangeKey_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_ulChangeKey.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_ulChangeKey.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_pszPQExp_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pszPQExp.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pszPQExp.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_MonstersContrib_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_MonstersContrib.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_MonstersContrib.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_pszExp_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pszExp.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pszExp.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_pTaskChar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_pTaskChar.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_pTaskChar.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_PremItems_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_PremItems.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_PremItems.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_GivenItems_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_GivenItems.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_GivenItems.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_TeamMemsWanted_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_TeamMemsWanted.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_TeamMemsWanted.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_PremTitles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_PremTitles.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_PremTitles.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_PlayerWanted_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_PlayerWanted.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_PlayerWanted.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_MonsterWanted_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_MonsterWanted.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_MonsterWanted.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_m_ItemsWanted_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_m_ItemsWanted.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_m_ItemsWanted.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_TMHomeItem_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_TMHomeItem.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_TMHomeItem.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_item_m_AwardItems_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_item_m_AwardItems.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_item_m_AwardItems.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_Monsters_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_Monsters.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_Monsters.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_RankingAward_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_RankingAward.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_RankingAward.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_plDisplayKey_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_plDisplayKey.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_plDisplayKey.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_pTitleAward_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_pTitleAward.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_pTitleAward.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_ulChangeKey_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_ulChangeKey.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_ulChangeKey.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_ulHistoryChange_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_ulHistoryChange.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_ulHistoryChange.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_pszExp_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_pszExp.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_pszExp.Rows[index].HeaderCell.Value = indexStr;
        }
        private void dataGridView_reward_m_pTaskChar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView_reward_m_pTaskChar.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView_reward_m_pTaskChar.Rows[index].HeaderCell.Value = indexStr;
        }
        #endregion

        private void click_OpenPWDBWindow(object sender, EventArgs e)
        {
            PWDBWindow PWDBWindow = new PWDBWindow(this);
            PWDBWindow.Show();
        }

        #region Edit Parametrs
        private void ClickPremItemsOpenSelectItemIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_m_PremItems.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {

                        int someOtherInt = int.Parse(this.dataGridView_m_PremItems.Rows[this.dataGridView_m_PremItems.CurrentCell.RowIndex].Cells[0].Value.ToString());
                        if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                        {
                            ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                            MainProgram.getInstance().goToElementIndex(item);
                        }

                      //  SelectItemIdWindow SelectItemIdWindow = new SelectItemIdWindow(this, 1);
                      //  SelectItemIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }
        private void ClickGivenItemsOpenSelectItemIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_m_GivenItems.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {
                        int someOtherInt = int.Parse(this.dataGridView_m_GivenItems.Rows[this.dataGridView_m_GivenItems.CurrentCell.RowIndex].Cells[0].Value.ToString());
                        if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                        {
                            ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                            MainProgram.getInstance().goToElementIndex(item);
                        }
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }
        private void ClickMonsterWantedOpenSelectItemIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_m_MonsterWanted.CurrentCell.ColumnIndex)
            {
                case 1:
                    int someOtherInt = int.Parse(this.dataGridView_m_MonsterWanted.Rows[this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                    {
                        ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                        MainProgram.getInstance().goToElementIndex(item);
                    }
                    break;
                case 4:
                    int someOtherInt2 = int.Parse(this.dataGridView_m_MonsterWanted.Rows[this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex].Cells[5].Value.ToString());
                    if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt2) != null)
                    {
                        ItemDupe item = TaskEditor.eLC.getItem(someOtherInt2);
                        MainProgram.getInstance().goToElementIndex(item);
                    }
                    break;
            }
        }
        private void ClickItemsWantedOpenSelectItemIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_m_ItemsWanted.CurrentCell.ColumnIndex)
            {
                case 1:
                    int someOtherInt = int.Parse(this.dataGridView_m_ItemsWanted.Rows[this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                    {
                        ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                        MainProgram.getInstance().goToElementIndex(item);
                    }
                    break;
            }
        }
        private void ClickAwardItemsOpenSelectItemIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_reward_item_m_AwardItems.CurrentCell.ColumnIndex)
            {
                case 1:
                    int someOtherInt = int.Parse(this.dataGridView_reward_item_m_AwardItems.Rows[this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                    {
                        ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                        MainProgram.getInstance().goToElementIndex(item);
                    }
                    break;
            }
        }
        private void ClickRankingAwardOpenSelectItemIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_reward_m_RankingAward.CurrentCell.ColumnIndex)
            {
                case 4:
                    if (LoadedElements == true)
                    {
                        int someOtherInt = int.Parse(this.dataGridView_reward_m_RankingAward.Rows[this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex].Cells[3].Value.ToString());
                        if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                        {
                            ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                            MainProgram.getInstance().goToElementIndex(item);
                        }
                     //   SelectItemIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }

        public void ChangeItemId(int ItemId, int param, bool CommonItem)
        {
            switch (param)
            {
                case 1:
                    int index1 = this.dataGridView_m_PremItems.CurrentCell.RowIndex;
                    this.SelectedTask.m_PremItems[index1].m_ulItemTemplId = ItemId;
                    this.dataGridView_m_PremItems.CurrentRow.Cells[0].Value = ItemId;
                    this.dataGridView_m_PremItems.Rows[index1].Cells[1].Value = Extensions.ItemName(ItemId);
                    this.SelectedTask.m_PremItems[index1].m_bCommonItem = CommonItem;
                    this.dataGridView_m_PremItems.CurrentRow.Cells[2].Value = CommonItem;
                    break;
                case 2:
                    int index2 = this.dataGridView_m_GivenItems.CurrentCell.RowIndex;
                    this.SelectedTask.m_GivenItems[index2].m_ulItemTemplId = ItemId;
                    this.dataGridView_m_GivenItems.CurrentRow.Cells[0].Value = ItemId;
                    this.dataGridView_m_GivenItems.Rows[index2].Cells[1].Value = Extensions.ItemName(ItemId);
                    this.SelectedTask.m_GivenItems[index2].m_bCommonItem = CommonItem;
                    this.dataGridView_m_GivenItems.CurrentRow.Cells[2].Value = CommonItem;
                    break;
                case 3:
                    int index3 = this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_MonsterWanted[index3].m_ulDropItemId = ItemId;
                    this.dataGridView_m_MonsterWanted.CurrentRow.Cells[3].Value = ItemId;
                    this.dataGridView_m_MonsterWanted.Rows[index3].Cells[4].Value = Extensions.ItemName(ItemId);
                    this.SelectedTask.m_MonsterWanted[index3].m_bDropCmnItem = CommonItem;
                    this.dataGridView_m_MonsterWanted.CurrentRow.Cells[6].Value = CommonItem;
                    break;
                case 4:
                    int index4 = this.dataGridView_m_ItemsWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_ItemsWanted[index4].m_ulItemTemplId = ItemId;
                    this.dataGridView_m_ItemsWanted.CurrentRow.Cells[0].Value = ItemId;
                    this.dataGridView_m_ItemsWanted.Rows[index4].Cells[1].Value = Extensions.ItemName(ItemId);
                    this.SelectedTask.m_ItemsWanted[index4].m_bCommonItem = CommonItem;
                    this.dataGridView_m_ItemsWanted.CurrentRow.Cells[2].Value = CommonItem;
                    break;
                case 5:
                    int selectedIndex = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                    int index5 = this.dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[index5].m_ulItemTemplId = ItemId;
                    this.dataGridView_reward_item_m_AwardItems.CurrentRow.Cells[0].Value = ItemId;
                    this.dataGridView_reward_item_m_AwardItems.Rows[index5].Cells[1].Value = Extensions.ItemName(ItemId);
                    this.SelectedReward.m_CandItems[selectedIndex].m_AwardItems[index5].m_bCommonItem = CommonItem;
                    this.dataGridView_reward_item_m_AwardItems.CurrentRow.Cells[2].Value = CommonItem;
                    break;
                case 6:
                    int index6 = this.dataGridView_reward_m_RankingAward.CurrentCell.RowIndex;
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[index6].m_ulAwardItemId = ItemId;
                    this.dataGridView_reward_m_RankingAward.CurrentRow.Cells[3].Value = ItemId;
                    this.dataGridView_reward_m_RankingAward.Rows[index6].Cells[4].Value = Extensions.ItemName(ItemId);
                    this.SelectedReward.m_PQRankingAward.m_RankingAward[index6].m_bCommonItem = CommonItem;
                    this.dataGridView_reward_m_RankingAward.CurrentRow.Cells[2].Value = CommonItem;
                    break;
                case 7:
                    int index7 = this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_PlayerWanted[index7].m_ulDropItemId = ItemId;
                    this.dataGridView_m_PlayerWanted.CurrentRow.Cells[1].Value = ItemId;
                    this.dataGridView_m_PlayerWanted.Rows[index7].Cells[2].Value = Extensions.ItemName(ItemId);
                    this.SelectedTask.m_PlayerWanted[index7].m_bDropCmnItem = CommonItem;
                    this.dataGridView_m_PlayerWanted.CurrentRow.Cells[4].Value = CommonItem;
                    break;
            }
        }

        private void ClickMonstersContribOpenSelectMonsterIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dataGridView_m_MonstersContrib.CurrentCell != null)
            switch (this.dataGridView_m_MonstersContrib.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {
                        SelectMonsterIdWindow SelectMonsterIdWindow = new SelectMonsterIdWindow(this, 1);
                        SelectMonsterIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }
        private void ClickMonstersOpenSelectMonsterNPCMineIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView_reward_m_Monsters.CurrentCell != null)
            switch (this.dataGridView_reward_m_Monsters.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {
                        SelectMonsterNPCMineIdWindow SelectMonsterNPCMineIdWindow = new SelectMonsterNPCMineIdWindow(this, 3);
                        SelectMonsterNPCMineIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }

        public void ChangeMonsterId(int MonsterId, int param)
        {
            switch (param)
            {
                case 1:
                    int index1 = this.dataGridView_m_MonstersContrib.CurrentCell.RowIndex;
                    this.SelectedTask.m_MonstersContrib[index1].m_ulMonsterTemplId = MonsterId;
                    this.dataGridView_m_MonstersContrib.CurrentRow.Cells[0].Value = MonsterId;
                    this.dataGridView_m_MonstersContrib.Rows[index1].Cells[1].Value = Extensions.MonsterNPCMineName(MonsterId);
                    break;
                case 2:
                    int index2 = this.dataGridView_m_MonsterWanted.CurrentCell.RowIndex;
                    this.SelectedTask.m_MonsterWanted[index2].m_ulMonsterTemplId = MonsterId;
                    this.dataGridView_m_MonsterWanted.CurrentRow.Cells[0].Value = MonsterId;
                    this.dataGridView_m_MonsterWanted.Rows[index2].Cells[1].Value = Extensions.MonsterNPCMineName(MonsterId);
                    break;
                case 3:
                    int index3 = this.dataGridView_reward_m_Monsters.CurrentCell.RowIndex;
                    this.SelectedReward.m_SummonedMonsters.m_Monsters[index3].m_ulMonsterTemplId = MonsterId;
                    this.dataGridView_reward_m_Monsters.CurrentRow.Cells[0].Value = MonsterId;
                    this.dataGridView_reward_m_Monsters.Rows[index3].Cells[1].Value = Extensions.MonsterNPCMineName(MonsterId);
                    break;
            }
        }

        private void button_Edit_m_ulDelvNPC_Click(object sender, EventArgs e)
        {
            if (LoadedElements == true)
            {
                SelectNPCIdWindow SelectNPCIdWindow = new SelectNPCIdWindow(this, 1);
                SelectNPCIdWindow.Show();
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(459));
            }
        }
        private void button_Edit_m_ulAwardNPC_Click(object sender, EventArgs e)
        {
            if (LoadedElements == true)
            {
                SelectNPCIdWindow SelectNPCIdWindow = new SelectNPCIdWindow(this, 2);
                SelectNPCIdWindow.Show();
            }
            else
            {
                JMessageBox.Show(this, Extensions.GetLocalization(459));
            }
        }

        public void ChangeNPCId(int NPCId, int param)
        {
            switch (param)
            {
                case 1:
                    this.SelectedTask.m_ulDelvNPC = NPCId;
                    this.textBox_m_ulDelvNPC.Text = NPCId.ToString();
                    this.ShowNPCName_m_ulDelvNPC();
                    break;
                case 2:
                    this.SelectedTask.m_ulAwardNPC = NPCId;
                    this.textBox_m_ulAwardNPC.Text = NPCId.ToString();
                    this.ShowNPCName_m_ulAwardNPC();
                    break;
            }
        }

        private void ClickPremTitlesOpenSelectTitleIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_m_PremTitles.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {
                        SelectTitleIdWindow SelectTitleIdWindow = new SelectTitleIdWindow(this, 1);
                        SelectTitleIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }
        private void ClickTitleAwardOpenSelectTitleIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_reward_m_pTitleAward.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {
                        SelectTitleIdWindow SelectTitleIdWindow = new SelectTitleIdWindow(this, 2);
                        SelectTitleIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }

        public void ChangeTitleId(int TitleId, int param)
        {
            switch (param)
            {
                case 1:
                    int index1 = this.dataGridView_m_PremTitles.CurrentCell.RowIndex;
                    this.SelectedTask.m_PremTitles[index1] = TitleId;
                    this.dataGridView_m_PremTitles.CurrentRow.Cells[0].Value = TitleId;
                    this.dataGridView_m_PremTitles.Rows[index1].Cells[1].Value = Extensions.TitleName(TitleId);
                    break;
                case 2:
                    int index2 = this.dataGridView_reward_m_pTitleAward.CurrentCell.RowIndex;
                    this.SelectedReward.m_pTitleAward[index2].m_ulTitleID = TitleId;
                    this.dataGridView_reward_m_pTitleAward.CurrentRow.Cells[0].Value = TitleId;
                    this.dataGridView_reward_m_pTitleAward.Rows[index2].Cells[1].Value = Extensions.TitleName(TitleId);
                    break;
            }
        }

        private void ClickHomeItemOpenSelectTitleIdWindow(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridView_TMHomeItem.CurrentCell.ColumnIndex)
            {
                case 1:
                    if (LoadedElements == true)
                    {
                        SelectHomeItemIdWindow SelectHomeItemIdWindow = new SelectHomeItemIdWindow(this, 1);
                        SelectHomeItemIdWindow.Show();
                    }
                    else
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(459));
                    }
                    break;
            }
        }

        public void ChangeHomeItemId(int HomeItemId, int param)
        {
            switch (param)
            {
                case 1:
                    int index1 = this.dataGridView_TMHomeItem.CurrentCell.RowIndex;
                    this.SelectedTask.TMHomeItemData[index1].m_ulItemTemplId = HomeItemId;
                    this.dataGridView_TMHomeItem.CurrentRow.Cells[0].Value = HomeItemId;
                    this.dataGridView_TMHomeItem.Rows[index1].Cells[1].Value = Extensions.HomeItemName(HomeItemId);
                    break;
            }
        }

        private void ClickOpenOccupWindow(object sender, DataGridViewCellEventArgs e)
        {
            int index = this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex;
            switch (this.dataGridView_m_PlayerWanted.CurrentCell.ColumnIndex)
            {
                case 2:
                    int someOtherInt = int.Parse(this.dataGridView_m_PlayerWanted.Rows[this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                    {
                        ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                        MainProgram.getInstance().goToElementIndex(item);
                    }
                    break;
                case 6:
                    int occupations = this.SelectedTask.m_PlayerWanted[index].m_Requirements.m_ulOccupations;
                    PlayerWantedOccupationsWindow PlayerWantedOccupationsWindow = new PlayerWantedOccupationsWindow(this, occupations);
                    PlayerWantedOccupationsWindow.Show();
                    break;
                case 10:
                    int force = this.SelectedTask.m_PlayerWanted[index].m_Requirements.m_iForce;
                    PlayerWantedForceWindow PlayerWantedForceWindow = new PlayerWantedForceWindow(this, force);
                    PlayerWantedForceWindow.Show();
                    break;
            }
        }

        public void ChangePlayerWantedOccupations(int occupations)
        {
            int index = this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex;
            this.SelectedTask.m_PlayerWanted[index].m_Requirements.m_ulOccupations = occupations;
            this.dataGridView_m_PlayerWanted.CurrentRow.Cells[6].Value = occupations;
        }
        public void ChangePlayerWantedForce(int force)
        {
            int index = this.dataGridView_m_PlayerWanted.CurrentCell.RowIndex;
            this.SelectedTask.m_PlayerWanted[index].m_Requirements.m_iForce = force;
            this.dataGridView_m_PlayerWanted.CurrentRow.Cells[10].Value = force;
        }

        private void button_Edit_m_ulDelvWorld_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 1, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }
        private void button_Edit_m_ulEnterRegionWorld_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 2, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }
        private void button_Edit_m_ulLeaveRegionWorld_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 3, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }
        private void button_Edit_m_ulTransWldId_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 4, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }
        private void button_Edit_m_ulReachSiteId_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 5, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }
        private void button_Edit_m_ulLeaveSiteId_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 6, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }
        private void button_Edit_reward_m_ulTransWldId_Click(object sender, EventArgs e)
        {
            SelectWorldIdWindow SelectWorldIdWindow = new SelectWorldIdWindow(this, 7, SelectWorldIdWindow_SelectedItemIndex);
            SelectWorldIdWindow.Show();
        }

        public void ChangeWorldId(int WorldId, int param)
        {
            switch (param)
            {
                case 1:
                    this.SelectedTask.m_ulDelvWorld = WorldId;
                    this.textBox_m_ulDelvWorld.Text = WorldId.ToString();
                    this.ShowInstanceName_m_ulDelvWorld();
                    break;
                case 2:
                    this.SelectedTask.m_ulEnterRegionWorld = WorldId;
                    this.textBox_m_ulEnterRegionWorld.Text = WorldId.ToString();
                    this.ShowInstanceName_m_ulEnterRegionWorld();
                    break;
                case 3:
                    this.SelectedTask.m_ulLeaveRegionWorld = WorldId;
                    this.textBox_m_ulLeaveRegionWorld.Text = WorldId.ToString();
                    this.ShowInstanceName_m_ulLeaveRegionWorld();
                    break;
                case 4:
                    this.SelectedTask.m_ulTransWldId = WorldId;
                    this.textBox_m_ulTransWldId.Text = WorldId.ToString();
                    this.ShowInstanceName_m_ulTransWldId();
                    break;
                case 5:
                    this.SelectedTask.m_ulReachSiteId = WorldId;
                    this.textBox_m_ulReachSiteId.Text = WorldId.ToString();
                    this.ShowInstanceName_m_ulReachSiteId();
                    break;
                case 6:
                    this.SelectedTask.m_ulLeaveSiteId = WorldId;
                    this.textBox_m_ulLeaveSiteId.Text = WorldId.ToString();
                    this.ShowInstanceName_m_ulLeaveSiteId();
                    break;
                case 7:
                    this.SelectedReward.m_ulTransWldId = WorldId;
                    this.textBox_reward_m_ulTransWldId.Text = WorldId.ToString();
                    this.ShowInstanceName_Award_m_ulTransWldId();
                    break;
            }
        }

        private void button_Edit_PremiseIconStateID_Click(object sender, EventArgs e)
        {
            SelectBuffIdWindow SelectBuffIdWindow = new SelectBuffIdWindow(this, 1);
            SelectBuffIdWindow.Show();
        }
        private void button_Edit_TMIconStateID_Click(object sender, EventArgs e)
        {
            SelectBuffIdWindow SelectBuffIdWindow = new SelectBuffIdWindow(this, 2);
            SelectBuffIdWindow.Show();
        }

        public void ChangeBuffId(int BuffId, int param)
        {
            switch (param)
            {
                case 1:
                    this.SelectedTask.PremiseIconStateID = BuffId;
                    this.textBox_PremiseIconStateID.Text = BuffId.ToString();
                    this.ShowBuffDesc_PremiseIconStateID();
                    break;
                case 2:
                    this.SelectedTask.TMIconStateID = BuffId;
                    this.textBox_TMIconStateID.Text = BuffId.ToString();
                    this.ShowBuffDesc_TMIconStateID();
                    break;
            }
        }

        private void button_Edit_m_iDeliveredSkillID_Click(object sender, EventArgs e)
        {
            SelectSkillIdWindow SelectSkillIdWindow = new SelectSkillIdWindow(this, 1);
            SelectSkillIdWindow.Show();
        }
        private void button_Edit_reward_m_iAwardSkillID_Click(object sender, EventArgs e)
        {
            SelectSkillIdWindow SelectSkillIdWindow = new SelectSkillIdWindow(this, 2);
            SelectSkillIdWindow.Show();
        }

        public void ChangeSkillId(int SkillId, int param)
        {
            switch (param)
            {
                case 1:
                    this.SelectedTask.m_iDeliveredSkillID = SkillId;
                    this.textBox_m_iDeliveredSkillID.Text = SkillId.ToString();
                    this.ShowSkillText_m_iDeliveredSkillID();
                    break;
                case 2:
                    this.SelectedReward.m_iAwardSkillID = SkillId;
                    this.textBox_reward_m_iAwardSkillID.Text = SkillId.ToString();
                    this.ShowSkillText_Award_m_iAwardSkillID();
                    break;
            }
        }

        private void button_Edit_reward_m_ulNewRelayStation_Click(object sender, EventArgs e)
        {
            SelectRelayStationIdWindow SelectRelayStationIdWindow = new SelectRelayStationIdWindow(this);
            SelectRelayStationIdWindow.Show();
        }
        public void ChangeRelayStationId(int RelayStationId)
        {

            this.SelectedReward.m_ulNewRelayStation = RelayStationId;
            this.textBox_reward_m_ulNewRelayStation.Text = RelayStationId.ToString();
            this.ShowRelayStationName_Award_m_ulNewRelayStation();
        }
        #endregion

        #region Convert Coords
        private void Convert_m_pDelvRegion(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SelectedTask.m_pDelvRegion.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex;
                this.textBox_m_pDelvRegion_Min_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_y) + ")";
                this.textBox_m_pDelvRegion_Max_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_y) + ")";
            }
            else
            {
                this.textBox_m_pDelvRegion_Min_Client.Text = "0, 0 (0)";
                this.textBox_m_pDelvRegion_Max_Client.Text = "0, 0 (0)";
            }
        }
        private void Convert_m_pEnterRegion(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SelectedTask.m_pEnterRegion.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex;
                this.textBox_m_pEnterRegion_Min_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_y) + ")";
                this.textBox_m_pEnterRegion_Max_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_y) + ")";
            }
            else
            {
                this.textBox_m_pEnterRegion_Min_Client.Text = "0, 0 (0)";
                this.textBox_m_pEnterRegion_Max_Client.Text = "0, 0 (0)";
            }
        }
        private void Convert_m_pLeaveRegion(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SelectedTask.m_pLeaveRegion.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex;
                this.textBox_m_pLeaveRegion_Min_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_y) + ")";
                this.textBox_m_pLeaveRegion_Max_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_y) + ")";
            }
            else
            {
                this.textBox_m_pLeaveRegion_Min_Client.Text = "0, 0 (0)";
                this.textBox_m_pLeaveRegion_Max_Client.Text = "0, 0 (0)";
            }
        }
        private void Convert_m_pReachSite(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SelectedTask.m_pReachSite.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pReachSite.CurrentCell.RowIndex;
                this.textBox_m_pReachSite_Min_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pReachSite[rowIndex].zvMin_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pReachSite[rowIndex].zvMin_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pReachSite[rowIndex].zvMin_y) + ")";
                this.textBox_m_pReachSite_Max_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pReachSite[rowIndex].zvMax_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pReachSite[rowIndex].zvMax_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pReachSite[rowIndex].zvMax_y) + ")";
            }
            else
            {
                this.textBox_m_pReachSite_Min_Client.Text = "0, 0 (0)";
                this.textBox_m_pReachSite_Max_Client.Text = "0, 0 (0)";
            }
        }
        private void Convert_m_pLeaveSite(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SelectedTask.m_pLeaveSite.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex;
                this.textBox_m_pLeaveSite_Min_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_y) + ")";
                this.textBox_m_pLeaveSite_Max_Client.Text = Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_y) + ")";
            }
            else
            {
                this.textBox_m_pLeaveSite_Min_Client.Text = "0, 0 (0)";
                this.textBox_m_pLeaveSite_Max_Client.Text = "0, 0 (0)";
            }
        }

        private void Convert_m_TreasureStartZone()
        {
            if (this.textBox_m_TreasureStartZone_x.Text != "" && this.textBox_m_TreasureStartZone_y.Text != "" && this.textBox_m_TreasureStartZone_z.Text != "")
            {
                this.toolTip.SetToolTip(this.textBox_m_TreasureStartZone_x, Extensions.ConvertToClientX(this.SelectedTask.m_TreasureStartZone.x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_TreasureStartZone.z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_TreasureStartZone.y) + ")");
                this.toolTip.SetToolTip(this.textBox_m_TreasureStartZone_y, Extensions.ConvertToClientX(this.SelectedTask.m_TreasureStartZone.x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_TreasureStartZone.z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_TreasureStartZone.y) + ")");
                this.toolTip.SetToolTip(this.textBox_m_TreasureStartZone_z, Extensions.ConvertToClientX(this.SelectedTask.m_TreasureStartZone.x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_TreasureStartZone.z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_TreasureStartZone.y) + ")");
            }
        }
        private void Convert_m_TransPt()
        {
            if (this.textBox_m_TransPt_x.Text != "" && this.textBox_m_TransPt_y.Text != "" && this.textBox_m_TransPt_z.Text != "")
            {
                this.toolTip.SetToolTip(this.textBox_m_TransPt_x, Extensions.ConvertToClientX(this.SelectedTask.m_TransPt.x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_TransPt.z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_TransPt.y) + ")");
                this.toolTip.SetToolTip(this.textBox_m_TransPt_y, Extensions.ConvertToClientX(this.SelectedTask.m_TransPt.x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_TransPt.z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_TransPt.y) + ")");
                this.toolTip.SetToolTip(this.textBox_m_TransPt_z, Extensions.ConvertToClientX(this.SelectedTask.m_TransPt.x) + ", " + Extensions.ConvertToClientZ(this.SelectedTask.m_TransPt.z) + " (" + Extensions.ConvertToClientY(this.SelectedTask.m_TransPt.y) + ")");
            }
        }
        private void Convert_reward_m_TransPt()
        {
            if (this.textBox_reward_m_TransPt_x.Text != "" && this.textBox_reward_m_TransPt_y.Text != "" && this.textBox_reward_m_TransPt_z.Text != "")
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_TransPt_x, Extensions.ConvertToClientX(this.SelectedReward.m_TransPt.x) + ", " + Extensions.ConvertToClientZ(this.SelectedReward.m_TransPt.z) + " (" + Extensions.ConvertToClientY(this.SelectedReward.m_TransPt.y) + ")");
                this.toolTip.SetToolTip(this.textBox_reward_m_TransPt_y, Extensions.ConvertToClientX(this.SelectedReward.m_TransPt.x) + ", " + Extensions.ConvertToClientZ(this.SelectedReward.m_TransPt.z) + " (" + Extensions.ConvertToClientY(this.SelectedReward.m_TransPt.y) + ")");
                this.toolTip.SetToolTip(this.textBox_reward_m_TransPt_z, Extensions.ConvertToClientX(this.SelectedReward.m_TransPt.x) + ", " + Extensions.ConvertToClientZ(this.SelectedReward.m_TransPt.z) + " (" + Extensions.ConvertToClientY(this.SelectedReward.m_TransPt.y) + ")");
            }
        }
        #endregion

        private void Count_m_ulGivenCmnCount_m_ulGivenTskCount()
        {
            int GivenCmnCount = 0;
            int GivenTskCount = 0;
            for (int i = 0; i < SelectedTask.m_GivenItems.Length; i++)
            {
                if (SelectedTask.m_GivenItems[i].m_bCommonItem == true)
                {
                    GivenCmnCount++;
                }
                if (SelectedTask.m_GivenItems[i].m_bCommonItem == false)
                {
                    GivenTskCount++;
                }
            }
            this.textBox_m_ulGivenCmnCount.Text = GivenCmnCount.ToString();
            this.textBox_m_ulGivenTskCount.Text = GivenTskCount.ToString();
            this.SelectedTask.m_ulGivenCmnCount = GivenCmnCount;
            this.SelectedTask.m_ulGivenTskCount = GivenTskCount;
        }

        public void LoadImageLists()
        {
            try
            {
                imageList1 = new ImageList();
                imageList1.ImageSize = new Size(22, 22);
                imageList1.ColorDepth = ColorDepth.Depth32Bit;
                imageList1.Images.Add(Resources.icon_0);
                imageList1.Images.Add(Resources.icon_1);
                imageList1.Images.Add(Resources.icon_2);
                imageList1.Images.Add(Resources.icon_3);
                imageList1.Images.Add(Resources.icon_4);
                imageList1.Images.Add(Resources.icon_5);
                this.jPictureBox3.BackColor = System.Drawing.Color.Transparent;
                this.jPictureBox3.ImageList = imageList1;
                this.jPictureBox3.ImageIndex = 0;
                imageList2 = new ImageList();
                imageList2.ImageSize = new Size(16, 16);
                imageList2.ColorDepth = ColorDepth.Depth32Bit;
                imageList2.Images.Add(Resources.icon_0_0);
                imageList2.Images.Add(Resources.icon_0_1);
                imageList2.Images.Add(Resources.icon_1_0);
                imageList2.Images.Add(Resources.icon_1_1);
                imageList2.Images.Add(Resources.icon_2_0);
                imageList2.Images.Add(Resources.icon_2_1);
                imageList2.Images.Add(Resources.icon_3_0);
                imageList2.Images.Add(Resources.icon_3_1);
                imageList2.Images.Add(Resources.icon_4_0);
                imageList2.Images.Add(Resources.icon_4_1);
                imageList2.Images.Add(Resources.icon_5_0);
                imageList2.Images.Add(Resources.icon_5_1);
                imageList2.Images.Add(Resources.icon_gm);
                this.treeView_tasks.ImageList = imageList2;
                this.treeView_tasks.ImageIndex = 0;
                this.treeView_tasks.SelectedImageIndex = 0;
            }
            catch (Exception e)
            {
                JMessageBox.Show(this, "NOT FOUND " + e.Message + "!");
            }
        }
        #endregion

        #region Detect NPC Name, Instance Name, Buff Description, Skill Text, Relay Station Name
        private void ShowNPCName_m_ulDelvNPC()
        {
            if (SelectedTask.m_ulDelvNPC != 0)
            {
                if (LoadedElements == true)
                {
                    this.toolTip.SetToolTip(this.textBox_m_ulDelvNPC, Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(SelectedTask.m_ulDelvNPC)));
                }
            }
            else
            {
                this.toolTip.SetToolTip(this.textBox_m_ulDelvNPC, Extensions.GetLocalization(2310));
            }
        }
        private void ShowNPCName_m_ulAwardNPC()
        {
            if (SelectedTask.m_ulAwardNPC != 0)
            {
                if (LoadedElements == true)
                {
                    this.toolTip.SetToolTip(this.textBox_m_ulAwardNPC, Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(SelectedTask.m_ulAwardNPC)));
                }
            }
            else
            {
                this.toolTip.SetToolTip(this.textBox_m_ulAwardNPC, Extensions.GetLocalization(2310));
            }
        }
        private void ShowInstanceName_m_ulDelvWorld()
        {
            this.toolTip.SetToolTip(this.textBox_m_ulDelvWorld, Extensions.InstanceName(SelectedTask.m_ulDelvWorld).name);
        }
        private void ShowInstanceName_m_ulEnterRegionWorld()
        {
            this.toolTip.SetToolTip(this.textBox_m_ulEnterRegionWorld, Extensions.InstanceName(SelectedTask.m_ulEnterRegionWorld).name);
        }
        private void ShowInstanceName_m_ulLeaveRegionWorld()
        {
            this.toolTip.SetToolTip(this.textBox_m_ulLeaveRegionWorld, Extensions.InstanceName(SelectedTask.m_ulLeaveRegionWorld).name);
        }
        private void ShowInstanceName_m_ulReachSiteId()
        {
            this.toolTip.SetToolTip(this.textBox_m_ulReachSiteId, Extensions.InstanceName(SelectedTask.m_ulReachSiteId).name);
        }
        private void ShowInstanceName_m_ulLeaveSiteId()
        {
            this.toolTip.SetToolTip(this.textBox_m_ulLeaveSiteId, Extensions.InstanceName(SelectedTask.m_ulLeaveSiteId).name);
        }
        private void ShowInstanceName_m_ulTransWldId()
        {
            this.toolTip.SetToolTip(this.textBox_m_ulTransWldId, Extensions.InstanceName(SelectedTask.m_ulTransWldId).name);
        }
        private void ShowInstanceName_Award_m_ulTransWldId()
        {
            if (SelectedReward != null)
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_ulTransWldId, Extensions.InstanceName(SelectedReward.m_ulTransWldId).name);
            }
            else
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_ulTransWldId, Extensions.InstanceName(0).name);
            }
        }

        private void Change_InstanceNameLang(object sender, EventArgs e)
        {
            /*this.LoadInstanceList();
            if (SelectedTask != null)
            {
                this.ShowInstanceName_m_ulDelvWorld();
                this.ShowInstanceName_m_ulEnterRegionWorld();
                this.ShowInstanceName_m_ulLeaveRegionWorld();
                this.ShowInstanceName_m_ulReachSiteId();
                this.ShowInstanceName_m_ulLeaveSiteId();
                this.ShowInstanceName_m_ulTransWldId();
                this.ShowInstanceName_Award_m_ulTransWldId();
            }*/
        }

        private void ShowBuffDesc_PremiseIconStateID()
        {
            this.toolTip.SetToolTip(this.textBox_PremiseIconStateID, Extensions.BuffDesc(SelectedTask.PremiseIconStateID));
        }
        private void ShowBuffDesc_TMIconStateID()
        {
            this.toolTip.SetToolTip(this.textBox_TMIconStateID, Extensions.BuffDesc(SelectedTask.TMIconStateID));
        }

        private void ShowSkillText_m_iDeliveredSkillID()
        {
            this.toolTip.SetToolTip(this.textBox_m_iDeliveredSkillID, Extensions.SkillText(SelectedTask.m_iDeliveredSkillID));
        }
        private void ShowSkillText_Award_m_iAwardSkillID()
        {
            if (SelectedReward != null)
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_iAwardSkillID, Extensions.SkillText(SelectedReward.m_iAwardSkillID));
            }
            else
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_iAwardSkillID, Extensions.SkillText(0));
            }
        }

        private void ShowRelayStationName_Award_m_ulNewRelayStation()
        {
            if (SelectedReward != null)
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_ulNewRelayStation, Extensions.RelayStationName(SelectedReward.m_ulNewRelayStation));
            }
            else
            {
                this.toolTip.SetToolTip(this.textBox_reward_m_ulNewRelayStation, Extensions.RelayStationName(0));
            }
        }
        #endregion

        private void CalculationExpAndSPDependingOnLvlAndNum(object sender, EventArgs e)
        {
            int exp = Convert.ToInt32(this.SelectedReward.m_ulExp * ModifierTable.GetModifier(Convert.ToInt32(this.numericUpDown_Lvl.Value)) * this.numericUpDown_Num.Value);
            this.textBox_Exp.Text = exp.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
            int sp = Convert.ToInt32(this.SelectedReward.m_ulSP * ModifierTable.GetModifier(Convert.ToInt32(this.numericUpDown_Lvl.Value)) * this.numericUpDown_Num.Value);
            this.textBox_SP.Text = sp.ToString(ValueFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
        }

        #region Show\Hide
        private void ShowHide()
        {
            if (this.radioButton_m_Award_S.Checked)
            {
                if (this.checkBox_reward_m_bUseLevCo.Checked || this.SelectedTask.m_ulAwardType_S == 1)
                {
                    this.textBox_Exp.Visible = true;
                    this.numericUpDown_Lvl.Visible = true;
                    this.numericUpDown_Num.Visible = true;
                    this.textBox_SP.Visible = true;
                }
                else
                {
                    this.textBox_Exp.Visible = false;
                    this.numericUpDown_Lvl.Visible = false;
                    this.numericUpDown_Num.Visible = false;
                    this.textBox_SP.Visible = false;
                }
            }
            if (this.radioButton_m_Award_F.Checked)
            {
                if (this.checkBox_reward_m_bUseLevCo.Checked || this.SelectedTask.m_ulAwardType_F == 1)
                {
                    this.textBox_Exp.Visible = true;
                    this.numericUpDown_Lvl.Visible = true;
                    this.numericUpDown_Num.Visible = true;
                    this.textBox_SP.Visible = true;
                }
                else
                {
                    this.textBox_Exp.Visible = false;
                    this.numericUpDown_Lvl.Visible = false;
                    this.numericUpDown_Num.Visible = false;
                    this.textBox_SP.Visible = false;
                }
            }
            if (this.radioButton_m_AwByRatio_S.Checked)
            {
                if (this.checkBox_reward_m_bUseLevCo.Checked || this.SelectedTask.m_ulAwardType_S == 1)
                {
                    this.textBox_Exp.Visible = true;
                    this.numericUpDown_Lvl.Visible = true;
                    this.numericUpDown_Num.Visible = true;
                    this.textBox_SP.Visible = true;
                }
                else
                {
                    this.textBox_Exp.Visible = false;
                    this.numericUpDown_Lvl.Visible = false;
                    this.numericUpDown_Num.Visible = false;
                    this.textBox_SP.Visible = false;
                }
            }
            if (this.radioButton_m_AwByRatio_F.Checked)
            {
                if (this.checkBox_reward_m_bUseLevCo.Checked || this.SelectedTask.m_ulAwardType_F == 1)
                {
                    this.textBox_Exp.Visible = true;
                    this.numericUpDown_Lvl.Visible = true;
                    this.numericUpDown_Num.Visible = true;
                    this.textBox_SP.Visible = true;
                }
                else
                {
                    this.textBox_Exp.Visible = false;
                    this.numericUpDown_Lvl.Visible = false;
                    this.numericUpDown_Num.Visible = false;
                    this.textBox_SP.Visible = false;
                }
            }
        }
        #endregion

        #region Сhange Color And Icon
        private void change_ColorAndIcon()
        {
            string m_szName22 = this.SelectedTask.Name;
            Color c22 = Color.White;
            if (this.SelectedTask.m_ulType == 0)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 1)
            {
                this.jPictureBox3.ImageIndex = 4;
                this.treeView_tasks.SelectedNode.ImageIndex = 8;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 9;
            }
            if (this.SelectedTask.m_ulType == 2)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 3)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            };
            if (this.SelectedTask.m_ulType == 4)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 5)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 6)
            {
                this.jPictureBox3.ImageIndex = 2;
                this.treeView_tasks.SelectedNode.ImageIndex = 4;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 5;
            }
            if (this.SelectedTask.m_ulType == 7)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 8)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 9)
            {
                this.jPictureBox3.ImageIndex = 3;
                this.treeView_tasks.SelectedNode.ImageIndex = 6;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 7;
            }
            if (this.SelectedTask.m_ulType == 10)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 11)
            {
                this.jPictureBox3.ImageIndex = 3;
                this.treeView_tasks.SelectedNode.ImageIndex = 6;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 7;
            }
            if (this.SelectedTask.m_ulType == 12)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
            }
            if (this.SelectedTask.m_ulType == 100)
            {
                this.jPictureBox3.ImageIndex = 4;
                this.treeView_tasks.SelectedNode.ImageIndex = 8;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 9;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(185)))), ((int)(((byte)(250)))));
                }
            }
            if (this.SelectedTask.m_ulType == 101)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(156)))), ((int)(((byte)(15)))));
                }
            }
            if (this.SelectedTask.m_ulType == 102)
            {
                this.jPictureBox3.ImageIndex = 5;
                this.treeView_tasks.SelectedNode.ImageIndex = 10;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 11;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
                }
            }
            if (this.SelectedTask.m_ulType == 103)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
            }
            if (this.SelectedTask.m_ulType == 104)
            {
                this.jPictureBox3.ImageIndex = 4;
                this.treeView_tasks.SelectedNode.ImageIndex = 8;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 9;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                }
            }
            if (this.SelectedTask.m_ulType == 105)
            {
                this.jPictureBox3.ImageIndex = 3;
                this.treeView_tasks.SelectedNode.ImageIndex = 6;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 7;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
                }
            }
            if (this.SelectedTask.m_ulType == 106)
            {
                this.jPictureBox3.ImageIndex = 2;
                this.treeView_tasks.SelectedNode.ImageIndex = 4;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 5;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                }
            }
            if (this.SelectedTask.m_ulType == 107)
            {
                this.jPictureBox3.ImageIndex = 2;
                this.treeView_tasks.SelectedNode.ImageIndex = 4;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 5;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
                }
            }
            if (this.SelectedTask.m_ulType == 108)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
                if (version >= 120)
                {
                    if (version >= 127)
                    {
                        c22 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    }
                    else
                    {
                        c22 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
                    }
                }
            }
            if (this.SelectedTask.m_ulType == 109)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(255)))), ((int)(((byte)(216)))));
                }
            }
            if (this.SelectedTask.m_ulType == 110)
            {
                this.jPictureBox3.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.ImageIndex = 0;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 1;
                if (version >= 120)
                {
                    c22 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
                }
            }
            if (SelectedTask.m_bKeyTask == true)
            {
                c22 = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(156)))), ((int)(((byte)(15)))));
                this.jPictureBox3.ImageIndex = 1;
                this.treeView_tasks.SelectedNode.ImageIndex = 2;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 3;
            }
            if (SelectedTask.m_bGM == true)
            {
                this.treeView_tasks.SelectedNode.ImageIndex = 12;
                this.treeView_tasks.SelectedNode.SelectedImageIndex = 12;
            }
            if (m_szName22.StartsWith("^"))
            {
                try
                {
                    if (version <= 9999)
                    {
                        c22 = Color.FromArgb(int.Parse(m_szName22.Substring(1, 6), NumberStyles.HexNumber));
                    }
                    if (SelectedTask.m_ulType == 105 || SelectedTask.m_ulType == 110)
                    {
                        if (SelectedTask.m_bKeyTask == false)
                        {
                            c22 = Color.FromArgb(int.Parse(m_szName22.Substring(1, 6), NumberStyles.HexNumber));
                        }
                    }
                    m_szName22 = m_szName22.Substring(7);
                }
                catch
                {
                    c22 = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(156)))), ((int)(((byte)(15)))));
                }
            }
            this.textBox_m_szName.ForeColor = c22;
            this.treeView_tasks.SelectedNode.ForeColor = c22;
        }
        #endregion

        #region Switch Show Digits And Percents

        private void CheckShowDigits()
        {
            if (lEnableShowDigits == true)
            {
                ValueFormat = "N0";
            }
            else
            {
                ValueFormat = "";
            }
        }
        private void CheckShowPercents()
        {
            if (lEnableShowPercents == true)
            {
                ProbValueFormat = "P4";
                ProbAddValueFormat = "100,0000%";
            }
            else
            {
                ProbValueFormat = "F6";
                ProbAddValueFormat = "1,000000";
            }
        }
        #endregion

        #region Preview Text
        private void textBox_conversation_m_pwstrDescript_Click(object sender, EventArgs e)
        {
            this.FormatingString(1);
        }
        private void textBox_conversation_m_pwstrTribute_Click(object sender, EventArgs e)
        {
            this.FormatingString(2);
        }
        private void textBox_conversation_m_pwstrOkText_Click(object sender, EventArgs e)
        {
            this.FormatingString(3);
        }
        private void textBox_conversation_m_pwstrNoText_Click(object sender, EventArgs e)
        {
            this.FormatingString(4);
        }
        private void textBox_conversation_window_talk_text_Click(object sender, EventArgs e)
        {
            this.FormatingString(5);
        }

        private void FormatingString(int param)
        {
            if (Selecting == false)
            {
                string line = "";
                switch (param)
                {
                    case 1:
                        line = this.textBox_conversation_m_pwstrDescript.Text;
                        break;
                    case 2:
                        line = this.textBox_conversation_m_pwstrTribute.Text;
                        break;
                    case 3:
                        line = this.textBox_conversation_m_pwstrOkText.Text;
                        break;
                    case 4:
                        line = this.textBox_conversation_m_pwstrNoText.Text;
                        break;
                    case 5:
                        line = this.textBox_conversation_window_talk_text.Text;
                        break;
                }
                string defaultcolor = "^FFFFFF";
                if (param == 2 && this.SelectedReward != null)
                {
                    switch (this.SelectedReward.m_nMsgChannel)
                    {
                        case 0:
                            defaultcolor = "^FFFFFF";
                            break;
                        case 1:
                            defaultcolor = "^FFE400";
                            break;
                        case 2:
                            defaultcolor = "^00FF00";
                            break;
                        case 3:
                            defaultcolor = "^00FFFC";
                            break;
                        case 4:
                            defaultcolor = "^0065FE";
                            break;
                        case 5:
                            defaultcolor = "^C0C0C0";
                            break;
                        case 6:
                            defaultcolor = "^FF7E00";
                            break;
                        case 7:
                            defaultcolor = "^FF742E";
                            break;
                        case 8:
                            defaultcolor = "^BED293";
                            break;
                        case 9:
                            defaultcolor = "^FF3600";
                            break;
                        case 10:
                            defaultcolor = "^9AA6FF";
                            break;
                        case 11:
                            defaultcolor = "^EC0D3C";
                            break;
                        case 12:
                            defaultcolor = "^FF9B3E";
                            break;
                        case 13:
                            defaultcolor = "^FFFFFF";
                            break;
                        case 14:
                            defaultcolor = "^FFFFFF";
                            break;
                        case 15:
                            defaultcolor = "^8A2BE2";
                            break;
                    }
                }
                Color tmp = Color.FromArgb(int.Parse(defaultcolor.Substring(1, 6), NumberStyles.HexNumber));
                string[] blocks = line.Split(new char[] { '^' });
                if (blocks.Length > 1)
                {
                    int le1 = 0;
                    this.richTextBox_PreviewText.Text = "";
                    le1 = (line.IndexOf('^', 0));
                    this.richTextBox_PreviewText.AppendText(string.Format(line.Substring(0, le1)));
                    this.richTextBox_PreviewText.Select(0, le1);
                    this.richTextBox_PreviewText.SelectionColor = tmp;
                    string result = "";

                    if (blocks[0] != "")
                    {
                        result += blocks[0];
                    }

                    int le = 0;
                    int st = 0;
                    Color color = tmp;
                    for (int i = 1; i < blocks.Length; i++)
                    {
                        if (blocks[i] != "")
                        {
                            st = this.richTextBox_PreviewText.Text.Length;
                            try
                            {
                                if (blocks[i].Substring(0, 6).ToUpper() == "FFFFFF")
                                {
                                    color = tmp;
                                }
                                else
                                {
                                    color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                                }
                                this.richTextBox_PreviewText.AppendText(string.Format(blocks[i].Substring(6)));
                            }
                            catch
                            {
                                this.richTextBox_PreviewText.AppendText(string.Format("^" + blocks[i]));
                            }
                            le = this.richTextBox_PreviewText.Text.Length - st;
                            this.richTextBox_PreviewText.Select(st, le);
                            this.richTextBox_PreviewText.SelectionColor = color;
                        }
                    }
                }
                else
                {
                    this.richTextBox_PreviewText.Text = line;
                    this.richTextBox_PreviewText.Select(0, this.richTextBox_PreviewText.Text.Length);
                    this.richTextBox_PreviewText.SelectionColor = tmp;
                }
                if (param == 5 || param == 2)
                {
                    string textWord = "$name";
                    string[] S = textWord.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in S)
                    {
                        if (s.Length >= 3)
                        {
                            int at = 0;
                            int start = this.richTextBox_PreviewText.Text.Length - 1;
                            while ((start > -1) && (at > -1))
                            {
                                at = this.richTextBox_PreviewText.Text.LastIndexOf(s, start);
                                if (at > -1)
                                {
                                    this.richTextBox_PreviewText.Select(at, s.Length);
                                    this.richTextBox_PreviewText.SelectionColor = Color.FromArgb(225, 220, 138);
                                    start = at - 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FormatingString_m_pTaskChar()
        {
            string line = "";
            for (int k = 0; k < this.dataGridView_m_pTaskChar.Rows.Count; k++)
            {
                if (this.dataGridView_m_pTaskChar.Rows[k].Cells[0].Value != null)
                {
                    line += this.dataGridView_m_pTaskChar.Rows[k].Cells[0].Value.ToString() + "\n^ffffff";
                }
            }
            string[] blocks = line.Split(new char[] { '^' });
            if (blocks.Length > 1)
            {
                int le1 = 0;
                this.richTextBox_PreviewText_m_pTaskChar.Text = "";
                le1 = (line.IndexOf('^', 0));
                this.richTextBox_PreviewText_m_pTaskChar.AppendText(string.Format(line.Substring(0, le1)));
                this.richTextBox_PreviewText_m_pTaskChar.Select(0, le1);
                this.richTextBox_PreviewText_m_pTaskChar.SelectionColor = Color.White;
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
                        st = this.richTextBox_PreviewText_m_pTaskChar.Text.Length;
                        try
                        {
                            color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                            this.richTextBox_PreviewText_m_pTaskChar.AppendText(string.Format(blocks[i].Substring(6)));
                        }
                        catch
                        {
                            this.richTextBox_PreviewText_m_pTaskChar.AppendText(string.Format("^" + blocks[i]));
                        }
                        le = this.richTextBox_PreviewText_m_pTaskChar.Text.Length - st;
                        this.richTextBox_PreviewText_m_pTaskChar.Select(st, le);
                        this.richTextBox_PreviewText_m_pTaskChar.SelectionColor = color;
                    }
                }
            }
            else
            {
                this.richTextBox_PreviewText_m_pTaskChar.Text = line;
                this.richTextBox_PreviewText_m_pTaskChar.Select(0, this.richTextBox_PreviewText_m_pTaskChar.Text.Length);
                this.richTextBox_PreviewText_m_pTaskChar.SelectionColor = Color.White;
            }
        }
        #endregion

        #region Show Info
        private void dataGridView_m_MonstersContrib_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_m_MonstersContrib.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(Id));
                    }
                    this.dataGridView_m_MonstersContrib.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_MonstersContrib.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_MonstersContrib_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_MonstersContrib_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_m_PremItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_m_PremItems.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, 0));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_m_PremItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_PremItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_PremItems_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_PremItems_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_m_GivenItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_m_GivenItems.Rows[e.RowIndex].Cells[0].Value);
                    uint Period = Extensions.StringToSecond(Convert.ToString(this.dataGridView_m_GivenItems.Rows[e.RowIndex].Cells[5].Value));
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, Period));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_m_GivenItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_GivenItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_GivenItems_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_GivenItems_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_m_PremTitles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_m_PremTitles.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetTitleProps(Id));
                    }
                    this.dataGridView_m_PremTitles.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_PremTitles.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_PremTitles_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_PremTitles_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_m_PlayerWanted_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 1 && e.ColumnIndex < 3 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_m_PlayerWanted.Rows[e.RowIndex].Cells[1].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, 0));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_m_PlayerWanted.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_PlayerWanted.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_PlayerWanted_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_PlayerWanted_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_m_MonsterWanted_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 5 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    if (e.ColumnIndex >= 3 && e.ColumnIndex < 5 && e.RowIndex > -1)
                    {
                        int Id = Convert.ToInt32(this.dataGridView_m_MonsterWanted.Rows[e.RowIndex].Cells[3].Value);
                        if (Id > 0)
                        {
                            if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, 0));
                            text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                        }
                    }
                    if (e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
                    {
                        int Id = Convert.ToInt32(this.dataGridView_m_MonsterWanted.Rows[e.RowIndex].Cells[0].Value);
                        if (Id > 0)
                        {
                            if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(Id));
                        }
                    }
                    this.dataGridView_m_MonsterWanted.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_MonsterWanted.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_MonsterWanted_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_MonsterWanted_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_m_ItemsWanted_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_m_ItemsWanted.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, 0));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_m_ItemsWanted.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_m_ItemsWanted.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_m_ItemsWanted_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_m_ItemsWanted_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_TMHomeItem_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_TMHomeItem.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetHomeItemProps(Id));
                    }
                    this.dataGridView_TMHomeItem.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_TMHomeItem.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_TMHomeItem_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_TMHomeItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_reward_item_m_AwardItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {

                if (e.ColumnIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    InfoTool ift = null;
                    try
                    {
                        int xe = e.RowIndex;
                        int Id = Convert.ToInt32(this.dataGridView_reward_item_m_AwardItems.Rows[e.RowIndex].Cells[0].Value);
                        if (Id > 0)
                        {
                            ift = Extensions.GetItemProps2byId(Id, 0);
                        }
                        if (ift != null)
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
                /*
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_reward_item_m_AwardItems.Rows[e.RowIndex].Cells[0].Value);
                    uint Period = Extensions.StringToSecond(Convert.ToString(this.dataGridView_reward_item_m_AwardItems.Rows[e.RowIndex].Cells[5].Value));
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, Period));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_reward_item_m_AwardItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_reward_item_m_AwardItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                */
            }
        }
        private void dataGridView_reward_item_m_AwardItems_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_reward_item_m_AwardItems_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_reward_m_Monsters_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_reward_m_Monsters.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetMonsterNPCMineProps(Id));
                    }
                    this.dataGridView_reward_m_Monsters.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_reward_m_Monsters.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_reward_m_Monsters_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_reward_m_Monsters_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_reward_m_RankingAward_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 3 && e.ColumnIndex < 5 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_reward_m_RankingAward.Rows[e.RowIndex].Cells[3].Value);
                    uint Period = Extensions.StringToSecond(Convert.ToString(this.dataGridView_reward_m_RankingAward.Rows[e.RowIndex].Cells[6].Value));
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetItemProps(Id, Period));
                        text += Extensions.ColorClean(Extensions.ItemDesc(Id));
                    }
                    this.dataGridView_reward_m_RankingAward.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_reward_m_RankingAward.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_reward_m_RankingAward_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_reward_m_RankingAward_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        private void dataGridView_reward_m_pTitleAward_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Scrolling == false && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
            {
                String text = "";
                try
                {
                    int Id = Convert.ToInt32(this.dataGridView_reward_m_pTitleAward.Rows[e.RowIndex].Cells[0].Value);
                    if (Id > 0)
                    {
                        if (LoadedElements == true) text += Extensions.ColorClean(Extensions.GetTitleProps(Id));
                    }
                    this.dataGridView_reward_m_pTitleAward.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
                catch
                {
                    this.dataGridView_reward_m_pTitleAward.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                }
            }
        }
        private void dataGridView_reward_m_pTitleAward_Scroll(object sender, ScrollEventArgs e)
        {
            Scrolling = true;
        }
        private void dataGridView_reward_m_pTitleAward_MouseMove(object sender, MouseEventArgs e)
        {
            if (Scrolling == true) Scrolling = false;
        }

        #endregion

        #region Get Midle Client Coords
        private void dataGridView_m_pDelvRegion_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt && e.Button == MouseButtons.Left && this.SelectedTask.m_pDelvRegion.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pDelvRegion.CurrentCell.RowIndex;
                int xMin = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_x));
                int yMin = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_y));
                int zMin = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pDelvRegion[rowIndex].zvMin_z));
                int xMax = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_x));
                int yMax = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_y));
                int zMax = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pDelvRegion[rowIndex].zvMax_z));
                Clipboard.SetText(Convert.ToString(xMin + ((xMax - xMin) / 2)) + ", " + Convert.ToString(zMin + ((zMax - zMin) / 2)) + " (" + yMin + "-" + yMax + ")");
            }
        }
        private void dataGridView_m_pEnterRegion_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt && e.Button == MouseButtons.Left && this.SelectedTask.m_pEnterRegion.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pEnterRegion.CurrentCell.RowIndex;
                int xMin = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_x));
                int yMin = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_y));
                int zMin = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pEnterRegion[rowIndex].zvMin_z));
                int xMax = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_x));
                int yMax = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_y));
                int zMax = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pEnterRegion[rowIndex].zvMax_z));
                Clipboard.SetText(Convert.ToString(xMin + ((xMax - xMin) / 2)) + ", " + Convert.ToString(zMin + ((zMax - zMin) / 2)) + " (" + yMin + "-" + yMax + ")");
            }
        }
        private void dataGridView_m_pLeaveRegion_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt && e.Button == MouseButtons.Left && this.SelectedTask.m_pLeaveRegion.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pLeaveRegion.CurrentCell.RowIndex;
                int xMin = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_x));
                int yMin = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_y));
                int zMin = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMin_z));
                int xMax = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_x));
                int yMax = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_y));
                int zMax = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveRegion[rowIndex].zvMax_z));
                Clipboard.SetText(Convert.ToString(xMin + ((xMax - xMin) / 2)) + ", " + Convert.ToString(zMin + ((zMax - zMin) / 2)) + " (" + yMin + "-" + yMax + ")");
            }
        }
        private void dataGridView_m_pReachSite_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt && e.Button == MouseButtons.Left && this.SelectedTask.m_pReachSite.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pReachSite.CurrentCell.RowIndex;
                int xMin = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pReachSite[rowIndex].zvMin_x));
                int yMin = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pReachSite[rowIndex].zvMin_y));
                int zMin = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pReachSite[rowIndex].zvMin_z));
                int xMax = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pReachSite[rowIndex].zvMax_x));
                int yMax = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pReachSite[rowIndex].zvMax_y));
                int zMax = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pReachSite[rowIndex].zvMax_z));
                Clipboard.SetText(Convert.ToString(xMin + ((xMax - xMin) / 2)) + ", " + Convert.ToString(zMin + ((zMax - zMin) / 2)) + " (" + yMin + "-" + yMax + ")");
            }
        }
        private void dataGridView_m_pLeaveSite_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt && e.Button == MouseButtons.Left && this.SelectedTask.m_pLeaveSite.Length != 0)
            {
                int rowIndex = this.dataGridView_m_pLeaveSite.CurrentCell.RowIndex;
                int xMin = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_x));
                int yMin = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_y));
                int zMin = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveSite[rowIndex].zvMin_z));
                int xMax = Convert.ToInt32(Extensions.ConvertToClientX(this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_x));
                int yMax = Convert.ToInt32(Extensions.ConvertToClientY(this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_y));
                int zMax = Convert.ToInt32(Extensions.ConvertToClientZ(this.SelectedTask.m_pLeaveSite[rowIndex].zvMax_z));
                Clipboard.SetText(Convert.ToString(xMin + ((xMax - xMin) / 2)) + ", " + Convert.ToString(zMin + ((zMax - zMin) / 2)) + " (" + yMin + "-" + yMax + ")");
            }
        }
        #endregion

        private int MainWindow_Width;



        private void numericUpDown_NewID_ValueChanged(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this.numericUpDown_NewID, Extensions.GetLocalization(6053) + this.numericUpDown_NewID.Value);
        }

        #region Setings
        public Boolean lEnableChangeConf = false;
        public Boolean lEnableShowTips = true;
        public int lPWDBLang = 0;
        public Boolean lEnableBackups = true;
        public Boolean lEnableToClipboard = true;
        public static int lLang = 0;
        public Boolean lEnableShowDigits = false;
        public Boolean lEnableShowPercents = false;
        public Boolean lEnableAutoLoadElements = false;
        public string lElementsPath = "";
        public Boolean lEnableShowInfo = true;
        public Boolean lEnableSetNewID = true;
        public Boolean lEnableAutoDetectNewID = true;

        #endregion


        private void click_ExportTask(object sender, EventArgs e)
        {         
           
            if (this.Tasks != null)
            {
                if (this.treeView_tasks.SelectedNodes.Count == 0) { JMessageBox.Show(this, "Please select tasks to export!"); return; }
                progressShow(Extensions.GetLocalization(504), 0, 0);
                
                string m_szName = this.SelectedTask.Name;
                if (m_szName.StartsWith("^"))
                {
                    m_szName = m_szName.Substring(7);
                }
                SaveFileDialog dialog = new SaveFileDialog
                {
                    FileName = "" + this.SelectedTask.ID + " - " + m_szName + ".gqe",
                    Filter = "Task ExportQuest (*.gqe)|*.gqe|All Files (*.*)|*.*"
                };
                if (dialog.ShowDialog() == DialogResult.OK && dialog.FileName != "")
                {
                    try
                    {
                        //this.Cursor = Cursors.AppStarting;
                        List<byte[]> export = new List<byte[]>();
                        for (int i = 0; i < this.treeView_tasks.SelectedNodes.Count; i++)
                        {
                           // Application.DoEvents();
                            this.SelectedTask = this.Tasks[((TreeNode)this.treeView_tasks.SelectedNodes[i]).Index];
                            MemoryStream output = new MemoryStream();
                            output.Position = 0;
                            BinaryWriter bw = new BinaryWriter(output);
                            int num2 = version;
                            bw.Write(0);
                            bw.Write(num2);
                            bw.Write(1);
                            bw.Write(16);
                            this.SelectedTask.Save(num2, bw);
                            bw.Close();
                            export.Add(output.ToArray());
                            progressShow(Extensions.GetLocalization(513), i, this.treeView_tasks.SelectedNodes.Count);

                        }
                        FileStream fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, export);
                        fs.Close();
                        //this.Cursor = Cursors.Default;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(464));
                        //this.Cursor = Cursors.Default;
                    }
                }
            }else
            {
                JMessageBox.Show(this, "Please load tasks.data!");
            }

            progressShow(Extensions.GetLocalization(499), 0, 0);        
        }

        private void click_ImportTask(object sender, EventArgs e)
        {
            if(this.Tasks == null) { JMessageBox.Show(this, "Please load tasks.data!"); return; }
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Task ExportQuest (*.gqe)|*.gqe|All Files (*.*)|*.*"
            };
            dialog.Multiselect = true;
            LockedSelecting = true;
            if (dialog.ShowDialog() == DialogResult.OK && dialog.FileNames != null && dialog.FileNames.Length > 0)
            {
                foreach (string filename in dialog.FileNames)
                {
                    using (Stream file = File.Open(filename, FileMode.Open))
                    {

                        BinaryFormatter bf = new BinaryFormatter();
                        List<byte[]> obj = (List<byte[]>)bf.Deserialize(file);

                        for (int i = 0; i < obj.Count; i++)
                        {
                            MemoryStream test = new MemoryStream(obj[i]);
                            importMs(test);
                           // Application.DoEvents();
                            progressShow("Exporting...", i, obj.Count);
                        }

                        file.Close();
                    }
                }
            }
            LockedSelecting = false;
            this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
            if (this.checkBox_SetNewID.Checked) this.treeView_tasks.EndUpdate();
            progressShow(Extensions.GetLocalization(499), 0, 0);
            this.numericUpDown_NewID.Value = NewID;
            this.listBox_conversation_talk_procs.SelectedIndex = 0;
        }


        private void importMs(MemoryStream input)
        {

            progressShow(Extensions.GetLocalization(507), 0, 0);
            if (this.Tasks != null)
            {
                NewID = Convert.ToInt32(this.numericUpDown_NewID.Value);
                if (this.checkBox_SetNewID.Checked) this.treeView_tasks.BeginUpdate();
                    try
                    {
                        //this.Cursor = Cursors.AppStarting;

                        BinaryReader binaryStream = new BinaryReader(input);
                        binaryStream.ReadInt32();
                        int version = binaryStream.ReadInt32();
                        int num7 = binaryStream.ReadInt32();
                        ATaskTemplFixedData[] taskArray5 = new ATaskTemplFixedData[this.Tasks.Length + 1];
                        taskArray5[taskArray5.Length - 1] = new ATaskTemplFixedData(version, binaryStream, num7 * 4 + 12, this.treeView_tasks.Nodes);
                        Array.Copy(this.Tasks, 0, taskArray5, 0, this.Tasks.Length);
                        this.Tasks = taskArray5;
                        TaskEditor.BTasks = this.Tasks;
                        binaryStream.Close();
                        input.Close();
                        this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[this.treeView_tasks.Nodes.Count - 1];
                        //this.groupBox1.Text = Extensions.GetLocalization(479) + Tasks.Length;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(466));
                        //this.Cursor = Cursors.Default;
                    }
                    try
                    {
                        ArrayList list2 = new ArrayList();
                        TreeNode selectedNode = this.treeView_tasks.SelectedNode;
                        while (selectedNode.Parent != null)
                        {
                            list2.Add(selectedNode.Index);
                            selectedNode = selectedNode.Parent;
                        }
                        if (list2.Count == 0)
                        {
                            ATaskTemplFixedData[] taskArray6 = new ATaskTemplFixedData[this.Tasks.Length + 1];
                            taskArray6[0] = this.Tasks[selectedNode.Index].Clone();
                            Array.Copy(this.Tasks, 0, taskArray6, 1, this.Tasks.Length);
                            this.Tasks = taskArray6;
                            TaskEditor.BTasks = this.Tasks;
                            this.treeView_tasks.Nodes.Insert(0, (TreeNode)this.treeView_tasks.SelectedNode.Clone());
                            this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
                            if (this.checkBox_SetNewID.Checked)
                            {
                                for (int i = 0; i < Tasks[0].talk_procs.Length; i++)
                                {
                                    for (int k = 0; k < Tasks[0].talk_procs[i].windows.Length; k++)
                                    {
                                        for (int l = 0; l < Tasks[0].talk_procs[i].windows[k].options.Length; l++)
                                        {
                                            if (Tasks[0].talk_procs[i].windows[k].options[l].id == this.Tasks[0].ID)
                                                Tasks[0].talk_procs[i].windows[k].options[l].id = NewID;
                                        }
                                    }
                                }
                                int oldID = this.Tasks[0].ID;
                                int newID = NewID;
                                this.Tasks[0].ID = NewID;
                                string m_szName = Tasks[0].Name;
                                if (m_szName.StartsWith("^"))
                                {
                                    m_szName = m_szName.Substring(7);
                                }
                                this.treeView_tasks.SelectedNode.Text = Tasks[0].ID.ToString() + " - " + m_szName;
                                NewID++;
                                for (int i = 0; i < Tasks[0].sub_quest_count; i++)
                                {
                                    this.SetNewID(this.Tasks[0].sub_quests[i], this.treeView_tasks.SelectedNode.Nodes[i], this.Tasks[0], this.treeView_tasks.SelectedNode);
                                    this.SetNewIDIntalk_procs(this.Tasks[0].sub_quests[i], oldID, newID);
                                }
                            }
                        }
                        else
                        {
                            ATaskTemplFixedData task2 = this.Tasks[selectedNode.Index];
                            for (int num8 = list2.Count - 1; num8 > 0; num8--)
                            {
                                task2 = task2.sub_quests[(int)list2[num8]];
                            }
                            task2.sub_quest_count++;
                            ATaskTemplFixedData[] taskArray7 = new ATaskTemplFixedData[task2.sub_quests.Length + 1];
                            Array.Copy(task2.sub_quests, 0, taskArray7, 0, task2.sub_quests.Length);
                            taskArray7[taskArray7.Length - 1] = task2.sub_quests[(int)list2[0]].Clone();
                            task2.sub_quests = taskArray7;
                            JMessageBox.Show(this, Extensions.GetLocalization(458));
                            this.treeView_tasks.SelectedNode.Parent.Nodes.Add((TreeNode)this.treeView_tasks.SelectedNode.Clone());
                        }
                        //this.Cursor = Cursors.Default;
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(467));
                        //this.Cursor = Cursors.Default;
                    }
                    try
                    {
                        this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[this.treeView_tasks.Nodes.Count - 1];
                        ArrayList list3 = new ArrayList();
                        //TreeNode parent = ((TreeView)this.contextMenuStrip_task.SourceControl).SelectedNode;
                        TreeNode parent = this.treeView_tasks.SelectedNode;
                        while (parent.Parent != null)
                        {
                            list3.Add(parent.Index);
                            parent = parent.Parent;
                        }
                        if (list3.Count == 0)
                        {
                            ATaskTemplFixedData[] taskArray8 = new ATaskTemplFixedData[this.Tasks.Length - 1];
                            Array.Copy(this.Tasks, 0, taskArray8, 0, parent.Index);
                            Array.Copy(this.Tasks, parent.Index + 1, taskArray8, parent.Index, this.Tasks.Length - 1 - parent.Index);
                            this.Tasks = taskArray8;
                            TaskEditor.BTasks = this.Tasks;
                        }
                        else
                        {
                            ATaskTemplFixedData task3 = this.Tasks[parent.Index];
                            for (int num9 = list3.Count - 1; num9 > 0; num9--)
                            {
                                task3 = task3.sub_quests[(int)list3[num9]];
                            }
                            task3.sub_quest_count--;
                            ATaskTemplFixedData[] destinationArray = new ATaskTemplFixedData[task3.sub_quests.Length - 1];
                            Array.Copy(task3.sub_quests, 0, destinationArray, 0, (int)list3[0]);
                            Array.Copy(task3.sub_quests, (int)list3[0] + 1, destinationArray, (int)list3[0], task3.sub_quests.Length - 1 - (int)list3[0]);
                            task3.sub_quests = destinationArray;
                        }
                        this.treeView_tasks.SelectedNode.Remove();
                    }
                    catch
                    {
                        JMessageBox.Show(this, Extensions.GetLocalization(468));
                        //this.Cursor = Cursors.Default;
                    }            
            }
            progressShow("Ready", 0, 0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Tasks != null)
            {

            }

        }
        private IToolType customTooltype;
        public bool isAutoOpen = false;
        public string autoOpenPath = "";

        private void dataGridView_reward_item_m_AwardItems_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(customTooltype != null)
            customTooltype.Close();
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView_tasks.SelectNone();
        }

        private void TaskEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.StandAlone)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    MainProgram.getInstance().ShowTaskEditor(null, null);

                }
            }
            else
            {
                MainProgram.getInstance().ExitInvoke();
            }
        }

        private void jScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            treeView_tasks.Nodes[e.NewValue].EnsureVisible();
        }

        private bool already_shown = false;
        private void TaskEditor_Shown(object sender, EventArgs e)
        {
            if (isAutoOpen && !already_shown)
            {
                isAutoOpen = false;
                already_shown = true;
                LockedSelecting = true;
                progressShow("Loading Please Wait.", 0, 0);
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    autoLoad();
                });
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            MainWindow_Width = this.Size.Width;
        }

        private void autoLoad()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    autoLoad();
                }
                ));
                return;
            }
            // this.Opacity = 0;
            // this.Hide();
            // this.SuspendLayout();
            this.Update();
            progressShow(Extensions.GetLocalization(500), 0, 0);

            try
            {
                this.comboBox_m_iPremForce.Items.Clear();
                this.comboBox_m_iPremForce.Items.Add(0 + "_NO");
                this.comboBox_m_iPremForce.Items.Add(-1 + "_ALL");
                this.comboBox_m_iPremForce.Items.Add(1004 + "_Corona");
                this.comboBox_m_iPremForce.Items.Add(1005 + "_Shroud");
                this.comboBox_m_iPremForce.Items.Add(1006 + "_Luminance");

                if (TaskEditor.eLC != null)
                {
                    foreach (ItemDupe data in TaskEditor.eLC.FORCES.Values)
                    {
                        if (data.itemId != 1004 && data.itemId != 1005 && data.itemId != 1006)
                            this.comboBox_m_iPremForce.Items.Add(data.itemId + "_" + data.name);
                    }
                }
                //this.Cursor = Cursors.WaitCursor;
                this.treeView_tasks.Nodes.Clear();
                this.treeView_tasks.BeginUpdate();
                //this.treeView_tasks.CheckBoxes = true;
                FileStream input = File.OpenRead(autoOpenPath);

                BinaryReader binaryStream = new BinaryReader(input);
                binaryStream.ReadInt32();
                int m_Version = binaryStream.ReadInt32();
                if (!TaskEditor.versions.Contains(m_Version))
                {
                    binaryStream.Close();
                    input.Close();
                    this.treeView_tasks.EndUpdate();
                    //this.Cursor = Cursors.Default;
                    JMessageBox.Show(this, Extensions.GetLocalization(470) + m_Version.ToString());
                    progressShow(Extensions.GetLocalization(499), 0, 0);
                }
                else
                {
                    tmpNewID = 0;
                    version = m_Version;
                    int m_uTaskCount = binaryStream.ReadInt32();
                    int[] numArray = new int[m_uTaskCount];
                    for (int index = 0; index < m_uTaskCount; index++)
                    {
                        numArray[index] = binaryStream.ReadInt32();
                    }
                    this.Tasks = new ATaskTemplFixedData[m_uTaskCount];
                    TaskEditor.BTasks = this.Tasks;
                    // Application.DoEvents();
                    int count = 0;
                    int maxCount = 100;
                    for (int num4 = 0; num4 < m_uTaskCount; num4++)
                    {
                        //// Application.DoEvents();
                        this.Tasks[num4] = new ATaskTemplFixedData(m_Version, binaryStream, numArray[num4], this.treeView_tasks.Nodes);
                        if (count > maxCount)
                        {
                            // Application.DoEvents();
                            progressShow(Extensions.GetLocalization(499), num4, m_uTaskCount);
                            count = 0;
                        }
                        count++;
                    }
                    binaryStream.Close();
                    input.Close();
                    this.treeView_tasks.EndUpdate();
                    this.comboBox_SaveVersion.Text = m_Version.ToString();
                    this.LoadedTask = true;
                    path = autoOpenPath;
                    //  if (LoadedTask == true && LoadedElements == true) this.Text = String.Format(Extensions.GetLocalization(471), path + " || " + lElementsPath);
                    //  else this.Text = String.Format(Extensions.GetLocalization(471), path);

                    //this.Cursor = Cursors.Default;
                    LockedSelecting = false;
                    this.treeView_tasks.SelectedNode = this.treeView_tasks.Nodes[0];
                    this.listBox_conversation_talk_procs.SelectedIndex = 0;
                    this.numericUpDown_NewID.Value = tmpNewID + 1;
                    //this.groupBox1.Text = Extensions.GetLocalization(479) + m_uTaskCount;
                    progressShow(Extensions.GetLocalization(499), 0, 0);
                    lElementsPath = ElementsEditor.configs.lastElementsLocation;
                    SelectItemIdWindow_SelectedListIndex = 0;
                    SelectItemIdWindow_SelectedItemIndex = 0;
                    SelectMonsterIdWindow_SelectedItemIndex = 0;
                    SelectNPCIdWindow_SelectedItemIndex = 0;
                    SelectMonsterNPCMineIdWindow_SelectedListIndex = 0;
                    SelectMonsterNPCMineIdWindow_SelectedItemIndex = 0;
                    SelectTitleIdWindow_SelectedItemIndex = 0;
                    SelectHomeItemIdWindow_SelectedItemIndex = 0;

                    progressShow("Ready", 0, 0);
                    pathLabel.Text = path;
                    version_label.Text = m_Version.ToString();
                    jLabel1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = jPictureBox2.Visible = true;
                }
            }
            catch (Exception exception)
            {
                this.treeView_tasks.EndUpdate();
                //this.Cursor = Cursors.Default;
                JMessageBox.Show(this, String.Format(Extensions.GetLocalization(475), exception.Message));
            }
            //this.Opacity = 100;
            // this.Show();
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void itemDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                if (dataGridView_reward_item_m_AwardItems.CurrentCell != null)
                {
                    int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                    int index2 = this.toolStripComboBox1_1.SelectedIndex;
                    this.toolStripComboBox1_1.SelectedIndex = -1;
                    int i = dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    if (index > -1)
                    {
                        string data = "\"^ffcb4aContains:^ff0000\\r";
                        for (int j = 0; j < this.dataGridView_reward_item_m_AwardItems.RowCount; j++)
                        {
                            //1+4
                            float datax = float.Parse(this.dataGridView_reward_item_m_AwardItems.Rows[j].Cells[4].Value.ToString()) * 100;
                            int count = int.Parse(this.dataGridView_reward_item_m_AwardItems.Rows[j].Cells[3].Value.ToString());
                            if(count > 1)
                                data += "\\r"+count+"x " + this.dataGridView_reward_item_m_AwardItems.Rows[j].Cells[1].Value + " (" + datax.ToString("0.00##") + "%)";
                            else
                                data += "\\r"+this.dataGridView_reward_item_m_AwardItems.Rows[j].Cells[1].Value + " (" + datax.ToString("0.00##") + "%)";
                        }
                        data += "\\r\\r^ffcb4aRight-click to open.\"";
                        Clipboard.SetText(@data);
                        return;
                    }
                    JMessageBox.Show(this, Extensions.GetLocalization(410));
                }
                JMessageBox.Show(this, Extensions.GetLocalization(411));
            }
        }

        private void importTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void dataGridView_reward_m_pTitleAward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                Export exportData = GetFromClipboard();
                if (exportData != null)
                {
                    List<int> ids = new List<int>();
                    foreach (KeyValuePair<int, object> entry in exportData.data)
                    {
                        SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                        ids.Add((int)data[0]);
                    }

                    if (this.SelectedReward != null)
                    {
                        foreach (int id in ids)
                        {
                            this.SelectedReward.m_ulTitleNum++;
                            Array.Resize<TITLE_AWARD>(ref this.SelectedReward.m_pTitleAward, this.SelectedReward.m_pTitleAward.Length + 1);
                            this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1] = new TITLE_AWARD();
                            this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1].m_ulTitleID = id;
                            this.SelectedReward.m_pTitleAward[this.SelectedReward.m_pTitleAward.Length - 1].m_lPeriod = 0;
                            string[] values = new string[]
                            {
                                ""+id+"",
                                Extensions.GetLocalization(402),
                                "00-00:00:00"
                            };
                            this.dataGridView_reward_m_pTitleAward.Rows.Add(values);
                        }
                    }
                }
            }
        }

        private void dataGridView_reward_item_m_AwardItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                Export exportData = GetFromClipboard();
                if (exportData != null)
                {
                    List<int> ids = new List<int>();
                    foreach (KeyValuePair<int, object> entry in exportData.data)
                    {
                        SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                        ids.Add((int)data[0]);
                    }
                    if (this.SelectedReward != null)
                    {
                        int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                        if (index > -1)
                        {
                            foreach (int id in ids)
                            {
                                this.SelectedReward.m_CandItems[index].m_ulAwardItems++;
                                Array.Resize<ITEM_WANTED>(ref this.SelectedReward.m_CandItems[index].m_AwardItems, this.SelectedReward.m_CandItems[index].m_AwardItems.Length + 1);
                                this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1] = new ITEM_WANTED();
                                this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_ulItemTemplId = id;
                                this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_bCommonItem = true;
                                this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_ulItemNum = 1;
                                this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_fProb = 1f;
                                this.SelectedReward.m_CandItems[index].m_AwardItems[this.SelectedReward.m_CandItems[index].m_AwardItems.Length - 1].m_lPeriod = 0;
                                string[] values = new string[]
                                {
                                    ""+id+"",
                                    Extensions.GetLocalization(402),
                                    "True",
                                    "1",
                                    ProbAddValueFormat,
                                    "00-00:00:00"
                                };
                                this.dataGridView_reward_item_m_AwardItems.Rows.Add(values);
                            }
                        }
                    }
                }
            }
        }

        private void recalculateDropsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                if (index > -1)
                {
                    ITEM_WANTED[] data = this.SelectedReward.m_CandItems[index].m_AwardItems;
                    float probability = 1f / data.Length;
                    for (int i = 0; i < data.Length; i++)
                    {
                        this.SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb = probability;
                        dataGridView_reward_item_m_AwardItems.Rows[i].Cells[4].Value = probability.ToString();
                    }
                }
            }
        }

        private void dropThisFasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedReward != null && dataGridView_reward_item_m_AwardItems.CurrentCell != null)
            {
                int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                if (index > -1)
                {
                    ITEM_WANTED[] data = this.SelectedReward.m_CandItems[index].m_AwardItems;
                    List<float> prob_Indexes = new List<float>();
                    for (int i = 0; i < data.Length; i++)
                    {
                        prob_Indexes.Add(data[i].m_fProb);
                    }

                    int selectedRow = dataGridView_reward_item_m_AwardItems.CurrentCell.RowIndex;
                    float probability = 0;

                    for (int i = 0; i < prob_Indexes.Count; i++)
                    {
                        if (selectedRow == i)
                            probability = prob_Indexes[selectedRow] * 2;
                        else
                            probability = (prob_Indexes[i] - (prob_Indexes[selectedRow] / (prob_Indexes.Count - 1)));

                        this.SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb = probability;
                        dataGridView_reward_item_m_AwardItems.Rows[i].Cells[4].Value = probability.ToString();
                    }
                }
            }
        }

        private void getTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedReward != null)
            {
                int index = this.checkedListBox_reward_canditems_m_bRandChoose.SelectedIndex;
                if (index > -1)
                {
                    ITEM_WANTED[] data = this.SelectedReward.m_CandItems[index].m_AwardItems;
                    float probability = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        probability +=  this.SelectedReward.m_CandItems[index].m_AwardItems[i].m_fProb;
                    }
                    try
                    {
                        JMessageBox.Show(this, "Total is:" +  probability);
                    }
                    catch { }
                }
            }
        }

        private void ReplaceWithTextBox_ButtonClick(object sender, EventArgs e)
        {
            if(this.LoadedTask && this.SelectedTask != null)
            {
                int nnewValue = 0;
                int replaceValue = 0;
                
                bool isMultiply = jTextBox1.Text.Equals("/");
                bool isDevide = jTextBox1.Text.Equals("*");
                bool isReplaceAllValues = jTextBox1.Text.Length == 0 || isMultiply || isDevide;
                bool isCo = int.TryParse(replaceWithTextBox.Text, out nnewValue);
                if(!isCo)
                {
                    JMessageBox.Show(this, "Replace value must be a number!");
                    return;
                }
                bool isCo2 = int.TryParse(jTextBox1.Text, out replaceValue);
                if (!isCo2 && !isReplaceAllValues)
                {
                    JMessageBox.Show(this, "n value must be a number!");
                    return;
                }
                int replaced = 0;


                switch (fieldscomboBox.SelectedIndex)
                {
                    case 0://EVENT GOLD
                        for(int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_ulDividend != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if(isDevide)
                                        current.m_Award_S.m_ulDividend = (int)(current.m_Award_S.m_ulDividend * nnewValue);
                                    else if(isMultiply)
                                        current.m_Award_S.m_ulDividend = (int)(current.m_Award_S.m_ulDividend / nnewValue);
                                    else
                                        current.m_Award_S.m_ulDividend = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_ulDividend)
                                    {
                                        current.m_Award_S.m_ulDividend = nnewValue;
                                        replaced++;
                                    }
                                }
                                for (int s = 0; s < this.Tasks[i].sub_quest_count; s++)
                                {
                                    current = this.Tasks[i].sub_quests[s];
                                    if (current.m_Award_S.m_ulDividend != 0 || replaceValue == 0)
                                    {
                                        if (isReplaceAllValues)
                                        {
                                            if (isDevide)
                                                current.m_Award_S.m_ulDividend = (int)(current.m_Award_S.m_ulDividend * nnewValue);
                                            else if (isMultiply)
                                                current.m_Award_S.m_ulDividend = (int)(current.m_Award_S.m_ulDividend / nnewValue);
                                            else
                                                current.m_Award_S.m_ulDividend = nnewValue;

                                            replaced++;
                                        }
                                        else
                                        {
                                            if (replaceValue == current.m_Award_S.m_ulDividend)
                                            {
                                                current.m_Award_S.m_ulDividend = nnewValue;
                                                replaced++;
                                            }
                                        }
                                    }
                                }
                            }
    
                        }
                        break;
                    case 2://EXP GOLD
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_ulExp != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_ulExp = (int)(current.m_Award_S.m_ulExp * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_ulExp = (int)(current.m_Award_S.m_ulExp / nnewValue);
                                    else
                                        current.m_Award_S.m_ulExp = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_ulExp)
                                    {
                                        current.m_Award_S.m_ulExp = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 3://SP GOLD
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_ulSP != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_ulSP = (int)(current.m_Award_S.m_ulSP * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_ulSP = (int)(current.m_Award_S.m_ulSP / nnewValue);
                                    else
                                        current.m_Award_S.m_ulSP = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_ulSP)
                                    {
                                        current.m_Award_S.m_ulSP = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 4://GOLD COINS
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_ulGoldNum != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_ulGoldNum = (int)(current.m_Award_S.m_ulGoldNum * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_ulGoldNum = (int)(current.m_Award_S.m_ulGoldNum / nnewValue);
                                    else
                                        current.m_Award_S.m_ulGoldNum = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_ulGoldNum)
                                    {
                                        current.m_Award_S.m_ulGoldNum = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 5://m_lReputation
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_lReputation != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_lReputation = (int)(current.m_Award_S.m_lReputation * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_lReputation = (int)(current.m_Award_S.m_lReputation / nnewValue);
                                    else
                                        current.m_Award_S.m_lReputation = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_lReputation)
                                    {
                                        current.m_Award_S.m_lReputation = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 6://m_ulContrib
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_ulContrib != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_ulContrib = (int)(current.m_Award_S.m_ulContrib * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_ulContrib = (int)(current.m_Award_S.m_ulContrib / nnewValue);
                                    else
                                        current.m_Award_S.m_ulContrib = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_ulContrib)
                                    {
                                        current.m_Award_S.m_ulContrib = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 7://m_iFactionExpContrib
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_iFactionExpContrib != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_iFactionExpContrib = (int)(current.m_Award_S.m_iFactionExpContrib * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_iFactionExpContrib = (int)(current.m_Award_S.m_iFactionExpContrib / nnewValue);
                                    else
                                        current.m_Award_S.m_iFactionExpContrib = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_iFactionExpContrib)
                                    {
                                        current.m_Award_S.m_iFactionExpContrib = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 8://m_iFactionContrib
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_Award_S.m_iFactionContrib != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    if (isDevide)
                                        current.m_Award_S.m_iFactionContrib = (int)(current.m_Award_S.m_iFactionContrib * nnewValue);
                                    else if (isMultiply)
                                        current.m_Award_S.m_iFactionContrib = (int)(current.m_Award_S.m_iFactionContrib / nnewValue);
                                    else
                                        current.m_Award_S.m_iFactionContrib = nnewValue;

                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_Award_S.m_iFactionContrib)
                                    {
                                        current.m_Award_S.m_iFactionContrib = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                        }
                        break;
                    case 1://Max Level
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_ulSuitableLevel != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    current.m_ulSuitableLevel = nnewValue;
                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_ulSuitableLevel)
                                    {
                                        current.m_ulSuitableLevel = nnewValue;
                                        replaced++;
                                    }
                                }
                            }

                            if (current.m_ulPremise_Lev_Max != 0 || replaceValue == 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    current.m_ulPremise_Lev_Max = nnewValue;
                                    replaced++;
                                }
                                else
                                {
                                    if (replaceValue == current.m_ulPremise_Lev_Max)
                                    {
                                        current.m_ulPremise_Lev_Max = nnewValue;
                                        replaced++;
                                    }
                                }
                            }
                            if (current.m_TeamMemsWanted != null && current.m_TeamMemsWanted.Length > 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    for (int x = 0; x < current.m_TeamMemsWanted.Length; x++)
                                    {
                                        current.m_TeamMemsWanted[x].m_ulLevelMax = nnewValue;
                                        replaced++;
                                    }
                                }
                                else
                                {
                                    for (int x = 0; x < current.m_TeamMemsWanted.Length; x++)
                                    {
                                        if (replaceValue == current.m_TeamMemsWanted[x].m_ulLevelMax)
                                        {
                                            current.m_TeamMemsWanted[x].m_ulLevelMax = nnewValue;
                                            replaced++;
                                        }
                                    }
                                }
                            }
                            if(this.Tasks[i].sub_quests != null && this.Tasks[i].sub_quests.Length > 0)
                            {
                                for(int x = 0; x < this.Tasks[i].sub_quest_count; x++)
                                {
                                    current = this.Tasks[i].sub_quests[x];
                                    if (current.m_ulSuitableLevel != 0 || replaceValue == 0)
                                    {
                                        if (isReplaceAllValues)
                                        {
                                            current.m_ulSuitableLevel = nnewValue;
                                            replaced++;
                                        }
                                        else
                                        {
                                            if (replaceValue == current.m_ulSuitableLevel)
                                            {
                                                current.m_ulSuitableLevel = nnewValue;
                                                replaced++;
                                            }
                                        }
                                    }

                                    if (current.m_ulPremise_Lev_Max != 0 || replaceValue == 0)
                                    {
                                        if (isReplaceAllValues)
                                        {
                                            current.m_ulPremise_Lev_Max = nnewValue;
                                            replaced++;
                                        }
                                        else
                                        {
                                            if (replaceValue == current.m_ulPremise_Lev_Max)
                                            {
                                                current.m_ulPremise_Lev_Max = nnewValue;
                                                replaced++;
                                            }
                                        }
                                    }
                                    if (current.m_TeamMemsWanted != null && current.m_TeamMemsWanted.Length > 0)
                                    {
                                        if (isReplaceAllValues)
                                        {
                                            for (int r = 0; r < current.m_TeamMemsWanted.Length; r++)
                                            {
                                                current.m_TeamMemsWanted[r].m_ulLevelMax = nnewValue;
                                                replaced++;
                                            }
                                        }
                                        else
                                        {
                                            for (int r = 0; r < current.m_TeamMemsWanted.Length; r++)
                                            {
                                                if (replaceValue == current.m_TeamMemsWanted[r].m_ulLevelMax)
                                                {
                                                    current.m_TeamMemsWanted[r].m_ulLevelMax = nnewValue;
                                                    replaced++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 9://Min Team Member Count
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_TeamMemsWanted != null && current.m_TeamMemsWanted.Length > 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    for (int x = 0; x < current.m_TeamMemsWanted.Length; x++)
                                    {
                                        current.m_TeamMemsWanted[x].m_ulMinCount = nnewValue;
                                        replaced++;
                                    }
                                }
                                else
                                {
                                    for (int x = 0; x < current.m_TeamMemsWanted.Length; x++)
                                    {
                                        if (replaceValue == current.m_TeamMemsWanted[x].m_ulMinCount)
                                        {
                                            current.m_TeamMemsWanted[x].m_ulMinCount = nnewValue;
                                            replaced++;
                                        }
                                    }
                                }
                            }
                            if (this.Tasks[i].sub_quests != null && this.Tasks[i].sub_quests.Length > 0)
                            {
                                for (int x = 0; x < this.Tasks[i].sub_quest_count; x++)
                                {
                                    current = this.Tasks[i].sub_quests[x];

                                    if (current.m_TeamMemsWanted != null && current.m_TeamMemsWanted.Length > 0)
                                    {
                                        if (isReplaceAllValues)
                                        {
                                            for (int r = 0; r < current.m_TeamMemsWanted.Length; r++)
                                            {
                                                current.m_TeamMemsWanted[r].m_ulMinCount = nnewValue;
                                                replaced++;
                                            }
                                        }
                                        else
                                        {
                                            for (int r = 0; r < current.m_TeamMemsWanted.Length; r++)
                                            {
                                                if (replaceValue == current.m_TeamMemsWanted[r].m_ulMinCount)
                                                {
                                                    current.m_TeamMemsWanted[r].m_ulMinCount = nnewValue;
                                                    replaced++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 10://Max Team Member Count
                        for (int i = 0; i < this.Tasks.Length; i++)
                        {
                            ATaskTemplFixedData current = this.Tasks[i];
                            if (current.m_TeamMemsWanted != null && current.m_TeamMemsWanted.Length > 0)
                            {
                                if (isReplaceAllValues)
                                {
                                    for (int x = 0; x < current.m_TeamMemsWanted.Length; x++)
                                    {
                                        current.m_TeamMemsWanted[x].m_ulMaxCount = nnewValue;
                                        replaced++;
                                    }
                                }
                                else
                                {
                                    for (int x = 0; x < current.m_TeamMemsWanted.Length; x++)
                                    {
                                        if (replaceValue == current.m_TeamMemsWanted[x].m_ulMaxCount)
                                        {
                                            current.m_TeamMemsWanted[x].m_ulMaxCount = nnewValue;
                                            replaced++;
                                        }
                                    }
                                }
                            }
                            if (this.Tasks[i].sub_quests != null && this.Tasks[i].sub_quests.Length > 0)
                            {
                                for (int x = 0; x < this.Tasks[i].sub_quest_count; x++)
                                {
                                    current = this.Tasks[i].sub_quests[x];

                                    if (current.m_TeamMemsWanted != null && current.m_TeamMemsWanted.Length > 0)
                                    {
                                        if (isReplaceAllValues)
                                        {
                                            for (int r = 0; r < current.m_TeamMemsWanted.Length; r++)
                                            {
                                                current.m_TeamMemsWanted[r].m_ulMaxCount = nnewValue;
                                                replaced++;
                                            }
                                        }
                                        else
                                        {
                                            for (int r = 0; r < current.m_TeamMemsWanted.Length; r++)
                                            {
                                                if (replaceValue == current.m_TeamMemsWanted[r].m_ulMaxCount)
                                                {
                                                    current.m_TeamMemsWanted[r].m_ulMaxCount = nnewValue;
                                                    replaced++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                JMessageBox.Show(this, "Replaced "+ replaced+" tasks.");
            }
        }

        private void below79ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LoadedTask && this.SelectedTask != null)
            {
                int replaced = 0;
                for (int i = 0; i < this.Tasks.Length; i++)
                {
                    ATaskTemplFixedData current = this.Tasks[i];
                   // if(current.re)

                }

                JMessageBox.Show(this, "Removed " + replaced + " tasks.");
            }
        }
    }
}