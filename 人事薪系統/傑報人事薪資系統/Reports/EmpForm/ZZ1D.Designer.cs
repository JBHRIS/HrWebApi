/* ======================================================================================================
 * 功能名稱：服務證明
 * 功能代號：ZZ1D
 * 功能路徑：報表列印 > 人事 > 服務證明
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1D.Designer.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/10    Daniel Chih    Ver 1.0.01     1. 新增報表選項：非自願離職證明
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/10
 */

namespace JBHR.Reports.EmpForm
{
    partial class ZZ1D
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
            this.report_type2 = new System.Windows.Forms.RadioButton();
            this.report_type1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LeaveForm = new System.Windows.Forms.Button();
            this.Create_Report = new System.Windows.Forms.Button();
            this.date_b = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comp_e = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comp_b = new System.Windows.Forms.ComboBox();
            this.dept_e = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dept_b = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.type_indt1 = new System.Windows.Forms.RadioButton();
            this.type_indt2 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.nobr_e = new JBControls.PopupTextBox();
            this.nobr_b = new JBControls.PopupTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.note2 = new System.Windows.Forms.TextBox();
            this.note1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.NonSelf_Resign_Report_Type = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.NonSelf_Resign_Report_Type);
            this.groupBox4.Controls.Add(this.report_type2);
            this.groupBox4.Controls.Add(this.report_type1);
            this.groupBox4.Location = new System.Drawing.Point(105, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(297, 35);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // report_type2
            // 
            this.report_type2.AutoSize = true;
            this.report_type2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.report_type2.Location = new System.Drawing.Point(87, 12);
            this.report_type2.Name = "report_type2";
            this.report_type2.Size = new System.Drawing.Size(81, 17);
            this.report_type2.TabIndex = 15;
            this.report_type2.Text = "離職證明";
            this.report_type2.UseVisualStyleBackColor = true;
            // 
            // report_type1
            // 
            this.report_type1.AutoSize = true;
            this.report_type1.Checked = true;
            this.report_type1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.report_type1.Location = new System.Drawing.Point(5, 12);
            this.report_type1.Name = "report_type1";
            this.report_type1.Size = new System.Drawing.Size(81, 17);
            this.report_type1.TabIndex = 14;
            this.report_type1.TabStop = true;
            this.report_type1.Text = "服務證明";
            this.report_type1.UseVisualStyleBackColor = true;
            // 
            // NonSelf_Resign_Report_Type
            // 
            this.NonSelf_Resign_Report_Type.AutoSize = true;
            this.NonSelf_Resign_Report_Type.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NonSelf_Resign_Report_Type.Location = new System.Drawing.Point(169, 12);
            this.NonSelf_Resign_Report_Type.Name = "NonSelf_Resign_Report_Type";
            this.NonSelf_Resign_Report_Type.Size = new System.Drawing.Size(123, 17);
            this.NonSelf_Resign_Report_Type.TabIndex = 16;
            this.NonSelf_Resign_Report_Type.Text = "非自願離職證明";
            this.NonSelf_Resign_Report_Type.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 648;
            this.label1.Text = "報表種類";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 647;
            this.label14.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 646;
            this.label6.Text = "員工編號";
            // 
            // LeaveForm
            // 
            this.LeaveForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LeaveForm.Location = new System.Drawing.Point(261, 309);
            this.LeaveForm.Name = "LeaveForm";
            this.LeaveForm.Size = new System.Drawing.Size(75, 23);
            this.LeaveForm.TabIndex = 17;
            this.LeaveForm.Text = "離開";
            this.LeaveForm.UseVisualStyleBackColor = true;
            this.LeaveForm.Click += new System.EventHandler(this.LeaveForm_Click);
            // 
            // Create_Report
            // 
            this.Create_Report.Location = new System.Drawing.Point(109, 309);
            this.Create_Report.Name = "Create_Report";
            this.Create_Report.Size = new System.Drawing.Size(75, 23);
            this.Create_Report.TabIndex = 16;
            this.Create_Report.Text = "產生";
            this.Create_Report.UseVisualStyleBackColor = true;
            this.Create_Report.Click += new System.EventHandler(this.Create_Report_Click);
            // 
            // date_b
            // 
            this.date_b.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_b.CaptionLabel = null;
            this.date_b.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_b.DecimalPlace = 2;
            this.date_b.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_b.IsEmpty = false;
            this.date_b.Location = new System.Drawing.Point(104, 88);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 7;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 644;
            this.label3.Text = "異動截止日";
            // 
            // comp_e
            // 
            this.comp_e.DisplayMember = "compname";
            this.comp_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_e.FormattingEnabled = true;
            this.comp_e.Location = new System.Drawing.Point(280, 62);
            this.comp_e.Name = "comp_e";
            this.comp_e.Size = new System.Drawing.Size(130, 20);
            this.comp_e.TabIndex = 6;
            this.comp_e.ValueMember = "comp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(242, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 643;
            this.label20.Text = "至";
            // 
            // comp_b
            // 
            this.comp_b.DisplayMember = "compname";
            this.comp_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_b.FormattingEnabled = true;
            this.comp_b.Location = new System.Drawing.Point(104, 62);
            this.comp_b.Name = "comp_b";
            this.comp_b.Size = new System.Drawing.Size(130, 20);
            this.comp_b.TabIndex = 5;
            this.comp_b.ValueMember = "comp";
            // 
            // dept_e
            // 
            this.dept_e.DisplayMember = "d_name";
            this.dept_e.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_e.FormattingEnabled = true;
            this.dept_e.Location = new System.Drawing.Point(280, 35);
            this.dept_e.Name = "dept_e";
            this.dept_e.Size = new System.Drawing.Size(130, 20);
            this.dept_e.TabIndex = 4;
            this.dept_e.ValueMember = "d_no";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(242, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 639;
            this.label15.Text = "至";
            // 
            // dept_b
            // 
            this.dept_b.DisplayMember = "d_name";
            this.dept_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dept_b.FormattingEnabled = true;
            this.dept_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dept_b.Location = new System.Drawing.Point(104, 35);
            this.dept_b.Name = "dept_b";
            this.dept_b.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dept_b.Size = new System.Drawing.Size(130, 20);
            this.dept_b.TabIndex = 3;
            this.dept_b.ValueMember = "d_no";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(68, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 637;
            this.label12.Text = "公司";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 633;
            this.label7.Text = "編制部門";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(40, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 649;
            this.label4.Text = "年資資料";
            // 
            // type_indt1
            // 
            this.type_indt1.AutoSize = true;
            this.type_indt1.Checked = true;
            this.type_indt1.Location = new System.Drawing.Point(5, 12);
            this.type_indt1.Name = "type_indt1";
            this.type_indt1.Size = new System.Drawing.Size(83, 16);
            this.type_indt1.TabIndex = 10;
            this.type_indt1.TabStop = true;
            this.type_indt1.Text = "公司到職日";
            this.type_indt1.UseVisualStyleBackColor = true;
            // 
            // type_indt2
            // 
            this.type_indt2.AutoSize = true;
            this.type_indt2.Location = new System.Drawing.Point(94, 12);
            this.type_indt2.Name = "type_indt2";
            this.type_indt2.Size = new System.Drawing.Size(83, 16);
            this.type_indt2.TabIndex = 11;
            this.type_indt2.Text = "集團到職日";
            this.type_indt2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.type_indt2);
            this.groupBox3.Controls.Add(this.type_indt1);
            this.groupBox3.Location = new System.Drawing.Point(105, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 35);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "BaseDS";
            this.baseDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(75, 22);
            this.nobr_e.TabIndex = 2;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
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
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(75, 22);
            this.nobr_b.TabIndex = 1;
            this.nobr_b.ValueMember = "nobr";
            this.nobr_b.WhereCmd = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(68, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1100;
            this.label9.Text = "編號";
            // 
            // note2
            // 
            this.note2.Location = new System.Drawing.Point(104, 117);
            this.note2.Name = "note2";
            this.note2.Size = new System.Drawing.Size(232, 22);
            this.note2.TabIndex = 8;
            // 
            // note1
            // 
            this.note1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.note1.Location = new System.Drawing.Point(104, 148);
            this.note1.Multiline = true;
            this.note1.Name = "note1";
            this.note1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.note1.Size = new System.Drawing.Size(256, 50);
            this.note1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(67, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1104;
            this.label5.Text = "事由";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(104, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 12);
            this.label2.TabIndex = 1105;
            this.label2.Text = "輸入請勿超過二行,換行請按Ctrl+Enter鍵";
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(435, 309);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 906;
            this.btnConfig.Tag = "ZZ1D";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // ZZ1D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 355);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.note1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.note2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LeaveForm);
            this.Controls.Add(this.Create_Report);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comp_e);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comp_b);
            this.Controls.Add(this.dept_e);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dept_b);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ1D";
            this.Text = "服務證明書";
            this.Load += new System.EventHandler(this.ZZ1D_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.RadioButton report_type2;
        internal System.Windows.Forms.RadioButton report_type1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button LeaveForm;
        private System.Windows.Forms.Button Create_Report;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox comp_e;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox comp_b;
        internal System.Windows.Forms.ComboBox dept_e;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox dept_b;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.RadioButton type_indt1;
        internal System.Windows.Forms.RadioButton type_indt2;
        private System.Windows.Forms.GroupBox groupBox3;
        private JBHR.Sal.BaseDS baseDS;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDS salaryDS;
        private JBControls.PopupTextBox nobr_e;
        private JBControls.PopupTextBox nobr_b;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox note2;
        internal System.Windows.Forms.TextBox note1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfig;
        internal System.Windows.Forms.RadioButton NonSelf_Resign_Report_Type;
    }
}