namespace PWDataEditorPaied.AngelicaFileManager
{
    partial class FileRip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileRip));
            this.jProgressBar1 = new JHUI.Controls.JProgressBar();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.SuspendLayout();
            // 
            // jProgressBar1
            // 
            this.jProgressBar1.ProgressTextType = JHUI.Controls.ProgressTextType.SHOW_PERCENTAGE;
            this.jProgressBar1.Location = new System.Drawing.Point(23, 51);
            this.jProgressBar1.Name = "jProgressBar1";
            this.jProgressBar1.Size = new System.Drawing.Size(415, 23);
            this.jProgressBar1.Style = JHUI.JColorStyle.Blue;
            this.jProgressBar1.TabIndex = 0;
            this.jProgressBar1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(24, 23);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(65, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Gold;
            this.jLabel1.TabIndex = 1;
            this.jLabel1.Text = "Extracting...";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // FileRip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 97);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jProgressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(462, 97);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(462, 97);
            this.Movable = false;
            this.Name = "FileRip";
            this.Resizable = false;
            this.ShadowType = JHUI.Forms.JFormShadowType.None;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = JHUI.JColorStyle.Blue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileRip_FormClosing);
            this.Shown += new System.EventHandler(this.FileRip_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JProgressBar jProgressBar1;
        private JHUI.Controls.JLabel jLabel1;
    }
}