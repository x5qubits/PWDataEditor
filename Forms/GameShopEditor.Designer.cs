using JHUI.Controls;
using System.Windows.Forms;

namespace ElementEditor
{
    partial class GameShopEditor
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
            JHUI.JAnimation jAnimation1 = new JHUI.JAnimation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameShopEditor));
            JHUI.JAnimation jAnimation2 = new JHUI.JAnimation();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Menu_Item = new JHUI.Controls.JContextMenu(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_moveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exportItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsHotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsNewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.makeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changePriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.doItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_dbSource = new System.Windows.Forms.ToolStripComboBox();
            this.doItToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteIfNotExistInShopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectInElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSubCat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_moveCat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label22 = new JHUI.Controls.JLabel();
            this.label21 = new JHUI.Controls.JLabel();
            this.numericUpDown_log_price = new JHUI.Controls.JNumericUpDown();
            this.numericUpDown_gift_amount = new JHUI.Controls.JNumericUpDown();
            this.textBox_gift_duration = new JHUI.Controls.JTextBox();
            this.label20 = new JHUI.Controls.JLabel();
            this.numericUpDown_gift_id = new JHUI.Controls.JNumericUpDown();
            this.label19 = new JHUI.Controls.JLabel();
            this.textBox_name = new JHUI.Controls.JTextBox();
            this.textBox_description = new JHUI.Controls.JTextBox();
            this.pictureBox_surface = new JHUI.Controls.JPictureBox();
            this.tabControl1 = new JHUI.Controls.JTabControl();
            this.tabPage1 = new JHUI.Controls.JTabPage();
            this.numericUpDown_itemID = new JHUI.Controls.JTextBox();
            this.jPictureBox4 = new JHUI.Controls.JPictureBox();
            this.ToolBox = new JHUI.Controls.JContextMenu(this.components);
            this.autoFixShopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeInexistentItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.controlTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiplyValueText = new System.Windows.Forms.ToolStripTextBox();
            this.devideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_surface = new JHUI.Controls.JTextBox();
            this.richTextBox_PreviewText = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new JHUI.Controls.JTabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_active = new JHUI.Controls.JCheckBox();
            this.textBox_flags = new JHUI.Controls.JTextBox();
            this.label13 = new JHUI.Controls.JLabel();
            this.textBox_day = new JHUI.Controls.JTextBox();
            this.label16 = new JHUI.Controls.JLabel();
            this.comboBox_type = new JHUI.Controls.JComboBox();
            this.label9 = new JHUI.Controls.JLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_start_date = new JHUI.Controls.JDateTime();
            this.label12 = new JHUI.Controls.JLabel();
            this.textBox_end_date = new JHUI.Controls.JDateTime();
            this.label10 = new JHUI.Controls.JLabel();
            this.label11 = new JHUI.Controls.JLabel();
            this.textBox_duration = new JHUI.Controls.JTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_amount = new JHUI.Controls.JNumericUpDown();
            this.label7 = new JHUI.Controls.JLabel();
            this.label8 = new JHUI.Controls.JLabel();
            this.comboBox_status = new JHUI.Controls.JComboBox();
            this.numericUpDown_price = new JHUI.Controls.JNumericUpDown();
            this.label15 = new JHUI.Controls.JLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new JHUI.Controls.JTabPage();
            this.tabPage3 = new JHUI.Controls.JTabPage();
            this.label17 = new JHUI.Controls.JLabel();
            this.textBox_npc8 = new JHUI.Controls.JTextBox();
            this.label14 = new JHUI.Controls.JLabel();
            this.textBox_npc4 = new JHUI.Controls.JTextBox();
            this.label4 = new JHUI.Controls.JLabel();
            this.label5 = new JHUI.Controls.JLabel();
            this.textBox_npc5 = new JHUI.Controls.JTextBox();
            this.textBox_npc6 = new JHUI.Controls.JTextBox();
            this.label6 = new JHUI.Controls.JLabel();
            this.textBox_npc7 = new JHUI.Controls.JTextBox();
            this.label3 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.textBox_npc1 = new JHUI.Controls.JTextBox();
            this.textBox_npc2 = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.textBox_npc3 = new JHUI.Controls.JTextBox();
            this.tabPage7 = new JHUI.Controls.JTabPage();
            this.buy_times_limit = new JHUI.Controls.JTextBox();
            this.buy_times_limit_mode = new JHUI.Controls.JComboBox();
            this.label23 = new JHUI.Controls.JLabel();
            this.label18 = new JHUI.Controls.JLabel();
            this.tabControl2 = new JHUI.Controls.JTabControl();
            this.tabPage6 = new JHUI.Controls.JTabPage();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.pathLabel = new JHUI.Controls.JLabel();
            this.version_label = new JHUI.Controls.JLabel();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jCheckBox1 = new JHUI.Controls.JCheckBox();
            this.replaceWithTextBox = new JHUI.Controls.JTextBox();
            this.jPictureBox5 = new JHUI.Controls.JPictureBox();
            this.textBox_search = new JHUI.Controls.JTextBox();
            this.checkBox1 = new JHUI.Controls.JCheckBox();
            this.fieldscomboBox = new JHUI.Controls.JComboBox();
            this.listBox_items = new JHUI.Controls.JDataGridView();
            this.RowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.SaveMenu = new JHUI.Controls.JContextMenu(this.components);
            this.saveUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionSelector = new System.Windows.Forms.ToolStripComboBox();
            this.doItToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sevToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveUpDown = new JHUI.Controls.JContextMenu(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_Cats = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBox_SubCats = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_timestamp = new JHUI.Controls.JLabel();
            this.jPictureBox3 = new JHUI.Controls.JPictureBox();
            this.Menu_Item.SuspendLayout();
            this.MenuSubCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_log_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_gift_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_gift_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_surface)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).BeginInit();
            this.ToolBox.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            this.SaveMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.jContextMenu1.SuspendLayout();
            this.MoveUpDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_Cats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_SubCats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_Item
            // 
            this.Menu_Item.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem12,
            this.toolStripSeparator2,
            this.toolStripMenuItem_moveItem,
            this.toolStripSeparator5,
            this.exportItemsToolStripMenuItem,
            this.importItemsToolStripMenuItem,
            this.miscToolStripMenuItem,
            this.makeToolStripMenuItem,
            this.changePriceToolStripMenuItem,
            this.updateDescriptionToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectInElementsToolStripMenuItem});
            this.Menu_Item.Name = "contextMenuStrip_Item";
            this.Menu_Item.Size = new System.Drawing.Size(170, 242);
            this.Menu_Item.Style = JHUI.JColorStyle.Gold;
            this.Menu_Item.Theme = JHUI.JThemeStyle.Dark;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.Add;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem3.Text = "Add";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.click_addItem);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Image = global::PWDataEditorPaied.Properties.Resources.Delete1;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem12.Text = "Delete Items";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.click_deleteItem);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuItem_moveItem
            // 
            this.toolStripMenuItem_moveItem.Image = global::PWDataEditorPaied.Properties.Resources.Login;
            this.toolStripMenuItem_moveItem.Name = "toolStripMenuItem_moveItem";
            this.toolStripMenuItem_moveItem.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem_moveItem.Text = "Move To Items";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(166, 6);
            // 
            // exportItemsToolStripMenuItem
            // 
            this.exportItemsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Disk_download;
            this.exportItemsToolStripMenuItem.Name = "exportItemsToolStripMenuItem";
            this.exportItemsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exportItemsToolStripMenuItem.Text = "Export Items";
            this.exportItemsToolStripMenuItem.Click += new System.EventHandler(this.exportItemsToolStripMenuItem_Click);
            // 
            // importItemsToolStripMenuItem
            // 
            this.importItemsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Disk_upload;
            this.importItemsToolStripMenuItem.Name = "importItemsToolStripMenuItem";
            this.importItemsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importItemsToolStripMenuItem.Text = "Import Items";
            this.importItemsToolStripMenuItem.Click += new System.EventHandler(this.importItemsToolStripMenuItem_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsNewToolStripMenuItem,
            this.markAsHotToolStripMenuItem,
            this.markAsNewToolStripMenuItem1});
            this.miscToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.miscToolStripMenuItem.Text = "Mark as ";
            // 
            // markAsNewToolStripMenuItem
            // 
            this.markAsNewToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.New;
            this.markAsNewToolStripMenuItem.Name = "markAsNewToolStripMenuItem";
            this.markAsNewToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.markAsNewToolStripMenuItem.Text = "New";
            this.markAsNewToolStripMenuItem.Click += new System.EventHandler(this.button12_Click);
            // 
            // markAsHotToolStripMenuItem
            // 
            this.markAsHotToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Flow_block;
            this.markAsHotToolStripMenuItem.Name = "markAsHotToolStripMenuItem";
            this.markAsHotToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.markAsHotToolStripMenuItem.Text = "Hot";
            // 
            // markAsNewToolStripMenuItem1
            // 
            this.markAsNewToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Layout;
            this.markAsNewToolStripMenuItem1.Name = "markAsNewToolStripMenuItem1";
            this.markAsNewToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.markAsNewToolStripMenuItem1.Text = "Normal";
            this.markAsNewToolStripMenuItem1.Click += new System.EventHandler(this.button16_Click);
            // 
            // makeToolStripMenuItem
            // 
            this.makeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientToolStripMenuItem,
            this.serverToolStripMenuItem1});
            this.makeToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.makeToolStripMenuItem.Name = "makeToolStripMenuItem";
            this.makeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.makeToolStripMenuItem.Text = "Control Type ";
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.button10_Click);
            // 
            // serverToolStripMenuItem1
            // 
            this.serverToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.serverToolStripMenuItem1.Name = "serverToolStripMenuItem1";
            this.serverToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.serverToolStripMenuItem1.Text = "Server";
            this.serverToolStripMenuItem1.Click += new System.EventHandler(this.button11_Click);
            // 
            // changePriceToolStripMenuItem
            // 
            this.changePriceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBox1,
            this.doItToolStripMenuItem});
            this.changePriceToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.changePriceToolStripMenuItem.Name = "changePriceToolStripMenuItem";
            this.changePriceToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.changePriceToolStripMenuItem.Text = "Change Price";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // doItToolStripMenuItem
            // 
            this.doItToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.doItToolStripMenuItem.Name = "doItToolStripMenuItem";
            this.doItToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.doItToolStripMenuItem.Text = "Do It";
            this.doItToolStripMenuItem.Click += new System.EventHandler(this.button9_Click);
            // 
            // updateDescriptionToolStripMenuItem
            // 
            this.updateDescriptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBox_dbSource,
            this.doItToolStripMenuItem1,
            this.deleteIfNotExistInShopToolStripMenuItem});
            this.updateDescriptionToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.updateDescriptionToolStripMenuItem.Name = "updateDescriptionToolStripMenuItem";
            this.updateDescriptionToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.updateDescriptionToolStripMenuItem.Text = "PWI Database";
            // 
            // comboBox_dbSource
            // 
            this.comboBox_dbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_dbSource.DropDownWidth = 181;
            this.comboBox_dbSource.Items.AddRange(new object[] {
            "item_ext_desc.txt",
            "pwdatabase.com/pwi",
            "pwdatabase.com/my",
            "pwdatabase.com/ms",
            "pwdatabase.com/ru",
            "pwdatabase.com/br",
            "pwdatabase.com/cn"});
            this.comboBox_dbSource.Name = "comboBox_dbSource";
            this.comboBox_dbSource.Size = new System.Drawing.Size(181, 23);
            // 
            // doItToolStripMenuItem1
            // 
            this.doItToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.doItToolStripMenuItem1.Name = "doItToolStripMenuItem1";
            this.doItToolStripMenuItem1.Size = new System.Drawing.Size(241, 22);
            this.doItToolStripMenuItem1.Text = "Update Name And Description";
            this.doItToolStripMenuItem1.Click += new System.EventHandler(this.button_autoDetect_Click);
            // 
            // deleteIfNotExistInShopToolStripMenuItem
            // 
            this.deleteIfNotExistInShopToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.deleteIfNotExistInShopToolStripMenuItem.Name = "deleteIfNotExistInShopToolStripMenuItem";
            this.deleteIfNotExistInShopToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.deleteIfNotExistInShopToolStripMenuItem.Text = "Delete if not exist in shop";
            this.deleteIfNotExistInShopToolStripMenuItem.Click += new System.EventHandler(this.deleteIfNotExistInShopToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(166, 6);
            // 
            // selectInElementsToolStripMenuItem
            // 
            this.selectInElementsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View1;
            this.selectInElementsToolStripMenuItem.Name = "selectInElementsToolStripMenuItem";
            this.selectInElementsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.selectInElementsToolStripMenuItem.Text = "Select In Elements";
            this.selectInElementsToolStripMenuItem.Click += new System.EventHandler(this.button17_Click);
            // 
            // MenuSubCat
            // 
            this.MenuSubCat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.toolStripMenuItem_moveCat,
            this.toolStripSeparator3,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.MenuSubCat.Name = "contextMenuStrip_SubCat";
            this.MenuSubCat.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuSubCat.Size = new System.Drawing.Size(139, 126);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Add;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.click_addSubCat);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Delete1;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.click_deleteSubCat);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // toolStripMenuItem_moveCat
            // 
            this.toolStripMenuItem_moveCat.Image = global::PWDataEditorPaied.Properties.Resources.Login;
            this.toolStripMenuItem_moveCat.Name = "toolStripMenuItem_moveCat";
            this.toolStripMenuItem_moveCat.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem_moveCat.Text = "Move To";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(135, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Up1;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUplistBox_Sub_Cats);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Down1;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveUplistBox_Sub_Cats);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.DropShadowColor = System.Drawing.Color.Black;
            this.label22.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label22.FontSize = JHUI.JLabelSize.Small;
            this.label22.ForeColor = System.Drawing.Color.Gray;
            this.label22.Location = new System.Drawing.Point(8, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 15);
            this.label22.Style = JHUI.JColorStyle.Gold;
            this.label22.TabIndex = 36;
            this.label22.Text = "Log Price:";
            this.label22.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.DropShadowColor = System.Drawing.Color.Black;
            this.label21.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label21.FontSize = JHUI.JLabelSize.Small;
            this.label21.ForeColor = System.Drawing.Color.Gray;
            this.label21.Location = new System.Drawing.Point(8, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 15);
            this.label21.Style = JHUI.JColorStyle.Gold;
            this.label21.TabIndex = 37;
            this.label21.Text = "Gift Duration:";
            this.label21.Theme = JHUI.JThemeStyle.Dark;
            // 
            // numericUpDown_log_price
            // 
            this.numericUpDown_log_price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericUpDown_log_price.CustomDrawButtons = false;
            this.numericUpDown_log_price.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_log_price.FontSize = JHUI.JLabelSize.Medium;
            this.numericUpDown_log_price.FontWeight = JHUI.JLabelWeight.Light;
            this.numericUpDown_log_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.numericUpDown_log_price.Location = new System.Drawing.Point(83, 92);
            this.numericUpDown_log_price.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.numericUpDown_log_price.Name = "numericUpDown_log_price";
            this.numericUpDown_log_price.Size = new System.Drawing.Size(65, 26);
            this.numericUpDown_log_price.Style = JHUI.JColorStyle.Gold;
            this.numericUpDown_log_price.StyleManager = null;
            this.numericUpDown_log_price.TabIndex = 37;
            this.numericUpDown_log_price.Theme = JHUI.JThemeStyle.Dark;
            this.numericUpDown_log_price.UseAlternateColors = false;
            this.numericUpDown_log_price.UseCustomBackColor = true;
            this.numericUpDown_log_price.UseSelectable = true;
            this.numericUpDown_log_price.UseStyleColors = false;
            this.numericUpDown_log_price.Leave += new System.EventHandler(this.edit_item);
            // 
            // numericUpDown_gift_amount
            // 
            this.numericUpDown_gift_amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericUpDown_gift_amount.CustomDrawButtons = false;
            this.numericUpDown_gift_amount.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_gift_amount.FontSize = JHUI.JLabelSize.Medium;
            this.numericUpDown_gift_amount.FontWeight = JHUI.JLabelWeight.Light;
            this.numericUpDown_gift_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.numericUpDown_gift_amount.Location = new System.Drawing.Point(83, 40);
            this.numericUpDown_gift_amount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_gift_amount.Name = "numericUpDown_gift_amount";
            this.numericUpDown_gift_amount.Size = new System.Drawing.Size(65, 26);
            this.numericUpDown_gift_amount.Style = JHUI.JColorStyle.Gold;
            this.numericUpDown_gift_amount.StyleManager = null;
            this.numericUpDown_gift_amount.TabIndex = 36;
            this.numericUpDown_gift_amount.Theme = JHUI.JThemeStyle.Dark;
            this.numericUpDown_gift_amount.UseAlternateColors = false;
            this.numericUpDown_gift_amount.UseCustomBackColor = true;
            this.numericUpDown_gift_amount.UseSelectable = true;
            this.numericUpDown_gift_amount.UseStyleColors = false;
            this.numericUpDown_gift_amount.Leave += new System.EventHandler(this.edit_item);
            // 
            // textBox_gift_duration
            // 
            this.textBox_gift_duration.BorderBottomLineSize = 5;
            this.textBox_gift_duration.BorderColor = System.Drawing.Color.Black;
            this.textBox_gift_duration.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_gift_duration.CustomButton.Image = null;
            this.textBox_gift_duration.CustomButton.Location = new System.Drawing.Point(47, 2);
            this.textBox_gift_duration.CustomButton.Name = "";
            this.textBox_gift_duration.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_gift_duration.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_gift_duration.CustomButton.TabIndex = 1;
            this.textBox_gift_duration.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_gift_duration.CustomButton.UseSelectable = true;
            this.textBox_gift_duration.CustomButton.Visible = false;
            this.textBox_gift_duration.DrawBorder = true;
            this.textBox_gift_duration.DrawBorderBottomLine = false;
            this.textBox_gift_duration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_gift_duration.Lines = new string[0];
            this.textBox_gift_duration.Location = new System.Drawing.Point(83, 69);
            this.textBox_gift_duration.MaxLength = 32767;
            this.textBox_gift_duration.Name = "textBox_gift_duration";
            this.textBox_gift_duration.PasswordChar = '\0';
            this.textBox_gift_duration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_gift_duration.SelectedText = "";
            this.textBox_gift_duration.SelectionLength = 0;
            this.textBox_gift_duration.SelectionStart = 0;
            this.textBox_gift_duration.ShortcutsEnabled = true;
            this.textBox_gift_duration.Size = new System.Drawing.Size(65, 20);
            this.textBox_gift_duration.Style = JHUI.JColorStyle.Gold;
            this.textBox_gift_duration.TabIndex = 36;
            this.textBox_gift_duration.TextWaterMark = "";
            this.textBox_gift_duration.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_gift_duration.UseCustomFont = true;
            this.textBox_gift_duration.UseSelectable = true;
            this.textBox_gift_duration.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_gift_duration.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_gift_duration.Leave += new System.EventHandler(this.edit_item);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.DropShadowColor = System.Drawing.Color.Black;
            this.label20.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label20.FontSize = JHUI.JLabelSize.Small;
            this.label20.ForeColor = System.Drawing.Color.Gray;
            this.label20.Location = new System.Drawing.Point(8, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 15);
            this.label20.Style = JHUI.JColorStyle.Gold;
            this.label20.TabIndex = 35;
            this.label20.Text = "Gift Amount:";
            this.label20.Theme = JHUI.JThemeStyle.Dark;
            // 
            // numericUpDown_gift_id
            // 
            this.numericUpDown_gift_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericUpDown_gift_id.CustomDrawButtons = false;
            this.numericUpDown_gift_id.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_gift_id.FontSize = JHUI.JLabelSize.Medium;
            this.numericUpDown_gift_id.FontWeight = JHUI.JLabelWeight.Light;
            this.numericUpDown_gift_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.numericUpDown_gift_id.Location = new System.Drawing.Point(83, 14);
            this.numericUpDown_gift_id.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_gift_id.Name = "numericUpDown_gift_id";
            this.numericUpDown_gift_id.Size = new System.Drawing.Size(65, 26);
            this.numericUpDown_gift_id.Style = JHUI.JColorStyle.Gold;
            this.numericUpDown_gift_id.StyleManager = null;
            this.numericUpDown_gift_id.TabIndex = 34;
            this.numericUpDown_gift_id.Theme = JHUI.JThemeStyle.Dark;
            this.numericUpDown_gift_id.UseAlternateColors = false;
            this.numericUpDown_gift_id.UseCustomBackColor = true;
            this.numericUpDown_gift_id.UseSelectable = true;
            this.numericUpDown_gift_id.UseStyleColors = false;
            this.numericUpDown_gift_id.Leave += new System.EventHandler(this.edit_item);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.DropShadowColor = System.Drawing.Color.Black;
            this.label19.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label19.FontSize = JHUI.JLabelSize.Small;
            this.label19.ForeColor = System.Drawing.Color.Gray;
            this.label19.Location = new System.Drawing.Point(8, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 15);
            this.label19.Style = JHUI.JColorStyle.Gold;
            this.label19.TabIndex = 33;
            this.label19.Text = "Gift ID:";
            this.label19.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_name
            // 
            this.textBox_name.BorderBottomLineSize = 5;
            this.textBox_name.BorderColor = System.Drawing.Color.Black;
            this.textBox_name.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_name.CustomButton.Image = null;
            this.textBox_name.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.textBox_name.CustomButton.Name = "";
            this.textBox_name.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.textBox_name.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_name.CustomButton.TabIndex = 1;
            this.textBox_name.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_name.CustomButton.UseSelectable = true;
            this.textBox_name.CustomButton.Visible = false;
            this.textBox_name.DrawBorder = true;
            this.textBox_name.DrawBorderBottomLine = false;
            this.textBox_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_name.Lines = new string[0];
            this.textBox_name.Location = new System.Drawing.Point(137, 6);
            this.textBox_name.MaxLength = 32;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.PasswordChar = '\0';
            this.textBox_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_name.SelectedText = "";
            this.textBox_name.SelectionLength = 0;
            this.textBox_name.SelectionStart = 0;
            this.textBox_name.ShortcutsEnabled = true;
            this.textBox_name.Size = new System.Drawing.Size(360, 24);
            this.textBox_name.Style = JHUI.JColorStyle.Blue;
            this.textBox_name.TabIndex = 8;
            this.textBox_name.TextWaterMark = "";
            this.textBox_name.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_name.UseCustomFont = true;
            this.textBox_name.UseSelectable = true;
            this.textBox_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_name.Leave += new System.EventHandler(this.edit_item);
            // 
            // textBox_description
            // 
            this.textBox_description.BorderBottomLineSize = 5;
            this.textBox_description.BorderColor = System.Drawing.Color.Black;
            this.textBox_description.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_description.CustomButton.Image = null;
            this.textBox_description.CustomButton.Location = new System.Drawing.Point(234, 2);
            this.textBox_description.CustomButton.Name = "";
            this.textBox_description.CustomButton.Size = new System.Drawing.Size(123, 123);
            this.textBox_description.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_description.CustomButton.TabIndex = 1;
            this.textBox_description.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_description.CustomButton.UseSelectable = true;
            this.textBox_description.CustomButton.Visible = false;
            this.textBox_description.DrawBorder = true;
            this.textBox_description.DrawBorderBottomLine = false;
            this.textBox_description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_description.Lines = new string[0];
            this.textBox_description.Location = new System.Drawing.Point(137, 34);
            this.textBox_description.MaxLength = 512;
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.PasswordChar = '\0';
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_description.SelectedText = "";
            this.textBox_description.SelectionLength = 0;
            this.textBox_description.SelectionStart = 0;
            this.textBox_description.ShortcutsEnabled = true;
            this.textBox_description.Size = new System.Drawing.Size(360, 128);
            this.textBox_description.Style = JHUI.JColorStyle.Gold;
            this.textBox_description.TabIndex = 10;
            this.textBox_description.TextWaterMark = "";
            this.textBox_description.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_description.UseCustomFont = true;
            this.textBox_description.UseSelectable = true;
            this.textBox_description.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_description.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_description.TextChanged += new System.EventHandler(this.textBox_description_TextChanged);
            this.textBox_description.Leave += new System.EventHandler(this.edit_item);
            // 
            // pictureBox_surface
            // 
            this.pictureBox_surface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_surface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_surface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_surface.Location = new System.Drawing.Point(3, 34);
            this.pictureBox_surface.Name = "pictureBox_surface";
            this.pictureBox_surface.Size = new System.Drawing.Size(128, 128);
            this.pictureBox_surface.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_surface.Style = JHUI.JColorStyle.Gold;
            this.pictureBox_surface.TabIndex = 6;
            this.pictureBox_surface.TabStop = false;
            this.pictureBox_surface.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_surface.Click += new System.EventHandler(this.jPictureBox4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            jAnimation1.AnimateOnlyDifferences = true;
            jAnimation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.BlindCoeff")));
            jAnimation1.LeafCoeff = 0F;
            jAnimation1.MaxTime = 1F;
            jAnimation1.MinTime = 0F;
            jAnimation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicCoeff")));
            jAnimation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicShift")));
            jAnimation1.MosaicSize = 0;
            jAnimation1.Padding = new System.Windows.Forms.Padding(0);
            jAnimation1.RotateCoeff = 0.5F;
            jAnimation1.RotateLimit = 0.2F;
            jAnimation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.ScaleCoeff")));
            jAnimation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.SlideCoeff")));
            jAnimation1.TimeCoeff = 0F;
            jAnimation1.TransparencyCoeff = 0F;
            this.tabControl1.ChangeAnimation = jAnimation1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(437, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 8);
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(511, 548);
            this.tabControl1.Style = JHUI.JColorStyle.Gold;
            this.tabControl1.TabIndex = 39;
            this.tabControl1.Theme = JHUI.JThemeStyle.Dark;
            this.tabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage1.Controls.Add(this.numericUpDown_itemID);
            this.tabPage1.Controls.Add(this.jPictureBox4);
            this.tabPage1.Controls.Add(this.textBox_name);
            this.tabPage1.Controls.Add(this.comboBox_surface);
            this.tabPage1.Controls.Add(this.textBox_description);
            this.tabPage1.Controls.Add(this.richTextBox_PreviewText);
            this.tabPage1.Controls.Add(this.pictureBox_surface);
            this.tabPage1.HorizontalScrollbarBarColor = true;
            this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage1.HorizontalScrollbarSize = 10;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(503, 506);
            this.tabPage1.Style = JHUI.JColorStyle.Gold;
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage1.VerticalScrollbarBarColor = true;
            this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage1.VerticalScrollbarSize = 10;
            // 
            // numericUpDown_itemID
            // 
            this.numericUpDown_itemID.BorderBottomLineSize = 5;
            this.numericUpDown_itemID.BorderColor = System.Drawing.Color.Black;
            this.numericUpDown_itemID.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.numericUpDown_itemID.CustomButton.Image = null;
            this.numericUpDown_itemID.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.numericUpDown_itemID.CustomButton.Name = "";
            this.numericUpDown_itemID.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.numericUpDown_itemID.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.numericUpDown_itemID.CustomButton.TabIndex = 1;
            this.numericUpDown_itemID.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.numericUpDown_itemID.CustomButton.UseSelectable = true;
            this.numericUpDown_itemID.CustomButton.Visible = false;
            this.numericUpDown_itemID.DrawBorder = true;
            this.numericUpDown_itemID.DrawBorderBottomLine = false;
            this.numericUpDown_itemID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_itemID.Lines = new string[0];
            this.numericUpDown_itemID.Location = new System.Drawing.Point(3, 6);
            this.numericUpDown_itemID.MaxLength = 32;
            this.numericUpDown_itemID.Name = "numericUpDown_itemID";
            this.numericUpDown_itemID.PasswordChar = '\0';
            this.numericUpDown_itemID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericUpDown_itemID.SelectedText = "";
            this.numericUpDown_itemID.SelectionLength = 0;
            this.numericUpDown_itemID.SelectionStart = 0;
            this.numericUpDown_itemID.ShortcutsEnabled = true;
            this.numericUpDown_itemID.Size = new System.Drawing.Size(128, 24);
            this.numericUpDown_itemID.Style = JHUI.JColorStyle.Blue;
            this.numericUpDown_itemID.TabIndex = 48;
            this.numericUpDown_itemID.TextWaterMark = "";
            this.numericUpDown_itemID.Theme = JHUI.JThemeStyle.Dark;
            this.numericUpDown_itemID.UseCustomFont = true;
            this.numericUpDown_itemID.UseSelectable = true;
            this.numericUpDown_itemID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.numericUpDown_itemID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_itemID.Leave += new System.EventHandler(this.edit_item);
            // 
            // jPictureBox4
            // 
            this.jPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox4.BackgroundImage")));
            this.jPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox4.ContextMenuStrip = this.ToolBox;
            this.jPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox4.Location = new System.Drawing.Point(473, 168);
            this.jPictureBox4.Name = "jPictureBox4";
            this.jPictureBox4.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox4.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox4.TabIndex = 47;
            this.jPictureBox4.TabStop = false;
            this.jPictureBox4.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox4.Click += new System.EventHandler(this.jPictureBox4_Click);
            // 
            // ToolBox
            // 
            this.ToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoFixShopToolStripMenuItem,
            this.removeInexistentItemsToolStripMenuItem,
            this.toolStripSeparator6,
            this.controlTypeToolStripMenuItem,
            this.replaceToolStripMenuItem});
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(204, 98);
            this.ToolBox.Style = JHUI.JColorStyle.Gold;
            this.ToolBox.Theme = JHUI.JThemeStyle.Dark;
            // 
            // autoFixShopToolStripMenuItem
            // 
            this.autoFixShopToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.autoFixShopToolStripMenuItem.Name = "autoFixShopToolStripMenuItem";
            this.autoFixShopToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.autoFixShopToolStripMenuItem.Text = "Auto Fix Shop";
            this.autoFixShopToolStripMenuItem.Click += new System.EventHandler(this.autoFixShopToolStripMenuItem_Click);
            // 
            // removeInexistentItemsToolStripMenuItem
            // 
            this.removeInexistentItemsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.removeInexistentItemsToolStripMenuItem.Name = "removeInexistentItemsToolStripMenuItem";
            this.removeInexistentItemsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.removeInexistentItemsToolStripMenuItem.Text = "Remove Unknown Items";
            this.removeInexistentItemsToolStripMenuItem.Click += new System.EventHandler(this.removeInexistentItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(200, 6);
            // 
            // controlTypeToolStripMenuItem
            // 
            this.controlTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.clientToolStripMenuItem1});
            this.controlTypeToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.controlTypeToolStripMenuItem.Name = "controlTypeToolStripMenuItem";
            this.controlTypeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.controlTypeToolStripMenuItem.Text = "Control Type";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.serverToolStripMenuItem.Text = "Server (All shop)";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.button19_Click);
            // 
            // clientToolStripMenuItem1
            // 
            this.clientToolStripMenuItem1.Name = "clientToolStripMenuItem1";
            this.clientToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.clientToolStripMenuItem1.Text = "Client (All shop)";
            this.clientToolStripMenuItem1.Click += new System.EventHandler(this.button20_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MultiplyValueText,
            this.devideToolStripMenuItem,
            this.multiplyToolStripMenuItem});
            this.replaceToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.replaceToolStripMenuItem.Text = "Math";
            // 
            // MultiplyValueText
            // 
            this.MultiplyValueText.Name = "MultiplyValueText";
            this.MultiplyValueText.Size = new System.Drawing.Size(100, 23);
            // 
            // devideToolStripMenuItem
            // 
            this.devideToolStripMenuItem.Name = "devideToolStripMenuItem";
            this.devideToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.devideToolStripMenuItem.Text = "Devide";
            this.devideToolStripMenuItem.Click += new System.EventHandler(this.button14_Click);
            // 
            // multiplyToolStripMenuItem
            // 
            this.multiplyToolStripMenuItem.Name = "multiplyToolStripMenuItem";
            this.multiplyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.multiplyToolStripMenuItem.Text = "Multiply";
            this.multiplyToolStripMenuItem.Click += new System.EventHandler(this.button15_Click);
            // 
            // comboBox_surface
            // 
            this.comboBox_surface.BorderBottomLineSize = 5;
            this.comboBox_surface.BorderColor = System.Drawing.Color.Black;
            this.comboBox_surface.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.comboBox_surface.CustomButton.Image = null;
            this.comboBox_surface.CustomButton.Location = new System.Drawing.Point(444, 1);
            this.comboBox_surface.CustomButton.Name = "";
            this.comboBox_surface.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.comboBox_surface.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.comboBox_surface.CustomButton.TabIndex = 1;
            this.comboBox_surface.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.comboBox_surface.CustomButton.UseSelectable = true;
            this.comboBox_surface.CustomButton.Visible = false;
            this.comboBox_surface.DrawBorder = true;
            this.comboBox_surface.DrawBorderBottomLine = false;
            this.comboBox_surface.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.comboBox_surface.Lines = new string[0];
            this.comboBox_surface.Location = new System.Drawing.Point(3, 167);
            this.comboBox_surface.MaxLength = 32767;
            this.comboBox_surface.Name = "comboBox_surface";
            this.comboBox_surface.PasswordChar = '\0';
            this.comboBox_surface.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.comboBox_surface.SelectedText = "";
            this.comboBox_surface.SelectionLength = 0;
            this.comboBox_surface.SelectionStart = 0;
            this.comboBox_surface.ShortcutsEnabled = true;
            this.comboBox_surface.Size = new System.Drawing.Size(468, 25);
            this.comboBox_surface.Style = JHUI.JColorStyle.Gold;
            this.comboBox_surface.TabIndex = 12;
            this.comboBox_surface.TextWaterMark = "";
            this.comboBox_surface.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_surface.UseCustomFont = true;
            this.comboBox_surface.UseSelectable = true;
            this.comboBox_surface.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.comboBox_surface.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.comboBox_surface.TextChanged += new System.EventHandler(this.edit_item);
            // 
            // richTextBox_PreviewText
            // 
            this.richTextBox_PreviewText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.richTextBox_PreviewText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_PreviewText.Location = new System.Drawing.Point(3, 198);
            this.richTextBox_PreviewText.Name = "richTextBox_PreviewText";
            this.richTextBox_PreviewText.ReadOnly = true;
            this.richTextBox_PreviewText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_PreviewText.Size = new System.Drawing.Size(494, 273);
            this.richTextBox_PreviewText.TabIndex = 41;
            this.richTextBox_PreviewText.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage4.HorizontalScrollbarBarColor = true;
            this.tabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage4.HorizontalScrollbarSize = 10;
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(503, 506);
            this.tabPage4.Style = JHUI.JColorStyle.Gold;
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Price";
            this.tabPage4.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage4.VerticalScrollbarBarColor = true;
            this.tabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage4.VerticalScrollbarSize = 10;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.groupBox4);
            this.groupBox8.Controls.Add(this.groupBox7);
            this.groupBox8.Controls.Add(this.button4);
            this.groupBox8.Controls.Add(this.groupBox6);
            this.groupBox8.Controls.Add(this.button3);
            this.groupBox8.Controls.Add(this.button1);
            this.groupBox8.Controls.Add(this.button2);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(497, 500);
            this.groupBox8.TabIndex = 35;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Price 1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_active);
            this.groupBox4.Controls.Add(this.textBox_flags);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.textBox_day);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.comboBox_type);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox4.Location = new System.Drawing.Point(3, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(491, 144);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Misc";
            // 
            // checkBox_active
            // 
            this.checkBox_active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_active.Location = new System.Drawing.Point(6, 12);
            this.checkBox_active.Name = "checkBox_active";
            this.checkBox_active.Size = new System.Drawing.Size(215, 17);
            this.checkBox_active.Style = JHUI.JColorStyle.Gold;
            this.checkBox_active.TabIndex = 49;
            this.checkBox_active.Text = "Activated";
            this.checkBox_active.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_active.UseSelectable = true;
            this.checkBox_active.UseVisualStyleBackColor = true;
            this.checkBox_active.CheckStateChanged += new System.EventHandler(this.edit_item);
            // 
            // textBox_flags
            // 
            this.textBox_flags.BorderBottomLineSize = 5;
            this.textBox_flags.BorderColor = System.Drawing.Color.Black;
            this.textBox_flags.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_flags.CustomButton.Image = null;
            this.textBox_flags.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.textBox_flags.CustomButton.Name = "";
            this.textBox_flags.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox_flags.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_flags.CustomButton.TabIndex = 1;
            this.textBox_flags.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_flags.CustomButton.UseSelectable = true;
            this.textBox_flags.CustomButton.Visible = false;
            this.textBox_flags.DrawBorder = true;
            this.textBox_flags.DrawBorderBottomLine = false;
            this.textBox_flags.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_flags.Lines = new string[0];
            this.textBox_flags.Location = new System.Drawing.Point(97, 66);
            this.textBox_flags.MaxLength = 32767;
            this.textBox_flags.Name = "textBox_flags";
            this.textBox_flags.PasswordChar = '\0';
            this.textBox_flags.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_flags.SelectedText = "";
            this.textBox_flags.SelectionLength = 0;
            this.textBox_flags.SelectionStart = 0;
            this.textBox_flags.ShortcutsEnabled = true;
            this.textBox_flags.Size = new System.Drawing.Size(124, 25);
            this.textBox_flags.Style = JHUI.JColorStyle.Gold;
            this.textBox_flags.TabIndex = 36;
            this.textBox_flags.TextWaterMark = "";
            this.textBox_flags.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_flags.UseCustomFont = true;
            this.textBox_flags.UseSelectable = true;
            this.textBox_flags.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_flags.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_flags.Leave += new System.EventHandler(this.edit_item);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.DropShadowColor = System.Drawing.Color.Black;
            this.label13.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label13.FontSize = JHUI.JLabelSize.Small;
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(8, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 15);
            this.label13.Style = JHUI.JColorStyle.Gold;
            this.label13.TabIndex = 29;
            this.label13.Text = "Day:";
            this.label13.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_day
            // 
            this.textBox_day.BorderBottomLineSize = 5;
            this.textBox_day.BorderColor = System.Drawing.Color.Black;
            this.textBox_day.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_day.CustomButton.Image = null;
            this.textBox_day.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.textBox_day.CustomButton.Name = "";
            this.textBox_day.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox_day.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_day.CustomButton.TabIndex = 1;
            this.textBox_day.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_day.CustomButton.UseSelectable = true;
            this.textBox_day.CustomButton.Visible = false;
            this.textBox_day.DrawBorder = true;
            this.textBox_day.DrawBorderBottomLine = false;
            this.textBox_day.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_day.Lines = new string[0];
            this.textBox_day.Location = new System.Drawing.Point(97, 99);
            this.textBox_day.MaxLength = 32767;
            this.textBox_day.Name = "textBox_day";
            this.textBox_day.PasswordChar = '\0';
            this.textBox_day.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_day.SelectedText = "";
            this.textBox_day.SelectionLength = 0;
            this.textBox_day.SelectionStart = 0;
            this.textBox_day.ShortcutsEnabled = true;
            this.textBox_day.Size = new System.Drawing.Size(124, 25);
            this.textBox_day.Style = JHUI.JColorStyle.Gold;
            this.textBox_day.TabIndex = 37;
            this.textBox_day.TextWaterMark = "";
            this.textBox_day.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_day.UseCustomFont = true;
            this.textBox_day.UseSelectable = true;
            this.textBox_day.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_day.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_day.Leave += new System.EventHandler(this.edit_item);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.DropShadowColor = System.Drawing.Color.Black;
            this.label16.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label16.FontSize = JHUI.JLabelSize.Small;
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(8, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 15);
            this.label16.Style = JHUI.JColorStyle.Gold;
            this.label16.TabIndex = 31;
            this.label16.Text = "Flags:";
            this.label16.Theme = JHUI.JThemeStyle.Dark;
            // 
            // comboBox_type
            // 
            this.comboBox_type.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox_type.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.ItemHeight = 19;
            this.comboBox_type.Items.AddRange(new object[] {
            "Client",
            "Server"});
            this.comboBox_type.Location = new System.Drawing.Point(97, 35);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(124, 25);
            this.comboBox_type.Style = JHUI.JColorStyle.Gold;
            this.comboBox_type.TabIndex = 38;
            this.comboBox_type.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_type.UseSelectable = true;
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.edit_item);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DropShadowColor = System.Drawing.Color.Black;
            this.label9.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label9.FontSize = JHUI.JLabelSize.Small;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(8, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.Style = JHUI.JColorStyle.Gold;
            this.label9.TabIndex = 16;
            this.label9.Text = "CTRL Type:";
            this.label9.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox_start_date);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.textBox_end_date);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.textBox_duration);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox7.Location = new System.Drawing.Point(3, 308);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(491, 186);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Time Settings";
            // 
            // textBox_start_date
            // 
            this.textBox_start_date.FontSize = JHUI.JDateTimeSize.Small;
            this.textBox_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textBox_start_date.Location = new System.Drawing.Point(97, 14);
            this.textBox_start_date.MaxDate = new System.DateTime(2038, 1, 1, 0, 0, 0, 0);
            this.textBox_start_date.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.textBox_start_date.MinimumSize = new System.Drawing.Size(0, 25);
            this.textBox_start_date.Name = "textBox_start_date";
            this.textBox_start_date.Size = new System.Drawing.Size(124, 25);
            this.textBox_start_date.Style = JHUI.JColorStyle.Gold;
            this.textBox_start_date.TabIndex = 35;
            this.textBox_start_date.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_start_date.Leave += new System.EventHandler(this.edit_item);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.DropShadowColor = System.Drawing.Color.Black;
            this.label12.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label12.FontSize = JHUI.JLabelSize.Small;
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(8, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 15);
            this.label12.Style = JHUI.JColorStyle.Gold;
            this.label12.TabIndex = 28;
            this.label12.Text = "Activation Date:";
            this.label12.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_end_date
            // 
            this.textBox_end_date.FontSize = JHUI.JDateTimeSize.Small;
            this.textBox_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textBox_end_date.Location = new System.Drawing.Point(97, 44);
            this.textBox_end_date.MaxDate = new System.DateTime(2038, 1, 1, 0, 0, 0, 0);
            this.textBox_end_date.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.textBox_end_date.MinimumSize = new System.Drawing.Size(0, 25);
            this.textBox_end_date.Name = "textBox_end_date";
            this.textBox_end_date.Size = new System.Drawing.Size(124, 25);
            this.textBox_end_date.Style = JHUI.JColorStyle.Gold;
            this.textBox_end_date.TabIndex = 34;
            this.textBox_end_date.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_end_date.Leave += new System.EventHandler(this.edit_item);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DropShadowColor = System.Drawing.Color.Black;
            this.label10.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label10.FontSize = JHUI.JLabelSize.Small;
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(24, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.Style = JHUI.JColorStyle.Gold;
            this.label10.TabIndex = 17;
            this.label10.Text = "Expire Date:";
            this.label10.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.DropShadowColor = System.Drawing.Color.Black;
            this.label11.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label11.FontSize = JHUI.JLabelSize.Small;
            this.label11.Location = new System.Drawing.Point(38, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.Style = JHUI.JColorStyle.Gold;
            this.label11.TabIndex = 27;
            this.label11.Text = "Duration:";
            this.label11.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_duration
            // 
            this.textBox_duration.BorderBottomLineSize = 5;
            this.textBox_duration.BorderColor = System.Drawing.Color.Black;
            this.textBox_duration.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_duration.CustomButton.Image = null;
            this.textBox_duration.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.textBox_duration.CustomButton.Name = "";
            this.textBox_duration.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox_duration.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_duration.CustomButton.TabIndex = 1;
            this.textBox_duration.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_duration.CustomButton.UseSelectable = true;
            this.textBox_duration.CustomButton.Visible = false;
            this.textBox_duration.DrawBorder = true;
            this.textBox_duration.DrawBorderBottomLine = false;
            this.textBox_duration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_duration.Lines = new string[0];
            this.textBox_duration.Location = new System.Drawing.Point(97, 74);
            this.textBox_duration.MaxLength = 32767;
            this.textBox_duration.Name = "textBox_duration";
            this.textBox_duration.PasswordChar = '\0';
            this.textBox_duration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_duration.SelectedText = "";
            this.textBox_duration.SelectionLength = 0;
            this.textBox_duration.SelectionStart = 0;
            this.textBox_duration.ShortcutsEnabled = true;
            this.textBox_duration.Size = new System.Drawing.Size(124, 25);
            this.textBox_duration.Style = JHUI.JColorStyle.Gold;
            this.textBox_duration.TabIndex = 21;
            this.textBox_duration.TextWaterMark = "";
            this.textBox_duration.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_duration.UseCustomFont = true;
            this.textBox_duration.UseSelectable = true;
            this.textBox_duration.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_duration.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_duration.Leave += new System.EventHandler(this.edit_item);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.button4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(185, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(52, 20);
            this.button4.TabIndex = 39;
            this.button4.Text = "Price 4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.numericUpDown_amount);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.comboBox_status);
            this.groupBox6.Controls.Add(this.numericUpDown_price);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox6.Location = new System.Drawing.Point(6, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(491, 107);
            this.groupBox6.TabIndex = 41;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sale Option";
            // 
            // numericUpDown_amount
            // 
            this.numericUpDown_amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.numericUpDown_amount.CustomDrawButtons = false;
            this.numericUpDown_amount.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_amount.FontSize = JHUI.JLabelSize.Medium;
            this.numericUpDown_amount.FontWeight = JHUI.JLabelWeight.Light;
            this.numericUpDown_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.numericUpDown_amount.Location = new System.Drawing.Point(99, 73);
            this.numericUpDown_amount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_amount.Name = "numericUpDown_amount";
            this.numericUpDown_amount.Size = new System.Drawing.Size(122, 26);
            this.numericUpDown_amount.Style = JHUI.JColorStyle.Gold;
            this.numericUpDown_amount.StyleManager = null;
            this.numericUpDown_amount.TabIndex = 3;
            this.numericUpDown_amount.Theme = JHUI.JThemeStyle.Dark;
            this.numericUpDown_amount.UseAlternateColors = false;
            this.numericUpDown_amount.UseCustomBackColor = true;
            this.numericUpDown_amount.UseSelectable = true;
            this.numericUpDown_amount.UseStyleColors = false;
            this.numericUpDown_amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_amount.Leave += new System.EventHandler(this.edit_item);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.DropShadowColor = System.Drawing.Color.Black;
            this.label7.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label7.FontSize = JHUI.JLabelSize.Small;
            this.label7.Location = new System.Drawing.Point(14, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.Style = JHUI.JColorStyle.Gold;
            this.label7.TabIndex = 2;
            this.label7.Text = "Cant:";
            this.label7.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DropShadowColor = System.Drawing.Color.Black;
            this.label8.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label8.FontSize = JHUI.JLabelSize.Small;
            this.label8.Location = new System.Drawing.Point(16, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 15);
            this.label8.Style = JHUI.JColorStyle.Gold;
            this.label8.TabIndex = 15;
            this.label8.Text = "Price:";
            this.label8.Theme = JHUI.JThemeStyle.Dark;
            // 
            // comboBox_status
            // 
            this.comboBox_status.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox_status.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.ItemHeight = 19;
            this.comboBox_status.Items.AddRange(new object[] {
            "Normal",
            "New",
            "Sold",
            "Hot",
            "Sale",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "Chinese name lol",
            "STAR 1",
            "STAR 2",
            "STAR 3",
            "STAR 4",
            "STAR 5",
            "STAR 6"});
            this.comboBox_status.Location = new System.Drawing.Point(99, 14);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(122, 25);
            this.comboBox_status.Style = JHUI.JColorStyle.Gold;
            this.comboBox_status.TabIndex = 33;
            this.comboBox_status.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_status.UseSelectable = true;
            this.comboBox_status.Leave += new System.EventHandler(this.edit_item);
            // 
            // numericUpDown_price
            // 
            this.numericUpDown_price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.numericUpDown_price.CustomDrawButtons = false;
            this.numericUpDown_price.DecimalPlaces = 2;
            this.numericUpDown_price.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown_price.FontSize = JHUI.JLabelSize.Medium;
            this.numericUpDown_price.FontWeight = JHUI.JLabelWeight.Light;
            this.numericUpDown_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.numericUpDown_price.Location = new System.Drawing.Point(99, 43);
            this.numericUpDown_price.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.numericUpDown_price.Name = "numericUpDown_price";
            this.numericUpDown_price.Size = new System.Drawing.Size(122, 26);
            this.numericUpDown_price.Style = JHUI.JColorStyle.Gold;
            this.numericUpDown_price.StyleManager = null;
            this.numericUpDown_price.TabIndex = 19;
            this.numericUpDown_price.Theme = JHUI.JThemeStyle.Dark;
            this.numericUpDown_price.ThousandsSeparator = true;
            this.numericUpDown_price.UseAlternateColors = false;
            this.numericUpDown_price.UseSelectable = true;
            this.numericUpDown_price.UseStyleColors = false;
            this.numericUpDown_price.Leave += new System.EventHandler(this.edit_item);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.DropShadowColor = System.Drawing.Color.Black;
            this.label15.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label15.FontSize = JHUI.JLabelSize.Small;
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(9, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.Style = JHUI.JColorStyle.Gold;
            this.label15.TabIndex = 30;
            this.label15.Text = "Status:";
            this.label15.Theme = JHUI.JThemeStyle.Dark;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.button3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Location = new System.Drawing.Point(125, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 20);
            this.button3.TabIndex = 38;
            this.button3.Text = "Price 3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 20);
            this.button1.TabIndex = 36;
            this.button1.Text = "Price 1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.button2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Location = new System.Drawing.Point(66, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 20);
            this.button2.TabIndex = 37;
            this.button2.Text = "Price 2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage2.Controls.Add(this.numericUpDown_gift_id);
            this.tabPage2.Controls.Add(this.numericUpDown_log_price);
            this.tabPage2.Controls.Add(this.numericUpDown_gift_amount);
            this.tabPage2.Controls.Add(this.textBox_gift_duration);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.HorizontalScrollbarBarColor = true;
            this.tabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage2.HorizontalScrollbarSize = 10;
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(503, 506);
            this.tabPage2.Style = JHUI.JColorStyle.Gold;
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bonus";
            this.tabPage2.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage2.VerticalScrollbarBarColor = true;
            this.tabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage2.VerticalScrollbarSize = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.textBox_npc8);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.textBox_npc4);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.textBox_npc5);
            this.tabPage3.Controls.Add(this.textBox_npc6);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBox_npc7);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.textBox_npc1);
            this.tabPage3.Controls.Add(this.textBox_npc2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.textBox_npc3);
            this.tabPage3.HorizontalScrollbarBarColor = true;
            this.tabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage3.HorizontalScrollbarSize = 10;
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(503, 506);
            this.tabPage3.Style = JHUI.JColorStyle.Gold;
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "NPC";
            this.tabPage3.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage3.VerticalScrollbarBarColor = true;
            this.tabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage3.VerticalScrollbarSize = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.DropShadowColor = System.Drawing.Color.Black;
            this.label17.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label17.FontSize = JHUI.JLabelSize.Small;
            this.label17.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label17.Location = new System.Drawing.Point(298, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 15);
            this.label17.Style = JHUI.JColorStyle.Gold;
            this.label17.TabIndex = 51;
            this.label17.Text = "NPC8:";
            this.label17.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_npc8
            // 
            this.textBox_npc8.BorderBottomLineSize = 5;
            this.textBox_npc8.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc8.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc8.CustomButton.Image = null;
            this.textBox_npc8.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc8.CustomButton.Name = "";
            this.textBox_npc8.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc8.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc8.CustomButton.TabIndex = 1;
            this.textBox_npc8.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc8.CustomButton.UseSelectable = true;
            this.textBox_npc8.CustomButton.Visible = false;
            this.textBox_npc8.DrawBorder = true;
            this.textBox_npc8.DrawBorderBottomLine = false;
            this.textBox_npc8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc8.Lines = new string[0];
            this.textBox_npc8.Location = new System.Drawing.Point(369, 93);
            this.textBox_npc8.MaxLength = 32767;
            this.textBox_npc8.Name = "textBox_npc8";
            this.textBox_npc8.PasswordChar = '\0';
            this.textBox_npc8.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc8.SelectedText = "";
            this.textBox_npc8.SelectionLength = 0;
            this.textBox_npc8.SelectionStart = 0;
            this.textBox_npc8.ShortcutsEnabled = true;
            this.textBox_npc8.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc8.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc8.TabIndex = 50;
            this.textBox_npc8.TextWaterMark = "";
            this.textBox_npc8.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc8.UseCustomFont = true;
            this.textBox_npc8.UseSelectable = true;
            this.textBox_npc8.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc8.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc8.Leave += new System.EventHandler(this.changeNPC);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.DropShadowColor = System.Drawing.Color.Black;
            this.label14.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label14.FontSize = JHUI.JLabelSize.Small;
            this.label14.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label14.Location = new System.Drawing.Point(10, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 15);
            this.label14.Style = JHUI.JColorStyle.Gold;
            this.label14.TabIndex = 49;
            this.label14.Text = "NPC4:";
            this.label14.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_npc4
            // 
            this.textBox_npc4.BorderBottomLineSize = 5;
            this.textBox_npc4.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc4.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc4.CustomButton.Image = null;
            this.textBox_npc4.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc4.CustomButton.Name = "";
            this.textBox_npc4.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc4.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc4.CustomButton.TabIndex = 1;
            this.textBox_npc4.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc4.CustomButton.UseSelectable = true;
            this.textBox_npc4.CustomButton.Visible = false;
            this.textBox_npc4.DrawBorder = true;
            this.textBox_npc4.DrawBorderBottomLine = false;
            this.textBox_npc4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc4.Lines = new string[0];
            this.textBox_npc4.Location = new System.Drawing.Point(81, 92);
            this.textBox_npc4.MaxLength = 32767;
            this.textBox_npc4.Name = "textBox_npc4";
            this.textBox_npc4.PasswordChar = '\0';
            this.textBox_npc4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc4.SelectedText = "";
            this.textBox_npc4.SelectionLength = 0;
            this.textBox_npc4.SelectionStart = 0;
            this.textBox_npc4.ShortcutsEnabled = true;
            this.textBox_npc4.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc4.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc4.TabIndex = 48;
            this.textBox_npc4.TextWaterMark = "";
            this.textBox_npc4.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc4.UseCustomFont = true;
            this.textBox_npc4.UseSelectable = true;
            this.textBox_npc4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc4.Leave += new System.EventHandler(this.changeNPC);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DropShadowColor = System.Drawing.Color.Black;
            this.label4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label4.FontSize = JHUI.JLabelSize.Small;
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(298, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.Style = JHUI.JColorStyle.Gold;
            this.label4.TabIndex = 47;
            this.label4.Text = "NPC5:";
            this.label4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DropShadowColor = System.Drawing.Color.Black;
            this.label5.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label5.FontSize = JHUI.JLabelSize.Small;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(298, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.Style = JHUI.JColorStyle.Gold;
            this.label5.TabIndex = 46;
            this.label5.Text = "NPC6:";
            this.label5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_npc5
            // 
            this.textBox_npc5.BorderBottomLineSize = 5;
            this.textBox_npc5.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc5.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc5.CustomButton.Image = null;
            this.textBox_npc5.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc5.CustomButton.Name = "";
            this.textBox_npc5.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc5.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc5.CustomButton.TabIndex = 1;
            this.textBox_npc5.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc5.CustomButton.UseSelectable = true;
            this.textBox_npc5.CustomButton.Visible = false;
            this.textBox_npc5.DrawBorder = true;
            this.textBox_npc5.DrawBorderBottomLine = false;
            this.textBox_npc5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc5.Lines = new string[0];
            this.textBox_npc5.Location = new System.Drawing.Point(369, 13);
            this.textBox_npc5.MaxLength = 32767;
            this.textBox_npc5.Name = "textBox_npc5";
            this.textBox_npc5.PasswordChar = '\0';
            this.textBox_npc5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc5.SelectedText = "";
            this.textBox_npc5.SelectionLength = 0;
            this.textBox_npc5.SelectionStart = 0;
            this.textBox_npc5.ShortcutsEnabled = true;
            this.textBox_npc5.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc5.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc5.TabIndex = 45;
            this.textBox_npc5.TextWaterMark = "";
            this.textBox_npc5.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc5.UseCustomFont = true;
            this.textBox_npc5.UseSelectable = true;
            this.textBox_npc5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc5.Leave += new System.EventHandler(this.changeNPC);
            // 
            // textBox_npc6
            // 
            this.textBox_npc6.BorderBottomLineSize = 5;
            this.textBox_npc6.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc6.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc6.CustomButton.Image = null;
            this.textBox_npc6.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc6.CustomButton.Name = "";
            this.textBox_npc6.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc6.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc6.CustomButton.TabIndex = 1;
            this.textBox_npc6.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc6.CustomButton.UseSelectable = true;
            this.textBox_npc6.CustomButton.Visible = false;
            this.textBox_npc6.DrawBorder = true;
            this.textBox_npc6.DrawBorderBottomLine = false;
            this.textBox_npc6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc6.Lines = new string[0];
            this.textBox_npc6.Location = new System.Drawing.Point(369, 39);
            this.textBox_npc6.MaxLength = 32767;
            this.textBox_npc6.Name = "textBox_npc6";
            this.textBox_npc6.PasswordChar = '\0';
            this.textBox_npc6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc6.SelectedText = "";
            this.textBox_npc6.SelectionLength = 0;
            this.textBox_npc6.SelectionStart = 0;
            this.textBox_npc6.ShortcutsEnabled = true;
            this.textBox_npc6.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc6.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc6.TabIndex = 44;
            this.textBox_npc6.TextWaterMark = "";
            this.textBox_npc6.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc6.UseCustomFont = true;
            this.textBox_npc6.UseSelectable = true;
            this.textBox_npc6.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc6.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc6.Leave += new System.EventHandler(this.changeNPC);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DropShadowColor = System.Drawing.Color.Black;
            this.label6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label6.FontSize = JHUI.JLabelSize.Small;
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(298, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.Style = JHUI.JColorStyle.Gold;
            this.label6.TabIndex = 43;
            this.label6.Text = "NPC7:";
            this.label6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_npc7
            // 
            this.textBox_npc7.BorderBottomLineSize = 5;
            this.textBox_npc7.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc7.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc7.CustomButton.Image = null;
            this.textBox_npc7.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc7.CustomButton.Name = "";
            this.textBox_npc7.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc7.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc7.CustomButton.TabIndex = 1;
            this.textBox_npc7.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc7.CustomButton.UseSelectable = true;
            this.textBox_npc7.CustomButton.Visible = false;
            this.textBox_npc7.DrawBorder = true;
            this.textBox_npc7.DrawBorderBottomLine = false;
            this.textBox_npc7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc7.Lines = new string[0];
            this.textBox_npc7.Location = new System.Drawing.Point(369, 66);
            this.textBox_npc7.MaxLength = 32767;
            this.textBox_npc7.Name = "textBox_npc7";
            this.textBox_npc7.PasswordChar = '\0';
            this.textBox_npc7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc7.SelectedText = "";
            this.textBox_npc7.SelectionLength = 0;
            this.textBox_npc7.SelectionStart = 0;
            this.textBox_npc7.ShortcutsEnabled = true;
            this.textBox_npc7.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc7.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc7.TabIndex = 42;
            this.textBox_npc7.TextWaterMark = "";
            this.textBox_npc7.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc7.UseCustomFont = true;
            this.textBox_npc7.UseSelectable = true;
            this.textBox_npc7.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc7.Leave += new System.EventHandler(this.changeNPC);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DropShadowColor = System.Drawing.Color.Black;
            this.label3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label3.FontSize = JHUI.JLabelSize.Small;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.Style = JHUI.JColorStyle.Gold;
            this.label3.TabIndex = 41;
            this.label3.Text = "NPC1:";
            this.label3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DropShadowColor = System.Drawing.Color.Black;
            this.label2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.Style = JHUI.JColorStyle.Gold;
            this.label2.TabIndex = 40;
            this.label2.Text = "NPC2:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_npc1
            // 
            this.textBox_npc1.BorderBottomLineSize = 5;
            this.textBox_npc1.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc1.CustomButton.Image = null;
            this.textBox_npc1.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc1.CustomButton.Name = "";
            this.textBox_npc1.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc1.CustomButton.TabIndex = 1;
            this.textBox_npc1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc1.CustomButton.UseSelectable = true;
            this.textBox_npc1.CustomButton.Visible = false;
            this.textBox_npc1.DrawBorder = true;
            this.textBox_npc1.DrawBorderBottomLine = false;
            this.textBox_npc1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc1.Lines = new string[0];
            this.textBox_npc1.Location = new System.Drawing.Point(81, 13);
            this.textBox_npc1.MaxLength = 32767;
            this.textBox_npc1.Name = "textBox_npc1";
            this.textBox_npc1.PasswordChar = '\0';
            this.textBox_npc1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc1.SelectedText = "";
            this.textBox_npc1.SelectionLength = 0;
            this.textBox_npc1.SelectionStart = 0;
            this.textBox_npc1.ShortcutsEnabled = true;
            this.textBox_npc1.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc1.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc1.TabIndex = 39;
            this.textBox_npc1.TextWaterMark = "";
            this.textBox_npc1.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc1.UseCustomFont = true;
            this.textBox_npc1.UseSelectable = true;
            this.textBox_npc1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc1.Leave += new System.EventHandler(this.changeNPC);
            // 
            // textBox_npc2
            // 
            this.textBox_npc2.BorderBottomLineSize = 5;
            this.textBox_npc2.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc2.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc2.CustomButton.Image = null;
            this.textBox_npc2.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc2.CustomButton.Name = "";
            this.textBox_npc2.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc2.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc2.CustomButton.TabIndex = 1;
            this.textBox_npc2.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc2.CustomButton.UseSelectable = true;
            this.textBox_npc2.CustomButton.Visible = false;
            this.textBox_npc2.DrawBorder = true;
            this.textBox_npc2.DrawBorderBottomLine = false;
            this.textBox_npc2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc2.Lines = new string[0];
            this.textBox_npc2.Location = new System.Drawing.Point(81, 39);
            this.textBox_npc2.MaxLength = 32767;
            this.textBox_npc2.Name = "textBox_npc2";
            this.textBox_npc2.PasswordChar = '\0';
            this.textBox_npc2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc2.SelectedText = "";
            this.textBox_npc2.SelectionLength = 0;
            this.textBox_npc2.SelectionStart = 0;
            this.textBox_npc2.ShortcutsEnabled = true;
            this.textBox_npc2.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc2.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc2.TabIndex = 38;
            this.textBox_npc2.TextWaterMark = "";
            this.textBox_npc2.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc2.UseCustomFont = true;
            this.textBox_npc2.UseSelectable = true;
            this.textBox_npc2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc2.Leave += new System.EventHandler(this.changeNPC);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.Style = JHUI.JColorStyle.Gold;
            this.label1.TabIndex = 37;
            this.label1.Text = "NPC3:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_npc3
            // 
            this.textBox_npc3.BorderBottomLineSize = 5;
            this.textBox_npc3.BorderColor = System.Drawing.Color.Black;
            this.textBox_npc3.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_npc3.CustomButton.Image = null;
            this.textBox_npc3.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.textBox_npc3.CustomButton.Name = "";
            this.textBox_npc3.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_npc3.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_npc3.CustomButton.TabIndex = 1;
            this.textBox_npc3.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_npc3.CustomButton.UseSelectable = true;
            this.textBox_npc3.CustomButton.Visible = false;
            this.textBox_npc3.DrawBorder = true;
            this.textBox_npc3.DrawBorderBottomLine = false;
            this.textBox_npc3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc3.Lines = new string[0];
            this.textBox_npc3.Location = new System.Drawing.Point(81, 66);
            this.textBox_npc3.MaxLength = 32767;
            this.textBox_npc3.Name = "textBox_npc3";
            this.textBox_npc3.PasswordChar = '\0';
            this.textBox_npc3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_npc3.SelectedText = "";
            this.textBox_npc3.SelectionLength = 0;
            this.textBox_npc3.SelectionStart = 0;
            this.textBox_npc3.ShortcutsEnabled = true;
            this.textBox_npc3.Size = new System.Drawing.Size(124, 20);
            this.textBox_npc3.Style = JHUI.JColorStyle.Gold;
            this.textBox_npc3.TabIndex = 36;
            this.textBox_npc3.TextWaterMark = "";
            this.textBox_npc3.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_npc3.UseCustomFont = true;
            this.textBox_npc3.UseSelectable = true;
            this.textBox_npc3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_npc3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_npc3.Leave += new System.EventHandler(this.changeNPC);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage7.Controls.Add(this.buy_times_limit);
            this.tabPage7.Controls.Add(this.buy_times_limit_mode);
            this.tabPage7.Controls.Add(this.label23);
            this.tabPage7.Controls.Add(this.label18);
            this.tabPage7.HorizontalScrollbarBarColor = true;
            this.tabPage7.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage7.HorizontalScrollbarSize = 10;
            this.tabPage7.Location = new System.Drawing.Point(4, 38);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(503, 506);
            this.tabPage7.Style = JHUI.JColorStyle.Gold;
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Buy Limits";
            this.tabPage7.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage7.VerticalScrollbarBarColor = true;
            this.tabPage7.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage7.VerticalScrollbarSize = 10;
            // 
            // buy_times_limit
            // 
            this.buy_times_limit.BorderBottomLineSize = 5;
            this.buy_times_limit.BorderColor = System.Drawing.Color.Black;
            this.buy_times_limit.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.buy_times_limit.CustomButton.Image = null;
            this.buy_times_limit.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.buy_times_limit.CustomButton.Name = "";
            this.buy_times_limit.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.buy_times_limit.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.buy_times_limit.CustomButton.TabIndex = 1;
            this.buy_times_limit.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.buy_times_limit.CustomButton.UseSelectable = true;
            this.buy_times_limit.CustomButton.Visible = false;
            this.buy_times_limit.DrawBorder = true;
            this.buy_times_limit.DrawBorderBottomLine = false;
            this.buy_times_limit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.buy_times_limit.Lines = new string[0];
            this.buy_times_limit.Location = new System.Drawing.Point(80, 19);
            this.buy_times_limit.MaxLength = 32767;
            this.buy_times_limit.Name = "buy_times_limit";
            this.buy_times_limit.PasswordChar = '\0';
            this.buy_times_limit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.buy_times_limit.SelectedText = "";
            this.buy_times_limit.SelectionLength = 0;
            this.buy_times_limit.SelectionStart = 0;
            this.buy_times_limit.ShortcutsEnabled = true;
            this.buy_times_limit.Size = new System.Drawing.Size(124, 25);
            this.buy_times_limit.Style = JHUI.JColorStyle.Gold;
            this.buy_times_limit.TabIndex = 47;
            this.buy_times_limit.TextWaterMark = "";
            this.buy_times_limit.Theme = JHUI.JThemeStyle.Dark;
            this.buy_times_limit.UseCustomFont = true;
            this.buy_times_limit.UseSelectable = true;
            this.buy_times_limit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.buy_times_limit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.buy_times_limit.Leave += new System.EventHandler(this.buy_times_limit_Leave);
            // 
            // buy_times_limit_mode
            // 
            this.buy_times_limit_mode.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.buy_times_limit_mode.FontSize = JHUI.JComboBoxSize.Small;
            this.buy_times_limit_mode.FormattingEnabled = true;
            this.buy_times_limit_mode.ItemHeight = 19;
            this.buy_times_limit_mode.Items.AddRange(new object[] {
            "No Limit",
            "Per Day",
            "Per Week",
            "Per Month"});
            this.buy_times_limit_mode.Location = new System.Drawing.Point(369, 19);
            this.buy_times_limit_mode.Name = "buy_times_limit_mode";
            this.buy_times_limit_mode.Size = new System.Drawing.Size(121, 25);
            this.buy_times_limit_mode.Style = JHUI.JColorStyle.White;
            this.buy_times_limit_mode.TabIndex = 46;
            this.buy_times_limit_mode.Theme = JHUI.JThemeStyle.Dark;
            this.buy_times_limit_mode.UseSelectable = true;
            this.buy_times_limit_mode.SelectedIndexChanged += new System.EventHandler(this.buy_times_limit_mode_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.DropShadowColor = System.Drawing.Color.Black;
            this.label23.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label23.FontSize = JHUI.JLabelSize.Small;
            this.label23.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label23.Location = new System.Drawing.Point(286, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 15);
            this.label23.Style = JHUI.JColorStyle.Gold;
            this.label23.TabIndex = 45;
            this.label23.Text = "Limit Mode:";
            this.label23.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.DropShadowColor = System.Drawing.Color.Black;
            this.label18.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label18.FontSize = JHUI.JLabelSize.Small;
            this.label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label18.Location = new System.Drawing.Point(16, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 15);
            this.label18.Style = JHUI.JColorStyle.Gold;
            this.label18.TabIndex = 43;
            this.label18.Text = "Buy times:";
            this.label18.Theme = JHUI.JThemeStyle.Dark;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            jAnimation2.AnimateOnlyDifferences = false;
            jAnimation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation2.BlindCoeff")));
            jAnimation2.LeafCoeff = 0F;
            jAnimation2.MaxTime = 1F;
            jAnimation2.MinTime = 0F;
            jAnimation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation2.MosaicCoeff")));
            jAnimation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("jAnimation2.MosaicShift")));
            jAnimation2.MosaicSize = 0;
            jAnimation2.Padding = new System.Windows.Forms.Padding(0);
            jAnimation2.RotateCoeff = 0F;
            jAnimation2.RotateLimit = 0F;
            jAnimation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation2.ScaleCoeff")));
            jAnimation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation2.SlideCoeff")));
            jAnimation2.TimeCoeff = 1F;
            jAnimation2.TransparencyCoeff = 0F;
            this.tabControl2.ChangeAnimation = jAnimation2;
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(23, 574);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(6, 8);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(921, 112);
            this.tabControl2.Style = JHUI.JColorStyle.Gold;
            this.tabControl2.TabIndex = 40;
            this.tabControl2.Theme = JHUI.JThemeStyle.Dark;
            this.tabControl2.UseSelectable = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage6.Controls.Add(this.jTextBox1);
            this.tabPage6.Controls.Add(this.jLabel2);
            this.tabPage6.Controls.Add(this.pathLabel);
            this.tabPage6.Controls.Add(this.version_label);
            this.tabPage6.Controls.Add(this.jLabel1);
            this.tabPage6.Controls.Add(this.jCheckBox1);
            this.tabPage6.Controls.Add(this.replaceWithTextBox);
            this.tabPage6.Controls.Add(this.jPictureBox5);
            this.tabPage6.Controls.Add(this.textBox_search);
            this.tabPage6.Controls.Add(this.checkBox1);
            this.tabPage6.Controls.Add(this.fieldscomboBox);
            this.tabPage6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage6.HorizontalScrollbarBarColor = true;
            this.tabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage6.HorizontalScrollbarSize = 10;
            this.tabPage6.Location = new System.Drawing.Point(4, 38);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(913, 70);
            this.tabPage6.Style = JHUI.JColorStyle.Gold;
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Miscellaneous";
            this.tabPage6.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage6.VerticalScrollbarBarColor = true;
            this.tabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage6.VerticalScrollbarSize = 10;
            // 
            // jTextBox1
            // 
            this.jTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jTextBox1.BorderBottomLineSize = 5;
            this.jTextBox1.BorderColor = System.Drawing.Color.Black;
            this.jTextBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(82, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.DrawBorder = true;
            this.jTextBox1.DrawBorderBottomLine = false;
            this.jTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.Lines = new string[] {
        "*"};
            this.jTextBox1.Location = new System.Drawing.Point(660, 14);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(106, 25);
            this.jTextBox1.Style = JHUI.JColorStyle.White;
            this.jTextBox1.TabIndex = 51;
            this.jTextBox1.Text = "*";
            this.jTextBox1.TextWaterMark = "Old Value";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomFont = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // jLabel2
            // 
            this.jLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jLabel2.AutoSize = true;
            this.jLabel2.CausesValidation = false;
            this.jLabel2.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.jLabel2.Location = new System.Drawing.Point(197, 57);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(32, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Gold;
            this.jLabel2.TabIndex = 49;
            this.jLabel2.Text = "Path:";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // pathLabel
            // 
            this.pathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pathLabel.AutoSize = true;
            this.pathLabel.CausesValidation = false;
            this.pathLabel.DropShadowColor = System.Drawing.Color.Black;
            this.pathLabel.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.pathLabel.FontSize = JHUI.JLabelSize.Small;
            this.pathLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pathLabel.Location = new System.Drawing.Point(279, 56);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pathLabel.Size = new System.Drawing.Size(181, 15);
            this.pathLabel.Style = JHUI.JColorStyle.Gold;
            this.pathLabel.TabIndex = 50;
            this.pathLabel.Text = "F:\\Blue-Dragon\\data\\element.data";
            this.pathLabel.Theme = JHUI.JThemeStyle.Dark;
            // 
            // version_label
            // 
            this.version_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version_label.AutoSize = true;
            this.version_label.CausesValidation = false;
            this.version_label.DropShadowColor = System.Drawing.Color.Black;
            this.version_label.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.version_label.FontSize = JHUI.JLabelSize.Small;
            this.version_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.version_label.Location = new System.Drawing.Point(279, 37);
            this.version_label.Name = "version_label";
            this.version_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.version_label.Size = new System.Drawing.Size(13, 15);
            this.version_label.Style = JHUI.JColorStyle.Gold;
            this.version_label.TabIndex = 47;
            this.version_label.Text = "0";
            this.version_label.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel1
            // 
            this.jLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jLabel1.AutoSize = true;
            this.jLabel1.CausesValidation = false;
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.jLabel1.Location = new System.Drawing.Point(196, 37);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(46, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 48;
            this.jLabel1.Text = "Version:";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jCheckBox1
            // 
            this.jCheckBox1.AutoSize = true;
            this.jCheckBox1.Location = new System.Drawing.Point(6, 49);
            this.jCheckBox1.Name = "jCheckBox1";
            this.jCheckBox1.Size = new System.Drawing.Size(98, 15);
            this.jCheckBox1.Style = JHUI.JColorStyle.Gold;
            this.jCheckBox1.TabIndex = 46;
            this.jCheckBox1.Text = "Case-sensitive";
            this.jCheckBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox1.UseSelectable = true;
            this.jCheckBox1.UseVisualStyleBackColor = true;
            // 
            // replaceWithTextBox
            // 
            this.replaceWithTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceWithTextBox.BorderBottomLineSize = 5;
            this.replaceWithTextBox.BorderColor = System.Drawing.Color.Black;
            this.replaceWithTextBox.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.replaceWithTextBox.CustomButton.Image = global::PWDataEditorPaied.Properties.Resources.OK;
            this.replaceWithTextBox.CustomButton.Location = new System.Drawing.Point(82, 1);
            this.replaceWithTextBox.CustomButton.Name = "";
            this.replaceWithTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.replaceWithTextBox.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.replaceWithTextBox.CustomButton.TabIndex = 1;
            this.replaceWithTextBox.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.replaceWithTextBox.CustomButton.UseSelectable = true;
            this.replaceWithTextBox.DrawBorder = true;
            this.replaceWithTextBox.DrawBorderBottomLine = false;
            this.replaceWithTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.replaceWithTextBox.Lines = new string[0];
            this.replaceWithTextBox.Location = new System.Drawing.Point(768, 14);
            this.replaceWithTextBox.MaxLength = 32767;
            this.replaceWithTextBox.Name = "replaceWithTextBox";
            this.replaceWithTextBox.PasswordChar = '\0';
            this.replaceWithTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.replaceWithTextBox.SelectedText = "";
            this.replaceWithTextBox.SelectionLength = 0;
            this.replaceWithTextBox.SelectionStart = 0;
            this.replaceWithTextBox.ShortcutsEnabled = true;
            this.replaceWithTextBox.ShowButton = true;
            this.replaceWithTextBox.Size = new System.Drawing.Size(106, 25);
            this.replaceWithTextBox.Style = JHUI.JColorStyle.Gold;
            this.replaceWithTextBox.TabIndex = 45;
            this.replaceWithTextBox.TextWaterMark = "New Value";
            this.replaceWithTextBox.Theme = JHUI.JThemeStyle.Dark;
            this.replaceWithTextBox.UseCustomFont = true;
            this.replaceWithTextBox.UseSelectable = true;
            this.replaceWithTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.replaceWithTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.replaceWithTextBox.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.globalUpdateField);
            // 
            // jPictureBox5
            // 
            this.jPictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox5.BackgroundImage")));
            this.jPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox5.ContextMenuStrip = this.ToolBox;
            this.jPictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox5.Location = new System.Drawing.Point(881, 14);
            this.jPictureBox5.Name = "jPictureBox5";
            this.jPictureBox5.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox5.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox5.TabIndex = 44;
            this.jPictureBox5.TabStop = false;
            this.jPictureBox5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox_search
            // 
            this.textBox_search.BorderBottomLineSize = 5;
            this.textBox_search.BorderColor = System.Drawing.Color.Black;
            this.textBox_search.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_search.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.textBox_search.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.textBox_search.CustomButton.Name = "";
            this.textBox_search.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.textBox_search.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_search.CustomButton.TabIndex = 1;
            this.textBox_search.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_search.CustomButton.UseSelectable = true;
            this.textBox_search.DrawBorder = true;
            this.textBox_search.DrawBorderBottomLine = false;
            this.textBox_search.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_search.FontSize = JHUI.JTextBoxSize.Medium;
            this.textBox_search.Lines = new string[0];
            this.textBox_search.Location = new System.Drawing.Point(6, 14);
            this.textBox_search.MaxLength = 32767;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.PasswordChar = '\0';
            this.textBox_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_search.SelectedText = "";
            this.textBox_search.SelectionLength = 0;
            this.textBox_search.SelectionStart = 0;
            this.textBox_search.ShortcutsEnabled = true;
            this.textBox_search.ShowButton = true;
            this.textBox_search.Size = new System.Drawing.Size(185, 29);
            this.textBox_search.Style = JHUI.JColorStyle.Gold;
            this.textBox_search.TabIndex = 43;
            this.textBox_search.TextWaterMark = "Search...";
            this.textBox_search.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_search.UseCustomFont = true;
            this.textBox_search.UseSelectable = true;
            this.textBox_search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_search.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.search);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(530, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 15);
            this.checkBox1.Style = JHUI.JColorStyle.Gold;
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Update Only Selected items";
            this.checkBox1.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox1.UseSelectable = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fieldscomboBox
            // 
            this.fieldscomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldscomboBox.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.fieldscomboBox.FontSize = JHUI.JComboBoxSize.Small;
            this.fieldscomboBox.FormattingEnabled = true;
            this.fieldscomboBox.ItemHeight = 19;
            this.fieldscomboBox.Items.AddRange(new object[] {
            "Cant",
            "Activation Date",
            "Expire Date",
            "Duration",
            "Day",
            "Price"});
            this.fieldscomboBox.Location = new System.Drawing.Point(530, 14);
            this.fieldscomboBox.Name = "fieldscomboBox";
            this.fieldscomboBox.Size = new System.Drawing.Size(127, 25);
            this.fieldscomboBox.Style = JHUI.JColorStyle.Gold;
            this.fieldscomboBox.TabIndex = 39;
            this.fieldscomboBox.Theme = JHUI.JThemeStyle.Dark;
            this.fieldscomboBox.UseSelectable = true;
            // 
            // listBox_items
            // 
            this.listBox_items.AllowDrop = true;
            this.listBox_items.AllowUserToAddRows = false;
            this.listBox_items.AllowUserToDeleteRows = false;
            this.listBox_items.AllowUserToResizeColumns = false;
            this.listBox_items.AllowUserToResizeRows = false;
            this.listBox_items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_items.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_items.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listBox_items.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listBox_items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listBox_items.ColumnHeadersHeight = 22;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowId,
            this.dataGridViewTextBoxColumn1,
            this.Column2});
            this.listBox_items.ContextMenuStrip = this.Menu_Item;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle2;
            this.listBox_items.EnableHeadersVisualStyles = false;
            this.listBox_items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.Location = new System.Drawing.Point(165, 57);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(270, 526);
            this.listBox_items.Style = JHUI.JColorStyle.Gold;
            this.listBox_items.TabIndex = 41;
            this.listBox_items.Theme = JHUI.JThemeStyle.Dark;
            this.listBox_items.VirtualMode = true;
            this.listBox_items.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellMouseEnter);
            this.listBox_items.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellMouseLeave);
            this.listBox_items.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listBox_items_CellMouseMove);
            this.listBox_items.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.listBox_items_CellValueNeeded);
            this.listBox_items.SelectionChanged += new System.EventHandler(this.change_item);
            this.listBox_items.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_items_DragEnter);
            this.listBox_items.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox_items_DragOver);
            this.listBox_items.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_items_KeyDown);
            // 
            // RowId
            // 
            this.RowId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RowId.Frozen = true;
            this.RowId.HeaderText = "SId";
            this.RowId.Name = "RowId";
            this.RowId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowId.Width = 27;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "IId";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 115.4045F;
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox2.ContextMenuStrip = this.SaveMenu;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(195, 29);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox2.TabIndex = 43;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.SaveShopClick);
            // 
            // SaveMenu
            // 
            this.SaveMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveUsToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(117, 48);
            this.SaveMenu.Style = JHUI.JColorStyle.Gold;
            this.SaveMenu.Theme = JHUI.JThemeStyle.Dark;
            // 
            // saveUsToolStripMenuItem
            // 
            this.saveUsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionSelector,
            this.doItToolStripMenuItem2});
            this.saveUsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Save1;
            this.saveUsToolStripMenuItem.Name = "saveUsToolStripMenuItem";
            this.saveUsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveUsToolStripMenuItem.Text = "Convert";
            // 
            // versionSelector
            // 
            this.versionSelector.Items.AddRange(new object[] {
            "Version:1.54 ++",
            "Version:1.40 ++",
            "Version:1.36 ++"});
            this.versionSelector.Name = "versionSelector";
            this.versionSelector.Size = new System.Drawing.Size(121, 23);
            this.versionSelector.SelectedIndexChanged += new System.EventHandler(this.versionSelector_SelectedIndexChanged);
            // 
            // doItToolStripMenuItem2
            // 
            this.doItToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Save1;
            this.doItToolStripMenuItem2.Name = "doItToolStripMenuItem2";
            this.doItToolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.doItToolStripMenuItem2.Text = "Do it";
            this.doItToolStripMenuItem2.Click += new System.EventHandler(this.SaveUSClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Save1;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveQUSClick);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.ContextMenuStrip = this.jContextMenu1;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(166, 29);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox1.TabIndex = 42;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.LoadShopClick);
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.jContextMenu1.Name = "ToolBox";
            this.jContextMenu1.Size = new System.Drawing.Size(139, 26);
            this.jContextMenu1.Style = JHUI.JColorStyle.Gold;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sevToolStripMenuItem,
            this.sevToolStripMenuItem1,
            this.toolStripMenuItem5});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.testToolStripMenuItem.Text = "Open Server";
            // 
            // sevToolStripMenuItem
            // 
            this.sevToolStripMenuItem.Name = "sevToolStripMenuItem";
            this.sevToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.sevToolStripMenuItem.Text = "136++";
            this.sevToolStripMenuItem.Click += new System.EventHandler(this.sevToolStripMenuItem_Click);
            // 
            // sevToolStripMenuItem1
            // 
            this.sevToolStripMenuItem1.Name = "sevToolStripMenuItem1";
            this.sevToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.sevToolStripMenuItem1.Text = "140++";
            this.sevToolStripMenuItem1.Click += new System.EventHandler(this.sevToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem5.Text = "154++";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // MoveUpDown
            // 
            this.MoveUpDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.MoveUpDown.Name = "MoveUpDown";
            this.MoveUpDown.Size = new System.Drawing.Size(139, 48);
            this.MoveUpDown.Style = JHUI.JColorStyle.Gold;
            this.MoveUpDown.Theme = JHUI.JThemeStyle.Dark;
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Up1;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addToolStripMenuItem.Text = "Move Up";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.moveUplistBox_Cats);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Down1;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.deleteToolStripMenuItem.Text = "Move Down";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.moveUplistBox_Cats);
            // 
            // listBox_Cats
            // 
            this.listBox_Cats.AllowUserToAddRows = false;
            this.listBox_Cats.AllowUserToDeleteRows = false;
            this.listBox_Cats.AllowUserToResizeColumns = false;
            this.listBox_Cats.AllowUserToResizeRows = false;
            this.listBox_Cats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_Cats.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_Cats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Cats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listBox_Cats.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listBox_Cats.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_Cats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listBox_Cats.ColumnHeadersHeight = 22;
            this.listBox_Cats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_Cats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.listBox_Cats.ContextMenuStrip = this.MoveUpDown;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_Cats.DefaultCellStyle = dataGridViewCellStyle5;
            this.listBox_Cats.EnableHeadersVisualStyles = false;
            this.listBox_Cats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_Cats.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_Cats.Location = new System.Drawing.Point(23, 57);
            this.listBox_Cats.MultiSelect = false;
            this.listBox_Cats.Name = "listBox_Cats";
            this.listBox_Cats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_Cats.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.listBox_Cats.RowHeadersVisible = false;
            this.listBox_Cats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_Cats.RowTemplate.Height = 15;
            this.listBox_Cats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.listBox_Cats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_Cats.Size = new System.Drawing.Size(136, 245);
            this.listBox_Cats.Style = JHUI.JColorStyle.Gold;
            this.listBox_Cats.TabIndex = 46;
            this.listBox_Cats.Theme = JHUI.JThemeStyle.Dark;
            this.listBox_Cats.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.rename_cat);
            this.listBox_Cats.SelectionChanged += new System.EventHandler(this.listBox_Cats_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 1F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Category";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // listBox_SubCats
            // 
            this.listBox_SubCats.AllowUserToAddRows = false;
            this.listBox_SubCats.AllowUserToDeleteRows = false;
            this.listBox_SubCats.AllowUserToResizeColumns = false;
            this.listBox_SubCats.AllowUserToResizeRows = false;
            this.listBox_SubCats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_SubCats.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_SubCats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_SubCats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listBox_SubCats.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listBox_SubCats.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_SubCats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.listBox_SubCats.ColumnHeadersHeight = 22;
            this.listBox_SubCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_SubCats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.listBox_SubCats.ContextMenuStrip = this.MenuSubCat;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_SubCats.DefaultCellStyle = dataGridViewCellStyle8;
            this.listBox_SubCats.EnableHeadersVisualStyles = false;
            this.listBox_SubCats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_SubCats.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_SubCats.Location = new System.Drawing.Point(23, 308);
            this.listBox_SubCats.MultiSelect = false;
            this.listBox_SubCats.Name = "listBox_SubCats";
            this.listBox_SubCats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_SubCats.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.listBox_SubCats.RowHeadersVisible = false;
            this.listBox_SubCats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_SubCats.RowTemplate.Height = 15;
            this.listBox_SubCats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.listBox_SubCats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_SubCats.Size = new System.Drawing.Size(136, 281);
            this.listBox_SubCats.Style = JHUI.JColorStyle.Gold;
            this.listBox_SubCats.TabIndex = 47;
            this.listBox_SubCats.Theme = JHUI.JThemeStyle.Dark;
            this.listBox_SubCats.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.rename_subcat);
            this.listBox_SubCats.SelectionChanged += new System.EventHandler(this.listBox_SubCats_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 1F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Subcategory";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBox_timestamp
            // 
            this.textBox_timestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_timestamp.AutoSize = true;
            this.textBox_timestamp.DropShadowColor = System.Drawing.Color.Black;
            this.textBox_timestamp.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.textBox_timestamp.FontSize = JHUI.JLabelSize.Small;
            this.textBox_timestamp.Location = new System.Drawing.Point(783, 30);
            this.textBox_timestamp.Name = "textBox_timestamp";
            this.textBox_timestamp.Size = new System.Drawing.Size(106, 15);
            this.textBox_timestamp.Style = JHUI.JColorStyle.Gold;
            this.textBox_timestamp.TabIndex = 48;
            this.textBox_timestamp.Text = "2016-07-31 00:28:30";
            this.textBox_timestamp.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jPictureBox3
            // 
            this.jPictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox3.BackgroundImage")));
            this.jPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox3.ContextMenuStrip = this.SaveMenu;
            this.jPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox3.Location = new System.Drawing.Point(911, 29);
            this.jPictureBox3.Name = "jPictureBox3";
            this.jPictureBox3.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox3.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox3.TabIndex = 49;
            this.jPictureBox3.TabStop = false;
            this.jPictureBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox3.Click += new System.EventHandler(this.click_get_timestamp);
            // 
            // GameShopEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jPictureBox3);
            this.Controls.Add(this.textBox_timestamp);
            this.Controls.Add(this.listBox_SubCats);
            this.Controls.Add(this.listBox_Cats);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.listBox_items);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GameShopEditor";
            this.Opacity = 0D;
            this.Style = JHUI.JColorStyle.Gold;
            this.Text = "GShop Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameShopEditor_FormClosing);
            this.Load += new System.EventHandler(this.GameShopEditor_Load);
            this.Shown += new System.EventHandler(this.GameShopEditor_Shown);
            this.Menu_Item.ResumeLayout(false);
            this.MenuSubCat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_log_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_gift_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_gift_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_surface)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).EndInit();
            this.ToolBox.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            this.SaveMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.jContextMenu1.ResumeLayout(false);
            this.MoveUpDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBox_Cats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_SubCats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private JLabel label22;
        private JLabel label21;
        private JNumericUpDown numericUpDown_log_price;
        private JNumericUpDown numericUpDown_gift_amount;
        private JTextBox textBox_gift_duration;
        private JLabel label20;
        private JNumericUpDown numericUpDown_gift_id;
        private JLabel label19;
        private JTextBox textBox_name;
        private JTextBox textBox_description;
        private JPictureBox pictureBox_surface;
        private JTabControl tabControl1;
        private JTabPage tabPage1;
        private JTabPage tabPage2;
        private JTabPage tabPage3;
        private JTabControl tabControl2;
        private System.Windows.Forms.RichTextBox richTextBox_PreviewText;
        private System.Windows.Forms.ContextMenuStrip MenuSubCat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_moveCat;
        private JContextMenu Menu_Item;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_moveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exportItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importItemsToolStripMenuItem;
        private JLabel label4;
        private JLabel label5;
        private JTextBox textBox_npc5;
        private JTextBox textBox_npc6;
        private JLabel label6;
        private JTextBox textBox_npc7;
        private JLabel label3;
        private JLabel label2;
        private JTextBox textBox_npc1;
        private JTextBox textBox_npc2;
        private JLabel label1;
        private JTextBox textBox_npc3;
        private JLabel label17;
        private JTextBox textBox_npc8;
        private JLabel label14;
        private JTextBox textBox_npc4;
        private JTabPage tabPage6;
        private JComboBox fieldscomboBox;
        private JCheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox4;
        private JCheckBox checkBox_active;
        private JTextBox textBox_flags;
        private JLabel label13;
        private JTextBox textBox_day;
        private JLabel label16;
        private JComboBox comboBox_type;
        private JLabel label9;
        private System.Windows.Forms.GroupBox groupBox7;
        private JDateTime textBox_start_date;
        private JLabel label12;
        private JDateTime textBox_end_date;
        private JLabel label10;
        private JLabel label11;
        private JTextBox textBox_duration;
        private System.Windows.Forms.GroupBox groupBox6;
        private JNumericUpDown numericUpDown_amount;
        private JLabel label7;
        private JLabel label8;
        private JComboBox comboBox_status;
        private JNumericUpDown numericUpDown_price;
        private JLabel label15;
        private JTabPage tabPage4;
        private JTabPage tabPage7;
        private JDataGridView listBox_items;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private JTextBox textBox_search;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markAsNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markAsNewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem markAsHotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changePriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem doItToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comboBox_dbSource;
        private System.Windows.Forms.ToolStripMenuItem doItToolStripMenuItem1;
        private JPictureBox jPictureBox2;
        private JPictureBox jPictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private JContextMenu MoveUpDown;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private JContextMenu SaveMenu;
        private System.Windows.Forms.ToolStripMenuItem saveUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox versionSelector;
        private System.Windows.Forms.ToolStripMenuItem doItToolStripMenuItem2;
        private JDataGridView listBox_Cats;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private JDataGridView listBox_SubCats;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private JPictureBox jPictureBox5;
        private JContextMenu ToolBox;
        private System.Windows.Forms.ToolStripMenuItem controlTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox MultiplyValueText;
        private System.Windows.Forms.ToolStripMenuItem devideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplyToolStripMenuItem;
        private JTextBox replaceWithTextBox;
        private JLabel textBox_timestamp;
        private JPictureBox jPictureBox3;
        private JCheckBox jCheckBox1;
        private JPictureBox jPictureBox4;
        private JTextBox comboBox_surface;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectInElementsToolStripMenuItem;
        private JLabel label18;
        private JContextMenu jContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sevToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private JLabel jLabel2;
        private JLabel pathLabel;
        private JLabel version_label;
        private JLabel jLabel1;
        private JTextBox jTextBox1;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem deleteIfNotExistInShopToolStripMenuItem;
        private JComboBox buy_times_limit_mode;
        private JTextBox buy_times_limit;
        private JLabel label23;
        private JTextBox numericUpDown_itemID;
        private ToolStripMenuItem removeInexistentItemsToolStripMenuItem;
        private ToolStripMenuItem autoFixShopToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
    }
}