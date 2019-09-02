using JHUI.Forms;
using sTASKedit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElementEditor
{
    public partial class ProcTypeGenerator : JForm
    {
        private int value = -1;
        public static string value_tosave = "";
        public ProcTypeGenerator(int _value)
        {
            value = _value;
            InitializeComponent();
            int p = 0;
            while (p < 16)
            {

                switch (p)
                {
                    case 0:
                        checkedListBox1.Items.Add("Doesn't drop on death");//proc_type_1
                        break;
                    case 1:
                        checkedListBox1.Items.Add("Unable to be discarded");//proc_type_2
                        break;
                    case 2:
                        checkedListBox1.Items.Add("Unable to be sold");//proc_type_4
                        break;
                    case 3:
                        checkedListBox1.Items.Add("Equipping bound (Hidden 8)");//proc_type_8
                        break;
                    case 4:
                        checkedListBox1.Items.Add("Unable to be traded");//proc_type_16
                        break;
                    case 5:
                        checkedListBox1.Items.Add("(Hidden 32)");//proc_type_32
                        break;
                    case 6:
                        checkedListBox1.Items.Add("Equipping bound.");//proc_type_64
                        break;
                    case 7:
                        checkedListBox1.Items.Add("Expires when leaving area. (Hidden 128)");//proc_type_128
                        break;
                    case 8:
                        checkedListBox1.Items.Add("Expires when leaving area.");//proc_type_256
                        break;
                    case 9:
                        checkedListBox1.Items.Add("Used once picked up");//proc_type_512
                        break;
                    case 10:
                        checkedListBox1.Items.Add("Drops upon death");//proc_type_1024
                        break;
                    case 11:
                        checkedListBox1.Items.Add("Lost when player logs off");//proc_type_2048
                        break;
                    case 12:
                        checkedListBox1.Items.Add("Can't Repair");//proc_type_4096
                        break;
                    case 13:
                        checkedListBox1.Items.Add("Can't Repair (Hidden 8192)");//proc_type_8192
                        break;
                    case 14:
                        checkedListBox1.Items.Add("Unable to be put into Account Stash");//proc_type_16384
                        break;
                    case 15:
                        checkedListBox1.Items.Add("Unable to be put into Account Stash (Hidden 32768)");//proc_type_32768
                        break;
                }
                p++;
            }
            List<uint> powers = new List<uint>(Extensions.GetPowers((uint)_value));
            for (int x = 0; x < powers.Count; x++)
            {
                if (powers[x] == 0) continue;
                try
                {
                    checkedListBox1.SetItemChecked(x, true);
                }
                catch { }
            }
            resultBox.Text = "" + _value;
            ProcTypeGenerator.value_tosave = _value.ToString();
        }

        private int getCValue(int p)
        {
            switch (p)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                case 4:
                    return 2;
                case 8:
                    return 3;
                case 16:
                    return 4;
                case 32:
                    return 5;
                case 64:
                    return 6;
                case 128:
                    return 7;
                case 256:
                    return 8;
                case 512:
                    return 9;
                case 1024:
                    return 10;
                case 2048:
                    return 11;
                case 4098:
                    return 12;
                case 8192:
                    return 13;
                case 16384:
                    return 14;
                case 32768:
                    return 15;
                default:
                    return 0;
            }
        }

        private int getValue(int p)
        {
            switch (p)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 4;
                case 3:
                    return 8;
                case 4:
                    return 16;
                case 5:
                    return 32;
                case 6:
                    return 64;
                case 7:
                    return 128;
                case 8:
                    return 256;
                case 9:
                    return 512;
                case 10:
                    return 1024;
                case 11:
                    return 2048;
                case 12:
                    return 4096;
                case 13:
                    return 8192;
                case 14:
                    return 16384;
                case 15:
                    return 32768;
                default:
                    return 0;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    result += getValue(i);
                }
            }
            ProcTypeGenerator.value_tosave = result.ToString();
            resultBox.Text = "" + result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
            ProcTypeGenerator.value_tosave = "32768";
            resultBox.Text = "32768";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            ProcTypeGenerator.value_tosave = "0";
            resultBox.Text = "0";
        }
    }
}
