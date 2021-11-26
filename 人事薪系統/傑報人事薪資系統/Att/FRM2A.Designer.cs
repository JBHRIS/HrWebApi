namespace JBHR.Att
{
    partial class FRM2A
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
            this.dataGridView1 = new JBControls.DataGridView();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.rOTEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.extDS = new JBHR.Ins.extDS();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOTECHGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bnImport = new System.Windows.Forms.Button();
            this.bnCreateExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxRote = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.txtBdate = new JBControls.TextBox();
            this.txtEdate = new JBControls.TextBox();
            this.chkNoTran = new JBControls.CheckBox();
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rOTECHGTableAdapter = new JBHR.Att.dsAttTableAdapters.ROTECHGTableAdapter();
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.rOTETableAdapter = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.rOTETableAdapter1 = new JBHR.Ins.extDSTableAdapters.ROTETableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTECHGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 210);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aDATEDataGridViewTextBoxColumn,
            this.nOBRDataGridViewTextBoxColumn,
            this.rOTEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.rOTECHGBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(622, 206);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "調班日期起";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOTEDataGridViewTextBoxColumn
            // 
            this.rOTEDataGridViewTextBoxColumn.DataPropertyName = "ROTE";
            this.rOTEDataGridViewTextBoxColumn.DataSource = this.rOTEBindingSource1;
            this.rOTEDataGridViewTextBoxColumn.DisplayMember = "ROTE_DISP";
            this.rOTEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.rOTEDataGridViewTextBoxColumn.HeaderText = "班別";
            this.rOTEDataGridViewTextBoxColumn.Name = "rOTEDataGridViewTextBoxColumn";
            this.rOTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.rOTEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rOTEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rOTEDataGridViewTextBoxColumn.ValueMember = "ROTE";
            // 
            // rOTEBindingSource1
            // 
            this.rOTEBindingSource1.DataMember = "ROTE";
            this.rOTEBindingSource1.DataSource = this.extDS;
            // 
            // extDS
            // 
            this.extDS.DataSetName = "extDS";
            this.extDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.extDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // rOTECHGBindingSource
            // 
            this.rOTECHGBindingSource.DataMember = "ROTECHG";
            this.rOTECHGBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.fullDataCtrl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 81);
            this.panel2.TabIndex = 1;
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
            this.fullDataCtrl1.DataSource = this.rOTECHGBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-3, 3);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "adate,nobr,rote";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "adate,nobr,rote";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bnImport);
            this.panel3.Controls.Add(this.bnCreateExcel);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(626, 150);
            this.panel3.TabIndex = 2;
            // 
            // bnImport
            // 
            this.bnImport.Location = new System.Drawing.Point(547, 119);
            this.bnImport.Name = "bnImport";
            this.bnImport.Size = new System.Drawing.Size(75, 23);
            this.bnImport.TabIndex = 8;
            this.bnImport.TabStop = false;
            this.bnImport.Text = "開始匯入";
            this.bnImport.UseVisualStyleBackColor = true;
            this.bnImport.Click += new System.EventHandler(this.bnImport_Click);
            // 
            // bnCreateExcel
            // 
            this.bnCreateExcel.Location = new System.Drawing.Point(466, 119);
            this.bnCreateExcel.Name = "bnCreateExcel";
            this.bnCreateExcel.Size = new System.Drawing.Size(75, 23);
            this.bnCreateExcel.TabIndex = 7;
            this.bnCreateExcel.TabStop = false;
            this.bnCreateExcel.Text = "匯出樣板";
            this.bnCreateExcel.UseVisualStyleBackColor = true;
            this.bnCreateExcel.Click += new System.EventHandler(this.bnCreateExcel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbxRote, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBdate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEdate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkNoTran, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(281, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbxRote
            // 
            this.cbxRote.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.rOTECHGBindingSource, "ROTE", true));
            this.cbxRote.FormattingEnabled = true;
            this.cbxRote.Location = new System.Drawing.Point(74, 115);
            this.cbxRote.Name = "cbxRote";
            this.cbxRote.Size = new System.Drawing.Size(121, 20);
            this.cbxRote.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "調班日期起";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "調班日期迄";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "班別";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTECHGBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.bASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = true;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(74, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(65, 22);
            this.ptxNobr.TabIndex = 1;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtBdate
            // 
            this.txtBdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBdate.CaptionLabel = this.label2;
            this.txtBdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rOTECHGBindingSource, "ADATE", true));
            this.txtBdate.DecimalPlace = 2;
            this.txtBdate.IsEmpty = true;
            this.txtBdate.Location = new System.Drawing.Point(74, 59);
            this.txtBdate.Mask = "0000/00/00";
            this.txtBdate.MaxLength = -1;
            this.txtBdate.Name = "txtBdate";
            this.txtBdate.PasswordChar = '\0';
            this.txtBdate.ReadOnly = false;
            this.txtBdate.ShowCalendarButton = true;
            this.txtBdate.Size = new System.Drawing.Size(100, 22);
            this.txtBdate.TabIndex = 1;
            this.txtBdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtBdate.Validating += new System.ComponentModel.CancelEventHandler(this.txtBdate_Validating);
            this.txtBdate.Validated += new System.EventHandler(this.txtBdate_Validated);
            // 
            // txtEdate
            // 
            this.txtEdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEdate.CaptionLabel = this.label3;
            this.txtEdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEdate.DecimalPlace = 2;
            this.txtEdate.IsEmpty = true;
            this.txtEdate.Location = new System.Drawing.Point(74, 87);
            this.txtEdate.Mask = "0000/00/00";
            this.txtEdate.MaxLength = -1;
            this.txtEdate.Name = "txtEdate";
            this.txtEdate.PasswordChar = '\0';
            this.txtEdate.ReadOnly = false;
            this.txtEdate.ShowCalendarButton = true;
            this.txtEdate.Size = new System.Drawing.Size(100, 22);
            this.txtEdate.TabIndex = 2;
            this.txtEdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtEdate.Validated += new System.EventHandler(this.txtEdate_Validated);
            // 
            // chkNoTran
            // 
            this.chkNoTran.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkNoTran.AutoSize = true;
            this.chkNoTran.CaptionLabel = null;
            this.chkNoTran.IsImitateCaption = true;
            this.chkNoTran.Location = new System.Drawing.Point(74, 34);
            this.chkNoTran.Name = "chkNoTran";
            this.chkNoTran.Size = new System.Drawing.Size(84, 16);
            this.chkNoTran.TabIndex = 1;
            this.chkNoTran.TabStop = false;
            this.chkNoTran.Text = "假日不轉換";
            this.chkNoTran.UseVisualStyleBackColor = true;
            // 
            // rOTEBindingSource
            // 
            this.rOTEBindingSource.DataMember = "ROTE";
            this.rOTEBindingSource.DataSource = this.dsAtt;
            // 
            // rOTECHGTableAdapter
            // 
            this.rOTECHGTableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // rOTETableAdapter
            // 
            this.rOTETableAdapter.ClearBeforeFill = true;
            // 
            // rOTETableAdapter1
            // 
            this.rOTETableAdapter1.ClearBeforeFill = true;
            // 
            // FRM2A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FRM2A";
            this.Text = "FRM2A";
            this.Load += new System.EventHandler(this.FRM2A_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTECHGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtBdate;
        private JBControls.TextBox txtEdate;
        private JBControls.CheckBox chkNoTran;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource rOTECHGBindingSource;
        private JBHR.Att.dsAttTableAdapters.ROTECHGTableAdapter rOTECHGTableAdapter;
        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource rOTEBindingSource;
        private JBHR.Att.dsAttTableAdapters.ROTETableAdapter rOTETableAdapter;
        private System.Windows.Forms.ComboBox cbxRote;
        private Ins.extDS extDS;
        private System.Windows.Forms.BindingSource rOTEBindingSource1;
        private Ins.extDSTableAdapters.ROTETableAdapter rOTETableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn rOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bnImport;
        private System.Windows.Forms.Button bnCreateExcel;
    }
}