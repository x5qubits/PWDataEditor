using JHUI.Components;
using JHUI.Controls;

namespace sTASKedit
{
	partial class SelectItemIdWindow
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
            this.comboBox_ItemsLists = new JHUI.Controls.JComboBox();
            this.dataGridView_Items = new JHUI.Controls.JDataGridView();
            this.Column_ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.textBox_SearchItemId = new JHUI.Controls.JTextBox();
            this.textBox_SearchItemName = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.richTextBox_Desc = new System.Windows.Forms.RichTextBox();
            this.checkBox_SearchAllLists = new JHUI.Controls.JCheckBox();
            this.dataGridView_Props = new JHUI.Controls.JDataGridView();
            this.Column_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new JHUI.Components.JToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_ItemsLists
            // 
            this.comboBox_ItemsLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_ItemsLists.FontSize = JHUI.JComboBoxSize.Small;
            this.comboBox_ItemsLists.FormattingEnabled = true;
            this.comboBox_ItemsLists.ItemHeight = 19;
            this.comboBox_ItemsLists.Location = new System.Drawing.Point(12, 63);
            this.comboBox_ItemsLists.Name = "comboBox_ItemsLists";
            this.comboBox_ItemsLists.Size = new System.Drawing.Size(630, 25);
            this.comboBox_ItemsLists.Style = JHUI.JColorStyle.Gold;
            this.comboBox_ItemsLists.TabIndex = 999;
            this.comboBox_ItemsLists.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_ItemsLists.UseSelectable = true;
            this.comboBox_ItemsLists.SelectedIndexChanged += new System.EventHandler(this.comboBox_ItemsLists_SelectedIndexChanged);
            // 
            // dataGridView_Items
            // 
            this.dataGridView_Items.AllowUserToAddRows = false;
            this.dataGridView_Items.AllowUserToDeleteRows = false;
            this.dataGridView_Items.AllowUserToResizeColumns = false;
            this.dataGridView_Items.AllowUserToResizeRows = false;
            this.dataGridView_Items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Items.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Items.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ItemId,
            this.Column_ItemName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Items.DefaultCellStyle = dataGridViewCellStyle8;
            //this.dataGridView_Items.DoubleBuffered = true;
            this.dataGridView_Items.EnableHeadersVisualStyles = false;
            this.dataGridView_Items.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Items.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Items.Location = new System.Drawing.Point(12, 98);
            this.dataGridView_Items.Name = "dataGridView_Items";
            this.dataGridView_Items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Items.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_Items.RowHeadersVisible = false;
            this.dataGridView_Items.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Items.RowTemplate.Height = 18;
            this.dataGridView_Items.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Items.Size = new System.Drawing.Size(312, 282);
            this.dataGridView_Items.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Items.TabIndex = 1;
            this.dataGridView_Items.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_Items.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Items_CellMouseEnter);
            this.dataGridView_Items.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Items_Scroll);
            this.dataGridView_Items.SelectionChanged += new System.EventHandler(this.dataGridView_Items_SelectionChanged);
            this.dataGridView_Items.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Items_MouseMove);
            // 
            // Column_ItemId
            // 
            this.Column_ItemId.HeaderText = "Item  Id";
            this.Column_ItemId.Name = "Column_ItemId";
            this.Column_ItemId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ItemId.Width = 70;
            // 
            // Column_ItemName
            // 
            this.Column_ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ItemName.HeaderText = "Name";
            this.Column_ItemName.Name = "Column_ItemName";
            this.Column_ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 474);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(150, 23);
            this.button_Ok.Style = JHUI.JColorStyle.Gold;
            this.button_Ok.TabIndex = 2;
            this.button_Ok.Text = "Ok";
            this.button_Ok.Theme = JHUI.JThemeStyle.Dark;
            this.button_Ok.UseSelectable = true;
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Location = new System.Drawing.Point(175, 474);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(150, 23);
            this.button_Cancel.Style = JHUI.JColorStyle.Gold;
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.Theme = JHUI.JThemeStyle.Dark;
            this.button_Cancel.UseSelectable = true;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // textBox_SearchItemId
            // 
            this.textBox_SearchItemId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchItemId.CustomButton.Image = null;
            this.textBox_SearchItemId.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchItemId.CustomButton.Name = "";
            this.textBox_SearchItemId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchItemId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchItemId.CustomButton.TabIndex = 1;
            this.textBox_SearchItemId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchItemId.CustomButton.UseSelectable = true;
            this.textBox_SearchItemId.CustomButton.Visible = false;
            this.textBox_SearchItemId.Lines = new string[0];
            this.textBox_SearchItemId.Location = new System.Drawing.Point(124, 388);
            this.textBox_SearchItemId.MaxLength = 32767;
            this.textBox_SearchItemId.Name = "textBox_SearchItemId";
            this.textBox_SearchItemId.PasswordChar = '\0';
            this.textBox_SearchItemId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchItemId.SelectedText = "";
            this.textBox_SearchItemId.SelectionLength = 0;
            this.textBox_SearchItemId.SelectionStart = 0;
            this.textBox_SearchItemId.ShortcutsEnabled = true;
            this.textBox_SearchItemId.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchItemId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchItemId.TabIndex = 4;
            this.textBox_SearchItemId.TextWaterMark = "";
            this.textBox_SearchItemId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchItemId.UseSelectable = true;
            this.textBox_SearchItemId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchItemId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchItemId.TextChanged += new System.EventHandler(this.textBox_SearchItemId_TextChanged);
            this.textBox_SearchItemId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchItemId_KeyPress);
            // 
            // textBox_SearchItemName
            // 
            this.textBox_SearchItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchItemName.CustomButton.Image = null;
            this.textBox_SearchItemName.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchItemName.CustomButton.Name = "";
            this.textBox_SearchItemName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchItemName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchItemName.CustomButton.TabIndex = 1;
            this.textBox_SearchItemName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchItemName.CustomButton.UseSelectable = true;
            this.textBox_SearchItemName.CustomButton.Visible = false;
            this.textBox_SearchItemName.Lines = new string[0];
            this.textBox_SearchItemName.Location = new System.Drawing.Point(124, 417);
            this.textBox_SearchItemName.MaxLength = 32767;
            this.textBox_SearchItemName.Name = "textBox_SearchItemName";
            this.textBox_SearchItemName.PasswordChar = '\0';
            this.textBox_SearchItemName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchItemName.SelectedText = "";
            this.textBox_SearchItemName.SelectionLength = 0;
            this.textBox_SearchItemName.SelectionStart = 0;
            this.textBox_SearchItemName.ShortcutsEnabled = true;
            this.textBox_SearchItemName.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchItemName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchItemName.TabIndex = 5;
            this.textBox_SearchItemName.TextWaterMark = "";
            this.textBox_SearchItemName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchItemName.UseSelectable = true;
            this.textBox_SearchItemName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchItemName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchItemName.TextChanged += new System.EventHandler(this.textBox_SearchItemName_TextChanged);
            this.textBox_SearchItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchItemName_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(8, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.Style = JHUI.JColorStyle.Gold;
            this.label1.TabIndex = 6;
            this.label1.Text = "Search By Id:";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(8, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.Style = JHUI.JColorStyle.Gold;
            this.label2.TabIndex = 7;
            this.label2.Text = "Search By Name:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // richTextBox_Desc
            // 
            this.richTextBox_Desc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Desc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.richTextBox_Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Desc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Desc.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.richTextBox_Desc.Location = new System.Drawing.Point(330, 344);
            this.richTextBox_Desc.Name = "richTextBox_Desc";
            this.richTextBox_Desc.Size = new System.Drawing.Size(313, 153);
            this.richTextBox_Desc.TabIndex = 8;
            this.richTextBox_Desc.Text = "";
            // 
            // checkBox_SearchAllLists
            // 
            this.checkBox_SearchAllLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_SearchAllLists.AutoSize = true;
            this.checkBox_SearchAllLists.Checked = true;
            this.checkBox_SearchAllLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SearchAllLists.Location = new System.Drawing.Point(12, 451);
            this.checkBox_SearchAllLists.Name = "checkBox_SearchAllLists";
            this.checkBox_SearchAllLists.Size = new System.Drawing.Size(120, 15);
            this.checkBox_SearchAllLists.Style = JHUI.JColorStyle.Gold;
            this.checkBox_SearchAllLists.TabIndex = 9;
            this.checkBox_SearchAllLists.Text = "Search On All Lists";
            this.checkBox_SearchAllLists.Theme = JHUI.JThemeStyle.Dark;
            this.checkBox_SearchAllLists.UseSelectable = true;
            this.checkBox_SearchAllLists.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Props
            // 
            this.dataGridView_Props.AllowUserToAddRows = false;
            this.dataGridView_Props.AllowUserToDeleteRows = false;
            this.dataGridView_Props.AllowUserToResizeColumns = false;
            this.dataGridView_Props.AllowUserToResizeRows = false;
            this.dataGridView_Props.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Props.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Props.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Props.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Props.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
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
            this.dataGridView_Props.Location = new System.Drawing.Point(330, 98);
            this.dataGridView_Props.Name = "dataGridView_Props";
            this.dataGridView_Props.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
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
            this.dataGridView_Props.Size = new System.Drawing.Size(312, 240);
            this.dataGridView_Props.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Props.TabIndex = 10;
            this.dataGridView_Props.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Column_Parameter
            // 
            this.Column_Parameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_Parameter.HeaderText = "Parameter";
            this.Column_Parameter.Name = "Column_Parameter";
            this.Column_Parameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Parameter.Width = 62;
            // 
            // Column_Value
            // 
            this.Column_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Value.HeaderText = "Value";
            this.Column_Value.Name = "Column_Value";
            this.Column_Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 90000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.Style = JHUI.JColorStyle.Blue;
            this.toolTip.StyleManager = null;
            this.toolTip.Theme = JHUI.JThemeStyle.Light;
            // 
            // SelectItemIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(668, 544);
            this.Controls.Add(this.dataGridView_Props);
            this.Controls.Add(this.checkBox_SearchAllLists);
            this.Controls.Add(this.richTextBox_Desc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_SearchItemName);
            this.Controls.Add(this.textBox_SearchItemId);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.dataGridView_Items);
            this.Controls.Add(this.comboBox_ItemsLists);
            this.MinimumSize = new System.Drawing.Size(668, 422);
            this.Name = "SelectItemIdWindow";
            this.ShowIcon = false;
            this.Text = "SelectItemIdWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectItemIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectItemIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectItemIdWindow_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectItemIdWindow_MouseDown);
            this.MouseLeave += new System.EventHandler(this.SelectItemIdWindow_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectItemIdWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SelectItemIdWindow_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JComboBox comboBox_ItemsLists;
        private JDataGridView dataGridView_Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ItemName;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JTextBox textBox_SearchItemId;
        private JTextBox textBox_SearchItemName;
        private JLabel label1;
        private JLabel label2;
        private System.Windows.Forms.RichTextBox richTextBox_Desc;
        private JCheckBox checkBox_SearchAllLists;
        private JDataGridView dataGridView_Props;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
        private JToolTip toolTip;
	}
}