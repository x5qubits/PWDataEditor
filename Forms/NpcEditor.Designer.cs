using JHUI.Controls;
using System.Windows.Forms;

namespace PWnpcEditor
{
    partial class NpcEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            JHUI.JAnimation jAnimation2 = new JHUI.JAnimation();
            this.mobsNpcList = new System.Windows.Forms.ListBox();
            this.NPC_MOB_CONTEXTLIST = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toGameCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToCoorddatatxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toClipboardForPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.copyElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new JHUI.Controls.JTabControl();
            this.tabPage1 = new JHUI.Controls.JTabPage();
            this.groupBox4 = new JHUI.Controls.JGroupBox();
            this.grupeNpcMob = new JHUI.Controls.JDataGridView();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPC_MOB_CONTEXTLIST_GRUPE = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new JHUI.Controls.JGroupBox();
            this.jButton1 = new JHUI.Controls.JButton();
            this.mobnpc_ingen = new JHUI.Controls.JCheckBox();
            this.mobnpc_autor = new JHUI.Controls.JCheckBox();
            this.mobnpc_validone = new JHUI.Controls.JCheckBox();
            this.mobnpc_maxNum = new JHUI.Controls.JTextBox();
            this.mobnpc_lt = new JHUI.Controls.JTextBox();
            this.mobnpc_gt = new JHUI.Controls.JTextBox();
            this.mobnpc_gid = new JHUI.Controls.JTextBox();
            this.mobnpc_trig = new JHUI.Controls.JTextBox();
            this.label18 = new JHUI.Controls.JLabel();
            this.label17 = new JHUI.Controls.JLabel();
            this.label16 = new JHUI.Controls.JLabel();
            this.label14 = new JHUI.Controls.JLabel();
            this.label9 = new JHUI.Controls.JLabel();
            this.groupBox2 = new JHUI.Controls.JGroupBox();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.mobnpc_rx = new JHUI.Controls.JTextBox();
            this.mobnpc_z = new JHUI.Controls.JTextBox();
            this.mobnpc_positiontype = new JHUI.Controls.JComboBox();
            this.mobnpc_rz = new JHUI.Controls.JTextBox();
            this.mobnpc_az = new JHUI.Controls.JTextBox();
            this.mobnpc_ry = new JHUI.Controls.JTextBox();
            this.mobnpc_x = new JHUI.Controls.JTextBox();
            this.mobnpc_ay = new JHUI.Controls.JTextBox();
            this.mobnpc_y = new JHUI.Controls.JTextBox();
            this.mobnpc_ax = new JHUI.Controls.JTextBox();
            this.labelZ = new JHUI.Controls.JLabel();
            this.labelY = new JHUI.Controls.JLabel();
            this.labelX = new JHUI.Controls.JLabel();
            this.label15 = new JHUI.Controls.JLabel();
            this.label3 = new JHUI.Controls.JLabel();
            this.label4 = new JHUI.Controls.JLabel();
            this.label5 = new JHUI.Controls.JLabel();
            this.label6 = new JHUI.Controls.JLabel();
            this.label7 = new JHUI.Controls.JLabel();
            this.label8 = new JHUI.Controls.JLabel();
            this.label10 = new JHUI.Controls.JLabel();
            this.label11 = new JHUI.Controls.JLabel();
            this.label12 = new JHUI.Controls.JLabel();
            this.groupBox1 = new JHUI.Controls.JGroupBox();
            this.mobnpc_name = new JHUI.Controls.JTextBox();
            this.mobnpc_type = new JHUI.Controls.JComboBox();
            this.mobnpc_id = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.label13 = new JHUI.Controls.JLabel();
            this.tabPage2 = new JHUI.Controls.JTabPage();
            this.dataGridView_resourceGroups = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RES_STRIP_MENU_GROUPE = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_resources = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RES_STRIP_MENU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fillCoordinatesFromGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importSelectedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new JHUI.Controls.JTabPage();
            this.groupBox8 = new JHUI.Controls.JGroupBox();
            this.Dyntext_image = new JHUI.Controls.JPictureBox();
            this.groupBox7 = new JHUI.Controls.JGroupBox();
            this.Dyntext_trig = new JHUI.Controls.JTextBox();
            this.label26 = new JHUI.Controls.JLabel();
            this.groupBox6 = new JHUI.Controls.JGroupBox();
            this.Dyntext_name = new JHUI.Controls.JComboBox();
            this.label28 = new JHUI.Controls.JLabel();
            this.Dyntext_id = new JHUI.Controls.JTextBox();
            this.label20 = new JHUI.Controls.JLabel();
            this.groupBox5 = new JHUI.Controls.JGroupBox();
            this.Dyntext_z = new JHUI.Controls.JTextBox();
            this.label21 = new JHUI.Controls.JLabel();
            this.label22 = new JHUI.Controls.JLabel();
            this.label23 = new JHUI.Controls.JLabel();
            this.label19 = new JHUI.Controls.JLabel();
            this.label27 = new JHUI.Controls.JLabel();
            this.Dyntext_x = new JHUI.Controls.JTextBox();
            this.Dyntext_y = new JHUI.Controls.JTextBox();
            this.Dyntext_scale = new JHUI.Controls.JTextBox();
            this.Dyntext_dx = new JHUI.Controls.JTextBox();
            this.label24 = new JHUI.Controls.JLabel();
            this.Dyntext_dy = new JHUI.Controls.JTextBox();
            this.label25 = new JHUI.Controls.JLabel();
            this.Dyntext_dz = new JHUI.Controls.JTextBox();
            this.Dyntext_items = new System.Windows.Forms.ListBox();
            this.DIN_STRIP_MENU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage4 = new JHUI.Controls.JTabPage();
            this.dataGridView_triggers = new JHUI.Controls.JDataGridView();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column42 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column43 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRIGER_STRIP_MENU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exportSelectedToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.importSelectedToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.sortIdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idAscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new JHUI.Controls.JCheckBox();
            this.comboBox1 = new JHUI.Controls.JComboBox();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.Save = new JHUI.Controls.JContextMenu(this.components);
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.version11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.version10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jTabControl1 = new JHUI.Controls.JTabControl();
            this.tabPage5 = new JHUI.Controls.JTabPage();
            this.jComboBox1 = new JHUI.Controls.JComboBox();
            this.jPictureBox4 = new JHUI.Controls.JPictureBox();
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.importFromCoordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jCheckBox1 = new JHUI.Controls.JCheckBox();
            this.jPictureBox3 = new JHUI.Controls.JPictureBox();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.pathLabel = new JHUI.Controls.JLabel();
            this.version_label = new JHUI.Controls.JLabel();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.searchInput1 = new JHUI.Controls.JTextBox();
            this.jPictureBox5 = new JHUI.Controls.JPictureBox();
            this.NPC_MOB_CONTEXTLIST.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupeNpcMob)).BeginInit();
            this.NPC_MOB_CONTEXTLIST_GRUPE.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resourceGroups)).BeginInit();
            this.RES_STRIP_MENU_GROUPE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resources)).BeginInit();
            this.RES_STRIP_MENU.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dyntext_image)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.DIN_STRIP_MENU.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_triggers)).BeginInit();
            this.TRIGER_STRIP_MENU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            this.Save.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.jTabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).BeginInit();
            this.jContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // mobsNpcList
            // 
            this.mobsNpcList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mobsNpcList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.mobsNpcList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mobsNpcList.ContextMenuStrip = this.NPC_MOB_CONTEXTLIST;
            this.mobsNpcList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.mobsNpcList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobsNpcList.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.mobsNpcList.FormattingEnabled = true;
            this.mobsNpcList.ItemHeight = 15;
            this.mobsNpcList.Location = new System.Drawing.Point(7, 13);
            this.mobsNpcList.MinimumSize = new System.Drawing.Size(249, 495);
            this.mobsNpcList.Name = "mobsNpcList";
            this.mobsNpcList.ScrollAlwaysVisible = true;
            this.mobsNpcList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.mobsNpcList.Size = new System.Drawing.Size(249, 495);
            this.mobsNpcList.TabIndex = 0;
            this.mobsNpcList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.mobsNpcList_DrawItem);
            this.mobsNpcList.SelectedIndexChanged += new System.EventHandler(this.mobsNpcList_SelectedIndexChanged);
            this.mobsNpcList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mobsNpcList_KeyDown_1);
            // 
            // NPC_MOB_CONTEXTLIST
            // 
            this.NPC_MOB_CONTEXTLIST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportSelectedToolStripMenuItem,
            this.importSelectedToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolStripMenuItem2,
            this.toGameCoordinatesToolStripMenuItem,
            this.toolStripSeparator10,
            this.exportToCoorddatatxtToolStripMenuItem,
            this.toClipboardForPToolStripMenuItem,
            this.toolStripSeparator11,
            this.copyElementsToolStripMenuItem});
            this.NPC_MOB_CONTEXTLIST.Name = "NPC_MOB_CONTEXTLIST";
            this.NPC_MOB_CONTEXTLIST.Size = new System.Drawing.Size(239, 226);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // exportSelectedToolStripMenuItem
            // 
            this.exportSelectedToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.exportSelectedToolStripMenuItem.Name = "exportSelectedToolStripMenuItem";
            this.exportSelectedToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.exportSelectedToolStripMenuItem.Text = "Export";
            this.exportSelectedToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedToolStripMenuItem_Click);
            // 
            // importSelectedToolStripMenuItem
            // 
            this.importSelectedToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_import;
            this.importSelectedToolStripMenuItem.Name = "importSelectedToolStripMenuItem";
            this.importSelectedToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.importSelectedToolStripMenuItem.Text = "Import";
            this.importSelectedToolStripMenuItem.Click += new System.EventHandler(this.importSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(235, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem2.Text = "Fill Coordinates From Game";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.button4_Click);
            // 
            // toGameCoordinatesToolStripMenuItem
            // 
            this.toGameCoordinatesToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Weather_sun;
            this.toGameCoordinatesToolStripMenuItem.Name = "toGameCoordinatesToolStripMenuItem";
            this.toGameCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.toGameCoordinatesToolStripMenuItem.Text = "To Game Coordinates";
            this.toGameCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.button8_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(235, 6);
            // 
            // exportToCoorddatatxtToolStripMenuItem
            // 
            this.exportToCoorddatatxtToolStripMenuItem.Name = "exportToCoorddatatxtToolStripMenuItem";
            this.exportToCoorddatatxtToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.exportToCoorddatatxtToolStripMenuItem.Text = "To Clipboard for coord_data.txt";
            this.exportToCoorddatatxtToolStripMenuItem.Click += new System.EventHandler(this.exportToCoorddatatxtToolStripMenuItem_Click);
            // 
            // toClipboardForPToolStripMenuItem
            // 
            this.toClipboardForPToolStripMenuItem.Name = "toClipboardForPToolStripMenuItem";
            this.toClipboardForPToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.toClipboardForPToolStripMenuItem.Text = "To Clipboard for precinct.clt";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(235, 6);
            // 
            // copyElementsToolStripMenuItem
            // 
            this.copyElementsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Forward_button;
            this.copyElementsToolStripMenuItem.Name = "copyElementsToolStripMenuItem";
            this.copyElementsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.copyElementsToolStripMenuItem.Text = "Copy Elements";
            this.copyElementsToolStripMenuItem.Click += new System.EventHandler(this.copyElementsToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            jAnimation1.AnimateOnlyDifferences = false;
            jAnimation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.BlindCoeff")));
            jAnimation1.LeafCoeff = 0F;
            jAnimation1.MaxTime = 1F;
            jAnimation1.MinTime = 0F;
            jAnimation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicCoeff")));
            jAnimation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicShift")));
            jAnimation1.MosaicSize = 0;
            jAnimation1.Padding = new System.Windows.Forms.Padding(0);
            jAnimation1.RotateCoeff = 0F;
            jAnimation1.RotateLimit = 0F;
            jAnimation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.ScaleCoeff")));
            jAnimation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.SlideCoeff")));
            jAnimation1.TimeCoeff = 1F;
            jAnimation1.TransparencyCoeff = 0F;
            this.tabControl1.ChangeAnimation = jAnimation1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 0);
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(949, 562);
            this.tabControl1.Style = JHUI.JColorStyle.Orange;
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Theme = JHUI.JThemeStyle.Dark;
            this.tabControl1.UseSelectable = true;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.AutoScrollMinSize = new System.Drawing.Size(941, 532);
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.mobsNpcList);
            this.tabPage1.HorizontalScrollbar = true;
            this.tabPage1.HorizontalScrollbarBarColor = true;
            this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage1.HorizontalScrollbarSize = 10;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(941, 532);
            this.tabPage1.Style = JHUI.JColorStyle.Gold;
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NPCs/Mobs";
            this.tabPage1.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage1.VerticalScrollbar = true;
            this.tabPage1.VerticalScrollbarBarColor = true;
            this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage1.VerticalScrollbarSize = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox4.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox4.Controls.Add(this.grupeNpcMob);
            this.groupBox4.DrawBottomLine = false;
            this.groupBox4.DrawShadows = false;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox4.FontSize = JHUI.JLabelSize.Small;
            this.groupBox4.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox4.Location = new System.Drawing.Point(261, 273);
            this.groupBox4.MinimumSize = new System.Drawing.Size(673, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.PaintDefault = false;
            this.groupBox4.Size = new System.Drawing.Size(679, 236);
            this.groupBox4.Style = JHUI.JColorStyle.Gold;
            this.groupBox4.StyleManager = null;
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Group";
            this.groupBox4.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox4.UseStyleColors = false;
            // 
            // grupeNpcMob
            // 
            this.grupeNpcMob.AllowUserToAddRows = false;
            this.grupeNpcMob.AllowUserToDeleteRows = false;
            this.grupeNpcMob.AllowUserToResizeRows = false;
            this.grupeNpcMob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grupeNpcMob.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.grupeNpcMob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grupeNpcMob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grupeNpcMob.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grupeNpcMob.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grupeNpcMob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grupeNpcMob.ColumnHeadersHeight = 22;
            this.grupeNpcMob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column30,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18});
            this.grupeNpcMob.ContextMenuStrip = this.NPC_MOB_CONTEXTLIST_GRUPE;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grupeNpcMob.DefaultCellStyle = dataGridViewCellStyle2;
            this.grupeNpcMob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupeNpcMob.EnableHeadersVisualStyles = false;
            this.grupeNpcMob.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grupeNpcMob.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.grupeNpcMob.Location = new System.Drawing.Point(3, 19);
            this.grupeNpcMob.Name = "grupeNpcMob";
            this.grupeNpcMob.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grupeNpcMob.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grupeNpcMob.RowHeadersVisible = false;
            this.grupeNpcMob.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grupeNpcMob.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grupeNpcMob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grupeNpcMob.Size = new System.Drawing.Size(673, 214);
            this.grupeNpcMob.Style = JHUI.JColorStyle.Orange;
            this.grupeNpcMob.TabIndex = 0;
            this.grupeNpcMob.Theme = JHUI.JThemeStyle.Dark;
            this.grupeNpcMob.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grupeNpcMob_CellValueChanged);
            this.grupeNpcMob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mobsNpcList_KeyDown);
            // 
            // Column30
            // 
            this.Column30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column30.HeaderText = "Name";
            this.Column30.Name = "Column30";
            this.Column30.ReadOnly = true;
            this.Column30.Width = 59;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 21;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Count";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 43;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Refresh";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Die Times";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 59;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Agressive";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 59;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.HeaderText = "Water Offset";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 77;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "Turn Offset";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 69;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column8.HeaderText = "Faction";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 49;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column9.HeaderText = "Faction Helper";
            this.Column9.Name = "Column9";
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 86;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column10.HeaderText = "Faction Accept";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 86;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column11.HeaderText = "Need Help";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.Width = 65;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column12.HeaderText = "Def Faction Help";
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.Width = 97;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column13.HeaderText = "Fac Help";
            this.Column13.Name = "Column13";
            this.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column13.Width = 55;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column14.HeaderText = "Fac Accept";
            this.Column14.Name = "Column14";
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column14.Width = 65;
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column15.HeaderText = "Path Id";
            this.Column15.Name = "Column15";
            this.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column15.Width = 47;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column16.HeaderText = "Path Type";
            this.Column16.Name = "Column16";
            this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column16.Width = 59;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column17.HeaderText = "Speed";
            this.Column17.Name = "Column17";
            this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column17.Width = 43;
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column18.HeaderText = "Delay";
            this.Column18.Name = "Column18";
            this.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column18.Width = 39;
            // 
            // NPC_MOB_CONTEXTLIST_GRUPE
            // 
            this.NPC_MOB_CONTEXTLIST_GRUPE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator7,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.NPC_MOB_CONTEXTLIST_GRUPE.Name = "NPC_MOB_CONTEXTLIST_GRUPE";
            this.NPC_MOB_CONTEXTLIST_GRUPE.Size = new System.Drawing.Size(170, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.View;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem1.Text = "Select In Elements";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.button17_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(166, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox3.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox3.Controls.Add(this.jButton1);
            this.groupBox3.Controls.Add(this.mobnpc_ingen);
            this.groupBox3.Controls.Add(this.mobnpc_autor);
            this.groupBox3.Controls.Add(this.mobnpc_validone);
            this.groupBox3.Controls.Add(this.mobnpc_maxNum);
            this.groupBox3.Controls.Add(this.mobnpc_lt);
            this.groupBox3.Controls.Add(this.mobnpc_gt);
            this.groupBox3.Controls.Add(this.mobnpc_gid);
            this.groupBox3.Controls.Add(this.mobnpc_trig);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.DrawBottomLine = false;
            this.groupBox3.DrawShadows = false;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox3.FontSize = JHUI.JLabelSize.Small;
            this.groupBox3.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Location = new System.Drawing.Point(467, 7);
            this.groupBox3.MinimumSize = new System.Drawing.Size(467, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.PaintDefault = false;
            this.groupBox3.Size = new System.Drawing.Size(473, 100);
            this.groupBox3.Style = JHUI.JColorStyle.Gold;
            this.groupBox3.StyleManager = null;
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GM ID";
            this.groupBox3.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox3.UseStyleColors = false;
            // 
            // jButton1
            // 
            this.jButton1.Location = new System.Drawing.Point(410, 11);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(57, 20);
            this.jButton1.Style = JHUI.JColorStyle.White;
            this.jButton1.TabIndex = 17;
            this.jButton1.Text = "GM ID";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // mobnpc_ingen
            // 
            this.mobnpc_ingen.AutoSize = true;
            this.mobnpc_ingen.Location = new System.Drawing.Point(13, 19);
            this.mobnpc_ingen.Name = "mobnpc_ingen";
            this.mobnpc_ingen.Size = new System.Drawing.Size(64, 15);
            this.mobnpc_ingen.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_ingen.TabIndex = 16;
            this.mobnpc_ingen.Text = "Init Gen";
            this.mobnpc_ingen.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_ingen.UseSelectable = true;
            this.mobnpc_ingen.UseVisualStyleBackColor = true;
            this.mobnpc_ingen.CheckedChanged += new System.EventHandler(this.mobnpc_ingen_CheckedChanged);
            // 
            // mobnpc_autor
            // 
            this.mobnpc_autor.AutoSize = true;
            this.mobnpc_autor.Location = new System.Drawing.Point(13, 37);
            this.mobnpc_autor.Name = "mobnpc_autor";
            this.mobnpc_autor.Size = new System.Drawing.Size(86, 15);
            this.mobnpc_autor.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_autor.TabIndex = 16;
            this.mobnpc_autor.Text = "Auto Revive";
            this.mobnpc_autor.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_autor.UseSelectable = true;
            this.mobnpc_autor.UseVisualStyleBackColor = true;
            this.mobnpc_autor.CheckedChanged += new System.EventHandler(this.mobnpc_autor_CheckedChanged);
            // 
            // mobnpc_validone
            // 
            this.mobnpc_validone.AutoSize = true;
            this.mobnpc_validone.Location = new System.Drawing.Point(13, 57);
            this.mobnpc_validone.Name = "mobnpc_validone";
            this.mobnpc_validone.Size = new System.Drawing.Size(79, 15);
            this.mobnpc_validone.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_validone.TabIndex = 16;
            this.mobnpc_validone.Text = "Valid Once";
            this.mobnpc_validone.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_validone.UseSelectable = true;
            this.mobnpc_validone.UseVisualStyleBackColor = true;
            this.mobnpc_validone.CheckedChanged += new System.EventHandler(this.mobnpc_validone_CheckedChanged);
            // 
            // mobnpc_maxNum
            // 
            this.mobnpc_maxNum.BorderBottomLineSize = 5;
            this.mobnpc_maxNum.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_maxNum.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_maxNum.CustomButton.Image = null;
            this.mobnpc_maxNum.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_maxNum.CustomButton.Name = "";
            this.mobnpc_maxNum.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_maxNum.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_maxNum.CustomButton.TabIndex = 1;
            this.mobnpc_maxNum.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_maxNum.CustomButton.UseSelectable = true;
            this.mobnpc_maxNum.CustomButton.Visible = false;
            this.mobnpc_maxNum.DrawBorder = true;
            this.mobnpc_maxNum.DrawBorderBottomLine = false;
            this.mobnpc_maxNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_maxNum.Lines = new string[0];
            this.mobnpc_maxNum.Location = new System.Drawing.Point(69, 74);
            this.mobnpc_maxNum.MaxLength = 32767;
            this.mobnpc_maxNum.Name = "mobnpc_maxNum";
            this.mobnpc_maxNum.PasswordChar = '\0';
            this.mobnpc_maxNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_maxNum.SelectedText = "";
            this.mobnpc_maxNum.SelectionLength = 0;
            this.mobnpc_maxNum.SelectionStart = 0;
            this.mobnpc_maxNum.ShortcutsEnabled = true;
            this.mobnpc_maxNum.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_maxNum.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_maxNum.TabIndex = 15;
            this.mobnpc_maxNum.TextWaterMark = "";
            this.mobnpc_maxNum.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_maxNum.UseCustomFont = true;
            this.mobnpc_maxNum.UseSelectable = true;
            this.mobnpc_maxNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_maxNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_maxNum.TextChanged += new System.EventHandler(this.mobnpc_maxNum_TextChanged);
            // 
            // mobnpc_lt
            // 
            this.mobnpc_lt.BorderBottomLineSize = 5;
            this.mobnpc_lt.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_lt.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_lt.CustomButton.Image = null;
            this.mobnpc_lt.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.mobnpc_lt.CustomButton.Name = "";
            this.mobnpc_lt.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_lt.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_lt.CustomButton.TabIndex = 1;
            this.mobnpc_lt.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_lt.CustomButton.UseSelectable = true;
            this.mobnpc_lt.CustomButton.Visible = false;
            this.mobnpc_lt.DrawBorder = true;
            this.mobnpc_lt.DrawBorderBottomLine = false;
            this.mobnpc_lt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_lt.Lines = new string[0];
            this.mobnpc_lt.Location = new System.Drawing.Point(344, 76);
            this.mobnpc_lt.MaxLength = 32767;
            this.mobnpc_lt.Name = "mobnpc_lt";
            this.mobnpc_lt.PasswordChar = '\0';
            this.mobnpc_lt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_lt.SelectedText = "";
            this.mobnpc_lt.SelectionLength = 0;
            this.mobnpc_lt.SelectionStart = 0;
            this.mobnpc_lt.ShortcutsEnabled = true;
            this.mobnpc_lt.Size = new System.Drawing.Size(123, 20);
            this.mobnpc_lt.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_lt.TabIndex = 15;
            this.mobnpc_lt.TextWaterMark = "";
            this.mobnpc_lt.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_lt.UseCustomFont = true;
            this.mobnpc_lt.UseSelectable = true;
            this.mobnpc_lt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_lt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_lt.TextChanged += new System.EventHandler(this.mobnpc_lt_TextChanged);
            // 
            // mobnpc_gt
            // 
            this.mobnpc_gt.BorderBottomLineSize = 5;
            this.mobnpc_gt.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_gt.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_gt.CustomButton.Image = null;
            this.mobnpc_gt.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.mobnpc_gt.CustomButton.Name = "";
            this.mobnpc_gt.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_gt.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_gt.CustomButton.TabIndex = 1;
            this.mobnpc_gt.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_gt.CustomButton.UseSelectable = true;
            this.mobnpc_gt.CustomButton.Visible = false;
            this.mobnpc_gt.DrawBorder = true;
            this.mobnpc_gt.DrawBorderBottomLine = false;
            this.mobnpc_gt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_gt.Lines = new string[0];
            this.mobnpc_gt.Location = new System.Drawing.Point(344, 54);
            this.mobnpc_gt.MaxLength = 32767;
            this.mobnpc_gt.Name = "mobnpc_gt";
            this.mobnpc_gt.PasswordChar = '\0';
            this.mobnpc_gt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_gt.SelectedText = "";
            this.mobnpc_gt.SelectionLength = 0;
            this.mobnpc_gt.SelectionStart = 0;
            this.mobnpc_gt.ShortcutsEnabled = true;
            this.mobnpc_gt.Size = new System.Drawing.Size(123, 20);
            this.mobnpc_gt.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_gt.TabIndex = 15;
            this.mobnpc_gt.TextWaterMark = "";
            this.mobnpc_gt.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_gt.UseCustomFont = true;
            this.mobnpc_gt.UseSelectable = true;
            this.mobnpc_gt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_gt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_gt.TextChanged += new System.EventHandler(this.mobnpc_gt_TextChanged);
            // 
            // mobnpc_gid
            // 
            this.mobnpc_gid.BorderBottomLineSize = 5;
            this.mobnpc_gid.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_gid.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_gid.CustomButton.Image = null;
            this.mobnpc_gid.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.mobnpc_gid.CustomButton.Name = "";
            this.mobnpc_gid.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_gid.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_gid.CustomButton.TabIndex = 1;
            this.mobnpc_gid.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_gid.CustomButton.UseSelectable = true;
            this.mobnpc_gid.CustomButton.Visible = false;
            this.mobnpc_gid.DrawBorder = true;
            this.mobnpc_gid.DrawBorderBottomLine = false;
            this.mobnpc_gid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_gid.Lines = new string[0];
            this.mobnpc_gid.Location = new System.Drawing.Point(344, 33);
            this.mobnpc_gid.MaxLength = 32767;
            this.mobnpc_gid.Name = "mobnpc_gid";
            this.mobnpc_gid.PasswordChar = '\0';
            this.mobnpc_gid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_gid.SelectedText = "";
            this.mobnpc_gid.SelectionLength = 0;
            this.mobnpc_gid.SelectionStart = 0;
            this.mobnpc_gid.ShortcutsEnabled = true;
            this.mobnpc_gid.Size = new System.Drawing.Size(123, 20);
            this.mobnpc_gid.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_gid.TabIndex = 15;
            this.mobnpc_gid.TextWaterMark = "";
            this.mobnpc_gid.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_gid.UseCustomFont = true;
            this.mobnpc_gid.UseSelectable = true;
            this.mobnpc_gid.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_gid.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_gid.TextChanged += new System.EventHandler(this.mobnpc_gid_TextChanged);
            // 
            // mobnpc_trig
            // 
            this.mobnpc_trig.BorderBottomLineSize = 5;
            this.mobnpc_trig.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_trig.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_trig.CustomButton.Image = null;
            this.mobnpc_trig.CustomButton.Location = new System.Drawing.Point(46, 2);
            this.mobnpc_trig.CustomButton.Name = "";
            this.mobnpc_trig.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_trig.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_trig.CustomButton.TabIndex = 1;
            this.mobnpc_trig.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_trig.CustomButton.UseSelectable = true;
            this.mobnpc_trig.CustomButton.Visible = false;
            this.mobnpc_trig.DrawBorder = true;
            this.mobnpc_trig.DrawBorderBottomLine = false;
            this.mobnpc_trig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_trig.Lines = new string[0];
            this.mobnpc_trig.Location = new System.Drawing.Point(344, 12);
            this.mobnpc_trig.MaxLength = 32767;
            this.mobnpc_trig.Name = "mobnpc_trig";
            this.mobnpc_trig.PasswordChar = '\0';
            this.mobnpc_trig.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_trig.SelectedText = "";
            this.mobnpc_trig.SelectionLength = 0;
            this.mobnpc_trig.SelectionStart = 0;
            this.mobnpc_trig.ShortcutsEnabled = true;
            this.mobnpc_trig.Size = new System.Drawing.Size(64, 20);
            this.mobnpc_trig.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_trig.TabIndex = 15;
            this.mobnpc_trig.TextWaterMark = "";
            this.mobnpc_trig.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_trig.UseCustomFont = true;
            this.mobnpc_trig.UseSelectable = true;
            this.mobnpc_trig.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_trig.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_trig.TextChanged += new System.EventHandler(this.mobnpc_trig_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.DropShadowColor = System.Drawing.Color.Black;
            this.label18.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label18.FontSize = JHUI.JLabelSize.Small;
            this.label18.Location = new System.Drawing.Point(11, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 15);
            this.label18.Style = JHUI.JColorStyle.Gold;
            this.label18.TabIndex = 10;
            this.label18.Text = "Max Num:";
            this.label18.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.DropShadowColor = System.Drawing.Color.Black;
            this.label17.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label17.FontSize = JHUI.JLabelSize.Small;
            this.label17.Location = new System.Drawing.Point(276, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 15);
            this.label17.Style = JHUI.JColorStyle.Gold;
            this.label17.TabIndex = 10;
            this.label17.Text = "Life Time:";
            this.label17.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.DropShadowColor = System.Drawing.Color.Black;
            this.label16.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label16.FontSize = JHUI.JLabelSize.Small;
            this.label16.Location = new System.Drawing.Point(276, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.Style = JHUI.JColorStyle.Gold;
            this.label16.TabIndex = 10;
            this.label16.Text = "Grupe Type:";
            this.label16.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.DropShadowColor = System.Drawing.Color.Black;
            this.label14.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label14.FontSize = JHUI.JLabelSize.Small;
            this.label14.Location = new System.Drawing.Point(301, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 15);
            this.label14.Style = JHUI.JColorStyle.Gold;
            this.label14.TabIndex = 10;
            this.label14.Text = "GenID:";
            this.label14.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DropShadowColor = System.Drawing.Color.Black;
            this.label9.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label9.FontSize = JHUI.JLabelSize.Small;
            this.label9.Location = new System.Drawing.Point(301, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.Style = JHUI.JColorStyle.Gold;
            this.label9.TabIndex = 10;
            this.label9.Text = "Triger:";
            this.label9.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox2.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox2.Controls.Add(this.jTextBox1);
            this.groupBox2.Controls.Add(this.mobnpc_rx);
            this.groupBox2.Controls.Add(this.mobnpc_z);
            this.groupBox2.Controls.Add(this.mobnpc_positiontype);
            this.groupBox2.Controls.Add(this.mobnpc_rz);
            this.groupBox2.Controls.Add(this.mobnpc_az);
            this.groupBox2.Controls.Add(this.mobnpc_ry);
            this.groupBox2.Controls.Add(this.mobnpc_x);
            this.groupBox2.Controls.Add(this.mobnpc_ay);
            this.groupBox2.Controls.Add(this.mobnpc_y);
            this.groupBox2.Controls.Add(this.mobnpc_ax);
            this.groupBox2.Controls.Add(this.labelZ);
            this.groupBox2.Controls.Add(this.labelY);
            this.groupBox2.Controls.Add(this.labelX);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.DrawBottomLine = false;
            this.groupBox2.DrawShadows = false;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox2.FontSize = JHUI.JLabelSize.Small;
            this.groupBox2.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Location = new System.Drawing.Point(262, 113);
            this.groupBox2.MinimumSize = new System.Drawing.Size(673, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.PaintDefault = false;
            this.groupBox2.Size = new System.Drawing.Size(679, 161);
            this.groupBox2.Style = JHUI.JColorStyle.Gold;
            this.groupBox2.StyleManager = null;
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location";
            this.groupBox2.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox2.UseStyleColors = false;
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
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(128, 2);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.CustomButton.Visible = false;
            this.jTextBox1.DrawBorder = true;
            this.jTextBox1.DrawBorderBottomLine = false;
            this.jTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(48, 32);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.Size = new System.Drawing.Size(146, 20);
            this.jTextBox1.Style = JHUI.JColorStyle.Orange;
            this.jTextBox1.TabIndex = 23;
            this.jTextBox1.TextWaterMark = "Input Game Coordinates";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomFont = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.TextChanged += new System.EventHandler(this.jTextBox1_TextChanged);
            // 
            // mobnpc_rx
            // 
            this.mobnpc_rx.BorderBottomLineSize = 5;
            this.mobnpc_rx.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_rx.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_rx.CustomButton.Image = null;
            this.mobnpc_rx.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_rx.CustomButton.Name = "";
            this.mobnpc_rx.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_rx.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_rx.CustomButton.TabIndex = 1;
            this.mobnpc_rx.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_rx.CustomButton.UseSelectable = true;
            this.mobnpc_rx.CustomButton.Visible = false;
            this.mobnpc_rx.DrawBorder = true;
            this.mobnpc_rx.DrawBorderBottomLine = false;
            this.mobnpc_rx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_rx.Lines = new string[0];
            this.mobnpc_rx.Location = new System.Drawing.Point(288, 57);
            this.mobnpc_rx.MaxLength = 32767;
            this.mobnpc_rx.Name = "mobnpc_rx";
            this.mobnpc_rx.PasswordChar = '\0';
            this.mobnpc_rx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_rx.SelectedText = "";
            this.mobnpc_rx.SelectionLength = 0;
            this.mobnpc_rx.SelectionStart = 0;
            this.mobnpc_rx.ShortcutsEnabled = true;
            this.mobnpc_rx.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_rx.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_rx.TabIndex = 19;
            this.mobnpc_rx.TextWaterMark = "";
            this.mobnpc_rx.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_rx.UseCustomFont = true;
            this.mobnpc_rx.UseSelectable = true;
            this.mobnpc_rx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_rx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_rx.TextChanged += new System.EventHandler(this.mobnpc_rx_TextChanged);
            // 
            // mobnpc_z
            // 
            this.mobnpc_z.BorderBottomLineSize = 5;
            this.mobnpc_z.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_z.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_z.CustomButton.Image = null;
            this.mobnpc_z.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_z.CustomButton.Name = "";
            this.mobnpc_z.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_z.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_z.CustomButton.TabIndex = 1;
            this.mobnpc_z.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_z.CustomButton.UseSelectable = true;
            this.mobnpc_z.CustomButton.Visible = false;
            this.mobnpc_z.DrawBorder = true;
            this.mobnpc_z.DrawBorderBottomLine = false;
            this.mobnpc_z.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_z.Lines = new string[0];
            this.mobnpc_z.Location = new System.Drawing.Point(48, 123);
            this.mobnpc_z.MaxLength = 32767;
            this.mobnpc_z.Name = "mobnpc_z";
            this.mobnpc_z.PasswordChar = '\0';
            this.mobnpc_z.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_z.SelectedText = "";
            this.mobnpc_z.SelectionLength = 0;
            this.mobnpc_z.SelectionStart = 0;
            this.mobnpc_z.ShortcutsEnabled = true;
            this.mobnpc_z.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_z.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_z.TabIndex = 9;
            this.mobnpc_z.TextWaterMark = "";
            this.mobnpc_z.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_z.UseCustomFont = true;
            this.mobnpc_z.UseSelectable = true;
            this.mobnpc_z.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_z.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_z.TextChanged += new System.EventHandler(this.mobnpc_z_TextChanged);
            // 
            // mobnpc_positiontype
            // 
            this.mobnpc_positiontype.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.mobnpc_positiontype.FontSize = JHUI.JComboBoxSize.Small;
            this.mobnpc_positiontype.FormattingEnabled = true;
            this.mobnpc_positiontype.ItemHeight = 19;
            this.mobnpc_positiontype.Items.AddRange(new object[] {
            "Ground",
            "Fly"});
            this.mobnpc_positiontype.Location = new System.Drawing.Point(288, 19);
            this.mobnpc_positiontype.Name = "mobnpc_positiontype";
            this.mobnpc_positiontype.Size = new System.Drawing.Size(100, 25);
            this.mobnpc_positiontype.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_positiontype.TabIndex = 17;
            this.mobnpc_positiontype.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_positiontype.UseSelectable = true;
            this.mobnpc_positiontype.SelectedIndexChanged += new System.EventHandler(this.mobnpc_positiontype_SelectedIndexChanged);
            // 
            // mobnpc_rz
            // 
            this.mobnpc_rz.BorderBottomLineSize = 5;
            this.mobnpc_rz.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_rz.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_rz.CustomButton.Image = null;
            this.mobnpc_rz.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_rz.CustomButton.Name = "";
            this.mobnpc_rz.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_rz.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_rz.CustomButton.TabIndex = 1;
            this.mobnpc_rz.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_rz.CustomButton.UseSelectable = true;
            this.mobnpc_rz.CustomButton.Visible = false;
            this.mobnpc_rz.DrawBorder = true;
            this.mobnpc_rz.DrawBorderBottomLine = false;
            this.mobnpc_rz.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_rz.Lines = new string[0];
            this.mobnpc_rz.Location = new System.Drawing.Point(288, 122);
            this.mobnpc_rz.MaxLength = 32767;
            this.mobnpc_rz.Name = "mobnpc_rz";
            this.mobnpc_rz.PasswordChar = '\0';
            this.mobnpc_rz.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_rz.SelectedText = "";
            this.mobnpc_rz.SelectionLength = 0;
            this.mobnpc_rz.SelectionStart = 0;
            this.mobnpc_rz.ShortcutsEnabled = true;
            this.mobnpc_rz.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_rz.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_rz.TabIndex = 13;
            this.mobnpc_rz.TextWaterMark = "";
            this.mobnpc_rz.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_rz.UseCustomFont = true;
            this.mobnpc_rz.UseSelectable = true;
            this.mobnpc_rz.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_rz.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_rz.TextChanged += new System.EventHandler(this.mobnpc_rz_TextChanged);
            // 
            // mobnpc_az
            // 
            this.mobnpc_az.BorderBottomLineSize = 5;
            this.mobnpc_az.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_az.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_az.CustomButton.Image = null;
            this.mobnpc_az.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_az.CustomButton.Name = "";
            this.mobnpc_az.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_az.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_az.CustomButton.TabIndex = 1;
            this.mobnpc_az.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_az.CustomButton.UseSelectable = true;
            this.mobnpc_az.CustomButton.Visible = false;
            this.mobnpc_az.DrawBorder = true;
            this.mobnpc_az.DrawBorderBottomLine = false;
            this.mobnpc_az.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_az.Lines = new string[0];
            this.mobnpc_az.Location = new System.Drawing.Point(533, 122);
            this.mobnpc_az.MaxLength = 32767;
            this.mobnpc_az.Name = "mobnpc_az";
            this.mobnpc_az.PasswordChar = '\0';
            this.mobnpc_az.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_az.SelectedText = "";
            this.mobnpc_az.SelectionLength = 0;
            this.mobnpc_az.SelectionStart = 0;
            this.mobnpc_az.ShortcutsEnabled = true;
            this.mobnpc_az.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_az.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_az.TabIndex = 13;
            this.mobnpc_az.TextWaterMark = "";
            this.mobnpc_az.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_az.UseCustomFont = true;
            this.mobnpc_az.UseSelectable = true;
            this.mobnpc_az.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_az.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_az.TextChanged += new System.EventHandler(this.mobnpc_az_TextChanged);
            // 
            // mobnpc_ry
            // 
            this.mobnpc_ry.BorderBottomLineSize = 5;
            this.mobnpc_ry.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_ry.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_ry.CustomButton.Image = null;
            this.mobnpc_ry.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_ry.CustomButton.Name = "";
            this.mobnpc_ry.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_ry.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_ry.CustomButton.TabIndex = 1;
            this.mobnpc_ry.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_ry.CustomButton.UseSelectable = true;
            this.mobnpc_ry.CustomButton.Visible = false;
            this.mobnpc_ry.DrawBorder = true;
            this.mobnpc_ry.DrawBorderBottomLine = false;
            this.mobnpc_ry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_ry.Lines = new string[0];
            this.mobnpc_ry.Location = new System.Drawing.Point(288, 92);
            this.mobnpc_ry.MaxLength = 32767;
            this.mobnpc_ry.Name = "mobnpc_ry";
            this.mobnpc_ry.PasswordChar = '\0';
            this.mobnpc_ry.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_ry.SelectedText = "";
            this.mobnpc_ry.SelectionLength = 0;
            this.mobnpc_ry.SelectionStart = 0;
            this.mobnpc_ry.ShortcutsEnabled = true;
            this.mobnpc_ry.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_ry.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_ry.TabIndex = 14;
            this.mobnpc_ry.TextWaterMark = "";
            this.mobnpc_ry.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_ry.UseCustomFont = true;
            this.mobnpc_ry.UseSelectable = true;
            this.mobnpc_ry.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_ry.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_ry.TextChanged += new System.EventHandler(this.mobnpc_ry_TextChanged);
            // 
            // mobnpc_x
            // 
            this.mobnpc_x.BorderBottomLineSize = 5;
            this.mobnpc_x.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_x.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_x.CustomButton.Image = null;
            this.mobnpc_x.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_x.CustomButton.Name = "";
            this.mobnpc_x.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_x.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_x.CustomButton.TabIndex = 1;
            this.mobnpc_x.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_x.CustomButton.UseSelectable = true;
            this.mobnpc_x.CustomButton.Visible = false;
            this.mobnpc_x.DrawBorder = true;
            this.mobnpc_x.DrawBorderBottomLine = false;
            this.mobnpc_x.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_x.Lines = new string[0];
            this.mobnpc_x.Location = new System.Drawing.Point(48, 58);
            this.mobnpc_x.MaxLength = 32767;
            this.mobnpc_x.Name = "mobnpc_x";
            this.mobnpc_x.PasswordChar = '\0';
            this.mobnpc_x.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_x.SelectedText = "";
            this.mobnpc_x.SelectionLength = 0;
            this.mobnpc_x.SelectionStart = 0;
            this.mobnpc_x.ShortcutsEnabled = true;
            this.mobnpc_x.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_x.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_x.TabIndex = 9;
            this.mobnpc_x.TextWaterMark = "";
            this.mobnpc_x.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_x.UseCustomFont = true;
            this.mobnpc_x.UseSelectable = true;
            this.mobnpc_x.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_x.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_x.TextChanged += new System.EventHandler(this.mobnpc_x_TextChanged);
            // 
            // mobnpc_ay
            // 
            this.mobnpc_ay.BorderBottomLineSize = 5;
            this.mobnpc_ay.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_ay.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_ay.CustomButton.Image = null;
            this.mobnpc_ay.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_ay.CustomButton.Name = "";
            this.mobnpc_ay.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_ay.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_ay.CustomButton.TabIndex = 1;
            this.mobnpc_ay.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_ay.CustomButton.UseSelectable = true;
            this.mobnpc_ay.CustomButton.Visible = false;
            this.mobnpc_ay.DrawBorder = true;
            this.mobnpc_ay.DrawBorderBottomLine = false;
            this.mobnpc_ay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_ay.Lines = new string[0];
            this.mobnpc_ay.Location = new System.Drawing.Point(533, 92);
            this.mobnpc_ay.MaxLength = 32767;
            this.mobnpc_ay.Name = "mobnpc_ay";
            this.mobnpc_ay.PasswordChar = '\0';
            this.mobnpc_ay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_ay.SelectedText = "";
            this.mobnpc_ay.SelectionLength = 0;
            this.mobnpc_ay.SelectionStart = 0;
            this.mobnpc_ay.ShortcutsEnabled = true;
            this.mobnpc_ay.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_ay.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_ay.TabIndex = 14;
            this.mobnpc_ay.TextWaterMark = "";
            this.mobnpc_ay.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_ay.UseCustomFont = true;
            this.mobnpc_ay.UseSelectable = true;
            this.mobnpc_ay.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_ay.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_ay.TextChanged += new System.EventHandler(this.mobnpc_ay_TextChanged);
            // 
            // mobnpc_y
            // 
            this.mobnpc_y.BorderBottomLineSize = 5;
            this.mobnpc_y.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_y.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_y.CustomButton.Image = null;
            this.mobnpc_y.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_y.CustomButton.Name = "";
            this.mobnpc_y.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_y.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_y.CustomButton.TabIndex = 1;
            this.mobnpc_y.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_y.CustomButton.UseSelectable = true;
            this.mobnpc_y.CustomButton.Visible = false;
            this.mobnpc_y.DrawBorder = true;
            this.mobnpc_y.DrawBorderBottomLine = false;
            this.mobnpc_y.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_y.Lines = new string[0];
            this.mobnpc_y.Location = new System.Drawing.Point(48, 93);
            this.mobnpc_y.MaxLength = 32767;
            this.mobnpc_y.Name = "mobnpc_y";
            this.mobnpc_y.PasswordChar = '\0';
            this.mobnpc_y.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_y.SelectedText = "";
            this.mobnpc_y.SelectionLength = 0;
            this.mobnpc_y.SelectionStart = 0;
            this.mobnpc_y.ShortcutsEnabled = true;
            this.mobnpc_y.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_y.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_y.TabIndex = 9;
            this.mobnpc_y.TextWaterMark = "";
            this.mobnpc_y.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_y.UseCustomFont = true;
            this.mobnpc_y.UseSelectable = true;
            this.mobnpc_y.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_y.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_y.TextChanged += new System.EventHandler(this.mobnpc_y_TextChanged);
            // 
            // mobnpc_ax
            // 
            this.mobnpc_ax.BorderBottomLineSize = 5;
            this.mobnpc_ax.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_ax.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_ax.CustomButton.Image = null;
            this.mobnpc_ax.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.mobnpc_ax.CustomButton.Name = "";
            this.mobnpc_ax.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_ax.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_ax.CustomButton.TabIndex = 1;
            this.mobnpc_ax.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_ax.CustomButton.UseSelectable = true;
            this.mobnpc_ax.CustomButton.Visible = false;
            this.mobnpc_ax.DrawBorder = true;
            this.mobnpc_ax.DrawBorderBottomLine = false;
            this.mobnpc_ax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_ax.Lines = new string[0];
            this.mobnpc_ax.Location = new System.Drawing.Point(533, 57);
            this.mobnpc_ax.MaxLength = 32767;
            this.mobnpc_ax.Name = "mobnpc_ax";
            this.mobnpc_ax.PasswordChar = '\0';
            this.mobnpc_ax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_ax.SelectedText = "";
            this.mobnpc_ax.SelectionLength = 0;
            this.mobnpc_ax.SelectionStart = 0;
            this.mobnpc_ax.ShortcutsEnabled = true;
            this.mobnpc_ax.Size = new System.Drawing.Size(100, 20);
            this.mobnpc_ax.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_ax.TabIndex = 15;
            this.mobnpc_ax.TextWaterMark = "";
            this.mobnpc_ax.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_ax.UseCustomFont = true;
            this.mobnpc_ax.UseSelectable = true;
            this.mobnpc_ax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_ax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_ax.TextChanged += new System.EventHandler(this.mobnpc_ax_TextChanged);
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.DropShadowColor = System.Drawing.Color.Black;
            this.labelZ.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.labelZ.FontSize = JHUI.JLabelSize.Small;
            this.labelZ.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelZ.Location = new System.Drawing.Point(154, 129);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(13, 15);
            this.labelZ.Style = JHUI.JColorStyle.Gold;
            this.labelZ.TabIndex = 22;
            this.labelZ.Text = "0";
            this.labelZ.Theme = JHUI.JThemeStyle.Dark;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.DropShadowColor = System.Drawing.Color.Black;
            this.labelY.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.labelY.FontSize = JHUI.JLabelSize.Small;
            this.labelY.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelY.Location = new System.Drawing.Point(154, 95);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(13, 15);
            this.labelY.Style = JHUI.JColorStyle.Gold;
            this.labelY.TabIndex = 21;
            this.labelY.Text = "0";
            this.labelY.Theme = JHUI.JThemeStyle.Dark;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.DropShadowColor = System.Drawing.Color.Black;
            this.labelX.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.labelX.FontSize = JHUI.JLabelSize.Small;
            this.labelX.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelX.Location = new System.Drawing.Point(153, 61);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 15);
            this.labelX.Style = JHUI.JColorStyle.Gold;
            this.labelX.TabIndex = 20;
            this.labelX.Text = "0";
            this.labelX.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.DropShadowColor = System.Drawing.Color.Black;
            this.label15.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label15.FontSize = JHUI.JLabelSize.Small;
            this.label15.Location = new System.Drawing.Point(230, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 15);
            this.label15.Style = JHUI.JColorStyle.Gold;
            this.label15.TabIndex = 18;
            this.label15.Text = "Rotate X:";
            this.label15.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DropShadowColor = System.Drawing.Color.Black;
            this.label3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label3.FontSize = JHUI.JLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(246, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.Style = JHUI.JColorStyle.Gold;
            this.label3.TabIndex = 5;
            this.label3.Text = "State:";
            this.label3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DropShadowColor = System.Drawing.Color.Black;
            this.label4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label4.FontSize = JHUI.JLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(25, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.Style = JHUI.JColorStyle.Gold;
            this.label4.TabIndex = 6;
            this.label4.Text = "X:";
            this.label4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DropShadowColor = System.Drawing.Color.Black;
            this.label5.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label5.FontSize = JHUI.JLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(25, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 15);
            this.label5.Style = JHUI.JColorStyle.Gold;
            this.label5.TabIndex = 7;
            this.label5.Text = "Y:";
            this.label5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DropShadowColor = System.Drawing.Color.Black;
            this.label6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label6.FontSize = JHUI.JLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(25, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.Style = JHUI.JColorStyle.Gold;
            this.label6.TabIndex = 8;
            this.label6.Text = "Z:";
            this.label6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.DropShadowColor = System.Drawing.Color.Black;
            this.label7.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label7.FontSize = JHUI.JLabelSize.Small;
            this.label7.Location = new System.Drawing.Point(230, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.Style = JHUI.JColorStyle.Gold;
            this.label7.TabIndex = 12;
            this.label7.Text = "Rotate Z:";
            this.label7.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DropShadowColor = System.Drawing.Color.Black;
            this.label8.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label8.FontSize = JHUI.JLabelSize.Small;
            this.label8.Location = new System.Drawing.Point(230, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.Style = JHUI.JColorStyle.Gold;
            this.label8.TabIndex = 11;
            this.label8.Text = "Rotate Y:";
            this.label8.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DropShadowColor = System.Drawing.Color.Black;
            this.label10.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label10.FontSize = JHUI.JLabelSize.Small;
            this.label10.Location = new System.Drawing.Point(467, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.Style = JHUI.JColorStyle.Gold;
            this.label10.TabIndex = 10;
            this.label10.Text = "Random X:";
            this.label10.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.DropShadowColor = System.Drawing.Color.Black;
            this.label11.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label11.FontSize = JHUI.JLabelSize.Small;
            this.label11.Location = new System.Drawing.Point(467, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.Style = JHUI.JColorStyle.Gold;
            this.label11.TabIndex = 11;
            this.label11.Text = "Random Y:";
            this.label11.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.DropShadowColor = System.Drawing.Color.Black;
            this.label12.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label12.FontSize = JHUI.JLabelSize.Small;
            this.label12.Location = new System.Drawing.Point(467, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.Style = JHUI.JColorStyle.Gold;
            this.label12.TabIndex = 12;
            this.label12.Text = "Random Z:";
            this.label12.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox1.Controls.Add(this.mobnpc_name);
            this.groupBox1.Controls.Add(this.mobnpc_type);
            this.groupBox1.Controls.Add(this.mobnpc_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.DrawBottomLine = false;
            this.groupBox1.DrawShadows = false;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.FontSize = JHUI.JLabelSize.Small;
            this.groupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(262, 7);
            this.groupBox1.MinimumSize = new System.Drawing.Size(200, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.PaintDefault = false;
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.Style = JHUI.JColorStyle.Gold;
            this.groupBox1.StyleManager = null;
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            this.groupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox1.UseStyleColors = false;
            // 
            // mobnpc_name
            // 
            this.mobnpc_name.BorderBottomLineSize = 5;
            this.mobnpc_name.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_name.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_name.CustomButton.Image = null;
            this.mobnpc_name.CustomButton.Location = new System.Drawing.Point(118, 2);
            this.mobnpc_name.CustomButton.Name = "";
            this.mobnpc_name.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_name.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_name.CustomButton.TabIndex = 1;
            this.mobnpc_name.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_name.CustomButton.UseSelectable = true;
            this.mobnpc_name.CustomButton.Visible = false;
            this.mobnpc_name.DrawBorder = true;
            this.mobnpc_name.DrawBorderBottomLine = false;
            this.mobnpc_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_name.Lines = new string[0];
            this.mobnpc_name.Location = new System.Drawing.Point(58, 45);
            this.mobnpc_name.MaxLength = 32767;
            this.mobnpc_name.Name = "mobnpc_name";
            this.mobnpc_name.PasswordChar = '\0';
            this.mobnpc_name.ReadOnly = true;
            this.mobnpc_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_name.SelectedText = "";
            this.mobnpc_name.SelectionLength = 0;
            this.mobnpc_name.SelectionStart = 0;
            this.mobnpc_name.ShortcutsEnabled = true;
            this.mobnpc_name.Size = new System.Drawing.Size(136, 20);
            this.mobnpc_name.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_name.TabIndex = 4;
            this.mobnpc_name.TextWaterMark = "";
            this.mobnpc_name.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_name.UseCustomFont = true;
            this.mobnpc_name.UseSelectable = true;
            this.mobnpc_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobnpc_type
            // 
            this.mobnpc_type.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.mobnpc_type.FontSize = JHUI.JComboBoxSize.Small;
            this.mobnpc_type.FormattingEnabled = true;
            this.mobnpc_type.ItemHeight = 19;
            this.mobnpc_type.Items.AddRange(new object[] {
            "Monster",
            "NPC"});
            this.mobnpc_type.Location = new System.Drawing.Point(58, 71);
            this.mobnpc_type.Name = "mobnpc_type";
            this.mobnpc_type.Size = new System.Drawing.Size(136, 25);
            this.mobnpc_type.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_type.TabIndex = 17;
            this.mobnpc_type.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_type.UseSelectable = true;
            this.mobnpc_type.SelectedIndexChanged += new System.EventHandler(this.mobnpc_type_SelectedIndexChanged);
            // 
            // mobnpc_id
            // 
            this.mobnpc_id.BorderBottomLineSize = 5;
            this.mobnpc_id.BorderColor = System.Drawing.Color.Black;
            this.mobnpc_id.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.mobnpc_id.CustomButton.Image = null;
            this.mobnpc_id.CustomButton.Location = new System.Drawing.Point(118, 2);
            this.mobnpc_id.CustomButton.Name = "";
            this.mobnpc_id.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.mobnpc_id.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.mobnpc_id.CustomButton.TabIndex = 1;
            this.mobnpc_id.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.mobnpc_id.CustomButton.UseSelectable = true;
            this.mobnpc_id.CustomButton.Visible = false;
            this.mobnpc_id.DrawBorder = true;
            this.mobnpc_id.DrawBorderBottomLine = false;
            this.mobnpc_id.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mobnpc_id.Lines = new string[0];
            this.mobnpc_id.Location = new System.Drawing.Point(58, 19);
            this.mobnpc_id.MaxLength = 32767;
            this.mobnpc_id.Name = "mobnpc_id";
            this.mobnpc_id.PasswordChar = '\0';
            this.mobnpc_id.ReadOnly = true;
            this.mobnpc_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mobnpc_id.SelectedText = "";
            this.mobnpc_id.SelectionLength = 0;
            this.mobnpc_id.SelectionStart = 0;
            this.mobnpc_id.ShortcutsEnabled = true;
            this.mobnpc_id.Size = new System.Drawing.Size(136, 20);
            this.mobnpc_id.Style = JHUI.JColorStyle.Orange;
            this.mobnpc_id.TabIndex = 2;
            this.mobnpc_id.TextWaterMark = "";
            this.mobnpc_id.Theme = JHUI.JThemeStyle.Dark;
            this.mobnpc_id.UseCustomFont = true;
            this.mobnpc_id.UseSelectable = true;
            this.mobnpc_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mobnpc_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.Style = JHUI.JColorStyle.Gold;
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DropShadowColor = System.Drawing.Color.Black;
            this.label2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.Style = JHUI.JColorStyle.Gold;
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.DropShadowColor = System.Drawing.Color.Black;
            this.label13.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label13.FontSize = JHUI.JLabelSize.Small;
            this.label13.Location = new System.Drawing.Point(18, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 15);
            this.label13.Style = JHUI.JColorStyle.Gold;
            this.label13.TabIndex = 5;
            this.label13.Text = "Type:";
            this.label13.Theme = JHUI.JThemeStyle.Dark;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.dataGridView_resourceGroups);
            this.tabPage2.Controls.Add(this.dataGridView_resources);
            this.tabPage2.HorizontalScrollbarBarColor = true;
            this.tabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage2.HorizontalScrollbarSize = 10;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(941, 532);
            this.tabPage2.Style = JHUI.JColorStyle.Gold;
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resorces";
            this.tabPage2.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage2.VerticalScrollbarBarColor = true;
            this.tabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage2.VerticalScrollbarSize = 10;
            // 
            // dataGridView_resourceGroups
            // 
            this.dataGridView_resourceGroups.AllowUserToAddRows = false;
            this.dataGridView_resourceGroups.AllowUserToDeleteRows = false;
            this.dataGridView_resourceGroups.AllowUserToResizeRows = false;
            this.dataGridView_resourceGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_resourceGroups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_resourceGroups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_resourceGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_resourceGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_resourceGroups.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView_resourceGroups.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_resourceGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_resourceGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resourceGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn15});
            this.dataGridView_resourceGroups.ContextMenuStrip = this.RES_STRIP_MENU_GROUPE;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_resourceGroups.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_resourceGroups.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_resourceGroups.EnableHeadersVisualStyles = false;
            this.dataGridView_resourceGroups.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_resourceGroups.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_resourceGroups.Location = new System.Drawing.Point(3, 338);
            this.dataGridView_resourceGroups.Name = "dataGridView_resourceGroups";
            this.dataGridView_resourceGroups.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_resourceGroups.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_resourceGroups.RowHeadersWidth = 150;
            this.dataGridView_resourceGroups.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_resourceGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_resourceGroups.Size = new System.Drawing.Size(935, 191);
            this.dataGridView_resourceGroups.Style = JHUI.JColorStyle.Orange;
            this.dataGridView_resourceGroups.TabIndex = 2;
            this.dataGridView_resourceGroups.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_resourceGroups.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resourceGroups_CellValueChanged);
            this.dataGridView_resourceGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_resourceGroups_KeyDown);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Type";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 22;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "Respawn";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 58;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn10.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 52;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn15.HeaderText = "?";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn15.Width = 16;
            // 
            // RES_STRIP_MENU_GROUPE
            // 
            this.RES_STRIP_MENU_GROUPE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem,
            this.toolStripSeparator5,
            this.addToolStripMenuItem2,
            this.deleteToolStripMenuItem2});
            this.RES_STRIP_MENU_GROUPE.Name = "RES_STRIP_MENU_GROUPE";
            this.RES_STRIP_MENU_GROUPE.Size = new System.Drawing.Size(170, 76);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View;
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.goToToolStripMenuItem.Text = "Select In Elements";
            this.goToToolStripMenuItem.Click += new System.EventHandler(this.button7_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(166, 6);
            // 
            // addToolStripMenuItem2
            // 
            this.addToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            this.addToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.addToolStripMenuItem2.Text = "Add";
            this.addToolStripMenuItem2.Click += new System.EventHandler(this.addToolStripMenuItem2_Click);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
            // 
            // dataGridView_resources
            // 
            this.dataGridView_resources.AllowUserToAddRows = false;
            this.dataGridView_resources.AllowUserToDeleteRows = false;
            this.dataGridView_resources.AllowUserToResizeRows = false;
            this.dataGridView_resources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_resources.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_resources.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_resources.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_resources.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_resources.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView_resources.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_resources.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_resources.ColumnHeadersHeight = 22;
            this.dataGridView_resources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_resources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23});
            this.dataGridView_resources.ContextMenuStrip = this.RES_STRIP_MENU;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_resources.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_resources.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_resources.EnableHeadersVisualStyles = false;
            this.dataGridView_resources.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_resources.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_resources.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_resources.Name = "dataGridView_resources";
            this.dataGridView_resources.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_resources.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_resources.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_resources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_resources.Size = new System.Drawing.Size(935, 329);
            this.dataGridView_resources.Style = JHUI.JColorStyle.Orange;
            this.dataGridView_resources.TabIndex = 1;
            this.dataGridView_resources.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_resources.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resources_CellClick);
            this.dataGridView_resources.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resources_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Count";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "X";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Y";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Z";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Random X";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 63;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Random Z";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 63;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.HeaderText = "?";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.Width = 16;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn2.HeaderText = "?";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.Width = 16;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn3.HeaderText = "?";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn3.Width = 16;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn11.HeaderText = "?";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 16;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn12.HeaderText = "?";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 16;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn13.HeaderText = "?";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Width = 16;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn14.HeaderText = "?";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn14.Width = 16;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Triger Link";
            this.Column19.Name = "Column19";
            // 
            // Column20
            // 
            this.Column20.HeaderText = "?";
            this.Column20.Name = "Column20";
            // 
            // Column21
            // 
            this.Column21.HeaderText = "?";
            this.Column21.Name = "Column21";
            // 
            // Column22
            // 
            this.Column22.HeaderText = "?";
            this.Column22.Name = "Column22";
            // 
            // Column23
            // 
            this.Column23.HeaderText = "?";
            this.Column23.Name = "Column23";
            // 
            // RES_STRIP_MENU
            // 
            this.RES_STRIP_MENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillCoordinatesFromGameToolStripMenuItem,
            this.toolStripSeparator6,
            this.addToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator2,
            this.exportSelectedToolStripMenuItem1,
            this.importSelectedToolStripMenuItem1});
            this.RES_STRIP_MENU.Name = "RES_STRIP_MENU";
            this.RES_STRIP_MENU.Size = new System.Drawing.Size(222, 126);
            // 
            // fillCoordinatesFromGameToolStripMenuItem
            // 
            this.fillCoordinatesFromGameToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.fillCoordinatesFromGameToolStripMenuItem.Name = "fillCoordinatesFromGameToolStripMenuItem";
            this.fillCoordinatesFromGameToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.fillCoordinatesFromGameToolStripMenuItem.Text = "Fill Coordinates From Game";
            this.fillCoordinatesFromGameToolStripMenuItem.Click += new System.EventHandler(this.button5_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // exportSelectedToolStripMenuItem1
            // 
            this.exportSelectedToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.exportSelectedToolStripMenuItem1.Name = "exportSelectedToolStripMenuItem1";
            this.exportSelectedToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.exportSelectedToolStripMenuItem1.Text = "Export";
            this.exportSelectedToolStripMenuItem1.Click += new System.EventHandler(this.exportSelectedToolStripMenuItem1_Click);
            // 
            // importSelectedToolStripMenuItem1
            // 
            this.importSelectedToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.document_import;
            this.importSelectedToolStripMenuItem1.Name = "importSelectedToolStripMenuItem1";
            this.importSelectedToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.importSelectedToolStripMenuItem1.Text = "Import";
            this.importSelectedToolStripMenuItem1.Click += new System.EventHandler(this.importSelectedToolStripMenuItem1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.AutoScrollMinSize = new System.Drawing.Size(941, 532);
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.Dyntext_items);
            this.tabPage3.HorizontalScrollbar = true;
            this.tabPage3.HorizontalScrollbarBarColor = true;
            this.tabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage3.HorizontalScrollbarSize = 10;
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(941, 532);
            this.tabPage3.Style = JHUI.JColorStyle.Gold;
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dynamics";
            this.tabPage3.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage3.VerticalScrollbar = true;
            this.tabPage3.VerticalScrollbarBarColor = true;
            this.tabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage3.VerticalScrollbarSize = 10;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox8.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox8.Controls.Add(this.Dyntext_image);
            this.groupBox8.DrawBottomLine = false;
            this.groupBox8.DrawShadows = false;
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox8.FontSize = JHUI.JLabelSize.Small;
            this.groupBox8.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox8.Location = new System.Drawing.Point(261, 208);
            this.groupBox8.MinimumSize = new System.Drawing.Size(652, 301);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.PaintDefault = false;
            this.groupBox8.Size = new System.Drawing.Size(680, 307);
            this.groupBox8.Style = JHUI.JColorStyle.Blue;
            this.groupBox8.StyleManager = null;
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Image";
            this.groupBox8.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox8.UseStyleColors = false;
            // 
            // Dyntext_image
            // 
            this.Dyntext_image.BackColor = System.Drawing.Color.Transparent;
            this.Dyntext_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dyntext_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dyntext_image.Location = new System.Drawing.Point(3, 19);
            this.Dyntext_image.MinimumSize = new System.Drawing.Size(400, 260);
            this.Dyntext_image.Name = "Dyntext_image";
            this.Dyntext_image.Size = new System.Drawing.Size(674, 285);
            this.Dyntext_image.Style = JHUI.JColorStyle.Gold;
            this.Dyntext_image.TabIndex = 24;
            this.Dyntext_image.TabStop = false;
            this.Dyntext_image.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox7.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox7.Controls.Add(this.Dyntext_trig);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.DrawBottomLine = false;
            this.groupBox7.DrawShadows = false;
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox7.FontSize = JHUI.JLabelSize.Small;
            this.groupBox7.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox7.Location = new System.Drawing.Point(468, 7);
            this.groupBox7.MinimumSize = new System.Drawing.Size(467, 86);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.PaintDefault = false;
            this.groupBox7.Size = new System.Drawing.Size(473, 86);
            this.groupBox7.Style = JHUI.JColorStyle.Blue;
            this.groupBox7.StyleManager = null;
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Misc";
            this.groupBox7.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox7.UseStyleColors = false;
            // 
            // Dyntext_trig
            // 
            this.Dyntext_trig.BorderBottomLineSize = 5;
            this.Dyntext_trig.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_trig.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_trig.CustomButton.Image = null;
            this.Dyntext_trig.CustomButton.Location = new System.Drawing.Point(100, 2);
            this.Dyntext_trig.CustomButton.Name = "";
            this.Dyntext_trig.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_trig.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_trig.CustomButton.TabIndex = 1;
            this.Dyntext_trig.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_trig.CustomButton.UseSelectable = true;
            this.Dyntext_trig.CustomButton.Visible = false;
            this.Dyntext_trig.DrawBorder = true;
            this.Dyntext_trig.DrawBorderBottomLine = false;
            this.Dyntext_trig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_trig.Lines = new string[0];
            this.Dyntext_trig.Location = new System.Drawing.Point(76, 19);
            this.Dyntext_trig.MaxLength = 32767;
            this.Dyntext_trig.Name = "Dyntext_trig";
            this.Dyntext_trig.PasswordChar = '\0';
            this.Dyntext_trig.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_trig.SelectedText = "";
            this.Dyntext_trig.SelectionLength = 0;
            this.Dyntext_trig.SelectionStart = 0;
            this.Dyntext_trig.ShortcutsEnabled = true;
            this.Dyntext_trig.Size = new System.Drawing.Size(118, 20);
            this.Dyntext_trig.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_trig.TabIndex = 15;
            this.Dyntext_trig.TextWaterMark = "";
            this.Dyntext_trig.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_trig.UseCustomFont = true;
            this.Dyntext_trig.UseSelectable = true;
            this.Dyntext_trig.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_trig.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_trig.TextChanged += new System.EventHandler(this.Dyntext_trig_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.DropShadowColor = System.Drawing.Color.Black;
            this.label26.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label26.FontSize = JHUI.JLabelSize.Small;
            this.label26.Location = new System.Drawing.Point(10, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 15);
            this.label26.Style = JHUI.JColorStyle.Gold;
            this.label26.TabIndex = 10;
            this.label26.Text = "Triger ID:";
            this.label26.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox6.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox6.Controls.Add(this.Dyntext_name);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.Dyntext_id);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.DrawBottomLine = false;
            this.groupBox6.DrawShadows = false;
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox6.FontSize = JHUI.JLabelSize.Small;
            this.groupBox6.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox6.Location = new System.Drawing.Point(262, 7);
            this.groupBox6.MinimumSize = new System.Drawing.Size(200, 86);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.PaintDefault = false;
            this.groupBox6.Size = new System.Drawing.Size(200, 86);
            this.groupBox6.Style = JHUI.JColorStyle.Gold;
            this.groupBox6.StyleManager = null;
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "General";
            this.groupBox6.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox6.UseStyleColors = false;
            // 
            // Dyntext_name
            // 
            this.Dyntext_name.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.Dyntext_name.FontSize = JHUI.JComboBoxSize.Small;
            this.Dyntext_name.FormattingEnabled = true;
            this.Dyntext_name.ItemHeight = 19;
            this.Dyntext_name.Location = new System.Drawing.Point(51, 47);
            this.Dyntext_name.Name = "Dyntext_name";
            this.Dyntext_name.Size = new System.Drawing.Size(138, 25);
            this.Dyntext_name.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_name.TabIndex = 22;
            this.Dyntext_name.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_name.UseSelectable = true;
            this.Dyntext_name.SelectedIndexChanged += new System.EventHandler(this.Dyntext_name_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.DropShadowColor = System.Drawing.Color.Black;
            this.label28.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label28.FontSize = JHUI.JLabelSize.Small;
            this.label28.Location = new System.Drawing.Point(10, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 15);
            this.label28.Style = JHUI.JColorStyle.Gold;
            this.label28.TabIndex = 20;
            this.label28.Text = "Name:";
            this.label28.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Dyntext_id
            // 
            this.Dyntext_id.BorderBottomLineSize = 5;
            this.Dyntext_id.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_id.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_id.CustomButton.Image = null;
            this.Dyntext_id.CustomButton.Location = new System.Drawing.Point(120, 2);
            this.Dyntext_id.CustomButton.Name = "";
            this.Dyntext_id.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_id.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_id.CustomButton.TabIndex = 1;
            this.Dyntext_id.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_id.CustomButton.UseSelectable = true;
            this.Dyntext_id.CustomButton.Visible = false;
            this.Dyntext_id.DrawBorder = true;
            this.Dyntext_id.DrawBorderBottomLine = false;
            this.Dyntext_id.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_id.Lines = new string[0];
            this.Dyntext_id.Location = new System.Drawing.Point(51, 19);
            this.Dyntext_id.MaxLength = 32767;
            this.Dyntext_id.Name = "Dyntext_id";
            this.Dyntext_id.PasswordChar = '\0';
            this.Dyntext_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_id.SelectedText = "";
            this.Dyntext_id.SelectionLength = 0;
            this.Dyntext_id.SelectionStart = 0;
            this.Dyntext_id.ShortcutsEnabled = true;
            this.Dyntext_id.Size = new System.Drawing.Size(138, 20);
            this.Dyntext_id.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_id.TabIndex = 21;
            this.Dyntext_id.TextWaterMark = "";
            this.Dyntext_id.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_id.UseCustomFont = true;
            this.Dyntext_id.UseSelectable = true;
            this.Dyntext_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_id.TextChanged += new System.EventHandler(this.Dyntext_id_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.DropShadowColor = System.Drawing.Color.Black;
            this.label20.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label20.FontSize = JHUI.JLabelSize.Small;
            this.label20.Location = new System.Drawing.Point(10, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 15);
            this.label20.Style = JHUI.JColorStyle.Gold;
            this.label20.TabIndex = 20;
            this.label20.Text = "ID:";
            this.label20.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox5.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox5.Controls.Add(this.Dyntext_z);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.Dyntext_x);
            this.groupBox5.Controls.Add(this.Dyntext_y);
            this.groupBox5.Controls.Add(this.Dyntext_scale);
            this.groupBox5.Controls.Add(this.Dyntext_dx);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.Dyntext_dy);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.Dyntext_dz);
            this.groupBox5.DrawBottomLine = false;
            this.groupBox5.DrawShadows = false;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox5.FontSize = JHUI.JLabelSize.Small;
            this.groupBox5.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox5.Location = new System.Drawing.Point(262, 99);
            this.groupBox5.MinimumSize = new System.Drawing.Size(673, 107);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.PaintDefault = false;
            this.groupBox5.Size = new System.Drawing.Size(679, 107);
            this.groupBox5.Style = JHUI.JColorStyle.Gold;
            this.groupBox5.StyleManager = null;
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Location";
            this.groupBox5.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox5.UseStyleColors = false;
            // 
            // Dyntext_z
            // 
            this.Dyntext_z.BorderBottomLineSize = 5;
            this.Dyntext_z.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_z.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_z.CustomButton.Image = null;
            this.Dyntext_z.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_z.CustomButton.Name = "";
            this.Dyntext_z.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_z.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_z.CustomButton.TabIndex = 1;
            this.Dyntext_z.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_z.CustomButton.UseSelectable = true;
            this.Dyntext_z.CustomButton.Visible = false;
            this.Dyntext_z.DrawBorder = true;
            this.Dyntext_z.DrawBorderBottomLine = false;
            this.Dyntext_z.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_z.Lines = new string[0];
            this.Dyntext_z.Location = new System.Drawing.Point(33, 67);
            this.Dyntext_z.MaxLength = 32767;
            this.Dyntext_z.Name = "Dyntext_z";
            this.Dyntext_z.PasswordChar = '\0';
            this.Dyntext_z.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_z.SelectedText = "";
            this.Dyntext_z.SelectionLength = 0;
            this.Dyntext_z.SelectionStart = 0;
            this.Dyntext_z.ShortcutsEnabled = true;
            this.Dyntext_z.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_z.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_z.TabIndex = 9;
            this.Dyntext_z.TextWaterMark = "";
            this.Dyntext_z.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_z.UseCustomFont = true;
            this.Dyntext_z.UseSelectable = true;
            this.Dyntext_z.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_z.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_z.TextChanged += new System.EventHandler(this.Dyntext_z_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.DropShadowColor = System.Drawing.Color.Black;
            this.label21.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label21.FontSize = JHUI.JLabelSize.Small;
            this.label21.Location = new System.Drawing.Point(10, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 15);
            this.label21.Style = JHUI.JColorStyle.Gold;
            this.label21.TabIndex = 6;
            this.label21.Text = "X:";
            this.label21.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.DropShadowColor = System.Drawing.Color.Black;
            this.label22.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label22.FontSize = JHUI.JLabelSize.Small;
            this.label22.Location = new System.Drawing.Point(10, 46);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 15);
            this.label22.Style = JHUI.JColorStyle.Gold;
            this.label22.TabIndex = 7;
            this.label22.Text = "Y:";
            this.label22.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.DropShadowColor = System.Drawing.Color.Black;
            this.label23.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label23.FontSize = JHUI.JLabelSize.Small;
            this.label23.Location = new System.Drawing.Point(10, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 15);
            this.label23.Style = JHUI.JColorStyle.Gold;
            this.label23.TabIndex = 8;
            this.label23.Text = "Z:";
            this.label23.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.DropShadowColor = System.Drawing.Color.Black;
            this.label19.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label19.FontSize = JHUI.JLabelSize.Small;
            this.label19.Location = new System.Drawing.Point(157, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 15);
            this.label19.Style = JHUI.JColorStyle.Gold;
            this.label19.TabIndex = 18;
            this.label19.Text = "Dir 1:";
            this.label19.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.DropShadowColor = System.Drawing.Color.Black;
            this.label27.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label27.FontSize = JHUI.JLabelSize.Small;
            this.label27.Location = new System.Drawing.Point(310, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 15);
            this.label27.Style = JHUI.JColorStyle.Gold;
            this.label27.TabIndex = 11;
            this.label27.Text = "Scale:";
            this.label27.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Dyntext_x
            // 
            this.Dyntext_x.BorderBottomLineSize = 5;
            this.Dyntext_x.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_x.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_x.CustomButton.Image = null;
            this.Dyntext_x.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_x.CustomButton.Name = "";
            this.Dyntext_x.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_x.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_x.CustomButton.TabIndex = 1;
            this.Dyntext_x.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_x.CustomButton.UseSelectable = true;
            this.Dyntext_x.CustomButton.Visible = false;
            this.Dyntext_x.DrawBorder = true;
            this.Dyntext_x.DrawBorderBottomLine = false;
            this.Dyntext_x.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_x.Lines = new string[0];
            this.Dyntext_x.Location = new System.Drawing.Point(33, 20);
            this.Dyntext_x.MaxLength = 32767;
            this.Dyntext_x.Name = "Dyntext_x";
            this.Dyntext_x.PasswordChar = '\0';
            this.Dyntext_x.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_x.SelectedText = "";
            this.Dyntext_x.SelectionLength = 0;
            this.Dyntext_x.SelectionStart = 0;
            this.Dyntext_x.ShortcutsEnabled = true;
            this.Dyntext_x.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_x.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_x.TabIndex = 9;
            this.Dyntext_x.TextWaterMark = "";
            this.Dyntext_x.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_x.UseCustomFont = true;
            this.Dyntext_x.UseSelectable = true;
            this.Dyntext_x.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_x.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_x.TextChanged += new System.EventHandler(this.Dyntext_x_TextChanged);
            // 
            // Dyntext_y
            // 
            this.Dyntext_y.BorderBottomLineSize = 5;
            this.Dyntext_y.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_y.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_y.CustomButton.Image = null;
            this.Dyntext_y.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_y.CustomButton.Name = "";
            this.Dyntext_y.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_y.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_y.CustomButton.TabIndex = 1;
            this.Dyntext_y.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_y.CustomButton.UseSelectable = true;
            this.Dyntext_y.CustomButton.Visible = false;
            this.Dyntext_y.DrawBorder = true;
            this.Dyntext_y.DrawBorderBottomLine = false;
            this.Dyntext_y.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_y.Lines = new string[0];
            this.Dyntext_y.Location = new System.Drawing.Point(33, 43);
            this.Dyntext_y.MaxLength = 32767;
            this.Dyntext_y.Name = "Dyntext_y";
            this.Dyntext_y.PasswordChar = '\0';
            this.Dyntext_y.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_y.SelectedText = "";
            this.Dyntext_y.SelectionLength = 0;
            this.Dyntext_y.SelectionStart = 0;
            this.Dyntext_y.ShortcutsEnabled = true;
            this.Dyntext_y.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_y.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_y.TabIndex = 9;
            this.Dyntext_y.TextWaterMark = "";
            this.Dyntext_y.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_y.UseCustomFont = true;
            this.Dyntext_y.UseSelectable = true;
            this.Dyntext_y.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_y.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_y.TextChanged += new System.EventHandler(this.Dyntext_y_TextChanged);
            // 
            // Dyntext_scale
            // 
            this.Dyntext_scale.BorderBottomLineSize = 5;
            this.Dyntext_scale.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_scale.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_scale.CustomButton.Image = null;
            this.Dyntext_scale.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_scale.CustomButton.Name = "";
            this.Dyntext_scale.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_scale.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_scale.CustomButton.TabIndex = 1;
            this.Dyntext_scale.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_scale.CustomButton.UseSelectable = true;
            this.Dyntext_scale.CustomButton.Visible = false;
            this.Dyntext_scale.DrawBorder = true;
            this.Dyntext_scale.DrawBorderBottomLine = false;
            this.Dyntext_scale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_scale.Lines = new string[0];
            this.Dyntext_scale.Location = new System.Drawing.Point(353, 20);
            this.Dyntext_scale.MaxLength = 32767;
            this.Dyntext_scale.Name = "Dyntext_scale";
            this.Dyntext_scale.PasswordChar = '\0';
            this.Dyntext_scale.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_scale.SelectedText = "";
            this.Dyntext_scale.SelectionLength = 0;
            this.Dyntext_scale.SelectionStart = 0;
            this.Dyntext_scale.ShortcutsEnabled = true;
            this.Dyntext_scale.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_scale.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_scale.TabIndex = 14;
            this.Dyntext_scale.TextWaterMark = "";
            this.Dyntext_scale.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_scale.UseCustomFont = true;
            this.Dyntext_scale.UseSelectable = true;
            this.Dyntext_scale.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_scale.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_scale.TextChanged += new System.EventHandler(this.Dyntext_scale_TextChanged);
            // 
            // Dyntext_dx
            // 
            this.Dyntext_dx.BorderBottomLineSize = 5;
            this.Dyntext_dx.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_dx.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_dx.CustomButton.Image = null;
            this.Dyntext_dx.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_dx.CustomButton.Name = "";
            this.Dyntext_dx.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_dx.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_dx.CustomButton.TabIndex = 1;
            this.Dyntext_dx.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_dx.CustomButton.UseSelectable = true;
            this.Dyntext_dx.CustomButton.Visible = false;
            this.Dyntext_dx.DrawBorder = true;
            this.Dyntext_dx.DrawBorderBottomLine = false;
            this.Dyntext_dx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_dx.Lines = new string[0];
            this.Dyntext_dx.Location = new System.Drawing.Point(195, 20);
            this.Dyntext_dx.MaxLength = 32767;
            this.Dyntext_dx.Name = "Dyntext_dx";
            this.Dyntext_dx.PasswordChar = '\0';
            this.Dyntext_dx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_dx.SelectedText = "";
            this.Dyntext_dx.SelectionLength = 0;
            this.Dyntext_dx.SelectionStart = 0;
            this.Dyntext_dx.ShortcutsEnabled = true;
            this.Dyntext_dx.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_dx.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_dx.TabIndex = 19;
            this.Dyntext_dx.TextWaterMark = "";
            this.Dyntext_dx.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_dx.UseCustomFont = true;
            this.Dyntext_dx.UseSelectable = true;
            this.Dyntext_dx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_dx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_dx.TextChanged += new System.EventHandler(this.Dyntext_dx_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.DropShadowColor = System.Drawing.Color.Black;
            this.label24.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label24.FontSize = JHUI.JLabelSize.Small;
            this.label24.Location = new System.Drawing.Point(157, 70);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(30, 15);
            this.label24.Style = JHUI.JColorStyle.Gold;
            this.label24.TabIndex = 12;
            this.label24.Text = "Rad:";
            this.label24.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Dyntext_dy
            // 
            this.Dyntext_dy.BorderBottomLineSize = 5;
            this.Dyntext_dy.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_dy.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_dy.CustomButton.Image = null;
            this.Dyntext_dy.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_dy.CustomButton.Name = "";
            this.Dyntext_dy.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_dy.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_dy.CustomButton.TabIndex = 1;
            this.Dyntext_dy.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_dy.CustomButton.UseSelectable = true;
            this.Dyntext_dy.CustomButton.Visible = false;
            this.Dyntext_dy.DrawBorder = true;
            this.Dyntext_dy.DrawBorderBottomLine = false;
            this.Dyntext_dy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_dy.Lines = new string[0];
            this.Dyntext_dy.Location = new System.Drawing.Point(195, 43);
            this.Dyntext_dy.MaxLength = 32767;
            this.Dyntext_dy.Name = "Dyntext_dy";
            this.Dyntext_dy.PasswordChar = '\0';
            this.Dyntext_dy.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_dy.SelectedText = "";
            this.Dyntext_dy.SelectionLength = 0;
            this.Dyntext_dy.SelectionStart = 0;
            this.Dyntext_dy.ShortcutsEnabled = true;
            this.Dyntext_dy.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_dy.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_dy.TabIndex = 14;
            this.Dyntext_dy.TextWaterMark = "";
            this.Dyntext_dy.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_dy.UseCustomFont = true;
            this.Dyntext_dy.UseSelectable = true;
            this.Dyntext_dy.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_dy.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_dy.TextChanged += new System.EventHandler(this.Dyntext_dy_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.DropShadowColor = System.Drawing.Color.Black;
            this.label25.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label25.FontSize = JHUI.JLabelSize.Small;
            this.label25.Location = new System.Drawing.Point(157, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 15);
            this.label25.Style = JHUI.JColorStyle.Gold;
            this.label25.TabIndex = 11;
            this.label25.Text = "Dir 2:";
            this.label25.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Dyntext_dz
            // 
            this.Dyntext_dz.BorderBottomLineSize = 5;
            this.Dyntext_dz.BorderColor = System.Drawing.Color.Black;
            this.Dyntext_dz.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.Dyntext_dz.CustomButton.Image = null;
            this.Dyntext_dz.CustomButton.Location = new System.Drawing.Point(82, 2);
            this.Dyntext_dz.CustomButton.Name = "";
            this.Dyntext_dz.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.Dyntext_dz.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.Dyntext_dz.CustomButton.TabIndex = 1;
            this.Dyntext_dz.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.Dyntext_dz.CustomButton.UseSelectable = true;
            this.Dyntext_dz.CustomButton.Visible = false;
            this.Dyntext_dz.DrawBorder = true;
            this.Dyntext_dz.DrawBorderBottomLine = false;
            this.Dyntext_dz.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_dz.Lines = new string[0];
            this.Dyntext_dz.Location = new System.Drawing.Point(195, 68);
            this.Dyntext_dz.MaxLength = 32767;
            this.Dyntext_dz.Name = "Dyntext_dz";
            this.Dyntext_dz.PasswordChar = '\0';
            this.Dyntext_dz.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dyntext_dz.SelectedText = "";
            this.Dyntext_dz.SelectionLength = 0;
            this.Dyntext_dz.SelectionStart = 0;
            this.Dyntext_dz.ShortcutsEnabled = true;
            this.Dyntext_dz.Size = new System.Drawing.Size(100, 20);
            this.Dyntext_dz.Style = JHUI.JColorStyle.Orange;
            this.Dyntext_dz.TabIndex = 13;
            this.Dyntext_dz.TextWaterMark = "";
            this.Dyntext_dz.Theme = JHUI.JThemeStyle.Dark;
            this.Dyntext_dz.UseCustomFont = true;
            this.Dyntext_dz.UseSelectable = true;
            this.Dyntext_dz.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Dyntext_dz.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Dyntext_dz.TextChanged += new System.EventHandler(this.Dyntext_dz_TextChanged);
            // 
            // Dyntext_items
            // 
            this.Dyntext_items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Dyntext_items.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Dyntext_items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dyntext_items.ContextMenuStrip = this.DIN_STRIP_MENU;
            this.Dyntext_items.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dyntext_items.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Dyntext_items.FormattingEnabled = true;
            this.Dyntext_items.ItemHeight = 15;
            this.Dyntext_items.Location = new System.Drawing.Point(7, 13);
            this.Dyntext_items.MinimumSize = new System.Drawing.Size(249, 495);
            this.Dyntext_items.Name = "Dyntext_items";
            this.Dyntext_items.ScrollAlwaysVisible = true;
            this.Dyntext_items.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Dyntext_items.Size = new System.Drawing.Size(249, 495);
            this.Dyntext_items.TabIndex = 3;
            this.Dyntext_items.SelectedIndexChanged += new System.EventHandler(this.Dyntext_items_SelectedIndexChanged);
            // 
            // DIN_STRIP_MENU
            // 
            this.DIN_STRIP_MENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem3,
            this.delToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripMenuItem3});
            this.DIN_STRIP_MENU.Name = "DIN_STRIP_MENU";
            this.DIN_STRIP_MENU.Size = new System.Drawing.Size(222, 120);
            // 
            // addToolStripMenuItem3
            // 
            this.addToolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem3.Name = "addToolStripMenuItem3";
            this.addToolStripMenuItem3.Size = new System.Drawing.Size(221, 22);
            this.addToolStripMenuItem3.Text = "Add";
            this.addToolStripMenuItem3.Click += new System.EventHandler(this.addToolStripMenuItem3_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.delToolStripMenuItem.Text = "Delete";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.document_import;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.Tools;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(221, 22);
            this.toolStripMenuItem3.Text = "Fill Coordinates From Game";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.dataGridView_triggers);
            this.tabPage4.HorizontalScrollbarBarColor = true;
            this.tabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage4.HorizontalScrollbarSize = 10;
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(941, 532);
            this.tabPage4.Style = JHUI.JColorStyle.Gold;
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Trigers";
            this.tabPage4.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage4.VerticalScrollbarBarColor = true;
            this.tabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage4.VerticalScrollbarSize = 10;
            // 
            // dataGridView_triggers
            // 
            this.dataGridView_triggers.AllowUserToAddRows = false;
            this.dataGridView_triggers.AllowUserToDeleteRows = false;
            this.dataGridView_triggers.AllowUserToResizeRows = false;
            this.dataGridView_triggers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_triggers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_triggers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_triggers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView_triggers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_triggers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_triggers.ColumnHeadersHeight = 24;
            this.dataGridView_triggers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_triggers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.Column24,
            this.Column42,
            this.Column26,
            this.Column27,
            this.Column25,
            this.Column28,
            this.Column29,
            this.Column43,
            this.Column31,
            this.Column32,
            this.Column33,
            this.Column34});
            this.dataGridView_triggers.ContextMenuStrip = this.TRIGER_STRIP_MENU;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_triggers.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView_triggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_triggers.EnableHeadersVisualStyles = false;
            this.dataGridView_triggers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_triggers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_triggers.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_triggers.Name = "dataGridView_triggers";
            this.dataGridView_triggers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_triggers.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView_triggers.RowHeadersWidth = 70;
            this.dataGridView_triggers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_triggers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_triggers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_triggers.Size = new System.Drawing.Size(935, 526);
            this.dataGridView_triggers.Style = JHUI.JColorStyle.Orange;
            this.dataGridView_triggers.TabIndex = 3;
            this.dataGridView_triggers.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_triggers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_triggers_CellValueChanged);
            this.dataGridView_triggers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_triggers_DataError);
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn25.HeaderText = "Triger Id";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn25.Width = 52;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn26.HeaderText = "GM Id";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn26.Width = 42;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.FillWeight = 150F;
            this.dataGridViewTextBoxColumn27.HeaderText = "Name";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn27.Width = 150;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn28.HeaderText = "On Load";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn28.Width = 55;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn29.HeaderText = "Delay Start";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn29.Width = 66;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn30.HeaderText = "Delay Stop";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn30.Width = 66;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "AutoStart";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn31.Width = 57;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn32.HeaderText = "Auto Stop";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn32.Width = 63;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn33.HeaderText = "Start Year";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn33.Width = 58;
            // 
            // Column24
            // 
            this.Column24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column24.HeaderText = "Start Month";
            this.Column24.Name = "Column24";
            this.Column24.Width = 92;
            // 
            // Column42
            // 
            this.Column42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column42.HeaderText = "Start Week Day";
            this.Column42.Items.AddRange(new object[] {
            "Any",
            "Sun",
            "Mon",
            "Tue",
            "Wed",
            "Tue",
            "Fri",
            "Sat"});
            this.Column42.Name = "Column42";
            this.Column42.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column42.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column42.Width = 108;
            // 
            // Column26
            // 
            this.Column26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column26.HeaderText = "Start Day";
            this.Column26.Name = "Column26";
            this.Column26.Width = 76;
            // 
            // Column27
            // 
            this.Column27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column27.HeaderText = "Start Hour";
            this.Column27.Name = "Column27";
            this.Column27.Width = 83;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "Start Minute";
            this.Column25.Name = "Column25";
            // 
            // Column28
            // 
            this.Column28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column28.HeaderText = "Stop Year";
            this.Column28.Name = "Column28";
            this.Column28.Width = 77;
            // 
            // Column29
            // 
            this.Column29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column29.HeaderText = "Stop Month";
            this.Column29.Name = "Column29";
            this.Column29.Width = 92;
            // 
            // Column43
            // 
            this.Column43.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column43.HeaderText = "Stop Week Day";
            this.Column43.Items.AddRange(new object[] {
            "Any",
            "Sun",
            "Mon",
            "Tue",
            "Wed",
            "Tue",
            "Fri",
            "Sat"});
            this.Column43.Name = "Column43";
            this.Column43.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column43.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column43.Width = 108;
            // 
            // Column31
            // 
            this.Column31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column31.HeaderText = "Stop Day";
            this.Column31.Name = "Column31";
            this.Column31.Width = 76;
            // 
            // Column32
            // 
            this.Column32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column32.HeaderText = "Stop Hour";
            this.Column32.Name = "Column32";
            this.Column32.Width = 83;
            // 
            // Column33
            // 
            this.Column33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column33.HeaderText = "Stop Minute";
            this.Column33.Name = "Column33";
            this.Column33.Width = 94;
            // 
            // Column34
            // 
            this.Column34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column34.HeaderText = "Duration";
            this.Column34.Name = "Column34";
            this.Column34.Width = 76;
            // 
            // TRIGER_STRIP_MENU
            // 
            this.TRIGER_STRIP_MENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem4,
            this.deleteSelectedToolStripMenuItem2,
            this.toolStripSeparator4,
            this.exportSelectedToolStripMenuItem3,
            this.importSelectedToolStripMenuItem3,
            this.toolStripSeparator9,
            this.sortIdsToolStripMenuItem});
            this.TRIGER_STRIP_MENU.Name = "TRIGER_STRIP_MENU";
            this.TRIGER_STRIP_MENU.Size = new System.Drawing.Size(111, 126);
            // 
            // addToolStripMenuItem4
            // 
            this.addToolStripMenuItem4.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addToolStripMenuItem4.Name = "addToolStripMenuItem4";
            this.addToolStripMenuItem4.Size = new System.Drawing.Size(110, 22);
            this.addToolStripMenuItem4.Text = "Add";
            this.addToolStripMenuItem4.Click += new System.EventHandler(this.addToolStripMenuItem4_Click);
            // 
            // deleteSelectedToolStripMenuItem2
            // 
            this.deleteSelectedToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteSelectedToolStripMenuItem2.Name = "deleteSelectedToolStripMenuItem2";
            this.deleteSelectedToolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.deleteSelectedToolStripMenuItem2.Text = "Delete";
            this.deleteSelectedToolStripMenuItem2.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(107, 6);
            // 
            // exportSelectedToolStripMenuItem3
            // 
            this.exportSelectedToolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.document_export;
            this.exportSelectedToolStripMenuItem3.Name = "exportSelectedToolStripMenuItem3";
            this.exportSelectedToolStripMenuItem3.Size = new System.Drawing.Size(110, 22);
            this.exportSelectedToolStripMenuItem3.Text = "Export";
            this.exportSelectedToolStripMenuItem3.Click += new System.EventHandler(this.exportSelectedToolStripMenuItem3_Click);
            // 
            // importSelectedToolStripMenuItem3
            // 
            this.importSelectedToolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.document_import;
            this.importSelectedToolStripMenuItem3.Name = "importSelectedToolStripMenuItem3";
            this.importSelectedToolStripMenuItem3.Size = new System.Drawing.Size(110, 22);
            this.importSelectedToolStripMenuItem3.Text = "Import";
            this.importSelectedToolStripMenuItem3.Click += new System.EventHandler(this.importSelectedToolStripMenuItem3_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(107, 6);
            // 
            // sortIdsToolStripMenuItem
            // 
            this.sortIdsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idAscToolStripMenuItem});
            this.sortIdsToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View;
            this.sortIdsToolStripMenuItem.Name = "sortIdsToolStripMenuItem";
            this.sortIdsToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
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
            this.aSKToolStripMenuItem.Click += new System.EventHandler(this.aSKToolStripMenuItem_Click);
            // 
            // dSKToolStripMenuItem
            // 
            this.dSKToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Snowflake;
            this.dSKToolStripMenuItem.Name = "dSKToolStripMenuItem";
            this.dSKToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.dSKToolStripMenuItem.Text = "DESC";
            this.dSKToolStripMenuItem.Click += new System.EventHandler(this.dSKToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 15);
            this.checkBox1.Style = JHUI.JColorStyle.Orange;
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Select all";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox1.UseSelectable = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 19;
            this.comboBox1.Location = new System.Drawing.Point(795, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 25);
            this.comboBox1.Style = JHUI.JColorStyle.Orange;
            this.comboBox1.TabIndex = 18;
            this.comboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox1.UseSelectable = true;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox2.ContextMenuStrip = this.Save;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(170, 29);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Orange;
            this.jPictureBox2.TabIndex = 54;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.button1_Click);
            // 
            // Save
            // 
            this.Save.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem1,
            this.convertToToolStripMenuItem});
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(133, 48);
            this.Save.Style = JHUI.JColorStyle.Orange;
            this.Save.Theme = JHUI.JThemeStyle.Dark;
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            this.saveAsToolStripMenuItem1.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // convertToToolStripMenuItem
            // 
            this.convertToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.version11ToolStripMenuItem,
            this.version10ToolStripMenuItem});
            this.convertToToolStripMenuItem.Name = "convertToToolStripMenuItem";
            this.convertToToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.convertToToolStripMenuItem.Text = "Convert To";
            // 
            // version11ToolStripMenuItem
            // 
            this.version11ToolStripMenuItem.Name = "version11ToolStripMenuItem";
            this.version11ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.version11ToolStripMenuItem.Text = "Version 11";
            this.version11ToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click11);
            // 
            // version10ToolStripMenuItem
            // 
            this.version10ToolStripMenuItem.Name = "version10ToolStripMenuItem";
            this.version10ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.version10ToolStripMenuItem.Text = "Version 10";
            this.version10ToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click10);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(141, 29);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Orange;
            this.jPictureBox1.TabIndex = 53;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.Load_Click);
            // 
            // jTabControl1
            // 
            this.jTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
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
            this.jTabControl1.ChangeAnimation = jAnimation2;
            this.jTabControl1.Controls.Add(this.tabPage5);
            this.jTabControl1.Location = new System.Drawing.Point(3, 611);
            this.jTabControl1.Name = "jTabControl1";
            this.jTabControl1.Padding = new System.Drawing.Point(6, 0);
            this.jTabControl1.SelectedIndex = 0;
            this.jTabControl1.Size = new System.Drawing.Size(949, 86);
            this.jTabControl1.Style = JHUI.JColorStyle.Orange;
            this.jTabControl1.TabIndex = 55;
            this.jTabControl1.Theme = JHUI.JThemeStyle.Dark;
            this.jTabControl1.UseSelectable = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage5.Controls.Add(this.jComboBox1);
            this.tabPage5.Controls.Add(this.jPictureBox4);
            this.tabPage5.Controls.Add(this.jCheckBox1);
            this.tabPage5.Controls.Add(this.jPictureBox3);
            this.tabPage5.Controls.Add(this.jLabel2);
            this.tabPage5.Controls.Add(this.pathLabel);
            this.tabPage5.Controls.Add(this.version_label);
            this.tabPage5.Controls.Add(this.jLabel1);
            this.tabPage5.Controls.Add(this.searchInput1);
            this.tabPage5.Controls.Add(this.checkBox1);
            this.tabPage5.Controls.Add(this.comboBox1);
            this.tabPage5.HorizontalScrollbarBarColor = true;
            this.tabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage5.HorizontalScrollbarSize = 10;
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(941, 56);
            this.tabPage5.Style = JHUI.JColorStyle.Gold;
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Miscellaneous";
            this.tabPage5.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage5.VerticalScrollbarBarColor = true;
            this.tabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage5.VerticalScrollbarSize = 10;
            // 
            // jComboBox1
            // 
            this.jComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jComboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jComboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.ItemHeight = 19;
            this.jComboBox1.Location = new System.Drawing.Point(618, 3);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.Size = new System.Drawing.Size(171, 25);
            this.jComboBox1.Style = JHUI.JColorStyle.Orange;
            this.jComboBox1.TabIndex = 61;
            this.jComboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox1.UseSelectable = true;
            // 
            // jPictureBox4
            // 
            this.jPictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox4.BackgroundImage")));
            this.jPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox4.ContextMenuStrip = this.jContextMenu1;
            this.jPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox4.Location = new System.Drawing.Point(912, 4);
            this.jPictureBox4.Name = "jPictureBox4";
            this.jPictureBox4.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox4.Style = JHUI.JColorStyle.Orange;
            this.jPictureBox4.TabIndex = 60;
            this.jPictureBox4.TabStop = false;
            this.jPictureBox4.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox4.Click += new System.EventHandler(this.jPictureBox4_Click);
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromCoordToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(218, 26);
            this.jContextMenu1.Style = JHUI.JColorStyle.White;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // importFromCoordToolStripMenuItem
            // 
            this.importFromCoordToolStripMenuItem.Name = "importFromCoordToolStripMenuItem";
            this.importFromCoordToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.importFromCoordToolStripMenuItem.Text = "Import from coord_data.txt";
            this.importFromCoordToolStripMenuItem.Click += new System.EventHandler(this.importFromCoordToolStripMenuItem_Click);
            // 
            // jCheckBox1
            // 
            this.jCheckBox1.AutoSize = true;
            this.jCheckBox1.Location = new System.Drawing.Point(87, 37);
            this.jCheckBox1.Name = "jCheckBox1";
            this.jCheckBox1.Size = new System.Drawing.Size(91, 15);
            this.jCheckBox1.Style = JHUI.JColorStyle.Orange;
            this.jCheckBox1.TabIndex = 59;
            this.jCheckBox1.Text = "Triger Search";
            this.jCheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.jCheckBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox1.UseSelectable = true;
            this.jCheckBox1.UseVisualStyleBackColor = true;
            // 
            // jPictureBox3
            // 
            this.jPictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox3.BackgroundImage")));
            this.jPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox3.ContextMenuStrip = this.jContextMenu1;
            this.jPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox3.Location = new System.Drawing.Point(912, 34);
            this.jPictureBox3.Name = "jPictureBox3";
            this.jPictureBox3.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox3.Style = JHUI.JColorStyle.Orange;
            this.jPictureBox3.TabIndex = 58;
            this.jPictureBox3.TabStop = false;
            this.jPictureBox3.Theme = JHUI.JThemeStyle.Dark;
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
            this.jLabel2.Location = new System.Drawing.Point(259, 30);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(32, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Gold;
            this.jLabel2.TabIndex = 56;
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
            this.pathLabel.Location = new System.Drawing.Point(341, 29);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pathLabel.Size = new System.Drawing.Size(181, 15);
            this.pathLabel.Style = JHUI.JColorStyle.Gold;
            this.pathLabel.TabIndex = 57;
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
            this.version_label.Location = new System.Drawing.Point(341, 10);
            this.version_label.Name = "version_label";
            this.version_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.version_label.Size = new System.Drawing.Size(13, 15);
            this.version_label.Style = JHUI.JColorStyle.Gold;
            this.version_label.TabIndex = 54;
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
            this.jLabel1.Location = new System.Drawing.Point(258, 10);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(46, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 55;
            this.jLabel1.Text = "Version:";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
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
            this.searchInput1.CustomButton.Location = new System.Drawing.Point(213, 1);
            this.searchInput1.CustomButton.Name = "";
            this.searchInput1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.searchInput1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.searchInput1.CustomButton.TabIndex = 1;
            this.searchInput1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.searchInput1.CustomButton.UseSelectable = true;
            this.searchInput1.DrawBorder = true;
            this.searchInput1.DrawBorderBottomLine = false;
            this.searchInput1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchInput1.FontSize = JHUI.JTextBoxSize.Medium;
            this.searchInput1.Lines = new string[0];
            this.searchInput1.Location = new System.Drawing.Point(11, 6);
            this.searchInput1.MaxLength = 32767;
            this.searchInput1.Name = "searchInput1";
            this.searchInput1.PasswordChar = '\0';
            this.searchInput1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchInput1.SelectedText = "";
            this.searchInput1.SelectionLength = 0;
            this.searchInput1.SelectionStart = 0;
            this.searchInput1.ShortcutsEnabled = true;
            this.searchInput1.ShowButton = true;
            this.searchInput1.Size = new System.Drawing.Size(241, 29);
            this.searchInput1.Style = JHUI.JColorStyle.Orange;
            this.searchInput1.TabIndex = 53;
            this.searchInput1.TextWaterMark = "Search...";
            this.searchInput1.Theme = JHUI.JThemeStyle.Dark;
            this.searchInput1.UseCustomFont = true;
            this.searchInput1.UseSelectable = true;
            this.searchInput1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchInput1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchInput1.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.UniversalSearch);
            // 
            // jPictureBox5
            // 
            this.jPictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox5.BackgroundImage")));
            this.jPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox5.Location = new System.Drawing.Point(921, 29);
            this.jPictureBox5.Name = "jPictureBox5";
            this.jPictureBox5.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox5.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox5.TabIndex = 110;
            this.jPictureBox5.TabStop = false;
            this.jPictureBox5.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox5.Click += new System.EventHandler(this.jPictureBox5_Click_1);
            // 
            // NpcEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jPictureBox5);
            this.Controls.Add(this.jTabControl1);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.jPictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "NpcEditor";
            this.Opacity = 0D;
            this.Style = JHUI.JColorStyle.Orange;
            this.Text = "Npc Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NpcEditor_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.NPC_MOB_CONTEXTLIST.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grupeNpcMob)).EndInit();
            this.NPC_MOB_CONTEXTLIST_GRUPE.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resourceGroups)).EndInit();
            this.RES_STRIP_MENU_GROUPE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resources)).EndInit();
            this.RES_STRIP_MENU.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dyntext_image)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.DIN_STRIP_MENU.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_triggers)).EndInit();
            this.TRIGER_STRIP_MENU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            this.Save.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.jTabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).EndInit();
            this.jContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox mobsNpcList;
        private JTabControl tabControl1;
        private JTabPage tabPage1;
        private JTabPage tabPage2;
        private JGroupBox groupBox4;
        private JGroupBox groupBox3;
        private JCheckBox mobnpc_ingen;
        private JCheckBox mobnpc_autor;
        private JCheckBox mobnpc_validone;
        private JTextBox mobnpc_maxNum;
        private JTextBox mobnpc_lt;
        private JLabel label18;
        private JTextBox mobnpc_gt;
        private JLabel label17;
        private JTextBox mobnpc_gid;
        private JLabel label16;
        private JLabel label14;
        private JTextBox mobnpc_trig;
        private JLabel label9;
        private JGroupBox groupBox2;
        private JLabel label15;
        private JTextBox mobnpc_rx;
        private JTextBox mobnpc_z;
        private JLabel label3;
        private JComboBox mobnpc_positiontype;
        private JLabel label4;
        private JLabel label5;
        private JTextBox mobnpc_rz;
        private JTextBox mobnpc_az;
        private JTextBox mobnpc_ry;
        private JLabel label6;
        private JLabel label7;
        private JTextBox mobnpc_x;
        private JLabel label8;
        private JTextBox mobnpc_ay;
        private JTextBox mobnpc_y;
        private JLabel label10;
        private JTextBox mobnpc_ax;
        private JLabel label11;
        private JLabel label12;
        private JGroupBox groupBox1;
        private JTextBox mobnpc_name;
        private JLabel label1;
        private JComboBox mobnpc_type;
        private JTextBox mobnpc_id;
        private JLabel label2;
        private JLabel label13;
        private JTabPage tabPage3;
        private JTabPage tabPage4;
        private JDataGridView grupeNpcMob;
        private JDataGridView dataGridView_resourceGroups;
        private JDataGridView dataGridView_resources;
        private JDataGridView dataGridView_triggers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column21;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column23;
        private System.Windows.Forms.ContextMenuStrip NPC_MOB_CONTEXTLIST;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSelectedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip NPC_MOB_CONTEXTLIST_GRUPE;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RES_STRIP_MENU_GROUPE;
        private System.Windows.Forms.ContextMenuStrip RES_STRIP_MENU;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importSelectedToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip TRIGER_STRIP_MENU;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem importSelectedToolStripMenuItem3;
        private JGroupBox groupBox5;
        private JLabel label19;
        private JTextBox Dyntext_dx;
        private JTextBox Dyntext_z;
        private JLabel label21;
        private JLabel label22;
        private JTextBox Dyntext_dz;
        private JTextBox Dyntext_dy;
        private JLabel label23;
        private JLabel label24;
        private JTextBox Dyntext_x;
        private JLabel label25;
        private JTextBox Dyntext_scale;
        private JTextBox Dyntext_y;
        private JLabel label26;
        private JTextBox Dyntext_trig;
        private JLabel label27;
        private System.Windows.Forms.ListBox Dyntext_items;
        private JGroupBox groupBox6;
        private JTextBox Dyntext_id;
        private JLabel label20;
        private JGroupBox groupBox8;
        private JPictureBox Dyntext_image;
        private JGroupBox groupBox7;
        private JLabel label28;
        private System.Windows.Forms.ContextMenuStrip DIN_STRIP_MENU;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private JComboBox Dyntext_name;
        private JComboBox comboBox1;
        private JCheckBox checkBox1;
        private JLabel labelZ;
        private JLabel labelY;
        private JLabel labelX;
        private JHUI.Controls.JPictureBox jPictureBox2;
        private JHUI.Controls.JPictureBox jPictureBox1;
        private JContextMenu Save;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem1;
        private JTabControl jTabControl1;
        private ToolStripMenuItem goToToolStripMenuItem;
        private JTextBox searchInput1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem fillCoordinatesFromGameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toGameCoordinatesToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private JLabel jLabel2;
        private JLabel pathLabel;
        private JLabel version_label;
        private JLabel jLabel1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private JTabPage tabPage5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn Column24;
        private DataGridViewComboBoxColumn Column42;
        private DataGridViewTextBoxColumn Column26;
        private DataGridViewTextBoxColumn Column27;
        private DataGridViewTextBoxColumn Column25;
        private DataGridViewTextBoxColumn Column28;
        private DataGridViewTextBoxColumn Column29;
        private DataGridViewComboBoxColumn Column43;
        private DataGridViewTextBoxColumn Column31;
        private DataGridViewTextBoxColumn Column32;
        private DataGridViewTextBoxColumn Column33;
        private DataGridViewTextBoxColumn Column34;
        private ToolStripMenuItem convertToToolStripMenuItem;
        private ToolStripMenuItem version11ToolStripMenuItem;
        private ToolStripMenuItem version10ToolStripMenuItem;
        private JPictureBox jPictureBox3;
        private JContextMenu jContextMenu1;
        private ToolStripMenuItem importFromCoordToolStripMenuItem;
        private JCheckBox jCheckBox1;
        private JButton jButton1;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem sortIdsToolStripMenuItem;
        private ToolStripMenuItem idAscToolStripMenuItem;
        private ToolStripMenuItem aSKToolStripMenuItem;
        private ToolStripMenuItem dSKToolStripMenuItem;
        private JTextBox jTextBox1;
        private JPictureBox jPictureBox4;
        private DataGridViewTextBoxColumn Column30;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewCheckBoxColumn Column11;
        private DataGridViewCheckBoxColumn Column12;
        private DataGridViewCheckBoxColumn Column13;
        private DataGridViewCheckBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column18;
        private JComboBox jComboBox1;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem exportToCoorddatatxtToolStripMenuItem;
        private ToolStripMenuItem toClipboardForPToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem copyElementsToolStripMenuItem;
        private JPictureBox jPictureBox5;
    }
}

