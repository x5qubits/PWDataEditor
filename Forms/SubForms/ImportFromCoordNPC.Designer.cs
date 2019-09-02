namespace PWDataEditorPaied.Forms.SubForms
{
    partial class ImportFromCoordNPC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFromCoordNPC));
            this.jComboBox1 = new JHUI.Controls.JComboBox();
            this.listBox_items = new JHUI.Controls.JDataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.jComboBox2 = new JHUI.Controls.JComboBox();
            this.jCheckBox1 = new JHUI.Controls.JCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            this.jContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // jComboBox1
            // 
            this.jComboBox1.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jComboBox1.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox1.FormattingEnabled = true;
            this.jComboBox1.ItemHeight = 19;
            this.jComboBox1.Location = new System.Drawing.Point(23, 63);
            this.jComboBox1.Name = "jComboBox1";
            this.jComboBox1.Size = new System.Drawing.Size(143, 25);
            this.jComboBox1.Style = JHUI.JColorStyle.Magenta;
            this.jComboBox1.TabIndex = 3;
            this.jComboBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox1.UseSelectable = true;
            this.jComboBox1.SelectedIndexChanged += new System.EventHandler(this.jComboBox1_SelectedIndexChanged);
            // 
            // listBox_items
            // 
            this.listBox_items.AllowDrop = true;
            this.listBox_items.AllowUserToAddRows = false;
            this.listBox_items.AllowUserToDeleteRows = false;
            this.listBox_items.AllowUserToResizeColumns = false;
            this.listBox_items.AllowUserToResizeRows = false;
            this.listBox_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_items.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_items.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.listBox_items.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.listBox_items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(148)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listBox_items.ColumnHeadersHeight = 30;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.listBox_items.ContextMenuStrip = this.jContextMenu1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle3;
            this.listBox_items.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.listBox_items.EditOnDoubleClick = true;
            this.listBox_items.EnableHeadersVisualStyles = false;
            this.listBox_items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.Location = new System.Drawing.Point(182, 61);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(148)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_items.RowTemplate.Height = 30;
            this.listBox_items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(644, 378);
            this.listBox_items.StandardTab = true;
            this.listBox_items.Style = JHUI.JColorStyle.Magenta;
            this.listBox_items.TabIndex = 7;
            this.listBox_items.Theme = JHUI.JThemeStyle.Dark;
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
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Width = 192;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Z";
            this.Column4.Name = "Column4";
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(111, 26);
            this.jContextMenu1.Style = JHUI.JColorStyle.White;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // jPictureBox1
            // 
            this.jPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.jPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("jPictureBox1.BackgroundImage")));
            this.jPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPictureBox1.Location = new System.Drawing.Point(182, 30);
            this.jPictureBox1.Name = "jPictureBox1";
            this.jPictureBox1.Size = new System.Drawing.Size(23, 22);
            this.jPictureBox1.Style = JHUI.JColorStyle.Orange;
            this.jPictureBox1.TabIndex = 54;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.jPictureBox1_Click);
            // 
            // jComboBox2
            // 
            this.jComboBox2.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.jComboBox2.FontSize = JHUI.JComboBoxSize.Small;
            this.jComboBox2.FormattingEnabled = true;
            this.jComboBox2.ItemHeight = 19;
            this.jComboBox2.Items.AddRange(new object[] {
            "MOB",
            "MINE",
            "NPC"});
            this.jComboBox2.Location = new System.Drawing.Point(23, 105);
            this.jComboBox2.Name = "jComboBox2";
            this.jComboBox2.Size = new System.Drawing.Size(143, 25);
            this.jComboBox2.Style = JHUI.JColorStyle.Magenta;
            this.jComboBox2.TabIndex = 62;
            this.jComboBox2.Theme = JHUI.JThemeStyle.Dark;
            this.jComboBox2.UseSelectable = true;
            this.jComboBox2.SelectedIndexChanged += new System.EventHandler(this.jComboBox2_SelectedIndexChanged);
            // 
            // jCheckBox1
            // 
            this.jCheckBox1.Location = new System.Drawing.Point(23, 136);
            this.jCheckBox1.Name = "jCheckBox1";
            this.jCheckBox1.Size = new System.Drawing.Size(143, 24);
            this.jCheckBox1.Style = JHUI.JColorStyle.Magenta;
            this.jCheckBox1.TabIndex = 66;
            this.jCheckBox1.Text = "Show Unknown?";
            this.jCheckBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox1.UseSelectable = true;
            // 
            // ImportFromCoordNPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 448);
            this.Controls.Add(this.jCheckBox1);
            this.Controls.Add(this.jComboBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.listBox_items);
            this.Controls.Add(this.jComboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportFromCoordNPC";
            this.Style = JHUI.JColorStyle.Magenta;
            this.Text = "Npcgen Maker";
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            this.jContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JComboBox jComboBox1;
        private JHUI.Controls.JDataGridView listBox_items;
        private JHUI.Controls.JPictureBox jPictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private JHUI.Controls.JContextMenu jContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private JHUI.Controls.JComboBox jComboBox2;
        private JHUI.Controls.JCheckBox jCheckBox1;
    }
}