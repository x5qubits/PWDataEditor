using JHUI.Forms;
using System;

namespace ElementEditor
{
    public partial class ImportOption : JForm
    {
        private bool locked = false;

        public ImportOption()
        {
            InitializeComponent();
            ElementsEditor.isImportInThisList = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            locked = true;
            ElementsEditor.isImportWithAdd = true;
            ElementsEditor.isImportWithReplace = false;
            ElementsEditor.isImportWithDelete = false;
            ElementsEditor.isImportNewOnly = false;
            ElementsEditor.importWithReplaceAndAddNew = false;
            jCheckBox2.Checked = false;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            jCheckBox1.Checked = false;
            locked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            locked = true;
            ElementsEditor.isImportWithAdd = false;
            ElementsEditor.isImportWithReplace = true;
            ElementsEditor.isImportWithDelete = false;
            ElementsEditor.isImportNewOnly = false;
            ElementsEditor.importWithReplaceAndAddNew = false;
            jCheckBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox3.Checked = false;
            jCheckBox1.Checked = false;
            locked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            locked = true;
            ElementsEditor.isImportWithAdd = false;
            ElementsEditor.isImportWithReplace = false;
            ElementsEditor.isImportWithDelete = true;
            ElementsEditor.isImportNewOnly = false;
            ElementsEditor.importWithReplaceAndAddNew = false;
            jCheckBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            jCheckBox1.Checked = false;
            checkBox3.Checked = true;
            locked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ElementsEditor.isImportcanceled = false;
            this.Close();
        }

        private void ImportOption_Shown(object sender, EventArgs e)
        {
            if (locked) { return; }
            locked = true;
            checkBox1.Checked = ElementsEditor.isImportWithAdd;
            checkBox2.Checked = ElementsEditor.isImportWithReplace;
            checkBox3.Checked = ElementsEditor.isImportWithDelete;
            jCheckBox1.Checked = ElementsEditor.isImportNewOnly;
            jCheckBox2.Checked = ElementsEditor.importWithReplaceAndAddNew;
            locked = false;
        }

        private void jCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            locked = true;
            ElementsEditor.isImportWithAdd = false;
            ElementsEditor.isImportWithReplace = false;
            ElementsEditor.isImportWithDelete = false;
            ElementsEditor.isImportNewOnly = true;
            ElementsEditor.importWithReplaceAndAddNew = false;
            jCheckBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            jCheckBox1.Checked = true;
            checkBox3.Checked = false;
            locked = false;
        }

        private void jCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (locked) { return; }
            locked = true;
            ElementsEditor.isImportWithAdd = false;
            ElementsEditor.isImportWithReplace = false;
            ElementsEditor.isImportWithDelete = false;
            ElementsEditor.isImportNewOnly = false;
            ElementsEditor.importWithReplaceAndAddNew = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            jCheckBox1.Checked = false;
            checkBox3.Checked = false;
            jCheckBox2.Checked = true;
            locked = false;
        }

        private void jCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            ElementsEditor.isImportInThisList = jCheckBox3.Checked;
        }
    }
}
