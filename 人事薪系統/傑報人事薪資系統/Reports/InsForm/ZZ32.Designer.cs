namespace JBHR.Reports.InsForm
{
    partial class ZZ32
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
            this.date_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date_t = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 6);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 424;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 425;
            this.label3.Text = "異動日期";
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(104, 34);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 426;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 427;
            this.label1.Text = "申報日期";
            // 
            // date_t
            // 
            this.date_t.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_t.CaptionLabel = null;
            this.date_t.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_t.DecimalPlace = 2;
            this.date_t.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_t.IsEmpty = false;
            this.date_t.Location = new System.Drawing.Point(104, 62);
            this.date_t.Mask = "0000/00/00";
            this.date_t.MaxLength = -1;
            this.date_t.Name = "date_t";
            this.date_t.PasswordChar = '\0';
            this.date_t.ReadOnly = false;
            this.date_t.Size = new System.Drawing.Size(80, 23);
            this.date_t.TabIndex = 428;
            this.date_t.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 429;
            this.label2.Text = "調薪日期";
            // 
            // LeaveForm
            // 
            this.LeaveForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LeaveForm.Location = new System.Drawing.Point(261, 125);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 433;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(109, 125);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 432;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // report_type
            // 
            this.report_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "加保",
            "退保",
            "調整"});
            this.report_type.Location = new System.Drawing.Point(104, 90);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(100, 20);
            this.report_type.TabIndex = 430;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(40, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 434;
            this.label13.Text = "報表種類";
            // 
            // ZZ32
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 166);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.date_t);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ32";
            this.Text = "勞健保異動卡";
            this.Load += new System.EventHandler(this.ZZ32_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox date_t;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label13;
    }
}