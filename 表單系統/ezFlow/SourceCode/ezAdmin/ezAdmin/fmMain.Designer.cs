namespace ezAdmin {
	partial class fmMain {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bnContinue = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.bnFinish = new System.Windows.Forms.Button();
			this.grdProcess = new System.Windows.Forms.DataGridView();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowTreenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowNodenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empnameCheckDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isCancelDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.processFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezAdminDS = new ezAdmin.ezAdminDS();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckCancel = new System.Windows.Forms.CheckBox();
			this.bnQuery = new System.Windows.Forms.Button();
			this.dtEnd = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dtStart = new System.Windows.Forms.DateTimePicker();
			this.ckDate = new System.Windows.Forms.CheckBox();
			this.bnMemberQuery = new System.Windows.Forms.Button();
			this.txtStarter = new System.Windows.Forms.TextBox();
			this.ckStarter = new System.Windows.Forms.CheckBox();
			this.bnDeptQuery = new System.Windows.Forms.Button();
			this.txtDept = new System.Windows.Forms.TextBox();
			this.ckDept = new System.Windows.Forms.CheckBox();
			this.cbFlow = new System.Windows.Forms.ComboBox();
			this.flowTreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ckFlow = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.bnOK = new System.Windows.Forms.Button();
			this.grdException = new System.Windows.Forms.DataGridView();
			this.autoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowTreenameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowNodenameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.errorTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.errorTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.errorMsgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.processExceptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.serviceController = new System.ServiceProcess.ServiceController();
			this.processFlowTableAdapter = new ezAdmin.ezAdminDSTableAdapters.ProcessFlowTableAdapter();
			this.flowTreeTableAdapter = new ezAdmin.ezAdminDSTableAdapters.FlowTreeTableAdapter();
			this.processExceptionTableAdapter = new ezAdmin.ezAdminDSTableAdapters.ProcessExceptionTableAdapter();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdProcess)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.processFlowBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezAdminDS)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flowTreeBindingSource)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdException)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.processExceptionBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(792, 573);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.grdProcess);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(784, 548);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "流程監控";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bnContinue);
			this.groupBox2.Controls.Add(this.bnCancel);
			this.groupBox2.Controls.Add(this.bnFinish);
			this.groupBox2.Location = new System.Drawing.Point(8, 487);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(768, 55);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "管理決策";
			// 
			// bnContinue
			// 
			this.bnContinue.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnContinue.ForeColor = System.Drawing.Color.Green;
			this.bnContinue.Location = new System.Drawing.Point(390, 21);
			this.bnContinue.Name = "bnContinue";
			this.bnContinue.Size = new System.Drawing.Size(175, 23);
			this.bnContinue.TabIndex = 3;
			this.bnContinue.Text = "選取的流程全部恢復運作";
			this.bnContinue.UseVisualStyleBackColor = true;
			this.bnContinue.Click += new System.EventHandler(this.bnContinue_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnCancel.ForeColor = System.Drawing.Color.Black;
			this.bnCancel.Location = new System.Drawing.Point(201, 21);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(175, 23);
			this.bnCancel.TabIndex = 2;
			this.bnCancel.Text = "選取的流程全部中止運作";
			this.bnCancel.UseVisualStyleBackColor = true;
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// bnFinish
			// 
			this.bnFinish.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnFinish.ForeColor = System.Drawing.Color.Blue;
			this.bnFinish.Location = new System.Drawing.Point(579, 21);
			this.bnFinish.Name = "bnFinish";
			this.bnFinish.Size = new System.Drawing.Size(175, 23);
			this.bnFinish.TabIndex = 0;
			this.bnFinish.Text = "選取的流程全部徹回";
			this.bnFinish.UseVisualStyleBackColor = true;
			this.bnFinish.Click += new System.EventHandler(this.bnFinish_Click);
			// 
			// grdProcess
			// 
			this.grdProcess.AllowUserToAddRows = false;
			this.grdProcess.AllowUserToDeleteRows = false;
			this.grdProcess.AutoGenerateColumns = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdProcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.adateDataGridViewTextBoxColumn,
            this.flowTreenameDataGridViewTextBoxColumn,
            this.empnameDataGridViewTextBoxColumn,
            this.flowNodenameDataGridViewTextBoxColumn,
            this.empnameCheckDataGridViewTextBoxColumn,
            this.isCancelDataGridViewCheckBoxColumn});
			this.grdProcess.DataSource = this.processFlowBindingSource;
			this.grdProcess.Location = new System.Drawing.Point(8, 110);
			this.grdProcess.Name = "grdProcess";
			this.grdProcess.ReadOnly = true;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdProcess.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.grdProcess.RowTemplate.Height = 24;
			this.grdProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdProcess.Size = new System.Drawing.Size(768, 371);
			this.grdProcess.TabIndex = 1;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumn.HeaderText = "ID";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.Width = 50;
			// 
			// adateDataGridViewTextBoxColumn
			// 
			this.adateDataGridViewTextBoxColumn.DataPropertyName = "adate";
			dataGridViewCellStyle2.Format = "yyyy/MM/dd";
			dataGridViewCellStyle2.NullValue = null;
			this.adateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.adateDataGridViewTextBoxColumn.HeaderText = "申請日期";
			this.adateDataGridViewTextBoxColumn.Name = "adateDataGridViewTextBoxColumn";
			this.adateDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// flowTreenameDataGridViewTextBoxColumn
			// 
			this.flowTreenameDataGridViewTextBoxColumn.DataPropertyName = "FlowTree_name";
			this.flowTreenameDataGridViewTextBoxColumn.HeaderText = "流程名稱";
			this.flowTreenameDataGridViewTextBoxColumn.Name = "flowTreenameDataGridViewTextBoxColumn";
			this.flowTreenameDataGridViewTextBoxColumn.ReadOnly = true;
			this.flowTreenameDataGridViewTextBoxColumn.Width = 190;
			// 
			// empnameDataGridViewTextBoxColumn
			// 
			this.empnameDataGridViewTextBoxColumn.DataPropertyName = "Emp_name";
			this.empnameDataGridViewTextBoxColumn.HeaderText = "申請者";
			this.empnameDataGridViewTextBoxColumn.Name = "empnameDataGridViewTextBoxColumn";
			this.empnameDataGridViewTextBoxColumn.ReadOnly = true;
			this.empnameDataGridViewTextBoxColumn.Width = 80;
			// 
			// flowNodenameDataGridViewTextBoxColumn
			// 
			this.flowNodenameDataGridViewTextBoxColumn.DataPropertyName = "FlowNode_name";
			this.flowNodenameDataGridViewTextBoxColumn.HeaderText = "處理進度";
			this.flowNodenameDataGridViewTextBoxColumn.Name = "flowNodenameDataGridViewTextBoxColumn";
			this.flowNodenameDataGridViewTextBoxColumn.ReadOnly = true;
			this.flowNodenameDataGridViewTextBoxColumn.Width = 175;
			// 
			// empnameCheckDataGridViewTextBoxColumn
			// 
			this.empnameCheckDataGridViewTextBoxColumn.DataPropertyName = "Emp_nameCheck";
			this.empnameCheckDataGridViewTextBoxColumn.HeaderText = "處理者";
			this.empnameCheckDataGridViewTextBoxColumn.Name = "empnameCheckDataGridViewTextBoxColumn";
			this.empnameCheckDataGridViewTextBoxColumn.ReadOnly = true;
			this.empnameCheckDataGridViewTextBoxColumn.Width = 80;
			// 
			// isCancelDataGridViewCheckBoxColumn
			// 
			this.isCancelDataGridViewCheckBoxColumn.DataPropertyName = "isCancel";
			this.isCancelDataGridViewCheckBoxColumn.HeaderText = "中止";
			this.isCancelDataGridViewCheckBoxColumn.Name = "isCancelDataGridViewCheckBoxColumn";
			this.isCancelDataGridViewCheckBoxColumn.ReadOnly = true;
			this.isCancelDataGridViewCheckBoxColumn.Width = 36;
			// 
			// processFlowBindingSource
			// 
			this.processFlowBindingSource.AllowNew = false;
			this.processFlowBindingSource.DataMember = "ProcessFlow";
			this.processFlowBindingSource.DataSource = this.ezAdminDS;
			// 
			// ezAdminDS
			// 
			this.ezAdminDS.DataSetName = "ezAdminDS";
			this.ezAdminDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckCancel);
			this.groupBox1.Controls.Add(this.bnQuery);
			this.groupBox1.Controls.Add(this.dtEnd);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.dtStart);
			this.groupBox1.Controls.Add(this.ckDate);
			this.groupBox1.Controls.Add(this.bnMemberQuery);
			this.groupBox1.Controls.Add(this.txtStarter);
			this.groupBox1.Controls.Add(this.ckStarter);
			this.groupBox1.Controls.Add(this.bnDeptQuery);
			this.groupBox1.Controls.Add(this.txtDept);
			this.groupBox1.Controls.Add(this.ckDept);
			this.groupBox1.Controls.Add(this.cbFlow);
			this.groupBox1.Controls.Add(this.ckFlow);
			this.groupBox1.Location = new System.Drawing.Point(8, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(768, 100);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "資料篩選";
			// 
			// ckCancel
			// 
			this.ckCancel.AutoSize = true;
			this.ckCancel.Location = new System.Drawing.Point(11, 20);
			this.ckCancel.Name = "ckCancel";
			this.ckCancel.Size = new System.Drawing.Size(120, 16);
			this.ckCancel.TabIndex = 13;
			this.ckCancel.Text = "只篩選中止的流程";
			this.ckCancel.UseVisualStyleBackColor = true;
			// 
			// bnQuery
			// 
			this.bnQuery.Location = new System.Drawing.Point(692, 42);
			this.bnQuery.Name = "bnQuery";
			this.bnQuery.Size = new System.Drawing.Size(62, 48);
			this.bnQuery.TabIndex = 12;
			this.bnQuery.Text = "篩選";
			this.bnQuery.UseVisualStyleBackColor = true;
			this.bnQuery.Click += new System.EventHandler(this.bnQuery_Click);
			// 
			// dtEnd
			// 
			this.dtEnd.CustomFormat = "yyyy/MM/dd";
			this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEnd.Location = new System.Drawing.Point(208, 42);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.Size = new System.Drawing.Size(79, 22);
			this.dtEnd.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(180, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "至";
			// 
			// dtStart
			// 
			this.dtStart.CustomFormat = "yyyy/MM/dd";
			this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStart.Location = new System.Drawing.Point(90, 42);
			this.dtStart.Name = "dtStart";
			this.dtStart.Size = new System.Drawing.Size(79, 22);
			this.dtStart.TabIndex = 9;
			// 
			// ckDate
			// 
			this.ckDate.AutoSize = true;
			this.ckDate.Location = new System.Drawing.Point(11, 45);
			this.ckDate.Name = "ckDate";
			this.ckDate.Size = new System.Drawing.Size(72, 16);
			this.ckDate.TabIndex = 8;
			this.ckDate.Text = "日期篩選";
			this.ckDate.UseVisualStyleBackColor = true;
			// 
			// bnMemberQuery
			// 
			this.bnMemberQuery.Enabled = false;
			this.bnMemberQuery.Location = new System.Drawing.Point(610, 67);
			this.bnMemberQuery.Name = "bnMemberQuery";
			this.bnMemberQuery.Size = new System.Drawing.Size(75, 23);
			this.bnMemberQuery.TabIndex = 7;
			this.bnMemberQuery.Text = "成員選取器";
			this.bnMemberQuery.UseVisualStyleBackColor = true;
			this.bnMemberQuery.Click += new System.EventHandler(this.bnMemberQuery_Click);
			// 
			// txtStarter
			// 
			this.txtStarter.Location = new System.Drawing.Point(470, 67);
			this.txtStarter.Name = "txtStarter";
			this.txtStarter.ReadOnly = true;
			this.txtStarter.Size = new System.Drawing.Size(134, 22);
			this.txtStarter.TabIndex = 6;
			// 
			// ckStarter
			// 
			this.ckStarter.AutoSize = true;
			this.ckStarter.Location = new System.Drawing.Point(380, 70);
			this.ckStarter.Name = "ckStarter";
			this.ckStarter.Size = new System.Drawing.Size(84, 16);
			this.ckStarter.TabIndex = 5;
			this.ckStarter.Text = "申請者篩選";
			this.ckStarter.UseVisualStyleBackColor = true;
			this.ckStarter.CheckedChanged += new System.EventHandler(this.ckStarter_CheckedChanged);
			// 
			// bnDeptQuery
			// 
			this.bnDeptQuery.Enabled = false;
			this.bnDeptQuery.Location = new System.Drawing.Point(293, 67);
			this.bnDeptQuery.Name = "bnDeptQuery";
			this.bnDeptQuery.Size = new System.Drawing.Size(75, 23);
			this.bnDeptQuery.TabIndex = 4;
			this.bnDeptQuery.Text = "組織選取器";
			this.bnDeptQuery.UseVisualStyleBackColor = true;
			this.bnDeptQuery.Click += new System.EventHandler(this.bnDeptQuery_Click);
			// 
			// txtDept
			// 
			this.txtDept.Location = new System.Drawing.Point(89, 67);
			this.txtDept.Name = "txtDept";
			this.txtDept.ReadOnly = true;
			this.txtDept.Size = new System.Drawing.Size(198, 22);
			this.txtDept.TabIndex = 3;
			// 
			// ckDept
			// 
			this.ckDept.AutoSize = true;
			this.ckDept.Location = new System.Drawing.Point(11, 70);
			this.ckDept.Name = "ckDept";
			this.ckDept.Size = new System.Drawing.Size(72, 16);
			this.ckDept.TabIndex = 2;
			this.ckDept.Text = "部門篩選";
			this.ckDept.UseVisualStyleBackColor = true;
			this.ckDept.CheckedChanged += new System.EventHandler(this.ckDept_CheckedChanged);
			// 
			// cbFlow
			// 
			this.cbFlow.DataSource = this.flowTreeBindingSource;
			this.cbFlow.DisplayMember = "name";
			this.cbFlow.FormattingEnabled = true;
			this.cbFlow.Location = new System.Drawing.Point(470, 43);
			this.cbFlow.Name = "cbFlow";
			this.cbFlow.Size = new System.Drawing.Size(215, 20);
			this.cbFlow.TabIndex = 1;
			this.cbFlow.ValueMember = "id";
			// 
			// flowTreeBindingSource
			// 
			this.flowTreeBindingSource.DataMember = "FlowTree";
			this.flowTreeBindingSource.DataSource = this.ezAdminDS;
			// 
			// ckFlow
			// 
			this.ckFlow.AutoSize = true;
			this.ckFlow.Location = new System.Drawing.Point(380, 45);
			this.ckFlow.Name = "ckFlow";
			this.ckFlow.Size = new System.Drawing.Size(72, 16);
			this.ckFlow.TabIndex = 0;
			this.ckFlow.Text = "流程篩選";
			this.ckFlow.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.bnOK);
			this.tabPage3.Controls.Add(this.grdException);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(784, 548);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "錯誤回報";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(305, 518);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(174, 23);
			this.bnOK.TabIndex = 1;
			this.bnOK.Text = "選取的項目問題已解決";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// grdException
			// 
			this.grdException.AllowUserToAddRows = false;
			this.grdException.AllowUserToDeleteRows = false;
			this.grdException.AllowUserToResizeRows = false;
			this.grdException.AutoGenerateColumns = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdException.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.grdException.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdException.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.autoDataGridViewTextBoxColumn,
            this.flowTreenameDataGridViewTextBoxColumn1,
            this.flowNodenameDataGridViewTextBoxColumn1,
            this.empnameDataGridViewTextBoxColumn1,
            this.errorTypeDataGridViewTextBoxColumn,
            this.errorMsgDataGridViewTextBoxColumn,
            this.adateDataGridViewTextBoxColumn1});
			this.grdException.DataSource = this.processExceptionBindingSource;
			this.grdException.Location = new System.Drawing.Point(3, 3);
			this.grdException.Name = "grdException";
			this.grdException.ReadOnly = true;
			this.grdException.RowTemplate.Height = 24;
			this.grdException.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdException.Size = new System.Drawing.Size(778, 508);
			this.grdException.TabIndex = 0;
			// 
			// autoDataGridViewTextBoxColumn
			// 
			this.autoDataGridViewTextBoxColumn.DataPropertyName = "auto";
			this.autoDataGridViewTextBoxColumn.HeaderText = "ID";
			this.autoDataGridViewTextBoxColumn.Name = "autoDataGridViewTextBoxColumn";
			this.autoDataGridViewTextBoxColumn.ReadOnly = true;
			this.autoDataGridViewTextBoxColumn.Width = 40;
			// 
			// flowTreenameDataGridViewTextBoxColumn1
			// 
			this.flowTreenameDataGridViewTextBoxColumn1.DataPropertyName = "FlowTree_name";
			this.flowTreenameDataGridViewTextBoxColumn1.HeaderText = "例外流程";
			this.flowTreenameDataGridViewTextBoxColumn1.Name = "flowTreenameDataGridViewTextBoxColumn1";
			this.flowTreenameDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// flowNodenameDataGridViewTextBoxColumn1
			// 
			this.flowNodenameDataGridViewTextBoxColumn1.DataPropertyName = "FlowNode_name";
			this.flowNodenameDataGridViewTextBoxColumn1.HeaderText = "例外節點";
			this.flowNodenameDataGridViewTextBoxColumn1.Name = "flowNodenameDataGridViewTextBoxColumn1";
			this.flowNodenameDataGridViewTextBoxColumn1.ReadOnly = true;
			this.flowNodenameDataGridViewTextBoxColumn1.Width = 80;
			// 
			// empnameDataGridViewTextBoxColumn1
			// 
			this.empnameDataGridViewTextBoxColumn1.DataPropertyName = "Emp_name";
			this.empnameDataGridViewTextBoxColumn1.HeaderText = "處理者";
			this.empnameDataGridViewTextBoxColumn1.Name = "empnameDataGridViewTextBoxColumn1";
			this.empnameDataGridViewTextBoxColumn1.ReadOnly = true;
			this.empnameDataGridViewTextBoxColumn1.Width = 60;
			// 
			// errorTypeDataGridViewTextBoxColumn
			// 
			this.errorTypeDataGridViewTextBoxColumn.DataPropertyName = "errorType";
			this.errorTypeDataGridViewTextBoxColumn.DataSource = this.errorTypeBindingSource;
			this.errorTypeDataGridViewTextBoxColumn.DisplayMember = "name";
			this.errorTypeDataGridViewTextBoxColumn.HeaderText = "例外類型";
			this.errorTypeDataGridViewTextBoxColumn.Name = "errorTypeDataGridViewTextBoxColumn";
			this.errorTypeDataGridViewTextBoxColumn.ReadOnly = true;
			this.errorTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.errorTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.errorTypeDataGridViewTextBoxColumn.ValueMember = "id";
			this.errorTypeDataGridViewTextBoxColumn.Width = 60;
			// 
			// errorTypeBindingSource
			// 
			this.errorTypeBindingSource.DataMember = "ErrorType";
			this.errorTypeBindingSource.DataSource = this.ezAdminDS;
			// 
			// errorMsgDataGridViewTextBoxColumn
			// 
			this.errorMsgDataGridViewTextBoxColumn.DataPropertyName = "errorMsg";
			this.errorMsgDataGridViewTextBoxColumn.HeaderText = "例外訊息";
			this.errorMsgDataGridViewTextBoxColumn.Name = "errorMsgDataGridViewTextBoxColumn";
			this.errorMsgDataGridViewTextBoxColumn.ReadOnly = true;
			this.errorMsgDataGridViewTextBoxColumn.Width = 290;
			// 
			// adateDataGridViewTextBoxColumn1
			// 
			this.adateDataGridViewTextBoxColumn1.DataPropertyName = "adate";
			dataGridViewCellStyle5.Format = "yyyy/MM/dd HH:mm";
			this.adateDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
			this.adateDataGridViewTextBoxColumn1.HeaderText = "發生時間";
			this.adateDataGridViewTextBoxColumn1.Name = "adateDataGridViewTextBoxColumn1";
			this.adateDataGridViewTextBoxColumn1.ReadOnly = true;
			this.adateDataGridViewTextBoxColumn1.Width = 90;
			// 
			// processExceptionBindingSource
			// 
			this.processExceptionBindingSource.DataMember = "ProcessException";
			this.processExceptionBindingSource.DataSource = this.ezAdminDS;
			// 
			// serviceController
			// 
			this.serviceController.MachineName = "127.0.0.1";
			this.serviceController.ServiceName = "Netlogon";
			// 
			// processFlowTableAdapter
			// 
			this.processFlowTableAdapter.ClearBeforeFill = true;
			// 
			// flowTreeTableAdapter
			// 
			this.flowTreeTableAdapter.ClearBeforeFill = true;
			// 
			// processExceptionTableAdapter
			// 
			this.processExceptionTableAdapter.ClearBeforeFill = true;
			// 
			// fmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "fmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ezFlow 超級管理員";
			this.Load += new System.EventHandler(this.fmMain_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdProcess)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.processFlowBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezAdminDS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.flowTreeBindingSource)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdException)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorTypeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.processExceptionBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DataGridView grdProcess;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.CheckBox ckDate;
		private System.Windows.Forms.Button bnMemberQuery;
		private System.Windows.Forms.TextBox txtStarter;
		private System.Windows.Forms.CheckBox ckStarter;
		private System.Windows.Forms.Button bnDeptQuery;
		private System.Windows.Forms.TextBox txtDept;
		private System.Windows.Forms.CheckBox ckDept;
		private System.Windows.Forms.ComboBox cbFlow;
		private System.Windows.Forms.CheckBox ckFlow;
		private System.Windows.Forms.Button bnQuery;
		private System.Windows.Forms.DateTimePicker dtEnd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button bnFinish;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.Button bnContinue;
		private System.Windows.Forms.CheckBox ckCancel;
		private System.Windows.Forms.DataGridView grdException;
		private ezAdminDS ezAdminDS;
		private System.Windows.Forms.BindingSource processFlowBindingSource;
		private ezAdmin.ezAdminDSTableAdapters.ProcessFlowTableAdapter processFlowTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn adateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn flowTreenameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn flowNodenameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn empnameCheckDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isCancelDataGridViewCheckBoxColumn;
		private System.Windows.Forms.BindingSource flowTreeBindingSource;
		private ezAdmin.ezAdminDSTableAdapters.FlowTreeTableAdapter flowTreeTableAdapter;
		private System.Windows.Forms.BindingSource processExceptionBindingSource;
		private ezAdmin.ezAdminDSTableAdapters.ProcessExceptionTableAdapter processExceptionTableAdapter;
		private System.Windows.Forms.BindingSource errorTypeBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn autoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn flowTreenameDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn flowNodenameDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn empnameDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewComboBoxColumn errorTypeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn errorMsgDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn adateDataGridViewTextBoxColumn1;
		private System.Windows.Forms.Button bnOK;
		private System.ServiceProcess.ServiceController serviceController;

	}
}

