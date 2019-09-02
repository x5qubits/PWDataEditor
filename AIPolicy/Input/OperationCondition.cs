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
    public partial class OperationCondition : UserControl
    {
        private string value = "";
        private string value2 = "";
        private string condition = "";
        public event EventHandler onChange = delegate { };
        private int y = 17;
        public OperationCondition()
        {
            InitializeComponent();
            operationType.SelectedIndex = 0;
            button2.Location = new Point(0, y);
            operationType.Location = new Point(button2.Width, y);
            textBox1.Location = new Point(button2.Width + operationType.Width, y);
            label1.Location = new Point(button2.Width + operationType.Width + textBox1.Width, y);
            textBox2.Location = new Point(button2.Width + operationType.Width + textBox1.Width + label1.Width, y);
        }

        private void operationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            switch (operationType.SelectedIndex)
            {
                case 0://Timer Running(ID)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 1://Hp Lower Than(fPercent)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0.00";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 2://Combat Started()
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width;
                    break;
                case 3://Random(fProbability)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0.00";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 4://Target Killed()
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width;
                    break;
                case 5://Died()
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width;
                    break;
                case 6://Public Counter(iID)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 7://Damage(iHurtLow,iHurtHigh)
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    this.Width = button2.Width + operationType.Width + textBox1.Width + textBox2.Width + label1.Width;
                    label1.Visible = true;
                    break;
                case 8://Path Ended(iPathID)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 9://History Stage(iID)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 10://History Value(iValue)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 11://Combat Ended()
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width;
                    break;
                case 12://History Value(iValue)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 13://Path Ended 2(iHurtLow,iHurtHigh)
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    this.Width = button2.Width + operationType.Width + textBox1.Width + textBox2.Width +  label1.Width;
                    label1.Visible = true;
                    break;
                case 14://History Value(iValue)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
                case 15://History Value(iValue)
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    this.Width = button2.Width + operationType.Width + textBox1.Width;
                    break;
            }
            this.condition = this.operationType.Items[operationType.SelectedIndex].ToString();
            this.value = this.textBox1.Text;
            this.value2 = this.textBox2.Text;
            if(onChange != null)
            {
                onChange(this, null);
            }
        }

        internal void setText1(string v)
        {
            textBox1.Text = v;
            this.value = this.textBox1.Text;
        }

        internal void setText2(string v)
        {
            textBox2.Text = v;
            this.value2 = this.textBox2.Text;
        }

        internal void SetOption(string v)
        {
           if( operationType.Items.Contains(v))
            {
                operationType.SelectedIndex = operationType.Items.IndexOf(v);
                this.condition = v;
                if (onChange != null)
                {
                    onChange(this, null);
                }
            }
        }

        internal string toString()
        {
            if(value.Length > 0 && value2.Length == 0)
            {
                return condition + "("+ value.Replace(',','.') +")";
            }
            else if(value.Length > 0 && value2.Length > 0)
            {
                return condition + "(" + value+","+ value2 + ")";
            }
            else
            {
                return condition + "()";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_DragEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkRed;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            setText1(this.textBox1.Text);
            if (onChange != null)
            {
                onChange(this, null);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            setText2(this.textBox2.Text);
            if (onChange != null)
            {
                onChange(this, null);
            }
        }
    }
}
