using JHUI.Controls;
using System.Windows.Forms;

namespace PWDataEditorPaied.AIPolicy.Input
{
    partial class ConditionVisual
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionVisual));
            this.contextMenuStripCondition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOperatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ConditionTB = new JHUI.Controls.JTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStripCondition.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripCondition
            // 
            this.contextMenuStripCondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConditionToolStripMenuItem,
            this.addOperatorToolStripMenuItem,
            this.variableToolStripMenuItem});
            this.contextMenuStripCondition.Name = "contextMenuStripCondition";
            this.contextMenuStripCondition.Size = new System.Drawing.Size(128, 70);
            // 
            // addConditionToolStripMenuItem
            // 
            this.addConditionToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.SettingsCog;
            this.addConditionToolStripMenuItem.Name = "addConditionToolStripMenuItem";
            this.addConditionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addConditionToolStripMenuItem.Text = "Condition";
            this.addConditionToolStripMenuItem.Click += new System.EventHandler(this.addOperatorToolStripMenuItem_Click);
            // 
            // addOperatorToolStripMenuItem
            // 
            this.addOperatorToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Unpack;
            this.addOperatorToolStripMenuItem.Name = "addOperatorToolStripMenuItem";
            this.addOperatorToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addOperatorToolStripMenuItem.Text = "Operator";
            this.addOperatorToolStripMenuItem.Click += new System.EventHandler(this.addConditionToolStripMenuItem_Click);
            // 
            // variableToolStripMenuItem
            // 
            this.variableToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View;
            this.variableToolStripMenuItem.Name = "variableToolStripMenuItem";
            this.variableToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.variableToolStripMenuItem.Text = "Variable";
            this.variableToolStripMenuItem.Click += new System.EventHandler(this.variableToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.button1.BackgroundImage = global::PWDataEditorPaied.Properties.Resources.AddPlus;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AddNewOperation);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.panel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(5, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 83);
            this.panel1.TabIndex = 11;
            this.panel1.WrapContents = false;
            this.panel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlAdded);
            this.panel1.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlRemoved);
            // 
            // ConditionTB
            // 
            this.ConditionTB.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ConditionTB.CustomButton.Image = null;
            this.ConditionTB.CustomButton.Location = new System.Drawing.Point(712, 2);
            this.ConditionTB.CustomButton.Name = "";
            this.ConditionTB.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.ConditionTB.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.ConditionTB.CustomButton.TabIndex = 1;
            this.ConditionTB.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.ConditionTB.CustomButton.UseSelectable = true;
            this.ConditionTB.CustomButton.Visible = false;
            this.ConditionTB.Enabled = false;
            this.ConditionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConditionTB.Lines = new string[0];
            this.ConditionTB.Location = new System.Drawing.Point(6, 19);
            this.ConditionTB.MaxLength = 32767;
            this.ConditionTB.Name = "ConditionTB";
            this.ConditionTB.PasswordChar = '\0';
            this.ConditionTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConditionTB.SelectedText = "";
            this.ConditionTB.SelectionLength = 0;
            this.ConditionTB.SelectionStart = 0;
            this.ConditionTB.ShortcutsEnabled = true;
            this.ConditionTB.Size = new System.Drawing.Size(730, 20);
            this.ConditionTB.Style = JHUI.JColorStyle.Silver;
            this.ConditionTB.TabIndex = 12;
            this.ConditionTB.TabStop = false;
            this.ConditionTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConditionTB.TextWaterMark = "";
            this.ConditionTB.Theme = JHUI.JThemeStyle.Dark;
            this.ConditionTB.UseSelectable = true;
            this.ConditionTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ConditionTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConditionTB);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(4, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 52);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Location = new System.Drawing.Point(4, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 130);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor";
            // 
            // ConditionVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(749, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConditionVisual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Silver;
            this.Text = "Condition Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConditionVisual_FormClosing);
            this.contextMenuStripCondition.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Button button1;
        #endregion

        private ContextMenuStrip contextMenuStripCondition;
        private ToolStripMenuItem addConditionToolStripMenuItem;
        private ToolStripMenuItem addOperatorToolStripMenuItem;
        private FlowLayoutPanel panel1;
        private JTextBox ConditionTB;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ToolStripMenuItem variableToolStripMenuItem;
    }
}