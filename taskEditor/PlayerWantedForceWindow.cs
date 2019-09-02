
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
	public partial class PlayerWantedForceWindow: JForm
    {
        uint value = 0;
        private TaskEditor MainWindow;
        public PlayerWantedForceWindow(TaskEditor MainWindow, int i)
		{
			InitializeComponent();
            this.MainWindow = MainWindow;
            this.SetLocalization();
            textBox_Force.Text = i.ToString();
            Force_ClickChanged();
		}

        private void Force_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                value += uint.Parse(((CheckBox)sender).Tag.ToString());
            else
                value -= uint.Parse(((CheckBox)sender).Tag.ToString());

            textBox_Force.Text = value.ToString();
        }

        public void Force_ClickChanged()
        {
            uint force;
            bool result = uint.TryParse(textBox_Force.Text, out force);

            if (!result)
                throw new Exception(Extensions.GetLocalization(403));

            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i].GetType().Name == "CheckBox")
                    ((CheckBox)Controls[i]).Checked = false;

            List<uint> powers = new List<uint>(GetPowers(force));

            for (int p = 0; p < powers.Count; p++)
            {
                if (powers[p] == 0) continue;

                switch (p)
                {
                    case 0:
                        checkBox_Force_1.Checked = true;
                        break;
                    case 1:
                        checkBox_Force_2.Checked = true;
                        break;
                    case 2:
                        checkBox_Force_3.Checked = true;
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
            MainWindow.ChangePlayerWantedForce(Convert.ToInt32(textBox_Force.Text));
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6007);
            checkBox_Force_1.Text = Extensions.GetLocalization(6008);
            checkBox_Force_2.Text = Extensions.GetLocalization(6009);
            checkBox_Force_3.Text = Extensions.GetLocalization(6010);
            button_Ok.Text = Extensions.GetLocalization(6011);
            button_Cancel.Text = Extensions.GetLocalization(6012);
        }
	}
}

