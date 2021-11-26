/* ======================================================================================================
 * 功能名稱：薪資總表
 * 功能代號：ZZ4A
 * 功能路徑：報表列印 > 薪資 > 薪資總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4A.Designer.cs
 * 功能用途：
 *  用於產出薪資總表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/13    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：公司
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/01/13
 */

namespace JBHR.Reports.SalForm
{
    partial class ZZ4A
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
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dept_type2 = new System.Windows.Forms.RadioButton();
            this.dept_type1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.date_b = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.seq = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.month = new JBControls.TextBox();
            this.year = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.work_e = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.work_b = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.label_company_to = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label_company_title = new System.Windows.Forms.Label();
            this.seqmerge = new JBControls.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "部門彙總",
            "部門彙總(直間接)",
            "部門分攤",
            "部門分攤(個人)",
            "薪資請領表(不分公司別)",
            "公司別合計",
            "財務薪資傳票",
            "人員薪資名冊",
            "會計轉帳格式"});
            this.report_type.Location = new System.Drawing.Point(104, 294);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(150, 20);
            this.report_type.TabIndex = 21;
            this.report_type.SelectedIndexChanged += new System.EventHandler(this.report_type_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(40, 297);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 1034;
            this.label30.Text = "報表種類";
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.FormattingEnabled = true;
            this.depts_e.Location = new System.Drawing.Point(280, 89);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 6;
            this.depts_e.ValueMember = "d_no";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(242, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 1033;
            this.label16.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.FormattingEnabled = true;
            this.depts_b.Location = new System.Drawing.Point(104, 89);
            this.depts_b.Name = "depts_b";
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 5;
            this.depts_b.ValueMember = "d_no";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(40, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1032;
            this.label8.Text = "成本部門";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dept_type2);
            this.groupBox1.Controls.Add(this.dept_type1);
            this.groupBox1.Location = new System.Drawing.Point(104, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 35);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dept_type2
            // 
            this.dept_type2.AutoSize = true;
            this.dept_type2.Location = new System.Drawing.Point(94, 12);
            this.dept_type2.Name = "dept_type2";
            this.dept_type2.Size = new System.Drawing.Size(71, 16);
            this.dept_type2.TabIndex = 2;
            this.dept_type2.Text = "編制部門";
            this.dept_type2.UseVisualStyleBackColor = true;
            this.dept_type2.Click += new System.EventHandler(this.dept_type2_Click);
            // 
            // dept_type1
            // 
            this.dept_type1.AutoSize = true;
            this.dept_type1.Checked = true;
            this.dept_type1.Location = new System.Drawing.Point(5, 12);
            this.dept_type1.Name = "dept_type1";
            this.dept_type1.Size = new System.Drawing.Size(71, 16);
            this.dept_type1.TabIndex = 1;
            this.dept_type1.TabStop = true;
            this.dept_type1.Text = "成本部門";
            this.dept_type1.UseVisualStyleBackColor = true;
            this.dept_type1.Click += new System.EventHandler(this.dept_type1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(40, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1031;
            this.label4.Text = "部門種類";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 35);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 19;
            this.type_data3.Text = "直接";
            this.type_data3.UseVisualStyleBackColor = true;
            // 
            // type_data2
            // 
            this.type_data2.AutoSize = true;
            this.type_data2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data2.Location = new System.Drawing.Point(60, 12);
            this.type_data2.Name = "type_data2";
            this.type_data2.Size = new System.Drawing.Size(53, 17);
            this.type_data2.TabIndex = 18;
            this.type_data2.Text = "間接";
            this.type_data2.UseVisualStyleBackColor = true;
            // 
            // type_data4
            // 
            this.type_data4.AutoSize = true;
            this.type_data4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data4.Location = new System.Drawing.Point(168, 12);
            this.type_data4.Name = "type_data4";
            this.type_data4.Size = new System.Drawing.Size(53, 17);
            this.type_data4.TabIndex = 20;
            this.type_data4.Text = "外勞";
            this.type_data4.UseVisualStyleBackColor = true;
            // 
            // type_data1
            // 
            this.type_data1.AutoSize = true;
            this.type_data1.Checked = true;
            this.type_data1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data1.Location = new System.Drawing.Point(6, 12);
            this.type_data1.Name = "type_data1";
            this.type_data1.Size = new System.Drawing.Size(53, 17);
            this.type_data1.TabIndex = 17;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(40, 263);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 13);
            this.label24.TabIndex = 1030;
            this.label24.Text = "資料內容";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 384);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 23;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 415);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 25;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 415);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 24;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 225);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 16;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(26, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1029;
            this.label1.Text = "異動截止日";
            // 
            // seq
            // 
            this.seq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq.CaptionLabel = null;
            this.seq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq.DecimalPlace = 2;
            this.seq.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq.IsEmpty = false;
            this.seq.Location = new System.Drawing.Point(244, 198);
            this.seq.Mask = "";
            this.seq.MaxLength = -1;
            this.seq.Name = "seq";
            this.seq.PasswordChar = '\0';
            this.seq.ReadOnly = false;
            this.seq.ShowCalendarButton = true;
            this.seq.Size = new System.Drawing.Size(20, 23);
            this.seq.TabIndex = 15;
            this.seq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(208, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1027;
            this.label2.Text = "期別";
            // 
            // month
            // 
            this.month.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month.CaptionLabel = null;
            this.month.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month.DecimalPlace = 2;
            this.month.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month.IsEmpty = false;
            this.month.Location = new System.Drawing.Point(136, 198);
            this.month.Mask = "";
            this.month.MaxLength = -1;
            this.month.Name = "month";
            this.month.PasswordChar = '\0';
            this.month.ReadOnly = false;
            this.month.ShowCalendarButton = true;
            this.month.Size = new System.Drawing.Size(25, 23);
            this.month.TabIndex = 14;
            this.month.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month.Validated += new System.EventHandler(this.month_Validated);
            // 
            // year
            // 
            this.year.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year.CaptionLabel = null;
            this.year.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year.DecimalPlace = 2;
            this.year.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year.IsEmpty = false;
            this.year.Location = new System.Drawing.Point(104, 198);
            this.year.Mask = "";
            this.year.MaxLength = -1;
            this.year.Name = "year";
            this.year.PasswordChar = '\0';
            this.year.ReadOnly = false;
            this.year.ShowCalendarButton = true;
            this.year.Size = new System.Drawing.Size(30, 23);
            this.year.TabIndex = 13;
            this.year.ValidType = JBControls.TextBox.EValidType.Integer;
            this.year.Validated += new System.EventHandler(this.year_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 202);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1026;
            this.label29.Text = "發放年月";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.Enabled = false;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 64);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 1021;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.Enabled = false;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 64);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 3;
            this.dept_b.ValueMember = "d_no";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1020;
            this.label7.Text = "編制部門";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1019;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1018;
            this.label6.Text = "員工編號";
            // 
            // note
            // 
            this.note.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.note.Location = new System.Drawing.Point(104, 321);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.note.Size = new System.Drawing.Size(256, 50);
            this.note.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(40, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 1084;
            this.label5.Text = "報表表頭";
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
            this.nobr_b.Location = new System.Drawing.Point(104, 171);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 11;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 171);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 12;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 115);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 8;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(242, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1088;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 115);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 7;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(68, 119);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1087;
            this.label23.Text = "員別";
            // 
            // work_e
            // 
            this.work_e.DisplayMember = "salname";
            this.work_e.FormattingEnabled = true;
            this.work_e.Location = new System.Drawing.Point(280, 141);
            this.work_e.Name = "work_e";
            this.work_e.Size = new System.Drawing.Size(130, 20);
            this.work_e.TabIndex = 10;
            this.work_e.ValueMember = "saladr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(242, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 1092;
            this.label3.Text = "至";
            // 
            // work_b
            // 
            this.work_b.DisplayMember = "salname";
            this.work_b.FormattingEnabled = true;
            this.work_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.work_b.Location = new System.Drawing.Point(104, 141);
            this.work_b.Name = "work_b";
            this.work_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.work_b.Size = new System.Drawing.Size(130, 20);
            this.work_b.TabIndex = 9;
            this.work_b.ValueMember = "saladr";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(40, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 1091;
            this.label9.Text = "資料群組";
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(435, 415);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1093;
            this.btnConfig.Tag = "ZZ4A";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // label_company_to
            // 
            this.label_company_to.AutoSize = true;
            this.label_company_to.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_company_to.Location = new System.Drawing.Point(242, 41);
            this.label_company_to.Name = "label_company_to";
            this.label_company_to.Size = new System.Drawing.Size(21, 13);
            this.label_company_to.TabIndex = 1125;
            this.label_company_to.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 38);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 1123;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 38);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1122;
            this.comp_b.ValueMember = "comp";
            // 
            // label_company_title
            // 
            this.label_company_title.AutoSize = true;
            this.label_company_title.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_company_title.Location = new System.Drawing.Point(68, 42);
            this.label_company_title.Name = "label_company_title";
            this.label_company_title.Size = new System.Drawing.Size(35, 13);
            this.label_company_title.TabIndex = 1124;
            this.label_company_title.Text = "公司";
            // 
            // seqmerge
            // 
            this.seqmerge.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seqmerge.CaptionLabel = null;
            this.seqmerge.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seqmerge.DecimalPlace = 2;
            this.seqmerge.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seqmerge.IsEmpty = true;
            this.seqmerge.Location = new System.Drawing.Point(360, 198);
            this.seqmerge.Mask = "";
            this.seqmerge.MaxLength = -1;
            this.seqmerge.Name = "seqmerge";
            this.seqmerge.PasswordChar = '\0';
            this.seqmerge.ReadOnly = false;
            this.seqmerge.ShowCalendarButton = true;
            this.seqmerge.Size = new System.Drawing.Size(20, 23);
            this.seqmerge.TabIndex = 1126;
            this.seqmerge.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(297, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 1127;
            this.label11.Text = "合併期別";
            // 
            // ZZ4A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 449);
            this.Controls.Add(this.seqmerge);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_company_to);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label_company_title);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.work_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.work_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.note);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.month);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ4A";
            this.Text = "薪資總表";
            this.Load += new System.EventHandler(this.ZZ4A_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox depts_b;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton dept_type2;
        internal System.Windows.Forms.RadioButton dept_type1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label24;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox seq;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox month;
        internal JBControls.TextBox year;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label label5;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.ComboBox work_e;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox work_b;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnConfig;


        private System.Windows.Forms.Label label_company_to;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label_company_title;
        internal JBControls.TextBox seqmerge;
        private System.Windows.Forms.Label label11;
    }
}