namespace JBHR.Sal
{
    partial class FRM41
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new JBControls.DataGridView();
            this.ACCCD_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCNAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCTRNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCDRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCCRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.gvACC = new System.Windows.Forms.DataGridView();
            this.dNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCTYPE_NAME = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.costTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.cODEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCSALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox4 = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.textBox5 = new JBControls.TextBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.aCCCDATTRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewDS = new JBHR.Sal.ViewDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.aCCCDTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.ACCCDTableAdapter();
            this.salaryDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aCCCDATTRTableAdapter = new JBHR.Sal.ViewDSTableAdapters.ACCCDATTRTableAdapter();
            this.aCCSALTableAdapter = new JBHR.Bas.BasDSTableAdapters.ACCSALTableAdapter();
            this.costTypeTableAdapter = new JBHR.Bas.BasDSTableAdapters.CostTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvACC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCSALBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCCDATTRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDSBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 560);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACCCD_DISP,
            this.aCCNAMEDataGridViewTextBoxColumn,
            this.ACCNAME_E,
            this.aCCTRNAMEDataGridViewTextBoxColumn,
            this.aCCDRDataGridViewTextBoxColumn,
            this.aCCCRDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aCCCDBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(784, 283);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ACCCD_DISP
            // 
            this.ACCCD_DISP.DataPropertyName = "ACCCD_DISP";
            this.ACCCD_DISP.HeaderText = "科目代碼";
            this.ACCCD_DISP.Name = "ACCCD_DISP";
            this.ACCCD_DISP.ReadOnly = true;
            // 
            // aCCNAMEDataGridViewTextBoxColumn
            // 
            this.aCCNAMEDataGridViewTextBoxColumn.DataPropertyName = "ACCNAME";
            this.aCCNAMEDataGridViewTextBoxColumn.HeaderText = "科目名稱";
            this.aCCNAMEDataGridViewTextBoxColumn.Name = "aCCNAMEDataGridViewTextBoxColumn";
            this.aCCNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ACCNAME_E
            // 
            this.ACCNAME_E.DataPropertyName = "ACCNAME_E";
            this.ACCNAME_E.HeaderText = "科目英文名稱";
            this.ACCNAME_E.Name = "ACCNAME_E";
            this.ACCNAME_E.ReadOnly = true;
            // 
            // aCCTRNAMEDataGridViewTextBoxColumn
            // 
            this.aCCTRNAMEDataGridViewTextBoxColumn.DataPropertyName = "ACC_TRNAME";
            this.aCCTRNAMEDataGridViewTextBoxColumn.HeaderText = "屬性";
            this.aCCTRNAMEDataGridViewTextBoxColumn.Name = "aCCTRNAMEDataGridViewTextBoxColumn";
            this.aCCTRNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCCDRDataGridViewTextBoxColumn
            // 
            this.aCCDRDataGridViewTextBoxColumn.DataPropertyName = "ACCDR";
            this.aCCDRDataGridViewTextBoxColumn.HeaderText = "借方科目";
            this.aCCDRDataGridViewTextBoxColumn.Name = "aCCDRDataGridViewTextBoxColumn";
            this.aCCDRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCCCRDataGridViewTextBoxColumn
            // 
            this.aCCCRDataGridViewTextBoxColumn.DataPropertyName = "ACCCR";
            this.aCCCRDataGridViewTextBoxColumn.HeaderText = "貸方科目";
            this.aCCCRDataGridViewTextBoxColumn.Name = "aCCCRDataGridViewTextBoxColumn";
            this.aCCCRDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄時間";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCCCDBindingSource
            // 
            this.aCCCDBindingSource.DataMember = "ACCCD";
            this.aCCCDBindingSource.DataSource = this.salaryDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(784, 273);
            this.splitContainer2.SplitterDistance = 194;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCodeGroup);
            this.panel1.Controls.Add(this.gvACC);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 194);
            this.panel1.TabIndex = 2;
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(695, 115);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(85, 23);
            this.btnCodeGroup.TabIndex = 102;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click_1);
            // 
            // gvACC
            // 
            this.gvACC.AllowUserToAddRows = false;
            this.gvACC.AllowUserToDeleteRows = false;
            this.gvACC.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvACC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvACC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvACC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dNODataGridViewTextBoxColumn,
            this.ACCTYPE_NAME,
            this.cODEDDataGridViewTextBoxColumn,
            this.cODECDataGridViewTextBoxColumn});
            this.gvACC.DataSource = this.aCCSALBindingSource;
            this.gvACC.Location = new System.Drawing.Point(273, 5);
            this.gvACC.Name = "gvACC";
            this.gvACC.RowHeadersVisible = false;
            this.gvACC.RowTemplate.Height = 24;
            this.gvACC.Size = new System.Drawing.Size(404, 179);
            this.gvACC.TabIndex = 101;
            this.gvACC.TabStop = false;
            // 
            // dNODataGridViewTextBoxColumn
            // 
            this.dNODataGridViewTextBoxColumn.DataPropertyName = "D_NO";
            this.dNODataGridViewTextBoxColumn.HeaderText = "成本別代碼";
            this.dNODataGridViewTextBoxColumn.Name = "dNODataGridViewTextBoxColumn";
            this.dNODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ACCTYPE_NAME
            // 
            this.ACCTYPE_NAME.DataPropertyName = "D_NO";
            this.ACCTYPE_NAME.DataSource = this.costTypeBindingSource;
            this.ACCTYPE_NAME.DisplayMember = "CostTypeName";
            this.ACCTYPE_NAME.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ACCTYPE_NAME.HeaderText = "成本別名稱";
            this.ACCTYPE_NAME.Name = "ACCTYPE_NAME";
            this.ACCTYPE_NAME.ValueMember = "CostTypeCode";
            // 
            // costTypeBindingSource
            // 
            this.costTypeBindingSource.DataMember = "CostType";
            this.costTypeBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cODEDDataGridViewTextBoxColumn
            // 
            this.cODEDDataGridViewTextBoxColumn.DataPropertyName = "CODE_D";
            this.cODEDDataGridViewTextBoxColumn.HeaderText = "借方科目";
            this.cODEDDataGridViewTextBoxColumn.Name = "cODEDDataGridViewTextBoxColumn";
            // 
            // cODECDataGridViewTextBoxColumn
            // 
            this.cODECDataGridViewTextBoxColumn.DataPropertyName = "CODE_C";
            this.cODECDataGridViewTextBoxColumn.HeaderText = "貸方科目";
            this.cODECDataGridViewTextBoxColumn.Name = "cODECDataGridViewTextBoxColumn";
            // 
            // aCCSALBindingSource
            // 
            this.aCCSALBindingSource.DataMember = "ACCSAL";
            this.aCCSALBindingSource.DataSource = this.basDS;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 9;
            this.button1.TabStop = false;
            this.button1.Text = "會計科目資料";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 184);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label5;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCCDBindingSource, "ACCDR", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(86, 113);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = 50;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = false;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 4;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "借方科目";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科目代碼";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCCDBindingSource, "ACCCD_DISP", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(86, 3);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "科目名稱";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "貸方科目";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(51, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "屬性";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCCDBindingSource, "ACCNAME", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(86, 31);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(155, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aCCCDBindingSource, "ACC_TR", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "科目英文名稱";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label6;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCCDBindingSource, "ACCNAME_E", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = true;
            this.textBox3.Location = new System.Drawing.Point(86, 85);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(155, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox5
            // 
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label4;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCCDBindingSource, "ACCCR", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = true;
            this.textBox5.Location = new System.Drawing.Point(86, 141);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = 50;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = false;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 5;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.String;
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
            this.fullDataCtrl1.DataSource = this.aCCCDBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "acccd,accname";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(784, 73);
            this.fullDataCtrl1.SortFields = "acccd,accname";
            this.fullDataCtrl1.TabIndex = 2;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // aCCCDATTRBindingSource
            // 
            this.aCCCDATTRBindingSource.DataMember = "ACCCDATTR";
            this.aCCCDATTRBindingSource.DataSource = this.viewDS;
            // 
            // viewDS
            // 
            this.viewDS.DataSetName = "ViewDS";
            this.viewDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.viewDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.aCCCDBindingSource;
            // 
            // aCCCDTableAdapter
            // 
            this.aCCCDTableAdapter.ClearBeforeFill = true;
            // 
            // salaryDSBindingSource
            // 
            this.salaryDSBindingSource.DataSource = this.salaryDS;
            this.salaryDSBindingSource.Position = 0;
            // 
            // aCCCDATTRTableAdapter
            // 
            this.aCCCDATTRTableAdapter.ClearBeforeFill = true;
            // 
            // aCCSALTableAdapter
            // 
            this.aCCSALTableAdapter.ClearBeforeFill = true;
            // 
            // costTypeTableAdapter
            // 
            this.costTypeTableAdapter.ClearBeforeFill = true;
            // 
            // FRM41
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "FRM41";
            this.Text = "FRM41";
            this.Load += new System.EventHandler(this.FRM41_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvACC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCSALBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCCCDATTRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource aCCCDBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.ACCCDTableAdapter aCCCDTableAdapter;
        private System.Windows.Forms.BindingSource salaryDSBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private JBControls.DataGridView dataGridView1;
        private ViewDS viewDS;
        private System.Windows.Forms.BindingSource aCCCDATTRBindingSource;
        private JBHR.Sal.ViewDSTableAdapters.ACCCDATTRTableAdapter aCCCDATTRTableAdapter;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gvACC;
        private System.Windows.Forms.Button btnCodeGroup;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource aCCSALBindingSource;
        private Bas.BasDSTableAdapters.ACCSALTableAdapter aCCSALTableAdapter;
        private JBControls.TextBox textBox4;
        private JBControls.TextBox textBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCCD_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCCNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCNAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCCTRNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCCDRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCCCRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource costTypeBindingSource;
        private Bas.BasDSTableAdapters.CostTypeTableAdapter costTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ACCTYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODECDataGridViewTextBoxColumn;
    }
}