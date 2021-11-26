
namespace JBHR.Att
{
    partial class FRM2_DiversionGroup_ADD
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
            this.dtpEDate = new JBControls.TextBox();
            this.dtpBDate = new JBControls.TextBox();
            this.lbDiversionGroupType = new System.Windows.Forms.Label();
            this.cbxDiversionGroupType = new System.Windows.Forms.ComboBox();
            this.lbGuid = new System.Windows.Forms.Label();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEmp = new System.Windows.Forms.Button();
            this.lbEmp = new System.Windows.Forms.Label();
            this.lbBDate = new System.Windows.Forms.Label();
            this.lbEDate = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.dtpEDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpBDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDiversionGroupType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxDiversionGroupType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbGuid, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtGuid, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbBDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbEDate, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 184);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dtpEDate
            // 
            this.dtpEDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.dtpEDate.CaptionLabel = null;
            this.dtpEDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.dtpEDate, 2);
            this.dtpEDate.DecimalPlace = 2;
            this.dtpEDate.Enabled = false;
            this.dtpEDate.IsEmpty = false;
            this.dtpEDate.Location = new System.Drawing.Point(109, 64);
            this.dtpEDate.Mask = "0000/00/00";
            this.dtpEDate.MaxLength = -1;
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.PasswordChar = '\0';
            this.dtpEDate.ReadOnly = false;
            this.dtpEDate.ShowCalendarButton = true;
            this.dtpEDate.Size = new System.Drawing.Size(208, 22);
            this.dtpEDate.TabIndex = 2;
            this.dtpEDate.ValidType = JBControls.TextBox.EValidType.Date;
            this.dtpEDate.Click += new System.EventHandler(this.dtpEDate_CloseUp);
            this.dtpEDate.Leave += new System.EventHandler(this.dtpEDate_CloseUp);
            // 
            // dtpBDate
            // 
            this.dtpBDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.dtpBDate.CaptionLabel = null;
            this.dtpBDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.dtpBDate, 2);
            this.dtpBDate.DecimalPlace = 2;
            this.dtpBDate.IsEmpty = false;
            this.dtpBDate.Location = new System.Drawing.Point(109, 34);
            this.dtpBDate.Mask = "0000/00/00";
            this.dtpBDate.MaxLength = -1;
            this.dtpBDate.Name = "dtpBDate";
            this.dtpBDate.PasswordChar = '\0';
            this.dtpBDate.ReadOnly = false;
            this.dtpBDate.ShowCalendarButton = true;
            this.dtpBDate.Size = new System.Drawing.Size(208, 22);
            this.dtpBDate.TabIndex = 1;
            this.dtpBDate.ValidType = JBControls.TextBox.EValidType.Date;
            this.dtpBDate.Click += new System.EventHandler(this.dtpBDate_CloseUp);
            this.dtpBDate.Leave += new System.EventHandler(this.dtpBDate_CloseUp);
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
            // cbxDiversionGroupType
            // 
            this.cbxDiversionGroupType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDiversionGroupType, 2);
            this.cbxDiversionGroupType.FormattingEnabled = true;
            this.cbxDiversionGroupType.Location = new System.Drawing.Point(109, 5);
            this.cbxDiversionGroupType.Name = "cbxDiversionGroupType";
            this.cbxDiversionGroupType.Size = new System.Drawing.Size(205, 20);
            this.cbxDiversionGroupType.TabIndex = 0;
            // 
            // lbGuid
            // 
            this.lbGuid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGuid.AutoSize = true;
            this.lbGuid.ForeColor = System.Drawing.Color.Black;
            this.lbGuid.Location = new System.Drawing.Point(74, 129);
            this.lbGuid.Name = "lbGuid";
            this.lbGuid.Size = new System.Drawing.Size(29, 12);
            this.lbGuid.TabIndex = 91;
            this.lbGuid.Text = "編號";
            // 
            // txtGuid
            // 
            this.txtGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtGuid, 2);
            this.txtGuid.Enabled = false;
            this.txtGuid.Location = new System.Drawing.Point(109, 124);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(208, 22);
            this.txtGuid.TabIndex = 90;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 20);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnEmp, 2);
            this.btnEmp.Location = new System.Drawing.Point(109, 94);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(208, 22);
            this.btnEmp.TabIndex = 3;
            this.btnEmp.Text = "選取員工";
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.ForeColor = System.Drawing.Color.Black;
            this.lbEmp.Location = new System.Drawing.Point(50, 99);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 87;
            this.lbEmp.Text = "員工編號";
            // 
            // lbBDate
            // 
            this.lbBDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBDate.AutoSize = true;
            this.lbBDate.ForeColor = System.Drawing.Color.Black;
            this.lbBDate.Location = new System.Drawing.Point(50, 39);
            this.lbBDate.Name = "lbBDate";
            this.lbBDate.Size = new System.Drawing.Size(53, 12);
            this.lbBDate.TabIndex = 77;
            this.lbBDate.Text = "生效日期";
            // 
            // lbEDate
            // 
            this.lbEDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEDate.AutoSize = true;
            this.lbEDate.ForeColor = System.Drawing.Color.Black;
            this.lbEDate.Location = new System.Drawing.Point(50, 69);
            this.lbEDate.Name = "lbEDate";
            this.lbEDate.Size = new System.Drawing.Size(53, 12);
            this.lbEDate.TabIndex = 78;
            this.lbEDate.Text = "失效日期";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 199);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
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
            // FRM2_DiversionGroup_ADD
            // 
            this.ClientSize = new System.Drawing.Size(344, 221);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM2_DiversionGroup_ADD";
            this.Text = "FRM2_DiversionGroup_ADD";
            this.Load += new System.EventHandler(this.FRM2_DiversionGroup_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbGuid;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Label lbEDate;
        private System.Windows.Forms.Label lbBDate;
        private System.Windows.Forms.Label lbEmp;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Label lbDiversionGroupType;
        private System.Windows.Forms.ComboBox cbxDiversionGroupType;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Button btnCancel;
        private JBControls.TextBox dtpEDate;
        private JBControls.TextBox dtpBDate;
    }
}
