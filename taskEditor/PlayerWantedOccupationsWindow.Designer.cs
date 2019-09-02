
using JHUI.Controls;
using System.Windows.Forms;

namespace sTASKedit
{
	partial class PlayerWantedOccupationsWindow
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWantedOccupationsWindow));
            this.textBox_Occupations = new JHUI.Controls.JTextBox();
            this.checkBox_Occupation_1 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_2 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_3 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_4 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_5 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_6 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_7 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_8 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_9 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_10 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_11 = new JHUI.Controls.JCheckBox();
            this.checkBox_Occupation_12 = new JHUI.Controls.JCheckBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.SuspendLayout();
            // 
            // textBox_Occupations
            // 
            // 
            // 
            // 
            this.textBox_Occupations.CustomButton.Image = null;
            this.textBox_Occupations.CustomButton.Location = new System.Drawing.Point(281, 2);
            this.textBox_Occupations.CustomButton.Name = "";
            this.textBox_Occupations.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_Occupations.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_Occupations.CustomButton.TabIndex = 1;
            this.textBox_Occupations.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_Occupations.CustomButton.UseSelectable = true;
            this.textBox_Occupations.CustomButton.Visible = false;
            this.textBox_Occupations.Lines = new string[0];
            this.textBox_Occupations.Location = new System.Drawing.Point(23, 63);
            this.textBox_Occupations.MaxLength = 32767;
            this.textBox_Occupations.Name = "textBox_Occupations";
            this.textBox_Occupations.PasswordChar = '\0';
            this.textBox_Occupations.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_Occupations.SelectedText = "";
            this.textBox_Occupations.SelectionLength = 0;
            this.textBox_Occupations.SelectionStart = 0;
            this.textBox_Occupations.ShortcutsEnabled = true;
            this.textBox_Occupations.Size = new System.Drawing.Size(299, 20);
            this.textBox_Occupations.Style = JHUI.JColorStyle.Gold;
            this.textBox_Occupations.TabIndex = 0;
            this.textBox_Occupations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Occupations.TextWaterMark = "";
            this.textBox_Occupations.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_Occupations.UseSelectable = true;
            this.textBox_Occupations.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_Occupations.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // checkBox_Occupation_1
            // 
            this.checkBox_Occupation_1.AutoSize = true;
            this.checkBox_Occupation_1.Location = new System.Drawing.Point(23, 99);
            this.checkBox_Occupation_1.Name = "checkBox_Occupation_1";
            this.checkBox_Occupation_1.Size = new System.Drawing.Size(88, 15);
            this.checkBox_Occupation_1.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_1.TabIndex = 1;
            this.checkBox_Occupation_1.Tag = "1";
            this.checkBox_Occupation_1.Text = "Blademaster";
            this.checkBox_Occupation_1.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_1.UseSelectable = true;
            this.checkBox_Occupation_1.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_1.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_2
            // 
            this.checkBox_Occupation_2.AutoSize = true;
            this.checkBox_Occupation_2.Location = new System.Drawing.Point(163, 99);
            this.checkBox_Occupation_2.Name = "checkBox_Occupation_2";
            this.checkBox_Occupation_2.Size = new System.Drawing.Size(59, 15);
            this.checkBox_Occupation_2.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_2.TabIndex = 2;
            this.checkBox_Occupation_2.Tag = "2";
            this.checkBox_Occupation_2.Text = "Wizard";
            this.checkBox_Occupation_2.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_2.UseSelectable = true;
            this.checkBox_Occupation_2.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_2.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_3
            // 
            this.checkBox_Occupation_3.AutoSize = true;
            this.checkBox_Occupation_3.Location = new System.Drawing.Point(163, 177);
            this.checkBox_Occupation_3.Name = "checkBox_Occupation_3";
            this.checkBox_Occupation_3.Size = new System.Drawing.Size(63, 15);
            this.checkBox_Occupation_3.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_3.TabIndex = 3;
            this.checkBox_Occupation_3.Tag = "4";
            this.checkBox_Occupation_3.Text = "Psychic";
            this.checkBox_Occupation_3.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_3.UseSelectable = true;
            this.checkBox_Occupation_3.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_3.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_4
            // 
            this.checkBox_Occupation_4.AutoSize = true;
            this.checkBox_Occupation_4.Location = new System.Drawing.Point(163, 125);
            this.checkBox_Occupation_4.Name = "checkBox_Occupation_4";
            this.checkBox_Occupation_4.Size = new System.Drawing.Size(89, 15);
            this.checkBox_Occupation_4.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_4.TabIndex = 4;
            this.checkBox_Occupation_4.Tag = "8";
            this.checkBox_Occupation_4.Text = "Venomancer";
            this.checkBox_Occupation_4.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_4.UseSelectable = true;
            this.checkBox_Occupation_4.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_4.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_5
            // 
            this.checkBox_Occupation_5.AutoSize = true;
            this.checkBox_Occupation_5.Location = new System.Drawing.Point(23, 125);
            this.checkBox_Occupation_5.Name = "checkBox_Occupation_5";
            this.checkBox_Occupation_5.Size = new System.Drawing.Size(73, 15);
            this.checkBox_Occupation_5.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_5.TabIndex = 5;
            this.checkBox_Occupation_5.Tag = "16";
            this.checkBox_Occupation_5.Text = "Barbarian";
            this.checkBox_Occupation_5.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_5.UseSelectable = true;
            this.checkBox_Occupation_5.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_5.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_6
            // 
            this.checkBox_Occupation_6.AutoSize = true;
            this.checkBox_Occupation_6.Location = new System.Drawing.Point(23, 177);
            this.checkBox_Occupation_6.Name = "checkBox_Occupation_6";
            this.checkBox_Occupation_6.Size = new System.Drawing.Size(67, 15);
            this.checkBox_Occupation_6.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_6.TabIndex = 6;
            this.checkBox_Occupation_6.Tag = "32";
            this.checkBox_Occupation_6.Text = "Assassin";
            this.checkBox_Occupation_6.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_6.UseSelectable = true;
            this.checkBox_Occupation_6.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_6.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_7
            // 
            this.checkBox_Occupation_7.AutoSize = true;
            this.checkBox_Occupation_7.Location = new System.Drawing.Point(23, 151);
            this.checkBox_Occupation_7.Name = "checkBox_Occupation_7";
            this.checkBox_Occupation_7.Size = new System.Drawing.Size(58, 15);
            this.checkBox_Occupation_7.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_7.TabIndex = 7;
            this.checkBox_Occupation_7.Tag = "64";
            this.checkBox_Occupation_7.Text = "Archer";
            this.checkBox_Occupation_7.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_7.UseSelectable = true;
            this.checkBox_Occupation_7.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_7.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_8
            // 
            this.checkBox_Occupation_8.AutoSize = true;
            this.checkBox_Occupation_8.Location = new System.Drawing.Point(163, 151);
            this.checkBox_Occupation_8.Name = "checkBox_Occupation_8";
            this.checkBox_Occupation_8.Size = new System.Drawing.Size(53, 15);
            this.checkBox_Occupation_8.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_8.TabIndex = 8;
            this.checkBox_Occupation_8.Tag = "128";
            this.checkBox_Occupation_8.Text = "Cleric";
            this.checkBox_Occupation_8.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_8.UseSelectable = true;
            this.checkBox_Occupation_8.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_8.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_9
            // 
            this.checkBox_Occupation_9.AutoSize = true;
            this.checkBox_Occupation_9.Location = new System.Drawing.Point(23, 203);
            this.checkBox_Occupation_9.Name = "checkBox_Occupation_9";
            this.checkBox_Occupation_9.Size = new System.Drawing.Size(57, 15);
            this.checkBox_Occupation_9.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_9.TabIndex = 9;
            this.checkBox_Occupation_9.Tag = "256";
            this.checkBox_Occupation_9.Text = "Seeker";
            this.checkBox_Occupation_9.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_9.UseSelectable = true;
            this.checkBox_Occupation_9.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_9.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_10
            // 
            this.checkBox_Occupation_10.AutoSize = true;
            this.checkBox_Occupation_10.Location = new System.Drawing.Point(163, 203);
            this.checkBox_Occupation_10.Name = "checkBox_Occupation_10";
            this.checkBox_Occupation_10.Size = new System.Drawing.Size(58, 15);
            this.checkBox_Occupation_10.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_10.TabIndex = 10;
            this.checkBox_Occupation_10.Tag = "512";
            this.checkBox_Occupation_10.Text = "Mystic";
            this.checkBox_Occupation_10.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_10.UseSelectable = true;
            this.checkBox_Occupation_10.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_10.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_11
            // 
            this.checkBox_Occupation_11.AutoSize = true;
            this.checkBox_Occupation_11.Location = new System.Drawing.Point(23, 229);
            this.checkBox_Occupation_11.Name = "checkBox_Occupation_11";
            this.checkBox_Occupation_11.Size = new System.Drawing.Size(78, 15);
            this.checkBox_Occupation_11.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_11.TabIndex = 11;
            this.checkBox_Occupation_11.Tag = "1024";
            this.checkBox_Occupation_11.Text = "Duskblade";
            this.checkBox_Occupation_11.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_11.UseSelectable = true;
            this.checkBox_Occupation_11.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_11.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // checkBox_Occupation_12
            // 
            this.checkBox_Occupation_12.AutoSize = true;
            this.checkBox_Occupation_12.Location = new System.Drawing.Point(163, 229);
            this.checkBox_Occupation_12.Name = "checkBox_Occupation_12";
            this.checkBox_Occupation_12.Size = new System.Drawing.Size(93, 15);
            this.checkBox_Occupation_12.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Occupation_12.TabIndex = 12;
            this.checkBox_Occupation_12.Tag = "2048";
            this.checkBox_Occupation_12.Text = "Stormbringer";
            this.checkBox_Occupation_12.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Occupation_12.UseSelectable = true;
            this.checkBox_Occupation_12.UseVisualStyleBackColor = true;
            this.checkBox_Occupation_12.CheckedChanged += new System.EventHandler(this.Occupations_CheckedChanged);
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(23, 255);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(100, 23);
            this.button_Ok.Style = JHUI.JColorStyle.Gold;
            this.button_Ok.TabIndex = 13;
            this.button_Ok.Text = "OK";
            this.button_Ok.Theme = JHUI.JThemeStyle.Dark;
            this.button_Ok.UseSelectable = true;
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(222, 255);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 23);
            this.button_Cancel.Style = JHUI.JColorStyle.Gold;
            this.button_Cancel.TabIndex = 14;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.Theme = JHUI.JThemeStyle.Dark;
            this.button_Cancel.UseSelectable = true;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // PlayerWantedOccupationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(345, 307);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.checkBox_Occupation_12);
            this.Controls.Add(this.checkBox_Occupation_11);
            this.Controls.Add(this.checkBox_Occupation_10);
            this.Controls.Add(this.checkBox_Occupation_9);
            this.Controls.Add(this.checkBox_Occupation_8);
            this.Controls.Add(this.checkBox_Occupation_7);
            this.Controls.Add(this.checkBox_Occupation_6);
            this.Controls.Add(this.checkBox_Occupation_5);
            this.Controls.Add(this.checkBox_Occupation_4);
            this.Controls.Add(this.checkBox_Occupation_3);
            this.Controls.Add(this.checkBox_Occupation_2);
            this.Controls.Add(this.checkBox_Occupation_1);
            this.Controls.Add(this.textBox_Occupations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 307);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(345, 307);
            this.Name = "PlayerWantedOccupationsWindow";
            this.ShowIcon = false;
            this.Text = "Player Wanted Occupations";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JTextBox textBox_Occupations;
        private JCheckBox checkBox_Occupation_1;
        private JCheckBox checkBox_Occupation_2;
        private JCheckBox checkBox_Occupation_3;
        private JCheckBox checkBox_Occupation_4;
        private JCheckBox checkBox_Occupation_5;
        private JCheckBox checkBox_Occupation_6;
        private JCheckBox checkBox_Occupation_7;
        private JCheckBox checkBox_Occupation_8;
        private JCheckBox checkBox_Occupation_9;
        private JCheckBox checkBox_Occupation_10;
        private JCheckBox checkBox_Occupation_11;
        private JCheckBox checkBox_Occupation_12;
        private JButton button_Ok;
        private JButton button_Cancel;
	}
}

