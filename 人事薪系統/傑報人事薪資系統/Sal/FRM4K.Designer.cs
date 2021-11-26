namespace JBHR.Sal
{
    partial class FRM4K
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
            this.dataGridView1 = new JBControls.DataGridView();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.sALNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEMODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fAIDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SalENRICHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFA_IDNO = new System.Windows.Forms.ComboBox();
            this.txtSQ = new JBControls.TextBox();
            this.txtYM = new JBControls.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptxSalcode = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtYymm = new JBControls.TextBox();
            this.txtSeq = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtAmt = new JBControls.TextBox();
            this.txtMemo = new JBControls.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.sALCODEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.extDS = new JBHR.Ins.extDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eNRICHTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.ENRICHTableAdapter();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.fAMILYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sALCODETableAdapter1 = new JBHR.Ins.extDSTableAdapters.SALCODETableAdapter();
            this.fAMILYTableAdapter = new JBHR.Ins.extDSTableAdapters.FAMILYTableAdapter();
            this.sALENRICHTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALENRICHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalENRICHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(813, 452);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOBRDataGridViewTextBoxColumn,
            this.nAMECDataGridViewTextBoxColumn,
            this.yYMMDataGridViewTextBoxColumn,
            this.sEQDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.sALNAMEDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.mEMODataGridViewTextBoxColumn,
            this.fAIDNODataGridViewTextBoxColumn,
            this.iMPORTDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.SalENRICHBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(813, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nAMECDataGridViewTextBoxColumn
            // 
            this.nAMECDataGridViewTextBoxColumn.DataPropertyName = "NAME_C";
            this.nAMECDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nAMECDataGridViewTextBoxColumn.Name = "nAMECDataGridViewTextBoxColumn";
            this.nAMECDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "計薪年月";
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sEQDataGridViewTextBoxColumn
            // 
            this.sEQDataGridViewTextBoxColumn.DataPropertyName = "SEQ";
            this.sEQDataGridViewTextBoxColumn.HeaderText = "期數";
            this.sEQDataGridViewTextBoxColumn.Name = "sEQDataGridViewTextBoxColumn";
            this.sEQDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sALCODEDataGridViewTextBoxColumn
            // 
            this.sALCODEDataGridViewTextBoxColumn.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn.DataSource = this.sALCODEBindingSource;
            this.sALCODEDataGridViewTextBoxColumn.DisplayMember = "SAL_CODE_DISP";
            this.sALCODEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sALCODEDataGridViewTextBoxColumn.HeaderText = "薪資代碼";
            this.sALCODEDataGridViewTextBoxColumn.Name = "sALCODEDataGridViewTextBoxColumn";
            this.sALCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sALCODEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sALCODEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sALCODEDataGridViewTextBoxColumn.ValueMember = "SAL_CODE";
            // 
            // sALCODEBindingSource
            // 
            this.sALCODEBindingSource.DataMember = "SALCODE";
            this.sALCODEBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sALNAMEDataGridViewTextBoxColumn
            // 
            this.sALNAMEDataGridViewTextBoxColumn.DataPropertyName = "SAL_NAME";
            this.sALNAMEDataGridViewTextBoxColumn.HeaderText = "薪資名稱";
            this.sALNAMEDataGridViewTextBoxColumn.Name = "sALNAMEDataGridViewTextBoxColumn";
            this.sALNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sALNAMEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
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
            // mEMODataGridViewTextBoxColumn
            // 
            this.mEMODataGridViewTextBoxColumn.DataPropertyName = "MEMO";
            this.mEMODataGridViewTextBoxColumn.HeaderText = "備註";
            this.mEMODataGridViewTextBoxColumn.Name = "mEMODataGridViewTextBoxColumn";
            this.mEMODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fAIDNODataGridViewTextBoxColumn
            // 
            this.fAIDNODataGridViewTextBoxColumn.DataPropertyName = "FA_IDNO";
            this.fAIDNODataGridViewTextBoxColumn.HeaderText = "眷屬身號";
            this.fAIDNODataGridViewTextBoxColumn.Name = "fAIDNODataGridViewTextBoxColumn";
            this.fAIDNODataGridViewTextBoxColumn.ReadOnly = true;
            this.fAIDNODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // iMPORTDataGridViewCheckBoxColumn
            // 
            this.iMPORTDataGridViewCheckBoxColumn.DataPropertyName = "IMPORT";
            this.iMPORTDataGridViewCheckBoxColumn.HeaderText = "匯入";
            this.iMPORTDataGridViewCheckBoxColumn.Name = "iMPORTDataGridViewCheckBoxColumn";
            this.iMPORTDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // SalENRICHBindingSource
            // 
            this.SalENRICHBindingSource.DataMember = "SALENRICH";
            this.SalENRICHBindingSource.DataSource = this.salaryDS;
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
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblSum);
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(813, 240);
            this.splitContainer2.SplitterDistance = 156;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbFA_IDNO);
            this.panel1.Controls.Add(this.txtSQ);
            this.panel1.Controls.Add(this.txtYM);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 156);
            this.panel1.TabIndex = 0;
            // 
            // cbFA_IDNO
            // 
            this.cbFA_IDNO.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SalENRICHBindingSource, "FA_IDNO", true));
            this.cbFA_IDNO.FormattingEnabled = true;
            this.cbFA_IDNO.Location = new System.Drawing.Point(376, 6);
            this.cbFA_IDNO.Name = "cbFA_IDNO";
            this.cbFA_IDNO.Size = new System.Drawing.Size(167, 20);
            this.cbFA_IDNO.TabIndex = 11;
            this.cbFA_IDNO.Visible = false;
            // 
            // txtSQ
            // 
            this.txtSQ.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSQ.CaptionLabel = null;
            this.txtSQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSQ.DecimalPlace = 2;
            this.txtSQ.IsEmpty = true;
            this.txtSQ.Location = new System.Drawing.Point(503, 120);
            this.txtSQ.Mask = "";
            this.txtSQ.MaxLength = 2;
            this.txtSQ.Name = "txtSQ";
            this.txtSQ.PasswordChar = '\0';
            this.txtSQ.ReadOnly = false;
            this.txtSQ.ShowCalendarButton = true;
            this.txtSQ.Size = new System.Drawing.Size(35, 22);
            this.txtSQ.TabIndex = 10;
            this.txtSQ.TabStop = false;
            this.txtSQ.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // txtYM
            // 
            this.txtYM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYM.CaptionLabel = null;
            this.txtYM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYM.DecimalPlace = 2;
            this.txtYM.IsEmpty = true;
            this.txtYM.Location = new System.Drawing.Point(444, 120);
            this.txtYM.Mask = "";
            this.txtYM.MaxLength = 0;
            this.txtYM.Name = "txtYM";
            this.txtYM.PasswordChar = '\0';
            this.txtYM.ReadOnly = false;
            this.txtYM.ShowCalendarButton = true;
            this.txtYM.Size = new System.Drawing.Size(53, 22);
            this.txtYM.TabIndex = 10;
            this.txtYM.TabStop = false;
            this.txtYM.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(544, 118);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(85, 25);
            this.btnChange.TabIndex = 9;
            this.btnChange.TabStop = false;
            this.btnChange.Text = "更換年月期別";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(544, 88);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(85, 25);
            this.btnImport.TabIndex = 8;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(320, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "眷屬身號";
            this.label6.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ptxSalcode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAmt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SalENRICHBindingSource, "SAL_CODE", true));
            this.ptxSalcode.FormattingEnabled = true;
            this.ptxSalcode.Location = new System.Drawing.Point(62, 66);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.Size = new System.Drawing.Size(121, 20);
            this.ptxSalcode.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtYymm);
            this.flowLayoutPanel1.Controls.Add(this.txtSeq);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(62, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(241, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // txtYymm
            // 
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = null;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SalENRICHBindingSource, "YYMM", true));
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = false;
            this.txtYymm.Location = new System.Drawing.Point(3, 3);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = 50;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(65, 22);
            this.txtYymm.TabIndex = 2;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = null;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SalENRICHBindingSource, "SEQ", true));
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = false;
            this.txtSeq.Location = new System.Drawing.Point(74, 3);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = 50;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(40, 22);
            this.txtSeq.TabIndex = 3;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            this.txtSeq.Validated += new System.EventHandler(this.txtSeq_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "計薪年月";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "薪資代碼";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(27, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "金額";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "備註";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SalENRICHBindingSource, "NOBR", true));
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("LabelText", this.SalENRICHBindingSource, "NAME_C", true));
            this.ptxNobr.DataSource = this.bASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(62, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(68, 22);
            this.ptxNobr.TabIndex = 1;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            this.ptxNobr.Validated += new System.EventHandler(this.ptxNobr_Validated);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // txtAmt
            // 
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = this.label4;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SalENRICHBindingSource, "AMT", true));
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = false;
            this.txtAmt.Location = new System.Drawing.Point(62, 92);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.ShowCalendarButton = true;
            this.txtAmt.Size = new System.Drawing.Size(100, 22);
            this.txtAmt.TabIndex = 5;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // txtMemo
            // 
            this.txtMemo.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMemo.CaptionLabel = this.label5;
            this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMemo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SalENRICHBindingSource, "MEMO", true));
            this.txtMemo.DecimalPlace = 2;
            this.txtMemo.IsEmpty = true;
            this.txtMemo.Location = new System.Drawing.Point(62, 120);
            this.txtMemo.Mask = "";
            this.txtMemo.MaxLength = 120;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ReadOnly = false;
            this.txtMemo.ShowCalendarButton = true;
            this.txtMemo.Size = new System.Drawing.Size(235, 22);
            this.txtMemo.TabIndex = 6;
            this.txtMemo.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(647, 12);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(0, 12);
            this.lblSum.TabIndex = 1;
            // 
            // fullDataCtrl1
            // 
            this.fullDataCtrl1.AllowModifyPrimaryKey = false;
            this.fullDataCtrl1.BindingCtrlsAutoInit = true;
            this.fullDataCtrl1.bnAddEnable = true;
            this.fullDataCtrl1.bnAddVisible = true;
            this.fullDataCtrl1.bnCancelEnable = true;
            this.fullDataCtrl1.bnCancelVisible = true;
            this.fullDataCtrl1.bnDelEnable = true;
            this.fullDataCtrl1.bnDelVisible = true;
            this.fullDataCtrl1.bnEditEnable = true;
            this.fullDataCtrl1.bnEditVisible = true;
            this.fullDataCtrl1.bnExportEnable = true;
            this.fullDataCtrl1.bnExportVisible = true;
            this.fullDataCtrl1.bnQueryEnable = true;
            this.fullDataCtrl1.bnQueryVisible = true;
            this.fullDataCtrl1.bnSaveEnable = true;
            this.fullDataCtrl1.bnSaveVisible = true;
            this.fullDataCtrl1.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fullDataCtrl1.DataAdapter = null;
            this.fullDataCtrl1.DataGrid = this.dataGridView1;
            this.fullDataCtrl1.DataSource = this.SalENRICHBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(7, 5);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,yymm,seq,sal_code,memo,import";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "nobr,yymm,seq,sal_code,memo,import";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterShow);
            // 
            // sALCODEBindingSource1
            // 
            this.sALCODEBindingSource1.DataMember = "SALCODE";
            this.sALCODEBindingSource1.DataSource = this.extDS;
            // 
            // extDS
            // 
            this.extDS.DataSetName = "extDS";
            this.extDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.extDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // eNRICHTableAdapter
            // 
            this.eNRICHTableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // fAMILYBindingSource
            // 
            this.fAMILYBindingSource.DataMember = "FAMILY";
            this.fAMILYBindingSource.DataSource = this.extDS;
            // 
            // sALCODETableAdapter1
            // 
            this.sALCODETableAdapter1.ClearBeforeFill = true;
            // 
            // fAMILYTableAdapter
            // 
            this.fAMILYTableAdapter.ClearBeforeFill = true;
            // 
            // sALENRICHTableAdapter
            // 
            this.sALENRICHTableAdapter.ClearBeforeFill = true;
            // 
            // FRM4K
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 452);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM4K";
            this.Text = "FRM4K";
            this.Load += new System.EventHandler(this.FRM4K_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalENRICHBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILYBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.Panel panel1;
        private JBControls.DataGridView dataGridView1;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource SalENRICHBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.ENRICHTableAdapter eNRICHTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private JBControls.TextBox txtYymm;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtAmt;
        private JBControls.TextBox txtMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.TextBox txtYM;
        private System.Windows.Forms.Button btnChange;
        private JBControls.TextBox txtSQ;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.ComboBox ptxSalcode;
        private Ins.extDS extDS;
        private System.Windows.Forms.BindingSource sALCODEBindingSource1;
        private Ins.extDSTableAdapters.SALCODETableAdapter sALCODETableAdapter1;
        private System.Windows.Forms.ComboBox cbFA_IDNO;
        private System.Windows.Forms.BindingSource fAMILYBindingSource;
        private Ins.extDSTableAdapters.FAMILYTableAdapter fAMILYTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fAIDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iMPORTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btnImport;
        private SalaryDSTableAdapters.SALENRICHTableAdapter sALENRICHTableAdapter;
    }
}