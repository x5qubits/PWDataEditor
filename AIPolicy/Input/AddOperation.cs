using AIPolicy.Operations;
using JHUI.Controls;
using JHUI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AIPolicy.Input
{
  public class AddOperation : JForm
  {
    private IContainer components = (IContainer) null;
    private JComboBox OperationCB;

    public int Result { get; private set; }

    public AddOperation()
    {
      this.InitializeComponent();
      this.OperationCB.DataSource = (object) Enum.GetNames(typeof (Operation.OperationType));
    }

    private void OkBTN_Click(object sender, EventArgs e)
    {
      this.Result = this.OperationCB.SelectedIndex;
      this.DialogResult = DialogResult.OK;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOperation));
            this.OperationCB = new JHUI.Controls.JComboBox();
            this.SuspendLayout();
            // 
            // OperationCB
            // 
            this.OperationCB.BackColor = System.Drawing.Color.White;
            this.OperationCB.FontSize = JHUI.JComboBoxSize.Small;
            this.OperationCB.ForeColor = System.Drawing.Color.Black;
            this.OperationCB.FormattingEnabled = true;
            this.OperationCB.ItemHeight = 19;
            this.OperationCB.Location = new System.Drawing.Point(14, 22);
            this.OperationCB.Name = "OperationCB";
            this.OperationCB.Size = new System.Drawing.Size(252, 25);
            this.OperationCB.Style = JHUI.JColorStyle.Silver;
            this.OperationCB.TabIndex = 1;
            this.OperationCB.Theme = JHUI.JThemeStyle.Dark;
            this.OperationCB.UseSelectable = true;
            // 
            // AddOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(279, 65);
            this.Controls.Add(this.OperationCB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Silver;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddOperation_FormClosing);
            this.ResumeLayout(false);

    }

        private void AddOperation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Result = this.OperationCB.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }
    }
}
