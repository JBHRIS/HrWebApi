
namespace JBHR.Bas
{
    partial class FRM1_BlackList
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
            this.lbName = new System.Windows.Forms.Label();
            this.basDS = new JBHR.Bas.BasDS();
            this.txtRemark = new JBControls.TextBox();
            this.HRblackListBS = new System.Windows.Forms.BindingSource(this.components);
            this.lbRemark = new System.Windows.Forms.Label();
            this.lbOUDT = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dataGridView1 = new JBControls.DataGridView();
            this.autoKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtOUDT = new JBControls.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbJOB = new System.Windows.Forms.Label();
            this.lbIDNO = new System.Windows.Forms.Label();
            this.txtName = new JBControls.TextBox();
            this.txtIDNO = new JBControls.TextBox();
            this.txtJOB = new JBControls.TextBox();
            this.lbReason = new System.Windows.Forms.Label();
            this.txtReason = new JBControls.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.hRBlackListTableAdapter = new JBHR.Bas.BasDSTableAdapters.HRBlackListTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRblackListBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.Color.Red;
            this.lbName.Location = new System.Drawing.Point(59, 19);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 12);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "姓名";
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRemark.CaptionLabel = null;
            this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtRemark, 4);
            this.txtRemark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HRblackListBS, "Remark", true));
            this.txtRemark.DecimalPlace = 2;
            this.txtRemark.IsEmpty = true;
            this.txtRemark.Location = new System.Drawing.Point(94, 134);
            this.txtRemark.Mask = "";
            this.txtRemark.MaxLength = 500;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PasswordChar = '\0';
            this.txtRemark.ReadOnly = false;
            this.txtRemark.ShowCalendarButton = true;
            this.txtRemark.Size = new System.Drawing.Size(638, 22);
            this.txtRemark.TabIndex = 6;
            this.txtRemark.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // HRblackListBS
            // 
            this.HRblackListBS.DataMember = "HRBlackList";
            this.HRblackListBS.DataSource = this.basDS;
            // 
            // lbRemark
            // 
            this.lbRemark.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRemark.AutoSize = true;
            this.lbRemark.ForeColor = System.Drawing.Color.Black;
            this.lbRemark.Location = new System.Drawing.Point(59, 139);
            this.lbRemark.Name = "lbRemark";
            this.lbRemark.Size = new System.Drawing.Size(29, 12);
            this.lbRemark.TabIndex = 28;
            this.lbRemark.Text = "備註";
            // 
            // lbOUDT
            // 
            this.lbOUDT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbOUDT.AutoSize = true;
            this.lbOUDT.ForeColor = System.Drawing.Color.Black;
            this.lbOUDT.Location = new System.Drawing.Point(35, 109);
            this.lbOUDT.Name = "lbOUDT";
            this.lbOUDT.Size = new System.Drawing.Size(53, 12);
            this.lbOUDT.TabIndex = 22;
            this.lbOUDT.Text = "離職日期";
            // 
            // fullDataCtrl1
            // 
            this.fullDataCtrl1.AllowModifyPrimaryKey = false;
            this.fullDataCtrl1.BindingCtrlsAutoInit = true;
            this.fullDataCtrl1.bnAddEnable = true;
            this.fullDataCtrl1.bnAddVisible = true;
            this.fullDataCtrl1.bnCancelEnable = true;
            this.fullDataCtrl1.bnCancelVisible = true;
            this.fullDataCtrl1.bnDelEnable = true;
            this.fullDataCtrl1.bnDelVisible = true;
            this.fullDataCtrl1.bnEditEnable = true;
            this.fullDataCtrl1.bnEditVisible = true;
            this.fullDataCtrl1.bnExportEnable = true;
            this.fullDataCtrl1.bnExportVisible = true;
            this.fullDataCtrl1.bnQueryEnable = true;
            this.fullDataCtrl1.bnQueryVisible = true;
            this.fullDataCtrl1.bnSaveEnable = true;
            this.fullDataCtrl1.bnSaveVisible = true;
            this.fullDataCtrl1.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fullDataCtrl1.DataAdapter = null;
            this.fullDataCtrl1.DataGrid = this.dataGridView1;
            this.fullDataCtrl1.DataSource = this.HRblackListBS;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 74);
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.autoKeyDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.iDNODataGridViewTextBoxColumn,
            this.jOBDataGridViewTextBoxColumn,
            this.reasonDataGridViewTextBoxColumn,
            this.oUDTDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.HRblackListBS;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(761, 181);
            this.dataGridView1.TabIndex = 10;
            // 
            // autoKeyDataGridViewTextBoxColumn
            // 
            this.autoKeyDataGridViewTextBoxColumn.DataPropertyName = "AutoKey";
            this.autoKeyDataGridViewTextBoxColumn.HeaderText = "AutoKey";
            this.autoKeyDataGridViewTextBoxColumn.Name = "autoKeyDataGridViewTextBoxColumn";
            this.autoKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.autoKeyDataGridViewTextBoxColumn.Visible = false;
            this.autoKeyDataGridViewTextBoxColumn.Width = 72;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDNODataGridViewTextBoxColumn
            // 
            this.iDNODataGridViewTextBoxColumn.DataPropertyName = "IDNO";
            this.iDNODataGridViewTextBoxColumn.HeaderText = "身分證號";
            this.iDNODataGridViewTextBoxColumn.MinimumWidth = 100;
            this.iDNODataGridViewTextBoxColumn.Name = "iDNODataGridViewTextBoxColumn";
            this.iDNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jOBDataGridViewTextBoxColumn
            // 
            this.jOBDataGridViewTextBoxColumn.DataPropertyName = "JOB";
            this.jOBDataGridViewTextBoxColumn.HeaderText = "職務";
            this.jOBDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.jOBDataGridViewTextBoxColumn.Name = "jOBDataGridViewTextBoxColumn";
            this.jOBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reasonDataGridViewTextBoxColumn
            // 
            this.reasonDataGridViewTextBoxColumn.DataPropertyName = "Reason";
            this.reasonDataGridViewTextBoxColumn.HeaderText = "原因";
            this.reasonDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.reasonDataGridViewTextBoxColumn.Name = "reasonDataGridViewTextBoxColumn";
            this.reasonDataGridViewTextBoxColumn.ReadOnly = true;
            this.reasonDataGridViewTextBoxColumn.Width = 200;
            // 
            // oUDTDataGridViewTextBoxColumn
            // 
            this.oUDTDataGridViewTextBoxColumn.DataPropertyName = "OUDT";
            this.oUDTDataGridViewTextBoxColumn.HeaderText = "離職日期";
            this.oUDTDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.oUDTDataGridViewTextBoxColumn.Name = "oUDTDataGridViewTextBoxColumn";
            this.oUDTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "備註";
            this.remarkDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarkDataGridViewTextBoxColumn.Width = 200;
            // 
            // keyDateDataGridViewTextBoxColumn
            // 
            this.keyDateDataGridViewTextBoxColumn.DataPropertyName = "Key_Date";
            this.keyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.keyDateDataGridViewTextBoxColumn.Name = "keyDateDataGridViewTextBoxColumn";
            this.keyDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDateDataGridViewTextBoxColumn.Width = 78;
            // 
            // keyManDataGridViewTextBoxColumn
            // 
            this.keyManDataGridViewTextBoxColumn.DataPropertyName = "Key_Man";
            this.keyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.keyManDataGridViewTextBoxColumn.Name = "keyManDataGridViewTextBoxColumn";
            this.keyManDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyManDataGridViewTextBoxColumn.Width = 66;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtOUDT
            // 
            this.txtOUDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOUDT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtOUDT.CaptionLabel = null;
            this.txtOUDT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOUDT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HRblackListBS, "OUDT", true));
            this.txtOUDT.DecimalPlace = 2;
            this.txtOUDT.IsEmpty = true;
            this.txtOUDT.Location = new System.Drawing.Point(94, 104);
            this.txtOUDT.Mask = "0000/00/00";
            this.txtOUDT.MaxLength = -1;
            this.txtOUDT.Name = "txtOUDT";
            this.txtOUDT.PasswordChar = '\0';
            this.txtOUDT.ReadOnly = false;
            this.txtOUDT.ShowCalendarButton = true;
            this.txtOUDT.Size = new System.Drawing.Size(100, 22);
            this.txtOUDT.TabIndex = 5;
            this.txtOUDT.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 178);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.93007F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.82518F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.230769F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.74126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbJOB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbIDNO, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbRemark, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtRemark, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDNO, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbOUDT, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtOUDT, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtJOB, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbReason, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtReason, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(757, 174);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // lbJOB
            // 
            this.lbJOB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbJOB.AutoSize = true;
            this.lbJOB.ForeColor = System.Drawing.Color.Black;
            this.lbJOB.Location = new System.Drawing.Point(59, 49);
            this.lbJOB.Name = "lbJOB";
            this.lbJOB.Size = new System.Drawing.Size(29, 12);
            this.lbJOB.TabIndex = 37;
            this.lbJOB.Text = "職務";
            // 
            // lbIDNO
            // 
            this.lbIDNO.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbIDNO.AutoSize = true;
            this.lbIDNO.ForeColor = System.Drawing.Color.Red;
            this.lbIDNO.Location = new System.Drawing.Point(207, 19);
            this.lbIDNO.Name = "lbIDNO";
            this.lbIDNO.Size = new System.Drawing.Size(53, 12);
            this.lbIDNO.TabIndex = 34;
            this.lbIDNO.Text = "身分證號";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtName.CaptionLabel = null;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HRblackListBS, "Name", true));
            this.txtName.DecimalPlace = 2;
            this.txtName.IsEmpty = true;
            this.txtName.Location = new System.Drawing.Point(94, 14);
            this.txtName.Mask = "";
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ReadOnly = false;
            this.txtName.ShowCalendarButton = true;
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 1;
            this.txtName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtIDNO
            // 
            this.txtIDNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtIDNO.CaptionLabel = null;
            this.txtIDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIDNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HRblackListBS, "IDNO", true));
            this.txtIDNO.DecimalPlace = 2;
            this.txtIDNO.IsEmpty = true;
            this.txtIDNO.Location = new System.Drawing.Point(266, 14);
            this.txtIDNO.Mask = "";
            this.txtIDNO.MaxLength = 50;
            this.txtIDNO.Name = "txtIDNO";
            this.txtIDNO.PasswordChar = '\0';
            this.txtIDNO.ReadOnly = false;
            this.txtIDNO.ShowCalendarButton = true;
            this.txtIDNO.Size = new System.Drawing.Size(128, 22);
            this.txtIDNO.TabIndex = 2;
            this.txtIDNO.ValidType = JBControls.TextBox.EValidType.String;
            this.txtIDNO.Leave += new System.EventHandler(this.txtIDNO_Leave);
            // 
            // txtJOB
            // 
            this.txtJOB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJOB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtJOB.CaptionLabel = null;
            this.txtJOB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtJOB, 3);
            this.txtJOB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HRblackListBS, "JOB", true));
            this.txtJOB.DecimalPlace = 2;
            this.txtJOB.IsEmpty = true;
            this.txtJOB.Location = new System.Drawing.Point(94, 44);
            this.txtJOB.Mask = "";
            this.txtJOB.MaxLength = 50;
            this.txtJOB.Name = "txtJOB";
            this.txtJOB.PasswordChar = '\0';
            this.txtJOB.ReadOnly = false;
            this.txtJOB.ShowCalendarButton = true;
            this.txtJOB.Size = new System.Drawing.Size(300, 22);
            this.txtJOB.TabIndex = 3;
            this.txtJOB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lbReason
            // 
            this.lbReason.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbReason.AutoSize = true;
            this.lbReason.ForeColor = System.Drawing.Color.Black;
            this.lbReason.Location = new System.Drawing.Point(59, 79);
            this.lbReason.Name = "lbReason";
            this.lbReason.Size = new System.Drawing.Size(29, 12);
            this.lbReason.TabIndex = 39;
            this.lbReason.Text = "原因";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtReason.CaptionLabel = null;
            this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtReason, 3);
            this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HRblackListBS, "Reason", true));
            this.txtReason.DecimalPlace = 2;
            this.txtReason.IsEmpty = true;
            this.txtReason.Location = new System.Drawing.Point(94, 74);
            this.txtReason.Mask = "";
            this.txtReason.MaxLength = 100;
            this.txtReason.Name = "txtReason";
            this.txtReason.PasswordChar = '\0';
            this.txtReason.ReadOnly = false;
            this.txtReason.ShowCalendarButton = true;
            this.txtReason.Size = new System.Drawing.Size(300, 22);
            this.txtReason.TabIndex = 4;
            this.txtReason.ValidType = JBControls.TextBox.EValidType.String;
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(761, 441);
            this.splitContainer1.SplitterDistance = 181;
            this.splitContainer1.TabIndex = 1;
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
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer2.Size = new System.Drawing.Size(761, 256);
            this.splitContainer2.SplitterDistance = 178;
            this.splitContainer2.TabIndex = 0;
            // 
            // hRBlackListTableAdapter
            // 
            this.hRBlackListTableAdapter.ClearBeforeFill = true;
            // 
            // FRM1_BlackList
            // 
            this.ClientSize = new System.Drawing.Size(761, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM1_BlackList";
            this.Load += new System.EventHandler(this.FRM1_BlackList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRblackListBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbName;
        private BasDS basDS;
        private JBControls.TextBox txtRemark;
        private System.Windows.Forms.Label lbRemark;
        private System.Windows.Forms.Label lbOUDT;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private JBControls.TextBox txtOUDT;
        private System.Windows.Forms.BindingSource HRblackListBS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbIDNO;
        private JBControls.TextBox txtName;
        private JBControls.TextBox txtIDNO;
        private System.Windows.Forms.Label lbJOB;
        private JBControls.TextBox txtJOB;
        private System.Windows.Forms.Label lbReason;
        private JBControls.TextBox txtReason;
        private BasDSTableAdapters.HRBlackListTableAdapter hRBlackListTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
    }
}
