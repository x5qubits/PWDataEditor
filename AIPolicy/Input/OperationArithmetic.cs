using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.AIPolicy.Input
{
    public partial class OperationArithmetic : UserControl
    {
        private string value = "";
        private string condition = "";
        public event EventHandler onChange = delegate { };
        private int y = 17;
        public OperationArithmetic()
        {
            InitializeComponent();
            operationType.SelectedIndex = 0;
            button2.Location = new Point(0, y);
            operationType.Location = new Point(button2.Width, y);
            textBox1.Location = new Point(button2.Width + operationType.Width, y);
            this.Width = button2.Width + operationType.Width;
        }

        private void operationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox1.Text = "";
            switch (operationType.SelectedIndex)
            {
                case 10://Var
                    textBox1.Visible = true;
                    textBox1.Text = "0";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                default:
                    this.Width = button2.Width + operationType.Width;
                    break;
            }
            this.condition = this.operationType.Items[operationType.SelectedIndex].ToString();
            this.value = this.textBox1.Text;
            if(onChange != null)
            {
                onChange(this, null);
            }
        }

        private void OperationCondition_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void OperationCondition_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(17, 17, 17);
        }

        internal string toString()
        {
            if(condition.Equals("Var"))
            {
                return value;
            }
            return condition;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkRed;
        }

        internal void setOperation(string v)
        {
            if (operationType.Items.Contains(v))
            {
                operationType.SelectedIndex = operationType.Items.IndexOf(v);
                this.condition = v;
            }
        }

        internal void SetText1(string v)
        {
            this.textBox1.Text = v;
            this.value = this.textBox1.Text;
            if (onChange != null)
            {
                onChange(this, null);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetText1(this.textBox1.Text);
            if (onChange != null)
            {
                onChange(this, null);
            }
        }
    }
}
