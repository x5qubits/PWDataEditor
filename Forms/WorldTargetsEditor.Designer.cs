namespace ElementEditor
{
    partial class WorldTargetsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldTargetsEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.RegionDataGrid = new JHUI.Controls.JDataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jPictureBox4 = new JHUI.Controls.JPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegionDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // jPictureBox2
            // 
            this.jPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox2.BackgroundImage")));
            this.jPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox2.Location = new System.Drawing.Point(52, 54);
            this.jPictureBox2.Name = "jPictureBox2";
            this.jPictureBox2.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox2.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox2.TabIndex = 55;
            this.jPictureBox2.TabStop = false;
            this.jPictureBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox2.Click += new System.EventHandler(this.jPictureBox2_Click);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(23, 54);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox1.TabIndex = 54;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.jPictureBox1_Click);
            // 
            // RegionDataGrid
            // 
            this.RegionDataGrid.AllowDrop = true;
            this.RegionDataGrid.AllowUserToAddRows = false;
            this.RegionDataGrid.AllowUserToDeleteRows = false;
            this.RegionDataGrid.AllowUserToResizeColumns = false;
            this.RegionDataGrid.AllowUserToResizeRows = false;
            this.RegionDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.RegionDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RegionDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RegionDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.RegionDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RegionDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RegionDataGrid.ColumnHeadersHeight = 30;
            this.RegionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RegionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.Column14,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RegionDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.RegionDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RegionDataGrid.EditOnDoubleClick = true;
            this.RegionDataGrid.EnableHeadersVisualStyles = false;
            this.RegionDataGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.RegionDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.RegionDataGrid.Location = new System.Drawing.Point(23, 82);
            this.RegionDataGrid.MultiSelect = false;
            this.RegionDataGrid.Name = "RegionDataGrid";
            this.RegionDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RegionDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RegionDataGrid.RowHeadersVisible = false;
            this.RegionDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RegionDataGrid.RowTemplate.Height = 30;
            this.RegionDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RegionDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RegionDataGrid.Size = new System.Drawing.Size(916, 595);
            this.RegionDataGrid.StandardTab = true;
            this.RegionDataGrid.Style = JHUI.JColorStyle.Blue;
            this.RegionDataGrid.TabIndex = 75;
            this.RegionDataGrid.Theme = JHUI.JThemeStyle.Dark;
            this.RegionDataGrid.VirtualMode = true;
            this.RegionDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RegionDataGrid_CellValueChanged);
            this.RegionDataGrid.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.RegionDataGrid_CellValueNeeded);
            this.RegionDataGrid.SelectionChanged += new System.EventHandler(this.RegionDataGrid_SelectionChanged);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.FillWeight = 50F;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.MinimumWidth = 50;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnId.Width = 50;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnName.FillWeight = 200F;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.MinimumWidth = 200;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column14
            // 
            this.Column14.FillWeight = 50F;
            this.Column14.HeaderText = "MapId";
            this.Column14.MinimumWidth = 50;
            this.Column14.Name = "Column14";
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column14.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Y";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Z";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Domain ID";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            // 
            // jPictureBox4
            // 
            this.jPictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox4.BackgroundImage")));
            this.jPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox4.Location = new System.Drawing.Point(916, 54);
            this.jPictureBox4.Name = "jPictureBox4";
            this.jPictureBox4.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox4.Style = JHUI.JColorStyle.Gold;
            this.jPictureBox4.TabIndex = 110;
            this.jPictureBox4.TabStop = false;
            this.jPictureBox4.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox4.Click += new System.EventHandler(this.jPictureBox4_Click);
            // 
            // WorldTargetsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jPictureBox4);
            this.Controls.Add(this.RegionDataGrid);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorldTargetsEditor";
            this.Text = "WorldTargets Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldTargetsEditor_FormClosing);
            this.Shown += new System.EventHandler(this.WorldTargetsEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegionDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JPictureBox jPictureBox2;
        private JHUI.Controls.JPictureBox jPictureBox1;
        private JHUI.Controls.JDataGridView RegionDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private JHUI.Controls.JPictureBox jPictureBox4;
    }
}