namespace PWDataEditorPaied.helper_classes
{
    partial class XMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMessageBox));
            this.jButton1 = new JHUI.Controls.JButton();
            this.jButton2 = new JHUI.Controls.JButton();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jButton3 = new JHUI.Controls.JButton();
            this.SuspendLayout();
            // 
            // jButton1
            // 
            this.jButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jButton1.FontSize = JHUI.JButtonSize.Medium;
            this.jButton1.FontWeight = JHUI.JButtonWeight.Regular;
            this.jButton1.Location = new System.Drawing.Point(34, 141);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(98, 25);
            this.jButton1.Style = JHUI.JColorStyle.Gold;
            this.jButton1.TabIndex = 1;
            this.jButton1.Text = "Yes";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.jButton1_Click);
            // 
            // jButton2
            // 
            this.jButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jButton2.FontSize = JHUI.JButtonSize.Medium;
            this.jButton2.FontWeight = JHUI.JButtonWeight.Regular;
            this.jButton2.Location = new System.Drawing.Point(336, 141);
            this.jButton2.Name = "jButton2";
            this.jButton2.Size = new System.Drawing.Size(98, 25);
            this.jButton2.Style = JHUI.JColorStyle.Gold;
            this.jButton2.TabIndex = 2;
            this.jButton2.Text = "No";
            this.jButton2.Theme = JHUI.JThemeStyle.Dark;
            this.jButton2.UseSelectable = true;
            this.jButton2.UseVisualStyleBackColor = true;
            this.jButton2.Click += new System.EventHandler(this.jButton2_Click);
            // 
            // jLabel1
            // 
            this.jLabel1.DropShadowColor = System.Drawing.Color.Black;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(34, 60);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(400, 78);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 4;
            this.jLabel1.Text = "Hello";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            this.jLabel1.WrapToLine = true;
            // 
            // jButton3
            // 
            this.jButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.jButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jButton3.FontSize = JHUI.JButtonSize.Medium;
            this.jButton3.FontWeight = JHUI.JButtonWeight.Regular;
            this.jButton3.Location = new System.Drawing.Point(189, 141);
            this.jButton3.Name = "jButton3";
            this.jButton3.Size = new System.Drawing.Size(98, 25);
            this.jButton3.Style = JHUI.JColorStyle.Gold;
            this.jButton3.TabIndex = 5;
            this.jButton3.Text = "Okay";
            this.jButton3.Theme = JHUI.JThemeStyle.Dark;
            this.jButton3.UseSelectable = true;
            this.jButton3.UseVisualStyleBackColor = true;
            this.jButton3.Click += new System.EventHandler(this.jButton3_Click);
            // 
            // XMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 180);
            this.ControlBox = false;
            this.Controls.Add(this.jButton3);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jButton2);
            this.Controls.Add(this.jButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.JControlBoxShow = false;
            this.Name = "XMessageBox";
            this.Resizable = false;
            this.Text = "Notification";
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JButton jButton2;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JButton jButton3;
    }
}