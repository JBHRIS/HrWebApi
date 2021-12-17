namespace JBHR.AnnualBonus.HunyaCustom
{
    partial class Hunya_ABPersonalBonus_Calculate
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbxDIVDSALCODE = new System.Windows.Forms.ComboBox();
            this.lbPAPAYYMM = new System.Windows.Forms.Label();
            this.lbSALCODE = new System.Windows.Forms.Label();
            this.lbEnrichYYMM = new System.Windows.Forms.Label();
            this.txtEnrichYYMM = new System.Windows.Forms.TextBox();
            this.lbMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudDIVDYYYY = new System.Windows.Forms.NumericUpDown();
            this.lbEmp = new System.Windows.Forms.Label();
            this.btnEmp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDIVDYYYY)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip.Location = new System.Drawing.Point(0, 289);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(344, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
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
            // tSSLabelProcess
            // 
            this.tSSLabelProcess.Name = "tSSLabelProcess";
            this.tSSLabelProcess.Size = new System.Drawing.Size(31, 17);
            this.tSSLabelProcess.Text = "等待";
            // 
            // cbxDIVDSALCODE
            // 
            this.cbxDIVDSALCODE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDIVDSALCODE, 2);
            this.cbxDIVDSALCODE.FormattingEnabled = true;
            this.cbxDIVDSALCODE.Location = new System.Drawing.Point(109, 155);
            this.cbxDIVDSALCODE.Name = "cbxDIVDSALCODE";
            this.cbxDIVDSALCODE.Size = new System.Drawing.Size(208, 20);
            this.cbxDIVDSALCODE.TabIndex = 3;
            // 
            // lbPAPAYYMM
            // 
            this.lbPAPAYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPAPAYYMM.AutoSize = true;
            this.lbPAPAYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbPAPAYYMM.Location = new System.Drawing.Point(50, 9);
            this.lbPAPAYYMM.Name = "lbPAPAYYMM";
            this.lbPAPAYYMM.Size = new System.Drawing.Size(53, 12);
            this.lbPAPAYYMM.TabIndex = 6;
            this.lbPAPAYYMM.Text = "考績年度";
            // 
            // lbSALCODE
            // 
            this.lbSALCODE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSALCODE.AutoSize = true;
            this.lbSALCODE.ForeColor = System.Drawing.Color.Black;
            this.lbSALCODE.Location = new System.Drawing.Point(14, 159);
            this.lbSALCODE.Name = "lbSALCODE";
            this.lbSALCODE.Size = new System.Drawing.Size(89, 12);
            this.lbSALCODE.TabIndex = 10;
            this.lbSALCODE.Text = "補扣發薪資代碼";
            // 
            // lbEnrichYYMM
            // 
            this.lbEnrichYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEnrichYYMM.AutoSize = true;
            this.lbEnrichYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbEnrichYYMM.Location = new System.Drawing.Point(14, 189);
            this.lbEnrichYYMM.Name = "lbEnrichYYMM";
            this.lbEnrichYYMM.Size = new System.Drawing.Size(89, 12);
            this.lbEnrichYYMM.TabIndex = 11;
            this.lbEnrichYYMM.Text = "轉入年月及期別";
            // 
            // txtEnrichYYMM
            // 
            this.txtEnrichYYMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnrichYYMM.Location = new System.Drawing.Point(109, 184);
            this.txtEnrichYYMM.Name = "txtEnrichYYMM";
            this.txtEnrichYYMM.Size = new System.Drawing.Size(100, 22);
            this.txtEnrichYYMM.TabIndex = 4;
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.ForeColor = System.Drawing.Color.Black;
            this.lbMemo.Location = new System.Drawing.Point(74, 219);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(29, 12);
            this.lbMemo.TabIndex = 14;
            this.lbMemo.Text = "備註";
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtMemo, 2);
            this.txtMemo.Location = new System.Drawing.Point(109, 213);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(208, 22);
            this.txtMemo.TabIndex = 6;
            // 
            // txtSeq
            // 
            this.txtSeq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSeq.Location = new System.Drawing.Point(215, 184);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(44, 22);
            this.txtSeq.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 21);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "離開";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            // 
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.ForeColor = System.Drawing.Color.Black;
            this.lbEmp.Location = new System.Drawing.Point(50, 39);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 16;
            this.lbEmp.Text = "員工編號";
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnEmp, 2);
            this.btnEmp.Location = new System.Drawing.Point(109, 34);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(208, 21);
            this.btnEmp.TabIndex = 17;
            this.btnEmp.Text = "選取員工";
            this.btnEmp.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lbPAPAYYMM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudDIVDYYYY, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbEnrichYYMM, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtEnrichYYMM, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbSALCODE, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxDIVDSALCODE, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 273);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 21);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "執行";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            // 
            // Hunya_ABPersonalBonus_Calculate
            // 
            this.ClientSize = new System.Drawing.Size(344, 311);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_ABPersonalBonus_Calculate";
            this.Text = "Hunya_ABPersonalBonus_Calculate";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDIVDYYYY)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.Windows.Forms.ComboBox cbxDIVDSALCODE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbPAPAYYMM;
        private System.Windows.Forms.Label lbSALCODE;
        private System.Windows.Forms.Label lbEnrichYYMM;
        private System.Windows.Forms.TextBox txtEnrichYYMM;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudDIVDYYYY;
        private System.Windows.Forms.Label lbEmp;
        private System.Windows.Forms.Button btnEmp;
        private System.ComponentModel.BackgroundWorker BW;
    }
}
