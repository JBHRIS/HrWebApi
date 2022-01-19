namespace JBHR.AnnualBonus.HunyaCustom
{
    partial class Hunya_ABPersonalBonus_Calculator
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
            this.cbxABSALCODE = new System.Windows.Forms.ComboBox();
            this.lbABYYMM = new System.Windows.Forms.Label();
            this.lbABSALCODE = new System.Windows.Forms.Label();
            this.lbEnrichYYMM = new System.Windows.Forms.Label();
            this.txtEnrichYYMM = new System.Windows.Forms.TextBox();
            this.lbMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudABYYYY = new System.Windows.Forms.NumericUpDown();
            this.lbEmp = new System.Windows.Forms.Label();
            this.btnEmp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMaternityCode = new System.Windows.Forms.Button();
            this.lbOUTCD = new System.Windows.Forms.Label();
            this.btnOUTCD = new System.Windows.Forms.Button();
            this.lbMaternityCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbExEmp = new System.Windows.Forms.Label();
            this.btnExEmp = new System.Windows.Forms.Button();
            this.lbSalBasd = new System.Windows.Forms.Label();
            this.btnSalBasd = new System.Windows.Forms.Button();
            this.lbBonusDays = new System.Windows.Forms.Label();
            this.nudBonusDays = new System.Windows.Forms.NumericUpDown();
            this.lbRateHCode = new System.Windows.Forms.Label();
            this.btnRateHCode = new System.Windows.Forms.Button();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudABYYYY)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonusDays)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tSSLabelSplit,
            this.tSSLabelProcess});
            this.statusStrip.Location = new System.Drawing.Point(0, 379);
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
            // cbxABSALCODE
            // 
            this.cbxABSALCODE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxABSALCODE, 2);
            this.cbxABSALCODE.FormattingEnabled = true;
            this.cbxABSALCODE.Location = new System.Drawing.Point(109, 245);
            this.cbxABSALCODE.Name = "cbxABSALCODE";
            this.cbxABSALCODE.Size = new System.Drawing.Size(208, 20);
            this.cbxABSALCODE.TabIndex = 6;
            // 
            // lbABYYMM
            // 
            this.lbABYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABYYMM.AutoSize = true;
            this.lbABYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbABYYMM.Location = new System.Drawing.Point(50, 9);
            this.lbABYYMM.Name = "lbABYYMM";
            this.lbABYYMM.Size = new System.Drawing.Size(53, 12);
            this.lbABYYMM.TabIndex = 6;
            this.lbABYYMM.Text = "考績年度";
            // 
            // lbABSALCODE
            // 
            this.lbABSALCODE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbABSALCODE.AutoSize = true;
            this.lbABSALCODE.ForeColor = System.Drawing.Color.Black;
            this.lbABSALCODE.Location = new System.Drawing.Point(14, 249);
            this.lbABSALCODE.Name = "lbABSALCODE";
            this.lbABSALCODE.Size = new System.Drawing.Size(89, 12);
            this.lbABSALCODE.TabIndex = 10;
            this.lbABSALCODE.Text = "補扣發薪資代碼";
            // 
            // lbEnrichYYMM
            // 
            this.lbEnrichYYMM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEnrichYYMM.AutoSize = true;
            this.lbEnrichYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbEnrichYYMM.Location = new System.Drawing.Point(14, 279);
            this.lbEnrichYYMM.Name = "lbEnrichYYMM";
            this.lbEnrichYYMM.Size = new System.Drawing.Size(89, 12);
            this.lbEnrichYYMM.TabIndex = 11;
            this.lbEnrichYYMM.Text = "轉入年月及期別";
            // 
            // txtEnrichYYMM
            // 
            this.txtEnrichYYMM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnrichYYMM.Location = new System.Drawing.Point(109, 274);
            this.txtEnrichYYMM.Name = "txtEnrichYYMM";
            this.txtEnrichYYMM.Size = new System.Drawing.Size(100, 22);
            this.txtEnrichYYMM.TabIndex = 7;
            // 
            // lbMemo
            // 
            this.lbMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMemo.AutoSize = true;
            this.lbMemo.ForeColor = System.Drawing.Color.Black;
            this.lbMemo.Location = new System.Drawing.Point(74, 309);
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
            this.txtMemo.Location = new System.Drawing.Point(109, 303);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(208, 22);
            this.txtMemo.TabIndex = 9;
            // 
            // txtSeq
            // 
            this.txtSeq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSeq.Location = new System.Drawing.Point(215, 274);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(44, 22);
            this.txtSeq.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(215, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 21);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "離開";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // lbEmp
            // 
            this.lbEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmp.AutoSize = true;
            this.lbEmp.ForeColor = System.Drawing.Color.Black;
            this.lbEmp.Location = new System.Drawing.Point(50, 129);
            this.lbEmp.Name = "lbEmp";
            this.lbEmp.Size = new System.Drawing.Size(53, 12);
            this.lbEmp.TabIndex = 16;
            this.lbEmp.Text = "員工編號";
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnEmp, 2);
            this.btnEmp.Location = new System.Drawing.Point(109, 124);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(208, 21);
            this.btnEmp.TabIndex = 2;
            this.btnEmp.Text = "請選擇需設定的人員";
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.btnMaternityCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbABYYMM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudABYYYY, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbOUTCD, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOUTCD, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMaternityCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.lbMemo, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtMemo, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtEnrichYYMM, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbEnrichYYMM, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtSeq, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbABSALCODE, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbxABSALCODE, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbExEmp, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnExEmp, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbSalBasd, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnSalBasd, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbBonusDays, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.nudBonusDays, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbEmp, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbRateHCode, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEmp, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnRateHCode, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 363);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnMaternityCode
            // 
            this.btnMaternityCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnMaternityCode, 2);
            this.btnMaternityCode.Location = new System.Drawing.Point(109, 64);
            this.btnMaternityCode.Name = "btnMaternityCode";
            this.btnMaternityCode.Size = new System.Drawing.Size(208, 21);
            this.btnMaternityCode.TabIndex = 26;
            this.btnMaternityCode.Text = "指定分娩假別代碼";
            this.btnMaternityCode.UseVisualStyleBackColor = true;
            // 
            // lbOUTCD
            // 
            this.lbOUTCD.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbOUTCD.AutoSize = true;
            this.lbOUTCD.ForeColor = System.Drawing.Color.Black;
            this.lbOUTCD.Location = new System.Drawing.Point(26, 39);
            this.lbOUTCD.Name = "lbOUTCD";
            this.lbOUTCD.Size = new System.Drawing.Size(77, 12);
            this.lbOUTCD.TabIndex = 24;
            this.lbOUTCD.Text = "離職原因照發";
            // 
            // btnOUTCD
            // 
            this.btnOUTCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnOUTCD, 2);
            this.btnOUTCD.Location = new System.Drawing.Point(109, 34);
            this.btnOUTCD.Name = "btnOUTCD";
            this.btnOUTCD.Size = new System.Drawing.Size(208, 21);
            this.btnOUTCD.TabIndex = 1;
            this.btnOUTCD.Text = "指定離職原因代碼";
            this.btnOUTCD.UseVisualStyleBackColor = true;
            this.btnOUTCD.Leave += new System.EventHandler(this.btnOUTCD_Leave);
            // 
            // lbMaternityCode
            // 
            this.lbMaternityCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMaternityCode.AutoSize = true;
            this.lbMaternityCode.ForeColor = System.Drawing.Color.Black;
            this.lbMaternityCode.Location = new System.Drawing.Point(26, 69);
            this.lbMaternityCode.Name = "lbMaternityCode";
            this.lbMaternityCode.Size = new System.Drawing.Size(77, 12);
            this.lbMaternityCode.TabIndex = 25;
            this.lbMaternityCode.Text = "分娩假別代碼";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(109, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 21);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "執行";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbExEmp
            // 
            this.lbExEmp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbExEmp.AutoSize = true;
            this.lbExEmp.ForeColor = System.Drawing.Color.Black;
            this.lbExEmp.Location = new System.Drawing.Point(26, 219);
            this.lbExEmp.Name = "lbExEmp";
            this.lbExEmp.Size = new System.Drawing.Size(77, 12);
            this.lbExEmp.TabIndex = 22;
            this.lbExEmp.Text = "比例例外員工";
            // 
            // btnExEmp
            // 
            this.btnExEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnExEmp, 2);
            this.btnExEmp.Location = new System.Drawing.Point(109, 214);
            this.btnExEmp.Name = "btnExEmp";
            this.btnExEmp.Size = new System.Drawing.Size(208, 21);
            this.btnExEmp.TabIndex = 5;
            this.btnExEmp.Text = "比例配發例外人員";
            this.btnExEmp.UseVisualStyleBackColor = true;
            this.btnExEmp.Click += new System.EventHandler(this.btnExEmp_Click);
            // 
            // lbSalBasd
            // 
            this.lbSalBasd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSalBasd.AutoSize = true;
            this.lbSalBasd.ForeColor = System.Drawing.Color.Black;
            this.lbSalBasd.Location = new System.Drawing.Point(26, 189);
            this.lbSalBasd.Name = "lbSalBasd";
            this.lbSalBasd.Size = new System.Drawing.Size(77, 12);
            this.lbSalBasd.TabIndex = 20;
            this.lbSalBasd.Text = "指定基本薪資";
            // 
            // btnSalBasd
            // 
            this.btnSalBasd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnSalBasd, 2);
            this.btnSalBasd.Location = new System.Drawing.Point(109, 184);
            this.btnSalBasd.Name = "btnSalBasd";
            this.btnSalBasd.Size = new System.Drawing.Size(208, 21);
            this.btnSalBasd.TabIndex = 4;
            this.btnSalBasd.Text = "選取基本薪資代碼";
            this.btnSalBasd.UseVisualStyleBackColor = true;
            // 
            // lbBonusDays
            // 
            this.lbBonusDays.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbBonusDays.AutoSize = true;
            this.lbBonusDays.ForeColor = System.Drawing.Color.Black;
            this.lbBonusDays.Location = new System.Drawing.Point(26, 159);
            this.lbBonusDays.Name = "lbBonusDays";
            this.lbBonusDays.Size = new System.Drawing.Size(77, 12);
            this.lbBonusDays.TabIndex = 18;
            this.lbBonusDays.Text = "發放年獎天數";
            // 
            // nudBonusDays
            // 
            this.nudBonusDays.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudBonusDays.Location = new System.Drawing.Point(109, 154);
            this.nudBonusDays.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudBonusDays.Name = "nudBonusDays";
            this.nudBonusDays.Size = new System.Drawing.Size(100, 22);
            this.nudBonusDays.TabIndex = 3;
            this.nudBonusDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBonusDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lbRateHCode
            // 
            this.lbRateHCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRateHCode.AutoSize = true;
            this.lbRateHCode.ForeColor = System.Drawing.Color.Black;
            this.lbRateHCode.Location = new System.Drawing.Point(26, 99);
            this.lbRateHCode.Name = "lbRateHCode";
            this.lbRateHCode.Size = new System.Drawing.Size(77, 12);
            this.lbRateHCode.TabIndex = 27;
            this.lbRateHCode.Text = "請假改發比例";
            // 
            // btnRateHCode
            // 
            this.btnRateHCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnRateHCode, 2);
            this.btnRateHCode.Location = new System.Drawing.Point(109, 94);
            this.btnRateHCode.Name = "btnRateHCode";
            this.btnRateHCode.Size = new System.Drawing.Size(208, 21);
            this.btnRateHCode.TabIndex = 28;
            this.btnRateHCode.Text = "指定改發比例假別";
            this.btnRateHCode.UseVisualStyleBackColor = true;
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // Hunya_ABPersonalBonus_Calculator
            // 
            this.ClientSize = new System.Drawing.Size(344, 401);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "Hunya_ABPersonalBonus_Calculator";
            this.Text = "Hunya_ABPersonalBonus_Calculate";
            this.Load += new System.EventHandler(this.Hunya_ABPersonalBonus_Calculator_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudABYYYY)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonusDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelSplit;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabelProcess;
        private System.Windows.Forms.ComboBox cbxABSALCODE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbABYYMM;
        private System.Windows.Forms.Label lbABSALCODE;
        private System.Windows.Forms.Label lbEnrichYYMM;
        private System.Windows.Forms.TextBox txtEnrichYYMM;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudABYYYY;
        private System.Windows.Forms.Label lbEmp;
        private System.Windows.Forms.Button btnEmp;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Button btnOUTCD;
        private System.Windows.Forms.Button btnExEmp;
        private System.Windows.Forms.Button btnSalBasd;
        private System.Windows.Forms.Label lbBonusDays;
        private System.Windows.Forms.NumericUpDown nudBonusDays;
        private System.Windows.Forms.Label lbSalBasd;
        private System.Windows.Forms.Label lbExEmp;
        private System.Windows.Forms.Label lbOUTCD;
        private System.Windows.Forms.Button btnMaternityCode;
        private System.Windows.Forms.Label lbMaternityCode;
        private System.Windows.Forms.Label lbRateHCode;
        private System.Windows.Forms.Button btnRateHCode;
    }
}
