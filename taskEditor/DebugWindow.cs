using JHUI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace sTASKedit
{
	public partial class DebugWindow:JForm
	{
        public DebugWindow(string Title, string Message)
		{
            try
            {
                this.InitializeComponent();
                this.Text = Title;
                this.textBox_Message.Text = Message;
                this.textBox_Message.SelectionStart = 0;
                this.textBox_Message.SelectionLength = 0;
                base.Show();
            }
            catch
            {
                base.Dispose(true);
            }
		}
	}
}