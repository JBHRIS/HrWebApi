namespace JBHR.Reports.AttForm
{
    partial class ZZ28
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
            this.label22 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.otyymm_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.otyymm_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yymm_e = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yymm_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.month_e = new JBControls.TextBox();
            this.month_b = new JBControls.TextBox();
            this.otmonth_e = new JBControls.TextBox();
            this.otmonth_b = new JBControls.TextBox();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(242, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 623;
            this.label22.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 6);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 2;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 6);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1;
            this.comp_b.ValueMember = "comp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(68, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 622;
            this.label12.Text = "公司";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 93);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 11;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // LeaveForm
            // 
            this.LeaveForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LeaveForm.Location = new System.Drawing.Point(261, 117);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 13;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(109, 117);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 12;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // otyymm_e
            // 
            this.otyymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otyymm_e.CaptionLabel = null;
            this.otyymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otyymm_e.DecimalPlace = 0;
            this.otyymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otyymm_e.IsEmpty = false;
            this.otyymm_e.Location = new System.Drawing.Point(280, 58);
            this.otyymm_e.Mask = "000000";
            this.otyymm_e.MaxLength = -1;
            this.otyymm_e.Name = "otyymm_e";
            this.otyymm_e.PasswordChar = '\0';
            this.otyymm_e.ReadOnly = false;
            this.otyymm_e.ShowCalendarButton = true;
            this.otyymm_e.Size = new System.Drawing.Size(30, 23);
            this.otyymm_e.TabIndex = 9;
            this.otyymm_e.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(242, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 615;
            this.label1.Text = "至";
            // 
            // otyymm_b
            // 
            this.otyymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otyymm_b.CaptionLabel = null;
            this.otyymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otyymm_b.DecimalPlace = 0;
            this.otyymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otyymm_b.IsEmpty = false;
            this.otyymm_b.Location = new System.Drawing.Point(104, 58);
            this.otyymm_b.Mask = "000000";
            this.otyymm_b.MaxLength = -1;
            this.otyymm_b.Name = "otyymm_b";
            this.otyymm_b.PasswordChar = '\0';
            this.otyymm_b.ReadOnly = false;
            this.otyymm_b.ShowCalendarButton = true;
            this.otyymm_b.Size = new System.Drawing.Size(30, 23);
            this.otyymm_b.TabIndex = 7;
            this.otyymm_b.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 614;
            this.label3.Text = "比較年月";
            // 
            // yymm_e
            // 
            this.yymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_e.CaptionLabel = null;
            this.yymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_e.DecimalPlace = 0;
            this.yymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_e.IsEmpty = false;
            this.yymm_e.Location = new System.Drawing.Point(280, 31);
            this.yymm_e.Mask = "000000";
            this.yymm_e.MaxLength = -1;
            this.yymm_e.Name = "yymm_e";
            this.yymm_e.PasswordChar = '\0';
            this.yymm_e.ReadOnly = false;
            this.yymm_e.ShowCalendarButton = true;
            this.yymm_e.Size = new System.Drawing.Size(30, 23);
            this.yymm_e.TabIndex = 5;
            this.yymm_e.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(242, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 611;
            this.label2.Text = "至";
            // 
            // yymm_b
            // 
            this.yymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_b.CaptionLabel = null;
            this.yymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_b.DecimalPlace = 0;
            this.yymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_b.IsEmpty = false;
            this.yymm_b.Location = new System.Drawing.Point(104, 31);
            this.yymm_b.Mask = "000000";
            this.yymm_b.MaxLength = -1;
            this.yymm_b.Name = "yymm_b";
            this.yymm_b.PasswordChar = '\0';
            this.yymm_b.ReadOnly = false;
            this.yymm_b.ShowCalendarButton = true;
            this.yymm_b.Size = new System.Drawing.Size(30, 23);
            this.yymm_b.TabIndex = 3;
            this.yymm_b.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 610;
            this.label29.Text = "基準年月";
            // 
            // month_e
            // 
            this.month_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_e.CaptionLabel = null;
            this.month_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_e.DecimalPlace = 2;
            this.month_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_e.IsEmpty = false;
            this.month_e.Location = new System.Drawing.Point(310, 31);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.ShowCalendarButton = true;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 6;
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
            this.month_b.Location = new System.Drawing.Point(134, 31);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.ShowCalendarButton = true;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 4;
            this.month_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_b.Validated += new System.EventHandler(this.month_b_Validated);
            // 
            // otmonth_e
            // 
            this.otmonth_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otmonth_e.CaptionLabel = null;
            this.otmonth_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otmonth_e.DecimalPlace = 2;
            this.otmonth_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otmonth_e.IsEmpty = false;
            this.otmonth_e.Location = new System.Drawing.Point(310, 58);
            this.otmonth_e.Mask = "";
            this.otmonth_e.MaxLength = -1;
            this.otmonth_e.Name = "otmonth_e";
            this.otmonth_e.PasswordChar = '\0';
            this.otmonth_e.ReadOnly = false;
            this.otmonth_e.ShowCalendarButton = true;
            this.otmonth_e.Size = new System.Drawing.Size(25, 23);
            this.otmonth_e.TabIndex = 10;
            this.otmonth_e.ValidType = JBControls.TextBox.EValidType.Integer;
            this.otmonth_e.Validated += new System.EventHandler(this.otmonth_e_Validated);
            // 
            // otmonth_b
            // 
            this.otmonth_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otmonth_b.CaptionLabel = null;
            this.otmonth_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otmonth_b.DecimalPlace = 2;
            this.otmonth_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otmonth_b.IsEmpty = false;
            this.otmonth_b.Location = new System.Drawing.Point(134, 58);
            this.otmonth_b.Mask = "";
            this.otmonth_b.MaxLength = -1;
            this.otmonth_b.Name = "otmonth_b";
            this.otmonth_b.PasswordChar = '\0';
            this.otmonth_b.ReadOnly = false;
            this.otmonth_b.ShowCalendarButton = true;
            this.otmonth_b.Size = new System.Drawing.Size(25, 23);
            this.otmonth_b.TabIndex = 8;
            this.otmonth_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.otmonth_b.Validated += new System.EventHandler(this.otmonth_b_Validated);
            // 
            // ZZ28
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 146);
            this.Controls.Add(this.otmonth_e);
            this.Controls.Add(this.otmonth_b);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.otyymm_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.otyymm_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yymm_e);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yymm_b);
            this.Controls.Add(this.label29);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ28";
            this.Text = "出勤工時比較表";
            this.Load += new System.EventHandler(this.ZZ28_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.CheckBox ExportExcel;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox otyymm_e;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox otyymm_b;
        private System.Windows.Forms.Label label3;
        internal JBControls.TextBox yymm_e;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox yymm_b;
        private System.Windows.Forms.Label label29;
        internal JBControls.TextBox month_e;
        internal JBControls.TextBox month_b;
        internal JBControls.TextBox otmonth_e;
        internal JBControls.TextBox otmonth_b;
    }
}