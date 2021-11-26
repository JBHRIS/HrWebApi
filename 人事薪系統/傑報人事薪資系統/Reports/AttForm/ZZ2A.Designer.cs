﻿namespace JBHR.Reports.AttForm
{
    partial class ZZ2A
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
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.indt = new JBControls.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yy = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.type_data3 = new System.Windows.Forms.RadioButton();
            this.type_data2 = new System.Windows.Forms.RadioButton();
            this.type_data4 = new System.Windows.Forms.RadioButton();
            this.type_data1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.empcd_e = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empcd_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(256, 218);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 16;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(104, 218);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 15;
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
            this.indt.Location = new System.Drawing.Point(104, 139);
            this.indt.Mask = "0000/00/00";
            this.indt.MaxLength = -1;
            this.indt.Name = "indt";
            this.indt.PasswordChar = '\0';
            this.indt.ReadOnly = false;
            this.indt.Size = new System.Drawing.Size(80, 23);
            this.indt.TabIndex = 10;
            this.indt.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(27, 143);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 664;
            this.label21.Text = "異動截止日";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(280, 110);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 9;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(242, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 663;
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
            this.date_b.Location = new System.Drawing.Point(104, 110);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 8;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            this.date_b.Validated += new System.EventHandler(this.date_b_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(40, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 662;
            this.label9.Text = "起迄日期";
            // 
            // yy
            // 
            this.yy.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yy.CaptionLabel = null;
            this.yy.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yy.DecimalPlace = 0;
            this.yy.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yy.IsEmpty = false;
            this.yy.Location = new System.Drawing.Point(104, 5);
            this.yy.Mask = "";
            this.yy.MaxLength = -1;
            this.yy.Name = "yy";
            this.yy.PasswordChar = '\0';
            this.yy.ReadOnly = false;
            this.yy.Size = new System.Drawing.Size(35, 23);
            this.yy.TabIndex = 1;
            this.yy.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 10);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 661;
            this.label29.Text = "輸入年度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type_data3);
            this.groupBox2.Controls.Add(this.type_data2);
            this.groupBox2.Controls.Add(this.type_data4);
            this.groupBox2.Controls.Add(this.type_data1);
            this.groupBox2.Location = new System.Drawing.Point(104, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 35);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // type_data3
            // 
            this.type_data3.AutoSize = true;
            this.type_data3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.type_data2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.type_data4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.type_data1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_data1.Location = new System.Drawing.Point(6, 12);
            this.type_data1.Name = "type_data1";
            this.type_data1.Size = new System.Drawing.Size(53, 17);
            this.type_data1.TabIndex = 11;
            this.type_data1.TabStop = true;
            this.type_data1.Text = "全部";
            this.type_data1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 660;
            this.label2.Text = "資料內容";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 85);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 7;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 659;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 85);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 6;
            this.dept_b.ValueMember = "d_no";
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
            this.label13.TabIndex = 658;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 657;
            this.label7.Text = "編制部門";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(68, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 656;
            this.label5.Text = "員別";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 655;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 654;
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
            this.nobr_b.Location = new System.Drawing.Point(104, 33);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 2;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 33);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 3;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // ZZ2A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 266);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.indt);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.yy);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.empcd_e);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empcd_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ2A";
            this.Text = "請假卡";
            this.Load += new System.EventHandler(this.ZZ2A_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox indt;
        private System.Windows.Forms.Label label21;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label9;
        internal JBControls.TextBox yy;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton type_data3;
        internal System.Windows.Forms.RadioButton type_data2;
        internal System.Windows.Forms.RadioButton type_data4;
        internal System.Windows.Forms.RadioButton type_data1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        internal System.Windows.Forms.ComboBox empcd_e;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox empcd_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
    }
}