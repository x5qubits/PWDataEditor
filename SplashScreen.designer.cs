namespace ElementEditor
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Location = new System.Drawing.Point(16, 30);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(361, 66);
            this.jPictureBox1.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox1.TabIndex = 0;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(199, 66);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(141, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 1;
            this.jLabel1.Text = "http://www.jhsoftware.pro/";
            this.jLabel1.Theme = JHUI.JThemeStyle.Light;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 121);
            this.ControlBox = false;
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jPictureBox1);
            this.DisplayHeader = false;
            this.JControlBoxShow = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "SplashScreen";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.PaintTopBorder = false;
            this.Resizable = false;
            this.ShadowType = JHUI.Forms.JFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = JHUI.JColorStyle.Black;
            this.Theme = JHUI.JThemeStyle.Light;
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JPictureBox jPictureBox1;
        private JHUI.Controls.JLabel jLabel1;
    }
}