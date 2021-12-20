namespace JBHR.Reports.SalForm
{
    partial class ZZ51B
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
            this.reporttype = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.type_tr3 = new System.Windows.Forms.RadioButton();
            this.type_tr2 = new System.Windows.Forms.RadioButton();
            this.type_tr1 = new System.Windows.Forms.RadioButton();
            this.ser_noe = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ser_nob = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.year = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.yrformat_e = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yrformat_b = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // reporttype
            // 
            this.reporttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reporttype.FormattingEnabled = true;
            this.reporttype.Items.AddRange(new object[] {
            "年度所得資料"});
            this.reporttype.Location = new System.Drawing.Point(103, 160);
            this.reporttype.Name = "reporttype";
            this.reporttype.Size = new System.Drawing.Size(120, 20);
            this.reporttype.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(39, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 444;
            this.label13.Text = "報表種類";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(39, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 442;
            this.label4.Text = "申報內容";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.type_tr3);
            this.groupBox1.Controls.Add(this.type_tr2);
            this.groupBox1.Controls.Add(this.type_tr1);
            this.groupBox1.Location = new System.Drawing.Point(104, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 35);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // type_tr3
            // 
            this.type_tr3.AutoSize = true;
            this.type_tr3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.type_tr3.Location = new System.Drawing.Point(130, 12);
            this.type_tr3.Name = "type_tr3";
            this.type_tr3.Size = new System.Drawing.Size(67, 17);
            this.type_tr3.TabIndex = 16;
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
            this.type_tr2.TabIndex = 15;
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
            this.type_tr1.TabIndex = 14;
            this.type_tr1.TabStop = true;
            this.type_tr1.Text = "全部";
            this.type_tr1.UseVisualStyleBackColor = true;
            // 
            // ser_noe
            // 
            this.ser_noe.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ser_noe.CaptionLabel = null;
            this.ser_noe.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ser_noe.DecimalPlace = 2;
            this.ser_noe.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ser_noe.IsEmpty = false;
            this.ser_noe.Location = new System.Drawing.Point(280, 64);
            this.ser_noe.Mask = "";
            this.ser_noe.MaxLength = -1;
            this.ser_noe.Name = "ser_noe";
            this.ser_noe.PasswordChar = '\0';
            this.ser_noe.ReadOnly = false;
            this.ser_noe.ShowCalendarButton = true;
            this.ser_noe.Size = new System.Drawing.Size(80, 23);
            this.ser_noe.TabIndex = 7;
            this.ser_noe.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(242, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 441;
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
            this.ser_nob.Location = new System.Drawing.Point(104, 64);
            this.ser_nob.Mask = "";
            this.ser_nob.MaxLength = -1;
            this.ser_nob.Name = "ser_nob";
            this.ser_nob.PasswordChar = '\0';
            this.ser_nob.ReadOnly = false;
            this.ser_nob.ShowCalendarButton = true;
            this.ser_nob.Size = new System.Drawing.Size(80, 23);
            this.ser_nob.TabIndex = 6;
            this.ser_nob.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(53, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 440;
            this.label8.Text = "流水號";
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
            this.year.ShowCalendarButton = true;
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
            this.label1.TabIndex = 439;
            this.label1.Text = "扣繳年度";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(103, 196);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 19;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LeaveForm.Location = new System.Drawing.Point(260, 223);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 21;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(108, 223);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 20;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 437;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 436;
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
            this.nobr_b.Location = new System.Drawing.Point(104, 36);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
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
            this.nobr_e.Location = new System.Drawing.Point(280, 36);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 3;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // yrformat_e
            // 
            this.yrformat_e.DisplayMember = "m_fmt_name";
            this.yrformat_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yrformat_e.FormattingEnabled = true;
            this.yrformat_e.Location = new System.Drawing.Point(279, 134);
            this.yrformat_e.Name = "yrformat_e";
            this.yrformat_e.Size = new System.Drawing.Size(130, 20);
            this.yrformat_e.TabIndex = 446;
            this.yrformat_e.ValueMember = "m_format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(241, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 448;
            this.label3.Text = "至";
            // 
            // yrformat_b
            // 
            this.yrformat_b.DisplayMember = "m_fmt_name";
            this.yrformat_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yrformat_b.FormattingEnabled = true;
            this.yrformat_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.yrformat_b.Location = new System.Drawing.Point(103, 134);
            this.yrformat_b.Name = "yrformat_b";
            this.yrformat_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.yrformat_b.Size = new System.Drawing.Size(130, 20);
            this.yrformat_b.TabIndex = 445;
            this.yrformat_b.ValueMember = "m_format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(39, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 447;
            this.label5.Text = "所得格式";
            // 
            // ZZ51B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 264);
            this.Controls.Add(this.yrformat_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yrformat_b);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.reporttype);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ser_noe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ser_nob);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ51B";
            this.Text = "年度所得資料列印";
            this.Load += new System.EventHandler(this.ZZ51B_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox reporttype;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton type_tr3;
        internal System.Windows.Forms.RadioButton type_tr2;
        internal System.Windows.Forms.RadioButton type_tr1;
        internal JBControls.TextBox ser_noe;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox ser_nob;
        private System.Windows.Forms.Label label8;
        internal JBControls.TextBox year;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private JBHR.Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private JBHR.Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        internal System.Windows.Forms.ComboBox yrformat_e;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox yrformat_b;
        private System.Windows.Forms.Label label5;
    }
}