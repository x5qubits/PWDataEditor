using JHUI.Forms;
using PWDataEditorPaied.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Pck_Guy_View
{
    public partial class SettingWindow : JForm
    {
        public SettingWindow()
        {
            InitializeComponent();
            this.numericUpDown1.Value = PackConfigs.compression;
            pref = PreferencesManager.Instance.Get();
            if(pref != null)
            {
                jToggle1.Checked = pref.registerPckExtension;
            }
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private Preferences pref;

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PackConfigs.compression = (int)numericUpDown1.Value;
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            if (pref != null)
            {
                pref.registerPckExtension = jToggle1.Checked;
                PreferencesManager.Instance.Set(pref);
            }
            FileAssociation fa = new FileAssociation();
            fa.ExecutableFilePath = Application.ExecutablePath;
            fa.FileTypeDescription = "Perfect World Editor By JHS.";
            fa.IsAdd = jToggle1.Checked;
            fa.Extension = ".pck";
            fa.ProgId = "PckOpener";
            fa.AppId = (int)EditorsColors.Pck_Editor;
            FileAssociations.EnsureAssociationsSet(fa);
        }
    }
}
