using JHUI.Controls;

namespace Pck_Guy_View
{
    partial class PackView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackView));
            this.groupBox3 = new JHUI.Controls.JGroupBox();
            this.FileList = new JHUI.Controls.JListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new JHUI.Controls.JProgressBar();
            this.progres = new JHUI.Controls.JLabel();
            this.groupBox1 = new JHUI.Controls.JGroupBox();
            this.label_path = new JHUI.Controls.JLabel();
            this.label11 = new JHUI.Controls.JLabel();
            this.label_comp = new JHUI.Controls.JLabel();
            this.label9 = new JHUI.Controls.JLabel();
            this.label_files = new JHUI.Controls.JLabel();
            this.label6 = new JHUI.Controls.JLabel();
            this.pictureBox6 = new JHUI.Controls.JPictureBox();
            this.pictureBox2 = new JHUI.Controls.JPictureBox();
            this.RewritePackBox = new JHUI.Controls.JPictureBox();
            this.SavePackBox = new JHUI.Controls.JPictureBox();
            this.pictureBox1 = new JHUI.Controls.JPictureBox();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jComboBox1 = new JHUI.Controls.JComboBox();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RewritePackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox3.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox3.Controls.Add(this.FileList);
            this.groupBox3.DrawBottomLine = false;
            this.groupBox3.DrawShadows = false;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox3.FontSize = JHUI.JLabelSize.Small;
            this.groupBox3.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Location = new System.Drawing.Point(1, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.PaintDefault = false;
            this.groupBox3.Size = new System.Drawing.Size(953, 541);
            this.groupBox3.Style = JHUI.JColorStyle.Gold;
            this.groupBox3.StyleManager = null;
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Files";
            this.groupBox3.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox3.UseStyleColors = false;
            // 
            // FileList
            // 
            this.FileList.AllowDrop = true;
            this.FileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.FileList.ContextMenuStrip = this.contextMenuStrip1;
            this.FileList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FileList.FullRowSelect = true;
            this.FileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FileList.Location = new System.Drawing.Point(6, 23);
            this.FileList.Name = "FileList";
            this.FileList.OwnerDraw = true;
            this.FileList.Size = new System.Drawing.Size(941, 512);
            this.FileList.Style = JHUI.JColorStyle.White;
            this.FileList.TabIndex = 72;
            this.FileList.Theme = JHUI.JThemeStyle.Dark;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.UseSelectable = true;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.FileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop_1);
            this.FileList.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver_1);
            this.FileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            this.FileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CSize";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "NSize";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CRatio";
            this.columnHeader4.Width = 160;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.extractToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 76);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Refresh2;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Unpack;
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.extractToolStripMenuItem.Text = "Extract";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.UnpackDirectoryOrFiles);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(8, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(940, 20);
            this.textBox1.TabIndex = 72;
            this.textBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(7, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(940, 20);
            this.progressBar1.Style = JHUI.JColorStyle.White;
            this.progressBar1.TabIndex = 67;
            this.progressBar1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // progres
            // 
            this.progres.AutoSize = true;
            this.progres.DropShadowColor = System.Drawing.Color.Black;
            this.progres.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.progres.FontSize = JHUI.JLabelSize.Small;
            this.progres.Location = new System.Drawing.Point(4, 15);
            this.progres.Name = "progres";
            this.progres.Size = new System.Drawing.Size(38, 15);
            this.progres.Style = JHUI.JColorStyle.Gold;
            this.progres.TabIndex = 68;
            this.progres.Text = "Ready";
            this.progres.Theme = JHUI.JThemeStyle.Dark;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox1.Controls.Add(this.label_path);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label_comp);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label_files);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.progres);
            this.groupBox1.DrawBottomLine = false;
            this.groupBox1.DrawShadows = false;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.FontSize = JHUI.JLabelSize.Small;
            this.groupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(1, 636);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.PaintDefault = false;
            this.groupBox1.Size = new System.Drawing.Size(953, 70);
            this.groupBox1.Style = JHUI.JColorStyle.Gold;
            this.groupBox1.StyleManager = null;
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            this.groupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox1.UseStyleColors = false;
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.DropShadowColor = System.Drawing.Color.Black;
            this.label_path.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_path.FontSize = JHUI.JLabelSize.Small;
            this.label_path.Location = new System.Drawing.Point(37, 55);
            this.label_path.MinimumSize = new System.Drawing.Size(55, 13);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(55, 15);
            this.label_path.Style = JHUI.JColorStyle.Gold;
            this.label_path.TabIndex = 75;
            this.label_path.Text = " ";
            this.label_path.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.DropShadowColor = System.Drawing.Color.Black;
            this.label11.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label11.FontSize = JHUI.JLabelSize.Small;
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.Style = JHUI.JColorStyle.Gold;
            this.label11.TabIndex = 74;
            this.label11.Text = "Path:";
            this.label11.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_comp
            // 
            this.label_comp.AutoSize = true;
            this.label_comp.DropShadowColor = System.Drawing.Color.Black;
            this.label_comp.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_comp.FontSize = JHUI.JLabelSize.Small;
            this.label_comp.Location = new System.Drawing.Point(656, 55);
            this.label_comp.MinimumSize = new System.Drawing.Size(55, 13);
            this.label_comp.Name = "label_comp";
            this.label_comp.Size = new System.Drawing.Size(13, 15);
            this.label_comp.Style = JHUI.JColorStyle.Gold;
            this.label_comp.TabIndex = 73;
            this.label_comp.Text = "0";
            this.label_comp.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DropShadowColor = System.Drawing.Color.Black;
            this.label9.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label9.FontSize = JHUI.JLabelSize.Small;
            this.label9.Location = new System.Drawing.Point(559, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 15);
            this.label9.Style = JHUI.JColorStyle.Gold;
            this.label9.TabIndex = 72;
            this.label9.Text = "Compression Level:";
            this.label9.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label_files
            // 
            this.label_files.AutoSize = true;
            this.label_files.DropShadowColor = System.Drawing.Color.Black;
            this.label_files.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label_files.FontSize = JHUI.JLabelSize.Small;
            this.label_files.Location = new System.Drawing.Point(460, 55);
            this.label_files.MinimumSize = new System.Drawing.Size(55, 13);
            this.label_files.Name = "label_files";
            this.label_files.Size = new System.Drawing.Size(13, 15);
            this.label_files.Style = JHUI.JColorStyle.Gold;
            this.label_files.TabIndex = 71;
            this.label_files.Text = "0";
            this.label_files.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DropShadowColor = System.Drawing.Color.Black;
            this.label6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label6.FontSize = JHUI.JLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(430, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.Style = JHUI.JColorStyle.Gold;
            this.label6.TabIndex = 70;
            this.label6.Text = "Files:";
            this.label6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Location = new System.Drawing.Point(925, 28);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(23, 22);
            this.pictureBox6.Style = JHUI.JColorStyle.Gold;
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox6.Click += new System.EventHandler(this.openSettings);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(230, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 22);
            this.pictureBox2.Style = JHUI.JColorStyle.Gold;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // RewritePackBox
            // 
            this.RewritePackBox.BackColor = System.Drawing.Color.Transparent;
            this.RewritePackBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RewritePackBox.BackgroundImage")));
            this.RewritePackBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RewritePackBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RewritePackBox.Location = new System.Drawing.Point(201, 28);
            this.RewritePackBox.Name = "RewritePackBox";
            this.RewritePackBox.Size = new System.Drawing.Size(23, 22);
            this.RewritePackBox.Style = JHUI.JColorStyle.Gold;
            this.RewritePackBox.TabIndex = 4;
            this.RewritePackBox.TabStop = false;
            this.RewritePackBox.Theme = JHUI.JThemeStyle.Dark;
            this.RewritePackBox.Click += new System.EventHandler(this.RewritePackBox_Click);
            // 
            // SavePackBox
            // 
            this.SavePackBox.BackColor = System.Drawing.Color.Transparent;
            this.SavePackBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SavePackBox.BackgroundImage")));
            this.SavePackBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SavePackBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SavePackBox.Location = new System.Drawing.Point(172, 28);
            this.SavePackBox.Name = "SavePackBox";
            this.SavePackBox.Size = new System.Drawing.Size(23, 22);
            this.SavePackBox.Style = JHUI.JColorStyle.Gold;
            this.SavePackBox.TabIndex = 2;
            this.SavePackBox.TabStop = false;
            this.SavePackBox.Theme = JHUI.JThemeStyle.Dark;
            this.SavePackBox.Click += new System.EventHandler(this.SavePackBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(143, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.Style = JHUI.JColorStyle.Gold;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(259, 28);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox1.TabIndex = 75;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.jPictureBox1_Click);
            // 
            // jComboBox1
            // 
            this.jComboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jComboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.ItemHeight = 19;
            this.jComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.jComboBox1.Location = new System.Drawing.Point(798, 28);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.Size = new System.Drawing.Size(121, 25);
            this.jComboBox1.Style = JHUI.JColorStyle.Silver;
            this.jComboBox1.TabIndex = 77;
            this.jComboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox1.UseSelectable = true;
            this.jComboBox1.SelectedIndexChanged += new System.EventHandler(this.jComboBox1_SelectedIndexChanged);
            // 
            // PackView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.BorderStyle = JHUI.Forms.JFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jComboBox1);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.SavePackBox);
            this.Controls.Add(this.RewritePackBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PackView";
            this.Opacity = 0D;
            this.Text = "Pack Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackView_FormClosing);
            this.Shown += new System.EventHandler(this.PackView_Shown);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RewritePackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SavePackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JGroupBox groupBox3;
        private JProgressBar progressBar1;
        private JLabel progres;
        private JGroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private JPictureBox pictureBox1;
        private JPictureBox RewritePackBox;
        private JPictureBox SavePackBox;
        private JPictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private JPictureBox pictureBox6;
        private JLabel label_path;
        private JLabel label11;
        private JLabel label_comp;
        private JLabel label9;
        private JLabel label_files;
        private JLabel label6;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private JListView FileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private JPictureBox jPictureBox1;
        private JComboBox jComboBox1;
    }
}