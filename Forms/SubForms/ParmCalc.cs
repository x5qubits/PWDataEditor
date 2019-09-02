using ElementEditor.classes;
using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.helper_classes
{
    public partial class ParmCalc : JForm
    {
        public ParmCalc(String value)
        {
            InitializeComponent();
            textBox2.Text = value;
        }

        private void floatValueChange(object sender, EventArgs e)
        {
            float n = -1;
            bool isInt = float.TryParse(textBox1.Text, out n);
            if (isInt)
            {
                byte[] bytes = BitConverter.GetBytes(n);
                textBox2.Text = BitConverter.ToInt32(bytes, 0).ToString();
            }
        }

        private void CryptedValueChanged(object sender, EventArgs e)
        {
           ///String text = "Float: " + (BitConverter.ToSingle(BitConverter.GetBytes(int.Parse(eLC.GetValue(list, element, f))), 0)).ToString("F6");

            int n = -1;
            bool isInt = int.TryParse(textBox2.Text, out n);
            if(isInt)
            {
                byte[] bytes = BitConverter.GetBytes(n);
                textBox1.Text = BitConverter.ToSingle(bytes, 0).ToString("F6");
                Constatns.valueParm = textBox2.Text;
            }
            
        }
    }
}
