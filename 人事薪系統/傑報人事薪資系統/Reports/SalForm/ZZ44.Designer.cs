/* ======================================================================================================
 * 功能名稱：加班費用分析表
 * 功能代號：ZZ44
 * 功能路徑：報表列印 > 薪資 > 加班費用分析表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ44.Designer.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/29    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/01/29
 */

namespace JBHR.Reports.SalForm
{
    partial class ZZ44
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
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.otyymm_e = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.otyymm_b = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yymm_e = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yymm_b = new JBControls.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ExportExcel = new System.Windows.Forms.CheckBox();
            this.otmonth_e = new JBControls.TextBox();
            this.otmonth_b = new JBControls.TextBox();
            this.month_e = new JBControls.TextBox();
            this.month_b = new JBControls.TextBox();
            this.emp_e = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.emp_b = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LeaveForm
            // 
            this.LeaveForm.Location = new System.Drawing.Point(261, 180);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 17;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(109, 180);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 16;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // otyymm_e
            // 
            this.otyymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otyymm_e.CaptionLabel = null;
            this.otyymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otyymm_e.DecimalPlace = 2;
            this.otyymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otyymm_e.IsEmpty = false;
            this.otyymm_e.Location = new System.Drawing.Point(280, 115);
            this.otyymm_e.Mask = "";
            this.otyymm_e.MaxLength = -1;
            this.otyymm_e.Name = "otyymm_e";
            this.otyymm_e.PasswordChar = '\0';
            this.otyymm_e.ReadOnly = false;
            this.otyymm_e.ShowCalendarButton = true;
            this.otyymm_e.Size = new System.Drawing.Size(30, 23);
            this.otyymm_e.TabIndex = 13;
            this.otyymm_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(242, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 949;
            this.label1.Text = "至";
            // 
            // otyymm_b
            // 
            this.otyymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otyymm_b.CaptionLabel = null;
            this.otyymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otyymm_b.DecimalPlace = 2;
            this.otyymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otyymm_b.IsEmpty = false;
            this.otyymm_b.Location = new System.Drawing.Point(104, 115);
            this.otyymm_b.Mask = "";
            this.otyymm_b.MaxLength = -1;
            this.otyymm_b.Name = "otyymm_b";
            this.otyymm_b.PasswordChar = '\0';
            this.otyymm_b.ReadOnly = false;
            this.otyymm_b.ShowCalendarButton = true;
            this.otyymm_b.Size = new System.Drawing.Size(30, 23);
            this.otyymm_b.TabIndex = 11;
            this.otyymm_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 948;
            this.label2.Text = "比較年月";
            // 
            // yymm_e
            // 
            this.yymm_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_e.CaptionLabel = null;
            this.yymm_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_e.DecimalPlace = 2;
            this.yymm_e.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_e.IsEmpty = false;
            this.yymm_e.Location = new System.Drawing.Point(280, 87);
            this.yymm_e.Mask = "";
            this.yymm_e.MaxLength = -1;
            this.yymm_e.Name = "yymm_e";
            this.yymm_e.PasswordChar = '\0';
            this.yymm_e.ReadOnly = false;
            this.yymm_e.ShowCalendarButton = true;
            this.yymm_e.Size = new System.Drawing.Size(30, 23);
            this.yymm_e.TabIndex = 9;
            this.yymm_e.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(242, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 947;
            this.label9.Text = "至";
            // 
            // yymm_b
            // 
            this.yymm_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.yymm_b.CaptionLabel = null;
            this.yymm_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.yymm_b.DecimalPlace = 2;
            this.yymm_b.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yymm_b.IsEmpty = false;
            this.yymm_b.Location = new System.Drawing.Point(104, 87);
            this.yymm_b.Mask = "";
            this.yymm_b.MaxLength = -1;
            this.yymm_b.Name = "yymm_b";
            this.yymm_b.PasswordChar = '\0';
            this.yymm_b.ReadOnly = false;
            this.yymm_b.ShowCalendarButton = true;
            this.yymm_b.Size = new System.Drawing.Size(30, 23);
            this.yymm_b.TabIndex = 7;
            this.yymm_b.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label29.Location = new System.Drawing.Point(40, 92);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 946;
            this.label29.Text = "基準年月";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
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
            this.label15.TabIndex = 962;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 33);
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
            this.label7.Location = new System.Drawing.Point(40, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 961;
            this.label7.Text = "編制部門";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(242, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 966;
            this.label22.Text = "至";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 7);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 2;
            this.comp_e.ValueMember = "comp";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 7);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 1;
            this.comp_b.ValueMember = "comp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(67, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 965;
            this.label12.Text = "公司";
            // 
            // ExportExcel
            // 
            this.ExportExcel.AutoSize = true;
            this.ExportExcel.Location = new System.Drawing.Point(104, 154);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(78, 16);
            this.ExportExcel.TabIndex = 15;
            this.ExportExcel.Text = "匯出Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            // 
            // otmonth_e
            // 
            this.otmonth_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.otmonth_e.CaptionLabel = null;
            this.otmonth_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otmonth_e.DecimalPlace = 2;
            this.otmonth_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.otmonth_e.IsEmpty = false;
            this.otmonth_e.Location = new System.Drawing.Point(310, 115);
            this.otmonth_e.Mask = "";
            this.otmonth_e.MaxLength = -1;
            this.otmonth_e.Name = "otmonth_e";
            this.otmonth_e.PasswordChar = '\0';
            this.otmonth_e.ReadOnly = false;
            this.otmonth_e.ShowCalendarButton = true;
            this.otmonth_e.Size = new System.Drawing.Size(25, 23);
            this.otmonth_e.TabIndex = 14;
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
            this.otmonth_b.Location = new System.Drawing.Point(134, 115);
            this.otmonth_b.Mask = "";
            this.otmonth_b.MaxLength = -1;
            this.otmonth_b.Name = "otmonth_b";
            this.otmonth_b.PasswordChar = '\0';
            this.otmonth_b.ReadOnly = false;
            this.otmonth_b.ShowCalendarButton = true;
            this.otmonth_b.Size = new System.Drawing.Size(25, 23);
            this.otmonth_b.TabIndex = 12;
            this.otmonth_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.otmonth_b.Validated += new System.EventHandler(this.otmonth_b_Validated);
            // 
            // month_e
            // 
            this.month_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.month_e.CaptionLabel = null;
            this.month_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.month_e.DecimalPlace = 2;
            this.month_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.month_e.IsEmpty = false;
            this.month_e.Location = new System.Drawing.Point(310, 87);
            this.month_e.Mask = "";
            this.month_e.MaxLength = -1;
            this.month_e.Name = "month_e";
            this.month_e.PasswordChar = '\0';
            this.month_e.ReadOnly = false;
            this.month_e.ShowCalendarButton = true;
            this.month_e.Size = new System.Drawing.Size(25, 23);
            this.month_e.TabIndex = 10;
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
            this.month_b.Location = new System.Drawing.Point(134, 87);
            this.month_b.Mask = "";
            this.month_b.MaxLength = -1;
            this.month_b.Name = "month_b";
            this.month_b.PasswordChar = '\0';
            this.month_b.ReadOnly = false;
            this.month_b.ShowCalendarButton = true;
            this.month_b.Size = new System.Drawing.Size(25, 23);
            this.month_b.TabIndex = 8;
            this.month_b.ValidType = JBControls.TextBox.EValidType.Integer;
            this.month_b.Validated += new System.EventHandler(this.month_b_Validated);
            // 
            // emp_e
            // 
            this.emp_e.DisplayMember = "empdescr";
            this.emp_e.FormattingEnabled = true;
            this.emp_e.Location = new System.Drawing.Point(279, 58);
            this.emp_e.Name = "emp_e";
            this.emp_e.Size = new System.Drawing.Size(130, 20);
            this.emp_e.TabIndex = 6;
            this.emp_e.ValueMember = "empcd";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(241, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 970;
            this.label19.Text = "至";
            // 
            // emp_b
            // 
            this.emp_b.DisplayMember = "empdescr";
            this.emp_b.FormattingEnabled = true;
            this.emp_b.Location = new System.Drawing.Point(103, 58);
            this.emp_b.Name = "emp_b";
            this.emp_b.Size = new System.Drawing.Size(130, 20);
            this.emp_b.TabIndex = 5;
            this.emp_b.ValueMember = "empcd";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(67, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 969;
            this.label11.Text = "員別";
            // 
            // ZZ44
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 225);
            this.Controls.Add(this.emp_e);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.emp_b);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.otmonth_e);
            this.Controls.Add(this.otmonth_b);
            this.Controls.Add(this.month_e);
            this.Controls.Add(this.month_b);
            this.Controls.Add(this.ExportExcel);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.otyymm_e);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.otyymm_b);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yymm_e);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.yymm_b);
            this.Controls.Add(this.label29);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ44";
            this.Text = "加班費年月比較分析表";
            this.Load += new System.EventHandler(this.ZZ44_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox otyymm_e;
        private System.Windows.Forms.Label label1;
        internal JBControls.TextBox otyymm_b;
        private System.Windows.Forms.Label label2;
        internal JBControls.TextBox yymm_e;
        private System.Windows.Forms.Label label9;
        internal JBControls.TextBox yymm_b;
        private System.Windows.Forms.Label label29;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox comp_e;
        internal System.Windows.Forms.ComboBox comp_b;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.CheckBox ExportExcel;
        internal JBControls.TextBox otmonth_e;
        internal JBControls.TextBox otmonth_b;
        internal JBControls.TextBox month_e;
        internal JBControls.TextBox month_b;
        internal System.Windows.Forms.ComboBox emp_e;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox emp_b;
        private System.Windows.Forms.Label label11;
    }
}