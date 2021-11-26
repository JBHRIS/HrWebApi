namespace JBHR.Sal
{
    partial class FRM45
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBase = new System.Windows.Forms.Button();
            this.btnInslab = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnAtt = new System.Windows.Forms.Button();
            this.btnAbs = new System.Windows.Forms.Button();
            this.btnOT = new System.Windows.Forms.Button();
            this.textBox2 = new JBControls.TextBox();
            this.wAGEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPlus = new JBHR.Sal.SalaryDS();
            this.textBox1 = new JBControls.TextBox();
            this.dvTeco = new JBControls.DataGridView();
            this.bsSalcodeTeco = new System.Windows.Forms.BindingSource(this.components);
            this.dsTeco = new JBHR.Sal.SalaryDS();
            this.bsWageTeco = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dvMinus = new JBControls.DataGridView();
            this.bsSalcodeMinus = new System.Windows.Forms.BindingSource(this.components);
            this.dsMinus = new JBHR.Sal.SalaryDS();
            this.bsWageMinus = new System.Windows.Forms.BindingSource(this.components);
            this.dvPlus = new JBControls.DataGridView();
            this.bsSalcodePlus = new System.Windows.Forms.BindingSource(this.components);
            this.bsWagedPlus = new System.Windows.Forms.BindingSource(this.components);
            this.txtSalDateE = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSeq = new JBControls.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new JBControls.CheckBox();
            this.txtSalDateB = new JBControls.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtYymm = new JBControls.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox20 = new JBControls.TextBox();
            this.textBox21 = new JBControls.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox17 = new JBControls.TextBox();
            this.textBox18 = new JBControls.TextBox();
            this.txtBankTeco = new JBControls.TextBox();
            this.textBox16 = new JBControls.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new JBControls.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.yRFORMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medDS = new JBHR.Med.MedDS();
            this.textBox14 = new JBControls.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox12 = new JBControls.TextBox();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTaxAmt = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTecoTotal = new JBControls.TextBox();
            this.txtTotalAmt = new JBControls.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCut = new JBControls.TextBox();
            this.txtCutTax = new JBControls.TextBox();
            this.txtTaxTotal = new JBControls.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPayAmt = new JBControls.TextBox();
            this.txtPayTax = new JBControls.TextBox();
            this.txtPayTotal = new JBControls.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.viewDS = new JBHR.Sal.ViewDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.wAGETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.WAGETableAdapter();
            this.wAGEDTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.WAGEDTableAdapter();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            this.yRFORMATTableAdapter = new JBHR.Med.MedDSTableAdapters.YRFORMATTableAdapter();
            this.SAL_CODE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aMTDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aMTDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wAGEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvTeco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalcodeTeco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTeco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWageTeco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalcodeMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWageMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalcodePlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWagedPlus)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 51);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(183, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 32;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(264, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(426, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(345, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(21, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(601, 18);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(29, 12);
            this.lblState.TabIndex = 31;
            this.lblState.Text = "wait";
            this.lblState.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(102, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.dvTeco);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.dvMinus);
            this.panel2.Controls.Add(this.dvPlus);
            this.panel2.Controls.Add(this.txtSalDateE);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtSeq);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.txtSalDateB);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtYymm);
            this.panel2.Controls.Add(this.tableLayoutPanel7);
            this.panel2.Controls.Add(this.tableLayoutPanel6);
            this.panel2.Controls.Add(this.textBox16);
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 584);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBase);
            this.groupBox2.Controls.Add(this.btnInslab);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.btnAtt);
            this.groupBox2.Controls.Add(this.btnAbs);
            this.groupBox2.Controls.Add(this.btnOT);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(23, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 67);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明細資料";
            // 
            // btnBase
            // 
            this.btnBase.Location = new System.Drawing.Point(669, 23);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(66, 28);
            this.btnBase.TabIndex = 76;
            this.btnBase.Text = "基本資料";
            this.btnBase.UseVisualStyleBackColor = true;
            this.btnBase.Visible = false;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // btnInslab
            // 
            this.btnInslab.Location = new System.Drawing.Point(576, 23);
            this.btnInslab.Name = "btnInslab";
            this.btnInslab.Size = new System.Drawing.Size(87, 28);
            this.btnInslab.TabIndex = 75;
            this.btnInslab.Text = "勞健退明細";
            this.btnInslab.UseVisualStyleBackColor = true;
            this.btnInslab.Click += new System.EventHandler(this.btnInslab_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 8;
            this.label23.Text = "出勤區間";
            // 
            // btnAtt
            // 
            this.btnAtt.Location = new System.Drawing.Point(284, 23);
            this.btnAtt.Name = "btnAtt";
            this.btnAtt.Size = new System.Drawing.Size(96, 28);
            this.btnAtt.TabIndex = 72;
            this.btnAtt.Text = "津貼餐費明細";
            this.btnAtt.UseVisualStyleBackColor = true;
            this.btnAtt.Click += new System.EventHandler(this.btnAtt_Click);
            // 
            // btnAbs
            // 
            this.btnAbs.Location = new System.Drawing.Point(481, 23);
            this.btnAbs.Name = "btnAbs";
            this.btnAbs.Size = new System.Drawing.Size(92, 28);
            this.btnAbs.TabIndex = 74;
            this.btnAbs.Text = "請假扣款明細";
            this.btnAbs.UseVisualStyleBackColor = true;
            this.btnAbs.Click += new System.EventHandler(this.btnAbs_Click);
            // 
            // btnOT
            // 
            this.btnOT.Location = new System.Drawing.Point(386, 23);
            this.btnOT.Name = "btnOT";
            this.btnOT.Size = new System.Drawing.Size(89, 28);
            this.btnOT.TabIndex = 73;
            this.btnOT.Text = "加班費明細";
            this.btnOT.UseVisualStyleBackColor = true;
            this.btnOT.Click += new System.EventHandler(this.btnOT_Click);
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = null;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "ATT_DATEE", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.Enabled = false;
            this.textBox2.IsEmpty = true;
            this.textBox2.Location = new System.Drawing.Point(181, 27);
            this.textBox2.Mask = "0000/00/00";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(95, 22);
            this.textBox2.TabIndex = 71;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // wAGEBindingSource
            // 
            this.wAGEBindingSource.DataMember = "WAGE";
            this.wAGEBindingSource.DataSource = this.dsPlus;
            // 
            // dsPlus
            // 
            this.dsPlus.DataSetName = "SalaryDS";
            this.dsPlus.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsPlus.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = null;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "ATT_DATEB", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.Enabled = false;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(68, 27);
            this.textBox1.Mask = "0000/00/00";
            this.textBox1.MaxLength = -1;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(95, 22);
            this.textBox1.TabIndex = 70;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // dvTeco
            // 
            this.dvTeco.AutoGenerateColumns = false;
            this.dvTeco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvTeco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvTeco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn1,
            this.sALCODEDataGridViewTextBoxColumn2,
            this.aMTDataGridViewTextBoxColumn2});
            this.dvTeco.DataSource = this.bsWageTeco;
            this.dvTeco.Location = new System.Drawing.Point(529, 122);
            this.dvTeco.Name = "dvTeco";
            this.dvTeco.RowHeadersVisible = false;
            this.dvTeco.RowTemplate.Height = 24;
            this.dvTeco.Size = new System.Drawing.Size(233, 278);
            this.dvTeco.TabIndex = 18;
            this.dvTeco.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvPlus_RowValidated);
            this.dvTeco.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dvPlus_RowValidating);
            // 
            // bsSalcodeTeco
            // 
            this.bsSalcodeTeco.DataMember = "SALCODE";
            this.bsSalcodeTeco.DataSource = this.dsTeco;
            // 
            // dsTeco
            // 
            this.dsTeco.DataSetName = "SalaryDS";
            this.dsTeco.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsTeco.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsWageTeco
            // 
            this.bsWageTeco.DataMember = "WAGED";
            this.bsWageTeco.DataSource = this.dsTeco;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.TabStop = false;
            this.button1.Text = "更新所得稅";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dvMinus
            // 
            this.dvMinus.AutoGenerateColumns = false;
            this.dvMinus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvMinus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvMinus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn2,
            this.sALCODEDataGridViewTextBoxColumn1,
            this.aMTDataGridViewTextBoxColumn1});
            this.dvMinus.DataSource = this.bsWageMinus;
            this.dvMinus.Location = new System.Drawing.Point(276, 122);
            this.dvMinus.Name = "dvMinus";
            this.dvMinus.RowHeadersVisible = false;
            this.dvMinus.RowTemplate.Height = 24;
            this.dvMinus.Size = new System.Drawing.Size(233, 278);
            this.dvMinus.TabIndex = 18;
            this.dvMinus.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvPlus_RowValidated);
            this.dvMinus.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dvPlus_RowValidating);
            // 
            // bsSalcodeMinus
            // 
            this.bsSalcodeMinus.DataMember = "SALCODE";
            this.bsSalcodeMinus.DataSource = this.dsMinus;
            // 
            // dsMinus
            // 
            this.dsMinus.DataSetName = "SalaryDS";
            this.dsMinus.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsMinus.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsWageMinus
            // 
            this.bsWageMinus.DataMember = "WAGED";
            this.bsWageMinus.DataSource = this.dsMinus;
            // 
            // dvPlus
            // 
            this.dvPlus.AutoGenerateColumns = false;
            this.dvPlus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvPlus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvPlus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SAL_CODE,
            this.sALCODEDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn});
            this.dvPlus.DataSource = this.bsWagedPlus;
            this.dvPlus.Location = new System.Drawing.Point(23, 122);
            this.dvPlus.Name = "dvPlus";
            this.dvPlus.RowHeadersVisible = false;
            this.dvPlus.RowTemplate.Height = 24;
            this.dvPlus.Size = new System.Drawing.Size(233, 278);
            this.dvPlus.TabIndex = 18;
            this.dvPlus.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvPlus_RowValidated);
            this.dvPlus.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dvPlus_RowValidating);
            // 
            // bsSalcodePlus
            // 
            this.bsSalcodePlus.DataMember = "SALCODE";
            this.bsSalcodePlus.DataSource = this.dsPlus;
            // 
            // bsWagedPlus
            // 
            this.bsWagedPlus.DataMember = "WAGED";
            this.bsWagedPlus.DataSource = this.dsPlus;
            // 
            // txtSalDateE
            // 
            this.txtSalDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSalDateE.CaptionLabel = null;
            this.txtSalDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSalDateE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "DATE_E", true));
            this.txtSalDateE.DecimalPlace = 2;
            this.txtSalDateE.IsEmpty = true;
            this.txtSalDateE.Location = new System.Drawing.Point(192, 94);
            this.txtSalDateE.Mask = "0000/00/00";
            this.txtSalDateE.MaxLength = -1;
            this.txtSalDateE.Name = "txtSalDateE";
            this.txtSalDateE.PasswordChar = '\0';
            this.txtSalDateE.ReadOnly = false;
            this.txtSalDateE.ShowCalendarButton = true;
            this.txtSalDateE.Size = new System.Drawing.Size(95, 22);
            this.txtSalDateE.TabIndex = 17;
            this.txtSalDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(26, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "發放年月";
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = this.label22;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = true;
            this.txtSeq.Location = new System.Drawing.Point(206, 10);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = -1;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(34, 22);
            this.txtSeq.TabIndex = 2;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            this.txtSeq.Validated += new System.EventHandler(this.txtSeq_Validated);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(147, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 15;
            this.label22.Text = "發放期別";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(26, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "計算起日";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.wAGEBindingSource, "CASH", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(679, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "現金";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtSalDateB
            // 
            this.txtSalDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSalDateB.CaptionLabel = this.label13;
            this.txtSalDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSalDateB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "DATE_B", true));
            this.txtSalDateB.DecimalPlace = 2;
            this.txtSalDateB.IsEmpty = true;
            this.txtSalDateB.Location = new System.Drawing.Point(85, 94);
            this.txtSalDateB.Mask = "0000/00/00";
            this.txtSalDateB.MaxLength = -1;
            this.txtSalDateB.Name = "txtSalDateB";
            this.txtSalDateB.PasswordChar = '\0';
            this.txtSalDateB.ReadOnly = false;
            this.txtSalDateB.ShowCalendarButton = true;
            this.txtSalDateB.Size = new System.Drawing.Size(95, 22);
            this.txtSalDateB.TabIndex = 7;
            this.txtSalDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(305, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "備註";
            // 
            // txtYymm
            // 
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = this.label10;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = true;
            this.txtYymm.Location = new System.Drawing.Point(85, 10);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = -1;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(62, 22);
            this.txtYymm.TabIndex = 1;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
            this.txtYymm.Validated += new System.EventHandler(this.txtYymm_Validated);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label21, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.textBox20, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.textBox21, 1, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(570, 7);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(107, 85);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(3, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "公司別";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(15, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 1;
            this.label21.Text = "稅率";
            // 
            // textBox20
            // 
            this.textBox20.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox20.CaptionLabel = this.label20;
            this.textBox20.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox20.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "COMP", true));
            this.textBox20.DecimalPlace = 2;
            this.textBox20.Enabled = false;
            this.textBox20.IsEmpty = true;
            this.textBox20.Location = new System.Drawing.Point(50, 3);
            this.textBox20.Mask = "";
            this.textBox20.MaxLength = 50;
            this.textBox20.Name = "textBox20";
            this.textBox20.PasswordChar = '\0';
            this.textBox20.ReadOnly = true;
            this.textBox20.ShowCalendarButton = true;
            this.textBox20.Size = new System.Drawing.Size(53, 22);
            this.textBox20.TabIndex = 2;
            this.textBox20.TabStop = false;
            this.textBox20.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox21
            // 
            this.textBox21.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox21.CaptionLabel = this.label21;
            this.textBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox21.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "TAXRATE", true));
            this.textBox21.DecimalPlace = 2;
            this.textBox21.Enabled = false;
            this.textBox21.IsEmpty = true;
            this.textBox21.Location = new System.Drawing.Point(50, 31);
            this.textBox21.Mask = "";
            this.textBox21.MaxLength = -1;
            this.textBox21.Name = "textBox21";
            this.textBox21.PasswordChar = '\0';
            this.textBox21.ReadOnly = true;
            this.textBox21.ShowCalendarButton = true;
            this.textBox21.Size = new System.Drawing.Size(53, 22);
            this.textBox21.TabIndex = 3;
            this.textBox21.TabStop = false;
            this.textBox21.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.textBox17, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.textBox18, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.txtBankTeco, 1, 2);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(442, 7);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(129, 85);
            this.tableLayoutPanel6.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(15, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "工作天";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(3, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "薪資群組";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(3, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 2;
            this.label19.Text = "轉帳代扣";
            // 
            // textBox17
            // 
            this.textBox17.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox17.CaptionLabel = this.label17;
            this.textBox17.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox17.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "WK_DAYS", true));
            this.textBox17.DecimalPlace = 2;
            this.textBox17.IsEmpty = true;
            this.textBox17.Location = new System.Drawing.Point(62, 3);
            this.textBox17.Mask = "";
            this.textBox17.MaxLength = -1;
            this.textBox17.Name = "textBox17";
            this.textBox17.PasswordChar = '\0';
            this.textBox17.ReadOnly = false;
            this.textBox17.ShowCalendarButton = true;
            this.textBox17.Size = new System.Drawing.Size(51, 22);
            this.textBox17.TabIndex = 3;
            this.textBox17.TabStop = false;
            this.textBox17.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox18
            // 
            this.textBox18.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox18.CaptionLabel = this.label18;
            this.textBox18.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox18.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "SALADR", true));
            this.textBox18.DecimalPlace = 2;
            this.textBox18.Enabled = false;
            this.textBox18.IsEmpty = true;
            this.textBox18.Location = new System.Drawing.Point(62, 31);
            this.textBox18.Mask = "";
            this.textBox18.MaxLength = 50;
            this.textBox18.Name = "textBox18";
            this.textBox18.PasswordChar = '\0';
            this.textBox18.ReadOnly = true;
            this.textBox18.ShowCalendarButton = true;
            this.textBox18.Size = new System.Drawing.Size(51, 22);
            this.textBox18.TabIndex = 4;
            this.textBox18.TabStop = false;
            this.textBox18.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtBankTeco
            // 
            this.txtBankTeco.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBankTeco.CaptionLabel = this.label19;
            this.txtBankTeco.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBankTeco.DecimalPlace = 2;
            this.txtBankTeco.Enabled = false;
            this.txtBankTeco.IsEmpty = true;
            this.txtBankTeco.Location = new System.Drawing.Point(62, 59);
            this.txtBankTeco.Mask = "";
            this.txtBankTeco.MaxLength = -1;
            this.txtBankTeco.Name = "txtBankTeco";
            this.txtBankTeco.PasswordChar = '\0';
            this.txtBankTeco.ReadOnly = true;
            this.txtBankTeco.ShowCalendarButton = true;
            this.txtBankTeco.Size = new System.Drawing.Size(63, 22);
            this.txtBankTeco.TabIndex = 5;
            this.txtBankTeco.TabStop = false;
            this.txtBankTeco.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox16
            // 
            this.textBox16.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox16.CaptionLabel = this.label16;
            this.textBox16.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox16.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "NOTE", true));
            this.textBox16.DecimalPlace = 2;
            this.textBox16.IsEmpty = true;
            this.textBox16.Location = new System.Drawing.Point(340, 94);
            this.textBox16.Mask = "";
            this.textBox16.MaxLength = 500;
            this.textBox16.Name = "textBox16";
            this.textBox16.PasswordChar = '\0';
            this.textBox16.ReadOnly = false;
            this.textBox16.ShowCalendarButton = true;
            this.textBox16.Size = new System.Drawing.Size(245, 22);
            this.textBox16.TabIndex = 5;
            this.textBox16.TabStop = false;
            this.textBox16.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox14, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(278, 35);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(166, 57);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBox1.BackColor = System.Drawing.Color.Transparent;
            this.comboBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBox1.CaptionLabel = this.label15;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.wAGEBindingSource, "FORMAT", true));
            this.comboBox1.DataSource = this.yRFORMATBindingSource;
            this.comboBox1.DisplayMember = "m_fmt_name";
            this.comboBox1.DropDownCount = 10;
            this.comboBox1.IsDisplayValueLabel = true;
            this.comboBox1.IsEmpty = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedValue = "";
            this.comboBox1.Size = new System.Drawing.Size(100, 22);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.TabStop = false;
            this.comboBox1.ValueMember = "m_format";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(3, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "媒體格式";
            // 
            // yRFORMATBindingSource
            // 
            this.yRFORMATBindingSource.DataMember = "YRFORMAT";
            this.yRFORMATBindingSource.DataSource = this.medDS;
            // 
            // medDS
            // 
            this.medDS.DataSetName = "MedDS";
            this.medDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.medDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox14
            // 
            this.textBox14.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox14.CaptionLabel = this.label14;
            this.textBox14.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "ACCOUNT_NO", true));
            this.textBox14.DecimalPlace = 2;
            this.textBox14.IsEmpty = true;
            this.textBox14.Location = new System.Drawing.Point(62, 3);
            this.textBox14.Mask = "";
            this.textBox14.MaxLength = 50;
            this.textBox14.Name = "textBox14";
            this.textBox14.PasswordChar = '\0';
            this.textBox14.ReadOnly = false;
            this.textBox14.ShowCalendarButton = true;
            this.textBox14.Size = new System.Drawing.Size(100, 22);
            this.textBox14.TabIndex = 3;
            this.textBox14.TabStop = false;
            this.textBox14.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(3, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "轉帳帳號";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBox12, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.ptxNobr, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(23, 35);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(217, 57);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(3, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "員工編號";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "轉帳日期";
            // 
            // textBox12
            // 
            this.textBox12.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox12.CaptionLabel = this.label12;
            this.textBox12.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wAGEBindingSource, "ADATE", true));
            this.textBox12.DecimalPlace = 2;
            this.textBox12.IsEmpty = true;
            this.textBox12.Location = new System.Drawing.Point(62, 31);
            this.textBox12.Mask = "0000/00/00";
            this.textBox12.MaxLength = -1;
            this.textBox12.Name = "textBox12";
            this.textBox12.PasswordChar = '\0';
            this.textBox12.ReadOnly = false;
            this.textBox12.ShowCalendarButton = true;
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 6;
            this.textBox12.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label11;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataSource = this.vBASEBindingSource;
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
            this.ptxNobr.TabIndex = 3;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.txtTaxAmt, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtTecoTotal, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTotalAmt, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(594, 415);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(165, 84);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // txtTaxAmt
            // 
            this.txtTaxAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTaxAmt.CaptionLabel = null;
            this.txtTaxAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTaxAmt.DecimalPlace = 2;
            this.txtTaxAmt.Enabled = false;
            this.txtTaxAmt.IsEmpty = true;
            this.txtTaxAmt.Location = new System.Drawing.Point(62, 59);
            this.txtTaxAmt.Mask = "";
            this.txtTaxAmt.MaxLength = -1;
            this.txtTaxAmt.Name = "txtTaxAmt";
            this.txtTaxAmt.PasswordChar = '\0';
            this.txtTaxAmt.ReadOnly = true;
            this.txtTaxAmt.ShowCalendarButton = true;
            this.txtTaxAmt.Size = new System.Drawing.Size(100, 22);
            this.txtTaxAmt.TabIndex = 6;
            this.txtTaxAmt.TabStop = false;
            this.txtTaxAmt.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "代扣合計";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "所得稅";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "實付薪資";
            // 
            // txtTecoTotal
            // 
            this.txtTecoTotal.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTecoTotal.CaptionLabel = null;
            this.txtTecoTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTecoTotal.DecimalPlace = 2;
            this.txtTecoTotal.Enabled = false;
            this.txtTecoTotal.IsEmpty = true;
            this.txtTecoTotal.Location = new System.Drawing.Point(62, 3);
            this.txtTecoTotal.Mask = "";
            this.txtTecoTotal.MaxLength = -1;
            this.txtTecoTotal.Name = "txtTecoTotal";
            this.txtTecoTotal.PasswordChar = '\0';
            this.txtTecoTotal.ReadOnly = true;
            this.txtTecoTotal.ShowCalendarButton = true;
            this.txtTecoTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTecoTotal.TabIndex = 3;
            this.txtTecoTotal.TabStop = false;
            this.txtTecoTotal.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTotalAmt.CaptionLabel = null;
            this.txtTotalAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTotalAmt.DecimalPlace = 2;
            this.txtTotalAmt.Enabled = false;
            this.txtTotalAmt.IsEmpty = true;
            this.txtTotalAmt.Location = new System.Drawing.Point(62, 31);
            this.txtTotalAmt.Mask = "";
            this.txtTotalAmt.MaxLength = -1;
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.PasswordChar = '\0';
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.ShowCalendarButton = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(100, 22);
            this.txtTotalAmt.TabIndex = 4;
            this.txtTotalAmt.TabStop = false;
            this.txtTotalAmt.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCut, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCutTax, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTaxTotal, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(276, 415);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(226, 84);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "應扣合計";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "應稅部分";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "應稅薪資";
            // 
            // txtCut
            // 
            this.txtCut.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCut.CaptionLabel = null;
            this.txtCut.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCut.DecimalPlace = 2;
            this.txtCut.Enabled = false;
            this.txtCut.IsEmpty = true;
            this.txtCut.Location = new System.Drawing.Point(62, 3);
            this.txtCut.Mask = "";
            this.txtCut.MaxLength = -1;
            this.txtCut.Name = "txtCut";
            this.txtCut.PasswordChar = '\0';
            this.txtCut.ReadOnly = true;
            this.txtCut.ShowCalendarButton = true;
            this.txtCut.Size = new System.Drawing.Size(100, 22);
            this.txtCut.TabIndex = 3;
            this.txtCut.TabStop = false;
            this.txtCut.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtCutTax
            // 
            this.txtCutTax.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCutTax.CaptionLabel = null;
            this.txtCutTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCutTax.DecimalPlace = 2;
            this.txtCutTax.Enabled = false;
            this.txtCutTax.IsEmpty = true;
            this.txtCutTax.Location = new System.Drawing.Point(62, 31);
            this.txtCutTax.Mask = "";
            this.txtCutTax.MaxLength = -1;
            this.txtCutTax.Name = "txtCutTax";
            this.txtCutTax.PasswordChar = '\0';
            this.txtCutTax.ReadOnly = true;
            this.txtCutTax.ShowCalendarButton = true;
            this.txtCutTax.Size = new System.Drawing.Size(100, 22);
            this.txtCutTax.TabIndex = 4;
            this.txtCutTax.TabStop = false;
            this.txtCutTax.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtTaxTotal
            // 
            this.txtTaxTotal.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTaxTotal.CaptionLabel = null;
            this.txtTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTaxTotal.DecimalPlace = 2;
            this.txtTaxTotal.Enabled = false;
            this.txtTaxTotal.IsEmpty = true;
            this.txtTaxTotal.Location = new System.Drawing.Point(62, 59);
            this.txtTaxTotal.Mask = "";
            this.txtTaxTotal.MaxLength = -1;
            this.txtTaxTotal.Name = "txtTaxTotal";
            this.txtTaxTotal.PasswordChar = '\0';
            this.txtTaxTotal.ReadOnly = true;
            this.txtTaxTotal.ShowCalendarButton = true;
            this.txtTaxTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTaxTotal.TabIndex = 5;
            this.txtTaxTotal.TabStop = false;
            this.txtTaxTotal.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPayAmt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPayTax, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPayTotal, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 415);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 84);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "應發薪資";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "應稅部分";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "應付薪資";
            // 
            // txtPayAmt
            // 
            this.txtPayAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayAmt.CaptionLabel = null;
            this.txtPayAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayAmt.DecimalPlace = 2;
            this.txtPayAmt.Enabled = false;
            this.txtPayAmt.IsEmpty = true;
            this.txtPayAmt.Location = new System.Drawing.Point(62, 3);
            this.txtPayAmt.Mask = "";
            this.txtPayAmt.MaxLength = -1;
            this.txtPayAmt.Name = "txtPayAmt";
            this.txtPayAmt.PasswordChar = '\0';
            this.txtPayAmt.ReadOnly = true;
            this.txtPayAmt.ShowCalendarButton = true;
            this.txtPayAmt.Size = new System.Drawing.Size(100, 22);
            this.txtPayAmt.TabIndex = 3;
            this.txtPayAmt.TabStop = false;
            this.txtPayAmt.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtPayTax
            // 
            this.txtPayTax.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayTax.CaptionLabel = null;
            this.txtPayTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayTax.DecimalPlace = 2;
            this.txtPayTax.Enabled = false;
            this.txtPayTax.IsEmpty = true;
            this.txtPayTax.Location = new System.Drawing.Point(62, 31);
            this.txtPayTax.Mask = "";
            this.txtPayTax.MaxLength = -1;
            this.txtPayTax.Name = "txtPayTax";
            this.txtPayTax.PasswordChar = '\0';
            this.txtPayTax.ReadOnly = true;
            this.txtPayTax.ShowCalendarButton = true;
            this.txtPayTax.Size = new System.Drawing.Size(100, 22);
            this.txtPayTax.TabIndex = 4;
            this.txtPayTax.TabStop = false;
            this.txtPayTax.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtPayTotal
            // 
            this.txtPayTotal.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayTotal.CaptionLabel = null;
            this.txtPayTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayTotal.DecimalPlace = 2;
            this.txtPayTotal.Enabled = false;
            this.txtPayTotal.IsEmpty = true;
            this.txtPayTotal.Location = new System.Drawing.Point(62, 59);
            this.txtPayTotal.Mask = "";
            this.txtPayTotal.MaxLength = -1;
            this.txtPayTotal.Name = "txtPayTotal";
            this.txtPayTotal.PasswordChar = '\0';
            this.txtPayTotal.ReadOnly = true;
            this.txtPayTotal.ShowCalendarButton = true;
            this.txtPayTotal.Size = new System.Drawing.Size(100, 22);
            this.txtPayTotal.TabIndex = 5;
            this.txtPayTotal.TabStop = false;
            this.txtPayTotal.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(759, 481);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(167, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Visible = false;
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
            // 
            // wAGETableAdapter
            // 
            this.wAGETableAdapter.ClearBeforeFill = true;
            // 
            // wAGEDTableAdapter
            // 
            this.wAGEDTableAdapter.ClearBeforeFill = true;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // yRFORMATTableAdapter
            // 
            this.yRFORMATTableAdapter.ClearBeforeFill = true;
            // 
            // SAL_CODE
            // 
            this.SAL_CODE.DataPropertyName = "SAL_CODE";
            this.SAL_CODE.DataSource = this.bsSalcodePlus;
            this.SAL_CODE.DisplayMember = "SAL_NAME";
            this.SAL_CODE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SAL_CODE.HeaderText = "薪資科目";
            this.SAL_CODE.Name = "SAL_CODE";
            this.SAL_CODE.ValueMember = "SAL_CODE";
            // 
            // sALCODEDataGridViewTextBoxColumn
            // 
            this.sALCODEDataGridViewTextBoxColumn.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn.DataSource = this.bsSalcodePlus;
            this.sALCODEDataGridViewTextBoxColumn.DisplayMember = "SAL_CODE_DISP";
            this.sALCODEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sALCODEDataGridViewTextBoxColumn.HeaderText = "薪資代碼";
            this.sALCODEDataGridViewTextBoxColumn.Name = "sALCODEDataGridViewTextBoxColumn";
            this.sALCODEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sALCODEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sALCODEDataGridViewTextBoxColumn.ValueMember = "SAL_CODE";
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "SAL_CODE";
            this.dataGridViewComboBoxColumn2.DataSource = this.bsSalcodeMinus;
            this.dataGridViewComboBoxColumn2.DisplayMember = "SAL_NAME";
            this.dataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn2.HeaderText = "薪資科目";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.ValueMember = "SAL_CODE";
            // 
            // sALCODEDataGridViewTextBoxColumn1
            // 
            this.sALCODEDataGridViewTextBoxColumn1.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn1.DataSource = this.bsSalcodeMinus;
            this.sALCODEDataGridViewTextBoxColumn1.DisplayMember = "SAL_CODE_DISP";
            this.sALCODEDataGridViewTextBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sALCODEDataGridViewTextBoxColumn1.HeaderText = "薪資代碼";
            this.sALCODEDataGridViewTextBoxColumn1.Name = "sALCODEDataGridViewTextBoxColumn1";
            this.sALCODEDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sALCODEDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sALCODEDataGridViewTextBoxColumn1.ValueMember = "SAL_CODE";
            // 
            // aMTDataGridViewTextBoxColumn1
            // 
            this.aMTDataGridViewTextBoxColumn1.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn1.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn1.Name = "aMTDataGridViewTextBoxColumn1";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "SAL_CODE";
            this.dataGridViewComboBoxColumn1.DataSource = this.bsSalcodeTeco;
            this.dataGridViewComboBoxColumn1.DisplayMember = "SAL_NAME";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.HeaderText = "薪資科目";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ValueMember = "SAL_CODE";
            // 
            // sALCODEDataGridViewTextBoxColumn2
            // 
            this.sALCODEDataGridViewTextBoxColumn2.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn2.DataSource = this.bsSalcodeTeco;
            this.sALCODEDataGridViewTextBoxColumn2.DisplayMember = "SAL_CODE_DISP";
            this.sALCODEDataGridViewTextBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sALCODEDataGridViewTextBoxColumn2.HeaderText = "薪資代碼";
            this.sALCODEDataGridViewTextBoxColumn2.Name = "sALCODEDataGridViewTextBoxColumn2";
            this.sALCODEDataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sALCODEDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sALCODEDataGridViewTextBoxColumn2.ValueMember = "SAL_CODE";
            // 
            // aMTDataGridViewTextBoxColumn2
            // 
            this.aMTDataGridViewTextBoxColumn2.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn2.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn2.Name = "aMTDataGridViewTextBoxColumn2";
            // 
            // FRM45
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM45";
            this.Text = "FRM45";
            this.Load += new System.EventHandler(this.FRM45_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wAGEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvTeco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalcodeTeco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTeco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWageTeco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalcodeMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWageMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSalcodePlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWagedPlus)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private SalaryDS dsPlus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox txtCut;
        private JBControls.TextBox txtCutTax;
        private JBControls.TextBox txtTaxTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox txtPayAmt;
        private JBControls.TextBox txtPayTax;
        private JBControls.TextBox txtPayTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox txtTecoTotal;
        private JBControls.TextBox txtTotalAmt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private JBControls.TextBox txtTaxAmt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private JBControls.TextBox txtYymm;
        private JBControls.TextBox textBox12;
        private JBControls.TextBox txtSalDateB;
        private JBHR.Sal.SalaryDSTableAdapters.WAGETableAdapter wAGETableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private JBControls.TextBox textBox14;
        private JBControls.TextBox textBox16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private JBControls.TextBox textBox17;
        private JBControls.TextBox textBox18;
        private JBControls.TextBox txtBankTeco;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private JBControls.TextBox textBox20;
        private JBControls.TextBox textBox21;
        private JBControls.CheckBox checkBox1;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.Label label22;
        private JBControls.ComboBox comboBox1;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtSalDateE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ViewDS viewDS;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.BindingSource bsWagedPlus;
        private JBHR.Sal.SalaryDSTableAdapters.WAGEDTableAdapter wAGEDTableAdapter;
        private JBControls.DataGridView dvTeco;
        private JBControls.DataGridView dvMinus;
        private JBControls.DataGridView dvPlus;
        private System.Windows.Forms.BindingSource bsSalcodePlus;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.BindingSource bsWageMinus;
        private System.Windows.Forms.BindingSource bsWageTeco;
        private SalaryDS dsMinus;
        private SalaryDS dsTeco;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource wAGEBindingSource;
        private System.Windows.Forms.BindingSource bsSalcodeMinus;
        private System.Windows.Forms.BindingSource bsSalcodeTeco;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOT;
        private System.Windows.Forms.Button btnAtt;
        private System.Windows.Forms.Button btnAbs;
        private JBControls.TextBox textBox1;
        private JBControls.TextBox textBox2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnInslab;
        private System.Windows.Forms.Button btnBase;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private Bas.BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private Med.MedDS medDS;
        private System.Windows.Forms.BindingSource yRFORMATBindingSource;
        private Med.MedDSTableAdapters.YRFORMATTableAdapter yRFORMATTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn SAL_CODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;

    }
}