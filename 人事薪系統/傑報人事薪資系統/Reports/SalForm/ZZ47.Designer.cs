/* ======================================================================================================
 * 功能名稱：薪資異動表
 * 功能代號：ZZ47
 * 功能路徑：報表列印 > 薪資 > 薪資異動表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ47.Designer.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/03    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/03
 */

namespace JBHR.Reports.SalForm
{
    partial class ZZ47
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
            this.salcode_e = new System.Windows.Forms.ComboBox();
            this.salcode_b = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.date_e = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dept_type2 = new System.Windows.Forms.RadioButton();
            this.dept_type1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ttstype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.work_e = new System.Windows.Forms.ComboBox();
            this.work_b = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
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
            this.label_company_to = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label_company_title = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.year_no_adjust = new JBControls.TextBox();
            this.tts_no_adjust = new System.Windows.Forms.RadioButton();
            this.tts_salary = new System.Windows.Forms.RadioButton();
            this.tts_none = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.tts_include_before = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // salcode_e
            // 
            this.salcode_e.DisplayMember = "sal_name";
            this.salcode_e.FormattingEnabled = true;
            this.salcode_e.Location = new System.Drawing.Point(280, 210);
            this.salcode_e.Name = "salcode_e";
            this.salcode_e.Size = new System.Drawing.Size(130, 20);
            this.salcode_e.TabIndex = 13;
            this.salcode_e.ValueMember = "sal_code";
            // 
            // salcode_b
            // 
            this.salcode_b.DisplayMember = "sal_name";
            this.salcode_b.FormattingEnabled = true;
            this.salcode_b.Location = new System.Drawing.Point(104, 210);
            this.salcode_b.Name = "salcode_b";
            this.salcode_b.Size = new System.Drawing.Size(130, 20);
            this.salcode_b.TabIndex = 12;
            this.salcode_b.ValueMember = "sal_code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(242, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 905;
            this.label9.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(40, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 904;
            this.label5.Text = "薪資代碼";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 35);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 20;
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
            this.type_data2.TabIndex = 19;
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
            this.type_data4.TabIndex = 21;
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
            this.type_data1.TabIndex = 18;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(40, 303);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 13);
            this.label24.TabIndex = 903;
            this.label24.Text = "資料內容";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 464);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 25;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 491);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 27;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 491);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 26;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(280, 62);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 5;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(242, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 901;
            this.label4.Text = "至";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 62);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 4;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 900;
            this.label3.Text = "起迄日期";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dept_type2);
            this.groupBox1.Controls.Add(this.dept_type1);
            this.groupBox1.Location = new System.Drawing.Point(103, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 35);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // dept_type2
            // 
            this.dept_type2.AutoSize = true;
            this.dept_type2.Location = new System.Drawing.Point(94, 12);
            this.dept_type2.Name = "dept_type2";
            this.dept_type2.Size = new System.Drawing.Size(71, 16);
            this.dept_type2.TabIndex = 7;
            this.dept_type2.Text = "成本部門";
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
            this.dept_type1.TabIndex = 6;
            this.dept_type1.TabStop = true;
            this.dept_type1.Text = "編制部門";
            this.dept_type1.UseVisualStyleBackColor = true;
            this.dept_type1.Click += new System.EventHandler(this.dept_type1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 898;
            this.label2.Text = "部門種類";
            // 
            // ttstype
            // 
            this.ttstype.FormattingEnabled = true;
            this.ttstype.Items.AddRange(new object[] {
            "在職",
            "全部"});
            this.ttstype.Location = new System.Drawing.Point(104, 7);
            this.ttstype.Name = "ttstype";
            this.ttstype.Size = new System.Drawing.Size(70, 20);
            this.ttstype.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 897;
            this.label1.Text = "異動種類";
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.Enabled = false;
            this.depts_e.FormattingEnabled = true;
            this.depts_e.Location = new System.Drawing.Point(280, 184);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 11;
            this.depts_e.ValueMember = "d_no";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(242, 189);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 896;
            this.label16.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.Enabled = false;
            this.depts_b.FormattingEnabled = true;
            this.depts_b.Location = new System.Drawing.Point(104, 184);
            this.depts_b.Name = "depts_b";
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 10;
            this.depts_b.ValueMember = "d_no";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 158);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 9;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 895;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 158);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 8;
            this.dept_b.ValueMember = "d_no";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(40, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 894;
            this.label8.Text = "成本部門";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 893;
            this.label7.Text = "編制部門";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 892;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 891;
            this.label6.Text = "員工編號";
            // 
            // work_e
            // 
            this.work_e.DisplayMember = "salname";
            this.work_e.FormattingEnabled = true;
            this.work_e.Location = new System.Drawing.Point(280, 238);
            this.work_e.Name = "work_e";
            this.work_e.Size = new System.Drawing.Size(130, 20);
            this.work_e.TabIndex = 15;
            this.work_e.ValueMember = "saladr";
            // 
            // work_b
            // 
            this.work_b.DisplayMember = "salname";
            this.work_b.FormattingEnabled = true;
            this.work_b.Location = new System.Drawing.Point(104, 238);
            this.work_b.Name = "work_b";
            this.work_b.Size = new System.Drawing.Size(130, 20);
            this.work_b.TabIndex = 14;
            this.work_b.ValueMember = "saladr";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(242, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 909;
            this.label10.Text = "至";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(40, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 908;
            this.label11.Text = "薪資群組";
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "薪資異動表"});
            this.report_type.Location = new System.Drawing.Point(103, 433);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(150, 20);
            this.report_type.TabIndex = 24;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(40, 436);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 973;
            this.label30.Text = "報表種類";
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
            this.nobr_b.Location = new System.Drawing.Point(104, 34);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 2;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 34);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 3;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 263);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 17;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(242, 266);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1055;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 263);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 16;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(67, 267);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1054;
            this.label23.Text = "員別";
            // 
            // label_company_to
            // 
            this.label_company_to.AutoSize = true;
            this.label_company_to.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_company_to.Location = new System.Drawing.Point(242, 135);
            this.label_company_to.Name = "label_company_to";
            this.label_company_to.Size = new System.Drawing.Size(21, 13);
            this.label_company_to.TabIndex = 1125;
            this.label_company_to.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 132);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 1123;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 132);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1122;
            this.comp_b.ValueMember = "comp";
            // 
            // label_company_title
            // 
            this.label_company_title.AutoSize = true;
            this.label_company_title.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_company_title.Location = new System.Drawing.Point(68, 136);
            this.label_company_title.Name = "label_company_title";
            this.label_company_title.Size = new System.Drawing.Size(35, 13);
            this.label_company_title.TabIndex = 1124;
            this.label_company_title.Text = "公司";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.year_no_adjust);
            this.groupBox3.Controls.Add(this.tts_no_adjust);
            this.groupBox3.Controls.Add(this.tts_salary);
            this.groupBox3.Controls.Add(this.tts_none);
            this.groupBox3.Location = new System.Drawing.Point(104, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 81);
            this.groupBox3.TabIndex = 904;
            this.groupBox3.TabStop = false;
            // 
            // year_no_adjust
            // 
            this.year_no_adjust.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year_no_adjust.CaptionLabel = null;
            this.year_no_adjust.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year_no_adjust.DecimalPlace = 0;
            this.year_no_adjust.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year_no_adjust.IsEmpty = false;
            this.year_no_adjust.Location = new System.Drawing.Point(124, 54);
            this.year_no_adjust.Mask = "";
            this.year_no_adjust.MaxLength = -1;
            this.year_no_adjust.Name = "year_no_adjust";
            this.year_no_adjust.PasswordChar = '\0';
            this.year_no_adjust.ReadOnly = false;
            this.year_no_adjust.ShowCalendarButton = true;
            this.year_no_adjust.Size = new System.Drawing.Size(37, 23);
            this.year_no_adjust.TabIndex = 21;
            this.year_no_adjust.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // tts_no_adjust
            // 
            this.tts_no_adjust.AutoSize = true;
            this.tts_no_adjust.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tts_no_adjust.Location = new System.Drawing.Point(6, 57);
            this.tts_no_adjust.Name = "tts_no_adjust";
            this.tts_no_adjust.Size = new System.Drawing.Size(235, 17);
            this.tts_no_adjust.TabIndex = 20;
            this.tts_no_adjust.Text = "只列印大於等於      天未調薪者";
            this.tts_no_adjust.UseVisualStyleBackColor = true;
            this.tts_no_adjust.CheckedChanged += new System.EventHandler(this.tts_no_adjust_CheckedChanged);
            // 
            // tts_salary
            // 
            this.tts_salary.AutoSize = true;
            this.tts_salary.Checked = true;
            this.tts_salary.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tts_salary.Location = new System.Drawing.Point(6, 34);
            this.tts_salary.Name = "tts_salary";
            this.tts_salary.Size = new System.Drawing.Size(151, 17);
            this.tts_salary.TabIndex = 19;
            this.tts_salary.TabStop = true;
            this.tts_salary.Text = "列印資料期間異動者";
            this.tts_salary.UseVisualStyleBackColor = true;
            this.tts_salary.CheckedChanged += new System.EventHandler(this.tts_salary_CheckedChanged);
            // 
            // tts_none
            // 
            this.tts_none.AutoSize = true;
            this.tts_none.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tts_none.Location = new System.Drawing.Point(6, 12);
            this.tts_none.Name = "tts_none";
            this.tts_none.Size = new System.Drawing.Size(151, 17);
            this.tts_none.TabIndex = 18;
            this.tts_none.Text = "只列印最後異動資料";
            this.tts_none.UseVisualStyleBackColor = true;
            this.tts_none.CheckedChanged += new System.EventHandler(this.tts_none_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(40, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 905;
            this.label12.Text = "篩選模式";
            // 
            // tts_include_before
            // 
            this.tts_include_before.AutoSize = true;
            this.tts_include_before.Location = new System.Drawing.Point(104, 411);
            this.tts_include_before.Name = "tts_include_before";
            this.tts_include_before.Size = new System.Drawing.Size(108, 16);
            this.tts_include_before.TabIndex = 1126;
            this.tts_include_before.Text = "包含前一筆資料";
            this.tts_include_before.UseVisualStyleBackColor = true;
            // 
            // ZZ47
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 538);
            this.Controls.Add(this.tts_include_before);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_company_to);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label_company_title);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.work_e);
            this.Controls.Add(this.work_b);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.salcode_e);
            this.Controls.Add(this.salcode_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ttstype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ47";
            this.Text = "薪資異動報表";
            this.Load += new System.EventHandler(this.ZZ47_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox salcode_e;
        internal System.Windows.Forms.ComboBox salcode_b;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label24;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton dept_type2;
        internal System.Windows.Forms.RadioButton dept_type1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox ttstype;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox depts_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox work_e;
        internal System.Windows.Forms.ComboBox work_b;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
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
        private System.Windows.Forms.Label label_company_to;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label_company_title;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton tts_no_adjust;
        internal System.Windows.Forms.RadioButton tts_salary;
        internal System.Windows.Forms.RadioButton tts_none;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.CheckBox tts_include_before;
        internal JBControls.TextBox year_no_adjust;
    }
}