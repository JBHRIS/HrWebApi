
namespace JBHR.Dividend.HunyaCustom
{
    partial class Hunya_DIVDPersonalAppraisal_ADD
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbDIVDYYYY = new System.Windows.Forms.Label();
            this.lbEmp = new System.Windows.Forms.Label();
            this.cbxDIVDAppraisalCode = new System.Windows.Forms.ComboBox();
            this.btnEmp = new System.Windows.Forms.Button();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbGuid = new System.Windows.Forms.Label();
            this.lbDIVDAppraisalCode = new System.Windows.Forms.Label();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.nudDIVDYYYY = new System.Windows.Forms.NumericUpDown();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDIVDYYYY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbDIVDYYYY
            // 
            this.lbDIVDYYYY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDIVDYYYY.AutoSize = true;
            this.lbDIVDYYYY.ForeColor = System.Drawing.Color.Black;
            this.lbDIVDYYYY.Location = new System.Drawing.Point(50, 9);
            this.lbDIVDYYYY.Name = "lbDIVDYYYY";
            this.lbDIVDYYYY.Size = new System.Drawing.Size(53, 12);
            this.lbDIVDYYYY.TabIndex = 6;
            this.lbDIVDYYYY.Text = "考績年度";
            // 
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.ForeColor = System.Drawing.Color.Black;
            this.lbEmp.Location = new System.Drawing.Point(50, 39);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 7;
            this.lbEmp.Text = "員工編號";
            // 
            // cbxDIVDAppraisalCode
            // 
            this.cbxDIVDAppraisalCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDIVDAppraisalCode, 2);
            this.cbxDIVDAppraisalCode.FormattingEnabled = true;
            this.cbxDIVDAppraisalCode.Location = new System.Drawing.Point(109, 65);
            this.cbxDIVDAppraisalCode.Name = "cbxDIVDAppraisalCode";
            this.cbxDIVDAppraisalCode.Size = new System.Drawing.Size(205, 20);
            this.cbxDIVDAppraisalCode.TabIndex = 2;
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
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 169);
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
            // txtGuid
            // 
            this.txtGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtGuid, 2);
            this.txtGuid.Enabled = false;
            this.txtGuid.Location = new System.Drawing.Point(109, 94);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(208, 22);
            this.txtGuid.TabIndex = 3;
            this.txtGuid.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 21);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.txtGuid, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbGuid, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbDIVDYYYY, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxDIVDAppraisalCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDIVDAppraisalCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudDIVDYYYY, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 154);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbGuid
            // 
            this.lbGuid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGuid.AutoSize = true;
            this.lbGuid.ForeColor = System.Drawing.Color.Black;
            this.lbGuid.Location = new System.Drawing.Point(74, 99);
            this.lbGuid.Name = "lbGuid";
            this.lbGuid.Size = new System.Drawing.Size(29, 12);
            this.lbGuid.TabIndex = 9;
            this.lbGuid.Text = "編號";
            // 
            // lbDIVDAppraisalCode
            // 
            this.lbDIVDAppraisalCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDIVDAppraisalCode.AutoSize = true;
            this.lbDIVDAppraisalCode.ForeColor = System.Drawing.Color.Black;
            this.lbDIVDAppraisalCode.Location = new System.Drawing.Point(50, 69);
            this.lbDIVDAppraisalCode.Name = "lbDIVDAppraisalCode";
            this.lbDIVDAppraisalCode.Size = new System.Drawing.Size(53, 12);
            this.lbDIVDAppraisalCode.TabIndex = 8;
            this.lbDIVDAppraisalCode.Text = "考績等第";
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // nudDIVDYYYY
            // 
            this.nudDIVDYYYY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudDIVDYYYY.Location = new System.Drawing.Point(109, 4);
            this.nudDIVDYYYY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDIVDYYYY.Minimum = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.nudDIVDYYYY.Name = "nudDIVDYYYY";
            this.nudDIVDYYYY.Size = new System.Drawing.Size(100, 22);
            this.nudDIVDYYYY.TabIndex = 0;
            this.nudDIVDYYYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDIVDYYYY.Value = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.nudDIVDYYYY.Leave += new System.EventHandler(this.nudDIVDYYYY_Leave);
            // 
            // Hunya_DIVDPersonalAppraisal_ADD
            // 
            this.ClientSize = new System.Drawing.Size(344, 191);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_DIVDPersonalAppraisal_ADD";
            this.Text = "Hunya_DIVDPersonalAppraisal_ADD";
            this.Load += new System.EventHandler(this.Hunya_DIVDPersonalAppraisal_ADD_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDIVDYYYY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbDIVDYYYY;
        private System.Windows.Forms.Label lbEmp;
        private System.Windows.Forms.ComboBox cbxDIVDAppraisalCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Label lbGuid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Label lbDIVDAppraisalCode;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.NumericUpDown nudDIVDYYYY;
    }
}
