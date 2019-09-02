namespace ElementEditor
{
    partial class ImageChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageChange));
            this.panel1 = new System.Windows.Forms.Panel();
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.addImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jTextBox1 = new JHUI.Controls.JTextBox();
            this.jTextBox2 = new JHUI.Controls.JTextBox();
            this.panel1.SuspendLayout();
            this.jContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.ContextMenuStrip = this.jContextMenu1;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 438);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addImageToolStripMenuItem,
            this.deleteImageToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(181, 92);
            this.jContextMenu1.Style = JHUI.JColorStyle.White;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            this.jContextMenu1.Opening += new System.ComponentModel.CancelEventHandler(this.jContextMenu1_Opening);
            // 
            // addImageToolStripMenuItem
            // 
            this.addImageToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
            this.addImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addImageToolStripMenuItem.Text = "Add Image";
            this.addImageToolStripMenuItem.Click += new System.EventHandler(this.addImageToolStripMenuItem_Click);
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.delete;
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            this.deleteImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteImageToolStripMenuItem.Text = "Delete Image";
            this.deleteImageToolStripMenuItem.Click += new System.EventHandler(this.deleteImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.save_as;
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ContextMenuStrip = this.jContextMenu1;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 441);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(512, 478);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(108, 27);
            this.button8.TabIndex = 35;
            this.button8.Text = "Use icon";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(30, 5);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox2.TabIndex = 45;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.jPictureBox2_Click);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(1, 5);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox1.TabIndex = 44;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.jPictureBox1_Click);
            // 
            // jTextBox1
            // 
            this.jTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jTextBox1.BorderBottomLineSize = 5;
            this.jTextBox1.BorderColor = System.Drawing.Color.Black;
            this.jTextBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.jTextBox1.CustomButton.Image = global::PWDataEditorPaied.Properties.Resources.save_as;
            this.jTextBox1.CustomButton.Location = new System.Drawing.Point(252, 1);
            this.jTextBox1.CustomButton.Name = "";
            this.jTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.jTextBox1.CustomButton.TabIndex = 1;
            this.jTextBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.CustomButton.UseSelectable = true;
            this.jTextBox1.DrawBorder = true;
            this.jTextBox1.DrawBorderBottomLine = false;
            this.jTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.Lines = new string[0];
            this.jTextBox1.Location = new System.Drawing.Point(232, 480);
            this.jTextBox1.MaxLength = 32767;
            this.jTextBox1.Name = "jTextBox1";
            this.jTextBox1.PasswordChar = '\0';
            this.jTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox1.SelectedText = "";
            this.jTextBox1.SelectionLength = 0;
            this.jTextBox1.SelectionStart = 0;
            this.jTextBox1.ShortcutsEnabled = true;
            this.jTextBox1.ShowButton = true;
            this.jTextBox1.Size = new System.Drawing.Size(274, 23);
            this.jTextBox1.Style = JHUI.JColorStyle.White;
            this.jTextBox1.TabIndex = 49;
            this.jTextBox1.TextWaterMark = "";
            this.jTextBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox1.UseCustomFont = true;
            this.jTextBox1.UseSelectable = true;
            this.jTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox1.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.jTextBox1_ButtonClick);
            // 
            // jTextBox2
            // 
            this.jTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jTextBox2.BorderBottomLineSize = 5;
            this.jTextBox2.BorderColor = System.Drawing.Color.Black;
            this.jTextBox2.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.jTextBox2.CustomButton.Image = global::PWDataEditorPaied.Properties.Resources.FindPlus;
            this.jTextBox2.CustomButton.Location = new System.Drawing.Point(194, 1);
            this.jTextBox2.CustomButton.Name = "";
            this.jTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.jTextBox2.CustomButton.Style = JHUI.JColorStyle.White;
            this.jTextBox2.CustomButton.TabIndex = 1;
            this.jTextBox2.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox2.CustomButton.UseSelectable = true;
            this.jTextBox2.DrawBorder = true;
            this.jTextBox2.DrawBorderBottomLine = false;
            this.jTextBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox2.Lines = new string[0];
            this.jTextBox2.Location = new System.Drawing.Point(10, 480);
            this.jTextBox2.MaxLength = 32767;
            this.jTextBox2.Name = "jTextBox2";
            this.jTextBox2.PasswordChar = '\0';
            this.jTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jTextBox2.SelectedText = "";
            this.jTextBox2.SelectionLength = 0;
            this.jTextBox2.SelectionStart = 0;
            this.jTextBox2.ShortcutsEnabled = true;
            this.jTextBox2.ShowButton = true;
            this.jTextBox2.Size = new System.Drawing.Size(216, 23);
            this.jTextBox2.Style = JHUI.JColorStyle.White;
            this.jTextBox2.TabIndex = 54;
            this.jTextBox2.TextWaterMark = "";
            this.jTextBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jTextBox2.UseCustomFont = true;
            this.jTextBox2.UseSelectable = true;
            this.jTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.jTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.jTextBox2.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.jTextBox2_ButtonClick);
            // 
            // ImageChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(634, 524);
            this.Controls.Add(this.jTextBox2);
            this.Controls.Add(this.jTextBox1);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Blue;
            this.Shown += new System.EventHandler(this.ImageChange_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.jContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button8;
        private JHUI.Controls.JPictureBox jPictureBox2;
        private JHUI.Controls.JPictureBox jPictureBox1;
        private JHUI.Controls.JTextBox jTextBox1;
        private JHUI.Controls.JContextMenu jContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private JHUI.Controls.JTextBox jTextBox2;
        private System.Windows.Forms.ToolStripMenuItem addImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
    }
}