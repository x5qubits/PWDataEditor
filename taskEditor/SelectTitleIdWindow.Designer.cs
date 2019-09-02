using JHUI.Controls;

namespace sTASKedit
{
    partial class SelectTitleIdWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTitleIdWindow));
            this.dataGridView_Titles = new JHUI.Controls.JDataGridView();
            this.Column_TitleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TitleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_SearchTitleId = new JHUI.Controls.JTextBox();
            this.textBox_SearchTitleName = new JHUI.Controls.JTextBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.dataGridView_Props = new JHUI.Controls.JDataGridView();
            this.Column_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Titles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Titles
            // 
            this.dataGridView_Titles.AllowUserToAddRows = false;
            this.dataGridView_Titles.AllowUserToDeleteRows = false;
            this.dataGridView_Titles.AllowUserToResizeColumns = false;
            this.dataGridView_Titles.AllowUserToResizeRows = false;
            this.dataGridView_Titles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Titles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Titles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Titles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Titles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Titles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Titles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Titles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_TitleId,
            this.Column_TitleName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Titles.DefaultCellStyle = dataGridViewCellStyle8;
            // this.dataGridView_Titles.DoubleBuffered = true;
            this.dataGridView_Titles.EnableHeadersVisualStyles = false;
            this.dataGridView_Titles.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Titles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Titles.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_Titles.Name = "dataGridView_Titles";
            this.dataGridView_Titles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Titles.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_Titles.RowHeadersVisible = false;
            this.dataGridView_Titles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Titles.RowTemplate.Height = 18;
            this.dataGridView_Titles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Titles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Titles.Size = new System.Drawing.Size(312, 220);
            this.dataGridView_Titles.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Titles.TabIndex = 0;
            this.dataGridView_Titles.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_Titles.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Titles_CellMouseEnter);
            this.dataGridView_Titles.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Titles_Scroll);
            this.dataGridView_Titles.SelectionChanged += new System.EventHandler(this.dataGridView_Titles_SelectionChanged);
            this.dataGridView_Titles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Titles_MouseMove);
            // 
            // Column_TitleId
            // 
            this.Column_TitleId.HeaderText = "Title Id";
            this.Column_TitleId.Name = "Column_TitleId";
            this.Column_TitleId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_TitleId.Width = 70;
            // 
            // Column_TitleName
            // 
            this.Column_TitleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_TitleName.HeaderText = "Name";
            this.Column_TitleName.Name = "Column_TitleName";
            this.Column_TitleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBox_SearchTitleId
            // 
            this.textBox_SearchTitleId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchTitleId.CustomButton.Image = null;
            this.textBox_SearchTitleId.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchTitleId.CustomButton.Name = "";
            this.textBox_SearchTitleId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchTitleId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchTitleId.CustomButton.TabIndex = 1;
            this.textBox_SearchTitleId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchTitleId.CustomButton.UseSelectable = true;
            this.textBox_SearchTitleId.CustomButton.Visible = false;
            this.textBox_SearchTitleId.Lines = new string[0];
            this.textBox_SearchTitleId.Location = new System.Drawing.Point(124, 291);
            this.textBox_SearchTitleId.MaxLength = 32767;
            this.textBox_SearchTitleId.Name = "textBox_SearchTitleId";
            this.textBox_SearchTitleId.PasswordChar = '\0';
            this.textBox_SearchTitleId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchTitleId.SelectedText = "";
            this.textBox_SearchTitleId.SelectionLength = 0;
            this.textBox_SearchTitleId.SelectionStart = 0;
            this.textBox_SearchTitleId.ShortcutsEnabled = true;
            this.textBox_SearchTitleId.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchTitleId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchTitleId.TabIndex = 1;
            this.textBox_SearchTitleId.TextWaterMark = "";
            this.textBox_SearchTitleId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchTitleId.UseSelectable = true;
            this.textBox_SearchTitleId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchTitleId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchTitleId.TextChanged += new System.EventHandler(this.textBox_SearchTitleId_TextChanged);
            this.textBox_SearchTitleId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchTitleId_KeyPress);
            // 
            // textBox_SearchTitleName
            // 
            this.textBox_SearchTitleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchTitleName.CustomButton.Image = null;
            this.textBox_SearchTitleName.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchTitleName.CustomButton.Name = "";
            this.textBox_SearchTitleName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchTitleName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchTitleName.CustomButton.TabIndex = 1;
            this.textBox_SearchTitleName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchTitleName.CustomButton.UseSelectable = true;
            this.textBox_SearchTitleName.CustomButton.Visible = false;
            this.textBox_SearchTitleName.Lines = new string[0];
            this.textBox_SearchTitleName.Location = new System.Drawing.Point(124, 320);
            this.textBox_SearchTitleName.MaxLength = 32767;
            this.textBox_SearchTitleName.Name = "textBox_SearchTitleName";
            this.textBox_SearchTitleName.PasswordChar = '\0';
            this.textBox_SearchTitleName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchTitleName.SelectedText = "";
            this.textBox_SearchTitleName.SelectionLength = 0;
            this.textBox_SearchTitleName.SelectionStart = 0;
            this.textBox_SearchTitleName.ShortcutsEnabled = true;
            this.textBox_SearchTitleName.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchTitleName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchTitleName.TabIndex = 2;
            this.textBox_SearchTitleName.TextWaterMark = "";
            this.textBox_SearchTitleName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchTitleName.UseSelectable = true;
            this.textBox_SearchTitleName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchTitleName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchTitleName.TextChanged += new System.EventHandler(this.textBox_SearchTitleName_TextChanged);
            this.textBox_SearchTitleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchTitleName_KeyPress);
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 348);
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
            this.button_Cancel.Location = new System.Drawing.Point(175, 348);
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
            this.label1.Location = new System.Drawing.Point(8, 295);
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
            this.label2.Location = new System.Drawing.Point(8, 324);
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Props.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_Props.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Props.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Parameter,
            this.Column_Value});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Props.DefaultCellStyle = dataGridViewCellStyle11;
            // this.dataGridView_Props.DoubleBuffered = true;
            this.dataGridView_Props.EnableHeadersVisualStyles = false;
            this.dataGridView_Props.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Props.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Props.Location = new System.Drawing.Point(330, 63);
            this.dataGridView_Props.Name = "dataGridView_Props";
            this.dataGridView_Props.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Props.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView_Props.RowHeadersVisible = false;
            this.dataGridView_Props.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Props.RowTemplate.Height = 18;
            this.dataGridView_Props.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Props.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Props.Size = new System.Drawing.Size(324, 307);
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
            // SelectTitleIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(668, 418);
            this.Controls.Add(this.dataGridView_Props);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_SearchTitleName);
            this.Controls.Add(this.textBox_SearchTitleId);
            this.Controls.Add(this.dataGridView_Titles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(668, 418);
            this.Name = "SelectTitleIdWindow";
            this.ShowIcon = false;
            this.Text = "SelectTitleIdWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectTitleIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectTitleIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectTitleIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Titles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JDataGridView dataGridView_Titles;
        private JTextBox textBox_SearchTitleId;
        private JTextBox textBox_SearchTitleName;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JLabel label1;
        private JLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TitleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TitleName;
        private JDataGridView dataGridView_Props;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
	}
}