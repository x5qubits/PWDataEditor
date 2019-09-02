using JHUI.Controls;

namespace ElementEditor
{
    partial class ImportOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportOption));
            this.checkBox1 = new JHUI.Controls.JCheckBox();
            this.checkBox2 = new JHUI.Controls.JCheckBox();
            this.checkBox3 = new JHUI.Controls.JCheckBox();
            this.btnAdd = new JHUI.Controls.JButton();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jCheckBox1 = new JHUI.Controls.JCheckBox();
            this.jCheckBox2 = new JHUI.Controls.JCheckBox();
            this.jToolTip1 = new JHUI.Components.JToolTip();
            this.jCheckBox3 = new JHUI.Controls.JCheckBox();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkBox1.Location = new System.Drawing.Point(23, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(235, 15);
            this.checkBox1.Style = JHUI.JColorStyle.Blue;
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Force Add New Items EVEN If They Exist.";
            this.checkBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.checkBox1, "Will add items regardless if they exist");
            this.checkBox1.UseSelectable = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkBox2.Location = new System.Drawing.Point(23, 79);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(167, 15);
            this.checkBox2.Style = JHUI.JColorStyle.Blue;
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Replace Existing Items Only";
            this.checkBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.checkBox2, "It will only replace existing items.");
            this.checkBox2.UseSelectable = true;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkBox3.Location = new System.Drawing.Point(23, 102);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(209, 15);
            this.checkBox3.Style = JHUI.JColorStyle.Blue;
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Clean List And Only Add This Items";
            this.checkBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.checkBox3, "It will delete all list and add only the items you want to import.");
            this.checkBox3.UseSelectable = true;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Brown;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(254, 161);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 27);
            this.btnAdd.Style = JHUI.JColorStyle.Gold;
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Okay";
            this.btnAdd.Theme = JHUI.JThemeStyle.Dark;
            this.btnAdd.UseSelectable = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.CausesValidation = false;
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.ForeColor = System.Drawing.Color.White;
            this.jLabel1.Location = new System.Drawing.Point(3, 8);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(195, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 14;
            this.jLabel1.Text = "How do you want to paste this items?";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel1.UseCustomForeColor = true;
            // 
            // jCheckBox1
            // 
            this.jCheckBox1.AutoSize = true;
            this.jCheckBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.jCheckBox1.Location = new System.Drawing.Point(23, 123);
            this.jCheckBox1.Name = "jCheckBox1";
            this.jCheckBox1.Size = new System.Drawing.Size(132, 15);
            this.jCheckBox1.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox1.TabIndex = 16;
            this.jCheckBox1.Text = "Add New Items Only";
            this.jCheckBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.jCheckBox1, "It will only add items regardless if they exist or not.");
            this.jCheckBox1.UseSelectable = true;
            this.jCheckBox1.UseVisualStyleBackColor = true;
            this.jCheckBox1.CheckedChanged += new System.EventHandler(this.jCheckBox1_CheckedChanged);
            // 
            // jCheckBox2
            // 
            this.jCheckBox2.AutoSize = true;
            this.jCheckBox2.Checked = true;
            this.jCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jCheckBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.jCheckBox2.Location = new System.Drawing.Point(23, 35);
            this.jCheckBox2.Name = "jCheckBox2";
            this.jCheckBox2.Size = new System.Drawing.Size(231, 15);
            this.jCheckBox2.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox2.TabIndex = 18;
            this.jCheckBox2.Text = "Replace Existing Items and Add Missing";
            this.jCheckBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jToolTip1.SetToolTip(this.jCheckBox2, "It will replace and add new intems if Auto Id option is not on. If auto id is on " +
        "it will add new items only.");
            this.jCheckBox2.UseSelectable = true;
            this.jCheckBox2.UseVisualStyleBackColor = true;
            this.jCheckBox2.CheckedChanged += new System.EventHandler(this.jCheckBox2_CheckedChanged);
            // 
            // jToolTip1
            // 
            this.jToolTip1.Style = JHUI.JColorStyle.White;
            this.jToolTip1.StyleManager = null;
            this.jToolTip1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jCheckBox3
            // 
            this.jCheckBox3.AutoSize = true;
            this.jCheckBox3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.jCheckBox3.Location = new System.Drawing.Point(23, 164);
            this.jCheckBox3.Name = "jCheckBox3";
            this.jCheckBox3.Size = new System.Drawing.Size(136, 15);
            this.jCheckBox3.Style = JHUI.JColorStyle.Blue;
            this.jCheckBox3.TabIndex = 20;
            this.jCheckBox3.Text = "Import in Current List";
            this.jCheckBox3.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox3.UseSelectable = true;
            this.jCheckBox3.UseVisualStyleBackColor = true;
            this.jCheckBox3.CheckedChanged += new System.EventHandler(this.jCheckBox3_CheckedChanged);
            // 
            // ImportOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.BackgroundImage = global::PWDataEditorPaied.Properties.Resources.Masck;
            this.ClientSize = new System.Drawing.Size(368, 202);
            this.Controls.Add(this.jCheckBox3);
            this.Controls.Add(this.jCheckBox2);
            this.Controls.Add(this.jCheckBox1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportOption";
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = JHUI.JColorStyle.Red;
            this.Shown += new System.EventHandler(this.ImportOption_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JCheckBox checkBox1;
        private JCheckBox checkBox2;
        private JCheckBox checkBox3;
        private JButton btnAdd;
        private JHUI.Controls.JLabel jLabel1;
        private JCheckBox jCheckBox1;
        private JCheckBox jCheckBox2;
        private JHUI.Components.JToolTip jToolTip1;
        private JCheckBox jCheckBox3;
    }
}