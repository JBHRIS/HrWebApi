namespace JBHR.Reports.EmpForm
{
    partial class ZZ15
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
            this.outcode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.out_day = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.bnLeave = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.date_b = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dept_type2 = new System.Windows.Forms.RadioButton();
            this.dept_type1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.depts_e = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.depts_b = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outcode
            // 
            this.outcode.DisplayMember = "outname";
            this.outcode.FormattingEnabled = true;
            this.outcode.Location = new System.Drawing.Point(117, 217);
            this.outcode.Name = "outcode";
            this.outcode.Size = new System.Drawing.Size(170, 20);
            this.outcode.TabIndex = 13;
            this.outcode.ValueMember = "outcd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(23, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 287;
            this.label2.Text = "除名離職代碼";
            // 
            // out_day
            // 
            this.out_day.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.out_day.CaptionLabel = null;
            this.out_day.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.out_day.DecimalPlace = 0;
            this.out_day.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.out_day.IsEmpty = false;
            this.out_day.Location = new System.Drawing.Point(117, 190);
            this.out_day.Mask = "";
            this.out_day.MaxLength = -1;
            this.out_day.Name = "out_day";
            this.out_day.PasswordChar = '\0';
            this.out_day.ReadOnly = false;
            this.out_day.ShowCalendarButton = true;
            this.out_day.Size = new System.Drawing.Size(30, 23);
            this.out_day.TabIndex = 12;
            this.out_day.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(10, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 285;
            this.label1.Text = "離職天數分界點";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(118, 311);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 16;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // bnLeave
            // 
            this.bnLeave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnLeave.Location = new System.Drawing.Point(275, 339);
            this.bnLeave.Name = "bnLeave";
            this.bnLeave.Size = new System.Drawing.Size(75, 23);
            this.bnLeave.TabIndex = 18;
            this.bnLeave.Text = "離開";
            this.bnLeave.UseVisualStyleBackColor = true;
            this.bnLeave.Click += new System.EventHandler(this.Leave_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(123, 339);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 17;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // report_type
            // 
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "v依部門",
            "v依月份",
            "依職稱",
            "依原因"});
            this.report_type.Location = new System.Drawing.Point(117, 281);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(100, 20);
            this.report_type.TabIndex = 15;
            this.report_type.SelectedIndexChanged += new System.EventHandler(this.report_type_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label30.Location = new System.Drawing.Point(53, 284);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 284;
            this.label30.Text = "報表種類";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(293, 161);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 11;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(117, 161);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 10;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(255, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 283;
            this.label4.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(53, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 282;
            this.label3.Text = "起迄日期";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(117, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 35);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data3.Location = new System.Drawing.Point(114, 12);
            this.type_data3.Name = "type_data3";
            this.type_data3.Size = new System.Drawing.Size(53, 17);
            this.type_data3.TabIndex = 13;
            this.type_data3.Text = "直接";
            this.type_data3.UseVisualStyleBackColor = true;
            // 
            // type_data2
            // 
            this.type_data2.AutoSize = true;
            this.type_data2.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data2.Location = new System.Drawing.Point(60, 12);
            this.type_data2.Name = "type_data2";
            this.type_data2.Size = new System.Drawing.Size(53, 17);
            this.type_data2.TabIndex = 12;
            this.type_data2.Text = "間接";
            this.type_data2.UseVisualStyleBackColor = true;
            // 
            // type_data4
            // 
            this.type_data4.AutoSize = true;
            this.type_data4.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data4.Location = new System.Drawing.Point(168, 12);
            this.type_data4.Name = "type_data4";
            this.type_data4.Size = new System.Drawing.Size(53, 17);
            this.type_data4.TabIndex = 14;
            this.type_data4.Text = "外勞";
            this.type_data4.UseVisualStyleBackColor = true;
            // 
            // type_data1
            // 
            this.type_data1.AutoSize = true;
            this.type_data1.Checked = true;
            this.type_data1.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data1.Location = new System.Drawing.Point(6, 12);
            this.type_data1.Name = "type_data1";
            this.type_data1.Size = new System.Drawing.Size(53, 17);
            this.type_data1.TabIndex = 11;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(53, 252);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 281;
            this.label29.Text = "資料內容";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(293, 133);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 9;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(255, 138);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 279;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(117, 133);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 8;
            this.comp_b.ValueMember = "comp";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(293, 77);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 5;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(255, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 275;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(117, 77);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 4;
            this.dept_b.ValueMember = "d_no";
            // 
            // empcd_e
            // 
            this.empcd_e.DisplayMember = "empdescr";
            this.empcd_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_e.FormattingEnabled = true;
            this.empcd_e.Location = new System.Drawing.Point(293, 10);
            this.empcd_e.Name = "empcd_e";
            this.empcd_e.Size = new System.Drawing.Size(130, 20);
            this.empcd_e.TabIndex = 2;
            this.empcd_e.ValueMember = "empcd";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(255, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 274;
            this.label13.Text = "至";
            // 
            // empcd_b
            // 
            this.empcd_b.DisplayMember = "empdescr";
            this.empcd_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empcd_b.FormattingEnabled = true;
            this.empcd_b.Location = new System.Drawing.Point(117, 10);
            this.empcd_b.Name = "empcd_b";
            this.empcd_b.Size = new System.Drawing.Size(130, 20);
            this.empcd_b.TabIndex = 1;
            this.empcd_b.ValueMember = "empcd";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(80, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 273;
            this.label12.Text = "公司";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(53, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 269;
            this.label7.Text = "編制部門";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(81, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 268;
            this.label5.Text = "員別";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dept_type2);
            this.groupBox1.Controls.Add(this.dept_type1);
            this.groupBox1.Location = new System.Drawing.Point(114, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 35);
            this.groupBox1.TabIndex = 3;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(51, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 900;
            this.label6.Text = "部門種類";
            // 
            // depts_e
            // 
            this.depts_e.DisplayMember = "d_name";
            this.depts_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depts_e.Enabled = false;
            this.depts_e.FormattingEnabled = true;
            this.depts_e.Location = new System.Drawing.Point(293, 103);
            this.depts_e.Name = "depts_e";
            this.depts_e.Size = new System.Drawing.Size(130, 20);
            this.depts_e.TabIndex = 7;
            this.depts_e.ValueMember = "d_no";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(255, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 904;
            this.label16.Text = "至";
            // 
            // depts_b
            // 
            this.depts_b.DisplayMember = "d_name";
            this.depts_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depts_b.Enabled = false;
            this.depts_b.FormattingEnabled = true;
            this.depts_b.Location = new System.Drawing.Point(117, 103);
            this.depts_b.Name = "depts_b";
            this.depts_b.Size = new System.Drawing.Size(130, 20);
            this.depts_b.TabIndex = 6;
            this.depts_b.ValueMember = "d_no";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(53, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 903;
            this.label8.Text = "成本部門";
            // 
            // ZZ15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 375);
            this.Controls.Add(this.depts_e);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.depts_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.outcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.out_day);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.bnLeave);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ15";
            this.Text = "離職率分析表";
            this.Load += new System.EventHandler(this.ZZ15_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox outcode;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox out_day;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button bnLeave;
        private System.Windows.Forms.Button Create_Report;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label30;
        internal JBControls.TextBox date_e;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton dept_type2;
        internal System.Windows.Forms.RadioButton dept_type1;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox depts_e;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ComboBox depts_b;
        private System.Windows.Forms.Label label8;
    }
}