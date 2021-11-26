namespace JBHR.Att
{
    partial class FRM24F
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM24F));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new JBControls.DataGridView();
            this.fOODCARDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImportCard = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCode = new JBControls.TextBox();
            this.txtCardNO = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.bsBASE = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.txtAdate = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkNoTran = new JBControls.CheckBox();
            this.txtOntime = new JBControls.TextBox();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.txtTemperature = new JBControls.TextBox();
            this.fdc = new JBControls.FullDataCtrl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.taBASE = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.fOOD_CARDTableAdapter = new JBHR.Att.dsAttTableAdapters.FOOD_CARDTableAdapter();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_NO_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oNTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTTRANDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fOODCARDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOBRDataGridViewTextBoxColumn,
            this.NAME_C,
            this.D_NO_DISP,
            this.D_NAME,
            this.cODEDataGridViewTextBoxColumn,
            this.aDATEDataGridViewTextBoxColumn,
            this.oNTIMEDataGridViewTextBoxColumn,
            this.cARDNODataGridViewTextBoxColumn,
            this.temperature,
            this.nOTTRANDataGridViewCheckBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.fOODCARDBindingSource;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDoubleClick);
            // 
            // fOODCARDBindingSource
            // 
            this.fOODCARDBindingSource.DataMember = "FOOD_CARD";
            this.fOODCARDBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.plFV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fdc);
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.button1);
            this.plFV.Controls.Add(this.btnImportCard);
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.plFV, "plFV");
            this.plFV.Name = "plFV";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImportCard
            // 
            resources.ApplyResources(this.btnImportCard, "btnImportCard");
            this.btnImportCard.Name = "btnImportCard";
            this.btnImportCard.TabStop = false;
            this.btnImportCard.UseVisualStyleBackColor = true;
            this.btnImportCard.Click += new System.EventHandler(this.btnImportCard_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCardNO, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkNoTran, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOntime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbTemperature, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTemperature, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // txtCode
            // 
            resources.ApplyResources(this.txtCode, "txtCode");
            this.txtCode.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCode.CaptionLabel = null;
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fOODCARDBindingSource, "CODE", true));
            this.txtCode.DecimalPlace = 2;
            this.txtCode.IsEmpty = true;
            this.txtCode.Mask = "";
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.ReadOnly = false;
            this.txtCode.ShowCalendarButton = true;
            this.txtCode.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtCardNO
            // 
            resources.ApplyResources(this.txtCardNO, "txtCardNO");
            this.txtCardNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCardNO.CaptionLabel = null;
            this.txtCardNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCardNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fOODCARDBindingSource, "CARDNO", true));
            this.txtCardNO.DecimalPlace = 2;
            this.txtCardNO.IsEmpty = true;
            this.txtCardNO.Mask = "";
            this.txtCardNO.MaxLength = 50;
            this.txtCardNO.Name = "txtCardNO";
            this.txtCardNO.PasswordChar = '\0';
            this.txtCardNO.ReadOnly = false;
            this.txtCardNO.ShowCalendarButton = true;
            this.txtCardNO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Name = "label5";
            // 
            // ptxNobr
            // 
            resources.ApplyResources(this.ptxNobr, "ptxNobr");
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.BackColor = System.Drawing.Color.White;
            this.ptxNobr.CaptionLabel = null;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fOODCARDBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.bsBASE;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // bsBASE
            // 
            this.bsBASE.DataMember = "BASE";
            this.bsBASE.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtAdate
            // 
            resources.ApplyResources(this.txtAdate, "txtAdate");
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = null;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fOODCARDBindingSource, "ADATE", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = false;
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // chkNoTran
            // 
            resources.ApplyResources(this.chkNoTran, "chkNoTran");
            this.chkNoTran.CaptionLabel = null;
            this.chkNoTran.IsImitateCaption = true;
            this.chkNoTran.Name = "chkNoTran";
            this.chkNoTran.TabStop = false;
            this.chkNoTran.UseVisualStyleBackColor = true;
            // 
            // txtOntime
            // 
            resources.ApplyResources(this.txtOntime, "txtOntime");
            this.txtOntime.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtOntime.CaptionLabel = null;
            this.txtOntime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOntime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fOODCARDBindingSource, "ONTIME", true));
            this.txtOntime.DecimalPlace = 2;
            this.txtOntime.IsEmpty = false;
            this.txtOntime.Mask = "0000";
            this.txtOntime.MaxLength = 50;
            this.txtOntime.Name = "txtOntime";
            this.txtOntime.PasswordChar = '\0';
            this.txtOntime.ReadOnly = false;
            this.txtOntime.ShowCalendarButton = true;
            this.txtOntime.ValidType = JBControls.TextBox.EValidType.String;
            this.txtOntime.Validating += new System.ComponentModel.CancelEventHandler(this.txtOntime_Validating);
            // 
            // lbTemperature
            // 
            resources.ApplyResources(this.lbTemperature, "lbTemperature");
            this.lbTemperature.ForeColor = System.Drawing.Color.Black;
            this.lbTemperature.Name = "lbTemperature";
            // 
            // txtTemperature
            // 
            resources.ApplyResources(this.txtTemperature, "txtTemperature");
            this.txtTemperature.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTemperature.CaptionLabel = null;
            this.txtTemperature.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTemperature.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fOODCARDBindingSource, "temperature", true));
            this.txtTemperature.DecimalPlace = 2;
            this.txtTemperature.IsEmpty = true;
            this.txtTemperature.Mask = "";
            this.txtTemperature.MaxLength = 50;
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.PasswordChar = '\0';
            this.txtTemperature.ReadOnly = false;
            this.txtTemperature.ShowCalendarButton = true;
            this.txtTemperature.ValidType = JBControls.TextBox.EValidType.String;
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
            this.fdc.DataSource = this.fOODCARDBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            resources.ApplyResources(this.fdc, "fdc");
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "nobr,adate,key_man";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.SortFields = "nobr,adate,key_man";
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeDel);
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
            // taBASE
            // 
            this.taBASE.ClearBeforeFill = true;
            // 
            // fOOD_CARDTableAdapter
            // 
            this.fOOD_CARDTableAdapter.ClearBeforeFill = true;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            resources.ApplyResources(this.nOBRDataGridViewTextBoxColumn, "nOBRDataGridViewTextBoxColumn");
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NAME_C
            // 
            this.NAME_C.DataPropertyName = "NAME_C";
            resources.ApplyResources(this.NAME_C, "NAME_C");
            this.NAME_C.Name = "NAME_C";
            this.NAME_C.ReadOnly = true;
            // 
            // D_NO_DISP
            // 
            this.D_NO_DISP.DataPropertyName = "D_NO_DISP";
            resources.ApplyResources(this.D_NO_DISP, "D_NO_DISP");
            this.D_NO_DISP.Name = "D_NO_DISP";
            this.D_NO_DISP.ReadOnly = true;
            // 
            // D_NAME
            // 
            this.D_NAME.DataPropertyName = "D_NAME";
            resources.ApplyResources(this.D_NAME, "D_NAME");
            this.D_NAME.Name = "D_NAME";
            this.D_NAME.ReadOnly = true;
            // 
            // cODEDataGridViewTextBoxColumn
            // 
            this.cODEDataGridViewTextBoxColumn.DataPropertyName = "CODE";
            resources.ApplyResources(this.cODEDataGridViewTextBoxColumn, "cODEDataGridViewTextBoxColumn");
            this.cODEDataGridViewTextBoxColumn.Name = "cODEDataGridViewTextBoxColumn";
            this.cODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            resources.ApplyResources(this.aDATEDataGridViewTextBoxColumn, "aDATEDataGridViewTextBoxColumn");
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oNTIMEDataGridViewTextBoxColumn
            // 
            this.oNTIMEDataGridViewTextBoxColumn.DataPropertyName = "ONTIME";
            resources.ApplyResources(this.oNTIMEDataGridViewTextBoxColumn, "oNTIMEDataGridViewTextBoxColumn");
            this.oNTIMEDataGridViewTextBoxColumn.Name = "oNTIMEDataGridViewTextBoxColumn";
            this.oNTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cARDNODataGridViewTextBoxColumn
            // 
            this.cARDNODataGridViewTextBoxColumn.DataPropertyName = "CARDNO";
            resources.ApplyResources(this.cARDNODataGridViewTextBoxColumn, "cARDNODataGridViewTextBoxColumn");
            this.cARDNODataGridViewTextBoxColumn.Name = "cARDNODataGridViewTextBoxColumn";
            this.cARDNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // temperature
            // 
            this.temperature.DataPropertyName = "temperature";
            resources.ApplyResources(this.temperature, "temperature");
            this.temperature.Name = "temperature";
            this.temperature.ReadOnly = true;
            // 
            // nOTTRANDataGridViewCheckBoxColumn
            // 
            this.nOTTRANDataGridViewCheckBoxColumn.DataPropertyName = "NOT_TRAN";
            resources.ApplyResources(this.nOTTRANDataGridViewCheckBoxColumn, "nOTTRANDataGridViewCheckBoxColumn");
            this.nOTTRANDataGridViewCheckBoxColumn.Name = "nOTTRANDataGridViewCheckBoxColumn";
            this.nOTTRANDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            resources.ApplyResources(this.kEYMANDataGridViewTextBoxColumn, "kEYMANDataGridViewTextBoxColumn");
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            resources.ApplyResources(this.kEYDATEDataGridViewTextBoxColumn, "kEYDATEDataGridViewTextBoxColumn");
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FRM24F
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM24F";
            this.Load += new System.EventHandler(this.FRM24F_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fOODCARDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private dsAtt dsAtt;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter taBASE;
        private System.Windows.Forms.BindingSource bsBASE;
        private dsBas dsBas;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtCode;
        private JBControls.TextBox txtCardNO;
        private JBControls.TextBox txtAdate;
        private JBControls.TextBox txtOntime;
        private JBControls.CheckBox chkNoTran;
        private System.Windows.Forms.BindingSource fOODCARDBindingSource;
        private dsAttTableAdapters.FOOD_CARDTableAdapter fOOD_CARDTableAdapter;
        private System.Windows.Forms.Button btnImportCard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTemperature;
        private JBControls.TextBox txtTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_NO_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oNTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperature;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nOTTRANDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}
