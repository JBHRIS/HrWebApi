
namespace JBHR.Att
{
    partial class FRM27A_ADD
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
            this.lbRoteH = new System.Windows.Forms.Label();
            this.cbxROTE_H = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trpState = new System.Windows.Forms.ToolStripStatusLabel();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.chkTransCard = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRoteH
            // 
            this.lbRoteH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRoteH.AutoSize = true;
            this.lbRoteH.Location = new System.Drawing.Point(8, 10);
            this.lbRoteH.Name = "lbRoteH";
            this.lbRoteH.Size = new System.Drawing.Size(89, 12);
            this.lbRoteH.TabIndex = 2;
            this.lbRoteH.Text = "調整假日班別為";
            // 
            // cbxROTE_H
            // 
            this.cbxROTE_H.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxROTE_H, 3);
            this.cbxROTE_H.FormattingEnabled = true;
            this.cbxROTE_H.Location = new System.Drawing.Point(103, 6);
            this.cbxROTE_H.Name = "cbxROTE_H";
            this.cbxROTE_H.Size = new System.Drawing.Size(214, 20);
            this.cbxROTE_H.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbRoteH, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxROTE_H, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkTransCard, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 98);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.Location = new System.Drawing.Point(194, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Location = new System.Drawing.Point(66, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "存档";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.trpState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 115);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(344, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoToolTip = true;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 20);
            this.toolStripProgressBar1.Tag = "";
            this.toolStripProgressBar1.ToolTipText = "123";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 21);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // trpState
            // 
            this.trpState.Name = "trpState";
            this.trpState.Size = new System.Drawing.Size(31, 21);
            this.trpState.Text = "等待";
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // chkTransCard
            // 
            this.chkTransCard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTransCard.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkTransCard, 2);
            this.chkTransCard.Location = new System.Drawing.Point(103, 40);
            this.chkTransCard.Name = "chkTransCard";
            this.chkTransCard.Size = new System.Drawing.Size(108, 16);
            this.chkTransCard.TabIndex = 15;
            this.chkTransCard.Text = "執行刷卡轉出勤";
            this.chkTransCard.UseVisualStyleBackColor = true;
            // 
            // FRM27A_ADD
            // 
            this.ClientSize = new System.Drawing.Size(344, 141);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM27A_ADD";
            this.Text = "調整假日班別";
            this.Load += new System.EventHandler(this.FRM27A_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRoteH;
        private System.Windows.Forms.ComboBox cbxROTE_H;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel trpState;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.CheckBox chkTransCard;
    }
}
