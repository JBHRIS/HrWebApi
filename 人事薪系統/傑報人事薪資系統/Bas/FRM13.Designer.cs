namespace JBHR.Bas
{
	partial class FRM13
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
            this.CheckFaIdno = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.fANAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fAIDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rELCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.rELCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fABIRDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fAMILYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnIMPORT = new System.Windows.Forms.Button();
            this.cbRELCODE = new System.Windows.Forms.ComboBox();
            this.popupTextBox1 = new JBControls.PopupTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new JBControls.MemoTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fAMILYTableAdapter = new JBHR.Bas.BasDSTableAdapters.FAMILYTableAdapter();
            this.rELCODETableAdapter = new JBHR.Bas.BasDSTableAdapters.RELCODETableAdapter();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rELCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 226;
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
            this.CheckFaIdno,
            this.nOBRDataGridViewTextBoxColumn,
            this.fANAMEDataGridViewTextBoxColumn,
            this.fAIDNODataGridViewTextBoxColumn,
            this.rELCODEDataGridViewTextBoxColumn,
            this.fABIRDTDataGridViewTextBoxColumn,
            this.aDDRDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.fAMILYBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowHeadersWidth = 62;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 226);
            this.dataGridViewEx1.TabIndex = 8;
            this.dataGridViewEx1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEx1_CellContentClick);
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // CheckFaIdno
            // 
            this.CheckFaIdno.HeaderText = "選取";
            this.CheckFaIdno.MinimumWidth = 8;
            this.CheckFaIdno.Name = "CheckFaIdno";
            this.CheckFaIdno.ReadOnly = true;
            this.CheckFaIdno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckFaIdno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckFaIdno.Text = "選取";
            this.CheckFaIdno.ToolTipText = "選取";
            this.CheckFaIdno.UseColumnTextForButtonValue = true;
            this.CheckFaIdno.Width = 54;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.DataSource = this.vBASEBindingSource;
            this.nOBRDataGridViewTextBoxColumn.DisplayMember = "NAME_C";
            this.nOBRDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nOBRDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nOBRDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nOBRDataGridViewTextBoxColumn.ValueMember = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.Width = 78;
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
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fANAMEDataGridViewTextBoxColumn
            // 
            this.fANAMEDataGridViewTextBoxColumn.DataPropertyName = "FA_NAME";
            this.fANAMEDataGridViewTextBoxColumn.HeaderText = "眷屬姓名";
            this.fANAMEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fANAMEDataGridViewTextBoxColumn.Name = "fANAMEDataGridViewTextBoxColumn";
            this.fANAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.fANAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // fAIDNODataGridViewTextBoxColumn
            // 
            this.fAIDNODataGridViewTextBoxColumn.DataPropertyName = "FA_IDNO";
            this.fAIDNODataGridViewTextBoxColumn.HeaderText = "眷屬身份証號";
            this.fAIDNODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fAIDNODataGridViewTextBoxColumn.Name = "fAIDNODataGridViewTextBoxColumn";
            this.fAIDNODataGridViewTextBoxColumn.ReadOnly = true;
            this.fAIDNODataGridViewTextBoxColumn.Width = 102;
            // 
            // rELCODEDataGridViewTextBoxColumn
            // 
            this.rELCODEDataGridViewTextBoxColumn.DataPropertyName = "REL_CODE";
            this.rELCODEDataGridViewTextBoxColumn.DataSource = this.rELCODEBindingSource;
            this.rELCODEDataGridViewTextBoxColumn.DisplayMember = "REL_NAME";
            this.rELCODEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.rELCODEDataGridViewTextBoxColumn.HeaderText = "眷屬種類";
            this.rELCODEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.rELCODEDataGridViewTextBoxColumn.Name = "rELCODEDataGridViewTextBoxColumn";
            this.rELCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.rELCODEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rELCODEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rELCODEDataGridViewTextBoxColumn.ValueMember = "REL_CODE";
            this.rELCODEDataGridViewTextBoxColumn.Width = 78;
            // 
            // rELCODEBindingSource
            // 
            this.rELCODEBindingSource.DataMember = "RELCODE";
            this.rELCODEBindingSource.DataSource = this.basDS;
            // 
            // fABIRDTDataGridViewTextBoxColumn
            // 
            this.fABIRDTDataGridViewTextBoxColumn.DataPropertyName = "FA_BIRDT";
            this.fABIRDTDataGridViewTextBoxColumn.HeaderText = "眷屬生日";
            this.fABIRDTDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fABIRDTDataGridViewTextBoxColumn.Name = "fABIRDTDataGridViewTextBoxColumn";
            this.fABIRDTDataGridViewTextBoxColumn.ReadOnly = true;
            this.fABIRDTDataGridViewTextBoxColumn.Width = 78;
            // 
            // aDDRDataGridViewTextBoxColumn
            // 
            this.aDDRDataGridViewTextBoxColumn.DataPropertyName = "ADDR";
            this.aDDRDataGridViewTextBoxColumn.HeaderText = "地址";
            this.aDDRDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aDDRDataGridViewTextBoxColumn.Name = "aDDRDataGridViewTextBoxColumn";
            this.aDDRDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDDRDataGridViewTextBoxColumn.Width = 54;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // fAMILYBindingSource
            // 
            this.fAMILYBindingSource.DataMember = "FAMILY";
            this.fAMILYBindingSource.DataSource = this.basDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 211);
            this.splitContainer2.SplitterDistance = 129;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bnIMPORT);
            this.panel1.Controls.Add(this.cbRELCODE);
            this.panel1.Controls.Add(this.popupTextBox1);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 129);
            this.panel1.TabIndex = 0;
            // 
            // bnIMPORT
            // 
            this.bnIMPORT.Location = new System.Drawing.Point(540, 97);
            this.bnIMPORT.Name = "bnIMPORT";
            this.bnIMPORT.Size = new System.Drawing.Size(75, 23);
            this.bnIMPORT.TabIndex = 29;
            this.bnIMPORT.TabStop = false;
            this.bnIMPORT.Text = "匯入";
            this.bnIMPORT.UseVisualStyleBackColor = true;
            this.bnIMPORT.Click += new System.EventHandler(this.bnIMPORT_Click);
            // 
            // cbRELCODE
            // 
            this.cbRELCODE.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fAMILYBindingSource, "REL_CODE", true));
            this.cbRELCODE.FormattingEnabled = true;
            this.cbRELCODE.Location = new System.Drawing.Point(96, 95);
            this.cbRELCODE.Name = "cbRELCODE";
            this.cbRELCODE.Size = new System.Drawing.Size(116, 20);
            this.cbRELCODE.TabIndex = 3;
            // 
            // popupTextBox1
            // 
            this.popupTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox1.CaptionLabel = this.label4;
            this.popupTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fAMILYBindingSource, "NOBR", true));
            this.popupTextBox1.DataSource = this.vBASEBindingSource;
            this.popupTextBox1.DisplayMember = "name_c";
            this.popupTextBox1.IsEmpty = false;
            this.popupTextBox1.IsEmptyToQuery = true;
            this.popupTextBox1.IsMustBeFound = true;
            this.popupTextBox1.LabelText = "";
            this.popupTextBox1.Location = new System.Drawing.Point(96, 9);
            this.popupTextBox1.Name = "popupTextBox1";
            this.popupTextBox1.QueryFields = "name_e,name_p";
            this.popupTextBox1.ReadOnly = false;
            this.popupTextBox1.ShowDisplayName = true;
            this.popupTextBox1.Size = new System.Drawing.Size(100, 22);
            this.popupTextBox1.TabIndex = 0;
            this.popupTextBox1.ValueMember = "nobr";
            this.popupTextBox1.WhereCmd = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(37, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "員工編號";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.maskedTextBox1.CaptionLabel = this.label6;
            this.maskedTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.maskedTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fAMILYBindingSource, "FA_BIRDT", true));
            this.maskedTextBox1.DecimalPlace = 2;
            this.maskedTextBox1.IsEmpty = true;
            this.maskedTextBox1.Location = new System.Drawing.Point(330, 8);
            this.maskedTextBox1.Mask = "0000/00/00";
            this.maskedTextBox1.MaxLength = -1;
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '\0';
            this.maskedTextBox1.ReadOnly = false;
            this.maskedTextBox1.ShowCalendarButton = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 4;
            this.maskedTextBox1.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(271, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "眷屬生日";
            // 
            // textBox4
            // 
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label5;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fAMILYBindingSource, "ADDR", true));
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(330, 37);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = false;
            this.textBox4.Size = new System.Drawing.Size(237, 50);
            this.textBox4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(271, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "眷屬地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(37, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "眷屬種類";
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fAMILYBindingSource, "FA_NAME", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(96, 37);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(37, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "眷屬姓名";
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fAMILYBindingSource, "FA_IDNO", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(96, 66);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "眷屬身份証號";
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
            this.fullDataCtrl1.DataSource = this.fAMILYBindingSource;
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
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "fa_idno,fa_name,nobr";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
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
            this.errorProvider1.DataSource = this.fAMILYBindingSource;
            // 
            // fAMILYTableAdapter
            // 
            this.fAMILYTableAdapter.ClearBeforeFill = true;
            // 
            // rELCODETableAdapter
            // 
            this.rELCODETableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM13";
            this.Text = "FRM13";
            this.Load += new System.EventHandler(this.FRM13_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rELCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILYBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
		private JBControls.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private JBControls.TextBox maskedTextBox1;
		private System.Windows.Forms.Label label6;
		private JBControls.MemoTextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private JBControls.PopupTextBox popupTextBox1;
		private BasDS basDS;
		private System.Windows.Forms.BindingSource fAMILYBindingSource;
        private JBHR.Bas.BasDSTableAdapters.FAMILYTableAdapter fAMILYTableAdapter;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.BindingSource rELCODEBindingSource;
        private JBHR.Bas.BasDSTableAdapters.RELCODETableAdapter rELCODETableAdapter;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn CheckFaIdno;
        private System.Windows.Forms.DataGridViewComboBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fANAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fAIDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn rELCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fABIRDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDDRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbRELCODE;
        private System.Windows.Forms.Button bnIMPORT;
    }
}