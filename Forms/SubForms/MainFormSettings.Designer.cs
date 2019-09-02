namespace PWDataEditorPaied.Forms.SubForms
{
    partial class MainFormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormSettings));
            this.jCheckBox1 = new JHUI.Controls.JCheckBox();
            this.jComboBox1 = new JHUI.Controls.JComboBox();
            this.styleListBox = new JHUI.Controls.JComboBox();
            this.editorsListBox = new JHUI.Controls.JComboBox();
            this.jButton1 = new JHUI.Controls.JButton();
            this.jGroupBox1 = new JHUI.Controls.JGroupBox();
            this.jGroupBox2 = new JHUI.Controls.JGroupBox();
            this.jCheckBox5 = new JHUI.Controls.JCheckBox();
            this.jCheckBox4 = new JHUI.Controls.JCheckBox();
            this.jCheckBox3 = new JHUI.Controls.JCheckBox();
            this.jCheckBox2 = new JHUI.Controls.JCheckBox();
            this.jGroupBox1.SuspendLayout();
            this.jGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // jCheckBox1
            // 
            this.jCheckBox1.AutoSize = true;
            this.jCheckBox1.Location = new System.Drawing.Point(8, 43);
            this.jCheckBox1.Name = "jCheckBox1";
            this.jCheckBox1.Size = new System.Drawing.Size(193, 15);
            this.jCheckBox1.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox1.TabIndex = 0;
            this.jCheckBox1.Text = "Remember last window location";
            this.jCheckBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox1.UseSelectable = true;
            this.jCheckBox1.UseVisualStyleBackColor = true;
            this.jCheckBox1.CheckedChanged += new System.EventHandler(this.jCheckBox1_CheckedChanged);
            // 
            // jComboBox1
            // 
            this.jComboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.ItemHeight = 19;
            this.jComboBox1.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.jComboBox1.Location = new System.Drawing.Point(198, 22);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.PromptText = "Select Template";
            this.jComboBox1.Size = new System.Drawing.Size(132, 25);
            this.jComboBox1.Style = JHUI.JColorStyle.Blue;
            this.jComboBox1.TabIndex = 1;
            this.jComboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox1.UseSelectable = true;
            // 
            // styleListBox
            // 
            this.styleListBox.FontSize = JHUI.JComboBoxSize.Small;
            this.styleListBox.FormattingEnabled = true;
            this.styleListBox.ItemHeight = 19;
            this.styleListBox.Location = new System.Drawing.Point(336, 22);
            this.styleListBox.Name = "styleListBox";
            this.styleListBox.PromptText = "Select Color";
            this.styleListBox.Size = new System.Drawing.Size(118, 25);
            this.styleListBox.Style = JHUI.JColorStyle.Blue;
            this.styleListBox.TabIndex = 2;
            this.styleListBox.Theme = JHUI.JThemeStyle.Dark;
            this.styleListBox.UseSelectable = true;
            // 
            // editorsListBox
            // 
            this.editorsListBox.FontSize = JHUI.JComboBoxSize.Small;
            this.editorsListBox.FormattingEnabled = true;
            this.editorsListBox.ItemHeight = 19;
            this.editorsListBox.Location = new System.Drawing.Point(8, 22);
            this.editorsListBox.Name = "editorsListBox";
            this.editorsListBox.PromptText = "Select Editor";
            this.editorsListBox.Size = new System.Drawing.Size(184, 25);
            this.editorsListBox.Style = JHUI.JColorStyle.Blue;
            this.editorsListBox.TabIndex = 3;
            this.editorsListBox.Theme = JHUI.JThemeStyle.Dark;
            this.editorsListBox.UseSelectable = true;
            this.editorsListBox.SelectedIndexChanged += new System.EventHandler(this.editorsListBox_SelectedIndexChanged);
            // 
            // jButton1
            // 
            this.jButton1.Location = new System.Drawing.Point(471, 23);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(75, 23);
            this.jButton1.Style = JHUI.JColorStyle.Blue;
            this.jButton1.TabIndex = 4;
            this.jButton1.Text = "Apply";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // jGroupBox1
            // 
            this.jGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox1.Controls.Add(this.jButton1);
            this.jGroupBox1.Controls.Add(this.jComboBox1);
            this.jGroupBox1.Controls.Add(this.editorsListBox);
            this.jGroupBox1.Controls.Add(this.styleListBox);
            this.jGroupBox1.DrawBottomLine = false;
            this.jGroupBox1.DrawShadows = false;
            this.jGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox1.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jGroupBox1.Location = new System.Drawing.Point(23, 164);
            this.jGroupBox1.Name = "jGroupBox1";
            this.jGroupBox1.PaintDefault = false;
            this.jGroupBox1.Size = new System.Drawing.Size(552, 70);
            this.jGroupBox1.Style = JHUI.JColorStyle.Blue;
            this.jGroupBox1.StyleManager = null;
            this.jGroupBox1.TabIndex = 5;
            this.jGroupBox1.TabStop = false;
            this.jGroupBox1.Text = "Skins";
            this.jGroupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox1.UseStyleColors = false;
            // 
            // jGroupBox2
            // 
            this.jGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.jGroupBox2.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.jGroupBox2.Controls.Add(this.jCheckBox5);
            this.jGroupBox2.Controls.Add(this.jCheckBox4);
            this.jGroupBox2.Controls.Add(this.jCheckBox3);
            this.jGroupBox2.Controls.Add(this.jCheckBox2);
            this.jGroupBox2.Controls.Add(this.jCheckBox1);
            this.jGroupBox2.DrawBottomLine = false;
            this.jGroupBox2.DrawShadows = false;
            this.jGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.jGroupBox2.FontSize = JHUI.JLabelSize.Small;
            this.jGroupBox2.FontWeight = JHUI.JLabelWeight.Light;
            this.jGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jGroupBox2.Location = new System.Drawing.Point(23, 59);
            this.jGroupBox2.Name = "jGroupBox2";
            this.jGroupBox2.PaintDefault = false;
            this.jGroupBox2.Size = new System.Drawing.Size(552, 99);
            this.jGroupBox2.Style = JHUI.JColorStyle.Blue;
            this.jGroupBox2.StyleManager = null;
            this.jGroupBox2.TabIndex = 6;
            this.jGroupBox2.TabStop = false;
            this.jGroupBox2.Text = "Preferences";
            this.jGroupBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jGroupBox2.UseStyleColors = false;
            // 
            // jCheckBox5
            // 
            this.jCheckBox5.AutoSize = true;
            this.jCheckBox5.Location = new System.Drawing.Point(8, 64);
            this.jCheckBox5.Name = "jCheckBox5";
            this.jCheckBox5.Size = new System.Drawing.Size(175, 15);
            this.jCheckBox5.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox5.TabIndex = 4;
            this.jCheckBox5.Text = "Show element editor on start";
            this.jCheckBox5.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox5.UseSelectable = true;
            this.jCheckBox5.UseVisualStyleBackColor = true;
            this.jCheckBox5.CheckedChanged += new System.EventHandler(this.jCheckBox5_CheckedChanged);
            // 
            // jCheckBox4
            // 
            this.jCheckBox4.AutoSize = true;
            this.jCheckBox4.Location = new System.Drawing.Point(278, 43);
            this.jCheckBox4.Name = "jCheckBox4";
            this.jCheckBox4.Size = new System.Drawing.Size(240, 15);
            this.jCheckBox4.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox4.TabIndex = 3;
            this.jCheckBox4.Text = "Hide editor from TaskBar on close button";
            this.jCheckBox4.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox4.UseSelectable = true;
            this.jCheckBox4.UseVisualStyleBackColor = true;
            this.jCheckBox4.CheckedChanged += new System.EventHandler(this.jCheckBox4_CheckedChanged);
            // 
            // jCheckBox3
            // 
            this.jCheckBox3.AutoSize = true;
            this.jCheckBox3.Location = new System.Drawing.Point(278, 22);
            this.jCheckBox3.Name = "jCheckBox3";
            this.jCheckBox3.Size = new System.Drawing.Size(191, 15);
            this.jCheckBox3.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox3.TabIndex = 2;
            this.jCheckBox3.Text = "Display editors minimize button";
            this.jCheckBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox3.UseSelectable = true;
            this.jCheckBox3.UseVisualStyleBackColor = true;
            this.jCheckBox3.CheckedChanged += new System.EventHandler(this.jCheckBox3_CheckedChanged);
            // 
            // jCheckBox2
            // 
            this.jCheckBox2.AutoSize = true;
            this.jCheckBox2.Checked = true;
            this.jCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jCheckBox2.Location = new System.Drawing.Point(8, 22);
            this.jCheckBox2.Name = "jCheckBox2";
            this.jCheckBox2.Size = new System.Drawing.Size(98, 15);
            this.jCheckBox2.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox2.TabIndex = 1;
            this.jCheckBox2.Text = "Always on top";
            this.jCheckBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox2.UseSelectable = true;
            this.jCheckBox2.UseVisualStyleBackColor = true;
            this.jCheckBox2.CheckedChanged += new System.EventHandler(this.jCheckBox2_CheckedChanged);
            // 
            // MainFormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 235);
            this.Controls.Add(this.jGroupBox2);
            this.Controls.Add(this.jGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFormSettings";
            this.Resizable = false;
            this.Style = JHUI.JColorStyle.Blue;
            this.Text = "Main Settings";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.MainFormSettings_Shown);
            this.jGroupBox1.ResumeLayout(false);
            this.jGroupBox2.ResumeLayout(false);
            this.jGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JCheckBox jCheckBox1;
        private JHUI.Controls.JComboBox jComboBox1;
        private JHUI.Controls.JComboBox styleListBox;
        private JHUI.Controls.JComboBox editorsListBox;
        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JGroupBox jGroupBox1;
        private JHUI.Controls.JGroupBox jGroupBox2;
        private JHUI.Controls.JCheckBox jCheckBox2;
        private JHUI.Controls.JCheckBox jCheckBox4;
        private JHUI.Controls.JCheckBox jCheckBox3;
        private JHUI.Controls.JCheckBox jCheckBox5;
    }
}