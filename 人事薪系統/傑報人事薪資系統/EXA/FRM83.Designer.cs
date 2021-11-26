namespace JBHR.EXA
{
	partial class FRM83
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
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eFFTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exa = new JBHR.EXA.exa();
            this.eFFSCOREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFLVLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eFFLVLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iMPORTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFEMPLOYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnIMPORT = new System.Windows.Forms.Button();
            this.cbEFFLVL = new System.Windows.Forms.ComboBox();
            this.cbDEPT = new System.Windows.Forms.ComboBox();
            this.cbEFFTYPE = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNOBR = new JBControls.PopupTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEFFSCORE = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYYMM = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.eFFEMPLOYTableAdapter = new JBHR.EXA.exaTableAdapters.EFFEMPLOYTableAdapter();
            this.eFFTYPETableAdapter = new JBHR.EXA.exaTableAdapters.EFFTYPETableAdapter();
            this.eFFLVLTableAdapter = new JBHR.EXA.exaTableAdapters.EFFLVLTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFLVLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFEMPLOYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(620, 424);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yYMMDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.eFFTYPEDataGridViewTextBoxColumn,
            this.eFFSCOREDataGridViewTextBoxColumn,
            this.eFFLVLDataGridViewTextBoxColumn,
            this.iMPORTDataGridViewCheckBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewEx1.DataSource = this.eFFEMPLOYBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowHeadersWidth = 62;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(620, 218);
            this.dataGridViewEx1.TabIndex = 8;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            this.dataGridViewEx1.SelectionChanged += new System.EventHandler(this.dataGridViewEx1_SelectionChanged);
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "績效年度";
            this.yYMMDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            this.yYMMDataGridViewTextBoxColumn.Width = 116;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NOBR";
            this.dataGridViewTextBoxColumn1.HeaderText = "員工編號";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 116;
            // 
            // eFFTYPEDataGridViewTextBoxColumn
            // 
            this.eFFTYPEDataGridViewTextBoxColumn.DataPropertyName = "EFFTYPE";
            this.eFFTYPEDataGridViewTextBoxColumn.DataSource = this.eFFTYPEBindingSource;
            this.eFFTYPEDataGridViewTextBoxColumn.DisplayMember = "EFFTYPE_NAME";
            this.eFFTYPEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.eFFTYPEDataGridViewTextBoxColumn.HeaderText = "考核種類";
            this.eFFTYPEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.eFFTYPEDataGridViewTextBoxColumn.Name = "eFFTYPEDataGridViewTextBoxColumn";
            this.eFFTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFTYPEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eFFTYPEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eFFTYPEDataGridViewTextBoxColumn.ValueMember = "EFFTYPE";
            this.eFFTYPEDataGridViewTextBoxColumn.Width = 116;
            // 
            // eFFTYPEBindingSource
            // 
            this.eFFTYPEBindingSource.DataMember = "EFFTYPE";
            this.eFFTYPEBindingSource.DataSource = this.exa;
            // 
            // exa
            // 
            this.exa.DataSetName = "exa";
            this.exa.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.exa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eFFSCOREDataGridViewTextBoxColumn
            // 
            this.eFFSCOREDataGridViewTextBoxColumn.DataPropertyName = "EFFSCORE";
            this.eFFSCOREDataGridViewTextBoxColumn.HeaderText = "考核分數";
            this.eFFSCOREDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.eFFSCOREDataGridViewTextBoxColumn.Name = "eFFSCOREDataGridViewTextBoxColumn";
            this.eFFSCOREDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFSCOREDataGridViewTextBoxColumn.Width = 116;
            // 
            // eFFLVLDataGridViewTextBoxColumn
            // 
            this.eFFLVLDataGridViewTextBoxColumn.DataPropertyName = "EFFLVL";
            this.eFFLVLDataGridViewTextBoxColumn.DataSource = this.eFFLVLBindingSource;
            this.eFFLVLDataGridViewTextBoxColumn.DisplayMember = "EFFLVL_NAME";
            this.eFFLVLDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.eFFLVLDataGridViewTextBoxColumn.HeaderText = "考核等級";
            this.eFFLVLDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.eFFLVLDataGridViewTextBoxColumn.Name = "eFFLVLDataGridViewTextBoxColumn";
            this.eFFLVLDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFLVLDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eFFLVLDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eFFLVLDataGridViewTextBoxColumn.ValueMember = "EFFLVL";
            this.eFFLVLDataGridViewTextBoxColumn.Width = 116;
            // 
            // eFFLVLBindingSource
            // 
            this.eFFLVLBindingSource.DataMember = "EFFLVL";
            this.eFFLVLBindingSource.DataSource = this.exa;
            // 
            // iMPORTDataGridViewCheckBoxColumn
            // 
            this.iMPORTDataGridViewCheckBoxColumn.DataPropertyName = "IMPORT";
            this.iMPORTDataGridViewCheckBoxColumn.HeaderText = "匯入否";
            this.iMPORTDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.iMPORTDataGridViewCheckBoxColumn.Name = "iMPORTDataGridViewCheckBoxColumn";
            this.iMPORTDataGridViewCheckBoxColumn.ReadOnly = true;
            this.iMPORTDataGridViewCheckBoxColumn.Visible = false;
            this.iMPORTDataGridViewCheckBoxColumn.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "KEY_DATE";
            this.dataGridViewTextBoxColumn2.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 116;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KEY_MAN";
            this.dataGridViewTextBoxColumn3.HeaderText = "建檔人員";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 116;
            // 
            // eFFEMPLOYBindingSource
            // 
            this.eFFEMPLOYBindingSource.DataMember = "EFFEMPLOY";
            this.eFFEMPLOYBindingSource.DataSource = this.exa;
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
            this.splitContainer2.Size = new System.Drawing.Size(620, 202);
            this.splitContainer2.SplitterDistance = 120;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bnIMPORT);
            this.panel1.Controls.Add(this.cbEFFLVL);
            this.panel1.Controls.Add(this.cbDEPT);
            this.panel1.Controls.Add(this.cbEFFTYPE);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNOBR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEFFSCORE);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtYYMM);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 120);
            this.panel1.TabIndex = 0;
            // 
            // bnIMPORT
            // 
            this.bnIMPORT.Location = new System.Drawing.Point(538, 103);
            this.bnIMPORT.Name = "bnIMPORT";
            this.bnIMPORT.Size = new System.Drawing.Size(75, 23);
            this.bnIMPORT.TabIndex = 7;
            this.bnIMPORT.TabStop = false;
            this.bnIMPORT.Text = "匯入";
            this.bnIMPORT.UseVisualStyleBackColor = true;
            this.bnIMPORT.Click += new System.EventHandler(this.bnIMPORT_Click);
            // 
            // cbEFFLVL
            // 
            this.cbEFFLVL.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFFEMPLOYBindingSource, "EFFLVL", true));
            this.cbEFFLVL.FormattingEnabled = true;
            this.cbEFFLVL.Location = new System.Drawing.Point(271, 102);
            this.cbEFFLVL.Name = "cbEFFLVL";
            this.cbEFFLVL.Size = new System.Drawing.Size(100, 26);
            this.cbEFFLVL.TabIndex = 5;
            // 
            // cbDEPT
            // 
            this.cbDEPT.Enabled = false;
            this.cbDEPT.FormattingEnabled = true;
            this.cbDEPT.Location = new System.Drawing.Point(96, 76);
            this.cbDEPT.Name = "cbDEPT";
            this.cbDEPT.Size = new System.Drawing.Size(100, 26);
            this.cbDEPT.TabIndex = 3;
            this.cbDEPT.TabStop = false;
            // 
            // cbEFFTYPE
            // 
            this.cbEFFTYPE.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFFEMPLOYBindingSource, "EFFTYPE", true));
            this.cbEFFTYPE.FormattingEnabled = true;
            this.cbEFFTYPE.Location = new System.Drawing.Point(96, 28);
            this.cbEFFTYPE.Name = "cbEFFTYPE";
            this.cbEFFTYPE.Size = new System.Drawing.Size(100, 26);
            this.cbEFFTYPE.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(212, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "考核等級";
            // 
            // txtNOBR
            // 
            this.txtNOBR.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNOBR.CaptionLabel = this.label4;
            this.txtNOBR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNOBR.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFEMPLOYBindingSource, "NOBR", true));
            this.txtNOBR.DataSource = this.vBASEBindingSource;
            this.txtNOBR.DisplayMember = "name_c";
            this.txtNOBR.IsEmpty = false;
            this.txtNOBR.IsEmptyToQuery = true;
            this.txtNOBR.IsMustBeFound = true;
            this.txtNOBR.LabelText = "";
            this.txtNOBR.Location = new System.Drawing.Point(96, 51);
            this.txtNOBR.Name = "txtNOBR";
            this.txtNOBR.QueryFields = "name_e,name_p";
            this.txtNOBR.ReadOnly = false;
            this.txtNOBR.ShowDisplayName = true;
            this.txtNOBR.Size = new System.Drawing.Size(100, 22);
            this.txtNOBR.TabIndex = 2;
            this.txtNOBR.ValueMember = "nobr";
            this.txtNOBR.WhereCmd = "";
            this.txtNOBR.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.txtNOBR_QueryCompleted);
            this.txtNOBR.Validated += new System.EventHandler(this.txtNOBR_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(10, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "員工編號";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(37, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "部門名稱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(37, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "考核種類";
            // 
            // txtEFFSCORE
            // 
            this.txtEFFSCORE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFSCORE.CaptionLabel = this.label6;
            this.txtEFFSCORE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFSCORE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFEMPLOYBindingSource, "EFFSCORE", true));
            this.txtEFFSCORE.DecimalPlace = 2;
            this.txtEFFSCORE.IsEmpty = false;
            this.txtEFFSCORE.Location = new System.Drawing.Point(96, 100);
            this.txtEFFSCORE.Mask = "";
            this.txtEFFSCORE.MaxLength = -1;
            this.txtEFFSCORE.Name = "txtEFFSCORE";
            this.txtEFFSCORE.PasswordChar = '\0';
            this.txtEFFSCORE.ReadOnly = false;
            this.txtEFFSCORE.ShowCalendarButton = true;
            this.txtEFFSCORE.Size = new System.Drawing.Size(100, 29);
            this.txtEFFSCORE.TabIndex = 4;
            this.txtEFFSCORE.ValidType = JBControls.TextBox.EValidType.Decimal;
            this.txtEFFSCORE.Validated += new System.EventHandler(this.txtEFFSCORE_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(37, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "考核分數";
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = this.label2;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFEMPLOYBindingSource, "YYMM", true));
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.IsEmpty = false;
            this.txtYYMM.Location = new System.Drawing.Point(96, 3);
            this.txtYYMM.Mask = "0000";
            this.txtYYMM.MaxLength = 50;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.ShowCalendarButton = true;
            this.txtYYMM.Size = new System.Drawing.Size(100, 29);
            this.txtYYMM.TabIndex = 0;
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(37, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "績效年度";
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
            this.fullDataCtrl1.DataGrid = this.dataGridViewEx1;
            this.fullDataCtrl1.DataSource = this.eFFEMPLOYBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "fa_idno,fa_name,nobr";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(620, 73);
            this.fullDataCtrl1.SortFields = "fa_idno,fa_name,nobr";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
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
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // eFFEMPLOYTableAdapter
            // 
            this.eFFEMPLOYTableAdapter.ClearBeforeFill = true;
            // 
            // eFFTYPETableAdapter
            // 
            this.eFFTYPETableAdapter.ClearBeforeFill = true;
            // 
            // eFFLVLTableAdapter
            // 
            this.eFFLVLTableAdapter.ClearBeforeFill = true;
            // 
            // FRM83
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 424);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM83";
            this.Text = "FRM83";
            this.Load += new System.EventHandler(this.FRM83_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFLVLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFEMPLOYBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private JBControls.FullDataCtrl fullDataCtrl1;
		private JBControls.DataGridView dataGridViewEx1;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
		private JBControls.TextBox txtYYMM;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
        private JBControls.PopupTextBox txtNOBR;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbEFFTYPE;
        private exa exa;
        private System.Windows.Forms.BindingSource eFFEMPLOYBindingSource;
        private exaTableAdapters.EFFEMPLOYTableAdapter eFFEMPLOYTableAdapter;
        private System.Windows.Forms.ComboBox cbDEPT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEFFLVL;
        private System.Windows.Forms.Label label5;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource eFFTYPEBindingSource;
        private exaTableAdapters.EFFTYPETableAdapter eFFTYPETableAdapter;
        private System.Windows.Forms.BindingSource eFFLVLBindingSource;
        private exaTableAdapters.EFFLVLTableAdapter eFFLVLTableAdapter;
        private JBControls.TextBox txtEFFSCORE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn eFFTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFSCOREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn eFFLVLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iMPORTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button bnIMPORT;
    }
}