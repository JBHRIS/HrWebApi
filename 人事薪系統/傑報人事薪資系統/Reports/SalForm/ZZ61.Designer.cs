namespace JBHR.Reports.SalForm
{
    partial class ZZ61
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
            this.zone = new System.Windows.Forms.CheckBox();
            this.reporttype = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ordertype = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.type_tr3 = new System.Windows.Forms.RadioButton();
            this.type_tr2 = new System.Windows.Forms.RadioButton();
            this.type_tr1 = new System.Windows.Forms.RadioButton();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.ser_noe = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ser_nob = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.year = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // zone
            // 
            this.zone.AutoSize = true;
            this.zone.Location = new System.Drawing.Point(103, 125);
            this.zone.Name = "zone";
            this.zone.Size = new System.Drawing.Size(108, 16);
            this.zone.TabIndex = 8;
            this.zone.Text = "小於0 元不列印";
            this.zone.UseVisualStyleBackColor = true;
            // 
            // reporttype
            // 
            this.reporttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reporttype.FormattingEnabled = true;
            this.reporttype.Items.AddRange(new object[] {
            "年度福利金資料"});
            this.reporttype.Location = new System.Drawing.Point(103, 218);
            this.reporttype.Name = "reporttype";
            this.reporttype.Size = new System.Drawing.Size(120, 20);
            this.reporttype.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(39, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 476;
            this.label13.Text = "報表種類";
            // 
            // ordertype
            // 
            this.ordertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ordertype.FormattingEnabled = true;
            this.ordertype.Items.AddRange(new object[] {
            "部門+員工",
            "身分證號"});
            this.ordertype.Location = new System.Drawing.Point(103, 190);
            this.ordertype.Name = "ordertype";
            this.ordertype.Size = new System.Drawing.Size(80, 20);
            this.ordertype.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(39, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 475;
            this.label9.Text = "排序種類";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(39, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 474;
            this.label4.Text = "申報內容";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.type_tr3);
            this.groupBox1.Controls.Add(this.type_tr2);
            this.groupBox1.Controls.Add(this.type_tr1);
            this.groupBox1.Location = new System.Drawing.Point(104, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 35);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // type_tr3
            // 
            this.type_tr3.AutoSize = true;
            this.type_tr3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_tr3.Location = new System.Drawing.Point(130, 12);
            this.type_tr3.Name = "type_tr3";
            this.type_tr3.Size = new System.Drawing.Size(67, 17);
            this.type_tr3.TabIndex = 11;
            this.type_tr3.Text = "已申報";
            this.type_tr3.UseVisualStyleBackColor = true;
            // 
            // type_tr2
            // 
            this.type_tr2.AutoSize = true;
            this.type_tr2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_tr2.Location = new System.Drawing.Point(60, 12);
            this.type_tr2.Name = "type_tr2";
            this.type_tr2.Size = new System.Drawing.Size(67, 17);
            this.type_tr2.TabIndex = 10;
            this.type_tr2.Text = "未申報";
            this.type_tr2.UseVisualStyleBackColor = true;
            // 
            // type_tr1
            // 
            this.type_tr1.AutoSize = true;
            this.type_tr1.Checked = true;
            this.type_tr1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_tr1.Location = new System.Drawing.Point(5, 12);
            this.type_tr1.Name = "type_tr1";
            this.type_tr1.Size = new System.Drawing.Size(53, 17);
            this.type_tr1.TabIndex = 9;
            this.type_tr1.TabStop = true;
            this.type_tr1.Text = "全部";
            this.type_tr1.UseVisualStyleBackColor = true;
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(103, 251);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 14;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(260, 273);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 16;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 273);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 15;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // ser_noe
            // 
            this.ser_noe.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ser_noe.CaptionLabel = null;
            this.ser_noe.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ser_noe.DecimalPlace = 2;
            this.ser_noe.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ser_noe.IsEmpty = false;
            this.ser_noe.Location = new System.Drawing.Point(280, 90);
            this.ser_noe.Mask = "";
            this.ser_noe.MaxLength = -1;
            this.ser_noe.Name = "ser_noe";
            this.ser_noe.PasswordChar = '\0';
            this.ser_noe.ReadOnly = false;
            this.ser_noe.Size = new System.Drawing.Size(80, 23);
            this.ser_noe.TabIndex = 7;
            this.ser_noe.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(242, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 471;
            this.label2.Text = "至";
            // 
            // ser_nob
            // 
            this.ser_nob.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ser_nob.CaptionLabel = null;
            this.ser_nob.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ser_nob.DecimalPlace = 2;
            this.ser_nob.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ser_nob.IsEmpty = false;
            this.ser_nob.Location = new System.Drawing.Point(104, 90);
            this.ser_nob.Mask = "";
            this.ser_nob.MaxLength = -1;
            this.ser_nob.Name = "ser_nob";
            this.ser_nob.PasswordChar = '\0';
            this.ser_nob.ReadOnly = false;
            this.ser_nob.Size = new System.Drawing.Size(80, 23);
            this.ser_nob.TabIndex = 6;
            this.ser_nob.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(53, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 470;
            this.label8.Text = "流水號";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 63);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 5;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 468;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 63);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 4;
            this.dept_b.ValueMember = "d_no";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 466;
            this.label7.Text = "編制部門";
            // 
            // year
            // 
            this.year.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.year.CaptionLabel = null;
            this.year.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.year.DecimalPlace = 2;
            this.year.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.year.IsEmpty = false;
            this.year.Location = new System.Drawing.Point(104, 6);
            this.year.Mask = "";
            this.year.MaxLength = -1;
            this.year.Name = "year";
            this.year.PasswordChar = '\0';
            this.year.ReadOnly = false;
            this.year.Size = new System.Drawing.Size(40, 23);
            this.year.TabIndex = 1;
            this.year.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 462;
            this.label1.Text = "扣繳年度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 461;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 460;
            this.label6.Text = "員工編號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(39, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 477;
            this.label3.Text = "資料內容";
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
            this.nobr_b.Location = new System.Drawing.Point(103, 34);
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
            this.nobr_e.Location = new System.Drawing.Point(279, 34);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 3;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // ZZ61
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 308);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zone);
            this.Controls.Add(this.reporttype);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ordertype);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.ser_noe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ser_nob);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ61";
            this.Text = "年度福利金資料列印";
            this.Load += new System.EventHandler(this.ZZ61_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox zone;
        internal System.Windows.Forms.ComboBox reporttype;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox ordertype;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton type_tr3;
        internal System.Windows.Forms.RadioButton type_tr2;
        internal System.Windows.Forms.RadioButton type_tr1;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox ser_noe;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox ser_nob;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        internal JBControls.TextBox year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
    }
}