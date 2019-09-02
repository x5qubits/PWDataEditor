
using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace sTASKedit
{
	public partial class PWDBWindow: JForm
	{
        private TaskEditor MainWindow;
        public PWDBWindow(TaskEditor MainWindow)
		{
			InitializeComponent();
            this.MainWindow = MainWindow;
            this.SetLocalization();
            this.comboBox_PWDBLang.SelectedIndex = MainWindow.lPWDBLang;
		}

        private void button_OpenPWDB_Click(object sender, EventArgs e)
        {
            if ((string)this.comboBox_PWDBLang.SelectedItem == "RU")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/ru/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "EN")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/pwi/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "FR")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/fr/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "DE")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/de/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "CN")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/cn/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "BR")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/br/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "JP")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/jp/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "PH")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/ph/", System.UriKind.Absolute);
            }
            if ((string)this.comboBox_PWDBLang.SelectedItem == "MY")
            {
                this.webBrowser_PWDB.Url = new System.Uri("http://www.pwdatabase.com/my/", System.UriKind.Absolute);
            }
        }

        private void comboBox_PWDBLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.lPWDBLang = this.comboBox_PWDBLang.SelectedIndex;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.webBrowser_PWDB.GoBack();
        }

        private void button_Forward_Click(object sender, EventArgs e)
        {
            this.webBrowser_PWDB.GoForward();
        }

        private void webBrowser_PWDB_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.textBox_AddressBar.Text = this.webBrowser_PWDB.Url.ToString();
        }

        private void textBox_AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.webBrowser_PWDB.Url = new System.Uri(this.textBox_AddressBar.Text, System.UriKind.Absolute);
            }
        }

        private void PWDBWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainWindow.lPWDBLang = this.comboBox_PWDBLang.SelectedIndex;
        }

        private void PWDBWindow_SizeChanged(object sender, EventArgs e)
        {
           // if (this.WindowState != FormWindowState.Maximized) MainWindow.lPWDBWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6003);
            button_Back.Text = Extensions.GetLocalization(6004);
            button_Forward.Text = Extensions.GetLocalization(6005);
            button_OpenPWDB.Text = Extensions.GetLocalization(6006);
        }
	}
}

