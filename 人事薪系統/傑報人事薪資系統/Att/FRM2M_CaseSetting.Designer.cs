namespace JBHR.Att
{
    partial class FRM2M_CaseSetting
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCode = new System.Windows.Forms.Label();
            this.txtCODE_DISP = new JBControls.TextBox();
            this.mEALCASESETTINGbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.lbNOTE = new System.Windows.Forms.Label();
            this.txtNOTE = new System.Windows.Forms.TextBox();
            this.lbMealType = new System.Windows.Forms.Label();
            this.lbBTime = new System.Windows.Forms.Label();
            this.lbETime = new System.Windows.Forms.Label();
            this.cbxMealType = new System.Windows.Forms.ComboBox();
            this.txtBTime = new System.Windows.Forms.TextBox();
            this.txtETime = new System.Windows.Forms.TextBox();
            this.chkApply = new JBControls.CheckBox();
            this.chkATTEND = new JBControls.CheckBox();
            this.chKOT = new JBControls.CheckBox();
            this.chKEAT = new JBControls.CheckBox();
            this.lbAMT = new System.Windows.Forms.Label();
            this.txtAMT = new JBControls.TextBox();
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.mealSettingCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mealTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.attendDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.oTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eatDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mealCaseSettingTableAdapter = new JBHR.Att.dsAttTableAdapters.MealCaseSettingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mEALCASESETTINGbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(636, 226);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(636, 144);
            this.plFV.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE_DISP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbNOTE, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNOTE, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbMealType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbBTime, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbETime, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxMealType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtETime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkApply, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkATTEND, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chKOT, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.chKEAT, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbAMT, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtAMT, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbCode
            // 
            this.lbCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCode.AutoSize = true;
            this.lbCode.ForeColor = System.Drawing.Color.Red;
            this.lbCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCode.Location = new System.Drawing.Point(24, 8);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(53, 12);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "扣款案例";
            // 
            // txtCODE_DISP
            // 
            this.txtCODE_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE_DISP.CaptionLabel = null;
            this.txtCODE_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALCASESETTINGbindingSource, "MealSettingCode", true));
            this.txtCODE_DISP.DecimalPlace = 2;
            this.txtCODE_DISP.IsEmpty = false;
            this.txtCODE_DISP.Location = new System.Drawing.Point(83, 3);
            this.txtCODE_DISP.Mask = "";
            this.txtCODE_DISP.MaxLength = 50;
            this.txtCODE_DISP.Name = "txtCODE_DISP";
            this.txtCODE_DISP.PasswordChar = '\0';
            this.txtCODE_DISP.ReadOnly = false;
            this.txtCODE_DISP.ShowCalendarButton = true;
            this.txtCODE_DISP.Size = new System.Drawing.Size(122, 22);
            this.txtCODE_DISP.TabIndex = 1;
            this.txtCODE_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // mEALCASESETTINGbindingSource
            // 
            this.mEALCASESETTINGbindingSource.DataMember = "MealCaseSetting";
            this.mEALCASESETTINGbindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbNOTE
            // 
            this.lbNOTE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNOTE.AutoSize = true;
            this.lbNOTE.ForeColor = System.Drawing.Color.Black;
            this.lbNOTE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNOTE.Location = new System.Drawing.Point(48, 120);
            this.lbNOTE.Name = "lbNOTE";
            this.lbNOTE.Size = new System.Drawing.Size(29, 12);
            this.lbNOTE.TabIndex = 4;
            this.lbNOTE.Text = "備註";
            // 
            // txtNOTE
            // 
            this.txtNOTE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOTE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALCASESETTINGbindingSource, "NOTE", true));
            this.txtNOTE.Location = new System.Drawing.Point(83, 115);
            this.txtNOTE.MaxLength = 500;
            this.txtNOTE.Multiline = true;
            this.txtNOTE.Name = "txtNOTE";
            this.txtNOTE.Size = new System.Drawing.Size(154, 22);
            this.txtNOTE.TabIndex = 5;
            // 
            // lbMealType
            // 
            this.lbMealType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMealType.AutoSize = true;
            this.lbMealType.ForeColor = System.Drawing.Color.Red;
            this.lbMealType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMealType.Location = new System.Drawing.Point(48, 36);
            this.lbMealType.Name = "lbMealType";
            this.lbMealType.Size = new System.Drawing.Size(29, 12);
            this.lbMealType.TabIndex = 1;
            this.lbMealType.Text = "餐別";
            // 
            // lbBTime
            // 
            this.lbBTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBTime.AutoSize = true;
            this.lbBTime.ForeColor = System.Drawing.Color.Black;
            this.lbBTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbBTime.Location = new System.Drawing.Point(24, 64);
            this.lbBTime.Name = "lbBTime";
            this.lbBTime.Size = new System.Drawing.Size(53, 12);
            this.lbBTime.TabIndex = 2;
            this.lbBTime.Text = "開始時間";
            // 
            // lbETime
            // 
            this.lbETime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbETime.AutoSize = true;
            this.lbETime.ForeColor = System.Drawing.Color.Black;
            this.lbETime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbETime.Location = new System.Drawing.Point(24, 92);
            this.lbETime.Name = "lbETime";
            this.lbETime.Size = new System.Drawing.Size(53, 12);
            this.lbETime.TabIndex = 3;
            this.lbETime.Text = "結束時間";
            // 
            // cbxMealType
            // 
            this.cbxMealType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxMealType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mEALCASESETTINGbindingSource, "MealType", true));
            this.cbxMealType.FormattingEnabled = true;
            this.cbxMealType.Location = new System.Drawing.Point(83, 32);
            this.cbxMealType.Name = "cbxMealType";
            this.cbxMealType.Size = new System.Drawing.Size(154, 20);
            this.cbxMealType.TabIndex = 2;
            this.cbxMealType.SelectedIndexChanged += new System.EventHandler(this.cbxMealType_SelectedIndexChanged);
            // 
            // txtBTime
            // 
            this.txtBTime.Enabled = false;
            this.txtBTime.Location = new System.Drawing.Point(83, 59);
            this.txtBTime.Name = "txtBTime";
            this.txtBTime.Size = new System.Drawing.Size(70, 22);
            this.txtBTime.TabIndex = 3;
            // 
            // txtETime
            // 
            this.txtETime.Enabled = false;
            this.txtETime.Location = new System.Drawing.Point(83, 87);
            this.txtETime.Name = "txtETime";
            this.txtETime.Size = new System.Drawing.Size(70, 22);
            this.txtETime.TabIndex = 4;
            // 
            // chkApply
            // 
            this.chkApply.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkApply.AutoSize = true;
            this.chkApply.CaptionLabel = null;
            this.chkApply.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mEALCASESETTINGbindingSource, "Apply", true));
            this.chkApply.ForeColor = System.Drawing.Color.Red;
            this.chkApply.IsImitateCaption = true;
            this.chkApply.Location = new System.Drawing.Point(323, 6);
            this.chkApply.Name = "chkApply";
            this.chkApply.Size = new System.Drawing.Size(48, 16);
            this.chkApply.TabIndex = 11;
            this.chkApply.TabStop = false;
            this.chkApply.Text = "報餐";
            this.chkApply.UseVisualStyleBackColor = true;
            // 
            // chkATTEND
            // 
            this.chkATTEND.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkATTEND.AutoSize = true;
            this.chkATTEND.CaptionLabel = null;
            this.chkATTEND.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mEALCASESETTINGbindingSource, "Attend", true));
            this.chkATTEND.ForeColor = System.Drawing.Color.Red;
            this.chkATTEND.IsImitateCaption = true;
            this.chkATTEND.Location = new System.Drawing.Point(323, 34);
            this.chkATTEND.Name = "chkATTEND";
            this.chkATTEND.Size = new System.Drawing.Size(48, 16);
            this.chkATTEND.TabIndex = 12;
            this.chkATTEND.TabStop = false;
            this.chkATTEND.Text = "出勤";
            this.chkATTEND.UseVisualStyleBackColor = true;
            // 
            // chKOT
            // 
            this.chKOT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chKOT.AutoSize = true;
            this.chKOT.CaptionLabel = null;
            this.chKOT.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mEALCASESETTINGbindingSource, "OT", true));
            this.chKOT.ForeColor = System.Drawing.Color.Red;
            this.chKOT.IsImitateCaption = true;
            this.chKOT.Location = new System.Drawing.Point(323, 62);
            this.chKOT.Name = "chKOT";
            this.chKOT.Size = new System.Drawing.Size(48, 16);
            this.chKOT.TabIndex = 13;
            this.chKOT.TabStop = false;
            this.chKOT.Text = "加班";
            this.chKOT.UseVisualStyleBackColor = true;
            // 
            // chKEAT
            // 
            this.chKEAT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chKEAT.AutoSize = true;
            this.chKEAT.CaptionLabel = null;
            this.chKEAT.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mEALCASESETTINGbindingSource, "Eat", true));
            this.chKEAT.ForeColor = System.Drawing.Color.Red;
            this.chKEAT.IsImitateCaption = true;
            this.chKEAT.Location = new System.Drawing.Point(323, 90);
            this.chKEAT.Name = "chKEAT";
            this.chKEAT.Size = new System.Drawing.Size(48, 16);
            this.chKEAT.TabIndex = 14;
            this.chKEAT.TabStop = false;
            this.chKEAT.Text = "用餐";
            this.chKEAT.UseVisualStyleBackColor = true;
            // 
            // lbAMT
            // 
            this.lbAMT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAMT.AutoSize = true;
            this.lbAMT.ForeColor = System.Drawing.Color.Red;
            this.lbAMT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAMT.Location = new System.Drawing.Point(264, 120);
            this.lbAMT.Name = "lbAMT";
            this.lbAMT.Size = new System.Drawing.Size(53, 12);
            this.lbAMT.TabIndex = 5;
            this.lbAMT.Text = "扣款金額";
            // 
            // txtAMT
            // 
            this.txtAMT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAMT.CaptionLabel = null;
            this.txtAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAMT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mEALCASESETTINGbindingSource, "AMT", true));
            this.txtAMT.DecimalPlace = 2;
            this.txtAMT.IsEmpty = true;
            this.txtAMT.Location = new System.Drawing.Point(323, 115);
            this.txtAMT.Mask = "";
            this.txtAMT.MaxLength = -1;
            this.txtAMT.Name = "txtAMT";
            this.txtAMT.PasswordChar = '\0';
            this.txtAMT.ReadOnly = false;
            this.txtAMT.ShowCalendarButton = true;
            this.txtAMT.Size = new System.Drawing.Size(122, 22);
            this.txtAMT.TabIndex = 6;
            this.txtAMT.ValidType = JBControls.TextBox.EValidType.Decimal;
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
            this.fdc.DataSource = this.mEALCASESETTINGbindingSource;
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
            this.mealSettingCodeDataGridViewTextBoxColumn,
            this.mealGroupDataGridViewTextBoxColumn,
            this.mealTypeDataGridViewTextBoxColumn,
            this.applyDataGridViewCheckBoxColumn,
            this.attendDataGridViewCheckBoxColumn,
            this.oTDataGridViewCheckBoxColumn,
            this.eatDataGridViewCheckBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.nOTEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.mEALCASESETTINGbindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(636, 331);
            this.dgv.TabIndex = 0;
            // 
            // mealSettingCodeDataGridViewTextBoxColumn
            // 
            this.mealSettingCodeDataGridViewTextBoxColumn.DataPropertyName = "MealSettingCode";
            this.mealSettingCodeDataGridViewTextBoxColumn.HeaderText = "扣款設定";
            this.mealSettingCodeDataGridViewTextBoxColumn.Name = "mealSettingCodeDataGridViewTextBoxColumn";
            this.mealSettingCodeDataGridViewTextBoxColumn.ReadOnly = true;
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
            // 
            // applyDataGridViewCheckBoxColumn
            // 
            this.applyDataGridViewCheckBoxColumn.DataPropertyName = "Apply";
            this.applyDataGridViewCheckBoxColumn.HeaderText = "報餐";
            this.applyDataGridViewCheckBoxColumn.Name = "applyDataGridViewCheckBoxColumn";
            this.applyDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // attendDataGridViewCheckBoxColumn
            // 
            this.attendDataGridViewCheckBoxColumn.DataPropertyName = "Attend";
            this.attendDataGridViewCheckBoxColumn.HeaderText = "出勤";
            this.attendDataGridViewCheckBoxColumn.Name = "attendDataGridViewCheckBoxColumn";
            this.attendDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // oTDataGridViewCheckBoxColumn
            // 
            this.oTDataGridViewCheckBoxColumn.DataPropertyName = "OT";
            this.oTDataGridViewCheckBoxColumn.HeaderText = "加班";
            this.oTDataGridViewCheckBoxColumn.Name = "oTDataGridViewCheckBoxColumn";
            this.oTDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // eatDataGridViewCheckBoxColumn
            // 
            this.eatDataGridViewCheckBoxColumn.DataPropertyName = "Eat";
            this.eatDataGridViewCheckBoxColumn.HeaderText = "用餐";
            this.eatDataGridViewCheckBoxColumn.Name = "eatDataGridViewCheckBoxColumn";
            this.eatDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "扣款設定";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(636, 561);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 2;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // mealCaseSettingTableAdapter
            // 
            this.mealCaseSettingTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2M_CaseSetting
            // 
            this.ClientSize = new System.Drawing.Size(636, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM2M_CaseSetting";
            this.Text = "FRM2M_CaseSetting";
            this.Load += new System.EventHandler(this.FRM2M_CaseSetting_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mEALCASESETTINGbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label lbNOTE;
        private JBControls.TextBox txtCODE_DISP;
        private JBControls.FullDataCtrl fdc;
        private JBControls.DataGridView dgv;
        private dsAtt dsAtt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtNOTE;
        private System.Windows.Forms.Label lbMealType;
        private System.Windows.Forms.Label lbBTime;
        private System.Windows.Forms.Label lbETime;
        private System.Windows.Forms.ComboBox cbxMealType;
        private System.Windows.Forms.TextBox txtBTime;
        private System.Windows.Forms.TextBox txtETime;
        private JBControls.CheckBox chkApply;
        private JBControls.CheckBox chkATTEND;
        private JBControls.CheckBox chKOT;
        private JBControls.CheckBox chKEAT;
        private System.Windows.Forms.Label lbAMT;
        private JBControls.TextBox txtAMT;
        private System.Windows.Forms.BindingSource mEALCASESETTINGbindingSource;
        private dsAttTableAdapters.MealCaseSettingTableAdapter mealCaseSettingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealSettingCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mealTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn applyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn attendDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn oTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eatDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}
