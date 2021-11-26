namespace JBHR.Reports.AttForm
{
    partial class ZZ25
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_type2 = new System.Windows.Forms.RadioButton();
            this.date_type1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.job_e = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.job_b = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.in_out = new System.Windows.Forms.CheckBox();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.date_n = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.work_e = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.work_b = new System.Windows.Forms.ComboBox();
            this.jobl_e = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.jobl_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.saladr_e = new System.Windows.Forms.ComboBox();
            this.saladr_b = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_type2);
            this.groupBox1.Controls.Add(this.date_type1);
            this.groupBox1.Location = new System.Drawing.Point(104, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 35);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // date_type2
            // 
            this.date_type2.AutoSize = true;
            this.date_type2.Checked = true;
            this.date_type2.Location = new System.Drawing.Point(149, 12);
            this.date_type2.Name = "date_type2";
            this.date_type2.Size = new System.Drawing.Size(95, 16);
            this.date_type2.TabIndex = 25;
            this.date_type2.TabStop = true;
            this.date_type2.Text = "年度統一計算";
            this.date_type2.UseVisualStyleBackColor = true;
            // 
            // date_type1
            // 
            this.date_type1.AutoSize = true;
            this.date_type1.Enabled = false;
            this.date_type1.Location = new System.Drawing.Point(5, 12);
            this.date_type1.Name = "date_type1";
            this.date_type1.Size = new System.Drawing.Size(139, 16);
            this.date_type1.TabIndex = 24;
            this.date_type1.Text = "依勞基法(到職日生效)";
            this.date_type1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(41, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 674;
            this.label8.Text = "資料格式";
            // 
            // job_e
            // 
            this.job_e.DisplayMember = "job_name";
            this.job_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.job_e.FormattingEnabled = true;
            this.job_e.Location = new System.Drawing.Point(280, 84);
            this.job_e.Name = "job_e";
            this.job_e.Size = new System.Drawing.Size(130, 20);
            this.job_e.TabIndex = 8;
            this.job_e.ValueMember = "job";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(242, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 671;
            this.label1.Text = "至";
            // 
            // job_b
            // 
            this.job_b.DisplayMember = "job_name";
            this.job_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.job_b.FormattingEnabled = true;
            this.job_b.Location = new System.Drawing.Point(104, 84);
            this.job_b.Name = "job_b";
            this.job_b.Size = new System.Drawing.Size(130, 20);
            this.job_b.TabIndex = 7;
            this.job_b.ValueMember = "job";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(67, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 670;
            this.label4.Text = "職稱";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Location = new System.Drawing.Point(104, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 35);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // type_data1
            // 
            this.type_data1.AutoSize = true;
            this.type_data1.Checked = true;
            this.type_data1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data1.Location = new System.Drawing.Point(5, 12);
            this.type_data1.Name = "type_data1";
            this.type_data1.Size = new System.Drawing.Size(53, 17);
            this.type_data1.TabIndex = 20;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
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
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 260);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 669;
            this.label29.Text = "資料內容";
            // 
            // in_out
            // 
            this.in_out.AutoSize = true;
            this.in_out.Location = new System.Drawing.Point(102, 362);
            this.in_out.Name = "in_out";
            this.in_out.Size = new System.Drawing.Size(72, 16);
            this.in_out.TabIndex = 27;
            this.in_out.Text = "包含離職";
            this.in_out.UseVisualStyleBackColor = true;
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(221, 362);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 28;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(258, 386);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 30;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(106, 386);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 29;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // report_type
            // 
            this.report_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "員工特休明細表",
            "員工特休彙總表"});
            this.report_type.Location = new System.Drawing.Point(102, 328);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(121, 20);
            this.report_type.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(38, 331);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 668;
            this.label17.Text = "報表種類";
            // 
            // date_n
            // 
            this.date_n.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_n.CaptionLabel = null;
            this.date_n.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_n.DecimalPlace = 2;
            this.date_n.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_n.IsEmpty = false;
            this.date_n.Location = new System.Drawing.Point(319, 188);
            this.date_n.Mask = "0000/00/00";
            this.date_n.MaxLength = -1;
            this.date_n.Name = "date_n";
            this.date_n.PasswordChar = '\0';
            this.date_n.ReadOnly = false;
            this.date_n.Size = new System.Drawing.Size(80, 23);
            this.date_n.TabIndex = 18;
            this.date_n.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(242, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 667;
            this.label3.Text = "特休截止日";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(104, 221);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 19;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(27, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 666;
            this.label2.Text = "異動截止日";
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 188);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 17;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(27, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 665;
            this.label9.Text = "特休開始日";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(242, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 664;
            this.label22.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 134);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 12;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 134);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 11;
            this.comp_b.ValueMember = "comp";
            // 
            // work_e
            // 
            this.work_e.DisplayMember = "work_addr";
            this.work_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.work_e.FormattingEnabled = true;
            this.work_e.Location = new System.Drawing.Point(280, 109);
            this.work_e.Name = "work_e";
            this.work_e.Size = new System.Drawing.Size(130, 20);
            this.work_e.TabIndex = 10;
            this.work_e.ValueMember = "work_code";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(242, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 663;
            this.label19.Text = "至";
            // 
            // work_b
            // 
            this.work_b.DisplayMember = "work_addr";
            this.work_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.work_b.FormattingEnabled = true;
            this.work_b.Location = new System.Drawing.Point(104, 109);
            this.work_b.Name = "work_b";
            this.work_b.Size = new System.Drawing.Size(130, 20);
            this.work_b.TabIndex = 9;
            this.work_b.ValueMember = "work_code";
            // 
            // jobl_e
            // 
            this.jobl_e.DisplayMember = "job_name";
            this.jobl_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_e.FormattingEnabled = true;
            this.jobl_e.Location = new System.Drawing.Point(280, 57);
            this.jobl_e.Name = "jobl_e";
            this.jobl_e.Size = new System.Drawing.Size(130, 20);
            this.jobl_e.TabIndex = 6;
            this.jobl_e.ValueMember = "jobl";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(242, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 662;
            this.label18.Text = "至";
            // 
            // jobl_b
            // 
            this.jobl_b.DisplayMember = "job_name";
            this.jobl_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_b.FormattingEnabled = true;
            this.jobl_b.Location = new System.Drawing.Point(104, 57);
            this.jobl_b.Name = "jobl_b";
            this.jobl_b.Size = new System.Drawing.Size(130, 20);
            this.jobl_b.TabIndex = 5;
            this.jobl_b.ValueMember = "jobl";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 33);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 661;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 33);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 3;
            this.dept_b.ValueMember = "d_no";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(68, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 660;
            this.label12.Text = "公司";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(52, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 659;
            this.label11.Text = "工作地";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(67, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 658;
            this.label10.Text = "職等";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 657;
            this.label7.Text = "編制部門";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 656;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 655;
            this.label6.Text = "員工編號";
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
            this.nobr_b.Location = new System.Drawing.Point(104, 5);
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
            this.nobr_e.Location = new System.Drawing.Point(280, 5);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 2;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(242, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 901;
            this.label13.Text = "至";
            // 
            // saladr_e
            // 
            this.saladr_e.DisplayMember = "salname";
            this.saladr_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saladr_e.FormattingEnabled = true;
            this.saladr_e.Location = new System.Drawing.Point(280, 161);
            this.saladr_e.Name = "saladr_e";
            this.saladr_e.Size = new System.Drawing.Size(130, 20);
            this.saladr_e.TabIndex = 16;
            this.saladr_e.ValueMember = "saladr";
            // 
            // saladr_b
            // 
            this.saladr_b.DisplayMember = "salname";
            this.saladr_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saladr_b.FormattingEnabled = true;
            this.saladr_b.Location = new System.Drawing.Point(104, 161);
            this.saladr_b.Name = "saladr_b";
            this.saladr_b.Size = new System.Drawing.Size(130, 20);
            this.saladr_b.TabIndex = 15;
            this.saladr_b.ValueMember = "saladr";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(40, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 900;
            this.label16.Text = "薪資群組";
            // 
            // ZZ25
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 425);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.saladr_e);
            this.Controls.Add(this.saladr_b);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.job_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.job_b);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.in_out);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.date_n);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.work_e);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.work_b);
            this.Controls.Add(this.jobl_e);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.jobl_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ25";
            this.Text = "特休報表";
            this.Load += new System.EventHandler(this.ZZ25_Load);
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

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton date_type2;
        internal System.Windows.Forms.RadioButton date_type1;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox job_e;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox job_b;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data1;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.CheckBox in_out;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label17;
        internal JBControls.TextBox date_n;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        internal System.Windows.Forms.ComboBox work_e;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox work_b;
        internal System.Windows.Forms.ComboBox jobl_e;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox jobl_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox saladr_e;
        internal System.Windows.Forms.ComboBox saladr_b;
        private System.Windows.Forms.Label label16;
    }
}