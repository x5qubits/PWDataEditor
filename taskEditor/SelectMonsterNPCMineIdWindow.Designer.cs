using JHUI.Controls;

namespace sTASKedit
{
    partial class SelectMonsterNPCMineIdWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMonsterNPCMineIdWindow));
            this.comboBox_MonstersNPCsMinesLists = new JHUI.Controls.JComboBox();
            this.dataGridView_MonstersNPCsMines = new JHUI.Controls.JDataGridView();
            this.Column_ElementId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.textBox_SearchMonsterNPCMineId = new JHUI.Controls.JTextBox();
            this.textBox_SearchMonsterNPCMineName = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.checkBox_SearchAllLists = new JHUI.Controls.JCheckBox();
            this.dataGridView_Props = new JHUI.Controls.JDataGridView();
            this.Column_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MonstersNPCsMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_MonstersNPCsMinesLists
            // 
            this.comboBox_MonstersNPCsMinesLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_MonstersNPCsMinesLists.FormattingEnabled = true;
            this.comboBox_MonstersNPCsMinesLists.ItemHeight = 23;
            this.comboBox_MonstersNPCsMinesLists.Location = new System.Drawing.Point(12, 55);
            this.comboBox_MonstersNPCsMinesLists.Name = "comboBox_MonstersNPCsMinesLists";
            this.comboBox_MonstersNPCsMinesLists.Size = new System.Drawing.Size(639, 29);
            this.comboBox_MonstersNPCsMinesLists.Style = JHUI.JColorStyle.Gold;
            this.comboBox_MonstersNPCsMinesLists.TabIndex = 999;
            this.comboBox_MonstersNPCsMinesLists.Theme = JHUI.JThemeStyle.Dark;
            this.comboBox_MonstersNPCsMinesLists.UseSelectable = true;
            this.comboBox_MonstersNPCsMinesLists.SelectedIndexChanged += new System.EventHandler(this.comboBox_MonstersNPCsMinesLists_SelectedIndexChanged);
            // 
            // dataGridView_MonstersNPCsMines
            // 
            this.dataGridView_MonstersNPCsMines.AllowUserToAddRows = false;
            this.dataGridView_MonstersNPCsMines.AllowUserToDeleteRows = false;
            this.dataGridView_MonstersNPCsMines.AllowUserToResizeColumns = false;
            this.dataGridView_MonstersNPCsMines.AllowUserToResizeRows = false;
            this.dataGridView_MonstersNPCsMines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_MonstersNPCsMines.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_MonstersNPCsMines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_MonstersNPCsMines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_MonstersNPCsMines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_MonstersNPCsMines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_MonstersNPCsMines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MonstersNPCsMines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ElementId,
            this.Column_ElementName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_MonstersNPCsMines.DefaultCellStyle = dataGridViewCellStyle8;
            // this.dataGridView_MonstersNPCsMines.DoubleBuffered = true;
            this.dataGridView_MonstersNPCsMines.EnableHeadersVisualStyles = false;
            this.dataGridView_MonstersNPCsMines.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_MonstersNPCsMines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_MonstersNPCsMines.Location = new System.Drawing.Point(12, 90);
            this.dataGridView_MonstersNPCsMines.Name = "dataGridView_MonstersNPCsMines";
            this.dataGridView_MonstersNPCsMines.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_MonstersNPCsMines.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_MonstersNPCsMines.RowHeadersVisible = false;
            this.dataGridView_MonstersNPCsMines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_MonstersNPCsMines.RowTemplate.Height = 18;
            this.dataGridView_MonstersNPCsMines.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_MonstersNPCsMines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MonstersNPCsMines.Size = new System.Drawing.Size(312, 231);
            this.dataGridView_MonstersNPCsMines.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_MonstersNPCsMines.TabIndex = 1;
            this.dataGridView_MonstersNPCsMines.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_MonstersNPCsMines.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MonstersNPCsMines_CellMouseEnter);
            this.dataGridView_MonstersNPCsMines.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_MonstersNPCsMines_Scroll);
            this.dataGridView_MonstersNPCsMines.SelectionChanged += new System.EventHandler(this.dataGridView_MonstersNPCsMines_SelectionChanged);
            this.dataGridView_MonstersNPCsMines.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MonstersNPCsMines_MouseMove);
            // 
            // Column_ElementId
            // 
            this.Column_ElementId.HeaderText = "Element  Id";
            this.Column_ElementId.Name = "Column_ElementId";
            this.Column_ElementId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ElementId.Width = 70;
            // 
            // Column_ElementName
            // 
            this.Column_ElementName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ElementName.HeaderText = "Name";
            this.Column_ElementName.Name = "Column_ElementName";
            this.Column_ElementName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 415);
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
            this.button_Cancel.Location = new System.Drawing.Point(175, 415);
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
            // textBox_SearchMonsterNPCMineId
            // 
            this.textBox_SearchMonsterNPCMineId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchMonsterNPCMineId.CustomButton.Image = null;
            this.textBox_SearchMonsterNPCMineId.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchMonsterNPCMineId.CustomButton.Name = "";
            this.textBox_SearchMonsterNPCMineId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchMonsterNPCMineId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchMonsterNPCMineId.CustomButton.TabIndex = 1;
            this.textBox_SearchMonsterNPCMineId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchMonsterNPCMineId.CustomButton.UseSelectable = true;
            this.textBox_SearchMonsterNPCMineId.CustomButton.Visible = false;
            this.textBox_SearchMonsterNPCMineId.Lines = new string[0];
            this.textBox_SearchMonsterNPCMineId.Location = new System.Drawing.Point(124, 329);
            this.textBox_SearchMonsterNPCMineId.MaxLength = 32767;
            this.textBox_SearchMonsterNPCMineId.Name = "textBox_SearchMonsterNPCMineId";
            this.textBox_SearchMonsterNPCMineId.PasswordChar = '\0';
            this.textBox_SearchMonsterNPCMineId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchMonsterNPCMineId.SelectedText = "";
            this.textBox_SearchMonsterNPCMineId.SelectionLength = 0;
            this.textBox_SearchMonsterNPCMineId.SelectionStart = 0;
            this.textBox_SearchMonsterNPCMineId.ShortcutsEnabled = true;
            this.textBox_SearchMonsterNPCMineId.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchMonsterNPCMineId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchMonsterNPCMineId.TabIndex = 4;
            this.textBox_SearchMonsterNPCMineId.TextWaterMark = "";
            this.textBox_SearchMonsterNPCMineId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchMonsterNPCMineId.UseSelectable = true;
            this.textBox_SearchMonsterNPCMineId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchMonsterNPCMineId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchMonsterNPCMineId.TextChanged += new System.EventHandler(this.textBox_SearchMonsterNPCMineId_TextChanged);
            this.textBox_SearchMonsterNPCMineId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchMonsterNPCMineId_KeyPress);
            // 
            // textBox_SearchMonsterNPCMineName
            // 
            this.textBox_SearchMonsterNPCMineName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchMonsterNPCMineName.CustomButton.Image = null;
            this.textBox_SearchMonsterNPCMineName.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchMonsterNPCMineName.CustomButton.Name = "";
            this.textBox_SearchMonsterNPCMineName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchMonsterNPCMineName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchMonsterNPCMineName.CustomButton.TabIndex = 1;
            this.textBox_SearchMonsterNPCMineName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchMonsterNPCMineName.CustomButton.UseSelectable = true;
            this.textBox_SearchMonsterNPCMineName.CustomButton.Visible = false;
            this.textBox_SearchMonsterNPCMineName.Lines = new string[0];
            this.textBox_SearchMonsterNPCMineName.Location = new System.Drawing.Point(124, 358);
            this.textBox_SearchMonsterNPCMineName.MaxLength = 32767;
            this.textBox_SearchMonsterNPCMineName.Name = "textBox_SearchMonsterNPCMineName";
            this.textBox_SearchMonsterNPCMineName.PasswordChar = '\0';
            this.textBox_SearchMonsterNPCMineName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchMonsterNPCMineName.SelectedText = "";
            this.textBox_SearchMonsterNPCMineName.SelectionLength = 0;
            this.textBox_SearchMonsterNPCMineName.SelectionStart = 0;
            this.textBox_SearchMonsterNPCMineName.ShortcutsEnabled = true;
            this.textBox_SearchMonsterNPCMineName.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchMonsterNPCMineName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchMonsterNPCMineName.TabIndex = 5;
            this.textBox_SearchMonsterNPCMineName.TextWaterMark = "";
            this.textBox_SearchMonsterNPCMineName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchMonsterNPCMineName.UseSelectable = true;
            this.textBox_SearchMonsterNPCMineName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchMonsterNPCMineName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchMonsterNPCMineName.TextChanged += new System.EventHandler(this.textBox_SearchMonsterNPCMineName_TextChanged);
            this.textBox_SearchMonsterNPCMineName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchMonsterNPCMineName_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(8, 333);
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
            this.label2.Location = new System.Drawing.Point(8, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.Style = JHUI.JColorStyle.Gold;
            this.label2.TabIndex = 7;
            this.label2.Text = "Search By Name:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // checkBox_SearchAllLists
            // 
            this.checkBox_SearchAllLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_SearchAllLists.AutoSize = true;
            this.checkBox_SearchAllLists.Checked = true;
            this.checkBox_SearchAllLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SearchAllLists.Location = new System.Drawing.Point(12, 392);
            this.checkBox_SearchAllLists.Name = "checkBox_SearchAllLists";
            this.checkBox_SearchAllLists.Size = new System.Drawing.Size(120, 15);
            this.checkBox_SearchAllLists.Style = JHUI.JColorStyle.Gold;
            this.checkBox_SearchAllLists.TabIndex = 8;
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
            this.dataGridView_Props.Location = new System.Drawing.Point(330, 90);
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
            this.dataGridView_Props.Size = new System.Drawing.Size(321, 347);
            this.dataGridView_Props.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Props.TabIndex = 9;
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
            // SelectMonsterNPCMineIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(668, 485);
            this.Controls.Add(this.dataGridView_Props);
            this.Controls.Add(this.checkBox_SearchAllLists);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_SearchMonsterNPCMineName);
            this.Controls.Add(this.textBox_SearchMonsterNPCMineId);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.dataGridView_MonstersNPCsMines);
            this.Controls.Add(this.comboBox_MonstersNPCsMinesLists);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(668, 422);
            this.Name = "SelectMonsterNPCMineIdWindow";
            this.ShowIcon = false;
            this.Text = "SelectMonsterNPCMineIdWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectMonsterNPCMineIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectMonsterNPCMineIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectMonsterNPCMineIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MonstersNPCsMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JComboBox comboBox_MonstersNPCsMinesLists;
        private JDataGridView dataGridView_MonstersNPCsMines;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JTextBox textBox_SearchMonsterNPCMineId;
        private JTextBox textBox_SearchMonsterNPCMineName;
        private JLabel label1;
        private JLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ElementId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ElementName;
        private JCheckBox checkBox_SearchAllLists;
        private JDataGridView dataGridView_Props;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
	}
}