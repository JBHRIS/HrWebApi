namespace FlowManage
{
    partial class fmSubWork
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.ckSubMang = new System.Windows.Forms.CheckBox();
            this.ckReplace = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbFlowAuth = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpDateD = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtNobr = new JBControls.PopupTextBox();
            this.txtDept = new JBControls.PopupTextBox();
            this.txtJob = new JBControls.PopupTextBox();
            this.subWorkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBase = new FlowManage.dsBase();
            this.empBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subWorkTableAdapter = new FlowManage.dsBaseTableAdapters.SubWorkTableAdapter();
            this.empTableAdapter = new FlowManage.dsBaseTableAdapters.EmpTableAdapter();
            this.deptTableAdapter = new FlowManage.dsBaseTableAdapters.DeptTableAdapter();
            this.posTableAdapter = new FlowManage.dsBaseTableAdapters.PosTableAdapter();
            this.iAutoKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNobrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSubDeptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSubJobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sJobName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSubMangDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iFlowAuthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bReplaceDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sKeyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dKeyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subWorkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(584, 362);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iAutoKeyDataGridViewTextBoxColumn,
            this.sNobrDataGridViewTextBoxColumn,
            this.sName,
            this.sSubDeptDataGridViewTextBoxColumn,
            this.sDeptName,
            this.sSubJobDataGridViewTextBoxColumn,
            this.sJobName,
            this.bSubMangDataGridViewCheckBoxColumn,
            this.iFlowAuthDataGridViewTextBoxColumn,
            this.bReplaceDataGridViewCheckBoxColumn,
            this.sKeyManDataGridViewTextBoxColumn,
            this.dKeyDateDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.subWorkBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(584, 245);
            this.dgv.TabIndex = 3;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckSubMang, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckReplace, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbFlowAuth, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDept, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJob, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 113);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "工號";
            // 
            // ckSubMang
            // 
            this.ckSubMang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckSubMang.AutoSize = true;
            this.ckSubMang.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.subWorkBindingSource, "bSubMang", true));
            this.ckSubMang.Location = new System.Drawing.Point(264, 6);
            this.ckSubMang.Name = "ckSubMang";
            this.ckSubMang.Size = new System.Drawing.Size(108, 16);
            this.ckSubMang.TabIndex = 8;
            this.ckSubMang.Text = "是否兼職為主管";
            this.ckSubMang.UseVisualStyleBackColor = true;
            // 
            // ckReplace
            // 
            this.ckReplace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckReplace.AutoSize = true;
            this.ckReplace.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.subWorkBindingSource, "bReplace", true));
            this.ckReplace.Location = new System.Drawing.Point(378, 6);
            this.ckReplace.Name = "ckReplace";
            this.ckReplace.Size = new System.Drawing.Size(84, 16);
            this.ckReplace.TabIndex = 16;
            this.ckReplace.Text = "取代原職位";
            this.ckReplace.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "兼職部門";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(319, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "兼職職稱";
            // 
            // cbFlowAuth
            // 
            this.cbFlowAuth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFlowAuth.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.subWorkBindingSource, "iFlowAuth", true));
            this.cbFlowAuth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subWorkBindingSource, "iFlowAuth", true));
            this.cbFlowAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFlowAuth.FormattingEnabled = true;
            this.cbFlowAuth.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbFlowAuth.Location = new System.Drawing.Point(378, 59);
            this.cbFlowAuth.Name = "cbFlowAuth";
            this.cbFlowAuth.Size = new System.Drawing.Size(37, 20);
            this.cbFlowAuth.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(319, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "簽核順位";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "生失效日";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dtpDateA);
            this.flowLayoutPanel1.Controls.Add(this.label14);
            this.flowLayoutPanel1.Controls.Add(this.dtpDateD);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(59, 56);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(202, 26);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // dtpDateD
            // 
            this.dtpDateD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateD.CustomFormat = "yyyy/MM/dd";
            this.dtpDateD.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.subWorkBindingSource, "dAdate", true));
            this.dtpDateD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateD.Location = new System.Drawing.Point(111, 3);
            this.dtpDateD.Name = "dtpDateD";
            this.dtpDateD.Size = new System.Drawing.Size(79, 22);
            this.dtpDateD.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(88, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "至";
            // 
            // dtpDateA
            // 
            this.dtpDateA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateA.CustomFormat = "yyyy/MM/dd";
            this.dtpDateA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.subWorkBindingSource, "dDdate", true));
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateA.Location = new System.Drawing.Point(3, 3);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(79, 22);
            this.dtpDateA.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 4);
            this.flowLayoutPanel2.Controls.Add(this.btnAdd);
            this.flowLayoutPanel2.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel2.Controls.Add(this.btnDel);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 85);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(584, 24);
            this.flowLayoutPanel2.TabIndex = 31;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.Location = new System.Drawing.Point(3, -2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdate.Location = new System.Drawing.Point(84, -2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDel.Location = new System.Drawing.Point(165, -2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtNobr
            // 
            this.txtNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobr.CaptionLabel = null;
            this.txtNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobr.DataBindings.Add(new System.Windows.Forms.Binding("LabelText", this.subWorkBindingSource, "sName", true));
            this.txtNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subWorkBindingSource, "sNobr", true));
            this.txtNobr.DataSource = this.empBindingSource;
            this.txtNobr.DisplayMember = "name";
            this.txtNobr.ErrorProvider = null;
            this.txtNobr.IsEmpty = true;
            this.txtNobr.IsEmptyToQuery = false;
            this.txtNobr.IsLeaveToQuery = false;
            this.txtNobr.IsQuery = true;
            this.txtNobr.LabelText = "";
            this.txtNobr.Location = new System.Drawing.Point(62, 3);
            this.txtNobr.Name = "txtNobr";
            this.txtNobr.QueryFields = "id,name";
            this.txtNobr.ReadOnly = false;
            this.txtNobr.ShowExceptionMsg = true;
            this.txtNobr.Size = new System.Drawing.Size(100, 22);
            this.txtNobr.TabIndex = 32;
            this.txtNobr.ValueMember = "id";
            this.txtNobr.WhereCmd = "";
            // 
            // txtDept
            // 
            this.txtDept.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDept.CaptionLabel = null;
            this.txtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDept.DataBindings.Add(new System.Windows.Forms.Binding("LabelText", this.subWorkBindingSource, "sDeptName", true));
            this.txtDept.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subWorkBindingSource, "sSubDept", true));
            this.txtDept.DataSource = this.deptBindingSource;
            this.txtDept.DisplayMember = "name";
            this.txtDept.ErrorProvider = null;
            this.txtDept.IsEmpty = true;
            this.txtDept.IsEmptyToQuery = false;
            this.txtDept.IsLeaveToQuery = false;
            this.txtDept.IsQuery = true;
            this.txtDept.LabelText = "";
            this.txtDept.Location = new System.Drawing.Point(62, 31);
            this.txtDept.Name = "txtDept";
            this.txtDept.QueryFields = "id,idparent,name";
            this.txtDept.ReadOnly = false;
            this.txtDept.ShowExceptionMsg = true;
            this.txtDept.Size = new System.Drawing.Size(100, 22);
            this.txtDept.TabIndex = 33;
            this.txtDept.ValueMember = "id";
            this.txtDept.WhereCmd = "";
            // 
            // txtJob
            // 
            this.txtJob.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtJob.CaptionLabel = null;
            this.txtJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtJob.DataBindings.Add(new System.Windows.Forms.Binding("LabelText", this.subWorkBindingSource, "sJobName", true));
            this.txtJob.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subWorkBindingSource, "sSubJob", true));
            this.txtJob.DataSource = this.posBindingSource;
            this.txtJob.DisplayMember = "name";
            this.txtJob.ErrorProvider = null;
            this.txtJob.IsEmpty = true;
            this.txtJob.IsEmptyToQuery = false;
            this.txtJob.IsLeaveToQuery = false;
            this.txtJob.IsQuery = true;
            this.txtJob.LabelText = "";
            this.txtJob.Location = new System.Drawing.Point(378, 31);
            this.txtJob.Name = "txtJob";
            this.txtJob.QueryFields = "id,name";
            this.txtJob.ReadOnly = false;
            this.txtJob.ShowExceptionMsg = true;
            this.txtJob.Size = new System.Drawing.Size(100, 22);
            this.txtJob.TabIndex = 34;
            this.txtJob.ValueMember = "id";
            this.txtJob.WhereCmd = "";
            // 
            // subWorkBindingSource
            // 
            this.subWorkBindingSource.DataMember = "SubWork";
            this.subWorkBindingSource.DataSource = this.dsBase;
            // 
            // dsBase
            // 
            this.dsBase.DataSetName = "dsBase";
            this.dsBase.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empBindingSource
            // 
            this.empBindingSource.DataMember = "Emp";
            this.empBindingSource.DataSource = this.dsBase;
            // 
            // deptBindingSource
            // 
            this.deptBindingSource.DataMember = "Dept";
            this.deptBindingSource.DataSource = this.dsBase;
            // 
            // posBindingSource
            // 
            this.posBindingSource.DataMember = "Pos";
            this.posBindingSource.DataSource = this.dsBase;
            // 
            // subWorkTableAdapter
            // 
            this.subWorkTableAdapter.ClearBeforeFill = true;
            // 
            // empTableAdapter
            // 
            this.empTableAdapter.ClearBeforeFill = true;
            // 
            // deptTableAdapter
            // 
            this.deptTableAdapter.ClearBeforeFill = true;
            // 
            // posTableAdapter
            // 
            this.posTableAdapter.ClearBeforeFill = true;
            // 
            // iAutoKeyDataGridViewTextBoxColumn
            // 
            this.iAutoKeyDataGridViewTextBoxColumn.DataPropertyName = "iAutoKey";
            this.iAutoKeyDataGridViewTextBoxColumn.HeaderText = "";
            this.iAutoKeyDataGridViewTextBoxColumn.Name = "iAutoKeyDataGridViewTextBoxColumn";
            this.iAutoKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.iAutoKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // sNobrDataGridViewTextBoxColumn
            // 
            this.sNobrDataGridViewTextBoxColumn.DataPropertyName = "sNobr";
            this.sNobrDataGridViewTextBoxColumn.HeaderText = "工號";
            this.sNobrDataGridViewTextBoxColumn.Name = "sNobrDataGridViewTextBoxColumn";
            this.sNobrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sName
            // 
            this.sName.DataPropertyName = "sName";
            this.sName.HeaderText = "姓名";
            this.sName.Name = "sName";
            this.sName.ReadOnly = true;
            // 
            // sSubDeptDataGridViewTextBoxColumn
            // 
            this.sSubDeptDataGridViewTextBoxColumn.DataPropertyName = "sSubDept";
            this.sSubDeptDataGridViewTextBoxColumn.HeaderText = "代理部門代碼";
            this.sSubDeptDataGridViewTextBoxColumn.Name = "sSubDeptDataGridViewTextBoxColumn";
            this.sSubDeptDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sDeptName
            // 
            this.sDeptName.DataPropertyName = "sDeptName";
            this.sDeptName.HeaderText = "代理部門名稱";
            this.sDeptName.Name = "sDeptName";
            this.sDeptName.ReadOnly = true;
            // 
            // sSubJobDataGridViewTextBoxColumn
            // 
            this.sSubJobDataGridViewTextBoxColumn.DataPropertyName = "sSubJob";
            this.sSubJobDataGridViewTextBoxColumn.HeaderText = "代理職稱代碼";
            this.sSubJobDataGridViewTextBoxColumn.Name = "sSubJobDataGridViewTextBoxColumn";
            this.sSubJobDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sJobName
            // 
            this.sJobName.DataPropertyName = "sJobName";
            this.sJobName.HeaderText = "代理職稱代碼";
            this.sJobName.Name = "sJobName";
            this.sJobName.ReadOnly = true;
            // 
            // bSubMangDataGridViewCheckBoxColumn
            // 
            this.bSubMangDataGridViewCheckBoxColumn.DataPropertyName = "bSubMang";
            this.bSubMangDataGridViewCheckBoxColumn.HeaderText = "是否兼職主管";
            this.bSubMangDataGridViewCheckBoxColumn.Name = "bSubMangDataGridViewCheckBoxColumn";
            this.bSubMangDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // iFlowAuthDataGridViewTextBoxColumn
            // 
            this.iFlowAuthDataGridViewTextBoxColumn.DataPropertyName = "iFlowAuth";
            this.iFlowAuthDataGridViewTextBoxColumn.HeaderText = "簽核順序";
            this.iFlowAuthDataGridViewTextBoxColumn.Name = "iFlowAuthDataGridViewTextBoxColumn";
            this.iFlowAuthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bReplaceDataGridViewCheckBoxColumn
            // 
            this.bReplaceDataGridViewCheckBoxColumn.DataPropertyName = "bReplace";
            this.bReplaceDataGridViewCheckBoxColumn.HeaderText = "取代原職位";
            this.bReplaceDataGridViewCheckBoxColumn.Name = "bReplaceDataGridViewCheckBoxColumn";
            this.bReplaceDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // sKeyManDataGridViewTextBoxColumn
            // 
            this.sKeyManDataGridViewTextBoxColumn.DataPropertyName = "sKeyMan";
            this.sKeyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.sKeyManDataGridViewTextBoxColumn.Name = "sKeyManDataGridViewTextBoxColumn";
            this.sKeyManDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dKeyDateDataGridViewTextBoxColumn
            // 
            this.dKeyDateDataGridViewTextBoxColumn.DataPropertyName = "dKeyDate";
            this.dKeyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.dKeyDateDataGridViewTextBoxColumn.Name = "dKeyDateDataGridViewTextBoxColumn";
            this.dKeyDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fmSubWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fmSubWork";
            this.Text = "fmSubWork";
            this.Load += new System.EventHandler(this.fmSubWork_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subWorkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckSubMang;
        private System.Windows.Forms.CheckBox ckReplace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbFlowAuth;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpDateD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDateA;
        private dsBase dsBase;
        private System.Windows.Forms.BindingSource subWorkBindingSource;
        private FlowManage.dsBaseTableAdapters.SubWorkTableAdapter subWorkTableAdapter;
        private System.Windows.Forms.BindingSource empBindingSource;
        private FlowManage.dsBaseTableAdapters.EmpTableAdapter empTableAdapter;
        private System.Windows.Forms.BindingSource deptBindingSource;
        private FlowManage.dsBaseTableAdapters.DeptTableAdapter deptTableAdapter;
        private System.Windows.Forms.BindingSource posBindingSource;
        private FlowManage.dsBaseTableAdapters.PosTableAdapter posTableAdapter;
        private JBControls.PopupTextBox txtNobr;
        private JBControls.PopupTextBox txtDept;
        private JBControls.PopupTextBox txtJob;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn iAutoKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNobrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSubDeptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSubJobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sJobName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSubMangDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iFlowAuthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bReplaceDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sKeyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dKeyDateDataGridViewTextBoxColumn;
    }
}