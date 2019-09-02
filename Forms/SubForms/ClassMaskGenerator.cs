using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElementEditor
{
    public partial class ClassMaskGenerator : JForm
    {
        private bool lockCheckBox = false;
        private int value = -1;
        public ClassMaskGenerator(int _value)
        {
            value = _value;
            InitializeComponent();
        }

        private void checkboxClick(object sender, EventArgs e)
        {
            if (!lockCheckBox)
            {
                int number = 0;

                if (checkBoxBM.Checked)
                {
                    number += 1;
                }
                if (checkBoxMG.Checked)
                {
                    number += 2;
                }
                if (checkBoxPS.Checked)
                {
                    number += 4;
                }
                if (checkBoxVE.Checked)
                {
                    number += 8;
                }
                if (checkBoxWB.Checked)
                {
                    number += 16;
                }
                if (checkBoxSIN.Checked)
                {
                    number += 32;
                }
                if (checkBoxEA.Checked)
                {
                    number += 64;
                }
                if (checkBoxEP.Checked)
                {
                    number += 128;
                }
                if (checkBoxSE.Checked)
                {
                    number += 256;
                }
                if (checkBoxMY.Checked)
                {
                    number += 512;
                }
                if (checkBoxDU.Checked)
                {
                    number += 1024;
                }
                if (checkBoxSU.Checked)
                {
                    number += 2048;
                }
                ElementsEditor.selectedMask = number;
                resultBox.Text = number.ToString();
            }
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {
            lockCheckBox = true;
            int number = Int32.Parse(resultBox.Text);
            ElementsEditor.selectedMask = number;
            if (number / 2048 > 0)
            {
                number = number % 2048;
                checkBoxSU.Checked = true;
            }
            else
            {
                checkBoxSU.Checked = false;
            }

            if (number / 1024 > 0)
            {
                number = number % 1024;
                checkBoxDU.Checked = true;
            }
            else
            {
                checkBoxDU.Checked = false;
            }

            if (number / 512 > 0)
            {
                number = number % 512;
                checkBoxMY.Checked = true;
            }
            else
            {
                checkBoxMY.Checked = false;
            }

            if (number / 256 > 0)
            {
                number = number % 256;
                checkBoxSE.Checked = true;
            }
            else
            {
                checkBoxSE.Checked = false;
            }

            if (number / 128 > 0)
            {
                number = number % 128;
                checkBoxEP.Checked = true;
            }
            else
            {
                checkBoxEP.Checked = false;
            }

            if (number / 64 > 0)
            {
                number = number % 64;
                checkBoxEA.Checked = true;
            }
            else
            {
                checkBoxEA.Checked = false;
            }

            if (number / 32 > 0)
            {
                number = number % 32;
                checkBoxSIN.Checked = true;
            }
            else
            {
                checkBoxSIN.Checked = false;
            }

            if (number / 16 > 0)
            {
                number = number % 16;
                checkBoxWB.Checked = true;
            }
            else
            {
                checkBoxWB.Checked = false;
            }

            if (number / 8 > 0)
            {
                number = number % 8;
                checkBoxVE.Checked = true;
            }
            else
            {
                checkBoxVE.Checked = false;
            }

            if (number / 4 > 0)
            {
                number = number % 4;
                checkBoxPS.Checked = true;
            }
            else
            {
                checkBoxPS.Checked = false;
            }

            if (number / 2 > 0)
            {
                number = number % 2;
                checkBoxMG.Checked = true;
            }
            else
            {
                checkBoxMG.Checked = false;
            }

            if (number / 1 > 0)
            {
                number = number % 1;
                checkBoxBM.Checked = true;
            }
            else
            {
                checkBoxBM.Checked = false;
            }
            lockCheckBox = false;
        }

        private void ClassMaskGenerator_Shown(object sender, EventArgs e)
        {
            lockCheckBox = true;
            int number = value;
            resultBox.Text = number.ToString();
            if (number / 2048 > 0)
            {
                number = number % 2048;
                checkBoxSU.Checked = true;
            }
            else
            {
                checkBoxSU.Checked = false;
            }

            if (number / 1024 > 0)
            {
                number = number % 1024;
                checkBoxDU.Checked = true;
            }
            else
            {
                checkBoxDU.Checked = false;
            }

            if (number / 512 > 0)
            {
                number = number % 512;
                checkBoxMY.Checked = true;
            }
            else
            {
                checkBoxMY.Checked = false;
            }

            if (number / 256 > 0)
            {
                number = number % 256;
                checkBoxSE.Checked = true;
            }
            else
            {
                checkBoxSE.Checked = false;
            }

            if (number / 128 > 0)
            {
                number = number % 128;
                checkBoxEP.Checked = true;
            }
            else
            {
                checkBoxEP.Checked = false;
            }

            if (number / 64 > 0)
            {
                number = number % 64;
                checkBoxEA.Checked = true;
            }
            else
            {
                checkBoxEA.Checked = false;
            }

            if (number / 32 > 0)
            {
                number = number % 32;
                checkBoxSIN.Checked = true;
            }
            else
            {
                checkBoxSIN.Checked = false;
            }

            if (number / 16 > 0)
            {
                number = number % 16;
                checkBoxWB.Checked = true;
            }
            else
            {
                checkBoxWB.Checked = false;
            }

            if (number / 8 > 0)
            {
                number = number % 8;
                checkBoxVE.Checked = true;
            }
            else
            {
                checkBoxVE.Checked = false;
            }

            if (number / 4 > 0)
            {
                number = number % 4;
                checkBoxPS.Checked = true;
            }
            else
            {
                checkBoxPS.Checked = false;
            }

            if (number / 2 > 0)
            {
                number = number % 2;
                checkBoxMG.Checked = true;
            }
            else
            {
                checkBoxMG.Checked = false;
            }

            if (number / 1 > 0)
            {
                number = number % 1;
                checkBoxBM.Checked = true;
            }
            else
            {
                checkBoxBM.Checked = false;
            }
           
            lockCheckBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBoxBM.Checked = true;
            checkBoxMG.Checked = true;
            checkBoxPS.Checked = true;
            checkBoxVE.Checked = true;
            checkBoxWB.Checked = true;
            checkBoxSIN.Checked = true;
            checkBoxEA.Checked = true;
            checkBoxEP.Checked = true;
            checkBoxSE.Checked = true;
            checkBoxMY.Checked = true;
            checkBoxDU.Checked = true;
            checkBoxSU.Checked = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkBoxBM.Checked = false;
            checkBoxMG.Checked = false;
            checkBoxPS.Checked = false;
            checkBoxVE.Checked = false;
            checkBoxWB.Checked = false;
            checkBoxSIN.Checked = false;
            checkBoxEA.Checked = false;
            checkBoxEP.Checked = false;
            checkBoxSE.Checked = false;
            checkBoxMY.Checked = false;
            checkBoxDU.Checked = false;
            checkBoxSU.Checked = false;
        }
    }
}
