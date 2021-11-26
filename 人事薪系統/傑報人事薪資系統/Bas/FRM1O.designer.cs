namespace JBHR.Bas
{
    partial class FRM1O
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.nobrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkAdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkAdrName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.wORKCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.AlertDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnIMPORT = new System.Windows.Forms.Button();
            this.cbWORKCD = new System.Windows.Forms.ComboBox();
            this.cbContractType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.txtDDate = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlertDate = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAlertDay = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdate = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.contractTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.contractTableAdapter = new JBHR.Bas.BasDSTableAdapters.ContractTableAdapter();
            this.wORKCDTableAdapter = new JBHR.Bas.BasDSTableAdapters.WORKCDTableAdapter();
            this.contractTypeTableAdapter = new JBHR.Bas.BasDSTableAdapters.ContractTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractTypeBindingSource)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nobrDataGridViewTextBoxColumn,
            this.contractTypeDataGridViewTextBoxColumn,
            this.adateDataGridViewTextBoxColumn,
            this.ddateDataGridViewTextBoxColumn,
            this.WorkAdr,
            this.WorkAdrName,
            this.AlertDay,
            this.keyDateDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.contractBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowHeadersWidth = 62;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 250);
            this.dataGridViewEx1.TabIndex = 7;
            this.dataGridViewEx1.SelectionChanged += new System.EventHandler(this.dataGridViewEx1_SelectionChanged);
            // 
            // nobrDataGridViewTextBoxColumn
            // 
            this.nobrDataGridViewTextBoxColumn.DataPropertyName = "Nobr";
            this.nobrDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nobrDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nobrDataGridViewTextBoxColumn.Name = "nobrDataGridViewTextBoxColumn";
            this.nobrDataGridViewTextBoxColumn.ReadOnly = true;
            this.nobrDataGridViewTextBoxColumn.Width = 78;
            // 
            // contractTypeDataGridViewTextBoxColumn
            // 
            this.contractTypeDataGridViewTextBoxColumn.DataPropertyName = "ContractType";
            this.contractTypeDataGridViewTextBoxColumn.HeaderText = "合同種類";
            this.contractTypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.contractTypeDataGridViewTextBoxColumn.Name = "contractTypeDataGridViewTextBoxColumn";
            this.contractTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.contractTypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // adateDataGridViewTextBoxColumn
            // 
            this.adateDataGridViewTextBoxColumn.DataPropertyName = "Adate";
            this.adateDataGridViewTextBoxColumn.HeaderText = "起始日期";
            this.adateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.adateDataGridViewTextBoxColumn.Name = "adateDataGridViewTextBoxColumn";
            this.adateDataGridViewTextBoxColumn.ReadOnly = true;
            this.adateDataGridViewTextBoxColumn.Width = 78;
            // 
            // ddateDataGridViewTextBoxColumn
            // 
            this.ddateDataGridViewTextBoxColumn.DataPropertyName = "Ddate";
            this.ddateDataGridViewTextBoxColumn.HeaderText = "到期日期";
            this.ddateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.ddateDataGridViewTextBoxColumn.Name = "ddateDataGridViewTextBoxColumn";
            this.ddateDataGridViewTextBoxColumn.ReadOnly = true;
            this.ddateDataGridViewTextBoxColumn.Width = 78;
            // 
            // WorkAdr
            // 
            this.WorkAdr.DataPropertyName = "WorkAdr";
            this.WorkAdr.HeaderText = "派駐區";
            this.WorkAdr.MinimumWidth = 8;
            this.WorkAdr.Name = "WorkAdr";
            this.WorkAdr.ReadOnly = true;
            this.WorkAdr.Width = 66;
            // 
            // WorkAdrName
            // 
            this.WorkAdrName.DataPropertyName = "WorkAdr";
            this.WorkAdrName.DataSource = this.wORKCDBindingSource;
            this.WorkAdrName.DisplayMember = "WORK_ADDR";
            this.WorkAdrName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.WorkAdrName.HeaderText = "派駐區名稱";
            this.WorkAdrName.MinimumWidth = 8;
            this.WorkAdrName.Name = "WorkAdrName";
            this.WorkAdrName.ReadOnly = true;
            this.WorkAdrName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WorkAdrName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WorkAdrName.ValueMember = "WORK_CODE";
            this.WorkAdrName.Width = 90;
            // 
            // wORKCDBindingSource
            // 
            this.wORKCDBindingSource.DataMember = "WORKCD";
            this.wORKCDBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AlertDay
            // 
            this.AlertDay.DataPropertyName = "AlertDay";
            this.AlertDay.HeaderText = "預先通知天數";
            this.AlertDay.MinimumWidth = 8;
            this.AlertDay.Name = "AlertDay";
            this.AlertDay.ReadOnly = true;
            this.AlertDay.Width = 102;
            // 
            // keyDateDataGridViewTextBoxColumn
            // 
            this.keyDateDataGridViewTextBoxColumn.DataPropertyName = "KeyDate";
            this.keyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.keyDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.keyDateDataGridViewTextBoxColumn.Name = "keyDateDataGridViewTextBoxColumn";
            this.keyDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDateDataGridViewTextBoxColumn.Width = 78;
            // 
            // keyManDataGridViewTextBoxColumn
            // 
            this.keyManDataGridViewTextBoxColumn.DataPropertyName = "KeyMan";
            this.keyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.keyManDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.keyManDataGridViewTextBoxColumn.Name = "keyManDataGridViewTextBoxColumn";
            this.keyManDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyManDataGridViewTextBoxColumn.Width = 66;
            // 
            // contractBindingSource
            // 
            this.contractBindingSource.DataMember = "Contract";
            this.contractBindingSource.DataSource = this.basDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 187);
            this.splitContainer2.SplitterDistance = 107;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bnIMPORT);
            this.panel1.Controls.Add(this.cbWORKCD);
            this.panel1.Controls.Add(this.cbContractType);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ptxNobr);
            this.panel1.Controls.Add(this.txtDDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAlertDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtAlertDay);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAdate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 107);
            this.panel1.TabIndex = 0;
            // 
            // bnIMPORT
            // 
            this.bnIMPORT.Location = new System.Drawing.Point(547, 78);
            this.bnIMPORT.Name = "bnIMPORT";
            this.bnIMPORT.Size = new System.Drawing.Size(75, 23);
            this.bnIMPORT.TabIndex = 12;
            this.bnIMPORT.TabStop = false;
            this.bnIMPORT.Text = "匯入";
            this.bnIMPORT.UseVisualStyleBackColor = true;
            this.bnIMPORT.Click += new System.EventHandler(this.bnIMPORT_Click);
            // 
            // cbWORKCD
            // 
            this.cbWORKCD.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contractBindingSource, "WorkAdr", true));
            this.cbWORKCD.FormattingEnabled = true;
            this.cbWORKCD.Location = new System.Drawing.Point(342, 5);
            this.cbWORKCD.Name = "cbWORKCD";
            this.cbWORKCD.Size = new System.Drawing.Size(121, 20);
            this.cbWORKCD.TabIndex = 4;
            // 
            // cbContractType
            // 
            this.cbContractType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contractBindingSource, "ContractType", true));
            this.cbContractType.FormattingEnabled = true;
            this.cbContractType.Location = new System.Drawing.Point(83, 30);
            this.cbContractType.Name = "cbContractType";
            this.cbContractType.Size = new System.Drawing.Size(121, 20);
            this.cbContractType.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 60;
            this.button1.TabStop = false;
            this.button1.Tag = "Contract";
            this.button1.Text = "設定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(295, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "派駐區";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label2;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contractBindingSource, "Nobr", true));
            this.ptxNobr.DataSource = this.vBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(83, 4);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.QueryFields = "name_e,name_p";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(92, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "員工編號";
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
            // txtDDate
            // 
            this.txtDDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDDate.CaptionLabel = this.label4;
            this.txtDDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contractBindingSource, "Ddate", true));
            this.txtDDate.DecimalPlace = 2;
            this.txtDDate.IsEmpty = false;
            this.txtDDate.Location = new System.Drawing.Point(83, 78);
            this.txtDDate.Mask = "0000/00/00";
            this.txtDDate.MaxLength = -1;
            this.txtDDate.Name = "txtDDate";
            this.txtDDate.PasswordChar = '\0';
            this.txtDDate.ReadOnly = false;
            this.txtDDate.ShowCalendarButton = true;
            this.txtDDate.Size = new System.Drawing.Size(68, 22);
            this.txtDDate.TabIndex = 3;
            this.txtDDate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtDDate.TextChanged += new System.EventHandler(this.txtDDate_TextChanged);
            this.txtDDate.Validated += new System.EventHandler(this.txtDDate_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(24, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "到期日期";
            // 
            // txtAlertDate
            // 
            this.txtAlertDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAlertDate.CaptionLabel = this.label7;
            this.txtAlertDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAlertDate.DecimalPlace = 2;
            this.txtAlertDate.Enabled = false;
            this.txtAlertDate.IsEmpty = true;
            this.txtAlertDate.Location = new System.Drawing.Point(342, 54);
            this.txtAlertDate.Mask = "0000/00/00";
            this.txtAlertDate.MaxLength = -1;
            this.txtAlertDate.Name = "txtAlertDate";
            this.txtAlertDate.PasswordChar = '\0';
            this.txtAlertDate.ReadOnly = false;
            this.txtAlertDate.ShowCalendarButton = true;
            this.txtAlertDate.Size = new System.Drawing.Size(68, 22);
            this.txtAlertDate.TabIndex = 6;
            this.txtAlertDate.TabStop = false;
            this.txtAlertDate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtAlertDate.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(283, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "提醒日期";
            this.label7.Visible = false;
            // 
            // txtAlertDay
            // 
            this.txtAlertDay.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAlertDay.CaptionLabel = this.label6;
            this.txtAlertDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAlertDay.DecimalPlace = 2;
            this.txtAlertDay.IsEmpty = true;
            this.txtAlertDay.Location = new System.Drawing.Point(342, 29);
            this.txtAlertDay.Mask = "";
            this.txtAlertDay.MaxLength = -1;
            this.txtAlertDay.Name = "txtAlertDay";
            this.txtAlertDay.PasswordChar = '\0';
            this.txtAlertDay.ReadOnly = false;
            this.txtAlertDay.ShowCalendarButton = true;
            this.txtAlertDay.Size = new System.Drawing.Size(68, 22);
            this.txtAlertDay.TabIndex = 5;
            this.txtAlertDay.ValidType = JBControls.TextBox.EValidType.Integer;
            this.txtAlertDay.Visible = false;
            this.txtAlertDay.TextChanged += new System.EventHandler(this.txtAlertDay_TextChanged);
            this.txtAlertDay.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(259, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "預先通知天數";
            this.label6.Visible = false;
            // 
            // txtAdate
            // 
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = this.label3;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contractBindingSource, "Adate", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = false;
            this.txtAdate.Location = new System.Drawing.Point(83, 54);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.Size = new System.Drawing.Size(68, 22);
            this.txtAdate.TabIndex = 2;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtAdate.Validated += new System.EventHandler(this.txtAdate_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(24, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "起始日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "合同種類";
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
            this.fullDataCtrl1.DataSource = this.contractBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.BeforeEdit += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // contractTypeBindingSource
            // 
            this.contractTypeBindingSource.DataMember = "ContractType";
            this.contractTypeBindingSource.DataSource = this.basDS;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // contractTableAdapter
            // 
            this.contractTableAdapter.ClearBeforeFill = true;
            // 
            // wORKCDTableAdapter
            // 
            this.wORKCDTableAdapter.ClearBeforeFill = true;
            // 
            // contractTypeTableAdapter
            // 
            this.contractTypeTableAdapter.ClearBeforeFill = true;
            // 
            // FRM1O
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM1O";
            this.Tag = "";
            this.Text = "FRM1O";
            this.Load += new System.EventHandler(this.FRM11M_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wORKCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dataGridViewEx1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private BasDS basDS;
        private JBControls.TextBox txtAdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private JBControls.TextBox txtDDate;
        private System.Windows.Forms.Label label4;
        private JBControls.PopupTextBox ptxNobr;
        private System.Windows.Forms.BindingSource contractBindingSource;
        private BasDSTableAdapters.ContractTableAdapter contractTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource wORKCDBindingSource;
        private BasDSTableAdapters.WORKCDTableAdapter wORKCDTableAdapter;
        private JBControls.TextBox txtAlertDate;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtAlertDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource contractTypeBindingSource;
        private BasDSTableAdapters.ContractTypeTableAdapter contractTypeTableAdapter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbContractType;
        private System.Windows.Forms.ComboBox cbWORKCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn nobrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkAdr;
        private System.Windows.Forms.DataGridViewComboBoxColumn WorkAdrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bnIMPORT;
    }
}