using JHUI.Controls;

namespace sTASKedit
{
	partial class SelectSkillIdWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSkillIdWindow));
            this.dataGridView_Skills = new JHUI.Controls.JDataGridView();
            this.Column_SkillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SkillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox_SkillDesc = new System.Windows.Forms.RichTextBox();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            this.textBox_SearchSkillId = new JHUI.Controls.JTextBox();
            this.textBox_SearchSkillName = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Skills)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Skills
            // 
            this.dataGridView_Skills.AllowUserToAddRows = false;
            this.dataGridView_Skills.AllowUserToDeleteRows = false;
            this.dataGridView_Skills.AllowUserToResizeColumns = false;
            this.dataGridView_Skills.AllowUserToResizeRows = false;
            this.dataGridView_Skills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Skills.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Skills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Skills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Skills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Skills.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Skills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Skills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_SkillId,
            this.Column_SkillName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Skills.DefaultCellStyle = dataGridViewCellStyle2;
            // this.dataGridView_Skills.DoubleBuffered = true;
            this.dataGridView_Skills.EnableHeadersVisualStyles = false;
            this.dataGridView_Skills.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_Skills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_Skills.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_Skills.Name = "dataGridView_Skills";
            this.dataGridView_Skills.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Skills.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Skills.RowHeadersVisible = false;
            this.dataGridView_Skills.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Skills.RowTemplate.Height = 18;
            this.dataGridView_Skills.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Skills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Skills.Size = new System.Drawing.Size(392, 378);
            this.dataGridView_Skills.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_Skills.TabIndex = 0;
            this.dataGridView_Skills.Theme = JHUI.JThemeStyle.Dark;
            this.dataGridView_Skills.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Skills_CellMouseEnter);
            this.dataGridView_Skills.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Skills_Scroll);
            this.dataGridView_Skills.SelectionChanged += new System.EventHandler(this.dataGridView_Skills_SelectionChanged);
            this.dataGridView_Skills.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Skills_MouseMove);
            // 
            // Column_SkillId
            // 
            this.Column_SkillId.HeaderText = "Skill Id";
            this.Column_SkillId.Name = "Column_SkillId";
            this.Column_SkillId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_SkillId.Width = 70;
            // 
            // Column_SkillName
            // 
            this.Column_SkillName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_SkillName.HeaderText = "Name";
            this.Column_SkillName.Name = "Column_SkillName";
            this.Column_SkillName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // richTextBox_SkillDesc
            // 
            this.richTextBox_SkillDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_SkillDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.richTextBox_SkillDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_SkillDesc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_SkillDesc.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.richTextBox_SkillDesc.Location = new System.Drawing.Point(410, 63);
            this.richTextBox_SkillDesc.Name = "richTextBox_SkillDesc";
            this.richTextBox_SkillDesc.Size = new System.Drawing.Size(402, 466);
            this.richTextBox_SkillDesc.TabIndex = 1;
            this.richTextBox_SkillDesc.Text = "";
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Ok.Location = new System.Drawing.Point(11, 506);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(190, 23);
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
            this.button_Cancel.Location = new System.Drawing.Point(215, 506);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(190, 23);
            this.button_Cancel.Style = JHUI.JColorStyle.Gold;
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.Theme = JHUI.JThemeStyle.Dark;
            this.button_Cancel.UseSelectable = true;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // textBox_SearchSkillId
            // 
            this.textBox_SearchSkillId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchSkillId.CustomButton.Image = null;
            this.textBox_SearchSkillId.CustomButton.Location = new System.Drawing.Point(262, 2);
            this.textBox_SearchSkillId.CustomButton.Name = "";
            this.textBox_SearchSkillId.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchSkillId.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchSkillId.CustomButton.TabIndex = 1;
            this.textBox_SearchSkillId.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchSkillId.CustomButton.UseSelectable = true;
            this.textBox_SearchSkillId.CustomButton.Visible = false;
            this.textBox_SearchSkillId.Lines = new string[0];
            this.textBox_SearchSkillId.Location = new System.Drawing.Point(124, 449);
            this.textBox_SearchSkillId.MaxLength = 32767;
            this.textBox_SearchSkillId.Name = "textBox_SearchSkillId";
            this.textBox_SearchSkillId.PasswordChar = '\0';
            this.textBox_SearchSkillId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchSkillId.SelectedText = "";
            this.textBox_SearchSkillId.SelectionLength = 0;
            this.textBox_SearchSkillId.SelectionStart = 0;
            this.textBox_SearchSkillId.ShortcutsEnabled = true;
            this.textBox_SearchSkillId.Size = new System.Drawing.Size(280, 20);
            this.textBox_SearchSkillId.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchSkillId.TabIndex = 4;
            this.textBox_SearchSkillId.TextWaterMark = "";
            this.textBox_SearchSkillId.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchSkillId.UseSelectable = true;
            this.textBox_SearchSkillId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchSkillId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchSkillId.TextChanged += new System.EventHandler(this.textBox_SearchSkillId_TextChanged);
            this.textBox_SearchSkillId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchSkillId_KeyPress);
            // 
            // textBox_SearchSkillName
            // 
            this.textBox_SearchSkillName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox_SearchSkillName.CustomButton.Image = null;
            this.textBox_SearchSkillName.CustomButton.Location = new System.Drawing.Point(262, 2);
            this.textBox_SearchSkillName.CustomButton.Name = "";
            this.textBox_SearchSkillName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox_SearchSkillName.CustomButton.Style = JHUI.JColorStyle.Blue;
            this.textBox_SearchSkillName.CustomButton.TabIndex = 1;
            this.textBox_SearchSkillName.CustomButton.Theme = JHUI.JThemeStyle.Light;
            this.textBox_SearchSkillName.CustomButton.UseSelectable = true;
            this.textBox_SearchSkillName.CustomButton.Visible = false;
            this.textBox_SearchSkillName.Lines = new string[0];
            this.textBox_SearchSkillName.Location = new System.Drawing.Point(124, 478);
            this.textBox_SearchSkillName.MaxLength = 32767;
            this.textBox_SearchSkillName.Name = "textBox_SearchSkillName";
            this.textBox_SearchSkillName.PasswordChar = '\0';
            this.textBox_SearchSkillName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_SearchSkillName.SelectedText = "";
            this.textBox_SearchSkillName.SelectionLength = 0;
            this.textBox_SearchSkillName.SelectionStart = 0;
            this.textBox_SearchSkillName.ShortcutsEnabled = true;
            this.textBox_SearchSkillName.Size = new System.Drawing.Size(280, 20);
            this.textBox_SearchSkillName.Style = JHUI.JColorStyle.Gold;
            this.textBox_SearchSkillName.TabIndex = 5;
            this.textBox_SearchSkillName.TextWaterMark = "";
            this.textBox_SearchSkillName.Theme = JHUI.JThemeStyle.Dark;
            this.textBox_SearchSkillName.UseSelectable = true;
            this.textBox_SearchSkillName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_SearchSkillName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_SearchSkillName.TextChanged += new System.EventHandler(this.textBox_SearchSkillName_TextChanged);
            this.textBox_SearchSkillName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SearchSkillName_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(8, 453);
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
            this.label2.Location = new System.Drawing.Point(8, 482);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.Style = JHUI.JColorStyle.Gold;
            this.label2.TabIndex = 7;
            this.label2.Text = "Search By Name:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // SelectSkillIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(826, 576);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_SearchSkillName);
            this.Controls.Add(this.textBox_SearchSkillId);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.richTextBox_SkillDesc);
            this.Controls.Add(this.dataGridView_Skills);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(826, 526);
            this.Name = "SelectSkillIdWindow";
            this.Text = "Select Skill Id";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectSkillIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectSkillIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectSkillIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Skills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private JDataGridView dataGridView_Skills;
        private System.Windows.Forms.RichTextBox richTextBox_SkillDesc;
        private JButton button_Ok;
        private JButton button_Cancel;
        private JTextBox textBox_SearchSkillId;
        private JTextBox textBox_SearchSkillName;
        private JLabel label1;
        private JLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SkillId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SkillName;
	}
}