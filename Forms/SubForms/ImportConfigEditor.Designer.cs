namespace PWDataEditorPaied.Forms.SubForms
{
    partial class ImportConfigEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportConfigEditor));
            this.jButton1 = new JHUI.Controls.JButton();
            this.listBox_items = new JHUI.Controls.JDataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionFromBox1 = new JHUI.Controls.JTextBox();
            this.versionFromBox2 = new JHUI.Controls.JTextBox();
            this.jButton2 = new JHUI.Controls.JButton();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.jLabel2 = new JHUI.Controls.JLabel();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            this.jContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jButton1
            // 
            this.jButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jButton1.Location = new System.Drawing.Point(24, 400);
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(489, 23);
            this.jButton1.Style = JHUI.JColorStyle.Blue;
            this.jButton1.TabIndex = 0;
            this.jButton1.Text = "Save";
            this.jButton1.Theme = JHUI.JThemeStyle.Dark;
            this.jButton1.UseSelectable = true;
            this.jButton1.UseVisualStyleBackColor = true;
            this.jButton1.Click += new System.EventHandler(this.SaveButton);
            // 
            // listBox_items
            // 
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listBox_items.ColumnHeadersHeight = 22;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.Column1,
            this.Column2});
            this.listBox_items.ContextMenuStrip = this.jContextMenu1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle3;
            this.listBox_items.EnableHeadersVisualStyles = false;
            this.listBox_items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.Location = new System.Drawing.Point(24, 95);
            this.listBox_items.MultiSelect = false;
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidth = 22;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_items.RowTemplate.Height = 30;
            this.listBox_items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(489, 299);
            this.listBox_items.Style = JHUI.JColorStyle.Blue;
            this.listBox_items.TabIndex = 29;
            this.listBox_items.TabStop = false;
            this.listBox_items.Theme = JHUI.JThemeStyle.Dark;
            // 
            // ColumnId
            // 
            this.ColumnId.FillWeight = 50F;
            this.ColumnId.HeaderText = "List Id";
            this.ColumnId.MinimumWidth = 50;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnId.Width = 50;
            // 
            // ColumnName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnName.FillWeight = 50F;
            this.ColumnName.HeaderText = "Row Id";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Width = 47;
            // 
            // Column1
            // 
            this.Column1.AutoComplete = false;
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column1.FillWeight = 200F;
            this.Column1.HeaderText = "Operation";
            this.Column1.Items.AddRange(new object[] {
            "Delete Row",
            "Add Row",
            "Replace"});
            this.Column1.MaxDropDownItems = 3;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 150F;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(108, 48);
            this.jContextMenu1.Style = JHUI.JColorStyle.Gold;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.Trash;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // versionFromBox1
            // 
            // 
            // 
            // 
            this.versionFromBox1.CustomButton.Image = null;
            this.versionFromBox1.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.versionFromBox1.CustomButton.Name = "";
            this.versionFromBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.versionFromBox1.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.versionFromBox1.CustomButton.TabIndex = 1;
            this.versionFromBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.versionFromBox1.CustomButton.UseSelectable = true;
            this.versionFromBox1.CustomButton.Visible = false;
            this.versionFromBox1.Lines = new string[] {
        "7"};
            this.versionFromBox1.Location = new System.Drawing.Point(102, 66);
            this.versionFromBox1.MaxLength = 32767;
            this.versionFromBox1.Name = "versionFromBox1";
            this.versionFromBox1.PasswordChar = '\0';
            this.versionFromBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.versionFromBox1.SelectedText = "";
            this.versionFromBox1.SelectionLength = 0;
            this.versionFromBox1.SelectionStart = 0;
            this.versionFromBox1.ShortcutsEnabled = true;
            this.versionFromBox1.Size = new System.Drawing.Size(100, 23);
            this.versionFromBox1.Style = JHUI.JColorStyle.Blue;
            this.versionFromBox1.TabIndex = 30;
            this.versionFromBox1.Text = "7";
            this.versionFromBox1.TextWaterMark = "Version From";
            this.versionFromBox1.Theme = JHUI.JThemeStyle.Dark;
            this.versionFromBox1.UseSelectable = true;
            this.versionFromBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.versionFromBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // versionFromBox2
            // 
            // 
            // 
            // 
            this.versionFromBox2.CustomButton.Image = null;
            this.versionFromBox2.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.versionFromBox2.CustomButton.Name = "";
            this.versionFromBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.versionFromBox2.CustomButton.Style = JHUI.JColorStyle.Gold;
            this.versionFromBox2.CustomButton.TabIndex = 1;
            this.versionFromBox2.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.versionFromBox2.CustomButton.UseSelectable = true;
            this.versionFromBox2.CustomButton.Visible = false;
            this.versionFromBox2.Lines = new string[] {
        "12"};
            this.versionFromBox2.Location = new System.Drawing.Point(278, 66);
            this.versionFromBox2.MaxLength = 32767;
            this.versionFromBox2.Name = "versionFromBox2";
            this.versionFromBox2.PasswordChar = '\0';
            this.versionFromBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.versionFromBox2.SelectedText = "";
            this.versionFromBox2.SelectionLength = 0;
            this.versionFromBox2.SelectionStart = 0;
            this.versionFromBox2.ShortcutsEnabled = true;
            this.versionFromBox2.Size = new System.Drawing.Size(100, 23);
            this.versionFromBox2.Style = JHUI.JColorStyle.Blue;
            this.versionFromBox2.TabIndex = 31;
            this.versionFromBox2.Text = "12";
            this.versionFromBox2.TextWaterMark = "Version To";
            this.versionFromBox2.Theme = JHUI.JThemeStyle.Dark;
            this.versionFromBox2.UseSelectable = true;
            this.versionFromBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.versionFromBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // jButton2
            // 
            this.jButton2.Location = new System.Drawing.Point(398, 66);
            this.jButton2.Name = "jButton2";
            this.jButton2.Size = new System.Drawing.Size(115, 23);
            this.jButton2.Style = JHUI.JColorStyle.Blue;
            this.jButton2.TabIndex = 32;
            this.jButton2.Text = "Read from Disk";
            this.jButton2.Theme = JHUI.JThemeStyle.Dark;
            this.jButton2.UseSelectable = true;
            this.jButton2.UseVisualStyleBackColor = true;
            this.jButton2.Click += new System.EventHandler(this.jButton2_Click);
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.FontSize = JHUI.JLabelSize.Small;
            this.jLabel1.Location = new System.Drawing.Point(215, 71);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(57, 15);
            this.jLabel1.Style = JHUI.JColorStyle.Blue;
            this.jLabel1.TabIndex = 33;
            this.jLabel1.Text = "Version To";
            this.jLabel1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // jLabel2
            // 
            this.jLabel2.AutoSize = true;
            this.jLabel2.FontSize = JHUI.JLabelSize.Small;
            this.jLabel2.Location = new System.Drawing.Point(23, 71);
            this.jLabel2.Name = "jLabel2";
            this.jLabel2.Size = new System.Drawing.Size(73, 15);
            this.jLabel2.Style = JHUI.JColorStyle.Blue;
            this.jLabel2.TabIndex = 34;
            this.jLabel2.Text = "Version From";
            this.jLabel2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // ImportConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 446);
            this.Controls.Add(this.jLabel2);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.jButton2);
            this.Controls.Add(this.versionFromBox2);
            this.Controls.Add(this.versionFromBox1);
            this.Controls.Add(this.listBox_items);
            this.Controls.Add(this.jButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportConfigEditor";
            this.Style = JHUI.JColorStyle.Blue;
            this.Text = "Elements Import Config Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceEditor_FormClosing);
            this.Shown += new System.EventHandler(this.ReplaceEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            this.jContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JButton jButton1;
        private JHUI.Controls.JDataGridView listBox_items;
        private JHUI.Controls.JTextBox versionFromBox1;
        private JHUI.Controls.JTextBox versionFromBox2;
        private JHUI.Controls.JButton jButton2;
        private JHUI.Controls.JLabel jLabel1;
        private JHUI.Controls.JLabel jLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private JHUI.Controls.JContextMenu jContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}