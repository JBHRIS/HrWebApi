namespace JBHR.Ins
{
    partial class FRM34
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
            this.rATECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rATENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nORMALRATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOSJOBRATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sELFCHARGEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPCHARGEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pARTIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lARCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.insDS = new JBHR.Ins.InsDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.textBox2 = new JBControls.TextBox();
            this.textBox3 = new JBControls.TextBox();
            this.textBox4 = new JBControls.TextBox();
            this.textBox7 = new JBControls.TextBox();
            this.textBox8 = new JBControls.TextBox();
            this.textBox9 = new JBControls.TextBox();
            this.textBox5 = new JBControls.TextBox();
            this.checkBoxNoFund = new System.Windows.Forms.CheckBox();
            this.checkBoxNoDisaster = new System.Windows.Forms.CheckBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.lARCODETableAdapter = new JBHR.Ins.InsDSTableAdapters.LARCODETableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lARCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(635, 441);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rATECODEDataGridViewTextBoxColumn,
            this.rATENAMEDataGridViewTextBoxColumn,
            this.nORMALRATEDataGridViewTextBoxColumn,
            this.lOSJOBRATEDataGridViewTextBoxColumn,
            this.sELFCHARGEDataGridViewTextBoxColumn,
            this.cOMPCHARGEDataGridViewTextBoxColumn,
            this.pARTIALDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.aDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.lARCODEBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(635, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // rATECODEDataGridViewTextBoxColumn
            // 
            this.rATECODEDataGridViewTextBoxColumn.DataPropertyName = "RATE_CODE";
            this.rATECODEDataGridViewTextBoxColumn.HeaderText = "身分代碼";
            this.rATECODEDataGridViewTextBoxColumn.Name = "rATECODEDataGridViewTextBoxColumn";
            this.rATECODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rATENAMEDataGridViewTextBoxColumn
            // 
            this.rATENAMEDataGridViewTextBoxColumn.DataPropertyName = "RATE_NAME";
            this.rATENAMEDataGridViewTextBoxColumn.HeaderText = "身分名稱";
            this.rATENAMEDataGridViewTextBoxColumn.Name = "rATENAMEDataGridViewTextBoxColumn";
            this.rATENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nORMALRATEDataGridViewTextBoxColumn
            // 
            this.nORMALRATEDataGridViewTextBoxColumn.DataPropertyName = "NORMALRATE";
            this.nORMALRATEDataGridViewTextBoxColumn.HeaderText = "普通事故費率";
            this.nORMALRATEDataGridViewTextBoxColumn.Name = "nORMALRATEDataGridViewTextBoxColumn";
            this.nORMALRATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lOSJOBRATEDataGridViewTextBoxColumn
            // 
            this.lOSJOBRATEDataGridViewTextBoxColumn.DataPropertyName = "LOSJOBRATE";
            this.lOSJOBRATEDataGridViewTextBoxColumn.HeaderText = "失業給付費率";
            this.lOSJOBRATEDataGridViewTextBoxColumn.Name = "lOSJOBRATEDataGridViewTextBoxColumn";
            this.lOSJOBRATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sELFCHARGEDataGridViewTextBoxColumn
            // 
            this.sELFCHARGEDataGridViewTextBoxColumn.DataPropertyName = "SELFCHARGE";
            this.sELFCHARGEDataGridViewTextBoxColumn.HeaderText = "員工負擔比例";
            this.sELFCHARGEDataGridViewTextBoxColumn.Name = "sELFCHARGEDataGridViewTextBoxColumn";
            this.sELFCHARGEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPCHARGEDataGridViewTextBoxColumn
            // 
            this.cOMPCHARGEDataGridViewTextBoxColumn.DataPropertyName = "COMPCHARGE";
            this.cOMPCHARGEDataGridViewTextBoxColumn.HeaderText = "公司負擔比例";
            this.cOMPCHARGEDataGridViewTextBoxColumn.Name = "cOMPCHARGEDataGridViewTextBoxColumn";
            this.cOMPCHARGEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pARTIALDataGridViewTextBoxColumn
            // 
            this.pARTIALDataGridViewTextBoxColumn.DataPropertyName = "PARTIAL";
            this.pARTIALDataGridViewTextBoxColumn.HeaderText = "部份負擔比例";
            this.pARTIALDataGridViewTextBoxColumn.Name = "pARTIALDataGridViewTextBoxColumn";
            this.pARTIALDataGridViewTextBoxColumn.ReadOnly = true;
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
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "生效日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lARCODEBindingSource
            // 
            this.lARCODEBindingSource.DataMember = "LARCODE";
            this.lARCODEBindingSource.DataSource = this.insDS;
            // 
            // insDS
            // 
            this.insDS.DataSetName = "InsDS";
            this.insDS.Locale = new System.Globalization.CultureInfo("");
            this.insDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.insDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(635, 225);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 144);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox7, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox9, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxNoFund, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxNoDisaster, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 140);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.label1.Text = "身分代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "身分名稱";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "生效日期";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "普通事故費率";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "失業給付費率";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(262, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "員工負擔比例";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(262, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "公司負擔比例";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(262, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "部份負擔比例";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "RATE_CODE", true));
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
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "RATE_NAME", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(86, 31);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(170, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "ADATE", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            this.textBox3.Location = new System.Drawing.Point(86, 59);
            this.textBox3.Mask = "0000/00/00";
            this.textBox3.MaxLength = -1;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label4;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "NORMALRATE", true));
            this.textBox4.DecimalPlace = 3;
            this.textBox4.IsEmpty = false;
            this.textBox4.Location = new System.Drawing.Point(86, 87);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = -1;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 3;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox7.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox7.CaptionLabel = this.label7;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "SELFCHARGE", true));
            this.textBox7.DecimalPlace = 2;
            this.textBox7.IsEmpty = false;
            this.textBox7.Location = new System.Drawing.Point(345, 31);
            this.textBox7.Mask = "";
            this.textBox7.MaxLength = -1;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.ReadOnly = false;
            this.textBox7.ShowCalendarButton = true;
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 5;
            this.textBox7.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox8.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox8.CaptionLabel = this.label8;
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "COMPCHARGE", true));
            this.textBox8.DecimalPlace = 2;
            this.textBox8.IsEmpty = false;
            this.textBox8.Location = new System.Drawing.Point(345, 59);
            this.textBox8.Mask = "";
            this.textBox8.MaxLength = -1;
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = '\0';
            this.textBox8.ReadOnly = false;
            this.textBox8.ShowCalendarButton = true;
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 6;
            this.textBox8.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox9.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox9.CaptionLabel = this.label9;
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "PARTIAL", true));
            this.textBox9.DecimalPlace = 2;
            this.textBox9.IsEmpty = false;
            this.textBox9.Location = new System.Drawing.Point(345, 87);
            this.textBox9.Mask = "";
            this.textBox9.MaxLength = -1;
            this.textBox9.Name = "textBox9";
            this.textBox9.PasswordChar = '\0';
            this.textBox9.ReadOnly = false;
            this.textBox9.ShowCalendarButton = true;
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 7;
            this.textBox9.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label5;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lARCODEBindingSource, "LOSJOBRATE", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = false;
            this.textBox5.Location = new System.Drawing.Point(86, 115);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = -1;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 4;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // checkBoxNoFund
            // 
            this.checkBoxNoFund.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxNoFund.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxNoFund, 2);
            this.checkBoxNoFund.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.lARCODEBindingSource, "NOFUND", true));
            this.checkBoxNoFund.Location = new System.Drawing.Point(262, 118);
            this.checkBoxNoFund.Name = "checkBoxNoFund";
            this.checkBoxNoFund.Size = new System.Drawing.Size(108, 16);
            this.checkBoxNoFund.TabIndex = 18;
            this.checkBoxNoFund.TabStop = false;
            this.checkBoxNoFund.Text = "不計算墊償基金";
            this.checkBoxNoFund.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoDisaster
            // 
            this.checkBoxNoDisaster.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxNoDisaster.AutoSize = true;
            this.checkBoxNoDisaster.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.lARCODEBindingSource, "NODISASTER", true));
            this.checkBoxNoDisaster.Location = new System.Drawing.Point(451, 118);
            this.checkBoxNoDisaster.Name = "checkBoxNoDisaster";
            this.checkBoxNoDisaster.Size = new System.Drawing.Size(108, 16);
            this.checkBoxNoDisaster.TabIndex = 19;
            this.checkBoxNoDisaster.TabStop = false;
            this.checkBoxNoDisaster.Text = "不計算職災補償";
            this.checkBoxNoDisaster.UseVisualStyleBackColor = true;
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
            this.fullDataCtrl1.DataSource = this.lARCODEBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(3, 3);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "rate_code,rate_name";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "rate_code";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // lARCODETableAdapter
            // 
            this.lARCODETableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.lARCODEBindingSource;
            // 
            // FRM34
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM34";
            this.Text = "FRM34";
            this.Load += new System.EventHandler(this.FRM34_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lARCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox textBox1;
        private JBControls.TextBox textBox2;
        private JBControls.TextBox textBox3;
        private JBControls.TextBox textBox4;
        private JBControls.TextBox textBox5;
        private JBControls.TextBox textBox7;
        private JBControls.TextBox textBox8;
        private JBControls.TextBox textBox9;
        private InsDS insDS;
        private System.Windows.Forms.BindingSource lARCODEBindingSource;
        private JBHR.Ins.InsDSTableAdapters.LARCODETableAdapter lARCODETableAdapter;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rATECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rATENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nORMALRATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOSJOBRATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sELFCHARGEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPCHARGEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pARTIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox checkBoxNoFund;
        private System.Windows.Forms.CheckBox checkBoxNoDisaster;
    }
}