namespace ezOrg {
	partial class fmDeptLevel {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grdDeptLevel = new System.Windows.Forms.DataGridView();
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.deptLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.deptLevelTableAdapter = new ezOrg.ezOrgDSTableAdapters.DeptLevelTableAdapter();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sortingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdDeptLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deptLevelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// grdDeptLevel
			// 
			this.grdDeptLevel.AllowUserToDeleteRows = false;
			this.grdDeptLevel.AllowUserToResizeColumns = false;
			this.grdDeptLevel.AllowUserToResizeRows = false;
			this.grdDeptLevel.AutoGenerateColumns = false;
			this.grdDeptLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDeptLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sortingDataGridViewTextBoxColumn});
			this.grdDeptLevel.DataSource = this.deptLevelBindingSource;
			this.grdDeptLevel.Location = new System.Drawing.Point(12, 12);
			this.grdDeptLevel.MultiSelect = false;
			this.grdDeptLevel.Name = "grdDeptLevel";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdDeptLevel.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.grdDeptLevel.RowTemplate.Height = 24;
			this.grdDeptLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdDeptLevel.Size = new System.Drawing.Size(368, 249);
			this.grdDeptLevel.TabIndex = 0;
			this.grdDeptLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDeptLevel_KeyDown);
			this.grdDeptLevel.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDeptLevel_CellEndEdit);
			this.grdDeptLevel.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdDeptLevel_DataError);
			this.grdDeptLevel.SelectionChanged += new System.EventHandler(this.grdDeptLevel_SelectionChanged);
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// deptLevelBindingSource
			// 
			this.deptLevelBindingSource.DataMember = "DeptLevel";
			this.deptLevelBindingSource.DataSource = this.ezOrgDS;
			// 
			// deptLevelTableAdapter
			// 
			this.deptLevelTableAdapter.ClearBeforeFill = true;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.idDataGridViewTextBoxColumn.HeaderText = "代碼";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.Width = 60;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "名稱";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.Width = 190;
			// 
			// sortingDataGridViewTextBoxColumn
			// 
			this.sortingDataGridViewTextBoxColumn.DataPropertyName = "sorting";
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.sortingDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.sortingDataGridViewTextBoxColumn.HeaderText = "排序";
			this.sortingDataGridViewTextBoxColumn.Name = "sortingDataGridViewTextBoxColumn";
			this.sortingDataGridViewTextBoxColumn.Width = 60;
			// 
			// fmDeptLevel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 273);
			this.Controls.Add(this.grdDeptLevel);
			this.MaximizeBox = false;
			this.Name = "fmDeptLevel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "部門層級鍊";
			this.Load += new System.EventHandler(this.fmDeptLevel_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdDeptLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deptLevelBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdDeptLevel;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource deptLevelBindingSource;
		private ezOrg.ezOrgDSTableAdapters.DeptLevelTableAdapter deptLevelTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sortingDataGridViewTextBoxColumn;
	}
}