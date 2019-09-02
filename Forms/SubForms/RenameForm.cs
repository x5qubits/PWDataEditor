using JHUI.Forms;
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
    public partial class RenameForm : JForm
    {
        static public string value = "";
        public RenameForm(string title = null)
        {
            InitializeComponent();

            if (title == null)
            {
                this.Text = "Choose Name";
            }else
            {
                this.Text = title;
            }
            DialogResult = DialogResult.Cancel;
            RenameForm.value = "";
           
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            RenameForm.value = jTextBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void RenameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
