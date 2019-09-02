using JHUI.Controls;

namespace sTASKedit
{
	partial class DebugWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
            this.textBox_Message = new JHUI.Controls.JTextBox();
            this.SuspendLayout();
            // 
            // textBox_Message
            // 
            this.textBox_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox_Message.CustomButton.Image = null;
            this.textBox_Message.CustomButton.Location = new System.Drawing.Point(-96, 1);
            this.textBox_Message.CustomButton.Name = "";
            this.textBox_Message.CustomButton.Size = new System.Drawing.Size(415, 415);
            this.textBox_Message.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_Message.CustomButton.TabIndex = 1;
            this.textBox_Message.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_Message.CustomButton.UseSelectable = true;
            this.textBox_Message.CustomButton.Visible = false;
            this.textBox_Message.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.textBox_Message.Lines = new string[0];
            this.textBox_Message.Location = new System.Drawing.Point(0, 63);
            this.textBox_Message.MaxLength = 32767;
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.PasswordChar = '\0';
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Message.SelectedText = "";
            this.textBox_Message.SelectionLength = 0;
            this.textBox_Message.SelectionStart = 0;
            this.textBox_Message.ShortcutsEnabled = true;
            this.textBox_Message.Size = new System.Drawing.Size(320, 417);
            this.textBox_Message.Style = JHUI.JColorStyle.Gold;
            this.textBox_Message.TabIndex = 0;
            this.textBox_Message.TextWaterMark = "";
            this.textBox_Message.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_Message.UseSelectable = true;
            this.textBox_Message.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_Message.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 480);
            this.Controls.Add(this.textBox_Message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugWindow";
            this.ShowIcon = false;
            this.Text = "DebugWindow";
            this.ResumeLayout(false);

		}

		#endregion

        private JTextBox textBox_Message;
	}
}