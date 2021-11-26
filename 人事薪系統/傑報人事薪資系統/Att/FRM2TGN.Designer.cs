namespace JBHR.Att
{
    partial class FRM2TGN
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEmp = new System.Windows.Forms.Button();
            this.lbEmp = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbHCode = new System.Windows.Forms.Label();
            this.cbxHCode = new System.Windows.Forms.ComboBox();
            this.lbDDate = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkOverride = new System.Windows.Forms.CheckBox();
            this.dtpBDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDDate = new System.Windows.Forms.DateTimePicker();
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
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbHCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxHCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbDDate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnGen, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkOverride, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpBDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpEDate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpDDate, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 169);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmp.Location = new System.Drawing.Point(93, 3);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(127, 22);
            this.btnEmp.TabIndex = 0;
            this.btnEmp.Text = "選取員工";
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.Location = new System.Drawing.Point(34, 8);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 2;
            this.lbEmp.Text = "員工對象";
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(34, 36);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(53, 12);
            this.lbDate.TabIndex = 27;
            this.lbDate.Text = "生效日期";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "失效日期";
            // 
            // lbHCode
            // 
            this.lbHCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHCode.AutoSize = true;
            this.lbHCode.Location = new System.Drawing.Point(58, 64);
            this.lbHCode.Name = "lbHCode";
            this.lbHCode.Size = new System.Drawing.Size(29, 12);
            this.lbHCode.TabIndex = 31;
            this.lbHCode.Text = "假別";
            // 
            // cbxHCode
            // 
            this.cbxHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxHCode, 2);
            this.cbxHCode.FormattingEnabled = true;
            this.cbxHCode.Location = new System.Drawing.Point(93, 60);
            this.cbxHCode.Name = "cbxHCode";
            this.cbxHCode.Size = new System.Drawing.Size(217, 20);
            this.cbxHCode.TabIndex = 3;
            this.cbxHCode.Text = "Advanceleave+-借假(得)";
            // 
            // lbDDate
            // 
            this.lbDDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDDate.AutoSize = true;
            this.lbDDate.Location = new System.Drawing.Point(22, 92);
            this.lbDDate.Name = "lbDDate";
            this.lbDDate.Size = new System.Drawing.Size(65, 12);
            this.lbDDate.TabIndex = 33;
            this.lbDDate.Text = "異動截止日";
            // 
            // btnGen
            // 
            this.btnGen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGen.Location = new System.Drawing.Point(93, 143);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(85, 23);
            this.btnGen.TabIndex = 5;
            this.btnGen.Text = "產生";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(226, 143);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 23);
            this.btnExit.TabIndex = 37;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkOverride
            // 
            this.chkOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOverride.AutoSize = true;
            this.chkOverride.Location = new System.Drawing.Point(93, 118);
            this.chkOverride.Name = "chkOverride";
            this.chkOverride.Size = new System.Drawing.Size(127, 16);
            this.chkOverride.TabIndex = 35;
            this.chkOverride.TabStop = false;
            this.chkOverride.Text = "覆蓋";
            this.chkOverride.UseVisualStyleBackColor = true;
            // 
            // dtpBDate
            // 
            this.dtpBDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBDate.Location = new System.Drawing.Point(93, 31);
            this.dtpBDate.Name = "dtpBDate";
            this.dtpBDate.Size = new System.Drawing.Size(127, 22);
            this.dtpBDate.TabIndex = 1;
            this.dtpBDate.CloseUp += new System.EventHandler(this.dtpBDate_CloseUp);
            this.dtpBDate.Leave += new System.EventHandler(this.dtpBDate_CloseUp);
            // 
            // dtpEDate
            // 
            this.dtpEDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEDate.Location = new System.Drawing.Point(316, 31);
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.Size = new System.Drawing.Size(127, 22);
            this.dtpEDate.TabIndex = 2;
            this.dtpEDate.CloseUp += new System.EventHandler(this.dtpEDate_CloseUp);
            this.dtpEDate.Leave += new System.EventHandler(this.dtpEDate_CloseUp);
            // 
            // dtpDDate
            // 
            this.dtpDDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDDate.Location = new System.Drawing.Point(93, 87);
            this.dtpDDate.Name = "dtpDDate";
            this.dtpDDate.Size = new System.Drawing.Size(127, 22);
            this.dtpDDate.TabIndex = 4;
            this.dtpDDate.CloseUp += new System.EventHandler(this.dtpDDate_CloseUp);
            this.dtpDDate.Leave += new System.EventHandler(this.dtpDDate_CloseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 185);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(470, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 48;
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
            // FRM2TGN
            // 
            this.ClientSize = new System.Drawing.Size(470, 207);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM2TGN";
            this.Text = "產生得假";
            this.Load += new System.EventHandler(this.FRM2TGN_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbHCode;
        private System.Windows.Forms.ComboBox cbxHCode;
        private System.Windows.Forms.Label lbDDate;
        private System.Windows.Forms.CheckBox chkOverride;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpBDate;
        private System.Windows.Forms.DateTimePicker dtpEDate;
        private System.Windows.Forms.DateTimePicker dtpDDate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.ComponentModel.BackgroundWorker BW;
    }
}
