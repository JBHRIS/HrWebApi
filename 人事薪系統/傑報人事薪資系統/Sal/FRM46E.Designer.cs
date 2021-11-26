namespace JBHR.Sal
{
    partial class FRM46E
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new JBControls.DataGridView();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEMODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMMITEDDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cOMMITTERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sALBASDTMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAmt = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtAdate = new JBControls.TextBox();
            this.ptxSalcode = new JBControls.PopupTextBox();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtMemo = new JBControls.TextBox();
            this.txtChecker = new JBControls.TextBox();
            this.chkCommited = new JBControls.CheckBox();
            this.chkTrans = new JBControls.CheckBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.sALBASD_TMPTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALBASD_TMPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALBASDTMPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(636, 452);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOBRDataGridViewTextBoxColumn,
            this.aDATEDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.mEMODataGridViewTextBoxColumn,
            this.cOMMITEDDataGridViewCheckBoxColumn,
            this.cOMMITTERDataGridViewTextBoxColumn,
            this.tRANSDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.sALBASDTMPBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(636, 194);
            this.dataGridView1.TabIndex = 9;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "生效日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sALCODEDataGridViewTextBoxColumn
            // 
            this.sALCODEDataGridViewTextBoxColumn.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn.HeaderText = "薪資代碼";
            this.sALCODEDataGridViewTextBoxColumn.Name = "sALCODEDataGridViewTextBoxColumn";
            this.sALCODEDataGridViewTextBoxColumn.ReadOnly = true;
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
            // cOMMITEDDataGridViewCheckBoxColumn
            // 
            this.cOMMITEDDataGridViewCheckBoxColumn.DataPropertyName = "COMMITED";
            this.cOMMITEDDataGridViewCheckBoxColumn.HeaderText = "已確認";
            this.cOMMITEDDataGridViewCheckBoxColumn.Name = "cOMMITEDDataGridViewCheckBoxColumn";
            this.cOMMITEDDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // cOMMITTERDataGridViewTextBoxColumn
            // 
            this.cOMMITTERDataGridViewTextBoxColumn.DataPropertyName = "COMMITTER";
            this.cOMMITTERDataGridViewTextBoxColumn.HeaderText = "確認者";
            this.cOMMITTERDataGridViewTextBoxColumn.Name = "cOMMITTERDataGridViewTextBoxColumn";
            this.cOMMITTERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tRANSDataGridViewCheckBoxColumn
            // 
            this.tRANSDataGridViewCheckBoxColumn.DataPropertyName = "TRANS";
            this.tRANSDataGridViewCheckBoxColumn.HeaderText = "已轉換";
            this.tRANSDataGridViewCheckBoxColumn.Name = "tRANSDataGridViewCheckBoxColumn";
            this.tRANSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // sALBASDTMPBindingSource
            // 
            this.sALBASDTMPBindingSource.DataMember = "SALBASD_TMP";
            this.sALBASDTMPBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
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
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(636, 254);
            this.splitContainer2.SplitterDistance = 174;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 174);
            this.panel1.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(538, 138);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(84, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.txtAmt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxSalcode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtChecker, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkCommited, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkTrans, 3, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 170);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtAmt
            // 
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = this.label4;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sALBASDTMPBindingSource, "AMT", true));
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = false;
            this.txtAmt.Location = new System.Drawing.Point(62, 87);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.Size = new System.Drawing.Size(94, 22);
            this.txtAmt.TabIndex = 4;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(27, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "金額";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "生效日期";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "薪資代碼";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "確認者";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sALBASDTMPBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.bASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = false;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(62, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.Size = new System.Drawing.Size(100, 22);
            this.ptxNobr.TabIndex = 1;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // txtAdate
            // 
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = this.label2;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sALBASDTMPBindingSource, "ADATE", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = false;
            this.txtAdate.Location = new System.Drawing.Point(62, 31);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.Size = new System.Drawing.Size(100, 22);
            this.txtAdate.TabIndex = 2;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxSalcode.CaptionLabel = this.label3;
            this.ptxSalcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxSalcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sALBASDTMPBindingSource, "SAL_CODE", true));
            this.ptxSalcode.DataSource = this.sALCODEBindingSource;
            this.ptxSalcode.DisplayMember = "sal_name";
            this.ptxSalcode.IsEmpty = false;
            this.ptxSalcode.IsEmptyToQuery = false;
            this.ptxSalcode.IsMustBeFound = true;
            this.ptxSalcode.LabelText = "";
            this.ptxSalcode.Location = new System.Drawing.Point(62, 59);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.ReadOnly = false;
            this.ptxSalcode.Size = new System.Drawing.Size(41, 22);
            this.ptxSalcode.TabIndex = 3;
            this.ptxSalcode.ValueMember = "sal_code";
            this.ptxSalcode.WhereCmd = "";
            this.ptxSalcode.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxSalcode_QueryCompleted);
            // 
            // sALCODEBindingSource
            // 
            this.sALCODEBindingSource.DataMember = "SALCODE";
            this.sALCODEBindingSource.DataSource = this.salaryDS;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(27, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "備註";
            // 
            // txtMemo
            // 
            this.txtMemo.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMemo.CaptionLabel = this.label6;
            this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemo, 3);
            this.txtMemo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sALBASDTMPBindingSource, "MEMO", true));
            this.txtMemo.DecimalPlace = 2;
            this.txtMemo.IsEmpty = true;
            this.txtMemo.Location = new System.Drawing.Point(62, 143);
            this.txtMemo.Mask = "";
            this.txtMemo.MaxLength = 50;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ReadOnly = false;
            this.txtMemo.Size = new System.Drawing.Size(356, 22);
            this.txtMemo.TabIndex = 5;
            this.txtMemo.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtChecker
            // 
            this.txtChecker.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtChecker.CaptionLabel = this.label5;
            this.txtChecker.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtChecker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sALBASDTMPBindingSource, "COMMITTER", true));
            this.txtChecker.DecimalPlace = 2;
            this.txtChecker.IsEmpty = true;
            this.txtChecker.Location = new System.Drawing.Point(62, 115);
            this.txtChecker.Mask = "";
            this.txtChecker.MaxLength = 50;
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.PasswordChar = '\0';
            this.txtChecker.ReadOnly = false;
            this.txtChecker.Size = new System.Drawing.Size(100, 22);
            this.txtChecker.TabIndex = 2;
            this.txtChecker.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // chkCommited
            // 
            this.chkCommited.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCommited.AutoSize = true;
            this.chkCommited.CaptionLabel = null;
            this.chkCommited.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sALBASDTMPBindingSource, "COMMITED", true));
            this.chkCommited.IsImitateCaption = true;
            this.chkCommited.Location = new System.Drawing.Point(168, 118);
            this.chkCommited.Name = "chkCommited";
            this.chkCommited.Size = new System.Drawing.Size(60, 16);
            this.chkCommited.TabIndex = 6;
            this.chkCommited.Text = "已確認";
            this.chkCommited.UseVisualStyleBackColor = true;
            // 
            // chkTrans
            // 
            this.chkTrans.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTrans.AutoSize = true;
            this.chkTrans.CaptionLabel = null;
            this.chkTrans.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sALBASDTMPBindingSource, "TRANS", true));
            this.chkTrans.IsImitateCaption = true;
            this.chkTrans.Location = new System.Drawing.Point(244, 118);
            this.chkTrans.Name = "chkTrans";
            this.chkTrans.Size = new System.Drawing.Size(60, 16);
            this.chkTrans.TabIndex = 6;
            this.chkTrans.Text = "已轉換";
            this.chkTrans.UseVisualStyleBackColor = true;
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
            this.fullDataCtrl1.DataSource = null;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "adate,nobr,sal_code,meno";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(636, 73);
            this.fullDataCtrl1.SortFields = "adate,nobr,sal_code,meno";
            this.fullDataCtrl1.TabIndex = 3;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterShow);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // sALBASD_TMPTableAdapter
            // 
            this.sALBASD_TMPTableAdapter.ClearBeforeFill = true;
            // 
            // FRM46E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 452);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM46E";
            this.Text = "FRM46E";
            this.Load += new System.EventHandler(this.FRM46_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALBASDTMPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtAmt;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtAdate;
        private JBControls.TextBox txtMemo;
        private JBControls.PopupTextBox ptxSalcode;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource sALBASDTMPBindingSource;
        private SalaryDSTableAdapters.SALBASD_TMPTableAdapter sALBASD_TMPTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cOMMITEDDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMMITTERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tRANSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox txtChecker;
        private JBControls.CheckBox chkCommited;
        private JBControls.CheckBox chkTrans;
    }
}