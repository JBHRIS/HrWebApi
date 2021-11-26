namespace JBHR.Att
{
    partial class FRM22
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new JBControls.DataGridView();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsBASE = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.cARDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tEMPSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCARDAPP = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCARDNO = new JBControls.TextBox();
            this.txtBDATE = new JBControls.TextBox();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new JBControls.CheckBox();
            this.txtEDATE = new JBControls.TextBox();
            this.fdc = new JBControls.FullDataCtrl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.taBASE = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.taCARDAPP = new JBHR.Att.dsAttTableAdapters.CARDAPPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCARDAPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
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
            this.nOBRDataGridViewTextBoxColumn,
            this.Column1,
            this.cARDNODataGridViewTextBoxColumn,
            this.bDATEDataGridViewTextBoxColumn,
            this.EDATE,
            this.tEMPSDataGridViewCheckBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.bsCARDAPP;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(626, 210);
            this.dgv.TabIndex = 7;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NOBR";
            this.Column1.DataSource = this.bsBASE;
            this.Column1.DisplayMember = "NAME_C";
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column1.HeaderText = "員工姓名";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.ValueMember = "NOBR";
            // 
            // bsBASE
            // 
            this.bsBASE.DataMember = "BASE";
            this.bsBASE.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cARDNODataGridViewTextBoxColumn
            // 
            this.cARDNODataGridViewTextBoxColumn.DataPropertyName = "CARDNO";
            this.cARDNODataGridViewTextBoxColumn.HeaderText = "刷卡卡號";
            this.cARDNODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cARDNODataGridViewTextBoxColumn.Name = "cARDNODataGridViewTextBoxColumn";
            this.cARDNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bDATEDataGridViewTextBoxColumn
            // 
            this.bDATEDataGridViewTextBoxColumn.DataPropertyName = "BDATE";
            this.bDATEDataGridViewTextBoxColumn.HeaderText = "生效日期";
            this.bDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.bDATEDataGridViewTextBoxColumn.Name = "bDATEDataGridViewTextBoxColumn";
            this.bDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // EDATE
            // 
            this.EDATE.DataPropertyName = "EDATE";
            this.EDATE.HeaderText = "失效日期";
            this.EDATE.MinimumWidth = 8;
            this.EDATE.Name = "EDATE";
            this.EDATE.ReadOnly = true;
            // 
            // tEMPSDataGridViewCheckBoxColumn
            // 
            this.tEMPSDataGridViewCheckBoxColumn.DataPropertyName = "TEMPS";
            this.tEMPSDataGridViewCheckBoxColumn.HeaderText = "臨時卡";
            this.tEMPSDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.tEMPSDataGridViewCheckBoxColumn.Name = "tEMPSDataGridViewCheckBoxColumn";
            this.tEMPSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsCARDAPP
            // 
            this.bsCARDAPP.DataMember = "CARDAPP";
            this.bsCARDAPP.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 227);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.tableLayoutPanel1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(626, 144);
            this.plFV.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCARDNO, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBDATE, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtEDATE, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "刷卡卡號";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "生效日期";
            // 
            // txtCARDNO
            // 
            this.txtCARDNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCARDNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCARDNO.CaptionLabel = this.label2;
            this.txtCARDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCARDNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARDAPP, "CARDNO", true));
            this.txtCARDNO.DecimalPlace = 2;
            this.txtCARDNO.IsEmpty = false;
            this.txtCARDNO.Location = new System.Drawing.Point(62, 31);
            this.txtCARDNO.Mask = "";
            this.txtCARDNO.MaxLength = 50;
            this.txtCARDNO.Name = "txtCARDNO";
            this.txtCARDNO.PasswordChar = '\0';
            this.txtCARDNO.ReadOnly = false;
            this.txtCARDNO.ShowCalendarButton = true;
            this.txtCARDNO.Size = new System.Drawing.Size(100, 22);
            this.txtCARDNO.TabIndex = 1;
            this.txtCARDNO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtBDATE
            // 
            this.txtBDATE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBDATE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBDATE.CaptionLabel = this.label3;
            this.txtBDATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBDATE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARDAPP, "BDATE", true));
            this.txtBDATE.DecimalPlace = 2;
            this.txtBDATE.IsEmpty = false;
            this.txtBDATE.Location = new System.Drawing.Point(62, 59);
            this.txtBDATE.Mask = "0000/00/00";
            this.txtBDATE.MaxLength = -1;
            this.txtBDATE.Name = "txtBDATE";
            this.txtBDATE.PasswordChar = '\0';
            this.txtBDATE.ReadOnly = false;
            this.txtBDATE.ShowCalendarButton = true;
            this.txtBDATE.Size = new System.Drawing.Size(100, 22);
            this.txtBDATE.TabIndex = 2;
            this.txtBDATE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARDAPP, "NOBR", true));
            this.ptxNobr.DataSource = this.bsBASE;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = false;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(62, 3);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(100, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.popupTextBox1_QueryCompleted);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "失效日期";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsCARDAPP, "TEMPS", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(62, 118);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "臨時卡";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtEDATE
            // 
            this.txtEDATE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEDATE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEDATE.CaptionLabel = this.label4;
            this.txtEDATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEDATE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCARDAPP, "EDATE", true));
            this.txtEDATE.DecimalPlace = 2;
            this.txtEDATE.IsEmpty = false;
            this.txtEDATE.Location = new System.Drawing.Point(62, 87);
            this.txtEDATE.Mask = "0000/00/00";
            this.txtEDATE.MaxLength = -1;
            this.txtEDATE.Name = "txtEDATE";
            this.txtEDATE.PasswordChar = '\0';
            this.txtEDATE.ReadOnly = false;
            this.txtEDATE.ShowCalendarButton = true;
            this.txtEDATE.Size = new System.Drawing.Size(100, 22);
            this.txtEDATE.TabIndex = 2;
            this.txtEDATE.ValidType = JBControls.TextBox.EValidType.Date;
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
            this.fdc.DataSource = this.bsCARDAPP;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(-1, 2);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "nobr,cardno,bdate,name_c";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 73);
            this.fdc.SortFields = "nobr,name_c,cardno,bdate,dept";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterEdit);
            this.fdc.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeDel);
            this.fdc.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterDel);
            this.fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeSave);
            this.fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterSave);
            this.fdc.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterCancel);
            this.fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterExport);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.bsCARDAPP;
            // 
            // taBASE
            // 
            this.taBASE.ClearBeforeFill = true;
            // 
            // taCARDAPP
            // 
            this.taCARDAPP.ClearBeforeFill = true;
            // 
            // FRM22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM22";
            this.Text = "FRM22";
            this.Load += new System.EventHandler(this.FRM22_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBASE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCARDAPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.Panel plFV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource bsCARDAPP;
        private JBHR.Att.dsAttTableAdapters.CARDAPPTableAdapter taCARDAPP;
        private JBControls.TextBox txtCARDNO;
        private JBControls.TextBox txtBDATE;
        private JBControls.CheckBox checkBox1;
        private JBControls.PopupTextBox ptxNobr;
        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bsBASE;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter taBASE;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtEDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDATE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tEMPSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}