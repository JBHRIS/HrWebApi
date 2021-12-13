namespace JBHR.AnnualBonus.HunyaCustom
{
    partial class Hunya_ABPersonalAppraisal_ADD
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
            this.lbABYYYY = new System.Windows.Forms.Label();
            this.lbEmp = new System.Windows.Forms.Label();
            this.btnEmp = new System.Windows.Forms.Button();
            this.lbABTypeCode = new System.Windows.Forms.Label();
            this.cbxABTypeCode = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbGuid = new System.Windows.Forms.Label();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.lbABLevelCode = new System.Windows.Forms.Label();
            this.cbxABLevelCode = new System.Windows.Forms.ComboBox();
            this.lbABScore = new System.Windows.Forms.Label();
            this.nudABScore = new System.Windows.Forms.NumericUpDown();
            this.nudABYYYY = new System.Windows.Forms.NumericUpDown();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudABScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudABYYYY)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lbABYYYY, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbABTypeCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxABTypeCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbGuid, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtGuid, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbABLevelCode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxABLevelCode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbABScore, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudABScore, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudABYYYY, 1, 0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 214);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbABYYYY
            // 
            this.lbABYYYY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABYYYY.AutoSize = true;
            this.lbABYYYY.ForeColor = System.Drawing.Color.Black;
            this.lbABYYYY.Location = new System.Drawing.Point(50, 9);
            this.lbABYYYY.Name = "lbABYYYY";
            this.lbABYYYY.Size = new System.Drawing.Size(53, 12);
            this.lbABYYYY.TabIndex = 8;
            this.lbABYYYY.Text = "考績年度";
            // 
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.ForeColor = System.Drawing.Color.Black;
            this.lbEmp.Location = new System.Drawing.Point(50, 39);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 9;
            this.lbEmp.Text = "員工編號";
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnEmp, 2);
            this.btnEmp.Location = new System.Drawing.Point(109, 34);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(208, 21);
            this.btnEmp.TabIndex = 1;
            this.btnEmp.Text = "選取員工";
            this.btnEmp.UseVisualStyleBackColor = true;
            // 
            // lbABTypeCode
            // 
            this.lbABTypeCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABTypeCode.AutoSize = true;
            this.lbABTypeCode.ForeColor = System.Drawing.Color.Black;
            this.lbABTypeCode.Location = new System.Drawing.Point(50, 69);
            this.lbABTypeCode.Name = "lbABTypeCode";
            this.lbABTypeCode.Size = new System.Drawing.Size(53, 12);
            this.lbABTypeCode.TabIndex = 10;
            this.lbABTypeCode.Text = "考績種類";
            // 
            // cbxABTypeCode
            // 
            this.cbxABTypeCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxABTypeCode, 2);
            this.cbxABTypeCode.FormattingEnabled = true;
            this.cbxABTypeCode.Location = new System.Drawing.Point(109, 65);
            this.cbxABTypeCode.Name = "cbxABTypeCode";
            this.cbxABTypeCode.Size = new System.Drawing.Size(205, 20);
            this.cbxABTypeCode.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 21);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 21);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbGuid
            // 
            this.lbGuid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGuid.AutoSize = true;
            this.lbGuid.ForeColor = System.Drawing.Color.Black;
            this.lbGuid.Location = new System.Drawing.Point(74, 159);
            this.lbGuid.Name = "lbGuid";
            this.lbGuid.Size = new System.Drawing.Size(29, 12);
            this.lbGuid.TabIndex = 13;
            this.lbGuid.Text = "編號";
            // 
            // txtGuid
            // 
            this.txtGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtGuid, 2);
            this.txtGuid.Enabled = false;
            this.txtGuid.Location = new System.Drawing.Point(109, 154);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(208, 22);
            this.txtGuid.TabIndex = 5;
            this.txtGuid.TabStop = false;
            // 
            // lbABLevelCode
            // 
            this.lbABLevelCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABLevelCode.AutoSize = true;
            this.lbABLevelCode.ForeColor = System.Drawing.Color.Black;
            this.lbABLevelCode.Location = new System.Drawing.Point(50, 129);
            this.lbABLevelCode.Name = "lbABLevelCode";
            this.lbABLevelCode.Size = new System.Drawing.Size(53, 12);
            this.lbABLevelCode.TabIndex = 12;
            this.lbABLevelCode.Text = "考績等第";
            // 
            // cbxABLevelCode
            // 
            this.cbxABLevelCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxABLevelCode, 2);
            this.cbxABLevelCode.FormattingEnabled = true;
            this.cbxABLevelCode.Location = new System.Drawing.Point(109, 125);
            this.cbxABLevelCode.Name = "cbxABLevelCode";
            this.cbxABLevelCode.Size = new System.Drawing.Size(205, 20);
            this.cbxABLevelCode.TabIndex = 4;
            // 
            // lbABScore
            // 
            this.lbABScore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABScore.AutoSize = true;
            this.lbABScore.ForeColor = System.Drawing.Color.Black;
            this.lbABScore.Location = new System.Drawing.Point(50, 99);
            this.lbABScore.Name = "lbABScore";
            this.lbABScore.Size = new System.Drawing.Size(53, 12);
            this.lbABScore.TabIndex = 11;
            this.lbABScore.Text = "考績分數";
            // 
            // nudABScore
            // 
            this.nudABScore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudABScore.DecimalPlaces = 2;
            this.nudABScore.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudABScore.Location = new System.Drawing.Point(109, 94);
            this.nudABScore.Name = "nudABScore";
            this.nudABScore.Size = new System.Drawing.Size(100, 22);
            this.nudABScore.TabIndex = 3;
            this.nudABScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudABYYYY
            // 
            this.nudABYYYY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudABYYYY.Location = new System.Drawing.Point(109, 4);
            this.nudABYYYY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudABYYYY.Minimum = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.nudABYYYY.Name = "nudABYYYY";
            this.nudABYYYY.Size = new System.Drawing.Size(100, 22);
            this.nudABYYYY.TabIndex = 0;
            this.nudABYYYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudABYYYY.Value = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.nudABYYYY.Leave += new System.EventHandler(this.nudABYYYY_Leave);
            // 
            // tSSLabelProcess
            // 
            this.tSSLabelProcess.Name = "tSSLabelProcess";
            this.tSSLabelProcess.Size = new System.Drawing.Size(31, 17);
            this.tSSLabelProcess.Text = "等待";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip.Location = new System.Drawing.Point(0, 229);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(344, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
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
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // Hunya_ABPersonalAppraisal_ADD
            // 
            this.ClientSize = new System.Drawing.Size(344, 251);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hunya_ABPersonalAppraisal_ADD";
            this.Text = "Hunya_ABPersonalAppraisal_ADD";
            this.Load += new System.EventHandler(this.Hunya_ABPersonalAppraisal_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudABScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudABYYYY)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbGuid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbABYYYY;
        private System.Windows.Forms.Label lbEmp;
        private System.Windows.Forms.ComboBox cbxABLevelCode;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Label lbABLevelCode;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Label lbABTypeCode;
        private System.Windows.Forms.ComboBox cbxABTypeCode;
        private System.Windows.Forms.Label lbABScore;
        private System.Windows.Forms.NumericUpDown nudABScore;
        private System.Windows.Forms.NumericUpDown nudABYYYY;
    }
}
