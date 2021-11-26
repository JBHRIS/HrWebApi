namespace JBHR.Att
{
    partial class FRM2P
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
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUGHRSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBSHRSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aBSPREBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTrans = new System.Windows.Forms.Button();
            this.btnMultiOperation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxHcode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTrans = new JBControls.CheckBox();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.txtAdate = new JBControls.TextBox();
            this.txtBtime = new JBControls.TextBox();
            this.txtEtime = new JBControls.TextBox();
            this.txtSugHrs = new JBControls.TextBox();
            this.txtAbsHrs = new JBControls.TextBox();
            this.txtYymm = new JBControls.TextBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.hCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.aBSPRETableAdapter = new JBHR.Att.dsAttTableAdapters.ABSPRETableAdapter();
            this.hCODETableAdapter = new JBHR.Att.dsAttTableAdapters.HCODETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBSPREBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 239;
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
            this.aDATEDataGridViewTextBoxColumn,
            this.bTIMEDataGridViewTextBoxColumn,
            this.hCODEDataGridViewTextBoxColumn,
            this.hNAMEDataGridViewTextBoxColumn,
            this.eTIMEDataGridViewTextBoxColumn,
            this.sUGHRSDataGridViewTextBoxColumn,
            this.aBSHRSDataGridViewTextBoxColumn,
            this.DDATE,
            this.tRANSDataGridViewCheckBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.yYMMDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aBSPREBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 239);
            this.dataGridView1.TabIndex = 0;
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
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "請假日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bTIMEDataGridViewTextBoxColumn
            // 
            this.bTIMEDataGridViewTextBoxColumn.DataPropertyName = "BTIME";
            this.bTIMEDataGridViewTextBoxColumn.HeaderText = "請假時間";
            this.bTIMEDataGridViewTextBoxColumn.Name = "bTIMEDataGridViewTextBoxColumn";
            this.bTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hCODEDataGridViewTextBoxColumn
            // 
            this.hCODEDataGridViewTextBoxColumn.DataPropertyName = "H_CODE";
            this.hCODEDataGridViewTextBoxColumn.HeaderText = "假別代碼";
            this.hCODEDataGridViewTextBoxColumn.Name = "hCODEDataGridViewTextBoxColumn";
            this.hCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hNAMEDataGridViewTextBoxColumn
            // 
            this.hNAMEDataGridViewTextBoxColumn.DataPropertyName = "H_NAME";
            this.hNAMEDataGridViewTextBoxColumn.HeaderText = "假別名稱";
            this.hNAMEDataGridViewTextBoxColumn.Name = "hNAMEDataGridViewTextBoxColumn";
            this.hNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eTIMEDataGridViewTextBoxColumn
            // 
            this.eTIMEDataGridViewTextBoxColumn.DataPropertyName = "ETIME";
            this.eTIMEDataGridViewTextBoxColumn.HeaderText = "假迄時間";
            this.eTIMEDataGridViewTextBoxColumn.Name = "eTIMEDataGridViewTextBoxColumn";
            this.eTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sUGHRSDataGridViewTextBoxColumn
            // 
            this.sUGHRSDataGridViewTextBoxColumn.DataPropertyName = "SUG_HRS";
            this.sUGHRSDataGridViewTextBoxColumn.HeaderText = "建議時數";
            this.sUGHRSDataGridViewTextBoxColumn.Name = "sUGHRSDataGridViewTextBoxColumn";
            this.sUGHRSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aBSHRSDataGridViewTextBoxColumn
            // 
            this.aBSHRSDataGridViewTextBoxColumn.DataPropertyName = "ABS_HRS";
            this.aBSHRSDataGridViewTextBoxColumn.HeaderText = "請假時數";
            this.aBSHRSDataGridViewTextBoxColumn.Name = "aBSHRSDataGridViewTextBoxColumn";
            this.aBSHRSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DDATE
            // 
            this.DDATE.DataPropertyName = "DDATE";
            this.DDATE.HeaderText = "失效日期";
            this.DDATE.Name = "DDATE";
            this.DDATE.ReadOnly = true;
            // 
            // tRANSDataGridViewCheckBoxColumn
            // 
            this.tRANSDataGridViewCheckBoxColumn.DataPropertyName = "TRANS";
            this.tRANSDataGridViewCheckBoxColumn.HeaderText = "已轉換";
            this.tRANSDataGridViewCheckBoxColumn.Name = "tRANSDataGridViewCheckBoxColumn";
            this.tRANSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "薪資年月";
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aBSPREBindingSource
            // 
            this.aBSPREBindingSource.DataMember = "ABSPRE";
            this.aBSPREBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 198);
            this.splitContainer2.SplitterDistance = 116;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnTrans);
            this.panel1.Controls.Add(this.btnMultiOperation);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 116);
            this.panel1.TabIndex = 0;
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(506, 87);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(104, 23);
            this.btnTrans.TabIndex = 2;
            this.btnTrans.TabStop = false;
            this.btnTrans.Text = "轉換";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // btnMultiOperation
            // 
            this.btnMultiOperation.Location = new System.Drawing.Point(506, 60);
            this.btnMultiOperation.Name = "btnMultiOperation";
            this.btnMultiOperation.Size = new System.Drawing.Size(106, 23);
            this.btnMultiOperation.TabIndex = 1;
            this.btnMultiOperation.TabStop = false;
            this.btnMultiOperation.Text = "產生請假";
            this.btnMultiOperation.UseVisualStyleBackColor = true;
            this.btnMultiOperation.Click += new System.EventHandler(this.btnMultiOperation_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.83007F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.16993F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel1.Controls.Add(this.cbxHcode, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkTrans, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBtime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEtime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSugHrs, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAbsHrs, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtYymm, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 108);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbxHcode
            // 
            this.cbxHcode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aBSPREBindingSource, "H_CODE", true));
            this.cbxHcode.FormattingEnabled = true;
            this.cbxHcode.Location = new System.Drawing.Point(356, 57);
            this.cbxHcode.Name = "cbxHcode";
            this.cbxHcode.Size = new System.Drawing.Size(121, 20);
            this.cbxHcode.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "請假日期";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(163, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "薪資年月";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "請假時間";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "假迄時間";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(297, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "建議時數";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(297, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "請假時數";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(297, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "假別代碼";
            // 
            // chkTrans
            // 
            this.chkTrans.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTrans.AutoSize = true;
            this.chkTrans.CaptionLabel = null;
            this.chkTrans.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.aBSPREBindingSource, "TRANS", true));
            this.chkTrans.IsImitateCaption = true;
            this.chkTrans.Location = new System.Drawing.Point(356, 86);
            this.chkTrans.Name = "chkTrans";
            this.chkTrans.Size = new System.Drawing.Size(60, 16);
            this.chkTrans.TabIndex = 8;
            this.chkTrans.TabStop = false;
            this.chkTrans.Text = "已轉換";
            this.chkTrans.UseVisualStyleBackColor = true;
            // 
            // ptxNobr
            // 
            this.ptxNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = null;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.bASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = true;
            this.ptxNobr.IsEmptyToQuery = false;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(69, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(65, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtAdate
            // 
            this.txtAdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = null;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "ADATE", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = true;
            this.txtAdate.Location = new System.Drawing.Point(69, 30);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.Size = new System.Drawing.Size(73, 22);
            this.txtAdate.TabIndex = 1;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtAdate.Validated += new System.EventHandler(this.txtAdate_Validated);
            // 
            // txtBtime
            // 
            this.txtBtime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBtime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBtime.CaptionLabel = null;
            this.txtBtime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBtime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "BTIME", true));
            this.txtBtime.DecimalPlace = 2;
            this.txtBtime.IsEmpty = true;
            this.txtBtime.Location = new System.Drawing.Point(69, 57);
            this.txtBtime.Mask = "0000";
            this.txtBtime.MaxLength = 50;
            this.txtBtime.Name = "txtBtime";
            this.txtBtime.PasswordChar = '\0';
            this.txtBtime.ReadOnly = false;
            this.txtBtime.ShowCalendarButton = true;
            this.txtBtime.Size = new System.Drawing.Size(49, 22);
            this.txtBtime.TabIndex = 3;
            this.txtBtime.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtEtime
            // 
            this.txtEtime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEtime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEtime.CaptionLabel = null;
            this.txtEtime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEtime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "ETIME", true));
            this.txtEtime.DecimalPlace = 2;
            this.txtEtime.IsEmpty = true;
            this.txtEtime.Location = new System.Drawing.Point(69, 84);
            this.txtEtime.Mask = "0000";
            this.txtEtime.MaxLength = 50;
            this.txtEtime.Name = "txtEtime";
            this.txtEtime.PasswordChar = '\0';
            this.txtEtime.ReadOnly = false;
            this.txtEtime.ShowCalendarButton = true;
            this.txtEtime.Size = new System.Drawing.Size(49, 22);
            this.txtEtime.TabIndex = 4;
            this.txtEtime.ValidType = JBControls.TextBox.EValidType.String;
            this.txtEtime.Validated += new System.EventHandler(this.txtEtime_Validated);
            // 
            // txtSugHrs
            // 
            this.txtSugHrs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSugHrs.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSugHrs.CaptionLabel = null;
            this.txtSugHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSugHrs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "SUG_HRS", true));
            this.txtSugHrs.DecimalPlace = 2;
            this.txtSugHrs.Enabled = false;
            this.txtSugHrs.IsEmpty = true;
            this.txtSugHrs.Location = new System.Drawing.Point(356, 3);
            this.txtSugHrs.Mask = "";
            this.txtSugHrs.MaxLength = -1;
            this.txtSugHrs.Name = "txtSugHrs";
            this.txtSugHrs.PasswordChar = '\0';
            this.txtSugHrs.ReadOnly = false;
            this.txtSugHrs.ShowCalendarButton = true;
            this.txtSugHrs.Size = new System.Drawing.Size(41, 22);
            this.txtSugHrs.TabIndex = 5;
            this.txtSugHrs.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // txtAbsHrs
            // 
            this.txtAbsHrs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAbsHrs.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAbsHrs.CaptionLabel = null;
            this.txtAbsHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAbsHrs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "ABS_HRS", true));
            this.txtAbsHrs.DecimalPlace = 2;
            this.txtAbsHrs.IsEmpty = true;
            this.txtAbsHrs.Location = new System.Drawing.Point(356, 30);
            this.txtAbsHrs.Mask = "";
            this.txtAbsHrs.MaxLength = -1;
            this.txtAbsHrs.Name = "txtAbsHrs";
            this.txtAbsHrs.PasswordChar = '\0';
            this.txtAbsHrs.ReadOnly = false;
            this.txtAbsHrs.ShowCalendarButton = true;
            this.txtAbsHrs.Size = new System.Drawing.Size(41, 22);
            this.txtAbsHrs.TabIndex = 6;
            this.txtAbsHrs.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // txtYymm
            // 
            this.txtYymm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = null;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aBSPREBindingSource, "YYMM", true));
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = true;
            this.txtYymm.Location = new System.Drawing.Point(222, 30);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = 50;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(54, 22);
            this.txtYymm.TabIndex = 2;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
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
            this.fullDataCtrl1.DataSource = this.aBSPREBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 3);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,adate,h_code,yymm";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(633, 73);
            this.fullDataCtrl1.SortFields = "nobr,adate,h_code,yymm";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // hCODEBindingSource
            // 
            this.hCODEBindingSource.DataMember = "HCODE";
            this.hCODEBindingSource.DataSource = this.dsAtt;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // aBSPRETableAdapter
            // 
            this.aBSPRETableAdapter.ClearBeforeFill = true;
            // 
            // hCODETableAdapter
            // 
            this.hCODETableAdapter.ClearBeforeFill = true;
            // 
            // FRM2P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM2P";
            this.Text = "FRM2P";
            this.Load += new System.EventHandler(this.FRM2P_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBSPREBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private JBControls.CheckBox chkTrans;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtAdate;
        private JBControls.TextBox txtYymm;
        private JBControls.TextBox txtBtime;
        private JBControls.TextBox txtEtime;
        private JBControls.TextBox txtSugHrs;
        private JBControls.TextBox txtAbsHrs;
        private JBControls.DataGridView dataGridView1;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource aBSPREBindingSource;
        private JBHR.Att.dsAttTableAdapters.ABSPRETableAdapter aBSPRETableAdapter;
        private System.Windows.Forms.BindingSource hCODEBindingSource;
        private JBHR.Att.dsAttTableAdapters.HCODETableAdapter hCODETableAdapter;
        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.Button btnMultiOperation;
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUGHRSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aBSHRSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDATE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tRANSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbxHcode;
    }
}