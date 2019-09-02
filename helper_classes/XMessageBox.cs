using JHUI.Forms;
using PWDataEditorPaied.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied.helper_classes
{
    public partial class XMessageBox : JForm
    {
        private string data = "";
        public XMessageBox()
        {
            InitializeComponent();
            jLabel1.Text = data;
        }

        public void SetInfo(string info, MessageBoxButtons type = MessageBoxButtons.OKCancel, string title = "Notification")
        {
            this.Text = title;
            data = info;
            jLabel1.Text = data;
            switch(type)
            {
                case MessageBoxButtons.OK:
                    jButton3.Text = "Okay";
                    jButton3.Enabled = true;
                    jButton3.Visible = true;
                    jButton1.Enabled = false;
                    jButton1.Visible = false;
                    jButton2.Enabled = false;
                    jButton2.Visible = false;
                    break;
                case MessageBoxButtons.OKCancel:
                    jButton1.Text = "Okay";
                    jButton1.Enabled = true;
                    jButton1.Visible = true;
                    jButton2.Text = "Cancel";
                    jButton2.Enabled = true;
                    jButton2.Visible = true;
                    jButton3.Enabled = false;
                    jButton3.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    jButton1.Text = "Yes";
                    jButton1.Enabled = true;
                    jButton1.Visible = true;
                    jButton2.Text = "No";
                    jButton2.Enabled = true;
                    jButton2.Visible = true;
                    jButton3.Enabled = false;
                    jButton3.Visible = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    jButton1.Text = "Yes";
                    jButton1.Enabled = true;
                    jButton1.Visible = true;
                    jButton2.Text = "Cancel";
                    jButton2.Enabled = true;
                    jButton2.Visible = true;
                    jButton3.Text = "No";
                    jButton3.Enabled = true;
                    jButton3.Visible = true;
                    break;
            }
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            PreferencesManager.XMessageBox = DialogResult.OK;
            this.Close();
        }

        private void jButton2_Click(object sender, EventArgs e)
        {
            PreferencesManager.XMessageBox = DialogResult.No;
            this.Close();
        }

        private void jButton3_Click(object sender, EventArgs e)
        {
            PreferencesManager.XMessageBox = DialogResult.Cancel;
            this.Close();
        }
    }
}
