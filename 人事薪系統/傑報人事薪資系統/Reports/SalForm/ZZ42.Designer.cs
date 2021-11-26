/* ======================================================================================================
 * 功能名稱：發放薪資報表
 * 功能代號：ZZ42
 * 功能路徑：報表列印 > 薪資 > 發放薪資報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ42.Designer.cs
 * 功能用途：
 *  用於產出發放薪資報表
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
    partial class ZZ42
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
            this.tran_count = new System.Windows.Forms.CheckBox();
            this.salary_pa1 = new System.Windows.Forms.CheckBox();
            this.prn_paa = new System.Windows.Forms.CheckBox();
            this.pa1 = new System.Windows.Forms.CheckBox();
            this.pa = new System.Windows.Forms.CheckBox();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data5 = new System.Windows.Forms.RadioButton();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.seq = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.month = new JBControls.TextBox();
            this.year = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.saladr_e = new System.Windows.Forms.ComboBox();
            this.saladr_b = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.attdate_e = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.attdate_b = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.note1 = new System.Windows.Forms.TextBox();
            this.note = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.note3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pa3 = new System.Windows.Forms.CheckBox();
            this.pa2 = new System.Windows.Forms.CheckBox();
            this.order1 = new System.Windows.Forms.CheckBox();
            this.order2 = new System.Windows.Forms.CheckBox();
            this.order3 = new System.Windows.Forms.CheckBox();
            this.no_upwage = new System.Windows.Forms.CheckBox();
            this.no_name = new System.Windows.Forms.CheckBox();
            this.prn_noemail = new System.Windows.Forms.CheckBox();
            this.no_deptcount = new System.Windows.Forms.CheckBox();
            this.no_comp = new System.Windows.Forms.CheckBox();
            this.sumdi = new System.Windows.Forms.CheckBox();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.date_t = new System.Windows.Forms.ComboBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.print_pdf = new System.Windows.Forms.CheckBox();
            this.noout = new System.Windows.Forms.CheckBox();
            this.noret = new System.Windows.Forms.CheckBox();
            this.sendsalary = new System.Windows.Forms.CheckBox();
            this.LABCHECK = new System.Windows.Forms.CheckBox();
            this.seqmerge = new JBControls.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.NoDispOt = new System.Windows.Forms.CheckBox();
            this.label_company_to = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label_company_title = new System.Windows.Forms.Label();
            this.TwoRows = new System.Windows.Forms.CheckBox();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.A3_BigCharacter = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // tran_count
            // 
            this.tran_count.AutoSize = true;
            this.tran_count.Checked = true;
            this.tran_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tran_count.Location = new System.Drawing.Point(375, 412);
            this.tran_count.Name = "tran_count";
            this.tran_count.Size = new System.Drawing.Size(120, 16);
            this.tran_count.TabIndex = 40;
            this.tran_count.Text = "轉帳包含外勞定存";
            this.tran_count.UseVisualStyleBackColor = true;
            // 
            // salary_pa1
            // 
            this.salary_pa1.AutoSize = true;
            this.salary_pa1.Location = new System.Drawing.Point(525, 351);
            this.salary_pa1.Name = "salary_pa1";
            this.salary_pa1.Size = new System.Drawing.Size(96, 16);
            this.salary_pa1.TabIndex = 41;
            this.salary_pa1.Text = "英文版薪資袋";
            this.salary_pa1.UseVisualStyleBackColor = true;
            // 
            // prn_paa
            // 
            this.prn_paa.AutoSize = true;
            this.prn_paa.Location = new System.Drawing.Point(525, 373);
            this.prn_paa.Name = "prn_paa";
            this.prn_paa.Size = new System.Drawing.Size(168, 16);
            this.prn_paa.TabIndex = 39;
            this.prn_paa.Text = "A.會計匯款明細表(A4)橫印";
            this.prn_paa.UseVisualStyleBackColor = true;
            // 
            // pa1
            // 
            this.pa1.AutoSize = true;
            this.pa1.Location = new System.Drawing.Point(525, 307);
            this.pa1.Name = "pa1";
            this.pa1.Size = new System.Drawing.Size(48, 16);
            this.pa1.TabIndex = 30;
            this.pa1.Text = "大張";
            this.pa1.UseVisualStyleBackColor = true;
            // 
            // pa
            // 
            this.pa.AutoSize = true;
            this.pa.Location = new System.Drawing.Point(375, 307);
            this.pa.Name = "pa";
            this.pa.Size = new System.Drawing.Size(48, 16);
            this.pa.TabIndex = 29;
            this.pa.Text = "小字";
            this.pa.UseVisualStyleBackColor = true;
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "薪資明細表--編制",
            "薪資明細表--成本",
            "薪資彙總表--編制",
            "薪資彙總表--成本",
            "轉帳明細表",
            "現金表",
            "轉帳磁片",
            "薪資人數",
            "薪資單",
            "會計匯款明細表",
            "職業災害保險薪資列表",
            "退休金提撥表",
            "薪資快報",
            "職稱彙總",
            "應免稅報表",
            "代扣清單",
            "所得稅代扣報表",
            "薪資單-無出勤",
            "代扣彙總公司別"});
            this.report_type.Location = new System.Drawing.Point(104, 307);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(180, 20);
            this.report_type.TabIndex = 21;
            this.report_type.SelectedIndexChanged += new System.EventHandler(this.report_type_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(40, 310);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 1065;
            this.label30.Text = "報表種類";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 450);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 26;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 476);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 28;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 476);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 27;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data5);
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 35);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // type_data5
            // 
            this.type_data5.AutoSize = true;
            this.type_data5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data5.Location = new System.Drawing.Point(227, 12);
            this.type_data5.Name = "type_data5";
            this.type_data5.Size = new System.Drawing.Size(81, 17);
            this.type_data5.TabIndex = 20;
            this.type_data5.Text = "不含外勞";
            this.type_data5.UseVisualStyleBackColor = true;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 18;
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
            this.type_data2.TabIndex = 17;
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
            this.type_data4.TabIndex = 19;
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
            this.type_data1.TabIndex = 16;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(40, 279);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 13);
            this.label24.TabIndex = 1064;
            this.label24.Text = "資料內容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(26, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1063;
            this.label1.Text = "異動截止日";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 214);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 13;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1062;
            this.label3.Text = "轉帳日期";
            // 
            // seq
            // 
            this.seq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq.CaptionLabel = null;
            this.seq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq.DecimalPlace = 2;
            this.seq.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq.IsEmpty = false;
            this.seq.Location = new System.Drawing.Point(244, 159);
            this.seq.Mask = "";
            this.seq.MaxLength = -1;
            this.seq.Name = "seq";
            this.seq.PasswordChar = '\0';
            this.seq.ReadOnly = false;
            this.seq.ShowCalendarButton = true;
            this.seq.Size = new System.Drawing.Size(20, 23);
            this.seq.TabIndex = 11;
            this.seq.ValidType = JBControls.TextBox.EValidType.String;
            this.seq.Validated += new System.EventHandler(this.seq_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(208, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1061;
            this.label2.Text = "期別";
            // 
            // month
            // 
            this.month.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month.CaptionLabel = null;
            this.month.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month.DecimalPlace = 2;
            this.month.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month.IsEmpty = true;
            this.month.Location = new System.Drawing.Point(151, 159);
            this.month.Mask = "";
            this.month.MaxLength = -1;
            this.month.Name = "month";
            this.month.PasswordChar = '\0';
            this.month.ReadOnly = false;
            this.month.ShowCalendarButton = true;
            this.month.Size = new System.Drawing.Size(25, 23);
            this.month.TabIndex = 10;
            this.month.ValidType = JBControls.TextBox.EValidType.String;
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
            this.year.Location = new System.Drawing.Point(104, 159);
            this.year.Mask = "";
            this.year.MaxLength = -1;
            this.year.Name = "year";
            this.year.PasswordChar = '\0';
            this.year.ReadOnly = false;
            this.year.ShowCalendarButton = true;
            this.year.Size = new System.Drawing.Size(45, 23);
            this.year.TabIndex = 9;
            this.year.ValidType = JBControls.TextBox.EValidType.Integer;
            this.year.Validated += new System.EventHandler(this.year_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 163);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1060;
            this.label29.Text = "發放年月";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 57);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 1055;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 57);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 3;
            this.dept_b.ValueMember = "d_no";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1054;
            this.label14.Text = "至";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1051;
            this.label7.Text = "編制部門";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1050;
            this.label6.Text = "員工編號";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(242, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 1070;
            this.label9.Text = "至";
            // 
            // saladr_e
            // 
            this.saladr_e.DisplayMember = "salname";
            this.saladr_e.FormattingEnabled = true;
            this.saladr_e.Location = new System.Drawing.Point(280, 108);
            this.saladr_e.Name = "saladr_e";
            this.saladr_e.Size = new System.Drawing.Size(130, 20);
            this.saladr_e.TabIndex = 6;
            this.saladr_e.ValueMember = "saladr";
            // 
            // saladr_b
            // 
            this.saladr_b.DisplayMember = "salname";
            this.saladr_b.FormattingEnabled = true;
            this.saladr_b.Location = new System.Drawing.Point(104, 108);
            this.saladr_b.Name = "saladr_b";
            this.saladr_b.Size = new System.Drawing.Size(130, 20);
            this.saladr_b.TabIndex = 5;
            this.saladr_b.ValueMember = "saladr";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(40, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 1069;
            this.label17.Text = "薪資群組";
            // 
            // attdate_e
            // 
            this.attdate_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.attdate_e.CaptionLabel = null;
            this.attdate_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.attdate_e.DecimalPlace = 2;
            this.attdate_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.attdate_e.IsEmpty = false;
            this.attdate_e.Location = new System.Drawing.Point(280, 240);
            this.attdate_e.Mask = "0000/00/00";
            this.attdate_e.MaxLength = -1;
            this.attdate_e.Name = "attdate_e";
            this.attdate_e.PasswordChar = '\0';
            this.attdate_e.ReadOnly = false;
            this.attdate_e.ShowCalendarButton = true;
            this.attdate_e.Size = new System.Drawing.Size(80, 23);
            this.attdate_e.TabIndex = 15;
            this.attdate_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(242, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 1074;
            this.label5.Text = "至";
            // 
            // attdate_b
            // 
            this.attdate_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.attdate_b.CaptionLabel = null;
            this.attdate_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.attdate_b.DecimalPlace = 2;
            this.attdate_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.attdate_b.IsEmpty = false;
            this.attdate_b.Location = new System.Drawing.Point(104, 240);
            this.attdate_b.Mask = "0000/00/00";
            this.attdate_b.MaxLength = -1;
            this.attdate_b.Name = "attdate_b";
            this.attdate_b.PasswordChar = '\0';
            this.attdate_b.ReadOnly = false;
            this.attdate_b.ShowCalendarButton = true;
            this.attdate_b.Size = new System.Drawing.Size(80, 23);
            this.attdate_b.TabIndex = 14;
            this.attdate_b.ValidType = JBControls.TextBox.EValidType.Date;
            this.attdate_b.Validated += new System.EventHandler(this.attdate_b_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(40, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1073;
            this.label8.Text = "出勤日期";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(68, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1083;
            this.label10.Text = "備註";
            // 
            // note1
            // 
            this.note1.Location = new System.Drawing.Point(104, 417);
            this.note1.Name = "note1";
            this.note1.Size = new System.Drawing.Size(200, 22);
            this.note1.TabIndex = 24;
            // 
            // note
            // 
            this.note.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.note.Location = new System.Drawing.Point(104, 359);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.note.Size = new System.Drawing.Size(256, 50);
            this.note.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(40, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1082;
            this.label4.Text = "提示文字";
            // 
            // note3
            // 
            this.note3.Location = new System.Drawing.Point(104, 331);
            this.note3.Name = "note3";
            this.note3.Size = new System.Drawing.Size(200, 22);
            this.note3.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(40, 335);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 1089;
            this.label13.Text = "報表表頭";
            // 
            // pa3
            // 
            this.pa3.AutoSize = true;
            this.pa3.Location = new System.Drawing.Point(375, 329);
            this.pa3.Name = "pa3";
            this.pa3.Size = new System.Drawing.Size(72, 16);
            this.pa3.TabIndex = 31;
            this.pa3.Text = "大張小字";
            this.pa3.UseVisualStyleBackColor = true;
            // 
            // pa2
            // 
            this.pa2.AutoSize = true;
            this.pa2.Location = new System.Drawing.Point(375, 351);
            this.pa2.Name = "pa2";
            this.pa2.Size = new System.Drawing.Size(48, 16);
            this.pa2.TabIndex = 32;
            this.pa2.Text = "直式";
            this.pa2.UseVisualStyleBackColor = true;
            // 
            // order1
            // 
            this.order1.AutoSize = true;
            this.order1.Location = new System.Drawing.Point(375, 453);
            this.order1.Name = "order1";
            this.order1.Size = new System.Drawing.Size(96, 16);
            this.order1.TabIndex = 33;
            this.order1.Text = "員工編號排列";
            this.order1.UseVisualStyleBackColor = true;
            // 
            // order2
            // 
            this.order2.AutoSize = true;
            this.order2.Location = new System.Drawing.Point(375, 475);
            this.order2.Name = "order2";
            this.order2.Size = new System.Drawing.Size(102, 16);
            this.order2.TabIndex = 34;
            this.order2.Text = "部門+職等排列";
            this.order2.UseVisualStyleBackColor = true;
            // 
            // order3
            // 
            this.order3.AutoSize = true;
            this.order3.Location = new System.Drawing.Point(375, 497);
            this.order3.Name = "order3";
            this.order3.Size = new System.Drawing.Size(84, 16);
            this.order3.TabIndex = 35;
            this.order3.Text = "依職等排列";
            this.order3.UseVisualStyleBackColor = true;
            // 
            // no_upwage
            // 
            this.no_upwage.AutoSize = true;
            this.no_upwage.Location = new System.Drawing.Point(375, 519);
            this.no_upwage.Name = "no_upwage";
            this.no_upwage.Size = new System.Drawing.Size(144, 16);
            this.no_upwage.TabIndex = 36;
            this.no_upwage.Text = "薪資總表不含上期薪資";
            this.no_upwage.UseVisualStyleBackColor = true;
            // 
            // no_name
            // 
            this.no_name.AutoSize = true;
            this.no_name.Location = new System.Drawing.Point(375, 373);
            this.no_name.Name = "no_name";
            this.no_name.Size = new System.Drawing.Size(132, 16);
            this.no_name.TabIndex = 37;
            this.no_name.Text = "轉帳明細表不印姓名";
            this.no_name.UseVisualStyleBackColor = true;
            // 
            // prn_noemail
            // 
            this.prn_noemail.AutoSize = true;
            this.prn_noemail.Location = new System.Drawing.Point(525, 392);
            this.prn_noemail.Name = "prn_noemail";
            this.prn_noemail.Size = new System.Drawing.Size(144, 16);
            this.prn_noemail.TabIndex = 38;
            this.prn_noemail.Text = "薪資單只列印無E-Mail";
            this.prn_noemail.UseVisualStyleBackColor = true;
            // 
            // no_deptcount
            // 
            this.no_deptcount.AutoSize = true;
            this.no_deptcount.Checked = true;
            this.no_deptcount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.no_deptcount.Location = new System.Drawing.Point(375, 392);
            this.no_deptcount.Name = "no_deptcount";
            this.no_deptcount.Size = new System.Drawing.Size(108, 16);
            this.no_deptcount.TabIndex = 1090;
            this.no_deptcount.Text = "部門不列印小計";
            this.no_deptcount.UseVisualStyleBackColor = true;
            // 
            // no_comp
            // 
            this.no_comp.AutoSize = true;
            this.no_comp.Location = new System.Drawing.Point(375, 434);
            this.no_comp.Name = "no_comp";
            this.no_comp.Size = new System.Drawing.Size(84, 16);
            this.no_comp.TabIndex = 1091;
            this.no_comp.Text = "不分公司別";
            this.no_comp.UseVisualStyleBackColor = true;
            // 
            // sumdi
            // 
            this.sumdi.AutoSize = true;
            this.sumdi.Location = new System.Drawing.Point(525, 412);
            this.sumdi.Name = "sumdi";
            this.sumdi.Size = new System.Drawing.Size(84, 16);
            this.sumdi.TabIndex = 39;
            this.sumdi.Text = "彙總直間接";
            this.sumdi.UseVisualStyleBackColor = true;
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
            this.nobr_b.Location = new System.Drawing.Point(104, 6);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 1;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 6);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 2;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // date_t
            // 
            this.date_t.DisplayMember = "adate";
            this.date_t.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.date_t.FormattingEnabled = true;
            this.date_t.Location = new System.Drawing.Point(104, 187);
            this.date_t.Name = "date_t";
            this.date_t.Size = new System.Drawing.Size(90, 20);
            this.date_t.TabIndex = 12;
            this.date_t.ValueMember = "adate";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 134);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 8;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(242, 137);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1095;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 134);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 7;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(68, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1094;
            this.label23.Text = "員別";
            // 
            // print_pdf
            // 
            this.print_pdf.AutoSize = true;
            this.print_pdf.Location = new System.Drawing.Point(525, 497);
            this.print_pdf.Name = "print_pdf";
            this.print_pdf.Size = new System.Drawing.Size(102, 16);
            this.print_pdf.TabIndex = 1096;
            this.print_pdf.Text = "薪資單PDF格式";
            this.print_pdf.UseVisualStyleBackColor = true;
            this.print_pdf.Visible = false;
            // 
            // noout
            // 
            this.noout.AutoSize = true;
            this.noout.Location = new System.Drawing.Point(525, 519);
            this.noout.Name = "noout";
            this.noout.Size = new System.Drawing.Size(72, 16);
            this.noout.TabIndex = 1097;
            this.noout.Text = "不含離職";
            this.noout.UseVisualStyleBackColor = true;
            this.noout.Visible = false;
            // 
            // noret
            // 
            this.noret.AutoSize = true;
            this.noret.Location = new System.Drawing.Point(525, 475);
            this.noret.Name = "noret";
            this.noret.Size = new System.Drawing.Size(144, 16);
            this.noret.TabIndex = 1098;
            this.noret.Text = "薪資單無出勤列印勞退";
            this.noret.UseVisualStyleBackColor = true;
            this.noret.Visible = false;
            // 
            // sendsalary
            // 
            this.sendsalary.AutoSize = true;
            this.sendsalary.Location = new System.Drawing.Point(218, 450);
            this.sendsalary.Name = "sendsalary";
            this.sendsalary.Size = new System.Drawing.Size(84, 16);
            this.sendsalary.TabIndex = 1108;
            this.sendsalary.Text = "薪資單傳送";
            this.sendsalary.UseVisualStyleBackColor = true;
            // 
            // LABCHECK
            // 
            this.LABCHECK.AutoSize = true;
            this.LABCHECK.Location = new System.Drawing.Point(434, 279);
            this.LABCHECK.Name = "LABCHECK";
            this.LABCHECK.Size = new System.Drawing.Size(36, 16);
            this.LABCHECK.TabIndex = 1112;
            this.LABCHECK.Text = "勞";
            this.LABCHECK.UseVisualStyleBackColor = true;
            // 
            // seqmerge
            // 
            this.seqmerge.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seqmerge.CaptionLabel = null;
            this.seqmerge.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seqmerge.DecimalPlace = 2;
            this.seqmerge.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seqmerge.IsEmpty = true;
            this.seqmerge.Location = new System.Drawing.Point(340, 160);
            this.seqmerge.Mask = "";
            this.seqmerge.MaxLength = -1;
            this.seqmerge.Name = "seqmerge";
            this.seqmerge.PasswordChar = '\0';
            this.seqmerge.ReadOnly = false;
            this.seqmerge.ShowCalendarButton = true;
            this.seqmerge.Size = new System.Drawing.Size(20, 23);
            this.seqmerge.TabIndex = 1113;
            this.seqmerge.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(277, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 1114;
            this.label11.Text = "合併期別";
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(668, 512);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1115;
            this.btnConfig.Tag = "ZZ42";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // NoDispOt
            // 
            this.NoDispOt.AutoSize = true;
            this.NoDispOt.Location = new System.Drawing.Point(525, 434);
            this.NoDispOt.Name = "NoDispOt";
            this.NoDispOt.Size = new System.Drawing.Size(120, 16);
            this.NoDispOt.TabIndex = 1116;
            this.NoDispOt.Text = "薪資單不顯示加班";
            this.NoDispOt.UseVisualStyleBackColor = true;
            // 
            // label_company_to
            // 
            this.label_company_to.AutoSize = true;
            this.label_company_to.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_company_to.Location = new System.Drawing.Point(242, 35);
            this.label_company_to.Name = "label_company_to";
            this.label_company_to.Size = new System.Drawing.Size(21, 13);
            this.label_company_to.TabIndex = 1121;
            this.label_company_to.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 32);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 1119;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 32);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1118;
            this.comp_b.ValueMember = "comp";
            // 
            // label_company_title
            // 
            this.label_company_title.AutoSize = true;
            this.label_company_title.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_company_title.Location = new System.Drawing.Point(68, 36);
            this.label_company_title.Name = "label_company_title";
            this.label_company_title.Size = new System.Drawing.Size(35, 13);
            this.label_company_title.TabIndex = 1120;
            this.label_company_title.Text = "公司";
            // 
            // TwoRows
            // 
            this.TwoRows.AutoSize = true;
            this.TwoRows.Location = new System.Drawing.Point(525, 453);
            this.TwoRows.Name = "TwoRows";
            this.TwoRows.Size = new System.Drawing.Size(126, 16);
            this.TwoRows.TabIndex = 1117;
            this.TwoRows.Text = "明細/彙總顯示二列";
            this.TwoRows.UseVisualStyleBackColor = true;
            this.TwoRows.Visible = false;
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.FormattingEnabled = true;
            this.depts_e.Location = new System.Drawing.Point(280, 82);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 1183;
            this.depts_e.ValueMember = "d_no";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(242, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 1185;
            this.label16.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.FormattingEnabled = true;
            this.depts_b.Location = new System.Drawing.Point(104, 82);
            this.depts_b.Name = "depts_b";
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 1182;
            this.depts_b.ValueMember = "d_no";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(40, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 1184;
            this.label18.Text = "成本部門";
            // 
            // A3_BigCharacter
            // 
            this.A3_BigCharacter.AutoSize = true;
            this.A3_BigCharacter.Location = new System.Drawing.Point(525, 329);
            this.A3_BigCharacter.Name = "A3_BigCharacter";
            this.A3_BigCharacter.Size = new System.Drawing.Size(72, 16);
            this.A3_BigCharacter.TabIndex = 1186;
            this.A3_BigCharacter.Text = "大張大字";
            this.A3_BigCharacter.UseVisualStyleBackColor = true;
            // 
            // ZZ42
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 539);
            this.Controls.Add(this.A3_BigCharacter);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label_company_to);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label_company_title);
            this.Controls.Add(this.TwoRows);
            this.Controls.Add(this.NoDispOt);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.seqmerge);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LABCHECK);
            this.Controls.Add(this.sendsalary);
            this.Controls.Add(this.noret);
            this.Controls.Add(this.noout);
            this.Controls.Add(this.print_pdf);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.date_t);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.sumdi);
            this.Controls.Add(this.no_comp);
            this.Controls.Add(this.no_deptcount);
            this.Controls.Add(this.prn_noemail);
            this.Controls.Add(this.no_name);
            this.Controls.Add(this.no_upwage);
            this.Controls.Add(this.order3);
            this.Controls.Add(this.order2);
            this.Controls.Add(this.order1);
            this.Controls.Add(this.pa2);
            this.Controls.Add(this.pa3);
            this.Controls.Add(this.note3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.note1);
            this.Controls.Add(this.note);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.attdate_e);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.attdate_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.saladr_e);
            this.Controls.Add(this.saladr_b);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tran_count);
            this.Controls.Add(this.salary_pa1);
            this.Controls.Add(this.prn_paa);
            this.Controls.Add(this.pa1);
            this.Controls.Add(this.pa);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.month);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ42";
            this.Text = "發放薪資報表";
            this.Load += new System.EventHandler(this.ZZ42_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox tran_count;
        internal System.Windows.Forms.CheckBox salary_pa1;
        internal System.Windows.Forms.CheckBox prn_paa;
        internal System.Windows.Forms.CheckBox pa1;
        internal System.Windows.Forms.CheckBox pa;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data5;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox seq;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox month;
        internal JBControls.TextBox year;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox saladr_e;
        internal System.Windows.Forms.ComboBox saladr_b;
        private System.Windows.Forms.Label label17;
        internal JBControls.TextBox attdate_e;
        private System.Windows.Forms.Label label5;
        internal JBControls.TextBox attdate_b;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox note1;
        internal System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox note3;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.CheckBox pa3;
        internal System.Windows.Forms.CheckBox pa2;
        internal System.Windows.Forms.CheckBox order1;
        internal System.Windows.Forms.CheckBox order2;
        internal System.Windows.Forms.CheckBox order3;
        internal System.Windows.Forms.CheckBox no_upwage;
        internal System.Windows.Forms.CheckBox no_name;
        internal System.Windows.Forms.CheckBox prn_noemail;
        internal System.Windows.Forms.CheckBox no_deptcount;
        internal System.Windows.Forms.CheckBox no_comp;
        internal System.Windows.Forms.CheckBox sumdi;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        private System.Windows.Forms.ComboBox date_t;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.CheckBox print_pdf;
        internal System.Windows.Forms.CheckBox noout;
        internal System.Windows.Forms.CheckBox noret;
        internal System.Windows.Forms.CheckBox sendsalary;
        internal System.Windows.Forms.CheckBox LABCHECK;
        internal JBControls.TextBox seqmerge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConfig;
        internal System.Windows.Forms.CheckBox NoDispOt;
        private System.Windows.Forms.Label label_company_to;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label_company_title;
        internal System.Windows.Forms.CheckBox TwoRows;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox depts_b;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.CheckBox A3_BigCharacter;
    }
}