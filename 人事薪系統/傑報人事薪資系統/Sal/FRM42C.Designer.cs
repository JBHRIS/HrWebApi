
namespace JBHR.Sal
{
    partial class FRM42C
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new JBControls.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.comboBox_DateType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_BranchCode = new System.Windows.Forms.TextBox();
            this.textBox_BankID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_Bank = new System.Windows.Forms.ComboBox();
            this.textBox_CompID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_BankAc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Comp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LABCHECK = new System.Windows.Forms.CheckBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.salaryTransferBankbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryTransferDataSet = new JBHR.SalaryTransferDataSet();
            this.salaryTransferBankTableAdapter = new JBHR.SalaryTransferDataSetTableAdapters.SalaryTransferBankTableAdapter();
            this.AUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBANKACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBANKNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBANKNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBANKIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBANKUSERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBRANCHCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYBANKLENGTHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPHASHEADERDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cOMPHASFOOTERDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cOMPDATETYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryTransferBankbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryTransferDataSet)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(637, 383);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AUTO,
            this.cOMPIDDataGridViewTextBoxColumn,
            this.cOMPNODataGridViewTextBoxColumn,
            this.cOMPNAMEDataGridViewTextBoxColumn,
            this.cOMPANYBANKACDataGridViewTextBoxColumn,
            this.cOMPANYBANKNODataGridViewTextBoxColumn,
            this.cOMPANYBANKNAMEDataGridViewTextBoxColumn,
            this.cOMPANYBANKIDDataGridViewTextBoxColumn,
            this.cOMPANYBANKUSERDataGridViewTextBoxColumn,
            this.cOMPANYBRANCHCODEDataGridViewTextBoxColumn,
            this.cOMPANYBANKLENGTHDataGridViewTextBoxColumn,
            this.cOMPHASHEADERDataGridViewCheckBoxColumn,
            this.cOMPHASFOOTERDataGridViewCheckBoxColumn,
            this.cOMPDATETYPEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.salaryTransferBankbindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(637, 184);
            this.dataGridView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownLength);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_User);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox_DateType);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_BranchCode);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_BankID);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox_Bank);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_CompID);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_BankAc);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox_Comp);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.LABCHECK);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(637, 195);
            this.splitContainer2.SplitterDistance = 113;
            this.splitContainer2.TabIndex = 0;
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.salaryTransferBankbindingSource, "COMPANY_BANK_LENGTH", true));
            this.numericUpDownLength.Location = new System.Drawing.Point(483, 59);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(122, 22);
            this.numericUpDownLength.TabIndex = 1;
            this.numericUpDownLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox_User
            // 
            this.textBox_User.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMPANY_BANK_USER", true));
            this.textBox_User.Location = new System.Drawing.Point(483, 32);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(122, 22);
            this.textBox_User.TabIndex = 2;
            // 
            // comboBox_DateType
            // 
            this.comboBox_DateType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salaryTransferBankbindingSource, "COMP_DATE_TYPE", true));
            this.comboBox_DateType.FormattingEnabled = true;
            this.comboBox_DateType.Location = new System.Drawing.Point(483, 5);
            this.comboBox_DateType.Name = "comboBox_DateType";
            this.comboBox_DateType.Size = new System.Drawing.Size(122, 20);
            this.comboBox_DateType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(424, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "帳戶長度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(221, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "代理編號";
            // 
            // textBox_BranchCode
            // 
            this.textBox_BranchCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMPANY_BRANCH_CODE", true));
            this.textBox_BranchCode.Location = new System.Drawing.Point(280, 31);
            this.textBox_BranchCode.Name = "textBox_BranchCode";
            this.textBox_BranchCode.Size = new System.Drawing.Size(122, 22);
            this.textBox_BranchCode.TabIndex = 2;
            // 
            // textBox_BankID
            // 
            this.textBox_BankID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMPANY_BANK_ID", true));
            this.textBox_BankID.Location = new System.Drawing.Point(280, 59);
            this.textBox_BankID.Name = "textBox_BankID";
            this.textBox_BankID.Size = new System.Drawing.Size(122, 22);
            this.textBox_BankID.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(436, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "使用者";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(424, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "日期格式";
            // 
            // comboBox_Bank
            // 
            this.comboBox_Bank.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salaryTransferBankbindingSource, "COMPANY_BANK_NO", true));
            this.comboBox_Bank.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMPANY_BANK_NAME", true));
            this.comboBox_Bank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Bank.Enabled = false;
            this.comboBox_Bank.FormattingEnabled = true;
            this.comboBox_Bank.Location = new System.Drawing.Point(71, 59);
            this.comboBox_Bank.Name = "comboBox_Bank";
            this.comboBox_Bank.Size = new System.Drawing.Size(122, 20);
            this.comboBox_Bank.TabIndex = 1117;
            // 
            // textBox_CompID
            // 
            this.textBox_CompID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMP_ID", true));
            this.textBox_CompID.Enabled = false;
            this.textBox_CompID.Location = new System.Drawing.Point(71, 29);
            this.textBox_CompID.Name = "textBox_CompID";
            this.textBox_CompID.Size = new System.Drawing.Size(122, 22);
            this.textBox_CompID.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(221, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "分行代碼";
            // 
            // textBox_BankAc
            // 
            this.textBox_BankAc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMPANY_BANK_AC", true));
            this.textBox_BankAc.Location = new System.Drawing.Point(280, 3);
            this.textBox_BankAc.Name = "textBox_BankAc";
            this.textBox_BankAc.Size = new System.Drawing.Size(122, 22);
            this.textBox_BankAc.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(36, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "銀行";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(221, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "銀行帳戶";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.salaryTransferBankbindingSource, "COMP_HAS_FOOTER", true));
            this.checkBox1.Location = new System.Drawing.Point(483, 91);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 1119;
            this.checkBox1.Text = "轉帳格式包含表尾";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "公司統編";
            // 
            // comboBox_Comp
            // 
            this.comboBox_Comp.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.salaryTransferBankbindingSource, "COMP_NO", true));
            this.comboBox_Comp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salaryTransferBankbindingSource, "COMP_NAME", true));
            this.comboBox_Comp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Comp.FormattingEnabled = true;
            this.comboBox_Comp.Location = new System.Drawing.Point(71, 3);
            this.comboBox_Comp.Name = "comboBox_Comp";
            this.comboBox_Comp.Size = new System.Drawing.Size(122, 20);
            this.comboBox_Comp.TabIndex = 0;
            this.comboBox_Comp.SelectedIndexChanged += new System.EventHandler(this.comboBox_Comp_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(36, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公司";
            // 
            // LABCHECK
            // 
            this.LABCHECK.AutoSize = true;
            this.LABCHECK.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.salaryTransferBankbindingSource, "COMP_HAS_HEADER", true));
            this.LABCHECK.Location = new System.Drawing.Point(280, 91);
            this.LABCHECK.Name = "LABCHECK";
            this.LABCHECK.Size = new System.Drawing.Size(120, 16);
            this.LABCHECK.TabIndex = 1118;
            this.LABCHECK.Text = "轉帳格式包含表頭";
            this.LABCHECK.UseVisualStyleBackColor = true;
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
            this.fullDataCtrl1.DataSource = this.salaryTransferBankbindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(3, 3);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(633, 73);
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // salaryTransferBankbindingSource
            // 
            this.salaryTransferBankbindingSource.DataMember = "SalaryTransferBank";
            this.salaryTransferBankbindingSource.DataSource = this.salaryTransferDataSet;
            // 
            // salaryTransferDataSet
            // 
            this.salaryTransferDataSet.DataSetName = "SalaryTransferDataSet";
            this.salaryTransferDataSet.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryTransferDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salaryTransferBankTableAdapter
            // 
            this.salaryTransferBankTableAdapter.ClearBeforeFill = true;
            // 
            // AUTO
            // 
            this.AUTO.DataPropertyName = "AUTO";
            this.AUTO.HeaderText = "AUTO";
            this.AUTO.Name = "AUTO";
            this.AUTO.ReadOnly = true;
            this.AUTO.Visible = false;
            // 
            // cOMPIDDataGridViewTextBoxColumn
            // 
            this.cOMPIDDataGridViewTextBoxColumn.DataPropertyName = "COMP_ID";
            this.cOMPIDDataGridViewTextBoxColumn.HeaderText = "統一編號";
            this.cOMPIDDataGridViewTextBoxColumn.Name = "cOMPIDDataGridViewTextBoxColumn";
            this.cOMPIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPNODataGridViewTextBoxColumn
            // 
            this.cOMPNODataGridViewTextBoxColumn.DataPropertyName = "COMP_NO";
            this.cOMPNODataGridViewTextBoxColumn.HeaderText = "公司代碼";
            this.cOMPNODataGridViewTextBoxColumn.Name = "cOMPNODataGridViewTextBoxColumn";
            this.cOMPNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPNAMEDataGridViewTextBoxColumn
            // 
            this.cOMPNAMEDataGridViewTextBoxColumn.DataPropertyName = "COMP_NAME";
            this.cOMPNAMEDataGridViewTextBoxColumn.HeaderText = "公司名稱";
            this.cOMPNAMEDataGridViewTextBoxColumn.Name = "cOMPNAMEDataGridViewTextBoxColumn";
            this.cOMPNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPANYBANKACDataGridViewTextBoxColumn
            // 
            this.cOMPANYBANKACDataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BANK_AC";
            this.cOMPANYBANKACDataGridViewTextBoxColumn.HeaderText = "公司轉帳銀行帳戶";
            this.cOMPANYBANKACDataGridViewTextBoxColumn.Name = "cOMPANYBANKACDataGridViewTextBoxColumn";
            this.cOMPANYBANKACDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMPANYBANKACDataGridViewTextBoxColumn.Width = 150;
            // 
            // cOMPANYBANKNODataGridViewTextBoxColumn
            // 
            this.cOMPANYBANKNODataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BANK_NO";
            this.cOMPANYBANKNODataGridViewTextBoxColumn.HeaderText = "銀行代碼";
            this.cOMPANYBANKNODataGridViewTextBoxColumn.Name = "cOMPANYBANKNODataGridViewTextBoxColumn";
            this.cOMPANYBANKNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPANYBANKNAMEDataGridViewTextBoxColumn
            // 
            this.cOMPANYBANKNAMEDataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BANK_NAME";
            this.cOMPANYBANKNAMEDataGridViewTextBoxColumn.HeaderText = "銀行名稱";
            this.cOMPANYBANKNAMEDataGridViewTextBoxColumn.Name = "cOMPANYBANKNAMEDataGridViewTextBoxColumn";
            this.cOMPANYBANKNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPANYBANKIDDataGridViewTextBoxColumn
            // 
            this.cOMPANYBANKIDDataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BANK_ID";
            this.cOMPANYBANKIDDataGridViewTextBoxColumn.HeaderText = "銀行代理編號";
            this.cOMPANYBANKIDDataGridViewTextBoxColumn.Name = "cOMPANYBANKIDDataGridViewTextBoxColumn";
            this.cOMPANYBANKIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPANYBANKUSERDataGridViewTextBoxColumn
            // 
            this.cOMPANYBANKUSERDataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BANK_USER";
            this.cOMPANYBANKUSERDataGridViewTextBoxColumn.HeaderText = "使用者";
            this.cOMPANYBANKUSERDataGridViewTextBoxColumn.Name = "cOMPANYBANKUSERDataGridViewTextBoxColumn";
            this.cOMPANYBANKUSERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPANYBRANCHCODEDataGridViewTextBoxColumn
            // 
            this.cOMPANYBRANCHCODEDataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BRANCH_CODE";
            this.cOMPANYBRANCHCODEDataGridViewTextBoxColumn.HeaderText = "分行代碼";
            this.cOMPANYBRANCHCODEDataGridViewTextBoxColumn.Name = "cOMPANYBRANCHCODEDataGridViewTextBoxColumn";
            this.cOMPANYBRANCHCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPANYBANKLENGTHDataGridViewTextBoxColumn
            // 
            this.cOMPANYBANKLENGTHDataGridViewTextBoxColumn.DataPropertyName = "COMPANY_BANK_LENGTH";
            this.cOMPANYBANKLENGTHDataGridViewTextBoxColumn.HeaderText = "帳戶長度";
            this.cOMPANYBANKLENGTHDataGridViewTextBoxColumn.Name = "cOMPANYBANKLENGTHDataGridViewTextBoxColumn";
            this.cOMPANYBANKLENGTHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOMPHASHEADERDataGridViewCheckBoxColumn
            // 
            this.cOMPHASHEADERDataGridViewCheckBoxColumn.DataPropertyName = "COMP_HAS_HEADER";
            this.cOMPHASHEADERDataGridViewCheckBoxColumn.HeaderText = "表頭";
            this.cOMPHASHEADERDataGridViewCheckBoxColumn.Name = "cOMPHASHEADERDataGridViewCheckBoxColumn";
            this.cOMPHASHEADERDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // cOMPHASFOOTERDataGridViewCheckBoxColumn
            // 
            this.cOMPHASFOOTERDataGridViewCheckBoxColumn.DataPropertyName = "COMP_HAS_FOOTER";
            this.cOMPHASFOOTERDataGridViewCheckBoxColumn.HeaderText = "表尾";
            this.cOMPHASFOOTERDataGridViewCheckBoxColumn.Name = "cOMPHASFOOTERDataGridViewCheckBoxColumn";
            this.cOMPHASFOOTERDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // cOMPDATETYPEDataGridViewTextBoxColumn
            // 
            this.cOMPDATETYPEDataGridViewTextBoxColumn.DataPropertyName = "COMP_DATE_TYPE";
            this.cOMPDATETYPEDataGridViewTextBoxColumn.HeaderText = "日期格式";
            this.cOMPDATETYPEDataGridViewTextBoxColumn.Name = "cOMPDATETYPEDataGridViewTextBoxColumn";
            this.cOMPDATETYPEDataGridViewTextBoxColumn.ReadOnly = true;
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
            // FRM42C
            // 
            this.ClientSize = new System.Drawing.Size(637, 383);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM42C";
            this.Load += new System.EventHandler(this.FRM42C_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryTransferBankbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryTransferDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private System.Windows.Forms.BindingSource salaryTransferBankbindingSource;
        private SalaryTransferDataSet salaryTransferDataSet;
        private SalaryTransferDataSetTableAdapters.SalaryTransferBankTableAdapter salaryTransferBankTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_DateType;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.TextBox textBox_BranchCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_BankID;
        private System.Windows.Forms.TextBox textBox_BankAc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.CheckBox LABCHECK;
        private System.Windows.Forms.ComboBox comboBox_Bank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Comp;
        private System.Windows.Forms.TextBox textBox_CompID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBANKACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBANKNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBANKNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBANKIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBANKUSERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBRANCHCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYBANKLENGTHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cOMPHASHEADERDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cOMPHASFOOTERDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPDATETYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}
