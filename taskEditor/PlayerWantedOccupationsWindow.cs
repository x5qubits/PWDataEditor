
using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace sTASKedit
{
	public partial class PlayerWantedOccupationsWindow: JForm
    {
        uint value = 0;
        private TaskEditor MainWindow;
        public PlayerWantedOccupationsWindow(TaskEditor MainWindow, int i)
		{
			InitializeComponent();
            this.MainWindow = MainWindow;
            this.SetLocalization();
            textBox_Occupations.Text = i.ToString();
            Occupations_ClickChanged();
		}

        private void Occupations_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                value += uint.Parse(((CheckBox)sender).Tag.ToString());
            else
                value -= uint.Parse(((CheckBox)sender).Tag.ToString());

            textBox_Occupations.Text = value.ToString();
        }

        public void Occupations_ClickChanged()
        {
            uint occupations;
            bool result = uint.TryParse(textBox_Occupations.Text, out occupations);

            if (!result)
                throw new Exception(Extensions.GetLocalization(403));

            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i].GetType().Name == "CheckBox")
                    ((CheckBox)Controls[i]).Checked = false;

            List<uint> powers = new List<uint>(GetPowers(occupations));

            for (int p = 0; p < powers.Count; p++)
            {
                if (powers[p] == 0) continue;

                switch (p)
                {
                    case 0:
                        checkBox_Occupation_1.Checked = true;
                        break;
                    case 1:
                        checkBox_Occupation_2.Checked = true;
                        break;
                    case 2:
                        checkBox_Occupation_3.Checked = true;
                        break;
                    case 3:
                        checkBox_Occupation_4.Checked = true;
                        break;
                    case 4:
                        checkBox_Occupation_5.Checked = true;
                        break;
                    case 5:
                        checkBox_Occupation_6.Checked = true;
                        break;
                    case 6:
                        checkBox_Occupation_7.Checked = true;
                        break;
                    case 7:
                        checkBox_Occupation_8.Checked = true;
                        break;
                    case 8:
                        checkBox_Occupation_9.Checked = true;
                        break;
                    case 9:
                        checkBox_Occupation_10.Checked = true;
                        break;
                    case 10:
                        checkBox_Occupation_11.Checked = true;
                        break;
                    case 11:
                        checkBox_Occupation_12.Checked = true;
                        break;
                }
            }
        }

        IEnumerable<uint> GetPowers(uint value)
        {
            uint v = value;
            while (v > 0)
            {
                yield return (v & 0x01);
                v >>= 1;
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangePlayerWantedOccupations(Convert.ToInt32(textBox_Occupations.Text));
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6000);
            checkBox_Occupation_1.Text = Extensions.GetLocalization(1120);
            checkBox_Occupation_2.Text = Extensions.GetLocalization(1121);
            checkBox_Occupation_3.Text = Extensions.GetLocalization(1122);
            checkBox_Occupation_4.Text = Extensions.GetLocalization(1123);
            checkBox_Occupation_5.Text = Extensions.GetLocalization(1124);
            checkBox_Occupation_6.Text = Extensions.GetLocalization(1125);
            checkBox_Occupation_7.Text = Extensions.GetLocalization(1126);
            checkBox_Occupation_8.Text = Extensions.GetLocalization(1127);
            checkBox_Occupation_9.Text = Extensions.GetLocalization(1128);
            checkBox_Occupation_10.Text = Extensions.GetLocalization(1129);
            checkBox_Occupation_11.Text = Extensions.GetLocalization(1130);
            checkBox_Occupation_12.Text = Extensions.GetLocalization(1131);
            button_Ok.Text = Extensions.GetLocalization(6001);
            button_Cancel.Text = Extensions.GetLocalization(6002);
        }
	}
}

