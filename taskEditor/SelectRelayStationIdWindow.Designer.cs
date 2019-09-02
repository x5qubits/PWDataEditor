using JHUI.Controls;

namespace sTASKedit
{
	partial class SelectRelayStationIdWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRelayStationIdWindow));
            this.dataGridView_RelayStations = new JHUI.Controls.JDataGridView();
            this.Column_RelayStationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RelayStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Ok = new JHUI.Controls.JButton();
            this.button_Cancel = new JHUI.Controls.JButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RelayStations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_RelayStations
            // 
            this.dataGridView_RelayStations.AllowUserToAddRows = false;
            this.dataGridView_RelayStations.AllowUserToDeleteRows = false;
            this.dataGridView_RelayStations.AllowUserToResizeColumns = false;
            this.dataGridView_RelayStations.AllowUserToResizeRows = false;
            this.dataGridView_RelayStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_RelayStations.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_RelayStations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_RelayStations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_RelayStations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_RelayStations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_RelayStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RelayStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_RelayStationId,
            this.Column_RelayStationName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_RelayStations.DefaultCellStyle = dataGridViewCellStyle2;
            // this.dataGridView_RelayStations.DoubleBuffered = true;
            this.dataGridView_RelayStations.EnableHeadersVisualStyles = false;
            this.dataGridView_RelayStations.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView_RelayStations.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridView_RelayStations.Location = new System.Drawing.Point(23, 63);
            this.dataGridView_RelayStations.Name = "dataGridView_RelayStations";
            this.dataGridView_RelayStations.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_RelayStations.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_RelayStations.RowHeadersVisible = false;
            this.dataGridView_RelayStations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_RelayStations.RowTemplate.Height = 18;
            this.dataGridView_RelayStations.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_RelayStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_RelayStations.Size = new System.Drawing.Size(385, 253);
            this.dataGridView_RelayStations.Style = JHUI.JColorStyle.Gold;
            this.dataGridView_RelayStations.TabIndex = 0;
            this.dataGridView_RelayStations.Theme = JHUI.JThemeStyle.Dark;
            // 
            // Column_RelayStationId
            // 
            this.Column_RelayStationId.HeaderText = "Relay Station Id";
            this.Column_RelayStationId.Name = "Column_RelayStationId";
            this.Column_RelayStationId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_RelayStationId.Width = 110;
            // 
            // Column_RelayStationName
            // 
            this.Column_RelayStationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_RelayStationName.HeaderText = "Name";
            this.Column_RelayStationName.Name = "Column_RelayStationName";
            this.Column_RelayStationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Ok.Location = new System.Drawing.Point(23, 322);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(150, 23);
            this.button_Ok.Style = JHUI.JColorStyle.Gold;
            this.button_Ok.TabIndex = 1;
            this.button_Ok.Text = "Ok";
            this.button_Ok.Theme = JHUI.JThemeStyle.Dark;
            this.button_Ok.UseSelectable = true;
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Cancel.Location = new System.Drawing.Point(258, 322);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(150, 23);
            this.button_Cancel.Style = JHUI.JColorStyle.Gold;
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.Theme = JHUI.JThemeStyle.Dark;
            this.button_Cancel.UseSelectable = true;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // SelectRelayStationIdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(431, 380);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.dataGridView_RelayStations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 288);
            this.Name = "SelectRelayStationIdWindow";
            this.ShowIcon = false;
            this.Text = "SelectRelayStationIdWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectRelayStationIdWindow_FormClosing);
            this.Load += new System.EventHandler(this.SelectRelayStationIdWindow_Load);
            this.SizeChanged += new System.EventHandler(this.SelectRelayStationIdWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RelayStations)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private JDataGridView dataGridView_RelayStations;
        private JButton button_Ok;
        private JButton button_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RelayStationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RelayStationName;
	}
}