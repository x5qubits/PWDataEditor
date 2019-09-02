using AIPolicy;
using JHUI.Controls;
using JHUI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AIPolicy.Input
{
  internal class AddPolicy : JForm
  {
    private IContainer components = (IContainer) null;
    private JTextBox IDTB;

    private AI Data { get; set; }

    public Policy Result { get; private set; }

    public AddPolicy()
    {
      this.InitializeComponent();
    }

    public void SetData(AI data)
    {
      this.Data = data;
    }

    private void OkBTN_Click(object sender, EventArgs e)
    {
      int result;
      if (!int.TryParse(this.IDTB.Text, out result))
      {
        int num = (int) MessageBox.Show("Bad input. Insert a number.");
      }
      else
      {
        if (this.Data.FindPolicy(result) != null && MessageBox.Show("Warning: ID already exists. Policy will be overwritten. Do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
          return;
        this.Result = new Policy(result);
        this.DialogResult = DialogResult.OK;
        this.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPolicy));
            this.IDTB = new JHUI.Controls.JTextBox();
            this.SuspendLayout();
            // 
            // IDTB
            // 
            this.IDTB.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.IDTB.CustomButton.Image = null;
            this.IDTB.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.IDTB.CustomButton.Name = "";
            this.IDTB.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.IDTB.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.IDTB.CustomButton.TabIndex = 1;
            this.IDTB.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.IDTB.CustomButton.UseSelectable = true;
            this.IDTB.CustomButton.Visible = false;
            this.IDTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTB.ForeColor = System.Drawing.Color.Black;
            this.IDTB.Lines = new string[0];
            this.IDTB.Location = new System.Drawing.Point(23, 23);
            this.IDTB.MaxLength = 32767;
            this.IDTB.Name = "IDTB";
            this.IDTB.PasswordChar = '\0';
            this.IDTB.TextWaterMark = "Enter Id";
            this.IDTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IDTB.SelectedText = "";
            this.IDTB.SelectionLength = 0;
            this.IDTB.SelectionStart = 0;
            this.IDTB.ShortcutsEnabled = true;
            this.IDTB.Size = new System.Drawing.Size(201, 25);
            this.IDTB.Style = JHUI.JColorStyle.Silver;
            this.IDTB.TabIndex = 1;
            this.IDTB.TextWaterMark = "Enter Id";
            this.IDTB.Theme = JHUI.JThemeStyle.Dark;
            this.IDTB.UseSelectable = true;
            this.IDTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.IDTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddPolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(246, 61);
            this.Controls.Add(this.IDTB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPolicy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Silver;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPolicy_FormClosing);
            this.ResumeLayout(false);

    }

        private void AddPolicy_FormClosing(object sender, FormClosingEventArgs e)
        {
            int result;
            if (!int.TryParse(this.IDTB.Text, out result))
            {
                int num = (int)MessageBox.Show("Bad input. Insert a number.");
            }
            else
            {
                if (this.Data.FindPolicy(result) != null && MessageBox.Show("Warning: ID already exists. Policy will be overwritten. Do you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                this.Result = new Policy(result);
                this.DialogResult = DialogResult.OK;
              //  this.Close();
            }
        }
    }
}
