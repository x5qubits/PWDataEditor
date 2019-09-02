using JHUI.Controls;

namespace Pck_Guy_View
{
    partial class SettingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingWindow));
            this.label1 = new JHUI.Controls.JLabel();
            this.numericUpDown1 = new JHUI.Controls.JNumericUpDown();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jToggle1 = new JHUI.Controls.JToggle();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(36, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.Style = JHUI.JColorStyle.Gold;
            this.label1.TabIndex = 8;
            this.label1.Text = "Pck Compression:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.White;
            this.numericUpDown1.CustomDrawButtons = false;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDown1.FontSize = JHUI.JLabelSize.Medium;
            this.numericUpDown1.FontWeight = JHUI.JLabelWeight.Light;
            this.numericUpDown1.Location = new System.Drawing.Point(182, 63);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.Style = JHUI.JColorStyle.Blue;
            this.numericUpDown1.StyleManager = null;
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Theme = JHUI.JThemeStyle.Light;
            this.numericUpDown1.UseAlternateColors = false;
            this.numericUpDown1.UseSelectable = true;
            this.numericUpDown1.UseStyleColors = false;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(36, 103);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(138, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 11;
            this.jLabel1.Text = "Register Native Extensions";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jToggle1
            // 
            this.jToggle1.AutoSize = true;
            this.jToggle1.Location = new System.Drawing.Point(222, 103);
            this.jToggle1.Name = "jToggle1";
            this.jToggle1.Size = new System.Drawing.Size(80, 17);
            this.jToggle1.Style = JHUI.JColorStyle.Gold;
            this.jToggle1.TabIndex = 12;
            this.jToggle1.Text = "&Off";
            this.jToggle1.Theme = JHUI.JThemeStyle.Dark;
            this.jToggle1.UseSelectable = true;
            this.jToggle1.UseVisualStyleBackColor = true;
            this.jToggle1.CheckedChanged += new System.EventHandler(this.jButton1_Click);
            // 
            // SettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.jToggle1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(344, 261);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(344, 261);
            this.Name = "SettingWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.White;
            this.Text = "Pack Editor Configs";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private JLabel label1;
        private JNumericUpDown numericUpDown1;
        private JLabel jLabel1;
        private JToggle jToggle1;
    }
}