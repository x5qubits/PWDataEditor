namespace PWDataEditorPaied.Forms
{
    partial class ElementSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementSettings));
            this.AutoNextId = new JHUI.Controls.JToggle();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.AutoLoadPck = new JHUI.Controls.JToggle();
            this.minNextId = new JHUI.Controls.JTextBox();
            this.jLabel3 = new JHUI.Controls.JLabel();
            this.maxNextId = new JHUI.Controls.JTextBox();
            this.jLabel4 = new JHUI.Controls.JLabel();
            this.jPictureBox3 = new JHUI.Controls.JPictureBox();
            this.jLabel5 = new JHUI.Controls.JLabel();
            this.jToggle1 = new JHUI.Controls.JToggle();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // AutoNextId
            // 
            this.AutoNextId.AutoSize = true;
            this.AutoNextId.Location = new System.Drawing.Point(309, 63);
            this.AutoNextId.Name = "AutoNextId";
            this.AutoNextId.Size = new System.Drawing.Size(80, 17);
            this.AutoNextId.Style = JHUI.JColorStyle.Blue;
            this.AutoNextId.TabIndex = 0;
            this.AutoNextId.Text = "&Off";
            this.AutoNextId.Theme = JHUI.JThemeStyle.Dark;
            this.AutoNextId.UseSelectable = true;
            this.AutoNextId.UseVisualStyleBackColor = true;
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(23, 61);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(239, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 1;
            this.jLabel1.Text = "Automatically assign new id\'s to importd items";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel2
            // 
            this.jLabel2.AutoSize = true;
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.Location = new System.Drawing.Point(23, 84);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(230, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Gold;
            this.jLabel2.TabIndex = 3;
            this.jLabel2.Text = "Automatically detect and load pck config files";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // AutoLoadPck
            // 
            this.AutoLoadPck.AutoSize = true;
            this.AutoLoadPck.Checked = true;
            this.AutoLoadPck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoLoadPck.Location = new System.Drawing.Point(309, 86);
            this.AutoLoadPck.Name = "AutoLoadPck";
            this.AutoLoadPck.Size = new System.Drawing.Size(80, 17);
            this.AutoLoadPck.Style = JHUI.JColorStyle.Blue;
            this.AutoLoadPck.TabIndex = 2;
            this.AutoLoadPck.Text = "&On";
            this.AutoLoadPck.Theme = JHUI.JThemeStyle.Dark;
            this.AutoLoadPck.UseSelectable = true;
            this.AutoLoadPck.UseVisualStyleBackColor = true;
            // 
            // minNextId
            // 
            // 
            // 
            // 
            this.minNextId.CustomButton.Image = null;
            this.minNextId.CustomButton.Location = new System.Drawing.Point(45, 1);
            this.minNextId.CustomButton.Name = "";
            this.minNextId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.minNextId.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.minNextId.CustomButton.TabIndex = 1;
            this.minNextId.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.minNextId.CustomButton.UseSelectable = true;
            this.minNextId.CustomButton.Visible = false;
            this.minNextId.Lines = new string[] {
        "1"};
            this.minNextId.Location = new System.Drawing.Point(191, 142);
            this.minNextId.MaxLength = 32767;
            this.minNextId.Name = "minNextId";
            this.minNextId.PasswordChar = '\0';
            this.minNextId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.minNextId.SelectedText = "";
            this.minNextId.SelectionLength = 0;
            this.minNextId.SelectionStart = 0;
            this.minNextId.ShortcutsEnabled = true;
            this.minNextId.Size = new System.Drawing.Size(67, 23);
            this.minNextId.Style = JHUI.JColorStyle.Blue;
            this.minNextId.TabIndex = 4;
            this.minNextId.Text = "1";
            this.minNextId.TextWaterMark = "";
            this.minNextId.Theme = JHUI.JThemeStyle.Dark;
            this.minNextId.UseSelectable = true;
            this.minNextId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.minNextId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.minNextId.TextChanged += new System.EventHandler(this.minNextId_TextChanged);
            // 
            // jLabel3
            // 
            this.jLabel3.AutoSize = true;
            this.jLabel3.FontSize = JHUI.JLabelSize.Small;
            this.jLabel3.Location = new System.Drawing.Point(26, 145);
            this.jLabel3.Name = "jLabel3";
            this.jLabel3.Size = new System.Drawing.Size(131, 15);
            this.jLabel3.Style = JHUI.JColorStyle.Gold;
            this.jLabel3.TabIndex = 5;
            this.jLabel3.Text = "Search from free id from:";
            this.jLabel3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // maxNextId
            // 
            // 
            // 
            // 
            this.maxNextId.CustomButton.Image = null;
            this.maxNextId.CustomButton.Location = new System.Drawing.Point(41, 1);
            this.maxNextId.CustomButton.Name = "";
            this.maxNextId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.maxNextId.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.maxNextId.CustomButton.TabIndex = 1;
            this.maxNextId.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.maxNextId.CustomButton.UseSelectable = true;
            this.maxNextId.CustomButton.Visible = false;
            this.maxNextId.Lines = new string[] {
        "80000"};
            this.maxNextId.Location = new System.Drawing.Point(294, 142);
            this.maxNextId.MaxLength = 32767;
            this.maxNextId.Name = "maxNextId";
            this.maxNextId.PasswordChar = '\0';
            this.maxNextId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.maxNextId.SelectedText = "";
            this.maxNextId.SelectionLength = 0;
            this.maxNextId.SelectionStart = 0;
            this.maxNextId.ShortcutsEnabled = true;
            this.maxNextId.Size = new System.Drawing.Size(63, 23);
            this.maxNextId.Style = JHUI.JColorStyle.Blue;
            this.maxNextId.TabIndex = 6;
            this.maxNextId.Text = "80000";
            this.maxNextId.TextWaterMark = "";
            this.maxNextId.Theme = JHUI.JThemeStyle.Dark;
            this.maxNextId.UseSelectable = true;
            this.maxNextId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.maxNextId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.maxNextId.TextChanged += new System.EventHandler(this.maxNextId_TextChanged);
            // 
            // jLabel4
            // 
            this.jLabel4.AutoSize = true;
            this.jLabel4.FontSize = JHUI.JLabelSize.Small;
            this.jLabel4.Location = new System.Drawing.Point(264, 145);
            this.jLabel4.Name = "jLabel4";
            this.jLabel4.Size = new System.Drawing.Size(18, 15);
            this.jLabel4.Style = JHUI.JColorStyle.Gold;
            this.jLabel4.TabIndex = 7;
            this.jLabel4.Text = "to";
            this.jLabel4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jPictureBox3
            // 
            this.jPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox3.BackgroundImage")));
            this.jPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox3.Location = new System.Drawing.Point(366, 142);
            this.jPictureBox3.Name = "jPictureBox3";
            this.jPictureBox3.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox3.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox3.TabIndex = 36;
            this.jPictureBox3.TabStop = false;
            this.jPictureBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox3.Click += new System.EventHandler(this.jPictureBox3_Click);
            // 
            // jLabel5
            // 
            this.jLabel5.AutoSize = true;
            this.jLabel5.FontSize = JHUI.JLabelSize.Small;
            this.jLabel5.Location = new System.Drawing.Point(23, 107);
            this.jLabel5.Name = "jLabel5";
            this.jLabel5.Size = new System.Drawing.Size(182, 15);
            this.jLabel5.Style = JHUI.JColorStyle.Gold;
            this.jLabel5.TabIndex = 38;
            this.jLabel5.Text = "Register file association to windows";
            this.jLabel5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jToggle1
            // 
            this.jToggle1.AutoSize = true;
            this.jToggle1.Location = new System.Drawing.Point(309, 109);
            this.jToggle1.Name = "jToggle1";
            this.jToggle1.Size = new System.Drawing.Size(80, 17);
            this.jToggle1.Style = JHUI.JColorStyle.Blue;
            this.jToggle1.TabIndex = 37;
            this.jToggle1.Text = "&Off";
            this.jToggle1.Theme = JHUI.JThemeStyle.Dark;
            this.jToggle1.UseSelectable = true;
            this.jToggle1.UseVisualStyleBackColor = true;
            this.jToggle1.CheckedChanged += new System.EventHandler(this.jToggle1_CheckedChanged);
            // 
            // ElementSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 234);
            this.Controls.Add(this.jLabel5);
            this.Controls.Add(this.jToggle1);
            this.Controls.Add(this.jPictureBox3);
            this.Controls.Add(this.jLabel4);
            this.Controls.Add(this.maxNextId);
            this.Controls.Add(this.jLabel3);
            this.Controls.Add(this.minNextId);
            this.Controls.Add(this.jLabel2);
            this.Controls.Add(this.AutoLoadPck);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.AutoNextId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(426, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(426, 234);
            this.Name = "ElementSettings";
            this.Resizable = false;
            this.Style = JHUI.JColorStyle.Orange;
            this.Text = "Element Editor Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElementSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JToggle AutoNextId;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JLabel jLabel2;
        private JHUI.Controls.JToggle AutoLoadPck;
        private JHUI.Controls.JTextBox minNextId;
        private JHUI.Controls.JLabel jLabel3;
        private JHUI.Controls.JTextBox maxNextId;
        private JHUI.Controls.JLabel jLabel4;
        private JHUI.Controls.JPictureBox jPictureBox3;
        private JHUI.Controls.JLabel jLabel5;
        private JHUI.Controls.JToggle jToggle1;
    }
}