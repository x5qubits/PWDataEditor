
using JHUI.Controls;

namespace sTASKedit
{
    partial class PlayerWantedForceWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWantedForceWindow));
            this.textBox_Force = new JHUI.Controls.JTextBox();
            this.checkBox_Force_1 = new JHUI.Controls.JCheckBox();
            this.checkBox_Force_2 = new JHUI.Controls.JCheckBox();
            this.checkBox_Force_3 = new JHUI.Controls.JCheckBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.SuspendLayout();
            // 
            // textBox_Force
            // 
            // 
            // 
            // 
            this.textBox_Force.CustomButton.Image = null;
            this.textBox_Force.CustomButton.Location = new System.Drawing.Point(219, 2);
            this.textBox_Force.CustomButton.Name = "";
            this.textBox_Force.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_Force.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_Force.CustomButton.TabIndex = 1;
            this.textBox_Force.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_Force.CustomButton.UseSelectable = true;
            this.textBox_Force.CustomButton.Visible = false;
            this.textBox_Force.Lines = new string[0];
            this.textBox_Force.Location = new System.Drawing.Point(55, 73);
            this.textBox_Force.MaxLength = 32767;
            this.textBox_Force.Name = "textBox_Force";
            this.textBox_Force.PasswordChar = '\0';
            this.textBox_Force.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_Force.SelectedText = "";
            this.textBox_Force.SelectionLength = 0;
            this.textBox_Force.SelectionStart = 0;
            this.textBox_Force.ShortcutsEnabled = true;
            this.textBox_Force.Size = new System.Drawing.Size(237, 20);
            this.textBox_Force.Style = JHUI.JColorStyle.Gold;
            this.textBox_Force.TabIndex = 0;
            this.textBox_Force.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Force.TextWaterMark = "";
            this.textBox_Force.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_Force.UseSelectable = true;
            this.textBox_Force.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_Force.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // checkBox_Force_1
            // 
            this.checkBox_Force_1.AutoSize = true;
            this.checkBox_Force_1.Location = new System.Drawing.Point(55, 109);
            this.checkBox_Force_1.Name = "checkBox_Force_1";
            this.checkBox_Force_1.Size = new System.Drawing.Size(62, 15);
            this.checkBox_Force_1.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Force_1.TabIndex = 1;
            this.checkBox_Force_1.Tag = "1";
            this.checkBox_Force_1.Text = "Corona";
            this.checkBox_Force_1.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Force_1.UseSelectable = true;
            this.checkBox_Force_1.UseVisualStyleBackColor = true;
            this.checkBox_Force_1.CheckedChanged += new System.EventHandler(this.Force_CheckedChanged);
            // 
            // checkBox_Force_2
            // 
            this.checkBox_Force_2.AutoSize = true;
            this.checkBox_Force_2.Location = new System.Drawing.Point(195, 109);
            this.checkBox_Force_2.Name = "checkBox_Force_2";
            this.checkBox_Force_2.Size = new System.Drawing.Size(61, 15);
            this.checkBox_Force_2.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Force_2.TabIndex = 2;
            this.checkBox_Force_2.Tag = "2";
            this.checkBox_Force_2.Text = "Shroud";
            this.checkBox_Force_2.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Force_2.UseSelectable = true;
            this.checkBox_Force_2.UseVisualStyleBackColor = true;
            this.checkBox_Force_2.CheckedChanged += new System.EventHandler(this.Force_CheckedChanged);
            // 
            // checkBox_Force_3
            // 
            this.checkBox_Force_3.AutoSize = true;
            this.checkBox_Force_3.Location = new System.Drawing.Point(55, 135);
            this.checkBox_Force_3.Name = "checkBox_Force_3";
            this.checkBox_Force_3.Size = new System.Drawing.Size(82, 15);
            this.checkBox_Force_3.Style = JHUI.JColorStyle.Gold;
            this.checkBox_Force_3.TabIndex = 3;
            this.checkBox_Force_3.Tag = "4";
            this.checkBox_Force_3.Text = "Luminance";
            this.checkBox_Force_3.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_Force_3.UseSelectable = true;
            this.checkBox_Force_3.UseVisualStyleBackColor = true;
            this.checkBox_Force_3.CheckedChanged += new System.EventHandler(this.Force_CheckedChanged);
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(65, 161);
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
            this.button_Cancel.Location = new System.Drawing.Point(181, 161);
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
            // PlayerWantedForceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(337, 216);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.checkBox_Force_3);
            this.Controls.Add(this.checkBox_Force_2);
            this.Controls.Add(this.checkBox_Force_1);
            this.Controls.Add(this.textBox_Force);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 216);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 216);
            this.Name = "PlayerWantedForceWindow";
            this.ShowIcon = false;
            this.Text = "Player Wanted Force";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JTextBox textBox_Force;
        private JCheckBox checkBox_Force_1;
        private JCheckBox checkBox_Force_2;
        private JCheckBox checkBox_Force_3;
        private JButton button_Ok;
        private JButton button_Cancel;
	}
}

