namespace JBHR.Att
{
	partial class FRM2K
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.cARDNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATASOURCEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATATABLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLNOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLADATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLONTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLCARDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSYS7ABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.label98 = new System.Windows.Forms.Label();
            this.txtLastCheck = new JBControls.TextBox();
            this.txtCheckTime = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBroswer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNo = new JBControls.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.txtOntime = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCardName = new JBControls.TextBox();
            this.txtDataSource = new JBControls.TextBox();
            this.txtAdate = new JBControls.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtInitailCatalog = new JBControls.TextBox();
            this.txtUserId = new JBControls.TextBox();
            this.txtNobr = new JBControls.TextBox();
            this.txtPassWord = new JBControls.TextBox();
            this.textBox1 = new JBControls.TextBox();
            this.txtDataTable = new JBControls.TextBox();
            this.lbTemperate = new System.Windows.Forms.Label();
            this.txtTemperature = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIP = new JBControls.TextBox();
            this.txtSource = new JBControls.TextBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.u_SYS7ATableAdapter = new JBHR.Att.dsAttTableAdapters.U_SYS7ATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSYS7ABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(645, 441);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cARDNAMEDataGridViewTextBoxColumn,
            this.dATASOURCEDataGridViewTextBoxColumn,
            this.dATATABLEDataGridViewTextBoxColumn,
            this.cOLNOBRDataGridViewTextBoxColumn,
            this.cOLADATEDataGridViewTextBoxColumn,
            this.cOLONTIMEDataGridViewTextBoxColumn,
            this.cOLCARDNODataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.uSYS7ABindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(645, 167);
            this.dataGridViewEx1.TabIndex = 8;
            // 
            // cARDNAMEDataGridViewTextBoxColumn
            // 
            this.cARDNAMEDataGridViewTextBoxColumn.DataPropertyName = "CARD_NAME";
            this.cARDNAMEDataGridViewTextBoxColumn.HeaderText = "卡鐘名稱";
            this.cARDNAMEDataGridViewTextBoxColumn.Name = "cARDNAMEDataGridViewTextBoxColumn";
            this.cARDNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cARDNAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // dATASOURCEDataGridViewTextBoxColumn
            // 
            this.dATASOURCEDataGridViewTextBoxColumn.DataPropertyName = "DATA_SOURCE";
            this.dATASOURCEDataGridViewTextBoxColumn.HeaderText = "主機";
            this.dATASOURCEDataGridViewTextBoxColumn.Name = "dATASOURCEDataGridViewTextBoxColumn";
            this.dATASOURCEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dATASOURCEDataGridViewTextBoxColumn.Width = 54;
            // 
            // dATATABLEDataGridViewTextBoxColumn
            // 
            this.dATATABLEDataGridViewTextBoxColumn.DataPropertyName = "DATATABLE";
            this.dATATABLEDataGridViewTextBoxColumn.HeaderText = "資料表";
            this.dATATABLEDataGridViewTextBoxColumn.Name = "dATATABLEDataGridViewTextBoxColumn";
            this.dATATABLEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dATATABLEDataGridViewTextBoxColumn.Width = 66;
            // 
            // cOLNOBRDataGridViewTextBoxColumn
            // 
            this.cOLNOBRDataGridViewTextBoxColumn.DataPropertyName = "COL_NOBR";
            this.cOLNOBRDataGridViewTextBoxColumn.HeaderText = "工號";
            this.cOLNOBRDataGridViewTextBoxColumn.Name = "cOLNOBRDataGridViewTextBoxColumn";
            this.cOLNOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOLNOBRDataGridViewTextBoxColumn.Width = 54;
            // 
            // cOLADATEDataGridViewTextBoxColumn
            // 
            this.cOLADATEDataGridViewTextBoxColumn.DataPropertyName = "COL_ADATE";
            this.cOLADATEDataGridViewTextBoxColumn.HeaderText = "日期";
            this.cOLADATEDataGridViewTextBoxColumn.Name = "cOLADATEDataGridViewTextBoxColumn";
            this.cOLADATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOLADATEDataGridViewTextBoxColumn.Width = 54;
            // 
            // cOLONTIMEDataGridViewTextBoxColumn
            // 
            this.cOLONTIMEDataGridViewTextBoxColumn.DataPropertyName = "COL_ONTIME";
            this.cOLONTIMEDataGridViewTextBoxColumn.HeaderText = "時間";
            this.cOLONTIMEDataGridViewTextBoxColumn.Name = "cOLONTIMEDataGridViewTextBoxColumn";
            this.cOLONTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOLONTIMEDataGridViewTextBoxColumn.Width = 54;
            // 
            // cOLCARDNODataGridViewTextBoxColumn
            // 
            this.cOLCARDNODataGridViewTextBoxColumn.DataPropertyName = "COL_CARDNO";
            this.cOLCARDNODataGridViewTextBoxColumn.HeaderText = "卡號";
            this.cOLCARDNODataGridViewTextBoxColumn.Name = "cOLCARDNODataGridViewTextBoxColumn";
            this.cOLCARDNODataGridViewTextBoxColumn.ReadOnly = true;
            this.cOLCARDNODataGridViewTextBoxColumn.Width = 54;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄時間";
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
            // uSYS7ABindingSource
            // 
            this.uSYS7ABindingSource.DataMember = "U_SYS7A";
            this.uSYS7ABindingSource.DataSource = this.dsAtt;
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
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(645, 270);
            this.splitContainer2.SplitterDistance = 190;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.label98, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtLastCheck, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCheckTime, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnBroswer, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label94, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label96, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label61, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label97, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCardNo, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label95, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label62, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label60, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtOntime, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtCardName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDataSource, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAdate, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTest, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtInitailCatalog, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUserId, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtNobr, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPassWord, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDataTable, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbTemperate, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTemperature, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIP, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSource, 7, 1);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 190);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(541, 161);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 23);
            this.btnImport.TabIndex = 11;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "匯入刷卡資料";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label98
            // 
            this.label98.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label98.AutoSize = true;
            this.label98.ForeColor = System.Drawing.Color.Red;
            this.label98.Location = new System.Drawing.Point(454, 133);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(77, 12);
            this.label98.TabIndex = 82;
            this.label98.Text = "最後檢核時間";
            // 
            // txtLastCheck
            // 
            this.txtLastCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLastCheck.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtLastCheck.CaptionLabel = this.label98;
            this.txtLastCheck.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLastCheck.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "LATEST_CHECK", true));
            this.txtLastCheck.DecimalPlace = 2;
            this.txtLastCheck.IsEmpty = false;
            this.txtLastCheck.Location = new System.Drawing.Point(537, 128);
            this.txtLastCheck.Mask = "0000/00/00";
            this.txtLastCheck.MaxLength = -1;
            this.txtLastCheck.Name = "txtLastCheck";
            this.txtLastCheck.PasswordChar = '\0';
            this.txtLastCheck.ReadOnly = false;
            this.txtLastCheck.ShowCalendarButton = true;
            this.txtLastCheck.Size = new System.Drawing.Size(77, 22);
            this.txtLastCheck.TabIndex = 14;
            this.txtLastCheck.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // txtCheckTime
            // 
            this.txtCheckTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCheckTime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCheckTime.CaptionLabel = this.label4;
            this.txtCheckTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCheckTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_CHECKTIME", true));
            this.txtCheckTime.DecimalPlace = 2;
            this.txtCheckTime.IsEmpty = true;
            this.txtCheckTime.Location = new System.Drawing.Point(537, 97);
            this.txtCheckTime.Mask = "";
            this.txtCheckTime.MaxLength = 50;
            this.txtCheckTime.Name = "txtCheckTime";
            this.txtCheckTime.PasswordChar = '\0';
            this.txtCheckTime.ReadOnly = true;
            this.txtCheckTime.ShowCalendarButton = true;
            this.txtCheckTime.Size = new System.Drawing.Size(98, 22);
            this.txtCheckTime.TabIndex = 13;
            this.txtCheckTime.TabStop = false;
            this.txtCheckTime.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(478, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 82;
            this.label4.Text = "檢核時間";
            // 
            // btnBroswer
            // 
            this.btnBroswer.Location = new System.Drawing.Point(259, 34);
            this.btnBroswer.Name = "btnBroswer";
            this.btnBroswer.Size = new System.Drawing.Size(28, 23);
            this.btnBroswer.TabIndex = 87;
            this.btnBroswer.TabStop = false;
            this.btnBroswer.Text = "..";
            this.btnBroswer.UseVisualStyleBackColor = true;
            this.btnBroswer.Visible = false;
            this.btnBroswer.Click += new System.EventHandler(this.btnBroswer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 85;
            this.label1.Text = "卡鐘名稱";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(296, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "資料表";
            // 
            // label94
            // 
            this.label94.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label94.AutoSize = true;
            this.label94.ForeColor = System.Drawing.Color.Red;
            this.label94.Location = new System.Drawing.Point(11, 40);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(53, 12);
            this.label94.TabIndex = 78;
            this.label94.Text = "主機名稱";
            // 
            // label96
            // 
            this.label96.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label96.AutoSize = true;
            this.label96.ForeColor = System.Drawing.Color.Red;
            this.label96.Location = new System.Drawing.Point(23, 71);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(41, 12);
            this.label96.TabIndex = 80;
            this.label96.Text = "資料庫";
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label61.AutoSize = true;
            this.label61.ForeColor = System.Drawing.Color.Red;
            this.label61.Location = new System.Drawing.Point(35, 102);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(29, 12);
            this.label61.TabIndex = 76;
            this.label61.Text = "帳號";
            // 
            // label97
            // 
            this.label97.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label97.AutoSize = true;
            this.label97.ForeColor = System.Drawing.Color.Black;
            this.label97.Location = new System.Drawing.Point(308, 102);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(29, 12);
            this.label97.TabIndex = 83;
            this.label97.Text = "時間";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(308, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 83;
            this.label2.Text = "卡號";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCardNo.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCardNo.CaptionLabel = null;
            this.txtCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCardNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_CARDNO", true));
            this.txtCardNo.DecimalPlace = 2;
            this.txtCardNo.IsEmpty = true;
            this.txtCardNo.Location = new System.Drawing.Point(343, 128);
            this.txtCardNo.Mask = "";
            this.txtCardNo.MaxLength = 50;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.PasswordChar = '\0';
            this.txtCardNo.ReadOnly = true;
            this.txtCardNo.ShowCalendarButton = true;
            this.txtCardNo.Size = new System.Drawing.Size(97, 22);
            this.txtCardNo.TabIndex = 10;
            this.txtCardNo.TabStop = false;
            this.txtCardNo.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label95
            // 
            this.label95.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label95.AutoSize = true;
            this.label95.ForeColor = System.Drawing.Color.Black;
            this.label95.Location = new System.Drawing.Point(308, 71);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(29, 12);
            this.label95.TabIndex = 81;
            this.label95.Text = "日期";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.Location = new System.Drawing.Point(308, 40);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(29, 12);
            this.label62.TabIndex = 79;
            this.label62.Text = "工號";
            // 
            // label60
            // 
            this.label60.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label60.AutoSize = true;
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(35, 133);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(29, 12);
            this.label60.TabIndex = 77;
            this.label60.Text = "密碼";
            // 
            // txtOntime
            // 
            this.txtOntime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOntime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtOntime.CaptionLabel = null;
            this.txtOntime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOntime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_ONTIME", true));
            this.txtOntime.DecimalPlace = 2;
            this.txtOntime.IsEmpty = true;
            this.txtOntime.Location = new System.Drawing.Point(343, 97);
            this.txtOntime.Mask = "";
            this.txtOntime.MaxLength = 50;
            this.txtOntime.Name = "txtOntime";
            this.txtOntime.PasswordChar = '\0';
            this.txtOntime.ReadOnly = true;
            this.txtOntime.ShowCalendarButton = true;
            this.txtOntime.Size = new System.Drawing.Size(97, 22);
            this.txtOntime.TabIndex = 9;
            this.txtOntime.TabStop = false;
            this.txtOntime.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(41, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 76;
            this.label7.Text = "SQL";
            // 
            // txtCardName
            // 
            this.txtCardName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCardName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCardName.CaptionLabel = null;
            this.txtCardName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCardName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "CARD_NAME", true));
            this.txtCardName.DecimalPlace = 2;
            this.txtCardName.IsEmpty = false;
            this.txtCardName.Location = new System.Drawing.Point(70, 4);
            this.txtCardName.Mask = "";
            this.txtCardName.MaxLength = 50;
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.PasswordChar = '\0';
            this.txtCardName.ReadOnly = false;
            this.txtCardName.ShowCalendarButton = true;
            this.txtCardName.Size = new System.Drawing.Size(109, 22);
            this.txtCardName.TabIndex = 0;
            this.txtCardName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtDataSource
            // 
            this.txtDataSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDataSource.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDataSource.CaptionLabel = null;
            this.txtDataSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDataSource, 2);
            this.txtDataSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "DATA_SOURCE", true));
            this.txtDataSource.DecimalPlace = 2;
            this.txtDataSource.IsEmpty = false;
            this.txtDataSource.Location = new System.Drawing.Point(70, 35);
            this.txtDataSource.Mask = "";
            this.txtDataSource.MaxLength = 50;
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.PasswordChar = '\0';
            this.txtDataSource.ReadOnly = false;
            this.txtDataSource.ShowCalendarButton = true;
            this.txtDataSource.Size = new System.Drawing.Size(182, 22);
            this.txtDataSource.TabIndex = 1;
            this.txtDataSource.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtAdate
            // 
            this.txtAdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = null;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_ADATE", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = true;
            this.txtAdate.Location = new System.Drawing.Point(343, 66);
            this.txtAdate.Mask = "";
            this.txtAdate.MaxLength = 50;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = true;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.Size = new System.Drawing.Size(97, 22);
            this.txtAdate.TabIndex = 8;
            this.txtAdate.TabStop = false;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(192, 127);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(59, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.TabStop = false;
            this.btnTest.Text = "測試";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtInitailCatalog
            // 
            this.txtInitailCatalog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInitailCatalog.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtInitailCatalog.CaptionLabel = null;
            this.txtInitailCatalog.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtInitailCatalog.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "INITAIL_CATALOG", true));
            this.txtInitailCatalog.DecimalPlace = 2;
            this.txtInitailCatalog.IsEmpty = true;
            this.txtInitailCatalog.Location = new System.Drawing.Point(70, 66);
            this.txtInitailCatalog.Mask = "";
            this.txtInitailCatalog.MaxLength = 50;
            this.txtInitailCatalog.Name = "txtInitailCatalog";
            this.txtInitailCatalog.PasswordChar = '\0';
            this.txtInitailCatalog.ReadOnly = false;
            this.txtInitailCatalog.ShowCalendarButton = true;
            this.txtInitailCatalog.Size = new System.Drawing.Size(109, 22);
            this.txtInitailCatalog.TabIndex = 2;
            this.txtInitailCatalog.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtUserId
            // 
            this.txtUserId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUserId.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtUserId.CaptionLabel = null;
            this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "USER_ID", true));
            this.txtUserId.DecimalPlace = 2;
            this.txtUserId.IsEmpty = true;
            this.txtUserId.Location = new System.Drawing.Point(70, 97);
            this.txtUserId.Mask = "";
            this.txtUserId.MaxLength = 50;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.PasswordChar = '\0';
            this.txtUserId.ReadOnly = false;
            this.txtUserId.ShowCalendarButton = true;
            this.txtUserId.Size = new System.Drawing.Size(109, 22);
            this.txtUserId.TabIndex = 3;
            this.txtUserId.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtNobr
            // 
            this.txtNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobr.CaptionLabel = null;
            this.txtNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_NOBR", true));
            this.txtNobr.DecimalPlace = 2;
            this.txtNobr.IsEmpty = true;
            this.txtNobr.Location = new System.Drawing.Point(343, 35);
            this.txtNobr.Mask = "";
            this.txtNobr.MaxLength = 50;
            this.txtNobr.Name = "txtNobr";
            this.txtNobr.PasswordChar = '\0';
            this.txtNobr.ReadOnly = true;
            this.txtNobr.ShowCalendarButton = true;
            this.txtNobr.Size = new System.Drawing.Size(97, 22);
            this.txtNobr.TabIndex = 7;
            this.txtNobr.TabStop = false;
            this.txtNobr.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassWord.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPassWord.CaptionLabel = null;
            this.txtPassWord.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassWord.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "PASSWORD", true));
            this.txtPassWord.DecimalPlace = 2;
            this.txtPassWord.IsEmpty = true;
            this.txtPassWord.Location = new System.Drawing.Point(70, 128);
            this.txtPassWord.Mask = "";
            this.txtPassWord.MaxLength = 50;
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.ReadOnly = false;
            this.txtPassWord.ShowCalendarButton = true;
            this.txtPassWord.Size = new System.Drawing.Size(109, 22);
            this.txtPassWord.TabIndex = 4;
            this.txtPassWord.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = null;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 6);
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "SQL", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(70, 161);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 500;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(461, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtDataTable
            // 
            this.txtDataTable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDataTable.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDataTable.CaptionLabel = null;
            this.txtDataTable.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDataTable.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "DATATABLE", true));
            this.txtDataTable.DecimalPlace = 2;
            this.txtDataTable.IsEmpty = true;
            this.txtDataTable.Location = new System.Drawing.Point(343, 4);
            this.txtDataTable.Mask = "";
            this.txtDataTable.MaxLength = 50;
            this.txtDataTable.Name = "txtDataTable";
            this.txtDataTable.PasswordChar = '\0';
            this.txtDataTable.ReadOnly = true;
            this.txtDataTable.ShowCalendarButton = true;
            this.txtDataTable.Size = new System.Drawing.Size(97, 22);
            this.txtDataTable.TabIndex = 6;
            this.txtDataTable.TabStop = false;
            this.txtDataTable.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lbTemperate
            // 
            this.lbTemperate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTemperate.AutoSize = true;
            this.lbTemperate.ForeColor = System.Drawing.Color.Black;
            this.lbTemperate.Location = new System.Drawing.Point(502, 9);
            this.lbTemperate.Name = "lbTemperate";
            this.lbTemperate.Size = new System.Drawing.Size(29, 12);
            this.lbTemperate.TabIndex = 88;
            this.lbTemperate.Text = "體溫";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTemperature.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTemperature.CaptionLabel = null;
            this.txtTemperature.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTemperature.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_TEMPERATURE", true));
            this.txtTemperature.DecimalPlace = 2;
            this.txtTemperature.IsEmpty = true;
            this.txtTemperature.Location = new System.Drawing.Point(537, 4);
            this.txtTemperature.Mask = "";
            this.txtTemperature.MaxLength = 50;
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.PasswordChar = '\0';
            this.txtTemperature.ReadOnly = true;
            this.txtTemperature.ShowCalendarButton = true;
            this.txtTemperature.Size = new System.Drawing.Size(97, 22);
            this.txtTemperature.TabIndex = 89;
            this.txtTemperature.TabStop = false;
            this.txtTemperature.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(502, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 82;
            this.label6.Text = "來源";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(490, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 82;
            this.label5.Text = "IP位置";
            // 
            // txtIP
            // 
            this.txtIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtIP.CaptionLabel = this.label5;
            this.txtIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_IPADD", true));
            this.txtIP.DecimalPlace = 2;
            this.txtIP.IsEmpty = true;
            this.txtIP.Location = new System.Drawing.Point(537, 66);
            this.txtIP.Mask = "";
            this.txtIP.MaxLength = 50;
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.ReadOnly = false;
            this.txtIP.ShowCalendarButton = true;
            this.txtIP.Size = new System.Drawing.Size(95, 22);
            this.txtIP.TabIndex = 12;
            this.txtIP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSource.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSource.CaptionLabel = this.label6;
            this.txtSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSYS7ABindingSource, "COL_SOURCE", true));
            this.txtSource.DecimalPlace = 2;
            this.txtSource.IsEmpty = true;
            this.txtSource.Location = new System.Drawing.Point(537, 35);
            this.txtSource.Mask = "";
            this.txtSource.MaxLength = 50;
            this.txtSource.Name = "txtSource";
            this.txtSource.PasswordChar = '\0';
            this.txtSource.ReadOnly = false;
            this.txtSource.ShowCalendarButton = true;
            this.txtSource.Size = new System.Drawing.Size(95, 22);
            this.txtSource.TabIndex = 11;
            this.txtSource.ValidType = JBControls.TextBox.EValidType.String;
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
            this.fullDataCtrl1.DataSource = this.uSYS7ABindingSource;
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
            this.fullDataCtrl1.Size = new System.Drawing.Size(645, 73);
            this.fullDataCtrl1.SortFields = "card_name";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.uSYS7ABindingSource;
            // 
            // u_SYS7ATableAdapter
            // 
            this.u_SYS7ATableAdapter.ClearBeforeFill = true;
            // 
            // FRM2K
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM2K";
            this.Text = "FRM2K";
            this.Load += new System.EventHandler(this.U_SYS7_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSYS7ABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
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
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label95;
        private JBControls.TextBox txtInitailCatalog;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label62;
        private JBControls.TextBox txtDataSource;
        private System.Windows.Forms.Label label94;
        private JBControls.TextBox txtPassWord;
        private System.Windows.Forms.Label label60;
        private JBControls.TextBox txtUserId;
        private System.Windows.Forms.Label label61;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private JBControls.DataGridView dataGridViewEx1;
        private JBControls.TextBox txtCardName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label2;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource uSYS7ABindingSource;
        private JBHR.Att.dsAttTableAdapters.U_SYS7ATableAdapter u_SYS7ATableAdapter;
        private JBControls.TextBox txtDataTable;
        private JBControls.TextBox txtCardNo;
        private JBControls.TextBox txtOntime;
        private JBControls.TextBox txtAdate;
        private JBControls.TextBox txtNobr;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox txtLastCheck;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtCheckTime;
        private JBControls.TextBox txtIP;
        private JBControls.TextBox txtSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBroswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATASOURCEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATATABLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLNOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLADATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLONTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLCARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTemperate;
        private JBControls.TextBox txtTemperature;
    }
}