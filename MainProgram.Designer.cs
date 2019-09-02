namespace ElementEditor
{
    partial class MainProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jButton1 = new JHUI.Controls.JButton();
            this.SSA0 = new JHUI.Controls.JContextMenu(this.components);
            this.startStandAloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jButton2 = new JHUI.Controls.JButton();
            this.SSA1 = new JHUI.Controls.JContextMenu(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jButton3 = new JHUI.Controls.JButton();
            this.SSA2 = new JHUI.Controls.JContextMenu(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jProgressBar1 = new JHUI.Controls.JProgressBar();
            this.jButton4 = new JHUI.Controls.JButton();
            this.SSA3 = new JHUI.Controls.JContextMenu(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox6 = new JHUI.Controls.JPictureBox();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jContextMenu2 = new JHUI.Controls.JContextMenu(this.components);
            this.policyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandAloneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.domainEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pckEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.regionEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.precinctEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.worldTargetsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.dynobjectsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.dynTasksEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.extraDropEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStandaloneToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.jLabel3 = new JHUI.Controls.JLabel();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.jContextMenu1.SuspendLayout();
            this.SSA0.SuspendLayout();
            this.SSA1.SuspendLayout();
            this.SSA2.SuspendLayout();
            this.SSA3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.jContextMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.jContextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Perfect World Editor";
            this.notifyIcon1.Visible = true;
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.resetLocationToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(152, 76);
            this.jContextMenu1.Style = JHUI.JColorStyle.Gold;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View1;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // resetLocationToolStripMenuItem
            // 
            this.resetLocationToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Refresh2;
            this.resetLocationToolStripMenuItem.Name = "resetLocationToolStripMenuItem";
            this.resetLocationToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.resetLocationToolStripMenuItem.Text = "Reset Location";
            this.resetLocationToolStripMenuItem.Click += new System.EventHandler(this.resetLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // jButton1
            // 
            this.jButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton1.ContextMenuStrip = this.SSA0;
            this.jButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton1.Location = new System.Drawing.Point(10, 68);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(134, 25);
            this.jButton1.Style = JHUI.JColorStyle.Gold;
            this.jButton1.TabIndex = 0;
            this.jButton1.Text = "Show Element Editor";
            this.jButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.ShowElementEditor);
            // 
            // SSA0
            // 
            this.SSA0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandAloneToolStripMenuItem});
            this.SSA0.Name = "SSA0";
            this.SSA0.Size = new System.Drawing.Size(160, 26);
            this.SSA0.Style = JHUI.JColorStyle.Gold;
            this.SSA0.Theme = JHUI.JThemeStyle.Dark;
            // 
            // startStandAloneToolStripMenuItem
            // 
            this.startStandAloneToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandAloneToolStripMenuItem.Name = "startStandAloneToolStripMenuItem";
            this.startStandAloneToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.startStandAloneToolStripMenuItem.Text = "Start standalone";
            this.startStandAloneToolStripMenuItem.Click += new System.EventHandler(this.startStandAloneToolStripMenuItem_Click);
            // 
            // jButton2
            // 
            this.jButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton2.ContextMenuStrip = this.SSA1;
            this.jButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton2.Location = new System.Drawing.Point(11, 130);
            this.jButton2.Name = "jButton2";
            this.jButton2.Size = new System.Drawing.Size(134, 25);
            this.jButton2.Style = JHUI.JColorStyle.Gold;
            this.jButton2.TabIndex = 1;
            this.jButton2.Text = "Show Task Editor";
            this.jButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jButton2.Theme = JHUI.JThemeStyle.Dark;
            this.jButton2.UseSelectable = true;
            this.jButton2.UseVisualStyleBackColor = true;
            this.jButton2.Click += new System.EventHandler(this.ShowTaskEditor);
            // 
            // SSA1
            // 
            this.SSA1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.SSA1.Name = "jContextMenu3";
            this.SSA1.Size = new System.Drawing.Size(160, 26);
            this.SSA1.Style = JHUI.JColorStyle.Gold;
            this.SSA1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem1.Text = "Start standalone";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // jButton3
            // 
            this.jButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton3.ContextMenuStrip = this.SSA2;
            this.jButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton3.Location = new System.Drawing.Point(11, 99);
            this.jButton3.Name = "jButton3";
            this.jButton3.Size = new System.Drawing.Size(134, 25);
            this.jButton3.Style = JHUI.JColorStyle.Gold;
            this.jButton3.TabIndex = 2;
            this.jButton3.Text = "Show Shop Editor";
            this.jButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jButton3.Theme = JHUI.JThemeStyle.Dark;
            this.jButton3.UseSelectable = true;
            this.jButton3.UseVisualStyleBackColor = true;
            this.jButton3.Click += new System.EventHandler(this.ShowShopEditor);
            // 
            // SSA2
            // 
            this.SSA2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.SSA2.Name = "jContextMenu3";
            this.SSA2.Size = new System.Drawing.Size(160, 26);
            this.SSA2.Style = JHUI.JColorStyle.Gold;
            this.SSA2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem2.Text = "Start standalone";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(8, 22);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(32, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 3;
            this.jLabel1.Text = "Hello";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jProgressBar1
            // 
            this.jProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jProgressBar1.Location = new System.Drawing.Point(10, 192);
            this.jProgressBar1.Name = "jProgressBar1";
            this.jProgressBar1.ProgressTextType = JHUI.Controls.ProgressTextType.DONT_SHOW;
            this.jProgressBar1.Size = new System.Drawing.Size(134, 11);
            this.jProgressBar1.Style = JHUI.JColorStyle.Blue;
            this.jProgressBar1.TabIndex = 4;
            this.jProgressBar1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jButton4
            // 
            this.jButton4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton4.ContextMenuStrip = this.SSA3;
            this.jButton4.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton4.Location = new System.Drawing.Point(10, 161);
            this.jButton4.Name = "jButton4";
            this.jButton4.Size = new System.Drawing.Size(134, 25);
            this.jButton4.Style = JHUI.JColorStyle.Gold;
            this.jButton4.TabIndex = 5;
            this.jButton4.Text = "Show NPC Editor";
            this.jButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jButton4.Theme = JHUI.JThemeStyle.Dark;
            this.jButton4.UseSelectable = true;
            this.jButton4.UseVisualStyleBackColor = true;
            this.jButton4.Click += new System.EventHandler(this.ShowNpcEditor);
            // 
            // SSA3
            // 
            this.SSA3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.SSA3.Name = "jContextMenu3";
            this.SSA3.Size = new System.Drawing.Size(160, 26);
            this.SSA3.Style = JHUI.JColorStyle.Gold;
            this.SSA3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem3.Text = "Start standalone";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Location = new System.Drawing.Point(92, 40);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(23, 22);
            this.pictureBox6.Style = JHUI.JColorStyle.Gold;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.jPictureBox1.ContextMenuStrip = this.jContextMenu2;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(11, 40);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox1.TabIndex = 12;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.jPictureBox1_Click);
            // 
            // jContextMenu2
            // 
            this.jContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.policyEditorToolStripMenuItem,
            this.domainEditorToolStripMenuItem,
            this.pckEditorToolStripMenuItem,
            this.regionEditorToolStripMenuItem,
            this.precinctEditorToolStripMenuItem,
            this.worldTargetsEditorToolStripMenuItem,
            this.dynobjectsEditorToolStripMenuItem,
            this.dynTasksEditorToolStripMenuItem,
            this.extraDropEditorToolStripMenuItem,
            this.adminToolToolStripMenuItem});
            this.jContextMenu2.Name = "jContextMenu2";
            this.jContextMenu2.Size = new System.Drawing.Size(181, 246);
            this.jContextMenu2.Style = JHUI.JColorStyle.Gold;
            this.jContextMenu2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // policyEditorToolStripMenuItem
            // 
            this.policyEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandAloneToolStripMenuItem1});
            this.policyEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.policyEditorToolStripMenuItem.Name = "policyEditorToolStripMenuItem";
            this.policyEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.policyEditorToolStripMenuItem.Text = "Policy Editor";
            this.policyEditorToolStripMenuItem.Click += new System.EventHandler(this.ShowAiPolicyEditor);
            // 
            // startStandAloneToolStripMenuItem1
            // 
            this.startStandAloneToolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandAloneToolStripMenuItem1.Name = "startStandAloneToolStripMenuItem1";
            this.startStandAloneToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.startStandAloneToolStripMenuItem1.Text = "Start standalone";
            this.startStandAloneToolStripMenuItem1.Click += new System.EventHandler(this.startStandAloneToolStripMenuItem1_Click);
            // 
            // domainEditorToolStripMenuItem
            // 
            this.domainEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem2});
            this.domainEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.domainEditorToolStripMenuItem.Name = "domainEditorToolStripMenuItem";
            this.domainEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.domainEditorToolStripMenuItem.Text = "Domains Editor";
            this.domainEditorToolStripMenuItem.Click += new System.EventHandler(this.ShowDomainEditor);
            // 
            // startStandaloneToolStripMenuItem2
            // 
            this.startStandaloneToolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem2.Name = "startStandaloneToolStripMenuItem2";
            this.startStandaloneToolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem2.Text = "Start standalone";
            this.startStandaloneToolStripMenuItem2.Click += new System.EventHandler(this.startStandaloneToolStripMenuItem2_Click);
            // 
            // pckEditorToolStripMenuItem
            // 
            this.pckEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem3});
            this.pckEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.pckEditorToolStripMenuItem.Name = "pckEditorToolStripMenuItem";
            this.pckEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pckEditorToolStripMenuItem.Text = "Pck Editor";
            this.pckEditorToolStripMenuItem.Click += new System.EventHandler(this.ShowPackView);
            // 
            // startStandaloneToolStripMenuItem3
            // 
            this.startStandaloneToolStripMenuItem3.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem3.Name = "startStandaloneToolStripMenuItem3";
            this.startStandaloneToolStripMenuItem3.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem3.Text = "Start standalone";
            this.startStandaloneToolStripMenuItem3.Click += new System.EventHandler(this.startStandaloneToolStripMenuItem3_Click);
            // 
            // regionEditorToolStripMenuItem
            // 
            this.regionEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem4});
            this.regionEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.regionEditorToolStripMenuItem.Name = "regionEditorToolStripMenuItem";
            this.regionEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.regionEditorToolStripMenuItem.Text = "Region Editor";
            this.regionEditorToolStripMenuItem.Click += new System.EventHandler(this.regionEditorToolStripMenuItem_Click);
            // 
            // startStandaloneToolStripMenuItem4
            // 
            this.startStandaloneToolStripMenuItem4.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem4.Name = "startStandaloneToolStripMenuItem4";
            this.startStandaloneToolStripMenuItem4.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem4.Text = "Start standalone";
            this.startStandaloneToolStripMenuItem4.Click += new System.EventHandler(this.startStandaloneToolStripMenuItem4_Click);
            // 
            // precinctEditorToolStripMenuItem
            // 
            this.precinctEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem5});
            this.precinctEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.precinctEditorToolStripMenuItem.Name = "precinctEditorToolStripMenuItem";
            this.precinctEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.precinctEditorToolStripMenuItem.Text = "Precinct Editor";
            this.precinctEditorToolStripMenuItem.Click += new System.EventHandler(this.precinctEditorToolStripMenuItem_Click);
            // 
            // startStandaloneToolStripMenuItem5
            // 
            this.startStandaloneToolStripMenuItem5.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem5.Name = "startStandaloneToolStripMenuItem5";
            this.startStandaloneToolStripMenuItem5.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem5.Text = "Start standalone";
            this.startStandaloneToolStripMenuItem5.Click += new System.EventHandler(this.startStandaloneToolStripMenuItem5_Click);
            // 
            // worldTargetsEditorToolStripMenuItem
            // 
            this.worldTargetsEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem6});
            this.worldTargetsEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.worldTargetsEditorToolStripMenuItem.Name = "worldTargetsEditorToolStripMenuItem";
            this.worldTargetsEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.worldTargetsEditorToolStripMenuItem.Text = "WorldTargets Editor";
            this.worldTargetsEditorToolStripMenuItem.Click += new System.EventHandler(this.worldTargetsEditorToolStripMenuItem_Click);
            // 
            // startStandaloneToolStripMenuItem6
            // 
            this.startStandaloneToolStripMenuItem6.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem6.Name = "startStandaloneToolStripMenuItem6";
            this.startStandaloneToolStripMenuItem6.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem6.Text = "Start standalone";
            this.startStandaloneToolStripMenuItem6.Click += new System.EventHandler(this.startStandaloneToolStripMenuItem6_Click);
            // 
            // dynobjectsEditorToolStripMenuItem
            // 
            this.dynobjectsEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem7});
            this.dynobjectsEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.dynobjectsEditorToolStripMenuItem.Name = "dynobjectsEditorToolStripMenuItem";
            this.dynobjectsEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dynobjectsEditorToolStripMenuItem.Text = "Dynobjects Editor";
            this.dynobjectsEditorToolStripMenuItem.Click += new System.EventHandler(this.dynobjectsEditorToolStripMenuItem_Click);
            // 
            // startStandaloneToolStripMenuItem7
            // 
            this.startStandaloneToolStripMenuItem7.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem7.Name = "startStandaloneToolStripMenuItem7";
            this.startStandaloneToolStripMenuItem7.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem7.Text = "Start standalone";
            this.startStandaloneToolStripMenuItem7.Click += new System.EventHandler(this.startStandaloneToolStripMenuItem7_Click);
            // 
            // dynTasksEditorToolStripMenuItem
            // 
            this.dynTasksEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem8});
            this.dynTasksEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.dynTasksEditorToolStripMenuItem.Name = "dynTasksEditorToolStripMenuItem";
            this.dynTasksEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dynTasksEditorToolStripMenuItem.Text = "DynTasks Editor";
            // 
            // startStandaloneToolStripMenuItem8
            // 
            this.startStandaloneToolStripMenuItem8.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem8.Name = "startStandaloneToolStripMenuItem8";
            this.startStandaloneToolStripMenuItem8.Size = new System.Drawing.Size(180, 22);
            this.startStandaloneToolStripMenuItem8.Text = "Start standalone";
            // 
            // extraDropEditorToolStripMenuItem
            // 
            this.extraDropEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem9});
            this.extraDropEditorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.extraDropEditorToolStripMenuItem.Name = "extraDropEditorToolStripMenuItem";
            this.extraDropEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extraDropEditorToolStripMenuItem.Text = "Extra Drop Editor";
            this.extraDropEditorToolStripMenuItem.Click += new System.EventHandler(this.extraDropEditorToolStripMenuItem_Click);
            // 
            // startStandaloneToolStripMenuItem9
            // 
            this.startStandaloneToolStripMenuItem9.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem9.Name = "startStandaloneToolStripMenuItem9";
            this.startStandaloneToolStripMenuItem9.Size = new System.Drawing.Size(180, 22);
            this.startStandaloneToolStripMenuItem9.Text = "Start standalone";
            // 
            // adminToolToolStripMenuItem
            // 
            this.adminToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStandaloneToolStripMenuItem10});
            this.adminToolToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Send_message;
            this.adminToolToolStripMenuItem.Name = "adminToolToolStripMenuItem";
            this.adminToolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adminToolToolStripMenuItem.Text = "Admin Tool";
            // 
            // startStandaloneToolStripMenuItem10
            // 
            this.startStandaloneToolStripMenuItem10.Image = global::PWDataEditorPaied.Properties.Resources.Windows1;
            this.startStandaloneToolStripMenuItem10.Name = "startStandaloneToolStripMenuItem10";
            this.startStandaloneToolStripMenuItem10.Size = new System.Drawing.Size(159, 22);
            this.startStandaloneToolStripMenuItem10.Text = "Start standalone";
            // 
            // jLabel2
            // 
            this.jLabel2.AutoSize = true;
            this.jLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jLabel2.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.Location = new System.Drawing.Point(101, 210);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(43, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Gold;
            this.jLabel2.TabIndex = 13;
            this.jLabel2.Text = "© 2018";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel2.Click += new System.EventHandler(this.jLabel2_Click);
            // 
            // jLabel3
            // 
            this.jLabel3.AutoSize = true;
            this.jLabel3.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel3.FontSize = JHUI.JLabelSize.Small;
            this.jLabel3.Location = new System.Drawing.Point(8, 210);
            this.jLabel3.Name = "jLabel3";
            this.jLabel3.Size = new System.Drawing.Size(52, 15);
            this.jLabel3.Style = JHUI.JColorStyle.Gold;
            this.jLabel3.TabIndex = 14;
            this.jLabel3.Text = "Version 5";
            this.jLabel3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(121, 40);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox2.TabIndex = 16;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.jPictureBox2_Click);
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 231);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jLabel3);
            this.Controls.Add(this.jLabel2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.jButton4);
            this.Controls.Add(this.jProgressBar1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jButton3);
            this.Controls.Add(this.jButton2);
            this.Controls.Add(this.jButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainProgram";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainProgram_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainProgram_FormClosed);
            this.Shown += new System.EventHandler(this.MainProgram_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainProgram_ResizeEnd);
            this.Move += new System.EventHandler(this.MainProgram_Move);
            this.jContextMenu1.ResumeLayout(false);
            this.SSA0.ResumeLayout(false);
            this.SSA1.ResumeLayout(false);
            this.SSA2.ResumeLayout(false);
            this.SSA3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.jContextMenu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JButton jButton2;
        private JHUI.Controls.JButton jButton3;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JProgressBar jProgressBar1;
        private JHUI.Controls.JButton jButton4;
        private JHUI.Controls.JContextMenu jContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private JHUI.Controls.JPictureBox pictureBox6;
        private JHUI.Controls.JPictureBox jPictureBox1;
        private JHUI.Controls.JContextMenu jContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem policyEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem domainEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pckEditorToolStripMenuItem;
        private JHUI.Controls.JContextMenu SSA0;
        private System.Windows.Forms.ToolStripMenuItem startStandAloneToolStripMenuItem;
        private JHUI.Controls.JContextMenu SSA1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private JHUI.Controls.JContextMenu SSA2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private JHUI.Controls.JContextMenu SSA3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem startStandAloneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem resetLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private JHUI.Controls.JLabel jLabel2;
        private JHUI.Controls.JLabel jLabel3;
        private JHUI.Controls.JPictureBox jPictureBox2;
        private System.Windows.Forms.ToolStripMenuItem regionEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precinctEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem worldTargetsEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynobjectsEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem dynTasksEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem extraDropEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem adminToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStandaloneToolStripMenuItem10;
    }
}