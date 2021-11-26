namespace JBHR.Att
{
    partial class FRM212D
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgv = new JBControls.DataGridView();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.sTRBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALUE1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALUE2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECK4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CHECK5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SALFUNCTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOTEBONUSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBworkHrs = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmt = new JBControls.TextBox();
            this.txtBtime = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new JBControls.CheckBox();
            this.checkBox6 = new JBControls.CheckBox();
            this.txtEtime = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEworkHrs = new JBControls.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbxSALFUNCTION = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox3 = new JBControls.CheckBox();
            this.checkBox2 = new JBControls.CheckBox();
            this.checkBox4 = new JBControls.CheckBox();
            this.fdc = new JBControls.FullDataCtrl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.rOTE_BONUSTableAdapter = new JBHR.Att.dsAttTableAdapters.ROTE_BONUSTableAdapter();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBONUSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(552, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.sALCODEDataGridViewTextBoxColumn,
            this.sTRBDataGridViewTextBoxColumn,
            this.sTREDataGridViewTextBoxColumn,
            this.vALUE1DataGridViewTextBoxColumn,
            this.vALUE2DataGridViewTextBoxColumn,
            this.AMT,
            this.CHECK4,
            this.CHECK5,
            this.SALFUNCTION,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.rOTEBONUSBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(626, 273);
            this.dgv.TabIndex = 8;
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
            // sTRBDataGridViewTextBoxColumn
            // 
            this.sTRBDataGridViewTextBoxColumn.DataPropertyName = "STR_B";
            this.sTRBDataGridViewTextBoxColumn.HeaderText = "開始時間";
            this.sTRBDataGridViewTextBoxColumn.Name = "sTRBDataGridViewTextBoxColumn";
            this.sTRBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sTREDataGridViewTextBoxColumn
            // 
            this.sTREDataGridViewTextBoxColumn.DataPropertyName = "STR_E";
            this.sTREDataGridViewTextBoxColumn.HeaderText = "結束時間";
            this.sTREDataGridViewTextBoxColumn.Name = "sTREDataGridViewTextBoxColumn";
            this.sTREDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALUE1DataGridViewTextBoxColumn
            // 
            this.vALUE1DataGridViewTextBoxColumn.DataPropertyName = "VALUE1";
            this.vALUE1DataGridViewTextBoxColumn.HeaderText = "工時起";
            this.vALUE1DataGridViewTextBoxColumn.Name = "vALUE1DataGridViewTextBoxColumn";
            this.vALUE1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALUE2DataGridViewTextBoxColumn
            // 
            this.vALUE2DataGridViewTextBoxColumn.DataPropertyName = "VALUE2";
            this.vALUE2DataGridViewTextBoxColumn.HeaderText = "工時迄";
            this.vALUE2DataGridViewTextBoxColumn.Name = "vALUE2DataGridViewTextBoxColumn";
            this.vALUE2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AMT
            // 
            this.AMT.DataPropertyName = "AMT";
            this.AMT.HeaderText = "金額";
            this.AMT.Name = "AMT";
            this.AMT.ReadOnly = true;
            // 
            // CHECK4
            // 
            this.CHECK4.DataPropertyName = "CHECK4";
            this.CHECK4.HeaderText = "出勤";
            this.CHECK4.Name = "CHECK4";
            this.CHECK4.ReadOnly = true;
            // 
            // CHECK5
            // 
            this.CHECK5.DataPropertyName = "CHECK5";
            this.CHECK5.HeaderText = "加班";
            this.CHECK5.Name = "CHECK5";
            this.CHECK5.ReadOnly = true;
            // 
            // SALFUNCTION
            // 
            this.SALFUNCTION.DataPropertyName = "SALFUNCTION";
            this.SALFUNCTION.HeaderText = "計算公式";
            this.SALFUNCTION.Name = "SALFUNCTION";
            this.SALFUNCTION.ReadOnly = true;
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
            // rOTEBONUSBindingSource
            // 
            this.rOTEBONUSBindingSource.DataMember = "ROTE_BONUS";
            this.rOTEBONUSBindingSource.DataSource = this.dsAtt;
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
            this.splitContainer2.IsSplitterFixed = true;
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
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(626, 164);
            this.splitContainer2.SplitterDistance = 128;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.Controls.Add(this.btnCopy);
            this.plFV.Controls.Add(this.btnAdvance);
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(626, 128);
            this.plFV.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(540, 68);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(82, 25);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "複製";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(540, 99);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(82, 25);
            this.btnAdvance.TabIndex = 1;
            this.btnAdvance.TabStop = false;
            this.btnAdvance.Text = "進階設定";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtBworkHrs, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAmt, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtBtime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.checkBox6, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtEtime, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtEworkHrs, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxSALFUNCTION, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox3, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBox2, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBox4, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 128);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(15, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "工時起";
            // 
            // txtBworkHrs
            // 
            this.txtBworkHrs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBworkHrs.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBworkHrs.CaptionLabel = this.label4;
            this.txtBworkHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBworkHrs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTEBONUSBindingSource, "VALUE1", true));
            this.txtBworkHrs.DecimalPlace = 2;
            this.txtBworkHrs.IsEmpty = false;
            this.txtBworkHrs.Location = new System.Drawing.Point(62, 58);
            this.txtBworkHrs.Mask = "";
            this.txtBworkHrs.MaxLength = -1;
            this.txtBworkHrs.Name = "txtBworkHrs";
            this.txtBworkHrs.PasswordChar = '\0';
            this.txtBworkHrs.ReadOnly = false;
            this.txtBworkHrs.ShowCalendarButton = true;
            this.txtBworkHrs.Size = new System.Drawing.Size(50, 22);
            this.txtBworkHrs.TabIndex = 4;
            this.txtBworkHrs.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(27, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "金額";
            // 
            // txtAmt
            // 
            this.txtAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = this.label5;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTEBONUSBindingSource, "AMT", true));
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = false;
            this.txtAmt.Location = new System.Drawing.Point(62, 86);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.ShowCalendarButton = true;
            this.txtAmt.Size = new System.Drawing.Size(50, 22);
            this.txtAmt.TabIndex = 6;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // txtBtime
            // 
            this.txtBtime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBtime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBtime.CaptionLabel = this.label2;
            this.txtBtime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBtime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTEBONUSBindingSource, "STR_B", true));
            this.txtBtime.DecimalPlace = 2;
            this.txtBtime.IsEmpty = false;
            this.txtBtime.Location = new System.Drawing.Point(62, 30);
            this.txtBtime.Mask = "";
            this.txtBtime.MaxLength = 50;
            this.txtBtime.Name = "txtBtime";
            this.txtBtime.PasswordChar = '\0';
            this.txtBtime.ReadOnly = false;
            this.txtBtime.ShowCalendarButton = true;
            this.txtBtime.Size = new System.Drawing.Size(50, 22);
            this.txtBtime.TabIndex = 2;
            this.txtBtime.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "開始時間";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "薪資代碼";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rOTEBONUSBindingSource, "CHECK1", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(62, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "需做滿";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.CaptionLabel = null;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rOTEBONUSBindingSource, "CHECK2", true));
            this.checkBox6.IsImitateCaption = true;
            this.checkBox6.Location = new System.Drawing.Point(128, 111);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(60, 16);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.TabStop = false;
            this.checkBox6.Text = "依比例";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // txtEtime
            // 
            this.txtEtime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEtime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEtime.CaptionLabel = this.label3;
            this.txtEtime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEtime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTEBONUSBindingSource, "STR_E", true));
            this.txtEtime.DecimalPlace = 2;
            this.txtEtime.IsEmpty = false;
            this.txtEtime.Location = new System.Drawing.Point(212, 30);
            this.txtEtime.Mask = "";
            this.txtEtime.MaxLength = 50;
            this.txtEtime.Name = "txtEtime";
            this.txtEtime.PasswordChar = '\0';
            this.txtEtime.ReadOnly = false;
            this.txtEtime.ShowCalendarButton = true;
            this.txtEtime.Size = new System.Drawing.Size(50, 22);
            this.txtEtime.TabIndex = 3;
            this.txtEtime.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(153, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "結束時間";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(165, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "工時迄";
            // 
            // txtEworkHrs
            // 
            this.txtEworkHrs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEworkHrs.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEworkHrs.CaptionLabel = null;
            this.txtEworkHrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEworkHrs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTEBONUSBindingSource, "VALUE2", true));
            this.txtEworkHrs.DecimalPlace = 2;
            this.txtEworkHrs.IsEmpty = false;
            this.txtEworkHrs.Location = new System.Drawing.Point(212, 58);
            this.txtEworkHrs.Mask = "";
            this.txtEworkHrs.MaxLength = -1;
            this.txtEworkHrs.Name = "txtEworkHrs";
            this.txtEworkHrs.PasswordChar = '\0';
            this.txtEworkHrs.ReadOnly = false;
            this.txtEworkHrs.ShowCalendarButton = true;
            this.txtEworkHrs.Size = new System.Drawing.Size(50, 22);
            this.txtEworkHrs.TabIndex = 5;
            this.txtEworkHrs.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // comboBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBox1, 2);
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.rOTEBONUSBindingSource, "SAL_CODE", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // cbxSALFUNCTION
            // 
            this.cbxSALFUNCTION.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.rOTEBONUSBindingSource, "SALFUNCTION", true));
            this.cbxSALFUNCTION.FormattingEnabled = true;
            this.cbxSALFUNCTION.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxSALFUNCTION.Location = new System.Drawing.Point(356, 30);
            this.cbxSALFUNCTION.Name = "cbxSALFUNCTION";
            this.cbxSALFUNCTION.Size = new System.Drawing.Size(121, 20);
            this.cbxSALFUNCTION.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(297, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "計算公式";
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.CaptionLabel = null;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rOTEBONUSBindingSource, "CHECK4", true));
            this.checkBox3.Enabled = false;
            this.checkBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox3.IsImitateCaption = true;
            this.checkBox3.Location = new System.Drawing.Point(302, 86);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "出勤";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CaptionLabel = null;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rOTEBONUSBindingSource, "CHECK5", true));
            this.checkBox2.Enabled = false;
            this.checkBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox2.IsImitateCaption = true;
            this.checkBox2.Location = new System.Drawing.Point(356, 86);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "加班";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CaptionLabel = null;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBox4, 2);
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rOTEBONUSBindingSource, "CHECK6", true));
            this.checkBox4.IsImitateCaption = true;
            this.checkBox4.Location = new System.Drawing.Point(212, 111);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(96, 16);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.TabStop = false;
            this.checkBox4.Text = "不扣休息時數";
            this.checkBox4.UseVisualStyleBackColor = true;
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
            this.fdc.CtrlType = JBControls.FullDataCtrl.ECtrlType.Action;
            this.fdc.DataAdapter = null;
            this.fdc.DataGrid = this.dgv;
            this.fdc.DataSource = this.rOTEBONUSBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(-4, 4);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "year_b,year_e,day_b,day_e";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 29);
            this.fdc.SortFields = "year_b,year_e,day_b,day_e";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // rOTE_BONUSTableAdapter
            // 
            this.rOTE_BONUSTableAdapter.ClearBeforeFill = true;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // FRM212D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM212D";
            this.Text = "FRM212D";
            this.Load += new System.EventHandler(this.FRM211D_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBONUSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.Panel plFV;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private dsAtt dsAtt;
        private System.Windows.Forms.DataGridViewTextBoxColumn yEARBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yEAREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dAYBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dAYEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtEtime;
        private JBControls.TextBox txtBworkHrs;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox txtAmt;
        private System.Windows.Forms.BindingSource rOTEBONUSBindingSource;
        private dsAttTableAdapters.ROTE_BONUSTableAdapter rOTE_BONUSTableAdapter;
        private JBControls.TextBox txtBtime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private JBControls.CheckBox checkBox1;
        private JBControls.CheckBox checkBox6;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox txtEworkHrs;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbxSALFUNCTION;
        private System.Windows.Forms.Label label7;
        private JBControls.CheckBox checkBox3;
        private JBControls.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTRBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALUE1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALUE2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALFUNCTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private JBControls.CheckBox checkBox4;
    }
}