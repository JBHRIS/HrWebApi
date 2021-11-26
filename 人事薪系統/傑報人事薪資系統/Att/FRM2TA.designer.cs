namespace JBHR.Att
{
    partial class FRM2TA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM2TA));
            this.checkBoxInvalid = new System.Windows.Forms.CheckBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxFixBalance = new System.Windows.Forms.CheckBox();
            this.checkBoxNullGuid = new System.Windows.Forms.CheckBox();
            this.checkBoxReset = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEmp = new System.Windows.Forms.Button();
            this.buttonGen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBeginDate = new JBControls.TextBox();
            this.textBoxEndDate = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrpProgressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxInvalid
            // 
            this.checkBoxInvalid.AutoSize = true;
            this.checkBoxInvalid.Location = new System.Drawing.Point(15, 21);
            this.checkBoxInvalid.Name = "checkBoxInvalid";
            this.checkBoxInvalid.Size = new System.Drawing.Size(128, 16);
            this.checkBoxInvalid.TabIndex = 66;
            this.checkBoxInvalid.TabStop = false;
            this.checkBoxInvalid.Text = "清除無效沖假(全部)";
            this.checkBoxInvalid.UseVisualStyleBackColor = true;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(166, 247);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "執行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxFixBalance);
            this.groupBox1.Controls.Add(this.checkBoxNullGuid);
            this.groupBox1.Controls.Add(this.checkBoxReset);
            this.groupBox1.Controls.Add(this.checkBoxInvalid);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 110);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修正異常";
            // 
            // checkBoxFixBalance
            // 
            this.checkBoxFixBalance.AutoSize = true;
            this.checkBoxFixBalance.Location = new System.Drawing.Point(15, 43);
            this.checkBoxFixBalance.Name = "checkBoxFixBalance";
            this.checkBoxFixBalance.Size = new System.Drawing.Size(96, 16);
            this.checkBoxFixBalance.TabIndex = 66;
            this.checkBoxFixBalance.TabStop = false;
            this.checkBoxFixBalance.Text = "剩餘時數修正";
            this.checkBoxFixBalance.UseVisualStyleBackColor = true;
            // 
            // checkBoxNullGuid
            // 
            this.checkBoxNullGuid.AutoSize = true;
            this.checkBoxNullGuid.Location = new System.Drawing.Point(14, 65);
            this.checkBoxNullGuid.Name = "checkBoxNullGuid";
            this.checkBoxNullGuid.Size = new System.Drawing.Size(96, 16);
            this.checkBoxNullGuid.TabIndex = 66;
            this.checkBoxNullGuid.TabStop = false;
            this.checkBoxNullGuid.Text = "修正編號空白";
            this.checkBoxNullGuid.UseVisualStyleBackColor = true;
            // 
            // checkBoxReset
            // 
            this.checkBoxReset.AutoSize = true;
            this.checkBoxReset.Location = new System.Drawing.Point(14, 87);
            this.checkBoxReset.Name = "checkBoxReset";
            this.checkBoxReset.Size = new System.Drawing.Size(72, 16);
            this.checkBoxReset.TabIndex = 66;
            this.checkBoxReset.TabStop = false;
            this.checkBoxReset.Text = "重新沖假";
            this.checkBoxReset.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonEmp);
            this.groupBox2.Controls.Add(this.buttonGen);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxBeginDate);
            this.groupBox2.Controls.Add(this.textBoxEndDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 113);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "條件";
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(71, 70);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(75, 23);
            this.buttonEmp.TabIndex = 4;
            this.buttonEmp.Text = "選取";
            this.buttonEmp.UseVisualStyleBackColor = true;
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(153, 70);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(75, 23);
            this.buttonGen.TabIndex = 3;
            this.buttonGen.TabStop = false;
            this.buttonGen.Text = "讀取名單";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 72;
            this.label7.Text = "員工";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "請假日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 69;
            this.label5.Text = "至";
            // 
            // textBoxBeginDate
            // 
            this.textBoxBeginDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxBeginDate.CaptionLabel = null;
            this.textBoxBeginDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxBeginDate.DecimalPlace = 2;
            this.textBoxBeginDate.IsEmpty = true;
            this.textBoxBeginDate.Location = new System.Drawing.Point(71, 13);
            this.textBoxBeginDate.Mask = "0000/00/00";
            this.textBoxBeginDate.MaxLength = -1;
            this.textBoxBeginDate.Name = "textBoxBeginDate";
            this.textBoxBeginDate.PasswordChar = '\0';
            this.textBoxBeginDate.ReadOnly = false;
            this.textBoxBeginDate.ShowCalendarButton = true;
            this.textBoxBeginDate.Size = new System.Drawing.Size(71, 22);
            this.textBoxBeginDate.TabIndex = 0;
            this.textBoxBeginDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxEndDate.CaptionLabel = null;
            this.textBoxEndDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxEndDate.DecimalPlace = 2;
            this.textBoxEndDate.IsEmpty = true;
            this.textBoxEndDate.Location = new System.Drawing.Point(174, 13);
            this.textBoxEndDate.Mask = "0000/00/00";
            this.textBoxEndDate.MaxLength = -1;
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.PasswordChar = '\0';
            this.textBoxEndDate.ReadOnly = false;
            this.textBoxEndDate.ShowCalendarButton = true;
            this.textBoxEndDate.Size = new System.Drawing.Size(71, 22);
            this.textBoxEndDate.TabIndex = 1;
            this.textBoxEndDate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 65;
            this.label1.Text = "假別種類";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(71, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "選取";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonExit.Location = new System.Drawing.Point(269, 247);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 56;
            this.buttonExit.TabStop = false;
            this.buttonExit.Text = "離開";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrpProgressbar,
            this.toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 290);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(530, 22);
            this.statusStrip1.TabIndex = 69;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrpProgressbar
            // 
            this.toolStrpProgressbar.Name = "toolStrpProgressbar";
            this.toolStrpProgressbar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FRM2TA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 312);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonRun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM2TA";
            this.Text = "FRM2TA";
            this.Load += new System.EventHandler(this.FRM2TA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxInvalid;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxFixBalance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBoxBeginDate;
        private JBControls.TextBox textBoxEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonEmp;
        private System.Windows.Forms.Button buttonGen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStrpProgressbar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBoxReset;
        private System.Windows.Forms.CheckBox checkBoxNullGuid;
    }
}