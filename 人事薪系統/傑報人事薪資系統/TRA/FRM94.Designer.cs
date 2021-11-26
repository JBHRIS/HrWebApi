namespace JBHR.TRA
{
    partial class FRM94
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.plFV = new System.Windows.Forms.Panel();
            this.bnIMPORT = new System.Windows.Forms.Button();
            this.ckKAVL = new System.Windows.Forms.CheckBox();
            this.tRCOSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.traDS1 = new JBHR.TRA.traDS1();
            this.cbCOURSE = new System.Windows.Forms.ComboBox();
            this.chkTR_REPO = new JBControls.CheckBox();
            this.chkCLOSE_ = new JBControls.CheckBox();
            this.txtST_HRS = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAT_HRS = new JBControls.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAPPLYNO = new JBControls.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTR_MEMO = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTR_ASDATE = new JBControls.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNobr = new JBControls.PopupTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.fdc = new JBControls.FullDataCtrl();
            this.dgv = new JBControls.DataGridView();
            this.AUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOURSEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tRCOSCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOBR_NAME = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aTHRSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ST_HRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPPLYNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLOSEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tRREPODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kAVLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tRASDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TR_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.tRCOSPTableAdapter = new JBHR.TRA.traDS1TableAdapters.TRCOSPTableAdapter();
            this.bASETableAdapter = new JBHR.Bas.BasDSTableAdapters.BASETableAdapter();
            this.tRCOSCTableAdapter = new JBHR.TRA.traDS1TableAdapters.TRCOSCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.plFV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRCOSPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRCOSCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            this.splitContainer2.Size = new System.Drawing.Size(640, 216);
            this.splitContainer2.SplitterDistance = 134;
            this.splitContainer2.TabIndex = 0;
            // 
            // plFV
            // 
            this.plFV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plFV.Controls.Add(this.bnIMPORT);
            this.plFV.Controls.Add(this.ckKAVL);
            this.plFV.Controls.Add(this.cbCOURSE);
            this.plFV.Controls.Add(this.chkTR_REPO);
            this.plFV.Controls.Add(this.chkCLOSE_);
            this.plFV.Controls.Add(this.txtST_HRS);
            this.plFV.Controls.Add(this.label2);
            this.plFV.Controls.Add(this.txtAT_HRS);
            this.plFV.Controls.Add(this.label12);
            this.plFV.Controls.Add(this.txtAPPLYNO);
            this.plFV.Controls.Add(this.label16);
            this.plFV.Controls.Add(this.txtTR_MEMO);
            this.plFV.Controls.Add(this.label4);
            this.plFV.Controls.Add(this.label7);
            this.plFV.Controls.Add(this.txtTR_ASDATE);
            this.plFV.Controls.Add(this.label22);
            this.plFV.Controls.Add(this.txtNobr);
            this.plFV.Controls.Add(this.label1);
            this.plFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFV.Location = new System.Drawing.Point(0, 0);
            this.plFV.Name = "plFV";
            this.plFV.Size = new System.Drawing.Size(640, 134);
            this.plFV.TabIndex = 1;
            // 
            // bnIMPORT
            // 
            this.bnIMPORT.Location = new System.Drawing.Point(551, 104);
            this.bnIMPORT.Name = "bnIMPORT";
            this.bnIMPORT.Size = new System.Drawing.Size(75, 23);
            this.bnIMPORT.TabIndex = 29;
            this.bnIMPORT.TabStop = false;
            this.bnIMPORT.Text = "匯入";
            this.bnIMPORT.UseVisualStyleBackColor = true;
            this.bnIMPORT.Click += new System.EventHandler(this.bnIMPORT_Click);
            // 
            // ckKAVL
            // 
            this.ckKAVL.AutoSize = true;
            this.ckKAVL.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tRCOSPBindingSource, "KAVL", true));
            this.ckKAVL.Location = new System.Drawing.Point(512, 66);
            this.ckKAVL.Name = "ckKAVL";
            this.ckKAVL.Size = new System.Drawing.Size(60, 16);
            this.ckKAVL.TabIndex = 28;
            this.ckKAVL.TabStop = false;
            this.ckKAVL.Text = "合格否";
            this.ckKAVL.UseVisualStyleBackColor = true;
            // 
            // tRCOSPBindingSource
            // 
            this.tRCOSPBindingSource.DataMember = "TRCOSP";
            this.tRCOSPBindingSource.DataSource = this.traDS1;
            // 
            // traDS1
            // 
            this.traDS1.DataSetName = "traDS1";
            this.traDS1.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.traDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbCOURSE
            // 
            this.cbCOURSE.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tRCOSPBindingSource, "COURSE", true));
            this.cbCOURSE.FormattingEnabled = true;
            this.cbCOURSE.Location = new System.Drawing.Point(69, 17);
            this.cbCOURSE.Name = "cbCOURSE";
            this.cbCOURSE.Size = new System.Drawing.Size(307, 20);
            this.cbCOURSE.TabIndex = 0;
            // 
            // chkTR_REPO
            // 
            this.chkTR_REPO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTR_REPO.AutoSize = true;
            this.chkTR_REPO.CaptionLabel = null;
            this.chkTR_REPO.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tRCOSPBindingSource, "TR_REPO", true));
            this.chkTR_REPO.IsImitateCaption = true;
            this.chkTR_REPO.Location = new System.Drawing.Point(512, 42);
            this.chkTR_REPO.Name = "chkTR_REPO";
            this.chkTR_REPO.Size = new System.Drawing.Size(72, 16);
            this.chkTR_REPO.TabIndex = 25;
            this.chkTR_REPO.TabStop = false;
            this.chkTR_REPO.Text = "完成評核";
            this.chkTR_REPO.UseVisualStyleBackColor = true;
            // 
            // chkCLOSE_
            // 
            this.chkCLOSE_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCLOSE_.AutoSize = true;
            this.chkCLOSE_.CaptionLabel = null;
            this.chkCLOSE_.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tRCOSPBindingSource, "CLOSE_", true));
            this.chkCLOSE_.IsImitateCaption = true;
            this.chkCLOSE_.Location = new System.Drawing.Point(512, 16);
            this.chkCLOSE_.Name = "chkCLOSE_";
            this.chkCLOSE_.Size = new System.Drawing.Size(48, 16);
            this.chkCLOSE_.TabIndex = 22;
            this.chkCLOSE_.TabStop = false;
            this.chkCLOSE_.Text = "結訓";
            this.chkCLOSE_.UseVisualStyleBackColor = true;
            // 
            // txtST_HRS
            // 
            this.txtST_HRS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtST_HRS.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtST_HRS.CaptionLabel = this.label2;
            this.txtST_HRS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtST_HRS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOSPBindingSource, "ST_HRS", true));
            this.txtST_HRS.DecimalPlace = 2;
            this.txtST_HRS.IsEmpty = true;
            this.txtST_HRS.Location = new System.Drawing.Point(69, 99);
            this.txtST_HRS.Mask = "";
            this.txtST_HRS.MaxLength = -1;
            this.txtST_HRS.Name = "txtST_HRS";
            this.txtST_HRS.PasswordChar = '\0';
            this.txtST_HRS.ReadOnly = false;
            this.txtST_HRS.ShowCalendarButton = true;
            this.txtST_HRS.Size = new System.Drawing.Size(71, 22);
            this.txtST_HRS.TabIndex = 5;
            this.txtST_HRS.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "已訓時數";
            // 
            // txtAT_HRS
            // 
            this.txtAT_HRS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAT_HRS.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAT_HRS.CaptionLabel = this.label12;
            this.txtAT_HRS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAT_HRS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOSPBindingSource, "AT_HRS", true));
            this.txtAT_HRS.DecimalPlace = 2;
            this.txtAT_HRS.IsEmpty = true;
            this.txtAT_HRS.Location = new System.Drawing.Point(69, 71);
            this.txtAT_HRS.Mask = "";
            this.txtAT_HRS.MaxLength = -1;
            this.txtAT_HRS.Name = "txtAT_HRS";
            this.txtAT_HRS.PasswordChar = '\0';
            this.txtAT_HRS.ReadOnly = false;
            this.txtAT_HRS.ShowCalendarButton = true;
            this.txtAT_HRS.Size = new System.Drawing.Size(71, 22);
            this.txtAT_HRS.TabIndex = 3;
            this.txtAT_HRS.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "缺課時數";
            // 
            // txtAPPLYNO
            // 
            this.txtAPPLYNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAPPLYNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAPPLYNO.CaptionLabel = this.label16;
            this.txtAPPLYNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAPPLYNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOSPBindingSource, "APPLYNO", true));
            this.txtAPPLYNO.DecimalPlace = 2;
            this.txtAPPLYNO.IsEmpty = true;
            this.txtAPPLYNO.Location = new System.Drawing.Point(276, 43);
            this.txtAPPLYNO.Mask = "";
            this.txtAPPLYNO.MaxLength = 50;
            this.txtAPPLYNO.Name = "txtAPPLYNO";
            this.txtAPPLYNO.PasswordChar = '\0';
            this.txtAPPLYNO.ReadOnly = false;
            this.txtAPPLYNO.ShowCalendarButton = true;
            this.txtAPPLYNO.Size = new System.Drawing.Size(100, 22);
            this.txtAPPLYNO.TabIndex = 2;
            this.txtAPPLYNO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(217, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 5;
            this.label16.Text = "申請編號";
            // 
            // txtTR_MEMO
            // 
            this.txtTR_MEMO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTR_MEMO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_MEMO.CaptionLabel = this.label4;
            this.txtTR_MEMO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_MEMO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOSPBindingSource, "TR_MEMO", true));
            this.txtTR_MEMO.DecimalPlace = 2;
            this.txtTR_MEMO.IsEmpty = true;
            this.txtTR_MEMO.Location = new System.Drawing.Point(275, 99);
            this.txtTR_MEMO.Mask = "";
            this.txtTR_MEMO.MaxLength = 200;
            this.txtTR_MEMO.Name = "txtTR_MEMO";
            this.txtTR_MEMO.PasswordChar = '\0';
            this.txtTR_MEMO.ReadOnly = false;
            this.txtTR_MEMO.ShowCalendarButton = true;
            this.txtTR_MEMO.Size = new System.Drawing.Size(195, 22);
            this.txtTR_MEMO.TabIndex = 6;
            this.txtTR_MEMO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(240, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "備註";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(10, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "課程名稱";
            // 
            // txtTR_ASDATE
            // 
            this.txtTR_ASDATE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTR_ASDATE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_ASDATE.CaptionLabel = this.label22;
            this.txtTR_ASDATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_ASDATE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOSPBindingSource, "TR_ASDATE", true));
            this.txtTR_ASDATE.DecimalPlace = 2;
            this.txtTR_ASDATE.IsEmpty = true;
            this.txtTR_ASDATE.Location = new System.Drawing.Point(276, 71);
            this.txtTR_ASDATE.Mask = "0000/00/00";
            this.txtTR_ASDATE.MaxLength = -1;
            this.txtTR_ASDATE.Name = "txtTR_ASDATE";
            this.txtTR_ASDATE.PasswordChar = '\0';
            this.txtTR_ASDATE.ReadOnly = false;
            this.txtTR_ASDATE.ShowCalendarButton = true;
            this.txtTR_ASDATE.Size = new System.Drawing.Size(100, 22);
            this.txtTR_ASDATE.TabIndex = 4;
            this.txtTR_ASDATE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(205, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 1;
            this.label22.Text = "完成評核日";
            // 
            // txtNobr
            // 
            this.txtNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNobr.BackColor = System.Drawing.SystemColors.Control;
            this.txtNobr.CaptionLabel = this.label1;
            this.txtNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOSPBindingSource, "NOBR", true));
            this.txtNobr.DataSource = this.vBASEBindingSource;
            this.txtNobr.DisplayMember = "name_c";
            this.txtNobr.IsEmpty = false;
            this.txtNobr.IsEmptyToQuery = true;
            this.txtNobr.IsMustBeFound = true;
            this.txtNobr.LabelText = "";
            this.txtNobr.Location = new System.Drawing.Point(69, 43);
            this.txtNobr.Name = "txtNobr";
            this.txtNobr.ReadOnly = false;
            this.txtNobr.ShowDisplayName = true;
            this.txtNobr.Size = new System.Drawing.Size(100, 22);
            this.txtNobr.TabIndex = 1;
            this.txtNobr.ValueMember = "nobr";
            this.txtNobr.WhereCmd = "";
            this.txtNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            this.txtNobr.Validated += new System.EventHandler(this.ptxNobr_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工代號";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.fdc.DataSource = this.tRCOSPBindingSource;
            this.fdc.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fdc.EnableAutoClone = false;
            this.fdc.GroupCmd = "";
            this.fdc.Location = new System.Drawing.Point(1, 2);
            this.fdc.Name = "fdc";
            this.fdc.QueryFields = "nobr,kavl";
            this.fdc.RecentQuerySql = "";
            this.fdc.SelectCmd = "";
            this.fdc.ShowExceptionMsg = true;
            this.fdc.Size = new System.Drawing.Size(635, 73);
            this.fdc.SortFields = "nobr,kavl";
            this.fdc.TabIndex = 0;
            this.fdc.WhereCmd = "";
            this.fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterAdd);
            this.fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fdc_AfterEdit);
            this.fdc.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fdc_BeforeDel);
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
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.AUTO,
            this.cOURSEDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.NOBR_NAME,
            this.aTHRSDataGridViewTextBoxColumn,
            this.ST_HRS,
            this.aPPLYNODataGridViewTextBoxColumn,
            this.cLOSEDataGridViewCheckBoxColumn,
            this.tRREPODataGridViewCheckBoxColumn,
            this.kAVLDataGridViewTextBoxColumn,
            this.tRASDATEDataGridViewTextBoxColumn,
            this.TR_MEMO,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv.DataSource = this.tRCOSPBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(640, 264);
            this.dgv.TabIndex = 7;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // AUTO
            // 
            this.AUTO.DataPropertyName = "AUTO";
            this.AUTO.HeaderText = "AUTO";
            this.AUTO.Name = "AUTO";
            this.AUTO.ReadOnly = true;
            this.AUTO.Visible = false;
            this.AUTO.Width = 54;
            // 
            // cOURSEDataGridViewTextBoxColumn
            // 
            this.cOURSEDataGridViewTextBoxColumn.DataPropertyName = "COURSE";
            this.cOURSEDataGridViewTextBoxColumn.DataSource = this.tRCOSCBindingSource;
            this.cOURSEDataGridViewTextBoxColumn.DisplayMember = "COURSE";
            this.cOURSEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.cOURSEDataGridViewTextBoxColumn.HeaderText = "課程名稱";
            this.cOURSEDataGridViewTextBoxColumn.Name = "cOURSEDataGridViewTextBoxColumn";
            this.cOURSEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOURSEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cOURSEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cOURSEDataGridViewTextBoxColumn.ValueMember = "GUID";
            this.cOURSEDataGridViewTextBoxColumn.Width = 78;
            // 
            // tRCOSCBindingSource
            // 
            this.tRCOSCBindingSource.DataMember = "TRCOSC";
            this.tRCOSCBindingSource.DataSource = this.traDS1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NOBR";
            this.dataGridViewTextBoxColumn1.HeaderText = "員工代號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // NOBR_NAME
            // 
            this.NOBR_NAME.DataPropertyName = "NOBR";
            this.NOBR_NAME.DataSource = this.vBASEBindingSource;
            this.NOBR_NAME.DisplayMember = "NAME_C";
            this.NOBR_NAME.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.NOBR_NAME.HeaderText = "姓名";
            this.NOBR_NAME.Name = "NOBR_NAME";
            this.NOBR_NAME.ReadOnly = true;
            this.NOBR_NAME.ValueMember = "NOBR";
            this.NOBR_NAME.Width = 35;
            // 
            // aTHRSDataGridViewTextBoxColumn
            // 
            this.aTHRSDataGridViewTextBoxColumn.DataPropertyName = "AT_HRS";
            this.aTHRSDataGridViewTextBoxColumn.HeaderText = "缺課時數";
            this.aTHRSDataGridViewTextBoxColumn.Name = "aTHRSDataGridViewTextBoxColumn";
            this.aTHRSDataGridViewTextBoxColumn.ReadOnly = true;
            this.aTHRSDataGridViewTextBoxColumn.Width = 78;
            // 
            // ST_HRS
            // 
            this.ST_HRS.DataPropertyName = "ST_HRS";
            this.ST_HRS.HeaderText = "已訓時數";
            this.ST_HRS.Name = "ST_HRS";
            this.ST_HRS.ReadOnly = true;
            this.ST_HRS.Width = 78;
            // 
            // aPPLYNODataGridViewTextBoxColumn
            // 
            this.aPPLYNODataGridViewTextBoxColumn.DataPropertyName = "APPLYNO";
            this.aPPLYNODataGridViewTextBoxColumn.HeaderText = "申請編號";
            this.aPPLYNODataGridViewTextBoxColumn.Name = "aPPLYNODataGridViewTextBoxColumn";
            this.aPPLYNODataGridViewTextBoxColumn.ReadOnly = true;
            this.aPPLYNODataGridViewTextBoxColumn.Width = 78;
            // 
            // cLOSEDataGridViewCheckBoxColumn
            // 
            this.cLOSEDataGridViewCheckBoxColumn.DataPropertyName = "CLOSE_";
            this.cLOSEDataGridViewCheckBoxColumn.HeaderText = "結訓";
            this.cLOSEDataGridViewCheckBoxColumn.Name = "cLOSEDataGridViewCheckBoxColumn";
            this.cLOSEDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cLOSEDataGridViewCheckBoxColumn.Width = 35;
            // 
            // tRREPODataGridViewCheckBoxColumn
            // 
            this.tRREPODataGridViewCheckBoxColumn.DataPropertyName = "TR_REPO";
            this.tRREPODataGridViewCheckBoxColumn.HeaderText = "完成評核";
            this.tRREPODataGridViewCheckBoxColumn.Name = "tRREPODataGridViewCheckBoxColumn";
            this.tRREPODataGridViewCheckBoxColumn.ReadOnly = true;
            this.tRREPODataGridViewCheckBoxColumn.Width = 59;
            // 
            // kAVLDataGridViewTextBoxColumn
            // 
            this.kAVLDataGridViewTextBoxColumn.DataPropertyName = "KAVL";
            this.kAVLDataGridViewTextBoxColumn.HeaderText = "合格否";
            this.kAVLDataGridViewTextBoxColumn.Name = "kAVLDataGridViewTextBoxColumn";
            this.kAVLDataGridViewTextBoxColumn.ReadOnly = true;
            this.kAVLDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.kAVLDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.kAVLDataGridViewTextBoxColumn.Width = 66;
            // 
            // tRASDATEDataGridViewTextBoxColumn
            // 
            this.tRASDATEDataGridViewTextBoxColumn.DataPropertyName = "TR_ASDATE";
            this.tRASDATEDataGridViewTextBoxColumn.HeaderText = "完成評核日";
            this.tRASDATEDataGridViewTextBoxColumn.Name = "tRASDATEDataGridViewTextBoxColumn";
            this.tRASDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRASDATEDataGridViewTextBoxColumn.Width = 90;
            // 
            // TR_MEMO
            // 
            this.TR_MEMO.DataPropertyName = "TR_MEMO";
            this.TR_MEMO.HeaderText = "備註";
            this.TR_MEMO.Name = "TR_MEMO";
            this.TR_MEMO.ReadOnly = true;
            this.TR_MEMO.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "KEY_DATE";
            this.dataGridViewTextBoxColumn2.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KEY_MAN";
            this.dataGridViewTextBoxColumn3.HeaderText = "建檔人員";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.basDSBindingSource;
            // 
            // basDSBindingSource
            // 
            this.basDSBindingSource.DataSource = this.basDS;
            this.basDSBindingSource.Position = 0;
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
            this.splitContainer1.Size = new System.Drawing.Size(640, 484);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 0;
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.basDS;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // tRCOSPTableAdapter
            // 
            this.tRCOSPTableAdapter.ClearBeforeFill = true;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // tRCOSCTableAdapter
            // 
            this.tRCOSCTableAdapter.ClearBeforeFill = true;
            // 
            // FRM94
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 484);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM94";
            this.Text = "FRM94";
            this.Load += new System.EventHandler(this.FRM94_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.plFV.ResumeLayout(false);
            this.plFV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRCOSPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRCOSCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDSBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        //private dsAtt dsAtt;
        //private dsBas dsBas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oNTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nOTTRANDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel plFV;
        private JBControls.TextBox txtTR_MEMO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private JBControls.PopupTextBox txtNobr;
        private JBControls.FullDataCtrl fdc;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtAT_HRS;
        private System.Windows.Forms.Label label12;
        private JBControls.TextBox txtAPPLYNO;
        private System.Windows.Forms.Label label16;
        private JBControls.TextBox txtTR_ASDATE;
        private System.Windows.Forms.Label label22;
        private JBControls.CheckBox chkTR_REPO;
        private JBControls.CheckBox chkCLOSE_;
        private System.Windows.Forms.BindingSource basDSBindingSource;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private Bas.BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private Bas.BasDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dEPTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aBSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRMENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRMENO1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALLEVELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALMENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCHLLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOSCODEDataGridViewTextBoxColumn;
        private traDS1 traDS1;
        private System.Windows.Forms.BindingSource tRCOSPBindingSource;
        private traDS1TableAdapters.TRCOSPTableAdapter tRCOSPTableAdapter;
        private System.Windows.Forms.ComboBox cbCOURSE;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private Bas.BasDSTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.CheckBox ckKAVL;
        private System.Windows.Forms.BindingSource tRCOSCBindingSource;
        private traDS1TableAdapters.TRCOSCTableAdapter tRCOSCTableAdapter;
        private JBControls.TextBox txtST_HRS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTO;
        private System.Windows.Forms.DataGridViewComboBoxColumn cOURSEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn NOBR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTHRSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ST_HRS;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPPLYNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cLOSEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tRREPODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kAVLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRASDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TR_MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button bnIMPORT;
    }
}