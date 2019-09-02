using PWDataEditorPaied.Element_Editor_Classes;
using PWDataEditorPaied.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ElementEditor
{
    partial class ElementsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.invertRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listbox_items_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCombobox = new System.Windows.Forms.ToolStripComboBox();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.makeRecipesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reforgeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_lists = new System.Windows.Forms.ComboBox();
            this.listbox_description = new System.Windows.Forms.GroupBox();
            this.listBox_items = new PWDataEditorPaied.Element_Editor_Classes.DBDataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configEditorExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSkillsToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readListDEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.caseSensitiveCheckbox = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.searchInput1 = new System.Windows.Forms.TextBox();
            this.progres = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.version_label = new System.Windows.Forms.Label();
            this.row_editor_context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementIntoTab = new System.Windows.Forms.TabControl();
            this.Edit = new System.Windows.Forms.TabPage();
            this.dataGridView_item = new PWDataEditorPaied.Element_Editor_Classes.DBDataGridView();
            this.RowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tab_salebtn_1 = new System.Windows.Forms.Button();
            this.tab_salebtn_5 = new System.Windows.Forms.Button();
            this.tab_salebtn_2 = new System.Windows.Forms.Button();
            this.tab_salebtn_8 = new System.Windows.Forms.Button();
            this.tab_salebtn_3 = new System.Windows.Forms.Button();
            this.tab_salebtn_7 = new System.Windows.Forms.Button();
            this.tab_salebtn_4 = new System.Windows.Forms.Button();
            this.tab_salebtn_6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label_item_32 = new System.Windows.Forms.Label();
            this.label_item_31 = new System.Windows.Forms.Label();
            this.label_item_30 = new System.Windows.Forms.Label();
            this.label_item_29 = new System.Windows.Forms.Label();
            this.label_item_28 = new System.Windows.Forms.Label();
            this.label_item_27 = new System.Windows.Forms.Label();
            this.label_item_26 = new System.Windows.Forms.Label();
            this.label_item_25 = new System.Windows.Forms.Label();
            this.label_item_24 = new System.Windows.Forms.Label();
            this.label_item_23 = new System.Windows.Forms.Label();
            this.label_item_22 = new System.Windows.Forms.Label();
            this.label_item_21 = new System.Windows.Forms.Label();
            this.label_item_20 = new System.Windows.Forms.Label();
            this.label_item_19 = new System.Windows.Forms.Label();
            this.label_item_18 = new System.Windows.Forms.Label();
            this.label_item_17 = new System.Windows.Forms.Label();
            this.label_item_16 = new System.Windows.Forms.Label();
            this.label_item_15 = new System.Windows.Forms.Label();
            this.label_item_14 = new System.Windows.Forms.Label();
            this.label_item_13 = new System.Windows.Forms.Label();
            this.label_item_12 = new System.Windows.Forms.Label();
            this.label_item_11 = new System.Windows.Forms.Label();
            this.label_item_10 = new System.Windows.Forms.Label();
            this.label_item_9 = new System.Windows.Forms.Label();
            this.label_item_8 = new System.Windows.Forms.Label();
            this.label_item_7 = new System.Windows.Forms.Label();
            this.label_item_6 = new System.Windows.Forms.Label();
            this.label_item_5 = new System.Windows.Forms.Label();
            this.label_item_4 = new System.Windows.Forms.Label();
            this.label_item_3 = new System.Windows.Forms.Label();
            this.label_item_2 = new System.Windows.Forms.Label();
            this.label_item_1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.picture_item_32 = new System.Windows.Forms.PictureBox();
            this.contextMenuStripSalePreview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.picture_item_31 = new System.Windows.Forms.PictureBox();
            this.picture_item_30 = new System.Windows.Forms.PictureBox();
            this.picture_item_29 = new System.Windows.Forms.PictureBox();
            this.picture_item_28 = new System.Windows.Forms.PictureBox();
            this.picture_item_27 = new System.Windows.Forms.PictureBox();
            this.picture_item_26 = new System.Windows.Forms.PictureBox();
            this.picture_item_25 = new System.Windows.Forms.PictureBox();
            this.picture_item_24 = new System.Windows.Forms.PictureBox();
            this.picture_item_23 = new System.Windows.Forms.PictureBox();
            this.picture_item_22 = new System.Windows.Forms.PictureBox();
            this.picture_item_21 = new System.Windows.Forms.PictureBox();
            this.picture_item_20 = new System.Windows.Forms.PictureBox();
            this.picture_item_19 = new System.Windows.Forms.PictureBox();
            this.picture_item_18 = new System.Windows.Forms.PictureBox();
            this.picture_item_17 = new System.Windows.Forms.PictureBox();
            this.picture_item_16 = new System.Windows.Forms.PictureBox();
            this.picture_item_15 = new System.Windows.Forms.PictureBox();
            this.picture_item_14 = new System.Windows.Forms.PictureBox();
            this.picture_item_13 = new System.Windows.Forms.PictureBox();
            this.picture_item_12 = new System.Windows.Forms.PictureBox();
            this.picture_item_11 = new System.Windows.Forms.PictureBox();
            this.picture_item_10 = new System.Windows.Forms.PictureBox();
            this.picture_item_9 = new System.Windows.Forms.PictureBox();
            this.picture_item_8 = new System.Windows.Forms.PictureBox();
            this.picture_item_7 = new System.Windows.Forms.PictureBox();
            this.picture_item_6 = new System.Windows.Forms.PictureBox();
            this.picture_item_5 = new System.Windows.Forms.PictureBox();
            this.picture_item_4 = new System.Windows.Forms.PictureBox();
            this.picture_item_3 = new System.Windows.Forms.PictureBox();
            this.picture_item_2 = new System.Windows.Forms.PictureBox();
            this.picture_item_1 = new System.Windows.Forms.PictureBox();
            this.craftTab = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.pictureBox44 = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.pictureBox43 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.pictureBox42 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox_craft_req_5 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pictureBox_craft_req_4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_req_8 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_req_3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_req_6 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_req_7 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_req_2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_req_1 = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.pictureBox_craft_32 = new System.Windows.Forms.PictureBox();
            this.contextMenuStripproduce = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_craft_31 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_30 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_29 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_28 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_27 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_26 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_25 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_24 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_23 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_22 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_21 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_20 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_19 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_18 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_17 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_16 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_15 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_14 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_13 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_12 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_11 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_10 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_9 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_8 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_7 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_6 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_5 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_craft_1 = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tab_craftbtn_1 = new System.Windows.Forms.Button();
            this.tab_craftbtn_5 = new System.Windows.Forms.Button();
            this.tab_craftbtn_2 = new System.Windows.Forms.Button();
            this.tab_craftbtn_8 = new System.Windows.Forms.Button();
            this.tab_craftbtn_3 = new System.Windows.Forms.Button();
            this.tab_craftbtn_7 = new System.Windows.Forms.Button();
            this.tab_craftbtn_4 = new System.Windows.Forms.Button();
            this.tab_craftbtn_6 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.versionToBox = new System.Windows.Forms.TextBox();
            this.versionFromBox = new System.Windows.Forms.TextBox();
            this.EnableDevMenu = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.nextautoIdlabelmax = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.autonewIdCTRLV = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.nextautoIdlabel = new System.Windows.Forms.TextBox();
            this.autonewId = new System.Windows.Forms.CheckBox();
            this.exportClipboardWithRules = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.autoSaveCache = new System.Windows.Forms.CheckBox();
            this.autoOpenCache = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button16 = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button15 = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.selecter_rowscheckbox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllItemNamesToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllItemNamesToClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.copySelectedItemsToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerMenuitems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.changeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_newValue = new System.Windows.Forms.TextBox();
            this.replaceSelected = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox_oldValue = new System.Windows.Forms.TextBox();
            this.changeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.classmaskMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2.SuspendLayout();
            this.listbox_items_menu.SuspendLayout();
            this.listbox_description.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.row_editor_context.SuspendLayout();
            this.elementIntoTab.SuspendLayout();
            this.Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).BeginInit();
            this.SaleTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_32)).BeginInit();
            this.contextMenuStripSalePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_1)).BeginInit();
            this.craftTab.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).BeginInit();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_1)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_32)).BeginInit();
            this.contextMenuStripproduce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.developerMenuitems.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.classmaskMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pastToolStripMenuItem,
            this.toolStripSeparator6,
            this.invertRowsToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(188, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.copyToolStripMenuItem.Text = "Copy Values";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_index;
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pastToolStripMenuItem.Text = "Paste Values";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.pastToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(184, 6);
            // 
            // invertRowsToolStripMenuItem
            // 
            this.invertRowsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.invertRowsToolStripMenuItem.Name = "invertRowsToolStripMenuItem";
            this.invertRowsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.invertRowsToolStripMenuItem.Text = "Invert Selected Values";
            this.invertRowsToolStripMenuItem.Click += new System.EventHandler(this.invertRowsToolStripMenuItem_Click);
            // 
            // listbox_items_menu
            // 
            this.listbox_items_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportToToolStripMenuItem,
            this.toolStripSeparator5,
            this.makeRecipesToolStripMenuItem2});
            this.listbox_items_menu.Name = "listbox_items_menu";
            this.listbox_items_menu.Size = new System.Drawing.Size(147, 154);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_import;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // exportToToolStripMenuItem
            // 
            this.exportToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCombobox,
            this.saveToolStripMenuItem1});
            this.exportToToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.bullet_toggle_plus;
            this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
            this.exportToToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportToToolStripMenuItem.Text = "Export To";
            // 
            // exportCombobox
            // 
            this.exportCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exportCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportCombobox.Name = "exportCombobox";
            this.exportCombobox.Size = new System.Drawing.Size(121, 23);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.saveToolStripMenuItem1.Text = "Export";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(143, 6);
            // 
            // makeRecipesToolStripMenuItem2
            // 
            this.makeRecipesToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reforgeTypeToolStripMenuItem,
            this.targetTypeToolStripMenuItem,
            this.materialTypeToolStripMenuItem});
            this.makeRecipesToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.bullet_toggle_plus;
            this.makeRecipesToolStripMenuItem2.Name = "makeRecipesToolStripMenuItem2";
            this.makeRecipesToolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.makeRecipesToolStripMenuItem2.Text = "Make Recipes";
            // 
            // reforgeTypeToolStripMenuItem
            // 
            this.reforgeTypeToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.reforgeTypeToolStripMenuItem.Name = "reforgeTypeToolStripMenuItem";
            this.reforgeTypeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.reforgeTypeToolStripMenuItem.Text = "Reforge Type";
            this.reforgeTypeToolStripMenuItem.Click += new System.EventHandler(this.reforgeTypeToolStripMenuItem_Click);
            // 
            // targetTypeToolStripMenuItem
            // 
            this.targetTypeToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.targetTypeToolStripMenuItem.Name = "targetTypeToolStripMenuItem";
            this.targetTypeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.targetTypeToolStripMenuItem.Text = "Target Type";
            this.targetTypeToolStripMenuItem.Click += new System.EventHandler(this.makeRecipesToolStripMenuItem_Click);
            // 
            // materialTypeToolStripMenuItem
            // 
            this.materialTypeToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.materialTypeToolStripMenuItem.Name = "materialTypeToolStripMenuItem";
            this.materialTypeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.materialTypeToolStripMenuItem.Text = "Material Type";
            this.materialTypeToolStripMenuItem.Click += new System.EventHandler(this.makeRecipesToolStripMenuItem1_Click);
            // 
            // comboBox_lists
            // 
            this.comboBox_lists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lists.FormattingEnabled = true;
            this.comboBox_lists.Location = new System.Drawing.Point(6, 19);
            this.comboBox_lists.Name = "comboBox_lists";
            this.comboBox_lists.Size = new System.Drawing.Size(260, 21);
            this.comboBox_lists.TabIndex = 18;
            this.comboBox_lists.SelectedIndexChanged += new System.EventHandler(this.change_list);
            // 
            // listbox_description
            // 
            this.listbox_description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listbox_description.Controls.Add(this.listBox_items);
            this.listbox_description.Location = new System.Drawing.Point(12, 78);
            this.listbox_description.Name = "listbox_description";
            this.listbox_description.Size = new System.Drawing.Size(272, 553);
            this.listbox_description.TabIndex = 19;
            this.listbox_description.TabStop = false;
            this.listbox_description.Text = "Items";
            // 
            // listBox_items
            // 
            this.listBox_items.AllowUserToAddRows = false;
            this.listBox_items.AllowUserToDeleteRows = false;
            this.listBox_items.AllowUserToResizeColumns = false;
            this.listBox_items.AllowUserToResizeRows = false;
            this.listBox_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_items.BackgroundColor = System.Drawing.Color.White;
            this.listBox_items.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.listBox_items.ColumnHeadersHeight = 30;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnImg,
            this.ColumnName});
            this.listBox_items.ContextMenuStrip = this.listbox_items_menu;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle7;
            this.listBox_items.DoubleBuffered = true;
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox_items.Location = new System.Drawing.Point(6, 19);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.listBox_items.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.listBox_items.RowTemplate.Height = 30;
            this.listBox_items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(260, 528);
            this.listBox_items.TabIndex = 28;
            this.listBox_items.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellMouseEnter);
            this.listBox_items.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellMouseLeave);
            this.listBox_items.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellValueChanged);
            this.listBox_items.SelectionChanged += new System.EventHandler(this.listBox_items_CellClick);
            this.listBox_items.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileOrginizerForm_KeyDown);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.FillWeight = 50F;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.MinimumWidth = 50;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnId.Width = 50;
            // 
            // ColumnImg
            // 
            this.ColumnImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnImg.FillWeight = 30F;
            this.ColumnImg.HeaderText = "Img";
            this.ColumnImg.Image = global::PWDataEditorPaied.Properties.Resources.blank;
            this.ColumnImg.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColumnImg.MinimumWidth = 30;
            this.ColumnImg.Name = "ColumnImg";
            this.ColumnImg.ReadOnly = true;
            this.ColumnImg.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnImg.Width = 30;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_lists);
            this.groupBox2.Location = new System.Drawing.Point(12, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 50);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.File;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Load";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configEditorExportToolStripMenuItem,
            this.exportSkillsToListToolStripMenuItem,
            this.readListDEBUGToolStripMenuItem,
            this.skillsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // configEditorExportToolStripMenuItem
            // 
            this.configEditorExportToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.configEditorExportToolStripMenuItem.Name = "configEditorExportToolStripMenuItem";
            this.configEditorExportToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.configEditorExportToolStripMenuItem.Text = "Config Editor Export";
            this.configEditorExportToolStripMenuItem.Click += new System.EventHandler(this.configEditorExportToolStripMenuItem_Click);
            // 
            // exportSkillsToListToolStripMenuItem
            // 
            this.exportSkillsToListToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.exportSkillsToListToolStripMenuItem.Name = "exportSkillsToListToolStripMenuItem";
            this.exportSkillsToListToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exportSkillsToListToolStripMenuItem.Text = "Export Skills To List";
            this.exportSkillsToListToolStripMenuItem.Click += new System.EventHandler(this.exportSkillsToListToolStripMenuItem_Click);
            // 
            // readListDEBUGToolStripMenuItem
            // 
            this.readListDEBUGToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.heand;
            this.readListDEBUGToolStripMenuItem.Name = "readListDEBUGToolStripMenuItem";
            this.readListDEBUGToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.readListDEBUGToolStripMenuItem.Text = "Read List(DEBUG)";
            this.readListDEBUGToolStripMenuItem.Click += new System.EventHandler(this.readListDEBUGToolStripMenuItem_Click);
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.infoIcon;
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.skillsToolStripMenuItem.Text = "Skills Octets Generator";
            this.skillsToolStripMenuItem.Click += new System.EventHandler(this.skillsToolStripMenuItem_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox9.Controls.Add(this.caseSensitiveCheckbox);
            this.groupBox9.Controls.Add(this.btnAdd);
            this.groupBox9.Controls.Add(this.searchInput1);
            this.groupBox9.Location = new System.Drawing.Point(15, 636);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(272, 71);
            this.groupBox9.TabIndex = 23;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Search";
            // 
            // caseSensitiveCheckbox
            // 
            this.caseSensitiveCheckbox.AutoSize = true;
            this.caseSensitiveCheckbox.Checked = true;
            this.caseSensitiveCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.caseSensitiveCheckbox.Location = new System.Drawing.Point(7, 47);
            this.caseSensitiveCheckbox.Name = "caseSensitiveCheckbox";
            this.caseSensitiveCheckbox.Size = new System.Drawing.Size(94, 17);
            this.caseSensitiveCheckbox.TabIndex = 12;
            this.caseSensitiveCheckbox.Text = "Case-sensitive";
            this.caseSensitiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = global::PWDataEditorPaied.Properties.Resources.Find;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(216, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // searchInput1
            // 
            this.searchInput1.Location = new System.Drawing.Point(6, 19);
            this.searchInput1.Name = "searchInput1";
            this.searchInput1.Size = new System.Drawing.Size(189, 20);
            this.searchInput1.TabIndex = 10;
            // 
            // progres
            // 
            this.progres.AutoSize = true;
            this.progres.Location = new System.Drawing.Point(6, 9);
            this.progres.Name = "progres";
            this.progres.Size = new System.Drawing.Size(38, 13);
            this.progres.TabIndex = 26;
            this.progres.Text = "Ready";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(613, 21);
            this.progressBar1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Version:";
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.Location = new System.Drawing.Point(332, 7);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(13, 13);
            this.version_label.TabIndex = 27;
            this.version_label.Text = "0";
            // 
            // row_editor_context
            // 
            this.row_editor_context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem});
            this.row_editor_context.Name = "row_editor_context";
            this.row_editor_context.Size = new System.Drawing.Size(116, 26);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Save;
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.changeToolStripMenuItem.Text = "Change";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // elementIntoTab
            // 
            this.elementIntoTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementIntoTab.Controls.Add(this.Edit);
            this.elementIntoTab.Controls.Add(this.SaleTab);
            this.elementIntoTab.Controls.Add(this.craftTab);
            this.elementIntoTab.Controls.Add(this.tabPage1);
            this.elementIntoTab.Controls.Add(this.tabPage4);
            this.elementIntoTab.Location = new System.Drawing.Point(293, 28);
            this.elementIntoTab.Name = "elementIntoTab";
            this.elementIntoTab.SelectedIndex = 0;
            this.elementIntoTab.Size = new System.Drawing.Size(633, 571);
            this.elementIntoTab.TabIndex = 31;
            this.elementIntoTab.SelectedIndexChanged += new System.EventHandler(this.elementIntoTab_SelectedIndexChanged);
            // 
            // Edit
            // 
            this.Edit.Controls.Add(this.dataGridView_item);
            this.Edit.Location = new System.Drawing.Point(4, 22);
            this.Edit.Name = "Edit";
            this.Edit.Padding = new System.Windows.Forms.Padding(3);
            this.Edit.Size = new System.Drawing.Size(625, 545);
            this.Edit.TabIndex = 0;
            this.Edit.Text = "Editor";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // dataGridView_item
            // 
            this.dataGridView_item.AllowUserToAddRows = false;
            this.dataGridView_item.AllowUserToDeleteRows = false;
            this.dataGridView_item.AllowUserToResizeColumns = false;
            this.dataGridView_item.AllowUserToResizeRows = false;
            this.dataGridView_item.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_item.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_item.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView_item.ColumnHeadersHeight = 22;
            this.dataGridView_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowId,
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataGridView_item.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView_item.DoubleBuffered = true;
            this.dataGridView_item.Location = new System.Drawing.Point(1, 1);
            this.dataGridView_item.Name = "dataGridView_item";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_item.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_item.RowHeadersVisible = false;
            this.dataGridView_item.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_item.Size = new System.Drawing.Size(622, 544);
            this.dataGridView_item.TabIndex = 1;
            this.dataGridView_item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_item_CellClick);
            this.dataGridView_item.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_item_CellMouseEnter);
            this.dataGridView_item.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_item_CellMouseLeave);
            this.dataGridView_item.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.change_value);
            this.dataGridView_item.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_item_EditingControlShowing);
            this.dataGridView_item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_item_KeyDown_1);
            // 
            // RowId
            // 
            this.RowId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RowId.Frozen = true;
            this.RowId.HeaderText = "Id";
            this.RowId.Name = "RowId";
            this.RowId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowId.Width = 22;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 60;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 60;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "i";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 15;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 115.4045F;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SaleTab
            // 
            this.SaleTab.Controls.Add(this.groupBox4);
            this.SaleTab.Controls.Add(this.groupBox1);
            this.SaleTab.Location = new System.Drawing.Point(4, 22);
            this.SaleTab.Name = "SaleTab";
            this.SaleTab.Padding = new System.Windows.Forms.Padding(3);
            this.SaleTab.Size = new System.Drawing.Size(625, 545);
            this.SaleTab.TabIndex = 2;
            this.SaleTab.Text = "Sale Preview";
            this.SaleTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.tab_salebtn_1);
            this.groupBox4.Controls.Add(this.tab_salebtn_5);
            this.groupBox4.Controls.Add(this.tab_salebtn_2);
            this.groupBox4.Controls.Add(this.tab_salebtn_8);
            this.groupBox4.Controls.Add(this.tab_salebtn_3);
            this.groupBox4.Controls.Add(this.tab_salebtn_7);
            this.groupBox4.Controls.Add(this.tab_salebtn_4);
            this.groupBox4.Controls.Add(this.tab_salebtn_6);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 100);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pages";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(228, 69);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 22);
            this.button10.TabIndex = 50;
            this.button10.Text = "Rename";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.addItemSalePreview);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(214, 20);
            this.textBox2.TabIndex = 50;
            // 
            // tab_salebtn_1
            // 
            this.tab_salebtn_1.BackColor = System.Drawing.Color.Black;
            this.tab_salebtn_1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_1.ForeColor = System.Drawing.Color.White;
            this.tab_salebtn_1.Location = new System.Drawing.Point(6, 19);
            this.tab_salebtn_1.Name = "tab_salebtn_1";
            this.tab_salebtn_1.Size = new System.Drawing.Size(69, 20);
            this.tab_salebtn_1.TabIndex = 37;
            this.tab_salebtn_1.Text = "Page 1";
            this.tab_salebtn_1.UseVisualStyleBackColor = false;
            this.tab_salebtn_1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_5
            // 
            this.tab_salebtn_5.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_5.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_5.Location = new System.Drawing.Point(7, 45);
            this.tab_salebtn_5.Name = "tab_salebtn_5";
            this.tab_salebtn_5.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_5.TabIndex = 45;
            this.tab_salebtn_5.Text = "Page 4";
            this.tab_salebtn_5.UseVisualStyleBackColor = false;
            this.tab_salebtn_5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_2
            // 
            this.tab_salebtn_2.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_2.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_2.Location = new System.Drawing.Point(82, 19);
            this.tab_salebtn_2.Name = "tab_salebtn_2";
            this.tab_salebtn_2.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_2.TabIndex = 38;
            this.tab_salebtn_2.Text = "Page 2";
            this.tab_salebtn_2.UseVisualStyleBackColor = false;
            this.tab_salebtn_2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_8
            // 
            this.tab_salebtn_8.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_8.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_8.Location = new System.Drawing.Point(225, 45);
            this.tab_salebtn_8.Name = "tab_salebtn_8";
            this.tab_salebtn_8.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_8.TabIndex = 44;
            this.tab_salebtn_8.Text = "Page 7";
            this.tab_salebtn_8.UseVisualStyleBackColor = false;
            this.tab_salebtn_8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_3
            // 
            this.tab_salebtn_3.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_3.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_3.Location = new System.Drawing.Point(153, 19);
            this.tab_salebtn_3.Name = "tab_salebtn_3";
            this.tab_salebtn_3.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_3.TabIndex = 39;
            this.tab_salebtn_3.Text = "Page 3";
            this.tab_salebtn_3.UseVisualStyleBackColor = false;
            this.tab_salebtn_3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_7
            // 
            this.tab_salebtn_7.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_7.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_7.Location = new System.Drawing.Point(153, 45);
            this.tab_salebtn_7.Name = "tab_salebtn_7";
            this.tab_salebtn_7.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_7.TabIndex = 43;
            this.tab_salebtn_7.Text = "Page 6";
            this.tab_salebtn_7.UseVisualStyleBackColor = false;
            this.tab_salebtn_7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_4
            // 
            this.tab_salebtn_4.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_4.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_4.Location = new System.Drawing.Point(225, 19);
            this.tab_salebtn_4.Name = "tab_salebtn_4";
            this.tab_salebtn_4.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_4.TabIndex = 40;
            this.tab_salebtn_4.Text = "Page 4";
            this.tab_salebtn_4.UseVisualStyleBackColor = false;
            this.tab_salebtn_4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // tab_salebtn_6
            // 
            this.tab_salebtn_6.BackColor = System.Drawing.Color.White;
            this.tab_salebtn_6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_salebtn_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_salebtn_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_salebtn_6.ForeColor = System.Drawing.Color.Black;
            this.tab_salebtn_6.Location = new System.Drawing.Point(82, 45);
            this.tab_salebtn_6.Name = "tab_salebtn_6";
            this.tab_salebtn_6.Size = new System.Drawing.Size(68, 20);
            this.tab_salebtn_6.TabIndex = 42;
            this.tab_salebtn_6.Text = "Page 5";
            this.tab_salebtn_6.UseVisualStyleBackColor = false;
            this.tab_salebtn_6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label_item_32);
            this.groupBox1.Controls.Add(this.label_item_31);
            this.groupBox1.Controls.Add(this.label_item_30);
            this.groupBox1.Controls.Add(this.label_item_29);
            this.groupBox1.Controls.Add(this.label_item_28);
            this.groupBox1.Controls.Add(this.label_item_27);
            this.groupBox1.Controls.Add(this.label_item_26);
            this.groupBox1.Controls.Add(this.label_item_25);
            this.groupBox1.Controls.Add(this.label_item_24);
            this.groupBox1.Controls.Add(this.label_item_23);
            this.groupBox1.Controls.Add(this.label_item_22);
            this.groupBox1.Controls.Add(this.label_item_21);
            this.groupBox1.Controls.Add(this.label_item_20);
            this.groupBox1.Controls.Add(this.label_item_19);
            this.groupBox1.Controls.Add(this.label_item_18);
            this.groupBox1.Controls.Add(this.label_item_17);
            this.groupBox1.Controls.Add(this.label_item_16);
            this.groupBox1.Controls.Add(this.label_item_15);
            this.groupBox1.Controls.Add(this.label_item_14);
            this.groupBox1.Controls.Add(this.label_item_13);
            this.groupBox1.Controls.Add(this.label_item_12);
            this.groupBox1.Controls.Add(this.label_item_11);
            this.groupBox1.Controls.Add(this.label_item_10);
            this.groupBox1.Controls.Add(this.label_item_9);
            this.groupBox1.Controls.Add(this.label_item_8);
            this.groupBox1.Controls.Add(this.label_item_7);
            this.groupBox1.Controls.Add(this.label_item_6);
            this.groupBox1.Controls.Add(this.label_item_5);
            this.groupBox1.Controls.Add(this.label_item_4);
            this.groupBox1.Controls.Add(this.label_item_3);
            this.groupBox1.Controls.Add(this.label_item_2);
            this.groupBox1.Controls.Add(this.label_item_1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.picture_item_32);
            this.groupBox1.Controls.Add(this.picture_item_31);
            this.groupBox1.Controls.Add(this.picture_item_30);
            this.groupBox1.Controls.Add(this.picture_item_29);
            this.groupBox1.Controls.Add(this.picture_item_28);
            this.groupBox1.Controls.Add(this.picture_item_27);
            this.groupBox1.Controls.Add(this.picture_item_26);
            this.groupBox1.Controls.Add(this.picture_item_25);
            this.groupBox1.Controls.Add(this.picture_item_24);
            this.groupBox1.Controls.Add(this.picture_item_23);
            this.groupBox1.Controls.Add(this.picture_item_22);
            this.groupBox1.Controls.Add(this.picture_item_21);
            this.groupBox1.Controls.Add(this.picture_item_20);
            this.groupBox1.Controls.Add(this.picture_item_19);
            this.groupBox1.Controls.Add(this.picture_item_18);
            this.groupBox1.Controls.Add(this.picture_item_17);
            this.groupBox1.Controls.Add(this.picture_item_16);
            this.groupBox1.Controls.Add(this.picture_item_15);
            this.groupBox1.Controls.Add(this.picture_item_14);
            this.groupBox1.Controls.Add(this.picture_item_13);
            this.groupBox1.Controls.Add(this.picture_item_12);
            this.groupBox1.Controls.Add(this.picture_item_11);
            this.groupBox1.Controls.Add(this.picture_item_10);
            this.groupBox1.Controls.Add(this.picture_item_9);
            this.groupBox1.Controls.Add(this.picture_item_8);
            this.groupBox1.Controls.Add(this.picture_item_7);
            this.groupBox1.Controls.Add(this.picture_item_6);
            this.groupBox1.Controls.Add(this.picture_item_5);
            this.groupBox1.Controls.Add(this.picture_item_4);
            this.groupBox1.Controls.Add(this.picture_item_3);
            this.groupBox1.Controls.Add(this.picture_item_2);
            this.groupBox1.Controls.Add(this.picture_item_1);
            this.groupBox1.Location = new System.Drawing.Point(3, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 79;
            this.checkBox1.Text = "Show Item ID";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // label_item_32
            // 
            this.label_item_32.AutoSize = true;
            this.label_item_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_32.Location = new System.Drawing.Point(256, 130);
            this.label_item_32.Name = "label_item_32";
            this.label_item_32.Size = new System.Drawing.Size(37, 13);
            this.label_item_32.TabIndex = 76;
            this.label_item_32.Text = "12345";
            this.label_item_32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_31
            // 
            this.label_item_31.AutoSize = true;
            this.label_item_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_31.Location = new System.Drawing.Point(220, 130);
            this.label_item_31.Name = "label_item_31";
            this.label_item_31.Size = new System.Drawing.Size(37, 13);
            this.label_item_31.TabIndex = 78;
            this.label_item_31.Text = "12345";
            this.label_item_31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_30
            // 
            this.label_item_30.AutoSize = true;
            this.label_item_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_30.Location = new System.Drawing.Point(184, 130);
            this.label_item_30.Name = "label_item_30";
            this.label_item_30.Size = new System.Drawing.Size(37, 13);
            this.label_item_30.TabIndex = 77;
            this.label_item_30.Text = "12345";
            this.label_item_30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_29
            // 
            this.label_item_29.AutoSize = true;
            this.label_item_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_29.Location = new System.Drawing.Point(148, 130);
            this.label_item_29.Name = "label_item_29";
            this.label_item_29.Size = new System.Drawing.Size(37, 13);
            this.label_item_29.TabIndex = 75;
            this.label_item_29.Text = "12345";
            this.label_item_29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_28
            // 
            this.label_item_28.AutoSize = true;
            this.label_item_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_28.Location = new System.Drawing.Point(113, 130);
            this.label_item_28.Name = "label_item_28";
            this.label_item_28.Size = new System.Drawing.Size(37, 13);
            this.label_item_28.TabIndex = 74;
            this.label_item_28.Text = "12345";
            this.label_item_28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_27
            // 
            this.label_item_27.AutoSize = true;
            this.label_item_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_27.Location = new System.Drawing.Point(77, 130);
            this.label_item_27.Name = "label_item_27";
            this.label_item_27.Size = new System.Drawing.Size(37, 13);
            this.label_item_27.TabIndex = 73;
            this.label_item_27.Text = "12345";
            this.label_item_27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_26
            // 
            this.label_item_26.AutoSize = true;
            this.label_item_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_26.Location = new System.Drawing.Point(41, 130);
            this.label_item_26.Name = "label_item_26";
            this.label_item_26.Size = new System.Drawing.Size(37, 13);
            this.label_item_26.TabIndex = 72;
            this.label_item_26.Text = "12345";
            this.label_item_26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_25
            // 
            this.label_item_25.AutoSize = true;
            this.label_item_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_25.Location = new System.Drawing.Point(5, 130);
            this.label_item_25.Name = "label_item_25";
            this.label_item_25.Size = new System.Drawing.Size(37, 13);
            this.label_item_25.TabIndex = 71;
            this.label_item_25.Text = "12345";
            this.label_item_25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_24
            // 
            this.label_item_24.AutoSize = true;
            this.label_item_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_24.Location = new System.Drawing.Point(257, 92);
            this.label_item_24.Name = "label_item_24";
            this.label_item_24.Size = new System.Drawing.Size(37, 13);
            this.label_item_24.TabIndex = 68;
            this.label_item_24.Text = "12345";
            this.label_item_24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_23
            // 
            this.label_item_23.AutoSize = true;
            this.label_item_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_23.Location = new System.Drawing.Point(221, 92);
            this.label_item_23.Name = "label_item_23";
            this.label_item_23.Size = new System.Drawing.Size(37, 13);
            this.label_item_23.TabIndex = 70;
            this.label_item_23.Text = "12345";
            this.label_item_23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_22
            // 
            this.label_item_22.AutoSize = true;
            this.label_item_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_22.Location = new System.Drawing.Point(185, 92);
            this.label_item_22.Name = "label_item_22";
            this.label_item_22.Size = new System.Drawing.Size(37, 13);
            this.label_item_22.TabIndex = 69;
            this.label_item_22.Text = "12345";
            this.label_item_22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_21
            // 
            this.label_item_21.AutoSize = true;
            this.label_item_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_21.Location = new System.Drawing.Point(149, 92);
            this.label_item_21.Name = "label_item_21";
            this.label_item_21.Size = new System.Drawing.Size(37, 13);
            this.label_item_21.TabIndex = 67;
            this.label_item_21.Text = "12345";
            this.label_item_21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_20
            // 
            this.label_item_20.AutoSize = true;
            this.label_item_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_20.Location = new System.Drawing.Point(114, 92);
            this.label_item_20.Name = "label_item_20";
            this.label_item_20.Size = new System.Drawing.Size(37, 13);
            this.label_item_20.TabIndex = 66;
            this.label_item_20.Text = "12345";
            this.label_item_20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_19
            // 
            this.label_item_19.AutoSize = true;
            this.label_item_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_19.Location = new System.Drawing.Point(78, 92);
            this.label_item_19.Name = "label_item_19";
            this.label_item_19.Size = new System.Drawing.Size(37, 13);
            this.label_item_19.TabIndex = 65;
            this.label_item_19.Text = "12345";
            this.label_item_19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_18
            // 
            this.label_item_18.AutoSize = true;
            this.label_item_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_18.Location = new System.Drawing.Point(42, 92);
            this.label_item_18.Name = "label_item_18";
            this.label_item_18.Size = new System.Drawing.Size(37, 13);
            this.label_item_18.TabIndex = 64;
            this.label_item_18.Text = "12345";
            this.label_item_18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_17
            // 
            this.label_item_17.AutoSize = true;
            this.label_item_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_17.Location = new System.Drawing.Point(6, 92);
            this.label_item_17.Name = "label_item_17";
            this.label_item_17.Size = new System.Drawing.Size(37, 13);
            this.label_item_17.TabIndex = 63;
            this.label_item_17.Text = "12345";
            this.label_item_17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_16
            // 
            this.label_item_16.AutoSize = true;
            this.label_item_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_16.Location = new System.Drawing.Point(257, 57);
            this.label_item_16.Name = "label_item_16";
            this.label_item_16.Size = new System.Drawing.Size(37, 13);
            this.label_item_16.TabIndex = 60;
            this.label_item_16.Text = "12345";
            this.label_item_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_15
            // 
            this.label_item_15.AutoSize = true;
            this.label_item_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_15.Location = new System.Drawing.Point(221, 57);
            this.label_item_15.Name = "label_item_15";
            this.label_item_15.Size = new System.Drawing.Size(37, 13);
            this.label_item_15.TabIndex = 62;
            this.label_item_15.Text = "12345";
            this.label_item_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_14
            // 
            this.label_item_14.AutoSize = true;
            this.label_item_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_14.Location = new System.Drawing.Point(185, 57);
            this.label_item_14.Name = "label_item_14";
            this.label_item_14.Size = new System.Drawing.Size(37, 13);
            this.label_item_14.TabIndex = 61;
            this.label_item_14.Text = "12345";
            this.label_item_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_13
            // 
            this.label_item_13.AutoSize = true;
            this.label_item_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_13.Location = new System.Drawing.Point(149, 57);
            this.label_item_13.Name = "label_item_13";
            this.label_item_13.Size = new System.Drawing.Size(37, 13);
            this.label_item_13.TabIndex = 59;
            this.label_item_13.Text = "12345";
            this.label_item_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_12
            // 
            this.label_item_12.AutoSize = true;
            this.label_item_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_12.Location = new System.Drawing.Point(114, 57);
            this.label_item_12.Name = "label_item_12";
            this.label_item_12.Size = new System.Drawing.Size(37, 13);
            this.label_item_12.TabIndex = 58;
            this.label_item_12.Text = "12345";
            this.label_item_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_11
            // 
            this.label_item_11.AutoSize = true;
            this.label_item_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_11.Location = new System.Drawing.Point(78, 57);
            this.label_item_11.Name = "label_item_11";
            this.label_item_11.Size = new System.Drawing.Size(37, 13);
            this.label_item_11.TabIndex = 57;
            this.label_item_11.Text = "12345";
            this.label_item_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_10
            // 
            this.label_item_10.AutoSize = true;
            this.label_item_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_10.Location = new System.Drawing.Point(42, 57);
            this.label_item_10.Name = "label_item_10";
            this.label_item_10.Size = new System.Drawing.Size(37, 13);
            this.label_item_10.TabIndex = 56;
            this.label_item_10.Text = "12345";
            this.label_item_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_9
            // 
            this.label_item_9.AutoSize = true;
            this.label_item_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_9.Location = new System.Drawing.Point(6, 57);
            this.label_item_9.Name = "label_item_9";
            this.label_item_9.Size = new System.Drawing.Size(37, 13);
            this.label_item_9.TabIndex = 55;
            this.label_item_9.Text = "12345";
            this.label_item_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_8
            // 
            this.label_item_8.AutoSize = true;
            this.label_item_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_8.Location = new System.Drawing.Point(257, 19);
            this.label_item_8.Name = "label_item_8";
            this.label_item_8.Size = new System.Drawing.Size(37, 13);
            this.label_item_8.TabIndex = 53;
            this.label_item_8.Text = "12345";
            this.label_item_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_7
            // 
            this.label_item_7.AutoSize = true;
            this.label_item_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_7.Location = new System.Drawing.Point(221, 19);
            this.label_item_7.Name = "label_item_7";
            this.label_item_7.Size = new System.Drawing.Size(37, 13);
            this.label_item_7.TabIndex = 54;
            this.label_item_7.Text = "12345";
            this.label_item_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_6
            // 
            this.label_item_6.AutoSize = true;
            this.label_item_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_6.Location = new System.Drawing.Point(185, 19);
            this.label_item_6.Name = "label_item_6";
            this.label_item_6.Size = new System.Drawing.Size(37, 13);
            this.label_item_6.TabIndex = 53;
            this.label_item_6.Text = "12345";
            this.label_item_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_5
            // 
            this.label_item_5.AutoSize = true;
            this.label_item_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_5.Location = new System.Drawing.Point(149, 19);
            this.label_item_5.Name = "label_item_5";
            this.label_item_5.Size = new System.Drawing.Size(37, 13);
            this.label_item_5.TabIndex = 52;
            this.label_item_5.Text = "12345";
            this.label_item_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_4
            // 
            this.label_item_4.AutoSize = true;
            this.label_item_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_4.Location = new System.Drawing.Point(114, 19);
            this.label_item_4.Name = "label_item_4";
            this.label_item_4.Size = new System.Drawing.Size(37, 13);
            this.label_item_4.TabIndex = 51;
            this.label_item_4.Text = "12345";
            this.label_item_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_3
            // 
            this.label_item_3.AutoSize = true;
            this.label_item_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_3.Location = new System.Drawing.Point(78, 19);
            this.label_item_3.Name = "label_item_3";
            this.label_item_3.Size = new System.Drawing.Size(37, 13);
            this.label_item_3.TabIndex = 50;
            this.label_item_3.Text = "12345";
            this.label_item_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_2
            // 
            this.label_item_2.AutoSize = true;
            this.label_item_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_2.Location = new System.Drawing.Point(42, 19);
            this.label_item_2.Name = "label_item_2";
            this.label_item_2.Size = new System.Drawing.Size(37, 13);
            this.label_item_2.TabIndex = 49;
            this.label_item_2.Text = "12345";
            this.label_item_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_item_1
            // 
            this.label_item_1.AutoSize = true;
            this.label_item_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_1.Location = new System.Drawing.Point(6, 19);
            this.label_item_1.Name = "label_item_1";
            this.label_item_1.Size = new System.Drawing.Size(37, 13);
            this.label_item_1.TabIndex = 47;
            this.label_item_1.Text = "12345";
            this.label_item_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(222, 168);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(69, 22);
            this.button8.TabIndex = 48;
            this.button8.Text = "Add";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 47;
            this.textBox1.Text = "0";
            // 
            // picture_item_32
            // 
            this.picture_item_32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_32.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_32.Location = new System.Drawing.Point(259, 130);
            this.picture_item_32.Name = "picture_item_32";
            this.picture_item_32.Size = new System.Drawing.Size(32, 32);
            this.picture_item_32.TabIndex = 31;
            this.picture_item_32.TabStop = false;
            this.picture_item_32.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_32.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_32.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // contextMenuStripSalePreview
            // 
            this.contextMenuStripSalePreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveHereToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem1});
            this.contextMenuStripSalePreview.Name = "contextMenuStripSalePreview";
            this.contextMenuStripSalePreview.Size = new System.Drawing.Size(133, 54);
            // 
            // moveHereToolStripMenuItem
            // 
            this.moveHereToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.moveHereToolStripMenuItem.Name = "moveHereToolStripMenuItem";
            this.moveHereToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.moveHereToolStripMenuItem.Text = "Move Here";
            this.moveHereToolStripMenuItem.Click += new System.EventHandler(this.moveHereToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.delteItemSalePreview);
            // 
            // picture_item_31
            // 
            this.picture_item_31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_31.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_31.Location = new System.Drawing.Point(223, 130);
            this.picture_item_31.Name = "picture_item_31";
            this.picture_item_31.Size = new System.Drawing.Size(32, 32);
            this.picture_item_31.TabIndex = 30;
            this.picture_item_31.TabStop = false;
            this.picture_item_31.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_31.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_31.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_30
            // 
            this.picture_item_30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_30.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_30.Location = new System.Drawing.Point(187, 130);
            this.picture_item_30.Name = "picture_item_30";
            this.picture_item_30.Size = new System.Drawing.Size(32, 32);
            this.picture_item_30.TabIndex = 29;
            this.picture_item_30.TabStop = false;
            this.picture_item_30.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_30.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_30.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_29
            // 
            this.picture_item_29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_29.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_29.Location = new System.Drawing.Point(151, 130);
            this.picture_item_29.Name = "picture_item_29";
            this.picture_item_29.Size = new System.Drawing.Size(32, 32);
            this.picture_item_29.TabIndex = 28;
            this.picture_item_29.TabStop = false;
            this.picture_item_29.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_29.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_29.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_28
            // 
            this.picture_item_28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_28.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_28.Location = new System.Drawing.Point(116, 130);
            this.picture_item_28.Name = "picture_item_28";
            this.picture_item_28.Size = new System.Drawing.Size(32, 32);
            this.picture_item_28.TabIndex = 27;
            this.picture_item_28.TabStop = false;
            this.picture_item_28.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_28.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_28.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_27
            // 
            this.picture_item_27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_27.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_27.Location = new System.Drawing.Point(80, 130);
            this.picture_item_27.Name = "picture_item_27";
            this.picture_item_27.Size = new System.Drawing.Size(32, 32);
            this.picture_item_27.TabIndex = 26;
            this.picture_item_27.TabStop = false;
            this.picture_item_27.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_27.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_27.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_26
            // 
            this.picture_item_26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_26.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_26.Location = new System.Drawing.Point(44, 130);
            this.picture_item_26.Name = "picture_item_26";
            this.picture_item_26.Size = new System.Drawing.Size(32, 32);
            this.picture_item_26.TabIndex = 25;
            this.picture_item_26.TabStop = false;
            this.picture_item_26.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_26.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_26.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_25
            // 
            this.picture_item_25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_25.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_25.Location = new System.Drawing.Point(8, 130);
            this.picture_item_25.Name = "picture_item_25";
            this.picture_item_25.Size = new System.Drawing.Size(32, 32);
            this.picture_item_25.TabIndex = 24;
            this.picture_item_25.TabStop = false;
            this.picture_item_25.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_25.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_25.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_24
            // 
            this.picture_item_24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_24.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_24.Location = new System.Drawing.Point(259, 92);
            this.picture_item_24.Name = "picture_item_24";
            this.picture_item_24.Size = new System.Drawing.Size(32, 32);
            this.picture_item_24.TabIndex = 23;
            this.picture_item_24.TabStop = false;
            this.picture_item_24.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_24.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_24.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_23
            // 
            this.picture_item_23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_23.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_23.Location = new System.Drawing.Point(223, 92);
            this.picture_item_23.Name = "picture_item_23";
            this.picture_item_23.Size = new System.Drawing.Size(32, 32);
            this.picture_item_23.TabIndex = 22;
            this.picture_item_23.TabStop = false;
            this.picture_item_23.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_23.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_23.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_22
            // 
            this.picture_item_22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_22.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_22.Location = new System.Drawing.Point(187, 92);
            this.picture_item_22.Name = "picture_item_22";
            this.picture_item_22.Size = new System.Drawing.Size(32, 32);
            this.picture_item_22.TabIndex = 21;
            this.picture_item_22.TabStop = false;
            this.picture_item_22.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_22.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_22.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_21
            // 
            this.picture_item_21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_21.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_21.Location = new System.Drawing.Point(151, 92);
            this.picture_item_21.Name = "picture_item_21";
            this.picture_item_21.Size = new System.Drawing.Size(32, 32);
            this.picture_item_21.TabIndex = 20;
            this.picture_item_21.TabStop = false;
            this.picture_item_21.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_21.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_21.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_20
            // 
            this.picture_item_20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_20.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_20.Location = new System.Drawing.Point(116, 92);
            this.picture_item_20.Name = "picture_item_20";
            this.picture_item_20.Size = new System.Drawing.Size(32, 32);
            this.picture_item_20.TabIndex = 19;
            this.picture_item_20.TabStop = false;
            this.picture_item_20.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_20.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_20.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_19
            // 
            this.picture_item_19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_19.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_19.Location = new System.Drawing.Point(80, 92);
            this.picture_item_19.Name = "picture_item_19";
            this.picture_item_19.Size = new System.Drawing.Size(32, 32);
            this.picture_item_19.TabIndex = 18;
            this.picture_item_19.TabStop = false;
            this.picture_item_19.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_19.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_19.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_18
            // 
            this.picture_item_18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_18.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_18.Location = new System.Drawing.Point(44, 92);
            this.picture_item_18.Name = "picture_item_18";
            this.picture_item_18.Size = new System.Drawing.Size(32, 32);
            this.picture_item_18.TabIndex = 17;
            this.picture_item_18.TabStop = false;
            this.picture_item_18.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_18.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_18.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_17
            // 
            this.picture_item_17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_17.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_17.Location = new System.Drawing.Point(8, 92);
            this.picture_item_17.Name = "picture_item_17";
            this.picture_item_17.Size = new System.Drawing.Size(32, 32);
            this.picture_item_17.TabIndex = 16;
            this.picture_item_17.TabStop = false;
            this.picture_item_17.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_17.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_17.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_16
            // 
            this.picture_item_16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_16.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_16.Location = new System.Drawing.Point(260, 57);
            this.picture_item_16.Name = "picture_item_16";
            this.picture_item_16.Size = new System.Drawing.Size(32, 32);
            this.picture_item_16.TabIndex = 15;
            this.picture_item_16.TabStop = false;
            this.picture_item_16.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_16.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_16.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_15
            // 
            this.picture_item_15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_15.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_15.Location = new System.Drawing.Point(224, 57);
            this.picture_item_15.Name = "picture_item_15";
            this.picture_item_15.Size = new System.Drawing.Size(32, 32);
            this.picture_item_15.TabIndex = 14;
            this.picture_item_15.TabStop = false;
            this.picture_item_15.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_15.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_15.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_14
            // 
            this.picture_item_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_14.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_14.Location = new System.Drawing.Point(188, 57);
            this.picture_item_14.Name = "picture_item_14";
            this.picture_item_14.Size = new System.Drawing.Size(32, 32);
            this.picture_item_14.TabIndex = 13;
            this.picture_item_14.TabStop = false;
            this.picture_item_14.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_14.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_14.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_13
            // 
            this.picture_item_13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_13.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_13.Location = new System.Drawing.Point(152, 57);
            this.picture_item_13.Name = "picture_item_13";
            this.picture_item_13.Size = new System.Drawing.Size(32, 32);
            this.picture_item_13.TabIndex = 12;
            this.picture_item_13.TabStop = false;
            this.picture_item_13.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_13.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_13.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_12
            // 
            this.picture_item_12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_12.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_12.Location = new System.Drawing.Point(117, 57);
            this.picture_item_12.Name = "picture_item_12";
            this.picture_item_12.Size = new System.Drawing.Size(32, 32);
            this.picture_item_12.TabIndex = 11;
            this.picture_item_12.TabStop = false;
            this.picture_item_12.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_12.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_12.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_11
            // 
            this.picture_item_11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_11.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_11.Location = new System.Drawing.Point(81, 57);
            this.picture_item_11.Name = "picture_item_11";
            this.picture_item_11.Size = new System.Drawing.Size(32, 32);
            this.picture_item_11.TabIndex = 10;
            this.picture_item_11.TabStop = false;
            this.picture_item_11.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_11.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_11.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_10
            // 
            this.picture_item_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_10.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_10.Location = new System.Drawing.Point(45, 57);
            this.picture_item_10.Name = "picture_item_10";
            this.picture_item_10.Size = new System.Drawing.Size(32, 32);
            this.picture_item_10.TabIndex = 9;
            this.picture_item_10.TabStop = false;
            this.picture_item_10.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_10.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_10.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_9
            // 
            this.picture_item_9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_9.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_9.Location = new System.Drawing.Point(9, 57);
            this.picture_item_9.Name = "picture_item_9";
            this.picture_item_9.Size = new System.Drawing.Size(32, 32);
            this.picture_item_9.TabIndex = 8;
            this.picture_item_9.TabStop = false;
            this.picture_item_9.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_9.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_9.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_8
            // 
            this.picture_item_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_8.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_8.Location = new System.Drawing.Point(260, 19);
            this.picture_item_8.Name = "picture_item_8";
            this.picture_item_8.Size = new System.Drawing.Size(32, 32);
            this.picture_item_8.TabIndex = 7;
            this.picture_item_8.TabStop = false;
            this.picture_item_8.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_8.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_8.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_7
            // 
            this.picture_item_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_7.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_7.Location = new System.Drawing.Point(224, 19);
            this.picture_item_7.Name = "picture_item_7";
            this.picture_item_7.Size = new System.Drawing.Size(32, 32);
            this.picture_item_7.TabIndex = 6;
            this.picture_item_7.TabStop = false;
            this.picture_item_7.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_7.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_7.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_6
            // 
            this.picture_item_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_6.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_6.Location = new System.Drawing.Point(188, 19);
            this.picture_item_6.Name = "picture_item_6";
            this.picture_item_6.Size = new System.Drawing.Size(32, 32);
            this.picture_item_6.TabIndex = 5;
            this.picture_item_6.TabStop = false;
            this.picture_item_6.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_6.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_6.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_5
            // 
            this.picture_item_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_5.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_5.Location = new System.Drawing.Point(152, 19);
            this.picture_item_5.Name = "picture_item_5";
            this.picture_item_5.Size = new System.Drawing.Size(32, 32);
            this.picture_item_5.TabIndex = 4;
            this.picture_item_5.TabStop = false;
            this.picture_item_5.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_5.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_5.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_4
            // 
            this.picture_item_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_4.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_4.Location = new System.Drawing.Point(117, 19);
            this.picture_item_4.Name = "picture_item_4";
            this.picture_item_4.Size = new System.Drawing.Size(32, 32);
            this.picture_item_4.TabIndex = 3;
            this.picture_item_4.TabStop = false;
            this.picture_item_4.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_4.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_4.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_3
            // 
            this.picture_item_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_3.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_3.Location = new System.Drawing.Point(81, 19);
            this.picture_item_3.Name = "picture_item_3";
            this.picture_item_3.Size = new System.Drawing.Size(32, 32);
            this.picture_item_3.TabIndex = 2;
            this.picture_item_3.TabStop = false;
            this.picture_item_3.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_3.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_3.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_2
            // 
            this.picture_item_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_2.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_2.Location = new System.Drawing.Point(45, 19);
            this.picture_item_2.Name = "picture_item_2";
            this.picture_item_2.Size = new System.Drawing.Size(32, 32);
            this.picture_item_2.TabIndex = 1;
            this.picture_item_2.TabStop = false;
            this.picture_item_2.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_2.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_2.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_1
            // 
            this.picture_item_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_item_1.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_1.Location = new System.Drawing.Point(9, 19);
            this.picture_item_1.Name = "picture_item_1";
            this.picture_item_1.Size = new System.Drawing.Size(32, 32);
            this.picture_item_1.TabIndex = 0;
            this.picture_item_1.TabStop = false;
            this.picture_item_1.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_1.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_1.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // craftTab
            // 
            this.craftTab.Controls.Add(this.groupBox11);
            this.craftTab.Controls.Add(this.groupBox10);
            this.craftTab.Controls.Add(this.groupBox8);
            this.craftTab.Controls.Add(this.groupBox7);
            this.craftTab.Location = new System.Drawing.Point(4, 22);
            this.craftTab.Name = "craftTab";
            this.craftTab.Padding = new System.Windows.Forms.Padding(3);
            this.craftTab.Size = new System.Drawing.Size(625, 545);
            this.craftTab.TabIndex = 3;
            this.craftTab.Text = "Craft Preview";
            this.craftTab.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBox24);
            this.groupBox11.Controls.Add(this.label33);
            this.groupBox11.Controls.Add(this.textBox22);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Controls.Add(this.textBox21);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.textBox18);
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Controls.Add(this.textBox15);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.textBox12);
            this.groupBox11.Controls.Add(this.label25);
            this.groupBox11.Controls.Add(this.textBox9);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.comboBox2);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.comboBox1);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.label8);
            this.groupBox11.Controls.Add(this.button12);
            this.groupBox11.Controls.Add(this.groupBox15);
            this.groupBox11.Controls.Add(this.groupBox14);
            this.groupBox11.Controls.Add(this.groupBox13);
            this.groupBox11.Controls.Add(this.groupBox12);
            this.groupBox11.Location = new System.Drawing.Point(313, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(309, 533);
            this.groupBox11.TabIndex = 50;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Item To Craft";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(103, 321);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(200, 20);
            this.textBox24.TabIndex = 91;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 324);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 13);
            this.label33.TabIndex = 92;
            this.label33.Text = "Num to make:";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(103, 484);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(44, 20);
            this.textBox22.TabIndex = 87;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 487);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(24, 13);
            this.label31.TabIndex = 88;
            this.label31.Text = "SP:";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(103, 456);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(44, 20);
            this.textBox21.TabIndex = 85;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 459);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(31, 13);
            this.label30.TabIndex = 86;
            this.label30.Text = "EXP:";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(103, 430);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(44, 20);
            this.textBox18.TabIndex = 83;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(9, 433);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 13);
            this.label27.TabIndex = 84;
            this.label27.Text = "Bind Type:";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(259, 433);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(44, 20);
            this.textBox15.TabIndex = 81;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(165, 436);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 13);
            this.label26.TabIndex = 82;
            this.label26.Text = "Craft Skill Level:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(259, 406);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(44, 20);
            this.textBox12.TabIndex = 79;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(165, 409);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 13);
            this.label25.TabIndex = 80;
            this.label25.Text = "Craft Skill Id:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(103, 402);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(44, 20);
            this.textBox9.TabIndex = 72;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 405);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 13);
            this.label24.TabIndex = 78;
            this.label24.Text = "Level:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(103, 375);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 77;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 378);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 76;
            this.label23.Text = "Craft Subtype:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 351);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 75;
            this.label20.Text = "Craft Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 348);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 74;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(74, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 73;
            this.label17.Text = "100%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Total Chance:";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(237, 505);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(69, 22);
            this.button12.TabIndex = 71;
            this.button12.Text = "Modify";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.modifyClickOtherCraftingItems);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox16);
            this.groupBox15.Controls.Add(this.textBox17);
            this.groupBox15.Controls.Add(this.pictureBox44);
            this.groupBox15.Controls.Add(this.label21);
            this.groupBox15.Controls.Add(this.label22);
            this.groupBox15.Location = new System.Drawing.Point(6, 222);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(297, 70);
            this.groupBox15.TabIndex = 70;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Item 4";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(97, 19);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(194, 20);
            this.textBox16.TabIndex = 53;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(97, 43);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(194, 20);
            this.textBox17.TabIndex = 66;
            this.textBox17.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // pictureBox44
            // 
            this.pictureBox44.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox44.Location = new System.Drawing.Point(6, 19);
            this.pictureBox44.Name = "pictureBox44";
            this.pictureBox44.Size = new System.Drawing.Size(32, 32);
            this.pictureBox44.TabIndex = 50;
            this.pictureBox44.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(44, 47);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 64;
            this.label21.Text = "Chance:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(44, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 63;
            this.label22.Text = "ID:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.textBox13);
            this.groupBox14.Controls.Add(this.textBox14);
            this.groupBox14.Controls.Add(this.pictureBox43);
            this.groupBox14.Controls.Add(this.label18);
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Location = new System.Drawing.Point(6, 152);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(297, 70);
            this.groupBox14.TabIndex = 69;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Item 3";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(97, 19);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(194, 20);
            this.textBox13.TabIndex = 53;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(97, 45);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(194, 20);
            this.textBox14.TabIndex = 66;
            this.textBox14.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // pictureBox43
            // 
            this.pictureBox43.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox43.Location = new System.Drawing.Point(6, 19);
            this.pictureBox43.Name = "pictureBox43";
            this.pictureBox43.Size = new System.Drawing.Size(32, 32);
            this.pictureBox43.TabIndex = 50;
            this.pictureBox43.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(44, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "Chance:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(44, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 63;
            this.label19.Text = "ID:";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.textBox10);
            this.groupBox13.Controls.Add(this.textBox11);
            this.groupBox13.Controls.Add(this.pictureBox42);
            this.groupBox13.Controls.Add(this.label15);
            this.groupBox13.Controls.Add(this.label16);
            this.groupBox13.Location = new System.Drawing.Point(6, 83);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(297, 70);
            this.groupBox13.TabIndex = 68;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Item 2";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(97, 19);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(194, 20);
            this.textBox10.TabIndex = 53;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(97, 45);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(194, 20);
            this.textBox11.TabIndex = 66;
            this.textBox11.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // pictureBox42
            // 
            this.pictureBox42.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox42.Location = new System.Drawing.Point(6, 19);
            this.pictureBox42.Name = "pictureBox42";
            this.pictureBox42.Size = new System.Drawing.Size(32, 32);
            this.pictureBox42.TabIndex = 50;
            this.pictureBox42.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 64;
            this.label15.Text = "Chance:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 63;
            this.label16.Text = "ID:";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox6);
            this.groupBox12.Controls.Add(this.textBox8);
            this.groupBox12.Controls.Add(this.pictureBox41);
            this.groupBox12.Controls.Add(this.label7);
            this.groupBox12.Controls.Add(this.label6);
            this.groupBox12.Location = new System.Drawing.Point(6, 14);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(297, 70);
            this.groupBox12.TabIndex = 67;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Item 1";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(97, 19);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(194, 20);
            this.textBox6.TabIndex = 53;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(97, 45);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(194, 20);
            this.textBox8.TabIndex = 66;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // pictureBox41
            // 
            this.pictureBox41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox41.Location = new System.Drawing.Point(6, 19);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(32, 32);
            this.pictureBox41.TabIndex = 50;
            this.pictureBox41.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Chance:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "ID:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox20);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Controls.Add(this.textBox19);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.button14);
            this.groupBox10.Controls.Add(this.button11);
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.textBox5);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_5);
            this.groupBox10.Controls.Add(this.textBox4);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_4);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_8);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_3);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_6);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_7);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_2);
            this.groupBox10.Controls.Add(this.pictureBox_craft_req_1);
            this.groupBox10.Location = new System.Drawing.Point(3, 327);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(301, 212);
            this.groupBox10.TabIndex = 49;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Required";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(100, 123);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(192, 20);
            this.textBox20.TabIndex = 87;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 127);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 13);
            this.label29.TabIndex = 88;
            this.label29.Text = "Duration:";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(100, 98);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(192, 20);
            this.textBox19.TabIndex = 85;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 102);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 86;
            this.label28.Text = "Price:";
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(223, 179);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(69, 22);
            this.button14.TabIndex = 71;
            this.button14.Text = "Add";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Visible = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(223, 178);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(69, 22);
            this.button11.TabIndex = 70;
            this.button11.Text = "Modify";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.ModifyRecipe);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Upgrade Count:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(100, 179);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(117, 20);
            this.textBox5.TabIndex = 69;
            // 
            // pictureBox_craft_req_5
            // 
            this.pictureBox_craft_req_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_5.Location = new System.Drawing.Point(36, 57);
            this.pictureBox_craft_req_5.Name = "pictureBox_craft_req_5";
            this.pictureBox_craft_req_5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_5.TabIndex = 53;
            this.pictureBox_craft_req_5.TabStop = false;
            this.pictureBox_craft_req_5.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(100, 152);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(192, 20);
            this.textBox4.TabIndex = 66;
            // 
            // pictureBox_craft_req_4
            // 
            this.pictureBox_craft_req_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_4.Location = new System.Drawing.Point(251, 19);
            this.pictureBox_craft_req_4.Name = "pictureBox_craft_req_4";
            this.pictureBox_craft_req_4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_4.TabIndex = 52;
            this.pictureBox_craft_req_4.TabStop = false;
            this.pictureBox_craft_req_4.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_8
            // 
            this.pictureBox_craft_req_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_8.Location = new System.Drawing.Point(251, 57);
            this.pictureBox_craft_req_8.Name = "pictureBox_craft_req_8";
            this.pictureBox_craft_req_8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_8.TabIndex = 56;
            this.pictureBox_craft_req_8.TabStop = false;
            this.pictureBox_craft_req_8.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_3
            // 
            this.pictureBox_craft_req_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_3.Location = new System.Drawing.Point(180, 19);
            this.pictureBox_craft_req_3.Name = "pictureBox_craft_req_3";
            this.pictureBox_craft_req_3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_3.TabIndex = 51;
            this.pictureBox_craft_req_3.TabStop = false;
            this.pictureBox_craft_req_3.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_6
            // 
            this.pictureBox_craft_req_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_6.Location = new System.Drawing.Point(109, 57);
            this.pictureBox_craft_req_6.Name = "pictureBox_craft_req_6";
            this.pictureBox_craft_req_6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_6.TabIndex = 54;
            this.pictureBox_craft_req_6.TabStop = false;
            this.pictureBox_craft_req_6.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_7
            // 
            this.pictureBox_craft_req_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_7.Location = new System.Drawing.Point(180, 57);
            this.pictureBox_craft_req_7.Name = "pictureBox_craft_req_7";
            this.pictureBox_craft_req_7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_7.TabIndex = 55;
            this.pictureBox_craft_req_7.TabStop = false;
            this.pictureBox_craft_req_7.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_2
            // 
            this.pictureBox_craft_req_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_2.Location = new System.Drawing.Point(109, 19);
            this.pictureBox_craft_req_2.Name = "pictureBox_craft_req_2";
            this.pictureBox_craft_req_2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_2.TabIndex = 50;
            this.pictureBox_craft_req_2.TabStop = false;
            this.pictureBox_craft_req_2.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_1
            // 
            this.pictureBox_craft_req_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_req_1.Location = new System.Drawing.Point(36, 19);
            this.pictureBox_craft_req_1.Name = "pictureBox_craft_req_1";
            this.pictureBox_craft_req_1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_1.TabIndex = 49;
            this.pictureBox_craft_req_1.TabStop = false;
            this.pictureBox_craft_req_1.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button13);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.textBox7);
            this.groupBox8.Controls.Add(this.pictureBox_craft_32);
            this.groupBox8.Controls.Add(this.pictureBox_craft_31);
            this.groupBox8.Controls.Add(this.pictureBox_craft_30);
            this.groupBox8.Controls.Add(this.pictureBox_craft_29);
            this.groupBox8.Controls.Add(this.pictureBox_craft_28);
            this.groupBox8.Controls.Add(this.pictureBox_craft_27);
            this.groupBox8.Controls.Add(this.pictureBox_craft_26);
            this.groupBox8.Controls.Add(this.pictureBox_craft_25);
            this.groupBox8.Controls.Add(this.pictureBox_craft_24);
            this.groupBox8.Controls.Add(this.pictureBox_craft_23);
            this.groupBox8.Controls.Add(this.pictureBox_craft_22);
            this.groupBox8.Controls.Add(this.pictureBox_craft_21);
            this.groupBox8.Controls.Add(this.pictureBox_craft_20);
            this.groupBox8.Controls.Add(this.pictureBox_craft_19);
            this.groupBox8.Controls.Add(this.pictureBox_craft_18);
            this.groupBox8.Controls.Add(this.pictureBox_craft_17);
            this.groupBox8.Controls.Add(this.pictureBox_craft_16);
            this.groupBox8.Controls.Add(this.pictureBox_craft_15);
            this.groupBox8.Controls.Add(this.pictureBox_craft_14);
            this.groupBox8.Controls.Add(this.pictureBox_craft_13);
            this.groupBox8.Controls.Add(this.pictureBox_craft_12);
            this.groupBox8.Controls.Add(this.pictureBox_craft_11);
            this.groupBox8.Controls.Add(this.pictureBox_craft_10);
            this.groupBox8.Controls.Add(this.pictureBox_craft_9);
            this.groupBox8.Controls.Add(this.pictureBox_craft_8);
            this.groupBox8.Controls.Add(this.pictureBox_craft_7);
            this.groupBox8.Controls.Add(this.pictureBox_craft_6);
            this.groupBox8.Controls.Add(this.pictureBox_craft_5);
            this.groupBox8.Controls.Add(this.pictureBox_craft_4);
            this.groupBox8.Controls.Add(this.pictureBox_craft_3);
            this.groupBox8.Controls.Add(this.pictureBox_craft_2);
            this.groupBox8.Controls.Add(this.pictureBox_craft_1);
            this.groupBox8.Location = new System.Drawing.Point(3, 112);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(301, 209);
            this.groupBox8.TabIndex = 48;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Items";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(223, 176);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(69, 22);
            this.button13.TabIndex = 73;
            this.button13.Text = "Add";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "Recipe Id:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(74, 177);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(143, 20);
            this.textBox7.TabIndex = 72;
            // 
            // pictureBox_craft_32
            // 
            this.pictureBox_craft_32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_32.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_32.Location = new System.Drawing.Point(260, 133);
            this.pictureBox_craft_32.Name = "pictureBox_craft_32";
            this.pictureBox_craft_32.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_32.TabIndex = 31;
            this.pictureBox_craft_32.TabStop = false;
            this.pictureBox_craft_32.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_32.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_32.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // contextMenuStripproduce
            // 
            this.contextMenuStripproduce.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator4,
            this.toolStripMenuItem2});
            this.contextMenuStripproduce.Name = "contextMenuStripSalePreview";
            this.contextMenuStripproduce.Size = new System.Drawing.Size(133, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem1.Text = "Move Here";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.moveCraftingItem);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(129, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.deleteCraftItem);
            // 
            // pictureBox_craft_31
            // 
            this.pictureBox_craft_31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_31.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_31.Location = new System.Drawing.Point(224, 133);
            this.pictureBox_craft_31.Name = "pictureBox_craft_31";
            this.pictureBox_craft_31.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_31.TabIndex = 30;
            this.pictureBox_craft_31.TabStop = false;
            this.pictureBox_craft_31.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_31.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_31.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_30
            // 
            this.pictureBox_craft_30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_30.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_30.Location = new System.Drawing.Point(188, 133);
            this.pictureBox_craft_30.Name = "pictureBox_craft_30";
            this.pictureBox_craft_30.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_30.TabIndex = 29;
            this.pictureBox_craft_30.TabStop = false;
            this.pictureBox_craft_30.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_30.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_30.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_29
            // 
            this.pictureBox_craft_29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_29.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_29.Location = new System.Drawing.Point(152, 133);
            this.pictureBox_craft_29.Name = "pictureBox_craft_29";
            this.pictureBox_craft_29.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_29.TabIndex = 28;
            this.pictureBox_craft_29.TabStop = false;
            this.pictureBox_craft_29.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_29.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_29.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_28
            // 
            this.pictureBox_craft_28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_28.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_28.Location = new System.Drawing.Point(117, 133);
            this.pictureBox_craft_28.Name = "pictureBox_craft_28";
            this.pictureBox_craft_28.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_28.TabIndex = 27;
            this.pictureBox_craft_28.TabStop = false;
            this.pictureBox_craft_28.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_28.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_28.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_27
            // 
            this.pictureBox_craft_27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_27.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_27.Location = new System.Drawing.Point(81, 133);
            this.pictureBox_craft_27.Name = "pictureBox_craft_27";
            this.pictureBox_craft_27.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_27.TabIndex = 26;
            this.pictureBox_craft_27.TabStop = false;
            this.pictureBox_craft_27.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_27.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_27.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_26
            // 
            this.pictureBox_craft_26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_26.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_26.Location = new System.Drawing.Point(45, 133);
            this.pictureBox_craft_26.Name = "pictureBox_craft_26";
            this.pictureBox_craft_26.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_26.TabIndex = 25;
            this.pictureBox_craft_26.TabStop = false;
            this.pictureBox_craft_26.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_26.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_26.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_25
            // 
            this.pictureBox_craft_25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_25.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_25.Location = new System.Drawing.Point(9, 133);
            this.pictureBox_craft_25.Name = "pictureBox_craft_25";
            this.pictureBox_craft_25.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_25.TabIndex = 24;
            this.pictureBox_craft_25.TabStop = false;
            this.pictureBox_craft_25.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_25.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_25.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_24
            // 
            this.pictureBox_craft_24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_24.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_24.Location = new System.Drawing.Point(260, 95);
            this.pictureBox_craft_24.Name = "pictureBox_craft_24";
            this.pictureBox_craft_24.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_24.TabIndex = 23;
            this.pictureBox_craft_24.TabStop = false;
            this.pictureBox_craft_24.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_24.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_24.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_23
            // 
            this.pictureBox_craft_23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_23.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_23.Location = new System.Drawing.Point(224, 95);
            this.pictureBox_craft_23.Name = "pictureBox_craft_23";
            this.pictureBox_craft_23.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_23.TabIndex = 22;
            this.pictureBox_craft_23.TabStop = false;
            this.pictureBox_craft_23.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_23.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_23.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_22
            // 
            this.pictureBox_craft_22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_22.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_22.Location = new System.Drawing.Point(188, 95);
            this.pictureBox_craft_22.Name = "pictureBox_craft_22";
            this.pictureBox_craft_22.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_22.TabIndex = 21;
            this.pictureBox_craft_22.TabStop = false;
            this.pictureBox_craft_22.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_22.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_22.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_21
            // 
            this.pictureBox_craft_21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_21.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_21.Location = new System.Drawing.Point(152, 95);
            this.pictureBox_craft_21.Name = "pictureBox_craft_21";
            this.pictureBox_craft_21.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_21.TabIndex = 20;
            this.pictureBox_craft_21.TabStop = false;
            this.pictureBox_craft_21.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_21.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_21.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_20
            // 
            this.pictureBox_craft_20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_20.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_20.Location = new System.Drawing.Point(117, 95);
            this.pictureBox_craft_20.Name = "pictureBox_craft_20";
            this.pictureBox_craft_20.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_20.TabIndex = 19;
            this.pictureBox_craft_20.TabStop = false;
            this.pictureBox_craft_20.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_20.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_20.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_19
            // 
            this.pictureBox_craft_19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_19.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_19.Location = new System.Drawing.Point(81, 95);
            this.pictureBox_craft_19.Name = "pictureBox_craft_19";
            this.pictureBox_craft_19.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_19.TabIndex = 18;
            this.pictureBox_craft_19.TabStop = false;
            this.pictureBox_craft_19.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_19.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_19.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_18
            // 
            this.pictureBox_craft_18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_18.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_18.Location = new System.Drawing.Point(45, 95);
            this.pictureBox_craft_18.Name = "pictureBox_craft_18";
            this.pictureBox_craft_18.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_18.TabIndex = 17;
            this.pictureBox_craft_18.TabStop = false;
            this.pictureBox_craft_18.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_18.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_18.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_17
            // 
            this.pictureBox_craft_17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_17.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_17.Location = new System.Drawing.Point(9, 95);
            this.pictureBox_craft_17.Name = "pictureBox_craft_17";
            this.pictureBox_craft_17.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_17.TabIndex = 16;
            this.pictureBox_craft_17.TabStop = false;
            this.pictureBox_craft_17.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_17.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_17.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_16
            // 
            this.pictureBox_craft_16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_16.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_16.Location = new System.Drawing.Point(260, 57);
            this.pictureBox_craft_16.Name = "pictureBox_craft_16";
            this.pictureBox_craft_16.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_16.TabIndex = 15;
            this.pictureBox_craft_16.TabStop = false;
            this.pictureBox_craft_16.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_16.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_16.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_15
            // 
            this.pictureBox_craft_15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_15.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_15.Location = new System.Drawing.Point(224, 57);
            this.pictureBox_craft_15.Name = "pictureBox_craft_15";
            this.pictureBox_craft_15.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_15.TabIndex = 14;
            this.pictureBox_craft_15.TabStop = false;
            this.pictureBox_craft_15.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_15.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_15.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_14
            // 
            this.pictureBox_craft_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_14.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_14.Location = new System.Drawing.Point(188, 57);
            this.pictureBox_craft_14.Name = "pictureBox_craft_14";
            this.pictureBox_craft_14.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_14.TabIndex = 13;
            this.pictureBox_craft_14.TabStop = false;
            this.pictureBox_craft_14.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_14.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_14.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_13
            // 
            this.pictureBox_craft_13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_13.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_13.Location = new System.Drawing.Point(152, 57);
            this.pictureBox_craft_13.Name = "pictureBox_craft_13";
            this.pictureBox_craft_13.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_13.TabIndex = 12;
            this.pictureBox_craft_13.TabStop = false;
            this.pictureBox_craft_13.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_13.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_13.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_12
            // 
            this.pictureBox_craft_12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_12.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_12.Location = new System.Drawing.Point(117, 57);
            this.pictureBox_craft_12.Name = "pictureBox_craft_12";
            this.pictureBox_craft_12.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_12.TabIndex = 11;
            this.pictureBox_craft_12.TabStop = false;
            this.pictureBox_craft_12.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_12.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_12.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_11
            // 
            this.pictureBox_craft_11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_11.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_11.Location = new System.Drawing.Point(81, 57);
            this.pictureBox_craft_11.Name = "pictureBox_craft_11";
            this.pictureBox_craft_11.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_11.TabIndex = 10;
            this.pictureBox_craft_11.TabStop = false;
            this.pictureBox_craft_11.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_11.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_11.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_10
            // 
            this.pictureBox_craft_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_10.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_10.Location = new System.Drawing.Point(45, 57);
            this.pictureBox_craft_10.Name = "pictureBox_craft_10";
            this.pictureBox_craft_10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_10.TabIndex = 9;
            this.pictureBox_craft_10.TabStop = false;
            this.pictureBox_craft_10.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_10.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_10.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_9
            // 
            this.pictureBox_craft_9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_9.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_9.Location = new System.Drawing.Point(9, 57);
            this.pictureBox_craft_9.Name = "pictureBox_craft_9";
            this.pictureBox_craft_9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_9.TabIndex = 8;
            this.pictureBox_craft_9.TabStop = false;
            this.pictureBox_craft_9.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_9.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_9.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_8
            // 
            this.pictureBox_craft_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_8.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_8.Location = new System.Drawing.Point(260, 19);
            this.pictureBox_craft_8.Name = "pictureBox_craft_8";
            this.pictureBox_craft_8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_8.TabIndex = 7;
            this.pictureBox_craft_8.TabStop = false;
            this.pictureBox_craft_8.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_8.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_8.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_7
            // 
            this.pictureBox_craft_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_7.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_7.Location = new System.Drawing.Point(224, 19);
            this.pictureBox_craft_7.Name = "pictureBox_craft_7";
            this.pictureBox_craft_7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_7.TabIndex = 6;
            this.pictureBox_craft_7.TabStop = false;
            this.pictureBox_craft_7.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_7.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_7.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_6
            // 
            this.pictureBox_craft_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_6.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_6.Location = new System.Drawing.Point(188, 19);
            this.pictureBox_craft_6.Name = "pictureBox_craft_6";
            this.pictureBox_craft_6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_6.TabIndex = 5;
            this.pictureBox_craft_6.TabStop = false;
            this.pictureBox_craft_6.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_6.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_6.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_5
            // 
            this.pictureBox_craft_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_5.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_5.Location = new System.Drawing.Point(152, 19);
            this.pictureBox_craft_5.Name = "pictureBox_craft_5";
            this.pictureBox_craft_5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_5.TabIndex = 4;
            this.pictureBox_craft_5.TabStop = false;
            this.pictureBox_craft_5.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_5.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_5.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_4
            // 
            this.pictureBox_craft_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_4.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_4.Location = new System.Drawing.Point(117, 19);
            this.pictureBox_craft_4.Name = "pictureBox_craft_4";
            this.pictureBox_craft_4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_4.TabIndex = 3;
            this.pictureBox_craft_4.TabStop = false;
            this.pictureBox_craft_4.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_4.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_4.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_3
            // 
            this.pictureBox_craft_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_3.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_3.Location = new System.Drawing.Point(81, 19);
            this.pictureBox_craft_3.Name = "pictureBox_craft_3";
            this.pictureBox_craft_3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_3.TabIndex = 2;
            this.pictureBox_craft_3.TabStop = false;
            this.pictureBox_craft_3.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_3.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_3.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_2
            // 
            this.pictureBox_craft_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_2.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_2.Location = new System.Drawing.Point(45, 19);
            this.pictureBox_craft_2.Name = "pictureBox_craft_2";
            this.pictureBox_craft_2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_2.TabIndex = 1;
            this.pictureBox_craft_2.TabStop = false;
            this.pictureBox_craft_2.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_2.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_2.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_1
            // 
            this.pictureBox_craft_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_craft_1.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_1.Location = new System.Drawing.Point(9, 19);
            this.pictureBox_craft_1.Name = "pictureBox_craft_1";
            this.pictureBox_craft_1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_1.TabIndex = 0;
            this.pictureBox_craft_1.TabStop = false;
            this.pictureBox_craft_1.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_1.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_1.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.tab_craftbtn_1);
            this.groupBox7.Controls.Add(this.tab_craftbtn_5);
            this.groupBox7.Controls.Add(this.tab_craftbtn_2);
            this.groupBox7.Controls.Add(this.tab_craftbtn_8);
            this.groupBox7.Controls.Add(this.tab_craftbtn_3);
            this.groupBox7.Controls.Add(this.tab_craftbtn_7);
            this.groupBox7.Controls.Add(this.tab_craftbtn_4);
            this.groupBox7.Controls.Add(this.tab_craftbtn_6);
            this.groupBox7.Location = new System.Drawing.Point(3, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(301, 100);
            this.groupBox7.TabIndex = 47;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Pages";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(228, 69);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(65, 22);
            this.button9.TabIndex = 50;
            this.button9.Text = "Rename";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.renameCraftTab);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(7, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 20);
            this.textBox3.TabIndex = 50;
            // 
            // tab_craftbtn_1
            // 
            this.tab_craftbtn_1.BackColor = System.Drawing.Color.Black;
            this.tab_craftbtn_1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_1.ForeColor = System.Drawing.Color.White;
            this.tab_craftbtn_1.Location = new System.Drawing.Point(6, 19);
            this.tab_craftbtn_1.Name = "tab_craftbtn_1";
            this.tab_craftbtn_1.Size = new System.Drawing.Size(69, 20);
            this.tab_craftbtn_1.TabIndex = 37;
            this.tab_craftbtn_1.Text = "Page 1";
            this.tab_craftbtn_1.UseVisualStyleBackColor = false;
            this.tab_craftbtn_1.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_5
            // 
            this.tab_craftbtn_5.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_5.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_5.Location = new System.Drawing.Point(7, 45);
            this.tab_craftbtn_5.Name = "tab_craftbtn_5";
            this.tab_craftbtn_5.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_5.TabIndex = 45;
            this.tab_craftbtn_5.Text = "Page 4";
            this.tab_craftbtn_5.UseVisualStyleBackColor = false;
            this.tab_craftbtn_5.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_2
            // 
            this.tab_craftbtn_2.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_2.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_2.Location = new System.Drawing.Point(82, 19);
            this.tab_craftbtn_2.Name = "tab_craftbtn_2";
            this.tab_craftbtn_2.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_2.TabIndex = 38;
            this.tab_craftbtn_2.Text = "Page 2";
            this.tab_craftbtn_2.UseVisualStyleBackColor = false;
            this.tab_craftbtn_2.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_8
            // 
            this.tab_craftbtn_8.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_8.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_8.Location = new System.Drawing.Point(225, 45);
            this.tab_craftbtn_8.Name = "tab_craftbtn_8";
            this.tab_craftbtn_8.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_8.TabIndex = 44;
            this.tab_craftbtn_8.Text = "Page 7";
            this.tab_craftbtn_8.UseVisualStyleBackColor = false;
            this.tab_craftbtn_8.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_3
            // 
            this.tab_craftbtn_3.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_3.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_3.Location = new System.Drawing.Point(153, 19);
            this.tab_craftbtn_3.Name = "tab_craftbtn_3";
            this.tab_craftbtn_3.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_3.TabIndex = 39;
            this.tab_craftbtn_3.Text = "Page 3";
            this.tab_craftbtn_3.UseVisualStyleBackColor = false;
            this.tab_craftbtn_3.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_7
            // 
            this.tab_craftbtn_7.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_7.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_7.Location = new System.Drawing.Point(153, 45);
            this.tab_craftbtn_7.Name = "tab_craftbtn_7";
            this.tab_craftbtn_7.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_7.TabIndex = 43;
            this.tab_craftbtn_7.Text = "Page 6";
            this.tab_craftbtn_7.UseVisualStyleBackColor = false;
            this.tab_craftbtn_7.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_4
            // 
            this.tab_craftbtn_4.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_4.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_4.Location = new System.Drawing.Point(225, 19);
            this.tab_craftbtn_4.Name = "tab_craftbtn_4";
            this.tab_craftbtn_4.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_4.TabIndex = 40;
            this.tab_craftbtn_4.Text = "Page 4";
            this.tab_craftbtn_4.UseVisualStyleBackColor = false;
            this.tab_craftbtn_4.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_6
            // 
            this.tab_craftbtn_6.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_6.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_6.Location = new System.Drawing.Point(82, 45);
            this.tab_craftbtn_6.Name = "tab_craftbtn_6";
            this.tab_craftbtn_6.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_6.TabIndex = 42;
            this.tab_craftbtn_6.Text = "Page 5";
            this.tab_craftbtn_6.UseVisualStyleBackColor = false;
            this.tab_craftbtn_6.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(625, 545);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.versionToBox);
            this.groupBox6.Controls.Add(this.versionFromBox);
            this.groupBox6.Controls.Add(this.EnableDevMenu);
            this.groupBox6.Location = new System.Drawing.Point(7, 398);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(613, 141);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Elements Convert";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkGreen;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(469, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 22);
            this.button3.TabIndex = 21;
            this.button3.Text = "Save Configs";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.saveExportConfigs);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Version To:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Version From:";
            // 
            // versionToBox
            // 
            this.versionToBox.Location = new System.Drawing.Point(129, 55);
            this.versionToBox.Name = "versionToBox";
            this.versionToBox.Size = new System.Drawing.Size(100, 20);
            this.versionToBox.TabIndex = 2;
            this.versionToBox.Text = "145";
            // 
            // versionFromBox
            // 
            this.versionFromBox.Location = new System.Drawing.Point(6, 55);
            this.versionFromBox.Name = "versionFromBox";
            this.versionFromBox.Size = new System.Drawing.Size(100, 20);
            this.versionFromBox.TabIndex = 2;
            this.versionFromBox.Text = "101";
            // 
            // EnableDevMenu
            // 
            this.EnableDevMenu.AutoSize = true;
            this.EnableDevMenu.Location = new System.Drawing.Point(6, 19);
            this.EnableDevMenu.Name = "EnableDevMenu";
            this.EnableDevMenu.Size = new System.Drawing.Size(122, 17);
            this.EnableDevMenu.TabIndex = 1;
            this.EnableDevMenu.Text = "Enable Config Menu";
            this.EnableDevMenu.UseVisualStyleBackColor = true;
            this.EnableDevMenu.CheckedChanged += new System.EventHandler(this.EnableDevMenu_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.groupBox16);
            this.groupBox5.Controls.Add(this.exportClipboardWithRules);
            this.groupBox5.Location = new System.Drawing.Point(7, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(612, 297);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Developer";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(100, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 9);
            this.label2.TabIndex = 33;
            this.label2.Text = "By disabeling this you will gain faster operations but you will lose the sight of" +
    " changed/added items.";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.Color.Green;
            this.checkBox3.Location = new System.Drawing.Point(6, 274);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox3.Size = new System.Drawing.Size(89, 17);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "Live cache";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.nextautoIdlabelmax);
            this.groupBox16.Controls.Add(this.label34);
            this.groupBox16.Controls.Add(this.label32);
            this.groupBox16.Controls.Add(this.autonewIdCTRLV);
            this.groupBox16.Controls.Add(this.button7);
            this.groupBox16.Controls.Add(this.nextautoIdlabel);
            this.groupBox16.Controls.Add(this.autonewId);
            this.groupBox16.Location = new System.Drawing.Point(10, 19);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(317, 124);
            this.groupBox16.TabIndex = 26;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Auto Element Id";
            // 
            // nextautoIdlabelmax
            // 
            this.nextautoIdlabelmax.Location = new System.Drawing.Point(238, 64);
            this.nextautoIdlabelmax.Name = "nextautoIdlabelmax";
            this.nextautoIdlabelmax.Size = new System.Drawing.Size(69, 20);
            this.nextautoIdlabelmax.TabIndex = 32;
            this.nextautoIdlabelmax.Text = "60000";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(208, 67);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(25, 13);
            this.label34.TabIndex = 31;
            this.label34.Text = "and";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 67);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(122, 13);
            this.label32.TabIndex = 30;
            this.label32.Text = "Search free Id Between:";
            // 
            // autonewIdCTRLV
            // 
            this.autonewIdCTRLV.AutoSize = true;
            this.autonewIdCTRLV.Location = new System.Drawing.Point(7, 37);
            this.autonewIdCTRLV.Name = "autonewIdCTRLV";
            this.autonewIdCTRLV.Size = new System.Drawing.Size(140, 17);
            this.autonewIdCTRLV.TabIndex = 26;
            this.autonewIdCTRLV.Text = "Auto assign on CTRL+V";
            this.autonewIdCTRLV.UseVisualStyleBackColor = true;
            this.autonewIdCTRLV.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkGreen;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(6, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(301, 28);
            this.button7.TabIndex = 24;
            this.button7.Text = "Search New free Id";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // nextautoIdlabel
            // 
            this.nextautoIdlabel.Location = new System.Drawing.Point(133, 64);
            this.nextautoIdlabel.Name = "nextautoIdlabel";
            this.nextautoIdlabel.Size = new System.Drawing.Size(69, 20);
            this.nextautoIdlabel.TabIndex = 25;
            this.nextautoIdlabel.Text = "30000";
            // 
            // autonewId
            // 
            this.autonewId.AutoSize = true;
            this.autonewId.Location = new System.Drawing.Point(7, 17);
            this.autonewId.Name = "autonewId";
            this.autonewId.Size = new System.Drawing.Size(147, 17);
            this.autonewId.TabIndex = 22;
            this.autonewId.Text = "Auto assign on File Import";
            this.autonewId.UseVisualStyleBackColor = true;
            this.autonewId.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // exportClipboardWithRules
            // 
            this.exportClipboardWithRules.AutoSize = true;
            this.exportClipboardWithRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportClipboardWithRules.ForeColor = System.Drawing.Color.Red;
            this.exportClipboardWithRules.Location = new System.Drawing.Point(476, 19);
            this.exportClipboardWithRules.Name = "exportClipboardWithRules";
            this.exportClipboardWithRules.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exportClipboardWithRules.Size = new System.Drawing.Size(128, 17);
            this.exportClipboardWithRules.TabIndex = 1;
            this.exportClipboardWithRules.Text = "Export With Rules";
            this.exportClipboardWithRules.UseVisualStyleBackColor = true;
            this.exportClipboardWithRules.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.autoSaveCache);
            this.groupBox3.Controls.Add(this.autoOpenCache);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(7, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 86);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cache";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Peru;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(7, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 22);
            this.button4.TabIndex = 21;
            this.button4.Text = "Reload Cache";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.reloadSettings);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGreen;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(133, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 22);
            this.button2.TabIndex = 20;
            this.button2.Text = "Save Cache";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.saveCache);
            // 
            // autoSaveCache
            // 
            this.autoSaveCache.AutoSize = true;
            this.autoSaveCache.Location = new System.Drawing.Point(8, 35);
            this.autoSaveCache.Name = "autoSaveCache";
            this.autoSaveCache.Size = new System.Drawing.Size(110, 17);
            this.autoSaveCache.TabIndex = 19;
            this.autoSaveCache.Text = "Auto Save Cache";
            this.autoSaveCache.UseVisualStyleBackColor = true;
            this.autoSaveCache.CheckedChanged += new System.EventHandler(this.autoSaveCache_CheckedChanged);
            // 
            // autoOpenCache
            // 
            this.autoOpenCache.AutoSize = true;
            this.autoOpenCache.Location = new System.Drawing.Point(8, 14);
            this.autoOpenCache.Name = "autoOpenCache";
            this.autoOpenCache.Size = new System.Drawing.Size(111, 17);
            this.autoOpenCache.TabIndex = 18;
            this.autoOpenCache.Text = "Auto Open Cache";
            this.autoOpenCache.UseVisualStyleBackColor = true;
            this.autoOpenCache.CheckedChanged += new System.EventHandler(this.autoOpenCache_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(490, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 22);
            this.button1.TabIndex = 12;
            this.button1.Text = "Delete Cache";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox18);
            this.tabPage4.Controls.Add(this.groupBox17);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(625, 545);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Advanced Search";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.checkBox2);
            this.groupBox18.Controls.Add(this.button16);
            this.groupBox18.Controls.Add(this.label37);
            this.groupBox18.Controls.Add(this.textBox25);
            this.groupBox18.Controls.Add(this.label38);
            this.groupBox18.Controls.Add(this.comboBox3);
            this.groupBox18.Location = new System.Drawing.Point(10, 109);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(609, 100);
            this.groupBox18.TabIndex = 33;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Fixed Search";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(10, 74);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(94, 17);
            this.checkBox2.TabIndex = 37;
            this.checkBox2.Text = "Case-sensitive";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Crimson;
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.Location = new System.Drawing.Point(111, 72);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(495, 22);
            this.button16.TabIndex = 36;
            this.button16.TabStop = false;
            this.button16.Text = "Search";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 49);
            this.label37.Margin = new System.Windows.Forms.Padding(0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(99, 13);
            this.label37.TabIndex = 35;
            this.label37.Text = "Value to search for:";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(111, 46);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(495, 20);
            this.textBox25.TabIndex = 34;
            this.textBox25.TabStop = false;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(9, 22);
            this.label38.Margin = new System.Windows.Forms.Padding(0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(94, 13);
            this.label38.TabIndex = 33;
            this.label38.Text = "Row to search for:";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Task Id",
            "Monster Drop",
            "Mine Drop",
            "NPC Crafting Service",
            "NPC Sale Service",
            "Skill Service"});
            this.comboBox3.Location = new System.Drawing.Point(111, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(495, 21);
            this.comboBox3.TabIndex = 32;
            this.comboBox3.TabStop = false;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.checkBox5);
            this.groupBox17.Controls.Add(this.checkBox4);
            this.groupBox17.Controls.Add(this.button15);
            this.groupBox17.Controls.Add(this.label36);
            this.groupBox17.Controls.Add(this.textBox23);
            this.groupBox17.Controls.Add(this.label35);
            this.groupBox17.Controls.Add(this.button5);
            this.groupBox17.Controls.Add(this.selecter_rowscheckbox);
            this.groupBox17.Location = new System.Drawing.Point(10, 7);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(609, 100);
            this.groupBox17.TabIndex = 32;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Dynamic Search Options";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(108, 74);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(67, 17);
            this.checkBox5.TabIndex = 39;
            this.checkBox5.Text = "All Fields";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(8, 73);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(81, 17);
            this.checkBox4.TabIndex = 38;
            this.checkBox4.Text = "Only this list";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Indigo;
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(482, 72);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(121, 22);
            this.button15.TabIndex = 33;
            this.button15.TabStop = false;
            this.button15.Text = "Search all values";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 51);
            this.label36.Margin = new System.Windows.Forms.Padding(0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(99, 13);
            this.label36.TabIndex = 31;
            this.label36.Text = "Value to search for:";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(108, 48);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(495, 20);
            this.textBox23.TabIndex = 30;
            this.textBox23.TabStop = false;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 24);
            this.label35.Margin = new System.Windows.Forms.Padding(0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(94, 13);
            this.label35.TabIndex = 29;
            this.label35.Text = "Row to search for:";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.MediumOrchid;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(238, 72);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(232, 22);
            this.button5.TabIndex = 31;
            this.button5.TabStop = false;
            this.button5.Text = "List All Rows Values in Selected List";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.listSameRowsIDValues);
            // 
            // selecter_rowscheckbox
            // 
            this.selecter_rowscheckbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selecter_rowscheckbox.FormattingEnabled = true;
            this.selecter_rowscheckbox.Location = new System.Drawing.Point(108, 21);
            this.selecter_rowscheckbox.Name = "selecter_rowscheckbox";
            this.selecter_rowscheckbox.Size = new System.Drawing.Size(495, 21);
            this.selecter_rowscheckbox.TabIndex = 23;
            this.selecter_rowscheckbox.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column6,
            this.dataGridViewTextBoxColumn4,
            this.Column4,
            this.Column5,
            this.Column7});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(622, 324);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Search Var";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 21.84429F;
            this.Column6.HeaderText = "Item Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 25.2093F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 21.84429F;
            this.Column4.HeaderText = "List Index";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 21.84429F;
            this.Column5.HeaderText = "Element Index";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 23.45023F;
            this.Column7.HeaderText = "Row Index";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllItemNamesToClipboardToolStripMenuItem,
            this.copyAllItemNamesToClipboardToolStripMenuItem1,
            this.toolStripSeparator7,
            this.copySelectedItemsToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(253, 76);
            // 
            // copyAllItemNamesToClipboardToolStripMenuItem
            // 
            this.copyAllItemNamesToClipboardToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.copyAllItemNamesToClipboardToolStripMenuItem.Name = "copyAllItemNamesToClipboardToolStripMenuItem";
            this.copyAllItemNamesToClipboardToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.copyAllItemNamesToClipboardToolStripMenuItem.Text = "Copy all Names to clipboard";
            this.copyAllItemNamesToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyAllItemNamesToClipboardToolStripMenuItem_Click);
            // 
            // copyAllItemNamesToClipboardToolStripMenuItem1
            // 
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.e115_Settings_100;
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Name = "copyAllItemNamesToClipboardToolStripMenuItem1";
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Size = new System.Drawing.Size(252, 22);
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Text = "Copy all Values to clipboard";
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Click += new System.EventHandler(this.copyAllItemNamesToClipboardToolStripMenuItem1_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(249, 6);
            // 
            // copySelectedItemsToClipboardToolStripMenuItem
            // 
            this.copySelectedItemsToClipboardToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Atachment;
            this.copySelectedItemsToClipboardToolStripMenuItem.Name = "copySelectedItemsToClipboardToolStripMenuItem";
            this.copySelectedItemsToClipboardToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.copySelectedItemsToClipboardToolStripMenuItem.Text = "Copy Selected Items To Clipboard";
            this.copySelectedItemsToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copySelectedItemsToClipboardToolStripMenuItem_Click);
            // 
            // developerMenuitems
            // 
            this.developerMenuitems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeValueToolStripMenuItem,
            this.addRowHereToolStripMenuItem});
            this.developerMenuitems.Name = "developerMenuitems";
            this.developerMenuitems.Size = new System.Drawing.Size(133, 48);
            // 
            // changeValueToolStripMenuItem
            // 
            this.changeValueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.changeToolStripMenuItem1});
            this.changeValueToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.bullet_toggle_plus;
            this.changeValueToolStripMenuItem.Name = "changeValueToolStripMenuItem";
            this.changeValueToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.changeValueToolStripMenuItem.Text = "Add Row";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "0";
            // 
            // changeToolStripMenuItem1
            // 
            this.changeToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.changeToolStripMenuItem1.Name = "changeToolStripMenuItem1";
            this.changeToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.changeToolStripMenuItem1.Text = "Add";
            this.changeToolStripMenuItem1.Click += new System.EventHandler(this.changeToolStripMenuItem1_Click);
            // 
            // addRowHereToolStripMenuItem
            // 
            this.addRowHereToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2,
            this.toolStripTextBox3,
            this.addToolStripMenuItem1});
            this.addRowHereToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.bullet_toggle_plus;
            this.addRowHereToolStripMenuItem.Name = "addRowHereToolStripMenuItem";
            this.addRowHereToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addRowHereToolStripMenuItem.Text = "Add Range";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Tag = "";
            this.toolStripTextBox2.Text = "1";
            this.toolStripTextBox2.ToolTipText = "Row Count";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox3.Text = "0";
            this.toolStripTextBox3.ToolTipText = "Value";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addRowHereToolStripMenuItem_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 30F;
            this.dataGridViewImageColumn1.HeaderText = "Img";
            this.dataGridViewImageColumn1.Image = global::PWDataEditorPaied.Properties.Resources.blank;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.MinimumWidth = 30;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.progres);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(625, 76);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(504, 57);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(115, 13);
            this.linkLabel1.TabIndex = 27;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Made by Games Shark";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.copyrightLink);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.CausesValidation = false;
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(293, 605);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(633, 102);
            this.tabControl2.TabIndex = 32;
            this.tabControl2.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.textBox_newValue);
            this.tabPage3.Controls.Add(this.replaceSelected);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.textBox_oldValue);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(625, 76);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Bulk Row Editor";
            this.tabPage3.ToolTipText = "Replaces the selected items based on your criteria!";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 53);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(354, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "You can use * to match any STRING value or string value to be replaced.";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Note:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(118, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "WHERE";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "equals value:";
            // 
            // textBox_newValue
            // 
            this.textBox_newValue.Location = new System.Drawing.Point(382, 12);
            this.textBox_newValue.Name = "textBox_newValue";
            this.textBox_newValue.Size = new System.Drawing.Size(137, 20);
            this.textBox_newValue.TabIndex = 24;
            this.textBox_newValue.TabStop = false;
            this.textBox_newValue.Text = "0.100";
            // 
            // replaceSelected
            // 
            this.replaceSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.replaceSelected.FormattingEnabled = true;
            this.replaceSelected.Items.AddRange(new object[] {
            "Replace",
            "Multiply",
            "Divide",
            "Add",
            "Extract"});
            this.replaceSelected.Location = new System.Drawing.Point(10, 11);
            this.replaceSelected.Name = "replaceSelected";
            this.replaceSelected.Size = new System.Drawing.Size(105, 21);
            this.replaceSelected.TabIndex = 22;
            this.replaceSelected.TabStop = false;
            this.replaceSelected.SelectedIndexChanged += new System.EventHandler(this.replaceSelected_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Maroon;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(525, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 22);
            this.button6.TabIndex = 21;
            this.button6.TabStop = false;
            this.button6.Text = "Do it";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.replaceInList);
            // 
            // textBox_oldValue
            // 
            this.textBox_oldValue.Location = new System.Drawing.Point(167, 12);
            this.textBox_oldValue.Name = "textBox_oldValue";
            this.textBox_oldValue.Size = new System.Drawing.Size(131, 20);
            this.textBox_oldValue.TabIndex = 20;
            this.textBox_oldValue.TabStop = false;
            this.textBox_oldValue.Text = "*";
            // 
            // changeToolStripMenuItem2
            // 
            this.changeToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.document_index;
            this.changeToolStripMenuItem2.Name = "changeToolStripMenuItem2";
            this.changeToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.changeToolStripMenuItem2.Text = "Change";
            this.changeToolStripMenuItem2.Click += new System.EventHandler(this.changeToolStripMenuItem2_Click);
            // 
            // classmaskMenu
            // 
            this.classmaskMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem2});
            this.classmaskMenu.Name = "classmaskMenu";
            this.classmaskMenu.Size = new System.Drawing.Size(116, 26);
            // 
            // ElementsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 709);
            this.Controls.Add(this.elementIntoTab);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.version_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listbox_description);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ElementsEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Element Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElementsEditor_FormClosing);
            this.contextMenuStrip2.ResumeLayout(false);
            this.listbox_items_menu.ResumeLayout(false);
            this.listbox_description.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.row_editor_context.ResumeLayout(false);
            this.elementIntoTab.ResumeLayout(false);
            this.Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).EndInit();
            this.SaleTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_32)).EndInit();
            this.contextMenuStripSalePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_item_1)).EndInit();
            this.craftTab.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_req_1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_32)).EndInit();
            this.contextMenuStripproduce.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_craft_1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.developerMenuitems.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.classmaskMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DBDataGridView dataGridView_item;
        private ComboBox comboBox_lists;
        private GroupBox listbox_description;
        private GroupBox groupBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private GroupBox groupBox9;
        private Button btnAdd;
        private TextBox searchInput1;
        private Label label1;
        private Label version_label;
        internal Label progres;
        internal ProgressBar progressBar1;
        private ContextMenuStrip listbox_items_menu;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private DBDataGridView listBox_items;
        private ContextMenuStrip row_editor_context;
        private ToolStripMenuItem changeToolStripMenuItem;
        private TabControl elementIntoTab;
        private TabPage Edit;
        private TabPage tabPage1;
        private GroupBox groupBox3;
        private Button button1;
        private CheckBox autoSaveCache;
        private CheckBox autoOpenCache;
        private Button button2;
        private GroupBox groupBox5;
        private CheckBox EnableDevMenu;
        private ContextMenuStrip developerMenuitems;
        private ToolStripMenuItem addRowHereToolStripMenuItem;
        private ToolStripMenuItem changeValueToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private GroupBox groupBox6;
        private Label label10;
        private Label label9;
        private TextBox versionToBox;
        private TextBox versionFromBox;
        private Button button3;
        private CheckBox caseSensitiveCheckbox;
        private Button button4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem exportToToolStripMenuItem;
        private ToolStripComboBox exportCombobox;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem changeToolStripMenuItem1;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripTextBox toolStripTextBox3;
        private ToolStripMenuItem configEditorExportToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn RowId;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private TabPage tabPage2;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private ComboBox replaceSelected;
        private Button button6;
        private TextBox textBox_oldValue;
        private ComboBox selecter_rowscheckbox;
        internal Label label13;
        internal Label label12;
        private TextBox textBox_newValue;
        private LinkLabel linkLabel1;
        private CheckBox exportClipboardWithRules;
        private TabPage SaleTab;
        private TabPage craftTab;
        private GroupBox groupBox1;
        private PictureBox picture_item_32;
        private PictureBox picture_item_31;
        private PictureBox picture_item_30;
        private PictureBox picture_item_29;
        private PictureBox picture_item_28;
        private PictureBox picture_item_27;
        private PictureBox picture_item_26;
        private PictureBox picture_item_25;
        private PictureBox picture_item_24;
        private PictureBox picture_item_23;
        private PictureBox picture_item_22;
        private PictureBox picture_item_21;
        private PictureBox picture_item_20;
        private PictureBox picture_item_19;
        private PictureBox picture_item_18;
        private PictureBox picture_item_17;
        private PictureBox picture_item_16;
        private PictureBox picture_item_15;
        private PictureBox picture_item_14;
        private PictureBox picture_item_13;
        private PictureBox picture_item_12;
        private PictureBox picture_item_11;
        private PictureBox picture_item_10;
        private PictureBox picture_item_9;
        private PictureBox picture_item_8;
        private PictureBox picture_item_7;
        private PictureBox picture_item_6;
        private PictureBox picture_item_5;
        private PictureBox picture_item_4;
        private PictureBox picture_item_3;
        private PictureBox picture_item_2;
        private PictureBox picture_item_1;
        private Button tab_salebtn_1;
        private GroupBox groupBox4;
        private Button tab_salebtn_5;
        private Button tab_salebtn_2;
        private Button tab_salebtn_8;
        private Button tab_salebtn_3;
        private Button tab_salebtn_7;
        private Button tab_salebtn_4;
        private Button tab_salebtn_6;
        private CheckBox autonewId;
        private Button button7;
        private Button button10;
        private TextBox textBox2;
        private Button button8;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStripSalePreview;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem moveHereToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        internal Label label_item_32;
        internal Label label_item_31;
        internal Label label_item_30;
        internal Label label_item_29;
        internal Label label_item_28;
        internal Label label_item_27;
        internal Label label_item_26;
        internal Label label_item_25;
        internal Label label_item_24;
        internal Label label_item_23;
        internal Label label_item_22;
        internal Label label_item_21;
        internal Label label_item_20;
        internal Label label_item_19;
        internal Label label_item_18;
        internal Label label_item_17;
        internal Label label_item_16;
        internal Label label_item_15;
        internal Label label_item_14;
        internal Label label_item_13;
        internal Label label_item_12;
        internal Label label_item_11;
        internal Label label_item_10;
        internal Label label_item_9;
        internal Label label_item_8;
        internal Label label_item_7;
        internal Label label_item_6;
        internal Label label_item_5;
        internal Label label_item_4;
        internal Label label_item_3;
        internal Label label_item_2;
        internal Label label_item_1;
        private GroupBox groupBox11;
        private PictureBox pictureBox41;
        private GroupBox groupBox10;
        private PictureBox pictureBox_craft_req_8;
        private PictureBox pictureBox_craft_req_7;
        private PictureBox pictureBox_craft_req_6;
        private PictureBox pictureBox_craft_req_5;
        private PictureBox pictureBox_craft_req_4;
        private PictureBox pictureBox_craft_req_3;
        private PictureBox pictureBox_craft_req_2;
        private PictureBox pictureBox_craft_req_1;
        private GroupBox groupBox8;
        private PictureBox pictureBox_craft_32;
        private ContextMenuStrip contextMenuStripproduce;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem2;
        private PictureBox pictureBox_craft_31;
        private PictureBox pictureBox_craft_30;
        private PictureBox pictureBox_craft_29;
        private PictureBox pictureBox_craft_28;
        private PictureBox pictureBox_craft_27;
        private PictureBox pictureBox_craft_26;
        private PictureBox pictureBox_craft_25;
        private PictureBox pictureBox_craft_24;
        private PictureBox pictureBox_craft_23;
        private PictureBox pictureBox_craft_22;
        private PictureBox pictureBox_craft_21;
        private PictureBox pictureBox_craft_20;
        private PictureBox pictureBox_craft_19;
        private PictureBox pictureBox_craft_18;
        private PictureBox pictureBox_craft_17;
        private PictureBox pictureBox_craft_16;
        private PictureBox pictureBox_craft_15;
        private PictureBox pictureBox_craft_14;
        private PictureBox pictureBox_craft_13;
        private PictureBox pictureBox_craft_12;
        private PictureBox pictureBox_craft_11;
        private PictureBox pictureBox_craft_10;
        private PictureBox pictureBox_craft_9;
        private PictureBox pictureBox_craft_8;
        private PictureBox pictureBox_craft_7;
        private PictureBox pictureBox_craft_6;
        private PictureBox pictureBox_craft_5;
        private PictureBox pictureBox_craft_4;
        private PictureBox pictureBox_craft_3;
        private PictureBox pictureBox_craft_2;
        private PictureBox pictureBox_craft_1;
        private GroupBox groupBox7;
        private Button button9;
        private TextBox textBox3;
        private Button tab_craftbtn_1;
        private Button tab_craftbtn_5;
        private Button tab_craftbtn_2;
        private Button tab_craftbtn_8;
        private Button tab_craftbtn_3;
        private Button tab_craftbtn_7;
        private Button tab_craftbtn_4;
        private Button tab_craftbtn_6;
        private CheckBox checkBox1;
        private GroupBox groupBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private PictureBox pictureBox44;
        private Label label21;
        private Label label22;
        private GroupBox groupBox14;
        private TextBox textBox13;
        private TextBox textBox14;
        private PictureBox pictureBox43;
        private Label label18;
        private Label label19;
        private GroupBox groupBox13;
        private TextBox textBox10;
        private TextBox textBox11;
        private PictureBox pictureBox42;
        private Label label15;
        private Label label16;
        private GroupBox groupBox12;
        private TextBox textBox6;
        private TextBox textBox8;
        private Label label7;
        private Label label6;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label3;
        private Label label4;
        private Button button11;
        private Button button12;
        private Button button13;
        private Label label5;
        private TextBox textBox7;
        private Label label17;
        private Label label8;
        private Button button14;
        private TextBox textBox24;
        private Label label33;
        private TextBox textBox22;
        private Label label31;
        private TextBox textBox21;
        private Label label30;
        private TextBox textBox18;
        private Label label27;
        private TextBox textBox15;
        private Label label26;
        private TextBox textBox12;
        private Label label25;
        private TextBox textBox9;
        private Label label24;
        private ComboBox comboBox2;
        private Label label23;
        private Label label20;
        private ComboBox comboBox1;
        private TextBox textBox20;
        private Label label29;
        private TextBox textBox19;
        private Label label28;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem changeToolStripMenuItem2;
        private ContextMenuStrip classmaskMenu;
        private GroupBox groupBox16;
        private TextBox nextautoIdlabelmax;
        internal Label label34;
        internal Label label32;
        private CheckBox autonewIdCTRLV;
        private TextBox nextautoIdlabel;
        private TabPage tabPage4;
        private DataGridView dataGridView1;
        internal Label label14;
        internal Label label11;
        private GroupBox groupBox17;
        private Button button15;
        internal Label label36;
        private TextBox textBox23;
        internal Label label35;
        private Button button5;
        private GroupBox groupBox18;
        private Button button16;
        internal Label label37;
        private TextBox textBox25;
        internal Label label38;
        private ComboBox comboBox3;
        private CheckBox checkBox2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyAllItemNamesToClipboardToolStripMenuItem;
        private ToolStripMenuItem copyAllItemNamesToClipboardToolStripMenuItem1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem makeRecipesToolStripMenuItem2;
        private ToolStripMenuItem reforgeTypeToolStripMenuItem;
        private ToolStripMenuItem targetTypeToolStripMenuItem;
        private ToolStripMenuItem materialTypeToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem invertRowsToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pastToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        internal Label label2;
        private CheckBox checkBox3;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem copySelectedItemsToClipboardToolStripMenuItem;
        private CheckBox checkBox4;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewImageColumn ColumnImg;
        private DataGridViewTextBoxColumn ColumnName;
        private ToolStripMenuItem exportSkillsToListToolStripMenuItem;
        private CheckBox checkBox5;
        private ToolStripMenuItem readListDEBUGToolStripMenuItem;
        private ToolStripMenuItem skillsToolStripMenuItem;
    }
}

