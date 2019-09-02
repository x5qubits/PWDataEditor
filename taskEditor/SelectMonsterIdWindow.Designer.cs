using JHUI.Controls;

namespace sTASKedit
{
	partial class SelectMonsterIdWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMonsterIdWindow));
            this.dataGridView_Monsters = new JHUI.Controls.JDataGridView();
            this.Column_MonsterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MonsterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_SearchMonsterId = new JHUI.Controls.JTextBox();
            this.textBox_SearchMonsterName = new JHUI.Controls.JTextBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.dataGridView_Props = new JHUI.Controls.JDataGridView();
            this.Column_Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Monsters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Monsters
            // 
            this.dataGridView_Monsters.AllowUserToAddRows = false;
            this.dataGridView_Monsters.AllowUserToDeleteRows = false;
            this.dataGridView_Monsters.AllowUserToResizeColumns = false;
            this.dataGridView_Monsters.AllowUserToResizeRows = false;
            this.dataGridView_Monsters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Monsters.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Monsters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Monsters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Monsters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Monsters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Monsters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Monsters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_MonsterId,
            this.Column_MonsterName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Monsters.DefaultCellStyle = dataGridViewCellStyle2;
            //this.dataGridView_Monsters.DoubleBuffered = true;
            this.dataGridView_Monsters.EnableHeadersVisualStyles = false;
            this.dataGridView_Monsters.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Monsters.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Monsters.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_Monsters.Name = "dataGridView_Monsters";
            this.dataGridView_Monsters.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Monsters.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Monsters.RowHeadersVisible = false;
            this.dataGridView_Monsters.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Monsters.RowTemplate.Height = 18;
            this.dataGridView_Monsters.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Monsters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Monsters.Size = new System.Drawing.Size(312, 285);
            this.dataGridView_Monsters.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Monsters.TabIndex = 0;
            this.dataGridView_Monsters.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_Monsters.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Monsters_CellMouseEnter);
            this.dataGridView_Monsters.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Monsters_Scroll);
            this.dataGridView_Monsters.SelectionChanged += new System.EventHandler(this.dataGridView_Monsters_SelectionChanged);
            this.dataGridView_Monsters.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Monsters_MouseMove);
            // 
            // Column_MonsterId
            // 
            this.Column_MonsterId.HeaderText = "Monster Id";
            this.Column_MonsterId.Name = "Column_MonsterId";
            this.Column_MonsterId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_MonsterId.Width = 70;
            // 
            // Column_MonsterName
            // 
            this.Column_MonsterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_MonsterName.HeaderText = "Name";
            this.Column_MonsterName.Name = "Column_MonsterName";
            this.Column_MonsterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // textBox_SearchMonsterId
            // 
            this.textBox_SearchMonsterId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchMonsterId.CustomButton.Image = null;
            this.textBox_SearchMonsterId.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchMonsterId.CustomButton.Name = "";
            this.textBox_SearchMonsterId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchMonsterId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchMonsterId.CustomButton.TabIndex = 1;
            this.textBox_SearchMonsterId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchMonsterId.CustomButton.UseSelectable = true;
            this.textBox_SearchMonsterId.CustomButton.Visible = false;
            this.textBox_SearchMonsterId.Lines = new string[0];
            this.textBox_SearchMonsterId.Location = new System.Drawing.Point(124, 356);
            this.textBox_SearchMonsterId.MaxLength = 32767;
            this.textBox_SearchMonsterId.Name = "textBox_SearchMonsterId";
            this.textBox_SearchMonsterId.PasswordChar = '\0';
            this.textBox_SearchMonsterId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchMonsterId.SelectedText = "";
            this.textBox_SearchMonsterId.SelectionLength = 0;
            this.textBox_SearchMonsterId.SelectionStart = 0;
            this.textBox_SearchMonsterId.ShortcutsEnabled = true;
            this.textBox_SearchMonsterId.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchMonsterId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchMonsterId.TabIndex = 1;
            this.textBox_SearchMonsterId.TextWaterMark = "";
            this.textBox_SearchMonsterId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchMonsterId.UseSelectable = true;
            this.textBox_SearchMonsterId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchMonsterId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchMonsterId.TextChanged += new System.EventHandler(this.textBox_SearchMonsterId_TextChanged);
            this.textBox_SearchMonsterId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchMonsterId_KeyPress);
            // 
            // textBox_SearchMonsterName
            // 
            this.textBox_SearchMonsterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchMonsterName.CustomButton.Image = null;
            this.textBox_SearchMonsterName.CustomButton.Location = new System.Drawing.Point(182, 2);
            this.textBox_SearchMonsterName.CustomButton.Name = "";
            this.textBox_SearchMonsterName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchMonsterName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchMonsterName.CustomButton.TabIndex = 1;
            this.textBox_SearchMonsterName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchMonsterName.CustomButton.UseSelectable = true;
            this.textBox_SearchMonsterName.CustomButton.Visible = false;
            this.textBox_SearchMonsterName.Lines = new string[0];
            this.textBox_SearchMonsterName.Location = new System.Drawing.Point(124, 385);
            this.textBox_SearchMonsterName.MaxLength = 32767;
            this.textBox_SearchMonsterName.Name = "textBox_SearchMonsterName";
            this.textBox_SearchMonsterName.PasswordChar = '\0';
            this.textBox_SearchMonsterName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchMonsterName.SelectedText = "";
            this.textBox_SearchMonsterName.SelectionLength = 0;
            this.textBox_SearchMonsterName.SelectionStart = 0;
            this.textBox_SearchMonsterName.ShortcutsEnabled = true;
            this.textBox_SearchMonsterName.Size = new System.Drawing.Size(200, 20);
            this.textBox_SearchMonsterName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchMonsterName.TabIndex = 2;
            this.textBox_SearchMonsterName.TextWaterMark = "";
            this.textBox_SearchMonsterName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchMonsterName.UseSelectable = true;
            this.textBox_SearchMonsterName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchMonsterName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchMonsterName.TextChanged += new System.EventHandler(this.textBox_SearchMonsterName_TextChanged);
            this.textBox_SearchMonsterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchMonsterName_KeyPress);
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 413);
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
            this.button_Cancel.Location = new System.Drawing.Point(175, 413);
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
            this.label1.Location = new System.Drawing.Point(8, 360);
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
            this.label2.Location = new System.Drawing.Point(8, 389);
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
            // this.dataGridView_Props.DoubleBuffered = true;
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
            this.dataGridView_Props.Size = new System.Drawing.Size(312, 372);
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
            // SelectMonsterIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(668, 483);
            this.Controls.Add(this.dataGridView_Props);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.textBox_SearchMonsterName);
            this.Controls.Add(this.textBox_SearchMonsterId);
            this.Controls.Add(this.dataGridView_Monsters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(668, 418);
            this.Name = "SelectMonsterIdWindow";
            this.ShowIcon = false;
            this.Text = "SelectMonsterIdWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectMonsterIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectMonsterIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectMonsterIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Monsters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Props)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JDataGridView dataGridView_Monsters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MonsterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MonsterName;
        private JTextBox textBox_SearchMonsterId;
        private JTextBox textBox_SearchMonsterName;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JLabel label1;
        private JLabel label2;
        private JDataGridView dataGridView_Props;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
	}
}