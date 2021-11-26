namespace JBHR.Att
{
    partial class FRM2M_Group
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCode = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.txtCODE_DISP = new JBControls.TextBox();
            this.mEALGROUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.txtCODE_Name = new JBControls.TextBox();
            this.dgvSetting = new System.Windows.Forms.DataGridView();
            this.mealSettingCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.attendDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.oTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eatDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEALCASESETTINGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbNOTE = new System.Windows.Forms.Label();
            this.txtNOTE = new System.Windows.Forms.TextBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnMealType = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.mealGroupCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealGroupDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealGroupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mealGroupTableAdapter = new JBHR.Att.dsAttTableAdapters.MealGroupTableAdapter();
            this.mealCaseSettingTableAdapter = new JBHR.Att.dsAttTableAdapters.MealCaseSettingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mEALGROUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEALCASESETTINGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCodeGroup.Location = new System.Drawing.Point(648, 47);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 6;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代码群组";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.plFV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnMealType);
            this.splitContainer2.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(736, 227);
            this.splitContainer2.SplitterDistance = 145;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(736, 145);
            this.plFV.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE_DISP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvSetting, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbNOTE, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNOTE, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSetting, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 141);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbCode
            // 
            this.lbCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCode.AutoSize = true;
            this.lbCode.ForeColor = System.Drawing.Color.Red;
            this.lbCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCode.Location = new System.Drawing.Point(3, 8);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(77, 12);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "用餐群組代碼";
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.Color.Red;
            this.lbName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbName.Location = new System.Drawing.Point(3, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(77, 12);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "用餐群組名稱";
            // 
            // txtCODE_DISP
            // 
            this.txtCODE_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE_DISP.CaptionLabel = null;
            this.txtCODE_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALGROUPBindingSource, "MealGroup_DISP", true));
            this.txtCODE_DISP.DecimalPlace = 2;
            this.txtCODE_DISP.IsEmpty = false;
            this.txtCODE_DISP.Location = new System.Drawing.Point(86, 3);
            this.txtCODE_DISP.Mask = "";
            this.txtCODE_DISP.MaxLength = 50;
            this.txtCODE_DISP.Name = "txtCODE_DISP";
            this.txtCODE_DISP.PasswordChar = '\0';
            this.txtCODE_DISP.ReadOnly = false;
            this.txtCODE_DISP.ShowCalendarButton = true;
            this.txtCODE_DISP.Size = new System.Drawing.Size(122, 22);
            this.txtCODE_DISP.TabIndex = 0;
            this.txtCODE_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // mEALGROUPBindingSource
            // 
            this.mEALGROUPBindingSource.DataMember = "MealGroup";
            this.mEALGROUPBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtCODE_Name
            // 
            this.txtCODE_Name.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE_Name.CaptionLabel = null;
            this.txtCODE_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE_Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALGROUPBindingSource, "MealGroup_Name", true));
            this.txtCODE_Name.DecimalPlace = 2;
            this.txtCODE_Name.IsEmpty = false;
            this.txtCODE_Name.Location = new System.Drawing.Point(86, 31);
            this.txtCODE_Name.Mask = "";
            this.txtCODE_Name.MaxLength = 50;
            this.txtCODE_Name.Name = "txtCODE_Name";
            this.txtCODE_Name.PasswordChar = '\0';
            this.txtCODE_Name.ReadOnly = false;
            this.txtCODE_Name.ShowCalendarButton = true;
            this.txtCODE_Name.Size = new System.Drawing.Size(122, 22);
            this.txtCODE_Name.TabIndex = 1;
            this.txtCODE_Name.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // dgvSetting
            // 
            this.dgvSetting.AllowUserToAddRows = false;
            this.dgvSetting.AllowUserToDeleteRows = false;
            this.dgvSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSetting.AutoGenerateColumns = false;
            this.dgvSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mealSettingCodeDataGridViewTextBoxColumn,
            this.mealGroupDataGridViewTextBoxColumn,
            this.mealTypeDataGridViewTextBoxColumn,
            this.applyDataGridViewCheckBoxColumn,
            this.attendDataGridViewCheckBoxColumn,
            this.oTDataGridViewCheckBoxColumn,
            this.eatDataGridViewCheckBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.nOTEDataGridViewTextBoxColumn1,
            this.kEYMANDataGridViewTextBoxColumn1,
            this.kEYDATEDataGridViewTextBoxColumn1});
            this.dgvSetting.DataSource = this.mEALCASESETTINGBindingSource;
            this.dgvSetting.Location = new System.Drawing.Point(214, 3);
            this.dgvSetting.Name = "dgvSetting";
            this.dgvSetting.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgvSetting, 5);
            this.dgvSetting.RowTemplate.Height = 24;
            this.dgvSetting.Size = new System.Drawing.Size(517, 135);
            this.dgvSetting.TabIndex = 14;
            this.dgvSetting.TabStop = false;
            // 
            // mealSettingCodeDataGridViewTextBoxColumn
            // 
            this.mealSettingCodeDataGridViewTextBoxColumn.DataPropertyName = "MealSettingCode";
            this.mealSettingCodeDataGridViewTextBoxColumn.HeaderText = "案例";
            this.mealSettingCodeDataGridViewTextBoxColumn.Name = "mealSettingCodeDataGridViewTextBoxColumn";
            this.mealSettingCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mealSettingCodeDataGridViewTextBoxColumn.Width = 80;
            // 
            // mealGroupDataGridViewTextBoxColumn
            // 
            this.mealGroupDataGridViewTextBoxColumn.DataPropertyName = "MealGroup";
            this.mealGroupDataGridViewTextBoxColumn.HeaderText = "MealGroup";
            this.mealGroupDataGridViewTextBoxColumn.Name = "mealGroupDataGridViewTextBoxColumn";
            this.mealGroupDataGridViewTextBoxColumn.ReadOnly = true;
            this.mealGroupDataGridViewTextBoxColumn.Visible = false;
            // 
            // mealTypeDataGridViewTextBoxColumn
            // 
            this.mealTypeDataGridViewTextBoxColumn.DataPropertyName = "MealType";
            this.mealTypeDataGridViewTextBoxColumn.HeaderText = "餐別";
            this.mealTypeDataGridViewTextBoxColumn.Name = "mealTypeDataGridViewTextBoxColumn";
            this.mealTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mealTypeDataGridViewTextBoxColumn.Width = 80;
            // 
            // applyDataGridViewCheckBoxColumn
            // 
            this.applyDataGridViewCheckBoxColumn.DataPropertyName = "Apply";
            this.applyDataGridViewCheckBoxColumn.HeaderText = "報餐";
            this.applyDataGridViewCheckBoxColumn.Name = "applyDataGridViewCheckBoxColumn";
            this.applyDataGridViewCheckBoxColumn.ReadOnly = true;
            this.applyDataGridViewCheckBoxColumn.Width = 55;
            // 
            // attendDataGridViewCheckBoxColumn
            // 
            this.attendDataGridViewCheckBoxColumn.DataPropertyName = "Attend";
            this.attendDataGridViewCheckBoxColumn.HeaderText = "出勤";
            this.attendDataGridViewCheckBoxColumn.Name = "attendDataGridViewCheckBoxColumn";
            this.attendDataGridViewCheckBoxColumn.ReadOnly = true;
            this.attendDataGridViewCheckBoxColumn.Width = 55;
            // 
            // oTDataGridViewCheckBoxColumn
            // 
            this.oTDataGridViewCheckBoxColumn.DataPropertyName = "OT";
            this.oTDataGridViewCheckBoxColumn.HeaderText = "加班";
            this.oTDataGridViewCheckBoxColumn.Name = "oTDataGridViewCheckBoxColumn";
            this.oTDataGridViewCheckBoxColumn.ReadOnly = true;
            this.oTDataGridViewCheckBoxColumn.Width = 55;
            // 
            // eatDataGridViewCheckBoxColumn
            // 
            this.eatDataGridViewCheckBoxColumn.DataPropertyName = "Eat";
            this.eatDataGridViewCheckBoxColumn.HeaderText = "用餐";
            this.eatDataGridViewCheckBoxColumn.Name = "eatDataGridViewCheckBoxColumn";
            this.eatDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eatDataGridViewCheckBoxColumn.Width = 55;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "扣款";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.aMTDataGridViewTextBoxColumn.Width = 80;
            // 
            // nOTEDataGridViewTextBoxColumn1
            // 
            this.nOTEDataGridViewTextBoxColumn1.DataPropertyName = "NOTE";
            this.nOTEDataGridViewTextBoxColumn1.HeaderText = "NOTE";
            this.nOTEDataGridViewTextBoxColumn1.Name = "nOTEDataGridViewTextBoxColumn1";
            this.nOTEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nOTEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // kEYMANDataGridViewTextBoxColumn1
            // 
            this.kEYMANDataGridViewTextBoxColumn1.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn1.HeaderText = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn1.Name = "kEYMANDataGridViewTextBoxColumn1";
            this.kEYMANDataGridViewTextBoxColumn1.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn1.Visible = false;
            // 
            // kEYDATEDataGridViewTextBoxColumn1
            // 
            this.kEYDATEDataGridViewTextBoxColumn1.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn1.HeaderText = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn1.Name = "kEYDATEDataGridViewTextBoxColumn1";
            this.kEYDATEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // mEALCASESETTINGBindingSource
            // 
            this.mEALCASESETTINGBindingSource.DataMember = "MealCaseSetting";
            this.mEALCASESETTINGBindingSource.DataSource = this.dsAtt;
            // 
            // lbNOTE
            // 
            this.lbNOTE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNOTE.AutoSize = true;
            this.lbNOTE.ForeColor = System.Drawing.Color.Black;
            this.lbNOTE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNOTE.Location = new System.Drawing.Point(51, 64);
            this.lbNOTE.Name = "lbNOTE";
            this.lbNOTE.Size = new System.Drawing.Size(29, 12);
            this.lbNOTE.TabIndex = 5;
            this.lbNOTE.Text = "備註";
            // 
            // txtNOTE
            // 
            this.txtNOTE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOTE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALGROUPBindingSource, "NOTE", true));
            this.txtNOTE.Location = new System.Drawing.Point(86, 59);
            this.txtNOTE.MaxLength = 500;
            this.txtNOTE.Multiline = true;
            this.txtNOTE.Name = "txtNOTE";
            this.tableLayoutPanel1.SetRowSpan(this.txtNOTE, 2);
            this.txtNOTE.Size = new System.Drawing.Size(122, 50);
            this.txtNOTE.TabIndex = 2;
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(86, 115);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(122, 23);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "扣款案例設定";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnMealType
            // 
            this.btnMealType.Location = new System.Drawing.Point(648, 5);
            this.btnMealType.Name = "btnMealType";
            this.btnMealType.Size = new System.Drawing.Size(75, 23);
            this.btnMealType.TabIndex = 7;
            this.btnMealType.TabStop = false;
            this.btnMealType.Text = "餐別設定";
            this.btnMealType.UseVisualStyleBackColor = true;
            this.btnMealType.Click += new System.EventHandler(this.btnMealType_Click);
            // 
            // fdc
            // 
            this.fdc.AllowModifyPrimaryKey = false;
            this.fdc.BindingCtrlsAutoInit = true;
            this.fdc.bnAddEnable = true;
            this.fdc.bnAddVisible = true;
            this.fdc.bnCancelEnable = true;
            this.fdc.bnCancelVisible = true;
            this.fdc.bnDelEnable = true;
            this.fdc.bnDelVisible = true;
            this.fdc.bnEditEnable = true;
            this.fdc.bnEditVisible = true;
            this.fdc.bnExportEnable = true;
            this.fdc.bnExportVisible = true;
            this.fdc.bnQueryEnable = true;
            this.fdc.bnQueryVisible = true;
            this.fdc.bnSaveEnable = true;
            this.fdc.bnSaveVisible = true;
            this.fdc.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fdc.DataAdapter = null;
            this.fdc.DataGrid = this.dgv;
            this.fdc.DataSource = this.mEALGROUPBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(2, 2);
            this.fdc.Name = "fdc";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(628, 73);
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mealGroupCodeDataGridViewTextBoxColumn,
            this.mealGroupDISPDataGridViewTextBoxColumn,
            this.mealGroupNameDataGridViewTextBoxColumn,
            this.nOTEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.mEALGROUPBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(736, 330);
            this.dgv.TabIndex = 7;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // mealGroupCodeDataGridViewTextBoxColumn
            // 
            this.mealGroupCodeDataGridViewTextBoxColumn.DataPropertyName = "MealGroup_Code";
            this.mealGroupCodeDataGridViewTextBoxColumn.HeaderText = "MealGroup_Code";
            this.mealGroupCodeDataGridViewTextBoxColumn.Name = "mealGroupCodeDataGridViewTextBoxColumn";
            this.mealGroupCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mealGroupCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // mealGroupDISPDataGridViewTextBoxColumn
            // 
            this.mealGroupDISPDataGridViewTextBoxColumn.DataPropertyName = "MealGroup_DISP";
            this.mealGroupDISPDataGridViewTextBoxColumn.HeaderText = "用餐群組代碼";
            this.mealGroupDISPDataGridViewTextBoxColumn.Name = "mealGroupDISPDataGridViewTextBoxColumn";
            this.mealGroupDISPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mealGroupNameDataGridViewTextBoxColumn
            // 
            this.mealGroupNameDataGridViewTextBoxColumn.DataPropertyName = "MealGroup_Name";
            this.mealGroupNameDataGridViewTextBoxColumn.HeaderText = "用餐群組名稱";
            this.mealGroupNameDataGridViewTextBoxColumn.Name = "mealGroupNameDataGridViewTextBoxColumn";
            this.mealGroupNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOTEDataGridViewTextBoxColumn
            // 
            this.nOTEDataGridViewTextBoxColumn.DataPropertyName = "NOTE";
            this.nOTEDataGridViewTextBoxColumn.HeaderText = "備註";
            this.nOTEDataGridViewTextBoxColumn.Name = "nOTEDataGridViewTextBoxColumn";
            this.nOTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(736, 561);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 2;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // mealGroupTableAdapter
            // 
            this.mealGroupTableAdapter.ClearBeforeFill = true;
            // 
            // mealCaseSettingTableAdapter
            // 
            this.mealCaseSettingTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2M_Group
            // 
            this.ClientSize = new System.Drawing.Size(736, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM2M_Group";
            this.Text = "FRM2M_Group";
            this.Load += new System.EventHandler(this.FRM2M_Group_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mEALGROUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEALCASESETTINGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label lbName;
        private JBControls.TextBox txtCODE_DISP;
        private JBControls.TextBox txtCODE_Name;
        private System.Windows.Forms.Label lbNOTE;
        private JBControls.FullDataCtrl fdc;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgvSetting;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource mEALGROUPBindingSource;
        private dsAttTableAdapters.MealGroupTableAdapter mealGroupTableAdapter;
        private System.Windows.Forms.BindingSource mEALCASESETTINGBindingSource;
        private dsAttTableAdapters.MealCaseSettingTableAdapter mealCaseSettingTableAdapter;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TextBox txtNOTE;
        private System.Windows.Forms.Button btnMealType;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealSettingCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn applyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn attendDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn oTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eatDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealGroupCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealGroupDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealGroupNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}
