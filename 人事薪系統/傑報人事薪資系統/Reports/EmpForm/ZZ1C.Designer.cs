namespace JBHR.Reports.EmpForm
{
    partial class ZZ1C
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
            this.edu_e = new System.Windows.Forms.ComboBox();
            this.edu_b = new System.Windows.Forms.ComboBox();
            this.only_schl = new System.Windows.Forms.CheckBox();
            this.report_type2 = new System.Windows.Forms.RadioButton();
            this.report_type1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            this.SuspendLayout();
            // 
            // edu_e
            // 
            this.edu_e.DisplayMember = "edudesc";
            this.edu_e.FormattingEnabled = true;
            this.edu_e.Location = new System.Drawing.Point(279, 113);
            this.edu_e.Name = "edu_e";
            this.edu_e.Size = new System.Drawing.Size(130, 20);
            this.edu_e.TabIndex = 10;
            this.edu_e.ValueMember = "educode";
            // 
            // edu_b
            // 
            this.edu_b.DisplayMember = "edudesc";
            this.edu_b.FormattingEnabled = true;
            this.edu_b.Location = new System.Drawing.Point(103, 113);
            this.edu_b.Name = "edu_b";
            this.edu_b.Size = new System.Drawing.Size(130, 20);
            this.edu_b.TabIndex = 9;
            this.edu_b.ValueMember = "educode";
            // 
            // only_schl
            // 
            this.only_schl.AutoSize = true;
            this.only_schl.Checked = true;
            this.only_schl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.only_schl.Location = new System.Drawing.Point(103, 250);
            this.only_schl.Name = "only_schl";
            this.only_schl.Size = new System.Drawing.Size(96, 16);
            this.only_schl.TabIndex = 18;
            this.only_schl.Text = "學歷只取一筆";
            this.only_schl.UseVisualStyleBackColor = true;
            // 
            // report_type2
            // 
            this.report_type2.AutoSize = true;
            this.report_type2.Location = new System.Drawing.Point(61, 13);
            this.report_type2.Name = "report_type2";
            this.report_type2.Size = new System.Drawing.Size(59, 16);
            this.report_type2.TabIndex = 17;
            this.report_type2.Text = "學經歷";
            this.report_type2.UseVisualStyleBackColor = true;
            // 
            // report_type1
            // 
            this.report_type1.AutoSize = true;
            this.report_type1.Checked = true;
            this.report_type1.Location = new System.Drawing.Point(8, 13);
            this.report_type1.Name = "report_type1";
            this.report_type1.Size = new System.Drawing.Size(47, 16);
            this.report_type1.TabIndex = 16;
            this.report_type1.TabStop = true;
            this.report_type1.Text = "學歷";
            this.report_type1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "報表種類";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(103, 278);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 19;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LeaveForm.Location = new System.Drawing.Point(260, 306);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 21;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 306);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 20;
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
            this.groupBox2.Location = new System.Drawing.Point(104, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 35);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 14;
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
            this.type_data2.TabIndex = 13;
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
            this.type_data4.TabIndex = 15;
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
            this.type_data1.TabIndex = 12;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 176);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 201;
            this.label29.Text = "資料內容";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(103, 137);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 11;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(27, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "異動截止日";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(241, 116);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 198;
            this.label21.Text = "至";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(40, 117);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 13);
            this.label22.TabIndex = 197;
            this.label22.Text = "學歷等級";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(279, 88);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 8;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(241, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 196;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(103, 88);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 7;
            this.comp_b.ValueMember = "comp";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 60);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 6;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 192;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 60);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 5;
            this.dept_b.ValueMember = "d_no";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 191;
            this.label14.Text = "至";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(67, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 189;
            this.label12.Text = "公司";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 185;
            this.label7.Text = "編制部門";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 184;
            this.label6.Text = "員工編號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(68, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 183;
            this.label5.Text = "員別";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(104, 34);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 3;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(242, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 190;
            this.label13.Text = "至";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(280, 34);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 4;
            this.empcd_e.ValueMember = "empcd";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.report_type1);
            this.groupBox1.Controls.Add(this.report_type2);
            this.groupBox1.Location = new System.Drawing.Point(103, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 35);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
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
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 2;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // ZZ1C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 346);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edu_e);
            this.Controls.Add(this.edu_b);
            this.Controls.Add(this.only_schl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ1C";
            this.Text = "學經歷資料報表";
            this.Load += new System.EventHandler(this.ZZ1C_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox edu_e;
        internal System.Windows.Forms.ComboBox edu_b;
        internal System.Windows.Forms.CheckBox only_schl;
        internal System.Windows.Forms.RadioButton report_type2;
        internal System.Windows.Forms.RadioButton report_type1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label29;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.GroupBox groupBox1;
        private JBHR.Sal.BaseDS baseDS;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDS salaryDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
    }
}