/* ======================================================================================================
 * 功能名稱：人事資料
 * 功能代號：ZZ11
 * 功能路徑：報表列印 > 人事 >　人事資料
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ11.Designer.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：
 */

namespace JBHR.Reports.EmpForm
{
    partial class ZZ11
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
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.work_e = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.work_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.date_e = new JBControls.TextBox();
            this.date_b = new JBControls.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ttstype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bnLeave = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.seniority_e = new JBControls.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.seniority_b = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.age_e = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.age_b = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.jobl_e = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.jobl_b = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.include_leave = new System.Windows.Forms.CheckBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.cindt_check = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(103, 357);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 25;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "基本報表1",
            "基本報表(NEW)",
            "基本報表-保險用",
            "基本報表-通訊用",
            "員工名冊",
            "v新進一覽表",
            "v離職一覽表",
            "v留職停薪明細",
            "標籤",
            "信封"});
            this.report_type.Location = new System.Drawing.Point(104, 328);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(121, 20);
            this.report_type.TabIndex = 24;
            this.report_type.SelectedIndexChanged += new System.EventHandler(this.report_type_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(40, 331);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 158;
            this.label30.Text = "報表種類";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 35);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 22;
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
            this.type_data2.TabIndex = 21;
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
            this.type_data4.TabIndex = 23;
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
            this.type_data1.TabIndex = 20;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 301);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 157;
            this.label29.Text = "資料內容";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 216);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 15;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(242, 221);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 156;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 216);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 14;
            this.comp_b.ValueMember = "comp";
            // 
            // work_e
            // 
            this.work_e.DisplayMember = "work_addr";
            this.work_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.work_e.FormattingEnabled = true;
            this.work_e.Location = new System.Drawing.Point(280, 191);
            this.work_e.Name = "work_e";
            this.work_e.Size = new System.Drawing.Size(130, 20);
            this.work_e.TabIndex = 13;
            this.work_e.ValueMember = "work_code";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(242, 196);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 155;
            this.label19.Text = "至";
            // 
            // work_b
            // 
            this.work_b.DisplayMember = "work_addr";
            this.work_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.work_b.FormattingEnabled = true;
            this.work_b.Location = new System.Drawing.Point(104, 191);
            this.work_b.Name = "work_b";
            this.work_b.Size = new System.Drawing.Size(130, 20);
            this.work_b.TabIndex = 12;
            this.work_b.ValueMember = "work_code";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 114);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 9;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 153;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 114);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 8;
            this.dept_b.ValueMember = "d_no";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 152;
            this.label14.Text = "至";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 60);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 5;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(242, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 151;
            this.label13.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 60);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 4;
            this.empcd_b.ValueMember = "empcd";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Enabled = false;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(280, 32);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 3;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 32);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 2;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(68, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 150;
            this.label12.Text = "公司";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(52, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 149;
            this.label11.Text = "工作地";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 147;
            this.label7.Text = "編制部門";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 146;
            this.label6.Text = "員工編號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(68, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 145;
            this.label5.Text = "員別";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(242, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 144;
            this.label4.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 143;
            this.label3.Text = "起迄日期";
            // 
            // ttstype
            // 
            this.ttstype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ttstype.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ttstype.FormattingEnabled = true;
            this.ttstype.Items.AddRange(new object[] {
            "在職",
            "新進",
            "離職",
            "全部",
            "新進不含離職",
            "留職停薪",
            "期間在職"});
            this.ttstype.Location = new System.Drawing.Point(104, 6);
            this.ttstype.Name = "ttstype";
            this.ttstype.Size = new System.Drawing.Size(129, 21);
            this.ttstype.TabIndex = 1;
            this.ttstype.SelectedIndexChanged += new System.EventHandler(this.ttstype_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "異動種類";
            // 
            // bnLeave
            // 
            this.bnLeave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnLeave.Location = new System.Drawing.Point(260, 383);
            this.bnLeave.Name = "bnLeave";
            this.bnLeave.Size = new System.Drawing.Size(75, 23);
            this.bnLeave.TabIndex = 28;
            this.bnLeave.Text = "離開";
            this.bnLeave.UseVisualStyleBackColor = true;
            this.bnLeave.Click += new System.EventHandler(this.Leave_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 383);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 27;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // seniority_e
            // 
            this.seniority_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seniority_e.CaptionLabel = null;
            this.seniority_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seniority_e.DecimalPlace = 2;
            this.seniority_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seniority_e.IsEmpty = false;
            this.seniority_e.Location = new System.Drawing.Point(279, 267);
            this.seniority_e.Mask = "";
            this.seniority_e.MaxLength = -1;
            this.seniority_e.Name = "seniority_e";
            this.seniority_e.PasswordChar = '\0';
            this.seniority_e.ReadOnly = false;
            this.seniority_e.ShowCalendarButton = true;
            this.seniority_e.Size = new System.Drawing.Size(30, 23);
            this.seniority_e.TabIndex = 19;
            this.seniority_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label31.Location = new System.Drawing.Point(242, 271);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(21, 13);
            this.label31.TabIndex = 162;
            this.label31.Text = "至";
            // 
            // seniority_b
            // 
            this.seniority_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seniority_b.CaptionLabel = null;
            this.seniority_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seniority_b.DecimalPlace = 2;
            this.seniority_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seniority_b.IsEmpty = false;
            this.seniority_b.Location = new System.Drawing.Point(104, 267);
            this.seniority_b.Mask = "";
            this.seniority_b.MaxLength = -1;
            this.seniority_b.Name = "seniority_b";
            this.seniority_b.PasswordChar = '\0';
            this.seniority_b.ReadOnly = false;
            this.seniority_b.ShowCalendarButton = true;
            this.seniority_b.Size = new System.Drawing.Size(30, 23);
            this.seniority_b.TabIndex = 18;
            this.seniority_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(68, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "年資";
            // 
            // age_e
            // 
            this.age_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.age_e.CaptionLabel = null;
            this.age_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.age_e.DecimalPlace = 2;
            this.age_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.age_e.IsEmpty = false;
            this.age_e.Location = new System.Drawing.Point(279, 240);
            this.age_e.Mask = "";
            this.age_e.MaxLength = -1;
            this.age_e.Name = "age_e";
            this.age_e.PasswordChar = '\0';
            this.age_e.ReadOnly = false;
            this.age_e.ShowCalendarButton = true;
            this.age_e.Size = new System.Drawing.Size(30, 23);
            this.age_e.TabIndex = 17;
            this.age_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(242, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 166;
            this.label8.Text = "至";
            // 
            // age_b
            // 
            this.age_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.age_b.CaptionLabel = null;
            this.age_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.age_b.DecimalPlace = 2;
            this.age_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.age_b.IsEmpty = false;
            this.age_b.Location = new System.Drawing.Point(104, 240);
            this.age_b.Mask = "";
            this.age_b.MaxLength = -1;
            this.age_b.Name = "age_b";
            this.age_b.PasswordChar = '\0';
            this.age_b.ReadOnly = false;
            this.age_b.ShowCalendarButton = true;
            this.age_b.Size = new System.Drawing.Size(30, 23);
            this.age_b.TabIndex = 16;
            this.age_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(68, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 165;
            this.label9.Text = "年齡";
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
            this.nobr_b.Location = new System.Drawing.Point(104, 86);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 6;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 86);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 7;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // jobl_e
            // 
            this.jobl_e.DisplayMember = "job_name";
            this.jobl_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_e.FormattingEnabled = true;
            this.jobl_e.Location = new System.Drawing.Point(280, 166);
            this.jobl_e.Name = "jobl_e";
            this.jobl_e.Size = new System.Drawing.Size(130, 20);
            this.jobl_e.TabIndex = 11;
            this.jobl_e.ValueMember = "jobl";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(242, 171);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 879;
            this.label18.Text = "至";
            // 
            // jobl_b
            // 
            this.jobl_b.DisplayMember = "job_name";
            this.jobl_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_b.FormattingEnabled = true;
            this.jobl_b.Location = new System.Drawing.Point(104, 166);
            this.jobl_b.Name = "jobl_b";
            this.jobl_b.Size = new System.Drawing.Size(130, 20);
            this.jobl_b.TabIndex = 10;
            this.jobl_b.ValueMember = "jobl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(68, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 878;
            this.label10.Text = "職等";
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depts_e.FormattingEnabled = true;
            this.depts_e.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.depts_e.Location = new System.Drawing.Point(280, 140);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 1185;
            this.depts_e.ValueMember = "d_no";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(242, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 1187;
            this.label16.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depts_b.FormattingEnabled = true;
            this.depts_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.depts_b.Location = new System.Drawing.Point(104, 140);
            this.depts_b.Name = "depts_b";
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 1184;
            this.depts_b.ValueMember = "d_no";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(40, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 1186;
            this.label17.Text = "成本部門";
            // 
            // include_leave
            // 
            this.include_leave.AutoSize = true;
            this.include_leave.Checked = true;
            this.include_leave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.include_leave.Enabled = false;
            this.include_leave.Location = new System.Drawing.Point(245, 9);
            this.include_leave.Name = "include_leave";
            this.include_leave.Size = new System.Drawing.Size(108, 16);
            this.include_leave.TabIndex = 1188;
            this.include_leave.Text = "包含已離職人員";
            this.include_leave.UseVisualStyleBackColor = true;
            this.include_leave.Visible = false;
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(404, 383);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1189;
            this.btnConfig.Tag = "ZZ11";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // cindt_check
            // 
            this.cindt_check.AutoSize = true;
            this.cindt_check.Location = new System.Drawing.Point(218, 357);
            this.cindt_check.Name = "cindt_check";
            this.cindt_check.Size = new System.Drawing.Size(168, 16);
            this.cindt_check.TabIndex = 1190;
            this.cindt_check.Text = "固定以集團到職日計算年資";
            this.cindt_check.UseVisualStyleBackColor = true;
            // 
            // ZZ11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 420);
            this.Controls.Add(this.cindt_check);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.include_leave);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.jobl_e);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.jobl_b);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.age_e);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.age_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.seniority_e);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.seniority_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.work_e);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.work_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ttstype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnLeave);
            this.Controls.Add(this.Create_Report);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ11";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ZZ11_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox ExportExcel;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        internal System.Windows.Forms.ComboBox work_e;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox work_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox empcd_b;
        internal JBControls.TextBox date_e;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox ttstype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnLeave;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox seniority_e;
        private System.Windows.Forms.Label label31;
        internal JBControls.TextBox seniority_b;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox age_e;
        private System.Windows.Forms.Label label8;
        internal JBControls.TextBox age_b;
        private System.Windows.Forms.Label label9;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal System.Windows.Forms.ComboBox jobl_e;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox jobl_b;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox depts_b;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.CheckBox include_leave;
        private System.Windows.Forms.Button btnConfig;
        internal System.Windows.Forms.CheckBox cindt_check;
    }
}