namespace JBHR.Sal
{
    partial class FRM46C
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
            this.wAGEDDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptxSalcode = new System.Windows.Forms.ComboBox();
            this.ptxDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtYymm = new JBControls.TextBox();
            this.txtSeq = new JBControls.TextBox();
            this.txtAmt = new JBControls.TextBox();
            this.ptxAcno = new JBControls.PopupTextBox();
            this.sALBASNDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDS = new JBHR.Sal.BaseDS();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dEPTTableAdapter = new JBHR.Sal.BaseDSTableAdapters.DEPTTableAdapter();
            this.wAGEDDTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.WAGEDDTableAdapter();
            this.sALBASNDTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALBASNDTableAdapter();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.basDS = new JBHR.Bas.BasDS();
            this.dEPTTableAdapter1 = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wAGEDDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALBASNDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 160;
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
            this.dNODataGridViewTextBoxColumn,
            this.dNAMEDataGridViewTextBoxColumn,
            this.sALNAMEDataGridViewTextBoxColumn,
            this.yYMMDataGridViewTextBoxColumn,
            this.sEQDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.aCNODataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.wAGEDDBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(626, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // wAGEDDBindingSource
            // 
            this.wAGEDDBindingSource.DataMember = "WAGEDD";
            this.wAGEDDBindingSource.DataSource = this.salaryDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 277);
            this.splitContainer2.SplitterDistance = 198;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 198);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ptxSalcode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptxDept, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtYymm, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAmt, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.ptxAcno, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 195);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.wAGEDDBindingSource, "SAL_CODE", true));
            this.ptxSalcode.FormattingEnabled = true;
            this.ptxSalcode.Location = new System.Drawing.Point(62, 113);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.Size = new System.Drawing.Size(121, 20);
            this.ptxSalcode.TabIndex = 4;
            // 
            // ptxDept
            // 
            this.ptxDept.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.wAGEDDBindingSource, "D_NO", true));
            this.ptxDept.Enabled = false;
            this.ptxDept.FormattingEnabled = true;
            this.ptxDept.Location = new System.Drawing.Point(62, 31);
            this.ptxDept.Name = "ptxDept";
            this.ptxDept.Size = new System.Drawing.Size(121, 20);
            this.ptxDept.TabIndex = 1;
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
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "部門";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "計薪年月";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "計薪期別";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "薪資代碼";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(27, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "編碼";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(27, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "金額";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEDDBindingSource, "NOBR", true));
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("LabelText", this.wAGEDDBindingSource, "NAME_C", true));
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
            // txtYymm
            // 
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = this.label3;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEDDBindingSource, "YYMM", true));
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = false;
            this.txtYymm.Location = new System.Drawing.Point(62, 57);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = 50;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(75, 22);
            this.txtYymm.TabIndex = 2;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = this.label4;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEDDBindingSource, "SEQ", true));
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = false;
            this.txtSeq.Location = new System.Drawing.Point(62, 85);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = 50;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(50, 22);
            this.txtSeq.TabIndex = 3;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtAmt
            // 
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = this.label7;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEDDBindingSource, "AMT", true));
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = false;
            this.txtAmt.Location = new System.Drawing.Point(62, 167);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.ShowCalendarButton = true;
            this.txtAmt.Size = new System.Drawing.Size(100, 22);
            this.txtAmt.TabIndex = 6;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // ptxAcno
            // 
            this.ptxAcno.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxAcno.CaptionLabel = null;
            this.ptxAcno.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxAcno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEDDBindingSource, "ACNO", true));
            this.ptxAcno.DataSource = this.sALBASNDBindingSource;
            this.ptxAcno.DisplayMember = "de_dept";
            this.ptxAcno.IsEmpty = true;
            this.ptxAcno.IsEmptyToQuery = true;
            this.ptxAcno.IsMustBeFound = true;
            this.ptxAcno.LabelText = "";
            this.ptxAcno.Location = new System.Drawing.Point(62, 139);
            this.ptxAcno.Name = "ptxAcno";
            this.ptxAcno.QueryFields = "yymm_b,yymm_e,sal_code";
            this.ptxAcno.ReadOnly = false;
            this.ptxAcno.ShowDisplayName = true;
            this.ptxAcno.Size = new System.Drawing.Size(100, 22);
            this.ptxAcno.TabIndex = 5;
            this.ptxAcno.ValueMember = "acno";
            this.ptxAcno.WhereCmd = "";
            this.ptxAcno.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxAcno_QueryCompleted);
            // 
            // sALBASNDBindingSource
            // 
            this.sALBASNDBindingSource.DataMember = "SALBASND";
            this.sALBASNDBindingSource.DataSource = this.salaryDS;
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
            this.fullDataCtrl1.DataSource = this.wAGEDDBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(7, 2);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,yymm,sal_code,acno,name_c";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "nobr,yymm,sal_code,acno,sal_name";
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
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.basDS;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "BaseDS";
            this.baseDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sALCODEBindingSource
            // 
            this.sALCODEBindingSource.DataMember = "SALCODE";
            this.sALCODEBindingSource.DataSource = this.salaryDS;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.wAGEDDBindingSource;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // wAGEDDTableAdapter
            // 
            this.wAGEDDTableAdapter.ClearBeforeFill = true;
            // 
            // sALBASNDTableAdapter
            // 
            this.sALBASNDTableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEPTTableAdapter1
            // 
            this.dEPTTableAdapter1.ClearBeforeFill = true;
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
            // dNODataGridViewTextBoxColumn
            // 
            this.dNODataGridViewTextBoxColumn.DataPropertyName = "D_NO";
            this.dNODataGridViewTextBoxColumn.DataSource = this.dEPTBindingSource;
            this.dNODataGridViewTextBoxColumn.DisplayMember = "D_NO_DISP";
            this.dNODataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dNODataGridViewTextBoxColumn.HeaderText = "部門編號";
            this.dNODataGridViewTextBoxColumn.Name = "dNODataGridViewTextBoxColumn";
            this.dNODataGridViewTextBoxColumn.ReadOnly = true;
            this.dNODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dNODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dNODataGridViewTextBoxColumn.ValueMember = "D_NO";
            // 
            // dNAMEDataGridViewTextBoxColumn
            // 
            this.dNAMEDataGridViewTextBoxColumn.DataPropertyName = "D_NAME";
            this.dNAMEDataGridViewTextBoxColumn.HeaderText = "部門名稱";
            this.dNAMEDataGridViewTextBoxColumn.Name = "dNAMEDataGridViewTextBoxColumn";
            this.dNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sALNAMEDataGridViewTextBoxColumn
            // 
            this.sALNAMEDataGridViewTextBoxColumn.DataPropertyName = "SAL_NAME";
            this.sALNAMEDataGridViewTextBoxColumn.HeaderText = "薪資名稱";
            this.sALNAMEDataGridViewTextBoxColumn.Name = "sALNAMEDataGridViewTextBoxColumn";
            this.sALNAMEDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.sEQDataGridViewTextBoxColumn.HeaderText = "計薪期別";
            this.sEQDataGridViewTextBoxColumn.Name = "sEQDataGridViewTextBoxColumn";
            this.sEQDataGridViewTextBoxColumn.ReadOnly = true;
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
            // aCNODataGridViewTextBoxColumn
            // 
            this.aCNODataGridViewTextBoxColumn.DataPropertyName = "ACNO";
            this.aCNODataGridViewTextBoxColumn.HeaderText = "編碼";
            this.aCNODataGridViewTextBoxColumn.Name = "aCNODataGridViewTextBoxColumn";
            this.aCNODataGridViewTextBoxColumn.ReadOnly = true;
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
            // FRM46C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM46C";
            this.Text = "FRM46C";
            this.Load += new System.EventHandler(this.FRM46C_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wAGEDDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALBASNDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtYymm;
        private JBControls.TextBox txtSeq;
        private JBControls.TextBox txtAmt;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource wAGEDDBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.WAGEDDTableAdapter wAGEDDTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.PopupTextBox ptxAcno;
        private System.Windows.Forms.BindingSource sALBASNDBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALBASNDTableAdapter sALBASNDTableAdapter;
        private BaseDS baseDS;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Sal.BaseDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.ComboBox ptxDept;
        protected System.Windows.Forms.ComboBox ptxSalcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dNODataGridViewTextBoxColumn;
        private Bas.BasDS basDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private Bas.BasDSTableAdapters.DEPTTableAdapter dEPTTableAdapter1;
    }
}