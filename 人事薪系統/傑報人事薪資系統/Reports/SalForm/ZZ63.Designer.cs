namespace JBHR.Reports.SalForm
{
    partial class ZZ63
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
            this.label3 = new System.Windows.Forms.Label();
            this.zone = new System.Windows.Forms.CheckBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.wcode_e = new System.Windows.Forms.ComboBox();
            this.wcode_b = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.seq_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yymm_e = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.seq_b = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yymm_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.nobr_b = new JBControls.PopupTextBox();
            this.nobr_e = new JBControls.PopupTextBox();
            this.month_e = new JBControls.TextBox();
            this.month_b = new JBControls.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 491;
            this.label3.Text = "資料內容";
            // 
            // zone
            // 
            this.zone.AutoSize = true;
            this.zone.Location = new System.Drawing.Point(104, 129);
            this.zone.Name = "zone";
            this.zone.Size = new System.Drawing.Size(126, 16);
            this.zone.TabIndex = 13;
            this.zone.Text = "小於1000 元不列印";
            this.zone.UseVisualStyleBackColor = true;
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 10);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 2;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 488;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 10);
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
            this.label7.Location = new System.Drawing.Point(40, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 487;
            this.label7.Text = "編制部門";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 486;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 485;
            this.label6.Text = "員工編號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(242, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 495;
            this.label5.Text = "至";
            // 
            // wcode_e
            // 
            this.wcode_e.DisplayMember = "w_name";
            this.wcode_e.FormattingEnabled = true;
            this.wcode_e.Location = new System.Drawing.Point(280, 36);
            this.wcode_e.Name = "wcode_e";
            this.wcode_e.Size = new System.Drawing.Size(130, 20);
            this.wcode_e.TabIndex = 4;
            this.wcode_e.ValueMember = "w_code";
            // 
            // wcode_b
            // 
            this.wcode_b.DisplayMember = "w_name";
            this.wcode_b.FormattingEnabled = true;
            this.wcode_b.Location = new System.Drawing.Point(104, 36);
            this.wcode_b.Name = "wcode_b";
            this.wcode_b.Size = new System.Drawing.Size(130, 20);
            this.wcode_b.TabIndex = 3;
            this.wcode_b.ValueMember = "w_code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(40, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 494;
            this.label4.Text = "福利代號";
            // 
            // seq_e
            // 
            this.seq_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_e.CaptionLabel = null;
            this.seq_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_e.DecimalPlace = 2;
            this.seq_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_e.IsEmpty = false;
            this.seq_e.Location = new System.Drawing.Point(387, 91);
            this.seq_e.Mask = "";
            this.seq_e.MaxLength = -1;
            this.seq_e.Name = "seq_e";
            this.seq_e.PasswordChar = '\0';
            this.seq_e.ReadOnly = false;
            this.seq_e.Size = new System.Drawing.Size(20, 23);
            this.seq_e.TabIndex = 12;
            this.seq_e.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(351, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1060;
            this.label1.Text = "期別";
            // 
            // yymm_e
            // 
            this.yymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_e.CaptionLabel = null;
            this.yymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_e.DecimalPlace = 2;
            this.yymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_e.IsEmpty = false;
            this.yymm_e.Location = new System.Drawing.Point(280, 91);
            this.yymm_e.Mask = "";
            this.yymm_e.MaxLength = -1;
            this.yymm_e.Name = "yymm_e";
            this.yymm_e.PasswordChar = '\0';
            this.yymm_e.ReadOnly = false;
            this.yymm_e.Size = new System.Drawing.Size(30, 23);
            this.yymm_e.TabIndex = 10;
            this.yymm_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(242, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1059;
            this.label2.Text = "至";
            // 
            // seq_b
            // 
            this.seq_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.seq_b.CaptionLabel = null;
            this.seq_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.seq_b.DecimalPlace = 2;
            this.seq_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seq_b.IsEmpty = false;
            this.seq_b.Location = new System.Drawing.Point(211, 91);
            this.seq_b.Mask = "";
            this.seq_b.MaxLength = -1;
            this.seq_b.Name = "seq_b";
            this.seq_b.PasswordChar = '\0';
            this.seq_b.ReadOnly = false;
            this.seq_b.Size = new System.Drawing.Size(20, 23);
            this.seq_b.TabIndex = 9;
            this.seq_b.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(175, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1058;
            this.label8.Text = "期別";
            // 
            // yymm_b
            // 
            this.yymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_b.CaptionLabel = null;
            this.yymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_b.DecimalPlace = 2;
            this.yymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_b.IsEmpty = false;
            this.yymm_b.Location = new System.Drawing.Point(104, 91);
            this.yymm_b.Mask = "";
            this.yymm_b.MaxLength = -1;
            this.yymm_b.Name = "yymm_b";
            this.yymm_b.PasswordChar = '\0';
            this.yymm_b.ReadOnly = false;
            this.yymm_b.Size = new System.Drawing.Size(30, 23);
            this.yymm_b.TabIndex = 7;
            this.yymm_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 95);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 1057;
            this.label29.Text = "發放年月";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 153);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 14;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(261, 182);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 16;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(109, 182);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 15;
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
            this.nobr_b.Location = new System.Drawing.Point(104, 64);
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
            this.nobr_e.Location = new System.Drawing.Point(280, 64);
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
            this.month_e.Location = new System.Drawing.Point(310, 91);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 11;
            this.month_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // month_b
            // 
            this.month_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_b.CaptionLabel = null;
            this.month_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_b.DecimalPlace = 2;
            this.month_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_b.IsEmpty = false;
            this.month_b.Location = new System.Drawing.Point(134, 91);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 8;
            this.month_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // ZZ63
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 228);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.seq_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yymm_e);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seq_b);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.yymm_b);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.wcode_e);
            this.Controls.Add(this.wcode_b);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zone);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ63";
            this.Text = "福利金與薪資資料列印";
            this.Load += new System.EventHandler(this.ZZ63_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.CheckBox zone;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox wcode_e;
        internal System.Windows.Forms.ComboBox wcode_b;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox seq_e;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox yymm_e;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox seq_b;
        private System.Windows.Forms.Label label8;
        internal JBControls.TextBox yymm_b;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
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