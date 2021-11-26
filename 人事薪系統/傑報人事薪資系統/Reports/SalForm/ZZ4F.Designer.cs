/* ======================================================================================================
 * 功能名稱：薪資異動通知單
 * 功能代號：ZZ4F
 * 功能路徑：報表列印 > 薪資 > 薪資異動通知單
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4F.Designer.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/04    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/04
 */

namespace JBHR.Reports.SalForm
{
    partial class ZZ4F
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
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.note1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.note2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.note4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.note3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.note5 = new System.Windows.Forms.TextBox();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.send_time = new System.Windows.Forms.DateTimePicker();
            this.send_date = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.ck_file = new System.Windows.Forms.CheckBox();
            this.ck_dispatch = new System.Windows.Forms.CheckBox();
            this.sendmail = new System.Windows.Forms.CheckBox();
            this.ttscode = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.test_pwd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.test_email = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1073;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1072;
            this.label6.Text = "員工編號";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 10);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 2;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 1071;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 10);
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
            this.label7.Location = new System.Drawing.Point(40, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1070;
            this.label7.Text = "編制部門";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 89);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 7;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1076;
            this.label2.Text = "人事異動日";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(103, 118);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 8;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(26, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1078;
            this.label1.Text = "薪資異動日";
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "薪資異動通知單",
            "人事通知單"});
            this.report_type.Location = new System.Drawing.Point(103, 342);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(180, 20);
            this.report_type.TabIndex = 14;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(39, 345);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 1083;
            this.label30.Text = "報表種類";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(253, 418);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 15;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            this.ExportExcel.Visible = false;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(256, 450);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 17;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(104, 450);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 16;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(66, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1085;
            this.label10.Text = "字號";
            // 
            // note1
            // 
            this.note1.Location = new System.Drawing.Point(103, 147);
            this.note1.Name = "note1";
            this.note1.Size = new System.Drawing.Size(200, 22);
            this.note1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(66, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1087;
            this.label3.Text = "事由";
            // 
            // note2
            // 
            this.note2.Location = new System.Drawing.Point(103, 174);
            this.note2.Name = "note2";
            this.note2.Size = new System.Drawing.Size(200, 22);
            this.note2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(61, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1091;
            this.label4.Text = "備註2";
            // 
            // note4
            // 
            this.note4.Location = new System.Drawing.Point(103, 230);
            this.note4.Name = "note4";
            this.note4.Size = new System.Drawing.Size(300, 22);
            this.note4.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(61, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 1089;
            this.label5.Text = "備註1";
            // 
            // note3
            // 
            this.note3.Location = new System.Drawing.Point(103, 203);
            this.note3.Name = "note3";
            this.note3.Size = new System.Drawing.Size(300, 22);
            this.note3.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(61, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 1093;
            this.label8.Text = "備註3";
            // 
            // note5
            // 
            this.note5.Location = new System.Drawing.Point(103, 259);
            this.note5.Name = "note5";
            this.note5.Size = new System.Drawing.Size(300, 22);
            this.note5.TabIndex = 13;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "BaseDS";
            this.baseDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
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
            this.nobr_b.Location = new System.Drawing.Point(104, 61);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 5;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 61);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 6;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 35);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 4;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(241, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1097;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(103, 35);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 3;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(66, 39);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1096;
            this.label23.Text = "員別";
            // 
            // send_time
            // 
            this.send_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.send_time.Location = new System.Drawing.Point(222, 368);
            this.send_time.Name = "send_time";
            this.send_time.ShowUpDown = true;
            this.send_time.Size = new System.Drawing.Size(101, 22);
            this.send_time.TabIndex = 1123;
            // 
            // send_date
            // 
            this.send_date.Location = new System.Drawing.Point(103, 368);
            this.send_date.Name = "send_date";
            this.send_date.Size = new System.Drawing.Size(112, 22);
            this.send_date.TabIndex = 1122;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(10, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 1121;
            this.label13.Text = "通知傳送時間";
            // 
            // ck_file
            // 
            this.ck_file.AutoSize = true;
            this.ck_file.Location = new System.Drawing.Point(253, 396);
            this.ck_file.Name = "ck_file";
            this.ck_file.Size = new System.Drawing.Size(120, 16);
            this.ck_file.TabIndex = 1127;
            this.ck_file.Text = "薪資異動測試發送";
            this.ck_file.UseVisualStyleBackColor = true;
            // 
            // ck_dispatch
            // 
            this.ck_dispatch.AutoSize = true;
            this.ck_dispatch.Location = new System.Drawing.Point(289, 344);
            this.ck_dispatch.Name = "ck_dispatch";
            this.ck_dispatch.Size = new System.Drawing.Size(84, 16);
            this.ck_dispatch.TabIndex = 1126;
            this.ck_dispatch.Text = "含派外人員";
            this.ck_dispatch.UseVisualStyleBackColor = true;
            this.ck_dispatch.Visible = false;
            // 
            // sendmail
            // 
            this.sendmail.AutoSize = true;
            this.sendmail.Location = new System.Drawing.Point(103, 418);
            this.sendmail.Name = "sendmail";
            this.sendmail.Size = new System.Drawing.Size(96, 16);
            this.sendmail.TabIndex = 1125;
            this.sendmail.Text = "薪資異動傳送";
            this.sendmail.UseVisualStyleBackColor = true;
            // 
            // ttscode
            // 
            this.ttscode.AutoSize = true;
            this.ttscode.Location = new System.Drawing.Point(103, 396);
            this.ttscode.Name = "ttscode";
            this.ttscode.Size = new System.Drawing.Size(120, 16);
            this.ttscode.TabIndex = 1124;
            this.ttscode.Text = "取得人事異動資料";
            this.ttscode.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(61, 317);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1131;
            this.label11.Text = "密碼";
            // 
            // test_pwd
            // 
            this.test_pwd.Location = new System.Drawing.Point(103, 314);
            this.test_pwd.Name = "test_pwd";
            this.test_pwd.PasswordChar = '*';
            this.test_pwd.Size = new System.Drawing.Size(100, 22);
            this.test_pwd.TabIndex = 1129;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(4, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 1130;
            this.label12.Text = "測試發送Email";
            // 
            // test_email
            // 
            this.test_email.Location = new System.Drawing.Point(103, 287);
            this.test_email.Name = "test_email";
            this.test_email.Size = new System.Drawing.Size(300, 22);
            this.test_email.TabIndex = 1128;
            // 
            // ZZ4F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 482);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.test_pwd);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.test_email);
            this.Controls.Add(this.ck_file);
            this.Controls.Add(this.ck_dispatch);
            this.Controls.Add(this.sendmail);
            this.Controls.Add(this.ttscode);
            this.Controls.Add(this.send_time);
            this.Controls.Add(this.send_date);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.note5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.note4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.note3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.note2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.note1);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ4F";
            this.Text = "薪資異動通知單";
            this.Load += new System.EventHandler(this.ZZ4F_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox note1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox note2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox note4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox note3;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox note5;
        private JBHR.Sal.BaseDS baseDS;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker send_time;
        private System.Windows.Forms.DateTimePicker send_date;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.CheckBox ck_file;
        internal System.Windows.Forms.CheckBox ck_dispatch;
        internal System.Windows.Forms.CheckBox sendmail;
        internal System.Windows.Forms.CheckBox ttscode;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox test_pwd;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox test_email;
    }
}