
using ElementEditor.classes;
using JHUI.Forms;
using JHUI.Utils;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ElementEditor.helper_classes
{
    public partial class IToolType : JForm
    {
        public IToolType(InfoTool data)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(32, 32, 32);
            this.Opacity = 0;
            fadeTimer = new Timer { Interval = 15, Enabled = true };
            fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
            mCurrentPoint = Cursor.Position;
            Left = (int)mCurrentPoint.X + 30;
            Top = (int)mCurrentPoint.Y;
           
            int itemID = 0;
            if (ElementsEditor.database.item_color.ContainsKey(data.itemId))
            {
                itemID = ElementsEditor.database.item_color[data.itemId];
            }
            Color color = Helper.getByID(itemID);
            titleText.Text = data.name + " ["+ data.itemId + "]";
            titleText.ForeColor = color;
            iconBox.Image = data.img;
            string line = data.basicAdons;
            line += data.time;
            line += data.addons;
            line += data.protect;
            line += data.description;
            change_preview(line);

            this.Height = 50 + richTextBox_PreviewText.Height;

            Size Size = Screen.PrimaryScreen.WorkingArea.Size;
            int yx = Size.Height;
            if (this.Bottom > yx)
            {
                 this.Top = this.Top - this.Height;
            }
        }
        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
        }

        private void change_preview(String description)
        {
            String line = description.Replace("\\r", Environment.NewLine).Replace("\\n", Environment.NewLine);
            string defaultcolor = "^FFFFFF";
            Color tmp = Color.FromArgb(int.Parse(defaultcolor.Substring(1, 6), NumberStyles.HexNumber));
            string[] blocks = line.Split(new char[] { '^' });
            if (blocks.Length > 1)
            {
                int le1 = 0;
                this.richTextBox_PreviewText.Text = "";
                le1 = (line.IndexOf('^', 0));
                this.richTextBox_PreviewText.AppendText(string.Format(line.Substring(0, le1)));
                this.richTextBox_PreviewText.Select(0, le1);
                this.richTextBox_PreviewText.SelectionColor = tmp;
                string result = "";

                if (blocks[0] != "")
                {
                    result += blocks[0];
                }

                int le = 0;
                int st = 0;
                Color color = tmp;
                for (int i = 1; i < blocks.Length; i++)
                {
                    if (blocks[i] != "")
                    {
                        st = this.richTextBox_PreviewText.Text.Length;
                        try
                        {
                            if (blocks[i].Substring(0, 6).ToUpper() == "FFFFFF")
                            {
                                color = tmp;
                            }
                            else
                            {
                                color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                            }
                            this.richTextBox_PreviewText.AppendText(string.Format(blocks[i].Substring(6)));
                        }
                        catch
                        {
                            this.richTextBox_PreviewText.AppendText(string.Format("^" + blocks[i]));
                        }
                        le = this.richTextBox_PreviewText.Text.Length - st;
                        this.richTextBox_PreviewText.Select(st, le);
                        this.richTextBox_PreviewText.SelectionColor = color;
                    }
                }
            }
            else
            {
                this.richTextBox_PreviewText.Text = line;
                this.richTextBox_PreviewText.Select(0, this.richTextBox_PreviewText.Text.Length);
                this.richTextBox_PreviewText.SelectionColor = tmp;
            }
            this.richTextBox_PreviewText.Multiline = true;
            this.richTextBox_PreviewText.DeselectAll();
            titleText.Focus();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x204) return; // WM_RBUTTONDOWN
            if (m.Msg == 0x205) return; // WM_RBUTTONUP
            base.WndProc(ref m);
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
                return;
            this.Opacity += 0.04;
            if (this.Opacity >= 0.99)
            {
                fadeTimer.Enabled = false;
            }
        }

        Timer fadeTimer;
        private Point mCurrentPoint;
    }
}
