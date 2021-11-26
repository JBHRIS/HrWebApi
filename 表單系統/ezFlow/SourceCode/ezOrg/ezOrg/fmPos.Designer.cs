namespace ezOrg {
	partial class fmPos {
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
		///
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.posLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.posLevelTableAdapter = new ezOrg.ezOrgDSTableAdapters.PosLevelTableAdapter();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.posLevelidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.posBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.posTableAdapter = new ezOrg.ezOrgDSTableAdapters.PosTableAdapter();
			this.bnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.posLevelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.posBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// posLevelBindingSource
			// 
			this.posLevelBindingSource.DataMember = "PosLevel";
			this.posLevelBindingSource.DataSource = this.ezOrgDS;
			// 
			// posLevelTableAdapter
			// 
			this.posLevelTableAdapter.ClearBeforeFill = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.posLevelidDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.posBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(521, 260);
			this.dataGridView1.TabIndex = 6;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumn.HeaderText = "職務代碼";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "職務名稱";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.Width = 180;
			// 
			// posLevelidDataGridViewTextBoxColumn
			// 
			this.posLevelidDataGridViewTextBoxColumn.DataPropertyName = "PosLevel_id";
			this.posLevelidDataGridViewTextBoxColumn.DataSource = this.posLevelBindingSource;
			this.posLevelidDataGridViewTextBoxColumn.DisplayMember = "name";
			this.posLevelidDataGridViewTextBoxColumn.HeaderText = "職務等級";
			this.posLevelidDataGridViewTextBoxColumn.Name = "posLevelidDataGridViewTextBoxColumn";
			this.posLevelidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.posLevelidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.posLevelidDataGridViewTextBoxColumn.ValueMember = "id";
			this.posLevelidDataGridViewTextBoxColumn.Width = 180;
			// 
			// posBindingSource
			// 
			this.posBindingSource.DataMember = "Pos";
			this.posBindingSource.DataSource = this.ezOrgDS;
			// 
			// posTableAdapter
			// 
			this.posTableAdapter.ClearBeforeFill = true;
			// 
			// bnSave
			// 
			this.bnSave.Location = new System.Drawing.Point(458, 278);
			this.bnSave.Name = "bnSave";
			this.bnSave.Size = new System.Drawing.Size(75, 23);
			this.bnSave.TabIndex = 7;
			this.bnSave.Text = "儲存變更";
			this.bnSave.UseVisualStyleBackColor = true;
			this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
			// 
			// fmPos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 306);
			this.Controls.Add(this.bnSave);
			this.Controls.Add(this.dataGridView1);
			this.MaximizeBox = false;
			this.Name = "fmPos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "職務編輯";
			this.Load += new System.EventHandler(this.fmPos_Load);
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.posLevelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.posBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource posLevelBindingSource;
		private ezOrg.ezOrgDSTableAdapters.PosLevelTableAdapter posLevelTableAdapter;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource posBindingSource;
		private ezOrg.ezOrgDSTableAdapters.PosTableAdapter posTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn posLevelidDataGridViewTextBoxColumn;
		private System.Windows.Forms.Button bnSave;
	}
}