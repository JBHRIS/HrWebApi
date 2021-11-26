namespace JBHR.Sal
{
    partial class FRM45E
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM45E));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDept = new JBControls.TextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.textBox8 = new JBControls.TextBox();
            this.bASETTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.textBox9 = new JBControls.TextBox();
            this.dv = new JBControls.DataGridView();
            this.checkBox1 = new JBControls.CheckBox();
            this.checkBox2 = new JBControls.CheckBox();
            this.checkBox3 = new JBControls.CheckBox();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sALBASDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new JBControls.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAL_CODE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMTBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mENODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALBASDTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALBASDTableAdapter();
            this.bASETableAdapter = new JBHR.Bas.BasDSTableAdapters.BASETableAdapter();
            this.bASETTSTableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETTSTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASETTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALBASDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.6124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.3876F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDept, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox8, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox9, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(735, 56);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "扶養人數";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "員工提撥比率";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(449, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "所得稅預扣金額";
            // 
            // txtDept
            // 
            this.txtDept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDept.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDept.CaptionLabel = null;
            this.txtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDept.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bASEBindingSource, "TAXCNT", true));
            this.txtDept.DecimalPlace = 2;
            this.txtDept.Enabled = false;
            this.txtDept.IsEmpty = true;
            this.txtDept.Location = new System.Drawing.Point(104, 13);
            this.txtDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDept.Mask = "";
            this.txtDept.MaxLength = -1;
            this.txtDept.Name = "txtDept";
            this.txtDept.PasswordChar = '\0';
            this.txtDept.ReadOnly = false;
            this.txtDept.ShowCalendarButton = true;
            this.txtDept.Size = new System.Drawing.Size(84, 29);
            this.txtDept.TabIndex = 1;
            this.txtDept.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox8.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox8.CaptionLabel = null;
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bASETTSBindingSource, "RETRATE", true));
            this.textBox8.DecimalPlace = 2;
            this.textBox8.Enabled = false;
            this.textBox8.IsEmpty = true;
            this.textBox8.Location = new System.Drawing.Point(329, 13);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox8.Mask = "";
            this.textBox8.MaxLength = -1;
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = '\0';
            this.textBox8.ReadOnly = false;
            this.textBox8.ShowCalendarButton = true;
            this.textBox8.Size = new System.Drawing.Size(108, 29);
            this.textBox8.TabIndex = 1;
            this.textBox8.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // bASETTSBindingSource
            // 
            this.bASETTSBindingSource.DataMember = "BASETTS";
            this.bASETTSBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox9.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox9.CaptionLabel = null;
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bASEBindingSource, "PRETAX", true));
            this.textBox9.DecimalPlace = 2;
            this.textBox9.Enabled = false;
            this.textBox9.IsEmpty = true;
            this.textBox9.Location = new System.Drawing.Point(605, 13);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox9.Mask = "";
            this.textBox9.MaxLength = -1;
            this.textBox9.Name = "textBox9";
            this.textBox9.PasswordChar = '\0';
            this.textBox9.ReadOnly = false;
            this.textBox9.ShowCalendarButton = true;
            this.textBox9.Size = new System.Drawing.Size(114, 29);
            this.textBox9.TabIndex = 1;
            this.textBox9.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // dv
            // 
            this.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv.Location = new System.Drawing.Point(18, 82);
            this.dv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dv.Name = "dv";
            this.dv.ReadOnly = true;
            this.dv.RowHeadersWidth = 62;
            this.dv.RowTemplate.Height = 24;
            this.dv.Size = new System.Drawing.Size(1138, 171);
            this.dv.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bASETTSBindingSource, "FIXRATE", true));
            this.checkBox1.Enabled = false;
            this.checkBox1.IsImitateCaption = false;
            this.checkBox1.Location = new System.Drawing.Point(762, 38);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(160, 22);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "所得稅固定稅率";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CaptionLabel = null;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bASEBindingSource, "COUNT_MA", true));
            this.checkBox2.Enabled = false;
            this.checkBox2.IsImitateCaption = false;
            this.checkBox2.Location = new System.Drawing.Point(933, 36);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(70, 22);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "外勞";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CaptionLabel = null;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bASETTSBindingSource, "NOWAGE", true));
            this.checkBox3.Enabled = false;
            this.checkBox3.IsImitateCaption = false;
            this.checkBox3.Location = new System.Drawing.Point(1014, 34);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(88, 22);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "不發薪";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // sALCODEBindingSource
            // 
            this.sALCODEBindingSource.DataMember = "SALCODE";
            this.sALCODEBindingSource.DataSource = this.salaryDS;
            // 
            // sALBASDBindingSource
            // 
            this.sALBASDBindingSource.DataMember = "SALBASD";
            this.sALBASDBindingSource.DataSource = this.salaryDS;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.aDATEDataGridViewTextBoxColumn,
            this.sALCODEDataGridViewTextBoxColumn,
            this.SAL_CODE,
            this.aMTDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.aMTBDataGridViewTextBoxColumn,
            this.mENODataGridViewTextBoxColumn,
            this.dDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sALBASDBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(18, 280);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1138, 396);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "紀錄";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 150;
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "異動日期";
            this.aDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDATEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aDATEDataGridViewTextBoxColumn.Width = 150;
            // 
            // sALCODEDataGridViewTextBoxColumn
            // 
            this.sALCODEDataGridViewTextBoxColumn.DataPropertyName = "SAL_CODE";
            this.sALCODEDataGridViewTextBoxColumn.HeaderText = "薪資代碼";
            this.sALCODEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sALCODEDataGridViewTextBoxColumn.Name = "sALCODEDataGridViewTextBoxColumn";
            this.sALCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sALCODEDataGridViewTextBoxColumn.Width = 150;
            // 
            // SAL_CODE
            // 
            this.SAL_CODE.DataPropertyName = "SAL_CODE";
            this.SAL_CODE.DataSource = this.sALCODEBindingSource;
            this.SAL_CODE.DisplayMember = "SAL_NAME";
            this.SAL_CODE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SAL_CODE.HeaderText = "薪資名稱";
            this.SAL_CODE.MinimumWidth = 8;
            this.SAL_CODE.Name = "SAL_CODE";
            this.SAL_CODE.ReadOnly = true;
            this.SAL_CODE.ValueMember = "SAL_CODE";
            this.SAL_CODE.Width = 150;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "金額";
            this.aMTDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.aMTDataGridViewTextBoxColumn.Width = 150;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 150;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 150;
            // 
            // aMTBDataGridViewTextBoxColumn
            // 
            this.aMTBDataGridViewTextBoxColumn.DataPropertyName = "AMTB";
            this.aMTBDataGridViewTextBoxColumn.HeaderText = "AMTB";
            this.aMTBDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aMTBDataGridViewTextBoxColumn.Name = "aMTBDataGridViewTextBoxColumn";
            this.aMTBDataGridViewTextBoxColumn.ReadOnly = true;
            this.aMTBDataGridViewTextBoxColumn.Width = 150;
            // 
            // mENODataGridViewTextBoxColumn
            // 
            this.mENODataGridViewTextBoxColumn.DataPropertyName = "MENO";
            this.mENODataGridViewTextBoxColumn.HeaderText = "備註";
            this.mENODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mENODataGridViewTextBoxColumn.Name = "mENODataGridViewTextBoxColumn";
            this.mENODataGridViewTextBoxColumn.ReadOnly = true;
            this.mENODataGridViewTextBoxColumn.Width = 150;
            // 
            // dDATEDataGridViewTextBoxColumn
            // 
            this.dDATEDataGridViewTextBoxColumn.DataPropertyName = "DDATE";
            this.dDATEDataGridViewTextBoxColumn.HeaderText = "失效日期";
            this.dDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dDATEDataGridViewTextBoxColumn.Name = "dDATEDataGridViewTextBoxColumn";
            this.dDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dDATEDataGridViewTextBoxColumn.Width = 150;
            // 
            // sALBASDTableAdapter
            // 
            this.sALBASDTableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // bASETTSTableAdapter
            // 
            this.bASETTSTableAdapter.ClearBeforeFill = true;
            // 
            // FRM45E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 744);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FRM45E";
            this.Text = "FRM45E";
            this.Load += new System.EventHandler(this.FRM45E_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASETTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sALBASDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.DataGridView dv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox txtDept;
        private JBControls.TextBox textBox8;
        private JBControls.TextBox textBox9;
        private JBControls.CheckBox checkBox1;
        private JBControls.CheckBox checkBox2;
        private JBControls.CheckBox checkBox3;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource sALBASDBindingSource;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn SAL_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDATEDataGridViewTextBoxColumn;
        private JBHR.Sal.SalaryDSTableAdapters.SALBASDTableAdapter sALBASDTableAdapter;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private Bas.BasDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASETTSBindingSource;
        private SalaryDSTableAdapters.BASETTSTableAdapter bASETTSTableAdapter;
    }
}