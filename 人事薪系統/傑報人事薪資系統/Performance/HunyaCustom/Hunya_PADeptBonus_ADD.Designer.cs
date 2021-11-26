
namespace JBHR.Performance.HunyaCustom
{
    partial class Hunya_PADeptBonus_ADD
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
            this.lbGuid = new System.Windows.Forms.Label();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.btnPADept = new System.Windows.Forms.Button();
            this.lbPADeptBonusYYMM_E = new System.Windows.Forms.Label();
            this.lbPADeptBonusYYMM_B = new System.Windows.Forms.Label();
            this.lbPABaseBonus = new System.Windows.Forms.Label();
            this.txtPAYYMM_E = new System.Windows.Forms.TextBox();
            this.txtPAYYMM_B = new System.Windows.Forms.TextBox();
            this.txtPABasicBonus = new JBControls.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tSSLabelSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLabelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lbGuid, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtGuid, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnPADept, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbPADeptBonusYYMM_E, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPADeptBonusYYMM_B, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPABaseBonus, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPAYYMM_E, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPAYYMM_B, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPABasicBonus, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
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
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbGuid
            // 
            this.lbGuid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbGuid.AutoSize = true;
            this.lbGuid.ForeColor = System.Drawing.Color.Black;
            this.lbGuid.Location = new System.Drawing.Point(74, 129);
            this.lbGuid.Name = "lbGuid";
            this.lbGuid.Size = new System.Drawing.Size(29, 12);
            this.lbGuid.TabIndex = 11;
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
            this.txtGuid.TabIndex = 4;
            this.txtGuid.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 20);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(50, 99);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.TabIndex = 7;
            this.label35.Text = "編制部門";
            // 
            // btnPADept
            // 
            this.btnPADept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPADept, 2);
            this.btnPADept.Location = new System.Drawing.Point(109, 94);
            this.btnPADept.Name = "btnPADept";
            this.btnPADept.Size = new System.Drawing.Size(208, 21);
            this.btnPADept.TabIndex = 3;
            this.btnPADept.Text = "選取部門";
            this.btnPADept.UseVisualStyleBackColor = true;
            // 
            // lbPADeptBonusYYMM_E
            // 
            this.lbPADeptBonusYYMM_E.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPADeptBonusYYMM_E.AutoSize = true;
            this.lbPADeptBonusYYMM_E.ForeColor = System.Drawing.Color.Black;
            this.lbPADeptBonusYYMM_E.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPADeptBonusYYMM_E.Location = new System.Drawing.Point(38, 69);
            this.lbPADeptBonusYYMM_E.Name = "lbPADeptBonusYYMM_E";
            this.lbPADeptBonusYYMM_E.Size = new System.Drawing.Size(65, 12);
            this.lbPADeptBonusYYMM_E.TabIndex = 9;
            this.lbPADeptBonusYYMM_E.Text = "考核年月迄";
            // 
            // lbPADeptBonusYYMM_B
            // 
            this.lbPADeptBonusYYMM_B.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPADeptBonusYYMM_B.AutoSize = true;
            this.lbPADeptBonusYYMM_B.ForeColor = System.Drawing.Color.Black;
            this.lbPADeptBonusYYMM_B.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPADeptBonusYYMM_B.Location = new System.Drawing.Point(38, 39);
            this.lbPADeptBonusYYMM_B.Name = "lbPADeptBonusYYMM_B";
            this.lbPADeptBonusYYMM_B.Size = new System.Drawing.Size(65, 12);
            this.lbPADeptBonusYYMM_B.TabIndex = 8;
            this.lbPADeptBonusYYMM_B.Text = "考核年月起";
            // 
            // lbPABaseBonus
            // 
            this.lbPABaseBonus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPABaseBonus.AutoSize = true;
            this.lbPABaseBonus.ForeColor = System.Drawing.Color.Black;
            this.lbPABaseBonus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPABaseBonus.Location = new System.Drawing.Point(50, 9);
            this.lbPABaseBonus.Name = "lbPABaseBonus";
            this.lbPABaseBonus.Size = new System.Drawing.Size(53, 12);
            this.lbPABaseBonus.TabIndex = 10;
            this.lbPABaseBonus.Text = "基本獎金";
            // 
            // txtPAYYMM_E
            // 
            this.txtPAYYMM_E.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAYYMM_E.Location = new System.Drawing.Point(109, 64);
            this.txtPAYYMM_E.Name = "txtPAYYMM_E";
            this.txtPAYYMM_E.Size = new System.Drawing.Size(100, 22);
            this.txtPAYYMM_E.TabIndex = 2;
            this.txtPAYYMM_E.Leave += new System.EventHandler(this.txtPAYYMM_E_Leave);
            // 
            // txtPAYYMM_B
            // 
            this.txtPAYYMM_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAYYMM_B.Location = new System.Drawing.Point(109, 34);
            this.txtPAYYMM_B.Name = "txtPAYYMM_B";
            this.txtPAYYMM_B.Size = new System.Drawing.Size(100, 22);
            this.txtPAYYMM_B.TabIndex = 1;
            this.txtPAYYMM_B.Leave += new System.EventHandler(this.txtPAYYMM_B_Leave);
            // 
            // txtPABasicBonus
            // 
            this.txtPABasicBonus.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPABasicBonus.CaptionLabel = null;
            this.txtPABasicBonus.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPABasicBonus.DecimalPlace = 2;
            this.txtPABasicBonus.IsEmpty = false;
            this.txtPABasicBonus.Location = new System.Drawing.Point(109, 3);
            this.txtPABasicBonus.Mask = "";
            this.txtPABasicBonus.MaxLength = -1;
            this.txtPABasicBonus.Name = "txtPABasicBonus";
            this.txtPABasicBonus.PasswordChar = '\0';
            this.txtPABasicBonus.ReadOnly = false;
            this.txtPABasicBonus.ShowCalendarButton = true;
            this.txtPABasicBonus.Size = new System.Drawing.Size(100, 22);
            this.txtPABasicBonus.TabIndex = 0;
            this.txtPABasicBonus.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip.Location = new System.Drawing.Point(0, 199);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(344, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
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
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // Hunya_PADeptBonus_ADD
            // 
            this.ClientSize = new System.Drawing.Size(344, 221);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_PADeptBonus_ADD";
            this.Text = "Hunya_PADeptBonus_ADD";
            this.Load += new System.EventHandler(this.Hunya_PADeptBonus_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbGuid;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private JBControls.TextBox txtPABasicBonus;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lbPADeptBonusYYMM_B;
        private System.Windows.Forms.Label lbPADeptBonusYYMM_E;
        private System.Windows.Forms.Label lbPABaseBonus;
        private System.Windows.Forms.TextBox txtPAYYMM_B;
        private System.Windows.Forms.TextBox txtPAYYMM_E;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Button btnPADept;
    }
}
