namespace JBHR.Reports.TraForm
{
    partial class ZZ91
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
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.jobl_e = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.jobl_b = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.jobs_e = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jobs_b = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subcode_e = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subcode_b = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.date_b = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.incu_out = new System.Windows.Forms.CheckBox();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.bnLeave = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(252, 6);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 2;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(214, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 160;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(76, 6);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1;
            this.comp_b.ValueMember = "comp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(40, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 159;
            this.label12.Text = "公司";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(252, 31);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(214, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 164;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(76, 31);
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
            this.label7.Location = new System.Drawing.Point(12, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "編制部門";
            // 
            // jobl_e
            // 
            this.jobl_e.DisplayMember = "job_name";
            this.jobl_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_e.FormattingEnabled = true;
            this.jobl_e.Location = new System.Drawing.Point(252, 56);
            this.jobl_e.Name = "jobl_e";
            this.jobl_e.Size = new System.Drawing.Size(130, 20);
            this.jobl_e.TabIndex = 6;
            this.jobl_e.ValueMember = "jobl";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(214, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 879;
            this.label18.Text = "至";
            // 
            // jobl_b
            // 
            this.jobl_b.DisplayMember = "job_name";
            this.jobl_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobl_b.FormattingEnabled = true;
            this.jobl_b.Location = new System.Drawing.Point(76, 56);
            this.jobl_b.Name = "jobl_b";
            this.jobl_b.Size = new System.Drawing.Size(130, 20);
            this.jobl_b.TabIndex = 5;
            this.jobl_b.ValueMember = "jobl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(39, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 878;
            this.label10.Text = "職等";
            // 
            // jobs_e
            // 
            this.jobs_e.DisplayMember = "job_name";
            this.jobs_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobs_e.FormattingEnabled = true;
            this.jobs_e.Location = new System.Drawing.Point(252, 82);
            this.jobs_e.Name = "jobs_e";
            this.jobs_e.Size = new System.Drawing.Size(130, 20);
            this.jobs_e.TabIndex = 8;
            this.jobs_e.ValueMember = "jobs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(214, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 883;
            this.label1.Text = "至";
            // 
            // jobs_b
            // 
            this.jobs_b.DisplayMember = "job_name";
            this.jobs_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobs_b.FormattingEnabled = true;
            this.jobs_b.Location = new System.Drawing.Point(76, 82);
            this.jobs_b.Name = "jobs_b";
            this.jobs_b.Size = new System.Drawing.Size(130, 20);
            this.jobs_b.TabIndex = 7;
            this.jobs_b.ValueMember = "jobs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(39, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 882;
            this.label2.Text = "職系";
            // 
            // subcode_e
            // 
            this.subcode_e.DisplayMember = "descr";
            this.subcode_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subcode_e.FormattingEnabled = true;
            this.subcode_e.Location = new System.Drawing.Point(252, 108);
            this.subcode_e.Name = "subcode_e";
            this.subcode_e.Size = new System.Drawing.Size(130, 20);
            this.subcode_e.TabIndex = 10;
            this.subcode_e.ValueMember = "tr_tyep";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(214, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 887;
            this.label3.Text = "至";
            // 
            // subcode_b
            // 
            this.subcode_b.DisplayMember = "descr";
            this.subcode_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subcode_b.FormattingEnabled = true;
            this.subcode_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.subcode_b.Location = new System.Drawing.Point(76, 108);
            this.subcode_b.Name = "subcode_b";
            this.subcode_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.subcode_b.Size = new System.Drawing.Size(130, 20);
            this.subcode_b.TabIndex = 9;
            this.subcode_b.ValueMember = "tr_tyep";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 886;
            this.label4.Text = "課程類別";
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
            this.nobr_b.Location = new System.Drawing.Point(75, 134);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 11;
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
            this.nobr_e.Location = new System.Drawing.Point(251, 134);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 12;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(213, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 891;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(11, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 890;
            this.label6.Text = "員工編號";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(251, 161);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 14;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(75, 161);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 13;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(213, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 895;
            this.label5.Text = "至";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(11, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 894;
            this.label8.Text = "開課日期";
            // 
            // incu_out
            // 
            this.incu_out.AutoSize = true;
            this.incu_out.Location = new System.Drawing.Point(75, 190);
            this.incu_out.Name = "incu_out";
            this.incu_out.Size = new System.Drawing.Size(72, 16);
            this.incu_out.TabIndex = 15;
            this.incu_out.Text = "包含離職";
            this.incu_out.UseVisualStyleBackColor = true;
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(75, 216);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 16;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // bnLeave
            // 
            this.bnLeave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnLeave.Location = new System.Drawing.Point(232, 242);
            this.bnLeave.Name = "bnLeave";
            this.bnLeave.Size = new System.Drawing.Size(75, 23);
            this.bnLeave.TabIndex = 18;
            this.bnLeave.Text = "離開";
            this.bnLeave.UseVisualStyleBackColor = true;
            this.bnLeave.Click += new System.EventHandler(this.bnLeave_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(80, 242);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 17;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // ZZ91
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 295);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.bnLeave);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.incu_out);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.subcode_e);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subcode_b);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.jobs_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jobs_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jobl_e);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.jobl_b);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label12);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ91";
            this.Text = "員工個人受訓資料";
            this.Load += new System.EventHandler(this.ZZ91_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox jobl_e;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox jobl_b;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox jobs_e;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox jobs_b;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox subcode_e;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox subcode_b;
        private System.Windows.Forms.Label label4;
        private Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private Sal.BaseDS baseDS;
        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        internal JBControls.TextBox date_e;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.CheckBox incu_out;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button bnLeave;
        private System.Windows.Forms.Button Create_Report;
    }
}