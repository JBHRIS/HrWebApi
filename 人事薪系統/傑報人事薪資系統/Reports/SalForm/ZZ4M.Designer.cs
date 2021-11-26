/* ======================================================================================================
 * 功能名稱：扣繳稅額繳款書
 * 功能代號：ZZ4M
 * 功能路徑：報表列印 > 薪資 > 扣繳稅額繳款書
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4M.Designer.cs
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
    partial class ZZ4M
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
            this.label20 = new System.Windows.Forms.Label();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.bnLeave = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.year_b = new JBControls.TextBox();
            this.month_b = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.seq_b = new JBControls.TextBox();
            this.seq_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.year_e = new JBControls.TextBox();
            this.month_e = new JBControls.TextBox();
            this.datet_e = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datet_b = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(252, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1153;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(50, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1152;
            this.label6.Text = "員工編號";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            //this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(290, 32);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(252, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 1151;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            //this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(114, 32);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 3;
            this.dept_b.ValueMember = "d_no";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(50, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1150;
            this.label7.Text = "編制部門";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(114, 174);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 14;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(11, 178);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 13);
            this.label20.TabIndex = 1155;
            this.label20.Text = "健保在保截止日";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            //this.empcd_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(290, 59);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 6;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(252, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 1159;
            this.label13.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            //this.empcd_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(114, 59);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 5;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(78, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1158;
            this.label5.Text = "員別";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(114, 208);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 16;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // bnLeave
            // 
            this.bnLeave.Location = new System.Drawing.Point(271, 234);
            this.bnLeave.Name = "bnLeave";
            this.bnLeave.Size = new System.Drawing.Size(75, 23);
            this.bnLeave.TabIndex = 18;
            this.bnLeave.Text = "離開";
            this.bnLeave.UseVisualStyleBackColor = true;
            this.bnLeave.Click += new System.EventHandler(this.bnLeave_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(119, 234);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 17;
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
            this.nobr_b.Location = new System.Drawing.Point(114, 84);
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
            this.nobr_e.Location = new System.Drawing.Point(290, 84);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 8;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(252, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 1165;
            this.label22.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            //this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(290, 6);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 2;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            //this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(114, 6);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1;
            this.comp_b.ValueMember = "comp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(78, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 1164;
            this.label12.Text = "公司";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(50, 115);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1148;
            this.label29.Text = "發放年月";
            // 
            // year_b
            // 
            this.year_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year_b.CaptionLabel = null;
            this.year_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year_b.DecimalPlace = 2;
            this.year_b.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year_b.IsEmpty = false;
            this.year_b.Location = new System.Drawing.Point(114, 111);
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
            // month_b
            // 
            this.month_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_b.CaptionLabel = null;
            this.month_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_b.DecimalPlace = 2;
            this.month_b.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_b.IsEmpty = false;
            this.month_b.Location = new System.Drawing.Point(146, 111);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(177, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1149;
            this.label2.Text = "期別";
            // 
            // seq_b
            // 
            this.seq_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_b.CaptionLabel = null;
            this.seq_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_b.DecimalPlace = 2;
            this.seq_b.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_b.IsEmpty = false;
            this.seq_b.Location = new System.Drawing.Point(213, 112);
            this.seq_b.Mask = "";
            this.seq_b.MaxLength = -1;
            this.seq_b.Name = "seq_b";
            this.seq_b.PasswordChar = '\0';
            this.seq_b.ReadOnly = false;
            this.seq_b.ShowCalendarButton = true;
            this.seq_b.Size = new System.Drawing.Size(20, 23);
            this.seq_b.TabIndex = 11;
            this.seq_b.ValidType = JBControls.TextBox.EValidType.String;
            this.seq_b.Validated += new System.EventHandler(this.seq_b_Validated);
            // 
            // seq_e
            // 
            this.seq_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_e.CaptionLabel = null;
            this.seq_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_e.DecimalPlace = 2;
            this.seq_e.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_e.IsEmpty = false;
            this.seq_e.Location = new System.Drawing.Point(388, 111);
            this.seq_e.Mask = "";
            this.seq_e.MaxLength = -1;
            this.seq_e.Name = "seq_e";
            this.seq_e.PasswordChar = '\0';
            this.seq_e.ReadOnly = false;
            this.seq_e.ShowCalendarButton = true;
            this.seq_e.Size = new System.Drawing.Size(20, 23);
            this.seq_e.TabIndex = 12;
            this.seq_e.ValidType = JBControls.TextBox.EValidType.String;
            this.seq_e.Validated += new System.EventHandler(this.seq_e_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(352, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1169;
            this.label1.Text = "期別";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(252, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 1172;
            this.label4.Text = "至";
            // 
            // year_e
            // 
            this.year_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year_e.CaptionLabel = null;
            this.year_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year_e.DecimalPlace = 2;
            this.year_e.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year_e.IsEmpty = false;
            this.year_e.Location = new System.Drawing.Point(290, 111);
            this.year_e.Mask = "";
            this.year_e.MaxLength = -1;
            this.year_e.Name = "year_e";
            this.year_e.PasswordChar = '\0';
            this.year_e.ReadOnly = false;
            this.year_e.ShowCalendarButton = true;
            this.year_e.Size = new System.Drawing.Size(30, 23);
            this.year_e.TabIndex = 1170;
            this.year_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.year_e.Validated += new System.EventHandler(this.year_e_Validated);
            // 
            // month_e
            // 
            this.month_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_e.CaptionLabel = null;
            this.month_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_e.DecimalPlace = 2;
            this.month_e.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_e.IsEmpty = false;
            this.month_e.Location = new System.Drawing.Point(321, 111);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.ShowCalendarButton = true;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 1171;
            this.month_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_e.Validated += new System.EventHandler(this.month_e_Validated);
            // 
            // datet_e
            // 
            this.datet_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.datet_e.CaptionLabel = null;
            this.datet_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.datet_e.DecimalPlace = 2;
            this.datet_e.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.datet_e.IsEmpty = false;
            this.datet_e.Location = new System.Drawing.Point(291, 143);
            this.datet_e.Mask = "0000/00/00";
            this.datet_e.MaxLength = -1;
            this.datet_e.Name = "datet_e";
            this.datet_e.PasswordChar = '\0';
            this.datet_e.ReadOnly = false;
            this.datet_e.ShowCalendarButton = true;
            this.datet_e.Size = new System.Drawing.Size(80, 23);
            this.datet_e.TabIndex = 1259;
            this.datet_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(253, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 1261;
            this.label3.Text = "至";
            // 
            // datet_b
            // 
            this.datet_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.datet_b.CaptionLabel = null;
            this.datet_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.datet_b.DecimalPlace = 2;
            this.datet_b.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.datet_b.IsEmpty = false;
            this.datet_b.Location = new System.Drawing.Point(115, 143);
            this.datet_b.Mask = "0000/00/00";
            this.datet_b.MaxLength = -1;
            this.datet_b.Name = "datet_b";
            this.datet_b.PasswordChar = '\0';
            this.datet_b.ReadOnly = false;
            this.datet_b.ShowCalendarButton = true;
            this.datet_b.Size = new System.Drawing.Size(80, 23);
            this.datet_b.TabIndex = 1258;
            this.datet_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(50, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 1260;
            this.label8.Text = "轉帳日期";
            // 
            // ZZ4M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 275);
            this.Controls.Add(this.datet_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datet_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.year_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seq_e);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.bnLeave);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.seq_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.year_b);
            this.Controls.Add(this.label29);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ4M";
            this.Text = "扣繳稅額繳款書";
            this.Load += new System.EventHandler(this.ZZ4M_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
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
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button bnLeave;
        private System.Windows.Forms.Button Create_Report;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label29;
        internal JBControls.TextBox year_b;
        internal JBControls.TextBox month_b;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox seq_b;
        internal JBControls.TextBox seq_e;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox year_e;
        internal JBControls.TextBox month_e;
        internal JBControls.TextBox datet_e;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox datet_b;
        private System.Windows.Forms.Label label8;
    }
}