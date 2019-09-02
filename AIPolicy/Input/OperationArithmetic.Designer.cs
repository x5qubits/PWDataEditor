using JHUI.Controls;

namespace PWDataEditorPaied.AIPolicy.Input
{
    partial class OperationArithmetic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.operationType = new JHUI.Controls.JComboBox();
            this.textBox1 = new JHUI.Controls.JTextBox();
            this.button2 = new JHUI.Controls.JButton();
            this.SuspendLayout();
            // 
            // operationType
            // 
            this.operationType.BackColor = System.Drawing.Color.Black;
            this.operationType.CausesValidation = false;
            this.operationType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operationType.FontSize = JHUI.JComboBoxSize.Small;
            this.operationType.ForeColor = System.Drawing.Color.White;
            this.operationType.FormattingEnabled = true;
            this.operationType.ItemHeight = 19;
            this.operationType.Items.AddRange(new object[] {
            "!",
            "||",
            "&&",
            "+",
            "-",
            "*",
            "/",
            ">",
            "<",
            "==",
            "Var",
            "="});
            this.operationType.Location = new System.Drawing.Point(29, 17);
            this.operationType.Name = "operationType";
            this.operationType.Size = new System.Drawing.Size(79, 25);
            this.operationType.Style = JHUI.JColorStyle.Gold;
            this.operationType.TabIndex = 6;
            this.operationType.TabStop = false;
            this.operationType.Theme = JHUI.JThemeStyle.Dark;
            this.operationType.UseSelectable = true;
            this.operationType.SelectedIndexChanged += new System.EventHandler(this.operationType_SelectedIndexChanged);
            this.operationType.MouseEnter += new System.EventHandler(this.OperationCondition_MouseEnter);
            this.operationType.MouseLeave += new System.EventHandler(this.OperationCondition_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(41, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox1.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(114, 17);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(65, 25);
            this.textBox1.Style = JHUI.JColorStyle.Gold;
            this.textBox1.TabIndex = 9;
            this.textBox1.TextWaterMark = "";
            this.textBox1.Theme = JHUI.JThemeStyle.Dark;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.MouseEnter += new System.EventHandler(this.OperationCondition_MouseEnter);
            this.textBox1.MouseLeave += new System.EventHandler(this.OperationCondition_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::PWDataEditorPaied.Properties.Resources.delete;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(3, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.Style = JHUI.JColorStyle.Gold;
            this.button2.TabIndex = 12;
            this.button2.Theme = JHUI.JThemeStyle.Dark;
            this.button2.UseSelectable = true;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.OperationCondition_MouseLeave);
            // 
            // OperationArithmetic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.operationType);
            this.Name = "OperationArithmetic";
            this.Size = new System.Drawing.Size(182, 53);
            this.MouseEnter += new System.EventHandler(this.OperationCondition_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.OperationCondition_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private JComboBox operationType;
        private JTextBox textBox1;
        private JButton button2;
    }
}
