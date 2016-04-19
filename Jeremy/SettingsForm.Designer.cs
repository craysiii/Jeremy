namespace Jeremy
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.settingsGridView = new System.Windows.Forms.DataGridView();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SettingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueInactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.settingsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsGridView
            // 
            this.settingsGridView.AllowUserToAddRows = false;
            this.settingsGridView.AllowUserToDeleteRows = false;
            this.settingsGridView.AllowUserToResizeColumns = false;
            this.settingsGridView.AllowUserToResizeRows = false;
            this.settingsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.settingsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.settingsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settingsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Active,
            this.SettingType,
            this.ValueActive,
            this.ValueInactive});
            this.settingsGridView.Location = new System.Drawing.Point(12, 12);
            this.settingsGridView.Name = "settingsGridView";
            this.settingsGridView.RowHeadersVisible = false;
            this.settingsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.settingsGridView.Size = new System.Drawing.Size(366, 183);
            this.settingsGridView.TabIndex = 0;
            // 
            // Active
            // 
            this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Active.HeaderText = "On";
            this.Active.Name = "Active";
            this.Active.Width = 27;
            // 
            // SettingType
            // 
            this.SettingType.HeaderText = "Setting Type";
            this.SettingType.Name = "SettingType";
            this.SettingType.ReadOnly = true;
            this.SettingType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SettingType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueActive
            // 
            this.ValueActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ValueActive.HeaderText = "Active Timeout";
            this.ValueActive.Name = "ValueActive";
            this.ValueActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValueActive.Width = 84;
            // 
            // ValueInactive
            // 
            this.ValueInactive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ValueInactive.HeaderText = "Inactive Timeout";
            this.ValueInactive.Name = "ValueInactive";
            this.ValueInactive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValueInactive.Width = 92;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 207);
            this.Controls.Add(this.settingsGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Jeremy Timeout Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.settingsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView settingsGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueInactive;
    }
}