using AIPolicy;
using JHUI.Controls;
using JHUI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AIPolicy.Input
{
    internal class AddTrigger : JForm
    {
        private IContainer components = (IContainer)null;
        private JTextBox IndexTB;
        private JTextBox NameTB;

        private Policy CurrentPolicy { get; set; }

        public Trigger Result { get; private set; }

        public AddTrigger()
        {
            this.InitializeComponent();
        }

        public void SetPolicy(Policy pol)
        {
            this.CurrentPolicy = pol;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            int result;
            if (!int.TryParse(this.IndexTB.Text, out result))
            {
                int num = (int)MessageBox.Show("Invalid input in field index.");
            }
            else
            {
                if (this.CurrentPolicy.GetListIndex(result) != -1 && MessageBox.Show("Warning: Index already exists. Trigger will be overwritten. Do you wish to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                this.Result = new Trigger(this.CurrentPolicy, result, this.NameTB.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTrigger));
            this.IndexTB = new JHUI.Controls.JTextBox();
            this.NameTB = new JHUI.Controls.JTextBox();
            this.SuspendLayout();
            // 
            // IndexTB
            // 
            this.IndexTB.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.IndexTB.CustomButton.Image = null;
            this.IndexTB.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.IndexTB.CustomButton.Name = "";
            this.IndexTB.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.IndexTB.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.IndexTB.CustomButton.TabIndex = 1;
            this.IndexTB.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.IndexTB.CustomButton.UseSelectable = true;
            this.IndexTB.CustomButton.Visible = false;
            this.IndexTB.ForeColor = System.Drawing.Color.Black;
            this.IndexTB.Lines = new string[0];
            this.IndexTB.Location = new System.Drawing.Point(12, 24);
            this.IndexTB.MaxLength = 32767;
            this.IndexTB.Name = "IndexTB";
            this.IndexTB.PasswordChar = '\0';
            this.IndexTB.TextWaterMark = "Triger Index";
            this.IndexTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IndexTB.SelectedText = "";
            this.IndexTB.SelectionLength = 0;
            this.IndexTB.SelectionStart = 0;
            this.IndexTB.ShortcutsEnabled = true;
            this.IndexTB.Size = new System.Drawing.Size(262, 22);
            this.IndexTB.Style = JHUI.JColorStyle.Silver;
            this.IndexTB.TabIndex = 0;
            this.IndexTB.TextWaterMark = "Triger Index";
            this.IndexTB.Theme = JHUI.JThemeStyle.Dark;
            this.IndexTB.UseSelectable = true;
            this.IndexTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.IndexTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // NameTB
            // 
            this.NameTB.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.NameTB.CustomButton.Image = null;
            this.NameTB.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.NameTB.CustomButton.Name = "";
            this.NameTB.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.NameTB.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.NameTB.CustomButton.TabIndex = 1;
            this.NameTB.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.NameTB.CustomButton.UseSelectable = true;
            this.NameTB.CustomButton.Visible = false;
            this.NameTB.ForeColor = System.Drawing.Color.Black;
            this.NameTB.Lines = new string[0];
            this.NameTB.Location = new System.Drawing.Point(12, 52);
            this.NameTB.MaxLength = 32767;
            this.NameTB.Name = "NameTB";
            this.NameTB.PasswordChar = '\0';
            this.NameTB.TextWaterMark = "Triger Name";
            this.NameTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTB.SelectedText = "";
            this.NameTB.SelectionLength = 0;
            this.NameTB.SelectionStart = 0;
            this.NameTB.ShortcutsEnabled = true;
            this.NameTB.Size = new System.Drawing.Size(262, 22);
            this.NameTB.Style = JHUI.JColorStyle.Silver;
            this.NameTB.TabIndex = 2;
            this.NameTB.TextWaterMark = "Triger Name";
            this.NameTB.Theme = JHUI.JThemeStyle.Dark;
            this.NameTB.UseSelectable = true;
            this.NameTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(290, 87);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.IndexTB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTrigger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Silver;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddTrigger_FormClosing);
            this.ResumeLayout(false);

        }


        private void AddTrigger_FormClosing(object sender, FormClosingEventArgs e)
        {
            int result;
            if (!int.TryParse(this.IndexTB.Text, out result))
            {
                int num = (int)MessageBox.Show("Invalid input in field index.");
            }
            else
            {
                if (this.CurrentPolicy.GetListIndex(result) != -1 && MessageBox.Show("Warning: Index already exists. Trigger will be overwritten. Do you wish to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                this.Result = new Trigger(this.CurrentPolicy, result, this.NameTB.Text);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
