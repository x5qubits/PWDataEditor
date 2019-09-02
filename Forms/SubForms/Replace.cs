using JHUI.Forms;
using System;

namespace PWDataEditorPaied.Forms
{
    public partial class Replace : JForm
    {
        private bool locked = false;
        static public string OldValue { get; set; }
        static public string NewValue { get; set; }
        static public bool Changed { get; set; }
        static public int replaceIndexType { get; set; }
        static public int SelectedOperation { get; set; } = 5;
        static public string OldValueFinal { get; set; } = "";
        static public string NewValueFinal { get; set; } = "";
        public Replace()
        {
            InitializeComponent();
            locked = true;
            replaceSelected.SelectedIndex = 0;
            replaceIndexType = replaceSelected.SelectedIndex;
            OldValue = textBox_oldValue.Text;
            NewValue = textBox_newValue.Text;
            Changed = false;
            locked = false;
            jLabel4.Visible = false;
            replaceSelected.SelectedIndex = Replace.SelectedOperation;
            textBox_oldValue.Text = Replace.OldValueFinal;
            textBox_newValue.Text = Replace.NewValueFinal;
        }

        private void replaceSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) return;
            this.jLabel3.Text = replaceSelected.Items[replaceSelected.SelectedIndex].ToString() + " Selected Rows";
            if(replaceSelected.SelectedIndex == 5)
                jLabel4.Visible = true;
            else
                jLabel4.Visible = false;
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            Changed = true;
            replaceIndexType = replaceSelected.SelectedIndex;
            OldValue = textBox_oldValue.Text;
            NewValue = textBox_newValue.Text;
            Replace.SelectedOperation = replaceIndexType;
            Replace.OldValueFinal = OldValue;
            Replace.NewValueFinal = NewValue;

            this.Close();
        }

        private void textBox_oldValue_TextChanged(object sender, EventArgs e)
        {
            OldValue = textBox_oldValue.Text;
        }

        private void textBox_newValue_TextChanged(object sender, EventArgs e)
        {
            NewValue = textBox_newValue.Text;
        }

        private void jLabel4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.mikesdotnetting.com/article/46/c-regular-expressions-cheat-sheet");
        }
    }
}
