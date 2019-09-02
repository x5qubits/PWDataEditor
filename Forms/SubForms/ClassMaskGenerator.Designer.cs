using JHUI.Controls;

namespace ElementEditor
{
    partial class ClassMaskGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassMaskGenerator));
            this.checkBoxBM = new JHUI.Controls.JCheckBox();
            this.checkBoxMG = new JHUI.Controls.JCheckBox();
            this.checkBoxWB = new JHUI.Controls.JCheckBox();
            this.checkBoxSIN = new JHUI.Controls.JCheckBox();
            this.checkBoxSE = new JHUI.Controls.JCheckBox();
            this.checkBoxMY = new JHUI.Controls.JCheckBox();
            this.checkBoxPS = new JHUI.Controls.JCheckBox();
            this.checkBoxEA = new JHUI.Controls.JCheckBox();
            this.checkBoxDU = new JHUI.Controls.JCheckBox();
            this.checkBoxVE = new JHUI.Controls.JCheckBox();
            this.checkBoxEP = new JHUI.Controls.JCheckBox();
            this.checkBoxSU = new JHUI.Controls.JCheckBox();
            this.resultBox = new JHUI.Controls.JTextBox();
            this.button6 = new JHUI.Controls.JButton();
            this.button1 = new JHUI.Controls.JButton();
            this.SuspendLayout();
            // 
            // checkBoxBM
            // 
            this.checkBoxBM.AutoSize = true;
            this.checkBoxBM.Location = new System.Drawing.Point(30, 64);
            this.checkBoxBM.Name = "checkBoxBM";
            this.checkBoxBM.Size = new System.Drawing.Size(88, 15);
            this.checkBoxBM.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxBM.TabIndex = 0;
            this.checkBoxBM.Text = "BladeMaster";
            this.checkBoxBM.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxBM.UseSelectable = true;
            this.checkBoxBM.UseVisualStyleBackColor = true;
            this.checkBoxBM.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxMG
            // 
            this.checkBoxMG.AutoSize = true;
            this.checkBoxMG.Location = new System.Drawing.Point(30, 87);
            this.checkBoxMG.Name = "checkBoxMG";
            this.checkBoxMG.Size = new System.Drawing.Size(59, 15);
            this.checkBoxMG.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxMG.TabIndex = 1;
            this.checkBoxMG.Text = "Wizard";
            this.checkBoxMG.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxMG.UseSelectable = true;
            this.checkBoxMG.UseVisualStyleBackColor = true;
            this.checkBoxMG.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxWB
            // 
            this.checkBoxWB.AutoSize = true;
            this.checkBoxWB.Location = new System.Drawing.Point(136, 63);
            this.checkBoxWB.Name = "checkBoxWB";
            this.checkBoxWB.Size = new System.Drawing.Size(73, 15);
            this.checkBoxWB.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxWB.TabIndex = 2;
            this.checkBoxWB.Text = "Barbarian";
            this.checkBoxWB.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxWB.UseSelectable = true;
            this.checkBoxWB.UseVisualStyleBackColor = true;
            this.checkBoxWB.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxSIN
            // 
            this.checkBoxSIN.AutoSize = true;
            this.checkBoxSIN.Location = new System.Drawing.Point(136, 87);
            this.checkBoxSIN.Name = "checkBoxSIN";
            this.checkBoxSIN.Size = new System.Drawing.Size(62, 15);
            this.checkBoxSIN.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxSIN.TabIndex = 3;
            this.checkBoxSIN.Text = "Assasin";
            this.checkBoxSIN.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxSIN.UseSelectable = true;
            this.checkBoxSIN.UseVisualStyleBackColor = true;
            this.checkBoxSIN.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxSE
            // 
            this.checkBoxSE.AutoSize = true;
            this.checkBoxSE.Location = new System.Drawing.Point(229, 63);
            this.checkBoxSE.Name = "checkBoxSE";
            this.checkBoxSE.Size = new System.Drawing.Size(57, 15);
            this.checkBoxSE.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxSE.TabIndex = 4;
            this.checkBoxSE.Text = "Seeker";
            this.checkBoxSE.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxSE.UseSelectable = true;
            this.checkBoxSE.UseVisualStyleBackColor = true;
            this.checkBoxSE.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxMY
            // 
            this.checkBoxMY.AutoSize = true;
            this.checkBoxMY.Location = new System.Drawing.Point(229, 87);
            this.checkBoxMY.Name = "checkBoxMY";
            this.checkBoxMY.Size = new System.Drawing.Size(58, 15);
            this.checkBoxMY.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxMY.TabIndex = 5;
            this.checkBoxMY.Text = "Mystic";
            this.checkBoxMY.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxMY.UseSelectable = true;
            this.checkBoxMY.UseVisualStyleBackColor = true;
            this.checkBoxMY.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxPS
            // 
            this.checkBoxPS.AutoSize = true;
            this.checkBoxPS.Location = new System.Drawing.Point(30, 110);
            this.checkBoxPS.Name = "checkBoxPS";
            this.checkBoxPS.Size = new System.Drawing.Size(63, 15);
            this.checkBoxPS.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxPS.TabIndex = 6;
            this.checkBoxPS.Text = "Psychic";
            this.checkBoxPS.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxPS.UseSelectable = true;
            this.checkBoxPS.UseVisualStyleBackColor = true;
            this.checkBoxPS.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxEA
            // 
            this.checkBoxEA.AutoSize = true;
            this.checkBoxEA.Location = new System.Drawing.Point(136, 110);
            this.checkBoxEA.Name = "checkBoxEA";
            this.checkBoxEA.Size = new System.Drawing.Size(58, 15);
            this.checkBoxEA.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxEA.TabIndex = 7;
            this.checkBoxEA.Text = "Archer";
            this.checkBoxEA.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxEA.UseSelectable = true;
            this.checkBoxEA.UseVisualStyleBackColor = true;
            this.checkBoxEA.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxDU
            // 
            this.checkBoxDU.AutoSize = true;
            this.checkBoxDU.Location = new System.Drawing.Point(229, 110);
            this.checkBoxDU.Name = "checkBoxDU";
            this.checkBoxDU.Size = new System.Drawing.Size(76, 15);
            this.checkBoxDU.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxDU.TabIndex = 8;
            this.checkBoxDU.Text = "DustBlade";
            this.checkBoxDU.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxDU.UseSelectable = true;
            this.checkBoxDU.UseVisualStyleBackColor = true;
            this.checkBoxDU.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxVE
            // 
            this.checkBoxVE.AutoSize = true;
            this.checkBoxVE.Location = new System.Drawing.Point(30, 133);
            this.checkBoxVE.Name = "checkBoxVE";
            this.checkBoxVE.Size = new System.Drawing.Size(86, 15);
            this.checkBoxVE.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxVE.TabIndex = 9;
            this.checkBoxVE.Text = "Venomarcer";
            this.checkBoxVE.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxVE.UseSelectable = true;
            this.checkBoxVE.UseVisualStyleBackColor = true;
            this.checkBoxVE.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxEP
            // 
            this.checkBoxEP.AutoSize = true;
            this.checkBoxEP.Location = new System.Drawing.Point(136, 133);
            this.checkBoxEP.Name = "checkBoxEP";
            this.checkBoxEP.Size = new System.Drawing.Size(53, 15);
            this.checkBoxEP.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxEP.TabIndex = 10;
            this.checkBoxEP.Text = "Cleric";
            this.checkBoxEP.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxEP.UseSelectable = true;
            this.checkBoxEP.UseVisualStyleBackColor = true;
            this.checkBoxEP.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // checkBoxSU
            // 
            this.checkBoxSU.AutoSize = true;
            this.checkBoxSU.Location = new System.Drawing.Point(229, 133);
            this.checkBoxSU.Name = "checkBoxSU";
            this.checkBoxSU.Size = new System.Drawing.Size(93, 15);
            this.checkBoxSU.Style = JHUI.JColorStyle.Magenta;
            this.checkBoxSU.TabIndex = 11;
            this.checkBoxSU.Text = "StormBringer";
            this.checkBoxSU.Theme = JHUI.JThemeStyle.Dark;
            this.checkBoxSU.UseSelectable = true;
            this.checkBoxSU.UseVisualStyleBackColor = true;
            this.checkBoxSU.CheckedChanged += new System.EventHandler(this.checkboxClick);
            // 
            // resultBox
            // 
            // 
            // 
            // 
            this.resultBox.CustomButton.Image = null;
            this.resultBox.CustomButton.Location = new System.Drawing.Point(45, 2);
            this.resultBox.CustomButton.Name = "";
            this.resultBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.resultBox.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.resultBox.CustomButton.TabIndex = 1;
            this.resultBox.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.resultBox.CustomButton.UseSelectable = true;
            this.resultBox.CustomButton.Visible = false;
            this.resultBox.Lines = new string[0];
            this.resultBox.Location = new System.Drawing.Point(31, 154);
            this.resultBox.MaxLength = 32767;
            this.resultBox.Name = "resultBox";
            this.resultBox.PasswordChar = '\0';
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.resultBox.SelectedText = "";
            this.resultBox.SelectionLength = 0;
            this.resultBox.SelectionStart = 0;
            this.resultBox.ShortcutsEnabled = true;
            this.resultBox.Size = new System.Drawing.Size(63, 20);
            this.resultBox.Style = JHUI.JColorStyle.Magenta;
            this.resultBox.TabIndex = 13;
            this.resultBox.TextWaterMark = "";
            this.resultBox.Theme = JHUI.JThemeStyle.Dark;
            this.resultBox.UseSelectable = true;
            this.resultBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.resultBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.resultBox.TextChanged += new System.EventHandler(this.resultBox_TextChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Teal;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(216, 154);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 22);
            this.button6.Style = JHUI.JColorStyle.Gold;
            this.button6.TabIndex = 22;
            this.button6.Text = "Select None";
            this.button6.Theme = JHUI.JThemeStyle.Dark;
            this.button6.UseSelectable = true;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(108, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 22);
            this.button1.Style = JHUI.JColorStyle.Gold;
            this.button1.TabIndex = 23;
            this.button1.Text = "Select All";
            this.button1.Theme = JHUI.JThemeStyle.Dark;
            this.button1.UseSelectable = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClassMaskGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.checkBoxSU);
            this.Controls.Add(this.checkBoxEP);
            this.Controls.Add(this.checkBoxVE);
            this.Controls.Add(this.checkBoxDU);
            this.Controls.Add(this.checkBoxEA);
            this.Controls.Add(this.checkBoxPS);
            this.Controls.Add(this.checkBoxMY);
            this.Controls.Add(this.checkBoxSE);
            this.Controls.Add(this.checkBoxSIN);
            this.Controls.Add(this.checkBoxWB);
            this.Controls.Add(this.checkBoxMG);
            this.Controls.Add(this.checkBoxBM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(339, 189);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(339, 189);
            this.Name = "ClassMaskGenerator";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Magenta;
            this.Text = "Class Mask Selector";
            this.Shown += new System.EventHandler(this.ClassMaskGenerator_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JCheckBox checkBoxBM;
        private JCheckBox checkBoxMG;
        private JCheckBox checkBoxWB;
        private JCheckBox checkBoxSIN;
        private JCheckBox checkBoxSE;
        private JCheckBox checkBoxMY;
        private JCheckBox checkBoxPS;
        private JCheckBox checkBoxEA;
        private JCheckBox checkBoxDU;
        private JCheckBox checkBoxVE;
        private JCheckBox checkBoxEP;
        private JCheckBox checkBoxSU;
        private JTextBox resultBox;
        private JButton button6;
        private JButton button1;
    }
}