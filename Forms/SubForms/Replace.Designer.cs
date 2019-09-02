namespace PWDataEditorPaied.Forms
{
    partial class Replace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replace));
            this.jButton1 = new JHUI.Controls.JButton();
            this.textBox_newValue = new JHUI.Controls.JTextBox();
            this.replaceSelected = new JHUI.Controls.JComboBox();
            this.textBox_oldValue = new JHUI.Controls.JTextBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jLabel2 = new JHUI.Controls.JLabel();
            this.jLabel3 = new JHUI.Controls.JLabel();
            this.jLabel4 = new JHUI.Controls.JLabel();
            this.jToolTip1 = new JHUI.Components.JToolTip();
            this.SuspendLayout();
            // 
            // jButton1
            // 
            this.jButton1.Location = new System.Drawing.Point(87, 151);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(489, 23);
            this.jButton1.Style = JHUI.JColorStyle.Gold;
            this.jButton1.TabIndex = 34;
            this.jButton1.Text = "Do It";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // textBox_newValue
            // 
            this.textBox_newValue.BorderBottomLineSize = 5;
            this.textBox_newValue.BorderColor = System.Drawing.Color.Black;
            this.textBox_newValue.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_newValue.CustomButton.Image = null;
            this.textBox_newValue.CustomButton.Location = new System.Drawing.Point(465, 1);
            this.textBox_newValue.CustomButton.Name = "";
            this.textBox_newValue.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox_newValue.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_newValue.CustomButton.TabIndex = 1;
            this.textBox_newValue.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_newValue.CustomButton.UseSelectable = true;
            this.textBox_newValue.CustomButton.Visible = false;
            this.textBox_newValue.DrawBorder = true;
            this.textBox_newValue.DrawBorderBottomLine = false;
            this.textBox_newValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_newValue.Lines = new string[] {
        "models\\$2"};
            this.textBox_newValue.Location = new System.Drawing.Point(87, 117);
            this.textBox_newValue.MaxLength = 32767;
            this.textBox_newValue.Name = "textBox_newValue";
            this.textBox_newValue.PasswordChar = '\0';
            this.textBox_newValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_newValue.SelectedText = "";
            this.textBox_newValue.SelectionLength = 0;
            this.textBox_newValue.SelectionStart = 0;
            this.textBox_newValue.ShortcutsEnabled = true;
            this.textBox_newValue.Size = new System.Drawing.Size(489, 25);
            this.textBox_newValue.Style = JHUI.JColorStyle.Blue;
            this.textBox_newValue.TabIndex = 33;
            this.textBox_newValue.TabStop = false;
            this.textBox_newValue.Text = "models\\$2";
            this.textBox_newValue.TextWaterMark = "";
            this.textBox_newValue.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_newValue.UseCustomFont = true;
            this.textBox_newValue.UseSelectable = true;
            this.textBox_newValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_newValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_newValue.TextChanged += new System.EventHandler(this.textBox_newValue_TextChanged);
            // 
            // replaceSelected
            // 
            this.replaceSelected.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.replaceSelected.FontSize = JHUI.JComboBoxSize.Small;
            this.replaceSelected.FormattingEnabled = true;
            this.replaceSelected.ItemHeight = 19;
            this.replaceSelected.Items.AddRange(new object[] {
            "Replace",
            "Multiply",
            "Divide",
            "Add",
            "Extract",
            "Regex",
            "Replace If Bigger",
            "Replace If Smaller"});
            this.replaceSelected.Location = new System.Drawing.Point(197, 27);
            this.replaceSelected.Name = "replaceSelected";
            this.replaceSelected.Size = new System.Drawing.Size(379, 25);
            this.replaceSelected.Style = JHUI.JColorStyle.Blue;
            this.replaceSelected.TabIndex = 32;
            this.replaceSelected.TabStop = false;
            this.replaceSelected.Theme = JHUI.JThemeStyle.Dark;
            this.replaceSelected.UseSelectable = true;
            this.replaceSelected.SelectedIndexChanged += new System.EventHandler(this.replaceSelected_SelectedIndexChanged);
            // 
            // textBox_oldValue
            // 
            this.textBox_oldValue.BorderBottomLineSize = 5;
            this.textBox_oldValue.BorderColor = System.Drawing.Color.Black;
            this.textBox_oldValue.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_oldValue.CustomButton.Image = null;
            this.textBox_oldValue.CustomButton.Location = new System.Drawing.Point(465, 1);
            this.textBox_oldValue.CustomButton.Name = "";
            this.textBox_oldValue.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox_oldValue.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_oldValue.CustomButton.TabIndex = 1;
            this.textBox_oldValue.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_oldValue.CustomButton.UseSelectable = true;
            this.textBox_oldValue.CustomButton.Visible = false;
            this.textBox_oldValue.DrawBorder = true;
            this.textBox_oldValue.DrawBorderBottomLine = false;
            this.textBox_oldValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_oldValue.Lines = new string[] {
        "models(.*)\\(.*)"};
            this.textBox_oldValue.Location = new System.Drawing.Point(87, 82);
            this.textBox_oldValue.MaxLength = 32767;
            this.textBox_oldValue.Name = "textBox_oldValue";
            this.textBox_oldValue.PasswordChar = '\0';
            this.textBox_oldValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_oldValue.SelectedText = "";
            this.textBox_oldValue.SelectionLength = 0;
            this.textBox_oldValue.SelectionStart = 0;
            this.textBox_oldValue.ShortcutsEnabled = true;
            this.textBox_oldValue.Size = new System.Drawing.Size(489, 25);
            this.textBox_oldValue.Style = JHUI.JColorStyle.Blue;
            this.textBox_oldValue.TabIndex = 31;
            this.textBox_oldValue.TabStop = false;
            this.textBox_oldValue.Text = "models(.*)\\(.*)";
            this.textBox_oldValue.TextWaterMark = "";
            this.textBox_oldValue.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_oldValue.UseCustomFont = true;
            this.textBox_oldValue.UseSelectable = true;
            this.textBox_oldValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_oldValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_oldValue.TextChanged += new System.EventHandler(this.textBox_oldValue_TextChanged);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(10, 82);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(60, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 35;
            this.jLabel1.Text = "Old Value :";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel2
            // 
            this.jLabel2.AutoSize = true;
            this.jLabel2.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.Location = new System.Drawing.Point(9, 119);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(65, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Gold;
            this.jLabel2.TabIndex = 36;
            this.jLabel2.Text = "New Value :";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel3
            // 
            this.jLabel3.AutoSize = true;
            this.jLabel3.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jLabel3.FontSize = JHUI.JLabelSize.Tall;
            this.jLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.jLabel3.Location = new System.Drawing.Point(8, 27);
            this.jLabel3.Name = "jLabel3";
            this.jLabel3.Size = new System.Drawing.Size(183, 25);
            this.jLabel3.Style = JHUI.JColorStyle.Gold;
            this.jLabel3.TabIndex = 37;
            this.jLabel3.Tag = "";
            this.jLabel3.Text = "Replace Selected Rows";
            this.jLabel3.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel3.UseCustomForeColor = true;
            // 
            // jLabel4
            // 
            this.jLabel4.AutoSize = true;
            this.jLabel4.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel4.FontSize = JHUI.JLabelSize.Small;
            this.jLabel4.ForeColor = System.Drawing.Color.DimGray;
            this.jLabel4.Location = new System.Drawing.Point(2, 34);
            this.jLabel4.Name = "jLabel4";
            this.jLabel4.Size = new System.Drawing.Size(12, 15);
            this.jLabel4.Style = JHUI.JColorStyle.Gold;
            this.jLabel4.TabIndex = 39;
            this.jLabel4.Text = "?";
            this.jLabel4.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.jLabel4, "You can replace EG: \r\nOld Value = \'\\bModels2\\b\' ,\r\nNew Value = \'Models\'. \r\nThis p" +
        "roduces : Models+Whatever is followd by. \r\nClick me for more info.");
            this.jLabel4.UseCustomForeColor = true;
            this.jLabel4.Click += new System.EventHandler(this.jLabel4_Click);
            // 
            // jToolTip1
            // 
            this.jToolTip1.Style = JHUI.JColorStyle.White;
            this.jToolTip1.StyleManager = null;
            this.jToolTip1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Replace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 183);
            this.Controls.Add(this.jLabel4);
            this.Controls.Add(this.jLabel3);
            this.Controls.Add(this.jLabel2);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jButton1);
            this.Controls.Add(this.textBox_newValue);
            this.Controls.Add(this.replaceSelected);
            this.Controls.Add(this.textBox_oldValue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(589, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(589, 183);
            this.Name = "Replace";
            this.Resizable = false;
            this.Style = JHUI.JColorStyle.Red;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JTextBox textBox_newValue;
        private JHUI.Controls.JComboBox replaceSelected;
        private JHUI.Controls.JTextBox textBox_oldValue;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JLabel jLabel2;
        private JHUI.Controls.JLabel jLabel3;
        private JHUI.Controls.JLabel jLabel4;
        private JHUI.Components.JToolTip jToolTip1;
    }
}