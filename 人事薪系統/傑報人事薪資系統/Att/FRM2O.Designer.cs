namespace JBHR.Att
{
    partial class FRM2O
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
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bASEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jOBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jOBBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jOBLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jOBLBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rOTEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.rOTEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.jOBTableAdapter = new JBHR.Att.dsBasTableAdapters.JOBTableAdapter();
            this.jOBLTableAdapter = new JBHR.Att.dsBasTableAdapters.JOBLTableAdapter();
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rOTETableAdapter = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxRote = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRote = new JBControls.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.gpbType = new System.Windows.Forms.GroupBox();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYear = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMonth = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDeptB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.txtBday = new JBControls.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEDay = new JBControls.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cbxDeptE = new System.Windows.Forms.ComboBox();
            this.cbxJobB = new System.Windows.Forms.ComboBox();
            this.cbxJobE = new System.Windows.Forms.ComboBox();
            this.cbxJoblB = new System.Windows.Forms.ComboBox();
            this.cbxJoblE = new System.Windows.Forms.ComboBox();
            this.cbxRoteB = new System.Windows.Forms.ComboBox();
            this.cbxRoteE = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBLBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.gpbType.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.dsBas;
            // 
            // bASEBindingSource1
            // 
            this.bASEBindingSource1.DataMember = "BASE";
            this.bASEBindingSource1.DataSource = this.dsBas;
            // 
            // jOBBindingSource
            // 
            this.jOBBindingSource.DataMember = "JOB";
            this.jOBBindingSource.DataSource = this.dsBas;
            // 
            // jOBBindingSource1
            // 
            this.jOBBindingSource1.DataMember = "JOB";
            this.jOBBindingSource1.DataSource = this.dsBas;
            // 
            // jOBLBindingSource
            // 
            this.jOBLBindingSource.DataMember = "JOBL";
            this.jOBLBindingSource.DataSource = this.dsBas;
            // 
            // jOBLBindingSource1
            // 
            this.jOBLBindingSource1.DataMember = "JOBL";
            this.jOBLBindingSource1.DataSource = this.dsBas;
            // 
            // rOTEBindingSource1
            // 
            this.rOTEBindingSource1.DataMember = "ROTE";
            this.rOTEBindingSource1.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rOTEBindingSource2
            // 
            this.rOTEBindingSource2.DataMember = "ROTE";
            this.rOTEBindingSource2.DataSource = this.dsAtt;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // jOBTableAdapter
            // 
            this.jOBTableAdapter.ClearBeforeFill = true;
            // 
            // jOBLTableAdapter
            // 
            this.jOBLTableAdapter.ClearBeforeFill = true;
            // 
            // rOTEBindingSource
            // 
            this.rOTEBindingSource.DataMember = "ROTE";
            this.rOTEBindingSource.DataSource = this.dsAtt;
            // 
            // rOTETableAdapter
            // 
            this.rOTETableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbxRote);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtRote);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.gpbType);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 369);
            this.panel1.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 32;
            // 
            // cbxRote
            // 
            this.cbxRote.DataSource = this.rOTEBindingSource;
            this.cbxRote.DisplayMember = "ROTENAME";
            this.cbxRote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRote.FormattingEnabled = true;
            this.cbxRote.Location = new System.Drawing.Point(142, 271);
            this.cbxRote.Name = "cbxRote";
            this.cbxRote.Size = new System.Drawing.Size(91, 20);
            this.cbxRote.TabIndex = 0;
            this.cbxRote.ValueMember = "ROTE";
            this.cbxRote.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(36, 303);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "等於某日期的班別";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(71, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 30;
            this.label17.Text = "變更成班別";
            // 
            // txtRote
            // 
            this.txtRote.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRote.CaptionLabel = null;
            this.txtRote.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRote.DecimalPlace = 2;
            this.txtRote.IsEmpty = true;
            this.txtRote.Location = new System.Drawing.Point(144, 297);
            this.txtRote.Mask = "";
            this.txtRote.MaxLength = -1;
            this.txtRote.Name = "txtRote";
            this.txtRote.PasswordChar = '\0';
            this.txtRote.ReadOnly = false;
            this.txtRote.ShowCalendarButton = true;
            this.txtRote.Size = new System.Drawing.Size(40, 22);
            this.txtRote.TabIndex = 1;
            this.txtRote.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(83, 250);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "更新類別";
            // 
            // gpbType
            // 
            this.gpbType.Controls.Add(this.rdb2);
            this.gpbType.Controls.Add(this.rdb1);
            this.gpbType.Location = new System.Drawing.Point(142, 236);
            this.gpbType.Name = "gpbType";
            this.gpbType.Size = new System.Drawing.Size(193, 32);
            this.gpbType.TabIndex = 14;
            this.gpbType.TabStop = false;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(76, 10);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(71, 16);
            this.rdb2.TabIndex = 1;
            this.rdb2.Text = "等於日期";
            this.rdb2.UseVisualStyleBackColor = true;
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Location = new System.Drawing.Point(6, 10);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(71, 16);
            this.rdb1.TabIndex = 0;
            this.rdb1.Text = "置換班別";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(242, 333);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(134, 333);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "產生";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtYear, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtMonth, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(57, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(316, 28);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "班表年月";
            // 
            // txtYear
            // 
            this.txtYear.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYear.CaptionLabel = null;
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYear.DecimalPlace = 2;
            this.txtYear.IsEmpty = true;
            this.txtYear.Location = new System.Drawing.Point(62, 3);
            this.txtYear.Mask = "";
            this.txtYear.MaxLength = -1;
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.ReadOnly = false;
            this.txtYear.ShowCalendarButton = true;
            this.txtYear.Size = new System.Drawing.Size(40, 22);
            this.txtYear.TabIndex = 0;
            this.txtYear.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "年";
            // 
            // txtMonth
            // 
            this.txtMonth.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMonth.CaptionLabel = null;
            this.txtMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMonth.DecimalPlace = 2;
            this.txtMonth.IsEmpty = true;
            this.txtMonth.Location = new System.Drawing.Point(131, 3);
            this.txtMonth.Mask = "00";
            this.txtMonth.MaxLength = -1;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.PasswordChar = '\0';
            this.txtMonth.ReadOnly = false;
            this.txtMonth.ShowCalendarButton = true;
            this.txtMonth.Size = new System.Drawing.Size(40, 22);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "月";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxDeptB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBday, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEDay, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label20, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxDeptE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxJobB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxJobE, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxJoblB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxJoblE, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxRoteB, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxRoteE, 3, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(57, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 174);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起迄日期";
            // 
            // cbxDeptB
            // 
            this.cbxDeptB.DisplayMember = "ROTENAME";
            this.cbxDeptB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeptB.FormattingEnabled = true;
            this.cbxDeptB.Location = new System.Drawing.Point(62, 59);
            this.cbxDeptB.Name = "cbxDeptB";
            this.cbxDeptB.Size = new System.Drawing.Size(124, 20);
            this.cbxDeptB.TabIndex = 4;
            this.cbxDeptB.ValueMember = "ROTE";
            this.cbxDeptB.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "部門代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工編號";
            // 
            // ptxNobrB
            // 
            this.ptxNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrB.CaptionLabel = null;
            this.ptxNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrB.DataSource = this.bASEBindingSource;
            this.ptxNobrB.DisplayMember = "name_c";
            this.ptxNobrB.IsEmpty = true;
            this.ptxNobrB.IsEmptyToQuery = true;
            this.ptxNobrB.IsMustBeFound = true;
            this.ptxNobrB.LabelText = "";
            this.ptxNobrB.Location = new System.Drawing.Point(62, 31);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(75, 22);
            this.ptxNobrB.TabIndex = 2;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "至";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "至";
            // 
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.bASEBindingSource1;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = true;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(215, 31);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(83, 22);
            this.ptxNobrE.TabIndex = 3;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // txtBday
            // 
            this.txtBday.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBday.CaptionLabel = null;
            this.txtBday.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBday.DecimalPlace = 2;
            this.txtBday.IsEmpty = true;
            this.txtBday.Location = new System.Drawing.Point(62, 3);
            this.txtBday.Mask = "";
            this.txtBday.MaxLength = -1;
            this.txtBday.Name = "txtBday";
            this.txtBday.PasswordChar = '\0';
            this.txtBday.ReadOnly = false;
            this.txtBday.ShowCalendarButton = true;
            this.txtBday.Size = new System.Drawing.Size(40, 22);
            this.txtBday.TabIndex = 0;
            this.txtBday.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "至";
            // 
            // txtEDay
            // 
            this.txtEDay.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEDay.CaptionLabel = null;
            this.txtEDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEDay.DecimalPlace = 2;
            this.txtEDay.IsEmpty = true;
            this.txtEDay.Location = new System.Drawing.Point(215, 3);
            this.txtEDay.Mask = "";
            this.txtEDay.MaxLength = -1;
            this.txtEDay.Name = "txtEDay";
            this.txtEDay.PasswordChar = '\0';
            this.txtEDay.ReadOnly = false;
            this.txtEDay.ShowCalendarButton = true;
            this.txtEDay.Size = new System.Drawing.Size(40, 22);
            this.txtEDay.TabIndex = 1;
            this.txtEDay.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "職稱代碼";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(192, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "至";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "職等代碼";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "至";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 151);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 2;
            this.label19.Text = "班別代碼";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(192, 151);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 5;
            this.label20.Text = "至";
            // 
            // cbxDeptE
            // 
            this.cbxDeptE.DisplayMember = "ROTENAME";
            this.cbxDeptE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeptE.FormattingEnabled = true;
            this.cbxDeptE.Location = new System.Drawing.Point(215, 59);
            this.cbxDeptE.Name = "cbxDeptE";
            this.cbxDeptE.Size = new System.Drawing.Size(124, 20);
            this.cbxDeptE.TabIndex = 5;
            this.cbxDeptE.ValueMember = "ROTE";
            this.cbxDeptE.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // cbxJobB
            // 
            this.cbxJobB.DisplayMember = "ROTENAME";
            this.cbxJobB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJobB.FormattingEnabled = true;
            this.cbxJobB.Location = new System.Drawing.Point(62, 86);
            this.cbxJobB.Name = "cbxJobB";
            this.cbxJobB.Size = new System.Drawing.Size(124, 20);
            this.cbxJobB.TabIndex = 6;
            this.cbxJobB.ValueMember = "ROTE";
            this.cbxJobB.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // cbxJobE
            // 
            this.cbxJobE.DisplayMember = "ROTENAME";
            this.cbxJobE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJobE.FormattingEnabled = true;
            this.cbxJobE.Location = new System.Drawing.Point(215, 86);
            this.cbxJobE.Name = "cbxJobE";
            this.cbxJobE.Size = new System.Drawing.Size(124, 20);
            this.cbxJobE.TabIndex = 7;
            this.cbxJobE.ValueMember = "ROTE";
            this.cbxJobE.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // cbxJoblB
            // 
            this.cbxJoblB.DisplayMember = "ROTENAME";
            this.cbxJoblB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJoblB.FormattingEnabled = true;
            this.cbxJoblB.Location = new System.Drawing.Point(62, 114);
            this.cbxJoblB.Name = "cbxJoblB";
            this.cbxJoblB.Size = new System.Drawing.Size(124, 20);
            this.cbxJoblB.TabIndex = 8;
            this.cbxJoblB.ValueMember = "ROTE";
            this.cbxJoblB.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // cbxJoblE
            // 
            this.cbxJoblE.DisplayMember = "ROTENAME";
            this.cbxJoblE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJoblE.FormattingEnabled = true;
            this.cbxJoblE.Location = new System.Drawing.Point(215, 114);
            this.cbxJoblE.Name = "cbxJoblE";
            this.cbxJoblE.Size = new System.Drawing.Size(124, 20);
            this.cbxJoblE.TabIndex = 9;
            this.cbxJoblE.ValueMember = "ROTE";
            this.cbxJoblE.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // cbxRoteB
            // 
            this.cbxRoteB.DisplayMember = "ROTENAME";
            this.cbxRoteB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoteB.FormattingEnabled = true;
            this.cbxRoteB.Location = new System.Drawing.Point(62, 143);
            this.cbxRoteB.Name = "cbxRoteB";
            this.cbxRoteB.Size = new System.Drawing.Size(124, 20);
            this.cbxRoteB.TabIndex = 10;
            this.cbxRoteB.ValueMember = "ROTE";
            this.cbxRoteB.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // cbxRoteE
            // 
            this.cbxRoteE.DisplayMember = "ROTENAME";
            this.cbxRoteE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoteE.FormattingEnabled = true;
            this.cbxRoteE.Location = new System.Drawing.Point(215, 143);
            this.cbxRoteE.Name = "cbxRoteE";
            this.cbxRoteE.Size = new System.Drawing.Size(124, 20);
            this.cbxRoteE.TabIndex = 11;
            this.cbxRoteE.ValueMember = "ROTE";
            this.cbxRoteE.SelectedIndexChanged += new System.EventHandler(this.cbxRote_SelectedIndexChanged);
            // 
            // FRM2O
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 369);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2O";
            this.Text = "FRM2O";
            this.Load += new System.EventHandler(this.FRM2O_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBLBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpbType.ResumeLayout(false);
            this.gpbType.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Att.dsBasTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private System.Windows.Forms.BindingSource jOBBindingSource;
        private JBHR.Att.dsBasTableAdapters.JOBTableAdapter jOBTableAdapter;
        private System.Windows.Forms.BindingSource jOBBindingSource1;
        private System.Windows.Forms.BindingSource jOBLBindingSource;
        private JBHR.Att.dsBasTableAdapters.JOBLTableAdapter jOBLTableAdapter;
        private System.Windows.Forms.BindingSource jOBLBindingSource1;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource rOTEBindingSource;
        private JBHR.Att.dsAttTableAdapters.ROTETableAdapter rOTETableAdapter;
        private System.Windows.Forms.BindingSource rOTEBindingSource1;
        private System.Windows.Forms.BindingSource rOTEBindingSource2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxRote;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private JBControls.TextBox txtRote;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gpbType;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtYear;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox txtMonth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private JBControls.PopupTextBox ptxNobrB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobrE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private JBControls.TextBox txtBday;
        private JBControls.TextBox txtEDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDeptB;
        private System.Windows.Forms.ComboBox cbxDeptE;
        private System.Windows.Forms.ComboBox cbxJobB;
        private System.Windows.Forms.ComboBox cbxJobE;
        private System.Windows.Forms.ComboBox cbxJoblB;
        private System.Windows.Forms.ComboBox cbxJoblE;
        private System.Windows.Forms.ComboBox cbxRoteB;
        private System.Windows.Forms.ComboBox cbxRoteE;
    }
}