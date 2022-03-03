/* ======================================================================================================
 * 功能名稱：各期薪資表
 * 功能代號：ZZ46
 * 功能路徑：報表列印 > 薪資 > 各期薪資表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ46.Designer.cs
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
    partial class ZZ46
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
            this.label3 = new System.Windows.Forms.Label();
            this.seq_e = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.month_e = new JBControls.TextBox();
            this.year_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.seq_b = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.month_b = new JBControls.TextBox();
            this.year_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.work_e = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.work_b = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MedianMon3 = new System.Windows.Forms.RadioButton();
            this.MedianMon2 = new System.Windows.Forms.RadioButton();
            this.MedianMon1 = new System.Windows.Forms.RadioButton();
            this.jobl_e = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.jobl_b = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.date_b.Location = new System.Drawing.Point(104, 197);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 17;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(26, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 1043;
            this.label3.Text = "轉帳截止日";
            // 
            // seq_e
            // 
            this.seq_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_e.CaptionLabel = null;
            this.seq_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_e.DecimalPlace = 2;
            this.seq_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_e.IsEmpty = false;
            this.seq_e.Location = new System.Drawing.Point(379, 167);
            this.seq_e.Mask = "";
            this.seq_e.MaxLength = -1;
            this.seq_e.Name = "seq_e";
            this.seq_e.PasswordChar = '\0';
            this.seq_e.ReadOnly = false;
            this.seq_e.ShowCalendarButton = true;
            this.seq_e.Size = new System.Drawing.Size(20, 23);
            this.seq_e.TabIndex = 16;
            this.seq_e.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(343, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1042;
            this.label4.Text = "期別";
            // 
            // month_e
            // 
            this.month_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_e.CaptionLabel = null;
            this.month_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_e.DecimalPlace = 2;
            this.month_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_e.IsEmpty = false;
            this.month_e.Location = new System.Drawing.Point(311, 167);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.ShowCalendarButton = true;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 15;
            this.month_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_e.Validated += new System.EventHandler(this.month_e_Validated);
            // 
            // year_e
            // 
            this.year_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year_e.CaptionLabel = null;
            this.year_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year_e.DecimalPlace = 2;
            this.year_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year_e.IsEmpty = false;
            this.year_e.Location = new System.Drawing.Point(280, 167);
            this.year_e.Mask = "";
            this.year_e.MaxLength = -1;
            this.year_e.Name = "year_e";
            this.year_e.PasswordChar = '\0';
            this.year_e.ReadOnly = false;
            this.year_e.ShowCalendarButton = true;
            this.year_e.Size = new System.Drawing.Size(30, 23);
            this.year_e.TabIndex = 14;
            this.year_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.year_e.Validated += new System.EventHandler(this.year_e_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(242, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1041;
            this.label1.Text = "至";
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "各期明細表",
            "部門月份彙總表",
            "年度薪資調節表",
            "年度扣繳清冊",
            "公司別各月份薪資匯總表",
            "公司薪資匯總表",
            "月份別公司薪資匯總表",
            "月份別薪資匯總表",
            "非主管平均及中位數薪資"});
            this.report_type.Location = new System.Drawing.Point(104, 296);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(180, 20);
            this.report_type.TabIndex = 22;
            this.report_type.SelectedIndexChanged += new System.EventHandler(this.report_type_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(40, 299);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 1040;
            this.label30.Text = "報表種類";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 335);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 23;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 364);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 25;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 364);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 24;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 221);
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
            this.label24.Location = new System.Drawing.Point(40, 234);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 13);
            this.label24.TabIndex = 1039;
            this.label24.Text = "資料內容";
            // 
            // seq_b
            // 
            this.seq_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_b.CaptionLabel = null;
            this.seq_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_b.DecimalPlace = 2;
            this.seq_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_b.IsEmpty = false;
            this.seq_b.Location = new System.Drawing.Point(203, 167);
            this.seq_b.Mask = "";
            this.seq_b.MaxLength = -1;
            this.seq_b.Name = "seq_b";
            this.seq_b.PasswordChar = '\0';
            this.seq_b.ReadOnly = false;
            this.seq_b.ShowCalendarButton = true;
            this.seq_b.Size = new System.Drawing.Size(20, 23);
            this.seq_b.TabIndex = 13;
            this.seq_b.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(167, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1038;
            this.label2.Text = "期別";
            // 
            // month_b
            // 
            this.month_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_b.CaptionLabel = null;
            this.month_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_b.DecimalPlace = 2;
            this.month_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_b.IsEmpty = false;
            this.month_b.Location = new System.Drawing.Point(135, 167);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.ShowCalendarButton = true;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 12;
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
            this.year_b.Location = new System.Drawing.Point(104, 167);
            this.year_b.Mask = "";
            this.year_b.MaxLength = -1;
            this.year_b.Name = "year_b";
            this.year_b.PasswordChar = '\0';
            this.year_b.ReadOnly = false;
            this.year_b.ShowCalendarButton = true;
            this.year_b.Size = new System.Drawing.Size(30, 23);
            this.year_b.TabIndex = 11;
            this.year_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 171);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1037;
            this.label29.Text = "發放年月";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(242, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 1036;
            this.label22.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 60);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 6;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 60);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 5;
            this.comp_b.ValueMember = "comp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(68, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 1035;
            this.label12.Text = "公司";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 35);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 1034;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 35);
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
            this.label7.Location = new System.Drawing.Point(40, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1033;
            this.label7.Text = "編制部門";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1032;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1031;
            this.label6.Text = "員工編號";
            // 
            // work_e
            // 
            this.work_e.DisplayMember = "salname";
            this.work_e.FormattingEnabled = true;
            this.work_e.Location = new System.Drawing.Point(280, 88);
            this.work_e.Name = "work_e";
            this.work_e.Size = new System.Drawing.Size(130, 20);
            this.work_e.TabIndex = 8;
            this.work_e.ValueMember = "saladr";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(242, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 1047;
            this.label5.Text = "至";
            // 
            // work_b
            // 
            this.work_b.DisplayMember = "salname";
            this.work_b.FormattingEnabled = true;
            this.work_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.work_b.Location = new System.Drawing.Point(104, 88);
            this.work_b.Name = "work_b";
            this.work_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.work_b.Size = new System.Drawing.Size(130, 20);
            this.work_b.TabIndex = 7;
            this.work_b.ValueMember = "saladr";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(40, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1046;
            this.label8.Text = "資料群組";
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
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 140);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 10;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(242, 143);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1051;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 140);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 9;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(67, 144);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1050;
            this.label23.Text = "員別";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(25, 270);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 1053;
            this.label20.Text = "中位數內容";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MedianMon3);
            this.groupBox3.Controls.Add(this.MedianMon2);
            this.groupBox3.Controls.Add(this.MedianMon1);
            this.groupBox3.Location = new System.Drawing.Point(104, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 35);
            this.groupBox3.TabIndex = 1052;
            this.groupBox3.TabStop = false;
            // 
            // MedianMon3
            // 
            this.MedianMon3.AutoSize = true;
            this.MedianMon3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MedianMon3.Location = new System.Drawing.Point(134, 12);
            this.MedianMon3.Name = "MedianMon3";
            this.MedianMon3.Size = new System.Drawing.Size(88, 17);
            this.MedianMon3.TabIndex = 29;
            this.MedianMon3.Text = "未滿6個月";
            this.MedianMon3.UseVisualStyleBackColor = true;
            // 
            // MedianMon2
            // 
            this.MedianMon2.AutoSize = true;
            this.MedianMon2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MedianMon2.Location = new System.Drawing.Point(60, 12);
            this.MedianMon2.Name = "MedianMon2";
            this.MedianMon2.Size = new System.Drawing.Size(74, 17);
            this.MedianMon2.TabIndex = 28;
            this.MedianMon2.Text = "滿6個月";
            this.MedianMon2.UseVisualStyleBackColor = true;
            // 
            // MedianMon1
            // 
            this.MedianMon1.AutoSize = true;
            this.MedianMon1.Checked = true;
            this.MedianMon1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MedianMon1.Location = new System.Drawing.Point(6, 12);
            this.MedianMon1.Name = "MedianMon1";
            this.MedianMon1.Size = new System.Drawing.Size(53, 17);
            this.MedianMon1.TabIndex = 27;
            this.MedianMon1.TabStop = true;
            this.MedianMon1.Text = "全部";
            this.MedianMon1.UseVisualStyleBackColor = true;
            // 
            // jobl_e
            // 
            this.jobl_e.DisplayMember = "job_name";
            this.jobl_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_e.FormattingEnabled = true;
            this.jobl_e.Location = new System.Drawing.Point(280, 115);
            this.jobl_e.Name = "jobl_e";
            this.jobl_e.Size = new System.Drawing.Size(130, 20);
            this.jobl_e.TabIndex = 1157;
            this.jobl_e.ValueMember = "jobl";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(242, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 1159;
            this.label18.Text = "至";
            // 
            // jobl_b
            // 
            this.jobl_b.DisplayMember = "job_name";
            this.jobl_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_b.FormattingEnabled = true;
            this.jobl_b.Location = new System.Drawing.Point(104, 114);
            this.jobl_b.Name = "jobl_b";
            this.jobl_b.Size = new System.Drawing.Size(130, 20);
            this.jobl_b.TabIndex = 1156;
            this.jobl_b.ValueMember = "jobl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(67, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1158;
            this.label10.Text = "職等";
            // 
            // ZZ46
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 404);
            this.Controls.Add(this.jobl_e);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.jobl_b);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.work_e);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.work_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seq_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.year_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.seq_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.year_b);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ46";
            this.Text = "各期薪資報表";
            this.Load += new System.EventHandler(this.ZZ46_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox seq_e;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox month_e;
        internal JBControls.TextBox year_e;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label24;
        internal JBControls.TextBox seq_b;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox month_b;
        internal JBControls.TextBox year_b;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox work_e;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox work_b;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton MedianMon3;
        internal System.Windows.Forms.RadioButton MedianMon2;
        internal System.Windows.Forms.RadioButton MedianMon1;
        internal System.Windows.Forms.ComboBox jobl_e;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox jobl_b;
        private System.Windows.Forms.Label label10;
    }
}