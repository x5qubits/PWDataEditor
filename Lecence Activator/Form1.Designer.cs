namespace Lecence_Activator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAdd = new System.Windows.Forms.Button();
            this.HardKeyasd = new System.Windows.Forms.Label();
            this.hwKey = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.box_2 = new System.Windows.Forms.CheckBox();
            this.box_5 = new System.Windows.Forms.CheckBox();
            this.box_4 = new System.Windows.Forms.CheckBox();
            this.box_1 = new System.Windows.Forms.CheckBox();
            this.box_6 = new System.Windows.Forms.CheckBox();
            this.box_3 = new System.Windows.Forms.CheckBox();
            this.box_7 = new System.Windows.Forms.CheckBox();
            this.box_8 = new System.Windows.Forms.CheckBox();
            this.versionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.box_0 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(337, 333);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 45);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Generate";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // HardKeyasd
            // 
            this.HardKeyasd.AutoSize = true;
            this.HardKeyasd.Location = new System.Drawing.Point(9, 47);
            this.HardKeyasd.Name = "HardKeyasd";
            this.HardKeyasd.Size = new System.Drawing.Size(77, 13);
            this.HardKeyasd.TabIndex = 16;
            this.HardKeyasd.Text = "Hardwere Key:";
            // 
            // hwKey
            // 
            this.hwKey.Location = new System.Drawing.Point(92, 44);
            this.hwKey.Name = "hwKey";
            this.hwKey.Size = new System.Drawing.Size(366, 20);
            this.hwKey.TabIndex = 17;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(92, 70);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(366, 20);
            this.username.TabIndex = 19;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "User Name:";
            // 
            // box_2
            // 
            this.box_2.AutoSize = true;
            this.box_2.Checked = true;
            this.box_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_2.Location = new System.Drawing.Point(92, 197);
            this.box_2.Name = "box_2";
            this.box_2.Size = new System.Drawing.Size(94, 17);
            this.box_2.TabIndex = 20;
            this.box_2.Text = "Element Editor";
            this.box_2.UseVisualStyleBackColor = true;
            this.box_2.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_5
            // 
            this.box_5.AutoSize = true;
            this.box_5.Checked = true;
            this.box_5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_5.Location = new System.Drawing.Point(302, 174);
            this.box_5.Name = "box_5";
            this.box_5.Size = new System.Drawing.Size(78, 17);
            this.box_5.TabIndex = 21;
            this.box_5.Text = "NPC Editor";
            this.box_5.UseVisualStyleBackColor = true;
            this.box_5.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_4
            // 
            this.box_4.AutoSize = true;
            this.box_4.Checked = true;
            this.box_4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_4.Location = new System.Drawing.Point(92, 242);
            this.box_4.Name = "box_4";
            this.box_4.Size = new System.Drawing.Size(81, 17);
            this.box_4.TabIndex = 22;
            this.box_4.Text = "Shop Editor";
            this.box_4.UseVisualStyleBackColor = true;
            this.box_4.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_1
            // 
            this.box_1.AutoSize = true;
            this.box_1.Checked = true;
            this.box_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_1.Location = new System.Drawing.Point(92, 174);
            this.box_1.Name = "box_1";
            this.box_1.Size = new System.Drawing.Size(85, 17);
            this.box_1.TabIndex = 23;
            this.box_1.Text = "Admin Editor";
            this.box_1.UseVisualStyleBackColor = true;
            this.box_1.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_6
            // 
            this.box_6.AutoSize = true;
            this.box_6.Checked = true;
            this.box_6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_6.Location = new System.Drawing.Point(302, 197);
            this.box_6.Name = "box_6";
            this.box_6.Size = new System.Drawing.Size(84, 17);
            this.box_6.TabIndex = 24;
            this.box_6.Text = "Policy Editor";
            this.box_6.UseVisualStyleBackColor = true;
            this.box_6.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_3
            // 
            this.box_3.AutoSize = true;
            this.box_3.Checked = true;
            this.box_3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_3.Location = new System.Drawing.Point(92, 220);
            this.box_3.Name = "box_3";
            this.box_3.Size = new System.Drawing.Size(80, 17);
            this.box_3.TabIndex = 25;
            this.box_3.Text = "Task Editor";
            this.box_3.UseVisualStyleBackColor = true;
            this.box_3.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_7
            // 
            this.box_7.AutoSize = true;
            this.box_7.Checked = true;
            this.box_7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_7.Location = new System.Drawing.Point(302, 220);
            this.box_7.Name = "box_7";
            this.box_7.Size = new System.Drawing.Size(75, 17);
            this.box_7.TabIndex = 26;
            this.box_7.Text = "Pck Editor";
            this.box_7.UseVisualStyleBackColor = true;
            this.box_7.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // box_8
            // 
            this.box_8.AutoSize = true;
            this.box_8.Location = new System.Drawing.Point(302, 243);
            this.box_8.Name = "box_8";
            this.box_8.Size = new System.Drawing.Size(92, 17);
            this.box_8.TabIndex = 27;
            this.box_8.Text = "Domain Editor";
            this.box_8.UseVisualStyleBackColor = true;
            this.box_8.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // versionBox
            // 
            this.versionBox.Location = new System.Drawing.Point(92, 18);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(366, 20);
            this.versionBox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Version:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(348, 20);
            this.textBox1.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Encrypt Password:";
            // 
            // box_0
            // 
            this.box_0.AutoSize = true;
            this.box_0.Checked = true;
            this.box_0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.box_0.Location = new System.Drawing.Point(191, 148);
            this.box_0.Name = "box_0";
            this.box_0.Size = new System.Drawing.Size(85, 17);
            this.box_0.TabIndex = 32;
            this.box_0.Text = "Profile Editor";
            this.box_0.UseVisualStyleBackColor = true;
            this.box_0.CheckedChanged += new System.EventHandler(this.domainBox_8_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(348, 20);
            this.textBox2.TabIndex = 34;
            this.textBox2.Text = "60";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Xor Password:";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(470, 390);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.box_0);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.box_8);
            this.Controls.Add(this.box_7);
            this.Controls.Add(this.box_3);
            this.Controls.Add(this.box_6);
            this.Controls.Add(this.box_1);
            this.Controls.Add(this.box_4);
            this.Controls.Add(this.box_5);
            this.Controls.Add(this.box_2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hwKey);
            this.Controls.Add(this.HardKeyasd);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(486, 429);
            this.MinimumSize = new System.Drawing.Size(486, 429);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licence Controler";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label HardKeyasd;
        private System.Windows.Forms.TextBox hwKey;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox box_2;
        private System.Windows.Forms.CheckBox box_5;
        private System.Windows.Forms.CheckBox box_4;
        private System.Windows.Forms.CheckBox box_1;
        private System.Windows.Forms.CheckBox box_6;
        private System.Windows.Forms.CheckBox box_3;
        private System.Windows.Forms.CheckBox box_7;
        private System.Windows.Forms.CheckBox box_8;
        private System.Windows.Forms.TextBox versionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox box_0;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}

