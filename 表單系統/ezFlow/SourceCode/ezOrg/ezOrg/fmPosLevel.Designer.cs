namespace ezOrg {
	partial class fmPosLevel {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grdPosLevel = new System.Windows.Forms.DataGridView();
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.posLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.posLevelTableAdapter = new ezOrg.ezOrgDSTableAdapters.PosLevelTableAdapter();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sorting = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdPosLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.posLevelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// grdPosLevel
			// 
			this.grdPosLevel.AllowUserToDeleteRows = false;
			this.grdPosLevel.AllowUserToResizeColumns = false;
			this.grdPosLevel.AllowUserToResizeRows = false;
			this.grdPosLevel.AutoGenerateColumns = false;
			this.grdPosLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPosLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.name,
            this.sorting});
			this.grdPosLevel.DataSource = this.posLevelBindingSource;
			this.grdPosLevel.Location = new System.Drawing.Point(12, 12);
			this.grdPosLevel.MultiSelect = false;
			this.grdPosLevel.Name = "grdPosLevel";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdPosLevel.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdPosLevel.RowTemplate.Height = 24;
			this.grdPosLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdPosLevel.Size = new System.Drawing.Size(368, 249);
			this.grdPosLevel.TabIndex = 1;
			this.grdPosLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPosLevel_KeyDown);
			this.grdPosLevel.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPosLevel_CellEndEdit);
			this.grdPosLevel.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdPosLevel_DataError);
			this.grdPosLevel.SelectionChanged += new System.EventHandler(this.grdPosLevel_SelectionChanged);
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
			// Column1
			// 
			this.Column1.DataPropertyName = "id";
			this.Column1.HeaderText = "代碼";
			this.Column1.Name = "Column1";
			this.Column1.Width = 60;
			// 
			// name
			// 
			this.name.DataPropertyName = "name";
			this.name.HeaderText = "名稱";
			this.name.Name = "name";
			this.name.Width = 190;
			// 
			// sorting
			// 
			this.sorting.DataPropertyName = "sorting";
			this.sorting.HeaderText = "排序";
			this.sorting.Name = "sorting";
			this.sorting.Width = 60;
			// 
			// fmPosLevel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 273);
			this.Controls.Add(this.grdPosLevel);
			this.MaximizeBox = false;
			this.Name = "fmPosLevel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "職務層級鍊";
			this.Load += new System.EventHandler(this.fmPosLevel_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdPosLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.posLevelBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdPosLevel;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource posLevelBindingSource;
		private ezOrg.ezOrgDSTableAdapters.PosLevelTableAdapter posLevelTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewTextBoxColumn sorting;
	}
}