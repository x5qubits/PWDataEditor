namespace PWDataEditorPaied.PW_Admin_classes
{
    partial class SelectWorld
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.dataGridView_Instances = new System.Windows.Forms.DataGridView();
            this.Column_WorldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InstanceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Instances)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Cancel.BackColor = System.Drawing.Color.Silver;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.ForeColor = System.Drawing.Color.White;
            this.button_Cancel.Location = new System.Drawing.Point(382, 253);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(150, 23);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Ok.BackColor = System.Drawing.Color.DarkOrange;
            this.button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ok.ForeColor = System.Drawing.Color.White;
            this.button_Ok.Location = new System.Drawing.Point(18, 253);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(150, 23);
            this.button_Ok.TabIndex = 4;
            this.button_Ok.Text = "Okay";
            this.button_Ok.UseVisualStyleBackColor = false;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // dataGridView_Instances
            // 
            this.dataGridView_Instances.AllowUserToAddRows = false;
            this.dataGridView_Instances.AllowUserToDeleteRows = false;
            this.dataGridView_Instances.AllowUserToResizeColumns = false;
            this.dataGridView_Instances.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Instances.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Instances.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_Instances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Instances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_WorldId,
            this.Column_InstanceName});
            this.dataGridView_Instances.Location = new System.Drawing.Point(6, 9);
            this.dataGridView_Instances.Name = "dataGridView_Instances";
            this.dataGridView_Instances.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_Instances.RowHeadersVisible = false;
            this.dataGridView_Instances.RowTemplate.Height = 18;
            this.dataGridView_Instances.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Instances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Instances.Size = new System.Drawing.Size(526, 238);
            this.dataGridView_Instances.TabIndex = 3;
            // 
            // Column_WorldId
            // 
            this.Column_WorldId.HeaderText = "World Id";
            this.Column_WorldId.Name = "Column_WorldId";
            this.Column_WorldId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_WorldId.Width = 70;
            // 
            // Column_InstanceName
            // 
            this.Column_InstanceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_InstanceName.HeaderText = "Name";
            this.Column_InstanceName.Name = "Column_InstanceName";
            this.Column_InstanceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SelectWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 283);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.dataGridView_Instances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SelectWorld";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectWorld";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Instances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.DataGridView dataGridView_Instances;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_WorldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InstanceName;
    }
}