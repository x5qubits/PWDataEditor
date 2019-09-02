using AIPolicy;
using JHUI.Controls;
using JHUI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PWDataEditorPaied.AIPolicy.Input
{
    public partial class EditMessage : JForm
    {
        private JTextBox RTB;
        private System.ComponentModel.IContainer components = null;
        public string Result
        {
          get
          {
            return this.RTB.Text;
          }
        }

        public EditMessage()
        {
          this.InitializeComponent();
        }

        public void SetText(string text)
        {
            if (text.Length > 0)
            {
                this.RTB.Text = text;
                if ((int)this.RTB.Text[0] != 34 || (int)this.RTB.Text[this.RTB.Text.Length - 1] != 34)
                    return;
                this.RTB.Text = this.RTB.Text.Substring(1, this.RTB.Text.Length - 2);
            }else
                { this.RTB.Text = ""; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
          this.DialogResult = DialogResult.OK;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMessage));
            this.RTB = new JHUI.Controls.JTextBox();
            this.SuspendLayout();
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.RTB.CustomButton.Image = null;
            this.RTB.CustomButton.Location = new System.Drawing.Point(294, 1);
            this.RTB.CustomButton.Name = "";
            this.RTB.CustomButton.Size = new System.Drawing.Size(77, 77);
            this.RTB.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.RTB.CustomButton.TabIndex = 1;
            this.RTB.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.RTB.CustomButton.UseSelectable = true;
            this.RTB.CustomButton.Visible = false;
            this.RTB.Lines = new string[0];
            this.RTB.Location = new System.Drawing.Point(18, 27);
            this.RTB.MaxLength = 32767;
            this.RTB.Multiline = true;
            this.RTB.Name = "RTB";
            this.RTB.PasswordChar = '\0';
            this.RTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RTB.SelectedText = "";
            this.RTB.SelectionLength = 0;
            this.RTB.SelectionStart = 0;
            this.RTB.ShortcutsEnabled = true;
            this.RTB.Size = new System.Drawing.Size(372, 79);
            this.RTB.Style = JHUI.JColorStyle.Silver;
            this.RTB.TabIndex = 0;
            this.RTB.TextWaterMark = "";
            this.RTB.Theme = JHUI.JThemeStyle.Dark;
            this.RTB.UseSelectable = true;
            this.RTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.RTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // EditMessage
            // 
            this.ClientSize = new System.Drawing.Size(413, 129);
            this.Controls.Add(this.RTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Silver;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditMessage_FormClosing);
            this.ResumeLayout(false);

        }

        private void EditMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
