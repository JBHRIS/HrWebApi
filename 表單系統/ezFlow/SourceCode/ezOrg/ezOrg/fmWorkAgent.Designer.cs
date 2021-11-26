namespace ezOrg {
	partial class fmWorkAgent {
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
			this.bnAdd = new System.Windows.Forms.Button();
			this.grdAgent = new System.Windows.Forms.DataGridView();
			this.posnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.workAgentBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.grdPower = new System.Windows.Forms.DataGridView();
			this.flowTreeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.flowTreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.workAgentPowerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.workAgentTableAdapter = new ezOrg.ezOrgDSTableAdapters.WorkAgentTableAdapter();
			this.workAgentPowerTableAdapter = new ezOrg.ezOrgDSTableAdapters.WorkAgentPowerTableAdapter();
			this.flowTreeTableAdapter = new ezOrg.ezOrgDSTableAdapters.FlowTreeTableAdapter();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbSource = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdAgent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.workAgentBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.workAgentPowerBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// bnAdd
			// 
			this.bnAdd.Location = new System.Drawing.Point(12, 33);
			this.bnAdd.Name = "bnAdd";
			this.bnAdd.Size = new System.Drawing.Size(260, 23);
			this.bnAdd.TabIndex = 1;
			this.bnAdd.Text = "新增代理人";
			this.bnAdd.UseVisualStyleBackColor = true;
			this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
			// 
			// grdAgent
			// 
			this.grdAgent.AllowUserToDeleteRows = false;
			this.grdAgent.AutoGenerateColumns = false;
			this.grdAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.posnameDataGridViewTextBoxColumn,
            this.empnameDataGridViewTextBoxColumn});
			this.grdAgent.DataSource = this.workAgentBindingSource;
			this.grdAgent.Location = new System.Drawing.Point(12, 62);
			this.grdAgent.MultiSelect = false;
			this.grdAgent.Name = "grdAgent";
			this.grdAgent.ReadOnly = true;
			this.grdAgent.RowTemplate.Height = 24;
			this.grdAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdAgent.Size = new System.Drawing.Size(260, 320);
			this.grdAgent.TabIndex = 2;
			this.grdAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdAgent_KeyDown);
			this.grdAgent.SelectionChanged += new System.EventHandler(this.grdAgent_SelectionChanged);
			// 
			// posnameDataGridViewTextBoxColumn
			// 
			this.posnameDataGridViewTextBoxColumn.DataPropertyName = "Pos_name";
			this.posnameDataGridViewTextBoxColumn.HeaderText = "職稱";
			this.posnameDataGridViewTextBoxColumn.Name = "posnameDataGridViewTextBoxColumn";
			this.posnameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// empnameDataGridViewTextBoxColumn
			// 
			this.empnameDataGridViewTextBoxColumn.DataPropertyName = "Emp_name";
			this.empnameDataGridViewTextBoxColumn.HeaderText = "姓名";
			this.empnameDataGridViewTextBoxColumn.Name = "empnameDataGridViewTextBoxColumn";
			this.empnameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// workAgentBindingSource
			// 
			this.workAgentBindingSource.DataMember = "WorkAgent";
			this.workAgentBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// grdPower
			// 
			this.grdPower.AllowUserToDeleteRows = false;
			this.grdPower.AutoGenerateColumns = false;
			this.grdPower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPower.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flowTreeidDataGridViewTextBoxColumn});
			this.grdPower.DataSource = this.workAgentPowerBindingSource;
			this.grdPower.Location = new System.Drawing.Point(278, 62);
			this.grdPower.MultiSelect = false;
			this.grdPower.Name = "grdPower";
			this.grdPower.RowTemplate.Height = 24;
			this.grdPower.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdPower.Size = new System.Drawing.Size(260, 320);
			this.grdPower.TabIndex = 3;
			this.grdPower.VirtualMode = true;
			this.grdPower.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPower_KeyDown);
			this.grdPower.SelectionChanged += new System.EventHandler(this.grdPower_SelectionChanged);
			// 
			// flowTreeidDataGridViewTextBoxColumn
			// 
			this.flowTreeidDataGridViewTextBoxColumn.DataPropertyName = "FlowTree_id";
			this.flowTreeidDataGridViewTextBoxColumn.DataSource = this.flowTreeBindingSource;
			this.flowTreeidDataGridViewTextBoxColumn.DisplayMember = "name";
			this.flowTreeidDataGridViewTextBoxColumn.HeaderText = "允許代理的流程名稱";
			this.flowTreeidDataGridViewTextBoxColumn.Name = "flowTreeidDataGridViewTextBoxColumn";
			this.flowTreeidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.flowTreeidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.flowTreeidDataGridViewTextBoxColumn.ValueMember = "id";
			this.flowTreeidDataGridViewTextBoxColumn.Width = 200;
			// 
			// flowTreeBindingSource
			// 
			this.flowTreeBindingSource.DataMember = "FlowTree";
			this.flowTreeBindingSource.DataSource = this.ezOrgDS;
			// 
			// workAgentPowerBindingSource
			// 
			this.workAgentPowerBindingSource.DataMember = "WorkAgentPower";
			this.workAgentPowerBindingSource.DataSource = this.ezOrgDS;
			// 
			// workAgentTableAdapter
			// 
			this.workAgentTableAdapter.ClearBeforeFill = true;
			// 
			// workAgentPowerTableAdapter
			// 
			this.workAgentPowerTableAdapter.ClearBeforeFill = true;
			// 
			// flowTreeTableAdapter
			// 
			this.flowTreeTableAdapter.ClearBeforeFill = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(278, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(233, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "若下面流程未設定，表示全流程皆可代理。";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "代理需求者：";
			// 
			// lbSource
			// 
			this.lbSource.AutoSize = true;
			this.lbSource.Location = new System.Drawing.Point(87, 9);
			this.lbSource.Name = "lbSource";
			this.lbSource.Size = new System.Drawing.Size(0, 12);
			this.lbSource.TabIndex = 6;
			// 
			// fmWorkAgent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 394);
			this.Controls.Add(this.lbSource);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grdPower);
			this.Controls.Add(this.grdAgent);
			this.Controls.Add(this.bnAdd);
			this.MaximizeBox = false;
			this.Name = "fmWorkAgent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "工作代理人";
			this.Load += new System.EventHandler(this.fmWorkAgent_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdAgent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.workAgentBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.workAgentPowerBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bnAdd;
		private System.Windows.Forms.DataGridView grdAgent;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource workAgentBindingSource;
		private ezOrg.ezOrgDSTableAdapters.WorkAgentTableAdapter workAgentTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn posnameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridView grdPower;
		private System.Windows.Forms.BindingSource workAgentPowerBindingSource;
		private ezOrg.ezOrgDSTableAdapters.WorkAgentPowerTableAdapter workAgentPowerTableAdapter;
		private System.Windows.Forms.BindingSource flowTreeBindingSource;
		private ezOrg.ezOrgDSTableAdapters.FlowTreeTableAdapter flowTreeTableAdapter;
		private System.Windows.Forms.DataGridViewComboBoxColumn flowTreeidDataGridViewTextBoxColumn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbSource;

	}
}