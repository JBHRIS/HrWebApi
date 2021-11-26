namespace JBHR.Wel
{
	partial class FRM62
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
            this.NOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.welDS = new JBHR.Wel.WelDS();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.wCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fORMATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.yRFOMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dAMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALADRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wELFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.popupTextBox1 = new JBControls.PopupTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new JBControls.TextBox();
            this.textBox5 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.wELFTableAdapter = new JBHR.Wel.WelDSTableAdapters.WELFTableAdapter();
            this.v_BASETableAdapter = new JBHR.Wel.WelDSTableAdapters.V_BASETableAdapter();
            this.wCODETableAdapter = new JBHR.Wel.WelDSTableAdapters.WCODETableAdapter();
            this.yRFOMATTableAdapter = new JBHR.Wel.WelDSTableAdapters.YRFOMATTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.welDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFOMATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wELFBindingSource)).BeginInit();
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
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 10;
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
            this.NOBR,
            this.dataGridViewComboBoxColumn1,
            this.yYMMDataGridViewTextBoxColumn,
            this.sEQDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.fORMATDataGridViewTextBoxColumn,
            this.aMTDataGridViewTextBoxColumn,
            this.dAMTDataGridViewTextBoxColumn,
            this.sALADRDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.wELFBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 260);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // NOBR
            // 
            this.NOBR.DataPropertyName = "NOBR";
            this.NOBR.HeaderText = "員工編號";
            this.NOBR.Name = "NOBR";
            this.NOBR.ReadOnly = true;
            this.NOBR.Width = 78;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "NOBR";
            this.dataGridViewComboBoxColumn1.DataSource = this.vBASEBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "NAME_C";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.HeaderText = "員工姓名";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "NOBR";
            this.dataGridViewComboBoxColumn1.Width = 78;
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.welDS;
            // 
            // welDS
            // 
            this.welDS.DataSetName = "WelDS";
            this.welDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.welDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "計薪年月";
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            this.yYMMDataGridViewTextBoxColumn.Width = 78;
            // 
            // sEQDataGridViewTextBoxColumn
            // 
            this.sEQDataGridViewTextBoxColumn.DataPropertyName = "SEQ";
            this.sEQDataGridViewTextBoxColumn.HeaderText = "期數";
            this.sEQDataGridViewTextBoxColumn.Name = "sEQDataGridViewTextBoxColumn";
            this.sEQDataGridViewTextBoxColumn.ReadOnly = true;
            this.sEQDataGridViewTextBoxColumn.Width = 54;
            // 
            // sALCODEDataGridViewTextBoxColumn
            // 
            this.sALCODEDataGridViewTextBoxColumn.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn.DataSource = this.wCODEBindingSource;
            this.sALCODEDataGridViewTextBoxColumn.DisplayMember = "W_NAME";
            this.sALCODEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sALCODEDataGridViewTextBoxColumn.HeaderText = "福利代號";
            this.sALCODEDataGridViewTextBoxColumn.Name = "sALCODEDataGridViewTextBoxColumn";
            this.sALCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sALCODEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sALCODEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sALCODEDataGridViewTextBoxColumn.ValueMember = "W_CODE";
            this.sALCODEDataGridViewTextBoxColumn.Width = 78;
            // 
            // wCODEBindingSource
            // 
            this.wCODEBindingSource.DataMember = "WCODE";
            this.wCODEBindingSource.DataSource = this.welDS;
            // 
            // fORMATDataGridViewTextBoxColumn
            // 
            this.fORMATDataGridViewTextBoxColumn.DataPropertyName = "FORMAT";
            this.fORMATDataGridViewTextBoxColumn.DataSource = this.yRFOMATBindingSource;
            this.fORMATDataGridViewTextBoxColumn.DisplayMember = "NAME";
            this.fORMATDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.fORMATDataGridViewTextBoxColumn.HeaderText = "格式";
            this.fORMATDataGridViewTextBoxColumn.Name = "fORMATDataGridViewTextBoxColumn";
            this.fORMATDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORMATDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fORMATDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fORMATDataGridViewTextBoxColumn.ValueMember = "CODE";
            this.fORMATDataGridViewTextBoxColumn.Width = 54;
            // 
            // yRFOMATBindingSource
            // 
            this.yRFOMATBindingSource.DataMember = "YRFOMAT";
            this.yRFOMATBindingSource.DataSource = this.welDS;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.aMTDataGridViewTextBoxColumn.Width = 54;
            // 
            // dAMTDataGridViewTextBoxColumn
            // 
            this.dAMTDataGridViewTextBoxColumn.DataPropertyName = "D_AMT";
            this.dAMTDataGridViewTextBoxColumn.HeaderText = "扣繳稅額";
            this.dAMTDataGridViewTextBoxColumn.Name = "dAMTDataGridViewTextBoxColumn";
            this.dAMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.dAMTDataGridViewTextBoxColumn.Width = 78;
            // 
            // sALADRDataGridViewTextBoxColumn
            // 
            this.sALADRDataGridViewTextBoxColumn.DataPropertyName = "SALADR";
            this.sALADRDataGridViewTextBoxColumn.HeaderText = "資料群組";
            this.sALADRDataGridViewTextBoxColumn.Name = "sALADRDataGridViewTextBoxColumn";
            this.sALADRDataGridViewTextBoxColumn.ReadOnly = true;
            this.sALADRDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // wELFBindingSource
            // 
            this.wELFBindingSource.DataMember = "WELF";
            this.wELFBindingSource.DataSource = this.welDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 177);
            this.splitContainer2.SplitterDistance = 97;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.popupTextBox1);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 97);
            this.panel1.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.wELFBindingSource, "FORMAT", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(363, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.wELFBindingSource, "SAL_CODE", true));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(100, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 78);
            this.button1.TabIndex = 15;
            this.button1.TabStop = false;
            this.button1.Text = "Excel 匯入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // popupTextBox1
            // 
            this.popupTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox1.CaptionLabel = this.label1;
            this.popupTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wELFBindingSource, "NOBR", true));
            this.popupTextBox1.DataSource = this.vBASEBindingSource;
            this.popupTextBox1.DisplayMember = "name_c";
            this.popupTextBox1.IsEmpty = false;
            this.popupTextBox1.IsEmptyToQuery = true;
            this.popupTextBox1.IsMustBeFound = true;
            this.popupTextBox1.LabelText = "";
            this.popupTextBox1.Location = new System.Drawing.Point(100, 7);
            this.popupTextBox1.Name = "popupTextBox1";
            this.popupTextBox1.QueryFields = "name_e,name_p";
            this.popupTextBox1.ReadOnly = false;
            this.popupTextBox1.ShowDisplayName = true;
            this.popupTextBox1.Size = new System.Drawing.Size(100, 22);
            this.popupTextBox1.TabIndex = 0;
            this.popupTextBox1.ValueMember = "nobr";
            this.popupTextBox1.WhereCmd = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(41, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // textBox6
            // 
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = null;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wELFBindingSource, "SEQ", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = false;
            this.textBox6.Location = new System.Drawing.Point(165, 35);
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = 50;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(35, 22);
            this.textBox6.TabIndex = 2;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox5
            // 
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label6;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wELFBindingSource, "D_AMT", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = false;
            this.textBox5.Location = new System.Drawing.Point(363, 63);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = -1;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 6;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(304, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "扣繳稅額";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(328, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "格式";
            // 
            // textBox4
            // 
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label4;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wELFBindingSource, "AMT", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = false;
            this.textBox4.Location = new System.Drawing.Point(363, 35);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = -1;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 5;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(328, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "金額";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(41, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "福利代號";
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wELFBindingSource, "YYMM", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(100, 35);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(59, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(41, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "計薪年月";
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
            this.fullDataCtrl1.DataSource = this.wELFBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,yymm,seq,sal_code";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(636, 73);
            this.fullDataCtrl1.SortFields = "nobr,yymm,sal_code";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
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
            this.errorProvider1.DataSource = this.wELFBindingSource;
            // 
            // wELFTableAdapter
            // 
            this.wELFTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // wCODETableAdapter
            // 
            this.wCODETableAdapter.ClearBeforeFill = true;
            // 
            // yRFOMATTableAdapter
            // 
            this.yRFOMATTableAdapter.ClearBeforeFill = true;
            // 
            // FRM62
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM62";
            this.Text = "FRM62";
            this.Load += new System.EventHandler(this.FRM62_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.welDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFOMATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wELFBindingSource)).EndInit();
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
		private JBControls.DataGridView dataGridViewEx1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel1;
		private JBControls.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private JBControls.FullDataCtrl fullDataCtrl1;
		private JBControls.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private JBControls.TextBox textBox5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
		private JBControls.PopupTextBox popupTextBox1;
		private JBControls.TextBox textBox6;
		private WelDS welDS;
		private System.Windows.Forms.BindingSource wELFBindingSource;
        private JBHR.Wel.WelDSTableAdapters.WELFTableAdapter wELFTableAdapter;
		private System.Windows.Forms.BindingSource vBASEBindingSource;
		private JBHR.Wel.WelDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
		private System.Windows.Forms.BindingSource wCODEBindingSource;
		private JBHR.Wel.WelDSTableAdapters.WCODETableAdapter wCODETableAdapter;
		private System.Windows.Forms.BindingSource yRFOMATBindingSource;
		private JBHR.Wel.WelDSTableAdapters.YRFOMATTableAdapter yRFOMATTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOBR;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fORMATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dAMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALADRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
	}
}