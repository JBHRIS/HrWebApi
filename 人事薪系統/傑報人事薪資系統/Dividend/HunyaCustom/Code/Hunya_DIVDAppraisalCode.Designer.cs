
namespace JBHR.Dividend.HunyaCustom.Code
{
    partial class Hunya_DIVDAppraisalCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new JBControls.DataGridView();
            this.aKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIVDAppraisalCodeDispDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIVDAppraisalCodeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIVDAppraisalCoefficientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyManDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIVDAppraisalCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hunya_Dividend = new JBHR.Dividend.HunyaCustom.Hunya_Dividend();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDIVDAppraisalCode_DISP = new JBControls.TextBox();
            this.lbDIVDAppraisalCode_DISP = new System.Windows.Forms.Label();
            this.lbDIVDAppraisalCoefficient = new System.Windows.Forms.Label();
            this.txtDIVDAppraisalCoefficient = new JBControls.TextBox();
            this.lbDIVDAppraisalCode_Name = new System.Windows.Forms.Label();
            this.txtDIVDAppraisalCode_Name = new JBControls.TextBox();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fdc = new JBControls.FullDataCtrl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.DIVDAppraisalCodeTableAdapter = new JBHR.Dividend.HunyaCustom.Hunya_DividendTableAdapters.Hunya_DIVDAppraisalCodeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIVDAppraisalCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Dividend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 441);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 5;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aKDataGridViewTextBoxColumn,
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn,
            this.dIVDAppraisalCodeDispDataGridViewTextBoxColumn,
            this.dIVDAppraisalCodeNameDataGridViewTextBoxColumn,
            this.dIVDAppraisalCoefficientDataGridViewTextBoxColumn,
            this.keyManDataGridViewTextBoxColumn,
            this.keyDateDataGridViewTextBoxColumn,
            this.gIDDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.DIVDAppraisalCodeBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(784, 266);
            this.dgv.TabIndex = 7;
            // 
            // aKDataGridViewTextBoxColumn
            // 
            this.aKDataGridViewTextBoxColumn.DataPropertyName = "AK";
            this.aKDataGridViewTextBoxColumn.HeaderText = "AK";
            this.aKDataGridViewTextBoxColumn.Name = "aKDataGridViewTextBoxColumn";
            this.aKDataGridViewTextBoxColumn.ReadOnly = true;
            this.aKDataGridViewTextBoxColumn.Visible = false;
            // 
            // dIVDAppraisalCodeDataGridViewTextBoxColumn
            // 
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn.DataPropertyName = "DIVDAppraisalCode";
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn.HeaderText = "DIVDAppraisalCode";
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn.Name = "dIVDAppraisalCodeDataGridViewTextBoxColumn";
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dIVDAppraisalCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // dIVDAppraisalCodeDispDataGridViewTextBoxColumn
            // 
            this.dIVDAppraisalCodeDispDataGridViewTextBoxColumn.DataPropertyName = "DIVDAppraisalCode_Disp";
            this.dIVDAppraisalCodeDispDataGridViewTextBoxColumn.HeaderText = "等第代碼";
            this.dIVDAppraisalCodeDispDataGridViewTextBoxColumn.Name = "dIVDAppraisalCodeDispDataGridViewTextBoxColumn";
            this.dIVDAppraisalCodeDispDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dIVDAppraisalCodeNameDataGridViewTextBoxColumn
            // 
            this.dIVDAppraisalCodeNameDataGridViewTextBoxColumn.DataPropertyName = "DIVDAppraisalCode_Name";
            this.dIVDAppraisalCodeNameDataGridViewTextBoxColumn.HeaderText = "等第名稱";
            this.dIVDAppraisalCodeNameDataGridViewTextBoxColumn.Name = "dIVDAppraisalCodeNameDataGridViewTextBoxColumn";
            this.dIVDAppraisalCodeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dIVDAppraisalCoefficientDataGridViewTextBoxColumn
            // 
            this.dIVDAppraisalCoefficientDataGridViewTextBoxColumn.DataPropertyName = "DIVDAppraisalCoefficient";
            this.dIVDAppraisalCoefficientDataGridViewTextBoxColumn.HeaderText = "等第係數";
            this.dIVDAppraisalCoefficientDataGridViewTextBoxColumn.Name = "dIVDAppraisalCoefficientDataGridViewTextBoxColumn";
            this.dIVDAppraisalCoefficientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyManDataGridViewTextBoxColumn
            // 
            this.keyManDataGridViewTextBoxColumn.DataPropertyName = "KeyMan";
            this.keyManDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.keyManDataGridViewTextBoxColumn.Name = "keyManDataGridViewTextBoxColumn";
            this.keyManDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyDateDataGridViewTextBoxColumn
            // 
            this.keyDateDataGridViewTextBoxColumn.DataPropertyName = "KeyDate";
            this.keyDateDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.keyDateDataGridViewTextBoxColumn.Name = "keyDateDataGridViewTextBoxColumn";
            this.keyDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gIDDataGridViewTextBoxColumn
            // 
            this.gIDDataGridViewTextBoxColumn.DataPropertyName = "GID";
            this.gIDDataGridViewTextBoxColumn.HeaderText = "GID";
            this.gIDDataGridViewTextBoxColumn.Name = "gIDDataGridViewTextBoxColumn";
            this.gIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.gIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // DIVDAppraisalCodeBindingSource
            // 
            this.DIVDAppraisalCodeBindingSource.DataMember = "Hunya_DIVDAppraisalCode";
            this.DIVDAppraisalCodeBindingSource.DataSource = this.hunya_Dividend;
            // 
            // hunya_Dividend
            // 
            this.hunya_Dividend.DataSetName = "Hunya_Dividend";
            this.hunya_Dividend.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            this.splitContainer2.Size = new System.Drawing.Size(784, 171);
            this.splitContainer2.SplitterDistance = 89;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(784, 89);
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
            this.tableLayoutPanel1.Controls.Add(this.txtDIVDAppraisalCode_DISP, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDIVDAppraisalCode_DISP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDIVDAppraisalCoefficient, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDIVDAppraisalCoefficient, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbDIVDAppraisalCode_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDIVDAppraisalCode_Name, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDIVDAppraisalCode_DISP
            // 
            this.txtDIVDAppraisalCode_DISP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDIVDAppraisalCode_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDIVDAppraisalCode_DISP.CaptionLabel = null;
            this.txtDIVDAppraisalCode_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDIVDAppraisalCode_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DIVDAppraisalCodeBindingSource, "DIVDAppraisalCode_Disp", true));
            this.txtDIVDAppraisalCode_DISP.DecimalPlace = 2;
            this.txtDIVDAppraisalCode_DISP.IsEmpty = false;
            this.txtDIVDAppraisalCode_DISP.Location = new System.Drawing.Point(171, 3);
            this.txtDIVDAppraisalCode_DISP.Mask = "";
            this.txtDIVDAppraisalCode_DISP.MaxLength = 50;
            this.txtDIVDAppraisalCode_DISP.Name = "txtDIVDAppraisalCode_DISP";
            this.txtDIVDAppraisalCode_DISP.PasswordChar = '\0';
            this.txtDIVDAppraisalCode_DISP.ReadOnly = false;
            this.txtDIVDAppraisalCode_DISP.ShowCalendarButton = true;
            this.txtDIVDAppraisalCode_DISP.Size = new System.Drawing.Size(116, 22);
            this.txtDIVDAppraisalCode_DISP.TabIndex = 0;
            this.txtDIVDAppraisalCode_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lbDIVDAppraisalCode_DISP
            // 
            this.lbDIVDAppraisalCode_DISP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDIVDAppraisalCode_DISP.AutoSize = true;
            this.lbDIVDAppraisalCode_DISP.ForeColor = System.Drawing.Color.Red;
            this.lbDIVDAppraisalCode_DISP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDIVDAppraisalCode_DISP.Location = new System.Drawing.Point(88, 8);
            this.lbDIVDAppraisalCode_DISP.Name = "lbDIVDAppraisalCode_DISP";
            this.lbDIVDAppraisalCode_DISP.Size = new System.Drawing.Size(77, 12);
            this.lbDIVDAppraisalCode_DISP.TabIndex = 0;
            this.lbDIVDAppraisalCode_DISP.Text = "考績等第代碼";
            // 
            // lbDIVDAppraisalCoefficient
            // 
            this.lbDIVDAppraisalCoefficient.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDIVDAppraisalCoefficient.AutoSize = true;
            this.lbDIVDAppraisalCoefficient.ForeColor = System.Drawing.Color.Red;
            this.lbDIVDAppraisalCoefficient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDIVDAppraisalCoefficient.Location = new System.Drawing.Point(88, 64);
            this.lbDIVDAppraisalCoefficient.Name = "lbDIVDAppraisalCoefficient";
            this.lbDIVDAppraisalCoefficient.Size = new System.Drawing.Size(77, 12);
            this.lbDIVDAppraisalCoefficient.TabIndex = 1;
            this.lbDIVDAppraisalCoefficient.Text = "考績等第係數";
            // 
            // txtDIVDAppraisalCoefficient
            // 
            this.txtDIVDAppraisalCoefficient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDIVDAppraisalCoefficient.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDIVDAppraisalCoefficient.CaptionLabel = null;
            this.txtDIVDAppraisalCoefficient.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDIVDAppraisalCoefficient.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DIVDAppraisalCodeBindingSource, "DIVDAppraisalCoefficient", true));
            this.txtDIVDAppraisalCoefficient.DecimalPlace = 2;
            this.txtDIVDAppraisalCoefficient.IsEmpty = false;
            this.txtDIVDAppraisalCoefficient.Location = new System.Drawing.Point(171, 59);
            this.txtDIVDAppraisalCoefficient.Mask = "";
            this.txtDIVDAppraisalCoefficient.MaxLength = -1;
            this.txtDIVDAppraisalCoefficient.Name = "txtDIVDAppraisalCoefficient";
            this.txtDIVDAppraisalCoefficient.PasswordChar = '\0';
            this.txtDIVDAppraisalCoefficient.ReadOnly = false;
            this.txtDIVDAppraisalCoefficient.ShowCalendarButton = true;
            this.txtDIVDAppraisalCoefficient.Size = new System.Drawing.Size(116, 22);
            this.txtDIVDAppraisalCoefficient.TabIndex = 2;
            this.txtDIVDAppraisalCoefficient.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // lbDIVDAppraisalCode_Name
            // 
            this.lbDIVDAppraisalCode_Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDIVDAppraisalCode_Name.AutoSize = true;
            this.lbDIVDAppraisalCode_Name.ForeColor = System.Drawing.Color.Red;
            this.lbDIVDAppraisalCode_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDIVDAppraisalCode_Name.Location = new System.Drawing.Point(88, 36);
            this.lbDIVDAppraisalCode_Name.Name = "lbDIVDAppraisalCode_Name";
            this.lbDIVDAppraisalCode_Name.Size = new System.Drawing.Size(77, 12);
            this.lbDIVDAppraisalCode_Name.TabIndex = 13;
            this.lbDIVDAppraisalCode_Name.Text = "考績等第名稱";
            // 
            // txtDIVDAppraisalCode_Name
            // 
            this.txtDIVDAppraisalCode_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDIVDAppraisalCode_Name.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDIVDAppraisalCode_Name.CaptionLabel = null;
            this.txtDIVDAppraisalCode_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDIVDAppraisalCode_Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DIVDAppraisalCodeBindingSource, "DIVDAppraisalCode_Name", true));
            this.txtDIVDAppraisalCode_Name.DecimalPlace = 2;
            this.txtDIVDAppraisalCode_Name.IsEmpty = false;
            this.txtDIVDAppraisalCode_Name.Location = new System.Drawing.Point(171, 31);
            this.txtDIVDAppraisalCode_Name.Mask = "";
            this.txtDIVDAppraisalCode_Name.MaxLength = 50;
            this.txtDIVDAppraisalCode_Name.Name = "txtDIVDAppraisalCode_Name";
            this.txtDIVDAppraisalCode_Name.PasswordChar = '\0';
            this.txtDIVDAppraisalCode_Name.ReadOnly = false;
            this.txtDIVDAppraisalCode_Name.ShowCalendarButton = true;
            this.txtDIVDAppraisalCode_Name.Size = new System.Drawing.Size(116, 22);
            this.txtDIVDAppraisalCode_Name.TabIndex = 1;
            this.txtDIVDAppraisalCode_Name.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(637, 5);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 4;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
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
            this.fdc.DataSource = this.DIVDAppraisalCodeBindingSource;
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
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // DIVDAppraisalCodeTableAdapter
            // 
            this.DIVDAppraisalCodeTableAdapter.ClearBeforeFill = true;
            // 
            // Hunya_DIVDAppraisalCode
            // 
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "Hunya_DIVDAppraisalCode";
            this.Text = "Hunya_DIVDAppraisalCode";
            this.Load += new System.EventHandler(this.Hunya_DIVDAppraisalCode_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIVDAppraisalCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hunya_Dividend)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.TextBox txtDIVDAppraisalCode_DISP;
        private System.Windows.Forms.Label lbDIVDAppraisalCode_DISP;
        private System.Windows.Forms.Label lbDIVDAppraisalCoefficient;
        private JBControls.TextBox txtDIVDAppraisalCoefficient;
        private System.Windows.Forms.Label lbDIVDAppraisalCode_Name;
        private JBControls.TextBox txtDIVDAppraisalCode_Name;
        private System.Windows.Forms.Button btnCodeGroup;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Hunya_Dividend hunya_Dividend;
        private System.Windows.Forms.DataGridViewTextBoxColumn aKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIVDAppraisalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIVDAppraisalCodeDispDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIVDAppraisalCodeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIVDAppraisalCoefficientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyManDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource DIVDAppraisalCodeBindingSource;
        private Hunya_DividendTableAdapters.Hunya_DIVDAppraisalCodeTableAdapter DIVDAppraisalCodeTableAdapter;
    }
}
