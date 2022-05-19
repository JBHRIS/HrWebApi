namespace JBHR.Sal
{
    partial class FRM3AA
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.cbxLab = new System.Windows.Forms.ComboBox();
            this.cbxRet = new System.Windows.Forms.ComboBox();
            this.cbMemo = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDdate = new JBControls.TextBox();
            this.comboBoxSheet = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.cbxHea = new System.Windows.Forms.ComboBox();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonGen = new System.Windows.Forms.Button();
            this.insDS = new JBHR.Ins.InsDS();
            this.fRM3AZBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv = new JBControls.DataGridView();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxJob = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxReason = new System.Windows.Forms.ComboBox();
            this.iNSNAMEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iNSNAMETableAdapter = new JBHR.Ins.InsDSTableAdapters.INSNAMETableAdapter();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REASON = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lAMT1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J_AMT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hAMT1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAMT1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEMARKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fRM3AZBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iNSNAMEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 4);
            this.textBox1.Location = new System.Drawing.Point(92, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(305, 22);
            this.textBox1.TabIndex = 0;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowser.Location = new System.Drawing.Point(419, 3);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 21);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "瀏覽";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // cbxLab
            // 
            this.cbxLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLab.FormattingEnabled = true;
            this.cbxLab.Location = new System.Drawing.Point(92, 58);
            this.cbxLab.Name = "cbxLab";
            this.cbxLab.Size = new System.Drawing.Size(103, 20);
            this.cbxLab.TabIndex = 7;
            // 
            // cbxRet
            // 
            this.cbxRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRet.FormattingEnabled = true;
            this.cbxRet.Location = new System.Drawing.Point(572, 58);
            this.cbxRet.Name = "cbxRet";
            this.cbxRet.Size = new System.Drawing.Size(106, 20);
            this.cbxRet.TabIndex = 9;
            // 
            // cbMemo
            // 
            this.cbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMemo.FormattingEnabled = true;
            this.cbMemo.Location = new System.Drawing.Point(572, 30);
            this.cbMemo.Name = "cbMemo";
            this.cbMemo.Size = new System.Drawing.Size(106, 20);
            this.cbMemo.TabIndex = 6;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(788, 57);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 22);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "轉入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "生效日期";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "勞保";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "職災";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "勞退";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "備註";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "匯入檔名";
            // 
            // txtDdate
            // 
            this.txtDdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDdate.CaptionLabel = null;
            this.txtDdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDdate.DecimalPlace = 2;
            this.txtDdate.IsEmpty = true;
            this.txtDdate.Location = new System.Drawing.Point(92, 30);
            this.txtDdate.Mask = "0000/00/00";
            this.txtDdate.MaxLength = -1;
            this.txtDdate.Name = "txtDdate";
            this.txtDdate.PasswordChar = '\0';
            this.txtDdate.ReadOnly = false;
            this.txtDdate.ShowCalendarButton = true;
            this.txtDdate.Size = new System.Drawing.Size(103, 22);
            this.txtDdate.TabIndex = 4;
            this.txtDdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // comboBoxSheet
            // 
            this.comboBoxSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSheet.FormattingEnabled = true;
            this.comboBoxSheet.Location = new System.Drawing.Point(572, 3);
            this.comboBoxSheet.Name = "comboBoxSheet";
            this.comboBoxSheet.Size = new System.Drawing.Size(106, 20);
            this.comboBoxSheet.TabIndex = 2;
            this.comboBoxSheet.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheet_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "工作表";
            // 
            // btnView
            // 
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnView.Location = new System.Drawing.Point(693, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 21);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "檢視";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cbxHea
            // 
            this.cbxHea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxHea.FormattingEnabled = true;
            this.cbxHea.Location = new System.Drawing.Point(403, 58);
            this.cbxHea.Name = "cbxHea";
            this.cbxHea.Size = new System.Drawing.Size(107, 20);
            this.cbxHea.TabIndex = 8;
            // 
            // cbxNobr
            // 
            this.cbxNobr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(249, 30);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(102, 20);
            this.cbxNobr.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "工號";
            // 
            // buttonGen
            // 
            this.buttonGen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGen.Location = new System.Drawing.Point(693, 57);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(75, 22);
            this.buttonGen.TabIndex = 10;
            this.buttonGen.Text = "產生";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // insDS
            // 
            this.insDS.DataSetName = "InsDS";
            this.insDS.Locale = new System.Globalization.CultureInfo("");
            this.insDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fRM3AZBindingSource
            // 
            this.fRM3AZBindingSource.DataMember = "FRM3AZ";
            this.fRM3AZBindingSource.DataSource = this.insDS;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.nOBRDataGridViewTextBoxColumn,
            this.nAMECDataGridViewTextBoxColumn,
            this.REASON,
            this.lAMT1DataGridViewTextBoxColumn,
            this.J_AMT1,
            this.hAMT1DataGridViewTextBoxColumn,
            this.rAMT1DataGridViewTextBoxColumn,
            this.rEMARKDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.fRM3AZBindingSource;
            this.dgv.Location = new System.Drawing.Point(12, 92);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(871, 480);
            this.dgv.TabIndex = 21;
            // 
            // pbStatus
            // 
            this.pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.pbStatus, 2);
            this.pbStatus.Location = new System.Drawing.Point(684, 30);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(184, 21);
            this.pbStatus.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.31034F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.758621F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.17241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.865169F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.73034F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.90449F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbStatus, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxLab, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnView, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSheet, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMemo, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxRet, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonGen, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxHea, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxJob, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowser, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxNobr, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxReason, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(871, 82);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // cbxJob
            // 
            this.cbxJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxJob.FormattingEnabled = true;
            this.cbxJob.Location = new System.Drawing.Point(249, 58);
            this.cbxJob.Name = "cbxJob";
            this.cbxJob.Size = new System.Drawing.Size(102, 20);
            this.cbxJob.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(368, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "健保";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "異動原因";
            // 
            // comboBoxReason
            // 
            this.comboBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReason.FormattingEnabled = true;
            this.comboBoxReason.Location = new System.Drawing.Point(403, 30);
            this.comboBoxReason.Name = "comboBoxReason";
            this.comboBoxReason.Size = new System.Drawing.Size(107, 20);
            this.comboBoxReason.TabIndex = 6;
            // 
            // iNSNAMEBindingSource
            // 
            this.iNSNAMEBindingSource.DataMember = "INSNAME";
            this.iNSNAMEBindingSource.DataSource = this.insDS;
            // 
            // iNSNAMETableAdapter
            // 
            this.iNSNAMETableAdapter.ClearBeforeFill = true;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Width = 78;
            // 
            // nAMECDataGridViewTextBoxColumn
            // 
            this.nAMECDataGridViewTextBoxColumn.DataPropertyName = "NAME_C";
            this.nAMECDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nAMECDataGridViewTextBoxColumn.Name = "nAMECDataGridViewTextBoxColumn";
            this.nAMECDataGridViewTextBoxColumn.ReadOnly = true;
            this.nAMECDataGridViewTextBoxColumn.Width = 78;
            // 
            // REASON
            // 
            this.REASON.DataPropertyName = "REASON";
            this.REASON.DataSource = this.iNSNAMEBindingSource;
            this.REASON.DisplayMember = "NAME";
            this.REASON.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.REASON.HeaderText = "異動原因";
            this.REASON.Name = "REASON";
            this.REASON.ReadOnly = true;
            this.REASON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REASON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.REASON.ValueMember = "NO";
            this.REASON.Width = 78;
            // 
            // lAMT1DataGridViewTextBoxColumn
            // 
            this.lAMT1DataGridViewTextBoxColumn.DataPropertyName = "L_AMT1";
            this.lAMT1DataGridViewTextBoxColumn.HeaderText = "應該勞保金額";
            this.lAMT1DataGridViewTextBoxColumn.Name = "lAMT1DataGridViewTextBoxColumn";
            this.lAMT1DataGridViewTextBoxColumn.ReadOnly = true;
            this.lAMT1DataGridViewTextBoxColumn.Width = 102;
            // 
            // J_AMT1
            // 
            this.J_AMT1.DataPropertyName = "J_AMT1";
            this.J_AMT1.HeaderText = "應該職災金額";
            this.J_AMT1.Name = "J_AMT1";
            this.J_AMT1.ReadOnly = true;
            this.J_AMT1.Width = 102;
            // 
            // hAMT1DataGridViewTextBoxColumn
            // 
            this.hAMT1DataGridViewTextBoxColumn.DataPropertyName = "H_AMT1";
            this.hAMT1DataGridViewTextBoxColumn.HeaderText = "應該健保金額";
            this.hAMT1DataGridViewTextBoxColumn.Name = "hAMT1DataGridViewTextBoxColumn";
            this.hAMT1DataGridViewTextBoxColumn.ReadOnly = true;
            this.hAMT1DataGridViewTextBoxColumn.Width = 102;
            // 
            // rAMT1DataGridViewTextBoxColumn
            // 
            this.rAMT1DataGridViewTextBoxColumn.DataPropertyName = "R_AMT1";
            this.rAMT1DataGridViewTextBoxColumn.HeaderText = "應該勞退工資";
            this.rAMT1DataGridViewTextBoxColumn.Name = "rAMT1DataGridViewTextBoxColumn";
            this.rAMT1DataGridViewTextBoxColumn.ReadOnly = true;
            this.rAMT1DataGridViewTextBoxColumn.Width = 102;
            // 
            // rEMARKDataGridViewTextBoxColumn
            // 
            this.rEMARKDataGridViewTextBoxColumn.DataPropertyName = "REMARK";
            this.rEMARKDataGridViewTextBoxColumn.HeaderText = "錯誤註記";
            this.rEMARKDataGridViewTextBoxColumn.Name = "rEMARKDataGridViewTextBoxColumn";
            this.rEMARKDataGridViewTextBoxColumn.ReadOnly = true;
            this.rEMARKDataGridViewTextBoxColumn.Width = 78;
            // 
            // FRM3AA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM3AA";
            this.Text = "FRM3AA-勞健保調整資料匯入";
            this.Load += new System.EventHandler(this.IP_FRM4L_Load);
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fRM3AZBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iNSNAMEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.ComboBox cbxLab;
        private System.Windows.Forms.ComboBox cbxRet;
        private System.Windows.Forms.ComboBox cbMemo;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtDdate;
        private System.Windows.Forms.ComboBox comboBoxSheet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cbxHea;
        private System.Windows.Forms.ComboBox cbxNobr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonGen;
        private Ins.InsDS insDS;
        private System.Windows.Forms.BindingSource fRM3AZBindingSource;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxJob;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxReason;
        private System.Windows.Forms.BindingSource iNSNAMEBindingSource;
        private Ins.InsDSTableAdapters.INSNAMETableAdapter iNSNAMETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn REASON;
        private System.Windows.Forms.DataGridViewTextBoxColumn lAMT1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn J_AMT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hAMT1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAMT1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEMARKDataGridViewTextBoxColumn;
    }
}