namespace JBHR.Reports.AttForm
{
    partial class ZZ2ZA
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.order2 = new System.Windows.Forms.RadioButton();
            this.order1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.note1 = new JBControls.TextBox();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.indt = new JBControls.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data5 = new System.Windows.Forms.RadioButton();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yymm_e = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yymm_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_type2 = new System.Windows.Forms.RadioButton();
            this.date_type1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.month_e = new JBControls.TextBox();
            this.month_b = new JBControls.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.order2);
            this.groupBox4.Controls.Add(this.order1);
            this.groupBox4.Location = new System.Drawing.Point(104, 265);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 35);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // order2
            // 
            this.order2.AutoSize = true;
            this.order2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order2.Location = new System.Drawing.Point(100, 12);
            this.order2.Name = "order2";
            this.order2.Size = new System.Drawing.Size(53, 17);
            this.order2.TabIndex = 24;
            this.order2.Text = "工號";
            this.order2.UseVisualStyleBackColor = true;
            // 
            // order1
            // 
            this.order1.AutoSize = true;
            this.order1.Checked = true;
            this.order1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order1.Location = new System.Drawing.Point(5, 12);
            this.order1.Name = "order1";
            this.order1.Size = new System.Drawing.Size(88, 17);
            this.order1.TabIndex = 23;
            this.order1.TabStop = true;
            this.order1.Text = "部門+工號";
            this.order1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(39, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 647;
            this.label8.Text = "排列順序";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(68, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 646;
            this.label5.Text = "備註";
            // 
            // note1
            // 
            this.note1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.note1.CaptionLabel = null;
            this.note1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.note1.DecimalPlace = 2;
            this.note1.IsEmpty = true;
            this.note1.Location = new System.Drawing.Point(104, 202);
            this.note1.Mask = "";
            this.note1.MaxLength = -1;
            this.note1.Name = "note1";
            this.note1.PasswordChar = '\0';
            this.note1.ReadOnly = false;
            this.note1.Size = new System.Drawing.Size(305, 22);
            this.note1.TabIndex = 17;
            this.note1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 311);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 25;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 335);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 27;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 335);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 26;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // indt
            // 
            this.indt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.indt.CaptionLabel = null;
            this.indt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.indt.DecimalPlace = 2;
            this.indt.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.indt.IsEmpty = false;
            this.indt.Location = new System.Drawing.Point(104, 173);
            this.indt.Mask = "0000/00/00";
            this.indt.MaxLength = -1;
            this.indt.Name = "indt";
            this.indt.PasswordChar = '\0';
            this.indt.ReadOnly = false;
            this.indt.Size = new System.Drawing.Size(80, 23);
            this.indt.TabIndex = 16;
            this.indt.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(27, 177);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 645;
            this.label21.Text = "到職截止日";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data5);
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 35);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // type_data5
            // 
            this.type_data5.AutoSize = true;
            this.type_data5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data5.Location = new System.Drawing.Point(225, 12);
            this.type_data5.Name = "type_data5";
            this.type_data5.Size = new System.Drawing.Size(60, 17);
            this.type_data5.TabIndex = 22;
            this.type_data5.Text = "直+外";
            this.type_data5.UseVisualStyleBackColor = true;
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
            this.type_data1.Location = new System.Drawing.Point(5, 12);
            this.type_data1.Name = "type_data1";
            this.type_data1.Size = new System.Drawing.Size(53, 17);
            this.type_data1.TabIndex = 18;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 644;
            this.label2.Text = "資料內容";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(280, 145);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 15;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(242, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 643;
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
            this.date_b.Location = new System.Drawing.Point(104, 145);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 14;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            this.date_b.Validated += new System.EventHandler(this.date_b_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(40, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 642;
            this.label9.Text = "出勤日期";
            // 
            // yymm_e
            // 
            this.yymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_e.CaptionLabel = null;
            this.yymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_e.DecimalPlace = 0;
            this.yymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_e.IsEmpty = false;
            this.yymm_e.Location = new System.Drawing.Point(280, 117);
            this.yymm_e.Mask = "";
            this.yymm_e.MaxLength = -1;
            this.yymm_e.Name = "yymm_e";
            this.yymm_e.PasswordChar = '\0';
            this.yymm_e.ReadOnly = false;
            this.yymm_e.Size = new System.Drawing.Size(30, 23);
            this.yymm_e.TabIndex = 12;
            this.yymm_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.yymm_e.Validated += new System.EventHandler(this.yymm_e_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(242, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 641;
            this.label3.Text = "至";
            // 
            // yymm_b
            // 
            this.yymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_b.CaptionLabel = null;
            this.yymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_b.DecimalPlace = 0;
            this.yymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_b.IsEmpty = false;
            this.yymm_b.Location = new System.Drawing.Point(104, 117);
            this.yymm_b.Mask = "";
            this.yymm_b.MaxLength = -1;
            this.yymm_b.Name = "yymm_b";
            this.yymm_b.PasswordChar = '\0';
            this.yymm_b.ReadOnly = false;
            this.yymm_b.Size = new System.Drawing.Size(30, 23);
            this.yymm_b.TabIndex = 10;
            this.yymm_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.yymm_b.Validated += new System.EventHandler(this.yymm_b_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 122);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 640;
            this.label29.Text = "計薪年月";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_type2);
            this.groupBox1.Controls.Add(this.date_type1);
            this.groupBox1.Location = new System.Drawing.Point(103, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 35);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // date_type2
            // 
            this.date_type2.AutoSize = true;
            this.date_type2.Location = new System.Drawing.Point(94, 12);
            this.date_type2.Name = "date_type2";
            this.date_type2.Size = new System.Drawing.Size(71, 16);
            this.date_type2.TabIndex = 9;
            this.date_type2.Text = "起迄日期";
            this.date_type2.UseVisualStyleBackColor = true;
            this.date_type2.Click += new System.EventHandler(this.date_type2_Click);
            // 
            // date_type1
            // 
            this.date_type1.AutoSize = true;
            this.date_type1.Checked = true;
            this.date_type1.Location = new System.Drawing.Point(4, 12);
            this.date_type1.Name = "date_type1";
            this.date_type1.Size = new System.Drawing.Size(71, 16);
            this.date_type1.TabIndex = 8;
            this.date_type1.TabStop = true;
            this.date_type1.Text = "計薪年月";
            this.date_type1.UseVisualStyleBackColor = true;
            this.date_type1.Click += new System.EventHandler(this.date_type1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 639;
            this.label1.Text = "日期種類";
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depts_e.FormattingEnabled = true;
            this.depts_e.Location = new System.Drawing.Point(280, 57);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 6;
            this.depts_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 638;
            this.label15.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depts_b.FormattingEnabled = true;
            this.depts_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.depts_b.Location = new System.Drawing.Point(104, 57);
            this.depts_b.Name = "depts_b";
            this.depts_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 5;
            this.depts_b.ValueMember = "d_no";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 637;
            this.label7.Text = "成本部門";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 33);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 4;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(242, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 636;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 33);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 3;
            this.comp_b.ValueMember = "comp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(68, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 635;
            this.label12.Text = "公司";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 634;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 633;
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
            // month_e
            // 
            this.month_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_e.CaptionLabel = null;
            this.month_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_e.DecimalPlace = 2;
            this.month_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_e.IsEmpty = false;
            this.month_e.Location = new System.Drawing.Point(311, 117);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 13;
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
            this.month_b.Location = new System.Drawing.Point(135, 117);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 11;
            this.month_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_b.Validated += new System.EventHandler(this.month_b_Validated);
            // 
            // ZZ2ZA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 368);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.note1);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.indt);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.yymm_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yymm_b);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ2ZA";
            this.Text = "員工加班請假檢核表";
            this.Load += new System.EventHandler(this.ZZ2ZA_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.RadioButton order2;
        internal System.Windows.Forms.RadioButton order1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        internal JBControls.TextBox note1;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox indt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data5;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label9;
        internal JBControls.TextBox yymm_e;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox yymm_b;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton date_type2;
        internal System.Windows.Forms.RadioButton date_type1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox depts_b;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal JBControls.TextBox month_e;
        internal JBControls.TextBox month_b;
    }
}