namespace JBHR.Att
{
    partial class FRM24
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
            this.dgv = new JBControls.DataGridView();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oNTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTTRANDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IPADD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCARD = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.btnProduce = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtIpAdd = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCardNO = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bsBASE = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.txtAdate = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkNoTran = new JBControls.CheckBox();
            this.txtOntime = new JBControls.TextBox();
            this.btnProduceHave = new System.Windows.Forms.Button();
            this.btnCheckRepeat = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.taBASE = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.taCARD = new JBHR.Att.dsAttTableAdapters.CARDTableAdapter();
            this.btnAdvance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCARD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(636, 452);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.nOBRDataGridViewTextBoxColumn,
            this.nAMECDataGridViewTextBoxColumn,
            this.DEPT,
            this.aDATEDataGridViewTextBoxColumn,
            this.oNTIMEDataGridViewTextBoxColumn,
            this.cARDNODataGridViewTextBoxColumn,
            this.cODEDataGridViewTextBoxColumn,
            this.nOTTRANDataGridViewCheckBoxColumn,
            this.IPADD,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.bsCARD;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(636, 252);
            this.dgv.TabIndex = 7;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Width = 78;
            // 
            // nAMECDataGridViewTextBoxColumn
            // 
            this.nAMECDataGridViewTextBoxColumn.DataPropertyName = "NAME_C";
            this.nAMECDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nAMECDataGridViewTextBoxColumn.Name = "nAMECDataGridViewTextBoxColumn";
            this.nAMECDataGridViewTextBoxColumn.ReadOnly = true;
            this.nAMECDataGridViewTextBoxColumn.Width = 78;
            // 
            // DEPT
            // 
            this.DEPT.DataPropertyName = "D_NO_DISP";
            this.DEPT.HeaderText = "編制部門代號";
            this.DEPT.Name = "DEPT";
            this.DEPT.ReadOnly = true;
            this.DEPT.Width = 102;
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "刷卡日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // oNTIMEDataGridViewTextBoxColumn
            // 
            this.oNTIMEDataGridViewTextBoxColumn.DataPropertyName = "ONTIME";
            this.oNTIMEDataGridViewTextBoxColumn.HeaderText = "刷卡時間";
            this.oNTIMEDataGridViewTextBoxColumn.Name = "oNTIMEDataGridViewTextBoxColumn";
            this.oNTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.oNTIMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // cARDNODataGridViewTextBoxColumn
            // 
            this.cARDNODataGridViewTextBoxColumn.DataPropertyName = "CARDNO";
            this.cARDNODataGridViewTextBoxColumn.HeaderText = "刷卡卡號";
            this.cARDNODataGridViewTextBoxColumn.Name = "cARDNODataGridViewTextBoxColumn";
            this.cARDNODataGridViewTextBoxColumn.ReadOnly = true;
            this.cARDNODataGridViewTextBoxColumn.Width = 78;
            // 
            // cODEDataGridViewTextBoxColumn
            // 
            this.cODEDataGridViewTextBoxColumn.DataPropertyName = "CODE";
            this.cODEDataGridViewTextBoxColumn.HeaderText = "來源";
            this.cODEDataGridViewTextBoxColumn.Name = "cODEDataGridViewTextBoxColumn";
            this.cODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cODEDataGridViewTextBoxColumn.Width = 54;
            // 
            // nOTTRANDataGridViewCheckBoxColumn
            // 
            this.nOTTRANDataGridViewCheckBoxColumn.DataPropertyName = "NOT_TRAN";
            this.nOTTRANDataGridViewCheckBoxColumn.HeaderText = "不轉換";
            this.nOTTRANDataGridViewCheckBoxColumn.Name = "nOTTRANDataGridViewCheckBoxColumn";
            this.nOTTRANDataGridViewCheckBoxColumn.ReadOnly = true;
            this.nOTTRANDataGridViewCheckBoxColumn.Width = 47;
            // 
            // IPADD
            // 
            this.IPADD.DataPropertyName = "IPADD";
            this.IPADD.HeaderText = "電子刷卡IP";
            this.IPADD.Name = "IPADD";
            this.IPADD.ReadOnly = true;
            this.IPADD.Width = 90;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "建檔人員";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "建檔日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // bsCARD
            // 
            this.bsCARD.DataMember = "CARD";
            this.bsCARD.DataSource = this.dsAtt;
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
            this.splitContainer2.Panel1.Controls.Add(this.plFV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(636, 196);
            this.splitContainer2.SplitterDistance = 114;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.btnAdvance);
            this.plFV.Controls.Add(this.btnProduce);
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Controls.Add(this.btnProduceHave);
            this.plFV.Controls.Add(this.btnCheckRepeat);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(636, 114);
            this.plFV.TabIndex = 1;
            // 
            // btnProduce
            // 
            this.btnProduce.Location = new System.Drawing.Point(492, 30);
            this.btnProduce.Name = "btnProduce";
            this.btnProduce.Size = new System.Drawing.Size(140, 23);
            this.btnProduce.TabIndex = 6;
            this.btnProduce.Text = "產生刷卡資料(無刷卡)";
            this.btnProduce.UseVisualStyleBackColor = true;
            this.btnProduce.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtIpAdd, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCardNO, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkNoTran, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOntime, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(453, 110);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtIpAdd
            // 
            this.txtIpAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIpAdd.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtIpAdd.CaptionLabel = this.label6;
            this.txtIpAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIpAdd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARD, "IPADD", true));
            this.txtIpAdd.DecimalPlace = 2;
            this.txtIpAdd.IsEmpty = true;
            this.txtIpAdd.Location = new System.Drawing.Point(293, 59);
            this.txtIpAdd.Mask = "";
            this.txtIpAdd.MaxLength = 50;
            this.txtIpAdd.Name = "txtIpAdd";
            this.txtIpAdd.PasswordChar = '\0';
            this.txtIpAdd.ReadOnly = false;
            this.txtIpAdd.Size = new System.Drawing.Size(100, 22);
            this.txtIpAdd.TabIndex = 6;
            this.txtIpAdd.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(222, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "電子刷卡IP";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCode.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCode.CaptionLabel = this.label5;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARD, "CODE", true));
            this.txtCode.DecimalPlace = 2;
            this.txtCode.IsEmpty = true;
            this.txtCode.Location = new System.Drawing.Point(293, 31);
            this.txtCode.Mask = "";
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.ReadOnly = false;
            this.txtCode.Size = new System.Drawing.Size(100, 22);
            this.txtCode.TabIndex = 5;
            this.txtCode.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(258, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "來源";
            // 
            // txtCardNO
            // 
            this.txtCardNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCardNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCardNO.CaptionLabel = this.label4;
            this.txtCardNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCardNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARD, "CARDNO", true));
            this.txtCardNO.DecimalPlace = 2;
            this.txtCardNO.IsEmpty = true;
            this.txtCardNO.Location = new System.Drawing.Point(293, 3);
            this.txtCardNO.Mask = "";
            this.txtCardNO.MaxLength = 50;
            this.txtCardNO.Name = "txtCardNO";
            this.txtCardNO.PasswordChar = '\0';
            this.txtCardNO.ReadOnly = false;
            this.txtCardNO.Size = new System.Drawing.Size(100, 22);
            this.txtCardNO.TabIndex = 4;
            this.txtCardNO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(234, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "刷卡卡號";
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
            this.label2.Text = "刷卡日期";
            // 
            // ptxNobr
            // 
            this.ptxNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.BackColor = System.Drawing.Color.White;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARD, "NOBR", true));
            this.ptxNobr.DataSource = this.bsBASE;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(62, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.Size = new System.Drawing.Size(100, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // bsBASE
            // 
            this.bsBASE.DataMember = "BASE";
            this.bsBASE.DataSource = this.dsBas;
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
            this.txtAdate.CaptionLabel = this.label2;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARD, "ADATE", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = false;
            this.txtAdate.Location = new System.Drawing.Point(62, 31);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.Size = new System.Drawing.Size(100, 22);
            this.txtAdate.TabIndex = 1;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "刷卡時間";
            // 
            // chkNoTran
            // 
            this.chkNoTran.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkNoTran.AutoSize = true;
            this.chkNoTran.CaptionLabel = null;
            this.chkNoTran.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCARD, "NOT_TRAN", true));
            this.chkNoTran.IsImitateCaption = true;
            this.chkNoTran.Location = new System.Drawing.Point(62, 89);
            this.chkNoTran.Name = "chkNoTran";
            this.chkNoTran.Size = new System.Drawing.Size(60, 16);
            this.chkNoTran.TabIndex = 3;
            this.chkNoTran.Text = "不轉換";
            this.chkNoTran.UseVisualStyleBackColor = true;
            // 
            // txtOntime
            // 
            this.txtOntime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOntime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtOntime.CaptionLabel = this.label3;
            this.txtOntime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOntime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARD, "ONTIME", true));
            this.txtOntime.DecimalPlace = 2;
            this.txtOntime.IsEmpty = false;
            this.txtOntime.Location = new System.Drawing.Point(62, 59);
            this.txtOntime.Mask = "0000";
            this.txtOntime.MaxLength = 50;
            this.txtOntime.Name = "txtOntime";
            this.txtOntime.PasswordChar = '\0';
            this.txtOntime.ReadOnly = false;
            this.txtOntime.Size = new System.Drawing.Size(100, 22);
            this.txtOntime.TabIndex = 2;
            this.txtOntime.ValidType = JBControls.TextBox.EValidType.String;
            this.txtOntime.Validating += new System.ComponentModel.CancelEventHandler(this.txtOntime_Validating);
            // 
            // btnProduceHave
            // 
            this.btnProduceHave.Location = new System.Drawing.Point(540, 85);
            this.btnProduceHave.Name = "btnProduceHave";
            this.btnProduceHave.Size = new System.Drawing.Size(87, 23);
            this.btnProduceHave.TabIndex = 5;
            this.btnProduceHave.Text = "產生刷卡資料";
            this.btnProduceHave.UseVisualStyleBackColor = true;
            this.btnProduceHave.Visible = false;
            this.btnProduceHave.Click += new System.EventHandler(this.btnProduceHave_Click);
            // 
            // btnCheckRepeat
            // 
            this.btnCheckRepeat.Location = new System.Drawing.Point(492, 3);
            this.btnCheckRepeat.Name = "btnCheckRepeat";
            this.btnCheckRepeat.Size = new System.Drawing.Size(140, 23);
            this.btnCheckRepeat.TabIndex = 4;
            this.btnCheckRepeat.Text = "重複刷卡檢查";
            this.btnCheckRepeat.UseVisualStyleBackColor = true;
            this.btnCheckRepeat.Visible = false;
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
            this.fdc.DataSource = this.bsCARD;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(1, 2);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "nobr,name_c,adate,ontime,key_man";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 73);
            this.fdc.SortFields = "nobr,name_c,adate,ontime,key_man";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeDel);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.bsCARD;
            // 
            // taBASE
            // 
            this.taBASE.ClearBeforeFill = true;
            // 
            // taCARD
            // 
            this.taCARD.ClearBeforeFill = true;
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(540, 59);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(87, 23);
            this.btnAdvance.TabIndex = 39;
            this.btnAdvance.Text = "進階查詢";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // FRM24
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 452);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM24";
            this.Text = "FRM24";
            this.Load += new System.EventHandler(this.FRM24_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCARD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource bsCARD;
        private JBHR.Att.dsAttTableAdapters.CARDTableAdapter taCARD;
        private System.Windows.Forms.Button btnProduce;
        private System.Windows.Forms.Button btnProduceHave;
        private System.Windows.Forms.Button btnCheckRepeat;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter taBASE;
        private System.Windows.Forms.BindingSource bsBASE;
        private dsBas dsBas;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtIpAdd;
        private JBControls.TextBox txtCode;
        private JBControls.TextBox txtCardNO;
        private JBControls.TextBox txtAdate;
        private JBControls.TextBox txtOntime;
        private JBControls.CheckBox chkNoTran;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oNTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nOTTRANDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPADD;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAdvance;
    }
}