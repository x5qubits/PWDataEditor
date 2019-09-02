using JHUI.Controls;

namespace sTASKedit
{
    partial class SelectNPCIdWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectNPCIdWindow));
            this.dataGridView_NPCs = new JHUI.Controls.JDataGridView();
            this.Column_NPCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NPCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_SearchNPCId = new JHUI.Controls.JTextBox();
            this.textBox_SearchNPCName = new JHUI.Controls.JTextBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.dataGridView_Props = new JHUI.Controls.JDataGridView();
            this.Column_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NPCs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_NPCs
            // 
            this.dataGridView_NPCs.AllowUserToAddRows = false;
            this.dataGridView_NPCs.AllowUserToDeleteRows = false;
            this.dataGridView_NPCs.AllowUserToResizeColumns = false;
            this.dataGridView_NPCs.AllowUserToResizeRows = false;
            this.dataGridView_NPCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_NPCs.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_NPCs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_NPCs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_NPCs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_NPCs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_NPCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NPCs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_NPCId,
            this.Column_NPCName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_NPCs.DefaultCellStyle = dataGridViewCellStyle8;
            //  this.dataGridView_NPCs.DoubleBuffered = true;
            this.dataGridView_NPCs.EnableHeadersVisualStyles = false;
            this.dataGridView_NPCs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_NPCs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_NPCs.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_NPCs.Name = "dataGridView_NPCs";
            this.dataGridView_NPCs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_NPCs.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_NPCs.RowHeadersVisible = false;
            this.dataGridView_NPCs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_NPCs.RowTemplate.Height = 18;
            this.dataGridView_NPCs.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_NPCs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_NPCs.Size = new System.Drawing.Size(312, 287);
            this.dataGridView_NPCs.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_NPCs.TabIndex = 0;
            this.dataGridView_NPCs.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_NPCs.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_NPCs_CellMouseEnter);
            this.dataGridView_NPCs.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_NPCs_Scroll);
            this.dataGridView_NPCs.SelectionChanged += new System.EventHandler(this.dataGridView_NPCs_SelectionChanged);
            this.dataGridView_NPCs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_NPCs_MouseMove);
            // 
            // Column_NPCId
            // 
            this.Column_NPCId.HeaderText = "NPC Id";
            this.Column_NPCId.Name = "Column_NPCId";
            this.Column_NPCId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_NPCId.Width = 70;
            // 
            // Column_NPCName
            // 
            this.Column_NPCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_NPCName.HeaderText = "Name";
            this.Column_NPCName.Name = "Column_NPCName";
            this.Column_NPCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBox_SearchNPCId
            // 
            this.textBox_SearchNPCId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchNPCId.CustomButton.Image = null;
            this.textBox_SearchNPCId.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchNPCId.CustomButton.Name = "";
            this.textBox_SearchNPCId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchNPCId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchNPCId.CustomButton.TabIndex = 1;
            this.textBox_SearchNPCId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchNPCId.CustomButton.UseSelectable = true;
            this.textBox_SearchNPCId.CustomButton.Visible = false;
            this.textBox_SearchNPCId.Lines = new string[0];
            this.textBox_SearchNPCId.Location = new System.Drawing.Point(124, 358);
            this.textBox_SearchNPCId.MaxLength = 32767;
            this.textBox_SearchNPCId.Name = "textBox_SearchNPCId";
            this.textBox_SearchNPCId.PasswordChar = '\0';
            this.textBox_SearchNPCId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchNPCId.SelectedText = "";
            this.textBox_SearchNPCId.SelectionLength = 0;
            this.textBox_SearchNPCId.SelectionStart = 0;
            this.textBox_SearchNPCId.ShortcutsEnabled = true;
            this.textBox_SearchNPCId.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchNPCId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchNPCId.TabIndex = 1;
            this.textBox_SearchNPCId.TextWaterMark = "";
            this.textBox_SearchNPCId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchNPCId.UseSelectable = true;
            this.textBox_SearchNPCId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchNPCId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchNPCId.TextChanged += new System.EventHandler(this.textBox_SearchNPCId_TextChanged);
            this.textBox_SearchNPCId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchNPCId_KeyPress);
            // 
            // textBox_SearchNPCName
            // 
            this.textBox_SearchNPCName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchNPCName.CustomButton.Image = null;
            this.textBox_SearchNPCName.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchNPCName.CustomButton.Name = "";
            this.textBox_SearchNPCName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchNPCName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchNPCName.CustomButton.TabIndex = 1;
            this.textBox_SearchNPCName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchNPCName.CustomButton.UseSelectable = true;
            this.textBox_SearchNPCName.CustomButton.Visible = false;
            this.textBox_SearchNPCName.Lines = new string[0];
            this.textBox_SearchNPCName.Location = new System.Drawing.Point(124, 387);
            this.textBox_SearchNPCName.MaxLength = 32767;
            this.textBox_SearchNPCName.Name = "textBox_SearchNPCName";
            this.textBox_SearchNPCName.PasswordChar = '\0';
            this.textBox_SearchNPCName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchNPCName.SelectedText = "";
            this.textBox_SearchNPCName.SelectionLength = 0;
            this.textBox_SearchNPCName.SelectionStart = 0;
            this.textBox_SearchNPCName.ShortcutsEnabled = true;
            this.textBox_SearchNPCName.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchNPCName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchNPCName.TabIndex = 2;
            this.textBox_SearchNPCName.TextWaterMark = "";
            this.textBox_SearchNPCName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchNPCName.UseSelectable = true;
            this.textBox_SearchNPCName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchNPCName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchNPCName.TextChanged += new System.EventHandler(this.textBox_SearchNPCName_TextChanged);
            this.textBox_SearchNPCName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchNPCName_KeyPress);
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 415);
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
            this.button_Cancel.Location = new System.Drawing.Point(175, 415);
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
            this.label1.Location = new System.Drawing.Point(8, 362);
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
            this.label2.Location = new System.Drawing.Point(8, 391);
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
            this.dataGridView_Props.Size = new System.Drawing.Size(323, 374);
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
            // SelectNPCIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(668, 485);
            this.Controls.Add(this.dataGridView_Props);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_SearchNPCName);
            this.Controls.Add(this.textBox_SearchNPCId);
            this.Controls.Add(this.dataGridView_NPCs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(668, 418);
            this.Name = "SelectNPCIdWindow";
            this.ShowIcon = false;
            this.Text = "SelectNPCIdWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectNPCIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectNPCIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectNPCIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NPCs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JDataGridView dataGridView_NPCs;
        private JTextBox textBox_SearchNPCId;
        private JTextBox textBox_SearchNPCName;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JLabel label1;
        private JLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NPCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NPCName;
        private JDataGridView dataGridView_Props;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
	}
}