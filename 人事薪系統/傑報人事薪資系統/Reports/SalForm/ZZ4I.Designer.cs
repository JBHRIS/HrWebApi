namespace JBHR.Reports.SalForm
{
    partial class ZZ4I
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
            this.date_b = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.seq_b = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.month_b = new JBControls.TextBox();
            this.year_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.salcode_e = new System.Windows.Forms.ComboBox();
            this.salcode_b = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.main_sort_salcode = new System.Windows.Forms.RadioButton();
            this.main_sort_nobr = new System.Windows.Forms.RadioButton();
            this.main_sort_depts = new System.Windows.Forms.RadioButton();
            this.main_sort_title_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minor_sort_salcode = new System.Windows.Forms.RadioButton();
            this.minor_sort_nobr = new System.Windows.Forms.RadioButton();
            this.minor_sort_depts = new System.Windows.Forms.RadioButton();
            this.minor_sort_title_label = new System.Windows.Forms.Label();
            this.page_check = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 168);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 12;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1078;
            this.label2.Text = "截止日期";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1086;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1085;
            this.label6.Text = "員工編號";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 6);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 2;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 1084;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 6);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 1;
            this.dept_b.ValueMember = "d_no";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1083;
            this.label7.Text = "編制部門";
            // 
            // seq_b
            // 
            this.seq_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_b.CaptionLabel = null;
            this.seq_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_b.DecimalPlace = 2;
            this.seq_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_b.IsEmpty = false;
            this.seq_b.Location = new System.Drawing.Point(203, 139);
            this.seq_b.Mask = "";
            this.seq_b.MaxLength = -1;
            this.seq_b.Name = "seq_b";
            this.seq_b.PasswordChar = '\0';
            this.seq_b.ReadOnly = false;
            this.seq_b.ShowCalendarButton = true;
            this.seq_b.Size = new System.Drawing.Size(20, 23);
            this.seq_b.TabIndex = 11;
            this.seq_b.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(167, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1091;
            this.label1.Text = "期別";
            // 
            // month_b
            // 
            this.month_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_b.CaptionLabel = null;
            this.month_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_b.DecimalPlace = 2;
            this.month_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_b.IsEmpty = false;
            this.month_b.Location = new System.Drawing.Point(136, 139);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.ShowCalendarButton = true;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 10;
            this.month_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_b.Validated += new System.EventHandler(this.month_b_Validated);
            // 
            // year_b
            // 
            this.year_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year_b.CaptionLabel = null;
            this.year_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year_b.DecimalPlace = 2;
            this.year_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year_b.IsEmpty = false;
            this.year_b.Location = new System.Drawing.Point(104, 139);
            this.year_b.Mask = "";
            this.year_b.MaxLength = -1;
            this.year_b.Name = "year_b";
            this.year_b.PasswordChar = '\0';
            this.year_b.ReadOnly = false;
            this.year_b.ShowCalendarButton = true;
            this.year_b.Size = new System.Drawing.Size(30, 23);
            this.year_b.TabIndex = 9;
            this.year_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.year_b.Validated += new System.EventHandler(this.year_b_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 143);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1090;
            this.label29.Text = "發放年月";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 279);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 13;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 308);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 15;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 308);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 14;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "BaseDS";
            this.baseDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nobr_b
            // 
            this.nobr_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.nobr_b.CaptionLabel = null;
            this.nobr_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.nobr_b.DataSource = this.bASEBindingSource;
            this.nobr_b.DisplayMember = "name_c";
            this.nobr_b.IsEmpty = true;
            this.nobr_b.IsEmptyToQuery = true;
            this.nobr_b.IsMustBeFound = true;
            this.nobr_b.LabelText = "";
            this.nobr_b.Location = new System.Drawing.Point(104, 112);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 7;
            this.nobr_b.ValueMember = "nobr";
            this.nobr_b.WhereCmd = "";
            // 
            // nobr_e
            // 
            this.nobr_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.nobr_e.CaptionLabel = null;
            this.nobr_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.nobr_e.DataSource = this.bASEBindingSource;
            this.nobr_e.DisplayMember = "name_c";
            this.nobr_e.IsEmpty = true;
            this.nobr_e.IsEmptyToQuery = true;
            this.nobr_e.IsMustBeFound = true;
            this.nobr_e.LabelText = "";
            this.nobr_e.Location = new System.Drawing.Point(280, 112);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 8;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // salcode_e
            // 
            this.salcode_e.DisplayMember = "sal_name";
            this.salcode_e.FormattingEnabled = true;
            this.salcode_e.Location = new System.Drawing.Point(280, 58);
            this.salcode_e.Name = "salcode_e";
            this.salcode_e.Size = new System.Drawing.Size(130, 20);
            this.salcode_e.TabIndex = 4;
            this.salcode_e.ValueMember = "sal_code";
            // 
            // salcode_b
            // 
            this.salcode_b.DisplayMember = "sal_name";
            this.salcode_b.FormattingEnabled = true;
            this.salcode_b.Location = new System.Drawing.Point(104, 58);
            this.salcode_b.Name = "salcode_b";
            this.salcode_b.Size = new System.Drawing.Size(130, 20);
            this.salcode_b.TabIndex = 3;
            this.salcode_b.ValueMember = "sal_code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(242, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 1095;
            this.label9.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(40, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 1094;
            this.label5.Text = "薪資代碼";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 84);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 6;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(242, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1099;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 84);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 5;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(67, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1098;
            this.label23.Text = "員別";
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.FormattingEnabled = true;
            this.depts_e.Location = new System.Drawing.Point(280, 32);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 1101;
            this.depts_e.ValueMember = "d_no";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(242, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 1103;
            this.label16.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.FormattingEnabled = true;
            this.depts_b.Location = new System.Drawing.Point(104, 32);
            this.depts_b.Name = "depts_b";
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 1100;
            this.depts_b.ValueMember = "d_no";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(40, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1102;
            this.label8.Text = "成本部門";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.main_sort_salcode);
            this.groupBox2.Controls.Add(this.main_sort_nobr);
            this.groupBox2.Controls.Add(this.main_sort_depts);
            this.groupBox2.Location = new System.Drawing.Point(104, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 35);
            this.groupBox2.TabIndex = 1104;
            this.groupBox2.TabStop = false;
            // 
            // main_sort_salcode
            // 
            this.main_sort_salcode.AutoSize = true;
            this.main_sort_salcode.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.main_sort_salcode.Location = new System.Drawing.Point(86, 12);
            this.main_sort_salcode.Name = "main_sort_salcode";
            this.main_sort_salcode.Size = new System.Drawing.Size(81, 17);
            this.main_sort_salcode.TabIndex = 22;
            this.main_sort_salcode.Text = "薪資代碼";
            this.main_sort_salcode.UseVisualStyleBackColor = true;
            this.main_sort_salcode.CheckedChanged += new System.EventHandler(this.main_sort_salcode_CheckedChanged);
            // 
            // main_sort_nobr
            // 
            this.main_sort_nobr.AutoSize = true;
            this.main_sort_nobr.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.main_sort_nobr.Location = new System.Drawing.Point(168, 12);
            this.main_sort_nobr.Name = "main_sort_nobr";
            this.main_sort_nobr.Size = new System.Drawing.Size(81, 17);
            this.main_sort_nobr.TabIndex = 23;
            this.main_sort_nobr.Text = "員工編號";
            this.main_sort_nobr.UseVisualStyleBackColor = true;
            this.main_sort_nobr.CheckedChanged += new System.EventHandler(this.main_sort_nobr_CheckedChanged);
            // 
            // main_sort_depts
            // 
            this.main_sort_depts.AutoSize = true;
            this.main_sort_depts.Checked = true;
            this.main_sort_depts.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.main_sort_depts.Location = new System.Drawing.Point(6, 12);
            this.main_sort_depts.Name = "main_sort_depts";
            this.main_sort_depts.Size = new System.Drawing.Size(81, 17);
            this.main_sort_depts.TabIndex = 20;
            this.main_sort_depts.TabStop = true;
            this.main_sort_depts.Text = "成本部門";
            this.main_sort_depts.UseVisualStyleBackColor = true;
            this.main_sort_depts.CheckedChanged += new System.EventHandler(this.main_sort_depts_CheckedChanged);
            // 
            // main_sort_title_label
            // 
            this.main_sort_title_label.AutoSize = true;
            this.main_sort_title_label.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.main_sort_title_label.Location = new System.Drawing.Point(25, 208);
            this.main_sort_title_label.Name = "main_sort_title_label";
            this.main_sort_title_label.Size = new System.Drawing.Size(77, 13);
            this.main_sort_title_label.TabIndex = 1105;
            this.main_sort_title_label.Text = "主要排序項";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minor_sort_salcode);
            this.groupBox1.Controls.Add(this.minor_sort_nobr);
            this.groupBox1.Controls.Add(this.minor_sort_depts);
            this.groupBox1.Location = new System.Drawing.Point(104, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 35);
            this.groupBox1.TabIndex = 1106;
            this.groupBox1.TabStop = false;
            // 
            // minor_sort_salcode
            // 
            this.minor_sort_salcode.AutoSize = true;
            this.minor_sort_salcode.Checked = true;
            this.minor_sort_salcode.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.minor_sort_salcode.Location = new System.Drawing.Point(86, 12);
            this.minor_sort_salcode.Name = "minor_sort_salcode";
            this.minor_sort_salcode.Size = new System.Drawing.Size(81, 17);
            this.minor_sort_salcode.TabIndex = 22;
            this.minor_sort_salcode.TabStop = true;
            this.minor_sort_salcode.Text = "薪資代碼";
            this.minor_sort_salcode.UseVisualStyleBackColor = true;
            // 
            // minor_sort_nobr
            // 
            this.minor_sort_nobr.AutoSize = true;
            this.minor_sort_nobr.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.minor_sort_nobr.Location = new System.Drawing.Point(168, 12);
            this.minor_sort_nobr.Name = "minor_sort_nobr";
            this.minor_sort_nobr.Size = new System.Drawing.Size(81, 17);
            this.minor_sort_nobr.TabIndex = 23;
            this.minor_sort_nobr.Text = "員工編號";
            this.minor_sort_nobr.UseVisualStyleBackColor = true;
            // 
            // minor_sort_depts
            // 
            this.minor_sort_depts.AutoSize = true;
            this.minor_sort_depts.Enabled = false;
            this.minor_sort_depts.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.minor_sort_depts.Location = new System.Drawing.Point(6, 12);
            this.minor_sort_depts.Name = "minor_sort_depts";
            this.minor_sort_depts.Size = new System.Drawing.Size(81, 17);
            this.minor_sort_depts.TabIndex = 20;
            this.minor_sort_depts.Text = "成本部門";
            this.minor_sort_depts.UseVisualStyleBackColor = true;
            // 
            // minor_sort_title_label
            // 
            this.minor_sort_title_label.AutoSize = true;
            this.minor_sort_title_label.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.minor_sort_title_label.Location = new System.Drawing.Point(25, 243);
            this.minor_sort_title_label.Name = "minor_sort_title_label";
            this.minor_sort_title_label.Size = new System.Drawing.Size(77, 13);
            this.minor_sort_title_label.TabIndex = 1107;
            this.minor_sort_title_label.Text = "次要排序項";
            // 
            // page_check
            // 
            this.page_check.AutoSize = true;
            this.page_check.Location = new System.Drawing.Point(245, 279);
            this.page_check.Name = "page_check";
            this.page_check.Size = new System.Drawing.Size(108, 16);
            this.page_check.TabIndex = 1203;
            this.page_check.Text = "產出報表不分頁";
            this.page_check.UseVisualStyleBackColor = true;
            // 
            // ZZ4I
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 350);
            this.Controls.Add(this.page_check);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.minor_sort_title_label);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.main_sort_title_label);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.salcode_e);
            this.Controls.Add(this.salcode_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.seq_b);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.year_b);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label2);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ4I";
            this.Text = "補扣發明細表";
            this.Load += new System.EventHandler(this.ZZ4I_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        internal JBControls.TextBox seq_b;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox month_b;
        internal JBControls.TextBox year_b;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal System.Windows.Forms.ComboBox salcode_e;
        internal System.Windows.Forms.ComboBox salcode_b;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox depts_b;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton main_sort_salcode;
        internal System.Windows.Forms.RadioButton main_sort_nobr;
        internal System.Windows.Forms.RadioButton main_sort_depts;
        private System.Windows.Forms.Label main_sort_title_label;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton minor_sort_salcode;
        internal System.Windows.Forms.RadioButton minor_sort_nobr;
        internal System.Windows.Forms.RadioButton minor_sort_depts;
        private System.Windows.Forms.Label minor_sort_title_label;
        internal System.Windows.Forms.CheckBox page_check;
    }
}