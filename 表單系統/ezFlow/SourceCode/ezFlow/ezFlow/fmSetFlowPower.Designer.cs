namespace ezFlow {
	partial class fmSetFlowPower {
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.bnAddOrg = new System.Windows.Forms.Button();
			this.grdOrg = new System.Windows.Forms.DataGridView();
			this.deptpathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isAllSubDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.posLevelsortingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.posLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezFlowDS = new ezFlow.ezFlowDS();
			this.flowTreePowerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ckAllSub = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbPosLevel = new System.Windows.Forms.ComboBox();
			this.bnSelectOrg = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOrgPath = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.bnAddRole = new System.Windows.Forms.Button();
			this.grdRole = new System.Windows.Forms.DataGridView();
			this.flowTreePowerRoleOnlyBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bnSelectRole = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRole = new System.Windows.Forms.TextBox();
			this.flowTreePowerTableAdapter = new ezFlow.ezFlowDSTableAdapters.FlowTreePowerTableAdapter();
			this.posLevelTableAdapter = new ezFlow.ezFlowDSTableAdapters.PosLevelTableAdapter();
			this.flowTreePowerRoleOnlyTableAdapter = new ezFlow.ezFlowDSTableAdapters.FlowTreePowerRoleOnlyTableAdapter();
			this.roleidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.posnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOrg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.posLevelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezFlowDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreePowerBindingSource)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreePowerRoleOnlyBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(592, 323);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.bnAddOrg);
			this.tabPage1.Controls.Add(this.grdOrg);
			this.tabPage1.Controls.Add(this.ckAllSub);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.cbPosLevel);
			this.tabPage1.Controls.Add(this.bnSelectOrg);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtOrgPath);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(584, 298);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "依部門決定開啟權";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// bnAddOrg
			// 
			this.bnAddOrg.Location = new System.Drawing.Point(90, 70);
			this.bnAddOrg.Name = "bnAddOrg";
			this.bnAddOrg.Size = new System.Drawing.Size(75, 23);
			this.bnAddOrg.TabIndex = 7;
			this.bnAddOrg.Text = "加入權限";
			this.bnAddOrg.UseVisualStyleBackColor = true;
			this.bnAddOrg.Click += new System.EventHandler(this.bnAddOrg_Click);
			// 
			// grdOrg
			// 
			this.grdOrg.AllowUserToAddRows = false;
			this.grdOrg.AllowUserToDeleteRows = false;
			this.grdOrg.AllowUserToResizeColumns = false;
			this.grdOrg.AllowUserToResizeRows = false;
			this.grdOrg.AutoGenerateColumns = false;
			this.grdOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdOrg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deptpathDataGridViewTextBoxColumn,
            this.isAllSubDataGridViewCheckBoxColumn,
            this.posLevelsortingDataGridViewTextBoxColumn});
			this.grdOrg.DataSource = this.flowTreePowerBindingSource;
			this.grdOrg.Location = new System.Drawing.Point(9, 99);
			this.grdOrg.MultiSelect = false;
			this.grdOrg.Name = "grdOrg";
			this.grdOrg.ReadOnly = true;
			this.grdOrg.RowTemplate.Height = 24;
			this.grdOrg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdOrg.Size = new System.Drawing.Size(567, 193);
			this.grdOrg.TabIndex = 6;
			this.grdOrg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdOrg_KeyDown);
			// 
			// deptpathDataGridViewTextBoxColumn
			// 
			this.deptpathDataGridViewTextBoxColumn.DataPropertyName = "Dept_path";
			this.deptpathDataGridViewTextBoxColumn.HeaderText = "部門樹";
			this.deptpathDataGridViewTextBoxColumn.Name = "deptpathDataGridViewTextBoxColumn";
			this.deptpathDataGridViewTextBoxColumn.ReadOnly = true;
			this.deptpathDataGridViewTextBoxColumn.Width = 300;
			// 
			// isAllSubDataGridViewCheckBoxColumn
			// 
			this.isAllSubDataGridViewCheckBoxColumn.DataPropertyName = "isAllSub";
			this.isAllSubDataGridViewCheckBoxColumn.HeaderText = "含子部門";
			this.isAllSubDataGridViewCheckBoxColumn.Name = "isAllSubDataGridViewCheckBoxColumn";
			this.isAllSubDataGridViewCheckBoxColumn.ReadOnly = true;
			this.isAllSubDataGridViewCheckBoxColumn.Width = 60;
			// 
			// posLevelsortingDataGridViewTextBoxColumn
			// 
			this.posLevelsortingDataGridViewTextBoxColumn.DataPropertyName = "PosLevel_sorting";
			this.posLevelsortingDataGridViewTextBoxColumn.DataSource = this.posLevelBindingSource;
			this.posLevelsortingDataGridViewTextBoxColumn.DisplayMember = "name";
			this.posLevelsortingDataGridViewTextBoxColumn.HeaderText = "最低職等";
			this.posLevelsortingDataGridViewTextBoxColumn.Name = "posLevelsortingDataGridViewTextBoxColumn";
			this.posLevelsortingDataGridViewTextBoxColumn.ReadOnly = true;
			this.posLevelsortingDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.posLevelsortingDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.posLevelsortingDataGridViewTextBoxColumn.ValueMember = "sorting";
			this.posLevelsortingDataGridViewTextBoxColumn.Width = 150;
			// 
			// posLevelBindingSource
			// 
			this.posLevelBindingSource.DataMember = "PosLevel";
			this.posLevelBindingSource.DataSource = this.ezFlowDS;
			// 
			// ezFlowDS
			// 
			this.ezFlowDS.DataSetName = "ezFlowDS";
			this.ezFlowDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// flowTreePowerBindingSource
			// 
			this.flowTreePowerBindingSource.DataMember = "FlowTreePower";
			this.flowTreePowerBindingSource.DataSource = this.ezFlowDS;
			// 
			// ckAllSub
			// 
			this.ckAllSub.AutoSize = true;
			this.ckAllSub.Checked = true;
			this.ckAllSub.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckAllSub.Location = new System.Drawing.Point(298, 47);
			this.ckAllSub.Name = "ckAllSub";
			this.ckAllSub.Size = new System.Drawing.Size(84, 16);
			this.ckAllSub.TabIndex = 5;
			this.ckAllSub.Text = "包括子部門";
			this.ckAllSub.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "最低職等限制";
			// 
			// cbPosLevel
			// 
			this.cbPosLevel.DataSource = this.posLevelBindingSource;
			this.cbPosLevel.DisplayMember = "name";
			this.cbPosLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPosLevel.FormattingEnabled = true;
			this.cbPosLevel.Location = new System.Drawing.Point(90, 44);
			this.cbPosLevel.Name = "cbPosLevel";
			this.cbPosLevel.Size = new System.Drawing.Size(201, 20);
			this.cbPosLevel.TabIndex = 3;
			this.cbPosLevel.ValueMember = "sorting";
			// 
			// bnSelectOrg
			// 
			this.bnSelectOrg.Location = new System.Drawing.Point(501, 16);
			this.bnSelectOrg.Name = "bnSelectOrg";
			this.bnSelectOrg.Size = new System.Drawing.Size(75, 23);
			this.bnSelectOrg.TabIndex = 2;
			this.bnSelectOrg.Text = "選取部門";
			this.bnSelectOrg.UseVisualStyleBackColor = true;
			this.bnSelectOrg.Click += new System.EventHandler(this.bnSelectOrg_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "指定部門樹";
			// 
			// txtOrgPath
			// 
			this.txtOrgPath.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtOrgPath.Location = new System.Drawing.Point(90, 16);
			this.txtOrgPath.Name = "txtOrgPath";
			this.txtOrgPath.ReadOnly = true;
			this.txtOrgPath.Size = new System.Drawing.Size(405, 22);
			this.txtOrgPath.TabIndex = 0;
			this.txtOrgPath.Text = "/";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.bnAddRole);
			this.tabPage2.Controls.Add(this.grdRole);
			this.tabPage2.Controls.Add(this.bnSelectRole);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.txtRole);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(584, 298);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "唯指定角色可開啟";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// bnAddRole
			// 
			this.bnAddRole.Location = new System.Drawing.Point(83, 43);
			this.bnAddRole.Name = "bnAddRole";
			this.bnAddRole.Size = new System.Drawing.Size(75, 23);
			this.bnAddRole.TabIndex = 7;
			this.bnAddRole.Text = "加入權限";
			this.bnAddRole.UseVisualStyleBackColor = true;
			this.bnAddRole.Click += new System.EventHandler(this.bnAddRole_Click);
			// 
			// grdRole
			// 
			this.grdRole.AllowUserToAddRows = false;
			this.grdRole.AllowUserToDeleteRows = false;
			this.grdRole.AllowUserToResizeColumns = false;
			this.grdRole.AllowUserToResizeRows = false;
			this.grdRole.AutoGenerateColumns = false;
			this.grdRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roleidDataGridViewTextBoxColumn,
            this.posnameDataGridViewTextBoxColumn});
			this.grdRole.DataSource = this.flowTreePowerRoleOnlyBindingSource;
			this.grdRole.Location = new System.Drawing.Point(8, 72);
			this.grdRole.MultiSelect = false;
			this.grdRole.Name = "grdRole";
			this.grdRole.ReadOnly = true;
			this.grdRole.RowTemplate.Height = 24;
			this.grdRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdRole.Size = new System.Drawing.Size(568, 218);
			this.grdRole.TabIndex = 6;
			this.grdRole.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdRole_KeyDown);
			// 
			// flowTreePowerRoleOnlyBindingSource
			// 
			this.flowTreePowerRoleOnlyBindingSource.DataMember = "FlowTreePowerRoleOnly";
			this.flowTreePowerRoleOnlyBindingSource.DataSource = this.ezFlowDS;
			// 
			// bnSelectRole
			// 
			this.bnSelectRole.Location = new System.Drawing.Point(251, 15);
			this.bnSelectRole.Name = "bnSelectRole";
			this.bnSelectRole.Size = new System.Drawing.Size(75, 23);
			this.bnSelectRole.TabIndex = 5;
			this.bnSelectRole.Text = "選取角色";
			this.bnSelectRole.UseVisualStyleBackColor = true;
			this.bnSelectRole.Click += new System.EventHandler(this.bnSelectRole_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "指定的角色";
			// 
			// txtRole
			// 
			this.txtRole.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtRole.Location = new System.Drawing.Point(83, 15);
			this.txtRole.Name = "txtRole";
			this.txtRole.ReadOnly = true;
			this.txtRole.Size = new System.Drawing.Size(162, 22);
			this.txtRole.TabIndex = 3;
			// 
			// flowTreePowerTableAdapter
			// 
			this.flowTreePowerTableAdapter.ClearBeforeFill = true;
			// 
			// posLevelTableAdapter
			// 
			this.posLevelTableAdapter.ClearBeforeFill = true;
			// 
			// flowTreePowerRoleOnlyTableAdapter
			// 
			this.flowTreePowerRoleOnlyTableAdapter.ClearBeforeFill = true;
			// 
			// roleidDataGridViewTextBoxColumn
			// 
			this.roleidDataGridViewTextBoxColumn.DataPropertyName = "Role_id";
			this.roleidDataGridViewTextBoxColumn.HeaderText = "角色代碼";
			this.roleidDataGridViewTextBoxColumn.Name = "roleidDataGridViewTextBoxColumn";
			this.roleidDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// posnameDataGridViewTextBoxColumn
			// 
			this.posnameDataGridViewTextBoxColumn.DataPropertyName = "Pos_name";
			this.posnameDataGridViewTextBoxColumn.HeaderText = "角色名稱";
			this.posnameDataGridViewTextBoxColumn.Name = "posnameDataGridViewTextBoxColumn";
			this.posnameDataGridViewTextBoxColumn.ReadOnly = true;
			this.posnameDataGridViewTextBoxColumn.Width = 410;
			// 
			// fmSetFlowPower
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 323);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.Name = "fmSetFlowPower";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "流程權限";
			this.Load += new System.EventHandler(this.fmSetFlowPower_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOrg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.posLevelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezFlowDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreePowerBindingSource)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreePowerRoleOnlyBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbPosLevel;
		private System.Windows.Forms.Button bnSelectOrg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOrgPath;
		private System.Windows.Forms.Button bnAddOrg;
		private System.Windows.Forms.DataGridView grdOrg;
		private System.Windows.Forms.CheckBox ckAllSub;
		private System.Windows.Forms.DataGridView grdRole;
		private System.Windows.Forms.Button bnSelectRole;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRole;
		private System.Windows.Forms.BindingSource flowTreePowerBindingSource;
		private ezFlowDS ezFlowDS;
		private ezFlow.ezFlowDSTableAdapters.FlowTreePowerTableAdapter flowTreePowerTableAdapter;
		private System.Windows.Forms.BindingSource posLevelBindingSource;
		private ezFlow.ezFlowDSTableAdapters.PosLevelTableAdapter posLevelTableAdapter;
		private System.Windows.Forms.Button bnAddRole;
		private System.Windows.Forms.DataGridViewTextBoxColumn deptpathDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isAllSubDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn posLevelsortingDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource flowTreePowerRoleOnlyBindingSource;
		private ezFlow.ezFlowDSTableAdapters.FlowTreePowerRoleOnlyTableAdapter flowTreePowerRoleOnlyTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn roleidDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn posnameDataGridViewTextBoxColumn;
	}
}