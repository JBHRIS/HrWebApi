namespace JBHR.Att
{
	partial class FRM2F
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
            this.AUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOBRPOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOBRLENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sERPOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sERLENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATEPOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATELENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_FORMAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIMEPOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIMELENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_FORMAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEMPERATURE_POS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEMPERATURE_LEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDDATEFORMATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uSYS7BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtTemperature_LEN = new JBControls.TextBox();
            this.textBox7 = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.textBox1 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxDateFormat = new System.Windows.Forms.ComboBox();
            this.textBox66 = new JBControls.TextBox();
            this.checkBox1 = new JBControls.CheckBox();
            this.comboBoxSpiltType = new System.Windows.Forms.ComboBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox64 = new JBControls.TextBox();
            this.textBox5 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new JBControls.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTemperature_POS = new System.Windows.Forms.Label();
            this.textBox46 = new JBControls.TextBox();
            this.textBox63 = new JBControls.TextBox();
            this.textBox65 = new JBControls.TextBox();
            this.textBox67 = new JBControls.TextBox();
            this.textBox2 = new JBControls.TextBox();
            this.txtTemperature_POS = new JBControls.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTemperature_LEN = new System.Windows.Forms.Label();
            this.textBox25 = new JBControls.TextBox();
            this.textBox47 = new JBControls.TextBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.u_SYS7TableAdapter = new JBHR.Sys.SysDSTableAdapters.U_SYS7TableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSYS7BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(633, 441);
            this.splitContainer1.SplitterDistance = 171;
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
            this.AUTO,
            this.cARDNAMEDataGridViewTextBoxColumn,
            this.nOBRPOSDataGridViewTextBoxColumn,
            this.nOBRLENDataGridViewTextBoxColumn,
            this.sERPOSDataGridViewTextBoxColumn,
            this.sERLENDataGridViewTextBoxColumn,
            this.dATEPOSDataGridViewTextBoxColumn,
            this.dATELENDataGridViewTextBoxColumn,
            this.DATE_FORMAT,
            this.tIMEPOSDataGridViewTextBoxColumn,
            this.tIMELENDataGridViewTextBoxColumn,
            this.TIME_FORMAT,
            this.TEMPERATURE_POS,
            this.TEMPERATURE_LEN,
            this.cARDDATEFORMATDataGridViewTextBoxColumn,
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn});
            this.dataGridViewEx1.DataSource = this.uSYS7BindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowHeadersWidth = 51;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(633, 171);
            this.dataGridViewEx1.TabIndex = 8;
            this.dataGridViewEx1.SelectionChanged += new System.EventHandler(this.dataGridViewEx1_SelectionChanged);
            // 
            // AUTO
            // 
            this.AUTO.DataPropertyName = "AUTO";
            this.AUTO.HeaderText = "編號";
            this.AUTO.MinimumWidth = 6;
            this.AUTO.Name = "AUTO";
            this.AUTO.ReadOnly = true;
            this.AUTO.Width = 68;
            // 
            // cARDNAMEDataGridViewTextBoxColumn
            // 
            this.cARDNAMEDataGridViewTextBoxColumn.DataPropertyName = "CARD_NAME";
            this.cARDNAMEDataGridViewTextBoxColumn.HeaderText = "卡鐘名稱";
            this.cARDNAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cARDNAMEDataGridViewTextBoxColumn.Name = "cARDNAMEDataGridViewTextBoxColumn";
            this.cARDNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOBRPOSDataGridViewTextBoxColumn
            // 
            this.nOBRPOSDataGridViewTextBoxColumn.DataPropertyName = "NOBR_POS";
            this.nOBRPOSDataGridViewTextBoxColumn.HeaderText = "刷卡卡號位置";
            this.nOBRPOSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nOBRPOSDataGridViewTextBoxColumn.Name = "nOBRPOSDataGridViewTextBoxColumn";
            this.nOBRPOSDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRPOSDataGridViewTextBoxColumn.Width = 132;
            // 
            // nOBRLENDataGridViewTextBoxColumn
            // 
            this.nOBRLENDataGridViewTextBoxColumn.DataPropertyName = "NOBR_LEN";
            this.nOBRLENDataGridViewTextBoxColumn.HeaderText = "刷卡卡號長度";
            this.nOBRLENDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nOBRLENDataGridViewTextBoxColumn.Name = "nOBRLENDataGridViewTextBoxColumn";
            this.nOBRLENDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRLENDataGridViewTextBoxColumn.Width = 132;
            // 
            // sERPOSDataGridViewTextBoxColumn
            // 
            this.sERPOSDataGridViewTextBoxColumn.DataPropertyName = "SER_POS";
            this.sERPOSDataGridViewTextBoxColumn.HeaderText = "卡片序號位置";
            this.sERPOSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sERPOSDataGridViewTextBoxColumn.Name = "sERPOSDataGridViewTextBoxColumn";
            this.sERPOSDataGridViewTextBoxColumn.ReadOnly = true;
            this.sERPOSDataGridViewTextBoxColumn.Width = 132;
            // 
            // sERLENDataGridViewTextBoxColumn
            // 
            this.sERLENDataGridViewTextBoxColumn.DataPropertyName = "SER_LEN";
            this.sERLENDataGridViewTextBoxColumn.HeaderText = "卡片序號長度";
            this.sERLENDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sERLENDataGridViewTextBoxColumn.Name = "sERLENDataGridViewTextBoxColumn";
            this.sERLENDataGridViewTextBoxColumn.ReadOnly = true;
            this.sERLENDataGridViewTextBoxColumn.Width = 132;
            // 
            // dATEPOSDataGridViewTextBoxColumn
            // 
            this.dATEPOSDataGridViewTextBoxColumn.DataPropertyName = "DATE_POS";
            this.dATEPOSDataGridViewTextBoxColumn.HeaderText = "日期位置";
            this.dATEPOSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dATEPOSDataGridViewTextBoxColumn.Name = "dATEPOSDataGridViewTextBoxColumn";
            this.dATEPOSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dATELENDataGridViewTextBoxColumn
            // 
            this.dATELENDataGridViewTextBoxColumn.DataPropertyName = "DATE_LEN";
            this.dATELENDataGridViewTextBoxColumn.HeaderText = "日期長度";
            this.dATELENDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dATELENDataGridViewTextBoxColumn.Name = "dATELENDataGridViewTextBoxColumn";
            this.dATELENDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DATE_FORMAT
            // 
            this.DATE_FORMAT.DataPropertyName = "DATE_FORMAT";
            this.DATE_FORMAT.HeaderText = "日期格式";
            this.DATE_FORMAT.MinimumWidth = 6;
            this.DATE_FORMAT.Name = "DATE_FORMAT";
            this.DATE_FORMAT.ReadOnly = true;
            // 
            // tIMEPOSDataGridViewTextBoxColumn
            // 
            this.tIMEPOSDataGridViewTextBoxColumn.DataPropertyName = "TIME_POS";
            this.tIMEPOSDataGridViewTextBoxColumn.HeaderText = "時間位置";
            this.tIMEPOSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tIMEPOSDataGridViewTextBoxColumn.Name = "tIMEPOSDataGridViewTextBoxColumn";
            this.tIMEPOSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIMELENDataGridViewTextBoxColumn
            // 
            this.tIMELENDataGridViewTextBoxColumn.DataPropertyName = "TIME_LEN";
            this.tIMELENDataGridViewTextBoxColumn.HeaderText = "時間長度";
            this.tIMELENDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tIMELENDataGridViewTextBoxColumn.Name = "tIMELENDataGridViewTextBoxColumn";
            this.tIMELENDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TIME_FORMAT
            // 
            this.TIME_FORMAT.DataPropertyName = "TIME_FORMAT";
            this.TIME_FORMAT.HeaderText = "時間格式";
            this.TIME_FORMAT.MinimumWidth = 6;
            this.TIME_FORMAT.Name = "TIME_FORMAT";
            this.TIME_FORMAT.ReadOnly = true;
            // 
            // TEMPERATURE_POS
            // 
            this.TEMPERATURE_POS.DataPropertyName = "TEMPERATURE_POS";
            this.TEMPERATURE_POS.HeaderText = "體溫位置";
            this.TEMPERATURE_POS.MinimumWidth = 6;
            this.TEMPERATURE_POS.Name = "TEMPERATURE_POS";
            this.TEMPERATURE_POS.ReadOnly = true;
            // 
            // TEMPERATURE_LEN
            // 
            this.TEMPERATURE_LEN.DataPropertyName = "TEMPERATURE_LEN";
            this.TEMPERATURE_LEN.HeaderText = "體溫長度";
            this.TEMPERATURE_LEN.MinimumWidth = 6;
            this.TEMPERATURE_LEN.Name = "TEMPERATURE_LEN";
            this.TEMPERATURE_LEN.ReadOnly = true;
            // 
            // cARDDATEFORMATDataGridViewTextBoxColumn
            // 
            this.cARDDATEFORMATDataGridViewTextBoxColumn.DataPropertyName = "CARDDATEFORMAT";
            this.cARDDATEFORMATDataGridViewTextBoxColumn.HeaderText = "刷卡日期格式";
            this.cARDDATEFORMATDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cARDDATEFORMATDataGridViewTextBoxColumn.Name = "cARDDATEFORMATDataGridViewTextBoxColumn";
            this.cARDDATEFORMATDataGridViewTextBoxColumn.ReadOnly = true;
            this.cARDDATEFORMATDataGridViewTextBoxColumn.Width = 132;
            // 
            // cARDNOEUQALNOBRDataGridViewCheckBoxColumn
            // 
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn.DataPropertyName = "CARDNOEUQALNOBR";
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn.HeaderText = "刷卡號碼與工號相同";
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn.Name = "cARDNOEUQALNOBRDataGridViewCheckBoxColumn";
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cARDNOEUQALNOBRDataGridViewCheckBoxColumn.Width = 157;
            // 
            // uSYS7BindingSource
            // 
            this.uSYS7BindingSource.DataMember = "U_SYS7";
            this.uSYS7BindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(633, 266);
            this.splitContainer2.SplitterDistance = 186;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTemperature_LEN, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox7, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDateFormat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox66, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSpiltType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label99, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox64, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label61, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label94, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label96, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label98, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbTemperature_POS, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox46, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox63, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox65, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox67, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTemperature_POS, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label60, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label62, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label95, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label97, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbTemperature_LEN, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox25, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox47, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 186);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.btnImport, 2);
            this.btnImport.Location = new System.Drawing.Point(534, 156);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 23);
            this.btnImport.TabIndex = 87;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "匯入刷卡資料";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtTemperature_LEN
            // 
            this.txtTemperature_LEN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTemperature_LEN.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTemperature_LEN.CaptionLabel = null;
            this.txtTemperature_LEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTemperature_LEN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "TEMPERATURE_LEN", true));
            this.txtTemperature_LEN.DecimalPlace = 2;
            this.txtTemperature_LEN.IsEmpty = false;
            this.txtTemperature_LEN.Location = new System.Drawing.Point(447, 157);
            this.txtTemperature_LEN.Mask = "";
            this.txtTemperature_LEN.MaxLength = -1;
            this.txtTemperature_LEN.Name = "txtTemperature_LEN";
            this.txtTemperature_LEN.PasswordChar = '\0';
            this.txtTemperature_LEN.ReadOnly = false;
            this.txtTemperature_LEN.ShowCalendarButton = true;
            this.txtTemperature_LEN.Size = new System.Drawing.Size(53, 22);
            this.txtTemperature_LEN.TabIndex = 19;
            this.txtTemperature_LEN.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox7.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox7.CaptionLabel = null;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "TIME_FORMAT", true));
            this.textBox7.DecimalPlace = 2;
            this.textBox7.IsEmpty = true;
            this.textBox7.Location = new System.Drawing.Point(560, 94);
            this.textBox7.Mask = "";
            this.textBox7.MaxLength = 50;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.ReadOnly = false;
            this.textBox7.ShowCalendarButton = true;
            this.textBox7.Size = new System.Drawing.Size(53, 22);
            this.textBox7.TabIndex = 15;
            this.textBox7.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(24, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 85;
            this.label1.Text = "卡機名稱";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = null;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "DATE_FORMAT", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = true;
            this.textBox6.Location = new System.Drawing.Point(560, 64);
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = 50;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(53, 22);
            this.textBox6.TabIndex = 12;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(531, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 30);
            this.label8.TabIndex = 81;
            this.label8.Text = "格式";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = null;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "CODE_LEN", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            this.textBox3.Location = new System.Drawing.Point(447, 124);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = -1;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(53, 22);
            this.textBox3.TabIndex = 17;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "CARD_NAME", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(101, 4);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(109, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(531, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 30);
            this.label7.TabIndex = 81;
            this.label7.Text = "格式";
            // 
            // comboBoxDateFormat
            // 
            this.comboBoxDateFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDateFormat.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.uSYS7BindingSource, "CARDDATEFORMAT", true));
            this.comboBoxDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDateFormat.FormattingEnabled = true;
            this.comboBoxDateFormat.Location = new System.Drawing.Point(101, 34);
            this.comboBoxDateFormat.Name = "comboBoxDateFormat";
            this.comboBoxDateFormat.Size = new System.Drawing.Size(109, 23);
            this.comboBoxDateFormat.TabIndex = 1;
            // 
            // textBox66
            // 
            this.textBox66.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox66.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox66.CaptionLabel = null;
            this.textBox66.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox66.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "TIME_LEN", true));
            this.textBox66.DecimalPlace = 2;
            this.textBox66.IsEmpty = false;
            this.textBox66.Location = new System.Drawing.Point(447, 94);
            this.textBox66.Mask = "";
            this.textBox66.MaxLength = -1;
            this.textBox66.Name = "textBox66";
            this.textBox66.PasswordChar = '\0';
            this.textBox66.ReadOnly = false;
            this.textBox66.ShowCalendarButton = true;
            this.textBox66.Size = new System.Drawing.Size(53, 22);
            this.textBox66.TabIndex = 14;
            this.textBox66.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uSYS7BindingSource, "CARDNOEUQALNOBR", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(101, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "卡號等於工號";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBoxSpiltType
            // 
            this.comboBoxSpiltType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSpiltType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.uSYS7BindingSource, "TEXT_TYPE", true));
            this.comboBoxSpiltType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpiltType.FormattingEnabled = true;
            this.comboBoxSpiltType.Location = new System.Drawing.Point(101, 94);
            this.comboBoxSpiltType.Name = "comboBoxSpiltType";
            this.comboBoxSpiltType.Size = new System.Drawing.Size(109, 23);
            this.comboBoxSpiltType.TabIndex = 3;
            // 
            // label99
            // 
            this.label99.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(8, 30);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(87, 30);
            this.label99.TabIndex = 84;
            this.label99.Text = "刷卡日期格式";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 93;
            this.label4.Text = "判斷類型";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(24, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 90;
            this.label5.Text = "分隔符號";
            // 
            // textBox64
            // 
            this.textBox64.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox64.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox64.CaptionLabel = null;
            this.textBox64.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox64.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "DATE_LEN", true));
            this.textBox64.DecimalPlace = 2;
            this.textBox64.IsEmpty = false;
            this.textBox64.Location = new System.Drawing.Point(447, 64);
            this.textBox64.Mask = "";
            this.textBox64.MaxLength = -1;
            this.textBox64.Name = "textBox64";
            this.textBox64.PasswordChar = '\0';
            this.textBox64.ReadOnly = false;
            this.textBox64.ShowCalendarButton = true;
            this.textBox64.Size = new System.Drawing.Size(53, 22);
            this.textBox64.TabIndex = 11;
            this.textBox64.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label6;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "IGNORE_SIGNAL", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = true;
            this.textBox5.Location = new System.Drawing.Point(101, 157);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = 50;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(53, 22);
            this.textBox5.TabIndex = 5;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 91;
            this.label6.Text = "忽略符號";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label5;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "SPILT_SIGNAL", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(101, 124);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = 50;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(53, 22);
            this.textBox4.TabIndex = 4;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label61.AutoSize = true;
            this.label61.ForeColor = System.Drawing.Color.Red;
            this.label61.Location = new System.Drawing.Point(241, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(87, 30);
            this.label61.TabIndex = 76;
            this.label61.Text = "刷卡卡號位置";
            // 
            // label94
            // 
            this.label94.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label94.AutoSize = true;
            this.label94.ForeColor = System.Drawing.Color.Red;
            this.label94.Location = new System.Drawing.Point(241, 30);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(87, 30);
            this.label94.TabIndex = 78;
            this.label94.Text = "卡片序號位置";
            // 
            // label96
            // 
            this.label96.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label96.AutoSize = true;
            this.label96.ForeColor = System.Drawing.Color.Red;
            this.label96.Location = new System.Drawing.Point(257, 67);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(71, 15);
            this.label96.TabIndex = 80;
            this.label96.Text = "日期位置";
            // 
            // label98
            // 
            this.label98.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label98.AutoSize = true;
            this.label98.ForeColor = System.Drawing.Color.Red;
            this.label98.Location = new System.Drawing.Point(257, 97);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(71, 15);
            this.label98.TabIndex = 82;
            this.label98.Text = "時間位置";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(257, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 96;
            this.label2.Text = "來源位置";
            // 
            // lbTemperature_POS
            // 
            this.lbTemperature_POS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTemperature_POS.AutoSize = true;
            this.lbTemperature_POS.ForeColor = System.Drawing.Color.Red;
            this.lbTemperature_POS.Location = new System.Drawing.Point(257, 160);
            this.lbTemperature_POS.Name = "lbTemperature_POS";
            this.lbTemperature_POS.Size = new System.Drawing.Size(71, 15);
            this.lbTemperature_POS.TabIndex = 100;
            this.lbTemperature_POS.Text = "體溫位置";
            // 
            // textBox46
            // 
            this.textBox46.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox46.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox46.CaptionLabel = null;
            this.textBox46.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox46.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "NOBR_POS", true));
            this.textBox46.DecimalPlace = 2;
            this.textBox46.IsEmpty = false;
            this.textBox46.Location = new System.Drawing.Point(334, 4);
            this.textBox46.Mask = "";
            this.textBox46.MaxLength = -1;
            this.textBox46.Name = "textBox46";
            this.textBox46.PasswordChar = '\0';
            this.textBox46.ReadOnly = false;
            this.textBox46.ShowCalendarButton = true;
            this.textBox46.Size = new System.Drawing.Size(53, 22);
            this.textBox46.TabIndex = 6;
            this.textBox46.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox63
            // 
            this.textBox63.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox63.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox63.CaptionLabel = null;
            this.textBox63.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox63.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "SER_POS", true));
            this.textBox63.DecimalPlace = 2;
            this.textBox63.IsEmpty = false;
            this.textBox63.Location = new System.Drawing.Point(334, 34);
            this.textBox63.Mask = "";
            this.textBox63.MaxLength = -1;
            this.textBox63.Name = "textBox63";
            this.textBox63.PasswordChar = '\0';
            this.textBox63.ReadOnly = false;
            this.textBox63.ShowCalendarButton = true;
            this.textBox63.Size = new System.Drawing.Size(53, 22);
            this.textBox63.TabIndex = 8;
            this.textBox63.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox65
            // 
            this.textBox65.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox65.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox65.CaptionLabel = null;
            this.textBox65.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox65.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "DATE_POS", true));
            this.textBox65.DecimalPlace = 2;
            this.textBox65.IsEmpty = false;
            this.textBox65.Location = new System.Drawing.Point(334, 64);
            this.textBox65.Mask = "";
            this.textBox65.MaxLength = -1;
            this.textBox65.Name = "textBox65";
            this.textBox65.PasswordChar = '\0';
            this.textBox65.ReadOnly = false;
            this.textBox65.ShowCalendarButton = true;
            this.textBox65.Size = new System.Drawing.Size(53, 22);
            this.textBox65.TabIndex = 10;
            this.textBox65.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox67
            // 
            this.textBox67.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox67.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox67.CaptionLabel = null;
            this.textBox67.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox67.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "TIME_POS", true));
            this.textBox67.DecimalPlace = 2;
            this.textBox67.IsEmpty = false;
            this.textBox67.Location = new System.Drawing.Point(334, 94);
            this.textBox67.Mask = "";
            this.textBox67.MaxLength = -1;
            this.textBox67.Name = "textBox67";
            this.textBox67.PasswordChar = '\0';
            this.textBox67.ReadOnly = false;
            this.textBox67.ShowCalendarButton = true;
            this.textBox67.Size = new System.Drawing.Size(53, 22);
            this.textBox67.TabIndex = 13;
            this.textBox67.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = null;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "CODE_POS", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(334, 124);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(53, 22);
            this.textBox2.TabIndex = 16;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // txtTemperature_POS
            // 
            this.txtTemperature_POS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTemperature_POS.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTemperature_POS.CaptionLabel = null;
            this.txtTemperature_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTemperature_POS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "TEMPERATURE_POS", true));
            this.txtTemperature_POS.DecimalPlace = 2;
            this.txtTemperature_POS.IsEmpty = false;
            this.txtTemperature_POS.Location = new System.Drawing.Point(334, 157);
            this.txtTemperature_POS.Mask = "";
            this.txtTemperature_POS.MaxLength = -1;
            this.txtTemperature_POS.Name = "txtTemperature_POS";
            this.txtTemperature_POS.PasswordChar = '\0';
            this.txtTemperature_POS.ReadOnly = false;
            this.txtTemperature_POS.ShowCalendarButton = true;
            this.txtTemperature_POS.Size = new System.Drawing.Size(53, 22);
            this.txtTemperature_POS.TabIndex = 18;
            this.txtTemperature_POS.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label60
            // 
            this.label60.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label60.AutoSize = true;
            this.label60.ForeColor = System.Drawing.Color.Red;
            this.label60.Location = new System.Drawing.Point(418, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(23, 30);
            this.label60.TabIndex = 77;
            this.label60.Text = "長度";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.ForeColor = System.Drawing.Color.Red;
            this.label62.Location = new System.Drawing.Point(418, 30);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(23, 30);
            this.label62.TabIndex = 79;
            this.label62.Text = "長度";
            // 
            // label95
            // 
            this.label95.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label95.AutoSize = true;
            this.label95.ForeColor = System.Drawing.Color.Red;
            this.label95.Location = new System.Drawing.Point(418, 60);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(23, 30);
            this.label95.TabIndex = 81;
            this.label95.Text = "長度";
            // 
            // label97
            // 
            this.label97.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label97.AutoSize = true;
            this.label97.ForeColor = System.Drawing.Color.Red;
            this.label97.Location = new System.Drawing.Point(418, 90);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(23, 30);
            this.label97.TabIndex = 83;
            this.label97.Text = "長度";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(418, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 30);
            this.label3.TabIndex = 97;
            this.label3.Text = "長度";
            // 
            // lbTemperature_LEN
            // 
            this.lbTemperature_LEN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTemperature_LEN.AutoSize = true;
            this.lbTemperature_LEN.ForeColor = System.Drawing.Color.Red;
            this.lbTemperature_LEN.Location = new System.Drawing.Point(418, 153);
            this.lbTemperature_LEN.Name = "lbTemperature_LEN";
            this.lbTemperature_LEN.Size = new System.Drawing.Size(23, 30);
            this.lbTemperature_LEN.TabIndex = 101;
            this.lbTemperature_LEN.Text = "長度";
            // 
            // textBox25
            // 
            this.textBox25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox25.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox25.CaptionLabel = null;
            this.textBox25.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox25.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "NOBR_LEN", true));
            this.textBox25.DecimalPlace = 2;
            this.textBox25.IsEmpty = false;
            this.textBox25.Location = new System.Drawing.Point(447, 4);
            this.textBox25.Mask = "";
            this.textBox25.MaxLength = -1;
            this.textBox25.Name = "textBox25";
            this.textBox25.PasswordChar = '\0';
            this.textBox25.ReadOnly = false;
            this.textBox25.ShowCalendarButton = true;
            this.textBox25.Size = new System.Drawing.Size(53, 22);
            this.textBox25.TabIndex = 7;
            this.textBox25.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // textBox47
            // 
            this.textBox47.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox47.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox47.CaptionLabel = null;
            this.textBox47.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox47.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7BindingSource, "SER_LEN", true));
            this.textBox47.DecimalPlace = 2;
            this.textBox47.IsEmpty = false;
            this.textBox47.Location = new System.Drawing.Point(447, 34);
            this.textBox47.Mask = "";
            this.textBox47.MaxLength = -1;
            this.textBox47.Name = "textBox47";
            this.textBox47.PasswordChar = '\0';
            this.textBox47.ReadOnly = false;
            this.textBox47.ShowCalendarButton = true;
            this.textBox47.Size = new System.Drawing.Size(53, 22);
            this.textBox47.TabIndex = 9;
            this.textBox47.ValidType = JBControls.TextBox.EValidType.Integer;
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
            this.fullDataCtrl1.DataSource = this.uSYS7BindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "card_name";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(633, 73);
            this.fullDataCtrl1.SortFields = "card_name";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // u_SYS7TableAdapter
            // 
            this.u_SYS7TableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.uSYS7BindingSource;
            // 
            // FRM2F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM2F";
            this.Text = "FRM2F";
            this.Load += new System.EventHandler(this.U_SYS7_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSYS7BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.CheckBox checkBox1;
        private System.Windows.Forms.Label label99;
        private JBControls.TextBox textBox66;
        private System.Windows.Forms.Label label97;
        private JBControls.TextBox textBox67;
        private System.Windows.Forms.Label label98;
        private JBControls.TextBox textBox64;
        private System.Windows.Forms.Label label95;
        private JBControls.TextBox textBox65;
        private System.Windows.Forms.Label label96;
        private JBControls.TextBox textBox47;
        private System.Windows.Forms.Label label62;
        private JBControls.TextBox textBox63;
        private System.Windows.Forms.Label label94;
        private JBControls.TextBox textBox25;
        private System.Windows.Forms.Label label60;
        private JBControls.TextBox textBox46;
        private System.Windows.Forms.Label label61;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private JBHR.Sys.SysDS sysDS;
        private System.Windows.Forms.BindingSource uSYS7BindingSource;
        private JBHR.Sys.SysDSTableAdapters.U_SYS7TableAdapter u_SYS7TableAdapter;
        private JBControls.DataGridView dataGridViewEx1;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnImport;
        private JBControls.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSpiltType;
        private System.Windows.Forms.ComboBox comboBoxDateFormat;
        private JBControls.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtTemperature_LEN;
        private System.Windows.Forms.Label lbTemperature_LEN;
        private JBControls.TextBox txtTemperature_POS;
        private System.Windows.Forms.Label lbTemperature_POS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRPOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRLENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sERPOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sERLENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATEPOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATELENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_FORMAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIMEPOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIMELENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_FORMAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEMPERATURE_POS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEMPERATURE_LEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDDATEFORMATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cARDNOEUQALNOBRDataGridViewCheckBoxColumn;
    }
}