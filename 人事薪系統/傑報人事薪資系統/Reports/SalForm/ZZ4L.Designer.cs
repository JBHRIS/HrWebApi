﻿/* ======================================================================================================
 * 功能名稱：中夜津貼明細表
 * 功能代號：ZZ4L
 * 功能路徑：報表列印 > 薪資 > 中夜津貼明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4L.Designer.cs
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
    partial class ZZ4L
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
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.yymm_e = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yymm_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.month_e = new JBControls.TextBox();
            this.month_b = new JBControls.TextBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 216);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 18;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 245);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 20;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 245);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 19;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1097;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1096;
            this.label6.Text = "員工編號";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            //this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.label15.TabIndex = 1095;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            //this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.label7.TabIndex = 1094;
            this.label7.Text = "編制部門";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(280, 119);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 12;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(242, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 13);
            this.label17.TabIndex = 1101;
            this.label17.Text = "至";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 119);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 11;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(40, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 1100;
            this.label20.Text = "出勤日期";
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "明細",
            "彙總"});
            this.report_type.Location = new System.Drawing.Point(104, 187);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(180, 20);
            this.report_type.TabIndex = 17;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(40, 190);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 1105;
            this.label30.Text = "報表種類";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 35);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 15;
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
            this.type_data2.TabIndex = 14;
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
            this.type_data4.TabIndex = 16;
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
            this.type_data1.TabIndex = 13;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1104;
            this.label2.Text = "資料內容";
            // 
            // yymm_e
            // 
            this.yymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_e.CaptionLabel = null;
            this.yymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_e.DecimalPlace = 2;
            this.yymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_e.IsEmpty = false;
            this.yymm_e.Location = new System.Drawing.Point(280, 89);
            this.yymm_e.Mask = "";
            this.yymm_e.MaxLength = -1;
            this.yymm_e.Name = "yymm_e";
            this.yymm_e.PasswordChar = '\0';
            this.yymm_e.ReadOnly = false;
            this.yymm_e.Size = new System.Drawing.Size(30, 23);
            this.yymm_e.TabIndex = 9;
            this.yymm_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.yymm_e.Validated += new System.EventHandler(this.yymm_e_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(242, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 1109;
            this.label9.Text = "至";
            // 
            // yymm_b
            // 
            this.yymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_b.CaptionLabel = null;
            this.yymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_b.DecimalPlace = 2;
            this.yymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_b.IsEmpty = false;
            this.yymm_b.Location = new System.Drawing.Point(104, 89);
            this.yymm_b.Mask = "";
            this.yymm_b.MaxLength = -1;
            this.yymm_b.Name = "yymm_b";
            this.yymm_b.PasswordChar = '\0';
            this.yymm_b.ReadOnly = false;
            this.yymm_b.Size = new System.Drawing.Size(30, 23);
            this.yymm_b.TabIndex = 7;
            this.yymm_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.yymm_b.Validated += new System.EventHandler(this.yymm_b_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 94);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1108;
            this.label29.Text = "計薪年月";
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
            this.nobr_b.Location = new System.Drawing.Point(104, 60);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 60);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 6;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // month_e
            // 
            this.month_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_e.CaptionLabel = null;
            this.month_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_e.DecimalPlace = 2;
            this.month_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_e.IsEmpty = false;
            this.month_e.Location = new System.Drawing.Point(311, 89);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 10;
            this.month_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_e.Validated += new System.EventHandler(this.month_e_Validated);
            // 
            // month_b
            // 
            this.month_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_b.CaptionLabel = null;
            this.month_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_b.DecimalPlace = 2;
            this.month_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_b.IsEmpty = false;
            this.month_b.Location = new System.Drawing.Point(135, 89);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 8;
            this.month_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_b.Validated += new System.EventHandler(this.month_b_Validated);
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            //this.empcd_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(281, 33);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 4;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(243, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 1116;
            this.label21.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            //this.empcd_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(105, 33);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 3;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(68, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 1115;
            this.label23.Text = "員別";
            // 
            // ZZ4L
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 295);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.yymm_e);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.yymm_b);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ4L";
            this.Text = "中夜津貼明細表";
            this.Load += new System.EventHandler(this.ZZ4L_Load);
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
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label17;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox yymm_e;
        private System.Windows.Forms.Label label9;
        internal JBControls.TextBox yymm_b;
        private System.Windows.Forms.Label label29;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal JBControls.TextBox month_e;
        internal JBControls.TextBox month_b;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label23;
    }
}