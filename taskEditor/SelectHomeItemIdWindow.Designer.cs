using JHUI.Controls;

namespace sTASKedit
{
    partial class SelectHomeItemIdWindow
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectHomeItemIdWindow));
            this.dataGridView_HomeItems = new JHUI.Controls.JDataGridView();
            this.Column_HomeItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_HomeItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_SearchHomeItemId = new JHUI.Controls.JTextBox();
            this.textBox_SearchHomeItemName = new JHUI.Controls.JTextBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.dataGridView_Props = new JHUI.Controls.JDataGridView();
            this.Column_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HomeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_HomeItems
            // 
            this.dataGridView_HomeItems.AllowUserToAddRows = false;
            this.dataGridView_HomeItems.AllowUserToDeleteRows = false;
            this.dataGridView_HomeItems.AllowUserToResizeColumns = false;
            this.dataGridView_HomeItems.AllowUserToResizeRows = false;
            this.dataGridView_HomeItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_HomeItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_HomeItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_HomeItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_HomeItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_HomeItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_HomeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HomeItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_HomeItemId,
            this.Column_HomeItemName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_HomeItems.DefaultCellStyle = dataGridViewCellStyle2;
            // this.dataGridView_HomeItems.DoubleBuffered = true;
            this.dataGridView_HomeItems.EnableHeadersVisualStyles = false;
            this.dataGridView_HomeItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_HomeItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_HomeItems.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_HomeItems.Name = "dataGridView_HomeItems";
            this.dataGridView_HomeItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_HomeItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_HomeItems.RowHeadersVisible = false;
            this.dataGridView_HomeItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_HomeItems.RowTemplate.Height = 18;
            this.dataGridView_HomeItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_HomeItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_HomeItems.Size = new System.Drawing.Size(312, 295);
            this.dataGridView_HomeItems.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_HomeItems.TabIndex = 0;
            this.dataGridView_HomeItems.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_HomeItems.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_HomeItems_CellMouseEnter);
            this.dataGridView_HomeItems.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_HomeItems_Scroll);
            this.dataGridView_HomeItems.SelectionChanged += new System.EventHandler(this.dataGridView_HomeItems_SelectionChanged);
            this.dataGridView_HomeItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_HomeItems_MouseMove);
            // 
            // Column_HomeItemId
            // 
            this.Column_HomeItemId.HeaderText = "Home Item Id";
            this.Column_HomeItemId.Name = "Column_HomeItemId";
            this.Column_HomeItemId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_HomeItemId.Width = 70;
            // 
            // Column_HomeItemName
            // 
            this.Column_HomeItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_HomeItemName.HeaderText = "Name";
            this.Column_HomeItemName.Name = "Column_HomeItemName";
            this.Column_HomeItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBox_SearchHomeItemId
            // 
            this.textBox_SearchHomeItemId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchHomeItemId.CustomButton.Image = null;
            this.textBox_SearchHomeItemId.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchHomeItemId.CustomButton.Name = "";
            this.textBox_SearchHomeItemId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchHomeItemId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchHomeItemId.CustomButton.TabIndex = 1;
            this.textBox_SearchHomeItemId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchHomeItemId.CustomButton.UseSelectable = true;
            this.textBox_SearchHomeItemId.CustomButton.Visible = false;
            this.textBox_SearchHomeItemId.Lines = new string[0];
            this.textBox_SearchHomeItemId.Location = new System.Drawing.Point(124, 366);
            this.textBox_SearchHomeItemId.MaxLength = 32767;
            this.textBox_SearchHomeItemId.Name = "textBox_SearchHomeItemId";
            this.textBox_SearchHomeItemId.PasswordChar = '\0';
            this.textBox_SearchHomeItemId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchHomeItemId.SelectedText = "";
            this.textBox_SearchHomeItemId.SelectionLength = 0;
            this.textBox_SearchHomeItemId.SelectionStart = 0;
            this.textBox_SearchHomeItemId.ShortcutsEnabled = true;
            this.textBox_SearchHomeItemId.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchHomeItemId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchHomeItemId.TabIndex = 1;
            this.textBox_SearchHomeItemId.TextWaterMark = "";
            this.textBox_SearchHomeItemId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchHomeItemId.UseSelectable = true;
            this.textBox_SearchHomeItemId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchHomeItemId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchHomeItemId.TextChanged += new System.EventHandler(this.textBox_SearchHomeItemId_TextChanged);
            this.textBox_SearchHomeItemId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchHomeItemId_KeyPress);
            // 
            // textBox_SearchHomeItemName
            // 
            this.textBox_SearchHomeItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchHomeItemName.CustomButton.Image = null;
            this.textBox_SearchHomeItemName.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchHomeItemName.CustomButton.Name = "";
            this.textBox_SearchHomeItemName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchHomeItemName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchHomeItemName.CustomButton.TabIndex = 1;
            this.textBox_SearchHomeItemName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchHomeItemName.CustomButton.UseSelectable = true;
            this.textBox_SearchHomeItemName.CustomButton.Visible = false;
            this.textBox_SearchHomeItemName.Lines = new string[0];
            this.textBox_SearchHomeItemName.Location = new System.Drawing.Point(124, 395);
            this.textBox_SearchHomeItemName.MaxLength = 32767;
            this.textBox_SearchHomeItemName.Name = "textBox_SearchHomeItemName";
            this.textBox_SearchHomeItemName.PasswordChar = '\0';
            this.textBox_SearchHomeItemName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchHomeItemName.SelectedText = "";
            this.textBox_SearchHomeItemName.SelectionLength = 0;
            this.textBox_SearchHomeItemName.SelectionStart = 0;
            this.textBox_SearchHomeItemName.ShortcutsEnabled = true;
            this.textBox_SearchHomeItemName.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchHomeItemName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchHomeItemName.TabIndex = 2;
            this.textBox_SearchHomeItemName.TextWaterMark = "";
            this.textBox_SearchHomeItemName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchHomeItemName.UseSelectable = true;
            this.textBox_SearchHomeItemName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchHomeItemName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchHomeItemName.TextChanged += new System.EventHandler(this.textBox_SearchHomeItemName_TextChanged);
            this.textBox_SearchHomeItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchHomeItemName_KeyPress);
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 423);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(150, 23);
            this.button_Ok.Style = JHUI.JColorStyle.Gold;
            this.button_Ok.TabIndex = 3;
            this.button_Ok.Text = "Ok";
            this.button_Ok.Theme = JHUI.JThemeStyle.Dark;
            this.button_Ok.UseSelectable = true;
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Location = new System.Drawing.Point(175, 423);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(150, 23);
            this.button_Cancel.Style = JHUI.JColorStyle.Gold;
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.Theme = JHUI.JThemeStyle.Dark;
            this.button_Cancel.UseSelectable = true;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(8, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.Style = JHUI.JColorStyle.Gold;
            this.label1.TabIndex = 5;
            this.label1.Text = "Search By Id:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(8, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.Style = JHUI.JColorStyle.Gold;
            this.label2.TabIndex = 6;
            this.label2.Text = "Search By Name:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // dataGridView_Props
            // 
            this.dataGridView_Props.AllowUserToAddRows = false;
            this.dataGridView_Props.AllowUserToDeleteRows = false;
            this.dataGridView_Props.AllowUserToResizeColumns = false;
            this.dataGridView_Props.AllowUserToResizeRows = false;
            this.dataGridView_Props.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Props.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Props.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Props.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Props.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Props.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Props.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Props.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Parameter,
            this.Column_Value});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Props.DefaultCellStyle = dataGridViewCellStyle5;
            //  this.dataGridView_Props.DoubleBuffered = true;
            this.dataGridView_Props.EnableHeadersVisualStyles = false;
            this.dataGridView_Props.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Props.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Props.Location = new System.Drawing.Point(330, 63);
            this.dataGridView_Props.Name = "dataGridView_Props";
            this.dataGridView_Props.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Props.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Props.RowHeadersVisible = false;
            this.dataGridView_Props.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Props.RowTemplate.Height = 18;
            this.dataGridView_Props.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Props.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Props.Size = new System.Drawing.Size(312, 382);
            this.dataGridView_Props.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Props.TabIndex = 7;
            this.dataGridView_Props.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Column_Parameter
            // 
            this.Column_Parameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_Parameter.HeaderText = "Parameter";
            this.Column_Parameter.Name = "Column_Parameter";
            this.Column_Parameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Parameter.Width = 63;
            // 
            // Column_Value
            // 
            this.Column_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Value.HeaderText = "Value";
            this.Column_Value.Name = "Column_Value";
            this.Column_Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SelectHomeItemIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(668, 493);
            this.Controls.Add(this.dataGridView_Props);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_SearchHomeItemName);
            this.Controls.Add(this.textBox_SearchHomeItemId);
            this.Controls.Add(this.dataGridView_HomeItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectHomeItemIdWindow";
            this.ShowIcon = false;
            this.Text = "Select Home ItemId Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectHomeItemIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectHomeItemIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectHomeItemIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HomeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JDataGridView dataGridView_HomeItems;
        private JTextBox textBox_SearchHomeItemId;
        private JTextBox textBox_SearchHomeItemName;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JLabel label1;
        private JLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_HomeItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_HomeItemName;
        private JDataGridView dataGridView_Props;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
	}
}