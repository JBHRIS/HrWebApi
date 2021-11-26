namespace JBHR.Sal
{
    partial class FRM4ADV
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbDate = new System.Windows.Forms.Label();
            this.dtpBDate = new System.Windows.Forms.DateTimePicker();
            this.lbEmp = new System.Windows.Forms.Label();
            this.btnEmp = new System.Windows.Forms.Button();
            this.lbOTDate = new System.Windows.Forms.Label();
            this.txtYYMM = new System.Windows.Forms.TextBox();
            this.chkWriteOff = new System.Windows.Forms.CheckBox();
            this.chkOverride = new System.Windows.Forms.CheckBox();
            this.dtpEDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHCodeType = new System.Windows.Forms.Button();
            this.chkYearClose = new System.Windows.Forms.CheckBox();
            this.btnGenEmp = new System.Windows.Forms.Button();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lbDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpBDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbOTDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtYYMM, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkWriteOff, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkOverride, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpEDate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnHCodeType, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkYearClose, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnGenEmp, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGen, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnConfig, 6, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(416, 197);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(30, 8);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(53, 12);
            this.lbDate.TabIndex = 28;
            this.lbDate.Text = "借假日期";
            // 
            // dtpBDate
            // 
            this.dtpBDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.dtpBDate, 2);
            this.dtpBDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBDate.Location = new System.Drawing.Point(89, 3);
            this.dtpBDate.Name = "dtpBDate";
            this.dtpBDate.Size = new System.Drawing.Size(114, 22);
            this.dtpBDate.TabIndex = 0;
            this.dtpBDate.CloseUp += new System.EventHandler(this.dtpBDate_CloseUp);
            // 
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.Location = new System.Drawing.Point(30, 64);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 3;
            this.lbEmp.Text = "員工對象";
            // 
            // btnEmp
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnEmp, 2);
            this.btnEmp.Location = new System.Drawing.Point(89, 59);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(114, 22);
            this.btnEmp.TabIndex = 4;
            this.btnEmp.Text = "選取員工";
            this.btnEmp.UseVisualStyleBackColor = true;
            // 
            // lbOTDate
            // 
            this.lbOTDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbOTDate.AutoSize = true;
            this.lbOTDate.Location = new System.Drawing.Point(6, 36);
            this.lbOTDate.Name = "lbOTDate";
            this.lbOTDate.Size = new System.Drawing.Size(77, 12);
            this.lbOTDate.TabIndex = 43;
            this.lbOTDate.Text = "沖銷計薪年月";
            // 
            // txtYYMM
            // 
            this.txtYYMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYYMM.Location = new System.Drawing.Point(89, 31);
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.Size = new System.Drawing.Size(54, 22);
            this.txtYYMM.TabIndex = 2;
            this.txtYYMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkWriteOff
            // 
            this.chkWriteOff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkWriteOff.AutoSize = true;
            this.chkWriteOff.Location = new System.Drawing.Point(89, 118);
            this.chkWriteOff.Name = "chkWriteOff";
            this.chkWriteOff.Size = new System.Drawing.Size(48, 16);
            this.chkWriteOff.TabIndex = 6;
            this.chkWriteOff.TabStop = false;
            this.chkWriteOff.Text = "沖假";
            this.chkWriteOff.UseVisualStyleBackColor = true;
            this.chkWriteOff.CheckedChanged += new System.EventHandler(this.chkWriteOff_CheckedChanged);
            // 
            // chkOverride
            // 
            this.chkOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOverride.AutoSize = true;
            this.chkOverride.Checked = true;
            this.chkOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverride.Location = new System.Drawing.Point(89, 90);
            this.chkOverride.Name = "chkOverride";
            this.chkOverride.Size = new System.Drawing.Size(54, 16);
            this.chkOverride.TabIndex = 5;
            this.chkOverride.TabStop = false;
            this.chkOverride.Text = "覆蓋";
            this.chkOverride.UseVisualStyleBackColor = true;
            // 
            // dtpEDate
            // 
            this.dtpEDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.dtpEDate, 2);
            this.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEDate.Location = new System.Drawing.Point(239, 3);
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.Size = new System.Drawing.Size(114, 22);
            this.dtpEDate.TabIndex = 1;
            this.dtpEDate.CloseUp += new System.EventHandler(this.dtpEDate_CloseUp);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "至";
            // 
            // btnHCodeType
            // 
            this.btnHCodeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnHCodeType, 4);
            this.btnHCodeType.Enabled = false;
            this.btnHCodeType.Location = new System.Drawing.Point(149, 115);
            this.btnHCodeType.Name = "btnHCodeType";
            this.btnHCodeType.Size = new System.Drawing.Size(204, 22);
            this.btnHCodeType.TabIndex = 7;
            this.btnHCodeType.Text = "選取時數不足時改沖的假別種類";
            this.btnHCodeType.UseVisualStyleBackColor = true;
            this.btnHCodeType.Click += new System.EventHandler(this.btnHCode_Click);
            // 
            // chkYearClose
            // 
            this.chkYearClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkYearClose.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkYearClose, 5);
            this.chkYearClose.Location = new System.Drawing.Point(89, 146);
            this.chkYearClose.Name = "chkYearClose";
            this.chkYearClose.Size = new System.Drawing.Size(264, 16);
            this.chkYearClose.TabIndex = 8;
            this.chkYearClose.TabStop = false;
            this.chkYearClose.Text = "年度結算：不足時數會轉為請假扣款";
            this.chkYearClose.UseVisualStyleBackColor = true;
            // 
            // btnGenEmp
            // 
            this.btnGenEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnGenEmp, 2);
            this.btnGenEmp.Location = new System.Drawing.Point(239, 59);
            this.btnGenEmp.Name = "btnGenEmp";
            this.btnGenEmp.Size = new System.Drawing.Size(114, 22);
            this.btnGenEmp.TabIndex = 3;
            this.btnGenEmp.TabStop = false;
            this.btnGenEmp.Text = "產生名單";
            this.btnGenEmp.UseVisualStyleBackColor = true;
            this.btnGenEmp.Click += new System.EventHandler(this.btnGenEmp_Click);
            // 
            // btnGen
            // 
            this.btnGen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.btnGen, 2);
            this.btnGen.Location = new System.Drawing.Point(103, 171);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(100, 23);
            this.btnGen.TabIndex = 9;
            this.btnGen.Text = "產生";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.btnExit, 2);
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(239, 171);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(388, 171);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 11;
            this.btnConfig.TabStop = false;
            this.btnConfig.Tag = "FRM4ADV";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(440, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 49;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tSSLabelSplit
            // 
            this.tSSLabelSplit.Name = "tSSLabelSplit";
            this.tSSLabelSplit.Size = new System.Drawing.Size(10, 17);
            this.tSSLabelSplit.Text = "|";
            // 
            // tSSLabelProcess
            // 
            this.tSSLabelProcess.Name = "tSSLabelProcess";
            this.tSSLabelProcess.Size = new System.Drawing.Size(31, 17);
            this.tSSLabelProcess.Text = "等待";
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // FRM4ADV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 236);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM4ADV";
            this.Text = "FRM4ADV";
            this.Load += new System.EventHandler(this.FRM4ADV_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbEmp;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.DateTimePicker dtpBDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEDate;
        private System.Windows.Forms.Button btnGenEmp;
        private System.Windows.Forms.Label lbOTDate;
        private System.Windows.Forms.Button btnHCodeType;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkWriteOff;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.TextBox txtYYMM;
        private System.Windows.Forms.CheckBox chkOverride;
        private System.Windows.Forms.CheckBox chkYearClose;
        private System.Windows.Forms.Button btnConfig;
    }
}