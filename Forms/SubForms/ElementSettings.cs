using ElementEditor;
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

namespace PWDataEditorPaied.Forms
{
    public partial class ElementSettings : JForm
    {
        private Preferences pref;
        private bool locked;

        public ElementSettings()
        {
            InitializeComponent();
            locked = true;
            minNextId.Text = DatabaseManager.Instance.nextId.ToString();
            maxNextId.Text = DatabaseManager.Instance.maxId.ToString();
            AutoNextId.Checked = DatabaseManager.Instance.autonewId;
            AutoLoadPck.Checked = DatabaseManager.Instance.AutoLoadPck;
            pref = PreferencesManager.Instance.Get();
            if(pref != null)
            {
                jToggle1.Checked = pref.registerDataExtension;
            }
            locked = false;
        }

        private void ElementSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            int n1;
            bool isNumeric1 = int.TryParse(minNextId.Text, out n1);
            int n2;
            bool isNumeric2 = int.TryParse(maxNextId.Text, out n2);
            if (!isNumeric1 || !isNumeric2)
            {
                e.Cancel = true;
                minNextId.Text = "1";
                maxNextId.Text = "80000";
            }
            else
            {
                DatabaseManager.Instance.updateSetting(AutoNextId.Checked, AutoLoadPck.Checked, n1, n2);
            }
        }

        private void minNextId_TextChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            int n;
            bool isNumeric = int.TryParse(minNextId.Text, out n);
            if (!isNumeric)
                minNextId.Text = "1";

        }

        private void maxNextId_TextChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            int n;
            bool isNumeric = int.TryParse(maxNextId.Text, out n);
            if (!isNumeric)
                maxNextId.Text = "80000";
        }

        private void jPictureBox3_Click(object sender, EventArgs e)
        {
            if (locked) { return; }
            int n = 1;
            bool isNumeric = int.TryParse(minNextId.Text, out n);
            if (!isNumeric)
                minNextId.Text = "1";
            minNextId.Text = ElementsEditor.eLC.getNextFreeId2(n).ToString();
        }

        private void jToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            if (pref != null)
            {
                pref.registerDataExtension = jToggle1.Checked;
                PreferencesManager.Instance.Set(pref);
            }
            FileAssociation fa = new FileAssociation();
            fa.ExecutableFilePath = Application.ExecutablePath;
            fa.FileTypeDescription = "Perfect World Editor By JHS.";
            fa.IsAdd = jToggle1.Checked;
            fa.Extension = ".data";
            fa.ProgId = "DataFiles";
            fa.AppId = 1985;
            FileAssociations.EnsureAssociationsSet(fa);
        }
    }
}
