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
    public partial class PckMoveFixer : JForm
    {
        static public string oldValue = "";
        static public string newValue = "";

        public PckMoveFixer(string title = null)
        {
            DialogResult = DialogResult.Cancel;
            PckMoveFixer.oldValue = "";
            PckMoveFixer.newValue = "";
            InitializeComponent();
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            PckMoveFixer.oldValue = jTextBox1.Text;
            PckMoveFixer.newValue = jTextBox2.Text;
        }

        private void RenameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
