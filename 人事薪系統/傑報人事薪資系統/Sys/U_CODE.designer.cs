namespace JBHR.Sys
{
	partial class U_CODE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(U_CODE));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.ptxPrg = new JBControls.PopupTextBox();
            this.uPRGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkOrder = new JBControls.CheckBox();
            this.checkBox1 = new JBControls.CheckBox();
            this.textBox7 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.aUTOKEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qFIELDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qATTRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qORDERDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fORMNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sYSTEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qLENSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qVARDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fIELD1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIELD2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.u_CODETableAdapter = new JBHR.Sys.SysDSTableAdapters.U_CODETableAdapter();
            this.u_PRGTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_PRGTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPRGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.ptxPrg);
            this.panel1.Controls.Add(this.chkOrder);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.uCODEBindingSource, "Q_ATTR", true));
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // uCODEBindingSource
            // 
            this.uCODEBindingSource.DataMember = "U_CODE";
            this.uCODEBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ptxPrg
            // 
            this.ptxPrg.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxPrg.CaptionLabel = null;
            this.ptxPrg.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxPrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uCODEBindingSource, "FORMNAME", true));
            this.ptxPrg.DataSource = this.uPRGBindingSource;
            this.ptxPrg.DisplayMember = "prog_name";
            this.ptxPrg.IsEmpty = true;
            this.ptxPrg.IsEmptyToQuery = true;
            this.ptxPrg.IsMustBeFound = true;
            this.ptxPrg.LabelText = "";
            resources.ApplyResources(this.ptxPrg, "ptxPrg");
            this.ptxPrg.Name = "ptxPrg";
            this.ptxPrg.ReadOnly = false;
            this.ptxPrg.ShowDisplayName = true;
            this.ptxPrg.ValueMember = "prog";
            this.ptxPrg.WhereCmd = "";
            // 
            // uPRGBindingSource
            // 
            this.uPRGBindingSource.DataMember = "U_PRG";
            this.uPRGBindingSource.DataSource = this.sysDS;
            // 
            // chkOrder
            // 
            resources.ApplyResources(this.chkOrder, "chkOrder");
            this.chkOrder.CaptionLabel = null;
            this.chkOrder.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uCODEBindingSource, "Q_ORDER", true));
            this.chkOrder.IsImitateCaption = true;
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.TabStop = false;
            this.chkOrder.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uCODEBindingSource, "Q_VAR", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.TabStop = false;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox7.CaptionLabel = this.label7;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uCODEBindingSource, "FIELD2", true));
            this.textBox7.DecimalPlace = 2;
            this.textBox7.IsEmpty = true;
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Mask = "";
            this.textBox7.MaxLength = 500;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.ReadOnly = false;
            this.textBox7.ShowCalendarButton = true;
            this.textBox7.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Name = "label7";
            // 
            // textBox6
            // 
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label6;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uCODEBindingSource, "FIELD1", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = true;
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = 500;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // textBox3
            // 
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uCODEBindingSource, "Q_FIELD", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // textBox4
            // 
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label4;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uCODEBindingSource, "Q_NAME", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = false;
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = 50;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uCODEBindingSource, "Q_CODE", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            this.fullDataCtrl1.DataGrid = this.dataGridViewEx1;
            this.fullDataCtrl1.DataSource = this.uCODEBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            resources.ApplyResources(this.fullDataCtrl1, "fullDataCtrl1");
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "user_id,name,system,workadr";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.SortFields = "user_id";
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterShow);
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aUTOKEYDataGridViewTextBoxColumn,
            this.qNAMEDataGridViewTextBoxColumn,
            this.qFIELDDataGridViewTextBoxColumn,
            this.qCODEDataGridViewTextBoxColumn,
            this.qATTRDataGridViewTextBoxColumn,
            this.qORDERDataGridViewCheckBoxColumn,
            this.fORMNAMEDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.sYSTEMDataGridViewTextBoxColumn,
            this.qLENSDataGridViewTextBoxColumn,
            this.qVARDataGridViewCheckBoxColumn,
            this.fIELD1DataGridViewTextBoxColumn,
            this.fIELD2DataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.uCODEBindingSource;
            resources.ApplyResources(this.dataGridViewEx1, "dataGridViewEx1");
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // aUTOKEYDataGridViewTextBoxColumn
            // 
            this.aUTOKEYDataGridViewTextBoxColumn.DataPropertyName = "AUTOKEY";
            resources.ApplyResources(this.aUTOKEYDataGridViewTextBoxColumn, "aUTOKEYDataGridViewTextBoxColumn");
            this.aUTOKEYDataGridViewTextBoxColumn.Name = "aUTOKEYDataGridViewTextBoxColumn";
            this.aUTOKEYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qNAMEDataGridViewTextBoxColumn
            // 
            this.qNAMEDataGridViewTextBoxColumn.DataPropertyName = "Q_NAME";
            resources.ApplyResources(this.qNAMEDataGridViewTextBoxColumn, "qNAMEDataGridViewTextBoxColumn");
            this.qNAMEDataGridViewTextBoxColumn.Name = "qNAMEDataGridViewTextBoxColumn";
            this.qNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qFIELDDataGridViewTextBoxColumn
            // 
            this.qFIELDDataGridViewTextBoxColumn.DataPropertyName = "Q_FIELD";
            resources.ApplyResources(this.qFIELDDataGridViewTextBoxColumn, "qFIELDDataGridViewTextBoxColumn");
            this.qFIELDDataGridViewTextBoxColumn.Name = "qFIELDDataGridViewTextBoxColumn";
            this.qFIELDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qCODEDataGridViewTextBoxColumn
            // 
            this.qCODEDataGridViewTextBoxColumn.DataPropertyName = "Q_CODE";
            resources.ApplyResources(this.qCODEDataGridViewTextBoxColumn, "qCODEDataGridViewTextBoxColumn");
            this.qCODEDataGridViewTextBoxColumn.Name = "qCODEDataGridViewTextBoxColumn";
            this.qCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qATTRDataGridViewTextBoxColumn
            // 
            this.qATTRDataGridViewTextBoxColumn.DataPropertyName = "Q_ATTR";
            resources.ApplyResources(this.qATTRDataGridViewTextBoxColumn, "qATTRDataGridViewTextBoxColumn");
            this.qATTRDataGridViewTextBoxColumn.Name = "qATTRDataGridViewTextBoxColumn";
            this.qATTRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qORDERDataGridViewCheckBoxColumn
            // 
            this.qORDERDataGridViewCheckBoxColumn.DataPropertyName = "Q_ORDER";
            resources.ApplyResources(this.qORDERDataGridViewCheckBoxColumn, "qORDERDataGridViewCheckBoxColumn");
            this.qORDERDataGridViewCheckBoxColumn.Name = "qORDERDataGridViewCheckBoxColumn";
            this.qORDERDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fORMNAMEDataGridViewTextBoxColumn
            // 
            this.fORMNAMEDataGridViewTextBoxColumn.DataPropertyName = "FORMNAME";
            resources.ApplyResources(this.fORMNAMEDataGridViewTextBoxColumn, "fORMNAMEDataGridViewTextBoxColumn");
            this.fORMNAMEDataGridViewTextBoxColumn.Name = "fORMNAMEDataGridViewTextBoxColumn";
            this.fORMNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            resources.ApplyResources(this.kEYDATEDataGridViewTextBoxColumn, "kEYDATEDataGridViewTextBoxColumn");
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            resources.ApplyResources(this.kEYMANDataGridViewTextBoxColumn, "kEYMANDataGridViewTextBoxColumn");
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sYSTEMDataGridViewTextBoxColumn
            // 
            this.sYSTEMDataGridViewTextBoxColumn.DataPropertyName = "SYSTEM";
            resources.ApplyResources(this.sYSTEMDataGridViewTextBoxColumn, "sYSTEMDataGridViewTextBoxColumn");
            this.sYSTEMDataGridViewTextBoxColumn.Name = "sYSTEMDataGridViewTextBoxColumn";
            this.sYSTEMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qLENSDataGridViewTextBoxColumn
            // 
            this.qLENSDataGridViewTextBoxColumn.DataPropertyName = "Q_LENS";
            resources.ApplyResources(this.qLENSDataGridViewTextBoxColumn, "qLENSDataGridViewTextBoxColumn");
            this.qLENSDataGridViewTextBoxColumn.Name = "qLENSDataGridViewTextBoxColumn";
            this.qLENSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qVARDataGridViewCheckBoxColumn
            // 
            this.qVARDataGridViewCheckBoxColumn.DataPropertyName = "Q_VAR";
            resources.ApplyResources(this.qVARDataGridViewCheckBoxColumn, "qVARDataGridViewCheckBoxColumn");
            this.qVARDataGridViewCheckBoxColumn.Name = "qVARDataGridViewCheckBoxColumn";
            this.qVARDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // fIELD1DataGridViewTextBoxColumn
            // 
            this.fIELD1DataGridViewTextBoxColumn.DataPropertyName = "FIELD1";
            resources.ApplyResources(this.fIELD1DataGridViewTextBoxColumn, "fIELD1DataGridViewTextBoxColumn");
            this.fIELD1DataGridViewTextBoxColumn.Name = "fIELD1DataGridViewTextBoxColumn";
            this.fIELD1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fIELD2DataGridViewTextBoxColumn
            // 
            this.fIELD2DataGridViewTextBoxColumn.DataPropertyName = "FIELD2";
            resources.ApplyResources(this.fIELD2DataGridViewTextBoxColumn, "fIELD2DataGridViewTextBoxColumn");
            this.fIELD2DataGridViewTextBoxColumn.Name = "fIELD2DataGridViewTextBoxColumn";
            this.fIELD2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fullDataCtrl1);
            // 
            // u_CODETableAdapter
            // 
            this.u_CODETableAdapter.ClearBeforeFill = true;
            // 
            // u_PRGTableAdapter
            // 
            this.u_PRGTableAdapter.ClearBeforeFill = true;
            // 
            // U_CODE
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "U_CODE";
            this.Load += new System.EventHandler(this.U_CODE_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPRGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
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

		private System.Windows.Forms.Panel panel1;
        private SysDS sysDS;
		private JBControls.DataGridView dataGridViewEx1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox4;
        private JBControls.TextBox textBox2;
        private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource uCODEBindingSource;
        private SysDSTableAdapters.U_CODETableAdapter u_CODETableAdapter;
        private JBControls.CheckBox chkOrder;
        private JBControls.CheckBox checkBox1;
        private JBControls.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn aUTOKEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qFIELDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qATTRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn qORDERDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sYSTEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qLENSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn qVARDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIELD1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIELD2DataGridViewTextBoxColumn;
        private JBControls.PopupTextBox ptxPrg;
        private System.Windows.Forms.BindingSource uPRGBindingSource;
        private SysDSTableAdapters.U_PRGTableAdapter u_PRGTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
	}
}