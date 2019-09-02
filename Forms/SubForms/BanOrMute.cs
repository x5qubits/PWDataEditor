using ElementEditor.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied
{
    public partial class BanOrMute : Form
    {
        public BanOrMute(String roleID)
        {
            InitializeComponent();
            roleId.Text = roleID;
            Constatns.banType = -1;
            comboBox_chatChannel.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roleIdx = 0;
            bool numericRoleId = int.TryParse(roleId.Text, out roleIdx);
            int banTime = 0;
            bool numericMinutes = int.TryParse(Minutes.Text, out banTime);
            if (!numericRoleId)
            {
                MessageBox.Show("Please input role id");
                return;
            }
            if (!numericMinutes)
            {
                MessageBox.Show("Please input muntes");
                return;
            }
            Constatns.banType = int.Parse(comboBox_chatChannel.Items[comboBox_chatChannel.SelectedIndex].ToString().Split(' ')[0]);
            Constatns.banMins = banTime * 60;
            Constatns.chatTobeBanedID = roleIdx;
            Constatns.reason = textBox1.Text;
            this.Close();
        }
    }
}
