using ElementEditor;
using JHUI;
using JHUI.Forms;
using PWDataEditorPaied.Database;
using sTASKedit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied.Forms.SubForms
{
    public partial class MainFormSettings : JForm
    {
        public MainFormSettings()
        {
            InitializeComponent();
        }
        private bool locked = false;
        private int lictype = 0;
        private Preferences pref;

        private void MainFormSettings_Shown(object sender, EventArgs e)
        {
            locked = true;
            lictype = (int)LicenceManager.type;
            pref = PreferencesManager.Instance.Get();
            if(lictype != pref.type)
            {
                pref = new Preferences(2);
                PreferencesManager.Instance.Set(pref);
            }
            jCheckBox2.Checked = pref.allTimeOntop;
            jCheckBox1.Checked = pref.RememberLastLocation;
            jCheckBox5.Checked = pref.ShowElementOnStart;
            jCheckBox3.Checked = pref.DisplayMinimize;
            jCheckBox4.Checked = pref.HideFormCompleatlyOnClose;
            if (LicenceManager.Products[(int)Editors.SkinChanger] == 1)
            {
                
                string[] editors = Enum.GetNames(typeof(EditorsColors));
                editorsListBox.Items.Clear();
                foreach (string str in editors)
                {
                    editorsListBox.Items.Add(str.Replace("_", " "));
                }
                string[] colors = Enum.GetNames(typeof(JColorStyle));
                styleListBox.Items.Clear();
                foreach (string str in colors)
                {
                    styleListBox.Items.Add(str.Replace("_", " "));
                }
                locked = false;
                editorsListBox.SelectedIndex = 0;
            }
            else
            {
                jGroupBox1.Text = jGroupBox1.Text + " - " + Extensions.GetLocalization(7500);
                jGroupBox1.Enabled = false;
            }
            locked = false;
        }

        private void editorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            int index3 = editorsListBox.SelectedIndex;
            if (index3 == -1)
            {
                JMessageBox.Show(this, "Please select a Editor.");
                return;
            }
            jComboBox1.SelectedIndex = (int)pref.teme[index3] - 1;
            styleListBox.SelectedIndex = (int)pref.color[index3];
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            if (locked) { return; }
            int index = jComboBox1.SelectedIndex;
            JThemeStyle teme = JThemeStyle.Light;
            JColorStyle color = JColorStyle.Default;
            int index2 = styleListBox.SelectedIndex;
            int index3 = editorsListBox.SelectedIndex;
            if (index2 == -1)
            {
                JMessageBox.Show(this, "Please select a color.");
                return;
            }
            if (index == -1)
            {
                JMessageBox.Show(this, "Please select a template.");
                return;
            }
            if (index3 == -1)
            {
                JMessageBox.Show(this, "Please select a Editor.");
                return;
            }
            color = (JColorStyle)index2;
            if (index == 1)
                teme = JThemeStyle.Dark;

            pref.teme[index3] = teme;
            pref.color[index3] = color;
            PreferencesManager.Instance.Set(pref);
            MainProgram.getInstance().setTemplate(teme, color, (EditorsColors)index3);
        }

        private void jCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            pref.allTimeOntop = jCheckBox2.Checked;
            PreferencesManager.Instance.Set(pref);
            MainProgram.getInstance().AllTimeOntop(jCheckBox2.Checked);
        }

        private void jCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            pref.RememberLastLocation = jCheckBox1.Checked;
            PreferencesManager.Instance.Set(pref);
        }

        private void jCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            pref.DisplayMinimize = jCheckBox3.Checked;
            Program.SHOWMINIMIZEBUTTON = jCheckBox3.Checked;
            PreferencesManager.Instance.Set(pref);
        }

        private void jCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            pref.HideFormCompleatlyOnClose = jCheckBox4.Checked;
            Program.HIDEINTASKBAR = jCheckBox4.Checked;
            PreferencesManager.Instance.Set(pref);
        }

        private void jCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            pref.ShowElementOnStart = jCheckBox5.Checked;
            PreferencesManager.Instance.Set(pref);
        }
    }
}
