using JHUI.Controls;

namespace PWDataEditorPaied.Forms.SubForms
{
    partial class WorldMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldMap));
            this.panel_path = new JHUI.Controls.JPanel();
            this.pictureBox_path = new JHUI.Controls.JPictureBox();
            this.toolTip = new JHUI.Components.JToolTip();
            this.comboBox_lists = new JHUI.Controls.JComboBox();
            this.panel_path.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_path)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_path
            // 
            this.panel_path.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_path.AutoScroll = true;
            this.panel_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.panel_path.Controls.Add(this.pictureBox_path);
            this.panel_path.HorizontalScrollbar = true;
            this.panel_path.HorizontalScrollbarBarColor = true;
            this.panel_path.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_path.HorizontalScrollbarSize = 10;
            this.panel_path.Location = new System.Drawing.Point(12, 86);
            this.panel_path.Name = "panel_path";
            this.panel_path.Size = new System.Drawing.Size(523, 320);
            this.panel_path.Style = JHUI.JColorStyle.Gold;
            this.panel_path.TabIndex = 101;
            this.panel_path.Theme = JHUI.JThemeStyle.Dark;
            this.panel_path.VerticalScrollbar = true;
            this.panel_path.VerticalScrollbarBarColor = true;
            this.panel_path.VerticalScrollbarHighlightOnWheel = false;
            this.panel_path.VerticalScrollbarSize = 10;
            // 
            // pictureBox_path
            // 
            this.pictureBox_path.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_path.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_path.Name = "pictureBox_path";
            this.pictureBox_path.Size = new System.Drawing.Size(100, 50);
            this.pictureBox_path.Style = JHUI.JColorStyle.White;
            this.pictureBox_path.TabIndex = 3;
            this.pictureBox_path.TabStop = false;
            this.pictureBox_path.Theme = JHUI.JThemeStyle.Dark;
            this.pictureBox_path.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_path_MouseDown);
            this.pictureBox_path.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_path_MouseMove);
            this.pictureBox_path.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_path_MouseUp);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 0;
            this.toolTip.ReshowDelay = 0;
            this.toolTip.Style = JHUI.JColorStyle.White;
            this.toolTip.StyleManager = null;
            this.toolTip.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            // 
            // comboBox_lists
            // 
            this.comboBox_lists.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.comboBox_lists.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox_lists.IntegralHeight = false;
            this.comboBox_lists.ItemHeight = 19;
            this.comboBox_lists.Location = new System.Drawing.Point(12, 55);
            this.comboBox_lists.MaxDropDownItems = 19;
            this.comboBox_lists.Name = "comboBox_lists";
            this.comboBox_lists.Size = new System.Drawing.Size(523, 25);
            this.comboBox_lists.Style = JHUI.JColorStyle.Blue;
            this.comboBox_lists.TabIndex = 105;
            this.comboBox_lists.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_lists.UseSelectable = true;
            this.comboBox_lists.UseStyleColors = true;
            this.comboBox_lists.SelectedIndexChanged += new System.EventHandler(this.comboBox_lists_SelectedIndexChanged);
            // 
            // WorldMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 429);
            this.Controls.Add(this.comboBox_lists);
            this.Controls.Add(this.panel_path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorldMap";
            this.Text = "Map View";
            this.Shown += new System.EventHandler(this.WorldMap_Shown);
            this.panel_path.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_path)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JPanel panel_path;
        private JHUI.Controls.JPictureBox pictureBox_path;
        private JHUI.Components.JToolTip toolTip;
        private JComboBox comboBox_lists;
    }
}