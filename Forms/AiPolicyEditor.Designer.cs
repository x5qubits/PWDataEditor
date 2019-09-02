using AIPolicy;
using JHUI.Controls;
using System.Windows.Forms;

namespace PWDataEditorPaied
{
    partial class AiPolicyEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            JHUI.JAnimation jAnimation1 = new JHUI.JAnimation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AiPolicyEditor));
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.RunCB = new JHUI.Controls.JCheckBox();
            this.AttackCB = new JHUI.Controls.JCheckBox();
            this.EnabledCB = new JHUI.Controls.JCheckBox();
            this.PolicysView = new JHUI.Controls.JDataGridView();
            this.contextMenuPolicy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionSetsView = new JHUI.Controls.JDataGridView();
            this.ProceduresView = new JHUI.Controls.JDataGridView();
            this.contextMenuProcedure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.PolicyBorderPanel = new System.Windows.Forms.GroupBox();
            this.TriggerBorderPanel = new System.Windows.Forms.GroupBox();
            this.OperationBorderPanel = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConditionTB = new JHUI.Controls.JTextBox();
            this.contextMenuEditCondition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ParamView = new JHUI.Controls.JDataGridView();
            this.TargetView = new JHUI.Controls.JDataGridView();
            this.TypeTargetCB = new JHUI.Controls.JComboBox();
            this.TypeOperationCB = new JHUI.Controls.JComboBox();
            this.tabControl2 = new JHUI.Controls.JTabControl();
            this.tabPage3 = new JHUI.Controls.JTabPage();
            this.searchInput1 = new JHUI.Controls.JTextBox();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.pathLabel = new JHUI.Controls.JLabel();
            this.version_label = new JHUI.Controls.JLabel();
            this.label1 = new JHUI.Controls.JLabel();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jPictureBox5 = new JHUI.Controls.JPictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportXMLBroadcastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PolicysView)).BeginInit();
            this.contextMenuPolicy.SuspendLayout();
            this.contextMenuAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionSetsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProceduresView)).BeginInit();
            this.contextMenuProcedure.SuspendLayout();
            this.PolicyBorderPanel.SuspendLayout();
            this.TriggerBorderPanel.SuspendLayout();
            this.OperationBorderPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuEditCondition.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParamView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetView)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenDialog
            // 
            this.OpenDialog.DefaultExt = "data";
            this.OpenDialog.FileName = "aipolicy.data";
            this.OpenDialog.Filter = "Ai File (*.data)|*.data|XML (*.xml)|*.xml";
            this.OpenDialog.ShowReadOnly = true;
            this.OpenDialog.Title = "Open Aipolicy.data";
            // 
            // RunCB
            // 
            this.RunCB.AutoCheck = false;
            this.RunCB.AutoSize = true;
            this.RunCB.BackColor = System.Drawing.Color.White;
            this.RunCB.ForeColor = System.Drawing.Color.Black;
            this.RunCB.Location = new System.Drawing.Point(245, 61);
            this.RunCB.Name = "RunCB";
            this.RunCB.Size = new System.Drawing.Size(68, 15);
            this.RunCB.Style = JHUI.JColorStyle.Purple;
            this.RunCB.TabIndex = 11;
            this.RunCB.Text = "Can Run";
            this.RunCB.Theme = JHUI.JThemeStyle.Dark;
            this.RunCB.UseSelectable = true;
            this.RunCB.UseVisualStyleBackColor = false;
            this.RunCB.CheckedChanged += new System.EventHandler(this.RunCB_CheckedChanged);
            // 
            // AttackCB
            // 
            this.AttackCB.AutoCheck = false;
            this.AttackCB.AutoSize = true;
            this.AttackCB.BackColor = System.Drawing.Color.White;
            this.AttackCB.ForeColor = System.Drawing.Color.Black;
            this.AttackCB.Location = new System.Drawing.Point(132, 61);
            this.AttackCB.Name = "AttackCB";
            this.AttackCB.Size = new System.Drawing.Size(96, 15);
            this.AttackCB.Style = JHUI.JColorStyle.Purple;
            this.AttackCB.TabIndex = 12;
            this.AttackCB.Text = "Attak Enabled";
            this.AttackCB.Theme = JHUI.JThemeStyle.Dark;
            this.AttackCB.UseSelectable = true;
            this.AttackCB.UseVisualStyleBackColor = false;
            this.AttackCB.CheckedChanged += new System.EventHandler(this.AttackCB_CheckedChanged);
            // 
            // EnabledCB
            // 
            this.EnabledCB.AutoCheck = false;
            this.EnabledCB.AutoSize = true;
            this.EnabledCB.BackColor = System.Drawing.Color.White;
            this.EnabledCB.ForeColor = System.Drawing.Color.Black;
            this.EnabledCB.Location = new System.Drawing.Point(7, 61);
            this.EnabledCB.Name = "EnabledCB";
            this.EnabledCB.Size = new System.Drawing.Size(106, 15);
            this.EnabledCB.Style = JHUI.JColorStyle.Purple;
            this.EnabledCB.TabIndex = 13;
            this.EnabledCB.Text = "Default Enabled";
            this.EnabledCB.Theme = JHUI.JThemeStyle.Dark;
            this.EnabledCB.UseSelectable = true;
            this.EnabledCB.UseVisualStyleBackColor = false;
            this.EnabledCB.CheckedChanged += new System.EventHandler(this.EnabledCB_CheckedChanged);
            // 
            // PolicysView
            // 
            this.PolicysView.AllowUserToAddRows = false;
            this.PolicysView.AllowUserToDeleteRows = false;
            this.PolicysView.AllowUserToOrderColumns = true;
            this.PolicysView.AllowUserToResizeColumns = false;
            this.PolicysView.AllowUserToResizeRows = false;
            this.PolicysView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PolicysView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PolicysView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.PolicysView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PolicysView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PolicysView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.PolicysView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PolicysView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.PolicysView.ColumnHeadersHeight = 22;
            this.PolicysView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PolicysView.ContextMenuStrip = this.contextMenuPolicy;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PolicysView.DefaultCellStyle = dataGridViewCellStyle23;
            this.PolicysView.EnableHeadersVisualStyles = false;
            this.PolicysView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PolicysView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PolicysView.Location = new System.Drawing.Point(4, 14);
            this.PolicysView.Name = "PolicysView";
            this.PolicysView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PolicysView.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.PolicysView.RowHeadersVisible = false;
            this.PolicysView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.PolicysView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PolicysView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PolicysView.Size = new System.Drawing.Size(122, 519);
            this.PolicysView.Style = JHUI.JColorStyle.Purple;
            this.PolicysView.TabIndex = 37;
            this.PolicysView.Theme = JHUI.JThemeStyle.Dark;
            this.PolicysView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellClick);
            this.PolicysView.SelectionChanged += new System.EventHandler(this.DataView_CellClick);
            this.PolicysView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PolicysView_KeyDown);
            // 
            // contextMenuPolicy
            // 
            this.contextMenuPolicy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.contextMenuPolicy.Name = "contextMenuPolicy";
            this.contextMenuPolicy.Size = new System.Drawing.Size(111, 126);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.AddPolicyBTN_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Atachment;
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DelPolicyBTN_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(107, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Pack;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Unpack;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // contextMenuAction
            // 
            this.contextMenuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem1,
            this.toolStripSeparator4,
            this.toolStripMenuItem3});
            this.contextMenuAction.Name = "contextMenuPolicy";
            this.contextMenuAction.Size = new System.Drawing.Size(108, 82);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "New";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.AddTriggerBTN_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem3.Text = "Delete";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.DelTriggerBTN_Click);
            // 
            // ActionSetsView
            // 
            this.ActionSetsView.AllowUserToAddRows = false;
            this.ActionSetsView.AllowUserToDeleteRows = false;
            this.ActionSetsView.AllowUserToOrderColumns = true;
            this.ActionSetsView.AllowUserToResizeColumns = false;
            this.ActionSetsView.AllowUserToResizeRows = false;
            this.ActionSetsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionSetsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ActionSetsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ActionSetsView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ActionSetsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ActionSetsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ActionSetsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionSetsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.ActionSetsView.ColumnHeadersHeight = 22;
            this.ActionSetsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ActionSetsView.ColumnHeadersVisible = false;
            this.ActionSetsView.ContextMenuStrip = this.contextMenuAction;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ActionSetsView.DefaultCellStyle = dataGridViewCellStyle17;
            this.ActionSetsView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ActionSetsView.EnableHeadersVisualStyles = false;
            this.ActionSetsView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ActionSetsView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ActionSetsView.Location = new System.Drawing.Point(6, 14);
            this.ActionSetsView.Name = "ActionSetsView";
            this.ActionSetsView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionSetsView.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.ActionSetsView.RowHeadersVisible = false;
            this.ActionSetsView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ActionSetsView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ActionSetsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ActionSetsView.Size = new System.Drawing.Size(418, 229);
            this.ActionSetsView.Style = JHUI.JColorStyle.Purple;
            this.ActionSetsView.TabIndex = 36;
            this.ActionSetsView.Theme = JHUI.JThemeStyle.Dark;
            this.ActionSetsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TriggerView_CellClick);
            this.ActionSetsView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionSetsView_KeyDown);
            // 
            // ProceduresView
            // 
            this.ProceduresView.AllowUserToAddRows = false;
            this.ProceduresView.AllowUserToDeleteRows = false;
            this.ProceduresView.AllowUserToOrderColumns = true;
            this.ProceduresView.AllowUserToResizeColumns = false;
            this.ProceduresView.AllowUserToResizeRows = false;
            this.ProceduresView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProceduresView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProceduresView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ProceduresView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ProceduresView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProceduresView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ProceduresView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProceduresView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProceduresView.ColumnHeadersHeight = 22;
            this.ProceduresView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ProceduresView.ColumnHeadersVisible = false;
            this.ProceduresView.ContextMenuStrip = this.contextMenuProcedure;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProceduresView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProceduresView.EnableHeadersVisualStyles = false;
            this.ProceduresView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ProceduresView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ProceduresView.Location = new System.Drawing.Point(8, 19);
            this.ProceduresView.Name = "ProceduresView";
            this.ProceduresView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProceduresView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProceduresView.RowHeadersVisible = false;
            this.ProceduresView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProceduresView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProceduresView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProceduresView.Size = new System.Drawing.Size(416, 169);
            this.ProceduresView.Style = JHUI.JColorStyle.Purple;
            this.ProceduresView.TabIndex = 35;
            this.ProceduresView.Theme = JHUI.JThemeStyle.Dark;
            this.ProceduresView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationView_CellClick);
            this.ProceduresView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProceduresView_KeyDown);
            // 
            // contextMenuProcedure
            // 
            this.contextMenuProcedure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripSeparator5,
            this.toolStripMenuItem8});
            this.contextMenuProcedure.Name = "contextMenuPolicy";
            this.contextMenuProcedure.Size = new System.Drawing.Size(108, 54);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem6.Text = "New";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.AddOpBTN_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem8.Text = "Delete";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.DelOpBTN_Click);
            // 
            // SaveDialog
            // 
            this.SaveDialog.DefaultExt = "*.data";
            this.SaveDialog.Filter = "Ai File (*.data)|*.data|XML (*.xml)|*.xml";
            // 
            // PolicyBorderPanel
            // 
            this.PolicyBorderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PolicyBorderPanel.Controls.Add(this.PolicysView);
            this.PolicyBorderPanel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.PolicyBorderPanel.Location = new System.Drawing.Point(7, 63);
            this.PolicyBorderPanel.Name = "PolicyBorderPanel";
            this.PolicyBorderPanel.Size = new System.Drawing.Size(132, 539);
            this.PolicyBorderPanel.TabIndex = 35;
            this.PolicyBorderPanel.TabStop = false;
            this.PolicyBorderPanel.Text = "Controllers";
            // 
            // TriggerBorderPanel
            // 
            this.TriggerBorderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TriggerBorderPanel.Controls.Add(this.ActionSetsView);
            this.TriggerBorderPanel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.TriggerBorderPanel.Location = new System.Drawing.Point(145, 63);
            this.TriggerBorderPanel.Name = "TriggerBorderPanel";
            this.TriggerBorderPanel.Size = new System.Drawing.Size(430, 253);
            this.TriggerBorderPanel.TabIndex = 37;
            this.TriggerBorderPanel.TabStop = false;
            this.TriggerBorderPanel.Text = "Action Sets";
            // 
            // OperationBorderPanel
            // 
            this.OperationBorderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationBorderPanel.Controls.Add(this.ProceduresView);
            this.OperationBorderPanel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.OperationBorderPanel.Location = new System.Drawing.Point(144, 408);
            this.OperationBorderPanel.Name = "OperationBorderPanel";
            this.OperationBorderPanel.Size = new System.Drawing.Size(430, 194);
            this.OperationBorderPanel.TabIndex = 38;
            this.OperationBorderPanel.TabStop = false;
            this.OperationBorderPanel.Text = "Procedures";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ConditionTB);
            this.groupBox1.Controls.Add(this.RunCB);
            this.groupBox1.Controls.Add(this.AttackCB);
            this.groupBox1.Controls.Add(this.EnabledCB);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(145, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 82);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // ConditionTB
            // 
            this.ConditionTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConditionTB.BorderBottomLineSize = 5;
            this.ConditionTB.BorderColor = System.Drawing.Color.Black;
            this.ConditionTB.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.ConditionTB.CustomButton.Image = null;
            this.ConditionTB.CustomButton.Location = new System.Drawing.Point(389, 1);
            this.ConditionTB.CustomButton.Name = "";
            this.ConditionTB.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.ConditionTB.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.ConditionTB.CustomButton.TabIndex = 1;
            this.ConditionTB.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.ConditionTB.CustomButton.UseSelectable = true;
            this.ConditionTB.CustomButton.Visible = false;
            this.ConditionTB.DrawBorder = true;
            this.ConditionTB.DrawBorderBottomLine = false;
            this.ConditionTB.Enabled = false;
            this.ConditionTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ConditionTB.FontWeight = JHUI.JTextBoxWeight.Light;
            this.ConditionTB.Lines = new string[0];
            this.ConditionTB.Location = new System.Drawing.Point(0, 16);
            this.ConditionTB.MaxLength = 32767;
            this.ConditionTB.Multiline = true;
            this.ConditionTB.Name = "ConditionTB";
            this.ConditionTB.PasswordChar = '\0';
            this.ConditionTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConditionTB.SelectedText = "";
            this.ConditionTB.SelectionLength = 0;
            this.ConditionTB.SelectionStart = 0;
            this.ConditionTB.ShortcutsEnabled = true;
            this.ConditionTB.Size = new System.Drawing.Size(429, 41);
            this.ConditionTB.Style = JHUI.JColorStyle.Purple;
            this.ConditionTB.TabIndex = 15;
            this.ConditionTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConditionTB.TextWaterMark = "";
            this.ConditionTB.Theme = JHUI.JThemeStyle.Dark;
            this.ConditionTB.UseCustomFont = true;
            this.ConditionTB.UseSelectable = true;
            this.ConditionTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ConditionTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ConditionTB.Click += new System.EventHandler(this.EditCondBTN_Click);
            // 
            // contextMenuEditCondition
            // 
            this.contextMenuEditCondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuEditCondition.Name = "contextMenuStrip1";
            this.contextMenuEditCondition.Size = new System.Drawing.Size(95, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Edit;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem2.Text = "Edit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.EditCondBTN_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ParamView);
            this.groupBox2.Controls.Add(this.TargetView);
            this.groupBox2.Controls.Add(this.TypeTargetCB);
            this.groupBox2.Controls.Add(this.TypeOperationCB);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Location = new System.Drawing.Point(581, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 539);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // ParamView
            // 
            this.ParamView.AllowUserToAddRows = false;
            this.ParamView.AllowUserToDeleteRows = false;
            this.ParamView.AllowUserToOrderColumns = true;
            this.ParamView.AllowUserToResizeColumns = false;
            this.ParamView.AllowUserToResizeRows = false;
            this.ParamView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ParamView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ParamView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ParamView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParamView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ParamView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParamView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ParamView.ColumnHeadersHeight = 22;
            this.ParamView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ParamView.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParamView.DefaultCellStyle = dataGridViewCellStyle5;
            this.ParamView.EnableHeadersVisualStyles = false;
            this.ParamView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ParamView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ParamView.Location = new System.Drawing.Point(6, 45);
            this.ParamView.Name = "ParamView";
            this.ParamView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParamView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ParamView.RowHeadersVisible = false;
            this.ParamView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ParamView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ParamView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParamView.Size = new System.Drawing.Size(357, 198);
            this.ParamView.Style = JHUI.JColorStyle.Purple;
            this.ParamView.TabIndex = 36;
            this.ParamView.Theme = JHUI.JThemeStyle.Dark;
            this.ParamView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ParamView_CellBeginEdit);
            this.ParamView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParamView_CellEndEdit);
            // 
            // TargetView
            // 
            this.TargetView.AllowUserToAddRows = false;
            this.TargetView.AllowUserToDeleteRows = false;
            this.TargetView.AllowUserToOrderColumns = true;
            this.TargetView.AllowUserToResizeColumns = false;
            this.TargetView.AllowUserToResizeRows = false;
            this.TargetView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TargetView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.TargetView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TargetView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TargetView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TargetView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TargetView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.TargetView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargetView.ColumnHeadersVisible = false;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TargetView.DefaultCellStyle = dataGridViewCellStyle26;
            this.TargetView.EnableHeadersVisualStyles = false;
            this.TargetView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TargetView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TargetView.Location = new System.Drawing.Point(6, 318);
            this.TargetView.Name = "TargetView";
            this.TargetView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TargetView.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.TargetView.RowHeadersVisible = false;
            this.TargetView.RowHeadersWidth = 100;
            this.TargetView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TargetView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TargetView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TargetView.Size = new System.Drawing.Size(357, 215);
            this.TargetView.Style = JHUI.JColorStyle.Purple;
            this.TargetView.TabIndex = 35;
            this.TargetView.TabStop = false;
            this.TargetView.Theme = JHUI.JThemeStyle.Dark;
            this.TargetView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.TargetView_CellBeginEdit);
            this.TargetView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TargetView_CellEndEdit);
            // 
            // TypeTargetCB
            // 
            this.TypeTargetCB.BackColor = System.Drawing.Color.White;
            this.TypeTargetCB.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.TypeTargetCB.FontSize = JHUI.JComboBoxSize.Small;
            this.TypeTargetCB.ForeColor = System.Drawing.Color.Black;
            this.TypeTargetCB.FormattingEnabled = true;
            this.TypeTargetCB.ItemHeight = 19;
            this.TypeTargetCB.Items.AddRange(new object[] {
            "Aggro First",
            "Aggro Second",
            "Aggro Second Random",
            "Target Most HP",
            "Target Most MP",
            "Target Least HP",
            "Target Character Profession Mask",
            "Target Self",
            "Target Monster Killer",
            "Target Monster Birthplace Faction",
            "Target Aggro Special 0",
            "Target Aggro Special 1",
            "Target Aggro Special 2",
            "Target Aggro First Redirected"});
            this.TypeTargetCB.Location = new System.Drawing.Point(6, 289);
            this.TypeTargetCB.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TypeTargetCB.Name = "TypeTargetCB";
            this.TypeTargetCB.Size = new System.Drawing.Size(357, 25);
            this.TypeTargetCB.Style = JHUI.JColorStyle.Purple;
            this.TypeTargetCB.TabIndex = 34;
            this.TypeTargetCB.Theme = JHUI.JThemeStyle.Dark;
            this.TypeTargetCB.UseSelectable = true;
            this.TypeTargetCB.SelectedIndexChanged += new System.EventHandler(this.TargetCB_SelectedIndexChanged);
            // 
            // TypeOperationCB
            // 
            this.TypeOperationCB.BackColor = System.Drawing.Color.White;
            this.TypeOperationCB.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.TypeOperationCB.FontSize = JHUI.JComboBoxSize.Small;
            this.TypeOperationCB.ForeColor = System.Drawing.Color.Black;
            this.TypeOperationCB.FormattingEnabled = true;
            this.TypeOperationCB.ItemHeight = 19;
            this.TypeOperationCB.Items.AddRange(new object[] {
            "Attak Target",
            "Use Skill",
            "Send Message",
            "Reset Aggro",
            "Execute Triger",
            "Enable Passive Triger",
            "Enable Active Triger",
            "Create Timer",
            "Delete Timer",
            "Flee",
            "Be Tunted",
            "Fade Target",
            "Fade Aggro",
            "Break",
            "Active Spawn",
            "Set Common Value",
            "Increase Common Value",
            "Summon Monster",
            "Change Path",
            "Play Action",
            "Revise History",
            "Set History",
            "Deliver Faction PVP Points",
            "Calc Variable",
            "Summon Monster",
            "Change Path",
            "Use Skill",
            "Active Spawn",
            "Deliver Task",
            "Summon Mine",
            "Summon Npc",
            "Deliver Random Task In Region",
            "Deliver Task In Damage List",
            "Clear Tower Task In Region",
            "save_player_count_in_radius_to_param",
            "save_player_count_in_region_to_param",
            "Unknown 3",
            "Unknown 4"});
            this.TypeOperationCB.Location = new System.Drawing.Point(6, 17);
            this.TypeOperationCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypeOperationCB.Name = "TypeOperationCB";
            this.TypeOperationCB.Size = new System.Drawing.Size(357, 25);
            this.TypeOperationCB.Style = JHUI.JColorStyle.Purple;
            this.TypeOperationCB.TabIndex = 32;
            this.TypeOperationCB.Theme = JHUI.JThemeStyle.Dark;
            this.TypeOperationCB.UseSelectable = true;
            this.TypeOperationCB.SelectedIndexChanged += new System.EventHandler(this.TypeOperationCB_SelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.CausesValidation = false;
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
            this.tabControl2.ChangeAnimation = jAnimation1;
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(7, 607);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(6, 0);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(943, 89);
            this.tabControl2.Style = JHUI.JColorStyle.Purple;
            this.tabControl2.TabIndex = 41;
            this.tabControl2.TabStop = false;
            this.tabControl2.Theme = JHUI.JThemeStyle.Dark;
            this.tabControl2.UseSelectable = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage3.Controls.Add(this.searchInput1);
            this.tabPage3.Controls.Add(this.jLabel2);
            this.tabPage3.Controls.Add(this.pathLabel);
            this.tabPage3.Controls.Add(this.version_label);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.HorizontalScrollbarBarColor = true;
            this.tabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage3.HorizontalScrollbarSize = 10;
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(935, 59);
            this.tabPage3.Style = JHUI.JColorStyle.Gold;
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Miscellaneous";
            this.tabPage3.Theme = JHUI.JThemeStyle.Dark;
            this.tabPage3.ToolTipText = "Replaces the selected items based on your criteria!";
            this.tabPage3.VerticalScrollbarBarColor = true;
            this.tabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage3.VerticalScrollbarSize = 10;
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
            this.searchInput1.CustomButton.Location = new System.Drawing.Point(150, 1);
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
            this.searchInput1.Location = new System.Drawing.Point(12, 15);
            this.searchInput1.MaxLength = 32767;
            this.searchInput1.Name = "searchInput1";
            this.searchInput1.PasswordChar = '\0';
            this.searchInput1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchInput1.SelectedText = "";
            this.searchInput1.SelectionLength = 0;
            this.searchInput1.SelectionStart = 0;
            this.searchInput1.ShortcutsEnabled = true;
            this.searchInput1.ShowButton = true;
            this.searchInput1.Size = new System.Drawing.Size(178, 29);
            this.searchInput1.Style = JHUI.JColorStyle.Purple;
            this.searchInput1.TabIndex = 44;
            this.searchInput1.TextWaterMark = "Search...";
            this.searchInput1.Theme = JHUI.JThemeStyle.Dark;
            this.searchInput1.UseCustomFont = true;
            this.searchInput1.UseSelectable = true;
            this.searchInput1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchInput1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchInput1.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.PolicyTB_TextChanged);
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
            this.jLabel2.Location = new System.Drawing.Point(202, 32);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(32, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Purple;
            this.jLabel2.TabIndex = 42;
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
            this.pathLabel.Location = new System.Drawing.Point(284, 31);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pathLabel.Size = new System.Drawing.Size(181, 15);
            this.pathLabel.Style = JHUI.JColorStyle.Purple;
            this.pathLabel.TabIndex = 43;
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
            this.version_label.Location = new System.Drawing.Point(284, 12);
            this.version_label.Name = "version_label";
            this.version_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.version_label.Size = new System.Drawing.Size(13, 15);
            this.version_label.Style = JHUI.JColorStyle.Purple;
            this.version_label.TabIndex = 40;
            this.version_label.Text = "0";
            this.version_label.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(201, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.Style = JHUI.JColorStyle.Purple;
            this.label1.TabIndex = 41;
            this.label1.Text = "Version:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox2.ContextMenuStrip = this.contextMenuStrip3;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(202, 28);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Purple;
            this.jPictureBox2.TabIndex = 43;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem1});
            this.contextMenuStrip3.Name = "classmaskMenu";
            this.contextMenuStrip3.Size = new System.Drawing.Size(187, 26);
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.saveDisketBig;
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            this.saveAsToolStripMenuItem1.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(173, 28);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Purple;
            this.jPictureBox1.TabIndex = 42;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // jPictureBox5
            // 
            this.jPictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox5.BackgroundImage")));
            this.jPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox5.ContextMenuStrip = this.contextMenuStrip1;
            this.jPictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox5.Location = new System.Drawing.Point(923, 28);
            this.jPictureBox5.Name = "jPictureBox5";
            this.jPictureBox5.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox5.Style = JHUI.JColorStyle.Blue;
            this.jPictureBox5.TabIndex = 47;
            this.jPictureBox5.TabStop = false;
            this.jPictureBox5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importXMLToolStripMenuItem,
            this.exportXMLBroadcastToolStripMenuItem});
            this.contextMenuStrip1.Name = "classmaskMenu";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 48);
            // 
            // importXMLToolStripMenuItem
            // 
            this.importXMLToolStripMenuItem.Name = "importXMLToolStripMenuItem";
            this.importXMLToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.importXMLToolStripMenuItem.Text = "Import XML Broadcast";
            this.importXMLToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenu_Click);
            // 
            // exportXMLBroadcastToolStripMenuItem
            // 
            this.exportXMLBroadcastToolStripMenuItem.Name = "exportXMLBroadcastToolStripMenuItem";
            this.exportXMLBroadcastToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exportXMLBroadcastToolStripMenuItem.Text = "Export XML Broadcast";
            this.exportXMLBroadcastToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenu_Click);
            // 
            // AiPolicyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jPictureBox5);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OperationBorderPanel);
            this.Controls.Add(this.TriggerBorderPanel);
            this.Controls.Add(this.PolicyBorderPanel);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AiPolicyEditor";
            this.Opacity = 0D;
            this.Style = JHUI.JColorStyle.Purple;
            this.Text = "AIPolicy Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AiPolicyEditor_FormClosing);
            this.Shown += new System.EventHandler(this.AiPolicyEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PolicysView)).EndInit();
            this.contextMenuPolicy.ResumeLayout(false);
            this.contextMenuAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActionSetsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProceduresView)).EndInit();
            this.contextMenuProcedure.ResumeLayout(false);
            this.PolicyBorderPanel.ResumeLayout(false);
            this.TriggerBorderPanel.ResumeLayout(false);
            this.OperationBorderPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuEditCondition.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParamView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetView)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox5)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private OpenFileDialog OpenDialog;
        private SaveFileDialog SaveDialog;
        #endregion
        private GroupBox PolicyBorderPanel;
        private GroupBox TriggerBorderPanel;
        private GroupBox OperationBorderPanel;
        private ContextMenuStrip contextMenuAction;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItem3;
        private ContextMenuStrip contextMenuProcedure;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem8;
        private ContextMenuStrip contextMenuPolicy;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem cloneToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private JTabControl tabControl2;
        private JTabPage tabPage3;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ContextMenuStrip contextMenuEditCondition;
        private ToolStripMenuItem toolStripMenuItem2;
        public JDataGridView ProceduresView;
        public JDataGridView PolicysView;
        public JDataGridView ActionSetsView;
        public JComboBox TypeOperationCB;
        public JDataGridView TargetView;
        public JComboBox TypeTargetCB;
        public JDataGridView ParamView;
        private JCheckBox RunCB;
        private JCheckBox AttackCB;
        private JCheckBox EnabledCB;
        private JPictureBox jPictureBox2;
        private JPictureBox jPictureBox1;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem saveAsToolStripMenuItem1;
        private JLabel jLabel2;
        private JLabel pathLabel;
        private JLabel version_label;
        private JLabel label1;
        private JTextBox searchInput1;
        private JTextBox ConditionTB;
        private JPictureBox jPictureBox5;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem importXMLToolStripMenuItem;
        private ToolStripMenuItem exportXMLBroadcastToolStripMenuItem;
    }
}