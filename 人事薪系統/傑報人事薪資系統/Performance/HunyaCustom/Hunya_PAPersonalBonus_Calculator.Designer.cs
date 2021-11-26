
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PAPersonalBonus_Calculator
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
            this.lbPAPAYYMM = new System.Windows.Forms.Label();
            this.lbPADept = new System.Windows.Forms.Label();
            this.btnPADept = new System.Windows.Forms.Button();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxPASALCODE = new System.Windows.Forms.ComboBox();
            this.txtPAYYMM = new System.Windows.Forms.TextBox();
            this.lbPAHocdeList = new System.Windows.Forms.Label();
            this.btnPAHocdeList = new System.Windows.Forms.Button();
            this.lbSALCODE = new System.Windows.Forms.Label();
            this.lbEnrichYYMM = new System.Windows.Forms.Label();
            this.txtEnrichYYMM = new System.Windows.Forms.TextBox();
            this.lbMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPAPAYYMM
            // 
            this.lbPAPAYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPAPAYYMM.AutoSize = true;
            this.lbPAPAYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbPAPAYYMM.Location = new System.Drawing.Point(50, 9);
            this.lbPAPAYYMM.Name = "lbPAPAYYMM";
            this.lbPAPAYYMM.Size = new System.Drawing.Size(53, 12);
            this.lbPAPAYYMM.TabIndex = 9;
            this.lbPAPAYYMM.Text = "考核年月";
            // 
            // lbPADept
            // 
            this.lbPADept.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPADept.AutoSize = true;
            this.lbPADept.ForeColor = System.Drawing.Color.Black;
            this.lbPADept.Location = new System.Drawing.Point(50, 39);
            this.lbPADept.Name = "lbPADept";
            this.lbPADept.Size = new System.Drawing.Size(53, 12);
            this.lbPADept.TabIndex = 10;
            this.lbPADept.Text = "部門代碼";
            // 
            // btnPADept
            // 
            this.btnPADept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPADept, 2);
            this.btnPADept.Location = new System.Drawing.Point(109, 34);
            this.btnPADept.Name = "btnPADept";
            this.btnPADept.Size = new System.Drawing.Size(208, 21);
            this.btnPADept.TabIndex = 1;
            this.btnPADept.Text = "選取部門";
            this.btnPADept.UseVisualStyleBackColor = true;
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
            this.statusStrip.Location = new System.Drawing.Point(0, 228);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.cbxPASALCODE, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbPAPAYYMM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPAYYMM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPADept, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPADept, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPAHocdeList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPAHocdeList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbSALCODE, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbEnrichYYMM, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtEnrichYYMM, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 6);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 213);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cbxPASALCODE
            // 
            this.cbxPASALCODE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxPASALCODE, 2);
            this.cbxPASALCODE.FormattingEnabled = true;
            this.cbxPASALCODE.Location = new System.Drawing.Point(109, 95);
            this.cbxPASALCODE.Name = "cbxPASALCODE";
            this.cbxPASALCODE.Size = new System.Drawing.Size(208, 20);
            this.cbxPASALCODE.TabIndex = 3;
            // 
            // txtPAYYMM
            // 
            this.txtPAYYMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAYYMM.Location = new System.Drawing.Point(109, 4);
            this.txtPAYYMM.Name = "txtPAYYMM";
            this.txtPAYYMM.Size = new System.Drawing.Size(100, 22);
            this.txtPAYYMM.TabIndex = 0;
            this.txtPAYYMM.Leave += new System.EventHandler(this.txtPAYYMM_Leave);
            // 
            // lbPAHocdeList
            // 
            this.lbPAHocdeList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPAHocdeList.AutoSize = true;
            this.lbPAHocdeList.ForeColor = System.Drawing.Color.Black;
            this.lbPAHocdeList.Location = new System.Drawing.Point(50, 69);
            this.lbPAHocdeList.Name = "lbPAHocdeList";
            this.lbPAHocdeList.Size = new System.Drawing.Size(53, 12);
            this.lbPAHocdeList.TabIndex = 11;
            this.lbPAHocdeList.Text = "指定扣假";
            // 
            // btnPAHocdeList
            // 
            this.btnPAHocdeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPAHocdeList, 2);
            this.btnPAHocdeList.Location = new System.Drawing.Point(109, 64);
            this.btnPAHocdeList.Name = "btnPAHocdeList";
            this.btnPAHocdeList.Size = new System.Drawing.Size(208, 21);
            this.btnPAHocdeList.TabIndex = 2;
            this.btnPAHocdeList.Text = "選取扣假代碼";
            this.btnPAHocdeList.UseVisualStyleBackColor = true;
            // 
            // lbSALCODE
            // 
            this.lbSALCODE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSALCODE.AutoSize = true;
            this.lbSALCODE.ForeColor = System.Drawing.Color.Black;
            this.lbSALCODE.Location = new System.Drawing.Point(14, 99);
            this.lbSALCODE.Name = "lbSALCODE";
            this.lbSALCODE.Size = new System.Drawing.Size(89, 12);
            this.lbSALCODE.TabIndex = 12;
            this.lbSALCODE.Text = "補扣發薪資代碼";
            // 
            // lbEnrichYYMM
            // 
            this.lbEnrichYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEnrichYYMM.AutoSize = true;
            this.lbEnrichYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbEnrichYYMM.Location = new System.Drawing.Point(14, 129);
            this.lbEnrichYYMM.Name = "lbEnrichYYMM";
            this.lbEnrichYYMM.Size = new System.Drawing.Size(89, 12);
            this.lbEnrichYYMM.TabIndex = 13;
            this.lbEnrichYYMM.Text = "轉入年月及期別";
            // 
            // txtEnrichYYMM
            // 
            this.txtEnrichYYMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnrichYYMM.Location = new System.Drawing.Point(109, 124);
            this.txtEnrichYYMM.Name = "txtEnrichYYMM";
            this.txtEnrichYYMM.Size = new System.Drawing.Size(100, 22);
            this.txtEnrichYYMM.TabIndex = 4;
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.ForeColor = System.Drawing.Color.Black;
            this.lbMemo.Location = new System.Drawing.Point(74, 159);
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
            this.txtMemo.Location = new System.Drawing.Point(109, 153);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(208, 22);
            this.txtMemo.TabIndex = 6;
            // 
            // txtSeq
            // 
            this.txtSeq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSeq.Location = new System.Drawing.Point(215, 124);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(44, 22);
            this.txtSeq.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 21);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "執行";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 21);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "離開";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // Hunya_PAPersonalBonus_Calculator
            // 
            this.ClientSize = new System.Drawing.Size(344, 250);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hunya_PAPersonalBonus_Calculator";
            this.Text = "Hunya_PAPersonalBonus_Calculate";
            this.Load += new System.EventHandler(this.Hunya_PAPersonalBonus_Calculator_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbPAPAYYMM;
        private System.Windows.Forms.Label lbPADept;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtPAYYMM;
        private System.Windows.Forms.Button btnPADept;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Label lbPAHocdeList;
        private System.Windows.Forms.Button btnPAHocdeList;
        private System.Windows.Forms.ComboBox cbxPASALCODE;
        private System.Windows.Forms.Label lbSALCODE;
        private System.Windows.Forms.Label lbEnrichYYMM;
        private System.Windows.Forms.TextBox txtEnrichYYMM;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
