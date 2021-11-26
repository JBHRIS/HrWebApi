namespace JBHR.Sal
{
    partial class FRM46D
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
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mENODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMTBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salbasd1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptxSalcode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtYYMM = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMemo = new JBControls.TextBox();
            this.txtAmt = new JBControls.TextBox();
            this.txtSeq = new JBControls.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.salbasd1TableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALBASD1TableAdapter();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salbasd1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 176;
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
            this.yYMMDataGridViewTextBoxColumn,
            this.sEQDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.mENODataGridViewTextBoxColumn,
            this.aMTBDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.salbasd1BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 176);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "工號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.sEQDataGridViewTextBoxColumn.HeaderText = "期別";
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
            // mENODataGridViewTextBoxColumn
            // 
            this.mENODataGridViewTextBoxColumn.DataPropertyName = "MENO";
            this.mENODataGridViewTextBoxColumn.HeaderText = "備註";
            this.mENODataGridViewTextBoxColumn.Name = "mENODataGridViewTextBoxColumn";
            this.mENODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aMTBDataGridViewTextBoxColumn
            // 
            this.aMTBDataGridViewTextBoxColumn.DataPropertyName = "AMTB";
            this.aMTBDataGridViewTextBoxColumn.HeaderText = "AMTB";
            this.aMTBDataGridViewTextBoxColumn.Name = "aMTBDataGridViewTextBoxColumn";
            this.aMTBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salbasd1BindingSource
            // 
            this.salbasd1BindingSource.DataMember = "salbasd1";
            this.salbasd1BindingSource.DataSource = this.salaryDS;
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
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(626, 261);
            this.splitContainer2.SplitterDistance = 178;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ptxSalcode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtYYMM, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAmt, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 170);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salbasd1BindingSource, "SAL_CODE", true));
            this.ptxSalcode.FormattingEnabled = true;
            this.ptxSalcode.Location = new System.Drawing.Point(62, 87);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.Size = new System.Drawing.Size(121, 20);
            this.ptxSalcode.TabIndex = 3;
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
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "計薪年月";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salbasd1BindingSource, "NOBR", true));
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
            this.ptxNobr.Size = new System.Drawing.Size(100, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.popupTextBox1_QueryCompleted);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = this.label2;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salbasd1BindingSource, "YYMM", true));
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.IsEmpty = false;
            this.txtYYMM.Location = new System.Drawing.Point(62, 31);
            this.txtYYMM.Mask = "";
            this.txtYYMM.MaxLength = 50;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.ShowCalendarButton = true;
            this.txtYYMM.Size = new System.Drawing.Size(73, 22);
            this.txtYYMM.TabIndex = 1;
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.String;
            this.txtYYMM.Validated += new System.EventHandler(this.txtAdate_Validated);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "備註";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(27, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "金額";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "薪資代碼";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(27, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "期別";
            // 
            // txtMemo
            // 
            this.txtMemo.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMemo.CaptionLabel = this.label5;
            this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMemo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salbasd1BindingSource, "MENO", true));
            this.txtMemo.DecimalPlace = 2;
            this.txtMemo.IsEmpty = true;
            this.txtMemo.Location = new System.Drawing.Point(62, 141);
            this.txtMemo.Mask = "";
            this.txtMemo.MaxLength = 50;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ReadOnly = false;
            this.txtMemo.ShowCalendarButton = true;
            this.txtMemo.Size = new System.Drawing.Size(333, 22);
            this.txtMemo.TabIndex = 5;
            this.txtMemo.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtAmt
            // 
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = this.label4;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salbasd1BindingSource, "AMT", true));
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = false;
            this.txtAmt.Location = new System.Drawing.Point(62, 113);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.ShowCalendarButton = true;
            this.txtAmt.Size = new System.Drawing.Size(100, 22);
            this.txtAmt.TabIndex = 4;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = this.label6;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salbasd1BindingSource, "SEQ", true));
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = false;
            this.txtSeq.Location = new System.Drawing.Point(62, 59);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = 50;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(47, 22);
            this.txtSeq.TabIndex = 2;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 178);
            this.panel1.TabIndex = 1;
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
            this.fullDataCtrl1.DataSource = this.salbasd1BindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 3);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,sal_code";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "nobr,sal_code";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterShow);
            // 
            // salbasd1TableAdapter
            // 
            this.salbasd1TableAdapter.ClearBeforeFill = true;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM46D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM46D";
            this.Text = "FRM46D";
            this.Load += new System.EventHandler(this.FRM46A_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salbasd1BindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtYYMM;
        private JBControls.TextBox txtAmt;
        private JBControls.TextBox txtMemo;
        private JBControls.DataGridView dataGridView1;
        private SalaryDS salaryDS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource salbasd1BindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALBASD1TableAdapter salbasd1TableAdapter;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.ComboBox ptxSalcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTBDataGridViewTextBoxColumn;
    }
}