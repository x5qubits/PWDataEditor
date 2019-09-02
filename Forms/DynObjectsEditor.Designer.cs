namespace ElementEditor
{
    partial class DynObjectsEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynObjectsEditor));
            this.listBox_items = new JHUI.Controls.JDataGridView();
            this.RowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jCheckBox1 = new JHUI.Controls.JCheckBox();
            this.textBox_search = new JHUI.Controls.JTextBox();
            this.jPictureBox2 = new JHUI.Controls.JPictureBox();
            this.jPictureBox1 = new JHUI.Controls.JPictureBox();
            this.MenuSubCat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_moveCat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).BeginInit();
            this.MenuSubCat.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listBox_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listBox_items.ColumnHeadersHeight = 22;
            this.listBox_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.listBox_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowId,
            this.Column2});
            this.listBox_items.ContextMenuStrip = this.MenuSubCat;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listBox_items.DefaultCellStyle = dataGridViewCellStyle2;
            this.listBox_items.EnableHeadersVisualStyles = false;
            this.listBox_items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBox_items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.Location = new System.Drawing.Point(23, 82);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox_items.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listBox_items.RowHeadersVisible = false;
            this.listBox_items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listBox_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBox_items.Size = new System.Drawing.Size(919, 563);
            this.listBox_items.Style = JHUI.JColorStyle.White;
            this.listBox_items.TabIndex = 42;
            this.listBox_items.Theme = JHUI.JThemeStyle.Dark;
            this.listBox_items.VirtualMode = true;
            this.listBox_items.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listBox_items_CellValueChanged);
            this.listBox_items.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.listBox_items_CellValueNeeded);
            // 
            // RowId
            // 
            this.RowId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RowId.HeaderText = "ID";
            this.RowId.Name = "RowId";
            this.RowId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RowId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowId.Width = 22;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 115.4045F;
            this.Column2.HeaderText = "Path";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // jCheckBox1
            // 
            this.jCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jCheckBox1.AutoSize = true;
            this.jCheckBox1.Location = new System.Drawing.Point(23, 686);
            this.jCheckBox1.Name = "jCheckBox1";
            this.jCheckBox1.Size = new System.Drawing.Size(98, 15);
            this.jCheckBox1.Style = JHUI.JColorStyle.Gold;
            this.jCheckBox1.TabIndex = 48;
            this.jCheckBox1.Text = "Case-sensitive";
            this.jCheckBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jCheckBox1.UseSelectable = true;
            this.jCheckBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_search
            // 
            this.textBox_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_search.BorderBottomLineSize = 5;
            this.textBox_search.BorderColor = System.Drawing.Color.Black;
            this.textBox_search.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox_search.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.textBox_search.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.textBox_search.CustomButton.Name = "";
            this.textBox_search.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.textBox_search.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_search.CustomButton.TabIndex = 1;
            this.textBox_search.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_search.CustomButton.UseSelectable = true;
            this.textBox_search.DrawBorder = true;
            this.textBox_search.DrawBorderBottomLine = false;
            this.textBox_search.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_search.FontSize = JHUI.JTextBoxSize.Medium;
            this.textBox_search.Lines = new string[0];
            this.textBox_search.Location = new System.Drawing.Point(23, 651);
            this.textBox_search.MaxLength = 32767;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.PasswordChar = '\0';
            this.textBox_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_search.SelectedText = "";
            this.textBox_search.SelectionLength = 0;
            this.textBox_search.SelectionStart = 0;
            this.textBox_search.ShortcutsEnabled = true;
            this.textBox_search.ShowButton = true;
            this.textBox_search.Size = new System.Drawing.Size(185, 29);
            this.textBox_search.Style = JHUI.JColorStyle.Gold;
            this.textBox_search.TabIndex = 47;
            this.textBox_search.TextWaterMark = "Search...";
            this.textBox_search.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_search.UseCustomFont = true;
            this.textBox_search.UseSelectable = true;
            this.textBox_search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_search.ButtonClick += new JHUI.Controls.JTextBox.ButClick(this.search_ButtonClick);
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
            this.jPictureBox2.TabIndex = 53;
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
            this.jPictureBox1.TabIndex = 52;
            this.jPictureBox1.TabStop = false;
            this.jPictureBox1.Theme = JHUI.JThemeStyle.Dark;
            this.jPictureBox1.Click += new System.EventHandler(this.jPictureBox1_Click);
            // 
            // MenuSubCat
            // 
            this.MenuSubCat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_moveCat,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.viewToolStripMenuItem});
            this.MenuSubCat.Name = "contextMenuStrip_SubCat";
            this.MenuSubCat.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuSubCat.Size = new System.Drawing.Size(153, 126);
            // 
            // toolStripMenuItem_moveCat
            // 
            this.toolStripMenuItem_moveCat.Image = global::PWDataEditorPaied.Properties.Resources.Login;
            this.toolStripMenuItem_moveCat.Name = "toolStripMenuItem_moveCat";
            this.toolStripMenuItem_moveCat.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_moveCat.Text = "Replace";
            this.toolStripMenuItem_moveCat.Click += new System.EventHandler(this.LogicReplace);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PWDataEditorPaied.Properties.Resources.Add;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.AddNew);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::PWDataEditorPaied.Properties.Resources.Delete1;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.Delete);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = global::PWDataEditorPaied.Properties.Resources.View;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // DynObjectsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 709);
            this.Controls.Add(this.jPictureBox2);
            this.Controls.Add(this.jPictureBox1);
            this.Controls.Add(this.jCheckBox1);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.listBox_items);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DynObjectsEditor";
            this.Text = "DynObjects Editor";
            this.Shown += new System.EventHandler(this.DynObjectsEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.listBox_items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPictureBox1)).EndInit();
            this.MenuSubCat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JHUI.Controls.JDataGridView listBox_items;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private JHUI.Controls.JCheckBox jCheckBox1;
        private JHUI.Controls.JTextBox textBox_search;
        private JHUI.Controls.JPictureBox jPictureBox2;
        private JHUI.Controls.JPictureBox jPictureBox1;
        private System.Windows.Forms.ContextMenuStrip MenuSubCat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_moveCat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    }
}