namespace JBHR.Bas
{
	partial class FRM11Y
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
            this.aCCCDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aCCCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.ACCCD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.costTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CODE_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCCSALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbACCTYPE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCODE_C = new JBControls.TextBox();
            this.txtCODE_D = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.eXPDEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.aCCSALTableAdapter = new JBHR.Bas.BasDSTableAdapters.ACCSALTableAdapter();
            this.eXP_DEPTTableAdapter = new JBHR.Bas.BasDSTableAdapters.EXP_DEPTTableAdapter();
            this.aCCCDTableAdapter = new JBHR.Bas.BasDSTableAdapters.ACCCDTableAdapter();
            this.costTypeTableAdapter = new JBHR.Bas.BasDSTableAdapters.CostTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCSALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eXPDEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.aCCCDDataGridViewTextBoxColumn,
            this.ACCCD,
            this.Column2,
            this.Column1,
            this.CODE_D,
            this.CODE_C,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.aCCSALBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 259);
            this.dataGridViewEx1.TabIndex = 7;
            // 
            // aCCCDDataGridViewTextBoxColumn
            // 
            this.aCCCDDataGridViewTextBoxColumn.DataPropertyName = "ACCCD";
            this.aCCCDDataGridViewTextBoxColumn.DataSource = this.aCCCDBindingSource;
            this.aCCCDDataGridViewTextBoxColumn.DisplayMember = "ACCCD_DISP";
            this.aCCCDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.aCCCDDataGridViewTextBoxColumn.HeaderText = "科目代碼";
            this.aCCCDDataGridViewTextBoxColumn.Name = "aCCCDDataGridViewTextBoxColumn";
            this.aCCCDDataGridViewTextBoxColumn.ReadOnly = true;
            this.aCCCDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCCCDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCCCDDataGridViewTextBoxColumn.ValueMember = "ACCCD";
            this.aCCCDDataGridViewTextBoxColumn.Width = 78;
            // 
            // aCCCDBindingSource
            // 
            this.aCCCDBindingSource.DataMember = "ACCCD";
            this.aCCCDBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ACCCD
            // 
            this.ACCCD.DataPropertyName = "ACCCD";
            this.ACCCD.DataSource = this.aCCCDBindingSource;
            this.ACCCD.DisplayMember = "ACCNAME";
            this.ACCCD.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ACCCD.HeaderText = "科目名稱";
            this.ACCCD.Name = "ACCCD";
            this.ACCCD.ReadOnly = true;
            this.ACCCD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACCCD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ACCCD.ValueMember = "ACCCD";
            this.ACCCD.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "D_NO";
            this.Column2.HeaderText = "成本別代碼";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "D_NO";
            this.Column1.DataSource = this.costTypeBindingSource;
            this.Column1.DisplayMember = "CostTypeName";
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column1.HeaderText = "成本別名稱";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.ValueMember = "CostTypeCode";
            this.Column1.Width = 90;
            // 
            // costTypeBindingSource
            // 
            this.costTypeBindingSource.DataMember = "CostType";
            this.costTypeBindingSource.DataSource = this.basDS;
            // 
            // CODE_D
            // 
            this.CODE_D.DataPropertyName = "CODE_D";
            this.CODE_D.HeaderText = "借方科目";
            this.CODE_D.Name = "CODE_D";
            this.CODE_D.ReadOnly = true;
            this.CODE_D.Width = 78;
            // 
            // CODE_C
            // 
            this.CODE_C.DataPropertyName = "CODE_C";
            this.CODE_C.HeaderText = "貸方科目";
            this.CODE_C.Name = "CODE_C";
            this.CODE_C.ReadOnly = true;
            this.CODE_C.Width = 78;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登入者";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 66;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登入時間";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 78;
            // 
            // aCCSALBindingSource
            // 
            this.aCCSALBindingSource.DataMember = "ACCSAL";
            this.aCCSALBindingSource.DataSource = this.basDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 178);
            this.splitContainer2.SplitterDistance = 102;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.btnCodeGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 102);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbACCTYPE, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE_C, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCODE_D, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 89);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cbACCTYPE
            // 
            this.cbACCTYPE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbACCTYPE.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aCCSALBindingSource, "D_NO", true));
            this.cbACCTYPE.FormattingEnabled = true;
            this.cbACCTYPE.Location = new System.Drawing.Point(74, 4);
            this.cbACCTYPE.Name = "cbACCTYPE";
            this.cbACCTYPE.Size = new System.Drawing.Size(121, 20);
            this.cbACCTYPE.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "成本別代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "貸方科目";
            // 
            // txtCODE_C
            // 
            this.txtCODE_C.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCODE_C.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE_C.CaptionLabel = this.label2;
            this.txtCODE_C.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE_C.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCSALBindingSource, "CODE_C", true));
            this.txtCODE_C.DecimalPlace = 2;
            this.txtCODE_C.IsEmpty = true;
            this.txtCODE_C.Location = new System.Drawing.Point(74, 62);
            this.txtCODE_C.Mask = "";
            this.txtCODE_C.MaxLength = 50;
            this.txtCODE_C.Name = "txtCODE_C";
            this.txtCODE_C.PasswordChar = '\0';
            this.txtCODE_C.ReadOnly = false;
            this.txtCODE_C.ShowCalendarButton = true;
            this.txtCODE_C.Size = new System.Drawing.Size(100, 22);
            this.txtCODE_C.TabIndex = 2;
            this.txtCODE_C.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtCODE_D
            // 
            this.txtCODE_D.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCODE_D.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCODE_D.CaptionLabel = this.label1;
            this.txtCODE_D.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCODE_D.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCCSALBindingSource, "CODE_D", true));
            this.txtCODE_D.DecimalPlace = 2;
            this.txtCODE_D.IsEmpty = true;
            this.txtCODE_D.Location = new System.Drawing.Point(74, 32);
            this.txtCODE_D.Mask = "";
            this.txtCODE_D.MaxLength = 50;
            this.txtCODE_D.Name = "txtCODE_D";
            this.txtCODE_D.PasswordChar = '\0';
            this.txtCODE_D.ReadOnly = false;
            this.txtCODE_D.ShowCalendarButton = true;
            this.txtCODE_D.Size = new System.Drawing.Size(100, 22);
            this.txtCODE_D.TabIndex = 1;
            this.txtCODE_D.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "借方科目";
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(542, 69);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 3;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Visible = false;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
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
            this.fullDataCtrl1.DataSource = this.aCCSALBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = true;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "empcd,empdescr";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "empcd,empdescr";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // eXPDEPTBindingSource
            // 
            this.eXPDEPTBindingSource.DataMember = "EXP_DEPT";
            this.eXPDEPTBindingSource.DataSource = this.basDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // aCCSALTableAdapter
            // 
            this.aCCSALTableAdapter.ClearBeforeFill = true;
            // 
            // eXP_DEPTTableAdapter
            // 
            this.eXP_DEPTTableAdapter.ClearBeforeFill = true;
            // 
            // aCCCDTableAdapter
            // 
            this.aCCCDTableAdapter.ClearBeforeFill = true;
            // 
            // costTypeTableAdapter
            // 
            this.costTypeTableAdapter.ClearBeforeFill = true;
            // 
            // FRM11Y
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM11Y";
            this.Text = "FRM11Y";
            this.Load += new System.EventHandler(this.FRM11D_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCCSALBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eXPDEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private JBControls.DataGridView dataGridViewEx1;
		private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.Panel panel1;
		private JBControls.TextBox txtCODE_C;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox txtCODE_D;
        private System.Windows.Forms.Label label1;
        private BasDS basDS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.BindingSource aCCSALBindingSource;
        private BasDSTableAdapters.ACCSALTableAdapter aCCSALTableAdapter;
        private System.Windows.Forms.ComboBox cbACCTYPE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource eXPDEPTBindingSource;
        private BasDSTableAdapters.EXP_DEPTTableAdapter eXP_DEPTTableAdapter;
        private Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource aCCCDBindingSource;
        private BasDSTableAdapters.ACCCDTableAdapter aCCCDTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource costTypeBindingSource;
        private BasDSTableAdapters.CostTypeTableAdapter costTypeTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn aCCCDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ACCCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
	}
}