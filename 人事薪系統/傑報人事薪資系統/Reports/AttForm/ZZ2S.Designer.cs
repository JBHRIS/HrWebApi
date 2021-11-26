/* ======================================================================================================
 * 功能名稱：扣繳稅額繳款書
 * 功能代號：ZZ2S
 * 功能路徑：報表列印 > 出勤 > 出勤異常通知
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ2S.Designer.cs
 * 功能用途：
 *  用於產出扣繳稅額繳款書與外籍所得稅報帳
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/19    Daniel Chih    Ver 1.0.01     1. 新增通知選項：早來晚走
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/19
 */

namespace JBHR.Reports.AttForm
{
    partial class ZZ2S
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
            this.nobr_b = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.nobr_e = new JBControls.PopupTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HRMail2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.send_type1 = new System.Windows.Forms.RadioButton();
            this.send_type = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.HRMail1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HRMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MailFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TestSubject = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.s_mange = new System.Windows.Forms.CheckBox();
            this.s_person = new System.Windows.Forms.CheckBox();
            this.SendMail = new System.Windows.Forms.Button();
            this.date_e = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_b = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bASETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter();
            this.baseDS = new JBHR.Sal.BaseDS();
            this.report_type = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.SuspendLayout();
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
            this.nobr_b.Location = new System.Drawing.Point(104, 7);
            this.nobr_b.Name = "nobr_b";
            this.nobr_b.ReadOnly = false;
            this.nobr_b.ShowDisplayName = true;
            this.nobr_b.Size = new System.Drawing.Size(80, 22);
            this.nobr_b.TabIndex = 1;
            this.nobr_b.ValueMember = "nobr";
            this.nobr_b.WhereCmd = "";
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
            this.nobr_e.Location = new System.Drawing.Point(274, 7);
            this.nobr_e.Name = "nobr_e";
            this.nobr_e.ReadOnly = false;
            this.nobr_e.ShowDisplayName = true;
            this.nobr_e.Size = new System.Drawing.Size(80, 22);
            this.nobr_e.TabIndex = 2;
            this.nobr_e.ValueMember = "nobr";
            this.nobr_e.WhereCmd = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(242, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 1149;
            this.label14.Text = "至";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(40, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1148;
            this.label7.Text = "員工編號";
            // 
            // HRMail2
            // 
            this.HRMail2.Location = new System.Drawing.Point(104, 179);
            this.HRMail2.Name = "HRMail2";
            this.HRMail2.Size = new System.Drawing.Size(250, 22);
            this.HRMail2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(21, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 1147;
            this.label6.Text = "HR人員MAIL2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(21, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1146;
            this.label5.Text = "MAIL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.send_type1);
            this.groupBox2.Controls.Add(this.send_type);
            this.groupBox2.Location = new System.Drawing.Point(104, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 35);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // send_type1
            // 
            this.send_type1.AutoSize = true;
            this.send_type1.Checked = true;
            this.send_type1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.send_type1.Location = new System.Drawing.Point(60, 12);
            this.send_type1.Name = "send_type1";
            this.send_type1.Size = new System.Drawing.Size(53, 17);
            this.send_type1.TabIndex = 12;
            this.send_type1.TabStop = true;
            this.send_type1.Text = "測試";
            this.send_type1.UseVisualStyleBackColor = true;
            // 
            // send_type
            // 
            this.send_type.AutoSize = true;
            this.send_type.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.send_type.Location = new System.Drawing.Point(6, 12);
            this.send_type.Name = "send_type";
            this.send_type.Size = new System.Drawing.Size(53, 17);
            this.send_type.TabIndex = 11;
            this.send_type.Text = "正式";
            this.send_type.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(66, 246);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 1145;
            this.label24.Text = "發送";
            // 
            // HRMail1
            // 
            this.HRMail1.Location = new System.Drawing.Point(104, 150);
            this.HRMail1.Name = "HRMail1";
            this.HRMail1.Size = new System.Drawing.Size(250, 22);
            this.HRMail1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(21, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1144;
            this.label3.Text = "HR人員MAIL1";
            // 
            // HRMail
            // 
            this.HRMail.Location = new System.Drawing.Point(104, 118);
            this.HRMail.Name = "HRMail";
            this.HRMail.Size = new System.Drawing.Size(250, 22);
            this.HRMail.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(21, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1143;
            this.label2.Text = "HR人員/測試";
            // 
            // MailFrom
            // 
            this.MailFrom.Location = new System.Drawing.Point(104, 91);
            this.MailFrom.Name = "MailFrom";
            this.MailFrom.Size = new System.Drawing.Size(250, 22);
            this.MailFrom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(52, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1142;
            this.label1.Text = "寄件者";
            // 
            // TestSubject
            // 
            this.TestSubject.Location = new System.Drawing.Point(104, 64);
            this.TestSubject.Name = "TestSubject";
            this.TestSubject.Size = new System.Drawing.Size(250, 22);
            this.TestSubject.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(39, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 1141;
            this.label13.Text = "測試主旨";
            // 
            // s_mange
            // 
            this.s_mange.AutoSize = true;
            this.s_mange.Checked = true;
            this.s_mange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.s_mange.Location = new System.Drawing.Point(196, 280);
            this.s_mange.Name = "s_mange";
            this.s_mange.Size = new System.Drawing.Size(96, 16);
            this.s_mange.TabIndex = 14;
            this.s_mange.Text = "通知部門主管";
            this.s_mange.UseVisualStyleBackColor = true;
            // 
            // s_person
            // 
            this.s_person.AutoSize = true;
            this.s_person.Checked = true;
            this.s_person.CheckState = System.Windows.Forms.CheckState.Checked;
            this.s_person.Location = new System.Drawing.Point(103, 280);
            this.s_person.Name = "s_person";
            this.s_person.Size = new System.Drawing.Size(72, 16);
            this.s_person.TabIndex = 13;
            this.s_person.Text = "通知個人";
            this.s_person.UseVisualStyleBackColor = true;
            // 
            // SendMail
            // 
            this.SendMail.Location = new System.Drawing.Point(158, 308);
            this.SendMail.Name = "SendMail";
            this.SendMail.Size = new System.Drawing.Size(75, 23);
            this.SendMail.TabIndex = 15;
            this.SendMail.Text = "發送通知";
            this.SendMail.UseVisualStyleBackColor = true;
            this.SendMail.Click += new System.EventHandler(this.SendMail_Click);
            // 
            // date_e
            // 
            this.date_e.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.date_e.CaptionLabel = null;
            this.date_e.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.date_e.DecimalPlace = 2;
            this.date_e.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.date_e.IsEmpty = false;
            this.date_e.Location = new System.Drawing.Point(274, 35);
            this.date_e.Mask = "0000/00/00";
            this.date_e.MaxLength = -1;
            this.date_e.Name = "date_e";
            this.date_e.PasswordChar = '\0';
            this.date_e.ReadOnly = false;
            this.date_e.ShowCalendarButton = true;
            this.date_e.Size = new System.Drawing.Size(80, 23);
            this.date_e.TabIndex = 4;
            this.date_e.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(242, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 1140;
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
            this.date_b.Location = new System.Drawing.Point(104, 35);
            this.date_b.Mask = "0000/00/00";
            this.date_b.MaxLength = -1;
            this.date_b.Name = "date_b";
            this.date_b.PasswordChar = '\0';
            this.date_b.ReadOnly = false;
            this.date_b.ShowCalendarButton = true;
            this.date_b.Size = new System.Drawing.Size(80, 23);
            this.date_b.TabIndex = 3;
            this.date_b.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(39, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 1139;
            this.label9.Text = "出勤日期";
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
            // report_type
            // 
            this.report_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.report_type.FormattingEnabled = true;
            this.report_type.Items.AddRange(new object[] {
            "出勤異常",
            "早來晚走"});
            this.report_type.Location = new System.Drawing.Point(104, 207);
            this.report_type.Name = "report_type";
            this.report_type.Size = new System.Drawing.Size(200, 20);
            this.report_type.TabIndex = 10;
            this.report_type.SelectedIndexChanged += new System.EventHandler(this.report_type_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(39, 210);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 1151;
            this.label17.Text = "發送種類";
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(352, 308);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1152;
            this.btnConfig.Tag = "ZZ2S";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // ZZ2S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 342);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.report_type);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.nobr_b);
            this.Controls.Add(this.nobr_e);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.HRMail2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.HRMail1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HRMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MailFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TestSubject);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.s_mange);
            this.Controls.Add(this.s_person);
            this.Controls.Add(this.SendMail);
            this.Controls.Add(this.date_e);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date_b);
            this.Controls.Add(this.label9);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "ZZ2S";
            this.Text = "出勤異常通知";
            this.Load += new System.EventHandler(this.ZZ2S_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JBControls.PopupTextBox nobr_b;
        private JBControls.PopupTextBox nobr_e;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox HRMail2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton send_type1;
        internal System.Windows.Forms.RadioButton send_type;
        private System.Windows.Forms.Label label24;
        internal System.Windows.Forms.TextBox HRMail1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox HRMail;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox MailFrom;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox TestSubject;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox s_mange;
        private System.Windows.Forms.CheckBox s_person;
        private System.Windows.Forms.Button SendMail;
        internal JBControls.TextBox date_e;
        private System.Windows.Forms.Label label4;
        internal JBControls.TextBox date_b;
        private System.Windows.Forms.Label label9;
        private Sal.SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private Sal.BaseDS baseDS;
        internal System.Windows.Forms.ComboBox report_type;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnConfig;
    }
}