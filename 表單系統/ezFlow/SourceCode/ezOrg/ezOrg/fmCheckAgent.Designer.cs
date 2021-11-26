namespace ezOrg {
	partial class fmCheckAgent {
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
			this.grdAgent = new System.Windows.Forms.DataGridView();
			this.posnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkAgentAlwaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.grdM = new System.Windows.Forms.DataGridView();
			this.deptidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.deptBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.isAllSubDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.checkAgentPowerMBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.grdD = new System.Windows.Forms.DataGridView();
			this.flowTreeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.flowTreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.checkAgentPowerDBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bnClear3 = new System.Windows.Forms.Button();
			this.bnClear2 = new System.Windows.Forms.Button();
			this.bnClear1 = new System.Windows.Forms.Button();
			this.bnAdd3 = new System.Windows.Forms.Button();
			this.bnAdd2 = new System.Windows.Forms.Button();
			this.bnAdd1 = new System.Windows.Forms.Button();
			this.txtName3 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtName2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtName1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPos3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPos2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPos1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lbSource = new System.Windows.Forms.Label();
			this.checkAgentAlwaysTableAdapter = new ezOrg.ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
			this.checkAgentPowerMTableAdapter = new ezOrg.ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
			this.deptTableAdapter = new ezOrg.ezOrgDSTableAdapters.DeptTableAdapter();
			this.checkAgentPowerDTableAdapter = new ezOrg.ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();
			this.flowTreeTableAdapter = new ezOrg.ezOrgDSTableAdapters.FlowTreeTableAdapter();
			this.bnAdd4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdAgent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAgentAlwaysBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deptBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAgentPowerMBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAgentPowerDBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdAgent
			// 
			this.grdAgent.AllowUserToDeleteRows = false;
			this.grdAgent.AutoGenerateColumns = false;
			this.grdAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.posnameDataGridViewTextBoxColumn,
            this.empnameDataGridViewTextBoxColumn});
			this.grdAgent.DataSource = this.checkAgentAlwaysBindingSource;
			this.grdAgent.Location = new System.Drawing.Point(12, 175);
			this.grdAgent.MultiSelect = false;
			this.grdAgent.Name = "grdAgent";
			this.grdAgent.ReadOnly = true;
			this.grdAgent.RowTemplate.Height = 24;
			this.grdAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdAgent.Size = new System.Drawing.Size(256, 286);
			this.grdAgent.TabIndex = 3;
			this.grdAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdAgent_KeyDown);
			this.grdAgent.SelectionChanged += new System.EventHandler(this.grdAgent_SelectionChanged);
			// 
			// posnameDataGridViewTextBoxColumn
			// 
			this.posnameDataGridViewTextBoxColumn.DataPropertyName = "Pos_name";
			this.posnameDataGridViewTextBoxColumn.HeaderText = "職稱";
			this.posnameDataGridViewTextBoxColumn.Name = "posnameDataGridViewTextBoxColumn";
			this.posnameDataGridViewTextBoxColumn.ReadOnly = true;
			this.posnameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.posnameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.posnameDataGridViewTextBoxColumn.Width = 99;
			// 
			// empnameDataGridViewTextBoxColumn
			// 
			this.empnameDataGridViewTextBoxColumn.DataPropertyName = "Emp_name";
			this.empnameDataGridViewTextBoxColumn.HeaderText = "姓名";
			this.empnameDataGridViewTextBoxColumn.Name = "empnameDataGridViewTextBoxColumn";
			this.empnameDataGridViewTextBoxColumn.ReadOnly = true;
			this.empnameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.empnameDataGridViewTextBoxColumn.Width = 99;
			// 
			// checkAgentAlwaysBindingSource
			// 
			this.checkAgentAlwaysBindingSource.DataMember = "CheckAgentAlways";
			this.checkAgentAlwaysBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// grdM
			// 
			this.grdM.AllowUserToDeleteRows = false;
			this.grdM.AutoGenerateColumns = false;
			this.grdM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deptidDataGridViewTextBoxColumn,
            this.isAllSubDataGridViewCheckBoxColumn});
			this.grdM.DataSource = this.checkAgentPowerMBindingSource;
			this.grdM.Location = new System.Drawing.Point(274, 175);
			this.grdM.MultiSelect = false;
			this.grdM.Name = "grdM";
			this.grdM.RowTemplate.Height = 24;
			this.grdM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdM.Size = new System.Drawing.Size(261, 286);
			this.grdM.TabIndex = 4;
			this.grdM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdM_KeyDown);
			this.grdM.SelectionChanged += new System.EventHandler(this.grdM_SelectionChanged);
			// 
			// deptidDataGridViewTextBoxColumn
			// 
			this.deptidDataGridViewTextBoxColumn.DataPropertyName = "Dept_id";
			this.deptidDataGridViewTextBoxColumn.DataSource = this.deptBindingSource;
			this.deptidDataGridViewTextBoxColumn.DisplayMember = "name";
			this.deptidDataGridViewTextBoxColumn.HeaderText = "部門名稱";
			this.deptidDataGridViewTextBoxColumn.Name = "deptidDataGridViewTextBoxColumn";
			this.deptidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.deptidDataGridViewTextBoxColumn.ValueMember = "id";
			this.deptidDataGridViewTextBoxColumn.Width = 153;
			// 
			// deptBindingSource
			// 
			this.deptBindingSource.DataMember = "Dept";
			this.deptBindingSource.DataSource = this.ezOrgDS;
			// 
			// isAllSubDataGridViewCheckBoxColumn
			// 
			this.isAllSubDataGridViewCheckBoxColumn.DataPropertyName = "isAllSub";
			this.isAllSubDataGridViewCheckBoxColumn.HeaderText = "子部門";
			this.isAllSubDataGridViewCheckBoxColumn.Name = "isAllSubDataGridViewCheckBoxColumn";
			this.isAllSubDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.isAllSubDataGridViewCheckBoxColumn.Width = 50;
			// 
			// checkAgentPowerMBindingSource
			// 
			this.checkAgentPowerMBindingSource.DataMember = "CheckAgentPowerM";
			this.checkAgentPowerMBindingSource.DataSource = this.ezOrgDS;
			// 
			// grdD
			// 
			this.grdD.AllowUserToDeleteRows = false;
			this.grdD.AutoGenerateColumns = false;
			this.grdD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flowTreeidDataGridViewTextBoxColumn});
			this.grdD.DataSource = this.checkAgentPowerDBindingSource;
			this.grdD.Location = new System.Drawing.Point(541, 175);
			this.grdD.MultiSelect = false;
			this.grdD.Name = "grdD";
			this.grdD.RowTemplate.Height = 24;
			this.grdD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdD.Size = new System.Drawing.Size(189, 286);
			this.grdD.TabIndex = 5;
			this.grdD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdD_KeyDown);
			this.grdD.SelectionChanged += new System.EventHandler(this.grdD_SelectionChanged);
			// 
			// flowTreeidDataGridViewTextBoxColumn
			// 
			this.flowTreeidDataGridViewTextBoxColumn.DataPropertyName = "FlowTree_id";
			this.flowTreeidDataGridViewTextBoxColumn.DataSource = this.flowTreeBindingSource;
			this.flowTreeidDataGridViewTextBoxColumn.DisplayMember = "name";
			this.flowTreeidDataGridViewTextBoxColumn.HeaderText = "流程名稱";
			this.flowTreeidDataGridViewTextBoxColumn.Name = "flowTreeidDataGridViewTextBoxColumn";
			this.flowTreeidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.flowTreeidDataGridViewTextBoxColumn.ValueMember = "id";
			this.flowTreeidDataGridViewTextBoxColumn.Width = 131;
			// 
			// flowTreeBindingSource
			// 
			this.flowTreeBindingSource.DataMember = "FlowTree";
			this.flowTreeBindingSource.DataSource = this.ezOrgDS;
			// 
			// checkAgentPowerDBindingSource
			// 
			this.checkAgentPowerDBindingSource.DataMember = "CheckAgentPowerD";
			this.checkAgentPowerDBindingSource.DataSource = this.ezOrgDS;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bnClear3);
			this.groupBox1.Controls.Add(this.bnClear2);
			this.groupBox1.Controls.Add(this.bnClear1);
			this.groupBox1.Controls.Add(this.bnAdd3);
			this.groupBox1.Controls.Add(this.bnAdd2);
			this.groupBox1.Controls.Add(this.bnAdd1);
			this.groupBox1.Controls.Add(this.txtName3);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtName2);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtName1);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtPos3);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtPos2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtPos1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(12, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(718, 115);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "預設簽核代理人";
			// 
			// bnClear3
			// 
			this.bnClear3.Location = new System.Drawing.Point(651, 21);
			this.bnClear3.Name = "bnClear3";
			this.bnClear3.Size = new System.Drawing.Size(51, 23);
			this.bnClear3.TabIndex = 17;
			this.bnClear3.Text = "清除";
			this.bnClear3.UseVisualStyleBackColor = true;
			this.bnClear3.Click += new System.EventHandler(this.bnClear3_Click);
			// 
			// bnClear2
			// 
			this.bnClear2.Location = new System.Drawing.Point(398, 21);
			this.bnClear2.Name = "bnClear2";
			this.bnClear2.Size = new System.Drawing.Size(51, 23);
			this.bnClear2.TabIndex = 16;
			this.bnClear2.Text = "清除";
			this.bnClear2.UseVisualStyleBackColor = true;
			this.bnClear2.Click += new System.EventHandler(this.bnClear2_Click);
			// 
			// bnClear1
			// 
			this.bnClear1.Location = new System.Drawing.Point(147, 21);
			this.bnClear1.Name = "bnClear1";
			this.bnClear1.Size = new System.Drawing.Size(51, 23);
			this.bnClear1.TabIndex = 15;
			this.bnClear1.Text = "清除";
			this.bnClear1.UseVisualStyleBackColor = true;
			this.bnClear1.Click += new System.EventHandler(this.bnClear1_Click);
			// 
			// bnAdd3
			// 
			this.bnAdd3.Location = new System.Drawing.Point(521, 21);
			this.bnAdd3.Name = "bnAdd3";
			this.bnAdd3.Size = new System.Drawing.Size(124, 23);
			this.bnAdd3.TabIndex = 14;
			this.bnAdd3.Text = "取得第三順位成員";
			this.bnAdd3.UseVisualStyleBackColor = true;
			this.bnAdd3.Click += new System.EventHandler(this.bnAdd3_Click);
			// 
			// bnAdd2
			// 
			this.bnAdd2.Location = new System.Drawing.Point(268, 21);
			this.bnAdd2.Name = "bnAdd2";
			this.bnAdd2.Size = new System.Drawing.Size(124, 23);
			this.bnAdd2.TabIndex = 13;
			this.bnAdd2.Text = "取得第二順位成員";
			this.bnAdd2.UseVisualStyleBackColor = true;
			this.bnAdd2.Click += new System.EventHandler(this.bnAdd2_Click);
			// 
			// bnAdd1
			// 
			this.bnAdd1.Location = new System.Drawing.Point(17, 21);
			this.bnAdd1.Name = "bnAdd1";
			this.bnAdd1.Size = new System.Drawing.Size(124, 23);
			this.bnAdd1.TabIndex = 12;
			this.bnAdd1.Text = "取得第一順位成員";
			this.bnAdd1.UseVisualStyleBackColor = true;
			this.bnAdd1.Click += new System.EventHandler(this.bnAdd1_Click);
			// 
			// txtName3
			// 
			this.txtName3.Location = new System.Drawing.Point(602, 82);
			this.txtName3.Name = "txtName3";
			this.txtName3.ReadOnly = true;
			this.txtName3.Size = new System.Drawing.Size(100, 22);
			this.txtName3.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(519, 92);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 12);
			this.label7.TabIndex = 10;
			this.label7.Text = "第三順位姓名";
			// 
			// txtName2
			// 
			this.txtName2.Location = new System.Drawing.Point(349, 82);
			this.txtName2.Name = "txtName2";
			this.txtName2.ReadOnly = true;
			this.txtName2.Size = new System.Drawing.Size(100, 22);
			this.txtName2.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(266, 92);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 12);
			this.label8.TabIndex = 8;
			this.label8.Text = "第二順位姓名";
			// 
			// txtName1
			// 
			this.txtName1.Location = new System.Drawing.Point(98, 82);
			this.txtName1.Name = "txtName1";
			this.txtName1.ReadOnly = true;
			this.txtName1.Size = new System.Drawing.Size(100, 22);
			this.txtName1.TabIndex = 7;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 92);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 12);
			this.label9.TabIndex = 6;
			this.label9.Text = "第一順位姓名";
			// 
			// txtPos3
			// 
			this.txtPos3.Location = new System.Drawing.Point(602, 54);
			this.txtPos3.Name = "txtPos3";
			this.txtPos3.ReadOnly = true;
			this.txtPos3.Size = new System.Drawing.Size(100, 22);
			this.txtPos3.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(519, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 12);
			this.label6.TabIndex = 4;
			this.label6.Text = "第三順位職稱";
			// 
			// txtPos2
			// 
			this.txtPos2.Location = new System.Drawing.Point(349, 54);
			this.txtPos2.Name = "txtPos2";
			this.txtPos2.ReadOnly = true;
			this.txtPos2.Size = new System.Drawing.Size(100, 22);
			this.txtPos2.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(266, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 12);
			this.label5.TabIndex = 2;
			this.label5.Text = "第二順位職稱";
			// 
			// txtPos1
			// 
			this.txtPos1.Location = new System.Drawing.Point(98, 54);
			this.txtPos1.Name = "txtPos1";
			this.txtPos1.ReadOnly = true;
			this.txtPos1.Size = new System.Drawing.Size(100, 22);
			this.txtPos1.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "第一順位職稱";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(272, 161);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "**可簽核的部門限制**";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(539, 161);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "**可簽核的流程限制**";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(77, 12);
			this.label10.TabIndex = 10;
			this.label10.Text = "代理需求者：";
			// 
			// lbSource
			// 
			this.lbSource.AutoSize = true;
			this.lbSource.Location = new System.Drawing.Point(89, 9);
			this.lbSource.Name = "lbSource";
			this.lbSource.Size = new System.Drawing.Size(0, 12);
			this.lbSource.TabIndex = 11;
			// 
			// checkAgentAlwaysTableAdapter
			// 
			this.checkAgentAlwaysTableAdapter.ClearBeforeFill = true;
			// 
			// checkAgentPowerMTableAdapter
			// 
			this.checkAgentPowerMTableAdapter.ClearBeforeFill = true;
			// 
			// deptTableAdapter
			// 
			this.deptTableAdapter.ClearBeforeFill = true;
			// 
			// checkAgentPowerDTableAdapter
			// 
			this.checkAgentPowerDTableAdapter.ClearBeforeFill = true;
			// 
			// flowTreeTableAdapter
			// 
			this.flowTreeTableAdapter.ClearBeforeFill = true;
			// 
			// bnAdd4
			// 
			this.bnAdd4.Location = new System.Drawing.Point(12, 150);
			this.bnAdd4.Name = "bnAdd4";
			this.bnAdd4.Size = new System.Drawing.Size(151, 23);
			this.bnAdd4.TabIndex = 13;
			this.bnAdd4.Text = "新增常態性代理人";
			this.bnAdd4.UseVisualStyleBackColor = true;
			this.bnAdd4.Click += new System.EventHandler(this.bnAdd4_Click);
			// 
			// fmCheckAgent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 473);
			this.Controls.Add(this.bnAdd4);
			this.Controls.Add(this.lbSource);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grdD);
			this.Controls.Add(this.grdM);
			this.Controls.Add(this.grdAgent);
			this.MaximizeBox = false;
			this.Name = "fmCheckAgent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "簽核代理人";
			this.Load += new System.EventHandler(this.fmCheckAgent_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdAgent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAgentAlwaysBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deptBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAgentPowerMBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flowTreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAgentPowerDBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView grdAgent;
		private System.Windows.Forms.DataGridView grdM;
		private System.Windows.Forms.DataGridView grdD;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtPos3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPos2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPos1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bnAdd3;
		private System.Windows.Forms.Button bnAdd2;
		private System.Windows.Forms.Button bnAdd1;
		private System.Windows.Forms.TextBox txtName3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtName2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtName1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lbSource;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource checkAgentAlwaysBindingSource;
		private ezOrg.ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter checkAgentAlwaysTableAdapter;
		private System.Windows.Forms.BindingSource checkAgentPowerMBindingSource;
		private ezOrg.ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter checkAgentPowerMTableAdapter;
		private System.Windows.Forms.BindingSource deptBindingSource;
		private ezOrg.ezOrgDSTableAdapters.DeptTableAdapter deptTableAdapter;
		private System.Windows.Forms.BindingSource checkAgentPowerDBindingSource;
		private ezOrg.ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter checkAgentPowerDTableAdapter;
		private System.Windows.Forms.BindingSource flowTreeBindingSource;
		private ezOrg.ezOrgDSTableAdapters.FlowTreeTableAdapter flowTreeTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn posnameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn deptidDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isAllSubDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn flowTreeidDataGridViewTextBoxColumn;
		private System.Windows.Forms.Button bnAdd4;
		private System.Windows.Forms.Button bnClear1;
		private System.Windows.Forms.Button bnClear3;
		private System.Windows.Forms.Button bnClear2;
	}
}