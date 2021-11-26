/* ======================================================================================================
 * 功能名稱：部門人力統計表
 * 功能代號：ZZ1E
 * 功能路徑：報表列印 > 人事 > 部門人力統計表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1E_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/11    Daniel Chih    Ver 1.0.01     1. 增加條件欄位：【年齡】、【年資】並篩選掉不在區間內的資料
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/11
 */

namespace JBHR.Reports.EmpForm
{
    partial class ZZ1E
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
            this.date_e = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.date_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.work_e = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.work_b = new System.Windows.Forms.ComboBox();
            this.job_e = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.job_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sex_e = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sex_b = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rotet_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rotet_b = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.age_e = new JBControls.TextBox();
            this.age_to_label = new System.Windows.Forms.Label();
            this.age_b = new JBControls.TextBox();
            this.age_title_label = new System.Windows.Forms.Label();
            this.seniority_e = new JBControls.TextBox();
            this.seniority_to_label = new System.Windows.Forms.Label();
            this.seniority_b = new JBControls.TextBox();
            this.seniority_title_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(271, 181);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 16;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(233, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 196;
            this.label4.Text = "至";
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "部門人力職等統計表",
            "v各月份人數統計表",
            "各月份人數增減統計表",
            "v部門人力職稱性別統計表",
            "v成本部門人力職稱統計表"});
            this.report_type.Location = new System.Drawing.Point(95, 266);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(180, 20);
            this.report_type.TabIndex = 17;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(32, 269);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 195;
            this.label30.Text = "報表種類";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(95, 301);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 18;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LeaveForm.Location = new System.Drawing.Point(252, 329);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 20;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(100, 329);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 19;
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
            this.date_b.Location = new System.Drawing.Point(95, 181);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 15;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(32, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 193;
            this.label3.Text = "起迄日期";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(271, 154);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 14;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(233, 159);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 192;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(95, 154);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 13;
            this.comp_b.ValueMember = "comp";
            // 
            // work_e
            // 
            this.work_e.DisplayMember = "work_addr";
            this.work_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.work_e.FormattingEnabled = true;
            this.work_e.Location = new System.Drawing.Point(271, 129);
            this.work_e.Name = "work_e";
            this.work_e.Size = new System.Drawing.Size(130, 20);
            this.work_e.TabIndex = 12;
            this.work_e.ValueMember = "work_code";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(233, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 191;
            this.label19.Text = "至";
            // 
            // work_b
            // 
            this.work_b.DisplayMember = "work_addr";
            this.work_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.work_b.FormattingEnabled = true;
            this.work_b.Location = new System.Drawing.Point(95, 129);
            this.work_b.Name = "work_b";
            this.work_b.Size = new System.Drawing.Size(130, 20);
            this.work_b.TabIndex = 11;
            this.work_b.ValueMember = "work_code";
            // 
            // job_e
            // 
            this.job_e.DisplayMember = "job_name";
            this.job_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.job_e.FormattingEnabled = true;
            this.job_e.Location = new System.Drawing.Point(271, 104);
            this.job_e.Name = "job_e";
            this.job_e.Size = new System.Drawing.Size(130, 20);
            this.job_e.TabIndex = 10;
            this.job_e.ValueMember = "job";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(233, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 190;
            this.label18.Text = "至";
            // 
            // job_b
            // 
            this.job_b.DisplayMember = "job_name";
            this.job_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.job_b.FormattingEnabled = true;
            this.job_b.Location = new System.Drawing.Point(95, 104);
            this.job_b.Name = "job_b";
            this.job_b.Size = new System.Drawing.Size(130, 20);
            this.job_b.TabIndex = 9;
            this.job_b.ValueMember = "job";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(271, 31);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(233, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 188;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(95, 31);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 3;
            this.dept_b.ValueMember = "d_no";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(271, 6);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 2;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(233, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 187;
            this.label13.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(95, 6);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 1;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(59, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 186;
            this.label12.Text = "公司";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(43, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 185;
            this.label11.Text = "工作地";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(58, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 184;
            this.label10.Text = "職稱";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(31, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 182;
            this.label7.Text = "編制部門";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(59, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 181;
            this.label5.Text = "員別";
            // 
            // sex_e
            // 
            this.sex_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sex_e.FormattingEnabled = true;
            this.sex_e.Items.AddRange(new object[] {
            "女",
            "男"});
            this.sex_e.Location = new System.Drawing.Point(271, 79);
            this.sex_e.Name = "sex_e";
            this.sex_e.Size = new System.Drawing.Size(130, 20);
            this.sex_e.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(233, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "至";
            // 
            // sex_b
            // 
            this.sex_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sex_b.FormattingEnabled = true;
            this.sex_b.Items.AddRange(new object[] {
            "女",
            "男"});
            this.sex_b.Location = new System.Drawing.Point(95, 79);
            this.sex_b.Name = "sex_b";
            this.sex_b.Size = new System.Drawing.Size(130, 20);
            this.sex_b.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(59, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 199;
            this.label2.Text = "性別";
            // 
            // rotet_e
            // 
            this.rotet_e.DisplayMember = "rotetname";
            this.rotet_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotet_e.FormattingEnabled = true;
            this.rotet_e.Location = new System.Drawing.Point(271, 55);
            this.rotet_e.Name = "rotet_e";
            this.rotet_e.Size = new System.Drawing.Size(130, 20);
            this.rotet_e.TabIndex = 6;
            this.rotet_e.ValueMember = "rotet";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(233, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 204;
            this.label16.Text = "至";
            // 
            // rotet_b
            // 
            this.rotet_b.DisplayMember = "rotetname";
            this.rotet_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotet_b.FormattingEnabled = true;
            this.rotet_b.Location = new System.Drawing.Point(95, 55);
            this.rotet_b.Name = "rotet_b";
            this.rotet_b.Size = new System.Drawing.Size(130, 20);
            this.rotet_b.TabIndex = 5;
            this.rotet_b.ValueMember = "rotet";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(59, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 203;
            this.label8.Text = "班別";
            // 
            // age_e
            // 
            this.age_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.age_e.CaptionLabel = null;
            this.age_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.age_e.DecimalPlace = 2;
            this.age_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.age_e.IsEmpty = false;
            this.age_e.Location = new System.Drawing.Point(270, 210);
            this.age_e.Mask = "";
            this.age_e.MaxLength = -1;
            this.age_e.Name = "age_e";
            this.age_e.PasswordChar = '\0';
            this.age_e.ReadOnly = false;
            this.age_e.ShowCalendarButton = true;
            this.age_e.Size = new System.Drawing.Size(30, 23);
            this.age_e.TabIndex = 206;
            this.age_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // age_to_label
            // 
            this.age_to_label.AutoSize = true;
            this.age_to_label.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.age_to_label.Location = new System.Drawing.Point(233, 214);
            this.age_to_label.Name = "age_to_label";
            this.age_to_label.Size = new System.Drawing.Size(21, 13);
            this.age_to_label.TabIndex = 212;
            this.age_to_label.Text = "至";
            // 
            // age_b
            // 
            this.age_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.age_b.CaptionLabel = null;
            this.age_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.age_b.DecimalPlace = 2;
            this.age_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.age_b.IsEmpty = false;
            this.age_b.Location = new System.Drawing.Point(95, 210);
            this.age_b.Mask = "";
            this.age_b.MaxLength = -1;
            this.age_b.Name = "age_b";
            this.age_b.PasswordChar = '\0';
            this.age_b.ReadOnly = false;
            this.age_b.ShowCalendarButton = true;
            this.age_b.Size = new System.Drawing.Size(30, 23);
            this.age_b.TabIndex = 205;
            this.age_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // age_title_label
            // 
            this.age_title_label.AutoSize = true;
            this.age_title_label.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.age_title_label.Location = new System.Drawing.Point(59, 214);
            this.age_title_label.Name = "age_title_label";
            this.age_title_label.Size = new System.Drawing.Size(35, 13);
            this.age_title_label.TabIndex = 211;
            this.age_title_label.Text = "年齡";
            // 
            // seniority_e
            // 
            this.seniority_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seniority_e.CaptionLabel = null;
            this.seniority_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seniority_e.DecimalPlace = 2;
            this.seniority_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seniority_e.IsEmpty = false;
            this.seniority_e.Location = new System.Drawing.Point(270, 237);
            this.seniority_e.Mask = "";
            this.seniority_e.MaxLength = -1;
            this.seniority_e.Name = "seniority_e";
            this.seniority_e.PasswordChar = '\0';
            this.seniority_e.ReadOnly = false;
            this.seniority_e.ShowCalendarButton = true;
            this.seniority_e.Size = new System.Drawing.Size(30, 23);
            this.seniority_e.TabIndex = 208;
            this.seniority_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // seniority_to_label
            // 
            this.seniority_to_label.AutoSize = true;
            this.seniority_to_label.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seniority_to_label.Location = new System.Drawing.Point(233, 241);
            this.seniority_to_label.Name = "seniority_to_label";
            this.seniority_to_label.Size = new System.Drawing.Size(21, 13);
            this.seniority_to_label.TabIndex = 210;
            this.seniority_to_label.Text = "至";
            // 
            // seniority_b
            // 
            this.seniority_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seniority_b.CaptionLabel = null;
            this.seniority_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seniority_b.DecimalPlace = 2;
            this.seniority_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seniority_b.IsEmpty = false;
            this.seniority_b.Location = new System.Drawing.Point(95, 237);
            this.seniority_b.Mask = "";
            this.seniority_b.MaxLength = -1;
            this.seniority_b.Name = "seniority_b";
            this.seniority_b.PasswordChar = '\0';
            this.seniority_b.ReadOnly = false;
            this.seniority_b.ShowCalendarButton = true;
            this.seniority_b.Size = new System.Drawing.Size(30, 23);
            this.seniority_b.TabIndex = 207;
            this.seniority_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // seniority_title_label
            // 
            this.seniority_title_label.AutoSize = true;
            this.seniority_title_label.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seniority_title_label.Location = new System.Drawing.Point(59, 241);
            this.seniority_title_label.Name = "seniority_title_label";
            this.seniority_title_label.Size = new System.Drawing.Size(35, 13);
            this.seniority_title_label.TabIndex = 209;
            this.seniority_title_label.Text = "年資";
            // 
            // ZZ1E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 367);
            this.Controls.Add(this.age_e);
            this.Controls.Add(this.age_to_label);
            this.Controls.Add(this.age_b);
            this.Controls.Add(this.age_title_label);
            this.Controls.Add(this.seniority_e);
            this.Controls.Add(this.seniority_to_label);
            this.Controls.Add(this.seniority_b);
            this.Controls.Add(this.seniority_title_label);
            this.Controls.Add(this.rotet_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.rotet_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sex_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sex_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.work_e);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.work_b);
            this.Controls.Add(this.job_e);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.job_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ1E";
            this.Text = "部門人力統計表";
            this.Load += new System.EventHandler(this.ZZ1E_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        internal System.Windows.Forms.ComboBox work_e;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox work_b;
        internal System.Windows.Forms.ComboBox job_e;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox job_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox sex_e;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox sex_b;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox rotet_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox rotet_b;
        private System.Windows.Forms.Label label8;
        internal JBControls.TextBox age_e;
        private System.Windows.Forms.Label age_to_label;
        internal JBControls.TextBox age_b;
        private System.Windows.Forms.Label age_title_label;
        internal JBControls.TextBox seniority_e;
        private System.Windows.Forms.Label seniority_to_label;
        internal JBControls.TextBox seniority_b;
        private System.Windows.Forms.Label seniority_title_label;
    }
}