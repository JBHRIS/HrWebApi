namespace JBHR.Att
{
    partial class FRM210
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
            this.dgv = new JBControls.DataGridView();
            this.hTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tYPENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoCreateHoursDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mergeDisplayDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.hCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.ExtendCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ExpireCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KEY_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KEY_MAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hcodeTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox3 = new JBControls.CheckBox();
            this.textBox6 = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new JBControls.CheckBox();
            this.textBox4 = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxExtend = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxExpire = new System.Windows.Forms.ComboBox();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.bsUNIT = new System.Windows.Forms.BindingSource(this.components);
            this.taUNIT = new JBHR.Att.dsViewTableAdapters.UNITTableAdapter();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.hcodeTypeTableAdapter = new JBHR.Att.dsAttTableAdapters.HcodeTypeTableAdapter();
            this.hCODETableAdapter = new JBHR.Att.dsAttTableAdapters.HCODETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hcodeTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUNIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 560);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
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
            this.hTYPEDataGridViewTextBoxColumn,
            this.tYPENAMEDataGridViewTextBoxColumn,
            this.sortDataGridViewTextBoxColumn,
            this.yearMaxDataGridViewTextBoxColumn,
            this.autoCreateHoursDataGridViewCheckBoxColumn,
            this.mergeDisplayDataGridViewCheckBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.GetCode,
            this.ExtendCode,
            this.ExpireCode,
            this.KEY_DATE,
            this.KEY_MAN});
            this.dgv.DataSource = this.hcodeTypeBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(784, 354);
            this.dgv.TabIndex = 7;
            // 
            // hTYPEDataGridViewTextBoxColumn
            // 
            this.hTYPEDataGridViewTextBoxColumn.DataPropertyName = "HTYPE_DISP";
            this.hTYPEDataGridViewTextBoxColumn.HeaderText = "請假類別";
            this.hTYPEDataGridViewTextBoxColumn.Name = "hTYPEDataGridViewTextBoxColumn";
            this.hTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.hTYPEDataGridViewTextBoxColumn.Width = 78;
            // 
            // tYPENAMEDataGridViewTextBoxColumn
            // 
            this.tYPENAMEDataGridViewTextBoxColumn.DataPropertyName = "TYPE_NAME";
            this.tYPENAMEDataGridViewTextBoxColumn.HeaderText = "請假類別名稱";
            this.tYPENAMEDataGridViewTextBoxColumn.Name = "tYPENAMEDataGridViewTextBoxColumn";
            this.tYPENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tYPENAMEDataGridViewTextBoxColumn.Width = 102;
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "排序";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            this.sortDataGridViewTextBoxColumn.ReadOnly = true;
            this.sortDataGridViewTextBoxColumn.Width = 54;
            // 
            // yearMaxDataGridViewTextBoxColumn
            // 
            this.yearMaxDataGridViewTextBoxColumn.DataPropertyName = "YearMax";
            this.yearMaxDataGridViewTextBoxColumn.HeaderText = "年休最大數";
            this.yearMaxDataGridViewTextBoxColumn.Name = "yearMaxDataGridViewTextBoxColumn";
            this.yearMaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearMaxDataGridViewTextBoxColumn.Width = 90;
            // 
            // autoCreateHoursDataGridViewCheckBoxColumn
            // 
            this.autoCreateHoursDataGridViewCheckBoxColumn.DataPropertyName = "AutoCreateHours";
            this.autoCreateHoursDataGridViewCheckBoxColumn.HeaderText = "自動產生時數";
            this.autoCreateHoursDataGridViewCheckBoxColumn.Name = "autoCreateHoursDataGridViewCheckBoxColumn";
            this.autoCreateHoursDataGridViewCheckBoxColumn.ReadOnly = true;
            this.autoCreateHoursDataGridViewCheckBoxColumn.Width = 83;
            // 
            // mergeDisplayDataGridViewCheckBoxColumn
            // 
            this.mergeDisplayDataGridViewCheckBoxColumn.DataPropertyName = "MergeDisplay";
            this.mergeDisplayDataGridViewCheckBoxColumn.HeaderText = "合併顯示";
            this.mergeDisplayDataGridViewCheckBoxColumn.Name = "mergeDisplayDataGridViewCheckBoxColumn";
            this.mergeDisplayDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mergeDisplayDataGridViewCheckBoxColumn.Width = 59;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "單位";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitDataGridViewTextBoxColumn.Width = 54;
            // 
            // GetCode
            // 
            this.GetCode.DataPropertyName = "GetCode";
            this.GetCode.DataSource = this.hCODEBindingSource;
            this.GetCode.DisplayMember = "H_CODE_DISP";
            this.GetCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.GetCode.HeaderText = "預設得假代碼";
            this.GetCode.Name = "GetCode";
            this.GetCode.ReadOnly = true;
            this.GetCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GetCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GetCode.ValueMember = "H_CODE";
            this.GetCode.Width = 102;
            // 
            // hCODEBindingSource
            // 
            this.hCODEBindingSource.DataMember = "HCODE";
            this.hCODEBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ExtendCode
            // 
            this.ExtendCode.DataPropertyName = "ExtendCode";
            this.ExtendCode.DataSource = this.hCODEBindingSource;
            this.ExtendCode.DisplayMember = "H_CODE_DISP";
            this.ExtendCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ExtendCode.HeaderText = "延休代碼";
            this.ExtendCode.Name = "ExtendCode";
            this.ExtendCode.ReadOnly = true;
            this.ExtendCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtendCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExtendCode.ValueMember = "H_CODE";
            this.ExtendCode.Width = 78;
            // 
            // ExpireCode
            // 
            this.ExpireCode.DataPropertyName = "ExpireCode";
            this.ExpireCode.DataSource = this.hCODEBindingSource;
            this.ExpireCode.DisplayMember = "H_CODE_DISP";
            this.ExpireCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ExpireCode.HeaderText = "失效代碼";
            this.ExpireCode.Name = "ExpireCode";
            this.ExpireCode.ReadOnly = true;
            this.ExpireCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpireCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExpireCode.ValueMember = "H_CODE";
            this.ExpireCode.Width = 78;
            // 
            // KEY_DATE
            // 
            this.KEY_DATE.DataPropertyName = "KEY_DATE";
            this.KEY_DATE.HeaderText = "登錄日期";
            this.KEY_DATE.Name = "KEY_DATE";
            this.KEY_DATE.ReadOnly = true;
            this.KEY_DATE.Width = 78;
            // 
            // KEY_MAN
            // 
            this.KEY_MAN.DataPropertyName = "KEY_MAN";
            this.KEY_MAN.HeaderText = "登錄者";
            this.KEY_MAN.Name = "KEY_MAN";
            this.KEY_MAN.ReadOnly = true;
            this.KEY_MAN.Width = 66;
            // 
            // hcodeTypeBindingSource
            // 
            this.hcodeTypeBindingSource.DataMember = "HcodeType";
            this.hcodeTypeBindingSource.DataSource = this.dsAtt;
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
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(784, 202);
            this.splitContainer2.SplitterDistance = 121;
            this.splitContainer2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(369, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "預設失效";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.checkBox3, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxExtend, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxExpire, 5, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 115);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox3.AutoSize = true;
            this.checkBox3.CaptionLabel = null;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.hcodeTypeBindingSource, "AutoCreateHours", true));
            this.checkBox3.IsImitateCaption = true;
            this.checkBox3.Location = new System.Drawing.Point(369, 62);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(96, 16);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "自動產生時數";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label9;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hcodeTypeBindingSource, "YearMax", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = true;
            this.textBox6.Location = new System.Drawing.Point(263, 59);
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = 10;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(60, 22);
            this.textBox6.TabIndex = 5;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(192, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "年休最大數";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.hcodeTypeBindingSource, "MergeDisplay", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(369, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "合併顯示";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label10;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hcodeTypeBindingSource, "Sort", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(263, 31);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = -1;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(60, 22);
            this.textBox4.TabIndex = 4;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(228, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "排序";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hcodeTypeBindingSource, "TYPE_NAME", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            this.textBox3.Location = new System.Drawing.Point(86, 31);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "請假類別名稱";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "請假類別代碼";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = null;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hcodeTypeBindingSource, "HTYPE_DISP", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(86, 3);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hcodeTypeBindingSource, "Unit", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(51, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "單位";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hcodeTypeBindingSource, "GetCode", true));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(86, 89);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 20);
            this.comboBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "預設得假";
            // 
            // comboBoxExtend
            // 
            this.comboBoxExtend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxExtend.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hcodeTypeBindingSource, "ExtendCode", true));
            this.comboBoxExtend.FormattingEnabled = true;
            this.comboBoxExtend.Location = new System.Drawing.Point(263, 89);
            this.comboBoxExtend.Name = "comboBoxExtend";
            this.comboBoxExtend.Size = new System.Drawing.Size(100, 20);
            this.comboBoxExtend.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(204, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "預設延休";
            // 
            // comboBoxExpire
            // 
            this.comboBoxExpire.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxExpire.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.hcodeTypeBindingSource, "ExpireCode", true));
            this.comboBoxExpire.FormattingEnabled = true;
            this.comboBoxExpire.Location = new System.Drawing.Point(471, 89);
            this.comboBoxExpire.Name = "comboBoxExpire";
            this.comboBoxExpire.Size = new System.Drawing.Size(100, 20);
            this.comboBoxExpire.TabIndex = 10;
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(638, 6);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 3;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
            // 
            // fdc
            // 
            this.fdc.AllowModifyPrimaryKey = false;
            this.fdc.BindingCtrlsAutoInit = true;
            this.fdc.bnAddEnable = true;
            this.fdc.bnAddVisible = true;
            this.fdc.bnCancelEnable = true;
            this.fdc.bnCancelVisible = true;
            this.fdc.bnDelEnable = true;
            this.fdc.bnDelVisible = true;
            this.fdc.bnEditEnable = true;
            this.fdc.bnEditVisible = true;
            this.fdc.bnExportEnable = true;
            this.fdc.bnExportVisible = true;
            this.fdc.bnQueryEnable = true;
            this.fdc.bnQueryVisible = true;
            this.fdc.bnSaveEnable = true;
            this.fdc.bnSaveVisible = true;
            this.fdc.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fdc.DataAdapter = null;
            this.fdc.DataGrid = this.dgv;
            this.fdc.DataSource = this.hcodeTypeBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(0, 3);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "type_name,htype_disp";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 73);
            this.fdc.SortFields = "type_name,htype_disp";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterEdit);
            this.fdc.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeDel);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // taUNIT
            // 
            this.taUNIT.ClearBeforeFill = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // hcodeTypeTableAdapter
            // 
            this.hcodeTypeTableAdapter.ClearBeforeFill = true;
            // 
            // hCODETableAdapter
            // 
            this.hCODETableAdapter.ClearBeforeFill = true;
            // 
            // FRM210
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "FRM210";
            this.Tag = "Att.FRM210";
            this.Text = "FRM210";
            this.Load += new System.EventHandler(this.FRM211_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hcodeTypeBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUNIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.FullDataCtrl fdc;
        private dsAtt dsAtt;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource bsUNIT;
        private JBHR.Att.dsViewTableAdapters.UNITTableAdapter taUNIT;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private JBControls.CheckBox checkBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hCODEDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource hcodeTypeBindingSource;
        private dsAttTableAdapters.HcodeTypeTableAdapter hcodeTypeTableAdapter;
        private JBControls.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxExpire;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxExtend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource hCODEBindingSource;
        private dsAttTableAdapters.HCODETableAdapter hCODETableAdapter;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tYPENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autoCreateHoursDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mergeDisplayDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn GetCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn ExtendCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn ExpireCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn KEY_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn KEY_MAN;
    }
}