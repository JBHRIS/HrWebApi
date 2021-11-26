
namespace JBHR.Att
{
    partial class FRM2_DiversionShift_ADD
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbDiversionGroupType = new System.Windows.Forms.Label();
            this.cbxDiversionGroup = new System.Windows.Forms.ComboBox();
            this.lbGuid = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpEDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBDate = new System.Windows.Forms.DateTimePicker();
            this.lbDiversionAttendType = new System.Windows.Forms.Label();
            this.lbBDate = new System.Windows.Forms.Label();
            this.lbEDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDateList = new System.Windows.Forms.Button();
            this.cbxDiversionAttendType = new System.Windows.Forms.ComboBox();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 228);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 51;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lbDiversionGroupType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxDiversionGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbGuid, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtpEDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpBDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDiversionAttendType, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbBDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbEDate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDateList, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxDiversionAttendType, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtGuid, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 6);
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
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // lbDiversionGroupType
            // 
            this.lbDiversionGroupType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDiversionGroupType.AutoSize = true;
            this.lbDiversionGroupType.Location = new System.Drawing.Point(50, 9);
            this.lbDiversionGroupType.Name = "lbDiversionGroupType";
            this.lbDiversionGroupType.Size = new System.Drawing.Size(53, 12);
            this.lbDiversionGroupType.TabIndex = 92;
            this.lbDiversionGroupType.Text = "分流班別";
            // 
            // cbxDiversionGroup
            // 
            this.cbxDiversionGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDiversionGroup, 2);
            this.cbxDiversionGroup.FormattingEnabled = true;
            this.cbxDiversionGroup.Location = new System.Drawing.Point(109, 5);
            this.cbxDiversionGroup.Name = "cbxDiversionGroup";
            this.cbxDiversionGroup.Size = new System.Drawing.Size(205, 20);
            this.cbxDiversionGroup.TabIndex = 0;
            this.cbxDiversionGroup.DropDownClosed += new System.EventHandler(this.cbxDiversionGroup_DropDownClosed);
            // 
            // lbGuid
            // 
            this.lbGuid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGuid.AutoSize = true;
            this.lbGuid.ForeColor = System.Drawing.Color.Black;
            this.lbGuid.Location = new System.Drawing.Point(74, 159);
            this.lbGuid.Name = "lbGuid";
            this.lbGuid.Size = new System.Drawing.Size(29, 12);
            this.lbGuid.TabIndex = 91;
            this.lbGuid.Text = "編號";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 20);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpEDate
            // 
            this.dtpEDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.dtpEDate, 2);
            this.dtpEDate.CustomFormat = "yyyy/MM/dd";
            this.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEDate.Location = new System.Drawing.Point(109, 64);
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.Size = new System.Drawing.Size(208, 22);
            this.dtpEDate.TabIndex = 2;
            this.dtpEDate.Value = new System.DateTime(2019, 9, 19, 10, 49, 45, 0);
            this.dtpEDate.CloseUp += new System.EventHandler(this.dtpEDate_CloseUp);
            this.dtpEDate.Leave += new System.EventHandler(this.dtpEDate_CloseUp);
            // 
            // dtpBDate
            // 
            this.dtpBDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.dtpBDate, 2);
            this.dtpBDate.CustomFormat = "yyyy/MM/dd";
            this.dtpBDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBDate.Location = new System.Drawing.Point(109, 34);
            this.dtpBDate.Name = "dtpBDate";
            this.dtpBDate.Size = new System.Drawing.Size(208, 22);
            this.dtpBDate.TabIndex = 1;
            this.dtpBDate.Value = new System.DateTime(2019, 9, 19, 10, 49, 36, 0);
            this.dtpBDate.CloseUp += new System.EventHandler(this.dtpBDate_CloseUp);
            this.dtpBDate.Leave += new System.EventHandler(this.dtpBDate_CloseUp);
            // 
            // lbDiversionAttendType
            // 
            this.lbDiversionAttendType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDiversionAttendType.AutoSize = true;
            this.lbDiversionAttendType.Location = new System.Drawing.Point(26, 129);
            this.lbDiversionAttendType.Name = "lbDiversionAttendType";
            this.lbDiversionAttendType.Size = new System.Drawing.Size(77, 12);
            this.lbDiversionAttendType.TabIndex = 97;
            this.lbDiversionAttendType.Text = "分流上班類別";
            // 
            // lbBDate
            // 
            this.lbBDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBDate.AutoSize = true;
            this.lbBDate.ForeColor = System.Drawing.Color.Black;
            this.lbBDate.Location = new System.Drawing.Point(38, 39);
            this.lbBDate.Name = "lbBDate";
            this.lbBDate.Size = new System.Drawing.Size(65, 12);
            this.lbBDate.TabIndex = 77;
            this.lbBDate.Text = "出勤日期起";
            // 
            // lbEDate
            // 
            this.lbEDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEDate.AutoSize = true;
            this.lbEDate.ForeColor = System.Drawing.Color.Black;
            this.lbEDate.Location = new System.Drawing.Point(38, 69);
            this.lbEDate.Name = "lbEDate";
            this.lbEDate.Size = new System.Drawing.Size(65, 12);
            this.lbEDate.TabIndex = 78;
            this.lbEDate.Text = "出勤日期迄";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "日期細節調整";
            // 
            // btnDateList
            // 
            this.btnDateList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnDateList, 2);
            this.btnDateList.Location = new System.Drawing.Point(109, 94);
            this.btnDateList.Name = "btnDateList";
            this.btnDateList.Size = new System.Drawing.Size(208, 22);
            this.btnDateList.TabIndex = 3;
            this.btnDateList.Text = "日期細節選擇";
            this.btnDateList.UseVisualStyleBackColor = true;
            this.btnDateList.Click += new System.EventHandler(this.btnDateList_Click);
            // 
            // cbxDiversionAttendType
            // 
            this.cbxDiversionAttendType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDiversionAttendType, 2);
            this.cbxDiversionAttendType.FormattingEnabled = true;
            this.cbxDiversionAttendType.Location = new System.Drawing.Point(109, 125);
            this.cbxDiversionAttendType.Name = "cbxDiversionAttendType";
            this.cbxDiversionAttendType.Size = new System.Drawing.Size(208, 20);
            this.cbxDiversionAttendType.TabIndex = 4;
            // 
            // txtGuid
            // 
            this.txtGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtGuid, 2);
            this.txtGuid.Enabled = false;
            this.txtGuid.Location = new System.Drawing.Point(109, 154);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(208, 22);
            this.txtGuid.TabIndex = 90;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // FRM2_DiversionShift_ADD
            // 
            this.ClientSize = new System.Drawing.Size(344, 250);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM2_DiversionShift_ADD";
            this.Text = "FRM2_DiversionShift_ADD";
            this.Load += new System.EventHandler(this.FRM2_DiversionShift_ADD_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbDiversionGroupType;
        private System.Windows.Forms.ComboBox cbxDiversionGroup;
        private System.Windows.Forms.Label lbGuid;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbEDate;
        private System.Windows.Forms.Label lbBDate;
        private System.Windows.Forms.DateTimePicker dtpEDate;
        private System.Windows.Forms.DateTimePicker dtpBDate;
        private System.Windows.Forms.ComboBox cbxDiversionAttendType;
        private System.Windows.Forms.Label lbDiversionAttendType;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDateList;
    }
}
