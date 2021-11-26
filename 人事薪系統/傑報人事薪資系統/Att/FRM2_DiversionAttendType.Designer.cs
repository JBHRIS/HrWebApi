
namespace JBHR.Att
{
    partial class FRM2_DiversionAttendType
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDiversionAttendType = new JBControls.TextBox();
            this.bsDiversionAttendType = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.lbDiversionAttendType = new System.Windows.Forms.Label();
            this.txtDiversionAttendName = new JBControls.TextBox();
            this.lbDiversionAttendName = new System.Windows.Forms.Label();
            this.chkCheckWFH_Attend = new System.Windows.Forms.CheckBox();
            this.chkCheckWorkLog = new System.Windows.Forms.CheckBox();
            this.chkCheckWebCard = new System.Windows.Forms.CheckBox();
            this.chkCheckTemperoturyReport = new System.Windows.Forms.CheckBox();
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.diversionAttendTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diversionAttendTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkWFHAttendDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkWorkLogDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkWebCardDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkTemperoturyReportDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.diversionAttendTypeTableAdapter = new JBHR.Att.dsAttTableAdapters.DiversionAttendTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDiversionAttendType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.plFV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(736, 144);
            this.splitContainer2.SplitterDistance = 62;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(736, 62);
            this.plFV.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtDiversionAttendType, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDiversionAttendType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDiversionAttendName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDiversionAttendName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkCheckWFH_Attend, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCheckWorkLog, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkCheckWebCard, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCheckTemperoturyReport, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDiversionAttendType
            // 
            this.txtDiversionAttendType.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDiversionAttendType.CaptionLabel = null;
            this.txtDiversionAttendType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDiversionAttendType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDiversionAttendType, "DiversionAttendType", true));
            this.txtDiversionAttendType.DecimalPlace = 2;
            this.txtDiversionAttendType.IsEmpty = false;
            this.txtDiversionAttendType.Location = new System.Drawing.Point(161, 3);
            this.txtDiversionAttendType.Mask = "";
            this.txtDiversionAttendType.MaxLength = 50;
            this.txtDiversionAttendType.Name = "txtDiversionAttendType";
            this.txtDiversionAttendType.PasswordChar = '\0';
            this.txtDiversionAttendType.ReadOnly = false;
            this.txtDiversionAttendType.ShowCalendarButton = true;
            this.txtDiversionAttendType.Size = new System.Drawing.Size(122, 22);
            this.txtDiversionAttendType.TabIndex = 11;
            this.txtDiversionAttendType.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // bsDiversionAttendType
            // 
            this.bsDiversionAttendType.DataMember = "DiversionAttendType";
            this.bsDiversionAttendType.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbDiversionAttendType
            // 
            this.lbDiversionAttendType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDiversionAttendType.AutoSize = true;
            this.lbDiversionAttendType.ForeColor = System.Drawing.Color.Red;
            this.lbDiversionAttendType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDiversionAttendType.Location = new System.Drawing.Point(78, 8);
            this.lbDiversionAttendType.Name = "lbDiversionAttendType";
            this.lbDiversionAttendType.Size = new System.Drawing.Size(77, 12);
            this.lbDiversionAttendType.TabIndex = 0;
            this.lbDiversionAttendType.Text = "分流上班類別";
            // 
            // txtDiversionAttendName
            // 
            this.txtDiversionAttendName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDiversionAttendName.CaptionLabel = null;
            this.txtDiversionAttendName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDiversionAttendName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDiversionAttendType, "DiversionAttendTypeName", true));
            this.txtDiversionAttendName.DecimalPlace = 2;
            this.txtDiversionAttendName.IsEmpty = false;
            this.txtDiversionAttendName.Location = new System.Drawing.Point(161, 31);
            this.txtDiversionAttendName.Mask = "";
            this.txtDiversionAttendName.MaxLength = 50;
            this.txtDiversionAttendName.Name = "txtDiversionAttendName";
            this.txtDiversionAttendName.PasswordChar = '\0';
            this.txtDiversionAttendName.ReadOnly = false;
            this.txtDiversionAttendName.ShowCalendarButton = true;
            this.txtDiversionAttendName.Size = new System.Drawing.Size(122, 22);
            this.txtDiversionAttendName.TabIndex = 12;
            this.txtDiversionAttendName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lbDiversionAttendName
            // 
            this.lbDiversionAttendName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDiversionAttendName.AutoSize = true;
            this.lbDiversionAttendName.ForeColor = System.Drawing.Color.Red;
            this.lbDiversionAttendName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDiversionAttendName.Location = new System.Drawing.Point(54, 37);
            this.lbDiversionAttendName.Name = "lbDiversionAttendName";
            this.lbDiversionAttendName.Size = new System.Drawing.Size(101, 12);
            this.lbDiversionAttendName.TabIndex = 1;
            this.lbDiversionAttendName.Text = "分流上班類別名稱";
            // 
            // chkCheckWFH_Attend
            // 
            this.chkCheckWFH_Attend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCheckWFH_Attend.AutoSize = true;
            this.chkCheckWFH_Attend.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsDiversionAttendType, "CheckWFH_Attend", true));
            this.chkCheckWFH_Attend.Location = new System.Drawing.Point(299, 6);
            this.chkCheckWFH_Attend.Name = "chkCheckWFH_Attend";
            this.chkCheckWFH_Attend.Size = new System.Drawing.Size(96, 16);
            this.chkCheckWFH_Attend.TabIndex = 13;
            this.chkCheckWFH_Attend.TabStop = false;
            this.chkCheckWFH_Attend.Text = "檢核居家出勤";
            this.chkCheckWFH_Attend.UseVisualStyleBackColor = true;
            // 
            // chkCheckWorkLog
            // 
            this.chkCheckWorkLog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCheckWorkLog.AutoSize = true;
            this.chkCheckWorkLog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsDiversionAttendType, "CheckWorkLog", true));
            this.chkCheckWorkLog.Location = new System.Drawing.Point(299, 35);
            this.chkCheckWorkLog.Name = "chkCheckWorkLog";
            this.chkCheckWorkLog.Size = new System.Drawing.Size(96, 16);
            this.chkCheckWorkLog.TabIndex = 14;
            this.chkCheckWorkLog.TabStop = false;
            this.chkCheckWorkLog.Text = "檢核工作日誌";
            this.chkCheckWorkLog.UseVisualStyleBackColor = true;
            // 
            // chkCheckWebCard
            // 
            this.chkCheckWebCard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCheckWebCard.AutoSize = true;
            this.chkCheckWebCard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsDiversionAttendType, "CheckWebCard", true));
            this.chkCheckWebCard.Location = new System.Drawing.Point(437, 6);
            this.chkCheckWebCard.Name = "chkCheckWebCard";
            this.chkCheckWebCard.Size = new System.Drawing.Size(96, 16);
            this.chkCheckWebCard.TabIndex = 15;
            this.chkCheckWebCard.TabStop = false;
            this.chkCheckWebCard.Text = "檢核線上打卡";
            this.chkCheckWebCard.UseVisualStyleBackColor = true;
            // 
            // chkCheckTemperoturyReport
            // 
            this.chkCheckTemperoturyReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCheckTemperoturyReport.AutoSize = true;
            this.chkCheckTemperoturyReport.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsDiversionAttendType, "CheckTemperoturyReport", true));
            this.chkCheckTemperoturyReport.Location = new System.Drawing.Point(437, 35);
            this.chkCheckTemperoturyReport.Name = "chkCheckTemperoturyReport";
            this.chkCheckTemperoturyReport.Size = new System.Drawing.Size(96, 16);
            this.chkCheckTemperoturyReport.TabIndex = 16;
            this.chkCheckTemperoturyReport.TabStop = false;
            this.chkCheckTemperoturyReport.Text = "檢核溫度回報";
            this.chkCheckTemperoturyReport.UseVisualStyleBackColor = true;
            // 
            // fdc
            // 
            this.fdc.AllowModifyPrimaryKey = false;
            this.fdc.BindingCtrlsAutoInit = true;
            this.fdc.bnAddEnable = true;
            this.fdc.bnAddVisible = true;
            this.fdc.bnCancelEnable = true;
            this.fdc.bnCancelVisible = true;
            this.fdc.bnDelEnable = true;
            this.fdc.bnDelVisible = true;
            this.fdc.bnEditEnable = true;
            this.fdc.bnEditVisible = true;
            this.fdc.bnExportEnable = true;
            this.fdc.bnExportVisible = true;
            this.fdc.bnQueryEnable = true;
            this.fdc.bnQueryVisible = true;
            this.fdc.bnSaveEnable = true;
            this.fdc.bnSaveVisible = true;
            this.fdc.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fdc.DataAdapter = null;
            this.fdc.DataGrid = this.dgv;
            this.fdc.DataSource = this.bsDiversionAttendType;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(2, 2);
            this.fdc.Name = "fdc";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(632, 73);
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diversionAttendTypeDataGridViewTextBoxColumn,
            this.diversionAttendTypeNameDataGridViewTextBoxColumn,
            this.checkWFHAttendDataGridViewCheckBoxColumn,
            this.checkWorkLogDataGridViewCheckBoxColumn,
            this.checkWebCardDataGridViewCheckBoxColumn,
            this.checkTemperoturyReportDataGridViewCheckBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn,
            this.autoKeyDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.bsDiversionAttendType;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(736, 413);
            this.dgv.TabIndex = 7;
            // 
            // diversionAttendTypeDataGridViewTextBoxColumn
            // 
            this.diversionAttendTypeDataGridViewTextBoxColumn.DataPropertyName = "DiversionAttendType";
            this.diversionAttendTypeDataGridViewTextBoxColumn.HeaderText = "分流上班類別";
            this.diversionAttendTypeDataGridViewTextBoxColumn.Name = "diversionAttendTypeDataGridViewTextBoxColumn";
            this.diversionAttendTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diversionAttendTypeNameDataGridViewTextBoxColumn
            // 
            this.diversionAttendTypeNameDataGridViewTextBoxColumn.DataPropertyName = "DiversionAttendTypeName";
            this.diversionAttendTypeNameDataGridViewTextBoxColumn.HeaderText = "分流上班類別名稱";
            this.diversionAttendTypeNameDataGridViewTextBoxColumn.Name = "diversionAttendTypeNameDataGridViewTextBoxColumn";
            this.diversionAttendTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkWFHAttendDataGridViewCheckBoxColumn
            // 
            this.checkWFHAttendDataGridViewCheckBoxColumn.DataPropertyName = "CheckWFH_Attend";
            this.checkWFHAttendDataGridViewCheckBoxColumn.HeaderText = "檢核居家出勤";
            this.checkWFHAttendDataGridViewCheckBoxColumn.Name = "checkWFHAttendDataGridViewCheckBoxColumn";
            this.checkWFHAttendDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // checkWorkLogDataGridViewCheckBoxColumn
            // 
            this.checkWorkLogDataGridViewCheckBoxColumn.DataPropertyName = "CheckWorkLog";
            this.checkWorkLogDataGridViewCheckBoxColumn.HeaderText = "檢核工作日誌";
            this.checkWorkLogDataGridViewCheckBoxColumn.Name = "checkWorkLogDataGridViewCheckBoxColumn";
            this.checkWorkLogDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // checkWebCardDataGridViewCheckBoxColumn
            // 
            this.checkWebCardDataGridViewCheckBoxColumn.DataPropertyName = "CheckWebCard";
            this.checkWebCardDataGridViewCheckBoxColumn.HeaderText = "檢核線上打卡";
            this.checkWebCardDataGridViewCheckBoxColumn.Name = "checkWebCardDataGridViewCheckBoxColumn";
            this.checkWebCardDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // checkTemperoturyReportDataGridViewCheckBoxColumn
            // 
            this.checkTemperoturyReportDataGridViewCheckBoxColumn.DataPropertyName = "CheckTemperoturyReport";
            this.checkTemperoturyReportDataGridViewCheckBoxColumn.HeaderText = "檢核溫度回報";
            this.checkTemperoturyReportDataGridViewCheckBoxColumn.Name = "checkTemperoturyReportDataGridViewCheckBoxColumn";
            this.checkTemperoturyReportDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // keyDateDataGridViewTextBoxColumn
            // 
            this.keyDateDataGridViewTextBoxColumn.DataPropertyName = "KeyDate";
            this.keyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.keyDateDataGridViewTextBoxColumn.Name = "keyDateDataGridViewTextBoxColumn";
            this.keyDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyManDataGridViewTextBoxColumn
            // 
            this.keyManDataGridViewTextBoxColumn.DataPropertyName = "KeyMan";
            this.keyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.keyManDataGridViewTextBoxColumn.Name = "keyManDataGridViewTextBoxColumn";
            this.keyManDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // autoKeyDataGridViewTextBoxColumn
            // 
            this.autoKeyDataGridViewTextBoxColumn.DataPropertyName = "AutoKey";
            this.autoKeyDataGridViewTextBoxColumn.HeaderText = "AutoKey";
            this.autoKeyDataGridViewTextBoxColumn.Name = "autoKeyDataGridViewTextBoxColumn";
            this.autoKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.autoKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.HeaderText = "編號";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.ReadOnly = true;
            this.guidDataGridViewTextBoxColumn.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(736, 561);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 2;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // diversionAttendTypeTableAdapter
            // 
            this.diversionAttendTypeTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2_DiversionAttendType
            // 
            this.ClientSize = new System.Drawing.Size(736, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM2_DiversionAttendType";
            this.Text = "FRM2_DiversionAttendType";
            this.Load += new System.EventHandler(this.FRM2_DiversionAttendType_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDiversionAttendType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbDiversionAttendType;
        private System.Windows.Forms.Label lbDiversionAttendName;
        private JBControls.TextBox txtDiversionAttendType;
        private JBControls.TextBox txtDiversionAttendName;
        private JBControls.FullDataCtrl fdc;
        private JBControls.DataGridView dgv;
        private dsAtt dsAtt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bsDiversionAttendType;
        private dsAttTableAdapters.DiversionAttendTypeTableAdapter diversionAttendTypeTableAdapter;
        private System.Windows.Forms.CheckBox chkCheckWFH_Attend;
        private System.Windows.Forms.CheckBox chkCheckWorkLog;
        private System.Windows.Forms.CheckBox chkCheckWebCard;
        private System.Windows.Forms.CheckBox chkCheckTemperoturyReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn diversionAttendTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diversionAttendTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkWFHAttendDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkWorkLogDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkWebCardDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkTemperoturyReportDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
    }
}
