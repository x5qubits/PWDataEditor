using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AIPolicy;
using AIPolicy.Operations;
using JHUI.Forms;
using JHUI.Controls;

namespace PWDataEditorPaied.AIPolicy.Input
{
    public class EditActionSet : JForm
    {
        public int freeId = 0;
        private JLabel label1;
        private JLabel asdasdasd;
        public Trigger data = null;
        public EditActionSet()
        {
            InitializeComponent();
        }

        public void setObject(Trigger pol, int _freeId = 0)
        {
            this.data = pol;
            freeId = _freeId;
            textBox1.Text =pol.Name.ToString();
            textBox2.Text = pol.Index.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                GB18030 name = new GB18030(new byte[128]);
                name.Set(textBox1.Text);
                data.Name = name;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

                int index = 0;
                bool isInt = int.TryParse(textBox2.Text, out index);
                if (isInt && freeId < index || isInt && ((Trigger)data).Index == index)
                {
                    data.Index = index;
                }
                else
                {
                    textBox2.Text = data.Index.ToString();
                    MessageBox.Show("Index must be a numeric value and bigger then:" + freeId);
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void EditActionSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditActionSet));
            this.textBox1 = new JHUI.Controls.JTextBox();
            this.textBox2 = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.asdasdasd = new JHUI.Controls.JLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(390, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(54, 26);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(408, 20);
            this.textBox1.Style = JHUI.JColorStyle.Silver;
            this.textBox1.TabIndex = 19;
            this.textBox1.TextWaterMark = "";
            this.textBox1.Theme = JHUI.JThemeStyle.Dark;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            // 
            // 
            // 
            this.textBox2.CustomButton.Image = null;
            this.textBox2.CustomButton.Location = new System.Drawing.Point(390, 2);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox2.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(54, 52);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(408, 20);
            this.textBox2.Style = JHUI.JColorStyle.Silver;
            this.textBox2.TabIndex = 21;
            this.textBox2.TextWaterMark = "";
            this.textBox2.Theme = JHUI.JThemeStyle.Dark;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.Style = JHUI.JColorStyle.Gold;
            this.label1.TabIndex = 20;
            this.label1.Text = "Index";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // asdasdasd
            // 
            this.asdasdasd.AutoSize = true;
            this.asdasdasd.Location = new System.Drawing.Point(3, 27);
            this.asdasdasd.Name = "asdasdasd";
            this.asdasdasd.Size = new System.Drawing.Size(45, 19);
            this.asdasdasd.Style = JHUI.JColorStyle.Gold;
            this.asdasdasd.TabIndex = 18;
            this.asdasdasd.Text = "Name";
            this.asdasdasd.Theme = JHUI.JThemeStyle.Dark;
            // 
            // EditActionSet
            // 
            this.ClientSize = new System.Drawing.Size(473, 88);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.asdasdasd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditActionSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Silver;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditActionSet_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private JTextBox textBox1;
        private JTextBox textBox2;
    }
}
