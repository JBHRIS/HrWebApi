namespace JBHR.Att
{
    partial class FRM21C
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
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hOLICODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsHOLICD = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.HOLI_CODE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsROTE = new System.Windows.Forms.BindingSource(this.components);
            this.ROTE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.oTRATECDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsHOL_DAY = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBatch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.fdc = new JBControls.FullDataCtrl();
            this.bsOTHCODE = new System.Windows.Forms.BindingSource(this.components);
            this.oTRATECDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.taHOL_DAY = new JBHR.Att.dsAttTableAdapters.HOL_DAYTableAdapter();
            this.taHOLICD = new JBHR.Att.dsAttTableAdapters.HOLICDTableAdapter();
            this.taOTHCODE = new JBHR.Att.dsAttTableAdapters.OTHCODETableAdapter();
            this.taROTE = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.oTRATECDTableAdapter = new JBHR.Att.dsAttTableAdapters.OTRATECDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHOLICD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsROTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHOL_DAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOTHCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTRATECDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 0;
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
            this.aDATEDataGridViewTextBoxColumn,
            this.hOLICODEDataGridViewTextBoxColumn,
            this.HOLI_CODE,
            this.aTYPEDataGridViewTextBoxColumn,
            this.rOTEDataGridViewTextBoxColumn,
            this.ROTE,
            this.oTRATECDDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.bsHOL_DAY;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(626, 214);
            this.dgv.TabIndex = 9;
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hOLICODEDataGridViewTextBoxColumn
            // 
            this.hOLICODEDataGridViewTextBoxColumn.DataPropertyName = "HOLI_CODE";
            this.hOLICODEDataGridViewTextBoxColumn.DataSource = this.bsHOLICD;
            this.hOLICODEDataGridViewTextBoxColumn.DisplayMember = "HOLI_CODE_DISP";
            this.hOLICODEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.hOLICODEDataGridViewTextBoxColumn.HeaderText = "行事曆代碼";
            this.hOLICODEDataGridViewTextBoxColumn.Name = "hOLICODEDataGridViewTextBoxColumn";
            this.hOLICODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.hOLICODEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hOLICODEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hOLICODEDataGridViewTextBoxColumn.ValueMember = "HOLI_CODE";
            // 
            // bsHOLICD
            // 
            this.bsHOLICD.DataMember = "HOLICD";
            this.bsHOLICD.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HOLI_CODE
            // 
            this.HOLI_CODE.DataPropertyName = "HOLI_CODE";
            this.HOLI_CODE.DataSource = this.bsHOLICD;
            this.HOLI_CODE.DisplayMember = "HOLI_NAME";
            this.HOLI_CODE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.HOLI_CODE.HeaderText = "行事曆";
            this.HOLI_CODE.Name = "HOLI_CODE";
            this.HOLI_CODE.ReadOnly = true;
            this.HOLI_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HOLI_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.HOLI_CODE.ValueMember = "HOLI_CODE";
            // 
            // aTYPEDataGridViewTextBoxColumn
            // 
            this.aTYPEDataGridViewTextBoxColumn.DataPropertyName = "ATYPE";
            this.aTYPEDataGridViewTextBoxColumn.HeaderText = "類別";
            this.aTYPEDataGridViewTextBoxColumn.Name = "aTYPEDataGridViewTextBoxColumn";
            this.aTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOTEDataGridViewTextBoxColumn
            // 
            this.rOTEDataGridViewTextBoxColumn.DataPropertyName = "ROTE";
            this.rOTEDataGridViewTextBoxColumn.DataSource = this.bsROTE;
            this.rOTEDataGridViewTextBoxColumn.DisplayMember = "ROTE_DISP";
            this.rOTEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.rOTEDataGridViewTextBoxColumn.HeaderText = "班別代碼";
            this.rOTEDataGridViewTextBoxColumn.Name = "rOTEDataGridViewTextBoxColumn";
            this.rOTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.rOTEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rOTEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rOTEDataGridViewTextBoxColumn.ValueMember = "ROTE";
            // 
            // bsROTE
            // 
            this.bsROTE.DataMember = "ROTE";
            this.bsROTE.DataSource = this.dsAtt;
            // 
            // ROTE
            // 
            this.ROTE.DataPropertyName = "ROTE";
            this.ROTE.DataSource = this.bsROTE;
            this.ROTE.DisplayMember = "ROTENAME";
            this.ROTE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ROTE.HeaderText = "班別";
            this.ROTE.Name = "ROTE";
            this.ROTE.ReadOnly = true;
            this.ROTE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ROTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ROTE.ValueMember = "ROTE";
            // 
            // oTRATECDDataGridViewTextBoxColumn
            // 
            this.oTRATECDDataGridViewTextBoxColumn.DataPropertyName = "OTRATECD";
            this.oTRATECDDataGridViewTextBoxColumn.HeaderText = "加班比率代碼";
            this.oTRATECDDataGridViewTextBoxColumn.Name = "oTRATECDDataGridViewTextBoxColumn";
            this.oTRATECDDataGridViewTextBoxColumn.ReadOnly = true;
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
            // bsHOL_DAY
            // 
            this.bsHOL_DAY.DataMember = "HOL_DAY";
            this.bsHOL_DAY.DataSource = this.dsAtt;
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
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(626, 223);
            this.splitContainer2.SplitterDistance = 138;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnBatch);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 138);
            this.panel1.TabIndex = 0;
            // 
            // btnBatch
            // 
            this.btnBatch.Location = new System.Drawing.Point(525, 110);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(87, 23);
            this.btnBatch.TabIndex = 1;
            this.btnBatch.TabStop = false;
            this.btnBatch.Text = "批次產生";
            this.btnBatch.UseVisualStyleBackColor = true;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox4, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 134);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(51, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(39, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "行事曆";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(51, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "類別";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(51, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "班別";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "加班比率代碼";
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHOL_DAY, "ADATE", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(86, 3);
            this.textBox1.Mask = "0000/00/00";
            this.textBox1.MaxLength = -1;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHOL_DAY, "HOLI_CODE", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHOL_DAY, "ATYPE", true));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(86, 57);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHOL_DAY, "ROTE", true));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(86, 83);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 4;
            // 
            // comboBox4
            // 
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHOL_DAY, "OTRATECD", true));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(86, 109);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 20);
            this.comboBox4.TabIndex = 5;
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
            this.fdc.DataSource = this.bsHOL_DAY;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(-2, 4);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "adate";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 73);
            this.fdc.SortFields = "adate";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterEdit);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // bsOTHCODE
            // 
            this.bsOTHCODE.DataMember = "OTHCODE";
            this.bsOTHCODE.DataSource = this.dsAtt;
            // 
            // oTRATECDBindingSource
            // 
            this.oTRATECDBindingSource.DataMember = "OTRATECD";
            this.oTRATECDBindingSource.DataSource = this.dsAtt;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.bsHOL_DAY;
            // 
            // taHOL_DAY
            // 
            this.taHOL_DAY.ClearBeforeFill = true;
            // 
            // taHOLICD
            // 
            this.taHOLICD.ClearBeforeFill = true;
            // 
            // taOTHCODE
            // 
            this.taOTHCODE.ClearBeforeFill = true;
            // 
            // taROTE
            // 
            this.taROTE.ClearBeforeFill = true;
            // 
            // oTRATECDTableAdapter
            // 
            this.oTRATECDTableAdapter.ClearBeforeFill = true;
            // 
            // FRM21C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM21C";
            this.Text = "FRM21C";
            this.Load += new System.EventHandler(this.FRM21C_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHOLICD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsROTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHOL_DAY)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOTHCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTRATECDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBox1;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource bsHOL_DAY;
        private JBHR.Att.dsAttTableAdapters.HOL_DAYTableAdapter taHOL_DAY;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bsHOLICD;
        private JBHR.Att.dsAttTableAdapters.HOLICDTableAdapter taHOLICD;
        private System.Windows.Forms.BindingSource bsOTHCODE;
        private JBHR.Att.dsAttTableAdapters.OTHCODETableAdapter taOTHCODE;
        private System.Windows.Forms.BindingSource bsROTE;
        private JBHR.Att.dsAttTableAdapters.ROTETableAdapter taROTE;
        private System.Windows.Forms.BindingSource oTRATECDBindingSource;
        private JBHR.Att.dsAttTableAdapters.OTRATECDTableAdapter oTRATECDTableAdapter;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn hOLICODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn HOLI_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn rOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ROTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn oTRATECDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;

    }
}