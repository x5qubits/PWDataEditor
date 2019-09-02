
using JHUI.Controls;

namespace sTASKedit
{
	partial class PWDBWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PWDBWindow));
            this.textBox_AddressBar = new JHUI.Controls.JTextBox();
            this.button_Back = new JHUI.Controls.JButton();
            this.button_Forward = new JHUI.Controls.JButton();
            this.comboBox_PWDBLang = new JHUI.Controls.JComboBox();
            this.button_OpenPWDB = new JHUI.Controls.JButton();
            this.webBrowser_PWDB = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // textBox_AddressBar
            // 
            this.textBox_AddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox_AddressBar.CustomButton.Image = null;
            this.textBox_AddressBar.CustomButton.Location = new System.Drawing.Point(385, 1);
            this.textBox_AddressBar.CustomButton.Name = "";
            this.textBox_AddressBar.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.textBox_AddressBar.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_AddressBar.CustomButton.TabIndex = 1;
            this.textBox_AddressBar.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_AddressBar.CustomButton.UseSelectable = true;
            this.textBox_AddressBar.CustomButton.Visible = false;
            this.textBox_AddressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_AddressBar.Lines = new string[0];
            this.textBox_AddressBar.Location = new System.Drawing.Point(29, 64);
            this.textBox_AddressBar.MaxLength = 32767;
            this.textBox_AddressBar.Name = "textBox_AddressBar";
            this.textBox_AddressBar.PasswordChar = '\0';
            this.textBox_AddressBar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_AddressBar.SelectedText = "";
            this.textBox_AddressBar.SelectionLength = 0;
            this.textBox_AddressBar.SelectionStart = 0;
            this.textBox_AddressBar.ShortcutsEnabled = true;
            this.textBox_AddressBar.Size = new System.Drawing.Size(405, 21);
            this.textBox_AddressBar.Style = JHUI.JColorStyle.Gold;
            this.textBox_AddressBar.TabIndex = 0;
            this.textBox_AddressBar.TextWaterMark = "";
            this.textBox_AddressBar.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_AddressBar.UseSelectable = true;
            this.textBox_AddressBar.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_AddressBar.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_AddressBar_KeyDown);
            // 
            // button_Back
            // 
            this.button_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Back.Location = new System.Drawing.Point(444, 63);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(44, 23);
            this.button_Back.Style = JHUI.JColorStyle.Gold;
            this.button_Back.TabIndex = 1;
            this.button_Back.Text = "Back";
            this.button_Back.Theme = JHUI.JThemeStyle.Dark;
            this.button_Back.UseSelectable = true;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // button_Forward
            // 
            this.button_Forward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Forward.Location = new System.Drawing.Point(494, 63);
            this.button_Forward.Name = "button_Forward";
            this.button_Forward.Size = new System.Drawing.Size(63, 23);
            this.button_Forward.Style = JHUI.JColorStyle.Gold;
            this.button_Forward.TabIndex = 2;
            this.button_Forward.Text = "Forward";
            this.button_Forward.Theme = JHUI.JThemeStyle.Dark;
            this.button_Forward.UseSelectable = true;
            this.button_Forward.UseVisualStyleBackColor = true;
            this.button_Forward.Click += new System.EventHandler(this.button_Forward_Click);
            // 
            // comboBox_PWDBLang
            // 
            this.comboBox_PWDBLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_PWDBLang.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox_PWDBLang.FormattingEnabled = true;
            this.comboBox_PWDBLang.ItemHeight = 19;
            this.comboBox_PWDBLang.Items.AddRange(new object[] {
            "RU",
            "EN",
            "FR",
            "DE",
            "CN",
            "BR",
            "JP",
            "PH",
            "MY"});
            this.comboBox_PWDBLang.Location = new System.Drawing.Point(563, 63);
            this.comboBox_PWDBLang.Name = "comboBox_PWDBLang";
            this.comboBox_PWDBLang.Size = new System.Drawing.Size(126, 25);
            this.comboBox_PWDBLang.Style = JHUI.JColorStyle.Gold;
            this.comboBox_PWDBLang.TabIndex = 3;
            this.comboBox_PWDBLang.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_PWDBLang.UseSelectable = true;
            this.comboBox_PWDBLang.SelectedIndexChanged += new System.EventHandler(this.comboBox_PWDBLang_SelectedIndexChanged);
            // 
            // button_OpenPWDB
            // 
            this.button_OpenPWDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenPWDB.Location = new System.Drawing.Point(695, 63);
            this.button_OpenPWDB.Name = "button_OpenPWDB";
            this.button_OpenPWDB.Size = new System.Drawing.Size(51, 23);
            this.button_OpenPWDB.Style = JHUI.JColorStyle.Gold;
            this.button_OpenPWDB.TabIndex = 4;
            this.button_OpenPWDB.Text = "Open";
            this.button_OpenPWDB.Theme = JHUI.JThemeStyle.Dark;
            this.button_OpenPWDB.UseSelectable = true;
            this.button_OpenPWDB.UseVisualStyleBackColor = true;
            this.button_OpenPWDB.Click += new System.EventHandler(this.button_OpenPWDB_Click);
            // 
            // webBrowser_PWDB
            // 
            this.webBrowser_PWDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser_PWDB.Location = new System.Drawing.Point(0, 96);
            this.webBrowser_PWDB.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser_PWDB.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_PWDB.Name = "webBrowser_PWDB";
            this.webBrowser_PWDB.Size = new System.Drawing.Size(758, 550);
            this.webBrowser_PWDB.TabIndex = 5;
            this.webBrowser_PWDB.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_PWDB_Navigated);
            // 
            // PWDBWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(758, 646);
            this.Controls.Add(this.webBrowser_PWDB);
            this.Controls.Add(this.button_OpenPWDB);
            this.Controls.Add(this.comboBox_PWDBLang);
            this.Controls.Add(this.button_Forward);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.textBox_AddressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PWDBWindow";
            this.ShowIcon = false;
            this.Text = "PW Data Base";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PWDBWindow_FormClosed);
            this.SizeChanged += new System.EventHandler(this.PWDBWindow_SizeChanged);
            this.ResumeLayout(false);

		}

		#endregion

        private JTextBox textBox_AddressBar;
        private JButton button_Back;
        private JButton button_Forward;
        private JButton button_OpenPWDB;
        private System.Windows.Forms.WebBrowser webBrowser_PWDB;
        public JComboBox comboBox_PWDBLang;
	}
}

