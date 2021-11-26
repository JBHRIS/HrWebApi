namespace JBHR.Sal
{
    partial class FRM4OP
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
            this.txtBdate = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEdate = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonGen = new System.Windows.Forms.Button();
            this.textBoxYYMM = new JBControls.TextBox();
            this.textBoxSeq = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOutEndDate = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOutBeginDate = new JBControls.TextBox();
            this.buttonEmpOut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBdate
            // 
            this.txtBdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBdate.CaptionLabel = null;
            this.txtBdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBdate.DecimalPlace = 2;
            this.txtBdate.IsEmpty = true;
            this.txtBdate.Location = new System.Drawing.Point(103, 81);
            this.txtBdate.Mask = "0000/00/00";
            this.txtBdate.MaxLength = -1;
            this.txtBdate.Name = "txtBdate";
            this.txtBdate.PasswordChar = '\0';
            this.txtBdate.ReadOnly = false;
            this.txtBdate.ShowCalendarButton = true;
            this.txtBdate.Size = new System.Drawing.Size(71, 22);
            this.txtBdate.TabIndex = 4;
            this.txtBdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtBdate.Validated += new System.EventHandler(this.txtBdate_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "結算日期";
            // 
            // txtEdate
            // 
            this.txtEdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEdate.CaptionLabel = null;
            this.txtEdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEdate.DecimalPlace = 2;
            this.txtEdate.IsEmpty = true;
            this.txtEdate.Location = new System.Drawing.Point(206, 81);
            this.txtEdate.Mask = "0000/00/00";
            this.txtEdate.MaxLength = -1;
            this.txtEdate.Name = "txtEdate";
            this.txtEdate.PasswordChar = '\0';
            this.txtEdate.ReadOnly = false;
            this.txtEdate.ShowCalendarButton = true;
            this.txtEdate.Size = new System.Drawing.Size(71, 22);
            this.txtEdate.TabIndex = 5;
            this.txtEdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "員工對象";
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(103, 109);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(75, 23);
            this.buttonEmp.TabIndex = 6;
            this.buttonEmp.Text = "選取";
            this.buttonEmp.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "選取";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "參考薪資";
            // 
            // buttonRun
            // 
            this.buttonRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonRun.Location = new System.Drawing.Point(168, 232);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 11;
            this.buttonRun.Text = "產生";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(298, 24);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(75, 23);
            this.buttonGen.TabIndex = 2;
            this.buttonGen.TabStop = false;
            this.buttonGen.Text = "產生名單";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // textBoxYYMM
            // 
            this.textBoxYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM.CaptionLabel = null;
            this.textBoxYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM.DecimalPlace = 2;
            this.textBoxYYMM.IsEmpty = true;
            this.textBoxYYMM.Location = new System.Drawing.Point(105, 195);
            this.textBoxYYMM.Mask = "";
            this.textBoxYYMM.MaxLength = -1;
            this.textBoxYYMM.Name = "textBoxYYMM";
            this.textBoxYYMM.PasswordChar = '\0';
            this.textBoxYYMM.ReadOnly = false;
            this.textBoxYYMM.ShowCalendarButton = true;
            this.textBoxYYMM.Size = new System.Drawing.Size(71, 22);
            this.textBoxYYMM.TabIndex = 9;
            this.textBoxYYMM.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxSeq
            // 
            this.textBoxSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSeq.CaptionLabel = null;
            this.textBoxSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSeq.DecimalPlace = 2;
            this.textBoxSeq.IsEmpty = true;
            this.textBoxSeq.Location = new System.Drawing.Point(183, 195);
            this.textBoxSeq.Mask = "";
            this.textBoxSeq.MaxLength = -1;
            this.textBoxSeq.Name = "textBoxSeq";
            this.textBoxSeq.PasswordChar = '\0';
            this.textBoxSeq.ReadOnly = false;
            this.textBoxSeq.ShowCalendarButton = true;
            this.textBoxSeq.Size = new System.Drawing.Size(30, 22);
            this.textBoxSeq.TabIndex = 10;
            this.textBoxSeq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "年月期別";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "至";
            // 
            // textBoxOutEndDate
            // 
            this.textBoxOutEndDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxOutEndDate.CaptionLabel = null;
            this.textBoxOutEndDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxOutEndDate.DecimalPlace = 2;
            this.textBoxOutEndDate.IsEmpty = true;
            this.textBoxOutEndDate.Location = new System.Drawing.Point(206, 24);
            this.textBoxOutEndDate.Mask = "0000/00/00";
            this.textBoxOutEndDate.MaxLength = -1;
            this.textBoxOutEndDate.Name = "textBoxOutEndDate";
            this.textBoxOutEndDate.PasswordChar = '\0';
            this.textBoxOutEndDate.ReadOnly = false;
            this.textBoxOutEndDate.ShowCalendarButton = true;
            this.textBoxOutEndDate.Size = new System.Drawing.Size(71, 22);
            this.textBoxOutEndDate.TabIndex = 1;
            this.textBoxOutEndDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "離職日期";
            // 
            // textBoxOutBeginDate
            // 
            this.textBoxOutBeginDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxOutBeginDate.CaptionLabel = null;
            this.textBoxOutBeginDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxOutBeginDate.DecimalPlace = 2;
            this.textBoxOutBeginDate.IsEmpty = true;
            this.textBoxOutBeginDate.Location = new System.Drawing.Point(103, 24);
            this.textBoxOutBeginDate.Mask = "0000/00/00";
            this.textBoxOutBeginDate.MaxLength = -1;
            this.textBoxOutBeginDate.Name = "textBoxOutBeginDate";
            this.textBoxOutBeginDate.PasswordChar = '\0';
            this.textBoxOutBeginDate.ReadOnly = false;
            this.textBoxOutBeginDate.ShowCalendarButton = true;
            this.textBoxOutBeginDate.Size = new System.Drawing.Size(71, 22);
            this.textBoxOutBeginDate.TabIndex = 0;
            this.textBoxOutBeginDate.ValidType = JBControls.TextBox.EValidType.Date;
            this.textBoxOutBeginDate.Validated += new System.EventHandler(this.textBoxOutBeginDate_Validated);
            // 
            // buttonEmpOut
            // 
            this.buttonEmpOut.Location = new System.Drawing.Point(103, 52);
            this.buttonEmpOut.Name = "buttonEmpOut";
            this.buttonEmpOut.Size = new System.Drawing.Size(75, 23);
            this.buttonEmpOut.TabIndex = 3;
            this.buttonEmpOut.Text = "選取";
            this.buttonEmpOut.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "離職員工";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "假別";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "選取";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FRM4OP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(431, 270);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSeq);
            this.Controls.Add(this.textBoxYYMM);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxOutBeginDate);
            this.Controls.Add(this.txtBdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOutEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEdate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGen);
            this.Controls.Add(this.buttonEmpOut);
            this.Controls.Add(this.buttonEmp);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM4OP";
            this.Load += new System.EventHandler(this.FRM4O_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private BaseDS baseDS;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Sal.BaseDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private System.Windows.Forms.BindingSource jOBLBindingSource;
        private JBHR.Sal.BaseDSTableAdapters.JOBLTableAdapter jOBLTableAdapter;
        private System.Windows.Forms.BindingSource jOBLBindingSource1;
        private ViewDS viewDS;
        private System.Windows.Forms.BindingSource fRM4PPRINTTYPEBindingSource;
        private JBHR.Sal.ViewDSTableAdapters.FRM4P_PRINTTYPETableAdapter fRM4P_PRINTTYPETableAdapter;
        private System.Windows.Forms.Button btnExit;
        private JBControls.TextBox txtBdate;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtEdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEmp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonGen;
        private JBControls.TextBox textBoxYYMM;
        private JBControls.TextBox textBoxSeq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBoxOutEndDate;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBoxOutBeginDate;
        private System.Windows.Forms.Button buttonEmpOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
    }
}