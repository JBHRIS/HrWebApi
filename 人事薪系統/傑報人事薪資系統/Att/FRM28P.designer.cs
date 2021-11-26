namespace JBHR.Att
{
    partial class FRM28P
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
            this.buttonEmp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBdate = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEdate = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonRote = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxError = new JBControls.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxEarily = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLate = new JBControls.TextBox();
            this.checkBoxABS = new JBControls.CheckBox();
            this.chkCheck = new JBControls.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtChkDateE = new JBControls.TextBox();
            this.txtChkTimeE = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChkDateB = new JBControls.TextBox();
            this.txtChkTimeB = new JBControls.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(95, 18);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(75, 23);
            this.buttonEmp.TabIndex = 1;
            this.buttonEmp.Text = "選取";
            this.buttonEmp.UseVisualStyleBackColor = true;
            this.buttonEmp.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "員工對象";
            // 
            // txtBdate
            // 
            this.txtBdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBdate.CaptionLabel = null;
            this.txtBdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBdate.DecimalPlace = 2;
            this.txtBdate.IsEmpty = true;
            this.txtBdate.Location = new System.Drawing.Point(95, 47);
            this.txtBdate.Mask = "0000/00/00";
            this.txtBdate.MaxLength = -1;
            this.txtBdate.Name = "txtBdate";
            this.txtBdate.PasswordChar = '\0';
            this.txtBdate.ReadOnly = false;
            this.txtBdate.ShowCalendarButton = true;
            this.txtBdate.Size = new System.Drawing.Size(71, 22);
            this.txtBdate.TabIndex = 2;
            this.txtBdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtBdate.Validated += new System.EventHandler(this.txtBdate_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "出勤日期";
            // 
            // txtEdate
            // 
            this.txtEdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEdate.CaptionLabel = null;
            this.txtEdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEdate.DecimalPlace = 2;
            this.txtEdate.IsEmpty = true;
            this.txtEdate.Location = new System.Drawing.Point(198, 47);
            this.txtEdate.Mask = "0000/00/00";
            this.txtEdate.MaxLength = -1;
            this.txtEdate.Name = "txtEdate";
            this.txtEdate.PasswordChar = '\0';
            this.txtEdate.ReadOnly = false;
            this.txtEdate.ShowCalendarButton = true;
            this.txtEdate.Size = new System.Drawing.Size(71, 22);
            this.txtEdate.TabIndex = 3;
            this.txtEdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtEdate.Validated += new System.EventHandler(this.txtEdate_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "至";
            // 
            // buttonRote
            // 
            this.buttonRote.Location = new System.Drawing.Point(95, 75);
            this.buttonRote.Name = "buttonRote";
            this.buttonRote.Size = new System.Drawing.Size(75, 23);
            this.buttonRote.TabIndex = 4;
            this.buttonRote.Text = "選取";
            this.buttonRote.UseVisualStyleBackColor = true;
            this.buttonRote.Click += new System.EventHandler(this.buttonRote_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "遲到>=";
            // 
            // checkBoxError
            // 
            this.checkBoxError.AutoSize = true;
            this.checkBoxError.CaptionLabel = null;
            this.checkBoxError.IsImitateCaption = true;
            this.checkBoxError.Location = new System.Drawing.Point(40, 185);
            this.checkBoxError.Name = "checkBoxError";
            this.checkBoxError.Size = new System.Drawing.Size(72, 16);
            this.checkBoxError.TabIndex = 33;
            this.checkBoxError.TabStop = false;
            this.checkBoxError.Text = "參考異常";
            this.checkBoxError.UseVisualStyleBackColor = true;
            this.checkBoxError.CheckedChanged += new System.EventHandler(this.checkBoxError_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxEarily);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxLate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBoxABS);
            this.groupBox1.Location = new System.Drawing.Point(36, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 42);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // textBoxEarily
            // 
            this.textBoxEarily.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxEarily.CaptionLabel = null;
            this.textBoxEarily.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxEarily.DecimalPlace = 2;
            this.textBoxEarily.IsEmpty = true;
            this.textBoxEarily.Location = new System.Drawing.Point(156, 14);
            this.textBoxEarily.Mask = "";
            this.textBoxEarily.MaxLength = 4;
            this.textBoxEarily.Name = "textBoxEarily";
            this.textBoxEarily.PasswordChar = '\0';
            this.textBoxEarily.ReadOnly = false;
            this.textBoxEarily.ShowCalendarButton = true;
            this.textBoxEarily.Size = new System.Drawing.Size(45, 22);
            this.textBoxEarily.TabIndex = 9;
            this.textBoxEarily.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "早退>=";
            // 
            // textBoxLate
            // 
            this.textBoxLate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxLate.CaptionLabel = null;
            this.textBoxLate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxLate.DecimalPlace = 2;
            this.textBoxLate.IsEmpty = true;
            this.textBoxLate.Location = new System.Drawing.Point(57, 14);
            this.textBoxLate.Mask = "";
            this.textBoxLate.MaxLength = 4;
            this.textBoxLate.Name = "textBoxLate";
            this.textBoxLate.PasswordChar = '\0';
            this.textBoxLate.ReadOnly = false;
            this.textBoxLate.ShowCalendarButton = true;
            this.textBoxLate.Size = new System.Drawing.Size(45, 22);
            this.textBoxLate.TabIndex = 8;
            this.textBoxLate.ValidType = JBControls.TextBox.EValidType.Integer;
            // 
            // checkBoxABS
            // 
            this.checkBoxABS.AutoSize = true;
            this.checkBoxABS.CaptionLabel = null;
            this.checkBoxABS.IsImitateCaption = true;
            this.checkBoxABS.Location = new System.Drawing.Point(227, 17);
            this.checkBoxABS.Name = "checkBoxABS";
            this.checkBoxABS.Size = new System.Drawing.Size(48, 16);
            this.checkBoxABS.TabIndex = 33;
            this.checkBoxABS.TabStop = false;
            this.checkBoxABS.Text = "曠職";
            this.checkBoxABS.UseVisualStyleBackColor = true;
            this.checkBoxABS.CheckedChanged += new System.EventHandler(this.checkBoxError_CheckedChanged);
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.CaptionLabel = null;
            this.chkCheck.IsImitateCaption = true;
            this.chkCheck.Location = new System.Drawing.Point(40, 250);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(72, 16);
            this.chkCheck.TabIndex = 35;
            this.chkCheck.TabStop = false;
            this.chkCheck.Text = "參考時段";
            this.chkCheck.UseVisualStyleBackColor = true;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "結束時間";
            // 
            // txtChkDateE
            // 
            this.txtChkDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtChkDateE.CaptionLabel = null;
            this.txtChkDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtChkDateE.DecimalPlace = 2;
            this.txtChkDateE.IsEmpty = true;
            this.txtChkDateE.Location = new System.Drawing.Point(69, 39);
            this.txtChkDateE.Mask = "0000/00/00";
            this.txtChkDateE.MaxLength = -1;
            this.txtChkDateE.Name = "txtChkDateE";
            this.txtChkDateE.PasswordChar = '\0';
            this.txtChkDateE.ReadOnly = false;
            this.txtChkDateE.ShowCalendarButton = true;
            this.txtChkDateE.Size = new System.Drawing.Size(71, 22);
            this.txtChkDateE.TabIndex = 12;
            this.txtChkDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // txtChkTimeE
            // 
            this.txtChkTimeE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtChkTimeE.CaptionLabel = null;
            this.txtChkTimeE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtChkTimeE.DecimalPlace = 2;
            this.txtChkTimeE.IsEmpty = true;
            this.txtChkTimeE.Location = new System.Drawing.Point(199, 39);
            this.txtChkTimeE.Mask = "";
            this.txtChkTimeE.MaxLength = 4;
            this.txtChkTimeE.Name = "txtChkTimeE";
            this.txtChkTimeE.PasswordChar = '\0';
            this.txtChkTimeE.ReadOnly = false;
            this.txtChkTimeE.ShowCalendarButton = true;
            this.txtChkTimeE.Size = new System.Drawing.Size(45, 22);
            this.txtChkTimeE.TabIndex = 13;
            this.txtChkTimeE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "開始時間";
            // 
            // txtChkDateB
            // 
            this.txtChkDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtChkDateB.CaptionLabel = null;
            this.txtChkDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtChkDateB.DecimalPlace = 2;
            this.txtChkDateB.IsEmpty = true;
            this.txtChkDateB.Location = new System.Drawing.Point(69, 14);
            this.txtChkDateB.Mask = "0000/00/00";
            this.txtChkDateB.MaxLength = -1;
            this.txtChkDateB.Name = "txtChkDateB";
            this.txtChkDateB.PasswordChar = '\0';
            this.txtChkDateB.ReadOnly = false;
            this.txtChkDateB.ShowCalendarButton = true;
            this.txtChkDateB.Size = new System.Drawing.Size(71, 22);
            this.txtChkDateB.TabIndex = 10;
            this.txtChkDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // txtChkTimeB
            // 
            this.txtChkTimeB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtChkTimeB.CaptionLabel = null;
            this.txtChkTimeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtChkTimeB.DecimalPlace = 2;
            this.txtChkTimeB.IsEmpty = true;
            this.txtChkTimeB.Location = new System.Drawing.Point(199, 14);
            this.txtChkTimeB.Mask = "";
            this.txtChkTimeB.MaxLength = 4;
            this.txtChkTimeB.Name = "txtChkTimeB";
            this.txtChkTimeB.PasswordChar = '\0';
            this.txtChkTimeB.ReadOnly = false;
            this.txtChkTimeB.ShowCalendarButton = true;
            this.txtChkTimeB.Size = new System.Drawing.Size(45, 22);
            this.txtChkTimeB.TabIndex = 11;
            this.txtChkTimeB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtChkDateB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtChkTimeB);
            this.groupBox2.Controls.Add(this.txtChkDateE);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtChkTimeE);
            this.groupBox2.Location = new System.Drawing.Point(36, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 65);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(73, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "產生";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(175, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "假別代碼1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(95, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(95, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(95, 154);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "假別代碼3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "假別代碼2";
            // 
            // FRM28P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 369);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkCheck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxError);
            this.Controls.Add(this.txtBdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEdate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRote);
            this.Controls.Add(this.buttonEmp);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM28P";
            this.Text = "FRM28P";
            this.Load += new System.EventHandler(this.FRM28P_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEmp;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtBdate;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtEdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonRote;
        private System.Windows.Forms.Label label3;
        private JBControls.CheckBox checkBoxError;
        private System.Windows.Forms.GroupBox groupBox1;
        private JBControls.CheckBox chkCheck;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox txtChkDateE;
        private JBControls.TextBox txtChkTimeE;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtChkDateB;
        private JBControls.TextBox txtChkTimeB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private JBControls.TextBox textBoxEarily;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBoxLate;
        private JBControls.CheckBox checkBoxABS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}