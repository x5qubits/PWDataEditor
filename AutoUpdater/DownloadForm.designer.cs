namespace NSUpdateManager
{
    partial class DownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.progressBar1 = new JHUI.Controls.JProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.ProgressTextType = JHUI.Controls.ProgressTextType.SHOW_PERCENTAGE;
            this.progressBar1.Location = new System.Drawing.Point(23, 63);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(455, 19);
            this.progressBar1.Style = JHUI.JColorStyle.Green;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(501, 93);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(501, 93);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(501, 93);
            this.Name = "DownloadForm";
            this.Style = JHUI.JColorStyle.Red;
            this.Text = "Update Manager";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JProgressBar progressBar1;
    }
}