using JHUI.Controls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementsEditor));
            JHUI.JAnimation jAnimation1 = new JHUI.JAnimation();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            JHUI.JAnimation jAnimation2 = new JHUI.JAnimation();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.findDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.dropSelectedAddonFasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateDropsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateTotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateAdonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateRandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSumeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.pathFixerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listbox_items_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.asignNewIdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.makeRecipesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reforgeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.sortIdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idAscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.makePetEggToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyPetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PastePetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_lists = new JHUI.Controls.JComboBox();
            this.BookMarks = new JHUI.Controls.JContextMenu(this.components);
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configEditorExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSkillsToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readListDEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caseSensitiveCheckbox = new JHUI.Controls.JCheckBox();
            this.searchInput1 = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.version_label = new JHUI.Controls.JLabel();
            this.row_editor_context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementIntoTab = new JHUI.Controls.JTabControl();
            this.Edit = new JHUI.Controls.JTabPage();
            this.dataGridView_item = new JHUI.Controls.JDataGridView();
            this.RowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleTab = new JHUI.Controls.JTabPage();
            this.groupBox4 = new JHUI.Controls.JGroupBox();
            this.button10 = new JHUI.Controls.JButton();
            this.textBox2 = new JHUI.Controls.JTextBox();
            this.tab_salebtn_1 = new JHUI.Controls.JButton();
            this.tab_salebtn_5 = new JHUI.Controls.JButton();
            this.tab_salebtn_2 = new JHUI.Controls.JButton();
            this.tab_salebtn_8 = new JHUI.Controls.JButton();
            this.tab_salebtn_3 = new JHUI.Controls.JButton();
            this.tab_salebtn_7 = new JHUI.Controls.JButton();
            this.tab_salebtn_4 = new JHUI.Controls.JButton();
            this.tab_salebtn_6 = new JHUI.Controls.JButton();
            this.groupBox1 = new JHUI.Controls.JGroupBox();
            this.checkBox1 = new JHUI.Controls.JCheckBox();
            this.label_item_32 = new JHUI.Controls.JLabel();
            this.label_item_31 = new JHUI.Controls.JLabel();
            this.label_item_30 = new JHUI.Controls.JLabel();
            this.label_item_29 = new JHUI.Controls.JLabel();
            this.label_item_28 = new JHUI.Controls.JLabel();
            this.label_item_27 = new JHUI.Controls.JLabel();
            this.label_item_26 = new JHUI.Controls.JLabel();
            this.label_item_25 = new JHUI.Controls.JLabel();
            this.label_item_24 = new JHUI.Controls.JLabel();
            this.label_item_23 = new JHUI.Controls.JLabel();
            this.label_item_22 = new JHUI.Controls.JLabel();
            this.label_item_21 = new JHUI.Controls.JLabel();
            this.label_item_20 = new JHUI.Controls.JLabel();
            this.label_item_19 = new JHUI.Controls.JLabel();
            this.label_item_18 = new JHUI.Controls.JLabel();
            this.label_item_17 = new JHUI.Controls.JLabel();
            this.label_item_16 = new JHUI.Controls.JLabel();
            this.label_item_15 = new JHUI.Controls.JLabel();
            this.label_item_14 = new JHUI.Controls.JLabel();
            this.label_item_13 = new JHUI.Controls.JLabel();
            this.label_item_12 = new JHUI.Controls.JLabel();
            this.label_item_11 = new JHUI.Controls.JLabel();
            this.label_item_10 = new JHUI.Controls.JLabel();
            this.label_item_9 = new JHUI.Controls.JLabel();
            this.label_item_8 = new JHUI.Controls.JLabel();
            this.label_item_7 = new JHUI.Controls.JLabel();
            this.label_item_6 = new JHUI.Controls.JLabel();
            this.label_item_5 = new JHUI.Controls.JLabel();
            this.label_item_4 = new JHUI.Controls.JLabel();
            this.label_item_3 = new JHUI.Controls.JLabel();
            this.label_item_2 = new JHUI.Controls.JLabel();
            this.label_item_1 = new JHUI.Controls.JLabel();
            this.button8 = new JHUI.Controls.JButton();
            this.textBox1 = new JHUI.Controls.JTextBox();
            this.picture_item_32 = new JHUI.Controls.JPictureBox();
            this.contextMenuStripSalePreview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.picture_item_31 = new JHUI.Controls.JPictureBox();
            this.picture_item_30 = new JHUI.Controls.JPictureBox();
            this.picture_item_29 = new JHUI.Controls.JPictureBox();
            this.picture_item_28 = new JHUI.Controls.JPictureBox();
            this.picture_item_27 = new JHUI.Controls.JPictureBox();
            this.picture_item_26 = new JHUI.Controls.JPictureBox();
            this.picture_item_25 = new JHUI.Controls.JPictureBox();
            this.picture_item_24 = new JHUI.Controls.JPictureBox();
            this.picture_item_23 = new JHUI.Controls.JPictureBox();
            this.picture_item_22 = new JHUI.Controls.JPictureBox();
            this.picture_item_21 = new JHUI.Controls.JPictureBox();
            this.picture_item_20 = new JHUI.Controls.JPictureBox();
            this.picture_item_19 = new JHUI.Controls.JPictureBox();
            this.picture_item_18 = new JHUI.Controls.JPictureBox();
            this.picture_item_17 = new JHUI.Controls.JPictureBox();
            this.picture_item_16 = new JHUI.Controls.JPictureBox();
            this.picture_item_15 = new JHUI.Controls.JPictureBox();
            this.picture_item_14 = new JHUI.Controls.JPictureBox();
            this.picture_item_13 = new JHUI.Controls.JPictureBox();
            this.picture_item_12 = new JHUI.Controls.JPictureBox();
            this.picture_item_11 = new JHUI.Controls.JPictureBox();
            this.picture_item_10 = new JHUI.Controls.JPictureBox();
            this.picture_item_9 = new JHUI.Controls.JPictureBox();
            this.picture_item_8 = new JHUI.Controls.JPictureBox();
            this.picture_item_7 = new JHUI.Controls.JPictureBox();
            this.picture_item_6 = new JHUI.Controls.JPictureBox();
            this.picture_item_5 = new JHUI.Controls.JPictureBox();
            this.picture_item_4 = new JHUI.Controls.JPictureBox();
            this.picture_item_3 = new JHUI.Controls.JPictureBox();
            this.picture_item_2 = new JHUI.Controls.JPictureBox();
            this.picture_item_1 = new JHUI.Controls.JPictureBox();
            this.craftTab = new JHUI.Controls.JTabPage();
            this.button9 = new JHUI.Controls.JButton();
            this.textBox3 = new JHUI.Controls.JTextBox();
            this.tab_craftbtn_8 = new JHUI.Controls.JButton();
            this.tab_craftbtn_5 = new JHUI.Controls.JButton();
            this.tab_craftbtn_7 = new JHUI.Controls.JButton();
            this.tab_craftbtn_1 = new JHUI.Controls.JButton();
            this.tab_craftbtn_6 = new JHUI.Controls.JButton();
            this.tab_craftbtn_2 = new JHUI.Controls.JButton();
            this.tab_craftbtn_3 = new JHUI.Controls.JButton();
            this.tab_craftbtn_4 = new JHUI.Controls.JButton();
            this.groupBox11 = new JHUI.Controls.JGroupBox();
            this.label2 = new JHUI.Controls.JLabel();
            this.textBox20 = new JHUI.Controls.JTextBox();
            this.textBox16 = new JHUI.Controls.JTextBox();
            this.label29 = new JHUI.Controls.JLabel();
            this.textBox17 = new JHUI.Controls.JTextBox();
            this.textBox19 = new JHUI.Controls.JTextBox();
            this.label28 = new JHUI.Controls.JLabel();
            this.textBox13 = new JHUI.Controls.JTextBox();
            this.textBox14 = new JHUI.Controls.JTextBox();
            this.textBox11 = new JHUI.Controls.JTextBox();
            this.textBox10 = new JHUI.Controls.JTextBox();
            this.textBox8 = new JHUI.Controls.JTextBox();
            this.textBox6 = new JHUI.Controls.JTextBox();
            this.pictureBox44 = new JHUI.Controls.JPictureBox();
            this.pictureBox43 = new JHUI.Controls.JPictureBox();
            this.pictureBox42 = new JHUI.Controls.JPictureBox();
            this.textBox24 = new JHUI.Controls.JTextBox();
            this.label33 = new JHUI.Controls.JLabel();
            this.pictureBox41 = new JHUI.Controls.JPictureBox();
            this.textBox22 = new JHUI.Controls.JTextBox();
            this.label31 = new JHUI.Controls.JLabel();
            this.textBox21 = new JHUI.Controls.JTextBox();
            this.label30 = new JHUI.Controls.JLabel();
            this.textBox18 = new JHUI.Controls.JTextBox();
            this.label27 = new JHUI.Controls.JLabel();
            this.textBox15 = new JHUI.Controls.JTextBox();
            this.label26 = new JHUI.Controls.JLabel();
            this.textBox12 = new JHUI.Controls.JTextBox();
            this.label25 = new JHUI.Controls.JLabel();
            this.textBox9 = new JHUI.Controls.JTextBox();
            this.label24 = new JHUI.Controls.JLabel();
            this.comboBox2 = new JHUI.Controls.JComboBox();
            this.label23 = new JHUI.Controls.JLabel();
            this.label20 = new JHUI.Controls.JLabel();
            this.comboBox1 = new JHUI.Controls.JComboBox();
            this.label17 = new JHUI.Controls.JLabel();
            this.label8 = new JHUI.Controls.JLabel();
            this.button12 = new JHUI.Controls.JButton();
            this.label6 = new JHUI.Controls.JLabel();
            this.groupBox10 = new JHUI.Controls.JGroupBox();
            this.button14 = new JHUI.Controls.JButton();
            this.button11 = new JHUI.Controls.JButton();
            this.label4 = new JHUI.Controls.JLabel();
            this.label3 = new JHUI.Controls.JLabel();
            this.textBox5 = new JHUI.Controls.JTextBox();
            this.pictureBox_craft_req_5 = new JHUI.Controls.JPictureBox();
            this.textBox4 = new JHUI.Controls.JTextBox();
            this.pictureBox_craft_req_4 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_req_8 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_req_3 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_req_6 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_req_7 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_req_2 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_req_1 = new JHUI.Controls.JPictureBox();
            this.groupBox8 = new JHUI.Controls.JGroupBox();
            this.button13 = new JHUI.Controls.JButton();
            this.label5 = new JHUI.Controls.JLabel();
            this.textBox7 = new JHUI.Controls.JTextBox();
            this.pictureBox_craft_32 = new JHUI.Controls.JPictureBox();
            this.contextMenuStripproduce = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_craft_31 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_30 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_29 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_28 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_27 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_26 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_25 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_24 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_23 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_22 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_21 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_20 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_19 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_18 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_17 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_16 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_15 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_14 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_13 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_12 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_11 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_10 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_9 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_8 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_7 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_6 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_5 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_4 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_3 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_2 = new JHUI.Controls.JPictureBox();
            this.pictureBox_craft_1 = new JHUI.Controls.JPictureBox();
            this.tabPage4 = new JHUI.Controls.JTabPage();
            this.jGroupBox2 = new JHUI.Controls.JGroupBox();
            this.dataGridView1 = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedItemsToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.copyAllItemNamesToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllItemNamesToClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox18 = new JHUI.Controls.JGroupBox();
            this.button16 = new JHUI.Controls.JButton();
            this.textBox25 = new JHUI.Controls.JTextBox();
            this.comboBox3 = new JHUI.Controls.JComboBox();
            this.groupBox17 = new JHUI.Controls.JGroupBox();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jComboBox1 = new JHUI.Controls.JComboBox();
            this.checkBox2 = new JHUI.Controls.JCheckBox();
            this.checkBox5 = new JHUI.Controls.JCheckBox();
            this.checkBox4 = new JHUI.Controls.JCheckBox();
            this.button15 = new JHUI.Controls.JButton();
            this.textBox23 = new JHUI.Controls.JTextBox();
            this.button5 = new JHUI.Controls.JButton();
            this.selecter_rowscheckbox = new JHUI.Controls.JComboBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl2 = new JHUI.Controls.JTabControl();
            this.tabPage3 = new JHUI.Controls.JTabPage();
            this.jPictureBox5 = new JHUI.Controls.JPictureBox();
            this.Tools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.elementEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importConfigsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readListUsefulForEncryptedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadRequiredFilesFrompckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportIconsForPWAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSkillsToListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.skillOctetsGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.pathLabel = new JHUI.Controls.JLabel();
            this.jPictureBox4 = new JHUI.Controls.JPictureBox();
            this.nextautoIdlabel = new JHUI.Controls.JLabel();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.classmaskMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.listBox_items = new JHUI.Controls.JDataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.jPictureBox3 = new JHUI.Controls.JPictureBox();
            this.jGroupBox1 = new JHUI.Controls.JGroupBox();
            this.contextMenuStrip2.SuspendLayout();
            this.listbox_items_menu.SuspendLayout();
            this.BookMarks.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).BeginInit();
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
            this.tabPage4.SuspendLayout();
            this.jGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).BeginInit();
            this.Tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.classmaskMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).BeginInit();
            this.jGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.copyToolStripMenuItem,
            this.pastToolStripMenuItem,
            this.invertRowsToolStripMenuItem,
            this.toolStripSeparator6,
            this.findDuplicatesToolStripMenuItem,
            this.toolStripSeparator9,
            this.saveToDiskToolStripMenuItem,
            this.viewModelToolStripMenuItem,
            this.toolStripSeparator13,
            this.dropSelectedAddonFasterToolStripMenuItem,
            this.recalculateDropsToolStripMenuItem,
            this.recalculateAdonsToolStripMenuItem,
            this.recalculateRandsToolStripMenuItem,
            this.toolStripSeparator15,
            this.pathFixerToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(195, 292);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.idea;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem3.Text = "Replace";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.replaceToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.finish_and_merge;
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.pastToolStripMenuItem.Text = "Paste";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.pastToolStripMenuItem_Click);
            // 
            // invertRowsToolStripMenuItem
            // 
            this.invertRowsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("invertRowsToolStripMenuItem.Image")));
            this.invertRowsToolStripMenuItem.Name = "invertRowsToolStripMenuItem";
            this.invertRowsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.invertRowsToolStripMenuItem.Text = "Invert";
            this.invertRowsToolStripMenuItem.Click += new System.EventHandler(this.invertRowsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(191, 6);
            // 
            // findDuplicatesToolStripMenuItem
            // 
            this.findDuplicatesToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Layers1;
            this.findDuplicatesToolStripMenuItem.Name = "findDuplicatesToolStripMenuItem";
            this.findDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.findDuplicatesToolStripMenuItem.Text = "Find Duplicates";
            this.findDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.FindDuplicatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(191, 6);
            // 
            // saveToDiskToolStripMenuItem
            // 
            this.saveToDiskToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Unpack;
            this.saveToDiskToolStripMenuItem.Name = "saveToDiskToolStripMenuItem";
            this.saveToDiskToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.saveToDiskToolStripMenuItem.Text = "Save Files To Disk";
            this.saveToDiskToolStripMenuItem.Click += new System.EventHandler(this.saveToDiskToolStripMenuItem_Click);
            // 
            // viewModelToolStripMenuItem
            // 
            this.viewModelToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View1;
            this.viewModelToolStripMenuItem.Name = "viewModelToolStripMenuItem";
            this.viewModelToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.viewModelToolStripMenuItem.Text = "View Model";
            this.viewModelToolStripMenuItem.Click += new System.EventHandler(this.viewModelToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(191, 6);
            // 
            // dropSelectedAddonFasterToolStripMenuItem
            // 
            this.dropSelectedAddonFasterToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Warning;
            this.dropSelectedAddonFasterToolStripMenuItem.Name = "dropSelectedAddonFasterToolStripMenuItem";
            this.dropSelectedAddonFasterToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.dropSelectedAddonFasterToolStripMenuItem.Text = "Drop Selected Faster";
            this.dropSelectedAddonFasterToolStripMenuItem.Click += new System.EventHandler(this.DropSelectedAddonFasterToolStripMenuItem_Click);
            // 
            // recalculateDropsToolStripMenuItem
            // 
            this.recalculateDropsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateTotalToolStripMenuItem});
            this.recalculateDropsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Warning;
            this.recalculateDropsToolStripMenuItem.Name = "recalculateDropsToolStripMenuItem";
            this.recalculateDropsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.recalculateDropsToolStripMenuItem.Text = "Recalculate Probability";
            this.recalculateDropsToolStripMenuItem.Click += new System.EventHandler(this.RecalculateDropsToolStripMenuItem_Click);
            // 
            // calculateTotalToolStripMenuItem
            // 
            this.calculateTotalToolStripMenuItem.Name = "calculateTotalToolStripMenuItem";
            this.calculateTotalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.calculateTotalToolStripMenuItem.Text = "Calculate Total";
            this.calculateTotalToolStripMenuItem.Click += new System.EventHandler(this.CalculateTotalToolStripMenuItem_Click);
            // 
            // recalculateAdonsToolStripMenuItem
            // 
            this.recalculateAdonsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSumeToolStripMenuItem});
            this.recalculateAdonsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Warning;
            this.recalculateAdonsToolStripMenuItem.Name = "recalculateAdonsToolStripMenuItem";
            this.recalculateAdonsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.recalculateAdonsToolStripMenuItem.Text = "Recalculate Adons";
            this.recalculateAdonsToolStripMenuItem.Click += new System.EventHandler(this.RecalculateAdonsToolStripMenuItem_Click);
            // 
            // showSumeToolStripMenuItem
            // 
            this.showSumeToolStripMenuItem.Name = "showSumeToolStripMenuItem";
            this.showSumeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.showSumeToolStripMenuItem.Text = "Show Sume";
            this.showSumeToolStripMenuItem.Click += new System.EventHandler(this.ShowSumeToolStripMenuItem_Click);
            // 
            // recalculateRandsToolStripMenuItem
            // 
            this.recalculateRandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSumeToolStripMenuItem1});
            this.recalculateRandsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Warning;
            this.recalculateRandsToolStripMenuItem.Name = "recalculateRandsToolStripMenuItem";
            this.recalculateRandsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.recalculateRandsToolStripMenuItem.Text = "Recalculate Rands";
            this.recalculateRandsToolStripMenuItem.Click += new System.EventHandler(this.RecalculateRandsToolStripMenuItem_Click);
            // 
            // showSumeToolStripMenuItem1
            // 
            this.showSumeToolStripMenuItem1.Name = "showSumeToolStripMenuItem1";
            this.showSumeToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.showSumeToolStripMenuItem1.Text = "Show Sume";
            this.showSumeToolStripMenuItem1.Click += new System.EventHandler(this.ShowSumeToolStripMenuItem1_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(191, 6);
            // 
            // pathFixerToolStripMenuItem
            // 
            this.pathFixerToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.SettingsCog;
            this.pathFixerToolStripMenuItem.Name = "pathFixerToolStripMenuItem";
            this.pathFixerToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.pathFixerToolStripMenuItem.Text = "Path Fixer";
            this.pathFixerToolStripMenuItem.Click += new System.EventHandler(this.PathFixerToolStripMenuItem_Click);
            // 
            // listbox_items_menu
            // 
            this.listbox_items_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripSeparator11,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator12,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.asignNewIdsToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyToClipboardToolStripMenuItem,
            this.toolStripSeparator5,
            this.makeRecipesToolStripMenuItem2,
            this.toolStripSeparator8,
            this.sortIdsToolStripMenuItem,
            this.toolStripSeparator14,
            this.makePetEggToolStripMenuItem,
            this.CopyPetToolStripMenuItem,
            this.PastePetToolStripMenuItem1});
            this.listbox_items_menu.Name = "listbox_items_menu";
            this.listbox_items_menu.Size = new System.Drawing.Size(174, 288);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(170, 6);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.copy;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.finish_and_merge;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(170, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Delete1;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // asignNewIdsToolStripMenuItem
            // 
            this.asignNewIdsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Check_boxes;
            this.asignNewIdsToolStripMenuItem.Name = "asignNewIdsToolStripMenuItem";
            this.asignNewIdsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.asignNewIdsToolStripMenuItem.Text = "Asign New Ids";
            this.asignNewIdsToolStripMenuItem.Click += new System.EventHandler(this.asignNewIdsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Clipboard;
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy To Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(170, 6);
            // 
            // makeRecipesToolStripMenuItem2
            // 
            this.makeRecipesToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reforgeTypeToolStripMenuItem,
            this.targetTypeToolStripMenuItem,
            this.materialTypeToolStripMenuItem});
            this.makeRecipesToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.bullet_toggle_plus;
            this.makeRecipesToolStripMenuItem2.Name = "makeRecipesToolStripMenuItem2";
            this.makeRecipesToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(170, 6);
            // 
            // sortIdsToolStripMenuItem
            // 
            this.sortIdsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idAscToolStripMenuItem});
            this.sortIdsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View;
            this.sortIdsToolStripMenuItem.Name = "sortIdsToolStripMenuItem";
            this.sortIdsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sortIdsToolStripMenuItem.Text = "Sort";
            // 
            // idAscToolStripMenuItem
            // 
            this.idAscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSKToolStripMenuItem,
            this.dSKToolStripMenuItem});
            this.idAscToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Shuffle;
            this.idAscToolStripMenuItem.Name = "idAscToolStripMenuItem";
            this.idAscToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.idAscToolStripMenuItem.Text = "ID";
            // 
            // aSKToolStripMenuItem
            // 
            this.aSKToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Snowflake;
            this.aSKToolStripMenuItem.Name = "aSKToolStripMenuItem";
            this.aSKToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.aSKToolStripMenuItem.Text = "ASC";
            this.aSKToolStripMenuItem.Click += new System.EventHandler(this.ASKToolStripMenuItem_Click);
            // 
            // dSKToolStripMenuItem
            // 
            this.dSKToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Snowflake;
            this.dSKToolStripMenuItem.Name = "dSKToolStripMenuItem";
            this.dSKToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.dSKToolStripMenuItem.Text = "DESC";
            this.dSKToolStripMenuItem.Click += new System.EventHandler(this.DSKToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(170, 6);
            // 
            // makePetEggToolStripMenuItem
            // 
            this.makePetEggToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.makePetEggToolStripMenuItem.Name = "makePetEggToolStripMenuItem";
            this.makePetEggToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.makePetEggToolStripMenuItem.Text = "Make Pet Egg";
            this.makePetEggToolStripMenuItem.Click += new System.EventHandler(this.MakePetEggToolStripMenuItem_Click);
            // 
            // CopyPetToolStripMenuItem
            // 
            this.CopyPetToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.copy;
            this.CopyPetToolStripMenuItem.Name = "CopyPetToolStripMenuItem";
            this.CopyPetToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.CopyPetToolStripMenuItem.Text = "Copy Egg With Pet";
            this.CopyPetToolStripMenuItem.Click += new System.EventHandler(this.CopyPets);
            // 
            // PastePetToolStripMenuItem1
            // 
            this.PastePetToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.finish_and_merge;
            this.PastePetToolStripMenuItem1.Name = "PastePetToolStripMenuItem1";
            this.PastePetToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.PastePetToolStripMenuItem1.Text = "Paste Egg With Pet";
            this.PastePetToolStripMenuItem1.Click += new System.EventHandler(this.PastePets);
            // 
            // comboBox_lists
            // 
            this.comboBox_lists.ContextMenuStrip = this.BookMarks;
            this.comboBox_lists.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox_lists.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox_lists.IntegralHeight = false;
            this.comboBox_lists.ItemHeight = 19;
            this.comboBox_lists.Location = new System.Drawing.Point(20, 63);
            this.comboBox_lists.MaxDropDownItems = 19;
            this.comboBox_lists.Name = "comboBox_lists";
            this.comboBox_lists.Size = new System.Drawing.Size(272, 25);
            this.comboBox_lists.Style = JHUI.JColorStyle.Blue;
            this.comboBox_lists.TabIndex = 1;
            this.comboBox_lists.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_lists.UseSelectable = true;
            this.comboBox_lists.UseStyleColors = true;
            this.comboBox_lists.SelectedIndexChanged += new System.EventHandler(this.Change_list);
            // 
            // BookMarks
            // 
            this.BookMarks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem,
            this.bookMarkToolStripMenuItem});
            this.BookMarks.Name = "BookMarks";
            this.BookMarks.Size = new System.Drawing.Size(157, 48);
            this.BookMarks.Style = JHUI.JColorStyle.Blue;
            this.BookMarks.Theme = JHUI.JThemeStyle.Dark;
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Shuffle;
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.goToToolStripMenuItem.Text = "Go To";
            // 
            // bookMarkToolStripMenuItem
            // 
            this.bookMarkToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Add;
            this.bookMarkToolStripMenuItem.Name = "bookMarkToolStripMenuItem";
            this.bookMarkToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.bookMarkToolStripMenuItem.Text = "Add Book Mark";
            this.bookMarkToolStripMenuItem.Click += new System.EventHandler(this.bookMarkToolStripMenuItem_Click);
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
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Load";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
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
            this.configEditorExportToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.SettingsCog;
            this.configEditorExportToolStripMenuItem.Name = "configEditorExportToolStripMenuItem";
            this.configEditorExportToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.configEditorExportToolStripMenuItem.Text = "Config Editor Export";
            // 
            // exportSkillsToListToolStripMenuItem
            // 
            this.exportSkillsToListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportSkillsToListToolStripMenuItem.Image")));
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
            // caseSensitiveCheckbox
            // 
            this.caseSensitiveCheckbox.AutoSize = true;
            this.caseSensitiveCheckbox.Checked = true;
            this.caseSensitiveCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.caseSensitiveCheckbox.Location = new System.Drawing.Point(6, 48);
            this.caseSensitiveCheckbox.Name = "caseSensitiveCheckbox";
            this.caseSensitiveCheckbox.Size = new System.Drawing.Size(98, 15);
            this.caseSensitiveCheckbox.Style = JHUI.JColorStyle.Blue;
            this.caseSensitiveCheckbox.TabIndex = 5;
            this.caseSensitiveCheckbox.Text = "Case-sensitive";
            this.caseSensitiveCheckbox.Theme = JHUI.JThemeStyle.Dark;
            this.caseSensitiveCheckbox.UseSelectable = true;
            this.caseSensitiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // searchInput1
            // 
            this.searchInput1.BorderBottomLineSize = 5;
            this.searchInput1.BorderColor = System.Drawing.Color.Black;
            this.searchInput1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.searchInput1.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.searchInput1.CustomButton.Location = new System.Drawing.Point(245, 2);
            this.searchInput1.CustomButton.Name = "";
            this.searchInput1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.searchInput1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.searchInput1.CustomButton.TabIndex = 1;
            this.searchInput1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.searchInput1.CustomButton.UseSelectable = true;
            this.searchInput1.DrawBorder = true;
            this.searchInput1.DrawBorderBottomLine = false;
            this.searchInput1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchInput1.FontWeight = JHUI.JTextBoxWeight.Light;
            this.searchInput1.Lines = new string[0];
            this.searchInput1.Location = new System.Drawing.Point(6, 6);
            this.searchInput1.MaxLength = 32767;
            this.searchInput1.Name = "searchInput1";
            this.searchInput1.PasswordChar = '\0';
            this.searchInput1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchInput1.SelectedText = "";
            this.searchInput1.SelectionLength = 0;
            this.searchInput1.SelectionStart = 0;
            this.searchInput1.ShortcutsEnabled = true;
            this.searchInput1.ShowButton = true;
            this.searchInput1.Size = new System.Drawing.Size(273, 30);
            this.searchInput1.Style = JHUI.JColorStyle.Blue;
            this.searchInput1.TabIndex = 4;
            this.searchInput1.TextWaterMark = "Search . . .";
            this.searchInput1.Theme = JHUI.JThemeStyle.Dark;
            this.searchInput1.UseCustomFont = true;
            this.searchInput1.UseSelectable = true;
            this.searchInput1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchInput1.WaterMarkFont = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchInput1.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(295, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.Style = JHUI.JColorStyle.Blue;
            this.label1.TabIndex = 27;
            this.label1.Text = "Version:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.CausesValidation = false;
            this.version_label.DropShadowColor = System.Drawing.Color.Black;
            this.version_label.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.version_label.FontSize = JHUI.JLabelSize.Small;
            this.version_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.version_label.Location = new System.Drawing.Point(378, 6);
            this.version_label.Name = "version_label";
            this.version_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.version_label.Size = new System.Drawing.Size(13, 15);
            this.version_label.Style = JHUI.JColorStyle.Blue;
            this.version_label.TabIndex = 27;
            this.version_label.Text = "0";
            this.version_label.Theme = JHUI.JThemeStyle.Dark;
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
            this.changeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeToolStripMenuItem.Image")));
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
            this.elementIntoTab.ChangeAnimation = jAnimation1;
            this.elementIntoTab.Controls.Add(this.Edit);
            this.elementIntoTab.Controls.Add(this.SaleTab);
            this.elementIntoTab.Controls.Add(this.craftTab);
            this.elementIntoTab.Controls.Add(this.tabPage4);
            this.elementIntoTab.Location = new System.Drawing.Point(309, 27);
            this.elementIntoTab.Name = "elementIntoTab";
            this.elementIntoTab.Padding = new System.Drawing.Point(6, 8);
            this.elementIntoTab.SelectedIndex = 0;
            this.elementIntoTab.Size = new System.Drawing.Size(640, 548);
            this.elementIntoTab.Style = JHUI.JColorStyle.White;
            this.elementIntoTab.TabIndex = 31;
            this.elementIntoTab.Theme = JHUI.JThemeStyle.Dark;
            this.elementIntoTab.UseSelectable = true;
            this.elementIntoTab.SelectedIndexChanged += new System.EventHandler(this.elementIntoTab_SelectedIndexChanged);
            // 
            // Edit
            // 
            this.Edit.Controls.Add(this.dataGridView_item);
            this.Edit.HorizontalScrollbarBarColor = true;
            this.Edit.HorizontalScrollbarHighlightOnWheel = false;
            this.Edit.HorizontalScrollbarSize = 10;
            this.Edit.Location = new System.Drawing.Point(4, 38);
            this.Edit.Name = "Edit";
            this.Edit.Padding = new System.Windows.Forms.Padding(3);
            this.Edit.Size = new System.Drawing.Size(632, 506);
            this.Edit.Style = JHUI.JColorStyle.Blue;
            this.Edit.TabIndex = 0;
            this.Edit.Text = "Editor";
            this.Edit.Theme = JHUI.JThemeStyle.Dark;
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.VerticalScrollbarBarColor = true;
            this.Edit.VerticalScrollbarHighlightOnWheel = false;
            this.Edit.VerticalScrollbarSize = 10;
            // 
            // dataGridView_item
            // 
            this.dataGridView_item.AllowUserToAddRows = false;
            this.dataGridView_item.AllowUserToDeleteRows = false;
            this.dataGridView_item.AllowUserToResizeColumns = false;
            this.dataGridView_item.AllowUserToResizeRows = false;
            this.dataGridView_item.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_item.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_item.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_item.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView_item.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_item.ColumnHeadersHeight = 22;
            this.dataGridView_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowId,
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataGridView_item.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_item.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_item.EnableHeadersVisualStyles = false;
            this.dataGridView_item.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_item.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_item.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_item.Name = "dataGridView_item";
            this.dataGridView_item.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_item.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_item.RowHeadersVisible = false;
            this.dataGridView_item.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_item.Size = new System.Drawing.Size(626, 500);
            this.dataGridView_item.StandardTab = true;
            this.dataGridView_item.Style = JHUI.JColorStyle.Blue;
            this.dataGridView_item.TabIndex = 3;
            this.dataGridView_item.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_item_CellClick);
            this.dataGridView_item.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_item_CellMouseEnter);
            this.dataGridView_item.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_item_CellMouseLeave);
            this.dataGridView_item.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Change_value);
            this.dataGridView_item.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_item_EditingControlShowing);
            this.dataGridView_item.SelectionChanged += new System.EventHandler(this.dataGridView_item_SelectionChanged);
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
            this.RowId.Width = 21;
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
            this.Column3.Width = 14;
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
            this.SaleTab.HorizontalScrollbarBarColor = true;
            this.SaleTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SaleTab.HorizontalScrollbarSize = 10;
            this.SaleTab.Location = new System.Drawing.Point(4, 38);
            this.SaleTab.Name = "SaleTab";
            this.SaleTab.Padding = new System.Windows.Forms.Padding(3);
            this.SaleTab.Size = new System.Drawing.Size(632, 506);
            this.SaleTab.Style = JHUI.JColorStyle.Blue;
            this.SaleTab.TabIndex = 2;
            this.SaleTab.Text = "Sale Preview";
            this.SaleTab.Theme = JHUI.JThemeStyle.Dark;
            this.SaleTab.UseVisualStyleBackColor = true;
            this.SaleTab.VerticalScrollbarBarColor = true;
            this.SaleTab.VerticalScrollbarHighlightOnWheel = false;
            this.SaleTab.VerticalScrollbarSize = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox4.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
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
            this.groupBox4.DrawBottomLine = false;
            this.groupBox4.DrawShadows = false;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox4.FontSize = JHUI.JLabelSize.Small;
            this.groupBox4.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.PaintDefault = false;
            this.groupBox4.Size = new System.Drawing.Size(301, 100);
            this.groupBox4.Style = JHUI.JColorStyle.Blue;
            this.groupBox4.StyleManager = null;
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pages";
            this.groupBox4.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox4.UseStyleColors = false;
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
            this.button10.Style = JHUI.JColorStyle.Blue;
            this.button10.TabIndex = 50;
            this.button10.Text = "Rename";
            this.button10.Theme = JHUI.JThemeStyle.Dark;
            this.button10.UseSelectable = true;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.addItemSalePreview);
            // 
            // textBox2
            // 
            this.textBox2.BorderBottomLineSize = 5;
            this.textBox2.BorderColor = System.Drawing.Color.Black;
            this.textBox2.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox2.CustomButton.Image = null;
            this.textBox2.CustomButton.Location = new System.Drawing.Point(196, 2);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox2.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.DrawBorder = true;
            this.textBox2.DrawBorderBottomLine = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(7, 71);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(214, 20);
            this.textBox2.Style = JHUI.JColorStyle.Blue;
            this.textBox2.TabIndex = 50;
            this.textBox2.TextWaterMark = "";
            this.textBox2.Theme = JHUI.JThemeStyle.Dark;
            this.textBox2.UseCustomFont = true;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.tab_salebtn_1.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_1.TabIndex = 37;
            this.tab_salebtn_1.Text = "Page 1";
            this.tab_salebtn_1.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_1.UseSelectable = true;
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
            this.tab_salebtn_5.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_5.TabIndex = 45;
            this.tab_salebtn_5.Text = "Page 4";
            this.tab_salebtn_5.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_5.UseSelectable = true;
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
            this.tab_salebtn_2.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_2.TabIndex = 38;
            this.tab_salebtn_2.Text = "Page 2";
            this.tab_salebtn_2.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_2.UseSelectable = true;
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
            this.tab_salebtn_8.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_8.TabIndex = 44;
            this.tab_salebtn_8.Text = "Page 7";
            this.tab_salebtn_8.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_8.UseSelectable = true;
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
            this.tab_salebtn_3.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_3.TabIndex = 39;
            this.tab_salebtn_3.Text = "Page 3";
            this.tab_salebtn_3.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_3.UseSelectable = true;
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
            this.tab_salebtn_7.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_7.TabIndex = 43;
            this.tab_salebtn_7.Text = "Page 6";
            this.tab_salebtn_7.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_7.UseSelectable = true;
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
            this.tab_salebtn_4.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_4.TabIndex = 40;
            this.tab_salebtn_4.Text = "Page 4";
            this.tab_salebtn_4.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_4.UseSelectable = true;
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
            this.tab_salebtn_6.Style = JHUI.JColorStyle.Blue;
            this.tab_salebtn_6.TabIndex = 42;
            this.tab_salebtn_6.Text = "Page 5";
            this.tab_salebtn_6.Theme = JHUI.JThemeStyle.Dark;
            this.tab_salebtn_6.UseSelectable = true;
            this.tab_salebtn_6.UseVisualStyleBackColor = false;
            this.tab_salebtn_6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tab_salebtn_1_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
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
            this.groupBox1.DrawBottomLine = false;
            this.groupBox1.DrawShadows = false;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.FontSize = JHUI.JLabelSize.Small;
            this.groupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.PaintDefault = false;
            this.groupBox1.Size = new System.Drawing.Size(301, 219);
            this.groupBox1.Style = JHUI.JColorStyle.Blue;
            this.groupBox1.StyleManager = null;
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            this.groupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox1.UseStyleColors = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(93, 15);
            this.checkBox1.Style = JHUI.JColorStyle.Blue;
            this.checkBox1.TabIndex = 79;
            this.checkBox1.Text = "Show Item ID";
            this.checkBox1.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox1.UseSelectable = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label_item_32
            // 
            this.label_item_32.AutoSize = true;
            this.label_item_32.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_32.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_32.FontSize = JHUI.JLabelSize.Small;
            this.label_item_32.Location = new System.Drawing.Point(256, 130);
            this.label_item_32.Name = "label_item_32";
            this.label_item_32.Size = new System.Drawing.Size(35, 15);
            this.label_item_32.Style = JHUI.JColorStyle.Blue;
            this.label_item_32.TabIndex = 76;
            this.label_item_32.Text = "12345";
            this.label_item_32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_32.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_31
            // 
            this.label_item_31.AutoSize = true;
            this.label_item_31.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_31.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_31.FontSize = JHUI.JLabelSize.Small;
            this.label_item_31.Location = new System.Drawing.Point(220, 130);
            this.label_item_31.Name = "label_item_31";
            this.label_item_31.Size = new System.Drawing.Size(35, 15);
            this.label_item_31.Style = JHUI.JColorStyle.Blue;
            this.label_item_31.TabIndex = 78;
            this.label_item_31.Text = "12345";
            this.label_item_31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_31.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_30
            // 
            this.label_item_30.AutoSize = true;
            this.label_item_30.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_30.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_30.FontSize = JHUI.JLabelSize.Small;
            this.label_item_30.Location = new System.Drawing.Point(184, 130);
            this.label_item_30.Name = "label_item_30";
            this.label_item_30.Size = new System.Drawing.Size(35, 15);
            this.label_item_30.Style = JHUI.JColorStyle.Blue;
            this.label_item_30.TabIndex = 77;
            this.label_item_30.Text = "12345";
            this.label_item_30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_30.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_29
            // 
            this.label_item_29.AutoSize = true;
            this.label_item_29.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_29.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_29.FontSize = JHUI.JLabelSize.Small;
            this.label_item_29.Location = new System.Drawing.Point(148, 130);
            this.label_item_29.Name = "label_item_29";
            this.label_item_29.Size = new System.Drawing.Size(35, 15);
            this.label_item_29.Style = JHUI.JColorStyle.Blue;
            this.label_item_29.TabIndex = 75;
            this.label_item_29.Text = "12345";
            this.label_item_29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_29.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_28
            // 
            this.label_item_28.AutoSize = true;
            this.label_item_28.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_28.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_28.FontSize = JHUI.JLabelSize.Small;
            this.label_item_28.Location = new System.Drawing.Point(113, 130);
            this.label_item_28.Name = "label_item_28";
            this.label_item_28.Size = new System.Drawing.Size(35, 15);
            this.label_item_28.Style = JHUI.JColorStyle.Blue;
            this.label_item_28.TabIndex = 74;
            this.label_item_28.Text = "12345";
            this.label_item_28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_28.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_27
            // 
            this.label_item_27.AutoSize = true;
            this.label_item_27.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_27.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_27.FontSize = JHUI.JLabelSize.Small;
            this.label_item_27.Location = new System.Drawing.Point(77, 130);
            this.label_item_27.Name = "label_item_27";
            this.label_item_27.Size = new System.Drawing.Size(35, 15);
            this.label_item_27.Style = JHUI.JColorStyle.Blue;
            this.label_item_27.TabIndex = 73;
            this.label_item_27.Text = "12345";
            this.label_item_27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_27.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_26
            // 
            this.label_item_26.AutoSize = true;
            this.label_item_26.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_26.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_26.FontSize = JHUI.JLabelSize.Small;
            this.label_item_26.Location = new System.Drawing.Point(41, 130);
            this.label_item_26.Name = "label_item_26";
            this.label_item_26.Size = new System.Drawing.Size(35, 15);
            this.label_item_26.Style = JHUI.JColorStyle.Blue;
            this.label_item_26.TabIndex = 72;
            this.label_item_26.Text = "12345";
            this.label_item_26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_26.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_25
            // 
            this.label_item_25.AutoSize = true;
            this.label_item_25.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_25.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_25.FontSize = JHUI.JLabelSize.Small;
            this.label_item_25.Location = new System.Drawing.Point(5, 130);
            this.label_item_25.Name = "label_item_25";
            this.label_item_25.Size = new System.Drawing.Size(35, 15);
            this.label_item_25.Style = JHUI.JColorStyle.Blue;
            this.label_item_25.TabIndex = 71;
            this.label_item_25.Text = "12345";
            this.label_item_25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_25.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_24
            // 
            this.label_item_24.AutoSize = true;
            this.label_item_24.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_24.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_24.FontSize = JHUI.JLabelSize.Small;
            this.label_item_24.Location = new System.Drawing.Point(257, 92);
            this.label_item_24.Name = "label_item_24";
            this.label_item_24.Size = new System.Drawing.Size(35, 15);
            this.label_item_24.Style = JHUI.JColorStyle.Blue;
            this.label_item_24.TabIndex = 68;
            this.label_item_24.Text = "12345";
            this.label_item_24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_24.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_23
            // 
            this.label_item_23.AutoSize = true;
            this.label_item_23.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_23.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_23.FontSize = JHUI.JLabelSize.Small;
            this.label_item_23.Location = new System.Drawing.Point(221, 92);
            this.label_item_23.Name = "label_item_23";
            this.label_item_23.Size = new System.Drawing.Size(35, 15);
            this.label_item_23.Style = JHUI.JColorStyle.Blue;
            this.label_item_23.TabIndex = 70;
            this.label_item_23.Text = "12345";
            this.label_item_23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_23.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_22
            // 
            this.label_item_22.AutoSize = true;
            this.label_item_22.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_22.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_22.FontSize = JHUI.JLabelSize.Small;
            this.label_item_22.Location = new System.Drawing.Point(185, 92);
            this.label_item_22.Name = "label_item_22";
            this.label_item_22.Size = new System.Drawing.Size(35, 15);
            this.label_item_22.Style = JHUI.JColorStyle.Blue;
            this.label_item_22.TabIndex = 69;
            this.label_item_22.Text = "12345";
            this.label_item_22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_22.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_21
            // 
            this.label_item_21.AutoSize = true;
            this.label_item_21.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_21.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_21.FontSize = JHUI.JLabelSize.Small;
            this.label_item_21.Location = new System.Drawing.Point(149, 92);
            this.label_item_21.Name = "label_item_21";
            this.label_item_21.Size = new System.Drawing.Size(35, 15);
            this.label_item_21.Style = JHUI.JColorStyle.Blue;
            this.label_item_21.TabIndex = 67;
            this.label_item_21.Text = "12345";
            this.label_item_21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_21.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_20
            // 
            this.label_item_20.AutoSize = true;
            this.label_item_20.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_20.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_20.FontSize = JHUI.JLabelSize.Small;
            this.label_item_20.Location = new System.Drawing.Point(114, 92);
            this.label_item_20.Name = "label_item_20";
            this.label_item_20.Size = new System.Drawing.Size(35, 15);
            this.label_item_20.Style = JHUI.JColorStyle.Blue;
            this.label_item_20.TabIndex = 66;
            this.label_item_20.Text = "12345";
            this.label_item_20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_20.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_19
            // 
            this.label_item_19.AutoSize = true;
            this.label_item_19.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_19.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_19.FontSize = JHUI.JLabelSize.Small;
            this.label_item_19.Location = new System.Drawing.Point(78, 92);
            this.label_item_19.Name = "label_item_19";
            this.label_item_19.Size = new System.Drawing.Size(35, 15);
            this.label_item_19.Style = JHUI.JColorStyle.Blue;
            this.label_item_19.TabIndex = 65;
            this.label_item_19.Text = "12345";
            this.label_item_19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_19.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_18
            // 
            this.label_item_18.AutoSize = true;
            this.label_item_18.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_18.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_18.FontSize = JHUI.JLabelSize.Small;
            this.label_item_18.Location = new System.Drawing.Point(42, 92);
            this.label_item_18.Name = "label_item_18";
            this.label_item_18.Size = new System.Drawing.Size(35, 15);
            this.label_item_18.Style = JHUI.JColorStyle.Blue;
            this.label_item_18.TabIndex = 64;
            this.label_item_18.Text = "12345";
            this.label_item_18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_18.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_17
            // 
            this.label_item_17.AutoSize = true;
            this.label_item_17.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_17.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_17.FontSize = JHUI.JLabelSize.Small;
            this.label_item_17.Location = new System.Drawing.Point(6, 92);
            this.label_item_17.Name = "label_item_17";
            this.label_item_17.Size = new System.Drawing.Size(35, 15);
            this.label_item_17.Style = JHUI.JColorStyle.Blue;
            this.label_item_17.TabIndex = 63;
            this.label_item_17.Text = "12345";
            this.label_item_17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_17.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_16
            // 
            this.label_item_16.AutoSize = true;
            this.label_item_16.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_16.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_16.FontSize = JHUI.JLabelSize.Small;
            this.label_item_16.Location = new System.Drawing.Point(257, 57);
            this.label_item_16.Name = "label_item_16";
            this.label_item_16.Size = new System.Drawing.Size(35, 15);
            this.label_item_16.Style = JHUI.JColorStyle.Blue;
            this.label_item_16.TabIndex = 60;
            this.label_item_16.Text = "12345";
            this.label_item_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_16.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_15
            // 
            this.label_item_15.AutoSize = true;
            this.label_item_15.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_15.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_15.FontSize = JHUI.JLabelSize.Small;
            this.label_item_15.Location = new System.Drawing.Point(221, 57);
            this.label_item_15.Name = "label_item_15";
            this.label_item_15.Size = new System.Drawing.Size(35, 15);
            this.label_item_15.Style = JHUI.JColorStyle.Blue;
            this.label_item_15.TabIndex = 62;
            this.label_item_15.Text = "12345";
            this.label_item_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_15.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_14
            // 
            this.label_item_14.AutoSize = true;
            this.label_item_14.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_14.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_14.FontSize = JHUI.JLabelSize.Small;
            this.label_item_14.Location = new System.Drawing.Point(185, 57);
            this.label_item_14.Name = "label_item_14";
            this.label_item_14.Size = new System.Drawing.Size(35, 15);
            this.label_item_14.Style = JHUI.JColorStyle.Blue;
            this.label_item_14.TabIndex = 61;
            this.label_item_14.Text = "12345";
            this.label_item_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_14.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_13
            // 
            this.label_item_13.AutoSize = true;
            this.label_item_13.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_13.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_13.FontSize = JHUI.JLabelSize.Small;
            this.label_item_13.Location = new System.Drawing.Point(149, 57);
            this.label_item_13.Name = "label_item_13";
            this.label_item_13.Size = new System.Drawing.Size(35, 15);
            this.label_item_13.Style = JHUI.JColorStyle.Blue;
            this.label_item_13.TabIndex = 59;
            this.label_item_13.Text = "12345";
            this.label_item_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_13.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_12
            // 
            this.label_item_12.AutoSize = true;
            this.label_item_12.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_12.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_12.FontSize = JHUI.JLabelSize.Small;
            this.label_item_12.Location = new System.Drawing.Point(114, 57);
            this.label_item_12.Name = "label_item_12";
            this.label_item_12.Size = new System.Drawing.Size(35, 15);
            this.label_item_12.Style = JHUI.JColorStyle.Blue;
            this.label_item_12.TabIndex = 58;
            this.label_item_12.Text = "12345";
            this.label_item_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_12.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_11
            // 
            this.label_item_11.AutoSize = true;
            this.label_item_11.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_11.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_11.FontSize = JHUI.JLabelSize.Small;
            this.label_item_11.Location = new System.Drawing.Point(78, 57);
            this.label_item_11.Name = "label_item_11";
            this.label_item_11.Size = new System.Drawing.Size(35, 15);
            this.label_item_11.Style = JHUI.JColorStyle.Blue;
            this.label_item_11.TabIndex = 57;
            this.label_item_11.Text = "12345";
            this.label_item_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_11.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_10
            // 
            this.label_item_10.AutoSize = true;
            this.label_item_10.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_10.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_10.FontSize = JHUI.JLabelSize.Small;
            this.label_item_10.Location = new System.Drawing.Point(42, 57);
            this.label_item_10.Name = "label_item_10";
            this.label_item_10.Size = new System.Drawing.Size(35, 15);
            this.label_item_10.Style = JHUI.JColorStyle.Blue;
            this.label_item_10.TabIndex = 56;
            this.label_item_10.Text = "12345";
            this.label_item_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_10.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_9
            // 
            this.label_item_9.AutoSize = true;
            this.label_item_9.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_9.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_9.FontSize = JHUI.JLabelSize.Small;
            this.label_item_9.Location = new System.Drawing.Point(6, 57);
            this.label_item_9.Name = "label_item_9";
            this.label_item_9.Size = new System.Drawing.Size(35, 15);
            this.label_item_9.Style = JHUI.JColorStyle.Blue;
            this.label_item_9.TabIndex = 55;
            this.label_item_9.Text = "12345";
            this.label_item_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_9.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_8
            // 
            this.label_item_8.AutoSize = true;
            this.label_item_8.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_8.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_8.FontSize = JHUI.JLabelSize.Small;
            this.label_item_8.Location = new System.Drawing.Point(257, 19);
            this.label_item_8.Name = "label_item_8";
            this.label_item_8.Size = new System.Drawing.Size(35, 15);
            this.label_item_8.Style = JHUI.JColorStyle.Blue;
            this.label_item_8.TabIndex = 53;
            this.label_item_8.Text = "12345";
            this.label_item_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_8.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_7
            // 
            this.label_item_7.AutoSize = true;
            this.label_item_7.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_7.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_7.FontSize = JHUI.JLabelSize.Small;
            this.label_item_7.Location = new System.Drawing.Point(221, 19);
            this.label_item_7.Name = "label_item_7";
            this.label_item_7.Size = new System.Drawing.Size(35, 15);
            this.label_item_7.Style = JHUI.JColorStyle.Blue;
            this.label_item_7.TabIndex = 54;
            this.label_item_7.Text = "12345";
            this.label_item_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_7.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_6
            // 
            this.label_item_6.AutoSize = true;
            this.label_item_6.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_6.FontSize = JHUI.JLabelSize.Small;
            this.label_item_6.Location = new System.Drawing.Point(185, 19);
            this.label_item_6.Name = "label_item_6";
            this.label_item_6.Size = new System.Drawing.Size(35, 15);
            this.label_item_6.Style = JHUI.JColorStyle.Blue;
            this.label_item_6.TabIndex = 53;
            this.label_item_6.Text = "12345";
            this.label_item_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_5
            // 
            this.label_item_5.AutoSize = true;
            this.label_item_5.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_5.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_5.FontSize = JHUI.JLabelSize.Small;
            this.label_item_5.Location = new System.Drawing.Point(149, 19);
            this.label_item_5.Name = "label_item_5";
            this.label_item_5.Size = new System.Drawing.Size(35, 15);
            this.label_item_5.Style = JHUI.JColorStyle.Blue;
            this.label_item_5.TabIndex = 52;
            this.label_item_5.Text = "12345";
            this.label_item_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_4
            // 
            this.label_item_4.AutoSize = true;
            this.label_item_4.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_4.FontSize = JHUI.JLabelSize.Small;
            this.label_item_4.Location = new System.Drawing.Point(114, 19);
            this.label_item_4.Name = "label_item_4";
            this.label_item_4.Size = new System.Drawing.Size(35, 15);
            this.label_item_4.Style = JHUI.JColorStyle.Blue;
            this.label_item_4.TabIndex = 51;
            this.label_item_4.Text = "12345";
            this.label_item_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_3
            // 
            this.label_item_3.AutoSize = true;
            this.label_item_3.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_3.FontSize = JHUI.JLabelSize.Small;
            this.label_item_3.Location = new System.Drawing.Point(78, 19);
            this.label_item_3.Name = "label_item_3";
            this.label_item_3.Size = new System.Drawing.Size(35, 15);
            this.label_item_3.Style = JHUI.JColorStyle.Blue;
            this.label_item_3.TabIndex = 50;
            this.label_item_3.Text = "12345";
            this.label_item_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_2
            // 
            this.label_item_2.AutoSize = true;
            this.label_item_2.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_2.FontSize = JHUI.JLabelSize.Small;
            this.label_item_2.Location = new System.Drawing.Point(42, 19);
            this.label_item_2.Name = "label_item_2";
            this.label_item_2.Size = new System.Drawing.Size(35, 15);
            this.label_item_2.Style = JHUI.JColorStyle.Blue;
            this.label_item_2.TabIndex = 49;
            this.label_item_2.Text = "12345";
            this.label_item_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_item_1
            // 
            this.label_item_1.AutoSize = true;
            this.label_item_1.DropShadowColor = System.Drawing.Color.Black;
            this.label_item_1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_item_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label_item_1.FontSize = JHUI.JLabelSize.Small;
            this.label_item_1.Location = new System.Drawing.Point(6, 19);
            this.label_item_1.Name = "label_item_1";
            this.label_item_1.Size = new System.Drawing.Size(35, 15);
            this.label_item_1.Style = JHUI.JColorStyle.Blue;
            this.label_item_1.TabIndex = 47;
            this.label_item_1.Text = "12345";
            this.label_item_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_item_1.Theme = JHUI.JThemeStyle.Dark;
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
            this.button8.Style = JHUI.JColorStyle.Blue;
            this.button8.TabIndex = 48;
            this.button8.Text = "Add";
            this.button8.Theme = JHUI.JThemeStyle.Dark;
            this.button8.UseSelectable = true;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderBottomLineSize = 5;
            this.textBox1.BorderColor = System.Drawing.Color.Black;
            this.textBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(192, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.DrawBorder = true;
            this.textBox1.DrawBorderBottomLine = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.Lines = new string[] {
        "0"};
            this.textBox1.Location = new System.Drawing.Point(7, 170);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.Style = JHUI.JColorStyle.Blue;
            this.textBox1.TabIndex = 47;
            this.textBox1.Text = "0";
            this.textBox1.TextWaterMark = "";
            this.textBox1.Theme = JHUI.JThemeStyle.Dark;
            this.textBox1.UseCustomFont = true;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // picture_item_32
            // 
            this.picture_item_32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_32.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_32.Location = new System.Drawing.Point(259, 130);
            this.picture_item_32.Name = "picture_item_32";
            this.picture_item_32.Size = new System.Drawing.Size(32, 32);
            this.picture_item_32.Style = JHUI.JColorStyle.Blue;
            this.picture_item_32.TabIndex = 31;
            this.picture_item_32.TabStop = false;
            this.picture_item_32.Theme = JHUI.JThemeStyle.Dark;
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
            this.moveHereToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.copy;
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
            this.deleteToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.delteItemSalePreview);
            // 
            // picture_item_31
            // 
            this.picture_item_31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_31.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_31.Location = new System.Drawing.Point(223, 130);
            this.picture_item_31.Name = "picture_item_31";
            this.picture_item_31.Size = new System.Drawing.Size(32, 32);
            this.picture_item_31.Style = JHUI.JColorStyle.Blue;
            this.picture_item_31.TabIndex = 30;
            this.picture_item_31.TabStop = false;
            this.picture_item_31.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_31.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_31.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_31.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_30
            // 
            this.picture_item_30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_30.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_30.Location = new System.Drawing.Point(187, 130);
            this.picture_item_30.Name = "picture_item_30";
            this.picture_item_30.Size = new System.Drawing.Size(32, 32);
            this.picture_item_30.Style = JHUI.JColorStyle.Blue;
            this.picture_item_30.TabIndex = 29;
            this.picture_item_30.TabStop = false;
            this.picture_item_30.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_30.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_30.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_30.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_29
            // 
            this.picture_item_29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_29.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_29.Location = new System.Drawing.Point(151, 130);
            this.picture_item_29.Name = "picture_item_29";
            this.picture_item_29.Size = new System.Drawing.Size(32, 32);
            this.picture_item_29.Style = JHUI.JColorStyle.Blue;
            this.picture_item_29.TabIndex = 28;
            this.picture_item_29.TabStop = false;
            this.picture_item_29.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_29.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_29.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_29.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_28
            // 
            this.picture_item_28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_28.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_28.Location = new System.Drawing.Point(116, 130);
            this.picture_item_28.Name = "picture_item_28";
            this.picture_item_28.Size = new System.Drawing.Size(32, 32);
            this.picture_item_28.Style = JHUI.JColorStyle.Blue;
            this.picture_item_28.TabIndex = 27;
            this.picture_item_28.TabStop = false;
            this.picture_item_28.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_28.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_28.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_28.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_27
            // 
            this.picture_item_27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_27.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_27.Location = new System.Drawing.Point(80, 130);
            this.picture_item_27.Name = "picture_item_27";
            this.picture_item_27.Size = new System.Drawing.Size(32, 32);
            this.picture_item_27.Style = JHUI.JColorStyle.Blue;
            this.picture_item_27.TabIndex = 26;
            this.picture_item_27.TabStop = false;
            this.picture_item_27.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_27.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_27.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_27.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_26
            // 
            this.picture_item_26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_26.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_26.Location = new System.Drawing.Point(44, 130);
            this.picture_item_26.Name = "picture_item_26";
            this.picture_item_26.Size = new System.Drawing.Size(32, 32);
            this.picture_item_26.Style = JHUI.JColorStyle.Blue;
            this.picture_item_26.TabIndex = 25;
            this.picture_item_26.TabStop = false;
            this.picture_item_26.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_26.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_26.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_26.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_25
            // 
            this.picture_item_25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_25.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_25.Location = new System.Drawing.Point(8, 130);
            this.picture_item_25.Name = "picture_item_25";
            this.picture_item_25.Size = new System.Drawing.Size(32, 32);
            this.picture_item_25.Style = JHUI.JColorStyle.Blue;
            this.picture_item_25.TabIndex = 24;
            this.picture_item_25.TabStop = false;
            this.picture_item_25.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_25.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_25.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_25.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_24
            // 
            this.picture_item_24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_24.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_24.Location = new System.Drawing.Point(259, 92);
            this.picture_item_24.Name = "picture_item_24";
            this.picture_item_24.Size = new System.Drawing.Size(32, 32);
            this.picture_item_24.Style = JHUI.JColorStyle.Blue;
            this.picture_item_24.TabIndex = 23;
            this.picture_item_24.TabStop = false;
            this.picture_item_24.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_24.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_24.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_24.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_23
            // 
            this.picture_item_23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_23.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_23.Location = new System.Drawing.Point(223, 92);
            this.picture_item_23.Name = "picture_item_23";
            this.picture_item_23.Size = new System.Drawing.Size(32, 32);
            this.picture_item_23.Style = JHUI.JColorStyle.Blue;
            this.picture_item_23.TabIndex = 22;
            this.picture_item_23.TabStop = false;
            this.picture_item_23.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_23.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_23.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_23.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_22
            // 
            this.picture_item_22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_22.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_22.Location = new System.Drawing.Point(187, 92);
            this.picture_item_22.Name = "picture_item_22";
            this.picture_item_22.Size = new System.Drawing.Size(32, 32);
            this.picture_item_22.Style = JHUI.JColorStyle.Blue;
            this.picture_item_22.TabIndex = 21;
            this.picture_item_22.TabStop = false;
            this.picture_item_22.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_22.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_22.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_22.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_21
            // 
            this.picture_item_21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_21.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_21.Location = new System.Drawing.Point(151, 92);
            this.picture_item_21.Name = "picture_item_21";
            this.picture_item_21.Size = new System.Drawing.Size(32, 32);
            this.picture_item_21.Style = JHUI.JColorStyle.Blue;
            this.picture_item_21.TabIndex = 20;
            this.picture_item_21.TabStop = false;
            this.picture_item_21.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_21.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_21.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_21.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_20
            // 
            this.picture_item_20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_20.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_20.Location = new System.Drawing.Point(116, 92);
            this.picture_item_20.Name = "picture_item_20";
            this.picture_item_20.Size = new System.Drawing.Size(32, 32);
            this.picture_item_20.Style = JHUI.JColorStyle.Blue;
            this.picture_item_20.TabIndex = 19;
            this.picture_item_20.TabStop = false;
            this.picture_item_20.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_20.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_20.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_20.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_19
            // 
            this.picture_item_19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_19.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_19.Location = new System.Drawing.Point(80, 92);
            this.picture_item_19.Name = "picture_item_19";
            this.picture_item_19.Size = new System.Drawing.Size(32, 32);
            this.picture_item_19.Style = JHUI.JColorStyle.Blue;
            this.picture_item_19.TabIndex = 18;
            this.picture_item_19.TabStop = false;
            this.picture_item_19.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_19.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_19.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_19.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_18
            // 
            this.picture_item_18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_18.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_18.Location = new System.Drawing.Point(44, 92);
            this.picture_item_18.Name = "picture_item_18";
            this.picture_item_18.Size = new System.Drawing.Size(32, 32);
            this.picture_item_18.Style = JHUI.JColorStyle.Blue;
            this.picture_item_18.TabIndex = 17;
            this.picture_item_18.TabStop = false;
            this.picture_item_18.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_18.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_18.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_18.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_17
            // 
            this.picture_item_17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_17.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_17.Location = new System.Drawing.Point(8, 92);
            this.picture_item_17.Name = "picture_item_17";
            this.picture_item_17.Size = new System.Drawing.Size(32, 32);
            this.picture_item_17.Style = JHUI.JColorStyle.Blue;
            this.picture_item_17.TabIndex = 16;
            this.picture_item_17.TabStop = false;
            this.picture_item_17.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_17.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_17.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_17.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_16
            // 
            this.picture_item_16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_16.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_16.Location = new System.Drawing.Point(260, 57);
            this.picture_item_16.Name = "picture_item_16";
            this.picture_item_16.Size = new System.Drawing.Size(32, 32);
            this.picture_item_16.Style = JHUI.JColorStyle.Blue;
            this.picture_item_16.TabIndex = 15;
            this.picture_item_16.TabStop = false;
            this.picture_item_16.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_16.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_16.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_16.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_15
            // 
            this.picture_item_15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_15.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_15.Location = new System.Drawing.Point(224, 57);
            this.picture_item_15.Name = "picture_item_15";
            this.picture_item_15.Size = new System.Drawing.Size(32, 32);
            this.picture_item_15.Style = JHUI.JColorStyle.Blue;
            this.picture_item_15.TabIndex = 14;
            this.picture_item_15.TabStop = false;
            this.picture_item_15.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_15.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_15.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_15.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_14
            // 
            this.picture_item_14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_14.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_14.Location = new System.Drawing.Point(188, 57);
            this.picture_item_14.Name = "picture_item_14";
            this.picture_item_14.Size = new System.Drawing.Size(32, 32);
            this.picture_item_14.Style = JHUI.JColorStyle.Blue;
            this.picture_item_14.TabIndex = 13;
            this.picture_item_14.TabStop = false;
            this.picture_item_14.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_14.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_14.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_14.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_13
            // 
            this.picture_item_13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_13.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_13.Location = new System.Drawing.Point(152, 57);
            this.picture_item_13.Name = "picture_item_13";
            this.picture_item_13.Size = new System.Drawing.Size(32, 32);
            this.picture_item_13.Style = JHUI.JColorStyle.Blue;
            this.picture_item_13.TabIndex = 12;
            this.picture_item_13.TabStop = false;
            this.picture_item_13.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_13.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_13.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_13.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_12
            // 
            this.picture_item_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_12.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_12.Location = new System.Drawing.Point(117, 57);
            this.picture_item_12.Name = "picture_item_12";
            this.picture_item_12.Size = new System.Drawing.Size(32, 32);
            this.picture_item_12.Style = JHUI.JColorStyle.Blue;
            this.picture_item_12.TabIndex = 11;
            this.picture_item_12.TabStop = false;
            this.picture_item_12.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_12.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_12.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_12.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_11
            // 
            this.picture_item_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_11.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_11.Location = new System.Drawing.Point(81, 57);
            this.picture_item_11.Name = "picture_item_11";
            this.picture_item_11.Size = new System.Drawing.Size(32, 32);
            this.picture_item_11.Style = JHUI.JColorStyle.Blue;
            this.picture_item_11.TabIndex = 10;
            this.picture_item_11.TabStop = false;
            this.picture_item_11.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_11.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_11.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_11.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_10
            // 
            this.picture_item_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_10.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_10.Location = new System.Drawing.Point(45, 57);
            this.picture_item_10.Name = "picture_item_10";
            this.picture_item_10.Size = new System.Drawing.Size(32, 32);
            this.picture_item_10.Style = JHUI.JColorStyle.Blue;
            this.picture_item_10.TabIndex = 9;
            this.picture_item_10.TabStop = false;
            this.picture_item_10.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_10.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_10.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_10.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_9
            // 
            this.picture_item_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_9.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_9.Location = new System.Drawing.Point(9, 57);
            this.picture_item_9.Name = "picture_item_9";
            this.picture_item_9.Size = new System.Drawing.Size(32, 32);
            this.picture_item_9.Style = JHUI.JColorStyle.Blue;
            this.picture_item_9.TabIndex = 8;
            this.picture_item_9.TabStop = false;
            this.picture_item_9.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_9.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_9.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_9.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_8
            // 
            this.picture_item_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_8.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_8.Location = new System.Drawing.Point(260, 19);
            this.picture_item_8.Name = "picture_item_8";
            this.picture_item_8.Size = new System.Drawing.Size(32, 32);
            this.picture_item_8.Style = JHUI.JColorStyle.Blue;
            this.picture_item_8.TabIndex = 7;
            this.picture_item_8.TabStop = false;
            this.picture_item_8.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_8.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_8.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_8.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_7
            // 
            this.picture_item_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_7.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_7.Location = new System.Drawing.Point(224, 19);
            this.picture_item_7.Name = "picture_item_7";
            this.picture_item_7.Size = new System.Drawing.Size(32, 32);
            this.picture_item_7.Style = JHUI.JColorStyle.Blue;
            this.picture_item_7.TabIndex = 6;
            this.picture_item_7.TabStop = false;
            this.picture_item_7.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_7.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_7.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_7.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_6
            // 
            this.picture_item_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_6.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_6.Location = new System.Drawing.Point(188, 19);
            this.picture_item_6.Name = "picture_item_6";
            this.picture_item_6.Size = new System.Drawing.Size(32, 32);
            this.picture_item_6.Style = JHUI.JColorStyle.Blue;
            this.picture_item_6.TabIndex = 5;
            this.picture_item_6.TabStop = false;
            this.picture_item_6.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_6.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_6.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_6.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_5
            // 
            this.picture_item_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_5.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_5.Location = new System.Drawing.Point(152, 19);
            this.picture_item_5.Name = "picture_item_5";
            this.picture_item_5.Size = new System.Drawing.Size(32, 32);
            this.picture_item_5.Style = JHUI.JColorStyle.Blue;
            this.picture_item_5.TabIndex = 4;
            this.picture_item_5.TabStop = false;
            this.picture_item_5.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_5.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_5.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_5.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_4
            // 
            this.picture_item_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_4.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_4.Location = new System.Drawing.Point(117, 19);
            this.picture_item_4.Name = "picture_item_4";
            this.picture_item_4.Size = new System.Drawing.Size(32, 32);
            this.picture_item_4.Style = JHUI.JColorStyle.Blue;
            this.picture_item_4.TabIndex = 3;
            this.picture_item_4.TabStop = false;
            this.picture_item_4.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_4.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_4.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_4.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_3
            // 
            this.picture_item_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_3.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_3.Location = new System.Drawing.Point(81, 19);
            this.picture_item_3.Name = "picture_item_3";
            this.picture_item_3.Size = new System.Drawing.Size(32, 32);
            this.picture_item_3.Style = JHUI.JColorStyle.Blue;
            this.picture_item_3.TabIndex = 2;
            this.picture_item_3.TabStop = false;
            this.picture_item_3.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_3.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_3.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_3.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_2
            // 
            this.picture_item_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_2.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_2.Location = new System.Drawing.Point(45, 19);
            this.picture_item_2.Name = "picture_item_2";
            this.picture_item_2.Size = new System.Drawing.Size(32, 32);
            this.picture_item_2.Style = JHUI.JColorStyle.Blue;
            this.picture_item_2.TabIndex = 1;
            this.picture_item_2.TabStop = false;
            this.picture_item_2.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_2.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_2.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_2.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // picture_item_1
            // 
            this.picture_item_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picture_item_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_item_1.ContextMenuStrip = this.contextMenuStripSalePreview;
            this.picture_item_1.Location = new System.Drawing.Point(9, 19);
            this.picture_item_1.Name = "picture_item_1";
            this.picture_item_1.Size = new System.Drawing.Size(32, 32);
            this.picture_item_1.Style = JHUI.JColorStyle.Blue;
            this.picture_item_1.TabIndex = 0;
            this.picture_item_1.TabStop = false;
            this.picture_item_1.Theme = JHUI.JThemeStyle.Dark;
            this.picture_item_1.Click += new System.EventHandler(this.picture_item_1_Click);
            this.picture_item_1.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.picture_item_1.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // craftTab
            // 
            this.craftTab.AutoScroll = true;
            this.craftTab.Controls.Add(this.button9);
            this.craftTab.Controls.Add(this.textBox3);
            this.craftTab.Controls.Add(this.tab_craftbtn_8);
            this.craftTab.Controls.Add(this.tab_craftbtn_5);
            this.craftTab.Controls.Add(this.tab_craftbtn_7);
            this.craftTab.Controls.Add(this.tab_craftbtn_1);
            this.craftTab.Controls.Add(this.tab_craftbtn_6);
            this.craftTab.Controls.Add(this.tab_craftbtn_2);
            this.craftTab.Controls.Add(this.tab_craftbtn_3);
            this.craftTab.Controls.Add(this.tab_craftbtn_4);
            this.craftTab.Controls.Add(this.groupBox11);
            this.craftTab.Controls.Add(this.groupBox10);
            this.craftTab.Controls.Add(this.groupBox8);
            this.craftTab.HorizontalScrollbar = true;
            this.craftTab.HorizontalScrollbarBarColor = true;
            this.craftTab.HorizontalScrollbarHighlightOnWheel = false;
            this.craftTab.HorizontalScrollbarSize = 10;
            this.craftTab.Location = new System.Drawing.Point(4, 38);
            this.craftTab.Name = "craftTab";
            this.craftTab.Padding = new System.Windows.Forms.Padding(3);
            this.craftTab.Size = new System.Drawing.Size(632, 506);
            this.craftTab.Style = JHUI.JColorStyle.Blue;
            this.craftTab.TabIndex = 3;
            this.craftTab.Text = "Craft Preview";
            this.craftTab.Theme = JHUI.JThemeStyle.Dark;
            this.craftTab.UseVisualStyleBackColor = true;
            this.craftTab.VerticalScrollbar = true;
            this.craftTab.VerticalScrollbarBarColor = true;
            this.craftTab.VerticalScrollbarHighlightOnWheel = false;
            this.craftTab.VerticalScrollbarSize = 10;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(474, 6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(145, 22);
            this.button9.Style = JHUI.JColorStyle.Blue;
            this.button9.TabIndex = 50;
            this.button9.Text = "Rename Page";
            this.button9.Theme = JHUI.JThemeStyle.Dark;
            this.button9.UseSelectable = true;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.renameCraftTab);
            // 
            // textBox3
            // 
            this.textBox3.BorderBottomLineSize = 5;
            this.textBox3.BorderColor = System.Drawing.Color.Black;
            this.textBox3.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox3.CustomButton.Image = null;
            this.textBox3.CustomButton.Location = new System.Drawing.Point(125, 2);
            this.textBox3.CustomButton.Name = "";
            this.textBox3.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox3.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox3.CustomButton.TabIndex = 1;
            this.textBox3.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox3.CustomButton.UseSelectable = true;
            this.textBox3.CustomButton.Visible = false;
            this.textBox3.DrawBorder = true;
            this.textBox3.DrawBorderBottomLine = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox3.Lines = new string[0];
            this.textBox3.Location = new System.Drawing.Point(325, 7);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.ShortcutsEnabled = true;
            this.textBox3.Size = new System.Drawing.Size(143, 20);
            this.textBox3.Style = JHUI.JColorStyle.Blue;
            this.textBox3.TabIndex = 50;
            this.textBox3.TextWaterMark = "";
            this.textBox3.Theme = JHUI.JThemeStyle.Dark;
            this.textBox3.UseCustomFont = true;
            this.textBox3.UseSelectable = true;
            this.textBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tab_craftbtn_8
            // 
            this.tab_craftbtn_8.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_8.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_8.Location = new System.Drawing.Point(241, 32);
            this.tab_craftbtn_8.Name = "tab_craftbtn_8";
            this.tab_craftbtn_8.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_8.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_8.TabIndex = 44;
            this.tab_craftbtn_8.Text = "Page 7";
            this.tab_craftbtn_8.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_8.UseSelectable = true;
            this.tab_craftbtn_8.UseVisualStyleBackColor = false;
            this.tab_craftbtn_8.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_5
            // 
            this.tab_craftbtn_5.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_5.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_5.Location = new System.Drawing.Point(15, 32);
            this.tab_craftbtn_5.Name = "tab_craftbtn_5";
            this.tab_craftbtn_5.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_5.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_5.TabIndex = 45;
            this.tab_craftbtn_5.Text = "Page 4";
            this.tab_craftbtn_5.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_5.UseSelectable = true;
            this.tab_craftbtn_5.UseVisualStyleBackColor = false;
            this.tab_craftbtn_5.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_7
            // 
            this.tab_craftbtn_7.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_7.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_7.Location = new System.Drawing.Point(164, 32);
            this.tab_craftbtn_7.Name = "tab_craftbtn_7";
            this.tab_craftbtn_7.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_7.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_7.TabIndex = 43;
            this.tab_craftbtn_7.Text = "Page 6";
            this.tab_craftbtn_7.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_7.UseSelectable = true;
            this.tab_craftbtn_7.UseVisualStyleBackColor = false;
            this.tab_craftbtn_7.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_1
            // 
            this.tab_craftbtn_1.BackColor = System.Drawing.Color.Black;
            this.tab_craftbtn_1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_1.ForeColor = System.Drawing.Color.White;
            this.tab_craftbtn_1.Location = new System.Drawing.Point(15, 6);
            this.tab_craftbtn_1.Name = "tab_craftbtn_1";
            this.tab_craftbtn_1.Size = new System.Drawing.Size(69, 20);
            this.tab_craftbtn_1.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_1.TabIndex = 37;
            this.tab_craftbtn_1.Text = "Page 1";
            this.tab_craftbtn_1.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_1.UseSelectable = true;
            this.tab_craftbtn_1.UseVisualStyleBackColor = false;
            this.tab_craftbtn_1.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_6
            // 
            this.tab_craftbtn_6.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_6.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_6.Location = new System.Drawing.Point(90, 32);
            this.tab_craftbtn_6.Name = "tab_craftbtn_6";
            this.tab_craftbtn_6.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_6.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_6.TabIndex = 42;
            this.tab_craftbtn_6.Text = "Page 5";
            this.tab_craftbtn_6.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_6.UseSelectable = true;
            this.tab_craftbtn_6.UseVisualStyleBackColor = false;
            this.tab_craftbtn_6.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_2
            // 
            this.tab_craftbtn_2.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_2.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_2.Location = new System.Drawing.Point(90, 6);
            this.tab_craftbtn_2.Name = "tab_craftbtn_2";
            this.tab_craftbtn_2.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_2.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_2.TabIndex = 38;
            this.tab_craftbtn_2.Text = "Page 2";
            this.tab_craftbtn_2.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_2.UseSelectable = true;
            this.tab_craftbtn_2.UseVisualStyleBackColor = false;
            this.tab_craftbtn_2.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_3
            // 
            this.tab_craftbtn_3.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_3.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_3.Location = new System.Drawing.Point(164, 6);
            this.tab_craftbtn_3.Name = "tab_craftbtn_3";
            this.tab_craftbtn_3.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_3.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_3.TabIndex = 39;
            this.tab_craftbtn_3.Text = "Page 3";
            this.tab_craftbtn_3.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_3.UseSelectable = true;
            this.tab_craftbtn_3.UseVisualStyleBackColor = false;
            this.tab_craftbtn_3.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // tab_craftbtn_4
            // 
            this.tab_craftbtn_4.BackColor = System.Drawing.Color.White;
            this.tab_craftbtn_4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tab_craftbtn_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tab_craftbtn_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.tab_craftbtn_4.ForeColor = System.Drawing.Color.Black;
            this.tab_craftbtn_4.Location = new System.Drawing.Point(241, 6);
            this.tab_craftbtn_4.Name = "tab_craftbtn_4";
            this.tab_craftbtn_4.Size = new System.Drawing.Size(68, 20);
            this.tab_craftbtn_4.Style = JHUI.JColorStyle.Blue;
            this.tab_craftbtn_4.TabIndex = 40;
            this.tab_craftbtn_4.Text = "Page 4";
            this.tab_craftbtn_4.Theme = JHUI.JThemeStyle.Dark;
            this.tab_craftbtn_4.UseSelectable = true;
            this.tab_craftbtn_4.UseVisualStyleBackColor = false;
            this.tab_craftbtn_4.Click += new System.EventHandler(this.tab_craftbtn_1_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox11.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox11.Controls.Add(this.label2);
            this.groupBox11.Controls.Add(this.textBox20);
            this.groupBox11.Controls.Add(this.textBox16);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Controls.Add(this.textBox17);
            this.groupBox11.Controls.Add(this.textBox19);
            this.groupBox11.Controls.Add(this.label28);
            this.groupBox11.Controls.Add(this.textBox13);
            this.groupBox11.Controls.Add(this.textBox14);
            this.groupBox11.Controls.Add(this.textBox11);
            this.groupBox11.Controls.Add(this.textBox10);
            this.groupBox11.Controls.Add(this.textBox8);
            this.groupBox11.Controls.Add(this.textBox6);
            this.groupBox11.Controls.Add(this.pictureBox44);
            this.groupBox11.Controls.Add(this.pictureBox43);
            this.groupBox11.Controls.Add(this.pictureBox42);
            this.groupBox11.Controls.Add(this.textBox24);
            this.groupBox11.Controls.Add(this.label33);
            this.groupBox11.Controls.Add(this.pictureBox41);
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
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.DrawBottomLine = false;
            this.groupBox11.DrawShadows = false;
            this.groupBox11.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox11.FontSize = JHUI.JLabelSize.Small;
            this.groupBox11.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox11.Location = new System.Drawing.Point(319, 58);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.PaintDefault = false;
            this.groupBox11.Size = new System.Drawing.Size(310, 329);
            this.groupBox11.Style = JHUI.JColorStyle.Blue;
            this.groupBox11.StyleManager = null;
            this.groupBox11.TabIndex = 50;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Recipe Edit";
            this.groupBox11.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox11.UseStyleColors = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DropShadowColor = System.Drawing.Color.Black;
            this.label2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(10, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.Style = JHUI.JColorStyle.Blue;
            this.label2.TabIndex = 93;
            this.label2.Text = "ID:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox20
            // 
            this.textBox20.BorderBottomLineSize = 5;
            this.textBox20.BorderColor = System.Drawing.Color.Black;
            this.textBox20.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox20.CustomButton.Image = null;
            this.textBox20.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox20.CustomButton.Name = "";
            this.textBox20.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox20.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox20.CustomButton.TabIndex = 1;
            this.textBox20.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox20.CustomButton.UseSelectable = true;
            this.textBox20.CustomButton.Visible = false;
            this.textBox20.DrawBorder = true;
            this.textBox20.DrawBorderBottomLine = false;
            this.textBox20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox20.Lines = new string[0];
            this.textBox20.Location = new System.Drawing.Point(103, 172);
            this.textBox20.MaxLength = 32767;
            this.textBox20.Name = "textBox20";
            this.textBox20.PasswordChar = '\0';
            this.textBox20.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox20.SelectedText = "";
            this.textBox20.SelectionLength = 0;
            this.textBox20.SelectionStart = 0;
            this.textBox20.ShortcutsEnabled = true;
            this.textBox20.Size = new System.Drawing.Size(44, 20);
            this.textBox20.Style = JHUI.JColorStyle.Blue;
            this.textBox20.TabIndex = 87;
            this.textBox20.TextWaterMark = "";
            this.textBox20.Theme = JHUI.JThemeStyle.Dark;
            this.textBox20.UseCustomFont = true;
            this.textBox20.UseSelectable = true;
            this.textBox20.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox20.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox16
            // 
            this.textBox16.BorderBottomLineSize = 5;
            this.textBox16.BorderColor = System.Drawing.Color.Black;
            this.textBox16.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox16.CustomButton.Image = null;
            this.textBox16.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox16.CustomButton.Name = "";
            this.textBox16.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox16.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox16.CustomButton.TabIndex = 1;
            this.textBox16.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox16.CustomButton.UseSelectable = true;
            this.textBox16.CustomButton.Visible = false;
            this.textBox16.DrawBorder = true;
            this.textBox16.DrawBorderBottomLine = false;
            this.textBox16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox16.Lines = new string[0];
            this.textBox16.Location = new System.Drawing.Point(254, 249);
            this.textBox16.MaxLength = 32767;
            this.textBox16.Name = "textBox16";
            this.textBox16.PasswordChar = '\0';
            this.textBox16.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox16.SelectedText = "";
            this.textBox16.SelectionLength = 0;
            this.textBox16.SelectionStart = 0;
            this.textBox16.ShortcutsEnabled = true;
            this.textBox16.Size = new System.Drawing.Size(44, 20);
            this.textBox16.Style = JHUI.JColorStyle.Blue;
            this.textBox16.TabIndex = 53;
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox16.TextWaterMark = "";
            this.textBox16.Theme = JHUI.JThemeStyle.Dark;
            this.textBox16.UseCustomFont = true;
            this.textBox16.UseSelectable = true;
            this.textBox16.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox16.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.DropShadowColor = System.Drawing.Color.Black;
            this.label29.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label29.FontSize = JHUI.JLabelSize.Small;
            this.label29.Location = new System.Drawing.Point(9, 176);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 15);
            this.label29.Style = JHUI.JColorStyle.Blue;
            this.label29.TabIndex = 88;
            this.label29.Text = "Duration:";
            this.label29.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox17
            // 
            this.textBox17.BorderBottomLineSize = 5;
            this.textBox17.BorderColor = System.Drawing.Color.Black;
            this.textBox17.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox17.CustomButton.Image = null;
            this.textBox17.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox17.CustomButton.Name = "";
            this.textBox17.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox17.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox17.CustomButton.TabIndex = 1;
            this.textBox17.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox17.CustomButton.UseSelectable = true;
            this.textBox17.CustomButton.Visible = false;
            this.textBox17.DrawBorder = true;
            this.textBox17.DrawBorderBottomLine = false;
            this.textBox17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox17.Lines = new string[0];
            this.textBox17.Location = new System.Drawing.Point(254, 275);
            this.textBox17.MaxLength = 32767;
            this.textBox17.Name = "textBox17";
            this.textBox17.PasswordChar = '\0';
            this.textBox17.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox17.SelectedText = "";
            this.textBox17.SelectionLength = 0;
            this.textBox17.SelectionStart = 0;
            this.textBox17.ShortcutsEnabled = true;
            this.textBox17.Size = new System.Drawing.Size(44, 20);
            this.textBox17.Style = JHUI.JColorStyle.Blue;
            this.textBox17.TabIndex = 66;
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox17.TextWaterMark = "";
            this.textBox17.Theme = JHUI.JThemeStyle.Dark;
            this.textBox17.UseCustomFont = true;
            this.textBox17.UseSelectable = true;
            this.textBox17.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox17.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox17.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // textBox19
            // 
            this.textBox19.BorderBottomLineSize = 5;
            this.textBox19.BorderColor = System.Drawing.Color.Black;
            this.textBox19.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox19.CustomButton.Image = null;
            this.textBox19.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox19.CustomButton.Name = "";
            this.textBox19.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox19.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox19.CustomButton.TabIndex = 1;
            this.textBox19.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox19.CustomButton.UseSelectable = true;
            this.textBox19.CustomButton.Visible = false;
            this.textBox19.DrawBorder = true;
            this.textBox19.DrawBorderBottomLine = false;
            this.textBox19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox19.Lines = new string[0];
            this.textBox19.Location = new System.Drawing.Point(261, 147);
            this.textBox19.MaxLength = 32767;
            this.textBox19.Name = "textBox19";
            this.textBox19.PasswordChar = '\0';
            this.textBox19.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox19.SelectedText = "";
            this.textBox19.SelectionLength = 0;
            this.textBox19.SelectionStart = 0;
            this.textBox19.ShortcutsEnabled = true;
            this.textBox19.Size = new System.Drawing.Size(44, 20);
            this.textBox19.Style = JHUI.JColorStyle.Blue;
            this.textBox19.TabIndex = 85;
            this.textBox19.TextWaterMark = "";
            this.textBox19.Theme = JHUI.JThemeStyle.Dark;
            this.textBox19.UseCustomFont = true;
            this.textBox19.UseSelectable = true;
            this.textBox19.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox19.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.DropShadowColor = System.Drawing.Color.Black;
            this.label28.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label28.FontSize = JHUI.JLabelSize.Small;
            this.label28.Location = new System.Drawing.Point(167, 152);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 15);
            this.label28.Style = JHUI.JColorStyle.Blue;
            this.label28.TabIndex = 86;
            this.label28.Text = "Price:";
            this.label28.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox13
            // 
            this.textBox13.BorderBottomLineSize = 5;
            this.textBox13.BorderColor = System.Drawing.Color.Black;
            this.textBox13.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox13.CustomButton.Image = null;
            this.textBox13.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox13.CustomButton.Name = "";
            this.textBox13.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox13.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox13.CustomButton.TabIndex = 1;
            this.textBox13.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox13.CustomButton.UseSelectable = true;
            this.textBox13.CustomButton.Visible = false;
            this.textBox13.DrawBorder = true;
            this.textBox13.DrawBorderBottomLine = false;
            this.textBox13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox13.Lines = new string[0];
            this.textBox13.Location = new System.Drawing.Point(183, 249);
            this.textBox13.MaxLength = 32767;
            this.textBox13.Name = "textBox13";
            this.textBox13.PasswordChar = '\0';
            this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox13.SelectedText = "";
            this.textBox13.SelectionLength = 0;
            this.textBox13.SelectionStart = 0;
            this.textBox13.ShortcutsEnabled = true;
            this.textBox13.Size = new System.Drawing.Size(44, 20);
            this.textBox13.Style = JHUI.JColorStyle.Blue;
            this.textBox13.TabIndex = 53;
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox13.TextWaterMark = "";
            this.textBox13.Theme = JHUI.JThemeStyle.Dark;
            this.textBox13.UseCustomFont = true;
            this.textBox13.UseSelectable = true;
            this.textBox13.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox13.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox14
            // 
            this.textBox14.BorderBottomLineSize = 5;
            this.textBox14.BorderColor = System.Drawing.Color.Black;
            this.textBox14.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox14.CustomButton.Image = null;
            this.textBox14.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox14.CustomButton.Name = "";
            this.textBox14.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox14.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox14.CustomButton.TabIndex = 1;
            this.textBox14.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox14.CustomButton.UseSelectable = true;
            this.textBox14.CustomButton.Visible = false;
            this.textBox14.DrawBorder = true;
            this.textBox14.DrawBorderBottomLine = false;
            this.textBox14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox14.Lines = new string[0];
            this.textBox14.Location = new System.Drawing.Point(183, 277);
            this.textBox14.MaxLength = 32767;
            this.textBox14.Name = "textBox14";
            this.textBox14.PasswordChar = '\0';
            this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox14.SelectedText = "";
            this.textBox14.SelectionLength = 0;
            this.textBox14.SelectionStart = 0;
            this.textBox14.ShortcutsEnabled = true;
            this.textBox14.Size = new System.Drawing.Size(44, 20);
            this.textBox14.Style = JHUI.JColorStyle.Blue;
            this.textBox14.TabIndex = 66;
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox14.TextWaterMark = "";
            this.textBox14.Theme = JHUI.JThemeStyle.Dark;
            this.textBox14.UseCustomFont = true;
            this.textBox14.UseSelectable = true;
            this.textBox14.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox14.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox14.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // textBox11
            // 
            this.textBox11.BorderBottomLineSize = 5;
            this.textBox11.BorderColor = System.Drawing.Color.Black;
            this.textBox11.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox11.CustomButton.Image = null;
            this.textBox11.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox11.CustomButton.Name = "";
            this.textBox11.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox11.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox11.CustomButton.TabIndex = 1;
            this.textBox11.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox11.CustomButton.UseSelectable = true;
            this.textBox11.CustomButton.Visible = false;
            this.textBox11.DrawBorder = true;
            this.textBox11.DrawBorderBottomLine = false;
            this.textBox11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox11.Lines = new string[0];
            this.textBox11.Location = new System.Drawing.Point(108, 277);
            this.textBox11.MaxLength = 32767;
            this.textBox11.Name = "textBox11";
            this.textBox11.PasswordChar = '\0';
            this.textBox11.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox11.SelectedText = "";
            this.textBox11.SelectionLength = 0;
            this.textBox11.SelectionStart = 0;
            this.textBox11.ShortcutsEnabled = true;
            this.textBox11.Size = new System.Drawing.Size(44, 20);
            this.textBox11.Style = JHUI.JColorStyle.Blue;
            this.textBox11.TabIndex = 66;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox11.TextWaterMark = "";
            this.textBox11.Theme = JHUI.JThemeStyle.Dark;
            this.textBox11.UseCustomFont = true;
            this.textBox11.UseSelectable = true;
            this.textBox11.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox11.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox11.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // textBox10
            // 
            this.textBox10.BorderBottomLineSize = 5;
            this.textBox10.BorderColor = System.Drawing.Color.Black;
            this.textBox10.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox10.CustomButton.Image = null;
            this.textBox10.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox10.CustomButton.Name = "";
            this.textBox10.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox10.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox10.CustomButton.TabIndex = 1;
            this.textBox10.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox10.CustomButton.UseSelectable = true;
            this.textBox10.CustomButton.Visible = false;
            this.textBox10.DrawBorder = true;
            this.textBox10.DrawBorderBottomLine = false;
            this.textBox10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox10.Lines = new string[0];
            this.textBox10.Location = new System.Drawing.Point(108, 249);
            this.textBox10.MaxLength = 32767;
            this.textBox10.Name = "textBox10";
            this.textBox10.PasswordChar = '\0';
            this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox10.SelectedText = "";
            this.textBox10.SelectionLength = 0;
            this.textBox10.SelectionStart = 0;
            this.textBox10.ShortcutsEnabled = true;
            this.textBox10.Size = new System.Drawing.Size(44, 20);
            this.textBox10.Style = JHUI.JColorStyle.Blue;
            this.textBox10.TabIndex = 53;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox10.TextWaterMark = "";
            this.textBox10.Theme = JHUI.JThemeStyle.Dark;
            this.textBox10.UseCustomFont = true;
            this.textBox10.UseSelectable = true;
            this.textBox10.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox10.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox8
            // 
            this.textBox8.BorderBottomLineSize = 5;
            this.textBox8.BorderColor = System.Drawing.Color.Black;
            this.textBox8.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox8.CustomButton.Image = null;
            this.textBox8.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox8.CustomButton.Name = "";
            this.textBox8.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox8.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox8.CustomButton.TabIndex = 1;
            this.textBox8.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox8.CustomButton.UseSelectable = true;
            this.textBox8.CustomButton.Visible = false;
            this.textBox8.DrawBorder = true;
            this.textBox8.DrawBorderBottomLine = false;
            this.textBox8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox8.Lines = new string[0];
            this.textBox8.Location = new System.Drawing.Point(37, 277);
            this.textBox8.MaxLength = 32767;
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = '\0';
            this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox8.SelectedText = "";
            this.textBox8.SelectionLength = 0;
            this.textBox8.SelectionStart = 0;
            this.textBox8.ShortcutsEnabled = true;
            this.textBox8.Size = new System.Drawing.Size(44, 20);
            this.textBox8.Style = JHUI.JColorStyle.Blue;
            this.textBox8.TabIndex = 66;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox8.TextWaterMark = "";
            this.textBox8.Theme = JHUI.JThemeStyle.Dark;
            this.textBox8.UseCustomFont = true;
            this.textBox8.UseSelectable = true;
            this.textBox8.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox8.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_Leave);
            // 
            // textBox6
            // 
            this.textBox6.BorderBottomLineSize = 5;
            this.textBox6.BorderColor = System.Drawing.Color.Black;
            this.textBox6.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox6.CustomButton.Image = null;
            this.textBox6.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox6.CustomButton.Name = "";
            this.textBox6.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox6.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox6.CustomButton.TabIndex = 1;
            this.textBox6.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox6.CustomButton.UseSelectable = true;
            this.textBox6.CustomButton.Visible = false;
            this.textBox6.DrawBorder = true;
            this.textBox6.DrawBorderBottomLine = false;
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox6.Lines = new string[0];
            this.textBox6.Location = new System.Drawing.Point(37, 249);
            this.textBox6.MaxLength = 32767;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox6.SelectedText = "";
            this.textBox6.SelectionLength = 0;
            this.textBox6.SelectionStart = 0;
            this.textBox6.ShortcutsEnabled = true;
            this.textBox6.Size = new System.Drawing.Size(44, 20);
            this.textBox6.Style = JHUI.JColorStyle.Blue;
            this.textBox6.TabIndex = 53;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.TextWaterMark = "";
            this.textBox6.Theme = JHUI.JThemeStyle.Dark;
            this.textBox6.UseCustomFont = true;
            this.textBox6.UseSelectable = true;
            this.textBox6.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox6.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox44
            // 
            this.pictureBox44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox44.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox44.Location = new System.Drawing.Point(259, 211);
            this.pictureBox44.Name = "pictureBox44";
            this.pictureBox44.Size = new System.Drawing.Size(32, 32);
            this.pictureBox44.Style = JHUI.JColorStyle.Blue;
            this.pictureBox44.TabIndex = 50;
            this.pictureBox44.TabStop = false;
            this.pictureBox44.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox44.WaitOnLoad = true;
            // 
            // pictureBox43
            // 
            this.pictureBox43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox43.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox43.Location = new System.Drawing.Point(189, 211);
            this.pictureBox43.Name = "pictureBox43";
            this.pictureBox43.Size = new System.Drawing.Size(32, 32);
            this.pictureBox43.Style = JHUI.JColorStyle.Blue;
            this.pictureBox43.TabIndex = 50;
            this.pictureBox43.TabStop = false;
            this.pictureBox43.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox43.WaitOnLoad = true;
            // 
            // pictureBox42
            // 
            this.pictureBox42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox42.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox42.Location = new System.Drawing.Point(113, 211);
            this.pictureBox42.Name = "pictureBox42";
            this.pictureBox42.Size = new System.Drawing.Size(32, 32);
            this.pictureBox42.Style = JHUI.JColorStyle.Blue;
            this.pictureBox42.TabIndex = 50;
            this.pictureBox42.TabStop = false;
            this.pictureBox42.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox42.WaitOnLoad = true;
            // 
            // textBox24
            // 
            this.textBox24.BorderBottomLineSize = 5;
            this.textBox24.BorderColor = System.Drawing.Color.Black;
            this.textBox24.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox24.CustomButton.Image = null;
            this.textBox24.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox24.CustomButton.Name = "";
            this.textBox24.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox24.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox24.CustomButton.TabIndex = 1;
            this.textBox24.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox24.CustomButton.UseSelectable = true;
            this.textBox24.CustomButton.Visible = false;
            this.textBox24.DrawBorder = true;
            this.textBox24.DrawBorderBottomLine = false;
            this.textBox24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox24.Lines = new string[0];
            this.textBox24.Location = new System.Drawing.Point(103, 147);
            this.textBox24.MaxLength = 32767;
            this.textBox24.Name = "textBox24";
            this.textBox24.PasswordChar = '\0';
            this.textBox24.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox24.SelectedText = "";
            this.textBox24.SelectionLength = 0;
            this.textBox24.SelectionStart = 0;
            this.textBox24.ShortcutsEnabled = true;
            this.textBox24.Size = new System.Drawing.Size(44, 20);
            this.textBox24.Style = JHUI.JColorStyle.Blue;
            this.textBox24.TabIndex = 91;
            this.textBox24.TextWaterMark = "";
            this.textBox24.Theme = JHUI.JThemeStyle.Dark;
            this.textBox24.UseCustomFont = true;
            this.textBox24.UseSelectable = true;
            this.textBox24.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox24.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.DropShadowColor = System.Drawing.Color.Black;
            this.label33.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label33.FontSize = JHUI.JLabelSize.Small;
            this.label33.Location = new System.Drawing.Point(9, 150);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(79, 15);
            this.label33.Style = JHUI.JColorStyle.Blue;
            this.label33.TabIndex = 92;
            this.label33.Text = "Num to make:";
            this.label33.Theme = JHUI.JThemeStyle.Dark;
            // 
            // pictureBox41
            // 
            this.pictureBox41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox41.Location = new System.Drawing.Point(41, 211);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(32, 32);
            this.pictureBox41.Style = JHUI.JColorStyle.Blue;
            this.pictureBox41.TabIndex = 50;
            this.pictureBox41.TabStop = false;
            this.pictureBox41.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox41.WaitOnLoad = true;
            // 
            // textBox22
            // 
            this.textBox22.BorderBottomLineSize = 5;
            this.textBox22.BorderColor = System.Drawing.Color.Black;
            this.textBox22.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox22.CustomButton.Image = null;
            this.textBox22.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox22.CustomButton.Name = "";
            this.textBox22.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox22.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox22.CustomButton.TabIndex = 1;
            this.textBox22.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox22.CustomButton.UseSelectable = true;
            this.textBox22.CustomButton.Visible = false;
            this.textBox22.DrawBorder = true;
            this.textBox22.DrawBorderBottomLine = false;
            this.textBox22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox22.Lines = new string[0];
            this.textBox22.Location = new System.Drawing.Point(261, 123);
            this.textBox22.MaxLength = 32767;
            this.textBox22.Name = "textBox22";
            this.textBox22.PasswordChar = '\0';
            this.textBox22.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox22.SelectedText = "";
            this.textBox22.SelectionLength = 0;
            this.textBox22.SelectionStart = 0;
            this.textBox22.ShortcutsEnabled = true;
            this.textBox22.Size = new System.Drawing.Size(44, 20);
            this.textBox22.Style = JHUI.JColorStyle.Blue;
            this.textBox22.TabIndex = 87;
            this.textBox22.TextWaterMark = "";
            this.textBox22.Theme = JHUI.JThemeStyle.Dark;
            this.textBox22.UseCustomFont = true;
            this.textBox22.UseSelectable = true;
            this.textBox22.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox22.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.DropShadowColor = System.Drawing.Color.Black;
            this.label31.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label31.FontSize = JHUI.JLabelSize.Small;
            this.label31.Location = new System.Drawing.Point(167, 126);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 15);
            this.label31.Style = JHUI.JColorStyle.Blue;
            this.label31.TabIndex = 88;
            this.label31.Text = "SP:";
            this.label31.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox21
            // 
            this.textBox21.BorderBottomLineSize = 5;
            this.textBox21.BorderColor = System.Drawing.Color.Black;
            this.textBox21.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox21.CustomButton.Image = null;
            this.textBox21.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox21.CustomButton.Name = "";
            this.textBox21.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox21.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox21.CustomButton.TabIndex = 1;
            this.textBox21.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox21.CustomButton.UseSelectable = true;
            this.textBox21.CustomButton.Visible = false;
            this.textBox21.DrawBorder = true;
            this.textBox21.DrawBorderBottomLine = false;
            this.textBox21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox21.Lines = new string[0];
            this.textBox21.Location = new System.Drawing.Point(103, 123);
            this.textBox21.MaxLength = 32767;
            this.textBox21.Name = "textBox21";
            this.textBox21.PasswordChar = '\0';
            this.textBox21.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox21.SelectedText = "";
            this.textBox21.SelectionLength = 0;
            this.textBox21.SelectionStart = 0;
            this.textBox21.ShortcutsEnabled = true;
            this.textBox21.Size = new System.Drawing.Size(44, 20);
            this.textBox21.Style = JHUI.JColorStyle.Blue;
            this.textBox21.TabIndex = 85;
            this.textBox21.TextWaterMark = "";
            this.textBox21.Theme = JHUI.JThemeStyle.Dark;
            this.textBox21.UseCustomFont = true;
            this.textBox21.UseSelectable = true;
            this.textBox21.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox21.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.DropShadowColor = System.Drawing.Color.Black;
            this.label30.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label30.FontSize = JHUI.JLabelSize.Small;
            this.label30.Location = new System.Drawing.Point(9, 126);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 15);
            this.label30.Style = JHUI.JColorStyle.Blue;
            this.label30.TabIndex = 86;
            this.label30.Text = "EXP:";
            this.label30.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox18
            // 
            this.textBox18.BorderBottomLineSize = 5;
            this.textBox18.BorderColor = System.Drawing.Color.Black;
            this.textBox18.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox18.CustomButton.Image = null;
            this.textBox18.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox18.CustomButton.Name = "";
            this.textBox18.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox18.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox18.CustomButton.TabIndex = 1;
            this.textBox18.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox18.CustomButton.UseSelectable = true;
            this.textBox18.CustomButton.Visible = false;
            this.textBox18.DrawBorder = true;
            this.textBox18.DrawBorderBottomLine = false;
            this.textBox18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox18.Lines = new string[0];
            this.textBox18.Location = new System.Drawing.Point(103, 99);
            this.textBox18.MaxLength = 32767;
            this.textBox18.Name = "textBox18";
            this.textBox18.PasswordChar = '\0';
            this.textBox18.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox18.SelectedText = "";
            this.textBox18.SelectionLength = 0;
            this.textBox18.SelectionStart = 0;
            this.textBox18.ShortcutsEnabled = true;
            this.textBox18.Size = new System.Drawing.Size(44, 20);
            this.textBox18.Style = JHUI.JColorStyle.Blue;
            this.textBox18.TabIndex = 83;
            this.textBox18.TextWaterMark = "";
            this.textBox18.Theme = JHUI.JThemeStyle.Dark;
            this.textBox18.UseCustomFont = true;
            this.textBox18.UseSelectable = true;
            this.textBox18.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox18.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.DropShadowColor = System.Drawing.Color.Black;
            this.label27.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label27.FontSize = JHUI.JLabelSize.Small;
            this.label27.Location = new System.Drawing.Point(9, 99);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 15);
            this.label27.Style = JHUI.JColorStyle.Blue;
            this.label27.TabIndex = 84;
            this.label27.Text = "Bind Type:";
            this.label27.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox15
            // 
            this.textBox15.BorderBottomLineSize = 5;
            this.textBox15.BorderColor = System.Drawing.Color.Black;
            this.textBox15.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox15.CustomButton.Image = null;
            this.textBox15.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox15.CustomButton.Name = "";
            this.textBox15.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox15.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox15.CustomButton.TabIndex = 1;
            this.textBox15.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox15.CustomButton.UseSelectable = true;
            this.textBox15.CustomButton.Visible = false;
            this.textBox15.DrawBorder = true;
            this.textBox15.DrawBorderBottomLine = false;
            this.textBox15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox15.Lines = new string[0];
            this.textBox15.Location = new System.Drawing.Point(261, 99);
            this.textBox15.MaxLength = 32767;
            this.textBox15.Name = "textBox15";
            this.textBox15.PasswordChar = '\0';
            this.textBox15.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox15.SelectedText = "";
            this.textBox15.SelectionLength = 0;
            this.textBox15.SelectionStart = 0;
            this.textBox15.ShortcutsEnabled = true;
            this.textBox15.Size = new System.Drawing.Size(44, 20);
            this.textBox15.Style = JHUI.JColorStyle.Blue;
            this.textBox15.TabIndex = 81;
            this.textBox15.TextWaterMark = "";
            this.textBox15.Theme = JHUI.JThemeStyle.Dark;
            this.textBox15.UseCustomFont = true;
            this.textBox15.UseSelectable = true;
            this.textBox15.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox15.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.DropShadowColor = System.Drawing.Color.Black;
            this.label26.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label26.FontSize = JHUI.JLabelSize.Small;
            this.label26.Location = new System.Drawing.Point(167, 102);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 15);
            this.label26.Style = JHUI.JColorStyle.Blue;
            this.label26.TabIndex = 82;
            this.label26.Text = "Craft Skill Level:";
            this.label26.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox12
            // 
            this.textBox12.BorderBottomLineSize = 5;
            this.textBox12.BorderColor = System.Drawing.Color.Black;
            this.textBox12.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox12.CustomButton.Image = null;
            this.textBox12.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox12.CustomButton.Name = "";
            this.textBox12.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox12.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox12.CustomButton.TabIndex = 1;
            this.textBox12.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox12.CustomButton.UseSelectable = true;
            this.textBox12.CustomButton.Visible = false;
            this.textBox12.DrawBorder = true;
            this.textBox12.DrawBorderBottomLine = false;
            this.textBox12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox12.Lines = new string[0];
            this.textBox12.Location = new System.Drawing.Point(261, 73);
            this.textBox12.MaxLength = 32767;
            this.textBox12.Name = "textBox12";
            this.textBox12.PasswordChar = '\0';
            this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox12.SelectedText = "";
            this.textBox12.SelectionLength = 0;
            this.textBox12.SelectionStart = 0;
            this.textBox12.ShortcutsEnabled = true;
            this.textBox12.Size = new System.Drawing.Size(44, 20);
            this.textBox12.Style = JHUI.JColorStyle.Blue;
            this.textBox12.TabIndex = 79;
            this.textBox12.TextWaterMark = "";
            this.textBox12.Theme = JHUI.JThemeStyle.Dark;
            this.textBox12.UseCustomFont = true;
            this.textBox12.UseSelectable = true;
            this.textBox12.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox12.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.DropShadowColor = System.Drawing.Color.Black;
            this.label25.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label25.FontSize = JHUI.JLabelSize.Small;
            this.label25.Location = new System.Drawing.Point(167, 80);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 15);
            this.label25.Style = JHUI.JColorStyle.Blue;
            this.label25.TabIndex = 80;
            this.label25.Text = "Craft Skill Id:";
            this.label25.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox9
            // 
            this.textBox9.BorderBottomLineSize = 5;
            this.textBox9.BorderColor = System.Drawing.Color.Black;
            this.textBox9.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox9.CustomButton.Image = null;
            this.textBox9.CustomButton.Location = new System.Drawing.Point(26, 2);
            this.textBox9.CustomButton.Name = "";
            this.textBox9.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox9.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox9.CustomButton.TabIndex = 1;
            this.textBox9.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox9.CustomButton.UseSelectable = true;
            this.textBox9.CustomButton.Visible = false;
            this.textBox9.DrawBorder = true;
            this.textBox9.DrawBorderBottomLine = false;
            this.textBox9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox9.Lines = new string[0];
            this.textBox9.Location = new System.Drawing.Point(103, 73);
            this.textBox9.MaxLength = 32767;
            this.textBox9.Name = "textBox9";
            this.textBox9.PasswordChar = '\0';
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox9.SelectedText = "";
            this.textBox9.SelectionLength = 0;
            this.textBox9.SelectionStart = 0;
            this.textBox9.ShortcutsEnabled = true;
            this.textBox9.Size = new System.Drawing.Size(44, 20);
            this.textBox9.Style = JHUI.JColorStyle.Blue;
            this.textBox9.TabIndex = 72;
            this.textBox9.TextWaterMark = "";
            this.textBox9.Theme = JHUI.JThemeStyle.Dark;
            this.textBox9.UseCustomFont = true;
            this.textBox9.UseSelectable = true;
            this.textBox9.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox9.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.DropShadowColor = System.Drawing.Color.Black;
            this.label24.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label24.FontSize = JHUI.JLabelSize.Small;
            this.label24.Location = new System.Drawing.Point(9, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 15);
            this.label24.Style = JHUI.JColorStyle.Blue;
            this.label24.TabIndex = 78;
            this.label24.Text = "Level:";
            this.label24.Theme = JHUI.JThemeStyle.Dark;
            // 
            // comboBox2
            // 
            this.comboBox2.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox2.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 19;
            this.comboBox2.Location = new System.Drawing.Point(103, 44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 25);
            this.comboBox2.Style = JHUI.JColorStyle.Blue;
            this.comboBox2.TabIndex = 77;
            this.comboBox2.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox2.UseSelectable = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.DropShadowColor = System.Drawing.Color.Black;
            this.label23.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label23.FontSize = JHUI.JLabelSize.Small;
            this.label23.Location = new System.Drawing.Point(9, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 15);
            this.label23.Style = JHUI.JColorStyle.Blue;
            this.label23.TabIndex = 76;
            this.label23.Text = "Recipe Subtype:";
            this.label23.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.DropShadowColor = System.Drawing.Color.Black;
            this.label20.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label20.FontSize = JHUI.JLabelSize.Small;
            this.label20.Location = new System.Drawing.Point(9, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 15);
            this.label20.Style = JHUI.JColorStyle.Blue;
            this.label20.TabIndex = 75;
            this.label20.Text = "Recipe Type:";
            this.label20.Theme = JHUI.JThemeStyle.Dark;
            // 
            // comboBox1
            // 
            this.comboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 19;
            this.comboBox1.Location = new System.Drawing.Point(103, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 25);
            this.comboBox1.Style = JHUI.JColorStyle.Blue;
            this.comboBox1.TabIndex = 74;
            this.comboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox1.UseSelectable = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.DropShadowColor = System.Drawing.Color.Black;
            this.label17.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label17.FontSize = JHUI.JLabelSize.Small;
            this.label17.Location = new System.Drawing.Point(271, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 15);
            this.label17.Style = JHUI.JColorStyle.Blue;
            this.label17.TabIndex = 73;
            this.label17.Text = "100%";
            this.label17.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DropShadowColor = System.Drawing.Color.Black;
            this.label8.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label8.FontSize = JHUI.JLabelSize.Small;
            this.label8.Location = new System.Drawing.Point(167, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.Style = JHUI.JColorStyle.Blue;
            this.label8.TabIndex = 72;
            this.label8.Text = "Total Chance:";
            this.label8.Theme = JHUI.JThemeStyle.Dark;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(236, 301);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(69, 22);
            this.button12.Style = JHUI.JColorStyle.Blue;
            this.button12.TabIndex = 71;
            this.button12.Text = "Save";
            this.button12.Theme = JHUI.JThemeStyle.Dark;
            this.button12.UseSelectable = true;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.modifyClickOtherCraftingItems);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DropShadowColor = System.Drawing.Color.Black;
            this.label6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label6.FontSize = JHUI.JLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(-4, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.Style = JHUI.JColorStyle.Blue;
            this.label6.TabIndex = 94;
            this.label6.Text = "Prob:";
            this.label6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox10.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
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
            this.groupBox10.DrawBottomLine = false;
            this.groupBox10.DrawShadows = false;
            this.groupBox10.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox10.FontSize = JHUI.JLabelSize.Small;
            this.groupBox10.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox10.Location = new System.Drawing.Point(12, 267);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.PaintDefault = false;
            this.groupBox10.Size = new System.Drawing.Size(301, 120);
            this.groupBox10.Style = JHUI.JColorStyle.Blue;
            this.groupBox10.StyleManager = null;
            this.groupBox10.TabIndex = 49;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Required Items";
            this.groupBox10.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox10.UseStyleColors = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(223, 93);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(69, 22);
            this.button14.Style = JHUI.JColorStyle.Blue;
            this.button14.TabIndex = 71;
            this.button14.Text = "Add";
            this.button14.Theme = JHUI.JThemeStyle.Dark;
            this.button14.UseSelectable = true;
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
            this.button11.Location = new System.Drawing.Point(223, 93);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(69, 22);
            this.button11.Style = JHUI.JColorStyle.Blue;
            this.button11.TabIndex = 70;
            this.button11.Text = "Modify";
            this.button11.Theme = JHUI.JThemeStyle.Dark;
            this.button11.UseSelectable = true;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.ModifyRecipe);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DropShadowColor = System.Drawing.Color.Black;
            this.label4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label4.FontSize = JHUI.JLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(51, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.Style = JHUI.JColorStyle.Blue;
            this.label4.TabIndex = 68;
            this.label4.Text = "ID:";
            this.label4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DropShadowColor = System.Drawing.Color.Black;
            this.label3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label3.FontSize = JHUI.JLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(129, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.Style = JHUI.JColorStyle.Blue;
            this.label3.TabIndex = 67;
            this.label3.Text = "Count:";
            this.label3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox5
            // 
            this.textBox5.BorderBottomLineSize = 5;
            this.textBox5.BorderColor = System.Drawing.Color.Black;
            this.textBox5.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox5.CustomButton.Image = null;
            this.textBox5.CustomButton.Location = new System.Drawing.Point(24, 2);
            this.textBox5.CustomButton.Name = "";
            this.textBox5.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.textBox5.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox5.CustomButton.TabIndex = 1;
            this.textBox5.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox5.CustomButton.UseSelectable = true;
            this.textBox5.CustomButton.Visible = false;
            this.textBox5.DrawBorder = true;
            this.textBox5.DrawBorderBottomLine = false;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox5.Lines = new string[0];
            this.textBox5.Location = new System.Drawing.Point(173, 93);
            this.textBox5.MaxLength = 32767;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox5.SelectedText = "";
            this.textBox5.SelectionLength = 0;
            this.textBox5.SelectionStart = 0;
            this.textBox5.ShortcutsEnabled = true;
            this.textBox5.Size = new System.Drawing.Size(44, 22);
            this.textBox5.Style = JHUI.JColorStyle.Blue;
            this.textBox5.TabIndex = 69;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextWaterMark = "";
            this.textBox5.Theme = JHUI.JThemeStyle.Dark;
            this.textBox5.UseCustomFont = true;
            this.textBox5.UseSelectable = true;
            this.textBox5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox_craft_req_5
            // 
            this.pictureBox_craft_req_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_5.Location = new System.Drawing.Point(9, 55);
            this.pictureBox_craft_req_5.Name = "pictureBox_craft_req_5";
            this.pictureBox_craft_req_5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_5.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_5.TabIndex = 53;
            this.pictureBox_craft_req_5.TabStop = false;
            this.pictureBox_craft_req_5.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_5.WaitOnLoad = true;
            this.pictureBox_craft_req_5.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // textBox4
            // 
            this.textBox4.BorderBottomLineSize = 5;
            this.textBox4.BorderColor = System.Drawing.Color.Black;
            this.textBox4.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox4.CustomButton.Image = null;
            this.textBox4.CustomButton.Location = new System.Drawing.Point(24, 2);
            this.textBox4.CustomButton.Name = "";
            this.textBox4.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.textBox4.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox4.CustomButton.TabIndex = 1;
            this.textBox4.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox4.CustomButton.UseSelectable = true;
            this.textBox4.CustomButton.Visible = false;
            this.textBox4.DrawBorder = true;
            this.textBox4.DrawBorderBottomLine = false;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox4.Lines = new string[0];
            this.textBox4.Location = new System.Drawing.Point(78, 93);
            this.textBox4.MaxLength = 32767;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox4.SelectedText = "";
            this.textBox4.SelectionLength = 0;
            this.textBox4.SelectionStart = 0;
            this.textBox4.ShortcutsEnabled = true;
            this.textBox4.Size = new System.Drawing.Size(44, 22);
            this.textBox4.Style = JHUI.JColorStyle.Blue;
            this.textBox4.TabIndex = 66;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextWaterMark = "";
            this.textBox4.Theme = JHUI.JThemeStyle.Dark;
            this.textBox4.UseCustomFont = true;
            this.textBox4.UseSelectable = true;
            this.textBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox_craft_req_4
            // 
            this.pictureBox_craft_req_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_4.Location = new System.Drawing.Point(260, 17);
            this.pictureBox_craft_req_4.Name = "pictureBox_craft_req_4";
            this.pictureBox_craft_req_4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_4.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_4.TabIndex = 52;
            this.pictureBox_craft_req_4.TabStop = false;
            this.pictureBox_craft_req_4.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_4.WaitOnLoad = true;
            this.pictureBox_craft_req_4.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_8
            // 
            this.pictureBox_craft_req_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_8.Location = new System.Drawing.Point(260, 55);
            this.pictureBox_craft_req_8.Name = "pictureBox_craft_req_8";
            this.pictureBox_craft_req_8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_8.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_8.TabIndex = 56;
            this.pictureBox_craft_req_8.TabStop = false;
            this.pictureBox_craft_req_8.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_8.WaitOnLoad = true;
            this.pictureBox_craft_req_8.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_3
            // 
            this.pictureBox_craft_req_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_3.Location = new System.Drawing.Point(185, 17);
            this.pictureBox_craft_req_3.Name = "pictureBox_craft_req_3";
            this.pictureBox_craft_req_3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_3.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_3.TabIndex = 51;
            this.pictureBox_craft_req_3.TabStop = false;
            this.pictureBox_craft_req_3.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_3.WaitOnLoad = true;
            this.pictureBox_craft_req_3.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_6
            // 
            this.pictureBox_craft_req_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_6.Location = new System.Drawing.Point(97, 55);
            this.pictureBox_craft_req_6.Name = "pictureBox_craft_req_6";
            this.pictureBox_craft_req_6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_6.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_6.TabIndex = 54;
            this.pictureBox_craft_req_6.TabStop = false;
            this.pictureBox_craft_req_6.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_6.WaitOnLoad = true;
            this.pictureBox_craft_req_6.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_7
            // 
            this.pictureBox_craft_req_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_7.Location = new System.Drawing.Point(185, 55);
            this.pictureBox_craft_req_7.Name = "pictureBox_craft_req_7";
            this.pictureBox_craft_req_7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_7.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_7.TabIndex = 55;
            this.pictureBox_craft_req_7.TabStop = false;
            this.pictureBox_craft_req_7.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_7.WaitOnLoad = true;
            this.pictureBox_craft_req_7.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_2
            // 
            this.pictureBox_craft_req_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_2.Location = new System.Drawing.Point(97, 17);
            this.pictureBox_craft_req_2.Name = "pictureBox_craft_req_2";
            this.pictureBox_craft_req_2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_2.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_2.TabIndex = 50;
            this.pictureBox_craft_req_2.TabStop = false;
            this.pictureBox_craft_req_2.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_2.WaitOnLoad = true;
            this.pictureBox_craft_req_2.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // pictureBox_craft_req_1
            // 
            this.pictureBox_craft_req_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_req_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_req_1.Location = new System.Drawing.Point(9, 17);
            this.pictureBox_craft_req_1.Name = "pictureBox_craft_req_1";
            this.pictureBox_craft_req_1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_req_1.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_req_1.TabIndex = 49;
            this.pictureBox_craft_req_1.TabStop = false;
            this.pictureBox_craft_req_1.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_req_1.WaitOnLoad = true;
            this.pictureBox_craft_req_1.Click += new System.EventHandler(this.pictureBox_craft_req_1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox8.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
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
            this.groupBox8.DrawBottomLine = false;
            this.groupBox8.DrawShadows = false;
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox8.FontSize = JHUI.JLabelSize.Small;
            this.groupBox8.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox8.Location = new System.Drawing.Point(12, 58);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.PaintDefault = false;
            this.groupBox8.Size = new System.Drawing.Size(301, 209);
            this.groupBox8.Style = JHUI.JColorStyle.Blue;
            this.groupBox8.StyleManager = null;
            this.groupBox8.TabIndex = 48;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Items";
            this.groupBox8.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox8.UseStyleColors = false;
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
            this.button13.Style = JHUI.JColorStyle.Blue;
            this.button13.TabIndex = 73;
            this.button13.Text = "Add";
            this.button13.Theme = JHUI.JThemeStyle.Dark;
            this.button13.UseSelectable = true;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DropShadowColor = System.Drawing.Color.Black;
            this.label5.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label5.FontSize = JHUI.JLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(12, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.Style = JHUI.JColorStyle.Blue;
            this.label5.TabIndex = 71;
            this.label5.Text = "Recipe Id:";
            this.label5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // textBox7
            // 
            this.textBox7.BorderBottomLineSize = 5;
            this.textBox7.BorderColor = System.Drawing.Color.Black;
            this.textBox7.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox7.CustomButton.Image = null;
            this.textBox7.CustomButton.Location = new System.Drawing.Point(125, 2);
            this.textBox7.CustomButton.Name = "";
            this.textBox7.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox7.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox7.CustomButton.TabIndex = 1;
            this.textBox7.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox7.CustomButton.UseSelectable = true;
            this.textBox7.CustomButton.Visible = false;
            this.textBox7.DrawBorder = true;
            this.textBox7.DrawBorderBottomLine = false;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox7.Lines = new string[0];
            this.textBox7.Location = new System.Drawing.Point(74, 177);
            this.textBox7.MaxLength = 32767;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox7.SelectedText = "";
            this.textBox7.SelectionLength = 0;
            this.textBox7.SelectionStart = 0;
            this.textBox7.ShortcutsEnabled = true;
            this.textBox7.Size = new System.Drawing.Size(143, 20);
            this.textBox7.Style = JHUI.JColorStyle.Blue;
            this.textBox7.TabIndex = 72;
            this.textBox7.TextWaterMark = "";
            this.textBox7.Theme = JHUI.JThemeStyle.Dark;
            this.textBox7.UseCustomFont = true;
            this.textBox7.UseSelectable = true;
            this.textBox7.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox_craft_32
            // 
            this.pictureBox_craft_32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_32.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_32.Location = new System.Drawing.Point(260, 133);
            this.pictureBox_craft_32.Name = "pictureBox_craft_32";
            this.pictureBox_craft_32.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_32.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_32.TabIndex = 31;
            this.pictureBox_craft_32.TabStop = false;
            this.pictureBox_craft_32.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_32.WaitOnLoad = true;
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
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.copy;
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
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.deleteCraftItem);
            // 
            // pictureBox_craft_31
            // 
            this.pictureBox_craft_31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_31.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_31.Location = new System.Drawing.Point(224, 133);
            this.pictureBox_craft_31.Name = "pictureBox_craft_31";
            this.pictureBox_craft_31.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_31.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_31.TabIndex = 30;
            this.pictureBox_craft_31.TabStop = false;
            this.pictureBox_craft_31.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_31.WaitOnLoad = true;
            this.pictureBox_craft_31.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_31.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_31.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_30
            // 
            this.pictureBox_craft_30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_30.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_30.Location = new System.Drawing.Point(188, 133);
            this.pictureBox_craft_30.Name = "pictureBox_craft_30";
            this.pictureBox_craft_30.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_30.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_30.TabIndex = 29;
            this.pictureBox_craft_30.TabStop = false;
            this.pictureBox_craft_30.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_30.WaitOnLoad = true;
            this.pictureBox_craft_30.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_30.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_30.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_29
            // 
            this.pictureBox_craft_29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_29.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_29.Location = new System.Drawing.Point(152, 133);
            this.pictureBox_craft_29.Name = "pictureBox_craft_29";
            this.pictureBox_craft_29.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_29.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_29.TabIndex = 28;
            this.pictureBox_craft_29.TabStop = false;
            this.pictureBox_craft_29.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_29.WaitOnLoad = true;
            this.pictureBox_craft_29.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_29.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_29.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_28
            // 
            this.pictureBox_craft_28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_28.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_28.Location = new System.Drawing.Point(117, 133);
            this.pictureBox_craft_28.Name = "pictureBox_craft_28";
            this.pictureBox_craft_28.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_28.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_28.TabIndex = 27;
            this.pictureBox_craft_28.TabStop = false;
            this.pictureBox_craft_28.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_28.WaitOnLoad = true;
            this.pictureBox_craft_28.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_28.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_28.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_27
            // 
            this.pictureBox_craft_27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_27.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_27.Location = new System.Drawing.Point(81, 133);
            this.pictureBox_craft_27.Name = "pictureBox_craft_27";
            this.pictureBox_craft_27.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_27.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_27.TabIndex = 26;
            this.pictureBox_craft_27.TabStop = false;
            this.pictureBox_craft_27.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_27.WaitOnLoad = true;
            this.pictureBox_craft_27.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_27.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_27.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_26
            // 
            this.pictureBox_craft_26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_26.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_26.Location = new System.Drawing.Point(45, 133);
            this.pictureBox_craft_26.Name = "pictureBox_craft_26";
            this.pictureBox_craft_26.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_26.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_26.TabIndex = 25;
            this.pictureBox_craft_26.TabStop = false;
            this.pictureBox_craft_26.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_26.WaitOnLoad = true;
            this.pictureBox_craft_26.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_26.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_26.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_25
            // 
            this.pictureBox_craft_25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_25.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_25.Location = new System.Drawing.Point(9, 133);
            this.pictureBox_craft_25.Name = "pictureBox_craft_25";
            this.pictureBox_craft_25.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_25.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_25.TabIndex = 24;
            this.pictureBox_craft_25.TabStop = false;
            this.pictureBox_craft_25.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_25.WaitOnLoad = true;
            this.pictureBox_craft_25.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_25.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_25.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_24
            // 
            this.pictureBox_craft_24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_24.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_24.Location = new System.Drawing.Point(260, 95);
            this.pictureBox_craft_24.Name = "pictureBox_craft_24";
            this.pictureBox_craft_24.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_24.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_24.TabIndex = 23;
            this.pictureBox_craft_24.TabStop = false;
            this.pictureBox_craft_24.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_24.WaitOnLoad = true;
            this.pictureBox_craft_24.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_24.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_24.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_23
            // 
            this.pictureBox_craft_23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_23.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_23.Location = new System.Drawing.Point(224, 95);
            this.pictureBox_craft_23.Name = "pictureBox_craft_23";
            this.pictureBox_craft_23.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_23.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_23.TabIndex = 22;
            this.pictureBox_craft_23.TabStop = false;
            this.pictureBox_craft_23.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_23.WaitOnLoad = true;
            this.pictureBox_craft_23.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_23.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_23.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_22
            // 
            this.pictureBox_craft_22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_22.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_22.Location = new System.Drawing.Point(188, 95);
            this.pictureBox_craft_22.Name = "pictureBox_craft_22";
            this.pictureBox_craft_22.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_22.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_22.TabIndex = 21;
            this.pictureBox_craft_22.TabStop = false;
            this.pictureBox_craft_22.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_22.WaitOnLoad = true;
            this.pictureBox_craft_22.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_22.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_22.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_21
            // 
            this.pictureBox_craft_21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_21.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_21.Location = new System.Drawing.Point(152, 95);
            this.pictureBox_craft_21.Name = "pictureBox_craft_21";
            this.pictureBox_craft_21.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_21.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_21.TabIndex = 20;
            this.pictureBox_craft_21.TabStop = false;
            this.pictureBox_craft_21.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_21.WaitOnLoad = true;
            this.pictureBox_craft_21.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_21.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_21.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_20
            // 
            this.pictureBox_craft_20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_20.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_20.Location = new System.Drawing.Point(117, 95);
            this.pictureBox_craft_20.Name = "pictureBox_craft_20";
            this.pictureBox_craft_20.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_20.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_20.TabIndex = 19;
            this.pictureBox_craft_20.TabStop = false;
            this.pictureBox_craft_20.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_20.WaitOnLoad = true;
            this.pictureBox_craft_20.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_20.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_20.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_19
            // 
            this.pictureBox_craft_19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_19.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_19.Location = new System.Drawing.Point(81, 95);
            this.pictureBox_craft_19.Name = "pictureBox_craft_19";
            this.pictureBox_craft_19.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_19.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_19.TabIndex = 18;
            this.pictureBox_craft_19.TabStop = false;
            this.pictureBox_craft_19.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_19.WaitOnLoad = true;
            this.pictureBox_craft_19.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_19.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_19.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_18
            // 
            this.pictureBox_craft_18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_18.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_18.Location = new System.Drawing.Point(45, 95);
            this.pictureBox_craft_18.Name = "pictureBox_craft_18";
            this.pictureBox_craft_18.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_18.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_18.TabIndex = 17;
            this.pictureBox_craft_18.TabStop = false;
            this.pictureBox_craft_18.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_18.WaitOnLoad = true;
            this.pictureBox_craft_18.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_18.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_18.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_17
            // 
            this.pictureBox_craft_17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_17.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_17.Location = new System.Drawing.Point(9, 95);
            this.pictureBox_craft_17.Name = "pictureBox_craft_17";
            this.pictureBox_craft_17.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_17.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_17.TabIndex = 16;
            this.pictureBox_craft_17.TabStop = false;
            this.pictureBox_craft_17.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_17.WaitOnLoad = true;
            this.pictureBox_craft_17.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_17.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_17.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_16
            // 
            this.pictureBox_craft_16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_16.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_16.Location = new System.Drawing.Point(260, 57);
            this.pictureBox_craft_16.Name = "pictureBox_craft_16";
            this.pictureBox_craft_16.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_16.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_16.TabIndex = 15;
            this.pictureBox_craft_16.TabStop = false;
            this.pictureBox_craft_16.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_16.WaitOnLoad = true;
            this.pictureBox_craft_16.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_16.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_16.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_15
            // 
            this.pictureBox_craft_15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_15.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_15.Location = new System.Drawing.Point(224, 57);
            this.pictureBox_craft_15.Name = "pictureBox_craft_15";
            this.pictureBox_craft_15.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_15.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_15.TabIndex = 14;
            this.pictureBox_craft_15.TabStop = false;
            this.pictureBox_craft_15.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_15.WaitOnLoad = true;
            this.pictureBox_craft_15.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_15.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_15.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_14
            // 
            this.pictureBox_craft_14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_14.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_14.Location = new System.Drawing.Point(188, 57);
            this.pictureBox_craft_14.Name = "pictureBox_craft_14";
            this.pictureBox_craft_14.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_14.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_14.TabIndex = 13;
            this.pictureBox_craft_14.TabStop = false;
            this.pictureBox_craft_14.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_14.WaitOnLoad = true;
            this.pictureBox_craft_14.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_14.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_14.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_13
            // 
            this.pictureBox_craft_13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_13.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_13.Location = new System.Drawing.Point(152, 57);
            this.pictureBox_craft_13.Name = "pictureBox_craft_13";
            this.pictureBox_craft_13.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_13.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_13.TabIndex = 12;
            this.pictureBox_craft_13.TabStop = false;
            this.pictureBox_craft_13.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_13.WaitOnLoad = true;
            this.pictureBox_craft_13.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_13.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_13.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_12
            // 
            this.pictureBox_craft_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_12.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_12.Location = new System.Drawing.Point(117, 57);
            this.pictureBox_craft_12.Name = "pictureBox_craft_12";
            this.pictureBox_craft_12.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_12.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_12.TabIndex = 11;
            this.pictureBox_craft_12.TabStop = false;
            this.pictureBox_craft_12.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_12.WaitOnLoad = true;
            this.pictureBox_craft_12.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_12.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_12.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_11
            // 
            this.pictureBox_craft_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_11.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_11.Location = new System.Drawing.Point(81, 57);
            this.pictureBox_craft_11.Name = "pictureBox_craft_11";
            this.pictureBox_craft_11.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_11.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_11.TabIndex = 10;
            this.pictureBox_craft_11.TabStop = false;
            this.pictureBox_craft_11.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_11.WaitOnLoad = true;
            this.pictureBox_craft_11.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_11.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_11.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_10
            // 
            this.pictureBox_craft_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_10.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_10.Location = new System.Drawing.Point(45, 57);
            this.pictureBox_craft_10.Name = "pictureBox_craft_10";
            this.pictureBox_craft_10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_10.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_10.TabIndex = 9;
            this.pictureBox_craft_10.TabStop = false;
            this.pictureBox_craft_10.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_10.WaitOnLoad = true;
            this.pictureBox_craft_10.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_10.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_10.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_9
            // 
            this.pictureBox_craft_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_9.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_9.Location = new System.Drawing.Point(9, 57);
            this.pictureBox_craft_9.Name = "pictureBox_craft_9";
            this.pictureBox_craft_9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_9.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_9.TabIndex = 8;
            this.pictureBox_craft_9.TabStop = false;
            this.pictureBox_craft_9.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_9.WaitOnLoad = true;
            this.pictureBox_craft_9.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_9.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_9.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_8
            // 
            this.pictureBox_craft_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_8.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_8.Location = new System.Drawing.Point(260, 19);
            this.pictureBox_craft_8.Name = "pictureBox_craft_8";
            this.pictureBox_craft_8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_8.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_8.TabIndex = 7;
            this.pictureBox_craft_8.TabStop = false;
            this.pictureBox_craft_8.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_8.WaitOnLoad = true;
            this.pictureBox_craft_8.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_8.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_8.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_7
            // 
            this.pictureBox_craft_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_7.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_7.Location = new System.Drawing.Point(224, 19);
            this.pictureBox_craft_7.Name = "pictureBox_craft_7";
            this.pictureBox_craft_7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_7.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_7.TabIndex = 6;
            this.pictureBox_craft_7.TabStop = false;
            this.pictureBox_craft_7.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_7.WaitOnLoad = true;
            this.pictureBox_craft_7.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_7.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_7.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_6
            // 
            this.pictureBox_craft_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_6.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_6.Location = new System.Drawing.Point(188, 19);
            this.pictureBox_craft_6.Name = "pictureBox_craft_6";
            this.pictureBox_craft_6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_6.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_6.TabIndex = 5;
            this.pictureBox_craft_6.TabStop = false;
            this.pictureBox_craft_6.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_6.WaitOnLoad = true;
            this.pictureBox_craft_6.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_6.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_6.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_5
            // 
            this.pictureBox_craft_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_5.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_5.Location = new System.Drawing.Point(152, 19);
            this.pictureBox_craft_5.Name = "pictureBox_craft_5";
            this.pictureBox_craft_5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_5.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_5.TabIndex = 4;
            this.pictureBox_craft_5.TabStop = false;
            this.pictureBox_craft_5.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_5.WaitOnLoad = true;
            this.pictureBox_craft_5.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_5.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_5.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_4
            // 
            this.pictureBox_craft_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_4.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_4.Location = new System.Drawing.Point(117, 19);
            this.pictureBox_craft_4.Name = "pictureBox_craft_4";
            this.pictureBox_craft_4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_4.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_4.TabIndex = 3;
            this.pictureBox_craft_4.TabStop = false;
            this.pictureBox_craft_4.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_4.WaitOnLoad = true;
            this.pictureBox_craft_4.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_4.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_4.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_3
            // 
            this.pictureBox_craft_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_3.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_3.Location = new System.Drawing.Point(81, 19);
            this.pictureBox_craft_3.Name = "pictureBox_craft_3";
            this.pictureBox_craft_3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_3.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_3.TabIndex = 2;
            this.pictureBox_craft_3.TabStop = false;
            this.pictureBox_craft_3.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_3.WaitOnLoad = true;
            this.pictureBox_craft_3.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_3.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_3.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_2
            // 
            this.pictureBox_craft_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_2.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_2.Location = new System.Drawing.Point(45, 19);
            this.pictureBox_craft_2.Name = "pictureBox_craft_2";
            this.pictureBox_craft_2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_2.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_2.TabIndex = 1;
            this.pictureBox_craft_2.TabStop = false;
            this.pictureBox_craft_2.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_2.WaitOnLoad = true;
            this.pictureBox_craft_2.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_2.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_2.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // pictureBox_craft_1
            // 
            this.pictureBox_craft_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.pictureBox_craft_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_craft_1.ContextMenuStrip = this.contextMenuStripproduce;
            this.pictureBox_craft_1.Location = new System.Drawing.Point(9, 19);
            this.pictureBox_craft_1.Name = "pictureBox_craft_1";
            this.pictureBox_craft_1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_craft_1.Style = JHUI.JColorStyle.Blue;
            this.pictureBox_craft_1.TabIndex = 0;
            this.pictureBox_craft_1.TabStop = false;
            this.pictureBox_craft_1.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_craft_1.WaitOnLoad = true;
            this.pictureBox_craft_1.Click += new System.EventHandler(this.picture_item_1_Click);
            this.pictureBox_craft_1.MouseEnter += new System.EventHandler(this.picture_item_1_MouseEnter);
            this.pictureBox_craft_1.MouseLeave += new System.EventHandler(this.picture_item_1_MouseLeave);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.jGroupBox2);
            this.tabPage4.Controls.Add(this.groupBox18);
            this.tabPage4.Controls.Add(this.groupBox17);
            this.tabPage4.HorizontalScrollbar = true;
            this.tabPage4.HorizontalScrollbarBarColor = false;
            this.tabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage4.HorizontalScrollbarSize = 10;
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(632, 506);
            this.tabPage4.Style = JHUI.JColorStyle.Blue;
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Advanced Search";
            this.tabPage4.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.VerticalScrollbar = true;
            this.tabPage4.VerticalScrollbarBarColor = true;
            this.tabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage4.VerticalScrollbarSize = 10;
            // 
            // jGroupBox2
            // 
            this.jGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox2.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox2.Controls.Add(this.dataGridView1);
            this.jGroupBox2.DrawBottomLine = false;
            this.jGroupBox2.DrawShadows = false;
            this.jGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox2.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox2.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jGroupBox2.Location = new System.Drawing.Point(0, 158);
            this.jGroupBox2.Name = "jGroupBox2";
            this.jGroupBox2.PaintDefault = false;
            this.jGroupBox2.Size = new System.Drawing.Size(619, 354);
            this.jGroupBox2.Style = JHUI.JColorStyle.White;
            this.jGroupBox2.StyleManager = null;
            this.jGroupBox2.TabIndex = 34;
            this.jGroupBox2.TabStop = false;
            this.jGroupBox2.Text = "Search Result";
            this.jGroupBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox2.UseStyleColors = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column6,
            this.dataGridViewTextBoxColumn4,
            this.Column4,
            this.Column5,
            this.Column7});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(613, 332);
            this.dataGridView1.Style = JHUI.JColorStyle.Blue;
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Search Var";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 83;
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
            this.selectAllToolStripMenuItem,
            this.copySelectedItemsToClipboardToolStripMenuItem,
            this.toolStripSeparator7,
            this.deleteSelectedToolStripMenuItem,
            this.toolStripSeparator10,
            this.copyAllItemNamesToClipboardToolStripMenuItem,
            this.copyAllItemNamesToClipboardToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 126);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_photo;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // copySelectedItemsToClipboardToolStripMenuItem
            // 
            this.copySelectedItemsToClipboardToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.finish_and_merge;
            this.copySelectedItemsToClipboardToolStripMenuItem.Name = "copySelectedItemsToClipboardToolStripMenuItem";
            this.copySelectedItemsToClipboardToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.copySelectedItemsToClipboardToolStripMenuItem.Text = "Copy";
            this.copySelectedItemsToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copySelectedItemsToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(154, 6);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(154, 6);
            // 
            // copyAllItemNamesToClipboardToolStripMenuItem
            // 
            this.copyAllItemNamesToClipboardToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.copy;
            this.copyAllItemNamesToClipboardToolStripMenuItem.Name = "copyAllItemNamesToClipboardToolStripMenuItem";
            this.copyAllItemNamesToClipboardToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.copyAllItemNamesToClipboardToolStripMenuItem.Text = "Copy all Names";
            this.copyAllItemNamesToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyAllItemNamesToClipboardToolStripMenuItem_Click);
            // 
            // copyAllItemNamesToClipboardToolStripMenuItem1
            // 
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.copy;
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Name = "copyAllItemNamesToClipboardToolStripMenuItem1";
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Text = "Copy all Values";
            this.copyAllItemNamesToClipboardToolStripMenuItem1.Click += new System.EventHandler(this.copyAllItemNamesToClipboardToolStripMenuItem1_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox18.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox18.Controls.Add(this.button16);
            this.groupBox18.Controls.Add(this.textBox25);
            this.groupBox18.Controls.Add(this.comboBox3);
            this.groupBox18.DrawBottomLine = false;
            this.groupBox18.DrawShadows = false;
            this.groupBox18.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox18.FontSize = JHUI.JLabelSize.Small;
            this.groupBox18.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox18.Location = new System.Drawing.Point(6, 112);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.PaintDefault = false;
            this.groupBox18.Size = new System.Drawing.Size(611, 47);
            this.groupBox18.Style = JHUI.JColorStyle.Blue;
            this.groupBox18.StyleManager = null;
            this.groupBox18.TabIndex = 33;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Fixed Search";
            this.groupBox18.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox18.UseStyleColors = false;
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
            this.button16.Location = new System.Drawing.Point(416, 16);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(189, 22);
            this.button16.Style = JHUI.JColorStyle.Blue;
            this.button16.TabIndex = 36;
            this.button16.TabStop = false;
            this.button16.Text = "Search";
            this.button16.Theme = JHUI.JThemeStyle.Dark;
            this.button16.UseSelectable = true;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // textBox25
            // 
            this.textBox25.BorderBottomLineSize = 5;
            this.textBox25.BorderColor = System.Drawing.Color.Black;
            this.textBox25.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox25.CustomButton.Image = null;
            this.textBox25.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.textBox25.CustomButton.Name = "";
            this.textBox25.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox25.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox25.CustomButton.TabIndex = 1;
            this.textBox25.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox25.CustomButton.UseSelectable = true;
            this.textBox25.CustomButton.Visible = false;
            this.textBox25.DrawBorder = true;
            this.textBox25.DrawBorderBottomLine = false;
            this.textBox25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox25.Lines = new string[0];
            this.textBox25.Location = new System.Drawing.Point(172, 15);
            this.textBox25.MaxLength = 32767;
            this.textBox25.Name = "textBox25";
            this.textBox25.PasswordChar = '\0';
            this.textBox25.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox25.SelectedText = "";
            this.textBox25.SelectionLength = 0;
            this.textBox25.SelectionStart = 0;
            this.textBox25.ShortcutsEnabled = true;
            this.textBox25.Size = new System.Drawing.Size(235, 25);
            this.textBox25.Style = JHUI.JColorStyle.Blue;
            this.textBox25.TabIndex = 34;
            this.textBox25.TabStop = false;
            this.textBox25.TextWaterMark = "Value";
            this.textBox25.Theme = JHUI.JThemeStyle.Dark;
            this.textBox25.UseCustomFont = true;
            this.textBox25.UseSelectable = true;
            this.textBox25.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox25.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBox3
            // 
            this.comboBox3.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox3.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 19;
            this.comboBox3.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Task Id",
            "Monster Drop",
            "Mine Drop",
            "NPC Crafting Service",
            "NPC Sale Service",
            "Skill Service"});
            this.comboBox3.Location = new System.Drawing.Point(10, 15);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(156, 25);
            this.comboBox3.Style = JHUI.JColorStyle.Blue;
            this.comboBox3.TabIndex = 32;
            this.comboBox3.TabStop = false;
            this.comboBox3.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox3.UseSelectable = true;
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox17.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox17.Controls.Add(this.jTextBox1);
            this.groupBox17.Controls.Add(this.jComboBox1);
            this.groupBox17.Controls.Add(this.checkBox2);
            this.groupBox17.Controls.Add(this.checkBox5);
            this.groupBox17.Controls.Add(this.checkBox4);
            this.groupBox17.Controls.Add(this.button15);
            this.groupBox17.Controls.Add(this.textBox23);
            this.groupBox17.Controls.Add(this.button5);
            this.groupBox17.Controls.Add(this.selecter_rowscheckbox);
            this.groupBox17.DrawBottomLine = false;
            this.groupBox17.DrawShadows = false;
            this.groupBox17.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox17.FontSize = JHUI.JLabelSize.Small;
            this.groupBox17.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox17.Location = new System.Drawing.Point(0, 2);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.PaintDefault = false;
            this.groupBox17.Size = new System.Drawing.Size(617, 107);
            this.groupBox17.Style = JHUI.JColorStyle.Blue;
            this.groupBox17.StyleManager = null;
            this.groupBox17.TabIndex = 32;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Dynamic Search Options";
            this.groupBox17.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox17.UseStyleColors = false;
            // 
            // jTextBox1
            // 
            this.jTextBox1.BorderBottomLineSize = 5;
            this.jTextBox1.BorderColor = System.Drawing.Color.Black;
            this.jTextBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = null;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(144, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.DrawBorder = true;
            this.jTextBox1.DrawBorderBottomLine = false;
            this.jTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(335, 50);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(168, 25);
            this.jTextBox1.Style = JHUI.JColorStyle.Blue;
            this.jTextBox1.TabIndex = 42;
            this.jTextBox1.TabStop = false;
            this.jTextBox1.TextWaterMark = "Value 2";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomFont = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // jComboBox1
            // 
            this.jComboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jComboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.ItemHeight = 19;
            this.jComboBox1.Location = new System.Drawing.Point(335, 19);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.Size = new System.Drawing.Size(168, 25);
            this.jComboBox1.Style = JHUI.JColorStyle.Blue;
            this.jComboBox1.TabIndex = 40;
            this.jComboBox1.TabStop = false;
            this.jComboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox1.UseSelectable = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(509, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 15);
            this.checkBox2.Style = JHUI.JColorStyle.Blue;
            this.checkBox2.TabIndex = 37;
            this.checkBox2.Text = "Case-sensitive";
            this.checkBox2.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox2.UseSelectable = true;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(509, 23);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(70, 15);
            this.checkBox5.Style = JHUI.JColorStyle.Blue;
            this.checkBox5.TabIndex = 39;
            this.checkBox5.Text = "All Fields";
            this.checkBox5.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox5.UseSelectable = true;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(509, 44);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(88, 15);
            this.checkBox4.Style = JHUI.JColorStyle.Blue;
            this.checkBox4.TabIndex = 38;
            this.checkBox4.Text = "Only this list";
            this.checkBox4.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox4.UseSelectable = true;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Indigo;
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(16, 81);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(156, 22);
            this.button15.Style = JHUI.JColorStyle.Blue;
            this.button15.TabIndex = 33;
            this.button15.TabStop = false;
            this.button15.Text = "Search";
            this.button15.Theme = JHUI.JThemeStyle.Dark;
            this.button15.UseSelectable = true;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // textBox23
            // 
            this.textBox23.BorderBottomLineSize = 5;
            this.textBox23.BorderColor = System.Drawing.Color.Black;
            this.textBox23.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox23.CustomButton.Image = null;
            this.textBox23.CustomButton.Location = new System.Drawing.Point(289, 1);
            this.textBox23.CustomButton.Name = "";
            this.textBox23.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox23.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox23.CustomButton.TabIndex = 1;
            this.textBox23.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox23.CustomButton.UseSelectable = true;
            this.textBox23.CustomButton.Visible = false;
            this.textBox23.DrawBorder = true;
            this.textBox23.DrawBorderBottomLine = false;
            this.textBox23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox23.Lines = new string[0];
            this.textBox23.Location = new System.Drawing.Point(16, 50);
            this.textBox23.MaxLength = 32767;
            this.textBox23.Name = "textBox23";
            this.textBox23.PasswordChar = '\0';
            this.textBox23.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox23.SelectedText = "";
            this.textBox23.SelectionLength = 0;
            this.textBox23.SelectionStart = 0;
            this.textBox23.ShortcutsEnabled = true;
            this.textBox23.Size = new System.Drawing.Size(313, 25);
            this.textBox23.Style = JHUI.JColorStyle.Blue;
            this.textBox23.TabIndex = 30;
            this.textBox23.TabStop = false;
            this.textBox23.TextWaterMark = "Value 1";
            this.textBox23.Theme = JHUI.JThemeStyle.Dark;
            this.textBox23.UseCustomFont = true;
            this.textBox23.UseSelectable = true;
            this.textBox23.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox23.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.MediumOrchid;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(178, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 22);
            this.button5.Style = JHUI.JColorStyle.Blue;
            this.button5.TabIndex = 31;
            this.button5.TabStop = false;
            this.button5.Text = "List Rows";
            this.button5.Theme = JHUI.JThemeStyle.Dark;
            this.button5.UseSelectable = true;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.listSameRowsIDValues);
            // 
            // selecter_rowscheckbox
            // 
            this.selecter_rowscheckbox.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.selecter_rowscheckbox.FontSize = JHUI.JComboBoxSize.Small;
            this.selecter_rowscheckbox.FormattingEnabled = true;
            this.selecter_rowscheckbox.ItemHeight = 19;
            this.selecter_rowscheckbox.Location = new System.Drawing.Point(16, 19);
            this.selecter_rowscheckbox.Name = "selecter_rowscheckbox";
            this.selecter_rowscheckbox.Size = new System.Drawing.Size(313, 25);
            this.selecter_rowscheckbox.Style = JHUI.JColorStyle.Blue;
            this.selecter_rowscheckbox.TabIndex = 23;
            this.selecter_rowscheckbox.TabStop = false;
            this.selecter_rowscheckbox.Theme = JHUI.JThemeStyle.Dark;
            this.selecter_rowscheckbox.UseSelectable = true;
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
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.CausesValidation = false;
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
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(8, 574);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(6, 8);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(941, 112);
            this.tabControl2.Style = JHUI.JColorStyle.White;
            this.tabControl2.TabIndex = 32;
            this.tabControl2.TabStop = false;
            this.tabControl2.Theme = JHUI.JThemeStyle.Dark;
            this.tabControl2.UseSelectable = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.jPictureBox5);
            this.tabPage3.Controls.Add(this.jLabel2);
            this.tabPage3.Controls.Add(this.pathLabel);
            this.tabPage3.Controls.Add(this.jPictureBox4);
            this.tabPage3.Controls.Add(this.caseSensitiveCheckbox);
            this.tabPage3.Controls.Add(this.searchInput1);
            this.tabPage3.Controls.Add(this.version_label);
            this.tabPage3.Controls.Add(this.nextautoIdlabel);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.jLabel1);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage3.HorizontalScrollbarBarColor = true;
            this.tabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage3.HorizontalScrollbarSize = 10;
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(933, 70);
            this.tabPage3.Style = JHUI.JColorStyle.Blue;
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Miscellaneous";
            this.tabPage3.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage3.ToolTipText = "Replaces the selected items based on your criteria!";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.VerticalScrollbarBarColor = true;
            this.tabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage3.VerticalScrollbarSize = 10;
            // 
            // jPictureBox5
            // 
            this.jPictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox5.BackgroundImage")));
            this.jPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox5.ContextMenuStrip = this.Tools;
            this.jPictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox5.Location = new System.Drawing.Point(902, 6);
            this.jPictureBox5.Name = "jPictureBox5";
            this.jPictureBox5.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox5.Style = JHUI.JColorStyle.Blue;
            this.jPictureBox5.TabIndex = 41;
            this.jPictureBox5.TabStop = false;
            this.jPictureBox5.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox5.Click += new System.EventHandler(this.JPictureBox5_Click);
            // 
            // Tools
            // 
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elementEditorToolStripMenuItem,
            this.skillsToolStripMenuItem1});
            this.Tools.Name = "row_editor_context";
            this.Tools.Size = new System.Drawing.Size(152, 48);
            // 
            // elementEditorToolStripMenuItem
            // 
            this.elementEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importConfigsToolStripMenuItem,
            this.readListUsefulForEncryptedFilesToolStripMenuItem,
            this.loadRequiredFilesFrompckToolStripMenuItem,
            this.exportIconsForPWAdminToolStripMenuItem,
            this.iconsEditorToolStripMenuItem});
            this.elementEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.elementEditorToolStripMenuItem.Name = "elementEditorToolStripMenuItem";
            this.elementEditorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.elementEditorToolStripMenuItem.Text = "Element Editor";
            // 
            // importConfigsToolStripMenuItem
            // 
            this.importConfigsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.importConfigsToolStripMenuItem.Name = "importConfigsToolStripMenuItem";
            this.importConfigsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.importConfigsToolStripMenuItem.Text = "Import Configs";
            this.importConfigsToolStripMenuItem.Click += new System.EventHandler(this.importConfigsToolStripMenuItem_Click);
            // 
            // readListUsefulForEncryptedFilesToolStripMenuItem
            // 
            this.readListUsefulForEncryptedFilesToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.readListUsefulForEncryptedFilesToolStripMenuItem.Name = "readListUsefulForEncryptedFilesToolStripMenuItem";
            this.readListUsefulForEncryptedFilesToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.readListUsefulForEncryptedFilesToolStripMenuItem.Text = "Read List (Useful For Encrypted Files)";
            this.readListUsefulForEncryptedFilesToolStripMenuItem.Click += new System.EventHandler(this.readListDEBUGToolStripMenuItem_Click);
            // 
            // loadRequiredFilesFrompckToolStripMenuItem
            // 
            this.loadRequiredFilesFrompckToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.loadRequiredFilesFrompckToolStripMenuItem.Name = "loadRequiredFilesFrompckToolStripMenuItem";
            this.loadRequiredFilesFrompckToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.loadRequiredFilesFrompckToolStripMenuItem.Text = "Load Required Files From .pck";
            this.loadRequiredFilesFrompckToolStripMenuItem.Click += new System.EventHandler(this.loadRequiredFilesFrompckToolStripMenuItem_Click);
            // 
            // exportIconsForPWAdminToolStripMenuItem
            // 
            this.exportIconsForPWAdminToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.exportIconsForPWAdminToolStripMenuItem.Name = "exportIconsForPWAdminToolStripMenuItem";
            this.exportIconsForPWAdminToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.exportIconsForPWAdminToolStripMenuItem.Text = "Export Icons For PW Admin";
            this.exportIconsForPWAdminToolStripMenuItem.Click += new System.EventHandler(this.ExportIconsForPWAdminToolStripMenuItem_Click);
            // 
            // iconsEditorToolStripMenuItem
            // 
            this.iconsEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.iconsEditorToolStripMenuItem.Name = "iconsEditorToolStripMenuItem";
            this.iconsEditorToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.iconsEditorToolStripMenuItem.Text = "Icons Editor";
            this.iconsEditorToolStripMenuItem.Click += new System.EventHandler(this.IconsEditorToolStripMenuItem_Click);
            // 
            // skillsToolStripMenuItem1
            // 
            this.skillsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSkillsToListToolStripMenuItem1,
            this.skillOctetsGeneratorToolStripMenuItem});
            this.skillsToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Play_button;
            this.skillsToolStripMenuItem1.Name = "skillsToolStripMenuItem1";
            this.skillsToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.skillsToolStripMenuItem1.Text = "Skill";
            // 
            // exportSkillsToListToolStripMenuItem1
            // 
            this.exportSkillsToListToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.exportSkillsToListToolStripMenuItem1.Name = "exportSkillsToListToolStripMenuItem1";
            this.exportSkillsToListToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.exportSkillsToListToolStripMenuItem1.Text = "Export Skills To List";
            this.exportSkillsToListToolStripMenuItem1.Click += new System.EventHandler(this.exportSkillsToListToolStripMenuItem_Click);
            // 
            // skillOctetsGeneratorToolStripMenuItem
            // 
            this.skillOctetsGeneratorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.skillOctetsGeneratorToolStripMenuItem.Name = "skillOctetsGeneratorToolStripMenuItem";
            this.skillOctetsGeneratorToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.skillOctetsGeneratorToolStripMenuItem.Text = "Skill Octets Generator";
            this.skillOctetsGeneratorToolStripMenuItem.Click += new System.EventHandler(this.skillsToolStripMenuItem_Click);
            // 
            // jLabel2
            // 
            this.jLabel2.AutoSize = true;
            this.jLabel2.CausesValidation = false;
            this.jLabel2.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.jLabel2.Location = new System.Drawing.Point(296, 26);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(32, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Blue;
            this.jLabel2.TabIndex = 38;
            this.jLabel2.Text = "Path:";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.CausesValidation = false;
            this.pathLabel.DropShadowColor = System.Drawing.Color.Black;
            this.pathLabel.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.pathLabel.FontSize = JHUI.JLabelSize.Small;
            this.pathLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pathLabel.Location = new System.Drawing.Point(378, 25);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pathLabel.Size = new System.Drawing.Size(181, 15);
            this.pathLabel.Style = JHUI.JColorStyle.Blue;
            this.pathLabel.TabIndex = 39;
            this.pathLabel.Text = "F:\\Blue-Dragon\\data\\element.data";
            this.pathLabel.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jPictureBox4
            // 
            this.jPictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox4.BackgroundImage")));
            this.jPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox4.Location = new System.Drawing.Point(902, 39);
            this.jPictureBox4.Name = "jPictureBox4";
            this.jPictureBox4.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox4.Style = JHUI.JColorStyle.Blue;
            this.jPictureBox4.TabIndex = 40;
            this.jPictureBox4.TabStop = false;
            this.jPictureBox4.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox4.Click += new System.EventHandler(this.jPictureBox4_Click);
            // 
            // nextautoIdlabel
            // 
            this.nextautoIdlabel.AutoSize = true;
            this.nextautoIdlabel.DropShadowColor = System.Drawing.Color.Black;
            this.nextautoIdlabel.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.nextautoIdlabel.FontSize = JHUI.JLabelSize.Small;
            this.nextautoIdlabel.Location = new System.Drawing.Point(378, 44);
            this.nextautoIdlabel.Name = "nextautoIdlabel";
            this.nextautoIdlabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nextautoIdlabel.Size = new System.Drawing.Size(13, 15);
            this.nextautoIdlabel.Style = JHUI.JColorStyle.Blue;
            this.nextautoIdlabel.TabIndex = 13;
            this.nextautoIdlabel.Text = "0";
            this.nextautoIdlabel.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(296, 44);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(46, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Blue;
            this.jLabel1.TabIndex = 37;
            this.jLabel1.Text = "Next id:";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.saveAsToolStripMenuItem1,
            this.exportToolStripMenuItem});
            this.contextMenuStrip3.Name = "classmaskMenu";
            this.contextMenuStrip3.Size = new System.Drawing.Size(187, 70);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::PWDataEditorPaied.Properties.Resources.Save1;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem4.Text = "Save";
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem1.Image")));
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Weather_rain;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exportToolStripMenuItem.Text = "Export";
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
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(188, 27);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Blue;
            this.jPictureBox1.TabIndex = 33;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // listBox_items
            // 
            this.listBox_items.AllowDrop = true;
            this.listBox_items.AllowUserToAddRows = false;
            this.listBox_items.AllowUserToDeleteRows = false;
            this.listBox_items.AllowUserToResizeColumns = false;
            this.listBox_items.AllowUserToResizeRows = false;
            this.listBox_items.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_items.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listBox_items.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listBox_items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.listBox_items.ColumnHeadersHeight = 30;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnImg,
            this.ColumnName});
            this.listBox_items.ContextMenuStrip = this.listbox_items_menu;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle10;
            this.listBox_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_items.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.listBox_items.EditOnDoubleClick = true;
            this.listBox_items.EnableHeadersVisualStyles = false;
            this.listBox_items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.Location = new System.Drawing.Point(3, 19);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_items.RowTemplate.Height = 30;
            this.listBox_items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(267, 458);
            this.listBox_items.StandardTab = true;
            this.listBox_items.Style = JHUI.JColorStyle.Blue;
            this.listBox_items.TabIndex = 2;
            this.listBox_items.Theme = JHUI.JThemeStyle.Dark;
            this.listBox_items.VirtualMode = true;
            this.listBox_items.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellContentClick);
            this.listBox_items.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellMouseEnter);
            this.listBox_items.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellMouseLeave);
            this.listBox_items.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listBox_items_CellMouseMove);
            this.listBox_items.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellValueChanged);
            this.listBox_items.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.listBox_items_CellValueNeeded);
            this.listBox_items.SelectionChanged += new System.EventHandler(this.listBox_items_CellClick);
            this.listBox_items.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_items_DragDrop);
            this.listBox_items.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_items_DragEnter);
            this.listBox_items.DragLeave += new System.EventHandler(this.listBox_items_DragLeave);
            this.listBox_items.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileOrginizerForm_KeyDown);
            this.listBox_items.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_items_MouseDown);
            this.listBox_items.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_items_MouseMove);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.FillWeight = 50F;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.MinimumWidth = 50;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnId.Width = 50;
            // 
            // ColumnImg
            // 
            this.ColumnImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle8.NullValue")));
            this.ColumnImg.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Width = 192;
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox2.ContextMenuStrip = this.contextMenuStrip3;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(217, 27);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Blue;
            this.jPictureBox2.TabIndex = 34;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // jPictureBox3
            // 
            this.jPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox3.BackgroundImage")));
            this.jPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox3.Location = new System.Drawing.Point(275, 27);
            this.jPictureBox3.Name = "jPictureBox3";
            this.jPictureBox3.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox3.Style = JHUI.JColorStyle.Blue;
            this.jPictureBox3.TabIndex = 35;
            this.jPictureBox3.TabStop = false;
            this.jPictureBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox3.Click += new System.EventHandler(this.ShowErrors_Click);
            // 
            // jGroupBox1
            // 
            this.jGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.jGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox1.Controls.Add(this.listBox_items);
            this.jGroupBox1.DrawBottomLine = true;
            this.jGroupBox1.DrawShadows = false;
            this.jGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox1.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.jGroupBox1.Location = new System.Drawing.Point(19, 95);
            this.jGroupBox1.Name = "jGroupBox1";
            this.jGroupBox1.PaintDefault = false;
            this.jGroupBox1.Size = new System.Drawing.Size(273, 480);
            this.jGroupBox1.Style = JHUI.JColorStyle.Blue;
            this.jGroupBox1.StyleManager = null;
            this.jGroupBox1.TabIndex = 43;
            this.jGroupBox1.TabStop = false;
            this.jGroupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox1.UseStyleColors = true;
            // 
            // ElementsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jGroupBox1);
            this.Controls.Add(this.jPictureBox3);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.comboBox_lists);
            this.Controls.Add(this.elementIntoTab);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ElementsEditor";
            this.Opacity = 0D;
            this.Style = JHUI.JColorStyle.Blue;
            this.Text = "Element Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElementsEditor_FormClosing);
            this.Shown += new System.EventHandler(this.ElementsEditor_Shown);
            this.ResizeBegin += new System.EventHandler(this.ElementsEditor_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.ElementsEditor_ResizeEnd);
            this.Leave += new System.EventHandler(this.ElementsEditor_Leave);
            this.contextMenuStrip2.ResumeLayout(false);
            this.listbox_items_menu.ResumeLayout(false);
            this.BookMarks.ResumeLayout(false);
            this.row_editor_context.ResumeLayout(false);
            this.elementIntoTab.ResumeLayout(false);
            this.Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_item)).EndInit();
            this.SaleTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).EndInit();
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
            this.tabPage4.ResumeLayout(false);
            this.jGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).EndInit();
            this.Tools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.classmaskMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).EndInit();
            this.jGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private JDataGridView dataGridView_item;
        private JComboBox comboBox_lists;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private JTextBox searchInput1;
        private JLabel label1;
        private JLabel version_label;
        private ContextMenuStrip listbox_items_menu;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private JDataGridView listBox_items;
        private ContextMenuStrip row_editor_context;
        private ToolStripMenuItem changeToolStripMenuItem;
        private JTabControl elementIntoTab;
        private JCheckBox caseSensitiveCheckbox;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem configEditorExportToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn RowId;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private JTabControl tabControl2;
        private JTabPage tabPage3;
        private JComboBox selecter_rowscheckbox;
        private JTabPage SaleTab;
        private JPictureBox picture_item_32;
        private JPictureBox picture_item_31;
        private JPictureBox picture_item_30;
        private JPictureBox picture_item_29;
        private JPictureBox picture_item_28;
        private JPictureBox picture_item_27;
        private JPictureBox picture_item_26;
        private JPictureBox picture_item_25;
        private JPictureBox picture_item_24;
        private JPictureBox picture_item_23;
        private JPictureBox picture_item_22;
        private JPictureBox picture_item_21;
        private JPictureBox picture_item_20;
        private JPictureBox picture_item_19;
        private JPictureBox picture_item_18;
        private JPictureBox picture_item_17;
        private JPictureBox picture_item_16;
        private JPictureBox picture_item_15;
        private JPictureBox picture_item_14;
        private JPictureBox picture_item_13;
        private JPictureBox picture_item_12;
        private JPictureBox picture_item_11;
        private JPictureBox picture_item_10;
        private JPictureBox picture_item_9;
        private JPictureBox picture_item_8;
        private JPictureBox picture_item_7;
        private JPictureBox picture_item_6;
        private JPictureBox picture_item_5;
        private JPictureBox picture_item_4;
        private JPictureBox picture_item_3;
        private JPictureBox picture_item_2;
        private JPictureBox picture_item_1;
        private JButton tab_salebtn_1;
        private JButton tab_salebtn_5;
        private JButton tab_salebtn_2;
        private JButton tab_salebtn_8;
        private JButton tab_salebtn_3;
        private JButton tab_salebtn_7;
        private JButton tab_salebtn_4;
        private JButton tab_salebtn_6;
        private JButton button10;
        private JTextBox textBox2;
        private JButton button8;
        private JTextBox textBox1;
        private ContextMenuStrip contextMenuStripSalePreview;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem moveHereToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        internal JLabel label_item_32;
        internal JLabel label_item_31;
        internal JLabel label_item_30;
        internal JLabel label_item_29;
        internal JLabel label_item_28;
        internal JLabel label_item_27;
        internal JLabel label_item_26;
        internal JLabel label_item_25;
        internal JLabel label_item_24;
        internal JLabel label_item_23;
        internal JLabel label_item_22;
        internal JLabel label_item_21;
        internal JLabel label_item_20;
        internal JLabel label_item_19;
        internal JLabel label_item_18;
        internal JLabel label_item_17;
        internal JLabel label_item_16;
        internal JLabel label_item_15;
        internal JLabel label_item_14;
        internal JLabel label_item_13;
        internal JLabel label_item_12;
        internal JLabel label_item_11;
        internal JLabel label_item_10;
        internal JLabel label_item_9;
        internal JLabel label_item_8;
        internal JLabel label_item_7;
        internal JLabel label_item_6;
        internal JLabel label_item_5;
        internal JLabel label_item_4;
        internal JLabel label_item_3;
        internal JLabel label_item_2;
        internal JLabel label_item_1;
        private JPictureBox pictureBox41;
        private JPictureBox pictureBox_craft_req_8;
        private JPictureBox pictureBox_craft_req_7;
        private JPictureBox pictureBox_craft_req_6;
        private JPictureBox pictureBox_craft_req_5;
        private JPictureBox pictureBox_craft_req_4;
        private JPictureBox pictureBox_craft_req_3;
        private JPictureBox pictureBox_craft_req_2;
        private JPictureBox pictureBox_craft_req_1;
        private JPictureBox pictureBox_craft_32;
        private ContextMenuStrip contextMenuStripproduce;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem2;
        private JPictureBox pictureBox_craft_31;
        private JPictureBox pictureBox_craft_30;
        private JPictureBox pictureBox_craft_29;
        private JPictureBox pictureBox_craft_28;
        private JPictureBox pictureBox_craft_27;
        private JPictureBox pictureBox_craft_26;
        private JPictureBox pictureBox_craft_25;
        private JPictureBox pictureBox_craft_24;
        private JPictureBox pictureBox_craft_23;
        private JPictureBox pictureBox_craft_22;
        private JPictureBox pictureBox_craft_21;
        private JPictureBox pictureBox_craft_20;
        private JPictureBox pictureBox_craft_19;
        private JPictureBox pictureBox_craft_18;
        private JPictureBox pictureBox_craft_17;
        private JPictureBox pictureBox_craft_16;
        private JPictureBox pictureBox_craft_15;
        private JPictureBox pictureBox_craft_14;
        private JPictureBox pictureBox_craft_13;
        private JPictureBox pictureBox_craft_12;
        private JPictureBox pictureBox_craft_11;
        private JPictureBox pictureBox_craft_10;
        private JPictureBox pictureBox_craft_9;
        private JPictureBox pictureBox_craft_8;
        private JPictureBox pictureBox_craft_7;
        private JPictureBox pictureBox_craft_6;
        private JPictureBox pictureBox_craft_5;
        private JPictureBox pictureBox_craft_4;
        private JPictureBox pictureBox_craft_3;
        private JPictureBox pictureBox_craft_2;
        private JPictureBox pictureBox_craft_1;
        private JButton button9;
        private JTextBox textBox3;
        private JButton tab_craftbtn_1;
        private JButton tab_craftbtn_5;
        private JButton tab_craftbtn_2;
        private JButton tab_craftbtn_8;
        private JButton tab_craftbtn_3;
        private JButton tab_craftbtn_7;
        private JButton tab_craftbtn_4;
        private JButton tab_craftbtn_6;
        private JCheckBox checkBox1;
        private JTextBox textBox16;
        private JTextBox textBox17;
        private JPictureBox pictureBox44;
        private JTextBox textBox13;
        private JTextBox textBox14;
        private JPictureBox pictureBox43;
        private JTextBox textBox10;
        private JTextBox textBox11;
        private JPictureBox pictureBox42;
        private JTextBox textBox6;
        private JTextBox textBox8;
        private JTextBox textBox4;
        private JTextBox textBox5;
        private JLabel label3;
        private JLabel label4;
        private JButton button11;
        private JButton button12;
        private JButton button13;
        private JLabel label5;
        private JTextBox textBox7;
        private JLabel label17;
        private JLabel label8;
        private JButton button14;
        private JTextBox textBox24;
        private JLabel label33;
        private JTextBox textBox22;
        private JLabel label31;
        private JTextBox textBox21;
        private JLabel label30;
        private JTextBox textBox18;
        private JLabel label27;
        private JTextBox textBox15;
        private JLabel label26;
        private JTextBox textBox12;
        private JLabel label25;
        private JTextBox textBox9;
        private JLabel label24;
        private JComboBox comboBox2;
        private JLabel label23;
        private JLabel label20;
        private JComboBox comboBox1;
        private JTextBox textBox20;
        private JLabel label29;
        private JTextBox textBox19;
        private JLabel label28;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem changeToolStripMenuItem2;
        private ContextMenuStrip classmaskMenu;
        private JTabPage tabPage4;
        private JDataGridView dataGridView1;
        private JButton button15;
        private JTextBox textBox23;
        private JButton button5;
        private JButton button16;
        private JTextBox textBox25;
        private JComboBox comboBox3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyAllItemNamesToClipboardToolStripMenuItem;
        private ToolStripMenuItem copyAllItemNamesToClipboardToolStripMenuItem1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private ToolStripMenuItem makeRecipesToolStripMenuItem2;
        private ToolStripMenuItem reforgeTypeToolStripMenuItem;
        private ToolStripMenuItem targetTypeToolStripMenuItem;
        private ToolStripMenuItem materialTypeToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pastToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem copySelectedItemsToClipboardToolStripMenuItem;
        private ToolStripMenuItem exportSkillsToListToolStripMenuItem;
        private ToolStripMenuItem readListDEBUGToolStripMenuItem;
        private ToolStripMenuItem skillsToolStripMenuItem;
        private ToolStripMenuItem saveToDiskToolStripMenuItem;
        private JTabPage Edit;
        private JTabPage craftTab;
        private JPictureBox jPictureBox1;
        private JPictureBox jPictureBox2;
        private ToolStripMenuItem invertRowsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem saveAsToolStripMenuItem1;
        private JCheckBox checkBox2;
        private JCheckBox checkBox4;
        private JCheckBox checkBox5;
        private JPictureBox jPictureBox3;
        private JLabel nextautoIdlabel;
        private JLabel jLabel1;
        private JLabel jLabel2;
        private JLabel pathLabel;
        private JPictureBox jPictureBox4;
        private ToolStripMenuItem asignNewIdsToolStripMenuItem;
        private ToolStripMenuItem viewModelToolStripMenuItem;
        private JPictureBox jPictureBox5;
        private ContextMenuStrip Tools;
        private ToolStripMenuItem skillsToolStripMenuItem1;
        private ToolStripMenuItem exportSkillsToListToolStripMenuItem1;
        private ToolStripMenuItem skillOctetsGeneratorToolStripMenuItem;
        private ToolStripMenuItem elementEditorToolStripMenuItem;
        private ToolStripMenuItem readListUsefulForEncryptedFilesToolStripMenuItem;
        private JLabel label6;
        private JLabel label2;
        private JContextMenu BookMarks;
        private ToolStripMenuItem goToToolStripMenuItem;
        private ToolStripMenuItem bookMarkToolStripMenuItem;
        private JGroupBox groupBox1;
        private JGroupBox groupBox4;
        private JGroupBox groupBox11;
        private JGroupBox groupBox10;
        private JGroupBox groupBox8;
        private JGroupBox groupBox17;
        private JGroupBox groupBox18;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewImageColumn ColumnImg;
        private DataGridViewTextBoxColumn ColumnName;
        private ToolStripMenuItem importConfigsToolStripMenuItem;
        private ToolStripMenuItem loadRequiredFilesFrompckToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private JGroupBox jGroupBox1;
        private JGroupBox jGroupBox2;
        private ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator8;
        private JTextBox jTextBox1;
        private JComboBox jComboBox1;
        private ToolStripMenuItem findDuplicatesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private ToolStripMenuItem sortIdsToolStripMenuItem;
        private ToolStripMenuItem idAscToolStripMenuItem;
        private ToolStripMenuItem aSKToolStripMenuItem;
        private ToolStripMenuItem dSKToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem recalculateDropsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem recalculateRandsToolStripMenuItem;
        private ToolStripMenuItem recalculateAdonsToolStripMenuItem;
        private ToolStripMenuItem dropSelectedAddonFasterToolStripMenuItem;
        private ToolStripMenuItem showSumeToolStripMenuItem;
        private ToolStripMenuItem showSumeToolStripMenuItem1;
        private ToolStripMenuItem exportIconsForPWAdminToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem makePetEggToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem pathFixerToolStripMenuItem;
        private ToolStripMenuItem calculateTotalToolStripMenuItem;
        private ToolStripMenuItem iconsEditorToolStripMenuItem;
        private ToolStripMenuItem CopyPetToolStripMenuItem;
        private ToolStripMenuItem PastePetToolStripMenuItem1;
    }
}

